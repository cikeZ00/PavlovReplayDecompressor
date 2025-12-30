using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;
using PavlovReplayReader.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

/// <summary>
/// NetFieldExportGroup for TTT (Trouble in Terrorist Town) game state.
/// Contains TTT-specific role and game phase information.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.TTTGameState", minimalParseMode: ParseMode.Minimal)]
public class TTTGameStateExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets the remote role.
    /// </summary>
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public int? RemoteRole { get; set; }

    /// <summary>
    /// Gets or sets the role.
    /// </summary>
    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public int? Role { get; set; }

    /// <summary>
    /// Gets or sets whether roles have been assigned.
    /// </summary>
    [NetFieldExport("bRolesAssigned", RepLayoutCmdType.PropertyBool)]
    public bool? bRolesAssigned { get; set; }

    /// <summary>
    /// Gets or sets the current phase time remaining.
    /// </summary>
    [NetFieldExport("PhaseTimeRemaining", RepLayoutCmdType.PropertyFloat)]
    public float? PhaseTimeRemaining { get; set; }

    /// <summary>
    /// Gets or sets whether the round is in progress.
    /// </summary>
    [NetFieldExport("bRoundInProgress", RepLayoutCmdType.PropertyBool)]
    public bool? bRoundInProgress { get; set; }

    /// <summary>
    /// Gets or sets the number of innocents alive.
    /// </summary>
    [NetFieldExport("InnocentsAlive", RepLayoutCmdType.PropertyInt)]
    public int? InnocentsAlive { get; set; }

    /// <summary>
    /// Gets or sets the number of traitors alive.
    /// </summary>
    [NetFieldExport("TraitorsAlive", RepLayoutCmdType.PropertyInt)]
    public int? TraitorsAlive { get; set; }

    /// <summary>
    /// Gets or sets the number of detectives alive.
    /// </summary>
    [NetFieldExport("DetectivesAlive", RepLayoutCmdType.PropertyInt)]
    public int? DetectivesAlive { get; set; }

    /// <summary>
    /// Gets or sets the replicated world time seconds.
    /// </summary>
    [NetFieldExport("ReplicatedWorldTimeSeconds", RepLayoutCmdType.PropertyFloat)]
    public float? ReplicatedWorldTimeSeconds { get; set; }
}

/// <summary>
/// NetFieldExportGroup for TTT player state.
/// Contains player's TTT role information.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.TTTPlayerState", minimalParseMode: ParseMode.Minimal)]
public class TTTPlayerStateExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets the remote role.
    /// </summary>
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public int? RemoteRole { get; set; }

    /// <summary>
    /// Gets or sets the role.
    /// </summary>
    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public int? Role { get; set; }

    /// <summary>
    /// Gets or sets the owner reference.
    /// </summary>
    [NetFieldExport("Owner", RepLayoutCmdType.PropertyObject)]
    public uint? Owner { get; set; }

    /// <summary>
    /// Gets or sets the player's TTT role.
    /// </summary>
    [NetFieldExport("TTTRole", RepLayoutCmdType.Enum)]
    public int? TTTRole { get; set; }

    /// <summary>
    /// Gets or sets whether the player's role is revealed.
    /// </summary>
    [NetFieldExport("bRoleRevealed", RepLayoutCmdType.PropertyBool)]
    public bool? bRoleRevealed { get; set; }

    /// <summary>
    /// Gets or sets the karma value.
    /// </summary>
    [NetFieldExport("Karma", RepLayoutCmdType.PropertyFloat)]
    public float? Karma { get; set; }

    /// <summary>
    /// Gets or sets the credits for shop purchases.
    /// </summary>
    [NetFieldExport("Credits", RepLayoutCmdType.PropertyInt)]
    public int? Credits { get; set; }
}

