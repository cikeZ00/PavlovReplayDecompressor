using Unreal.Core.Models;
using PavlovReplayReader.Models.Enums;

namespace PavlovReplayReader.Models;

/// <summary>
/// Represents vehicle data from the replay.
/// </summary>
public class VehicleData
{
    /// <summary>
    /// Channel index for this vehicle.
    /// </summary>
    public uint ChannelIndex { get; set; }

    /// <summary>
    /// Type of vehicle (e.g., "PavlovVehicle", "PavlovTank").
    /// </summary>
    public string? VehicleType { get; set; }

    /// <summary>
    /// Replay time when this data was last updated.
    /// </summary>
    public float LastUpdateTime { get; set; }

    #region Health

    /// <summary>
    /// Current health.
    /// </summary>
    public float? Health { get; set; }

    /// <summary>
    /// Maximum health.
    /// </summary>
    public float? MaxHealth { get; set; }

    /// <summary>
    /// Current damage state.
    /// </summary>
    public int? DamageState { get; set; }

    #endregion

    #region Movement

    /// <summary>
    /// Replicated movement data.
    /// </summary>
    public FRepMovement? ReplicatedMovement { get; set; }

    /// <summary>
    /// Current speed.
    /// </summary>
    public float? Speed { get; set; }

    /// <summary>
    /// Throttle input (-1 to 1).
    /// </summary>
    public float? Throttle { get; set; }

    /// <summary>
    /// Steering input (-1 to 1).
    /// </summary>
    public float? Steering { get; set; }

    /// <summary>
    /// Brake input (0 to 1).
    /// </summary>
    public float? Brake { get; set; }

    /// <summary>
    /// Whether the engine is running.
    /// </summary>
    public bool? EngineRunning { get; set; }

    #endregion

    #region Occupants

    /// <summary>
    /// Team ID this vehicle belongs to.
    /// </summary>
    public byte? TeamId { get; set; }

    /// <summary>
    /// Driver actor reference.
    /// </summary>
    public uint? DriverRef { get; set; }

    /// <summary>
    /// Passenger actor references.
    /// </summary>
    public uint[]? PassengerRefs { get; set; }

    /// <summary>
    /// Gunner actor reference (for tanks).
    /// </summary>
    public uint? GunnerRef { get; set; }

    /// <summary>
    /// Commander actor reference (for tanks).
    /// </summary>
    public uint? CommanderRef { get; set; }

    #endregion

    #region Tank-Specific

    /// <summary>
    /// Turret rotation (for tanks).
    /// </summary>
    public FRotator? TurretRotation { get; set; }

    /// <summary>
    /// Gun elevation angle (for tanks).
    /// </summary>
    public float? GunElevation { get; set; }

    /// <summary>
    /// Main gun ammo count.
    /// </summary>
    public int? MainGunAmmo { get; set; }

    /// <summary>
    /// Coaxial machine gun ammo count.
    /// </summary>
    public int? CoaxialAmmo { get; set; }

    /// <summary>
    /// Whether the main gun is loaded.
    /// </summary>
    public bool? MainGunLoaded { get; set; }

    /// <summary>
    /// Reload progress (0 to 1).
    /// </summary>
    public float? ReloadProgress { get; set; }

    #endregion

    #region State

    /// <summary>
    /// Whether the vehicle is hidden.
    /// </summary>
    public bool? IsHidden { get; set; }

    /// <summary>
    /// Owner actor reference.
    /// </summary>
    public uint? OwnerRef { get; set; }

    #endregion
}
