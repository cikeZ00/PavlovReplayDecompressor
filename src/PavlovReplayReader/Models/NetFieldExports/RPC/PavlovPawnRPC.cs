using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports.RPC;

#region RPC Function Structs

/// <summary>
/// RPC struct for MulticastOnImpactDamage function.
/// Called when a player takes impact damage.
/// Path: /Script/Pavlov.PavlovPawn:MulticastOnImpactDamage
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.PavlovPawn:MulticastOnImpactDamage", minimalParseMode: ParseMode.Minimal)]
public class MulticastOnImpactDamage : INetFieldExportGroup
{
    /// <summary>
    /// Location where the damage occurred (handle 0).
    /// </summary>
    [NetFieldExport("Location", RepLayoutCmdType.PropertyVector)]
    public FVector? Location { get; set; }

    /// <summary>
    /// Name of the bone that was hit (handle 1).
    /// </summary>
    [NetFieldExport("BoneName", RepLayoutCmdType.PropertyName)]
    public string? BoneName { get; set; }

    /// <summary>
    /// Direction of the impact (handle 2).
    /// </summary>
    [NetFieldExport("Direction", RepLayoutCmdType.PropertyVector)]
    public FVector? Direction { get; set; }

    /// <summary>
    /// Force of the impulse (handle 3).
    /// </summary>
    [NetFieldExport("ImpulseForce", RepLayoutCmdType.PropertyFloat)]
    public float? ImpulseForce { get; set; }

    /// <summary>
    /// Wound rate from damage (handle 4).
    /// Type: uint8 in FImpactDamage struct.
    /// </summary>
    [NetFieldExport("WoundRate", RepLayoutCmdType.PropertyByte)]
    public byte? WoundRate { get; set; }

    /// <summary>
    /// Wound scale from damage (handle 5).
    /// Type: float in FImpactDamage struct.
    /// </summary>
    [NetFieldExport("WoundScale", RepLayoutCmdType.PropertyFloat)]
    public float? WoundScale { get; set; }

    /// <summary>
    /// Reference to the instigator actor (handle 6).
    /// </summary>
    [NetFieldExport("Instigator", RepLayoutCmdType.PropertyObject)]
    public uint? Instigator { get; set; }
}

/// <summary>
/// RPC struct for MulticastOnHeadshot function.
/// Called when a player is killed by a headshot.
/// Path: /Script/Pavlov.PavlovPawn:MulticastOnHeadshot
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.PavlovPawn:MulticastOnHeadshot", minimalParseMode: ParseMode.Minimal)]
public class MulticastOnHeadshot : INetFieldExportGroup
{
    /// <summary>
    /// Reference to the killer actor (handle 0).
    /// </summary>
    [NetFieldExport("Killer", RepLayoutCmdType.PropertyObject)]
    public uint? Killer { get; set; }

    /// <summary>
    /// Location where the headshot hit (handle 1).
    /// </summary>
    [NetFieldExport("HitLocation", RepLayoutCmdType.PropertyVector)]
    public FVector? HitLocation { get; set; }

    /// <summary>
    /// Direction of the shot (handle 2).
    /// </summary>
    [NetFieldExport("HitDirection", RepLayoutCmdType.PropertyVector)]
    public FVector? HitDirection { get; set; }

    /// <summary>
    /// Wound rate from the headshot (handle 3).
    /// Serialized as a byte (0-255).
    /// </summary>
    [NetFieldExport("WoundRate", RepLayoutCmdType.PropertyByte)]
    public byte? WoundRate { get; set; }
}

/// <summary>
/// RPC struct for MulticastOnHelmetHit function.
/// Called when a player's helmet is hit.
/// Path: /Script/Pavlov.PavlovPawn:MulticastOnHelmetHit
/// SDK signature: void MulticastOnHelmetHit(const FVector_NetQuantize& Location, const FVector_NetQuantizeNormal& Direction)
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.PavlovPawn:MulticastOnHelmetHit", minimalParseMode: ParseMode.Minimal)]
public class MulticastOnHelmetHit : INetFieldExportGroup
{
    /// <summary>
    /// Location of the helmet hit (handle 0).
    /// Type: FVector_NetQuantize - uses variable-length quantized serialization.
    /// </summary>
    [NetFieldExport("Location", RepLayoutCmdType.PropertyVectorQ)]
    public FVector? Location { get; set; }

