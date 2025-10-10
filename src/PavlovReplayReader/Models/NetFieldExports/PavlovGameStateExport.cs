using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports;

[NetFieldExportGroup("/Script/Pavlov.PavlovGameState", minimalParseMode: ParseMode.Minimal)]
public class PavlovGameStateExport : INetFieldExportGroup
{
    [NetFieldExport("bNoTeams", RepLayoutCmdType.PropertyBool)]
    public bool? bNoTeams { get; set; }

    [NetFieldExport("bMovementDisabled", RepLayoutCmdType.PropertyBool)]
    public bool? bMovementDisabled { get; set; }

    [NetFieldExport("bNoFallDamage", RepLayoutCmdType.PropertyBool)]
    public bool? bNoFallDamage { get; set; }

    [NetFieldExport("bLimitedAmmo", RepLayoutCmdType.PropertyBool)]
    public bool? bLimitedAmmo { get; set; }

    [NetFieldExport("Team0Score", RepLayoutCmdType.PropertyInt)]
    public int? Team0Score { get; set; }

    [NetFieldExport("Team1Score", RepLayoutCmdType.PropertyInt)]
    public int? Team1Score { get; set; }

    [NetFieldExport("RoundDuration", RepLayoutCmdType.PropertyInt)]
    public int? RoundDuration { get; set; }

    [NetFieldExport("RoundTime", RepLayoutCmdType.PropertyInt)]
    public int? RoundTime { get; set; }

    [NetFieldExport("PauseTime", RepLayoutCmdType.PropertyInt)]
    public int? PauseTime { get; set; }

    [NetFieldExport("AttackingTeam", RepLayoutCmdType.PropertyInt)]
    public int? AttackingTeam { get; set; }

    [NetFieldExport("RoundWinner", RepLayoutCmdType.PropertyInt)]
    public int? RoundWinner { get; set; }

    [NetFieldExport("RoundsLeft", RepLayoutCmdType.PropertyInt)]
    public int? RoundsLeft { get; set; }

    [NetFieldExport("bMatchTimePaused", RepLayoutCmdType.PropertyBool)]
    public bool? bMatchTimePaused { get; set; }

    [NetFieldExport("MatchTime", RepLayoutCmdType.PropertyFloat)]
    public float? MatchTime { get; set; }

    [NetFieldExport("bShowNameTags", RepLayoutCmdType.PropertyBool)]
    public bool? bShowNameTags { get; set; }

    [NetFieldExport("CompetitiveMode", RepLayoutCmdType.Enum)]
    public int? CompetitiveMode { get; set; }

    [NetFieldExport("bPreventGrenadePin", RepLayoutCmdType.PropertyBool)]
    public bool? bPreventGrenadePin { get; set; }

    [NetFieldExport("bEnableProne", RepLayoutCmdType.PropertyBool)]
    public bool? bEnableProne { get; set; }

    [NetFieldExport("bCanReviveEnemies", RepLayoutCmdType.PropertyBool)]
    public bool? bCanReviveEnemies { get; set; }

    [NetFieldExport("GameModeType", RepLayoutCmdType.Enum)]
    public int? GameModeType { get; set; }

    [NetFieldExport("AFKTimeLimit", RepLayoutCmdType.PropertyInt)]
    public int? AFKTimeLimit { get; set; }

    [NetFieldExport("bCanSwitchTeams", RepLayoutCmdType.PropertyBool)]
    public bool? bCanSwitchTeams { get; set; }

    [NetFieldExport("BuyMenuScript", RepLayoutCmdType.PropertyString)]
    public string? BuyMenuScript { get; set; }

    [NetFieldExport("BalancingCSV", RepLayoutCmdType.PropertyString)]
    public string? BalancingCSV { get; set; }

    [NetFieldExport("ModdedItemEquipmentIndex", RepLayoutCmdType.PropertyInt)]
    public int? ModdedItemEquipmentIndex { get; set; }

    [NetFieldExport("MaxPlayers", RepLayoutCmdType.PropertyInt)]
    public int? MaxPlayers { get; set; }

    [NetFieldExport("bPinProtected", RepLayoutCmdType.PropertyBool)]
    public bool? bPinProtected { get; set; }

    [NetFieldExport("Holiday", RepLayoutCmdType.Enum)]
    public int? Holiday { get; set; }

    [NetFieldExport("bCanAutoEjectVehicles", RepLayoutCmdType.PropertyBool)]
    public bool? bCanAutoEjectVehicles { get; set; }

    // Note: The following properties are available in the dump but require special handling:
    // - TempPlayerArray (ArrayProperty) - Array of player references
    // - EquipmentDataByClassMap (MapProperty) - Equipment data mapping
    // - PreloadedSkins (MapProperty) - Skin preloading data
    // - Settings (StructProperty) - Game settings structure
    // - EquipmentCosts (ObjectProperty) - Equipment cost object
    // - ScoreboardClass (ClassProperty) - Scoreboard class reference
    // - HandMenuClass (ClassProperty) - Hand menu class reference
    // - NameTagClass (ClassProperty) - Name tag class reference
    // - BuyRestrictions (StructProperty) - Buy menu restrictions
    // - EquipmentMap (MapProperty) - Equipment mapping
    // - ModdedBuyMenuItems (MapProperty) - Modded buy menu items
    // - ModdedTTTBuyMenuItems (ArrayProperty) - TTT mode buy items
    // - DisabledBuyMenuItems (ArrayProperty) - Disabled buy menu items
    // - CustomSkins (MapProperty) - Custom skin mapping
    // - SpawnableEquipment (ArrayProperty) - Equipment that can spawn
    // - VehicleInfoMap (MapProperty) - Vehicle information
    // - LootMeshes (MapProperty) - Loot mesh mapping
    // - AvatarSkinTable (ObjectProperty) - Avatar skin table object
    // - AvatarSkinClasses (MapProperty) - Avatar skin class mapping
    // - EquipmentIndexCache (ArrayProperty) - Equipment index cache
    // - Killfeed (ArrayProperty) - Kill feed entries
    // - CosmeticTickManager (ObjectProperty) - Cosmetic tick manager
    // - AsyncLoader (ObjectProperty) - Async loader object
    // - OnKillfeedEntry (MulticastInlineDelegateProperty) - Killfeed event delegate
    // - ModInitializers (ArrayProperty) - Mod initializer array
    // - GlobalInfo (ObjectProperty) - Global info object
    // - NameTagPool (ArrayProperty) - Name tag object pool
    // - OfflineModUGCs (ArrayProperty) - Offline mod UGC IDs
}

