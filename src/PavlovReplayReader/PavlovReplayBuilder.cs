using PavlovReplayReader.Models;

namespace PavlovReplayReader;

/// <summary>
/// Responsible for constructing the <see cref="PavlovReplay"/> out of the received exports.
/// </summary>
public class PavlovReplayBuilder
{
    /// <summary>
    /// Once a replay is fully parsed, add the data build over time to the replay.
    /// </summary>
    /// <param name="replay"></param>
    /// <returns>PavlovReplay</returns>
    public PavlovReplay Build(PavlovReplay replay)
    {
        // TODO: Build replay data from parsed exports
        return replay;
    }
}
