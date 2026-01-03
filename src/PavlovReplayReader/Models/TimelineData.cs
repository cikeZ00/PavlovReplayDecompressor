using System.Collections.Generic;
using Unreal.Core.Models;

namespace PavlovReplayReader.Models;

/// <summary>
/// Represents a single snapshot of pawn state at a specific time.
/// </summary>
public class PawnSnapshot
{
    /// <summary>
    /// Replay time in seconds when this snapshot was captured.
    /// </summary>
    public float Time { get; set; }

    /// <summary>
    /// World location at this time.
    /// </summary>
    public FVector? Location { get; set; }

    /// <summary>
    /// Head world location at this time.
    /// </summary>
    public FVector? HeadLocation { get; set; }

    /// <summary>
    /// Left hand world location at this time.
    /// </summary>
    public FVector? LeftHandLocation { get; set; }

    /// <summary>
    /// Right hand world location at this time.
    /// </summary>
    public FVector? RightHandLocation { get; set; }

    /// <summary>
    /// Velocity at this time.
    /// </summary>
    public FVector? Velocity { get; set; }

    /// <summary>
    /// Body/head rotation at this time.
    /// </summary>
    public FRotator? Rotation { get; set; }

    /// <summary>
    /// Left hand rotation.
    /// </summary>
    public FRotator? LeftHandRotation { get; set; }

    /// <summary>
    /// Right hand rotation.
    /// </summary>
    public FRotator? RightHandRotation { get; set; }

    /// <summary>
    /// Heading/yaw in degrees.
    /// </summary>
    public float? Heading { get; set; }

    /// <summary>
    /// Head/HMD rotation.
    /// </summary>
    public FRotator? HeadRot { get; set; }

    /// <summary>
    /// Gaze direction.
    /// </summary>
    public FVector? GazeDir { get; set; }

    /// <summary>
    /// Whether this position data appears valid (Z height in reasonable range).
    /// </summary>
    public bool IsPositionValid { get; set; } = true;

    /// <summary>
    /// Whether the player is dead at this snapshot time.
    /// </summary>
    public bool IsDead { get; set; }
}

/// <summary>
/// Timeline data for a single pawn across the entire replay.
/// </summary>
public class PawnTimeline
{
    /// <summary>
    /// Channel index for this pawn.
    /// </summary>
    public uint ChannelIndex { get; set; }

    /// <summary>
    /// Associated player name (if known).
    /// </summary>
    public string? PlayerName { get; set; }

    /// <summary>
    /// Associated player ID (if known).
    /// </summary>
    public ulong? PlayerId { get; set; }

    /// <summary>
    /// Team ID (0 or 1 for teams).
    /// </summary>
    public int? TeamId { get; set; }

    /// <summary>
    /// Time of first snapshot in seconds.
    /// </summary>
    public float? FirstSnapshotTime { get; set; }

    /// <summary>
    /// Time of last snapshot in seconds.
    /// </summary>
    public float? LastSnapshotTime { get; set; }

    /// <summary>
    /// All position/state snapshots for this pawn.
    /// </summary>
    public List<PawnSnapshot> Snapshots { get; set; } = new();
}

/// <summary>
/// Represents a game event at a specific time (kills, objectives, etc.).
/// </summary>
public class GameEvent
{
    /// <summary>
    /// Replay time in seconds when this event occurred.
    /// </summary>
    public float Time { get; set; }

    /// <summary>
    /// Type of event.
    /// </summary>
    public string EventType { get; set; } = "";

    /// <summary>
    /// Event description or details.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Additional event-specific data.
    /// </summary>
    public Dictionary<string, object>? Data { get; set; }
}

/// <summary>
/// Kill feed entry captured from the replay.
/// </summary>
public class KillEvent : GameEvent
{
    public string? KillerName { get; set; }
    public ulong? KillerId { get; set; }
    public byte? KillerTeamId { get; set; }
    public string? VictimName { get; set; }
    public ulong? VictimId { get; set; }
    public byte? VictimTeamId { get; set; }
    public string? Weapon { get; set; }
    public bool IsHeadshot { get; set; }
}

/// <summary>
/// Score change event.
/// </summary>
public class ScoreEvent : GameEvent
{
    public int Team0Score { get; set; }
    public int Team1Score { get; set; }
}

/// <summary>
/// Round state change event.
/// </summary>
public class RoundEvent : GameEvent
{
    public string? MatchState { get; set; }
    public int RoundNumber { get; set; }
    public float RoundTime { get; set; }
}

/// <summary>
/// Damage event when a player takes damage.
/// </summary>
public class DamageEvent : GameEvent
{
    public uint? VictimChannel { get; set; }
    public string? VictimName { get; set; }
    public uint? InstigatorChannel { get; set; }
    public string? InstigatorName { get; set; }
    public string? BoneName { get; set; }
    public FVector? Location { get; set; }
    public FVector? Direction { get; set; }
    public float? ImpulseForce { get; set; }
    public float? WoundRate { get; set; }
    public float? WoundScale { get; set; }
    public bool IsHeadshot { get; set; }
    public bool IsHelmetHit { get; set; }
}

/// <summary>
/// Bomb-related event (plant, defuse, detonate, etc.).
/// </summary>
public class BombEvent : GameEvent
{
    public string? BombAction { get; set; }
    public bool? IsPlanted { get; set; }
    public bool? IsDefused { get; set; }
    public bool? CodeSucceeded { get; set; }
}

/// <summary>
/// Grenade event (pin removed, lever released, detonation).
/// </summary>
public class GrenadeEvent : GameEvent
{
    public string? GrenadeAction { get; set; }
    public uint? GrenadeChannel { get; set; }
    public FVector? Location { get; set; }
}

/// <summary>
/// Weapon fire event.
/// </summary>
public class WeaponFireEvent : GameEvent
{
    public uint? WeaponChannel { get; set; }
    public uint? OwnerChannel { get; set; }
    public string? OwnerName { get; set; }
}

/// <summary>
/// Knife stab event.
/// </summary>
public class KnifeEvent : GameEvent
{
    public uint? AttackerChannel { get; set; }
    public string? AttackerName { get; set; }
    public uint? VictimChannel { get; set; }
    public string? VictimName { get; set; }
}

/// <summary>
/// Complete timeline export containing all time-series data from the replay.
/// </summary>
public class ReplayTimeline
{
    /// <summary>
    /// Replay file name.
    /// </summary>
    public string? FileName { get; set; }

    /// <summary>
    /// Total replay duration in seconds.
    /// </summary>
    public float Duration { get; set; }

    /// <summary>
    /// Game mode type.
    /// </summary>
    public string? GameMode { get; set; }

    /// <summary>
    /// Map name.
    /// </summary>
    public string? MapName { get; set; }

    /// <summary>
    /// Final team 0 score.
    /// </summary>
    public int FinalTeam0Score { get; set; }

    /// <summary>
    /// Final team 1 score.
    /// </summary>
    public int FinalTeam1Score { get; set; }

    /// <summary>
    /// All player timelines.
    /// </summary>
    public List<PawnTimeline> PawnTimelines { get; set; } = new();

    /// <summary>
    /// All game events in chronological order.
    /// </summary>
    public List<GameEvent> Events { get; set; } = new();

    /// <summary>
    /// Final player stats at end of replay.
    /// </summary>
    public List<PlayerData>? FinalPlayerStats { get; set; }
}
