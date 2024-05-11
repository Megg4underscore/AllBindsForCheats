using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace AllBindsForCheats
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("ULTRAKILL.exe")]
    public class Plugin : BaseUnityPlugin
    {
        private Harmony patch;
        private void Awake()
        {
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            patch = new Harmony(PluginInfo.PLUGIN_GUID);
            patch.PatchAll(typeof(Plugin));
            patch.PatchAll(typeof(BindPatch));
        }
    }

    public static class BindPatch
    {

        [HarmonyPatch(typeof(CheatBinds), "Awake"), HarmonyPrefix]
        static void AllBindsAllowed(ref string ___bannedBinds)
        {
            Debug.Log("ALL BINDS FOR CHEATS HAS BEEN APPLIED TO YOUR ULTRAKILL");
            ___bannedBinds = "";
        }
    }
}