/// <summary>
/// NetFieldExportGroup for Zombie Coop game state.
/// Contains zombie wave and survival information.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.ZombieCoopGameState", minimalParseMode: ParseMode.Minimal)]
public class ZombieCoopGameStateExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets the remote role.
    /// </summary>
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public int? RemoteRole { get; set; }

    /// <summary>
    /// Gets or sets the role.
    /// </summary>
    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public int? Role { get; set; }

    /// <summary>
    /// Gets or sets the current wave number.
    /// </summary>
    [NetFieldExport("CurrentWave", RepLayoutCmdType.PropertyInt)]
    public int? CurrentWave { get; set; }

    /// <summary>
    /// Gets or sets the maximum waves.
    /// </summary>
    [NetFieldExport("MaxWaves", RepLayoutCmdType.PropertyInt)]
    public int? MaxWaves { get; set; }

    /// <summary>
    /// Gets or sets the zombies remaining in current wave.
    /// </summary>
    [NetFieldExport("ZombiesRemaining", RepLayoutCmdType.PropertyInt)]
    public int? ZombiesRemaining { get; set; }

    /// <summary>
    /// Gets or sets the total zombies in wave.
    /// </summary>
    [NetFieldExport("TotalZombiesInWave", RepLayoutCmdType.PropertyInt)]
    public int? TotalZombiesInWave { get; set; }

    /// <summary>
    /// Gets or sets whether between waves.
    /// </summary>
    [NetFieldExport("bBetweenWaves", RepLayoutCmdType.PropertyBool)]
    public bool? bBetweenWaves { get; set; }

    /// <summary>
    /// Gets or sets the time until next wave.
    /// </summary>
    [NetFieldExport("TimeToNextWave", RepLayoutCmdType.PropertyFloat)]
    public float? TimeToNextWave { get; set; }

    /// <summary>
    /// Gets or sets the replicated world time seconds.
    /// </summary>
    [NetFieldExport("ReplicatedWorldTimeSeconds", RepLayoutCmdType.PropertyFloat)]
    public float? ReplicatedWorldTimeSeconds { get; set; }
}

/// <summary>
/// NetFieldExportGroup for The Hidden game state.
/// Contains Hidden-specific game information.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.TheHiddenGameState", minimalParseMode: ParseMode.Minimal)]
public class TheHiddenGameStateExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets the remote role.
    /// </summary>
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public int? RemoteRole { get; set; }

    /// <summary>
    /// Gets or sets the role.
    /// </summary>
    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public int? Role { get; set; }

    /// <summary>
    /// Gets or sets the Hidden player reference.
    /// </summary>
    [NetFieldExport("HiddenPlayer", RepLayoutCmdType.PropertyObject)]
    public uint? HiddenPlayer { get; set; }

    /// <summary>
    /// Gets or sets the Hidden's remaining health.
    /// </summary>
    [NetFieldExport("HiddenHealth", RepLayoutCmdType.PropertyFloat)]
    public float? HiddenHealth { get; set; }

    /// <summary>
    /// Gets or sets whether the Hidden is visible.
    /// </summary>
    [NetFieldExport("bHiddenVisible", RepLayoutCmdType.PropertyBool)]
    public bool? bHiddenVisible { get; set; }

    /// <summary>
    /// Gets or sets the number of IRIS alive.
    /// </summary>
    [NetFieldExport("IRISAlive", RepLayoutCmdType.PropertyInt)]
    public int? IRISAlive { get; set; }

    /// <summary>
    /// Gets or sets the replicated world time seconds.
    /// </summary>
    [NetFieldExport("ReplicatedWorldTimeSeconds", RepLayoutCmdType.PropertyFloat)]
    public float? ReplicatedWorldTimeSeconds { get; set; }
}

/// <summary>
/// NetFieldExportGroup for Gun Game state.
/// Contains gun game level and progression information.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.GunGameState", minimalParseMode: ParseMode.Minimal)]
public class GunGameStateExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets the remote role.
    /// </summary>
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public int? RemoteRole { get; set; }

    /// <summary>
    /// Gets or sets the role.
    /// </summary>
    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public int? Role { get; set; }

    /// <summary>
    /// Gets or sets the total number of gun levels.
    /// </summary>
    [NetFieldExport("TotalGunLevels", RepLayoutCmdType.PropertyInt)]
    public int? TotalGunLevels { get; set; }

    /// <summary>
    /// Gets or sets the leader's current gun level.
    /// </summary>
    [NetFieldExport("LeaderGunLevel", RepLayoutCmdType.PropertyInt)]
    public int? LeaderGunLevel { get; set; }

    /// <summary>
    /// Gets or sets the leader player reference.
    /// </summary>
    [NetFieldExport("LeaderPlayer", RepLayoutCmdType.PropertyObject)]
    public uint? LeaderPlayer { get; set; }

    /// <summary>
    /// Gets or sets the replicated world time seconds.
    /// </summary>
    [NetFieldExport("ReplicatedWorldTimeSeconds", RepLayoutCmdType.PropertyFloat)]
    public float? ReplicatedWorldTimeSeconds { get; set; }
}

