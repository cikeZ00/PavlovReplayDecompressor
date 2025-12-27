using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

/// <summary>
/// NetFieldExportGroup for VR Inventory Logic.
/// Handles inventory management and item tracking.
/// </summary>
[NetFieldExportGroup("/Script/VRFramework.VRInventoryLogic", minimalParseMode: ParseMode.Minimal)]
public class VRInventoryLogicExport : INetFieldExportGroup
{
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public object? RemoteRole { get; set; }

    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public object? Role { get; set; }

    [NetFieldExport("Owner", RepLayoutCmdType.PropertyObject)]
    public uint? Owner { get; set; }

    [NetFieldExport("Instigator", RepLayoutCmdType.PropertyObject)]
    public uint? Instigator { get; set; }

    [NetFieldExport("ReplicatedMovement", RepLayoutCmdType.RepMovement)]
    public FRepMovement? ReplicatedMovement { get; set; }

    [NetFieldExport("AttachParent", RepLayoutCmdType.PropertyObject)]
    public uint? AttachParent { get; set; }

    [NetFieldExport("AttachComponent", RepLayoutCmdType.PropertyObject)]
    public uint? AttachComponent { get; set; }

    [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVector100)]
    public FVector? RelativeScale3D { get; set; }
}

/// <summary>
/// NetFieldExportGroup for VR Bullet Manager.
/// Handles bullet physics and trajectory calculations.
/// </summary>
[NetFieldExportGroup("/Script/VRFramework.VRBulletManager", minimalParseMode: ParseMode.Minimal)]
public class VRBulletManagerExport : INetFieldExportGroup
{
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public object? RemoteRole { get; set; }

    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public object? Role { get; set; }
}

/// <summary>
/// NetFieldExportGroup for Pavlov Game Logic.
/// Contains core game logic state.
/// </summary>
[NetFieldExportGroup("/Script/PavlovProxy.Pavlov_GameLogic", minimalParseMode: ParseMode.Minimal)]
public class PavlovGameLogicExport : INetFieldExportGroup
{
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public object? RemoteRole { get; set; }

    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public object? Role { get; set; }
}

/// <summary>
/// NetFieldExportGroup for Pavlov Global Info.
/// Contains global game information.
/// </summary>
[NetFieldExportGroup("/Script/PavlovProxy.Pavlov_GlobalInfo", minimalParseMode: ParseMode.Minimal)]
public class PavlovGlobalInfoExport : INetFieldExportGroup
{
    [NetFieldExport("GameLogic", RepLayoutCmdType.PropertyObject)]
    public uint? GameLogic { get; set; }
}

/// <summary>
/// NetFieldExportGroup for World Settings.
/// Contains world configuration parameters.
/// </summary>
[NetFieldExportGroup("/Script/Engine.WorldSettings", minimalParseMode: ParseMode.Minimal)]
public class WorldSettingsExport : INetFieldExportGroup
{
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public object? RemoteRole { get; set; }

    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public object? Role { get; set; }

    [NetFieldExport("WorldGravityZ", RepLayoutCmdType.PropertyFloat)]
    public float? WorldGravityZ { get; set; }
}

/// <summary>
/// NetFieldExportGroup for Loot Spawn Manager.
/// Manages loot spawning in game modes.
/// </summary>
[NetFieldExportGroup("/Game/LoadoutRoom/Bps/LootSpawner/BP_LootSpawnManager.BP_LootSpawnManager_C", minimalParseMode: ParseMode.Minimal)]
public class LootSpawnManagerExport : INetFieldExportGroup
{
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public object? RemoteRole { get; set; }

    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public object? Role { get; set; }
}

/// <summary>
/// NetFieldExportGroup for AI Director (zombie mode).
/// Controls zombie spawning and AI behavior.
/// </summary>
[NetFieldExportGroup("/Game/ZombieMode/Pavlov_AIDirector.Pavlov_AIDirector_C", minimalParseMode: ParseMode.Minimal)]
public class PavlovAIDirectorExport : INetFieldExportGroup
{
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public object? RemoteRole { get; set; }

    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public object? Role { get; set; }
}

/// <summary>
/// NetFieldExportGroup for Replay Player Controller.
/// Used for replay playback control.
/// </summary>
[NetFieldExportGroup("/Game/Replay/BP_ReplayPlayerController.BP_ReplayPlayerController_C", minimalParseMode: ParseMode.Minimal)]
public class ReplayPlayerControllerExport : INetFieldExportGroup
{
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public object? RemoteRole { get; set; }

    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public object? Role { get; set; }
}

/// <summary>
/// NetFieldExportGroup for Spectator Ghost.
/// Represents a spectating player.
/// </summary>
[NetFieldExportGroup("/Game/Gameplay/Misc/Spectator/BP_PavlovGhost.BP_PavlovGhost_C", minimalParseMode: ParseMode.Minimal)]
public class PavlovGhostExport : INetFieldExportGroup
{
    [NetFieldExport("bHidden", RepLayoutCmdType.PropertyBool)]
    public bool? bHidden { get; set; }

    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public object? RemoteRole { get; set; }

    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public object? Role { get; set; }

    [NetFieldExport("Owner", RepLayoutCmdType.PropertyObject)]
    public uint? Owner { get; set; }

    [NetFieldExport("Instigator", RepLayoutCmdType.PropertyObject)]
    public uint? Instigator { get; set; }

    [NetFieldExport("ReplicatedMovement", RepLayoutCmdType.RepMovement)]
    public FRepMovement? ReplicatedMovement { get; set; }

    [NetFieldExport("PlayerState", RepLayoutCmdType.PropertyObject)]
    public uint? PlayerState { get; set; }

    [NetFieldExport("Controller", RepLayoutCmdType.PropertyObject)]
    public uint? Controller { get; set; }

