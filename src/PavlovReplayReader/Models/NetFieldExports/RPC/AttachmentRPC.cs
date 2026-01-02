using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models.Enums;

namespace PavlovReplayReader.Models.NetFieldExports.RPC;

#region Attachment ClassNetCache

/// <summary>
/// ClassNetCache for Suppressor_Pistol attachment.
/// Path: /Game/Attachments/Suppressor/Suppressor_Pistol.Suppressor_Pistol_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("/Game/Attachments/Suppressor/Suppressor_Pistol.Suppressor_Pistol_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class SuppressorPistolCache
{
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRAttachment:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Suppressor_Rifle attachment.
/// Path: /Game/Attachments/Suppressor/Suppressor_Rifle.Suppressor_Rifle_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("/Game/Attachments/Suppressor/Suppressor_Rifle.Suppressor_Rifle_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class SuppressorRifleCache
{
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRAttachment:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Sight_ACOG attachment.
/// Path: /Game/Attachments/Scope/Sight_ACOG.Sight_ACOG_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("/Game/Attachments/Scope/Sight_ACOG.Sight_ACOG_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class SightACOGCache
{
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRAttachment:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Sight_RedDot attachment.
/// Path: /Game/Attachments/Scope/Sight_RedDot.Sight_RedDot_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("/Game/Attachments/Scope/Sight_RedDot.Sight_RedDot_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class SightRedDotCache
{
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRAttachment:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Grip_Vertical attachment.
/// Path: /Game/Attachments/Grip/Grip_Vertical.Grip_Vertical_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("/Game/Attachments/Grip/Grip_Vertical.Grip_Vertical_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class GripVerticalCache
{
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRAttachment:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

/// <summary>
/// ClassNetCache for Grip_Angled attachment.
/// Path: /Game/Attachments/Grip/Grip_Angled.Grip_Angled_C_ClassNetCache
/// </summary>
[NetFieldExportClassNetCache("/Game/Attachments/Grip/Grip_Angled.Grip_Angled_C_ClassNetCache", minimalParseMode: ParseMode.Minimal)]
public class GripAngledCache
{
    [NetFieldExportRPC("MulticastStateSanityCheck", "/Script/VRFramework.VRAttachment:MulticastStateSanityCheck", isFunction: true)]
    public object? MulticastStateSanityCheck { get; set; }
}

#endregion
