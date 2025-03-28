using PavlovReplayReader.Models;
using PavlovReplayReader.Models.NetFieldExports;
using PavlovReplayReader.Models.NetFieldExports.Weapons;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace PavlovReplayReader;

/// <summary>
/// Responsible for constructing the <see cref="PavlovReplay"/> out of the received exports.
/// </summary>
public class PavlovReplayBuilder
{
    private readonly GameData GameData = new();
    private readonly List<KillFeedEntry> KillFeed = new();

    private readonly Dictionary<uint, uint> _actorToChannel = new();
    private readonly Dictionary<uint, uint> _channelToActor = new();
    private readonly Dictionary<uint, uint> _pawnChannelToStateChannel = new();

    /// <summary>
    /// Sometimes we receive a PlayerPawn but we havent received the PlayerState yet, so we dont want to processes these yet.
    /// </summary>
    private readonly Dictionary<uint, List<QueuedPlayerPawn>> _queuedPlayerPawns = new();

    private readonly HashSet<uint> _onlySpectatingPlayers = new();
    private readonly Dictionary<uint, PlayerData> _players = new();
    private readonly Dictionary<int?, TeamData> _teams = new();

    private readonly Dictionary<uint, Inventory> _inventories = new();
    private readonly Dictionary<uint, WeaponData> _weapons = new();
    private readonly Dictionary<uint, WeaponData> _unknownWeapons = new();

    private float? ReplicatedWorldTimeSeconds = 0;
    private double? ReplicatedWorldTimeSecondsDouble = 0;

    public void AddActorChannel(uint channelIndex, uint guid)
    {
        _actorToChannel[guid] = channelIndex;
        _channelToActor[channelIndex] = guid;
    }

    public void RemoveChannel(uint channelIndex)
    {
        _weapons.Remove(channelIndex);
        _unknownWeapons.Remove(channelIndex);
    }

    /// <summary>
    /// Once a replay is fully parsed, add the data build over time to the replay.
    /// </summary>
    /// <param name="replay"></param>
    /// <returns>PavlovReplay</returns>
    public PavlovReplay Build(PavlovReplay replay)
    {
        UpdateTeamData();
        replay.GameData = GameData;
        replay.KillFeed = KillFeed;
        replay.TeamData = _teams.Values;
        replay.PlayerData = _players.Values;
        return replay;
    }

    private bool TryGetPlayerDataFromActor(uint guid, [NotNullWhen(returnValue: true)] out PlayerData? playerData)
    {
        if (_actorToChannel.TryGetValue(guid, out var pawnChannel))
        {
            if (_pawnChannelToStateChannel.TryGetValue(pawnChannel, out var stateChannel))
            {
                return _players.TryGetValue(stateChannel, out playerData);
            }
        }
        playerData = null;
        return false;
    }

    private bool TryGetPlayerDataFromPawn(uint pawn, [NotNullWhen(returnValue: true)] out PlayerData? playerData)
    {
        if (_pawnChannelToStateChannel.TryGetValue(pawn, out var stateChannel))
        {
            return _players.TryGetValue(stateChannel, out playerData);
        }
        playerData = null;
        return false;
    }

    private void HandleQueuedPlayerPawns(uint stateChannelIndex)
    {
        if (_channelToActor.TryGetValue(stateChannelIndex, out var actorId))
        {
            if (_queuedPlayerPawns.Remove(actorId, out var playerPawns))
            {
                foreach (var playerPawn in playerPawns)
                {
                    UpdatePlayerPawn(playerPawn.ChannelId, playerPawn.PlayerPawn);
                }
            }
        }
    }

    public void UpdateGameState(GameState state)
    {
        GameData.ReplicatedWorldTimeSeconds ??= state.ReplicatedWorldTimeSeconds;
        GameData.MatchState ??= state.MatchState?.Name;
        GameData.ElapsedTime ??= state.ElapsedTime;
        GameData.Team0Score ??= state.Team0Score;
        GameData.Team1Score ??= state.Team1Score;
        GameData.RoundTime ??= state.RoundTime;
        GameData.AttackingTeam ??= state.AttackingTeam;
        GameData.NameTagClass ??= state.NameTagClass?.ToString();
        GameData.bEnableProne ??= state.bEnableProne;
        GameData.bCanReviveEnemies ??= state.bCanReviveEnemies;
        GameData.GameModeType ??= state.GameModeType;
        GameData.AFKTimeLimit ??= state.AFKTimeLimit;
        GameData.BalancingCSV ??= state.BalancingCSV;
        GameData.SpawnableEquipment ??= state.SpawnableEquipment?.Select(i => i.Name);
        GameData.MaxPlayers ??= state.MaxPlayers;
        GameData.ModInitializers ??= state.ModInitializers?.Select(i => i.Name);
        GameData.ModId ??= state.ModId;
        GameData.ModPath ??= state.ModPath;
        GameData.GlobalInfo ??= state.GlobalInfo;
        GameData.bNoTeams ??= state.bNoTeams;
        GameData.bShowNameTags ??= state.bShowNameTags;
        GameData.BuyMenuScript ??= state.BuyMenuScript;
    }




