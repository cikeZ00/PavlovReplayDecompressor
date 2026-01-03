using System;
using System.Collections.Generic;
using System.Linq;
using PavlovReplayReader.Models;
using PavlovReplayReader.Models.NetFieldExports;
using PavlovReplayReader.Models.NetFieldExports.RPC;
using Unreal.Core.Contracts;
using Unreal.Core.Models;

namespace PavlovReplayReader;

/// <summary>
/// Responsible for constructing the <see cref="PavlovReplay"/> out of the received exports.
/// </summary>
public class PavlovReplayBuilder
{
    private readonly Dictionary<uint, INetFieldExportGroup> _channelToExportMap = new();
    private readonly Dictionary<string, int> _exportTypeCounts = new();
    private int _totalExportsProcessed = 0;
    private uint _maxChannelIndex = 0;
    private float _lastWorldTime = 0;
    private float _firstWorldTime = 0;  // Track first ReplicatedWorldTimeSeconds to calculate actual duration
    private bool _hasFirstWorldTime = false;  // Track if we've seen the first world time
    private int _frameCounter = 0;  // Frame counter for snapshot interval tracking
    private readonly Dictionary<uint, int> _lastSnapshotFrame = new();  // Per-pawn snapshot tracking
    
    /// <summary>
    /// Minimum time interval between snapshots in seconds.
    /// Set to 0 for every update, or higher values to reduce output size.
    /// </summary>
    public float SnapshotInterval { get; set; } = 0.1f;
    
    /// <summary>
    /// Whether to record timeline snapshots. Set to true for time-series data export.
    /// </summary>
    public bool RecordTimeline { get; set; } = false;

    // Core data
    private GameData? _gameData;
    private readonly Dictionary<uint, PlayerData> _players = new();
    
    // Pawn data
    private readonly Dictionary<uint, PawnData> _pawns = new();
    
    // Weapon data
    private readonly Dictionary<uint, WeaponData> _weapons = new();
    
    // Vehicle data
    private readonly Dictionary<uint, VehicleData> _vehicles = new();
    
    // Bomb data (S&D)
    private BombData? _bomb;
    private readonly List<BombSiteData> _bombSites = new();
    
    // Game mode specific data
    private GameModeData? _gameModeData;
    private readonly Dictionary<uint, TTTPlayerData> _tttPlayers = new();
    
    // Health components
    private readonly Dictionary<uint, HealthData> _healthComponents = new();
    
    // Timeline tracking
    private readonly Dictionary<uint, PawnTimeline> _pawnTimelines = new();
    private readonly List<GameEvent> _gameEvents = new();
    private int? _lastTeam0Score = null;
    private int? _lastTeam1Score = null;
    
    // Network GUID to channel index mapping for resolving PropertyObject references
    // PropertyObject fields like PlayerState, Owner, Controller are network GUIDs, not channel indices
    private readonly Dictionary<uint, uint> _guidToChannel = new();
    private readonly Dictionary<uint, uint> _channelToGuid = new();

    /// <summary>
    /// Called when a channel is opened with its actor GUID.
    /// Used to build GUID-to-channel mapping for resolving PropertyObject references.
    /// </summary>
    public void OnChannelOpened(uint channelIndex, uint actorGuid)
    {
        _guidToChannel[actorGuid] = channelIndex;
        _channelToGuid[channelIndex] = actorGuid;
    }
    
    /// <summary>
    /// Called when a channel is closed.
    /// </summary>
    public void OnChannelClosed(uint channelIndex, uint actorGuid)
    {
        // Keep mappings for later resolution - closed channels may still be referenced
    }
    
    /// <summary>
    /// Resolves a network GUID to a channel index.
    /// Returns null if the GUID is not found.
    /// </summary>
    private uint? ResolveGuidToChannel(uint? networkGuid)
    {
        if (networkGuid == null || networkGuid == 0)
            return null;
        
        return _guidToChannel.TryGetValue(networkGuid.Value, out var channelIndex) 
            ? channelIndex 
            : null;
    }

    /// <summary>
    /// Called when an export is read from the replay.
    /// </summary>
    public void OnExportRead(uint channelIndex, INetFieldExportGroup? exportGroup)
    {
        if (exportGroup == null)
            return;

        // Track statistics
        _totalExportsProcessed++;
        _frameCounter++;  // Increment frame counter for each export
        if (channelIndex > _maxChannelIndex)
            _maxChannelIndex = channelIndex;

        var typeName = exportGroup.GetType().Name;
        _exportTypeCounts.TryGetValue(typeName, out var count);
        _exportTypeCounts[typeName] = count + 1;

        // Store the export by channel for tracking
        _channelToExportMap[channelIndex] = exportGroup;

        // Route to appropriate handler based on export type
        switch (exportGroup)
        {
            // Game State
            case PavlovGameStateExport gameState:
                HandleGameState(gameState);
                break;
            
            // Player State
            case PavlovPlayerStateExport playerState:
                HandlePlayerState(channelIndex, playerState);
                break;
            
            // Pawn
            case PavlovPawnExport pawn:
                HandlePawn(channelIndex, pawn);
                break;
            
            // Controllers
            case PavlovControllerExport controller:
                HandleController(channelIndex, controller);
                break;
            
            // Weapons
            case VRGunExport gun:
                HandleGun(channelIndex, gun);
                break;
            case MagazineExport magazine:
                HandleMagazine(channelIndex, magazine);
                break;
            case VRGrenadeExport grenade:
                HandleGrenade(channelIndex, grenade);
                break;
            case VRKnifeExport knife:
                HandleKnife(channelIndex, knife);
                break;
            case VRLauncherExport launcher:
                HandleLauncher(channelIndex, launcher);
                break;
            
            // Vehicles
            case PavlovVehicleExport vehicle:
                HandleVehicle(channelIndex, vehicle);
                break;
            case PavlovTankExport tank:
                HandleTank(channelIndex, tank);
                break;
            
            // Bomb (S&D)
            case BombExport bomb:
                HandleBomb(channelIndex, bomb);
                break;
            case BombPlantSpotExport bombSite:
                HandleBombSite(channelIndex, bombSite);
                break;
            
            // Health components
            case VHealthComponentExport health:
                HandleHealthComponent(channelIndex, health);
                break;
            
            // Game mode specific states
            case TTTGameStateExport tttState:
                HandleTTTGameState(tttState);
                break;
            case TTTPlayerStateExport tttPlayer:
                HandleTTTPlayerState(channelIndex, tttPlayer);
                break;
            case ZombieCoopGameStateExport zombieState:
                HandleZombieCoopGameState(zombieState);
                break;
            case TheHiddenGameStateExport hiddenState:
                HandleTheHiddenGameState(hiddenState);
                break;
            case GunGameStateExport gunGameState:
                HandleGunGameState(gunGameState);
                break;
            case PropHuntGameStateExport propHuntState:
                HandlePropHuntGameState(propHuntState);
                break;
            case InfectionGameStateExport infectionState:
                HandleInfectionGameState(infectionState);
                break;
            case JailbreakGameStateExport jailbreakState:
                HandleJailbreakGameState(jailbreakState);
                break;
            
            // RPC Events - Kill feed
            case MulticastOnKillfeedEntry killfeed:
                HandleKillfeedRPC(channelIndex, killfeed);
                break;
            
            // RPC Events - Damage
            case MulticastOnImpactDamage damage:
                HandleImpactDamageRPC(channelIndex, damage);
                break;
            case MulticastOnHeadshot headshot:
                HandleHeadshotRPC(channelIndex, headshot);
                break;
            case MulticastOnHelmetHit helmetHit:
                HandleHelmetHitRPC(channelIndex, helmetHit);
                break;
            case MulticastOnRadialDeath radialDeath:
                HandleRadialDeathRPC(channelIndex, radialDeath);
                break;
            
            // RPC Events - Bomb
            case MulticastOnPlantStateChanged plantState:
                HandleBombPlantStateRPC(channelIndex, plantState);
                break;
            case MulticastOnEnterCode enterCode:
                HandleBombCodeRPC(channelIndex, enterCode);
                break;
            case MulticastOnDefuse defuse:
                HandleBombDefuseRPC(channelIndex);
                break;
            case MulticastOnDetonation bombDetonate:
                HandleBombDetonationRPC(channelIndex);
                break;
            
            // RPC Events - Grenades
            case GrenadeMulticastOnDetonation grenadeDetonate:
                HandleGrenadeDetonationRPC(channelIndex);
                break;
            case MulticastOnSafetyPinRemoved pinRemoved:
                HandleGrenadePinRemovedRPC(channelIndex);
                break;
            case MulticastOnReleaseSafetyLever leverReleased:
                HandleGrenadeLeverReleasedRPC(channelIndex);
                break;
            
            // RPC Events - Weapons
            case MulticastFire weaponFire:
                HandleWeaponFireRPC(channelIndex);
                break;
            
            // RPC Events - Knife
            case MulticastOnStab stab:
                HandleKnifeStabRPC(channelIndex, stab);
                break;
            
            // RPC Events - Health/Death
            case MulticastOnKilledWithData killedWithData:
                HandleKilledWithDataRPC(channelIndex, killedWithData);
                break;
            
            // Fallback for any GameState/PlayerState variants we might have missed
            default:
                HandleGenericExport(channelIndex, exportGroup);
                break;
        }
    }

