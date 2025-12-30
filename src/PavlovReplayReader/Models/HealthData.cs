namespace PavlovReplayReader.Models;

/// <summary>
/// Represents health component data for actors.
/// </summary>
public class HealthData
{
    /// <summary>
    /// Channel index for this health component.
    /// </summary>
    public uint ChannelIndex { get; set; }

    /// <summary>
    /// Replay time when this data was last updated.
    /// </summary>
    public float LastUpdateTime { get; set; }

    /// <summary>
    /// Current health value.
    /// </summary>
    public float? Health { get; set; }

    /// <summary>
    /// Maximum health value.
    /// </summary>
    public float? MaxHealth { get; set; }

    /// <summary>
    /// Whether this component is active.
    /// </summary>
    public bool? IsActive { get; set; }

    /// <summary>
    /// Owner actor reference.
    /// </summary>
    public uint? OwnerRef { get; set; }
}
