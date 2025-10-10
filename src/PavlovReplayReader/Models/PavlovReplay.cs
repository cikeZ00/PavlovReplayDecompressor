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

    // TODO: Add additional parsed replay data properties as needed
    // Examples:
    // - Team data (IEnumerable<TeamData>)
    // - Kill feed (IList<KillFeedEntry>)
    // - Events (IList<GameEvent>)
    // - Voice data (IEnumerable<VoiceData>)
}
