using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

/// <summary>
/// NetFieldExportGroup for Pavlov Game State.
/// Property handles from Debug.txt:
/// - 4: RemoteRole, 13: Role, 15: GameModeClass, 16: SpectatorClass
/// - 17: bReplicatedHasBegunPlay, 18: ReplicatedWorldTimeSeconds, 19: MatchState
/// - 31,32: Team1, 35: bMovementDisabled
/// - 38: Team0Score, 39: Team1Score, 41: RoundTime
/// - 43: AttackingTeam, 44: RoundWinner, 45: RoundsLeft
/// - 50: NameTagClass, 53: bPreventGrenadePin, 56: GameModeType
/// - 59: BuyMenuScript, 60: BalancingCSV, 61,62: SpawnableEquipment
/// - 64: MaxPlayers, 66: Holiday, 71: GlobalInfo
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.PavlovGameState", minimalParseMode: ParseMode.Minimal)]
public class PavlovGameStateExport : INetFieldExportGroup
{
    #region Base Actor Properties

    /// <summary>
    /// Gets or sets the remote role (handle 4). Ignored.
    /// </summary>
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public int? RemoteRole { get; set; }

    /// <summary>
    /// Gets or sets the role (handle 13). Ignored.
    /// </summary>
    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public int? Role { get; set; }

    /// <summary>
    /// Gets or sets the game mode class reference (handle 15).
    /// </summary>
    [NetFieldExport("GameModeClass", RepLayoutCmdType.PropertyObject)]
    public uint? GameModeClass { get; set; }

    /// <summary>
    /// Gets or sets the spectator class reference (handle 16).
    /// </summary>
    [NetFieldExport("SpectatorClass", RepLayoutCmdType.PropertyObject)]
    public uint? SpectatorClass { get; set; }

    /// <summary>
    /// Gets or sets whether replicated has begun play (handle 17).
    /// </summary>
    [NetFieldExport("bReplicatedHasBegunPlay", RepLayoutCmdType.PropertyBool)]
    public bool? bReplicatedHasBegunPlay { get; set; }

    /// <summary>
    /// Gets or sets the replicated world time seconds (handle 18).
    /// </summary>
    [NetFieldExport("ReplicatedWorldTimeSeconds", RepLayoutCmdType.PropertyFloat)]
    public float? ReplicatedWorldTimeSeconds { get; set; }

    /// <summary>
    /// Gets or sets the match state string (handle 19).
    /// </summary>
    [NetFieldExport("MatchState", RepLayoutCmdType.PropertyName)]
    public string? MatchState { get; set; }

    #endregion

    #region Team Data

    /// <summary>
    /// Gets or sets team 1 data (handle 31). Ignored - complex struct.
    /// </summary>
    [NetFieldExport("Team1", RepLayoutCmdType.Ignore)]
    public object? Team1 { get; set; }

    #endregion

    #region Game Settings

    [NetFieldExport("bNoTeams", RepLayoutCmdType.PropertyBool)]
    public bool? bNoTeams { get; set; }

    /// <summary>
    /// Gets or sets whether movement is disabled (handle 35).
    /// </summary>
    [NetFieldExport("bMovementDisabled", RepLayoutCmdType.PropertyBool)]
    public bool? bMovementDisabled { get; set; }

    [NetFieldExport("bNoFallDamage", RepLayoutCmdType.PropertyBool)]
    public bool? bNoFallDamage { get; set; }

    [NetFieldExport("bLimitedAmmo", RepLayoutCmdType.PropertyBool)]
    public bool? bLimitedAmmo { get; set; }

    #endregion

    #region Score and Round Data

    /// <summary>
    /// Gets or sets Team 0's score (handle 38).
    /// </summary>
    [NetFieldExport("Team0Score", RepLayoutCmdType.PropertyInt)]
    public int? Team0Score { get; set; }

    /// <summary>
    /// Gets or sets Team 1's score (handle 39).
    /// </summary>
    [NetFieldExport("Team1Score", RepLayoutCmdType.PropertyInt)]
    public int? Team1Score { get; set; }

    [NetFieldExport("RoundDuration", RepLayoutCmdType.PropertyInt)]
    public int? RoundDuration { get; set; }

    /// <summary>
    /// Gets or sets the round time (handle 41).
    /// </summary>
    [NetFieldExport("RoundTime", RepLayoutCmdType.PropertyInt)]
    public int? RoundTime { get; set; }

    [NetFieldExport("PauseTime", RepLayoutCmdType.PropertyInt)]
    public int? PauseTime { get; set; }

