using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

//[NetFieldExportClassNetCache("PavlovPlayerState_ClassNetCache", minimalParseMode: ParseMode.Debug)]
//public class PavlovPlayerStateCache
//{
//    [NetFieldExportRPC("DestroyPavTVItem", "/Script/Pavlov.PavlovPlayerState:DestroyPavTVItem", isFunction: true)]
//    public DestroyPavTVItem DestroyPavTVItem { get; set; }
//}

[NetFieldExportGroup("/Script/Pavlov.PavlovPlayerState", minimalParseMode: ParseMode.Minimal)]
public class PavlovPlayerState : INetFieldExportGroup
{
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public int? RemoteRole { get; set; }

    [NetFieldExport("Owner", RepLayoutCmdType.Ignore)]
    public uint? Owner { get; set; }

    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public int? Role { get; set; }

    [NetFieldExport("Score", RepLayoutCmdType.PropertyUInt32)]
    public uint? Score { get; set; }

    [NetFieldExport("PlayerId", RepLayoutCmdType.PropertyInt)]
    public int? PlayerId { get; set; }

    [NetFieldExport("CompressedPing", RepLayoutCmdType.Ignore)]
    public int? CompressedPing { get; set; }

    [NetFieldExport("bOnlySpectator", RepLayoutCmdType.PropertyBool)]
    public bool? bOnlySpectator { get; set; }

    [NetFieldExport("StartTime", RepLayoutCmdType.PropertyInt)]
    public int? StartTime { get; set; }

    [NetFieldExport("UniqueID", RepLayoutCmdType.PropertyNetId)]
    public string UniqueID { get; set; }

    [NetFieldExport("PlayerNamePrivate", RepLayoutCmdType.PropertyString)]
    public string PlayerNamePrivate { get; set; }

    [NetFieldExport("TeamId", RepLayoutCmdType.PropertyInt)]
    public int? TeamId { get; set; }

    [NetFieldExport("Kills", RepLayoutCmdType.PropertyInt)]
    public int? Kills { get; set; }

    [NetFieldExport("Deaths", RepLayoutCmdType.PropertyInt)]
    public int? Deaths { get; set; }

    [NetFieldExport("Assists", RepLayoutCmdType.PropertyInt)]
    public int? Assists { get; set; }

    [NetFieldExport("Cash", RepLayoutCmdType.PropertyInt)]
    public int? Cash { get; set; }

    [NetFieldExport("PlatformId", RepLayoutCmdType.Ignore)]
    public int? PlatformId { get; set; }

    [NetFieldExport("bDead", RepLayoutCmdType.PropertyBool)]
    public bool? bDead { get; set; }

    [NetFieldExport("PlayerHeight", RepLayoutCmdType.PropertyFloat)]
    public float? PlayerHeight { get; set; }

    [NetFieldExport("bRightHanded", RepLayoutCmdType.PropertyBool)]
    public bool? bRightHanded { get; set; }

    [NetFieldExport("bVirtualStock", RepLayoutCmdType.PropertyBool)]
    public bool? bVirtualStock { get; set; }

    [NetFieldExport("bSpeaking", RepLayoutCmdType.PropertyBool)]
    public bool? bSpeaking { get; set; }

    [NetFieldExport("LifetimeTeamKillCount", RepLayoutCmdType.PropertyInt)]
    public int? LifetimeTeamKillCount { get; set; }

    [NetFieldExport("SkinOverride", RepLayoutCmdType.PropertyString)]
    public string? SkinOverride { get; set; }
}