    #region Game State Handlers

    private void HandleGameState(PavlovGameStateExport export)
    {
        _gameData ??= new GameData();
        
        // Track world time using ReplicatedWorldTimeSeconds (continuous world time)
        // ReplicatedWorldTimeSeconds is the actual continuous world time from the start of the replay
        if (export.ReplicatedWorldTimeSeconds.HasValue)
        {
            var worldTime = export.ReplicatedWorldTimeSeconds.Value;
            if (!_hasFirstWorldTime)
            {
                _firstWorldTime = worldTime;
                _hasFirstWorldTime = true;
            }
            _lastWorldTime = worldTime;
        }
        
        // Match state and timing
        if (export.RoundDuration.HasValue) _gameData.RoundDuration = export.RoundDuration;
        if (export.RoundTime.HasValue) _gameData.RoundTime = export.RoundTime;
        if (export.PauseTime.HasValue) _gameData.PauseTime = export.PauseTime;
        if (export.AttackingTeam.HasValue) _gameData.AttackingTeam = export.AttackingTeam;
        if (export.RoundWinner.HasValue) _gameData.RoundWinner = export.RoundWinner;
        if (export.RoundsLeft.HasValue) _gameData.RoundsLeft = export.RoundsLeft;
        if (export.bMatchTimePaused.HasValue) _gameData.bMatchTimePaused = export.bMatchTimePaused;
        if (export.MatchTime.HasValue) _gameData.MatchTime = export.MatchTime;
        
        // Get current relative time for events
        var currentTime = GetCurrentTime();
        
        // Note: Team0/Team1/Team2 player arrays are ignored - they contain object references
        // that can't be properly parsed. Team assignments are tracked via TeamId on each PlayerState.
        
        // Team scores - track changes for timeline
        if (export.Team0Score.HasValue) 
        {
            if (RecordTimeline && _lastTeam0Score != export.Team0Score)
            {
                _gameEvents.Add(new ScoreEvent
                {
                    Time = currentTime,
                    EventType = "ScoreChange",
                    Team0Score = export.Team0Score.Value,
                    Team1Score = export.Team1Score ?? _gameData.Team1Score ?? 0
                });
            }
            _lastTeam0Score = export.Team0Score;
            _gameData.Team0Score = export.Team0Score;
        }
        if (export.Team1Score.HasValue) 
        {
            if (RecordTimeline && _lastTeam1Score != export.Team1Score)
            {
                _gameEvents.Add(new ScoreEvent
                {
                    Time = currentTime,
                    EventType = "ScoreChange",
                    Team0Score = export.Team0Score ?? _gameData.Team0Score ?? 0,
                    Team1Score = export.Team1Score.Value
                });
            }
            _lastTeam1Score = export.Team1Score;
            _gameData.Team1Score = export.Team1Score;
        }
        
        // Track match state changes (using RoundWinner as a proxy for state changes)
        if (export.RoundWinner.HasValue && RecordTimeline)
        {
            _gameEvents.Add(new RoundEvent
            {
                Time = currentTime,
                EventType = "RoundEnd",
                RoundNumber = _gameData.RoundsLeft ?? 0,
                RoundTime = export.RoundTime ?? 0
            });
        }
        
        // Game settings
        if (export.bNoTeams.HasValue) _gameData.bNoTeams = export.bNoTeams;
        if (export.bMovementDisabled.HasValue) _gameData.bMovementDisabled = export.bMovementDisabled;
        if (export.bNoFallDamage.HasValue) _gameData.bNoFallDamage = export.bNoFallDamage;
        if (export.bLimitedAmmo.HasValue) _gameData.bLimitedAmmo = export.bLimitedAmmo;
        if (export.bShowNameTags.HasValue) _gameData.bShowNameTags = export.bShowNameTags;
        if (export.bPreventGrenadePin.HasValue) _gameData.bPreventGrenadePin = export.bPreventGrenadePin;
        if (export.bEnableProne.HasValue) _gameData.bEnableProne = export.bEnableProne;
        if (export.bCanReviveEnemies.HasValue) _gameData.bCanReviveEnemies = export.bCanReviveEnemies;
        if (export.bCanSwitchTeams.HasValue) _gameData.bCanSwitchTeams = export.bCanSwitchTeams;
        if (export.bPinProtected.HasValue) _gameData.bPinProtected = export.bPinProtected;
        if (export.bCanAutoEjectVehicles.HasValue) _gameData.bCanAutoEjectVehicles = export.bCanAutoEjectVehicles;
        
        // Game mode
        if (export.GameModeType.HasValue) _gameData.GameModeType = export.GameModeType;
        if (export.CompetitiveMode.HasValue) _gameData.CompetitiveMode = export.CompetitiveMode;
        if (export.Holiday.HasValue) _gameData.Holiday = export.Holiday;
        
        // Player limits
        if (export.MaxPlayers.HasValue) _gameData.MaxPlayers = export.MaxPlayers;
        if (export.AFKTimeLimit.HasValue) _gameData.AFKTimeLimit = export.AFKTimeLimit;
    }
    
    /// <summary>
    /// Gets the current relative time (elapsed time from replay start).
    /// </summary>
    private float GetCurrentTime()
    {
        return _hasFirstWorldTime ? _lastWorldTime - _firstWorldTime : 0f;
    }

    #endregion

    #region Player State Handlers

    private void HandlePlayerState(uint channelIndex, PavlovPlayerStateExport export)
    {
        if (!_players.TryGetValue(channelIndex, out var player))
        {
            player = new PlayerData();
            _players[channelIndex] = player;
        }
        
        // Identification
        if (export.PlayerNamePrivate != null) player.PlayerName = export.PlayerNamePrivate;
        if (export.PlatformId != null) player.PlatformId = export.PlatformId;
        if (export.PlayerId.HasValue) player.PlayerId = export.PlayerId.Value;
        
        // Team
        if (export.TeamId.HasValue) player.TeamId = export.TeamId.Value;
        
        // Stats
        if (export.Kills.HasValue) player.Kills = export.Kills.Value;
        if (export.Deaths.HasValue) player.Deaths = export.Deaths.Value;
        if (export.Assists.HasValue) player.Assists = export.Assists.Value;
        if (export.Cash.HasValue) player.Cash = export.Cash.Value;
        if (export.Exp.HasValue) player.Exp = export.Exp.Value;
        if (export.Score.HasValue) player.Score = export.Score.Value;
        if (export.Progress.HasValue) player.Progress = export.Progress.Value;
        
        // State
        if (export.bDead.HasValue) player.bDead = export.bDead.Value;
        if (export.bDev.HasValue) player.bDev = export.bDev.Value;
        if (export.Flair.HasValue) player.Flair = export.Flair;
        if (export.RespawnCountdown.HasValue) player.RespawnCountdown = export.RespawnCountdown.Value;
        
        // Settings
        if (export.PlayerHeight.HasValue) player.PlayerHeight = export.PlayerHeight.Value;
        if (export.bRightHanded.HasValue) player.bRightHanded = export.bRightHanded.Value;
        if (export.bVirtualStock.HasValue) player.bVirtualStock = export.bVirtualStock.Value;
        
        // Voice/communication
        if (export.bCanVote.HasValue) player.bCanVote = export.bCanVote.Value;
        if (export.bSpeaking.HasValue) player.bSpeaking = export.bSpeaking.Value;
        if (export.bGagged.HasValue) player.bGagged = export.bGagged.Value;
        if (export.PlayerPlatform.HasValue) player.PlayerPlatform = export.PlayerPlatform;
        
        // Moderation
        if (export.bAuthenticated.HasValue) player.bAuthenticated = export.bAuthenticated.Value;
        if (export.LifeTeamKillCount.HasValue) player.LifeTeamKillCount = export.LifeTeamKillCount.Value;
        if (export.LifetimeTeamKillCount.HasValue) player.LifetimeTeamKillCount = export.LifetimeTeamKillCount.Value;
        
        // Misc
        if (export.ExtraRespawnCountdown.HasValue) player.ExtraRespawnCountdown = export.ExtraRespawnCountdown.Value;
        if (export.DeadTime.HasValue) player.DeadTime = export.DeadTime.Value;
        if (export.bSpawnGhost.HasValue) player.bSpawnGhost = export.bSpawnGhost.Value;
        if (export.bHasPlayerProxy.HasValue) player.bHasPlayerProxy = export.bHasPlayerProxy.Value;
        if (export.CompressedPing.HasValue) player.CompressedPing = export.CompressedPing.Value;
    }

