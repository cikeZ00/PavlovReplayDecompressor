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
    #region Actor Base Properties

    /// <summary>
    /// Gets or sets whether the magazine is hidden.
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
    /// Gets or sets whether the magazine is torn off.
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
    /// Gets or sets the parent item (the gun this magazine is attached to).
    /// </summary>
    [NetFieldExport("Parent", RepLayoutCmdType.PropertyObject)]
    public uint? Parent { get; set; }

    /// <summary>
    /// Gets or sets the parent attachment slot.
    /// </summary>
    [NetFieldExport("ParentSlot", RepLayoutCmdType.PropertyByte)]
    public byte? ParentSlot { get; set; }

    #endregion

    #region Magazine Properties

    /// <summary>
    /// Gets or sets the current bullet count in the magazine.
    /// </summary>
    [NetFieldExport("Bullets", RepLayoutCmdType.PropertyInt)]
    public int? Bullets { get; set; }

    /// <summary>
    /// Gets or sets the maximum bullet capacity.
    /// </summary>
    [NetFieldExport("MaxBullets", RepLayoutCmdType.PropertyInt)]
    public int? MaxBullets { get; set; }

    /// <summary>
    /// Gets or sets the magazine skin class (class reference, ignored).
    /// </summary>
    [NetFieldExport("MagazineSkinClass", RepLayoutCmdType.Ignore)]
    public object? MagazineSkinClass { get; set; }

    #endregion
}

#region Specific Magazine Exports

// Rifle Magazines
[NetFieldExportGroup("/Game/Guns/M4/Magazine_M4.Magazine_M4_C", minimalParseMode: ParseMode.Minimal)]
public class MagazineM4Export : MagazineExport { }

[NetFieldExportGroup("/Game/Guns/AK/Magazine_AK47.Magazine_AK47_C", minimalParseMode: ParseMode.Minimal)]
public class MagazineAK47Export : MagazineExport { }

[NetFieldExportGroup("/Game/Guns/AKshorty/Magazine_AKshorty.Magazine_AKshorty_C", minimalParseMode: ParseMode.Minimal)]
public class MagazineAKshortyExport : MagazineExport { }

[NetFieldExportGroup("/Game/Guns/AUG/Magazine_AUG.Magazine_AUG_C", minimalParseMode: ParseMode.Minimal)]
public class MagazineAUGExport : MagazineExport { }

[NetFieldExportGroup("/Game/Guns/SCAR/Magazine_SCAR20.Magazine_SCAR20_C", minimalParseMode: ParseMode.Minimal)]
public class MagazineSCAR20Export : MagazineExport { }

[NetFieldExportGroup("/Game/Guns/AutoSniper/Magazine_AutoSniper.Magazine_AutoSniper_C", minimalParseMode: ParseMode.Minimal)]
public class MagazineAutoSniperExport : MagazineExport { }

// Pistol Magazines
[NetFieldExportGroup("/Game/Guns/C1911/Magazine_1911.Magazine_1911_C", minimalParseMode: ParseMode.Minimal)]
public class Magazine1911Export : MagazineExport { }

[NetFieldExportGroup("/Game/Guns/Tokarev/Magazine_Tokarev.Magazine_Tokarev_C", minimalParseMode: ParseMode.Minimal)]
public class MagazineTokarevExport : MagazineExport { }

[NetFieldExportGroup("/Game/Guns/DE/Magazine_DE.Magazine_DE_C", minimalParseMode: ParseMode.Minimal)]
public class MagazineDEExport : MagazineExport { }

[NetFieldExportGroup("/Game/Guns/Glock/Magazine_Glock.Magazine_Glock_C", minimalParseMode: ParseMode.Minimal)]
public class MagazineGlockExport : MagazineExport { }

[NetFieldExportGroup("/Game/Guns/57/Magazine_57.Magazine_57_C", minimalParseMode: ParseMode.Minimal)]
public class Magazine57Export : MagazineExport { }

[NetFieldExportGroup("/Game/Guns/Revolver/Magazine_Revolver.Magazine_Revolver_C", minimalParseMode: ParseMode.Minimal)]
public class MagazineRevolverExport : MagazineExport { }

// SMG Magazines
[NetFieldExportGroup("/Game/Guns/SMG/Magazine_SMG.Magazine_SMG_C", minimalParseMode: ParseMode.Minimal)]
public class MagazineSMGExport : MagazineExport { }

[NetFieldExportGroup("/Game/Guns/Pepe/Magazine_Pepe.Magazine_Pepe_C", minimalParseMode: ParseMode.Minimal)]
public class MagazinePepeExport : MagazineExport { }

#endregion