    /// <summary>
    /// Direction of the hit (handle 1).
    /// Type: FVector_NetQuantizeNormal - 48-bit quantized normal vector.
    /// </summary>
    [NetFieldExport("Direction", RepLayoutCmdType.PropertyVectorNormal)]
    public FVector? Direction { get; set; }
}

/// <summary>
/// RPC struct for MulticastOnRadialDeath function.
/// Called when a player dies from radial/explosion damage.
/// Path: /Script/Pavlov.PavlovPawn:MulticastOnRadialDeath
/// SDK signature: void MulticastOnRadialDeath(const FVector_NetQuantize& Origin)
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.PavlovPawn:MulticastOnRadialDeath", minimalParseMode: ParseMode.Minimal)]
public class MulticastOnRadialDeath : INetFieldExportGroup
{
    /// <summary>
    /// Origin point of the radial damage (handle 0).
    /// Type: FVector_NetQuantize - uses variable-length quantized serialization.
    /// </summary>
    [NetFieldExport("Origin", RepLayoutCmdType.PropertyVectorQ)]
    public FVector? Origin { get; set; }
}

/// <summary>
/// RPC struct for MulticastOnHelmetBlownoff function.
/// Called when a player's helmet is blown off.
/// Path: /Script/Pavlov.PavlovPawn:MulticastOnHelmetBlownoff
/// No parameters in Debug.txt dump - likely a zero-parameter event.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.PavlovPawn:MulticastOnHelmetBlownoff", minimalParseMode: ParseMode.Minimal)]
public class MulticastOnHelmetBlownoff : INetFieldExportGroup
{
}

/// <summary>
/// RPC struct for MulticastOnHitSlow function.
/// Called when a player is hit and slowed.
/// Path: /Script/Pavlov.PavlovPawn:MulticastOnHitSlow
/// No parameters in Debug.txt dump - likely a zero-parameter event.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.PavlovPawn:MulticastOnHitSlow", minimalParseMode: ParseMode.Minimal)]
public class MulticastOnHitSlow : INetFieldExportGroup
{
}

/// <summary>
/// RPC struct for MulticastOnMagazineGrabbed function.
/// Called when a player grabs a magazine.
/// Path: /Script/Pavlov.PavlovPawn:MulticastOnMagazineGrabbed
/// SDK signature: void MulticastOnMagazineGrabbed(bool bDominant)
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.PavlovPawn:MulticastOnMagazineGrabbed", minimalParseMode: ParseMode.Minimal)]
public class MulticastOnMagazineGrabbed : INetFieldExportGroup
{
    /// <summary>
    /// Whether the dominant hand grabbed the magazine (handle 0).
    /// </summary>
    [NetFieldExport("bDominant", RepLayoutCmdType.PropertyBool)]
    public bool? bDominant { get; set; }
}

/// <summary>
/// RPC struct for MulticastOnWearArmour function.
/// Called when a player puts on armour.
/// Path: /Script/Pavlov.PavlovPawn:MulticastOnWearArmour
/// No parameters in Debug.txt dump - likely a zero-parameter event.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.PavlovPawn:MulticastOnWearArmour", minimalParseMode: ParseMode.Minimal)]
public class MulticastOnWearArmour : INetFieldExportGroup
{
}

/// <summary>
/// RPC struct for MulticastResetPawn function.
/// Called when a player pawn is reset.
/// Path: /Script/Pavlov.PavlovPawn:MulticastResetPawn
/// No parameters in Debug.txt dump - likely a zero-parameter event.
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.PavlovPawn:MulticastResetPawn", minimalParseMode: ParseMode.Minimal)]
public class MulticastResetPawn : INetFieldExportGroup
{
}

/// <summary>
/// RPC struct for MulticastTeleportTo function.
/// Called when a player is teleported.
/// Path: /Script/Pavlov.PavlovPawn:MulticastTeleportTo
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.PavlovPawn:MulticastTeleportTo", minimalParseMode: ParseMode.Minimal)]
public class MulticastTeleportTo : INetFieldExportGroup
{
    /// <summary>
    /// Destination location for teleport (handle 0).
    /// </summary>
    [NetFieldExport("DestLocation", RepLayoutCmdType.PropertyVector)]
    public FVector? DestLocation { get; set; }

