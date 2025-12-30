using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

/// <summary>
/// NetFieldExportGroup for the Vankrupt Health Component.
/// Contains player health information.
/// </summary>
[NetFieldExportGroup("/Script/Vankrupt.VHealthComponent", minimalParseMode: ParseMode.Minimal)]
public class VHealthComponentExport : INetFieldExportGroup
{
    /// <summary>
    /// Gets or sets the component's active state.
    /// </summary>
    [NetFieldExport("bIsActive", RepLayoutCmdType.PropertyBool)]
    public bool? bIsActive { get; set; }

    /// <summary>
    /// Gets or sets whether the component replicates.
    /// </summary>
    [NetFieldExport("bReplicates", RepLayoutCmdType.PropertyBool)]
    public bool? bReplicates { get; set; }

    /// <summary>
    /// Gets or sets the owner reference.
    /// </summary>
    [NetFieldExport("Owner", RepLayoutCmdType.PropertyObject)]
    public uint? Owner { get; set; }

    /// <summary>
    /// Gets or sets the current health value.
    /// </summary>
    [NetFieldExport("Health", RepLayoutCmdType.PropertyFloat)]
    public float? Health { get; set; }

    /// <summary>
    /// Gets or sets the maximum health value.
    /// </summary>
    [NetFieldExport("MaxHealth", RepLayoutCmdType.PropertyFloat)]
    public float? MaxHealth { get; set; }

    /// <summary>
    /// Gets or sets the relative location of the component.
    /// </summary>
    [NetFieldExport("RelativeLocation", RepLayoutCmdType.PropertyVector100)]
    public Unreal.Core.Models.FVector? RelativeLocation { get; set; }

    /// <summary>
    /// Gets or sets the relative rotation of the component.
    /// </summary>
    [NetFieldExport("RelativeRotation", RepLayoutCmdType.PropertyRotator)]
    public Unreal.Core.Models.FRotator? RelativeRotation { get; set; }

    /// <summary>
    /// Gets or sets the relative scale of the component.
    /// </summary>
    [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVector)]
    public Unreal.Core.Models.FVector? RelativeScale3D { get; set; }

    /// <summary>
    /// Gets or sets whether the entity is dead (handle 3).
    /// </summary>
    [NetFieldExport("bDead", RepLayoutCmdType.PropertyBool)]
    public bool? bDead { get; set; }
}
