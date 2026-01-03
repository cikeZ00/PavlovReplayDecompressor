using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports.RPC;

#region RPC Function Structs

/// <summary>
/// RPC struct for MulticastOnMagazineReleased function.
/// Called when a magazine is released from a weapon.
/// Path: /Script/VRFramework.VRGun:MulticastOnMagazineReleased
/// </summary>
[NetFieldExportGroup("/Script/VRFramework.VRGun:MulticastOnMagazineReleased", minimalParseMode: ParseMode.Minimal)]
public class MulticastOnMagazineReleased : INetFieldExportGroup
{
    /// <summary>
    /// Reference to the released magazine actor (handle 0).
    /// </summary>
    [NetFieldExport("ReleasedMagazine", RepLayoutCmdType.PropertyObject)]
    public uint? ReleasedMagazine { get; set; }
}

/// <summary>
/// RPC struct for MulticastFire function.
/// Called when a weapon is fired.
/// </summary>
[NetFieldExportGroup("/Script/VRFramework.VRGun:MulticastFire", minimalParseMode: ParseMode.Minimal)]
public class MulticastFire : INetFieldExportGroup
{
    // Fire event - may have muzzle position/rotation data in some implementations
}

#endregion

#region Pistol ClassNetCache

/// <summary>
/// ClassNetCache for Gun_Revolver.
/// Path: /Game/Guns/Revolver/Gun_Revolver.Gun_Revolver_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Gun_Revolver_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class GunRevolverCache
{
    /// <summary>
    /// RPC for fire event (handle 4).
    /// </summary>
    [NetFieldExportRPC("MulticastFire", "/Script/VRFramework.VRGun:MulticastFire", isFunction: true)]
    public MulticastFire? MulticastFire { get; set; }
}

