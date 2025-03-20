using PavlovReplayReader.Models.NetFieldExports;
using System.Collections.Generic;
using Unreal.Core.Models;

namespace PavlovReplayReader.Models;

// TODO: Remove unused properties
public class PlayerData
{
    public PlayerData(PavlovPlayerState playerState)
    {
        Id = playerState.PlayerId;
        PlayerId = playerState.UniqueID;
        PlayerName = playerState.PlayerNamePrivate;
        TeamIndex = playerState.TeamId;
        Kills = (uint?)playerState.Kills;
        Deaths = (uint?)playerState.Deaths;
        Assists = (uint?)playerState.Assists;
        Cash = (uint?)playerState.Cash;
        PlatformId = playerState.PlatformId;
        bDead = playerState.bDead;
        PlayerHeight = playerState.PlayerHeight;
        bRightHanded = playerState.bRightHanded;
        bVirtualStock = playerState.bVirtualStock;
        bSpeaking = playerState.bSpeaking;
        LifetimeTeamKillCount = (uint?)playerState.LifetimeTeamKillCount;
        SkinOverride = playerState.SkinOverride;
    }

    public int? Id { get; set; }
    public string? PlayerId { get; set; }
    public string? PlayerName { get; set; }
    public int? TeamIndex { get; set; }
    public uint? Kills { get; set; }
    public uint? Deaths { get; set; }
    public uint? Assists { get; set; }
    public uint? Cash { get; set; }
    public int? PlatformId { get; set; }
    public bool? bDead { get; set; }
    public float? PlayerHeight { get; set; }
    public bool? bRightHanded { get; set; }
    public bool? bVirtualStock { get; set; }
    public bool? bSpeaking { get; set; }
    public uint? LifetimeTeamKillCount { get; set; }
    public string? SkinOverride { get; set; }

    public uint? RebootCounter { get; set; }
    public int? Placement { get; set; }
    public uint? TeamKills { get; set; }
    public int? DeathCause { get; set; }
    public int? DeathCircumstance { get; set; }
    public IEnumerable<string>? DeathTags { get; set; }
    public FVector? DeathLocation { get; set; }
    public float? DeathTime { get; set; }
    public double? DeathTimeDouble { get; set; }
    public uint? CurrentWeapon { get; internal set; }

    public IList<PlayerMovement> Locations { get; set; } = new List<PlayerMovement>();
}

public class Cosmetics
{
    public int? CharacterGender { get; set; }
    public int? CharacterBodyType { get; set; }
    public string? Parts { get; set; }
    public IEnumerable<string> VariantRequiredCharacterParts { get; set; }
    public string? HeroType { get; set; }
    public string? BannerIconId { get; set; }
    public string? BannerColorId { get; set; }
    public IEnumerable<string> ItemWraps { get; set; }
    public string SkyDiveContrail { get; set; }
    public string Glider { get; set; }
    public string Pickaxe { get; set; }
    public bool? IsDefaultCharacter { get; set; }
    public string Character { get; set; }
    public string Backpack { get; set; }
    public string LoadingScreen { get; set; }
    public IEnumerable<string> Dances { get; set; }
    public string MusicPack { get; set; }
    public string PetSkin { get; set; }
}

public class PlayerMovement
{
    public FRepMovement? ReplicatedMovement { get; set; }
    public float? ReplicatedWorldTimeSeconds { get; set; }

    public double? ReplicatedWorldTimeSecondsDouble { get; set; }

    public float? LastUpdateTime { get; set; }

    public bool? bIsCrouched { get; set; }
    public bool? bIsSprinting { get; set; }
    public bool? bIsJumping { get; set; }
    public bool? bIsSlopeSliding { get; set; }

    public bool? bIsZiplining { get; set; }
    public bool? bIsTargeting { get; set; }

    public bool? bIsDBNO { get; set; }

    public bool? bIsHonking { get; set; }
    public bool? bIsInAnyStorm { get; set; }

    public bool? bIsWaitingForEmoteInteraction { get; set; }
    public bool? bIsPlayingEmote { get; set; }

    public bool? bIsSkydiving { get; set; }
    public bool? bIsSkydivingFromLaunchPad { get; set; }
    public bool? bIsSkydivingFromBus { get; set; }
    public bool? bIsParachuteOpen { get; set; }
    public bool? bIsParachuteForcedOpen { get; set; }
    public bool? bIsInWaterVolume { get; set; }
}