    /// <summary>
    /// Gets or sets the attacking team (handle 43).
    /// </summary>
    [NetFieldExport("AttackingTeam", RepLayoutCmdType.PropertyInt)]
    public int? AttackingTeam { get; set; }

    /// <summary>
    /// Gets or sets the round winner (handle 44).
    /// </summary>
    [NetFieldExport("RoundWinner", RepLayoutCmdType.PropertyInt)]
    public int? RoundWinner { get; set; }

    /// <summary>
    /// Gets or sets the rounds left (handle 45).
    /// </summary>
    [NetFieldExport("RoundsLeft", RepLayoutCmdType.PropertyInt)]
    public int? RoundsLeft { get; set; }

    [NetFieldExport("bMatchTimePaused", RepLayoutCmdType.PropertyBool)]
    public bool? bMatchTimePaused { get; set; }

    [NetFieldExport("MatchTime", RepLayoutCmdType.PropertyFloat)]
    public float? MatchTime { get; set; }

    #endregion

    #region UI and Visual Settings

    /// <summary>
    /// Gets or sets the name tag class reference (handle 50).
    /// </summary>
    [NetFieldExport("NameTagClass", RepLayoutCmdType.PropertyObject)]
    public uint? NameTagClass { get; set; }

    [NetFieldExport("bShowNameTags", RepLayoutCmdType.PropertyBool)]
    public bool? bShowNameTags { get; set; }

    [NetFieldExport("CompetitiveMode", RepLayoutCmdType.Enum)]
    public int? CompetitiveMode { get; set; }

    #endregion

    #region Game Rules

    /// <summary>
    /// Gets or sets whether grenade pin is prevented (handle 53).
    /// </summary>
    [NetFieldExport("bPreventGrenadePin", RepLayoutCmdType.PropertyBool)]
    public bool? bPreventGrenadePin { get; set; }

    [NetFieldExport("bEnableProne", RepLayoutCmdType.PropertyBool)]
    public bool? bEnableProne { get; set; }

    [NetFieldExport("bCanReviveEnemies", RepLayoutCmdType.PropertyBool)]
    public bool? bCanReviveEnemies { get; set; }

    /// <summary>
    /// Gets or sets the game mode type (handle 56).
    /// </summary>
    [NetFieldExport("GameModeType", RepLayoutCmdType.Enum)]
    public int? GameModeType { get; set; }

    [NetFieldExport("AFKTimeLimit", RepLayoutCmdType.PropertyInt)]
    public int? AFKTimeLimit { get; set; }

    [NetFieldExport("bCanSwitchTeams", RepLayoutCmdType.PropertyBool)]
    public bool? bCanSwitchTeams { get; set; }

    #endregion

    #region Buy Menu and Equipment

    /// <summary>
    /// Gets or sets the buy menu script (handle 59).
    /// </summary>
    [NetFieldExport("BuyMenuScript", RepLayoutCmdType.PropertyString)]
    public string? BuyMenuScript { get; set; }

    /// <summary>
    /// Gets or sets the balancing CSV (handle 60).
    /// </summary>
    [NetFieldExport("BalancingCSV", RepLayoutCmdType.PropertyString)]
    public string? BalancingCSV { get; set; }

    /// <summary>
    /// Gets or sets spawnable equipment (handles 61,62). Ignored - array.
    /// </summary>
    [NetFieldExport("SpawnableEquipment", RepLayoutCmdType.Ignore)]
    public object? SpawnableEquipment { get; set; }

    [NetFieldExport("ModdedItemEquipmentIndex", RepLayoutCmdType.PropertyInt)]
    public int? ModdedItemEquipmentIndex { get; set; }

    #endregion

    #region Server Settings

    /// <summary>
    /// Gets or sets the max players (handle 64).
    /// </summary>
    [NetFieldExport("MaxPlayers", RepLayoutCmdType.PropertyInt)]
    public int? MaxPlayers { get; set; }

    [NetFieldExport("bPinProtected", RepLayoutCmdType.PropertyBool)]
    public bool? bPinProtected { get; set; }

    /// <summary>
    /// Gets or sets the holiday mode (handle 66).
    /// </summary>
    [NetFieldExport("Holiday", RepLayoutCmdType.Enum)]
    public int? Holiday { get; set; }

    [NetFieldExport("bCanAutoEjectVehicles", RepLayoutCmdType.PropertyBool)]
    public bool? bCanAutoEjectVehicles { get; set; }

    /// <summary>
    /// Gets or sets the global info reference (handle 71). Ignored.
    /// </summary>
    [NetFieldExport("GlobalInfo", RepLayoutCmdType.PropertyObject)]
    public uint? GlobalInfo { get; set; }

    #endregion
}

