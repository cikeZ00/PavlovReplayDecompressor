using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

/// <summary>
/// NetFieldExportGroup for Pavlov Controller (VR hand controller).
/// Contains hand tracking data for VR controllers.
/// </summary>
[NetFieldExportGroup("/Game/Gameplay/BP_PavlovController.BP_PavlovController_C", minimalParseMode: ParseMode.Minimal)]
public class PavlovControllerExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets whether this controller is hidden.
    /// </summary>
    [NetFieldExport("bHidden", RepLayoutCmdType.PropertyBool)]
    public bool? bHidden { get; set; }

    /// <summary>
    /// Gets or sets the remote role of this controller.
    /// </summary>
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public int? RemoteRole { get; set; }

    /// <summary>
    /// Gets or sets the role of this controller.
    /// </summary>
    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public int? Role { get; set; }

    /// <summary>
    /// Gets or sets the owner of this controller.
    /// </summary>
    [NetFieldExport("Owner", RepLayoutCmdType.PropertyObject)]
    public uint? Owner { get; set; }

    /// <summary>
    /// Gets or sets the instigator.
    /// </summary>
    [NetFieldExport("Instigator", RepLayoutCmdType.PropertyObject)]
    public uint? Instigator { get; set; }

    /// <summary>
    /// Gets or sets the hand type (left or right).
    /// </summary>
    [NetFieldExport("HandType", RepLayoutCmdType.PropertyByte)]
    public byte? HandType { get; set; }

    /// <summary>
    /// Gets or sets the controller state.
    /// </summary>
    [NetFieldExport("State", RepLayoutCmdType.PropertyByte)]
    public byte? State { get; set; }

    /// <summary>
    /// Gets or sets the controller flag.
    /// </summary>
    [NetFieldExport("bFlag", RepLayoutCmdType.PropertyBool)]
    public bool? bFlag { get; set; }

    /// <summary>
    /// Gets or sets whether this is the dominant hand.
    /// </summary>
    [NetFieldExport("bDominant", RepLayoutCmdType.PropertyBool)]
    public bool? bDominant { get; set; }

    /// <summary>
    /// Gets or sets the location offset from the pawn.
    /// Note: Set to Ignore as the actual serialization format doesn't match PropertyVector.
    /// </summary>
    [NetFieldExport("LocationOffset", RepLayoutCmdType.Ignore)]
    public FVector? LocationOffset { get; set; }

    /// <summary>
    /// Gets or sets the rotation offset from the pawn.
    /// Note: Set to Ignore as the actual serialization format doesn't match PropertyRotator.
    /// </summary>
    [NetFieldExport("RotationOffset", RepLayoutCmdType.Ignore)]
    public FRotator? RotationOffset { get; set; }

    /// <summary>
    /// Gets or sets the relative location.
    /// </summary>
    [NetFieldExport("RelativeLocation", RepLayoutCmdType.PropertyVector100)]
    public FVector? RelativeLocation { get; set; }

    /// <summary>
    /// Gets or sets the relative rotation.
    /// </summary>
    [NetFieldExport("RelativeRotation", RepLayoutCmdType.PropertyRotator)]
    public FRotator? RelativeRotation { get; set; }

    /// <summary>
    /// Gets or sets the attach parent.
    /// </summary>
    [NetFieldExport("AttachParent", RepLayoutCmdType.PropertyObject)]
    public uint? AttachParent { get; set; }

    /// <summary>
    /// Gets or sets the attach socket name.
    /// </summary>
    [NetFieldExport("AttachSocketName", RepLayoutCmdType.Property)]
    public string? AttachSocketName { get; set; }

    /// <summary>
    /// Gets or sets the attach children.
    /// </summary>
    [NetFieldExport("AttachChildren", RepLayoutCmdType.DynamicArray)]
    public uint[]? AttachChildren { get; set; }

    /// <summary>
    /// Gets or sets whether this component replicates using registered sub-object list.
    /// </summary>
    [NetFieldExport("bReplicateUsingRegisteredSubObjectList", RepLayoutCmdType.PropertyBool)]
    public bool? bReplicateUsingRegisteredSubObjectList { get; set; }
}
