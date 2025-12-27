using System.Collections.Generic;
using Unreal.Core.Models;

namespace PavlovReplayReader.Models;

/// <summary>
/// Represents a Pavlov VR replay with all parsed data.
/// </summary>
public class PavlovReplay : Replay
{
    /// <summary>
    /// Game state data parsed from the replay.
    /// Contains information about match settings, scores, rules, and configuration.
    /// </summary>
    public GameData? GameData { get; set; }

    /// <summary>
    /// Player state data for all players in the match.
    /// Contains stats, equipment, settings, and state for each player.
    /// </summary>
    public List<PlayerData>? Players { get; set; }

    /// <summary>
    /// Player pawn data including position, movement, and VR controller tracking.
    /// Keyed by channel index.
    /// </summary>
    public Dictionary<uint, PawnData>? Pawns { get; set; }

    /// <summary>
    /// Weapon/item data including guns, grenades, knives, etc.
    /// Keyed by channel index.
    /// </summary>
    public Dictionary<uint, WeaponData>? Weapons { get; set; }

    /// <summary>
    /// Vehicle data including cars and tanks.
    /// Keyed by channel index.
    /// </summary>
    public Dictionary<uint, VehicleData>? Vehicles { get; set; }

    /// <summary>
    /// Bomb data for Search and Destroy mode.
    /// </summary>
    public BombData? Bomb { get; set; }

    /// <summary>
    /// Bomb site data for Search and Destroy mode.
    /// </summary>
    public List<BombSiteData>? BombSites { get; set; }

    /// <summary>
    /// Game mode specific state data (TTT, Zombie, etc.).
    /// </summary>
    public GameModeData? GameModeState { get; set; }

    /// <summary>
    /// TTT-specific player data (roles, karma, credits).
    /// Keyed by channel index.
    /// </summary>
    public Dictionary<uint, TTTPlayerData>? TTTPlayers { get; set; }

    /// <summary>
    /// Health component data for various actors.
    /// Keyed by channel index.
    /// </summary>
    public Dictionary<uint, HealthData>? HealthComponents { get; set; }

    /// <summary>
    /// Summary statistics about the replay parsing.
    /// </summary>
    public ReplayStats? Stats { get; set; }
}

/// <summary>
/// Statistics about the parsed replay.
/// </summary>
public class ReplayStats
{
    /// <summary>
    /// Total number of exports processed.
    /// </summary>
    public int TotalExportsProcessed { get; set; }

    /// <summary>
    /// Number of unique export types encountered.
    /// </summary>
    public int UniqueExportTypes { get; set; }

    /// <summary>
    /// Export type counts by name.
    /// </summary>
    public Dictionary<string, int>? ExportTypeCounts { get; set; }

    /// <summary>
    /// Maximum channel index seen.
    /// </summary>
    public uint MaxChannelIndex { get; set; }

    /// <summary>
    /// Replay duration in seconds (from world time).
    /// </summary>
    public float? ReplayDuration { get; set; }
}
