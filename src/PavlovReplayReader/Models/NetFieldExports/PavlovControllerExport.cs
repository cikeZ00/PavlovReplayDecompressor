using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

/// <summary>
/// NetFieldExportGroup for Pavlov Controller (VR hand controller).
/// Contains hand tracking data for VR controllers.
/// Property handles from Debug.txt:
/// 4: RemoteRole, 5: AttachParent, 6: LocationOffset, 7: RelativeScale3D,
/// 8: RotationOffset, 10: AttachComponent, 12: Owner, 13: Role, 14: Instigator,
/// 16: HandType, 17: State, 22: bFlag, 23: bDominant
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
    /// Gets or sets the remote role of this controller (handle 4).
    /// </summary>
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public int? RemoteRole { get; set; }

    /// <summary>
    /// Gets or sets the attach parent (handle 5).
    /// </summary>
    [NetFieldExport("AttachParent", RepLayoutCmdType.PropertyObject)]
    public uint? AttachParent { get; set; }

    /// <summary>
    /// Gets or sets the location offset from the pawn (handle 6).
    /// Note: Set to Ignore as the actual serialization format doesn't match PropertyVector.
    /// </summary>
    [NetFieldExport("LocationOffset", RepLayoutCmdType.Ignore)]
    public FVector? LocationOffset { get; set; }

    /// <summary>
    /// Gets or sets the relative scale 3D (handle 7).
    /// 31 bits - uses PropertyVectorQ format (quantized vector).
    /// </summary>
    [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVectorQ)]
    public FVector? RelativeScale3D { get; set; }

    /// <summary>
    /// Gets or sets the rotation offset from the pawn (handle 8).
    /// Note: Set to Ignore as the actual serialization format doesn't match PropertyRotator.
    /// </summary>
    [NetFieldExport("RotationOffset", RepLayoutCmdType.Ignore)]
    public FRotator? RotationOffset { get; set; }

    /// <summary>
    /// Gets or sets the attach component (handle 10).
    /// 8 bits - PropertyObject format.
    /// </summary>
    [NetFieldExport("AttachComponent", RepLayoutCmdType.PropertyObject)]
    public uint? AttachComponent { get; set; }

    /// <summary>
    /// Gets or sets the owner of this controller (handle 12).
    /// </summary>
    [NetFieldExport("Owner", RepLayoutCmdType.PropertyObject)]
    public uint? Owner { get; set; }

    /// <summary>
    /// Gets or sets the role of this controller (handle 13).
    /// </summary>
    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public int? Role { get; set; }

    /// <summary>
    /// Gets or sets the instigator (handle 14).
    /// </summary>
    [NetFieldExport("Instigator", RepLayoutCmdType.PropertyObject)]
    public uint? Instigator { get; set; }

    /// <summary>
    /// Gets or sets the hand type - left or right (handle 16).
    /// </summary>
    [NetFieldExport("HandType", RepLayoutCmdType.PropertyByte)]
    public byte? HandType { get; set; }

    /// <summary>
    /// Gets or sets the controller state (handle 17).
    /// </summary>
    [NetFieldExport("State", RepLayoutCmdType.PropertyByte)]
    public byte? State { get; set; }

    /// <summary>
    /// Gets or sets the controller flag (handle 22).
    /// </summary>
    [NetFieldExport("bFlag", RepLayoutCmdType.PropertyBool)]
    public bool? bFlag { get; set; }

    /// <summary>
    /// Gets or sets whether this is the dominant hand (handle 23).
    /// </summary>
    [NetFieldExport("bDominant", RepLayoutCmdType.PropertyBool)]
    public bool? bDominant { get; set; }

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