    public void UpdatePrivateName(uint channelIndex, PlayerNameData playerNameData)
    {
        if (_players.TryGetValue(channelIndex, out var playerData))
        {
            playerData.PlayerName = playerNameData.DecodedName;
        }
    }

    //public void UpdatePlaylistInfo(PlaylistInfo playlist) => GameData.CurrentPlaylist ??= playlist.Name;

    //public void UpdateGameplayModifiers(ActiveGameplayModifier modifier) => GameData.ActiveGameplayModifiers.Add(modifier.ModifierDef?.Name);

    public void UpdateTeamData()
    {
        foreach (var playerData in _players.Values)
        {
            if (playerData?.TeamIndex == null)
            {
                continue;
            }

            if (!_teams.TryGetValue(playerData.TeamIndex, out var teamData))
            {
                _teams[playerData.TeamIndex] = new TeamData()
                {
                    TeamIndex = playerData.TeamIndex,
                    PlayerIds = new List<int?>() { playerData.Id },
                    PlayerNames = new List<string?>() { playerData.PlayerName ?? playerData.PlayerId },
                    Placement = playerData.Placement,
                    //PartyOwnerId = playerData.IsPartyLeader ? playerData.Id : null,
                    TeamKills = playerData.TeamKills
                };
                continue;
            }

            teamData.Placement ??= playerData.Placement;
            teamData.TeamKills ??= playerData.TeamKills;

            teamData.PlayerIds.Add(playerData.Id);
            teamData.PlayerNames.Add(playerData.PlayerName ?? playerData.PlayerId);
            //if (playerData.IsPartyLeader)
            //{
            //    teamData.PartyOwnerId = playerData.Id;
            //}
        }
    }

    public void UpdatePlayerState(uint channelIndex, PavlovPlayerState state)
    {
        if (state.bOnlySpectator == true)
        {
            _onlySpectatingPlayers.Add(channelIndex);
            return;
        }

        if (_onlySpectatingPlayers.Contains(channelIndex))
        {
            return;
        }

        var isNewPlayer = !_players.TryGetValue(channelIndex, out var playerData);

        if (isNewPlayer)
        {
            playerData = new PlayerData(state);
            _players[channelIndex] = playerData;
        }

        // Update player data with new state properties only if they are not null
        playerData.Id = state.PlayerId ?? playerData.Id;
        playerData.PlayerId = state.UniqueID ?? playerData.PlayerId;
        playerData.PlayerName = state.PlayerNamePrivate ?? playerData.PlayerName;
        playerData.TeamIndex = state.TeamId ?? playerData.TeamIndex;
        playerData.Kills = (uint?) state.Kills ?? playerData.Kills;
        playerData.Deaths = (uint?) state.Deaths ?? playerData.Deaths;
        playerData.Assists = (uint?) state.Assists ?? playerData.Assists;
        playerData.Cash = (uint?) state.Cash ?? playerData.Cash;
        playerData.PlatformId = state.PlatformId ?? playerData.PlatformId;
        playerData.bDead = state.bDead ?? playerData.bDead;
        playerData.PlayerHeight = state.PlayerHeight ?? playerData.PlayerHeight;
        playerData.bRightHanded = state.bRightHanded ?? playerData.bRightHanded;
        playerData.bVirtualStock = state.bVirtualStock ?? playerData.bVirtualStock;
        playerData.bSpeaking = state.bSpeaking ?? playerData.bSpeaking;
        playerData.LifetimeTeamKillCount = (uint?) state.LifetimeTeamKillCount ?? playerData.LifetimeTeamKillCount;
        playerData.SkinOverride = state.SkinOverride ?? playerData.SkinOverride;

        if (state.TeamId > 0)
        {
            playerData.TeamIndex = state.TeamId;
        }

        if (isNewPlayer)
        {
            HandleQueuedPlayerPawns(channelIndex);
        }
    }




    public void UpdateKillFeed(uint channelIndex, PlayerData data, GameState state)
    {
        var entry = new KillFeedEntry()
        {
            Killer = data.Instigator,
            Victim = (uint?) data.Id,
            DamageCauser = "placeholder",
            bHeadshot = data.bDead ?? false,
            KillerName = data.PlayerName,
            KillerTeamId = data.TeamIndex,
            KillerId = data.Instigator,
            VictimName = data.PlayerName,
            VictimTeamId = data.TeamIndex,
            VictimId = (uint?) data.Id,
            EntryLifespan = data.DeathTime ?? 0,
            bLocalPlayer = data.bSpeaking ?? false
        };

        KillFeed.Add(entry);
    }


