using Unreal.Core.Models;
using PavlovReplayReader.Models.Enums;

namespace PavlovReplayReader.Models;

/// <summary>
/// Represents weapon/gun data from the replay.
/// </summary>
public class WeaponData
{
    /// <summary>
    /// Channel index for this weapon.
    /// </summary>
    public uint ChannelIndex { get; set; }

    /// <summary>
    /// Type of weapon (e.g., "VRGun", "VRKnife", "VRGrenade", "VRLauncher").
    /// </summary>
    public string? WeaponType { get; set; }

    /// <summary>
    /// Weapon class path name.
    /// </summary>
    public string? ClassName { get; set; }

    /// <summary>
    /// Replay time when this data was last updated.
    /// </summary>
    public float LastUpdateTime { get; set; }

    #region Ammo

    /// <summary>
    /// Current ammo in chamber.
    /// </summary>
    public int? Ammo { get; set; }

    /// <summary>
    /// Current ammo in magazine.
    /// </summary>
    public int? MagAmmo { get; set; }

    /// <summary>
    /// Maximum ammo capacity.
    /// </summary>
    public int? MaxAmmo { get; set; }

    #endregion

    #region Weapon State

    /// <summary>
    /// Whether the weapon is cocked/ready to fire.
    /// </summary>
    public bool? IsCocked { get; set; }

    /// <summary>
    /// Whether the safety is engaged.
    /// </summary>
    public bool? SafetyOn { get; set; }

    /// <summary>
    /// Whether the slide is locked back.
    /// </summary>
    public bool? SlideLocked { get; set; }

    /// <summary>
    /// Current fire mode (0=semi, 1=auto, 2=burst, etc.).
    /// </summary>
    public byte? FireMode { get; set; }

    /// <summary>
    /// Two-hand stock state for rifles.
    /// </summary>
    public int? TwoHandStockState { get; set; }

    /// <summary>
    /// Launcher state (for launchers).
    /// </summary>
    public int? LauncherState { get; set; }

    #endregion

    #region Grenade State

    /// <summary>
    /// Grenade state (SafeWithPin, Safe, Cooking, Detonated).
    /// </summary>
    public int? GrenadeState { get; set; }

    /// <summary>
    /// Grenade type (Grenade, Smoke, Flash, Other).
    /// </summary>
    public int? GrenadeType { get; set; }

    /// <summary>
    /// Time spent cooking (pin pulled).
    /// </summary>
    public float? CookTime { get; set; }

    /// <summary>
    /// Fuse time remaining.
    /// </summary>
    public float? FuseTime { get; set; }

    #endregion

    #region Explosive State (C4/Door Bomb)

    /// <summary>
    /// Whether the explosive is armed.
    /// </summary>
    public bool? IsArmed { get; set; }

    /// <summary>
    /// Whether the explosive is planted.
    /// </summary>
    public bool? IsPlanted { get; set; }

    /// <summary>
    /// Timer value for explosives.
    /// </summary>
    public float? Timer { get; set; }

    #endregion

    #region Attachments

    /// <summary>
    /// Attached magazine reference.
    /// </summary>
    public uint? AttachedMagazine { get; set; }

    /// <summary>
    /// Attached sight/optic reference.
    /// </summary>
    public uint? AttachedSight { get; set; }

    /// <summary>
    /// Attached suppressor reference.
    /// </summary>
    public uint? AttachedSuppressor { get; set; }

    /// <summary>
    /// Attached laser reference.
    /// </summary>
    public uint? AttachedLaser { get; set; }

    /// <summary>
    /// Attached flashlight reference.
    /// </summary>
    public uint? AttachedFlashlight { get; set; }

    /// <summary>
    /// Attached grip reference.
    /// </summary>
    public uint? AttachedGrip { get; set; }

    #endregion

    #region Cosmetics

    /// <summary>
    /// Equipped skin ID.
    /// </summary>
    public int? SkinId { get; set; }

    /// <summary>
    /// Equipped charm ID.
    /// </summary>
    public int? CharmId { get; set; }

    #endregion

    #region Position and Ownership

    /// <summary>
    /// Current position in world.
    /// </summary>
    public FRepMovement? ReplicatedMovement { get; set; }

    /// <summary>
    /// Owner actor reference (usually a pawn).
    /// </summary>
    public uint? OwnerRef { get; set; }

    /// <summary>
    /// Instigator reference.
    /// </summary>
    public uint? InstigatorRef { get; set; }

    /// <summary>
    /// Whether the weapon is hidden.
    /// </summary>
    public bool? IsHidden { get; set; }

    /// <summary>
    /// Whether the weapon is torn off (dropped/detached).
    /// </summary>
    public bool? IsTornOff { get; set; }

    /// <summary>
    /// Attach parent actor reference.
    /// </summary>
    public uint? AttachParentRef { get; set; }

    /// <summary>
    /// Attach socket name.
    /// </summary>
    public string? AttachSocket { get; set; }

    #endregion
}
