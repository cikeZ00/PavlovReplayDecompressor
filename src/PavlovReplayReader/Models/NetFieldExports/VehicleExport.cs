using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

/// <summary>
/// NetFieldExportGroup for vehicles.
/// Contains vehicle state, health, and movement data.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.PavlovVehicle", minimalParseMode: ParseMode.Minimal)]
public class PavlovVehicleExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets whether the vehicle is hidden.
    /// </summary>
    [NetFieldExport("bHidden", RepLayoutCmdType.PropertyBool)]
    public bool? bHidden { get; set; }

    /// <summary>
    /// Gets or sets the remote role.
    /// </summary>
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public int? RemoteRole { get; set; }

    /// <summary>
    /// Gets or sets the role.
    /// </summary>
    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public int? Role { get; set; }

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

    /// <summary>
    /// Gets or sets the vehicle health.
    /// </summary>
    [NetFieldExport("Health", RepLayoutCmdType.PropertyFloat)]
    public float? Health { get; set; }

    /// <summary>
    /// Gets or sets the maximum health.
    /// </summary>
    [NetFieldExport("MaxHealth", RepLayoutCmdType.PropertyFloat)]
    public float? MaxHealth { get; set; }

    /// <summary>
    /// Gets or sets the vehicle damage state.
    /// </summary>
    [NetFieldExport("DamageState", RepLayoutCmdType.Enum)]
    public int? DamageState { get; set; }

    /// <summary>
    /// Gets or sets the team ID.
    /// </summary>
    [NetFieldExport("TeamId", RepLayoutCmdType.PropertyByte)]
    public byte? TeamId { get; set; }

    /// <summary>
    /// Gets or sets the driver reference.
    /// </summary>
    [NetFieldExport("Driver", RepLayoutCmdType.PropertyObject)]
    public uint? Driver { get; set; }

    /// <summary>
    /// Gets or sets the passengers.
    /// </summary>
    [NetFieldExport("Passengers", RepLayoutCmdType.DynamicArray)]
    public uint[]? Passengers { get; set; }

    /// <summary>
    /// Gets or sets the current speed.
    /// </summary>
    [NetFieldExport("Speed", RepLayoutCmdType.PropertyFloat)]
    public float? Speed { get; set; }

    /// <summary>
    /// Gets or sets the throttle input.
    /// </summary>
    [NetFieldExport("Throttle", RepLayoutCmdType.PropertyFloat)]
    public float? Throttle { get; set; }

    /// <summary>
    /// Gets or sets the steering input.
    /// </summary>
    [NetFieldExport("Steering", RepLayoutCmdType.PropertyFloat)]
    public float? Steering { get; set; }

    /// <summary>
    /// Gets or sets the brake input.
    /// </summary>
    [NetFieldExport("Brake", RepLayoutCmdType.PropertyFloat)]
    public float? Brake { get; set; }

    /// <summary>
    /// Gets or sets whether the engine is running.
    /// </summary>
    [NetFieldExport("bEngineRunning", RepLayoutCmdType.PropertyBool)]
    public bool? bEngineRunning { get; set; }
}

/// <summary>
/// NetFieldExportGroup for tanks.
/// Contains tank-specific state including turret and main gun.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.PavlovTank", minimalParseMode: ParseMode.Minimal)]
public class PavlovTankExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets whether the tank is hidden.
    /// </summary>
    [NetFieldExport("bHidden", RepLayoutCmdType.PropertyBool)]
    public bool? bHidden { get; set; }

    /// <summary>
    /// Gets or sets the remote role.
    /// </summary>
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public int? RemoteRole { get; set; }

    /// <summary>
    /// Gets or sets the role.
    /// </summary>
    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public int? Role { get; set; }

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

    /// <summary>
    /// Gets or sets the vehicle health.
    /// </summary>
    [NetFieldExport("Health", RepLayoutCmdType.PropertyFloat)]
    public float? Health { get; set; }

    /// <summary>
    /// Gets or sets the maximum health.
    /// </summary>
    [NetFieldExport("MaxHealth", RepLayoutCmdType.PropertyFloat)]
    public float? MaxHealth { get; set; }

    /// <summary>
    /// Gets or sets the tank damage state.
    /// </summary>
    [NetFieldExport("DamageState", RepLayoutCmdType.Enum)]
    public int? DamageState { get; set; }

    /// <summary>
    /// Gets or sets the team ID.
    /// </summary>
    [NetFieldExport("TeamId", RepLayoutCmdType.PropertyByte)]
    public byte? TeamId { get; set; }

    /// <summary>
    /// Gets or sets the turret rotation.
    /// </summary>
    [NetFieldExport("TurretRotation", RepLayoutCmdType.PropertyRotator)]
    public FRotator? TurretRotation { get; set; }

    /// <summary>
    /// Gets or sets the gun elevation.
    /// </summary>
    [NetFieldExport("GunElevation", RepLayoutCmdType.PropertyFloat)]
    public float? GunElevation { get; set; }

    /// <summary>
    /// Gets or sets the main gun ammo.
    /// </summary>
    [NetFieldExport("MainGunAmmo", RepLayoutCmdType.PropertyInt)]
    public int? MainGunAmmo { get; set; }

    /// <summary>
    /// Gets or sets the coaxial machine gun ammo.
    /// </summary>
    [NetFieldExport("CoaxialAmmo", RepLayoutCmdType.PropertyInt)]
    public int? CoaxialAmmo { get; set; }

    /// <summary>
    /// Gets or sets whether the main gun is loaded.
    /// </summary>
    [NetFieldExport("bMainGunLoaded", RepLayoutCmdType.PropertyBool)]
    public bool? bMainGunLoaded { get; set; }

    /// <summary>
    /// Gets or sets the reload progress.
    /// </summary>
    [NetFieldExport("ReloadProgress", RepLayoutCmdType.PropertyFloat)]
    public float? ReloadProgress { get; set; }

    /// <summary>
    /// Gets or sets the driver reference.
    /// </summary>
    [NetFieldExport("Driver", RepLayoutCmdType.PropertyObject)]
    public uint? Driver { get; set; }

    /// <summary>
    /// Gets or sets the gunner reference.
    /// </summary>
    [NetFieldExport("Gunner", RepLayoutCmdType.PropertyObject)]
    public uint? Gunner { get; set; }

    /// <summary>
    /// Gets or sets the commander reference.
    /// </summary>
    [NetFieldExport("Commander", RepLayoutCmdType.PropertyObject)]
    public uint? Commander { get; set; }
}
