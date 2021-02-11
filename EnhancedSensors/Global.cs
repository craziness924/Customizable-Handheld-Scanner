using HarmonyLib;
using System;
using UnityEngine;

namespace EnhancedScanner
{
    class Global
    {
        public static string hostilehex = "ff0000";
        public static string crewhex = "00ff00";
        public static string npchex = "ffffff";
        public static string doorhex = "6666ff";
        public static string teleporterhex = "ff00ff";
        public static string itemhex = "FFFF00";
        public static string researchhex = "44FFFF";
       
        /* commented out until use is found 
        public static bool a = ColorUtility.TryParseHtmlString("ffffff", out Color h);
        public static Color GetColor(string hexstring)
        {
            bool a = ColorUtility.TryParseHtmlString(hexstring, out Color h);
            return h;
        }
        */
        public static string Walter() //changes all the color values for the key, besides items and scanner
        {
            return $"[{hostilehex}](*) HOSTILE[-]\n[{crewhex}](*) CREW[-]\n[{npchex}](*) NPC[-]\n[{doorhex}](*) DOOR[-]\n[{teleporterhex}](*) TELEPORTER[-]";
        }
        public static string ItemKey()
        {
            return $"\n[{itemhex}](*) PICKUPS[-]"; 
        }
        public static string ResearchKey()
        {
            return $"\n[{researchhex}](*) RESEARCH MATS[-]";
        }
        public static Color hostilergb()
        {
            return NGUIText.ParseColor24(hostilehex, 0);
        }
        public static Color crewrgb()
        {
            return NGUIText.ParseColor24(crewhex, 0);
        }
        public static Color npcrgb()
        {
            return NGUIText.ParseColor24(npchex, 0);
        }
        public static Color doorrgb()
        {
            return NGUIText.ParseColor24(doorhex, 0);
        }
        public static Color teleporterrgb()
        {
            return NGUIText.ParseColor24(teleporterhex, 0);
        }
        public static Color itemrgb()
        {
            return NGUIText.ParseColor24(itemhex, 0);
        }
        public static Color researchrgb()
        {
            return NGUIText.ParseColor24(researchhex, 0);
        }
    }
    [HarmonyPatch(typeof(PLServer), "Start")]
    class LoadPatch
    {
        static void Postfix()
        {
            string[] settings = PLXMLOptionsIO.Instance.CurrentOptions.GetStringValue("EnhancedHandheldScannerSettings").Split(' ');
            if (settings.Length > 7)
            {
                Global.hostilehex = settings[0];
                Global.crewhex = settings[1];
                Global.npchex = settings[2];
                Global.doorhex = settings[3];
                Global.teleporterhex = settings[4];
                Global.itemhex = settings[5];
                Global.researchhex = settings[6];
            }
            else
            {
                PulsarPluginLoader.Utilities.Logger.Info("Failed to load EnhancedHandheldScanner settings, or settings left on default!");
            }
            
        }


    }
}
