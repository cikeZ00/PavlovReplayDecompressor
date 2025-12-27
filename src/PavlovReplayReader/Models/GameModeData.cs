using PavlovReplayReader.Models.Enums;

namespace PavlovReplayReader.Models;

/// <summary>
/// Represents game mode specific state data.
/// </summary>
public class GameModeData
{
    /// <summary>
    /// The game mode type this data is for.
    /// </summary>
    public string? GameModeType { get; set; }

    /// <summary>
    /// Replay time when this data was last updated.
    /// </summary>
    public float LastUpdateTime { get; set; }

    /// <summary>
    /// Replicated world time in seconds.
    /// </summary>
    public float? ReplicatedWorldTimeSeconds { get; set; }

    #region TTT (Trouble in Terrorist Town)

    /// <summary>
    /// Whether roles have been assigned (TTT).
    /// </summary>
    public bool? TTT_RolesAssigned { get; set; }

    /// <summary>
    /// Phase time remaining (TTT).
    /// </summary>
    public float? TTT_PhaseTimeRemaining { get; set; }

    /// <summary>
    /// Whether the round is in progress (TTT).
    /// </summary>
    public bool? TTT_RoundInProgress { get; set; }

    /// <summary>
    /// Number of innocents alive (TTT).
    /// </summary>
    public int? TTT_InnocentsAlive { get; set; }

    /// <summary>
    /// Number of traitors alive (TTT).
    /// </summary>
    public int? TTT_TraitorsAlive { get; set; }

    /// <summary>
    /// Number of detectives alive (TTT).
    /// </summary>
    public int? TTT_DetectivesAlive { get; set; }

    #endregion

    #region Zombie Coop

    /// <summary>
    /// Current wave number (Zombie Coop).
    /// </summary>
    public int? Zombie_CurrentWave { get; set; }

    /// <summary>
    /// Maximum waves (Zombie Coop).
    /// </summary>
    public int? Zombie_MaxWaves { get; set; }

    /// <summary>
    /// Zombies remaining in current wave (Zombie Coop).
    /// </summary>
    public int? Zombie_ZombiesRemaining { get; set; }

    /// <summary>
    /// Total zombies in the wave (Zombie Coop).
    /// </summary>
    public int? Zombie_TotalZombiesInWave { get; set; }

    /// <summary>
    /// Whether between waves (Zombie Coop).
    /// </summary>
    public bool? Zombie_BetweenWaves { get; set; }

    /// <summary>
    /// Time until next wave (Zombie Coop).
    /// </summary>
    public float? Zombie_TimeToNextWave { get; set; }

    #endregion

    #region The Hidden

    /// <summary>
    /// Hidden player reference (The Hidden).
    /// </summary>
    public uint? Hidden_PlayerRef { get; set; }

    /// <summary>
    /// Hidden's health (The Hidden).
    /// </summary>
    public float? Hidden_Health { get; set; }

    /// <summary>
    /// Whether the Hidden is currently visible (The Hidden).
    /// </summary>
    public bool? Hidden_IsVisible { get; set; }

    /// <summary>
    /// Number of IRIS team members alive (The Hidden).
    /// </summary>
    public int? Hidden_IRISAlive { get; set; }

    #endregion

    #region Gun Game

    /// <summary>
    /// Total gun levels to progress through (Gun Game).
    /// </summary>
    public int? GunGame_TotalGunLevels { get; set; }

    /// <summary>
    /// Leader's current gun level (Gun Game).
    /// </summary>
    public int? GunGame_LeaderGunLevel { get; set; }

    /// <summary>
    /// Leader player reference (Gun Game).
    /// </summary>
    public uint? GunGame_LeaderPlayerRef { get; set; }

    #endregion

    #region Prop Hunt

    /// <summary>
    /// Number of props alive (Prop Hunt).
    /// </summary>
    public int? PropHunt_PropsAlive { get; set; }

    /// <summary>
    /// Number of hunters alive (Prop Hunt).
    /// </summary>
    public int? PropHunt_HuntersAlive { get; set; }

    /// <summary>
    /// Whether in hide phase (Prop Hunt).
    /// </summary>
    public bool? PropHunt_HidePhase { get; set; }

    /// <summary>
    /// Hide time remaining (Prop Hunt).
    /// </summary>
    public float? PropHunt_HideTimeRemaining { get; set; }

    #endregion

    #region Infection

    /// <summary>
    /// Number of survivors (Infection).
    /// </summary>
    public int? Infection_SurvivorsCount { get; set; }

    /// <summary>
    /// Number of infected (Infection).
    /// </summary>
    public int? Infection_InfectedCount { get; set; }

    /// <summary>
    /// Whether alpha has been selected (Infection).
    /// </summary>
    public bool? Infection_AlphaSelected { get; set; }

    /// <summary>
    /// Alpha player reference (Infection).
    /// </summary>
    public uint? Infection_AlphaPlayerRef { get; set; }

    #endregion

    #region Jailbreak

    /// <summary>
    /// Warden player reference (Jailbreak).
    /// </summary>
    public uint? Jailbreak_WardenRef { get; set; }

    /// <summary>
    /// Number of guards alive (Jailbreak).
    /// </summary>
    public int? Jailbreak_GuardsAlive { get; set; }

    /// <summary>
    /// Number of prisoners alive (Jailbreak).
    /// </summary>
    public int? Jailbreak_PrisonersAlive { get; set; }

    /// <summary>
    /// Whether last request is active (Jailbreak).
    /// </summary>
    public bool? Jailbreak_LastRequest { get; set; }

    #endregion
}

/// <summary>
/// TTT-specific player state data.
/// </summary>
public class TTTPlayerData
{
    /// <summary>
    /// Channel index for this player state.
    /// </summary>
    public uint ChannelIndex { get; set; }

    /// <summary>
    /// Player's TTT role (Innocent, Traitor, Detective, Spectator).
    /// </summary>
    public int? Role { get; set; }

    /// <summary>
    /// Whether the player's role has been revealed.
    /// </summary>
    public bool? RoleRevealed { get; set; }

    /// <summary>
    /// Player's karma value.
    /// </summary>
    public float? Karma { get; set; }

    /// <summary>
    /// Player's shop credits.
    /// </summary>
    public int? Credits { get; set; }

    /// <summary>
    /// Owner actor reference.
    /// </summary>
    public uint? OwnerRef { get; set; }
}
