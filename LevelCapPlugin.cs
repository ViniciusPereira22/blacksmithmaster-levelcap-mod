using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;

[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
public sealed class LevelCapPlugin : BaseUnityPlugin
{
    public const string PluginGuid = "vinic.blacksmithmaster.levelcap";
    public const string PluginName = "Blacksmith Master - Level Cap Mod";
    public const string PluginVersion = "1.1.0";

    internal static LevelCapPlugin Instance;

    private Harmony _harmony;

    private ConfigEntry<int> _defaultCap = null!;
    private ConfigEntry<int> _blacksmithCap = null!;
    private ConfigEntry<int> _minerCap = null!;
    private ConfigEntry<int> _cashierCap = null!;
    private ConfigEntry<int> _supportCap = null!;
    private ConfigEntry<int> _lumberjackCap = null!;
    private ConfigEntry<int> _scholarCap = null!;

    private void Awake()
    {
        Instance = this;
        BindConfig();

        _harmony = new Harmony(PluginGuid);
        _harmony.PatchAll();

        Logger.LogInfo($"{PluginName} loaded. Version={PluginVersion}");
    }

    private void OnDestroy()
    {
        if (_harmony != null)
        {
            _harmony.UnpatchSelf();
            _harmony = null;
        }
        if (ReferenceEquals(Instance, this))
        {
            Instance = null;
        }
    }

    private void BindConfig()
    {
        _defaultCap = Config.Bind("Level Caps", "DefaultCap", 20, "Fallback cap used when a staff type has no specific override.");
        _blacksmithCap = Config.Bind("Level Caps", "BlacksmithCap", 20, "Max level for Blacksmith.");
        _minerCap = Config.Bind("Level Caps", "MinerCap", 15, "Max level for Miner.");
        _cashierCap = Config.Bind("Level Caps", "CashierCap", 15, "Max level for Cashier.");
        _supportCap = Config.Bind("Level Caps", "SupportCap", 10, "Max level for Support.");
        _lumberjackCap = Config.Bind("Level Caps", "LumberjackCap", 20, "Max level for Lumberjack.");
        _scholarCap = Config.Bind("Level Caps", "ScholarCap", 15, "Max level for Scholar.");
    }

    internal int GetCapFor(TavernData.StaffType staffType)
    {
        int requested;
        switch (staffType)
        {
            case TavernData.StaffType.Blacksmith:
                requested = _blacksmithCap.Value;
                break;
            case TavernData.StaffType.Miner:
                requested = _minerCap.Value;
                break;
            case TavernData.StaffType.Cashier:
                requested = _cashierCap.Value;
                break;
            case TavernData.StaffType.Support:
                requested = _supportCap.Value;
                break;
            case TavernData.StaffType.Lumberjack:
                requested = _lumberjackCap.Value;
                break;
            case TavernData.StaffType.Scholar:
                requested = _scholarCap.Value;
                break;
            default:
                requested = _defaultCap.Value;
                break;
        }

        // Hard floor to avoid invalid config values breaking progression logic.
        return Mathf.Max(1, requested);
    }
}

[HarmonyPatch(typeof(TavernData.StaffInfo), "get_MaxLevel")]
internal static class StaffInfoMaxLevelPatch
{
    private static void Postfix(TavernData.StaffInfo __instance, ref int __result)
    {
        LevelCapPlugin plugin = LevelCapPlugin.Instance;
        if (plugin == null || __instance == null)
        {
            return;
        }

        int moddedCap = plugin.GetCapFor(__instance.Type);
        __result = moddedCap;
    }
}
