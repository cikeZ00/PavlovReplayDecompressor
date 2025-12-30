using System.Collections.Generic;

namespace PavlovReplayReader.Models;

/// <summary>
/// Represents player state data from Pavlov replays.
/// Based on Pavlov.PavlovPlayerState from GObjects dump.
/// </summary>
public class PlayerData
{
    // Voice channels
    public string? VoiceChannelPrimary { get; set; }
    public string? VoiceChannelSecondary { get; set; }

    // Team and stats
    public int TeamId { get; set; }
    public int Kills { get; set; }
    public int Deaths { get; set; }
    public int Assists { get; set; }
    public int Cash { get; set; }
    public int Exp { get; set; }
    public int Progress { get; set; }

    // Player identification
    public string? PlatformId { get; set; }
    public string? PlayerName { get; set; }
    public int PlayerId { get; set; }

    // Player state
    public bool bDead { get; set; }
    public bool bDev { get; set; }
    public int? Flair { get; set; }
    public int RespawnCountdown { get; set; }

    // Player settings
    public float PlayerHeight { get; set; }
    public bool bRightHanded { get; set; }
    public bool bVirtualStock { get; set; }

    // Voice and communication
    public bool bCanVote { get; set; }
    public bool bSpeaking { get; set; }
    public bool bGagged { get; set; }
    public int? PlayerPlatform { get; set; }

    // Purchases and equipment
    public IDictionary<string, int>? Purchases { get; set; }
    public IDictionary<string, string>? EquippedSkins { get; set; }

    // Authentication and moderation
    public bool bAuthenticated { get; set; }
    public int LifeTeamKillCount { get; set; }
    public int LifetimeTeamKillCount { get; set; }

    // Respawn and death tracking
    public float ExtraRespawnCountdown { get; set; }
    public float DeadTime { get; set; }

    // Miscellaneous
    public bool bSpawnGhost { get; set; }
    public bool bHasPlayerProxy { get; set; }
    public string? SkinOverride { get; set; }

    // Score (inherited from PlayerState)
    public float Score { get; set; }
    public int CompressedPing { get; set; }
    }

