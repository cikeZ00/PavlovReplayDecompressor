using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

/// <summary>
/// NetFieldExportGroup for Pavlov Player Pawn.
/// Contains player position, rotation, controller tracking, and avatar data.
/// Property handles from Debug.txt:
/// - 4: RemoteRole, 12: Owner, 13: Role, 14: Instigator
/// - 16: PlayerState, 17: Controller
/// - 45: Location, 46: Velocity, 47: Heading, 48: Flags
/// - 49,50: Location1/Rotation, 51,52: Location2/Rotation1, 53,54: Location3/Rotation2
/// - 55: InventoryLogic, 56: LeftController, 57: RightController
/// - 58-62: Index/Midle/Ring/Pinky/Thumb (left hand)
/// - 63-67: Index1/Midle1/Ring1/Pinky1/Thumb1 (right hand)
/// - 68,69: Supported/Supported1
/// - 70: Blinking, 71: GazeDir, 72: AvatarSkinClass
/// - 76: bInvulnerable, 77: RadioChannel, 78: Armour, 79: HelmetArmour
/// - 80: TeamId (32-bit int!), 81: RevivePlayerState, 86: AvatarId
/// </summary>
[NetFieldExportGroup("/Game/Gameplay/BP_PavlovPawn.BP_PavlovPawn_C", minimalParseMode: ParseMode.Minimal)]
public class PavlovPawnExport : INetFieldExportGroup
{
    #region Base Actor Properties

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
    /// Gets or sets the remote role of this pawn (handle 4).
    /// </summary>
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public int? RemoteRole { get; set; }

    /// <summary>
    /// Gets or sets the role of this pawn (handle 13).
    /// </summary>
    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public int? Role { get; set; }

    /// <summary>
    /// Gets or sets the owner of this pawn (handle 12).
    /// </summary>
    [NetFieldExport("Owner", RepLayoutCmdType.PropertyObject)]
    public uint? Owner { get; set; }

    /// <summary>
    /// Gets or sets the instigator (handle 14).
    /// </summary>
    [NetFieldExport("Instigator", RepLayoutCmdType.PropertyObject)]
    public uint? Instigator { get; set; }

    /// <summary>
    /// Gets or sets the player state reference (handle 16).
    /// </summary>
    [NetFieldExport("PlayerState", RepLayoutCmdType.PropertyObject)]
    public uint? PlayerState { get; set; }

    /// <summary>
    /// Gets or sets the player controller reference (handle 17).
    /// </summary>
    [NetFieldExport("Controller", RepLayoutCmdType.PropertyObject)]
    public uint? Controller { get; set; }

    #endregion

    #region Position and Movement

    /// <summary>
    /// Gets or sets the replicated movement data.
    /// Contains Location, Rotation, LinearVelocity, and AngularVelocity.
    /// </summary>
    [NetFieldExport("ReplicatedMovement", RepLayoutCmdType.RepMovement)]
    public FRepMovement? ReplicatedMovement { get; set; }

    /// <summary>
    /// Gets or sets the player location (handle 45, fallback position).
    /// Note: Pavlov primarily uses Location1/Location2/Location3 for VR tracking.
    /// </summary>
    [NetFieldExport("Location", RepLayoutCmdType.Ignore)]
    public FVector? Location { get; set; }

    /// <summary>
    /// Gets or sets the player velocity (handle 46).
    /// </summary>
    [NetFieldExport("Velocity", RepLayoutCmdType.Ignore)]
    public FVector? Velocity { get; set; }

    /// <summary>
    /// Gets or sets the player heading/yaw rotation (handle 47).
    /// </summary>
    [NetFieldExport("Heading", RepLayoutCmdType.PropertyFloat)]
    public float? Heading { get; set; }

    /// <summary>
    /// Gets or sets the player flags (handle 48).
    /// </summary>
    [NetFieldExport("Flags", RepLayoutCmdType.PropertyByte)]
    public byte? Flags { get; set; }

    /// <summary>
    /// Gets or sets the player/head location (handle 49, Location1 from VR tracking).
    /// This is the main position of the player in the world.
    /// </summary>
    [NetFieldExport("Location1", RepLayoutCmdType.PropertyVector)]
    public FVector? Location1 { get; set; }

