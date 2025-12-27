using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

/// <summary>
/// NetFieldExportGroup for Search and Destroy bomb.
/// Contains bomb state for S&amp;D game mode.
/// </summary>
[NetFieldExportGroup("/Game/Gameplay/SearchAndDestroy/Bomb/Bomb.Bomb_C", minimalParseMode: ParseMode.Minimal)]
public class BombExport : BombExportBase { }

/// <summary>
/// NetFieldExportGroup for basic bomb variant.
/// </summary>
[NetFieldExportGroup("/Game/Gameplay/SearchAndDestroy/Bomb/Bomb_Basic.Bomb_Basic_C", minimalParseMode: ParseMode.Minimal)]
public class BombBasicExport : BombExportBase { }

/// <summary>
/// Base class for bomb exports with all properties.
/// </summary>
public class BombExportBase : INetFieldExportGroup
{
    #region Actor Base Properties

    /// <summary>
    /// Gets or sets whether the bomb is hidden.
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
    /// Gets or sets whether the bomb is torn off.
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

    #region Bomb Properties

    /// <summary>
    /// Gets or sets the current bomb state.
    /// </summary>
    [NetFieldExport("State", RepLayoutCmdType.Enum)]
    public int? State { get; set; }

    /// <summary>
    /// Gets or sets the current bomb state (alternative name).
    /// </summary>
    [NetFieldExport("BombState", RepLayoutCmdType.Enum)]
    public int? BombState { get; set; }

    /// <summary>
    /// Gets or sets the bomb timer value.
    /// </summary>
    [NetFieldExport("Timer", RepLayoutCmdType.PropertyFloat)]
    public float? Timer { get; set; }

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
    /// Gets or sets the bomb defuse code.
    /// </summary>
    [NetFieldExport("Code", RepLayoutCmdType.PropertyString)]
    public string? Code { get; set; }

    /// <summary>
    /// Gets or sets the next digit to enter in the defuse code.
    /// </summary>
    [NetFieldExport("NextDigit", RepLayoutCmdType.PropertyInt)]
    public int? NextDigit { get; set; }

    /// <summary>
    /// Gets or sets the wire states for defusing.
    /// </summary>
    [NetFieldExport("WireStates", RepLayoutCmdType.Ignore)]
    public object? WireStates { get; set; }

    #endregion
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
    public object? RemoteRole { get; set; }

    /// <summary>
    /// Gets or sets the role.
    /// </summary>
    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public object? Role { get; set; }

    /// <summary>
    /// Gets or sets the replicated movement.
    /// </summary>
    [NetFieldExport("ReplicatedMovement", RepLayoutCmdType.RepMovement)]
    public FRepMovement? ReplicatedMovement { get; set; }

    /// <summary>
    /// Gets or sets whether this spot is enabled.
    /// </summary>
    [NetFieldExport("bSpotEnabled", RepLayoutCmdType.PropertyBool)]
    public bool? bSpotEnabled { get; set; }
}

/// <summary>
/// NetFieldExportGroup for defuse pliers.
/// Used for bomb defusal in S&amp;D mode.
/// </summary>
[NetFieldExportGroup("/Game/Gameplay/SearchAndDestroy/Pliers/Pliers_Basic.Pliers_Basic_C", minimalParseMode: ParseMode.Minimal)]
public class PliersExport : INetFieldExportGroup
{
    #region Actor Base Properties

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
    /// Gets or sets the replicated movement.
    /// </summary>
    [NetFieldExport("ReplicatedMovement", RepLayoutCmdType.RepMovement)]
    public FRepMovement? ReplicatedMovement { get; set; }

    #endregion

    #region Attachment Replication

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
    /// Gets or sets the relative scale for attachment.
    /// </summary>
    [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVector100)]
    public FVector? RelativeScale3D { get; set; }

    #endregion

    #region VRItem Properties

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
}
