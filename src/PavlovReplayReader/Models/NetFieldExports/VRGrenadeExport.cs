using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;
using PavlovReplayReader.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

/// <summary>
/// NetFieldExportGroup for grenades.
/// Contains grenade state, type, and fuse information.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.VRGrenade", minimalParseMode: ParseMode.Minimal)]
public class VRGrenadeExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets whether the grenade is hidden.
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
    /// Gets or sets whether the grenade is torn off.
    /// </summary>
    [NetFieldExport("bTearOff", RepLayoutCmdType.PropertyBool)]
    public bool? bTearOff { get; set; }

    /// <summary>
    /// Gets or sets the grenade state.
    /// </summary>
    [NetFieldExport("GrenadeState", RepLayoutCmdType.Enum)]
    public int? GrenadeState { get; set; }

    /// <summary>
    /// Gets or sets the grenade type.
    /// </summary>
    [NetFieldExport("GrenadeType", RepLayoutCmdType.Enum)]
    public int? GrenadeType { get; set; }

    /// <summary>
    /// Gets or sets the cook time (how long the pin has been pulled).
    /// </summary>
    [NetFieldExport("CookTime", RepLayoutCmdType.PropertyFloat)]
    public float? CookTime { get; set; }

    /// <summary>
    /// Gets or sets the fuse time.
    /// </summary>
    [NetFieldExport("FuseTime", RepLayoutCmdType.PropertyFloat)]
    public float? FuseTime { get; set; }

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