    #endregion

    #region Pawn Handlers

    private void HandlePawn(uint channelIndex, PavlovPawnExport export)
    {
        if (!_pawns.TryGetValue(channelIndex, out var pawn))
        {
            pawn = new PawnData { ChannelIndex = channelIndex };
            _pawns[channelIndex] = pawn;
        }
        
        pawn.LastUpdateTime = _lastWorldTime;
        
        // VR Tracking positions - Location1/2/3 are the actual tracked positions in Pavlov
        if (export.Location1 is not null) pawn.HeadLocation = export.Location1;
        if (export.Location2 is not null) pawn.LeftHandLocation = export.Location2;
        if (export.Location3 is not null) pawn.RightHandLocation = export.Location3;
        
        // VR Tracking rotations
        if (export.Rotation is not null) pawn.Rotation = export.Rotation;
        if (export.Rotation1 is not null) pawn.LeftHandRotation = export.Rotation1;
        if (export.Rotation2 is not null) pawn.RightHandRotation = export.Rotation2;
        
        // World Location/Velocity properties
        if (export.Location is not null) pawn.Location = export.Location;
        if (export.Velocity is not null) pawn.Velocity = export.Velocity;
        if (export.Heading.HasValue) pawn.Heading = export.Heading;
        
        // Controllers - these are actor references (network GUIDs), not positions
        if (export.LeftController.HasValue) pawn.LeftControllerRef = export.LeftController;
        if (export.RightController.HasValue) pawn.RightControllerRef = export.RightController;
        // Note: LeftControllerRot and RightControllerRot are ignored as they don't exist in SDK
        if (export.LeftControllerRot is not null) pawn.LeftControllerRot = export.LeftControllerRot;
        if (export.RightControllerRot is not null) pawn.RightControllerRot = export.RightControllerRot;
        if (export.HeadRot is not null) pawn.HeadRot = export.HeadRot;
        if (export.GazeDir is not null) pawn.GazeDir = export.GazeDir;
        
        // Finger tracking
        UpdateFingerTracking(pawn, export);
        
        // Avatar and state
        if (export.TeamId.HasValue) pawn.TeamId = export.TeamId;
        if (export.AvatarId.HasValue) pawn.AvatarId = export.AvatarId;
        if (export.AvatarSkinClass.HasValue) pawn.AvatarSkinClass = export.AvatarSkinClass;
        if (export.Blinking.HasValue) pawn.Blinking = export.Blinking;
        if (export.bIsTalking.HasValue) pawn.IsTalking = export.bIsTalking;
        if (export.bParachuting.HasValue) pawn.IsParachuting = export.bParachuting;
        if (export.bHidden.HasValue) pawn.IsHidden = export.bHidden;
        if (export.bInvulnerable.HasValue) pawn.IsInvulnerable = export.bInvulnerable;
        if (export.Flags.HasValue) pawn.Flags = export.Flags;
        if (export.Armour.HasValue) pawn.Armour = export.Armour;
        if (export.HelmetArmour.HasValue) pawn.HelmetArmour = export.HelmetArmour;
        if (export.RadioChannel.HasValue) pawn.RadioChannel = export.RadioChannel;
        if (export.LeftSupported.HasValue) pawn.LeftSupported = export.LeftSupported;
        if (export.RightSupported.HasValue) pawn.RightSupported = export.RightSupported;
        
        // References - store raw network GUIDs
        if (export.PlayerState.HasValue) pawn.PlayerStateRef = export.PlayerState;
        if (export.Controller.HasValue) pawn.ControllerRef = export.Controller;
        if (export.Owner.HasValue) pawn.OwnerRef = export.Owner;
        
        // Resolve PlayerState network GUID to channel index for player linking
        if (pawn.PlayerStateRef.HasValue && pawn.ResolvedPlayerChannel == null)
        {
            var resolvedChannel = ResolveGuidToChannel(pawn.PlayerStateRef);
            if (resolvedChannel.HasValue)
            {
                pawn.ResolvedPlayerChannel = resolvedChannel;
            }
        }
        
        // Record timeline snapshot if enabled
        // Use frame-based interval since MatchTime may not be available or may not update frequently
        if (RecordTimeline && pawn.Location is not null)
        {
            // Get last snapshot frame for this pawn (default to -1000 to ensure first snapshot is recorded)
            _lastSnapshotFrame.TryGetValue(channelIndex, out var lastFrame);
            if (lastFrame == 0) lastFrame = -1000;  // Ensure first record

            // Always record the first valid position for each pawn
            var isFirstSnapshot = !_pawnTimelines.ContainsKey(channelIndex) ||
                                 _pawnTimelines[channelIndex].Snapshots.Count == 0;

            // Record every N frames (approximately, SnapshotInterval * 100 frames per second estimate)
            var frameInterval = Math.Max(1, (int)(SnapshotInterval * 100));
            if (isFirstSnapshot || _frameCounter - lastFrame >= frameInterval)
            {
                RecordPawnSnapshot(channelIndex, pawn);
                _lastSnapshotFrame[channelIndex] = _frameCounter;
            }
        }
    }
    
    private void RecordPawnSnapshot(uint channelIndex, PawnData pawn)
    {
        if (!_pawnTimelines.TryGetValue(channelIndex, out var timeline))
        {
            timeline = new PawnTimeline { ChannelIndex = channelIndex };
            _pawnTimelines[channelIndex] = timeline;
        }
        
        // Update timeline metadata
        if (pawn.TeamId.HasValue) timeline.TeamId = pawn.TeamId;
        
        // Check if player is dead by looking up the linked player
        bool isDead = false;
        if (pawn.ResolvedPlayerChannel.HasValue && _players.TryGetValue(pawn.ResolvedPlayerChannel.Value, out var player))
        {
            isDead = player.bDead;
        }
        
        // Create snapshot
        var loc = pawn.Location;
        var isFirstSnapshot = timeline.Snapshots.Count == 0;
        // Calculate relative time: subtract first world time to get elapsed time from replay start
        float snapshotTime = isFirstSnapshot ? 0f : (_hasFirstWorldTime ? _lastWorldTime - _firstWorldTime : 0f);
        var snapshot = new PawnSnapshot
        {
            Time = snapshotTime,  // First snapshot at time 0, subsequent snapshots use relative time
            Location = loc is not null ? new FVector(loc.X, loc.Y, loc.Z) : null,
            HeadLocation = pawn.HeadLocation is { } hl ? new FVector(hl.X, hl.Y, hl.Z) : null,
            LeftHandLocation = pawn.LeftHandLocation is { } lh ? new FVector(lh.X, lh.Y, lh.Z) : null,
            RightHandLocation = pawn.RightHandLocation is { } rh ? new FVector(rh.X, rh.Y, rh.Z) : null,
            Velocity = pawn.Velocity is { } vel ? new FVector(vel.X, vel.Y, vel.Z) : null,
            Rotation = pawn.Rotation,
            LeftHandRotation = pawn.LeftHandRotation,
            RightHandRotation = pawn.RightHandRotation,
            Heading = pawn.Heading,
            HeadRot = pawn.HeadRot,
            GazeDir = pawn.GazeDir,
            // Mark position as invalid if Z is unreasonable (< 50cm or > 500cm for head height)
            IsPositionValid = loc is null || (loc.Z >= 50 && loc.Z <= 500),
            IsDead = isDead
        };
        
        // Detect jittery/corrupt tracking data by checking velocity against recent snapshots
        // If we have at least 2 previous snapshots, check for unrealistic speed
        if (loc is not null && snapshot.IsPositionValid && timeline.Snapshots.Count >= 1)
        {
            var prevSnap = timeline.Snapshots[^1];
            if (prevSnap.Location is not null && prevSnap.IsPositionValid)
            {
                var dt = snapshot.Time - prevSnap.Time;
                if (dt > 0 && dt < 1.0f) // Only check for nearby snapshots
                {
                    var dx = loc.X - prevSnap.Location.X;
                    var dy = loc.Y - prevSnap.Location.Y;
                    var dist = Math.Sqrt(dx * dx + dy * dy);
                    var speed = dist / dt;
                    
                    // VR movement speeds: walking ~2-5 units/s, running ~10-20, sprinting ~20-50
                    // Speed > 200 units/s indicates corrupt tracking data or teleportation
                    if (speed > 200)
                    {
                        snapshot.IsPositionValid = false;
                    }
                }
            }
        }
        
        timeline.Snapshots.Add(snapshot);
    }

