using PavlovReplayReader.Models.NetFieldExports;
using Unreal.Core.Models;

namespace PavlovReplayReader.Models;

public class Llama
{
    public Llama()
    {

    }

    public Llama(uint channelIndex, SupplyDropLlama drop)
    {
        Id = channelIndex;
        Looted = drop.Looted;
        LandingLocation = drop.FinalDestination;
        Location = drop.ReplicatedMovement?.Location;
        HasSpawnedPickups = drop.bHasSpawnedPickups;
    }

    public uint Id { get; set; }
    public FVector? Location { get; set; }
    public bool HasSpawnedPickups { get; set; }
    public bool Looted { get; set; }
    public float? LootedTime { get; set; }
    public double? LootedTimeDouble { get; set; }
    public FVector? LandingLocation { get; set; }
}
