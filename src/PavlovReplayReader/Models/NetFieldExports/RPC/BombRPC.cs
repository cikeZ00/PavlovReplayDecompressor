using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports.RPC;

#region RPC Function Structs

/// <summary>
/// RPC struct for MulticastOnPlantStateChanged function.
/// Called when a bomb plant spot state changes.
/// Path: /Script/Pavlov.BombPlantSpot:MulticastOnPlantStateChanged
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.BombPlantSpot:MulticastOnPlantStateChanged", minimalParseMode: ParseMode.Minimal)]
public class MulticastOnPlantStateChanged : INetFieldExportGroup
{
    /// <summary>
    /// Whether the bomb is planted (handle 0).
    /// </summary>
    [NetFieldExport("bPlanted", RepLayoutCmdType.PropertyBool)]
    public bool? bPlanted { get; set; }
}

/// <summary>
/// RPC struct for MulticastOnEnterCode function.
/// Called when a bomb defuse code is entered.
/// Path: /Script/Pavlov.Bomb:MulticastOnEnterCode
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.Bomb:MulticastOnEnterCode", minimalParseMode: ParseMode.Minimal)]
public class MulticastOnEnterCode : INetFieldExportGroup
{
    /// <summary>
    /// Whether the code entry succeeded (handle 0).
    /// </summary>
    [NetFieldExport("bSucceed", RepLayoutCmdType.PropertyBool)]
    public bool? bSucceed { get; set; }
}

/// <summary>
/// RPC struct for bomb beep event.
/// Called when the bomb emits a beep sound.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.Bomb:MulticastOnBeep", minimalParseMode: ParseMode.Minimal)]
public class MulticastOnBeep : INetFieldExportGroup
{
    // Typically no parameters - just a sound event
}

/// <summary>
/// RPC struct for bomb defuse event.
/// Called when the bomb is defused.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.Bomb:MulticastOnDefuse", minimalParseMode: ParseMode.Minimal)]
public class MulticastOnDefuse : INetFieldExportGroup
{
    // Defuse event may have minimal parameters
}

/// <summary>
/// RPC struct for bomb detonation event.
/// Called when the bomb explodes.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.Bomb:MulticastOnDetonation", minimalParseMode: ParseMode.Minimal)]
public class MulticastOnDetonation : INetFieldExportGroup
{
    // Detonation event may have minimal parameters
}

/// <summary>
/// RPC struct for bomb grace period event.
/// Called during the grace period before detonation.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.Bomb:MulticastOnGrace", minimalParseMode: ParseMode.Minimal)]
public class MulticastOnGrace : INetFieldExportGroup
{
    // Grace event may have minimal parameters
}

/// <summary>
/// RPC struct for pliers cut event.
/// Called when pliers cut a wire.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.Pliers:MulticastOnCut", minimalParseMode: ParseMode.Minimal)]
public class MulticastOnCut : INetFieldExportGroup
{
    // Cut event may include wire index or success status
}

#endregion

#region Bomb ClassNetCache

/// <summary>
/// ClassNetCache for BombPlantSpot_Basic.
/// Contains RPC function mappings for bomb plant spot events.
/// Path: /Game/Gameplay/SearchAndDestroy/Bomb/BombPlantSpot_Basic.BombPlantSpot_Basic_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("BombPlantSpot_Basic_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class BombPlantSpotCache
{
    /// <summary>
    /// RPC for plant state changes (handle 0).
    /// </summary>
    [NetFieldExportRPC("MulticastOnPlantStateChanged", "/Script/Pavlov.BombPlantSpot:MulticastOnPlantStateChanged", isFunction: true)]
    public MulticastOnPlantStateChanged? MulticastOnPlantStateChanged { get; set; }

    /// <summary>
    /// RPC for state sanity check (handle 1).
    /// </summary>
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/Pavlov.BombPlantSpot:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Bomb_Basic.
/// Contains RPC function mappings for bomb events.
/// Path: /Game/Gameplay/SearchAndDestroy/Bomb/Bomb_Basic.Bomb_Basic_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Bomb_Basic_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class BombCache
{
    /// <summary>
    /// RPC for bomb beep sound (handle 0).
    /// </summary>
    [NetFieldExportRPC("MulticastOnBeep", "/Script/Pavlov.Bomb:MulticastOnBeep", isFunction: true)]
    public MulticastOnBeep? MulticastOnBeep { get; set; }

    /// <summary>
    /// RPC for bomb defuse (handle 2).
    /// </summary>
    [NetFieldExportRPC("MulticastOnDefuse", "/Script/Pavlov.Bomb:MulticastOnDefuse", isFunction: true)]
    public MulticastOnDefuse? MulticastOnDefuse { get; set; }

    /// <summary>
    /// RPC for bomb detonation (handle 3).
    /// </summary>
    [NetFieldExportRPC("MulticastOnDetonation", "/Script/Pavlov.Bomb:MulticastOnDetonation", isFunction: true)]
    public MulticastOnDetonation? MulticastOnDetonation { get; set; }

    /// <summary>
    /// RPC for code entry (handle 4).
    /// </summary>
    [NetFieldExportRPC("MulticastOnEnterCode", "/Script/Pavlov.Bomb:MulticastOnEnterCode", isFunction: true)]
    public MulticastOnEnterCode? MulticastOnEnterCode { get; set; }

    /// <summary>
    /// RPC for grace period (handle 5).
    /// </summary>
    [NetFieldExportRPC("MulticastOnGrace", "/Script/Pavlov.Bomb:MulticastOnGrace", isFunction: true)]
    public MulticastOnGrace? MulticastOnGrace { get; set; }

    /// <summary>
    /// RPC for state sanity check (handle 7).
    /// </summary>
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/Pavlov.Bomb:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Pliers_Basic.
/// Contains RPC function mappings for pliers events.
/// Path: /Game/Gameplay/SearchAndDestroy/Pliers/Pliers_Basic.Pliers_Basic_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Pliers_Basic_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class PliersCache
{
    /// <summary>
    /// RPC for wire cut event (handle 0).
    /// </summary>
    [NetFieldExportRPC("MulticastOnCut", "/Script/Pavlov.Pliers:MulticastOnCut", isFunction: true)]
    public MulticastOnCut? MulticastOnCut { get; set; }

    /// <summary>
    /// RPC for state sanity check (handle 2).
    /// </summary>
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/Pavlov.Pliers:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

#endregion
