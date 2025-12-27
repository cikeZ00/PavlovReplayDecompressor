namespace PavlovReplayReader.Models.Enums;

/// <summary>
/// Game mode types available in Pavlov VR.
/// </summary>
public enum EPavlovGameModeType : byte
{
    Custom = 0,
    Deathmatch = 1,
    TeamDeathmatch = 2,
    SearchAndDestroy = 3,
    LastManStanding = 4,
    Siege = 5,
    GunGame = 6,
    CaptureTheFlag = 7,
    TTT = 8,
    Jailbreak = 9,
    ZombieCoop = 10,
    TheHidden = 11,
    Push = 12,
    PropHunt = 13,
    OITC = 14,
    Infection = 15,
    Hunt = 16,
    Tutorial = 17,
    None = 18,
    KOTH = 19,
    TankTDM = 20,
    WW2GunGame = 21,
    KillHouse = 22
}

/// <summary>
/// Competitive mode settings.
/// </summary>
public enum ECompetitiveMode : byte
{
    Disabled = 0,
    Normal = 1,
    Enhanced = 2
}

/// <summary>
/// Holiday/seasonal events.
/// </summary>
public enum EHolidays : byte
{
    None = 0,
    AprilFools = 1,
    Halloween = 2,
    Xmas = 3
}

/// <summary>
/// Match result outcomes.
/// </summary>
public enum EMatchResult : byte
{
    Victory = 0,
    Defeat = 1,
    Draw = 2
}

/// <summary>
/// Match types for different game configurations.
/// </summary>
public enum EMatchType : byte
{
    Normal = 0,
    NormalWithBots = 1,
    Coop = 2
}

/// <summary>
/// Player flair badges.
/// </summary>
public enum EPlayerFlair : byte
{
    None = 0,
    Patron = 1,
    Moderator = 2,
    Tester = 3,
    Developer = 4
}

/// <summary>
/// Player platform/device types.
/// </summary>
public enum EPlayerPlatform : byte
{
    STEAM = 0,
    PSN = 1,
    OCULUS = 2,
    NONE = 99
}

/// <summary>
/// Device types for Shack version (Quest/standalone).
/// </summary>
public enum EShackDeviceType : byte
{
    None = 0,
    OculusQuest = 1,
    OculusQuest2 = 2,
    OculusQuestPro = 3,
    OculusQuest3 = 4,
    HTCSunrise = 5,
    PSVR2 = 6,
    PC = 7
}

/// <summary>
/// Bomb state for Search and Destroy mode.
/// </summary>
public enum EBombState : byte
{
    StandBy = 0,
    Armed = 1,
    Planted = 2,
    Detonating = 3,
    Detonated = 4,
    Defused = 5
}

/// <summary>
/// Grenade states.
/// </summary>
public enum EGrenadeState : byte
{
    SafeWithPin = 0,
    Safe = 1,
    Cooking = 2,
    Detonated = 3
}

/// <summary>
/// Grenade types.
/// </summary>
public enum EGrenadeType : byte
{
    Grenade = 0,
    Smoke = 1,
    Flash = 2,
    Other = 3
}

/// <summary>
/// Player effect states for visual/audio effects.
/// </summary>
public enum EPlayerEffectState : byte
{
    Normal = 0,
    Flashed = 1,
    FlashedVision = 2,
    Supressed = 3,
    Ghost = 4,
    Tank = 5
}

/// <summary>
/// Vehicle damage states.
/// </summary>
public enum EVehicleDamageState : byte
{
    Normal = 0,
    Light = 1,
    Medium = 2,
    Heavy = 3,
    Critical = 4,
    Destroyed = 5
}

/// <summary>
/// Hill states for King of the Hill mode.
/// </summary>
public enum EHillState : byte
{
    Inactive = 0,
    ActiveNeutral = 1,
    ActiveTeam0 = 2,
    ActiveTeam1 = 3
}

/// <summary>
/// Launcher state for rocket/grenade launchers.
/// </summary>
public enum ELauncherState : byte
{
    Unloaded = 0,
    Loaded = 1,
    Cocked = 2
}

/// <summary>
/// Two-hand stock states for rifles.
/// </summary>
public enum ETwoHandStockState : byte
{
    Unstocked = 0,
    Stocking = 1,
    Stocked = 2,
    Destocking = 3
}

/// <summary>
/// Weapon filter for game mode restrictions.
/// </summary>
public enum EWeaponFilter : byte
{
    None = 0,
    RiflesOnly = 1,
    HandGunsOnly = 2,
    KnivesOnly = 3,
    GrenadesOnly = 4
}

/// <summary>
/// Hit feedback types for damage indication.
/// </summary>
public enum EHitFeedbackType : byte
{
    Body = 0,
    BodyArmor = 1,
    Helmet = 2,
    Headshot = 3
}