    /// <summary>
    /// Gets or sets the head/body rotation (handle 50).
    /// </summary>
    [NetFieldExport("Rotation", RepLayoutCmdType.PropertyRotator)]
    public FRotator? Rotation { get; set; }

    /// <summary>
    /// Gets or sets the left hand location (handle 51, Location2 from VR tracking).
    /// </summary>
    [NetFieldExport("Location2", RepLayoutCmdType.PropertyVector)]
    public FVector? Location2 { get; set; }

    /// <summary>
    /// Gets or sets the left hand rotation (handle 52, Rotation1 from VR tracking).
    /// </summary>
    [NetFieldExport("Rotation1", RepLayoutCmdType.PropertyRotator)]
    public FRotator? Rotation1 { get; set; }

    /// <summary>
    /// Gets or sets the right hand location (handle 53, Location3 from VR tracking).
    /// </summary>
    [NetFieldExport("Location3", RepLayoutCmdType.PropertyVector)]
    public FVector? Location3 { get; set; }

    /// <summary>
    /// Gets or sets the right hand rotation (handle 54, Rotation2 from VR tracking).
    /// </summary>
    [NetFieldExport("Rotation2", RepLayoutCmdType.PropertyRotator)]
    public FRotator? Rotation2 { get; set; }

    #endregion

    #region VR Controller References

    /// <summary>
    /// Gets or sets the inventory logic reference (handle 55).
    /// </summary>
    [NetFieldExport("InventoryLogic", RepLayoutCmdType.PropertyObject)]
    public uint? InventoryLogic { get; set; }

    /// <summary>
    /// Gets or sets the left VR controller reference (handle 56, network GUID).
    /// This is a reference to the AVRController actor, not a position.
    /// </summary>
    [NetFieldExport("LeftController", RepLayoutCmdType.PropertyObject)]
    public uint? LeftController { get; set; }

    /// <summary>
    /// Gets or sets the right VR controller reference (handle 57, network GUID).
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

    #endregion

    #region Finger Tracking (Left Hand - handles 58-62)

    /// <summary>
    /// Gets or sets the left index finger bend value (handle 58).
    /// Note: Property name in replay is "Index", mapped to LeftIndex for clarity.
    /// </summary>
    [NetFieldExport("Index", RepLayoutCmdType.PropertyByte)]
    public byte? LeftIndex { get; set; }

    /// <summary>
    /// Gets or sets the left middle finger bend value (handle 59).
    /// Note: Property name in replay is "Midle" (typo), mapped to LeftMiddle.
    /// </summary>
    [NetFieldExport("Midle", RepLayoutCmdType.PropertyByte)]
    public byte? LeftMiddle { get; set; }

    /// <summary>
    /// Gets or sets the left ring finger bend value (handle 60).
    /// </summary>
    [NetFieldExport("Ring", RepLayoutCmdType.PropertyByte)]
    public byte? LeftRing { get; set; }

    /// <summary>
    /// Gets or sets the left pinky finger bend value (handle 61).
    /// </summary>
    [NetFieldExport("Pinky", RepLayoutCmdType.PropertyByte)]
    public byte? LeftPinky { get; set; }

    /// <summary>
    /// Gets or sets the left thumb bend value (handle 62).
    /// </summary>
    [NetFieldExport("Thumb", RepLayoutCmdType.PropertyByte)]
    public byte? LeftThumb { get; set; }

    #endregion

    #region Finger Tracking (Right Hand - handles 63-67)

    /// <summary>
    /// Gets or sets the right index finger bend value (handle 63).
    /// Note: Property name in replay is "Index1", mapped to RightIndex for clarity.
    /// </summary>
    [NetFieldExport("Index1", RepLayoutCmdType.PropertyByte)]
    public byte? RightIndex { get; set; }

    /// <summary>
    /// Gets or sets the right middle finger bend value (handle 64).
    /// Note: Property name in replay is "Midle1" (typo), mapped to RightMiddle.
    /// </summary>
    [NetFieldExport("Midle1", RepLayoutCmdType.PropertyByte)]
    public byte? RightMiddle { get; set; }

    /// <summary>
    /// Gets or sets the right ring finger bend value (handle 65).
    /// </summary>
    [NetFieldExport("Ring1", RepLayoutCmdType.PropertyByte)]
    public byte? RightRing { get; set; }