/// <summary>
/// ClassNetCache for Gun_Tokarev.
/// Path: /Game/Guns/Tokarev/Gun_Tokarev.Gun_Tokarev_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Gun_Tokarev_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class GunTokarevCache
{
    [NetFieldExportRPC("MulticastFire", "/Script/VRFramework.VRGun:MulticastFire", isFunction: true)]
    public MulticastFire? MulticastFire { get; set; }

    [NetFieldExportRPC("MulticastOnMagazineReleased", "/Script/VRFramework.VRGun:MulticastOnMagazineReleased", isFunction: true)]
    public MulticastOnMagazineReleased? MulticastOnMagazineReleased { get; set; }

    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRGun:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Gun_1911.
/// Path: /Game/Guns/C1911/Gun_1911.Gun_1911_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Gun_1911_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class Gun1911Cache
{
    [NetFieldExportRPC("MulticastFire", "/Script/VRFramework.VRGun:MulticastFire", isFunction: true)]
    public MulticastFire? MulticastFire { get; set; }

    [NetFieldExportRPC("MulticastOnMagazineReleased", "/Script/VRFramework.VRGun:MulticastOnMagazineReleased", isFunction: true)]
    public MulticastOnMagazineReleased? MulticastOnMagazineReleased { get; set; }

    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRGun:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Gun_Cet9 (Tec-9).
/// Path: /Game/Guns/Cet9/Gun_Cet9.Gun_Cet9_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Gun_Cet9_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class GunCet9Cache
{
    [NetFieldExportRPC("MulticastFire", "/Script/VRFramework.VRGun:MulticastFire", isFunction: true)]
    public MulticastFire? MulticastFire { get; set; }

    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRGun:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Gun_57.
/// Path: /Game/Guns/57/Gun_57.Gun_57_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Gun_57_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class Gun57Cache
{
    [NetFieldExportRPC("MulticastFire", "/Script/VRFramework.VRGun:MulticastFire", isFunction: true)]
    public MulticastFire? MulticastFire { get; set; }

    [NetFieldExportRPC("MulticastOnMagazineReleased", "/Script/VRFramework.VRGun:MulticastOnMagazineReleased", isFunction: true)]
    public MulticastOnMagazineReleased? MulticastOnMagazineReleased { get; set; }

    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRGun:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Gun_Glock.
/// Path: /Game/Guns/Glock/Gun_Glock.Gun_Glock_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Gun_Glock_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class GunGlockCache
{
    [NetFieldExportRPC("MulticastFire", "/Script/VRFramework.VRGun:MulticastFire", isFunction: true)]
    public MulticastFire? MulticastFire { get; set; }

    [NetFieldExportRPC("MulticastOnMagazineReleased", "/Script/VRFramework.VRGun:MulticastOnMagazineReleased", isFunction: true)]
    public MulticastOnMagazineReleased? MulticastOnMagazineReleased { get; set; }
}

/// <summary>
/// ClassNetCache for Gun_DE (Desert Eagle).
/// Path: /Game/Guns/DE/Gun_DE.Gun_DE_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Gun_DE_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class GunDECache
{
    [NetFieldExportRPC("MulticastFire", "/Script/VRFramework.VRGun:MulticastFire", isFunction: true)]
    public MulticastFire? MulticastFire { get; set; }
}

/// <summary>
/// ClassNetCache for Gun_Vanas.
/// Path: /Game/Guns/Vanas/Gun_Vanas.Gun_Vanas_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Gun_Vanas_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class GunVanasCache
{
    [NetFieldExportRPC("MulticastFire", "/Script/VRFramework.VRGun:MulticastFire", isFunction: true)]
    public MulticastFire? MulticastFire { get; set; }

    [NetFieldExportRPC("MulticastOnMagazineReleased", "/Script/VRFramework.VRGun:MulticastOnMagazineReleased", isFunction: true)]
    public MulticastOnMagazineReleased? MulticastOnMagazineReleased { get; set; }
}

/// <summary>
/// ClassNetCache for Gun_Pepe.
/// Path: /Game/Guns/Pepe/Gun_Pepe.Gun_Pepe_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Gun_Pepe_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class GunPepeCache
{
    [NetFieldExportRPC("MulticastFire", "/Script/VRFramework.VRGun:MulticastFire", isFunction: true)]
    public MulticastFire? MulticastFire { get; set; }

    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRGun:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

#endregion

#region Rifle ClassNetCache

/// <summary>
/// ClassNetCache for Gun_AK47.
/// Path: /Game/Guns/AK/Gun_AK47.Gun_AK47_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Gun_AK47_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class GunAK47Cache
{
    [NetFieldExportRPC("MulticastFire", "/Script/VRFramework.VRGun:MulticastFire", isFunction: true)]
    public MulticastFire? MulticastFire { get; set; }

    [NetFieldExportRPC("MulticastOnMagazineReleased", "/Script/VRFramework.VRGun:MulticastOnMagazineReleased", isFunction: true)]
    public MulticastOnMagazineReleased? MulticastOnMagazineReleased { get; set; }

    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRGun:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Gun_AK12.
/// Path: /Game/Guns/AK/Gun_AK12.Gun_AK12_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Gun_AK12_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class GunAK12Cache
{
    [NetFieldExportRPC("MulticastFire", "/Script/VRFramework.VRGun:MulticastFire", isFunction: true)]
    public MulticastFire? MulticastFire { get; set; }

    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRGun:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Gun_M4.
/// Path: /Game/Guns/M4/Gun_M4.Gun_M4_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Gun_M4_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class GunM4Cache
{
    [NetFieldExportRPC("MulticastFire", "/Script/VRFramework.VRGun:MulticastFire", isFunction: true)]
    public MulticastFire? MulticastFire { get; set; }

    [NetFieldExportRPC("MulticastOnMagazineReleased", "/Script/VRFramework.VRGun:MulticastOnMagazineReleased", isFunction: true)]
    public MulticastOnMagazineReleased? MulticastOnMagazineReleased { get; set; }

    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRGun:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Gun_M16.
/// Path: /Game/Guns/M16/Gun_M16.Gun_M16_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Gun_M16_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class GunM16Cache
{
    [NetFieldExportRPC("MulticastFire", "/Script/VRFramework.VRGun:MulticastFire", isFunction: true)]
    public MulticastFire? MulticastFire { get; set; }

    [NetFieldExportRPC("MulticastOnMagazineReleased", "/Script/VRFramework.VRGun:MulticastOnMagazineReleased", isFunction: true)]
    public MulticastOnMagazineReleased? MulticastOnMagazineReleased { get; set; }
}

/// <summary>
/// ClassNetCache for Gun_AUG.
/// Path: /Game/Guns/AUG/Gun_AUG.Gun_AUG_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Gun_AUG_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class GunAUGCache
{
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRGun:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Gun_AutoSniper.
/// Path: /Game/Guns/AutoSniper/Gun_AutoSniper.Gun_AutoSniper_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Gun_AutoSniper_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class GunAutoSniperCache
{
    [NetFieldExportRPC("MulticastFire", "/Script/VRFramework.VRGun:MulticastFire", isFunction: true)]
    public MulticastFire? MulticastFire { get; set; }
}

#endregion

#region SMG ClassNetCache

/// <summary>
/// ClassNetCache for Gun_Kriss (Vector).
/// Path: /Game/Guns/Kriss/Gun_Kriss.Gun_Kriss_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Gun_Kriss_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class GunKrissCache
{
    [NetFieldExportRPC("MulticastFire", "/Script/VRFramework.VRGun:MulticastFire", isFunction: true)]
    public MulticastFire? MulticastFire { get; set; }
}

/// <summary>
/// ClassNetCache for Gun_AR9.
/// Path: /Game/Guns/AR9/Gun_AR9.Gun_AR9_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Gun_AR9_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class GunAR9Cache
{
    [NetFieldExportRPC("MulticastFire", "/Script/VRFramework.VRGun:MulticastFire", isFunction: true)]
    public MulticastFire? MulticastFire { get; set; }

    [NetFieldExportRPC("MulticastOnMagazineReleased", "/Script/VRFramework.VRGun:MulticastOnMagazineReleased", isFunction: true)]
    public MulticastOnMagazineReleased? MulticastOnMagazineReleased { get; set; }

    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRGun:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

#endregion

#region Shotgun ClassNetCache

/// <summary>
/// ClassNetCache for Gun_Sawedoff.
/// Path: /Game/Guns/Shotgun/Sawedoff/Gun_Sawedoff.Gun_Sawedoff_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Gun_Sawedoff_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class GunSawedoffCache
{
    [NetFieldExportRPC("MulticastFire", "/Script/VRFramework.VRGun:MulticastFire", isFunction: true)]
    public MulticastFire? MulticastFire { get; set; }

    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRGun:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

#endregion

#region Magazine ClassNetCache

/// <summary>
/// ClassNetCache for Magazine_Tokarev.
/// Path: /Game/Guns/Tokarev/Magazine_Tokarev.Magazine_Tokarev_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Magazine_Tokarev_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class MagazineTokarevCache
{
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRMagazine:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Magazine_1911.
/// Path: /Game/Guns/C1911/Magazine_1911.Magazine_1911_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Magazine_1911_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class Magazine1911Cache
{
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRMagazine:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Magazine_Cet9.
/// Path: /Game/Guns/Cet9/Magazine_Cet9.Magazine_Cet9_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Magazine_Cet9_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class MagazineCet9Cache
{
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRMagazine:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Magazine_57.
/// Path: /Game/Guns/57/Magazine_57.Magazine_57_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Magazine_57_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class Magazine57Cache
{
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRMagazine:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Magazine_Glock.
/// Path: /Game/Guns/Glock/Magazine_Glock.Magazine_Glock_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Magazine_Glock_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class MagazineGlockCache
{
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRMagazine:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Magazine_DE.
/// Path: /Game/Guns/DE/Magazine_DE.Magazine_DE_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Magazine_DE_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class MagazineDECache
{
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRMagazine:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Magazine_AK47.
/// Path: /Game/Guns/AK/Magazine_AK47.Magazine_AK47_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Magazine_AK47_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class MagazineAK47Cache
{
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRMagazine:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Magazine_AK12.
/// Path: /Game/Guns/AK/Magazine_AK12.Magazine_AK12_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Magazine_AK12_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class MagazineAK12Cache
{
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRMagazine:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Magazine_M4.
/// Path: /Game/Guns/M4/Magazine_M4.Magazine_M4_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Magazine_M4_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class MagazineM4Cache
{
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRMagazine:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Magazine_AUG.
/// Path: /Game/Guns/AUG/Magazine_AUG.Magazine_AUG_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Magazine_AUG_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class MagazineAUGCache
{
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRMagazine:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Magazine_AR9.
/// Path: /Game/Guns/AR9/Magazine_AR9.Magazine_AR9_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Magazine_AR9_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class MagazineAR9Cache
{
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRMagazine:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Magazine_Pepe.
/// Path: /Game/Guns/Pepe/Magazine_Pepe.Magazine_Pepe_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("Magazine_Pepe_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class MagazinePepeCache
{
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRMagazine:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

#endregion