    private void UpdateFingerTracking(PawnData pawn, PavlovPawnExport export)
    {
        // Left hand fingers
        if (export.LeftIndex.HasValue || export.LeftMiddle.HasValue || 
            export.LeftRing.HasValue || export.LeftPinky.HasValue || export.LeftThumb.HasValue)
        {
            pawn.LeftFingers ??= new float[5];
            if (export.LeftIndex.HasValue) pawn.LeftFingers[0] = export.LeftIndex.Value;
            if (export.LeftMiddle.HasValue) pawn.LeftFingers[1] = export.LeftMiddle.Value;
            if (export.LeftRing.HasValue) pawn.LeftFingers[2] = export.LeftRing.Value;
            if (export.LeftPinky.HasValue) pawn.LeftFingers[3] = export.LeftPinky.Value;
            if (export.LeftThumb.HasValue) pawn.LeftFingers[4] = export.LeftThumb.Value;
        }
        
        // Right hand fingers
        if (export.RightIndex.HasValue || export.RightMiddle.HasValue || 
            export.RightRing.HasValue || export.RightPinky.HasValue || export.RightThumb.HasValue)
        {
            pawn.RightFingers ??= new float[5];
            if (export.RightIndex.HasValue) pawn.RightFingers[0] = export.RightIndex.Value;
            if (export.RightMiddle.HasValue) pawn.RightFingers[1] = export.RightMiddle.Value;
            if (export.RightRing.HasValue) pawn.RightFingers[2] = export.RightRing.Value;
            if (export.RightPinky.HasValue) pawn.RightFingers[3] = export.RightPinky.Value;
            if (export.RightThumb.HasValue) pawn.RightFingers[4] = export.RightThumb.Value;
        }
        
        // Packed hand data
        if (export.PackedLeftHand.HasValue) pawn.PackedLeftHand = export.PackedLeftHand;
        if (export.PackedRightHand.HasValue) pawn.PackedRightHand = export.PackedRightHand;
    }

    private void HandleController(uint channelIndex, PavlovControllerExport export)
    {
        // Controller data is typically attached to a pawn, we can use Owner to link
        // For now, just track it separately - could be enhanced to merge with pawn data
    }

    #endregion

    #region Weapon Handlers

    private void HandleGun(uint channelIndex, VRGunExport export)
    {
        var weapon = GetOrCreateWeapon(channelIndex, "VRGun");
        
        // Ammo
        if (export.Ammo.HasValue) weapon.Ammo = export.Ammo;
        if (export.MagAmmo.HasValue) weapon.MagAmmo = export.MagAmmo;
        if (export.MaxAmmo.HasValue) weapon.MaxAmmo = export.MaxAmmo;
        
        // State
        if (export.bCocked.HasValue) weapon.IsCocked = export.bCocked;
        if (export.bSafetyOn.HasValue) weapon.SafetyOn = export.bSafetyOn;
        if (export.bSlideLocked.HasValue) weapon.SlideLocked = export.bSlideLocked;
        if (export.FireMode.HasValue) weapon.FireMode = export.FireMode;
        if (export.TwoHandStockState.HasValue) weapon.TwoHandStockState = export.TwoHandStockState;
        
        // Attachments
        if (export.AttachedMagazine.HasValue) weapon.AttachedMagazine = export.AttachedMagazine;
        if (export.AttachedSight.HasValue) weapon.AttachedSight = export.AttachedSight;
        if (export.AttachedSuppressor.HasValue) weapon.AttachedSuppressor = export.AttachedSuppressor;
        if (export.AttachedLaser.HasValue) weapon.AttachedLaser = export.AttachedLaser;
        if (export.AttachedFlashlight.HasValue) weapon.AttachedFlashlight = export.AttachedFlashlight;
        if (export.AttachedGrip.HasValue) weapon.AttachedGrip = export.AttachedGrip;
        
        // Cosmetics
        if (export.SkinId.HasValue) weapon.SkinId = export.SkinId;
        if (export.CharmId.HasValue) weapon.CharmId = export.CharmId;
        
        // Common properties
        UpdateWeaponCommon(weapon, export.ReplicatedMovement, export.Owner, export.Instigator, 
            export.bHidden, export.bTearOff, export.AttachParent, 
            export.AttachSocket);
    }

    private void HandleMagazine(uint channelIndex, MagazineExport export)
    {
        var weapon = GetOrCreateWeapon(channelIndex, "Magazine");
        
        if (export.Bullets.HasValue) weapon.Ammo = export.Bullets;
        if (export.MaxBullets.HasValue) weapon.MaxAmmo = export.MaxBullets;
        
        UpdateWeaponCommon(weapon, export.ReplicatedMovement, export.Owner, export.Instigator,
            export.bHidden, export.bTearOff, export.AttachParent,
            export.AttachSocket);
    }

    private void HandleGrenade(uint channelIndex, VRGrenadeExport export)
    {
        var weapon = GetOrCreateWeapon(channelIndex, "VRGrenade");
        
        if (export.State.HasValue) weapon.GrenadeState = export.State;
        if (export.GrenadeType.HasValue) weapon.GrenadeType = export.GrenadeType;
        if (export.CookTime.HasValue) weapon.CookTime = export.CookTime;
        if (export.FuseTime.HasValue) weapon.FuseTime = export.FuseTime;
        
        UpdateWeaponCommon(weapon, export.ReplicatedMovement, export.Owner, export.Instigator,
            export.bHidden, export.bTearOff, export.AttachParent,
            export.AttachSocket);
    }

    private void HandleKnife(uint channelIndex, VRKnifeExport export)
    {
        var weapon = GetOrCreateWeapon(channelIndex, "VRKnife");
        
        if (export.SkinId.HasValue) weapon.SkinId = export.SkinId;
        
        UpdateWeaponCommon(weapon, export.ReplicatedMovement, export.Owner, export.Instigator,
            export.bHidden, export.bTearOff, export.AttachParent,
            export.AttachSocket);
    }

    private void HandleLauncher(uint channelIndex, VRLauncherExport export)
    {
        var weapon = GetOrCreateWeapon(channelIndex, "VRLauncher");
        
        // VRLauncher has bCocked but no state enum
        if (export.Ammo.HasValue) weapon.Ammo = export.Ammo;
        
        UpdateWeaponCommon(weapon, export.ReplicatedMovement, export.Owner, export.Instigator,
            export.bHidden, export.bTearOff, export.AttachParent,
            export.AttachSocket);
    }

    private WeaponData GetOrCreateWeapon(uint channelIndex, string weaponType)
    {
        if (!_weapons.TryGetValue(channelIndex, out var weapon))
        {
            weapon = new WeaponData { ChannelIndex = channelIndex, WeaponType = weaponType };
            _weapons[channelIndex] = weapon;
        }
        weapon.LastUpdateTime = _lastWorldTime;
        return weapon;
    }

    private void UpdateWeaponCommon(WeaponData weapon, FRepMovement? movement, uint? owner, 
        uint? instigator, bool? hidden, bool? tornOff, uint? attachParent, string? attachSocket)
    {
        if (movement != null) weapon.ReplicatedMovement = movement;
        if (owner.HasValue) weapon.OwnerRef = owner;
        if (instigator.HasValue) weapon.InstigatorRef = instigator;
        if (hidden.HasValue) weapon.IsHidden = hidden;
        if (tornOff.HasValue) weapon.IsTornOff = tornOff;
        if (attachParent.HasValue) weapon.AttachParentRef = attachParent;
        if (attachSocket != null) weapon.AttachSocket = attachSocket;
    }

    #endregion

