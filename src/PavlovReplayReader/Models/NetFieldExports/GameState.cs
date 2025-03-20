using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

[NetFieldExportClassNetCache("PavlovGameState_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class GameStateCache
{
    [NetFieldExportRPC("MulticastOnKillfeedEntry", "/Script/Pavlov.PavlovGameState:MulticastOnKillfeedEntry", enablePropertyChecksum: false)]
    public KillfeedEntry[] KillfeedEntries { get; set; }
}

[NetFieldExportGroup("/Script/Pavlov.PavlovGameState", minimalParseMode: ParseMode.Minimal)]
public class GameState : INetFieldExportGroup
{
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public object RemoteRole { get; set; }

    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public object Role { get; set; }

    [NetFieldExport("GameModeClass", RepLayoutCmdType.Ignore)]
    public ItemDefinition GameModeClass { get; set; }

    [NetFieldExport("SpectatorClass", RepLayoutCmdType.Ignore)]
    public uint? SpectatorClass { get; set; }

    [NetFieldExport("bReplicatedHasBegunPlay", RepLayoutCmdType.PropertyBool)]
    public bool? bReplicatedHasBegunPlay { get; set; }

    [NetFieldExport("ReplicatedWorldTimeSeconds", RepLayoutCmdType.PropertyFloat)]
    public float? ReplicatedWorldTimeSeconds { get; set; }

    [NetFieldExport("MatchState", RepLayoutCmdType.Property)]
    public FName MatchState { get; set; }

    [NetFieldExport("ElapsedTime", RepLayoutCmdType.PropertyInt)]
    public int? ElapsedTime { get; set; }

    [NetFieldExport("Team0Score", RepLayoutCmdType.PropertyInt)]
    public int? Team0Score { get; set; }

    [NetFieldExport("Team1Score", RepLayoutCmdType.PropertyInt)]
    public int? Team1Score { get; set; }

    [NetFieldExport("RoundTime", RepLayoutCmdType.PropertyInt)]
    public int? RoundTime { get; set; }

    [NetFieldExport("AttackingTeam", RepLayoutCmdType.PropertyInt)]
    public int? AttackingTeam { get; set; }

    [NetFieldExport("NameTagClass", RepLayoutCmdType.Ignore)]
    public uint? NameTagClass { get; set; }

    [NetFieldExport("bEnableProne", RepLayoutCmdType.PropertyBool)]
    public bool? bEnableProne { get; set; }

    [NetFieldExport("bCanReviveEnemies", RepLayoutCmdType.PropertyBool)]
    public bool? bCanReviveEnemies { get; set; }

    [NetFieldExport("GameModeType", RepLayoutCmdType.PropertyInt)]
    public int? GameModeType { get; set; }

    [NetFieldExport("AFKTimeLimit", RepLayoutCmdType.PropertyInt)]
    public int? AFKTimeLimit { get; set; }

    [NetFieldExport("BalancingCSV", RepLayoutCmdType.PropertyString)]
    public string BalancingCSV { get; set; }

    [NetFieldExport("SpawnableEquipment", RepLayoutCmdType.DynamicArray)]
    public ItemDefinition[] SpawnableEquipment { get; set; }

    [NetFieldExport("MaxPlayers", RepLayoutCmdType.PropertyInt)]
    public int? MaxPlayers { get; set; }

    [NetFieldExport("ModInitializers", RepLayoutCmdType.DynamicArray)]
    public ItemDefinition[] ModInitializers { get; set; }

    [NetFieldExport("ModId", RepLayoutCmdType.PropertyInt)]
    public int? ModId { get; set; }

    [NetFieldExport("ModPath", RepLayoutCmdType.PropertyString)]
    public string ModPath { get; set; }

    [NetFieldExport("GlobalInfo", RepLayoutCmdType.Ignore)]
    public uint? GlobalInfo { get; set; }
}

public class KillfeedEntry
{
    [NetFieldExport("Killer", RepLayoutCmdType.Property)]
    public ActorGuid Killer { get; set; }

    [NetFieldExport("Victim", RepLayoutCmdType.Property)]
    public ActorGuid Victim { get; set; }

    [NetFieldExport("DamageCauser", RepLayoutCmdType.Property)]
    public ItemDefinition DamageCauser { get; set; }

    [NetFieldExport("bHeadshot", RepLayoutCmdType.PropertyBool)]
    public bool? bHeadshot { get; set; }

    [NetFieldExport("KillerName", RepLayoutCmdType.PropertyString)]
    public string KillerName { get; set; }

    [NetFieldExport("KillerTeamId", RepLayoutCmdType.PropertyInt)]
    public int? KillerTeamId { get; set; }

    [NetFieldExport("KillerId", RepLayoutCmdType.PropertyInt)]
    public int? KillerId { get; set; }

    [NetFieldExport("VictimName", RepLayoutCmdType.PropertyString)]
    public string VictimName { get; set; }

    [NetFieldExport("VictimTeamId", RepLayoutCmdType.PropertyInt)]
    public int? VictimTeamId { get; set; }

    [NetFieldExport("VictimId", RepLayoutCmdType.PropertyInt)]
    public int? VictimId { get; set; }

    [NetFieldExport("EntryLifespan", RepLayoutCmdType.PropertyFloat)]
    public float? EntryLifespan { get; set; }

    [NetFieldExport("bLocalPlayer", RepLayoutCmdType.PropertyBool)]
    public bool? bLocalPlayer { get; set; }
}
