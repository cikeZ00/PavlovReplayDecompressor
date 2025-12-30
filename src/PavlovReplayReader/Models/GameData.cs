using System.Collections.Generic;

namespace PavlovReplayReader.Models;

/// <summary>
/// Represents game state data from a Pavlov VR replay.
/// Based on Pavlov.PavlovGameState class.
/// </summary>
public class GameData
{
    // Replicated world time
    public float? ReplicatedWorldTimeSeconds { get; set; }
    
    // Match state
    public string? MatchState { get; set; }
    public float? ElapsedTime { get; set; }
    
    // Team scores
    public int? Team0Score { get; set; }
    public int? Team1Score { get; set; }
    
    // Round information
    public int? RoundDuration { get; set; }
    public int? RoundTime { get; set; }
    public int? PauseTime { get; set; }
    public int? AttackingTeam { get; set; }
    public int? RoundWinner { get; set; }
    public int? RoundsLeft { get; set; }
    public bool? bMatchTimePaused { get; set; }
    public float? MatchTime { get; set; }
    
    // Game settings
    public bool? bNoTeams { get; set; }
    public bool? bMovementDisabled { get; set; }
    public bool? bNoFallDamage { get; set; }
    public bool? bLimitedAmmo { get; set; }
    public bool? bShowNameTags { get; set; }
    public bool? bPreventGrenadePin { get; set; }
    public bool? bEnableProne { get; set; }
    public bool? bCanReviveEnemies { get; set; }
    public bool? bCanSwitchTeams { get; set; }
    public bool? bPinProtected { get; set; }
    public bool? bCanAutoEjectVehicles { get; set; }
    
    // Game mode
    public int? GameModeType { get; set; }
    public int? CompetitiveMode { get; set; }
    public int? Holiday { get; set; }
    
    // Player limits
    public int? MaxPlayers { get; set; }
    public int? AFKTimeLimit { get; set; }
    
    // Classes
    public string? ScoreboardClass { get; set; }
    public string? HandMenuClass { get; set; }
    public string? NameTagClass { get; set; }
    
    // Buy menu and equipment
    public string? BuyMenuScript { get; set; }
    public string? BalancingCSV { get; set; }
    public IEnumerable<string>? SpawnableEquipment { get; set; }
    public IEnumerable<string>? DisabledBuyMenuItems { get; set; }
    public int? ModdedItemEquipmentIndex { get; set; }
    
    // Mods
    public IEnumerable<string>? ModInitializers { get; set; }
    public string? ModId { get; set; }
    public string? ModPath { get; set; }
    public object? GlobalInfo { get; set; }
    
    // Equipment costs (could be more specific type later)
    public object? EquipmentCosts { get; set; }
    
    // Buy restrictions (could be more specific type later)
    public object? BuyRestrictions { get; set; }
    
    // Settings (could be more specific type later)
    public object? Settings { get; set; }
}
