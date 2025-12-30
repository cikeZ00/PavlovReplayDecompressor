using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;
using PavlovReplayReader.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

/// <summary>
/// NetFieldExportGroup for King of the Hill point.
/// Contains hill capture state for KOTH game mode.
/// </summary>
[NetFieldExportGroup("/Game/Gameplay/KOTH/BP_KOTHCapturePoint.BP_KOTHCapturePoint_C", minimalParseMode: ParseMode.Minimal)]
public class KOTHCapturePointExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets whether the capture point is hidden.
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
    /// Gets or sets the hill state.
    /// </summary>
    [NetFieldExport("HillState", RepLayoutCmdType.Enum)]
    public int? HillState { get; set; }

    /// <summary>
    /// Gets or sets the capture progress (0-1).
    /// </summary>
    [NetFieldExport("CaptureProgress", RepLayoutCmdType.PropertyFloat)]
    public float? CaptureProgress { get; set; }

    /// <summary>
    /// Gets or sets the owning team ID.
    /// </summary>
    [NetFieldExport("OwningTeam", RepLayoutCmdType.PropertyByte)]
    public byte? OwningTeam { get; set; }

    /// <summary>
    /// Gets or sets whether the point is being contested.
    /// </summary>
    [NetFieldExport("bContested", RepLayoutCmdType.PropertyBool)]
    public bool? bContested { get; set; }

    /// <summary>
    /// Gets or sets whether the point is active.
    /// </summary>
    [NetFieldExport("bActive", RepLayoutCmdType.PropertyBool)]
    public bool? bActive { get; set; }

    /// <summary>
    /// Gets or sets the replicated movement.
    /// </summary>
    [NetFieldExport("ReplicatedMovement", RepLayoutCmdType.RepMovement)]
    public FRepMovement? ReplicatedMovement { get; set; }
}

/// <summary>
/// NetFieldExportGroup for Push mode capture point.
/// Contains push objective state.
/// </summary>
[NetFieldExportGroup("/Game/Gameplay/Push/BP_PushCapturePoint.BP_PushCapturePoint_C", minimalParseMode: ParseMode.Minimal)]
public class PushCapturePointExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets whether the capture point is hidden.
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
    /// Gets or sets the capture progress.
    /// </summary>
    [NetFieldExport("CaptureProgress", RepLayoutCmdType.PropertyFloat)]
    public float? CaptureProgress { get; set; }

    /// <summary>
    /// Gets or sets the owning team ID.
    /// </summary>
    [NetFieldExport("OwningTeam", RepLayoutCmdType.PropertyByte)]
    public byte? OwningTeam { get; set; }

    /// <summary>
    /// Gets or sets whether the point is being contested.
    /// </summary>
    [NetFieldExport("bContested", RepLayoutCmdType.PropertyBool)]
    public bool? bContested { get; set; }

    /// <summary>
    /// Gets or sets whether this is the active objective.
    /// </summary>
    [NetFieldExport("bIsCurrentObjective", RepLayoutCmdType.PropertyBool)]
    public bool? bIsCurrentObjective { get; set; }

    /// <summary>
    /// Gets or sets the objective index in the sequence.
    /// </summary>
    [NetFieldExport("ObjectiveIndex", RepLayoutCmdType.PropertyInt)]
    public int? ObjectiveIndex { get; set; }

    /// <summary>
    /// Gets or sets the replicated movement.
    /// </summary>
    [NetFieldExport("ReplicatedMovement", RepLayoutCmdType.RepMovement)]
    public FRepMovement? ReplicatedMovement { get; set; }
}

/// <summary>
/// NetFieldExportGroup for Capture The Flag flag.
/// Contains flag state and carrier information.
/// </summary>
[NetFieldExportGroup("/Game/Gameplay/CTF/BP_Flag.BP_Flag_C", minimalParseMode: ParseMode.Minimal)]
public class CTFFlagExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets whether the flag is hidden.
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
    /// Gets or sets the replicated movement.
    /// </summary>
    [NetFieldExport("ReplicatedMovement", RepLayoutCmdType.RepMovement)]
    public FRepMovement? ReplicatedMovement { get; set; }

    /// <summary>
    /// Gets or sets the team ID this flag belongs to.
    /// </summary>
    [NetFieldExport("TeamId", RepLayoutCmdType.PropertyByte)]
    public byte? TeamId { get; set; }

    /// <summary>
    /// Gets or sets the current flag carrier.
    /// </summary>
    [NetFieldExport("Carrier", RepLayoutCmdType.PropertyObject)]
    public uint? Carrier { get; set; }

    /// <summary>
    /// Gets or sets whether the flag is at home base.
    /// </summary>
    [NetFieldExport("bAtHome", RepLayoutCmdType.PropertyBool)]
    public bool? bAtHome { get; set; }

    /// <summary>
    /// Gets or sets whether the flag is being carried.
    /// </summary>
    [NetFieldExport("bCarried", RepLayoutCmdType.PropertyBool)]
    public bool? bCarried { get; set; }

    /// <summary>
    /// Gets or sets whether the flag is dropped.
    /// </summary>
    [NetFieldExport("bDropped", RepLayoutCmdType.PropertyBool)]
    public bool? bDropped { get; set; }

    /// <summary>
    /// Gets or sets the time until auto-return.
    /// </summary>
    [NetFieldExport("ReturnTimer", RepLayoutCmdType.PropertyFloat)]
    public float? ReturnTimer { get; set; }

    /// <summary>
    /// Gets or sets the attach parent.
    /// </summary>
    [NetFieldExport("AttachParent", RepLayoutCmdType.PropertyObject)]
    public uint? AttachParent { get; set; }

    /// <summary>
    /// Gets or sets the attach socket.
    /// </summary>
    [NetFieldExport("AttachSocket", RepLayoutCmdType.PropertyName)]
    public string? AttachSocket { get; set; }

    /// <summary>
    /// Gets or sets the attach component.
    /// </summary>
    [NetFieldExport("AttachComponent", RepLayoutCmdType.PropertyObject)]
    public uint? AttachComponent { get; set; }

    /// <summary>
    /// Gets or sets the location offset.
    /// </summary>
    [NetFieldExport("LocationOffset", RepLayoutCmdType.PropertyVector100)]
    public FVector? LocationOffset { get; set; }

    /// <summary>
    /// Gets or sets the relative scale for attachment.
    /// </summary>
    [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVector100)]
    public FVector? RelativeScale3D { get; set; }

    /// <summary>
    /// Gets or sets the rotation offset.
    /// </summary>
    [NetFieldExport("RotationOffset", RepLayoutCmdType.PropertyRotator)]
    public FRotator? RotationOffset { get; set; }
}