    #region Vehicle Handlers

    private void HandleVehicle(uint channelIndex, PavlovVehicleExport export)
    {
        var vehicle = GetOrCreateVehicle(channelIndex, "PavlovVehicle");
        
        // Health
        if (export.Health.HasValue) vehicle.Health = export.Health;
        if (export.MaxHealth.HasValue) vehicle.MaxHealth = export.MaxHealth;
        if (export.DamageState.HasValue) vehicle.DamageState = export.DamageState;
        
        // Movement
        if (export.ReplicatedMovement != null) vehicle.ReplicatedMovement = export.ReplicatedMovement;
        if (export.Speed.HasValue) vehicle.Speed = export.Speed;
        if (export.Throttle.HasValue) vehicle.Throttle = export.Throttle;
        if (export.Steering.HasValue) vehicle.Steering = export.Steering;
        if (export.Brake.HasValue) vehicle.Brake = export.Brake;
        if (export.bEngineRunning.HasValue) vehicle.EngineRunning = export.bEngineRunning;
        
        // Occupants
        if (export.TeamId.HasValue) vehicle.TeamId = export.TeamId;
        if (export.Driver.HasValue) vehicle.DriverRef = export.Driver;
        if (export.Passengers != null) vehicle.PassengerRefs = export.Passengers;
        
        // State
        if (export.bHidden.HasValue) vehicle.IsHidden = export.bHidden;
        if (export.Owner.HasValue) vehicle.OwnerRef = export.Owner;
    }

    private void HandleTank(uint channelIndex, PavlovTankExport export)
    {
        var vehicle = GetOrCreateVehicle(channelIndex, "PavlovTank");
        
        // Health
        if (export.Health.HasValue) vehicle.Health = export.Health;
        if (export.MaxHealth.HasValue) vehicle.MaxHealth = export.MaxHealth;
        if (export.DamageState.HasValue) vehicle.DamageState = export.DamageState;
        
        // Movement
        if (export.ReplicatedMovement != null) vehicle.ReplicatedMovement = export.ReplicatedMovement;
        
        // Occupants
        if (export.TeamId.HasValue) vehicle.TeamId = export.TeamId;
        if (export.Driver.HasValue) vehicle.DriverRef = export.Driver;
        if (export.Gunner.HasValue) vehicle.GunnerRef = export.Gunner;
        if (export.Commander.HasValue) vehicle.CommanderRef = export.Commander;
        
        // Tank-specific
        if (export.TurretRotation != null) vehicle.TurretRotation = export.TurretRotation;
        if (export.GunElevation.HasValue) vehicle.GunElevation = export.GunElevation;
        if (export.MainGunAmmo.HasValue) vehicle.MainGunAmmo = export.MainGunAmmo;
        if (export.CoaxialAmmo.HasValue) vehicle.CoaxialAmmo = export.CoaxialAmmo;
        if (export.bMainGunLoaded.HasValue) vehicle.MainGunLoaded = export.bMainGunLoaded;
        if (export.ReloadProgress.HasValue) vehicle.ReloadProgress = export.ReloadProgress;
        
        // State
        if (export.bHidden.HasValue) vehicle.IsHidden = export.bHidden;
        if (export.Owner.HasValue) vehicle.OwnerRef = export.Owner;
    }

    private VehicleData GetOrCreateVehicle(uint channelIndex, string vehicleType)
    {
        if (!_vehicles.TryGetValue(channelIndex, out var vehicle))
        {
            vehicle = new VehicleData { ChannelIndex = channelIndex, VehicleType = vehicleType };
            _vehicles[channelIndex] = vehicle;
        }
        vehicle.LastUpdateTime = _lastWorldTime;
        return vehicle;
    }

    #endregion

    #region Bomb Handlers (S&D)

    private void HandleBomb(uint channelIndex, BombExport export)
    {
        _bomb ??= new BombData { ChannelIndex = channelIndex };
        _bomb.LastUpdateTime = _lastWorldTime;
        
        // BombState and State can both be set - prefer BombState if available
        if (export.BombState.HasValue) _bomb.BombState = export.BombState;
        else if (export.State.HasValue) _bomb.BombState = export.State;
        if (export.BombTime.HasValue) _bomb.BombTime = export.BombTime;
        if (export.DefuseProgress.HasValue) _bomb.DefuseProgress = export.DefuseProgress;
        if (export.bDefusing.HasValue) _bomb.IsDefusing = export.bDefusing;
        if (export.ReplicatedMovement != null) _bomb.ReplicatedMovement = export.ReplicatedMovement;
        if (export.Owner.HasValue) _bomb.OwnerRef = export.Owner;
        if (export.bHidden.HasValue) _bomb.IsHidden = export.bHidden;
        if (export.AttachParent.HasValue) 
            _bomb.AttachParentRef = export.AttachParent;
    }

    private void HandleBombSite(uint channelIndex, BombPlantSpotExport export)
    {
        var site = _bombSites.FirstOrDefault(s => s.ChannelIndex == channelIndex);
        if (site == null)
        {
            site = new BombSiteData { ChannelIndex = channelIndex };
            _bombSites.Add(site);
        }
        site.LastUpdateTime = _lastWorldTime;
        
        if (export.bSpotEnabled.HasValue) site.IsActive = export.bSpotEnabled;
        if (export.ReplicatedMovement != null) site.ReplicatedMovement = export.ReplicatedMovement;
    }

    #endregion

    #region Health Component Handler

    private void HandleHealthComponent(uint channelIndex, VHealthComponentExport export)
    {
        if (!_healthComponents.TryGetValue(channelIndex, out var health))
        {
            health = new HealthData { ChannelIndex = channelIndex };
            _healthComponents[channelIndex] = health;
        }
        health.LastUpdateTime = _lastWorldTime;
        
        if (export.Health.HasValue) health.Health = export.Health;
        if (export.MaxHealth.HasValue) health.MaxHealth = export.MaxHealth;
        if (export.bIsActive.HasValue) health.IsActive = export.bIsActive;
        if (export.Owner.HasValue) health.OwnerRef = export.Owner;
    }

    #endregion

    #region Game Mode Specific Handlers

    private void InitGameModeData()
    {
        _gameModeData ??= new GameModeData();
    }

    private void HandleTTTGameState(TTTGameStateExport export)
    {
        InitGameModeData();
        _gameModeData!.GameModeType = "TTT";
        _gameModeData.LastUpdateTime = _lastWorldTime;
        
        if (export.ReplicatedWorldTimeSeconds.HasValue) 
            _gameModeData.ReplicatedWorldTimeSeconds = export.ReplicatedWorldTimeSeconds;
        if (export.bRolesAssigned.HasValue) _gameModeData.TTT_RolesAssigned = export.bRolesAssigned;
        if (export.PhaseTimeRemaining.HasValue) _gameModeData.TTT_PhaseTimeRemaining = export.PhaseTimeRemaining;
        if (export.bRoundInProgress.HasValue) _gameModeData.TTT_RoundInProgress = export.bRoundInProgress;
        if (export.InnocentsAlive.HasValue) _gameModeData.TTT_InnocentsAlive = export.InnocentsAlive;
        if (export.TraitorsAlive.HasValue) _gameModeData.TTT_TraitorsAlive = export.TraitorsAlive;
        if (export.DetectivesAlive.HasValue) _gameModeData.TTT_DetectivesAlive = export.DetectivesAlive;
    }

    private void HandleTTTPlayerState(uint channelIndex, TTTPlayerStateExport export)
    {
        if (!_tttPlayers.TryGetValue(channelIndex, out var tttPlayer))
        {
            tttPlayer = new TTTPlayerData { ChannelIndex = channelIndex };
            _tttPlayers[channelIndex] = tttPlayer;
        }
        
        if (export.TTTRole.HasValue) tttPlayer.Role = export.TTTRole;
        if (export.bRoleRevealed.HasValue) tttPlayer.RoleRevealed = export.bRoleRevealed;
        if (export.Karma.HasValue) tttPlayer.Karma = export.Karma;
        if (export.Credits.HasValue) tttPlayer.Credits = export.Credits;
        if (export.Owner.HasValue) tttPlayer.OwnerRef = export.Owner;
    }