    /// <summary>
    /// Gets or sets the right pinky finger bend value (handle 66).
    /// </summary>
    [NetFieldExport("Pinky1", RepLayoutCmdType.PropertyByte)]
    public byte? RightPinky { get; set; }

    /// <summary>
    /// Gets or sets the right thumb bend value (handle 67).
    /// </summary>
    [NetFieldExport("Thumb1", RepLayoutCmdType.PropertyByte)]
    public byte? RightThumb { get; set; }

    #endregion

    #region Hand Support State

    /// <summary>
    /// Gets or sets whether the left hand is supported/gripping (handle 68).
    /// </summary>
    [NetFieldExport("Supported", RepLayoutCmdType.PropertyBool)]
    public bool? LeftSupported { get; set; }

    /// <summary>
    /// Gets or sets whether the right hand is supported/gripping (handle 69).
    /// </summary>
    [NetFieldExport("Supported1", RepLayoutCmdType.PropertyBool)]
    public bool? RightSupported { get; set; }

    #endregion

    #region Avatar and State

    /// <summary>
    /// Gets or sets whether the player is blinking (handle 70).
    /// </summary>
    [NetFieldExport("Blinking", RepLayoutCmdType.PropertyBool)]
    public bool? Blinking { get; set; }

    /// <summary>
    /// Gets or sets the gaze direction (handle 71).
    /// </summary>
    [NetFieldExport("GazeDir", RepLayoutCmdType.PropertyVector)]
    public FVector? GazeDir { get; set; }

    /// <summary>
    /// Gets or sets the avatar skin class (handle 72).
    /// </summary>
    [NetFieldExport("AvatarSkinClass", RepLayoutCmdType.PropertyObject)]
    public uint? AvatarSkinClass { get; set; }

    /// <summary>
    /// Gets or sets whether the player is invulnerable (handle 76).
    /// </summary>
    [NetFieldExport("bInvulnerable", RepLayoutCmdType.PropertyBool)]
    public bool? bInvulnerable { get; set; }

    /// <summary>
    /// Gets or sets the radio channel (handle 77).
    /// </summary>
    [NetFieldExport("RadioChannel", RepLayoutCmdType.PropertyByte)]
    public byte? RadioChannel { get; set; }

    /// <summary>
    /// Gets or sets the body armour value (handle 78).
    /// </summary>
    [NetFieldExport("Armour", RepLayoutCmdType.PropertyInt)]
    public int? Armour { get; set; }

    /// <summary>
    /// Gets or sets the helmet armour value (handle 79).
    /// </summary>
    [NetFieldExport("HelmetArmour", RepLayoutCmdType.PropertyInt)]
    public int? HelmetArmour { get; set; }

    /// <summary>
    /// Gets or sets the player's team ID (handle 80).
    /// Note: This is a 32-bit int in the pawn, not a byte!
    /// </summary>
    [NetFieldExport("TeamId", RepLayoutCmdType.PropertyInt)]
    public int? TeamId { get; set; }

    /// <summary>
    /// Gets or sets the revive player state reference (handle 81).
    /// </summary>
    [NetFieldExport("RevivePlayerState", RepLayoutCmdType.PropertyObject)]
    public uint? RevivePlayerState { get; set; }

    /// <summary>
    /// Gets or sets the avatar ID (handle 86).
    /// </summary>
    [NetFieldExport("AvatarId", RepLayoutCmdType.PropertyInt)]
    public int? AvatarId { get; set; }

    /// <summary>
    /// Gets or sets the head rotation.
    /// </summary>
    [NetFieldExport("HeadRot", RepLayoutCmdType.PropertyRotator)]
    public FRotator? HeadRot { get; set; }

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
    /// Gets or sets the attached component reference.
    /// </summary>
    [NetFieldExport("AttachComponent", RepLayoutCmdType.PropertyObject)]
    public uint? AttachComponent { get; set; }

    /// <summary>
    /// Gets or sets whether the pawn is tear off (detached from network).
    /// </summary>
    [NetFieldExport("bTearOff", RepLayoutCmdType.PropertyBool)]
    public bool? bTearOff { get; set; }

    #endregion

    #region Packed Finger Data (Alternative to individual finger tracking)

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
