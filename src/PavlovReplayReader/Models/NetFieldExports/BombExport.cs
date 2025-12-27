using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;
using PavlovReplayReader.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

/// <summary>
/// NetFieldExportGroup for Search and Destroy bomb.
/// Contains bomb state for S&amp;D game mode.
/// </summary>
[NetFieldExportGroup("/Game/Gameplay/SearchAndDestroy/Bomb/Bomb.Bomb_C", minimalParseMode: ParseMode.Minimal)]
public class BombExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets whether the bomb is hidden.
    /// </summary>
    [NetFieldExport("bHidden", RepLayoutCmdType.PropertyBool)]
    public bool? bHidden { get; set; }

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
    /// Gets or sets the instigator reference.
    /// </summary>
    [NetFieldExport("Instigator", RepLayoutCmdType.PropertyObject)]
    public uint? Instigator { get; set; }

    /// <summary>
    /// Gets or sets the replicated movement.
    /// </summary>
    [NetFieldExport("ReplicatedMovement", RepLayoutCmdType.RepMovement)]
    public FRepMovement? ReplicatedMovement { get; set; }

    /// <summary>
    /// Gets or sets whether the bomb is torn off.
    /// </summary>
    [NetFieldExport("bTearOff", RepLayoutCmdType.PropertyBool)]
    public bool? bTearOff { get; set; }

    /// <summary>
    /// Gets or sets the current bomb state.
    /// </summary>
    [NetFieldExport("BombState", RepLayoutCmdType.Enum)]
    public int? BombState { get; set; }

    /// <summary>
    /// Gets or sets the time remaining on the bomb.
    /// </summary>
    [NetFieldExport("BombTime", RepLayoutCmdType.PropertyFloat)]
    public float? BombTime { get; set; }

    /// <summary>
    /// Gets or sets the defuse progress.
    /// </summary>
    [NetFieldExport("DefuseProgress", RepLayoutCmdType.PropertyFloat)]
    public float? DefuseProgress { get; set; }

    /// <summary>
    /// Gets or sets whether the bomb is being defused.
    /// </summary>
    [NetFieldExport("bDefusing", RepLayoutCmdType.PropertyBool)]
    public bool? bDefusing { get; set; }

    /// <summary>
    /// Gets or sets the attach parent.
    /// </summary>
    [NetFieldExport("AttachmentReplication_AttachParent", RepLayoutCmdType.PropertyObject)]
    public uint? AttachmentReplication_AttachParent { get; set; }

    /// <summary>
    /// Gets or sets the attach socket.
    /// </summary>
    [NetFieldExport("AttachmentReplication_AttachSocket", RepLayoutCmdType.Property)]
    public string? AttachmentReplication_AttachSocket { get; set; }

    /// <summary>
    /// Gets or sets the attach component.
    /// </summary>
    [NetFieldExport("AttachmentReplication_AttachComponent", RepLayoutCmdType.PropertyObject)]
    public uint? AttachmentReplication_AttachComponent { get; set; }

    /// <summary>
    /// Gets or sets the location offset.
    /// </summary>
    [NetFieldExport("AttachmentReplication_LocationOffset", RepLayoutCmdType.PropertyVector)]
    public FVector? AttachmentReplication_LocationOffset { get; set; }

    /// <summary>
    /// Gets or sets the rotation offset.
    /// </summary>
    [NetFieldExport("AttachmentReplication_RotationOffset", RepLayoutCmdType.PropertyRotator)]
    public FRotator? AttachmentReplication_RotationOffset { get; set; }
}

/// <summary>
/// NetFieldExportGroup for bomb plant spot.
/// Contains bomb site information for S&amp;D mode.
/// </summary>
[NetFieldExportGroup("/Game/Gameplay/SearchAndDestroy/Bomb/BombPlantSpot_Basic.BombPlantSpot_Basic_C", minimalParseMode: ParseMode.Minimal)]
public class BombPlantSpotExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets whether the bomb spot is hidden.
    /// </summary>
    [NetFieldExport("bHidden", RepLayoutCmdType.PropertyBool)]
    public bool? bHidden { get; set; }

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
    /// Gets or sets whether the bomb is planted at this spot.
    /// </summary>
    [NetFieldExport("bBombPlanted", RepLayoutCmdType.PropertyBool)]
    public bool? bBombPlanted { get; set; }

    /// <summary>
    /// Gets or sets whether this spot is active.
    /// </summary>
    [NetFieldExport("bActive", RepLayoutCmdType.PropertyBool)]
    public bool? bActive { get; set; }

    /// <summary>
    /// Gets or sets the bomb site identifier (A, B, etc).
    /// </summary>
    [NetFieldExport("SiteId", RepLayoutCmdType.PropertyByte)]
    public byte? SiteId { get; set; }

    /// <summary>
    /// Gets or sets the replicated movement.
    /// </summary>
    [NetFieldExport("ReplicatedMovement", RepLayoutCmdType.RepMovement)]
    public FRepMovement? ReplicatedMovement { get; set; }
}
