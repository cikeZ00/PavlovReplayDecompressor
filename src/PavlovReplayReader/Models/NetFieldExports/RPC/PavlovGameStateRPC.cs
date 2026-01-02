using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports.RPC;

#region RPC Function Structs

/// <summary>
/// RPC struct for DisplayMatchStateOverlay function.
/// Called to display a match state overlay UI element.
/// Path: /Script/Pavlov.PavlovGameState:DisplayMatchStateOverlay
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.PavlovGameState:DisplayMatchStateOverlay", minimalParseMode: ParseMode.Minimal)]
public class DisplayMatchStateOverlay : INetFieldExportGroup
{
    /// <summary>
    /// Class reference for the overlay to display (handle 0).
    /// </summary>
    [NetFieldExport("OverlayClass", RepLayoutCmdType.PropertyObject)]
    public uint? OverlayClass { get; set; }
}

/// <summary>
/// RPC struct for MulticastOnKillfeedEntry function.
/// Called when a kill occurs, providing killfeed data.
/// Path: /Script/Pavlov.PavlovGameState:MulticastOnKillfeedEntry
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.PavlovGameState:MulticastOnKillfeedEntry", minimalParseMode: ParseMode.Minimal)]
public class MulticastOnKillfeedEntry : INetFieldExportGroup
{
    /// <summary>
    /// Reference to the killer actor (handle 0).
    /// </summary>
    [NetFieldExport("Killer", RepLayoutCmdType.PropertyObject)]
    public uint? Killer { get; set; }

    /// <summary>
    /// Reference to the victim actor (handle 1).
    /// </summary>
    [NetFieldExport("Victim", RepLayoutCmdType.PropertyObject)]
    public uint? Victim { get; set; }

    /// <summary>
    /// Reference to the damage causer (weapon) (handle 2).
    /// </summary>
    [NetFieldExport("DamageCauser", RepLayoutCmdType.PropertyObject)]
    public uint? DamageCauser { get; set; }

    /// <summary>
    /// Whether the kill was a headshot (handle 3).
    /// </summary>
    [NetFieldExport("bHeadshot", RepLayoutCmdType.PropertyBool)]
    public bool? bHeadshot { get; set; }

    /// <summary>
    /// Name of the killer player (handle 4).
    /// </summary>
    [NetFieldExport("KillerName", RepLayoutCmdType.PropertyString)]
    public string? KillerName { get; set; }

    /// <summary>
    /// Team ID of the killer (handle 5).
    /// </summary>
    [NetFieldExport("KillerTeamId", RepLayoutCmdType.PropertyInt)]
    public int? KillerTeamId { get; set; }

    /// <summary>
    /// Unique ID of the killer (handle 6).
    /// </summary>
    [NetFieldExport("KillerId", RepLayoutCmdType.PropertyString)]
    public string? KillerId { get; set; }

    /// <summary>
    /// Name of the victim player (handle 7).
    /// </summary>
    [NetFieldExport("VictimName", RepLayoutCmdType.PropertyString)]
    public string? VictimName { get; set; }

    /// <summary>
    /// Team ID of the victim (handle 8).
    /// </summary>
    [NetFieldExport("VictimTeamId", RepLayoutCmdType.PropertyInt)]
    public int? VictimTeamId { get; set; }

    /// <summary>
    /// Unique ID of the victim (handle 9).
    /// </summary>
    [NetFieldExport("VictimId", RepLayoutCmdType.PropertyString)]
    public string? VictimId { get; set; }

    /// <summary>
    /// Lifespan of this killfeed entry in seconds (handle 10).
    /// </summary>
    [NetFieldExport("EntryLifespan", RepLayoutCmdType.PropertyFloat)]
    public float? EntryLifespan { get; set; }

    /// <summary>
    /// Whether the local player was involved (handle 11).
    /// </summary>
    [NetFieldExport("bLocalPlayer", RepLayoutCmdType.PropertyBool)]
    public bool? bLocalPlayer { get; set; }
}

#endregion

#region GameState ClassNetCache

/// <summary>
/// ClassNetCache for PavlovGameState.
/// Contains RPC function mappings for game state events.
/// Path: /Script/Pavlov.PavlovGameState_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("/Script/Pavlov.PavlovGameState_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class PavlovGameStateCache
{
    /// <summary>
    /// RPC for displaying match state overlay (handle 0).
    /// </summary>
    [NetFieldExportRPC("DisplayMatchStateOverlay", "/Script/Pavlov.PavlovGameState:DisplayMatchStateOverlay", isFunction: true)]
    public DisplayMatchStateOverlay? DisplayMatchStateOverlay { get; set; }

    /// <summary>
    /// RPC for killfeed entries (handle 1).
    /// </summary>
    [NetFieldExportRPC("MulticastOnKillfeedEntry", "/Script/Pavlov.PavlovGameState:MulticastOnKillfeedEntry", isFunction: true)]
    public MulticastOnKillfeedEntry? MulticastOnKillfeedEntry { get; set; }
}

#endregion
