using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports.RPC;

#region RPC Function Structs

/// <summary>
/// RPC struct for grenade detonation event.
/// Called when a grenade detonates.
/// </summary>
[NetFieldExportGroup("/Script/VRFramework.VRGrenade:MulticastOnDetonation", minimalParseMode: ParseMode.Minimal)]
public class GrenadeMulticastOnDetonation : INetFieldExportGroup
{
    // Detonation location may be passed, or it uses actor location
}

/// <summary>
/// RPC struct for safety lever release event.
/// Called when a grenade's safety lever is released.
/// </summary>
[NetFieldExportGroup("/Script/VRFramework.VRGrenade:MulticastOnReleaseSafetyLever", minimalParseMode: ParseMode.Minimal)]
public class MulticastOnReleaseSafetyLever : INetFieldExportGroup
{
    // Event notification - no parameters
}

/// <summary>
/// RPC struct for safety pin removal event.
/// Called when a grenade's safety pin is removed.
/// </summary>
[NetFieldExportGroup("/Script/VRFramework.VRGrenade:MulticastOnSafetyPinRemoved", minimalParseMode: ParseMode.Minimal)]
public class MulticastOnSafetyPinRemoved : INetFieldExportGroup
{
    // Event notification - no parameters
}

#endregion

#region Flash Grenade ClassNetCache

/// <summary>
/// ClassNetCache for Grenade_Flash.
/// Path: /Game/Guns/Grenades/Flash/Grenade_Flash.Grenade_Flash_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("/Game/Guns/Grenades/Flash/Grenade_Flash.Grenade_Flash_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class GrenadeFlashCache
{
    /// <summary>
    /// RPC for detonation event (handle 1).
    /// </summary>
    [NetFieldExportRPC("MulticastOnDetonation", "/Script/VRFramework.VRGrenade:MulticastOnDetonation", isFunction: true)]
    public GrenadeMulticastOnDetonation? MulticastOnDetonation { get; set; }

    /// <summary>
    /// RPC for safety lever release (handle 2).
    /// </summary>
    [NetFieldExportRPC("MulticastOnReleaseSafetyLever", "/Script/VRFramework.VRGrenade:MulticastOnReleaseSafetyLever", isFunction: true)]
    public MulticastOnReleaseSafetyLever? MulticastOnReleaseSafetyLever { get; set; }

    /// <summary>
    /// RPC for safety pin removal (handle 3).
    /// </summary>
    [NetFieldExportRPC("MulticastOnSafetyPinRemoved", "/Script/VRFramework.VRGrenade:MulticastOnSafetyPinRemoved", isFunction: true)]
    public MulticastOnSafetyPinRemoved? MulticastOnSafetyPinRemoved { get; set; }

    /// <summary>
    /// RPC for state sanity check (handle 8).
    /// </summary>
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRGrenade:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Grenade_Flash_RU (Russian flash grenade).
/// Path: /Game/Guns/Grenades/Flash/Grenade_Flash_RU.Grenade_Flash_RU_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("/Game/Guns/Grenades/Flash/Grenade_Flash_RU.Grenade_Flash_RU_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class GrenadeFlashRUCache
{
    [NetFieldExportRPC("MulticastOnDetonation", "/Script/VRFramework.VRGrenade:MulticastOnDetonation", isFunction: true)]
    public GrenadeMulticastOnDetonation? MulticastOnDetonation { get; set; }

    [NetFieldExportRPC("MulticastOnReleaseSafetyLever", "/Script/VRFramework.VRGrenade:MulticastOnReleaseSafetyLever", isFunction: true)]
    public MulticastOnReleaseSafetyLever? MulticastOnReleaseSafetyLever { get; set; }

    [NetFieldExportRPC("MulticastOnSafetyPinRemoved", "/Script/VRFramework.VRGrenade:MulticastOnSafetyPinRemoved", isFunction: true)]
    public MulticastOnSafetyPinRemoved? MulticastOnSafetyPinRemoved { get; set; }

    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRGrenade:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

#endregion

#region Frag Grenade ClassNetCache

/// <summary>
/// ClassNetCache for Grenade_M64.
/// Path: /Game/Guns/Grenades/M64/Grenade_M64.Grenade_M64_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("/Game/Guns/Grenades/M64/Grenade_M64.Grenade_M64_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class GrenadeM64Cache
{
    [NetFieldExportRPC("MulticastOnDetonation", "/Script/VRFramework.VRGrenade:MulticastOnDetonation", isFunction: true)]
    public GrenadeMulticastOnDetonation? MulticastOnDetonation { get; set; }

    [NetFieldExportRPC("MulticastOnReleaseSafetyLever", "/Script/VRFramework.VRGrenade:MulticastOnReleaseSafetyLever", isFunction: true)]
    public MulticastOnReleaseSafetyLever? MulticastOnReleaseSafetyLever { get; set; }

    [NetFieldExportRPC("MulticastOnSafetyPinRemoved", "/Script/VRFramework.VRGrenade:MulticastOnSafetyPinRemoved", isFunction: true)]
    public MulticastOnSafetyPinRemoved? MulticastOnSafetyPinRemoved { get; set; }

    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRGrenade:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Grenade_M64_RU (Russian frag grenade).
/// Path: /Game/Guns/Grenades/M64/Grenade_M64_RU.Grenade_M64_RU_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("/Game/Guns/Grenades/M64/Grenade_M64_RU.Grenade_M64_RU_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class GrenadeM64RUCache
{
    [NetFieldExportRPC("MulticastOnDetonation", "/Script/VRFramework.VRGrenade:MulticastOnDetonation", isFunction: true)]
    public GrenadeMulticastOnDetonation? MulticastOnDetonation { get; set; }

    [NetFieldExportRPC("MulticastOnReleaseSafetyLever", "/Script/VRFramework.VRGrenade:MulticastOnReleaseSafetyLever", isFunction: true)]
    public MulticastOnReleaseSafetyLever? MulticastOnReleaseSafetyLever { get; set; }

    [NetFieldExportRPC("MulticastOnSafetyPinRemoved", "/Script/VRFramework.VRGrenade:MulticastOnSafetyPinRemoved", isFunction: true)]
    public MulticastOnSafetyPinRemoved? MulticastOnSafetyPinRemoved { get; set; }
}

#endregion

#region Smoke Grenade ClassNetCache

/// <summary>
/// ClassNetCache for Grenade_Smoke_RU (Russian smoke grenade).
/// Path: /Game/Guns/Grenades/Smoke/Grenade_Smoke_RU.Grenade_Smoke_RU_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("/Game/Guns/Grenades/Smoke/Grenade_Smoke_RU.Grenade_Smoke_RU_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class GrenadeSmokeRUCache
{
    [NetFieldExportRPC("MulticastOnDetonation", "/Script/VRFramework.VRGrenade:MulticastOnDetonation", isFunction: true)]
    public GrenadeMulticastOnDetonation? MulticastOnDetonation { get; set; }

    [NetFieldExportRPC("MulticastOnReleaseSafetyLever", "/Script/VRFramework.VRGrenade:MulticastOnReleaseSafetyLever", isFunction: true)]
    public MulticastOnReleaseSafetyLever? MulticastOnReleaseSafetyLever { get; set; }

    [NetFieldExportRPC("MulticastOnSafetyPinRemoved", "/Script/VRFramework.VRGrenade:MulticastOnSafetyPinRemoved", isFunction: true)]
    public MulticastOnSafetyPinRemoved? MulticastOnSafetyPinRemoved { get; set; }
}

#endregion
