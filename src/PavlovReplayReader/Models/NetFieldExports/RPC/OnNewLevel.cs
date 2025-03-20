using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports.RPC;

[NetFieldExportGroup("/Script/FortniteGame.PavlovPlayerStateAthena:Client_OnNewLevel", minimalParseMode: ParseMode.Debug)]
public class OnNewLevel : INetFieldExportGroup
{
    [NetFieldExport("NewLevel", RepLayoutCmdType.PropertyInt)]
    public int NewLevel { get; set; }
}
