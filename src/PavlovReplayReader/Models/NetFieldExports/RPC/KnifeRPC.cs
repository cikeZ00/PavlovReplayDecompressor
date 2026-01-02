using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports.RPC;

#region RPC Function Structs

/// <summary>
/// RPC struct for SetLatestInstigator function.
/// Called to set the instigator on a knife (for kill attribution).
/// Path: /Game/Guns/Knife/Knife_Bayonet.Knife_Bayonet_C:SetLatestInstigator
/// </summary>
[NetFieldExportGroup("/Game/Guns/Knife/Knife_Bayonet.Knife_Bayonet_C:SetLatestInstigator", minimalParseMode: ParseMode.Minimal)]
public class SetLatestInstigator : INetFieldExportGroup
{
    /// <summary>
    /// Reference to the controller that threw/used the knife (handle 0).
    /// </summary>
    [NetFieldExport("ItemController", RepLayoutCmdType.PropertyObject)]
    public uint? ItemController { get; set; }
}

/// <summary>
/// RPC struct for MulticastOnStab function.
/// Called when a knife stabs an entity.
/// Path: /Script/Pavlov.Knife:MulticastOnStab
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.Knife:MulticastOnStab", minimalParseMode: ParseMode.Minimal)]
public class MulticastOnStab : INetFieldExportGroup
{
    /// <summary>
    /// Whether the stab killed the target (handle 0).
    /// </summary>
    [NetFieldExport("bDead", RepLayoutCmdType.PropertyBool)]
    public bool? bDead { get; set; }
}

/// <summary>
/// RPC struct for SetKnifeBloody function.
/// Called to set the knife's bloody state after a kill.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.Knife:SetKnifeBloody", minimalParseMode: ParseMode.Minimal)]
public class SetKnifeBloody : INetFieldExportGroup
{
    // Blood state - may have bool or no parameters
}

/// <summary>
/// RPC struct for StartThrowSound_Multi function.
/// Called when a knife throw starts.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.Knife:StartThrowSound_Multi", minimalParseMode: ParseMode.Minimal)]
public class StartThrowSound : INetFieldExportGroup
{
    // Sound event - typically no parameters
}

#endregion

#region Knife ClassNetCache

/// <summary>
/// ClassNetCache for Knife_Bayonet.
/// Path: /Game/Guns/Knife/Knife_Bayonet.Knife_Bayonet_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("/Game/Guns/Knife/Knife_Bayonet.Knife_Bayonet_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class KnifeBayonetCache
{
    /// <summary>
    /// RPC for setting knife instigator (handle 2).
    /// </summary>
    [NetFieldExportRPC("SetLatestInstigator", "/Game/Guns/Knife/Knife_Bayonet.Knife_Bayonet_C:SetLatestInstigator", isFunction: true)]
    public SetLatestInstigator? SetLatestInstigator { get; set; }

    /// <summary>
    /// RPC for stab event (handle 3).
    /// </summary>
    [NetFieldExportRPC("MulticastOnStab", "/Script/Pavlov.Knife:MulticastOnStab", isFunction: true)]
    public MulticastOnStab? MulticastOnStab { get; set; }

    /// <summary>
    /// RPC for throw sound start (handle 4).
    /// </summary>
    [NetFieldExportRPC("StartThrowSound_Multi", "/Script/Pavlov.Knife:StartThrowSound_Multi", isFunction: true)]
    public StartThrowSound? StartThrowSound_Multi { get; set; }

    /// <summary>
    /// RPC for state sanity check (handle 5).
    /// </summary>
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/Pavlov.Knife:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for KnifeSkin_96_knife.
/// Path: /Game/Skins/Knife/KnifeSkin_96_knife.KnifeSkin_96_knife_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("/Game/Skins/Knife/KnifeSkin_96_knife.KnifeSkin_96_knife_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class KnifeSkin96Cache
{
    /// <summary>
    /// RPC for setting knife bloody state (handle 0).
    /// </summary>
    [NetFieldExportRPC("SetKnifeBloody", "/Script/Pavlov.Knife:SetKnifeBloody", isFunction: true)]
    public SetKnifeBloody? SetKnifeBloody { get; set; }
}

#endregion
