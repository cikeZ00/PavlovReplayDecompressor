using Unreal.Core.Models;

namespace PavlovReplayReader.Models;

/// <summary>
/// Represents a Pavlov VR replay with all parsed data.
/// </summary>
public class PavlovReplay : Replay
{
    /// <summary>
    /// Generic game data parsed from the replay.
    /// This is a placeholder object that will be populated as parsing is implemented.
    /// </summary>
    public object? GameData { get; set; }

    // TODO: Add additional parsed replay data properties as needed
    // Examples:
    // - Player data
    // - Team data
    // - Kill feed
    // - Events
    // - Voice data
}
