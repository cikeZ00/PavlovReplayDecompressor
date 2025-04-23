using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;
using System;

namespace PavlovReplayReader.Models.NetFieldExports.RPC
{
    [NetFieldExportClassNetCache("VoiceRouter_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
    public class VoiceRouterCache
    {
        [NetFieldExportRPC("ReplayOnVoiceBunch_Client", "/Script/Pavlov.VoiceRouter:ReplayOnVoiceBunch_Client", isFunction: true)]
        public ReplayOnVoiceBunch_Client ReplayOnVoiceBunch_Client { get; set; }
        
        [NetFieldExportRPC("ClientOnVoiceBunch", "/Script/Pavlov.VoiceRouter:ClientOnVoiceBunch", isFunction: true)]
        public ClientOnVoiceBunch ClientOnVoiceBunch { get; set; }
    }

    [NetFieldExportGroup("/Script/Pavlov.VoiceRouter:ReplayOnVoiceBunch_Client", minimalParseMode: ParseMode.Full)]
    public class ReplayOnVoiceBunch_Client : INetFieldExportGroup
    {
        [NetFieldExport("Players", RepLayoutCmdType.DynamicArray)]
        public int[] PlayerIndices { get; set; }

        [NetFieldExport("Players1", RepLayoutCmdType.DynamicArray)]
        public int[] PlayerIndices1 { get; set; }

        [NetFieldExport("Packets",  RepLayoutCmdType.DynamicArray)]
        public byte[] Packets { get; set; }
        
        [NetFieldExport("Packets1", RepLayoutCmdType.DynamicArray)]
        public byte[] Packets1 { get; set; }

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

        [NetFieldExport("Players1", RepLayoutCmdType.DynamicArray)]
        public int[] PlayerIndices1 { get; set; }

        [NetFieldExport("Packets", RepLayoutCmdType.DynamicArray)]
        public byte[][] Packets { get; set; }

        [NetFieldExport("Packets1", RepLayoutCmdType.DynamicArray)]
        public byte[][] Packets1 { get; set; }

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