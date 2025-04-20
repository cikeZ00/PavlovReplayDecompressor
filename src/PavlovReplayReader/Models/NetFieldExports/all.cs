using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports
{

    // /Game/LoadoutRoom/Bps/LootSpawner/BP_LootSpawnManager.BP_LootSpawnManager_C
    [NetFieldExportGroup("/Game/LoadoutRoom/Bps/LootSpawner/BP_LootSpawnManager.BP_LootSpawnManager_C", minimalParseMode: ParseMode.Minimal)]
    public class BPLootSpawnManager : INetFieldExportGroup
    {
        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }
    }

    // /Script/PavlovProxy.Pavlov_GameLogic
    [NetFieldExportGroup("/Script/PavlovProxy.Pavlov_GameLogic", minimalParseMode: ParseMode.Minimal)]
    public class PavlovGameLogic : INetFieldExportGroup
    {
        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }
    }

    // /Script/VRFramework.VRBulletManager
    [NetFieldExportGroup("/Script/VRFramework.VRBulletManager", minimalParseMode: ParseMode.Minimal)]
    public class VRBulletManager : INetFieldExportGroup
    {
        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }
    }

    // /Script/VRFramework.VRInventoryLogic
    [NetFieldExportGroup("/Script/VRFramework.VRInventoryLogic", minimalParseMode: ParseMode.Minimal)]
    public class VRInventoryLogic : INetFieldExportGroup
    {
        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("AttachParent", RepLayoutCmdType.Ignore)]
        public object AttachParent { get; set; }

        [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVector10)]
        public FVector RelativeScale3D { get; set; }

        [NetFieldExport("AttachComponent", RepLayoutCmdType.Ignore)]
        public object AttachComponent { get; set; }

        [NetFieldExport("Owner", RepLayoutCmdType.Ignore)]
        public ActorGuid Owner { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }

        [NetFieldExport("Instigator", RepLayoutCmdType.Ignore)]
        public ActorGuid Instigator { get; set; }
    }

    // /Game/ZombieMode/Pavlov_AIDirector.Pavlov_AIDirector_C
    [NetFieldExportGroup("/Game/ZombieMode/Pavlov_AIDirector.Pavlov_AIDirector_C", minimalParseMode: ParseMode.Minimal)]
    public class PavlovAIDirector : INetFieldExportGroup
    {
        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }
    }

    // /Game/Guns/Knife/Knife_Bayonet.Knife_Bayonet_C
    [NetFieldExportGroup("/Game/Guns/Knife/Knife_Bayonet.Knife_Bayonet_C", minimalParseMode: ParseMode.Minimal)]
    public class Knife_Bayonet : INetFieldExportGroup
    {
        [NetFieldExport("bReplicateMovement", RepLayoutCmdType.PropertyBool)]
        public bool? bReplicateMovement { get; set; }

        [NetFieldExport("ReplicatedMovement", RepLayoutCmdType.RepMovement)]
        public FRepMovement ReplicatedMovement { get; set; }

        [NetFieldExport("LocationOffset", RepLayoutCmdType.PropertyVectorQ)]
        public FVector LocationOffset { get; set; }

        [NetFieldExport("RotationOffset", RepLayoutCmdType.PropertyRotator)]
        public FRotator RotationOffset { get; set; }

        [NetFieldExport("Controller", RepLayoutCmdType.Ignore)]
        public object Controller { get; set; }

        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("AttachParent", RepLayoutCmdType.Ignore)]
        public object AttachParent { get; set; }

        [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVector10)]
        public FVector RelativeScale3D { get; set; }

        [NetFieldExport("AttachSocket", RepLayoutCmdType.PropertyName)]
        public string AttachSocket { get; set; }

        [NetFieldExport("AttachComponent", RepLayoutCmdType.Ignore)]
        public object AttachComponent { get; set; }

        [NetFieldExport("Owner", RepLayoutCmdType.Ignore)]
        public ActorGuid Owner { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }

        [NetFieldExport("Parent", RepLayoutCmdType.Ignore)]
        public object Parent { get; set; }

        [NetFieldExport("bPickDisabled", RepLayoutCmdType.PropertyBool)]
        public bool? bPickDisabled { get; set; }
    }

    // /Script/PavlovProxy.Pavlov_GlobalInfo
    [NetFieldExportGroup("/Script/PavlovProxy.Pavlov_GlobalInfo", minimalParseMode: ParseMode.Minimal)]
    public class PavlovGlobalInfo : INetFieldExportGroup
    {
        [NetFieldExport("GameLogic", RepLayoutCmdType.Ignore)]
        public object GameLogic { get; set; }
    }

    // /Game/Gameplay/BP_PavlovController.BP_PavlovController_C
    [NetFieldExportGroup("/Game/Gameplay/BP_PavlovController.BP_PavlovController_C", minimalParseMode: ParseMode.Minimal)]
    public class BP_PavlovController : INetFieldExportGroup
    {
        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("AttachParent", RepLayoutCmdType.Ignore)]
        public object AttachParent { get; set; }

        [NetFieldExport("LocationOffset", RepLayoutCmdType.PropertyVectorQ)]
        public FVector LocationOffset { get; set; }

        [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVector10)]
        public FVector RelativeScale3D { get; set; }

        [NetFieldExport("RotationOffset", RepLayoutCmdType.PropertyRotator)]
        public FRotator RotationOffset { get; set; }

        [NetFieldExport("AttachComponent", RepLayoutCmdType.Ignore)]
        public object AttachComponent { get; set; }

        [NetFieldExport("Owner", RepLayoutCmdType.Ignore)]
        public ActorGuid Owner { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }

        [NetFieldExport("Instigator", RepLayoutCmdType.Ignore)]
        public ActorGuid Instigator { get; set; }

        [NetFieldExport("HandType", RepLayoutCmdType.PropertyByte)]
        public byte HandType { get; set; }

        [NetFieldExport("State", RepLayoutCmdType.PropertyByte)]
        public byte State { get; set; }

        [NetFieldExport("bFlag", RepLayoutCmdType.PropertyBool)]
        public bool? bFlag { get; set; }

        [NetFieldExport("bDominant", RepLayoutCmdType.PropertyBool)]
        public bool? bDominant { get; set; }
    }

    // /Game/Guns/Grenades/M64/Grenade_M64.Grenade_M64_C
    [NetFieldExportGroup("/Game/Guns/Grenades/M64/Grenade_M64.Grenade_M64_C", minimalParseMode: ParseMode.Minimal)]
    public class Grenade_M64 : INetFieldExportGroup
    {
        [NetFieldExport("bReplicateMovement", RepLayoutCmdType.PropertyBool)]
        public bool? bReplicateMovement { get; set; }

        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("AttachParent", RepLayoutCmdType.Ignore)]
        public object AttachParent { get; set; }

        [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVector10)]
        public FVector RelativeScale3D { get; set; }

        [NetFieldExport("AttachSocket", RepLayoutCmdType.PropertyName)]
        public string AttachSocket { get; set; }

        [NetFieldExport("LocationOffset", RepLayoutCmdType.PropertyVectorQ)]
        public FVector LocationOffset { get; set; }

        [NetFieldExport("RotationOffset", RepLayoutCmdType.PropertyRotator)]
        public FRotator RotationOffset { get; set; }

        [NetFieldExport("Controller", RepLayoutCmdType.Ignore)]
        public object Controller { get; set; }

        [NetFieldExport("Instigator", RepLayoutCmdType.Ignore)]
        public ActorGuid Instigator { get; set; }

        [NetFieldExport("State", RepLayoutCmdType.PropertyByte)]
        public byte State { get; set; }

        [NetFieldExport("bHidden", RepLayoutCmdType.PropertyBool)]
        public bool? bHidden { get; set; }

        [NetFieldExport("ReplicatedMovement", RepLayoutCmdType.RepMovement)]
        public FRepMovement ReplicatedMovement { get; set; }

        [NetFieldExport("AttachComponent", RepLayoutCmdType.Ignore)]
        public object AttachComponent { get; set; }

        [NetFieldExport("Owner", RepLayoutCmdType.Ignore)]
        public ActorGuid Owner { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }

        [NetFieldExport("Parent", RepLayoutCmdType.Ignore)]
        public object Parent { get; set; }

        [NetFieldExport("ParentSlot", RepLayoutCmdType.PropertyByte)]
        public byte ParentSlot { get; set; }

        [NetFieldExport("bPickDisabled", RepLayoutCmdType.PropertyBool)]
        public bool? bPickDisabled { get; set; }

        [NetFieldExport("bProjectileActive", RepLayoutCmdType.PropertyNativeBool)]
        public bool bProjectileActive { get; set; }
    }

    // /Game/Guns/AntiTank/Gun_AntiTank.Gun_AntiTank_C
    [NetFieldExportGroup("/Game/Guns/AntiTank/Gun_AntiTank.Gun_AntiTank_C", minimalParseMode: ParseMode.Minimal)]
    public class Gun_AntiTank : INetFieldExportGroup
    {
        [NetFieldExport("bReplicateMovement", RepLayoutCmdType.PropertyBool)]
        public bool? bReplicateMovement { get; set; }

        [NetFieldExport("ReplicatedMovement", RepLayoutCmdType.RepMovement)]
        public FRepMovement ReplicatedMovement { get; set; }


        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("AttachParent", RepLayoutCmdType.Ignore)]
        public object AttachParent { get; set; }

        [NetFieldExport("LocationOffset", RepLayoutCmdType.PropertyVector100)]
        public FVector LocationOffset { get; set; }

        [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVector10)]
        public FVector RelativeScale3D { get; set; }

        [NetFieldExport("RotationOffset", RepLayoutCmdType.PropertyRotator)]
        public FRotator RotationOffset { get; set; }

        [NetFieldExport("AttachComponent", RepLayoutCmdType.Ignore)]
        public object AttachComponent { get; set; }

        [NetFieldExport("Owner", RepLayoutCmdType.Ignore)]
        public ActorGuid Owner { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }

        [NetFieldExport("Instigator", RepLayoutCmdType.Ignore)]
        public ActorGuid Instigator { get; set; }

        [NetFieldExport("Controller", RepLayoutCmdType.Ignore)]
        public object Controller { get; set; }

        [NetFieldExport("BlockDuration", RepLayoutCmdType.PropertyFloat)]
        public float? BlockDuration { get; set; }

        [NetFieldExport("StateProxy", RepLayoutCmdType.Ignore)]
        public object StateProxy { get; set; }
    }

    // /Game/Attachments/Scope/Sight_ScopeX8.Sight_ScopeX8_C
    [NetFieldExportGroup("/Game/Attachments/Scope/Sight_ScopeX8.Sight_ScopeX8_C", minimalParseMode: ParseMode.Minimal)]
    public class Sight_ScopeX8 : INetFieldExportGroup
    {
        [NetFieldExport("bReplicateMovement", RepLayoutCmdType.PropertyBool)]
        public bool? bReplicateMovement { get; set; }

        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("AttachParent", RepLayoutCmdType.Ignore)]
        public object AttachParent { get; set; }

        [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVector10)]
        public FVector RelativeScale3D { get; set; }

        [NetFieldExport("AttachSocket", RepLayoutCmdType.PropertyName)]
        public string AttachSocket { get; set; }

        [NetFieldExport("AttachComponent", RepLayoutCmdType.Ignore)]
        public object AttachComponent { get; set; }

        [NetFieldExport("Owner", RepLayoutCmdType.Ignore)]
        public ActorGuid Owner { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }

        [NetFieldExport("Parent", RepLayoutCmdType.Ignore)]
        public object Parent { get; set; }

        [NetFieldExport("ParentSlot", RepLayoutCmdType.PropertyByte)]
        public byte ParentSlot { get; set; }

        [NetFieldExport("bPickDisabled", RepLayoutCmdType.PropertyBool)]
        public bool? bPickDisabled { get; set; }

        [NetFieldExport("bAttaching", RepLayoutCmdType.PropertyBool)]
        public bool? bAttaching { get; set; }
    }

    // /Script/Vankrupt.VHealthComponent
    [NetFieldExportGroup("/Script/Vankrupt.VHealthComponent", minimalParseMode: ParseMode.Minimal)]
    public class VHealthComponent : INetFieldExportGroup
    {
        [NetFieldExport("Health", RepLayoutCmdType.PropertyFloat)]
        public float FFloatProperty { get; set; }

        // Sometimes bDead is also replicated.
        [NetFieldExport("bDead", RepLayoutCmdType.PropertyBool)]
        public bool? bDead { get; set; }
    }

    // /Game/Maps/datacenter/datacenter.datacenter_C
    [NetFieldExportGroup("/Game/Maps/datacenter/datacenter.datacenter_C", minimalParseMode: ParseMode.Minimal)]
    public class Datacenter : INetFieldExportGroup
    {
        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }
    }

    // /Game/Gameplay/SearchAndDestroy/Bomb/BombPlantSpot_Basic.BombPlantSpot_Basic_C
    [NetFieldExportGroup("/Game/Gameplay/SearchAndDestroy/Bomb/BombPlantSpot_Basic.BombPlantSpot_Basic_C", minimalParseMode: ParseMode.Minimal)]
    public class BombPlantSpot_Basic : INetFieldExportGroup
    {
        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("ReplicatedMovement", RepLayoutCmdType.RepMovement)]
        public FRepMovement ReplicatedMovement { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }

    }


    // /Game/Meshes/OfficeLevel/Props/BP_LightBlocker.BP_LightBlocker_C
    [NetFieldExportGroup("/Game/Meshes/OfficeLevel/Props/BP_LightBlocker.BP_LightBlocker_C", minimalParseMode: ParseMode.Minimal)]
    public class BP_LightBlocker : INetFieldExportGroup
    {
        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }

        [NetFieldExport("Visible", RepLayoutCmdType.PropertyBool)]
        public bool? Visible { get; set; }
    }

    // /Game/Maps/datacenter/Datacenter_Audio.Datacenter_Audio_C
    [NetFieldExportGroup("/Game/Maps/datacenter/Datacenter_Audio.Datacenter_Audio_C", minimalParseMode: ParseMode.Minimal)]
    public class Datacenter_Audio : INetFieldExportGroup
    {
        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }
    }

    // /Script/Engine.WorldSettings
    [NetFieldExportGroup("/Script/Engine.WorldSettings", minimalParseMode: ParseMode.Minimal)]
    public class WorldSettings : INetFieldExportGroup
    {
        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }

        [NetFieldExport("WorldGravityZ", RepLayoutCmdType.PropertyFloat)]
        public float? WorldGravityZ { get; set; }
    }

    // /Game/Guns/AntiTank/Bullet_AntiTank.Bullet_AntiTank_C
    [NetFieldExportGroup("/Game/Guns/AntiTank/Bullet_AntiTank.Bullet_AntiTank_C", minimalParseMode: ParseMode.Minimal)]
    public class Bullet_AntiTank : INetFieldExportGroup
    {
        [NetFieldExport("bHidden", RepLayoutCmdType.PropertyBool)]
        public bool? bHidden { get; set; }

        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("Owner", RepLayoutCmdType.Ignore)]
        public ActorGuid Owner { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }

        [NetFieldExport("Instigator", RepLayoutCmdType.Ignore)]
        public ActorGuid Instigator { get; set; }
    }

    // /Game/Meshes/OfficeLevel/Props/BP_GlassPanel.BP_GlassPanel_C
    [NetFieldExportGroup("/Game/Meshes/OfficeLevel/Props/BP_GlassPanel.BP_GlassPanel_C", minimalParseMode: ParseMode.Minimal)]
    public class BP_GlassPanel : INetFieldExportGroup
    {
        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }

        [NetFieldExport("Broken", RepLayoutCmdType.PropertyNativeBool)]
        public bool Broken { get; set; }
    }

    // /Game/Gameplay/Misc/Spectator/BP_PavlovGhostController.BP_PavlovGhostController_C
    [NetFieldExportGroup("/Game/Gameplay/Misc/Spectator/BP_PavlovGhostController.BP_PavlovGhostController_C", minimalParseMode: ParseMode.Minimal)]
    public class BP_PavlovGhostController : INetFieldExportGroup
    {
        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("AttachParent", RepLayoutCmdType.Ignore)]
        public object AttachParent { get; set; }

        [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVector10)]
        public FVector RelativeScale3D { get; set; }

        [NetFieldExport("LocationOffset", RepLayoutCmdType.PropertyVectorQ)]
        public FVector LocationOffset { get; set; }

        [NetFieldExport("RotationOffset", RepLayoutCmdType.PropertyRotator)]
        public FRotator RotationOffset { get; set; }

        [NetFieldExport("AttachComponent", RepLayoutCmdType.Ignore)]
        public object AttachComponent { get; set; }

        [NetFieldExport("Owner", RepLayoutCmdType.Ignore)]
        public ActorGuid Owner { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }

        [NetFieldExport("Instigator", RepLayoutCmdType.Ignore)]
        public ActorGuid Instigator { get; set; }

        [NetFieldExport("HandType", RepLayoutCmdType.PropertyByte)]
        public byte HandType { get; set; }

        [NetFieldExport("bDominant", RepLayoutCmdType.PropertyBool)]
        public bool? bDominant { get; set; }
    }

    // /Game/Gameplay/Misc/Spectator/BP_PavlovGhost.BP_PavlovGhost_C
    [NetFieldExportGroup("/Game/Gameplay/Misc/Spectator/BP_PavlovGhost.BP_PavlovGhost_C", minimalParseMode: ParseMode.Minimal)]
    public class BP_PavlovGhost : INetFieldExportGroup
    {
        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("Owner", RepLayoutCmdType.Ignore)]
        public ActorGuid Owner { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }

        [NetFieldExport("Instigator", RepLayoutCmdType.Ignore)]
        public ActorGuid Instigator { get; set; }

        [NetFieldExport("PlayerState", RepLayoutCmdType.Ignore)]
        public object PlayerState { get; set; }

        [NetFieldExport("Controller", RepLayoutCmdType.Ignore)]
        public object Controller { get; set; }

        [NetFieldExport("Location", RepLayoutCmdType.PropertyVector)]
        public FVector Location { get; set; }

        [NetFieldExport("Location1", RepLayoutCmdType.PropertyVector)]
        public FVector Location1 { get; set; }

        [NetFieldExport("Location2", RepLayoutCmdType.PropertyVector)]
        public FVector Location2 { get; set; }

        [NetFieldExport("Location3", RepLayoutCmdType.PropertyVector)]
        public FVector Location3 { get; set; }

        [NetFieldExport("Heading", RepLayoutCmdType.PropertyFloat)]
        public float? Heading { get; set; }

        [NetFieldExport("Velocity", RepLayoutCmdType.PropertyVector10)]
        public FVector Velocity { get; set; }

        [NetFieldExport("Rotation", RepLayoutCmdType.PropertyRotator)]
        public FRotator? Rotation { get; set; }

        [NetFieldExport("Rotation1", RepLayoutCmdType.PropertyRotator)]
        public FRotator? Rotation1 { get; set; }

        [NetFieldExport("Rotation2", RepLayoutCmdType.PropertyRotator)]
        public FRotator? Rotation2 { get; set; }

        [NetFieldExport("LeftController", RepLayoutCmdType.Ignore)]
        public object LeftController { get; set; }

        [NetFieldExport("RightController", RepLayoutCmdType.Ignore)]
        public object RightController { get; set; }
    }

    // /Game/Guns/M16/Gun_M16.Gun_M16_C
    [NetFieldExportGroup("/Game/Guns/M16/Gun_M16.Gun_M16_C", minimalParseMode: ParseMode.Minimal)]
    public class Gun_M16 : INetFieldExportGroup
    {
        [NetFieldExport("bReplicateMovement", RepLayoutCmdType.PropertyBool)]
        public bool? bReplicateMovement { get; set; }

        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("AttachParent", RepLayoutCmdType.Ignore)]
        public object AttachParent { get; set; }

        [NetFieldExport("LocationOffset", RepLayoutCmdType.PropertyVector100)]
        public FVector LocationOffset { get; set; }

        [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVector10)]
        public FVector RelativeScale3D { get; set; }

        [NetFieldExport("RotationOffset", RepLayoutCmdType.PropertyRotator)]
        public FRotator RotationOffset { get; set; }

        [NetFieldExport("AttachComponent", RepLayoutCmdType.Ignore)]
        public object AttachComponent { get; set; }

        [NetFieldExport("Owner", RepLayoutCmdType.Ignore)]
        public ActorGuid Owner { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }

        [NetFieldExport("Instigator", RepLayoutCmdType.Ignore)]
        public ActorGuid Instigator { get; set; }

        [NetFieldExport("Controller", RepLayoutCmdType.Ignore)]
        public object Controller { get; set; }

        [NetFieldExport("BlockDuration", RepLayoutCmdType.PropertyFloat)]
        public float? BlockDuration { get; set; }

        [NetFieldExport("StateProxy", RepLayoutCmdType.Ignore)]
        public object StateProxy { get; set; }

        [NetFieldExport("AttachSocket", RepLayoutCmdType.PropertyName)]
        public string AttachSocket { get; set; }

        [NetFieldExport("Parent", RepLayoutCmdType.Ignore)]
        public object Parent { get; set; }

        [NetFieldExport("ParentSlot", RepLayoutCmdType.PropertyByte)]
        public byte ParentSlot { get; set; }

        [NetFieldExport("bPickDisabled", RepLayoutCmdType.PropertyBool)]
        public bool? bPickDisabled { get; set; }

        [NetFieldExport("ReplicatedMovement", RepLayoutCmdType.RepMovement)]
        public FRepMovement ReplicatedMovement { get; set; }
    }

    // /Game/Guns/M16/Magazine_M16.Magazine_M16_C
    [NetFieldExportGroup("/Game/Guns/M16/Magazine_M16.Magazine_M16_C", minimalParseMode: ParseMode.Minimal)]
    public class Magazine_M16 : INetFieldExportGroup
    {
        [NetFieldExport("bReplicateMovement", RepLayoutCmdType.PropertyBool)]
        public bool? bReplicateMovement { get; set; }

        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("AttachParent", RepLayoutCmdType.Ignore)]
        public object AttachParent { get; set; }

        [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVector10)]
        public FVector RelativeScale3D { get; set; }

        [NetFieldExport("AttachSocket", RepLayoutCmdType.PropertyName)]
        public string AttachSocket { get; set; }

        [NetFieldExport("AttachComponent", RepLayoutCmdType.Ignore)]
        public object AttachComponent { get; set; }

        [NetFieldExport("Owner", RepLayoutCmdType.Ignore)]
        public ActorGuid Owner { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }

        [NetFieldExport("Parent", RepLayoutCmdType.Ignore)]
        public object Parent { get; set; }

        [NetFieldExport("Bullets", RepLayoutCmdType.PropertyInt)]
        public int Bullets { get; set; }
    }

    // /Game/Guns/M4/Gun_M4.Gun_M4_C
    [NetFieldExportGroup("/Game/Guns/M4/Gun_M4.Gun_M4_C", minimalParseMode: ParseMode.Minimal)]
    public class Gun_M4 : INetFieldExportGroup
    {
        [NetFieldExport("bReplicateMovement", RepLayoutCmdType.PropertyBool)]
        public bool? bReplicateMovement { get; set; }

        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("AttachParent", RepLayoutCmdType.Ignore)]
        public object AttachParent { get; set; }

        [NetFieldExport("LocationOffset", RepLayoutCmdType.PropertyVector100)]
        public FVector LocationOffset { get; set; }

        [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVector10)]
        public FVector RelativeScale3D { get; set; }

        [NetFieldExport("RotationOffset", RepLayoutCmdType.PropertyRotator)]
        public FRotator RotationOffset { get; set; }

        [NetFieldExport("AttachComponent", RepLayoutCmdType.Ignore)]
        public object AttachComponent { get; set; }

        [NetFieldExport("Owner", RepLayoutCmdType.Ignore)]
        public ActorGuid Owner { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }

        [NetFieldExport("Controller", RepLayoutCmdType.Ignore)]
        public object Controller { get; set; }

        [NetFieldExport("StateProxy", RepLayoutCmdType.Ignore)]
        public object StateProxy { get; set; }

        [NetFieldExport("AttachSocket", RepLayoutCmdType.PropertyName)]
        public string AttachSocket { get; set; }

        [NetFieldExport("Parent", RepLayoutCmdType.Ignore)]
        public object Parent { get; set; }

        [NetFieldExport("ParentSlot", RepLayoutCmdType.PropertyByte)]
        public byte ParentSlot { get; set; }

        [NetFieldExport("bPickDisabled", RepLayoutCmdType.PropertyBool)]
        public bool? bPickDisabled { get; set; }

        [NetFieldExport("ReplicatedMovement", RepLayoutCmdType.RepMovement)]
        public FRepMovement ReplicatedMovement { get; set; }

        [NetFieldExport("HandlingSound", RepLayoutCmdType.PropertySoftObject)]
        public object? HandlingSound { get; set; }
    }

    // /Game/Guns/M4/Magazine_M4.Magazine_M4_C
    [NetFieldExportGroup("/Game/Guns/M4/Magazine_M4.Magazine_M4_C", minimalParseMode: ParseMode.Minimal)]
    public class Magazine_M4 : INetFieldExportGroup
    {
        [NetFieldExport("bReplicateMovement", RepLayoutCmdType.PropertyBool)]
        public bool? bReplicateMovement { get; set; }

        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("AttachParent", RepLayoutCmdType.Ignore)]
        public object AttachParent { get; set; }

        [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVector10)]
        public FVector RelativeScale3D { get; set; }

        [NetFieldExport("AttachSocket", RepLayoutCmdType.PropertyName)]
        public string AttachSocket { get; set; }

        [NetFieldExport("AttachComponent", RepLayoutCmdType.Ignore)]
        public object AttachComponent { get; set; }

        [NetFieldExport("Owner", RepLayoutCmdType.Ignore)]
        public ActorGuid Owner { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }

        [NetFieldExport("Parent", RepLayoutCmdType.Ignore)]
        public object Parent { get; set; }

        [NetFieldExport("Bullets", RepLayoutCmdType.PropertyInt)]
        public int Bullets { get; set; }

        [NetFieldExport("bPickDisabled", RepLayoutCmdType.PropertyBool)]
        public bool? bPickDisabled { get; set; }

        [NetFieldExport("ReplicatedMovement", RepLayoutCmdType.RepMovement)]
        public FRepMovement ReplicatedMovement { get; set; }

        [NetFieldExport("RotationOffset", RepLayoutCmdType.PropertyRotator)]
        public FRotator RotationOffset { get; set; }

        [NetFieldExport("Controller", RepLayoutCmdType.Ignore)]
        public object Controller { get; set; }
    }

    // /Game/Attachments/Grip/Grip_Angled.Grip_Angled_C
    [NetFieldExportGroup("/Game/Attachments/Grip/Grip_Angled.Grip_Angled_C", minimalParseMode: ParseMode.Minimal)]
    public class Grip_Angled : INetFieldExportGroup
    {
        [NetFieldExport("bReplicateMovement", RepLayoutCmdType.PropertyBool)]
        public bool? bReplicateMovement { get; set; }

        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("AttachParent", RepLayoutCmdType.Ignore)]
        public object AttachParent { get; set; }

        [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVector10)]
        public FVector RelativeScale3D { get; set; }

        [NetFieldExport("AttachSocket", RepLayoutCmdType.PropertyName)]
        public string AttachSocket { get; set; }

        [NetFieldExport("AttachComponent", RepLayoutCmdType.Ignore)]
        public object AttachComponent { get; set; }

        [NetFieldExport("Owner", RepLayoutCmdType.Ignore)]
        public ActorGuid Owner { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }

        [NetFieldExport("Parent", RepLayoutCmdType.Ignore)]
        public object Parent { get; set; }

        [NetFieldExport("ParentSlot", RepLayoutCmdType.PropertyByte)]
        public byte ParentSlot { get; set; }

        [NetFieldExport("bPickDisabled", RepLayoutCmdType.PropertyBool)]
        public bool? bPickDisabled { get; set; }
    }

    // /Game/Attachments/Scope/Sight_RedDot.Sight_RedDot_C
    [NetFieldExportGroup("/Game/Attachments/Scope/Sight_RedDot.Sight_RedDot_C", minimalParseMode: ParseMode.Minimal)]
    public class Sight_RedDot : INetFieldExportGroup
    {
        [NetFieldExport("bReplicateMovement", RepLayoutCmdType.PropertyBool)]
        public bool? bReplicateMovement { get; set; }

        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("AttachParent", RepLayoutCmdType.Ignore)]
        public object AttachParent { get; set; }

        [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVector10)]
        public FVector RelativeScale3D { get; set; }

        [NetFieldExport("AttachSocket", RepLayoutCmdType.PropertyName)]
        public string AttachSocket { get; set; }

        [NetFieldExport("AttachComponent", RepLayoutCmdType.Ignore)]
        public object AttachComponent { get; set; }

        [NetFieldExport("Owner", RepLayoutCmdType.Ignore)]
        public ActorGuid Owner { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }

        [NetFieldExport("Parent", RepLayoutCmdType.Ignore)]
        public object Parent { get; set; }

        [NetFieldExport("ParentSlot", RepLayoutCmdType.PropertyByte)]
        public byte ParentSlot { get; set; }

        [NetFieldExport("bPickDisabled", RepLayoutCmdType.PropertyBool)]
        public bool? bPickDisabled { get; set; }
    }

    // /Game/Guns/Bullets/Bullet_39mm.Bullet_39mm_C
    [NetFieldExportGroup("/Game/Guns/Bullets/Bullet_39mm.Bullet_39mm_C", minimalParseMode: ParseMode.Minimal)]
    public class Bullet_39mm : INetFieldExportGroup
    {
        [NetFieldExport("bHidden", RepLayoutCmdType.PropertyBool)]
        public bool? bHidden { get; set; }

        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("Owner", RepLayoutCmdType.Ignore)]
        public ActorGuid Owner { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }

        [NetFieldExport("Instigator", RepLayoutCmdType.Ignore)]
        public ActorGuid Instigator { get; set; }
    }

    // /Game/UI/Moderation/Voting/Vote_EndMatch.Vote_EndMatch_C
    [NetFieldExportGroup("/Game/UI/Moderation/Voting/Vote_EndMatch.Vote_EndMatch_C", minimalParseMode: ParseMode.Minimal)]
    public class Vote_EndMatch : INetFieldExportGroup
    {
        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("AttachParent", RepLayoutCmdType.Ignore)]
        public object AttachParent { get; set; }

        [NetFieldExport("LocationOffset", RepLayoutCmdType.PropertyVectorQ)]
        public FVector LocationOffset { get; set; }

        [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVector10)]
        public FVector RelativeScale3D { get; set; }

        [NetFieldExport("RotationOffset", RepLayoutCmdType.PropertyRotator)]
        public FRotator RotationOffset { get; set; }

        [NetFieldExport("AttachComponent", RepLayoutCmdType.Ignore)]
        public object AttachComponent { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }

        [NetFieldExport("YesVotes", RepLayoutCmdType.PropertyByte)]
        public byte YesVotes { get; set; }

        [NetFieldExport("State", RepLayoutCmdType.PropertyByte)]
        public byte State { get; set; }

        [NetFieldExport("CensusNum", RepLayoutCmdType.PropertyByte)]
        public byte CensusNum { get; set; }

        [NetFieldExport("TeamId", RepLayoutCmdType.PropertyInt)]
        public int? TeamId { get; set; }

        [NetFieldExport("VoteInstigatorName", RepLayoutCmdType.PropertyString)]
        public string VoteInstigatorName { get; set; }

        [NetFieldExport("VoteInstigator", RepLayoutCmdType.Ignore)]
        public ActorGuid VoteInstigator { get; set; }
    }
}