/// <summary>
/// NetFieldExportGroup for Prop Hunt game state.
/// Contains prop hunt specific information.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.PropHuntGameState", minimalParseMode: ParseMode.Minimal)]
public class PropHuntGameStateExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets the remote role.
    /// </summary>
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public int? RemoteRole { get; set; }

    /// <summary>
    /// Gets or sets the role.
    /// </summary>
    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public int? Role { get; set; }

    /// <summary>
    /// Gets or sets the number of props alive.
    /// </summary>
    [NetFieldExport("PropsAlive", RepLayoutCmdType.PropertyInt)]
    public int? PropsAlive { get; set; }

    /// <summary>
    /// Gets or sets the number of hunters alive.
    /// </summary>
    [NetFieldExport("HuntersAlive", RepLayoutCmdType.PropertyInt)]
    public int? HuntersAlive { get; set; }

    /// <summary>
    /// Gets or sets whether hide phase is active.
    /// </summary>
    [NetFieldExport("bHidePhase", RepLayoutCmdType.PropertyBool)]
    public bool? bHidePhase { get; set; }

    /// <summary>
    /// Gets or sets the hide time remaining.
    /// </summary>
    [NetFieldExport("HideTimeRemaining", RepLayoutCmdType.PropertyFloat)]
    public float? HideTimeRemaining { get; set; }

    /// <summary>
    /// Gets or sets the replicated world time seconds.
    /// </summary>
    [NetFieldExport("ReplicatedWorldTimeSeconds", RepLayoutCmdType.PropertyFloat)]
    public float? ReplicatedWorldTimeSeconds { get; set; }
}

/// <summary>
/// NetFieldExportGroup for Infection game state.
/// Contains infection mode specific information.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.InfectionGameState", minimalParseMode: ParseMode.Minimal)]
public class InfectionGameStateExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets the remote role.
    /// </summary>
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public int? RemoteRole { get; set; }

    /// <summary>
    /// Gets or sets the role.
    /// </summary>
    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public int? Role { get; set; }

    /// <summary>
    /// Gets or sets the number of survivors.
    /// </summary>
    [NetFieldExport("SurvivorsCount", RepLayoutCmdType.PropertyInt)]
    public int? SurvivorsCount { get; set; }

    /// <summary>
    /// Gets or sets the number of infected.
    /// </summary>
    [NetFieldExport("InfectedCount", RepLayoutCmdType.PropertyInt)]
    public int? InfectedCount { get; set; }

    /// <summary>
    /// Gets or sets whether alpha has been selected.
    /// </summary>
    [NetFieldExport("bAlphaSelected", RepLayoutCmdType.PropertyBool)]
    public bool? bAlphaSelected { get; set; }

    /// <summary>
    /// Gets or sets the alpha player reference.
    /// </summary>
    [NetFieldExport("AlphaPlayer", RepLayoutCmdType.PropertyObject)]
    public uint? AlphaPlayer { get; set; }

    /// <summary>
    /// Gets or sets the replicated world time seconds.
    /// </summary>
    [NetFieldExport("ReplicatedWorldTimeSeconds", RepLayoutCmdType.PropertyFloat)]
    public float? ReplicatedWorldTimeSeconds { get; set; }
}

/// <summary>
/// NetFieldExportGroup for Jailbreak game state.
/// Contains jailbreak mode specific information.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.JailbreakGameState", minimalParseMode: ParseMode.Minimal)]
public class JailbreakGameStateExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets the remote role.
    /// </summary>
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public int? RemoteRole { get; set; }

    /// <summary>
    /// Gets or sets the role.
    /// </summary>
    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public int? Role { get; set; }

    /// <summary>
    /// Gets or sets the warden player reference.
    /// </summary>
    [NetFieldExport("Warden", RepLayoutCmdType.PropertyObject)]
    public uint? Warden { get; set; }

    /// <summary>
    /// Gets or sets the number of guards alive.
    /// </summary>
    [NetFieldExport("GuardsAlive", RepLayoutCmdType.PropertyInt)]
    public int? GuardsAlive { get; set; }

    /// <summary>
    /// Gets or sets the number of prisoners alive.
    /// </summary>
    [NetFieldExport("PrisonersAlive", RepLayoutCmdType.PropertyInt)]
    public int? PrisonersAlive { get; set; }

    /// <summary>
    /// Gets or sets whether last request is active.
    /// </summary>
    [NetFieldExport("bLastRequest", RepLayoutCmdType.PropertyBool)]
    public bool? bLastRequest { get; set; }

    /// <summary>
    /// Gets or sets the replicated world time seconds.
    /// </summary>
    [NetFieldExport("ReplicatedWorldTimeSeconds", RepLayoutCmdType.PropertyFloat)]
    public float? ReplicatedWorldTimeSeconds { get; set; }
}