/// <summary>
/// Parachute states for Battlegrounds mode.
/// </summary>
public enum EParachuteState : byte
{
    Packed = 0,
    Deploying = 1,
    Deployed = 2,
    Ditched = 3
}

/// <summary>
/// Match states.
/// </summary>
public enum EMatchState : byte
{
    NoMatch = 0,
    CreatingMatch = 1,
    Waiting = 2,
    Playing = 3,
    OnHold = 4,
    Cancelled = 5,
    Completed = 6
}

/// <summary>
/// Killhouse door states.
/// </summary>
public enum EKillhouseDoorState : byte
{
    Waiting = 0,
    Closed = 1,
    Open = 2
}

/// <summary>
/// Killhouse overall state.
/// </summary>
public enum EKillhouseState : byte
{
    Staging = 0,
    Playing = 1,
    Complete = 2
}

/// <summary>
/// Killhouse target states.
/// </summary>
public enum EKillhouseTargetState : byte
{
    Inactive = 0,
    Waiting = 1,
    Active = 2,
    TargetDown = 3,
    Down = 4
}

/// <summary>
/// Killhouse target types.
/// </summary>
public enum EKillhouseTargetType : byte
{
    None = 0,
    Threat = 1,
    Friendly = 2,
    Hostage = 3
}

/// <summary>
/// KOTH capture states.
/// </summary>
public enum EKOTHCaptureState : byte
{
    Enemy = 0,
    Neutral = 1,
    Friendly = 2
}

/// <summary>
/// Mine types.
/// </summary>
public enum EMineType : byte
{
    None = 0,
    AntiTankMine = 1,
    AntiPersonnelMine = 2
}

/// <summary>
/// Push mode hip slot items.
/// </summary>
public enum EPushHipSlot : byte
{
    None = 0,
    Knife = 1,
    Medkit = 2,
    AmmoCrate = 3,
    RepairTool = 4
}

/// <summary>
/// TTT roles.
/// </summary>
public enum ETTTRole : byte
{
    Innocent = 0,
    Traitor = 1,
    Detective = 2,
    Spectator = 3
}

/// <summary>
/// Gore severity levels.
/// </summary>
public enum EVGoreSeverity : byte
{
    None = 0,
    Small = 1,
    Medium = 2,
    Large = 3,
    Shotgun = 4
}

/// <summary>
/// Vote states.
/// </summary>
public enum EVoteState : byte
{
    Voting = 0,
    Succeed = 1,
    Failed = 2
}

/// <summary>
/// Mod types.
/// </summary>
public enum EModType : byte
{
    Map = 0,
    Mod = 1,
    GameMode = 2
}

/// <summary>
/// Game difficulty levels.
/// </summary>
public enum EGameDifficulty : byte
{
    Easy = 0,
    Normal = 1,
    Hard = 2
}

/// <summary>
/// Online regions.
/// </summary>
public enum EOnlineRegion : byte
{
    America = 0,
    Europe = 1,
    AsiaPacific = 2
}

/// <summary>
/// Finger types for hand tracking.
/// </summary>
public enum EFinger : byte
{
    Index = 0,
    Middle = 1,
    Ring = 2,
    Pinky = 3,
    Thumb = 4
}

/// <summary>
/// Pliers state for bomb defusal.
/// </summary>
public enum EPliersState : byte
{
    Standby = 0,
    Cutting = 1,
    Cut = 2
}

/// <summary>
/// Skin filter types.
/// </summary>
public enum ESkinFilterType : byte
{
    Pistol = 0,
    Smg = 1,
    Rifle = 2,
    Heavy = 3,
    Knife = 4,
    Gear = 5,
    Charm = 6,
    Bundle = 7
}

/// <summary>
/// Skin family/collection types.
/// </summary>
public enum ESkinFamily : byte
{
    Default = 0,
    Patreon = 1,
    Developer = 2,
    QA = 3,
    Glacial = 4,
    Billibong = 5,
    Rekt = 6,
    Royalty = 7,
    DragonGolden = 8,
    DragonPapyrus = 9,
    WaveTrip = 10,
    Scifi = 11,
    Massacre = 12,
    Circuit = 13,
    Jungle = 14,
    Wargo = 15,
    Tester = 16
}

/// <summary>
/// Player stats categories.
/// </summary>
public enum EPlayerStats : byte
{
    Kill = 0,
    Death = 1,
    Assist = 2,
    Headshot = 3,
    TeamKill = 4,
    BombDefused = 5,
    BombPlanted = 6,
    ChickenKilled = 7,
    Experience = 8,
    Karma = 9,
    ELO = 10,
    BotKill = 11,
    RoundWin = 12,
    GameWin = 13,
    ZombieKill = 14
}
