using System;
using System.Collections.Generic;

namespace PavlovReplayReader.Models;

public class GameData
{
    public string GameSessionId { get; set; }
    public DateTime? UtcTimeStartedMatch { get; set; }
    public float? ReplicatedWorldTimeSeconds { get; set; }
    public string MatchState { get; set; }
    public int? ElapsedTime { get; set; }
    public int? Team0Score { get; set; }
    public int? Team1Score { get; set; }
    public int? RoundTime { get; set; }
    public int? AttackingTeam { get; set; }
    public string NameTagClass { get; set; }
    public bool? bEnableProne { get; set; }
    public bool? bCanReviveEnemies { get; set; }
    public int? GameModeType { get; set; }
    public int? AFKTimeLimit { get; set; }
    public string BalancingCSV { get; set; }
    public IEnumerable<string> SpawnableEquipment { get; set; }
    public int? MaxPlayers { get; set; }
    public IEnumerable<string> ModInitializers { get; set; }
    public int? ModId { get; set; }
    public string ModPath { get; set; }
    public uint? GlobalInfo { get; set; }
}
