using Unreal.Core.Models;

namespace PavlovReplayReader.Models;

/// <summary>
/// Represents player pawn data including position, movement, and VR controller tracking.
/// Updated in real-time as the replay progresses.
/// </summary>
public class PawnData
{
    /// <summary>
    /// Channel index for this pawn (used for linking to player state).
    /// </summary>
    public uint ChannelIndex { get; set; }

    /// <summary>
    /// Replay time when this pawn data was last updated (in seconds).
    /// </summary>
    public float LastUpdateTime { get; set; }

    #region Position and Movement

    /// <summary>
    /// Current world location of the pawn (from Location - world pawn position).
    /// </summary>
    public FVector? Location { get; set; }

    /// <summary>
    /// Head location (from Location1).
    /// </summary>
    public FVector? HeadLocation { get; set; }

    /// <summary>
    /// Left hand world location (from Location2).
    /// </summary>
    public FVector? LeftHandLocation { get; set; }

    /// <summary>
    /// Right hand world location (from Location3).
    /// </summary>
    public FVector? RightHandLocation { get; set; }

    /// <summary>
    /// Head/body rotation.
    /// </summary>
    public FRotator? Rotation { get; set; }

    /// <summary>
    /// Left hand rotation.
    /// </summary>
    public FRotator? LeftHandRotation { get; set; }

    /// <summary>
    /// Right hand rotation.
    /// </summary>
    public FRotator? RightHandRotation { get; set; }

    /// <summary>
    /// Current velocity of the pawn.
    /// </summary>
    public FVector? Velocity { get; set; }

    /// <summary>
    /// Current heading/yaw rotation in degrees.
    /// </summary>
    public float? Heading { get; set; }

    #endregion

    #region VR Controller Tracking

    /// <summary>
    /// Left VR controller actor reference (network GUID).
    /// </summary>
    public uint? LeftControllerRef { get; set; }

    /// <summary>
    /// Right VR controller actor reference (network GUID).
    /// </summary>
    public uint? RightControllerRef { get; set; }

    /// <summary>
    /// Left VR controller rotation.
    /// </summary>
    public FRotator? LeftControllerRot { get; set; }

    /// <summary>
    /// Right VR controller rotation.
    /// </summary>
    public FRotator? RightControllerRot { get; set; }

    /// <summary>
    /// Head/HMD rotation.
    /// </summary>
    public FRotator? HeadRot { get; set; }

    /// <summary>
    /// Gaze/look direction vector.
    /// </summary>
    public FVector? GazeDir { get; set; }

    #endregion

    #region Finger Tracking

    /// <summary>
    /// Left hand finger curl values (Index, Middle, Ring, Pinky, Thumb).
    /// Values range from 0 (extended) to 1 (fully curled).
    /// </summary>
    public float[]? LeftFingers { get; set; }

    /// <summary>
    /// Right hand finger curl values (Index, Middle, Ring, Pinky, Thumb).
    /// Values range from 0 (extended) to 1 (fully curled).
    /// </summary>
    public float[]? RightFingers { get; set; }

    /// <summary>
    /// Packed left hand finger data.
    /// </summary>
    public uint? PackedLeftHand { get; set; }

    /// <summary>
    /// Packed right hand finger data.
    /// </summary>
    public uint? PackedRightHand { get; set; }

    #endregion

    #region Avatar and State

    /// <summary>
    /// Team ID this pawn belongs to (0 or 1 for teams).
    /// </summary>
    public int? TeamId { get; set; }

    /// <summary>
    /// Avatar/skin ID.
    /// </summary>
    public int? AvatarId { get; set; }

    /// <summary>
    /// Avatar skin class reference.
    /// </summary>
    public uint? AvatarSkinClass { get; set; }

    /// <summary>
    /// Whether the player's avatar is currently blinking.
    /// </summary>
    public bool? Blinking { get; set; }

    /// <summary>
    /// Whether the player is currently talking (voice activity).
    /// </summary>
    public bool? IsTalking { get; set; }

    /// <summary>
    /// Whether the player is currently parachuting.
    /// </summary>
    public bool? IsParachuting { get; set; }

    /// <summary>
    /// Whether the pawn is hidden.
    /// </summary>
    public bool? IsHidden { get; set; }

    /// <summary>
    /// Whether the player is invulnerable.
    /// </summary>
    public bool? IsInvulnerable { get; set; }

    /// <summary>
    /// Player flags byte.
    /// </summary>
    public byte? Flags { get; set; }

    /// <summary>
    /// Body armour value.
    /// </summary>
    public int? Armour { get; set; }

    /// <summary>
    /// Helmet armour value.
    /// </summary>
    public int? HelmetArmour { get; set; }

    /// <summary>
    /// Radio channel the player is on.
    /// </summary>
    public byte? RadioChannel { get; set; }

    /// <summary>
    /// Whether the left hand is supported/gripping.
    /// </summary>
    public bool? LeftSupported { get; set; }

    /// <summary>
    /// Whether the right hand is supported/gripping.
    /// </summary>
    public bool? RightSupported { get; set; }

    #endregion

    #region References

    /// <summary>
    /// Associated player state network GUID (raw value from replay).
    /// Use ResolvedPlayerChannel for the actual channel index.
    /// </summary>
    public uint? PlayerStateRef { get; set; }
    
    /// <summary>
    /// Resolved player state channel index (from network GUID mapping).
    /// This is the channel index that can be used to look up player data.
    /// </summary>
    public uint? ResolvedPlayerChannel { get; set; }

    /// <summary>
    /// Controller actor reference.
    /// </summary>
    public uint? ControllerRef { get; set; }

    /// <summary>
    /// Owner actor reference.
    /// </summary>
    public uint? OwnerRef { get; set; }

    #endregion
}
