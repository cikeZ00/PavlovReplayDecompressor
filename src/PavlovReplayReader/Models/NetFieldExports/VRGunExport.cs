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
    #region Actor Base Properties

    /// <summary>
    /// Gets or sets whether the gun is hidden.
    /// </summary>
    [NetFieldExport("bHidden", RepLayoutCmdType.PropertyBool)]
    public bool? bHidden { get; set; }

    /// <summary>
    /// Gets or sets whether movement replication is enabled.
    /// </summary>
    [NetFieldExport("bReplicateMovement", RepLayoutCmdType.PropertyBool)]
    public bool? bReplicateMovement { get; set; }

    /// <summary>
    /// Gets or sets the remote role.
    /// </summary>
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public object? RemoteRole { get; set; }

    /// <summary>
    /// Gets or sets the role.
    /// </summary>
    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public object? Role { get; set; }

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

    #endregion

    #region Attachment Replication (FRepAttachment)

    /// <summary>
    /// Gets or sets the attach parent actor.
    /// </summary>
    [NetFieldExport("AttachParent", RepLayoutCmdType.PropertyObject)]
    public uint? AttachParent { get; set; }

    /// <summary>
    /// Gets or sets the attach socket name.
    /// </summary>
    [NetFieldExport("AttachSocket", RepLayoutCmdType.PropertyName)]
    public string? AttachSocket { get; set; }

    /// <summary>
    /// Gets or sets the attach component.
    /// </summary>
    [NetFieldExport("AttachComponent", RepLayoutCmdType.PropertyObject)]
    public uint? AttachComponent { get; set; }

    /// <summary>
    /// Gets or sets the location offset for attachment.
    /// </summary>
    [NetFieldExport("LocationOffset", RepLayoutCmdType.PropertyVector100)]
    public FVector? LocationOffset { get; set; }

    /// <summary>
    /// Gets or sets the relative scale for attachment.
    /// </summary>
    [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVector100)]
    public FVector? RelativeScale3D { get; set; }

    /// <summary>
    /// Gets or sets the rotation offset for attachment.
    /// </summary>
    [NetFieldExport("RotationOffset", RepLayoutCmdType.PropertyRotator)]
    public FRotator? RotationOffset { get; set; }

    #endregion

    #region VRItem Properties

    /// <summary>
    /// Gets or sets whether the gun is torn off (detached from network).
    /// </summary>
    [NetFieldExport("bTearOff", RepLayoutCmdType.PropertyBool)]
    public bool? bTearOff { get; set; }

    /// <summary>
    /// Gets or sets whether picking up is disabled.
    /// </summary>
    [NetFieldExport("bPickDisabled", RepLayoutCmdType.PropertyBool)]
    public bool? bPickDisabled { get; set; }

    /// <summary>
    /// Gets or sets the controller holding this item.
    /// </summary>
    [NetFieldExport("Controller", RepLayoutCmdType.PropertyObject)]
    public uint? Controller { get; set; }

    /// <summary>
    /// Gets or sets the parent item (e.g., gun for magazine).
    /// </summary>
    [NetFieldExport("Parent", RepLayoutCmdType.PropertyObject)]
    public uint? Parent { get; set; }

    /// <summary>
    /// Gets or sets the parent attachment slot.
    /// </summary>
    [NetFieldExport("ParentSlot", RepLayoutCmdType.PropertyByte)]
    public byte? ParentSlot { get; set; }

    /// <summary>
    /// Gets or sets the item state proxy for weapon handling.
    /// </summary>
    [NetFieldExport("StateProxy", RepLayoutCmdType.Ignore)]
    public object? StateProxy { get; set; }

    /// <summary>
    /// Gets or sets the handling sound state.
    /// </summary>
    [NetFieldExport("HandlingSound", RepLayoutCmdType.Enum)]
    public int? HandlingSound { get; set; }

    #endregion

    #region Gun Properties

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
    /// Gets or sets whether the gun is suppressed.
    /// </summary>
    [NetFieldExport("bSuppressed", RepLayoutCmdType.PropertyBool)]
    public bool? bSuppressed { get; set; }

    #endregion

    #region Attachments

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

    #endregion

    #region Cosmetics

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

    #endregion
}

#region Specific Gun Exports

// Rifles
[NetFieldExportGroup("/Game/Guns/M4/Gun_M4.Gun_M4_C", minimalParseMode: ParseMode.Minimal)]
public class GunM4Export : VRGunExport { }

[NetFieldExportGroup("/Game/Guns/AK/Gun_AK47.Gun_AK47_C", minimalParseMode: ParseMode.Minimal)]
public class GunAK47Export : VRGunExport { }

[NetFieldExportGroup("/Game/Guns/AKshorty/Gun_AKshorty.Gun_AKshorty_C", minimalParseMode: ParseMode.Minimal)]
public class GunAKshortyExport : VRGunExport { }

[NetFieldExportGroup("/Game/Guns/AUG/Gun_AUG.Gun_AUG_C", minimalParseMode: ParseMode.Minimal)]
public class GunAUGExport : VRGunExport { }

[NetFieldExportGroup("/Game/Guns/SCAR/Gun_SCAR20.Gun_SCAR20_C", minimalParseMode: ParseMode.Minimal)]
public class GunSCAR20Export : VRGunExport { }

[NetFieldExportGroup("/Game/Guns/AutoSniper/Gun_AutoSniper.Gun_AutoSniper_C", minimalParseMode: ParseMode.Minimal)]
public class GunAutoSniperExport : VRGunExport { }

// Pistols
[NetFieldExportGroup("/Game/Guns/C1911/Gun_1911.Gun_1911_C", minimalParseMode: ParseMode.Minimal)]
public class Gun1911Export : VRGunExport { }

[NetFieldExportGroup("/Game/Guns/Tokarev/Gun_Tokarev.Gun_Tokarev_C", minimalParseMode: ParseMode.Minimal)]
public class GunTokarevExport : VRGunExport { }

[NetFieldExportGroup("/Game/Guns/DE/Gun_DE.Gun_DE_C", minimalParseMode: ParseMode.Minimal)]
public class GunDEExport : VRGunExport { }

[NetFieldExportGroup("/Game/Guns/Glock/Gun_Glock.Gun_Glock_C", minimalParseMode: ParseMode.Minimal)]
public class GunGlockExport : VRGunExport { }

[NetFieldExportGroup("/Game/Guns/57/Gun_57.Gun_57_C", minimalParseMode: ParseMode.Minimal)]
public class Gun57Export : VRGunExport { }

[NetFieldExportGroup("/Game/Guns/Revolver/Gun_Revolver.Gun_Revolver_C", minimalParseMode: ParseMode.Minimal)]
public class GunRevolverExport : VRGunExport { }

// SMGs
[NetFieldExportGroup("/Game/Guns/SMG/Gun_SMG.Gun_SMG_C", minimalParseMode: ParseMode.Minimal)]
public class GunSMGExport : VRGunExport { }

[NetFieldExportGroup("/Game/Guns/Pepe/Gun_Pepe.Gun_Pepe_C", minimalParseMode: ParseMode.Minimal)]
public class GunPepeExport : VRGunExport { }

#endregion
