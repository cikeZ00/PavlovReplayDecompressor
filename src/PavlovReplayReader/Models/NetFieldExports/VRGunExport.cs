using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

/// <summary>
/// NetFieldExportGroup for VR Gun base class.
/// Contains weapon state, ammo, and attachment information.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.VRGun", minimalParseMode: ParseMode.Minimal)]
public class VRGunExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets whether the gun is hidden.
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
    /// Gets or sets whether the gun can be damaged.
    /// </summary>
    [NetFieldExport("bCanBeDamaged", RepLayoutCmdType.PropertyBool)]
    public bool? bCanBeDamaged { get; set; }

    /// <summary>
    /// Gets or sets the replicated movement.
    /// </summary>
    [NetFieldExport("ReplicatedMovement", RepLayoutCmdType.RepMovement)]
    public FRepMovement? ReplicatedMovement { get; set; }

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
    /// Gets or sets the relative rotation for attachment.
    /// </summary>
    [NetFieldExport("AttachmentReplication_RelativeScale3D", RepLayoutCmdType.PropertyVector)]
    public FVector? AttachmentReplication_RelativeScale3D { get; set; }

    /// <summary>
    /// Gets or sets the rotation offset for attachment.
    /// </summary>
    [NetFieldExport("AttachmentReplication_RotationOffset", RepLayoutCmdType.PropertyRotator)]
    public FRotator? AttachmentReplication_RotationOffset { get; set; }

    /// <summary>
    /// Gets or sets whether the gun is torn off (detached from network).
    /// </summary>
    [NetFieldExport("bTearOff", RepLayoutCmdType.PropertyBool)]
    public bool? bTearOff { get; set; }

    /// <summary>
    /// Gets or sets the current ammo in chamber.
    /// </summary>
    [NetFieldExport("Ammo", RepLayoutCmdType.PropertyInt)]
    public int? Ammo { get; set; }

    /// <summary>
    /// Gets or sets the current magazine ammo.
    /// </summary>
    [NetFieldExport("MagAmmo", RepLayoutCmdType.PropertyInt)]
    public int? MagAmmo { get; set; }

    /// <summary>
    /// Gets or sets the maximum ammo capacity.
    /// </summary>
    [NetFieldExport("MaxAmmo", RepLayoutCmdType.PropertyInt)]
    public int? MaxAmmo { get; set; }

    /// <summary>
    /// Gets or sets whether the gun is cocked.
    /// </summary>
    [NetFieldExport("bCocked", RepLayoutCmdType.PropertyBool)]
    public bool? bCocked { get; set; }

    /// <summary>
    /// Gets or sets whether the safety is on.
    /// </summary>
    [NetFieldExport("bSafetyOn", RepLayoutCmdType.PropertyBool)]
    public bool? bSafetyOn { get; set; }

    /// <summary>
    /// Gets or sets whether the slide is locked.
    /// </summary>
    [NetFieldExport("bSlideLocked", RepLayoutCmdType.PropertyBool)]
    public bool? bSlideLocked { get; set; }

    /// <summary>
    /// Gets or sets the fire mode.
    /// </summary>
    [NetFieldExport("FireMode", RepLayoutCmdType.PropertyByte)]
    public byte? FireMode { get; set; }

    /// <summary>
    /// Gets or sets the two-hand stock state.
    /// </summary>
    [NetFieldExport("TwoHandStockState", RepLayoutCmdType.Enum)]
    public int? TwoHandStockState { get; set; }

    /// <summary>
    /// Gets or sets the attached magazine reference.
    /// </summary>
    [NetFieldExport("AttachedMagazine", RepLayoutCmdType.PropertyObject)]
    public uint? AttachedMagazine { get; set; }

    /// <summary>
    /// Gets or sets the attached sight reference.
    /// </summary>
    [NetFieldExport("AttachedSight", RepLayoutCmdType.PropertyObject)]
    public uint? AttachedSight { get; set; }

    /// <summary>
    /// Gets or sets the attached suppressor reference.
    /// </summary>
    [NetFieldExport("AttachedSuppressor", RepLayoutCmdType.PropertyObject)]
    public uint? AttachedSuppressor { get; set; }

    /// <summary>
    /// Gets or sets the attached laser reference.
    /// </summary>
    [NetFieldExport("AttachedLaser", RepLayoutCmdType.PropertyObject)]
    public uint? AttachedLaser { get; set; }

    /// <summary>
    /// Gets or sets the attached flashlight reference.
    /// </summary>
    [NetFieldExport("AttachedFlashlight", RepLayoutCmdType.PropertyObject)]
    public uint? AttachedFlashlight { get; set; }

    /// <summary>
    /// Gets or sets the attached grip reference.
    /// </summary>
    [NetFieldExport("AttachedGrip", RepLayoutCmdType.PropertyObject)]
    public uint? AttachedGrip { get; set; }

    /// <summary>
    /// Gets or sets the skin ID.
    /// </summary>
    [NetFieldExport("SkinId", RepLayoutCmdType.PropertyInt)]
    public int? SkinId { get; set; }

    /// <summary>
    /// Gets or sets the charm ID.
    /// </summary>
    [NetFieldExport("CharmId", RepLayoutCmdType.PropertyInt)]
    public int? CharmId { get; set; }
}
