using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

/// <summary>
/// NetFieldExportGroup for Voice Router.
/// Handles voice communication routing between players.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.VoiceRouter", minimalParseMode: ParseMode.Minimal)]
public class VoiceRouterExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets whether the voice router is active.
    /// </summary>
    [NetFieldExport("bIsActive", RepLayoutCmdType.PropertyBool)]
    public bool? bIsActive { get; set; }

    /// <summary>
    /// Gets or sets the owner reference.
    /// </summary>
    [NetFieldExport("Owner", RepLayoutCmdType.PropertyObject)]
    public uint? Owner { get; set; }

    /// <summary>
    /// Gets or sets whether the component replicates.
    /// </summary>
    [NetFieldExport("bReplicates", RepLayoutCmdType.PropertyBool)]
    public bool? bReplicates { get; set; }

    /// <summary>
    /// Gets or sets the relative location.
    /// </summary>
    [NetFieldExport("RelativeLocation", RepLayoutCmdType.PropertyVector100)]
    public FVector? RelativeLocation { get; set; }

    /// <summary>
    /// Gets or sets the relative rotation.
    /// </summary>
    [NetFieldExport("RelativeRotation", RepLayoutCmdType.PropertyRotator)]
    public FRotator? RelativeRotation { get; set; }
}

/// <summary>
/// NetFieldExportGroup for radio voice communication component.
/// Handles team radio communication.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.RadioVoiceCommunicationComponent", minimalParseMode: ParseMode.Minimal)]
public class RadioVoiceCommunicationExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets whether the radio is active.
    /// </summary>
    [NetFieldExport("bIsActive", RepLayoutCmdType.PropertyBool)]
    public bool? bIsActive { get; set; }

    /// <summary>
    /// Gets or sets the owner reference.
    /// </summary>
    [NetFieldExport("Owner", RepLayoutCmdType.PropertyObject)]
    public uint? Owner { get; set; }

    /// <summary>
    /// Gets or sets whether the component replicates.
    /// </summary>
    [NetFieldExport("bReplicates", RepLayoutCmdType.PropertyBool)]
    public bool? bReplicates { get; set; }

    /// <summary>
    /// Gets or sets the current channel.
    /// </summary>
    [NetFieldExport("Channel", RepLayoutCmdType.PropertyInt)]
    public int? Channel { get; set; }

    /// <summary>
    /// Gets or sets whether push to talk is active.
    /// </summary>
    [NetFieldExport("bPushToTalk", RepLayoutCmdType.PropertyBool)]
    public bool? bPushToTalk { get; set; }
}