    private void HandleZombieCoopGameState(ZombieCoopGameStateExport export)
    {
        InitGameModeData();
        _gameModeData!.GameModeType = "ZombieCoop";
        _gameModeData.LastUpdateTime = _lastWorldTime;
        
        if (export.ReplicatedWorldTimeSeconds.HasValue) 
            _gameModeData.ReplicatedWorldTimeSeconds = export.ReplicatedWorldTimeSeconds;
        if (export.CurrentWave.HasValue) _gameModeData.Zombie_CurrentWave = export.CurrentWave;
        if (export.MaxWaves.HasValue) _gameModeData.Zombie_MaxWaves = export.MaxWaves;
        if (export.ZombiesRemaining.HasValue) _gameModeData.Zombie_ZombiesRemaining = export.ZombiesRemaining;
        if (export.TotalZombiesInWave.HasValue) _gameModeData.Zombie_TotalZombiesInWave = export.TotalZombiesInWave;
        if (export.bBetweenWaves.HasValue) _gameModeData.Zombie_BetweenWaves = export.bBetweenWaves;
        if (export.TimeToNextWave.HasValue) _gameModeData.Zombie_TimeToNextWave = export.TimeToNextWave;
    }

    private void HandleTheHiddenGameState(TheHiddenGameStateExport export)
    {
        InitGameModeData();
        _gameModeData!.GameModeType = "TheHidden";
        _gameModeData.LastUpdateTime = _lastWorldTime;
        
        if (export.ReplicatedWorldTimeSeconds.HasValue) 
            _gameModeData.ReplicatedWorldTimeSeconds = export.ReplicatedWorldTimeSeconds;
        if (export.HiddenPlayer.HasValue) _gameModeData.Hidden_PlayerRef = export.HiddenPlayer;
        if (export.HiddenHealth.HasValue) _gameModeData.Hidden_Health = export.HiddenHealth;
        if (export.bHiddenVisible.HasValue) _gameModeData.Hidden_IsVisible = export.bHiddenVisible;
        if (export.IRISAlive.HasValue) _gameModeData.Hidden_IRISAlive = export.IRISAlive;
    }

    private void HandleGunGameState(GunGameStateExport export)
    {
        InitGameModeData();
        _gameModeData!.GameModeType = "GunGame";
        _gameModeData.LastUpdateTime = _lastWorldTime;
        
        if (export.ReplicatedWorldTimeSeconds.HasValue) 
            _gameModeData.ReplicatedWorldTimeSeconds = export.ReplicatedWorldTimeSeconds;
        if (export.TotalGunLevels.HasValue) _gameModeData.GunGame_TotalGunLevels = export.TotalGunLevels;
        if (export.LeaderGunLevel.HasValue) _gameModeData.GunGame_LeaderGunLevel = export.LeaderGunLevel;
        if (export.LeaderPlayer.HasValue) _gameModeData.GunGame_LeaderPlayerRef = export.LeaderPlayer;
    }

    private void HandlePropHuntGameState(PropHuntGameStateExport export)
    {
        InitGameModeData();
        _gameModeData!.GameModeType = "PropHunt";
        _gameModeData.LastUpdateTime = _lastWorldTime;
        
        if (export.ReplicatedWorldTimeSeconds.HasValue) 
            _gameModeData.ReplicatedWorldTimeSeconds = export.ReplicatedWorldTimeSeconds;
        if (export.PropsAlive.HasValue) _gameModeData.PropHunt_PropsAlive = export.PropsAlive;
        if (export.HuntersAlive.HasValue) _gameModeData.PropHunt_HuntersAlive = export.HuntersAlive;
        if (export.bHidePhase.HasValue) _gameModeData.PropHunt_HidePhase = export.bHidePhase;
        if (export.HideTimeRemaining.HasValue) _gameModeData.PropHunt_HideTimeRemaining = export.HideTimeRemaining;
    }

    private void HandleInfectionGameState(InfectionGameStateExport export)
    {
        InitGameModeData();
        _gameModeData!.GameModeType = "Infection";
        _gameModeData.LastUpdateTime = _lastWorldTime;
        
        if (export.ReplicatedWorldTimeSeconds.HasValue) 
            _gameModeData.ReplicatedWorldTimeSeconds = export.ReplicatedWorldTimeSeconds;
        if (export.SurvivorsCount.HasValue) _gameModeData.Infection_SurvivorsCount = export.SurvivorsCount;
        if (export.InfectedCount.HasValue) _gameModeData.Infection_InfectedCount = export.InfectedCount;
        if (export.bAlphaSelected.HasValue) _gameModeData.Infection_AlphaSelected = export.bAlphaSelected;
        if (export.AlphaPlayer.HasValue) _gameModeData.Infection_AlphaPlayerRef = export.AlphaPlayer;
    }

    private void HandleJailbreakGameState(JailbreakGameStateExport export)
    {
        InitGameModeData();
        _gameModeData!.GameModeType = "Jailbreak";
        _gameModeData.LastUpdateTime = _lastWorldTime;
        
        if (export.ReplicatedWorldTimeSeconds.HasValue) 
            _gameModeData.ReplicatedWorldTimeSeconds = export.ReplicatedWorldTimeSeconds;
        if (export.Warden.HasValue) _gameModeData.Jailbreak_WardenRef = export.Warden;
        if (export.GuardsAlive.HasValue) _gameModeData.Jailbreak_GuardsAlive = export.GuardsAlive;
        if (export.PrisonersAlive.HasValue) _gameModeData.Jailbreak_PrisonersAlive = export.PrisonersAlive;
        if (export.bLastRequest.HasValue) _gameModeData.Jailbreak_LastRequest = export.bLastRequest;
    }

    #endregion

    #region RPC Event Handlers

    /// <summary>
    /// Handles killfeed RPC events with full kill data.
    /// </summary>
    private void HandleKillfeedRPC(uint channelIndex, MulticastOnKillfeedEntry export)
    {
        if (!RecordTimeline) return;
        
        var currentTime = GetCurrentTime();
        
        // Resolve killer/victim from object references if names not provided
        string? killerName = export.KillerName;
        string? victimName = export.VictimName;
        byte? killerTeamId = (byte?)(export.KillerTeamId);
        byte? victimTeamId = (byte?)(export.VictimTeamId);
        
        // Try to resolve killer name from object reference
        // Killer/Victim are PlayerState references, so resolve directly to _players
        if (string.IsNullOrEmpty(killerName) && export.Killer.HasValue)
        {
            var killerChannel = ResolveGuidToChannel(export.Killer);
            if (killerChannel.HasValue && _players.TryGetValue(killerChannel.Value, out var killerPlayer))
            {
                killerName = killerPlayer.PlayerName;
                killerTeamId = (byte?)killerPlayer.TeamId;
            }
        }
        
        // Try to resolve victim name from object reference
        if (string.IsNullOrEmpty(victimName) && export.Victim.HasValue)
        {
            var victimChannel = ResolveGuidToChannel(export.Victim);
            if (victimChannel.HasValue && _players.TryGetValue(victimChannel.Value, out var victimPlayer))
            {
                victimName = victimPlayer.PlayerName;
                victimTeamId = (byte?)victimPlayer.TeamId;
            }
        }
        
        var killEvent = new KillEvent
        {
            Time = currentTime,
            EventType = "Kill",
            KillerName = killerName,
            VictimName = victimName,
            IsHeadshot = export.bHeadshot ?? false,
            KillerTeamId = killerTeamId,
            VictimTeamId = victimTeamId,
            Description = $"{killerName ?? "Unknown"} killed {victimName ?? "Unknown"}" +
                         (export.bHeadshot == true ? " (headshot)" : "")
        };
        
        // Try to parse IDs
        if (ulong.TryParse(export.KillerId, out var killerId))
            killEvent.KillerId = killerId;
        if (ulong.TryParse(export.VictimId, out var victimId))
            killEvent.VictimId = victimId;
        
        _gameEvents.Add(killEvent);
    }

    /// <summary>
    /// Handles impact damage RPC events.
    /// </summary>
    private void HandleImpactDamageRPC(uint channelIndex, MulticastOnImpactDamage export)
    {
        if (!RecordTimeline) return;
        
        var currentTime = GetCurrentTime();
        
        // Get victim info from pawn if available
        string? victimName = null;
        if (_pawns.TryGetValue(channelIndex, out var pawn) && pawn.ResolvedPlayerChannel.HasValue)
        {
            if (_players.TryGetValue(pawn.ResolvedPlayerChannel.Value, out var player))
                victimName = player.PlayerName;
        }
        
        var damageEvent = new DamageEvent
        {
            Time = currentTime,
            EventType = "Damage",
            VictimChannel = channelIndex,
            VictimName = victimName,
            BoneName = export.BoneName,
            Location = export.Location,
            Direction = export.Direction,
            ImpulseForce = export.ImpulseForce,
            WoundRate = export.WoundRate,
            WoundScale = export.WoundScale,
            Description = $"Impact damage to {export.BoneName ?? "body"}"
        };
        
        _gameEvents.Add(damageEvent);
    }