    [NetFieldExport("LeftController", RepLayoutCmdType.PropertyObject)]
    public uint? LeftController { get; set; }

    [NetFieldExport("RightController", RepLayoutCmdType.PropertyObject)]
    public uint? RightController { get; set; }

    [NetFieldExport("Heading", RepLayoutCmdType.PropertyFloat)]
    public float? Heading { get; set; }

    [NetFieldExport("Velocity", RepLayoutCmdType.PropertyVector100)]
    public FVector? Velocity { get; set; }

    [NetFieldExport("Location", RepLayoutCmdType.PropertyVector)]
    public FVector? Location { get; set; }

    [NetFieldExport("Rotation", RepLayoutCmdType.PropertyRotator)]
    public FRotator? Rotation { get; set; }

    [NetFieldExport("Location1", RepLayoutCmdType.PropertyVector)]
    public FVector? Location1 { get; set; }

    [NetFieldExport("Location2", RepLayoutCmdType.PropertyVector)]
    public FVector? Location2 { get; set; }

    [NetFieldExport("Location3", RepLayoutCmdType.PropertyVector)]
    public FVector? Location3 { get; set; }

    [NetFieldExport("Rotation1", RepLayoutCmdType.PropertyRotator)]
    public FRotator? Rotation1 { get; set; }

    [NetFieldExport("Rotation2", RepLayoutCmdType.PropertyRotator)]
    public FRotator? Rotation2 { get; set; }
}

/// <summary>
/// NetFieldExportGroup for Spectator Ghost Controller.
/// Controls spectating player behavior.
/// </summary>
[NetFieldExportGroup("/Game/Gameplay/Misc/Spectator/BP_PavlovGhostController.BP_PavlovGhostController_C", minimalParseMode: ParseMode.Minimal)]
public class PavlovGhostControllerExport : INetFieldExportGroup
{
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public object? RemoteRole { get; set; }

    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public object? Role { get; set; }

    [NetFieldExport("PlayerState", RepLayoutCmdType.PropertyObject)]
    public uint? PlayerState { get; set; }

    [NetFieldExport("AttachParent", RepLayoutCmdType.PropertyObject)]
    public uint? AttachParent { get; set; }

    [NetFieldExport("LocationOffset", RepLayoutCmdType.PropertyVector100)]
    public FVector? LocationOffset { get; set; }

    [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVector100)]
    public FVector? RelativeScale3D { get; set; }

    [NetFieldExport("RotationOffset", RepLayoutCmdType.PropertyRotator)]
    public FRotator? RotationOffset { get; set; }

    [NetFieldExport("AttachComponent", RepLayoutCmdType.PropertyObject)]
    public uint? AttachComponent { get; set; }

    [NetFieldExport("Owner", RepLayoutCmdType.PropertyObject)]
    public uint? Owner { get; set; }

    [NetFieldExport("Instigator", RepLayoutCmdType.PropertyObject)]
    public uint? Instigator { get; set; }

    [NetFieldExport("HandType", RepLayoutCmdType.PropertyByte)]
    public byte? HandType { get; set; }

    [NetFieldExport("bDominant", RepLayoutCmdType.PropertyBool)]
    public bool? bDominant { get; set; }

    [NetFieldExport("bFlag", RepLayoutCmdType.PropertyBool)]
    public bool? bFlag { get; set; }
}

/// <summary>
/// NetFieldExportGroup for Vote Kick Player.
/// Handles player kick voting.
/// </summary>
[NetFieldExportGroup("/Game/UI/Moderation/Voting/Vote_KickPlayer.Vote_KickPlayer_C", minimalParseMode: ParseMode.Minimal)]
public class VoteKickPlayerExport : INetFieldExportGroup
{
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public object? RemoteRole { get; set; }

    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public object? Role { get; set; }

    [NetFieldExport("AttachParent", RepLayoutCmdType.PropertyObject)]
    public uint? AttachParent { get; set; }

    [NetFieldExport("LocationOffset", RepLayoutCmdType.PropertyVector100)]
    public FVector? LocationOffset { get; set; }

    [NetFieldExport("RelativeScale3D", RepLayoutCmdType.PropertyVector100)]
    public FVector? RelativeScale3D { get; set; }

    [NetFieldExport("RotationOffset", RepLayoutCmdType.PropertyRotator)]
    public FRotator? RotationOffset { get; set; }

    [NetFieldExport("AttachComponent", RepLayoutCmdType.PropertyObject)]
    public uint? AttachComponent { get; set; }

    [NetFieldExport("VoteInstigator", RepLayoutCmdType.PropertyString)]
    public string? VoteInstigator { get; set; }

    [NetFieldExport("VoteInstigatorName", RepLayoutCmdType.PropertyString)]
    public string? VoteInstigatorName { get; set; }

    [NetFieldExport("Param1", RepLayoutCmdType.PropertyString)]
    public string? Param1 { get; set; }

    [NetFieldExport("YesVotes", RepLayoutCmdType.PropertyByte)]
    public byte? YesVotes { get; set; }

    [NetFieldExport("NoVotes", RepLayoutCmdType.PropertyByte)]
    public byte? NoVotes { get; set; }

    [NetFieldExport("State", RepLayoutCmdType.PropertyByte)]
    public byte? State { get; set; }

    [NetFieldExport("TeamId", RepLayoutCmdType.PropertyInt)]
    public int? TeamId { get; set; }

    [NetFieldExport("CensusNum", RepLayoutCmdType.PropertyByte)]
    public byte? CensusNum { get; set; }

    [NetFieldExport("SpawnLocation", RepLayoutCmdType.PropertyVector)]
    public FVector? SpawnLocation { get; set; }
}