    public void UpdatePlayerPawn(uint channelIndex, PlayerPawn pawn)
    {
        PlayerData playerState;

        if (pawn.PlayerState.HasValue)
        {
            // Update _pawnChannelToStateChannel every time we receive a PlayerState value for a given channel
            var actorId = pawn.PlayerState.Value;
            if (_actorToChannel.TryGetValue(actorId, out var stateChannelIndex))
            {
                _pawnChannelToStateChannel[channelIndex] = stateChannelIndex;
            }
            else
            {
                if (!_queuedPlayerPawns.TryGetValue(actorId, out var playerPawns))
                {
                    playerPawns = new List<QueuedPlayerPawn>();
                    _queuedPlayerPawns[actorId] = playerPawns;
                }

                playerPawns.Add(new QueuedPlayerPawn
                {
                    ChannelId = channelIndex,
                    PlayerPawn = pawn
                });

                return;
            }

            playerState = _players[stateChannelIndex];
        }
        else
        {
            if (!TryGetPlayerDataFromPawn(channelIndex, out playerState))
            {
                return;
            }
        }

        // Update player state with new pawn properties
        playerState.Instigator = pawn.Instigator;
        playerState.Controller = pawn.Controller;
        playerState.RevivePlayerState = pawn.RevivePlayerState;
        playerState.AvatarSkinClass = pawn.AvatarSkinClass;
        playerState.CustomMesh = pawn.CustomMesh;
        playerState.RadioChannel = pawn.RadioChannel;
        playerState.Armour = pawn.Armour;
        playerState.HelmetArmour = pawn.HelmetArmour;
        playerState.TeamId = pawn.TeamId;
        playerState.WorkshopProxy = pawn.WorkshopProxy;
        playerState.AvatarId = pawn.AvatarId;

        // Create a new PlayerMovement using explicit location and rotation fields
        var newMovement = new PlayerMovement
        {
            Location = pawn.Location,
            Location1 = pawn.Location1,
            Location2 = pawn.Location2,
            Location3 = pawn.Location3,
            Velocity = pawn.Velocity,
            Heading = pawn.Heading,
            Rotation = pawn.Rotation,
            Rotation1 = pawn.Rotation1,
            Rotation2 = pawn.Rotation2,
        };

        playerState.Locations.Add(newMovement);
    }






    public void UpdateInventory(uint channelIndex, FortInventory fortInventory)
    {
        if (!_inventories.TryGetValue(channelIndex, out var inventory))
        {
            // TODO updates for unknown parent inventory !?
            // TODO receive inventory for some random channel without replaypawn...?
            if (!fortInventory.ReplayPawn.HasValue)
            {
                return;
            }

            inventory = new Inventory()
            {
                Id = channelIndex,
                ReplayPawn = fortInventory.ReplayPawn
            };
            _inventories[channelIndex] = inventory;
        }

        if (fortInventory.ReplayPawn > 0)
        {
            inventory.ReplayPawn = fortInventory.ReplayPawn;
        }

        if (!inventory.PlayerId.HasValue)
        {
            if (TryGetPlayerDataFromActor(inventory.ReplayPawn.GetValueOrDefault(), out var playerData))
            {
                inventory.PlayerId = playerData.Id;
                inventory.PlayerName = playerData.PlayerId;
                //playerData.InventoryId = inventory.Id;
            }
        }

        if (!fortInventory.A.HasValue)
        {
            return;
        }

        var inventoryItem = new InventoryItem()
        {
            Count = fortInventory.Count,
            ItemDefinition = fortInventory.ItemDefinition?.Name,
            OrderIndex = fortInventory.OrderIndex,
            Durability = fortInventory.Durability,
            Level = fortInventory.Level,
            LoadedAmmo = fortInventory.LoadedAmmo,
            A = fortInventory.A,
            B = fortInventory.B,
            C = fortInventory.C,
            D = fortInventory.D
        };
        inventory.Items.Add(inventoryItem);
    }

    public void UpdateWeapon(uint channelIndex, BaseWeapon weapon)
    {
        if (!_weapons.TryGetValue(channelIndex, out var newWeapon))
        {
            if (!_unknownWeapons.TryGetValue(channelIndex, out newWeapon))
            {
                newWeapon = new WeaponData();
                _weapons[channelIndex] = newWeapon;
            }
            else
            {
                _unknownWeapons.Remove(channelIndex);
            }
        }

        newWeapon.bIsEquippingWeapon ??= weapon.bIsEquippingWeapon;
        newWeapon.bIsReloadingWeapon ??= weapon.bIsReloadingWeapon;
        newWeapon.WeaponLevel ??= weapon.WeaponLevel;
        newWeapon.AmmoCount ??= weapon.AmmoCount;
        newWeapon.LastFireTimeVerified ??= weapon.LastFireTimeVerified;
        newWeapon.A ??= weapon.A;
        newWeapon.B ??= weapon.B;
        newWeapon.C ??= weapon.C;
        newWeapon.D ??= weapon.D;
        newWeapon.WeaponName ??= weapon.WeaponData?.Name;
    }


    //public void UpdateExplosion(BroadcastExplosion explosion)
    //{
    //    // ¯\_(ツ)_/¯
    //}


    //public void UpdateGameplayCue(uint channelIndex, GameplayCue gameplayCue)
    //{
    //    // ¯\_(ツ)_/¯
    //}
}
