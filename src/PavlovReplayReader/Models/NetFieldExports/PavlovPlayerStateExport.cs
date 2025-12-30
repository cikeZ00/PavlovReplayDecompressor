using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

/// <summary>
/// NetFieldExportGroup for Pavlov Player State.
/// Property handles from Debug.txt:
/// - 4: RemoteRole, 12: Owner, 13: Role
/// - 15: Score, 16: PlayerId, 17: CompressedPing
/// - 19: bOnlySpectator, 23: StartTime, 24: UniqueID, 25: PlayerNamePrivate
/// - 26: TeamId, 27: Kills, 28: Deaths, 29: Assists, 30: Cash
/// - 33: PlatformId, 34: bDead, 37: PlayerHeight
/// - 38: bRightHanded, 39: bVirtualStock, 41: bSpeaking
/// - 43: PlayerPlatform, 44: LifetimeTeamKillCount
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.PavlovPlayerState", minimalParseMode: ParseMode.Minimal)]
public class PavlovPlayerStateExport : INetFieldExportGroup
{
    #region Base Actor Properties (inherited from PlayerState)

    /// <summary>
    /// Gets or sets the remote role (handle 4). Ignored.
    /// </summary>
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public int? RemoteRole { get; set; }

    /// <summary>
    /// Gets or sets the owner reference (handle 12).
    /// </summary>
    [NetFieldExport("Owner", RepLayoutCmdType.PropertyObject)]
    public uint? Owner { get; set; }

    /// <summary>
    /// Gets or sets the role (handle 13). Ignored.
    /// </summary>
    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public int? Role { get; set; }

    /// <summary>
    /// Gets or sets the score (handle 15).
    /// </summary>
    [NetFieldExport("Score", RepLayoutCmdType.PropertyFloat)]
    public float? Score { get; set; }

    /// <summary>
    /// Gets or sets the player ID (handle 16).
    /// </summary>
    [NetFieldExport("PlayerId", RepLayoutCmdType.PropertyInt)]
    public int? PlayerId { get; set; }

    /// <summary>
    /// Gets or sets the compressed ping value (handle 17).
    /// </summary>
    [NetFieldExport("CompressedPing", RepLayoutCmdType.PropertyByte)]
    public byte? CompressedPing { get; set; }

    /// <summary>
    /// Gets or sets whether this is a spectator only (handle 19).
    /// </summary>
    [NetFieldExport("bOnlySpectator", RepLayoutCmdType.PropertyBool)]
    public bool? bOnlySpectator { get; set; }

    /// <summary>
    /// Gets or sets the start time (handle 23).
    /// </summary>
    [NetFieldExport("StartTime", RepLayoutCmdType.PropertyInt)]
    public int? StartTime { get; set; }

    /// <summary>
    /// Gets or sets the unique network ID (handle 24).
    /// </summary>
    [NetFieldExport("UniqueID", RepLayoutCmdType.PropertyNetId)]
    public string? UniqueID { get; set; }

    /// <summary>
    /// Gets or sets the player name (handle 25).
    /// </summary>
    [NetFieldExport("PlayerNamePrivate", RepLayoutCmdType.PropertyString)]
    public string? PlayerNamePrivate { get; set; }

    /// <summary>
    /// Gets or sets the ping (from Ping property, may be decoded from CompressedPing).
    /// </summary>
    [NetFieldExport("Ping", RepLayoutCmdType.PropertyInt)]
    public int? Ping { get; set; }

    /// <summary>
    /// Gets or sets the player name (alternative property).
    /// </summary>
    [NetFieldExport("PlayerName", RepLayoutCmdType.PropertyString)]
    public string? PlayerName { get; set; }

    #endregion

    #region Pavlov-Specific Properties

    /// <summary>
    /// Gets or sets the team ID (handle 26).
    /// </summary>
    [NetFieldExport("TeamId", RepLayoutCmdType.PropertyInt)]
    public int? TeamId { get; set; }

    /// <summary>
    /// Gets or sets the kill count (handle 27).
    /// </summary>
    [NetFieldExport("Kills", RepLayoutCmdType.PropertyInt)]
    public int? Kills { get; set; }

    /// <summary>
    /// Gets or sets the death count (handle 28).
    /// </summary>
    [NetFieldExport("Deaths", RepLayoutCmdType.PropertyInt)]
    public int? Deaths { get; set; }

