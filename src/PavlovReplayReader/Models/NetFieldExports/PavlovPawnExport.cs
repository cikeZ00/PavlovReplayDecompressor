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
    /// Gets or sets the player location (handle 45, fallback position).
    /// Note: Pavlov primarily uses Location (handles 49,51,53) for VR tracking.
    /// It's possible this is the starting position for the pawn.
    /// </summary>
    [NetFieldExportHandle(45, RepLayoutCmdType.PropertyVector)]
    public FVector? Location { get; set; }

    /// <summary>
    /// Gets or sets the player velocity (handle 46).
    /// </summary>
    [NetFieldExportHandle(46, RepLayoutCmdType.PropertyVector10)]
    public FVector? Velocity { get; set; }

    /// <summary>
    /// Gets or sets the player heading/yaw rotation (handle 47).
    /// </summary>
    [NetFieldExportHandle(47, RepLayoutCmdType.PropertyFloat)]
    public float? Heading { get; set; }

    /// <summary>
    /// Gets or sets the player flags (handle 48).
    /// </summary>
    [NetFieldExportHandle(48, RepLayoutCmdType.PropertyByte)]
    public byte? Flags { get; set; }

    /// <summary>
    /// Gets or sets the player/head location (handle 49, first "Location" from VR tracking).
    /// This is the main position of the player in the world.
    /// Note: Uses handle-based binding since replay uses same name "Location" for multiple properties.
    /// </summary>
    [NetFieldExportHandle(49, RepLayoutCmdType.PropertyVector)]
    public FVector? Location1 { get; set; }

    /// <summary>
    /// Gets or sets the head/body rotation (handle 50, first "Rotation" from VR tracking).
    /// </summary>
    [NetFieldExportHandle(50, RepLayoutCmdType.PropertyRotator)]
    public FRotator? Rotation { get; set; }

    /// <summary>
    /// Gets or sets the left hand location (handle 51, second "Location" from VR tracking).
    /// Note: Uses handle-based binding since replay uses same name "Location" for multiple properties.
    /// </summary>
    [NetFieldExportHandle(51, RepLayoutCmdType.PropertyVector)]
    public FVector? Location2 { get; set; }

    /// <summary>
    /// Gets or sets the left hand rotation (handle 52, second "Rotation" from VR tracking).
    /// </summary>
    [NetFieldExportHandle(52, RepLayoutCmdType.PropertyRotator)]
    public FRotator? Rotation1 { get; set; }

    /// <summary>
    /// Gets or sets the right hand location (handle 53, third "Location" from VR tracking).
    /// Note: Uses handle-based binding since replay uses same name "Location" for multiple properties.
    /// </summary>
    [NetFieldExportHandle(53, RepLayoutCmdType.PropertyVector)]
    public FVector? Location3 { get; set; }

    /// <summary>
    /// Gets or sets the right hand rotation (handle 54, third "Rotation" from VR tracking).
    /// </summary>
    [NetFieldExportHandle(54, RepLayoutCmdType.PropertyRotator)]
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
    /// Note: Property name in replay is "Index" - uses handle-based binding since right hand also uses "Index".
    /// </summary>
    [NetFieldExportHandle(58, RepLayoutCmdType.PropertyByte)]
    public byte? LeftIndex { get; set; }

    /// <summary>
    /// Gets or sets the left middle finger bend value (handle 59).
    /// Note: Property name in replay is "Midle" (typo) - uses handle-based binding.
    /// </summary>
    [NetFieldExportHandle(59, RepLayoutCmdType.PropertyByte)]
    public byte? LeftMiddle { get; set; }

    /// <summary>
    /// Gets or sets the left ring finger bend value (handle 60).
    /// Note: Uses handle-based binding since right hand also uses "Ring".
    /// </summary>
    [NetFieldExportHandle(60, RepLayoutCmdType.PropertyByte)]
    public byte? LeftRing { get; set; }

    /// <summary>
    /// Gets or sets the left pinky finger bend value (handle 61).
    /// Note: Uses handle-based binding since right hand also uses "Pinky".
    /// </summary>
    [NetFieldExportHandle(61, RepLayoutCmdType.PropertyByte)]
    public byte? LeftPinky { get; set; }

    /// <summary>
    /// Gets or sets the left thumb bend value (handle 62).
    /// Note: Uses handle-based binding since right hand also uses "Thumb".
    /// </summary>
    [NetFieldExportHandle(62, RepLayoutCmdType.PropertyByte)]
    public byte? LeftThumb { get; set; }

    #endregion

    #region Finger Tracking (Right Hand - handles 63-67)

    /// <summary>
    /// Gets or sets the right index finger bend value (handle 63).
    /// Note: Property name in replay is "Index" (same as left hand) - uses handle-based binding.
    /// </summary>
    [NetFieldExportHandle(63, RepLayoutCmdType.PropertyByte)]
    public byte? RightIndex { get; set; }

    /// <summary>
    /// Gets or sets the right middle finger bend value (handle 64).
    /// Note: Property name in replay is "Midle" (typo, same as left hand) - uses handle-based binding.
    /// </summary>
    [NetFieldExportHandle(64, RepLayoutCmdType.PropertyByte)]
    public byte? RightMiddle { get; set; }

    /// <summary>
    /// Gets or sets the right ring finger bend value (handle 65).
    /// Note: Property name in replay is "Ring" (same as left hand) - uses handle-based binding.
    /// </summary>
    [NetFieldExportHandle(65, RepLayoutCmdType.PropertyByte)]
    public byte? RightRing { get; set; }

    /// <summary>
    /// Gets or sets the right pinky finger bend value (handle 66).
    /// Note: Property name in replay is "Pinky" (same as left hand) - uses handle-based binding.
    /// </summary>
    [NetFieldExportHandle(66, RepLayoutCmdType.PropertyByte)]
    public byte? RightPinky { get; set; }

    /// <summary>
    /// Gets or sets the right thumb bend value (handle 67).
    /// Note: Property name in replay is "Thumb" (same as left hand) - uses handle-based binding.
    /// </summary>
    [NetFieldExportHandle(67, RepLayoutCmdType.PropertyByte)]
    public byte? RightThumb { get; set; }

    #endregion

    #region Hand Support State

    /// <summary>
    /// Gets or sets whether the left hand is supported/gripping (handle 68).
    /// Note: Property name in replay is "Supported" - uses handle-based binding since right hand also uses "Supported".
    /// </summary>
    [NetFieldExportHandle(68, RepLayoutCmdType.PropertyBool)]
    public bool? LeftSupported { get; set; }

    /// <summary>
    /// Gets or sets whether the right hand is supported/gripping (handle 69).
    /// Note: Property name in replay is "Supported" (same as left hand) - uses handle-based binding.
    /// </summary>
    [NetFieldExportHandle(69, RepLayoutCmdType.PropertyBool)]
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

    /// <summary>
    /// Gets or sets custom mesh (Unknown purpose). Ignored.
    /// </summary>
    [NetFieldExport("CustomMesh", RepLayoutCmdType.Ignore)]
    public uint? CustomMesh { get; set; }

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
