using System.Collections.Generic;
using Unreal.Core.Models;

namespace PavlovReplayReader.Models;

public class KillFeedEntry
{
    public uint? Killer { get; set; }
    public uint? Victim { get; set; }
    public string? DamageCauser { get; set; }
    public bool? bHeadshot { get; set; }
    public string? KillerName { get; set; }
    public int? KillerTeamId { get; set; }
    public uint? KillerId { get; set; }
    public string? VictimName { get; set; }
    public int? VictimTeamId { get; set; }
    public uint? VictimId { get; set; }
    public float? EntryLifespan { get; set; }
    public bool? bLocalPlayer { get; set; }
}