    /// <summary>
    /// Destination rotation for teleport (handle 1).
    /// </summary>
    [NetFieldExport("DestRotation", RepLayoutCmdType.PropertyRotator)]
    public FRotator? DestRotation { get; set; }
}

/// <summary>
/// RPC struct for MulticastAdjustAvatarScale function.
/// Called when player height/scale is adjusted.
/// Path: /Script/Pavlov.PavlovPawn:MulticastAdjustAvatarScale
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.PavlovPawn:MulticastAdjustAvatarScale", minimalParseMode: ParseMode.Minimal)]
public class MulticastAdjustAvatarScale : INetFieldExportGroup
{
    /// <summary>
    /// Player height value (handle 0).
    /// </summary>
    [NetFieldExport("PlayerHeight", RepLayoutCmdType.PropertyFloat)]
    public float? PlayerHeight { get; set; }
}

/// <summary>
/// RPC struct for MulticastPlayerLanded function.
/// Called when a player lands on a surface.
/// Path: /Script/Pavlov.PavlovPawn:MulticastPlayerLanded
/// SDK signature: void MulticastPlayerLanded(EPhysicalSurface LandedSurface)
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.PavlovPawn:MulticastPlayerLanded", minimalParseMode: ParseMode.Minimal)]
public class MulticastPlayerLanded : INetFieldExportGroup
{
    /// <summary>
    /// Physical material of the surface landed on (handle 0).
    /// Type: EPhysicalSurface enum.
    /// </summary>
    [NetFieldExport("LandedSurface", RepLayoutCmdType.Enum)]
    public int? LandedSurface { get; set; }
}

/// <summary>
/// RPC struct for PlayInventoryGrabSoundMulti function.
/// Called when a player grabs/puts an item in inventory.
/// Path: /Script/Pavlov.PavlovPawn:PlayInventoryGrabSoundMulti
/// </summary>
[NetFieldExportGroup("/Script/Pavlov.PavlovPawn:PlayInventoryGrabSoundMulti", minimalParseMode: ParseMode.Minimal)]
public class PlayInventoryGrabSoundMulti : INetFieldExportGroup
{
    /// <summary>
    /// Inventory slot affected (handle 0).
    /// </summary>
    [NetFieldExport("Slot", RepLayoutCmdType.PropertyByte)]
    public byte? Slot { get; set; }

    /// <summary>
    /// Whether the item was put into inventory (handle 1).
    /// </summary>
    [NetFieldExport("bPut", RepLayoutCmdType.PropertyBool)]
    public bool? bPut { get; set; }

    /// <summary>
    /// Type of item grabbed/put (handle 2).
    /// </summary>
    [NetFieldExport("ItemType", RepLayoutCmdType.PropertyByte)]
    public byte? ItemType { get; set; }
}

#endregion

#region Pawn ClassNetCache

