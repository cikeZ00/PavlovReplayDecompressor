using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

/// <summary>
/// Base class for VRItem-derived weapons and items with common properties.
/// </summary>
public abstract class VRItemExportBase : INetFieldExportGroup
{
    #region Actor Base Properties

    [NetFieldExport("bHidden", RepLayoutCmdType.PropertyBool)]
    public bool? bHidden { get; set; }

    [NetFieldExport("bReplicateMovement", RepLayoutCmdType.PropertyBool)]
    public bool? bReplicateMovement { get; set; }

    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public object? RemoteRole { get; set; }

    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public object? Role { get; set; }

    [NetFieldExport("Owner", RepLayoutCmdType.PropertyObject)]
    public uint? Owner { get; set; }

    [NetFieldExport("Instigator", RepLayoutCmdType.PropertyObject)]
    public uint? Instigator { get; set; }

    [NetFieldExport("ReplicatedMovement", RepLayoutCmdType.RepMovement)]
    public FRepMovement? ReplicatedMovement { get; set; }

    #endregion

    #region Attachment Replication (FRepAttachment)

    [NetFieldExport("AttachParent", RepLayoutCmdType.PropertyObject)]
    public uint? AttachParent { get; set; }

    [NetFieldExport("AttachSocket", RepLayoutCmdType.PropertyName)]
    public string? AttachSocket { get; set; }

    [NetFieldExport("AttachComponent", RepLayoutCmdType.PropertyObject)]
    public uint? AttachComponent { get; set; }

    [NetFieldExport("LocationOffset", RepLayoutCmdType.PropertyVector100)]
    public FVector? LocationOffset { get; set; }

    [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVector100)]
    public FVector? RelativeScale3D { get; set; }

    [NetFieldExport("RotationOffset", RepLayoutCmdType.PropertyRotator)]
    public FRotator? RotationOffset { get; set; }

    #endregion

    #region VRItem Properties

    [NetFieldExport("bTearOff", RepLayoutCmdType.PropertyBool)]
    public bool? bTearOff { get; set; }

    [NetFieldExport("bPickDisabled", RepLayoutCmdType.PropertyBool)]
    public bool? bPickDisabled { get; set; }

    [NetFieldExport("Controller", RepLayoutCmdType.PropertyObject)]
    public uint? Controller { get; set; }

    [NetFieldExport("Parent", RepLayoutCmdType.PropertyObject)]
    public uint? Parent { get; set; }

    [NetFieldExport("ParentSlot", RepLayoutCmdType.PropertyByte)]
    public byte? ParentSlot { get; set; }

    [NetFieldExport("StateProxy", RepLayoutCmdType.Ignore)]
    public object? StateProxy { get; set; }

    [NetFieldExport("HandlingSound", RepLayoutCmdType.Enum)]
    public int? HandlingSound { get; set; }

    #endregion
}

/// <summary>
/// NetFieldExportGroup for knife/melee weapons.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.VRKnife", minimalParseMode: ParseMode.Minimal)]
public class VRKnifeExport : VRItemExportBase
{
    [NetFieldExport("SkinId", RepLayoutCmdType.PropertyInt)]
    public int? SkinId { get; set; }

    [NetFieldExport("bDominant", RepLayoutCmdType.PropertyBool)]
    public bool? bDominant { get; set; }

    [NetFieldExport("HandType", RepLayoutCmdType.PropertyByte)]
    public byte? HandType { get; set; }
}

/// <summary>
/// Bayonet knife variant.
/// </summary>
[NetFieldExportGroup("/Game/Guns/Knife/Knife_Bayonet.Knife_Bayonet_C", minimalParseMode: ParseMode.Minimal)]
public class KnifeBayonetExport : VRKnifeExport { }

/// <summary>
/// NetFieldExportGroup for rocket/grenade launchers.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.VRLauncher", minimalParseMode: ParseMode.Minimal)]
public class VRLauncherExport : VRItemExportBase
{
    [NetFieldExport("Ammo", RepLayoutCmdType.PropertyInt)]
    public int? Ammo { get; set; }

    [NetFieldExport("bCocked", RepLayoutCmdType.PropertyBool)]
    public bool? bCocked { get; set; }
}

/// <summary>
/// NetFieldExportGroup for shotguns.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.VRShotgun", minimalParseMode: ParseMode.Minimal)]
public class VRShotgunExport : VRItemExportBase
{
    [NetFieldExport("Ammo", RepLayoutCmdType.PropertyInt)]
    public int? Ammo { get; set; }

    [NetFieldExport("MagAmmo", RepLayoutCmdType.PropertyInt)]
    public int? MagAmmo { get; set; }

    [NetFieldExport("MaxAmmo", RepLayoutCmdType.PropertyInt)]
    public int? MaxAmmo { get; set; }

    [NetFieldExport("bCocked", RepLayoutCmdType.PropertyBool)]
    public bool? bCocked { get; set; }

    [NetFieldExport("bSafetyOn", RepLayoutCmdType.PropertyBool)]
    public bool? bSafetyOn { get; set; }

    [NetFieldExport("FireMode", RepLayoutCmdType.PropertyByte)]
    public byte? FireMode { get; set; }

    [NetFieldExport("SkinId", RepLayoutCmdType.PropertyInt)]
    public int? SkinId { get; set; }
}

/// <summary>
/// NetFieldExportGroup for bullets/ammunition items.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.Bullet", minimalParseMode: ParseMode.Minimal)]
public class BulletExport : VRItemExportBase
{
    [NetFieldExport("bSuppressed", RepLayoutCmdType.PropertyBool)]
    public bool? bSuppressed { get; set; }
}

