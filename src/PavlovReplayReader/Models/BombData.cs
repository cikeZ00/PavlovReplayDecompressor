using Unreal.Core.Models;
using PavlovReplayReader.Models.Enums;

namespace PavlovReplayReader.Models;

/// <summary>
/// Represents bomb data for Search and Destroy mode.
/// </summary>
public class BombData
{
    /// <summary>
    /// Channel index for this bomb.
    /// </summary>
    public uint ChannelIndex { get; set; }

    /// <summary>
    /// Replay time when this data was last updated.
    /// </summary>
    public float LastUpdateTime { get; set; }

    /// <summary>
    /// Current bomb state (StandBy, Armed, Planted, Detonating, Detonated, Defused).
    /// </summary>
    public int? BombState { get; set; }

    /// <summary>
    /// Time remaining on the bomb fuse.
    /// </summary>
    public float? BombTime { get; set; }

    /// <summary>
    /// Defuse progress (0 to 1).
    /// </summary>
    public float? DefuseProgress { get; set; }

    /// <summary>
    /// Whether the bomb is currently being defused.
    /// </summary>
    public bool? IsDefusing { get; set; }

    /// <summary>
    /// Replicated movement/position data.
    /// </summary>
    public FRepMovement? ReplicatedMovement { get; set; }

    /// <summary>
    /// Owner actor reference.
    /// </summary>
    public uint? OwnerRef { get; set; }

    /// <summary>
    /// Whether the bomb is hidden.
    /// </summary>
    public bool? IsHidden { get; set; }

    /// <summary>
    /// Attach parent reference.
    /// </summary>
    public uint? AttachParentRef { get; set; }
}

/// <summary>
/// Represents a bomb plant spot/site.
/// </summary>
public class BombSiteData
{
    /// <summary>
    /// Channel index for this bomb site.
    /// </summary>
    public uint ChannelIndex { get; set; }

    /// <summary>
    /// Replay time when this data was last updated.
    /// </summary>
    public float LastUpdateTime { get; set; }

    /// <summary>
    /// Site identifier (0=A, 1=B, etc.).
    /// </summary>
    public byte? SiteId { get; set; }

    /// <summary>
    /// Whether a bomb is currently planted at this site.
    /// </summary>
    public bool? BombPlanted { get; set; }

    /// <summary>
    /// Whether this site is active/available for planting.
    /// </summary>
    public bool? IsActive { get; set; }

    /// <summary>
    /// Position of the bomb site.
    /// </summary>
    public FRepMovement? ReplicatedMovement { get; set; }
}
