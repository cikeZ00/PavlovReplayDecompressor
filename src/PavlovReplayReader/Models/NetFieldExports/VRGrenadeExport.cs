using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

/// <summary>
/// NetFieldExportGroup for grenades.
/// Contains grenade state, type, and fuse information.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.VRGrenade", minimalParseMode: ParseMode.Minimal)]
public class VRGrenadeExport : INetFieldExportGroup
{
    #region Actor Base Properties

    /// <summary>
    /// Gets or sets whether the grenade is hidden.
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
    /// Gets or sets whether the grenade is torn off.
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
    /// Gets or sets the parent item.
    /// </summary>
    [NetFieldExport("Parent", RepLayoutCmdType.PropertyObject)]
    public uint? Parent { get; set; }

    /// <summary>
    /// Gets or sets the parent attachment slot.
    /// </summary>
    [NetFieldExport("ParentSlot", RepLayoutCmdType.PropertyByte)]
    public byte? ParentSlot { get; set; }

    #endregion

    #region Grenade Properties

    /// <summary>
    /// Gets or sets the grenade state.
    /// </summary>
    [NetFieldExport("State", RepLayoutCmdType.Enum)]
    public int? State { get; set; }

    /// <summary>
    /// Gets or sets the grenade type.
    /// </summary>
    [NetFieldExport("GrenadeType", RepLayoutCmdType.Enum)]
    public int? GrenadeType { get; set; }

    /// <summary>
    /// Gets or sets whether the projectile is active (in flight).
    /// </summary>
    [NetFieldExport("bProjectileActive", RepLayoutCmdType.PropertyBool)]
    public bool? bProjectileActive { get; set; }

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

    #endregion
}

#region Specific Grenade Exports

// Flash Grenades
[NetFieldExportGroup("/Game/Guns/Grenades/Flash/Grenade_Flash.Grenade_Flash_C", minimalParseMode: ParseMode.Minimal)]
public class GrenadeFlashExport : VRGrenadeExport { }

[NetFieldExportGroup("/Game/Guns/Grenades/Flash/Grenade_Flash_RU.Grenade_Flash_RU_C", minimalParseMode: ParseMode.Minimal)]
public class GrenadeFlashRUExport : VRGrenadeExport { }

// Smoke Grenades
[NetFieldExportGroup("/Game/Guns/Grenades/Smoke/Grenade_Smoke.Grenade_Smoke_C", minimalParseMode: ParseMode.Minimal)]
public class GrenadeSmokeExport : VRGrenadeExport { }

[NetFieldExportGroup("/Game/Guns/Grenades/Smoke/Grenade_Smoke_RU.Grenade_Smoke_RU_C", minimalParseMode: ParseMode.Minimal)]
public class GrenadeSmokeRUExport : VRGrenadeExport { }

// Frag Grenades
[NetFieldExportGroup("/Game/Guns/Grenades/M64/Grenade_M64.Grenade_M64_C", minimalParseMode: ParseMode.Minimal)]
public class GrenadeM64Export : VRGrenadeExport { }

[NetFieldExportGroup("/Game/Guns/Grenades/M64/Grenade_M64_RU.Grenade_M64_RU_C", minimalParseMode: ParseMode.Minimal)]
public class GrenadeM64RUExport : VRGrenadeExport { }

#endregion
