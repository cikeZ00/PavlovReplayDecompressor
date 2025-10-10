using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

[NetFieldExportGroup("/Script/Pavlov.PavlovPlayerState", minimalParseMode: ParseMode.Minimal)]
public class PavlovPlayerStateExport : INetFieldExportGroup
{
    [NetFieldExport("TeamId", RepLayoutCmdType.PropertyInt)]
    public int? TeamId { get; set; }

    [NetFieldExport("Kills", RepLayoutCmdType.PropertyInt)]
    public int? Kills { get; set; }

    [NetFieldExport("Deaths", RepLayoutCmdType.PropertyInt)]
    public int? Deaths { get; set; }

    [NetFieldExport("Assists", RepLayoutCmdType.PropertyInt)]
    public int? Assists { get; set; }

    [NetFieldExport("Cash", RepLayoutCmdType.PropertyInt)]
    public int? Cash { get; set; }

    [NetFieldExport("Exp", RepLayoutCmdType.PropertyInt)]
    public int? Exp { get; set; }

    [NetFieldExport("Progress", RepLayoutCmdType.PropertyInt)]
    public int? Progress { get; set; }

    [NetFieldExport("PlatformId", RepLayoutCmdType.PropertyString)]
    public string? PlatformId { get; set; }

    // From base Engine.PlayerState class
    [NetFieldExport("PlayerNamePrivate", RepLayoutCmdType.PropertyString)]
    public string? PlayerNamePrivate { get; set; }

    [NetFieldExport("bDead", RepLayoutCmdType.PropertyBool)]
    public bool? bDead { get; set; }

    [NetFieldExport("bDev", RepLayoutCmdType.PropertyBool)]
    public bool? bDev { get; set; }

    [NetFieldExport("Flair", RepLayoutCmdType.Enum)]
    public int? Flair { get; set; }

    [NetFieldExport("RespawnCountdown", RepLayoutCmdType.PropertyInt)]
    public int? RespawnCountdown { get; set; }

    [NetFieldExport("PlayerHeight", RepLayoutCmdType.PropertyFloat)]
    public float? PlayerHeight { get; set; }

    [NetFieldExport("bRightHanded", RepLayoutCmdType.PropertyBool)]
    public bool? bRightHanded { get; set; }

    [NetFieldExport("bVirtualStock", RepLayoutCmdType.PropertyBool)]
    public bool? bVirtualStock { get; set; }

    [NetFieldExport("bCanVote", RepLayoutCmdType.PropertyBool)]
    public bool? bCanVote { get; set; }

    [NetFieldExport("bSpeaking", RepLayoutCmdType.PropertyBool)]
    public bool? bSpeaking { get; set; }

    [NetFieldExport("bGagged", RepLayoutCmdType.PropertyBool)]
    public bool? bGagged { get; set; }

    [NetFieldExport("PlayerPlatform", RepLayoutCmdType.Enum)]
    public int? PlayerPlatform { get; set; }

    [NetFieldExport("bAuthenticated", RepLayoutCmdType.PropertyBool)]
    public bool? bAuthenticated { get; set; }

    [NetFieldExport("LifeTeamKillCount", RepLayoutCmdType.PropertyInt)]
    public int? LifeTeamKillCount { get; set; }

    [NetFieldExport("LifetimeTeamKillCount", RepLayoutCmdType.PropertyInt)]
    public int? LifetimeTeamKillCount { get; set; }

    [NetFieldExport("ExtraRespawnCountdown", RepLayoutCmdType.PropertyFloat)]
    public float? ExtraRespawnCountdown { get; set; }

    [NetFieldExport("DeadTime", RepLayoutCmdType.PropertyFloat)]
    public float? DeadTime { get; set; }

    [NetFieldExport("bSpawnGhost", RepLayoutCmdType.PropertyBool)]
    public bool? bSpawnGhost { get; set; }

    [NetFieldExport("bHasPlayerProxy", RepLayoutCmdType.PropertyBool)]
    public bool? bHasPlayerProxy { get; set; }

    // Note: PlayerName is inherited from PlayerState base class, not in PavlovPlayerState dump
    [NetFieldExport("PlayerName", RepLayoutCmdType.PropertyString)]
    public string? PlayerName { get; set; }

    // Note: PlayerId is inherited from PlayerState base class  
    [NetFieldExport("PlayerId", RepLayoutCmdType.PropertyInt)]
    public int? PlayerId { get; set; }

    // Note: Score is inherited from PlayerState base class
    [NetFieldExport("Score", RepLayoutCmdType.PropertyFloat)]
    public float? Score { get; set; }

    // Note: Ping and StartTime are inherited from PlayerState base class
    [NetFieldExport("Ping", RepLayoutCmdType.PropertyInt)]
    public int? Ping { get; set; }

    [NetFieldExport("StartTime", RepLayoutCmdType.PropertyInt)]
    public int? StartTime { get; set; }

    [NetFieldExport("SkinOverride", RepLayoutCmdType.PropertyName)]
    public string? SkinOverride { get; set; }

    // Note: The following properties are available in the dump but require special handling:
    // - VoiceChannelPrimary (ObjectProperty) - Voice channel object reference
    // - VoiceChannelSecondary (ObjectProperty) - Voice channel object reference
    // - Purchases (MapProperty) - Map of purchased items
    // - EquippedSkins (MapProperty) - Map of equipped skins
    // - OnCashUpdated (MulticastInlineDelegateProperty) - Cash update event delegate
}