    /// <summary>
    /// Handles headshot RPC events.
    /// </summary>
    private void HandleHeadshotRPC(uint channelIndex, MulticastOnHeadshot export)
    {
        if (!RecordTimeline) return;
        
        var currentTime = GetCurrentTime();
        
        string? victimName = null;
        if (_pawns.TryGetValue(channelIndex, out var pawn) && pawn.ResolvedPlayerChannel.HasValue)
        {
            if (_players.TryGetValue(pawn.ResolvedPlayerChannel.Value, out var player))
                victimName = player.PlayerName;
        }
        
        var damageEvent = new DamageEvent
        {
            Time = currentTime,
            EventType = "Headshot",
            VictimChannel = channelIndex,
            VictimName = victimName,
            Location = export.HitLocation,
            Direction = export.HitDirection,
            WoundRate = export.WoundRate,
            IsHeadshot = true,
            Description = $"Headshot on {victimName ?? "Unknown"}"
        };
        
        _gameEvents.Add(damageEvent);
    }

    /// <summary>
    /// Handles helmet hit RPC events.
    /// </summary>
    private void HandleHelmetHitRPC(uint channelIndex, MulticastOnHelmetHit export)
    {
        if (!RecordTimeline) return;
        
        var currentTime = GetCurrentTime();
        
        string? victimName = null;
        if (_pawns.TryGetValue(channelIndex, out var pawn) && pawn.ResolvedPlayerChannel.HasValue)
        {
            if (_players.TryGetValue(pawn.ResolvedPlayerChannel.Value, out var player))
                victimName = player.PlayerName;
        }
        
        var damageEvent = new DamageEvent
        {
            Time = currentTime,
            EventType = "HelmetHit",
            VictimChannel = channelIndex,
            VictimName = victimName,
            Location = export.Location,
            Direction = export.Direction,
            IsHelmetHit = true,
            Description = $"Helmet hit on {victimName ?? "Unknown"}"
        };
        
        _gameEvents.Add(damageEvent);
    }

    /// <summary>
    /// Handles radial death (explosion) RPC events.
    /// </summary>
    private void HandleRadialDeathRPC(uint channelIndex, MulticastOnRadialDeath export)
    {
        if (!RecordTimeline) return;
        
        var currentTime = GetCurrentTime();
        
        string? victimName = null;
        if (_pawns.TryGetValue(channelIndex, out var pawn) && pawn.ResolvedPlayerChannel.HasValue)
        {
            if (_players.TryGetValue(pawn.ResolvedPlayerChannel.Value, out var player))
                victimName = player.PlayerName;
        }
        
        var damageEvent = new DamageEvent
        {
            Time = currentTime,
            EventType = "RadialDeath",
            VictimChannel = channelIndex,
            VictimName = victimName,
            Location = export.Origin,
            Description = $"{victimName ?? "Unknown"} killed by explosion"
        };
        
        _gameEvents.Add(damageEvent);
    }

    /// <summary>
    /// Handles bomb plant state change RPC.
    /// </summary>
    private void HandleBombPlantStateRPC(uint channelIndex, MulticastOnPlantStateChanged export)
    {
        if (!RecordTimeline) return;
        
        var currentTime = GetCurrentTime();
        
        var bombEvent = new BombEvent
        {
            Time = currentTime,
            EventType = export.bPlanted == true ? "BombPlanted" : "BombDefused",
            BombAction = export.bPlanted == true ? "Planted" : "Defused",
            IsPlanted = export.bPlanted,
            Description = export.bPlanted == true ? "Bomb planted" : "Bomb defused"
        };
        
        _gameEvents.Add(bombEvent);
    }

    /// <summary>
    /// Handles bomb code entry RPC.
    /// </summary>
    private void HandleBombCodeRPC(uint channelIndex, MulticastOnEnterCode export)
    {
        if (!RecordTimeline) return;
        
        var currentTime = GetCurrentTime();
        
        var bombEvent = new BombEvent
        {
            Time = currentTime,
            EventType = "BombCodeEntry",
            BombAction = "CodeEntry",
            CodeSucceeded = export.bSucceed,
            Description = export.bSucceed == true ? "Bomb code entered successfully" : "Bomb code failed"
        };
        
        _gameEvents.Add(bombEvent);
    }

    /// <summary>
    /// Handles bomb defuse RPC.
    /// </summary>
    private void HandleBombDefuseRPC(uint channelIndex)
    {
        if (!RecordTimeline) return;
        
        var currentTime = GetCurrentTime();
        
        var bombEvent = new BombEvent
        {
            Time = currentTime,
            EventType = "BombDefused",
            BombAction = "Defused",
            IsDefused = true,
            Description = "Bomb defused"
        };
        
        _gameEvents.Add(bombEvent);
    }

    /// <summary>
    /// Handles bomb detonation RPC.
    /// </summary>
    private void HandleBombDetonationRPC(uint channelIndex)
    {
        if (!RecordTimeline) return;
        
        var currentTime = GetCurrentTime();
        
        var bombEvent = new BombEvent
        {
            Time = currentTime,
            EventType = "BombDetonated",
            BombAction = "Detonated",
            Description = "Bomb detonated"
        };
        
        _gameEvents.Add(bombEvent);
    }

    /// <summary>
    /// Handles grenade detonation RPC.
    /// </summary>
    private void HandleGrenadeDetonationRPC(uint channelIndex)
    {
        if (!RecordTimeline) return;
        
        var currentTime = GetCurrentTime();
        
        var grenadeEvent = new GrenadeEvent
        {
            Time = currentTime,
            EventType = "GrenadeDetonation",
            GrenadeAction = "Detonated",
            GrenadeChannel = channelIndex,
            Description = "Grenade detonated"
        };
        
        _gameEvents.Add(grenadeEvent);
    }

    /// <summary>
    /// Handles grenade pin removed RPC.
    /// </summary>
    private void HandleGrenadePinRemovedRPC(uint channelIndex)
    {
        if (!RecordTimeline) return;
        
        var currentTime = GetCurrentTime();
        
        var grenadeEvent = new GrenadeEvent
        {
            Time = currentTime,
            EventType = "GrenadePinRemoved",
            GrenadeAction = "PinRemoved",
            GrenadeChannel = channelIndex,
            Description = "Grenade pin removed"
        };
        
        _gameEvents.Add(grenadeEvent);
    }

    /// <summary>
    /// Handles grenade safety lever released RPC.
    /// </summary>
    private void HandleGrenadeLeverReleasedRPC(uint channelIndex)
    {
        if (!RecordTimeline) return;
        
        var currentTime = GetCurrentTime();
        
        var grenadeEvent = new GrenadeEvent
        {
            Time = currentTime,
            EventType = "GrenadeLeverReleased",
            GrenadeAction = "LeverReleased",
            GrenadeChannel = channelIndex,
            Description = "Grenade safety lever released"
        };
        
        _gameEvents.Add(grenadeEvent);
    }

    /// <summary>
    /// Handles weapon fire RPC.
    /// </summary>
    private void HandleWeaponFireRPC(uint channelIndex)
    {
        // Note: Weapon fire events are extremely frequent and may flood the timeline
        // Only record if we specifically want shot data - currently disabled by default
        // Uncomment below if shot tracking is desired
        
        /*
        if (!RecordTimeline) return;
        
        var currentTime = GetCurrentTime();
        
        string? ownerName = null;
        uint? ownerChannel = null;
        if (_weapons.TryGetValue(channelIndex, out var weapon) && weapon.OwnerRef.HasValue)
        {
            var resolved = ResolveGuidToChannel(weapon.OwnerRef);
            if (resolved.HasValue && _pawns.TryGetValue(resolved.Value, out var pawn))
            {
                ownerChannel = resolved;
                if (pawn.ResolvedPlayerChannel.HasValue && _players.TryGetValue(pawn.ResolvedPlayerChannel.Value, out var player))
                    ownerName = player.PlayerName;
            }
        }
        
        var fireEvent = new WeaponFireEvent
        {
            Time = currentTime,
            EventType = "WeaponFire",
            WeaponChannel = channelIndex,
            OwnerChannel = ownerChannel,
            OwnerName = ownerName,
            Description = $"{ownerName ?? "Unknown"} fired weapon"
        };
        
        _gameEvents.Add(fireEvent);
        */
    }

