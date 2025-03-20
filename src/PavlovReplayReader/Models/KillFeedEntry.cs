using System.Collections.Generic;
using Unreal.Core.Models;

namespace PavlovReplayReader.Models;

public class KillFeedEntry
{
    public int? Killer { get; set; }
    public int? Victim { get; set; }
    public int? DamageCauser { get; set; }
    public bool bHeadshot { get; set; }
    public string? KillerName { get; set; }
    public int? KillerTeamId { get; set; }
    public int? KillerId { get; set; }
    public string? VictimName { get; set; }
    public int? VictimTeamId { get; set; }
    public int? VictimId { get; set; }
    public float? EntryLifespan { get; set; }
    public bool bLocalPlayer { get; set; }
}
