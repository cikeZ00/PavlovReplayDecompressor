using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

/// <summary>
/// NetFieldExportGroup for gun magazines.
/// Contains ammunition data for detachable magazines.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.Magazine", minimalParseMode: ParseMode.Minimal)]
public class MagazineExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets whether the magazine is hidden.
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
    /// Gets or sets whether the magazine can be damaged.
    /// </summary>
    [NetFieldExport("bCanBeDamaged", RepLayoutCmdType.PropertyBool)]
    public bool? bCanBeDamaged { get; set; }

    /// <summary>
    /// Gets or sets the replicated movement.
    /// </summary>
    [NetFieldExport("ReplicatedMovement", RepLayoutCmdType.RepMovement)]
    public FRepMovement? ReplicatedMovement { get; set; }

    /// <summary>
    /// Gets or sets whether the magazine is torn off.
    /// </summary>
    [NetFieldExport("bTearOff", RepLayoutCmdType.PropertyBool)]
    public bool? bTearOff { get; set; }

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
    /// Gets or sets the relative location for attachment.
    /// </summary>
    [NetFieldExport("AttachmentReplication_LocationOffset", RepLayoutCmdType.PropertyVector)]
    public FVector? AttachmentReplication_LocationOffset { get; set; }

    /// <summary>
    /// Gets or sets the rotation offset for attachment.
    /// </summary>
    [NetFieldExport("AttachmentReplication_RotationOffset", RepLayoutCmdType.PropertyRotator)]
    public FRotator? AttachmentReplication_RotationOffset { get; set; }

    /// <summary>
    /// Gets or sets the relative scale for attachment.
    /// </summary>
    [NetFieldExport("AttachmentReplication_RelativeScale3D", RepLayoutCmdType.PropertyVector)]
    public FVector? AttachmentReplication_RelativeScale3D { get; set; }

    /// <summary>
    /// Gets or sets the current ammo count in the magazine.
    /// </summary>
    [NetFieldExport("Ammo", RepLayoutCmdType.PropertyInt)]
    public int? Ammo { get; set; }

    /// <summary>
    /// Gets or sets the maximum ammo capacity.
    /// </summary>
    [NetFieldExport("MaxAmmo", RepLayoutCmdType.PropertyInt)]
    public int? MaxAmmo { get; set; }
}