/// <summary>
/// ClassNetCache for BP_PavlovPawn.
/// Contains RPC function mappings for player pawn multicast events.
/// Path: BP_PavlovPawn_C_ClassNetCache (short name for compatibility)
/// </summary>
[NetFieldExportClassNetCache("BP_PavlovPawn_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class PavlovPawnCache
{
    /// <summary>
    /// RPC for adjusting avatar scale based on player height (handle 13).
    /// </summary>
    [NetFieldExportRPC("MulticastAdjustAvatarScale", "/Script/Pavlov.PavlovPawn:MulticastAdjustAvatarScale", isFunction: true)]
    public MulticastAdjustAvatarScale? MulticastAdjustAvatarScale { get; set; }

    /// <summary>
    /// RPC for headshot kill event (handle 15).
    /// </summary>
    [NetFieldExportRPC("MulticastOnHeadshot", "/Script/Pavlov.PavlovPawn:MulticastOnHeadshot", isFunction: true)]
    public MulticastOnHeadshot? MulticastOnHeadshot { get; set; }

    /// <summary>
    /// RPC for helmet blown off event (handle 16).
    /// </summary>
    [NetFieldExportRPC("MulticastOnHelmetBlownoff", "/Script/Pavlov.PavlovPawn:MulticastOnHelmetBlownoff", isFunction: true)]
    public MulticastOnHelmetBlownoff? MulticastOnHelmetBlownoff { get; set; }

    /// <summary>
    /// RPC for helmet hit event (handle 17).
    /// </summary>
    [NetFieldExportRPC("MulticastOnHelmetHit", "/Script/Pavlov.PavlovPawn:MulticastOnHelmetHit", isFunction: true)]
    public MulticastOnHelmetHit? MulticastOnHelmetHit { get; set; }

    /// <summary>
    /// RPC for slow effect from hit (handle 19).
    /// </summary>
    [NetFieldExportRPC("MulticastOnHitSlow", "/Script/Pavlov.PavlovPawn:MulticastOnHitSlow", isFunction: true)]
    public MulticastOnHitSlow? MulticastOnHitSlow { get; set; }

    /// <summary>
    /// RPC for impact damage event (handle 20).
    /// </summary>
    [NetFieldExportRPC("MulticastOnImpactDamage", "/Script/Pavlov.PavlovPawn:MulticastOnImpactDamage", isFunction: true)]
    public MulticastOnImpactDamage? MulticastOnImpactDamage { get; set; }

    /// <summary>
    /// RPC for magazine grabbed event (handle 21).
    /// </summary>
    [NetFieldExportRPC("MulticastOnMagazineGrabbed", "/Script/Pavlov.PavlovPawn:MulticastOnMagazineGrabbed", isFunction: true)]
    public MulticastOnMagazineGrabbed? MulticastOnMagazineGrabbed { get; set; }

    /// <summary>
    /// RPC for radial/explosion death event (handle 22).
    /// </summary>
    [NetFieldExportRPC("MulticastOnRadialDeath", "/Script/Pavlov.PavlovPawn:MulticastOnRadialDeath", isFunction: true)]
    public MulticastOnRadialDeath? MulticastOnRadialDeath { get; set; }

    /// <summary>
    /// RPC for wearing armour event (handle 23).
    /// </summary>
    [NetFieldExportRPC("MulticastOnWearArmour", "/Script/Pavlov.PavlovPawn:MulticastOnWearArmour", isFunction: true)]
    public MulticastOnWearArmour? MulticastOnWearArmour { get; set; }

    /// <summary>
    /// RPC for player landed event (handle 25).
    /// </summary>
    [NetFieldExportRPC("MulticastPlayerLanded", "/Script/Pavlov.PavlovPawn:MulticastPlayerLanded", isFunction: true)]
    public MulticastPlayerLanded? MulticastPlayerLanded { get; set; }

    /// <summary>
    /// RPC for pawn reset event (handle 26).
    /// </summary>
    [NetFieldExportRPC("MulticastResetPawn", "/Script/Pavlov.PavlovPawn:MulticastResetPawn", isFunction: true)]
    public MulticastResetPawn? MulticastResetPawn { get; set; }

    /// <summary>
    /// RPC for teleport event (handle 27).
    /// </summary>
    [NetFieldExportRPC("MulticastTeleportTo", "/Script/Pavlov.PavlovPawn:MulticastTeleportTo", isFunction: true)]
    public MulticastTeleportTo? MulticastTeleportTo { get; set; }

    /// <summary>
    /// RPC for inventory grab sound (handle 28).
    /// </summary>
    [NetFieldExportRPC("PlayInventoryGrabSoundMulti", "/Script/Pavlov.PavlovPawn:PlayInventoryGrabSoundMulti", isFunction: true)]
    public PlayInventoryGrabSoundMulti? PlayInventoryGrabSoundMulti { get; set; }
}

/// <summary>
/// ClassNetCache for BP_PavlovGhost spectator pawn.
/// Path: BP_PavlovGhost_C_ClassNetCache (short name for compatibility)
/// </summary>
[NetFieldExportClassNetCache("BP_PavlovGhost_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class PavlovGhostCache
{
    // Ghost pawns inherit from PavlovPawn but may have different RPC functions
}

#endregion
