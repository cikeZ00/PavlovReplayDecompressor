using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;
using System;

namespace PavlovReplayReader.Models.NetFieldExports.RPC
{
    [NetFieldExportGroup("/Script/Pavlov.VoiceRouter:ReplayOnVoiceBunch_Client", minimalParseMode: ParseMode.Full)]
    public class ReplayOnVoiceBunch_Client : INetFieldExportGroup
    {
        [NetFieldExport("Players", RepLayoutCmdType.DynamicArray)]
        public int[] PlayerIndices { get; set; }

        [NetFieldExport("Packets", RepLayoutCmdType.DynamicArray)]
        public byte[][] Packets { get; set; }

        [NetFieldExport("TimeSeconds", RepLayoutCmdType.PropertyFloat)]
        public float TimeSeconds { get; set; }

        public bool ContainsPlayer(int playerIndex)
        {
            if (PlayerIndices == null)
                return false;

            foreach (var idx in PlayerIndices)
            {
                if (idx == playerIndex)
                    return true;
            }

            return false;
        }
    }

    [NetFieldExportGroup("/Script/Pavlov.VoiceRouter:ClientOnVoiceBunch", minimalParseMode: ParseMode.Full)]
    public class ClientOnVoiceBunch : INetFieldExportGroup
    {
        [NetFieldExport("Players", RepLayoutCmdType.DynamicArray)]
        public int[] PlayerIndices { get; set; }

        [NetFieldExport("Packets", RepLayoutCmdType.DynamicArray)]
        public byte[][] Packets { get; set; }

        [NetFieldExport("TimeSeconds", RepLayoutCmdType.PropertyFloat)]
        public float TimeSeconds { get; set; }

        public bool ContainsPlayer(int playerIndex)
        {
            if (PlayerIndices == null)
                return false;

            foreach (var idx in PlayerIndices)
            {
                if (idx == playerIndex)
                    return true;
            }

            return false;
        }
    }
}