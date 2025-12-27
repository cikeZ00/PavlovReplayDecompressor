using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

/// <summary>
/// NetFieldExportGroup for Pavlov Player Pawn.
/// Contains player position, rotation, controller tracking, and avatar data.
/// </summary>
[NetFieldExportGroup("/Game/Gameplay/BP_PavlovPawn.BP_PavlovPawn_C", minimalParseMode: ParseMode.Minimal)]
public class PavlovPawnExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets whether the pawn is hidden in game.
    /// </summary>
    [NetFieldExport("bHidden", RepLayoutCmdType.PropertyBool)]
    public bool? bHidden { get; set; }

    /// <summary>
    /// Gets or sets whether the pawn can be damaged.
    /// </summary>
    [NetFieldExport("bCanBeDamaged", RepLayoutCmdType.PropertyBool)]
    public bool? bCanBeDamaged { get; set; }

    /// <summary>
    /// Gets or sets whether replay pause is on.
    /// </summary>
    [NetFieldExport("bReplayPauseCountDown", RepLayoutCmdType.PropertyBool)]
    public bool? bReplayPauseCountDown { get; set; }

    /// <summary>
    /// Gets or sets the remote role of this pawn.
    /// </summary>
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public int? RemoteRole { get; set; }

    /// <summary>
    /// Gets or sets the role of this pawn.
    /// </summary>
    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public int? Role { get; set; }

    /// <summary>
    /// Gets or sets the owner of this pawn.
    /// </summary>
    [NetFieldExport("Owner", RepLayoutCmdType.PropertyObject)]
    public uint? Owner { get; set; }

    /// <summary>
    /// Gets or sets the instigator.
    /// </summary>
    [NetFieldExport("Instigator", RepLayoutCmdType.PropertyObject)]
    public uint? Instigator { get; set; }

    /// <summary>
    /// Gets or sets the replicated movement data.
    /// Contains Location, Rotation, LinearVelocity, and AngularVelocity.
    /// </summary>
    [NetFieldExport("ReplicatedMovement", RepLayoutCmdType.RepMovement)]
    public FRepMovement? ReplicatedMovement { get; set; }

    /// <summary>
    /// Gets or sets the player/head location (Location1 from VR tracking).
    /// This is the main position of the player in the world.
    /// </summary>
    [NetFieldExport("Location1", RepLayoutCmdType.PropertyVector)]
    public FVector? Location1 { get; set; }

    /// <summary>
    /// Gets or sets the left hand location (Location2 from VR tracking).
    /// </summary>
    [NetFieldExport("Location2", RepLayoutCmdType.PropertyVector)]
    public FVector? Location2 { get; set; }

    /// <summary>
    /// Gets or sets the right hand location (Location3 from VR tracking).
    /// </summary>
    [NetFieldExport("Location3", RepLayoutCmdType.PropertyVector)]
    public FVector? Location3 { get; set; }

    /// <summary>
    /// Gets or sets the head/body rotation.
    /// </summary>
    [NetFieldExport("Rotation", RepLayoutCmdType.PropertyRotator)]
    public FRotator? Rotation { get; set; }

    /// <summary>
    /// Gets or sets the left hand rotation (Rotation1 from VR tracking).
    /// </summary>
    [NetFieldExport("Rotation1", RepLayoutCmdType.PropertyRotator)]
    public FRotator? Rotation1 { get; set; }

    /// <summary>
    /// Gets or sets the right hand rotation (Rotation2 from VR tracking).
    /// </summary>
    [NetFieldExport("Rotation2", RepLayoutCmdType.PropertyRotator)]
    public FRotator? Rotation2 { get; set; }

    /// <summary>
    /// Gets or sets the player location (if replicated separately from ReplicatedMovement).
    /// Note: Set to Ignore as Pavlov uses Location1/Location2/Location3 for position data.
    /// </summary>
    [NetFieldExport("Location", RepLayoutCmdType.Ignore)]
    public FVector? Location { get; set; }

    /// <summary>
    /// Gets or sets the player velocity (if replicated separately from ReplicatedMovement).
    /// Note: Set to Ignore as Pavlov uses ReplicatedMovement.LinearVelocity for velocity data.
    /// </summary>
    [NetFieldExport("Velocity", RepLayoutCmdType.Ignore)]
    public FVector? Velocity { get; set; }

    /// <summary>
    /// Gets or sets the player heading (yaw rotation).
    /// </summary>
    [NetFieldExport("Heading", RepLayoutCmdType.PropertyFloat)]
    public float? Heading { get; set; }

    /// <summary>
    /// Gets or sets the left VR controller reference (network GUID).
    /// This is a reference to the AVRController actor, not a position.
    /// </summary>
    [NetFieldExport("LeftController", RepLayoutCmdType.PropertyObject)]
    public uint? LeftController { get; set; }

    /// <summary>
    /// Gets or sets the right VR controller reference (network GUID).
    /// This is a reference to the AVRController actor, not a position.
    /// </summary>
    [NetFieldExport("RightController", RepLayoutCmdType.PropertyObject)]
    public uint? RightController { get; set; }

    /// <summary>
    /// Gets or sets the left controller rotation.
    /// Note: This property may not be replicated directly; rotation data might come from the VRController actor.
    /// </summary>
    [NetFieldExport("LeftControllerRot", RepLayoutCmdType.Ignore)]
    public FRotator? LeftControllerRot { get; set; }

    /// <summary>
    /// Gets or sets the right controller rotation.
    /// Note: This property may not be replicated directly; rotation data might come from the VRController actor.
    /// </summary>
    [NetFieldExport("RightControllerRot", RepLayoutCmdType.Ignore)]
    public FRotator? RightControllerRot { get; set; }

    /// <summary>
    /// Gets or sets the head rotation.
    /// </summary>
    [NetFieldExport("HeadRot", RepLayoutCmdType.PropertyRotator)]
    public FRotator? HeadRot { get; set; }

    /// <summary>
    /// Gets or sets the player's team ID.
    /// </summary>
    [NetFieldExport("TeamId", RepLayoutCmdType.PropertyByte)]
    public byte? TeamId { get; set; }

    /// <summary>
    /// Gets or sets the avatar ID.
    /// </summary>
    [NetFieldExport("AvatarId", RepLayoutCmdType.PropertyInt)]
    public int? AvatarId { get; set; }

    /// <summary>
    /// Gets or sets the avatar skin class.
    /// </summary>
    [NetFieldExport("AvatarSkinClass", RepLayoutCmdType.PropertyObject)]
    public uint? AvatarSkinClass { get; set; }

    /// <summary>
    /// Gets or sets the gaze direction.
    /// </summary>
    [NetFieldExport("GazeDir", RepLayoutCmdType.PropertyVector)]
    public FVector? GazeDir { get; set; }

    /// <summary>
    /// Gets or sets whether the player is blinking.
    /// </summary>
    [NetFieldExport("Blinking", RepLayoutCmdType.PropertyBool)]
    public bool? Blinking { get; set; }

    /// <summary>
    /// Gets or sets whether the player is currently talking.
    /// </summary>
    [NetFieldExport("bIsTalking", RepLayoutCmdType.PropertyBool)]
    public bool? bIsTalking { get; set; }

    /// <summary>
    /// Gets or sets whether the player is parachuting.
    /// </summary>
    [NetFieldExport("bParachuting", RepLayoutCmdType.PropertyBool)]
    public bool? bParachuting { get; set; }

    /// <summary>
    /// Gets or sets the player controller reference.
    /// </summary>
    [NetFieldExport("Controller", RepLayoutCmdType.PropertyObject)]
    public uint? Controller { get; set; }

    /// <summary>
    /// Gets or sets the player state reference.
    /// </summary>
    [NetFieldExport("PlayerState", RepLayoutCmdType.PropertyObject)]
    public uint? PlayerState { get; set; }

    /// <summary>
    /// Gets or sets the attached component reference.
    /// </summary>
    [NetFieldExport("AttachComponent", RepLayoutCmdType.PropertyObject)]
    public uint? AttachComponent { get; set; }

    /// <summary>
    /// Gets or sets whether the pawn is tear off (detached from network).
    /// </summary>
    [NetFieldExport("bTearOff", RepLayoutCmdType.PropertyBool)]
    public bool? bTearOff { get; set; }

    #region Finger Tracking

    /// <summary>
    /// Gets or sets the left index finger bend value.
    /// </summary>
    [NetFieldExport("LeftIndex", RepLayoutCmdType.PropertyFloat)]
    public float? LeftIndex { get; set; }

    /// <summary>
    /// Gets or sets the left middle finger bend value.
    /// </summary>
    [NetFieldExport("LeftMiddle", RepLayoutCmdType.PropertyFloat)]
    public float? LeftMiddle { get; set; }

    /// <summary>
    /// Gets or sets the left ring finger bend value.
    /// </summary>
    [NetFieldExport("LeftRing", RepLayoutCmdType.PropertyFloat)]
    public float? LeftRing { get; set; }

    /// <summary>
    /// Gets or sets the left pinky finger bend value.
    /// </summary>
    [NetFieldExport("LeftPinky", RepLayoutCmdType.PropertyFloat)]
    public float? LeftPinky { get; set; }

    /// <summary>
    /// Gets or sets the left thumb bend value.
    /// </summary>
    [NetFieldExport("LeftThumb", RepLayoutCmdType.PropertyFloat)]
    public float? LeftThumb { get; set; }

    /// <summary>
    /// Gets or sets the right index finger bend value.
    /// </summary>
    [NetFieldExport("RightIndex", RepLayoutCmdType.PropertyFloat)]
    public float? RightIndex { get; set; }

    /// <summary>
    /// Gets or sets the right middle finger bend value.
    /// </summary>
    [NetFieldExport("RightMiddle", RepLayoutCmdType.PropertyFloat)]
    public float? RightMiddle { get; set; }

    /// <summary>
    /// Gets or sets the right ring finger bend value.
    /// </summary>
    [NetFieldExport("RightRing", RepLayoutCmdType.PropertyFloat)]
    public float? RightRing { get; set; }

    /// <summary>
    /// Gets or sets the right pinky finger bend value.
    /// </summary>
    [NetFieldExport("RightPinky", RepLayoutCmdType.PropertyFloat)]
    public float? RightPinky { get; set; }

    /// <summary>
    /// Gets or sets the right thumb bend value.
    /// </summary>
    [NetFieldExport("RightThumb", RepLayoutCmdType.PropertyFloat)]
    public float? RightThumb { get; set; }

    #endregion

    #region Packed Finger Data

    /// <summary>
    /// Gets or sets the packed left hand finger data.
    /// </summary>
    [NetFieldExport("PackedLeftHand", RepLayoutCmdType.PropertyUInt32)]
    public uint? PackedLeftHand { get; set; }

    /// <summary>
    /// Gets or sets the packed right hand finger data.
    /// </summary>
    [NetFieldExport("PackedRightHand", RepLayoutCmdType.PropertyUInt32)]
    public uint? PackedRightHand { get; set; }

    #endregion
}
