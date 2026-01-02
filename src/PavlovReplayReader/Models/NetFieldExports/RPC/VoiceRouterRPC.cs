using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports.RPC;

#region RPC Function Structs

/// <summary>
/// RPC struct for ReplayOnVoiceBunch_Client function.
/// Contains voice data packets for replay playback.
/// Path: /Script/Pavlov.VoiceRouter:ReplayOnVoiceBunch_Client
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.VoiceRouter:ReplayOnVoiceBunch_Client", minimalParseMode: ParseMode.Minimal)]
public class ReplayOnVoiceBunch : INetFieldExportGroup
{
    /// <summary>
    /// First player reference (handle 0).
    /// </summary>
    [NetFieldExportHandle(0, RepLayoutCmdType.PropertyObject)]
    public uint? Player1 { get; set; }

    /// <summary>
    /// Second player reference (handle 1).
    /// </summary>
    [NetFieldExportHandle(1, RepLayoutCmdType.PropertyObject)]
    public uint? Player2 { get; set; }

    /// <summary>
    /// First voice packet data (handle 3).
    /// </summary>
    [NetFieldExportHandle(3, RepLayoutCmdType.Ignore)]
    public object? Packet1 { get; set; }

    /// <summary>
    /// Second voice packet data (handle 4).
    /// </summary>
    [NetFieldExportHandle(4, RepLayoutCmdType.Ignore)]
    public object? Packet2 { get; set; }
}

#endregion

#region VoiceRouter ClassNetCache

/// <summary>
/// ClassNetCache for VoiceRouter.
/// Contains RPC function mappings for voice communication events.
/// Path: /Script/Pavlov.VoiceRouter_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("/Script/Pavlov.VoiceRouter_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class VoiceRouterCache
{
    /// <summary>
    /// RPC for voice data during replay (handle 1).
    /// </summary>
    [NetFieldExportRPC("ReplayOnVoiceBunch_Client", "/Script/Pavlov.VoiceRouter:ReplayOnVoiceBunch_Client", isFunction: true)]
    public ReplayOnVoiceBunch? ReplayOnVoiceBunch_Client { get; set; }
}

#endregion
