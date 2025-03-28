using PavlovReplayReader.Models.NetFieldExports;
using System.Collections.Generic;
using Unreal.Core.Models;

namespace PavlovReplayReader.Models;

// TODO: Remove unused properties
public class PlayerData
{
    public PlayerData(PavlovPlayerState playerState)
    {
        Id = playerState.PlayerId ?? Id;
        PlayerId = playerState.UniqueID ?? PlayerId;
        PlayerName = playerState.PlayerNamePrivate ?? PlayerName;
        TeamIndex = playerState.TeamId ?? TeamIndex;
        Kills = (uint?) playerState.Kills ?? Kills;
        Deaths = (uint?) playerState.Deaths ?? Deaths;
        Assists = (uint?) playerState.Assists ?? Assists;
        Cash = (uint?) playerState.Cash ?? Cash;
        PlatformId = playerState.PlatformId ?? PlatformId;
        bDead = playerState.bDead ?? bDead;
        PlayerHeight = playerState.PlayerHeight ?? PlayerHeight;
        bRightHanded = playerState.bRightHanded ?? bRightHanded;
        bVirtualStock = playerState.bVirtualStock ?? bVirtualStock;
        bSpeaking = playerState.bSpeaking ?? bSpeaking;
        LifetimeTeamKillCount = (uint?) playerState.LifetimeTeamKillCount ?? LifetimeTeamKillCount;
        SkinOverride = playerState.SkinOverride ?? SkinOverride;
    }

    public int? Id { get; set; } = -1;
    public string? PlayerId { get; set; } = "Unknown";
    public string? PlayerName { get; set; } = "Unknown";
    public int? TeamIndex { get; set; } = -1;
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
    public uint? Instigator { get; set; }
    public uint? Controller { get; set; }
    public uint? RevivePlayerState { get; set; }
    public uint? AvatarSkinClass { get; set; }
    public uint? CustomMesh { get; set; }
    public byte? RadioChannel { get; set; }
    public int? Armour { get; set; }
    public int? HelmetArmour { get; set; }
    public byte? TeamId { get; set; }
    public uint? WorkshopProxy { get; set; }
    public int? AvatarId { get; set; }

    public IList<PlayerMovement> Locations { get; set; } = new List<PlayerMovement>();
}

public class PlayerMovement
{
    // Multiple location values captured from the replay:
    public FVector? Location { get; set; }
    public FVector? Location1 { get; set; }
    public FVector? Location2 { get; set; }
    public FVector? Location3 { get; set; }

    // Single velocity value:
    public FVector Velocity { get; set; }

    // Heading, which is stored separately:
    public FRotator Heading { get; set; }

    // Multiple rotation values captured from the replay:
    public FRotator? Rotation { get; set; }
    public FRotator? Rotation1 { get; set; }
    public FRotator? Rotation2 { get; set; }
}


