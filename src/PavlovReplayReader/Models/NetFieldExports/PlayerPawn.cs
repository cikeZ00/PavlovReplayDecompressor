using PavlovReplayReader.Models.NetFieldExports.RPC;
using System.Collections.Generic;
using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

//TODO: Implement the rest of the RPCs
//[NetFieldExportClassNetCache("BP_PavlovPawn_C_ClassNetCache", minimalParseMode: ParseMode.Full)]
//public class PlayerPawnCache
//{
//    [NetFieldExportRPC("MulticastAdjustAvatarScale", "/Script/Pavlov.PavlovPawn:MulticastAdjustAvatarScale", enablePropertyChecksum: false)]
//    public AdjustAvatarScale MulticastAdjustAvatarScale { get; set; }

//    [NetFieldExportRPC("MulticastOnHeadshot", "/Script/Pavlov.PavlovPawn:MulticastOnHeadshot", enablePropertyChecksum: false)]
//    public OnHeadshot MulticastOnHeadshot { get; set; }

//    [NetFieldExportRPC("MulticastOnHelmetBlownoff", "/Script/Pavlov.PavlovPawn:MulticastOnHelmetBlownoff", enablePropertyChecksum: false)]
//    public OnHelmetBlownoff MulticastOnHelmetBlownoff { get; set; }

//    [NetFieldExportRPC("MulticastOnHelmetHit", "/Script/Pavlov.PavlovPawn:MulticastOnHelmetHit", enablePropertyChecksum: false)]
//    public OnHelmetHit MulticastOnHelmetHit { get; set; }

//    [NetFieldExportRPC("MulticastOnHitSlow", "/Script/Pavlov.PavlovPawn:MulticastOnHitSlow", enablePropertyChecksum: false)]
//    public OnHitSlow MulticastOnHitSlow { get; set; }

//    [NetFieldExportRPC("MulticastOnImpactDamage", "/Script/Pavlov.PavlovPawn:MulticastOnImpactDamage", enablePropertyChecksum: false)]
//    public OnImpactDamage MulticastOnImpactDamage { get; set; }

//    [NetFieldExportRPC("MulticastOnMagazineGrabbed", "/Script/Pavlov.PavlovPawn:MulticastOnMagazineGrabbed", enablePropertyChecksum: false)]
//    public OnMagazineGrabbed MulticastOnMagazineGrabbed { get; set; }

//    [NetFieldExportRPC("MulticastOnRadialDeath", "/Script/Pavlov.PavlovPawn:MulticastOnRadialDeath", enablePropertyChecksum: false)]
//    public OnRadialDeath MulticastOnRadialDeath { get; set; }

//    [NetFieldExportRPC("MulticastOnWearArmour", "/Script/Pavlov.PavlovPawn:MulticastOnWearArmour", enablePropertyChecksum: false)]
//    public OnWearArmour MulticastOnWearArmour { get; set; }

//    [NetFieldExportRPC("MulticastPlayerLanded", "/Script/Pavlov.PavlovPawn:MulticastPlayerLanded", enablePropertyChecksum: false)]
//    public PlayerLanded MulticastPlayerLanded { get; set; }

//    [NetFieldExportRPC("MulticastTeleportTo", "/Script/Pavlov.PavlovPawn:MulticastTeleportTo", enablePropertyChecksum: false)]
//    public TeleportTo MulticastTeleportTo { get; set; }

//    [NetFieldExportRPC("PlayInventoryGrabSoundMulti", "/Script/Pavlov.PavlovPawn:PlayInventoryGrabSoundMulti", enablePropertyChecksum: false)]
//    public InventoryGrabSoundMulti PlayInventoryGrabSoundMulti { get; set; }
//}

[NetFieldExportGroup("/Game/Gameplay/BP_PavlovPawn.BP_PavlovPawn_C", minimalParseMode: ParseMode.Minimal)]
public class PlayerPawn : INetFieldExportGroup
{
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public int? RemoteRole { get; set; }

    [NetFieldExport("Owner", RepLayoutCmdType.Property)]
    public ActorGuid Owner { get; set; }

    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public object Role { get; set; }

    [NetFieldExport("Instigator", RepLayoutCmdType.PropertyObject)]
    public uint? Instigator { get; set; }

    [NetFieldExport("PlayerState", RepLayoutCmdType.PropertyObject)]
    public uint? PlayerState { get; set; }

    [NetFieldExport("Controller", RepLayoutCmdType.PropertyObject)]
    public uint? Controller { get; set; }

    // TODO: Figure out how to handle the multiple entries of the Location property

    [NetFieldExport("Location", RepLayoutCmdType.PropertyVector100)]
    public FVector Location { get; set; }

    [NetFieldExport("Velocity", RepLayoutCmdType.PropertyVector10)]
    public FVector Velocity { get; set; }

    [NetFieldExport("Heading", RepLayoutCmdType.PropertyRotator)]
    public FRotator Heading { get; set; }

    [NetFieldExport("Flags", RepLayoutCmdType.PropertyByte)]
    public byte? Flags { get; set; }

    // TODO: Figure out how to handle the multiple entries of the Rotation property
    [NetFieldExport("Rotation", RepLayoutCmdType.PropertyRotator)]
    public FRotator Rotation { get; set; }

    [NetFieldExport("InventoryLogic", RepLayoutCmdType.PropertyObject)]
    public uint? InventoryLogic { get; set; }

    [NetFieldExport("LeftController", RepLayoutCmdType.PropertyObject)]
    public uint? LeftController { get; set; }

    [NetFieldExport("RightController", RepLayoutCmdType.PropertyObject)]
    public uint? RightController { get; set; }

    [NetFieldExport("Index", RepLayoutCmdType.PropertyByte)]
    public byte? Index { get; set; }

    [NetFieldExport("Midle", RepLayoutCmdType.PropertyByte)]
    public byte? Midle { get; set; }

    [NetFieldExport("Ring", RepLayoutCmdType.PropertyByte)]
    public byte? Ring { get; set; }

    [NetFieldExport("Pinky", RepLayoutCmdType.PropertyByte)]
    public byte? Pinky { get; set; }

    [NetFieldExport("Thumb", RepLayoutCmdType.PropertyByte)]
    public byte? Thumb { get; set; }

    [NetFieldExport("Supported", RepLayoutCmdType.PropertyBool)]
    public bool? Supported { get; set; }

    [NetFieldExport("AvatarSkinClass", RepLayoutCmdType.PropertyObject)]
    public uint? AvatarSkinClass { get; set; }

    [NetFieldExport("CustomMesh", RepLayoutCmdType.PropertyObject)]
    public uint? CustomMesh { get; set; }

    [NetFieldExport("RadioChannel", RepLayoutCmdType.PropertyByte)]
    public byte? RadioChannel { get; set; }

    [NetFieldExport("Armour", RepLayoutCmdType.PropertyByte)]
    public byte? Armour { get; set; }

    [NetFieldExport("HelmetArmour", RepLayoutCmdType.PropertyByte)]
    public byte? HelmetArmour { get; set; }

    [NetFieldExport("TeamId", RepLayoutCmdType.PropertyByte)]
    public byte? TeamId { get; set; }

    [NetFieldExport("RevivePlayerState", RepLayoutCmdType.PropertyObject)]
    public uint? RevivePlayerState { get; set; }

    [NetFieldExport("WorkshopProxy", RepLayoutCmdType.PropertyObject)]
    public uint? WorkshopProxy { get; set; }

    [NetFieldExport("AvatarId", RepLayoutCmdType.PropertyInt)]
    public int? AvatarId { get; set; }
}

