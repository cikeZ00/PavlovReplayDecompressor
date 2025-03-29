using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports

{
    // /Script/Pavlov.VoiceRouter
    [NetFieldExportGroup("/Script/Pavlov.VoiceRouter", minimalParseMode: ParseMode.Minimal)]
    public class VoiceRouter : INetFieldExportGroup
    {
        [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
        public object RemoteRole { get; set; }

        [NetFieldExport("Owner", RepLayoutCmdType.Ignore)]
        public ActorGuid Owner { get; set; }

        [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
        public object Role { get; set; }
    }
}