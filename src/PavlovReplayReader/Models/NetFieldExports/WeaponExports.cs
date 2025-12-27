
using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

/// <summary>
/// NetFieldExportGroup for knife/melee weapons.
/// Contains knife state and position data.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.VRKnife", minimalParseMode: ParseMode.Minimal)]
public class VRKnifeExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets whether the knife is hidden.
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
    /// Gets or sets whether the knife is torn off.
    /// </summary>
    [NetFieldExport("bTearOff", RepLayoutCmdType.PropertyBool)]
    public bool? bTearOff { get; set; }

    /// <summary>
    /// Gets or sets the skin ID.
    /// </summary>
    [NetFieldExport("SkinId", RepLayoutCmdType.PropertyInt)]
    public int? SkinId { get; set; }

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
/// NetFieldExportGroup for rocket/grenade launchers.
/// Contains launcher state and ammo data.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.VRLauncher", minimalParseMode: ParseMode.Minimal)]
public class VRLauncherExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets whether the launcher is hidden.
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
    /// Gets or sets whether the launcher is torn off.
    /// </summary>
    [NetFieldExport("bTearOff", RepLayoutCmdType.PropertyBool)]
    public bool? bTearOff { get; set; }

    /// <summary>
    /// Gets or sets the launcher state.
    /// </summary>
    [NetFieldExport("LauncherState", RepLayoutCmdType.Enum)]
    public int? LauncherState { get; set; }

    /// <summary>
    /// Gets or sets the current ammo.
    /// </summary>
    [NetFieldExport("Ammo", RepLayoutCmdType.PropertyInt)]
    public int? Ammo { get; set; }

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
/// NetFieldExportGroup for C4/explosive.
/// Contains explosive state and timer data.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.VRC4", minimalParseMode: ParseMode.Minimal)]
public class VRC4Export : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets whether the C4 is hidden.
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
    /// Gets or sets whether the C4 is torn off.
    /// </summary>
    [NetFieldExport("bTearOff", RepLayoutCmdType.PropertyBool)]
    public bool? bTearOff { get; set; }

    /// <summary>
    /// Gets or sets whether the C4 is armed.
    /// </summary>
    [NetFieldExport("bArmed", RepLayoutCmdType.PropertyBool)]
    public bool? bArmed { get; set; }

    /// <summary>
    /// Gets or sets whether the C4 is planted.
    /// </summary>
    [NetFieldExport("bPlanted", RepLayoutCmdType.PropertyBool)]
    public bool? bPlanted { get; set; }

    /// <summary>
    /// Gets or sets the timer value.
    /// </summary>
    [NetFieldExport("Timer", RepLayoutCmdType.PropertyFloat)]
    public float? Timer { get; set; }

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
/// NetFieldExportGroup for item pickups.
/// Contains pickup item data.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.ItemPickup", minimalParseMode: ParseMode.Minimal)]
public class ItemPickupExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets whether the pickup is hidden.
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
    /// Gets or sets the replicated movement.
    /// </summary>
    [NetFieldExport("ReplicatedMovement", RepLayoutCmdType.RepMovement)]
    public FRepMovement? ReplicatedMovement { get; set; }

    /// <summary>
    /// Gets or sets whether the pickup is available.
    /// </summary>
    [NetFieldExport("bAvailable", RepLayoutCmdType.PropertyBool)]
    public bool? bAvailable { get; set; }

    /// <summary>
    /// Gets or sets the respawn time.
    /// </summary>
    [NetFieldExport("RespawnTime", RepLayoutCmdType.PropertyFloat)]
    public float? RespawnTime { get; set; }

    /// <summary>
    /// Gets or sets the item class reference.
    /// </summary>
    [NetFieldExport("ItemClass", RepLayoutCmdType.PropertyObject)]
    public uint? ItemClass { get; set; }
}

/// <summary>
/// NetFieldExportGroup for door bombs (breach charges).
/// Contains breach charge state.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.VRDoorBomb", minimalParseMode: ParseMode.Minimal)]
public class VRDoorBombExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets whether the door bomb is hidden.
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
    /// Gets or sets whether the charge is torn off.
    /// </summary>
    [NetFieldExport("bTearOff", RepLayoutCmdType.PropertyBool)]
    public bool? bTearOff { get; set; }

    /// <summary>
    /// Gets or sets whether the charge is planted.
    /// </summary>
    [NetFieldExport("bPlanted", RepLayoutCmdType.PropertyBool)]
    public bool? bPlanted { get; set; }

    /// <summary>
    /// Gets or sets whether the charge is armed.
    /// </summary>
    [NetFieldExport("bArmed", RepLayoutCmdType.PropertyBool)]
    public bool? bArmed { get; set; }

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
