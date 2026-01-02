using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports.RPC;

#region RPC Function Structs

/// <summary>
/// RPC struct for MulticastOnKilledWithData function.
/// Called when an entity is killed, providing death details.
/// Path: /Script/Vankrupt.VHealthComponent:MulticastOnKilledWithData
/// </summary>
[NetFieldExportGroup("/Script/Vankrupt.VHealthComponent:MulticastOnKilledWithData", minimalParseMode: ParseMode.Minimal)]
public class MulticastOnKilledWithData : INetFieldExportGroup
{
    /// <summary>
    /// Location of the death (handle 0).
    /// </summary>
    [NetFieldExport("Location", RepLayoutCmdType.PropertyVector)]
    public FVector? Location { get; set; }

    /// <summary>
    /// Impulse direction/force applied (handle 1).
    /// </summary>
    [NetFieldExport("Impulse", RepLayoutCmdType.PropertyVector)]
    public FVector? Impulse { get; set; }

    /// <summary>
    /// Name of the bone that was hit (handle 2).
    /// </summary>
    [NetFieldExport("BoneName", RepLayoutCmdType.PropertyName)]
    public string? BoneName { get; set; }

    /// <summary>
    /// Reference to the component (handle 3).
    /// </summary>
    [NetFieldExport("Component", RepLayoutCmdType.PropertyObject)]
    public uint? Component { get; set; }
}

#endregion

#region Health ClassNetCache

/// <summary>
/// ClassNetCache for VHealthComponent.
/// Contains RPC function mappings for health component events.
/// Path: /Script/Vankrupt.VHealthComponent_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("/Script/Vankrupt.VHealthComponent_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class VHealthComponentCache
{
    /// <summary>
    /// RPC for generic killed event (handle 1).
    /// </summary>
    [NetFieldExportRPC("MulticastOnKilled", "/Script/Vankrupt.VHealthComponent:MulticastOnKilled", isFunction: true)]
    public object? MulticastOnKilled { get; set; }

    /// <summary>
    /// RPC for killed event with detailed data (handle 2).
    /// </summary>
    [NetFieldExportRPC("MulticastOnKilledWithData", "/Script/Vankrupt.VHealthComponent:MulticastOnKilledWithData", isFunction: true)]
    public MulticastOnKilledWithData? MulticastOnKilledWithData { get; set; }
}

#endregion