    /// <summary>
    /// Handles knife stab RPC.
    /// </summary>
    private void HandleKnifeStabRPC(uint channelIndex, MulticastOnStab export)
    {
        if (!RecordTimeline) return;
        
        var currentTime = GetCurrentTime();
        
        // Knife stab events - try to identify attacker from weapon owner
        string? attackerName = null;
        if (_weapons.TryGetValue(channelIndex, out var weapon) && weapon.OwnerRef.HasValue)
        {
            var resolved = ResolveGuidToChannel(weapon.OwnerRef);
            if (resolved.HasValue && _pawns.TryGetValue(resolved.Value, out var pawn))
            {
                if (pawn.ResolvedPlayerChannel.HasValue && _players.TryGetValue(pawn.ResolvedPlayerChannel.Value, out var player))
                    attackerName = player.PlayerName;
            }
        }
        
        var knifeEvent = new KnifeEvent
        {
            Time = currentTime,
            EventType = export.bDead == true ? "KnifeKill" : "KnifeStab",
            AttackerName = attackerName,
            Description = export.bDead == true 
                ? $"{attackerName ?? "Unknown"} killed with knife" 
                : $"{attackerName ?? "Unknown"} stabbed with knife"
        };
        
        _gameEvents.Add(knifeEvent);
    }

    /// <summary>
    /// Handles killed with data RPC from health component.
    /// </summary>
    private void HandleKilledWithDataRPC(uint channelIndex, MulticastOnKilledWithData export)
    {
        if (!RecordTimeline) return;
        
        var currentTime = GetCurrentTime();
        
        // Try to identify the victim
        // The health component RPC comes in on the owning pawn's channel (subobject RPCs use parent channel)
        string? victimName = null;
        
        // Direct lookup: The channelIndex IS the pawn's channel
        if (_pawns.TryGetValue(channelIndex, out var pawn) && pawn.ResolvedPlayerChannel.HasValue)
        {
            if (_players.TryGetValue(pawn.ResolvedPlayerChannel.Value, out var player))
            {
                victimName = player.PlayerName;
            }
        }
        
        var killEvent = new KillEvent
        {
            Time = currentTime,
            EventType = "Death",
            VictimName = victimName,
            Description = $"{victimName ?? "Unknown"} was killed",
            Data = new Dictionary<string, object>
            {
                { "BoneName", export.BoneName ?? "unknown" },
                { "Location", export.Location?.ToString() ?? "unknown" }
            }
        };
        
        _gameEvents.Add(killEvent);
    }

    #endregion

    #region Generic Handler

    private void HandleGenericExport(uint channelIndex, INetFieldExportGroup exportGroup)
    {
        var typeName = exportGroup.GetType().Name;
        
        // Fallback detection for any state types we might have missed
        if (typeName.Contains("GameState", StringComparison.OrdinalIgnoreCase))
        {
            _gameData ??= new GameData();
            CopyPropertiesReflection(exportGroup, _gameData);
        }
        else if (typeName.Contains("PlayerState", StringComparison.OrdinalIgnoreCase))
        {
            if (!_players.TryGetValue(channelIndex, out var player))
            {
                player = new PlayerData();
                _players[channelIndex] = player;
            }
            CopyPropertiesReflection(exportGroup, player);
        }
    }

    private void CopyPropertiesReflection(object source, object target)
    {
        var sourceType = source.GetType();
        var targetType = target.GetType();

        foreach (var prop in sourceType.GetProperties())
        {
            var targetPropertyName = prop.Name == "PlayerNamePrivate" ? "PlayerName" : prop.Name;
            var targetProp = targetType.GetProperty(targetPropertyName);
            
            if (targetProp != null && targetProp.CanWrite)
            {
                try
                {
                    var value = prop.GetValue(source);
                    if (value != null)
                    {
                        targetProp.SetValue(target, value);
                    }
                }
                catch
                {
                    // Ignore conversion errors
                }
            }
        }
    }

    #endregion

    /// <summary>
    /// Once a replay is fully parsed, add the data built over time to the replay.
    /// </summary>
    public PavlovReplay Build(PavlovReplay replay)
    {
        // Core data
        replay.GameData = _gameData;
        replay.Players = _players.Values.ToList();
        
        // Pawn data (only include if we have any)
        if (_pawns.Count > 0)
            replay.Pawns = new Dictionary<uint, PawnData>(_pawns);
        
        // Weapon data
        if (_weapons.Count > 0)
            replay.Weapons = new Dictionary<uint, WeaponData>(_weapons);
        
        // Vehicle data
        if (_vehicles.Count > 0)
            replay.Vehicles = new Dictionary<uint, VehicleData>(_vehicles);
        
        // Bomb data (S&D)
        replay.Bomb = _bomb;
        if (_bombSites.Count > 0)
            replay.BombSites = _bombSites;
        
        // Game mode specific data
        replay.GameModeState = _gameModeData;
        if (_tttPlayers.Count > 0)
            replay.TTTPlayers = new Dictionary<uint, TTTPlayerData>(_tttPlayers);
        
        // Health components
        if (_healthComponents.Count > 0)
            replay.HealthComponents = new Dictionary<uint, HealthData>(_healthComponents);
        
        // Calculate duration using ReplicatedWorldTimeSeconds difference
        // This gives us the actual elapsed time from first to last world time update
        float? replayDuration = null;
        if (_hasFirstWorldTime && _lastWorldTime > _firstWorldTime)
        {
            replayDuration = _lastWorldTime - _firstWorldTime;
        }
        
        // Statistics
        replay.Stats = new ReplayStats
        {
            TotalExportsProcessed = _totalExportsProcessed,
            UniqueExportTypes = _exportTypeCounts.Count,
            ExportTypeCounts = new Dictionary<string, int>(_exportTypeCounts),
            MaxChannelIndex = _maxChannelIndex,
            ReplayDuration = replayDuration
        };
        
        return replay;
    }
    
    /// <summary>
    /// Builds a timeline export with all time-series data from the replay.
    /// Call this after Build() if you want timeline data.
    /// </summary>
    public ReplayTimeline BuildTimeline(string? fileName = null)
    {
        // Calculate duration using ReplicatedWorldTimeSeconds difference
        float duration = (_hasFirstWorldTime && _lastWorldTime > _firstWorldTime) 
            ? _lastWorldTime - _firstWorldTime 
            : 0f;
        
        var timeline = new ReplayTimeline
        {
            FileName = fileName,
            Duration = duration,
            GameMode = _gameData?.GameModeType?.ToString(),
            FinalTeam0Score = _gameData?.Team0Score ?? 0,
            FinalTeam1Score = _gameData?.Team1Score ?? 0,
            FinalPlayerStats = _players.Values.ToList(),
            Events = _gameEvents.OrderBy(e => e.Time).ToList()
        };
        
        // Process pawn timelines - link available metadata
        foreach (var pt in _pawnTimelines.Values)
        {
            if (pt.Snapshots.Count == 0)
                continue;
                
            var pawn = _pawns.GetValueOrDefault(pt.ChannelIndex);
            
            // Update timeline metadata from pawn
            if (pawn?.TeamId != null) pt.TeamId = pawn.TeamId;
            
            // Calculate time span for this pawn (first to last snapshot)
            var firstTime = pt.Snapshots[0].Time;
            var lastTime = pt.Snapshots[^1].Time;
            pt.FirstSnapshotTime = firstTime;
            pt.LastSnapshotTime = lastTime;
            
            // Try to link player name using the resolved player channel
            if (pawn?.ResolvedPlayerChannel != null)
            {
                if (_players.TryGetValue(pawn.ResolvedPlayerChannel.Value, out var player))
                {
                    pt.PlayerName = player.PlayerName;
                    pt.PlayerId = !string.IsNullOrEmpty(player.PlatformId) 
                        ? ulong.TryParse(player.PlatformId, out var pid) ? pid : null 
                        : null;
                    // Also update TeamId from player if pawn didn't have it
                    if (pt.TeamId == null)
                        pt.TeamId = player.TeamId;
                }
            }
            
            timeline.PawnTimelines.Add(pt);
        }
        
        // Sort timelines by snapshot count (most active first) to help identify main players
        timeline.PawnTimelines = timeline.PawnTimelines
            .OrderByDescending(pt => pt.Snapshots.Count)
            .ToList();
        
        return timeline;
    }
}
