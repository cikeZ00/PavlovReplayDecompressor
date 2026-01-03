using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports.RPC;

#region RPC Function Structs

/// <summary>
/// RPC struct for MulticastChangeState function.
/// Called when a VR item controller changes state.
/// Path: /Script/VRFramework.VRItemController:MulticastChangeState
/// </summary>
[NetFieldExportGroup("/Script/VRFramework.VRItemController:MulticastChangeState", minimalParseMode: ParseMode.Minimal)]
public class MulticastChangeState : INetFieldExportGroup
{
    /// <summary>
    /// New state of the controller (handle 0).
    /// </summary>
    [NetFieldExport("State", RepLayoutCmdType.PropertyByte)]
    public byte? State { get; set; }

    /// <summary>
    /// Rotation of the state change (handle 1).
    /// Complex FQuat serialization - using Ignore for now.
    /// </summary>
    [NetFieldExport("Rotation", RepLayoutCmdType.Ignore)]
    public object? Rotation { get; set; }

    /// <summary>
    /// Translation/location of the state change (handle 2).
    /// </summary>
    [NetFieldExport("Translation", RepLayoutCmdType.PropertyVector)]
    public FVector? Translation { get; set; }

    /// <summary>
    /// Scale of the state change (handle 3).
    /// </summary>
    [NetFieldExport("Scale3D", RepLayoutCmdType.PropertyVector)]
    public FVector? Scale3D { get; set; }

    /// <summary>
    /// Reference to the affected actor (handle 4).
    /// </summary>
    [NetFieldExport("Actor", RepLayoutCmdType.PropertyObject)]
    public uint? Actor { get; set; }

    /// <summary>
    /// Flag value for the state change (handle 5).
    /// </summary>
    [NetFieldExport("bFlag", RepLayoutCmdType.PropertyBool)]
    public bool? bFlag { get; set; }
}

/// <summary>
/// RPC struct for MulticastStateSanityCheck function.
/// Used for state synchronization validation.
/// </summary>
[NetFieldExportGroup("/Script/VRFramework.VRItemController:MulticastStateSanityCheck", minimalParseMode: ParseMode.Minimal)]
public class MulticastStateSanityCheck : INetFieldExportGroup
{
    // This function typically has no parameters or minimal state data
}

#endregion

#region Controller ClassNetCache

/// <summary>
/// ClassNetCache for BP_PavlovController.
/// Contains RPC function mappings for VR controller events.
/// Path: /Game/Gameplay/BP_PavlovController.BP_PavlovController_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("BP_PavlovController_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class PavlovControllerCache
{
    /// <summary>
    /// RPC for controller state changes (handle 2).
    /// </summary>
    [NetFieldExportRPC("MulticastChangeState", "/Script/VRFramework.VRItemController:MulticastChangeState", isFunction: true)]
    public MulticastChangeState? MulticastChangeState { get; set; }
}

/// <summary>
/// ClassNetCache for BP_PavlovGhostController (spectator controller).
/// Path: /Game/Gameplay/Misc/Spectator/BP_PavlovGhostController.BP_PavlovGhostController_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("BP_PavlovGhostController_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class PavlovGhostControllerCache
{
    /// <summary>
    /// RPC for controller state changes (handle 2).
    /// </summary>
    [NetFieldExportRPC("MulticastChangeState", "/Script/VRFramework.VRItemController:MulticastChangeState", isFunction: true)]
    public MulticastChangeState? MulticastChangeState { get; set; }
}

/// <summary>
/// ClassNetCache for VRInventoryLogic.
/// Path: /Script/VRFramework.VRInventoryLogic_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("VRInventoryLogic_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class VRInventoryLogicCache
{
    /// <summary>
    /// RPC for inventory state sanity check (handle 2).
    /// </summary>
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRInventoryLogic:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

#endregion
