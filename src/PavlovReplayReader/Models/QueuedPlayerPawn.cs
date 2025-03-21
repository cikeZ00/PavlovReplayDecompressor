using PavlovReplayReader.Models.NetFieldExports;

namespace PavlovReplayReader.Models;

public class QueuedPlayerPawn
{
    public uint ChannelId { get; set; }
    public PlayerPawn PlayerPawn { get; set; }
}