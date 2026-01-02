using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports.RPC;

#region RPC Function Structs

/// <summary>
/// RPC struct for MulticastOnRoundStateChanged function.
/// Called when the round state changes (starting/ending).
/// Path: /Script/PavlovProxy.Pavlov_GameLogic:MulticastOnRoundStateChanged
/// </summary>
[NetFieldExportGroup("/Script/PavlovProxy.Pavlov_GameLogic:MulticastOnRoundStateChanged", minimalParseMode: ParseMode.Minimal)]
public class MulticastOnRoundStateChanged : INetFieldExportGroup
{
    /// <summary>
    /// Whether the round is starting (true) or ending (false) (handle 0).
    /// </summary>
    [NetFieldExport("bStarting", RepLayoutCmdType.PropertyBool)]
    public bool? bStarting { get; set; }
}

#endregion

#region GameLogic ClassNetCache

/// <summary>
/// ClassNetCache for Pavlov_GameLogic.
/// Contains RPC function mappings for game logic events.
/// Path: /Script/PavlovProxy.Pavlov_GameLogic_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("/Script/PavlovProxy.Pavlov_GameLogic_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class PavlovGameLogicCache
{
    /// <summary>
    /// RPC for round state changes (handle 0).
    /// </summary>
    [NetFieldExportRPC("MulticastOnRoundStateChanged", "/Script/PavlovProxy.Pavlov_GameLogic:MulticastOnRoundStateChanged", isFunction: true)]
    public MulticastOnRoundStateChanged? MulticastOnRoundStateChanged { get; set; }
}

#endregion
