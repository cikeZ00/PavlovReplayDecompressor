using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports.RPC;

#region Player State ClassNetCache

/// <summary>
/// ClassNetCache for PavlovPlayerState.
/// Contains RPC function mappings for player state events.
/// Path: /Script/Pavlov.PavlovPlayerState_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("/Script/Pavlov.PavlovPlayerState_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class PavlovPlayerStateCache
{
    /// <summary>
    /// RPC for clearing PavTV items (handle 0).
    /// </summary>
    [NetFieldExportRPC("ClearPavTVItems", "/Script/Pavlov.PavlovPlayerState:ClearPavTVItems", isFunction: true)]
    public object? ClearPavTVItems { get; set; }
}

#endregion