// Individual bullet exports
[NetFieldExportGroup("/Game/Guns/Bullets/Bullet_9mm.Bullet_9mm_C", minimalParseMode: ParseMode.Minimal)]
public class Bullet9mmExport : BulletExport { }

[NetFieldExportGroup("/Game/Guns/Bullets/Bullet_45ACP.Bullet_45ACP_C", minimalParseMode: ParseMode.Minimal)]
public class Bullet45ACPExport : BulletExport { }

[NetFieldExportGroup("/Game/Guns/Bullets/Bullet_39mm.Bullet_39mm_C", minimalParseMode: ParseMode.Minimal)]
public class Bullet39mmExport : BulletExport { }

[NetFieldExportGroup("/Game/Guns/Bullets/Bullet_Magnum.Bullet_Magnum_C", minimalParseMode: ParseMode.Minimal)]
public class BulletMagnumExport : BulletExport { }

[NetFieldExportGroup("/Game/Guns/Bullets/Bullet_HighPowerRifle.Bullet_HighPowerRifle_C", minimalParseMode: ParseMode.Minimal)]
public class BulletHighPowerRifleExport : BulletExport { }

[NetFieldExportGroup("/Game/Guns/Bullets/Bullet_7_62_39mm.Bullet_7_62_39mm_C", minimalParseMode: ParseMode.Minimal)]
public class Bullet762Export : BulletExport { }

[NetFieldExportGroup("/Game/Guns/Bullets/Bullet_7_62_39mm_Half.Bullet_7_62_39mm_Half_C", minimalParseMode: ParseMode.Minimal)]
public class Bullet762HalfExport : BulletExport { }

[NetFieldExportGroup("/Game/Guns/Bullets/Bullet_50Cal_Half.Bullet_50Cal_Half_C", minimalParseMode: ParseMode.Minimal)]
public class Bullet50CalExport : BulletExport { }

/// <summary>
/// NetFieldExportGroup for weapon attachments (sights, grips, suppressors, lasers).
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.VRAttachment", minimalParseMode: ParseMode.Minimal)]
public class VRAttachmentExport : VRItemExportBase
{
    [NetFieldExport("bAttaching", RepLayoutCmdType.PropertyBool)]
    public bool? bAttaching { get; set; }

    [NetFieldExport("bAttachmentAccessoryOn", RepLayoutCmdType.PropertyBool)]
    public bool? bAttachmentAccessoryOn { get; set; }
}

// Sight attachments
[NetFieldExportGroup("/Game/Attachments/Scope/Sight_Holo.Sight_Holo_C", minimalParseMode: ParseMode.Minimal)]
public class SightHoloExport : VRAttachmentExport { }

[NetFieldExportGroup("/Game/Attachments/Scope/Sight_ACOG.Sight_ACOG_C", minimalParseMode: ParseMode.Minimal)]
public class SightACOGExport : VRAttachmentExport { }

[NetFieldExportGroup("/Game/Attachments/Scope/Sight_ScopeX8.Sight_ScopeX8_C", minimalParseMode: ParseMode.Minimal)]
public class SightScopeX8Export : VRAttachmentExport { }

// Grip attachments
[NetFieldExportGroup("/Game/Attachments/Grip/Grip_Angled.Grip_Angled_C", minimalParseMode: ParseMode.Minimal)]
public class GripAngledExport : VRAttachmentExport { }

// Suppressor attachments
[NetFieldExportGroup("/Game/Attachments/Suppressor/Suppressor_Rifle.Suppressor_Rifle_C", minimalParseMode: ParseMode.Minimal)]
public class SuppressorRifleExport : VRAttachmentExport { }

// Laser attachments
[NetFieldExportGroup("/Game/Attachments/LaserAttachment/Laser_Rifle.Laser_Rifle_C", minimalParseMode: ParseMode.Minimal)]
public class LaserRifleExport : VRAttachmentExport { }

/// <summary>
/// NetFieldExportGroup for attach proxy actors (for knife attachments etc).
/// </summary>
[NetFieldExportGroup("/Game/Guns/Knife/AttachProxy_Knife.AttachProxy_Knife_C", minimalParseMode: ParseMode.Minimal)]
public class AttachProxyKnifeExport : INetFieldExportGroup
{
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public object? RemoteRole { get; set; }

    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public object? Role { get; set; }

    [NetFieldExport("Owner", RepLayoutCmdType.PropertyObject)]
    public uint? Owner { get; set; }

    [NetFieldExport("AttachParent", RepLayoutCmdType.PropertyObject)]
    public uint? AttachParent { get; set; }

    [NetFieldExport("AttachParent1", RepLayoutCmdType.PropertyObject)]
    public uint? AttachParent1 { get; set; }

    [NetFieldExport("AttachSocket", RepLayoutCmdType.PropertyName)]
    public string? AttachSocket { get; set; }

    [NetFieldExport("AttachComponent", RepLayoutCmdType.PropertyObject)]
    public uint? AttachComponent { get; set; }

    [NetFieldExport("LocationOffset", RepLayoutCmdType.PropertyVector100)]
    public FVector? LocationOffset { get; set; }

    [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVector100)]
    public FVector? RelativeScale3D { get; set; }

    [NetFieldExport("RotationOffset", RepLayoutCmdType.PropertyRotator)]
    public FRotator? RotationOffset { get; set; }

    [NetFieldExport("Rotation", RepLayoutCmdType.PropertyVector)]
    public FVector? Rotation { get; set; }

    [NetFieldExport("Translation", RepLayoutCmdType.PropertyVector)]
    public FVector? Translation { get; set; }

    [NetFieldExport("Scale3D", RepLayoutCmdType.PropertyVector)]
    public FVector? Scale3D { get; set; }

    [NetFieldExport("BoneName", RepLayoutCmdType.PropertyName)]
    public string? BoneName { get; set; }
}
