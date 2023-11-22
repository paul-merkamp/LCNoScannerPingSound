using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Diagnostics;

namespace LCNoScannerPingSound
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private Harmony harmony;

        public void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            harmony = new Harmony("LCNoScannerPingSound");
            harmony.PatchAll();
        }

        [HarmonyLib.HarmonyPatch(typeof(HUDManager), "Awake")]
        public class HUDManager_Awake_Patch
        {
            static void Postfix(HUDManager __instance)
            {
                __instance.scanSFX = null;
            }
        }
    }
}