    /// <summary>
    /// Gets or sets the assist count (handle 29).
    /// </summary>
    [NetFieldExport("Assists", RepLayoutCmdType.PropertyInt)]
    public int? Assists { get; set; }

    /// <summary>
    /// Gets or sets the cash amount (handle 30).
    /// </summary>
    [NetFieldExport("Cash", RepLayoutCmdType.PropertyInt)]
    public int? Cash { get; set; }

    /// <summary>
    /// Gets or sets the platform ID (handle 33) - Steam/Oculus ID.
    /// </summary>
    [NetFieldExport("PlatformId", RepLayoutCmdType.PropertyString)]
    public string? PlatformId { get; set; }

    /// <summary>
    /// Gets or sets whether the player is dead (handle 34).
    /// </summary>
    [NetFieldExport("bDead", RepLayoutCmdType.PropertyBool)]
    public bool? bDead { get; set; }

    /// <summary>
    /// Gets or sets the player height setting (handle 37).
    /// </summary>
    [NetFieldExport("PlayerHeight", RepLayoutCmdType.PropertyFloat)]
    public float? PlayerHeight { get; set; }

    /// <summary>
    /// Gets or sets whether the player is right-handed (handle 38).
    /// </summary>
    [NetFieldExport("bRightHanded", RepLayoutCmdType.PropertyBool)]
    public bool? bRightHanded { get; set; }

    /// <summary>
    /// Gets or sets whether virtual stock is enabled (handle 39).
    /// </summary>
    [NetFieldExport("bVirtualStock", RepLayoutCmdType.PropertyBool)]
    public bool? bVirtualStock { get; set; }

    /// <summary>
    /// Gets or sets whether the player is speaking (handle 41).
    /// </summary>
    [NetFieldExport("bSpeaking", RepLayoutCmdType.PropertyBool)]
    public bool? bSpeaking { get; set; }

    /// <summary>
    /// Gets or sets the player platform type (handle 43).
    /// </summary>
    [NetFieldExport("PlayerPlatform", RepLayoutCmdType.Enum)]
    public int? PlayerPlatform { get; set; }

    /// <summary>
    /// Gets or sets the lifetime team kill count (handle 44).
    /// </summary>
    [NetFieldExport("LifetimeTeamKillCount", RepLayoutCmdType.PropertyInt)]
    public int? LifetimeTeamKillCount { get; set; }

    #endregion

    #region Additional Properties (may not be replicated in all versions)

    [NetFieldExport("Exp", RepLayoutCmdType.PropertyInt)]
    public int? Exp { get; set; }

    [NetFieldExport("Progress", RepLayoutCmdType.PropertyInt)]
    public int? Progress { get; set; }

    [NetFieldExport("bDev", RepLayoutCmdType.PropertyBool)]
    public bool? bDev { get; set; }

    [NetFieldExport("Flair", RepLayoutCmdType.Enum)]
    public int? Flair { get; set; }

    [NetFieldExport("RespawnCountdown", RepLayoutCmdType.PropertyInt)]
    public int? RespawnCountdown { get; set; }

    [NetFieldExport("bCanVote", RepLayoutCmdType.PropertyBool)]
    public bool? bCanVote { get; set; }

    [NetFieldExport("bGagged", RepLayoutCmdType.PropertyBool)]
    public bool? bGagged { get; set; }

    [NetFieldExport("bAuthenticated", RepLayoutCmdType.PropertyBool)]
    public bool? bAuthenticated { get; set; }

    [NetFieldExport("LifeTeamKillCount", RepLayoutCmdType.PropertyInt)]
    public int? LifeTeamKillCount { get; set; }

    [NetFieldExport("ExtraRespawnCountdown", RepLayoutCmdType.PropertyFloat)]
    public float? ExtraRespawnCountdown { get; set; }

    [NetFieldExport("DeadTime", RepLayoutCmdType.PropertyFloat)]
    public float? DeadTime { get; set; }

    [NetFieldExport("bSpawnGhost", RepLayoutCmdType.PropertyBool)]
    public bool? bSpawnGhost { get; set; }

    [NetFieldExport("bHasPlayerProxy", RepLayoutCmdType.PropertyBool)]
    public bool? bHasPlayerProxy { get; set; }

    [NetFieldExport("SkinOverride", RepLayoutCmdType.PropertyName)]
    public string? SkinOverride { get; set; }

    #endregion
}
