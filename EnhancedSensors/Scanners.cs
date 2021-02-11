using HarmonyLib;
using PulsarPluginLoader.Patches;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

namespace EnhancedScanner
{
    public class Sensors
    {
        [HarmonyPatch(typeof(PLPawnItem_Scanner), MethodType.Constructor)]
        internal class ZoomPatch
        {
            private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                List<CodeInstruction> TargetSequence = new List<CodeInstruction>() //changes the alarm siren threshold for shields
            {
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldc_I4_3),
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PLPawnItem_Scanner), "MaxZoomLevel")),
            };
                List<CodeInstruction> InjectedSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldc_I4_5),
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PLPawnItem_Scanner), "MaxZoomLevel")),
            };
                return HarmonyHelpers.PatchBySequence(instructions, TargetSequence, InjectedSequence, HarmonyHelpers.PatchMode.REPLACE);
            }
        }
        [HarmonyPatch(typeof(PLScanner), "Update")]
        internal class ColorKeyPatch
        {
            private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                List<CodeInstruction> TargetSequence = new List<CodeInstruction>() //changes the color key on the scanner for all but the 
            {
                new CodeInstruction(OpCodes.Stloc_0),
                new CodeInstruction(OpCodes.Ldsfld, AccessTools.Field(typeof(PLNetworkManager), "Instance")),
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLNetworkManager), "ViewedPawn"))
            };
                List<CodeInstruction> InjectedSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Global), "Walter")),
                new CodeInstruction(OpCodes.Stloc_0),
            };
                IEnumerable<CodeInstruction> itemkeycolor = HarmonyHelpers.PatchBySequence(instructions, TargetSequence, InjectedSequence, HarmonyHelpers.PatchMode.AFTER);
                TargetSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldstr, "\n[FFFF00](*) PICKUPS[-]")
            };
                InjectedSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Global),"ItemKey")),
            };
                IEnumerable<CodeInstruction> researchkeycolor = HarmonyHelpers.PatchBySequence(itemkeycolor, TargetSequence, InjectedSequence, HarmonyHelpers.PatchMode.REPLACE);
                TargetSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldstr, "\n[44FFFF](*) RESEARCH MATS[-]")
            };
                InjectedSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Global),"ResearchKey")),
            };
                IEnumerable<CodeInstruction> teleporterblip = HarmonyHelpers.PatchBySequence(researchkeycolor, TargetSequence, InjectedSequence, HarmonyHelpers.PatchMode.REPLACE);
                TargetSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldc_R4, 1f),
                new CodeInstruction(OpCodes.Ldc_R4, 0f),
                new CodeInstruction(OpCodes.Ldc_R4, 1f),
                new CodeInstruction(OpCodes.Newobj)
            };
                InjectedSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Global),"teleporterrgb")),
            };
                IEnumerable<CodeInstruction> crewblip = HarmonyHelpers.PatchBySequence(teleporterblip, TargetSequence, InjectedSequence, HarmonyHelpers.PatchMode.REPLACE, HarmonyHelpers.CheckMode.NONNULL);
                TargetSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Color), "get_green")),
            };
                InjectedSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Global),"crewrgb")),
            };
                IEnumerable<CodeInstruction> hostileblip1 = HarmonyHelpers.PatchBySequence(crewblip, TargetSequence, InjectedSequence, HarmonyHelpers.PatchMode.REPLACE);
                TargetSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Color), "get_red")),
            };
                InjectedSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Global),"hostilergb")),
            };
                IEnumerable<CodeInstruction> hostileblip2 = HarmonyHelpers.PatchBySequence(hostileblip1, TargetSequence, InjectedSequence, HarmonyHelpers.PatchMode.REPLACE);
                TargetSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Color), "get_red")),
            };
                InjectedSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Global),"hostilergb")),
            };
                IEnumerable<CodeInstruction> itemblip1 = HarmonyHelpers.PatchBySequence(hostileblip2, TargetSequence, InjectedSequence, HarmonyHelpers.PatchMode.REPLACE);
                TargetSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Color), "get_yellow")),
            };
                InjectedSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Global),"itemrgb")),
            };
                IEnumerable<CodeInstruction> itemblip2 = HarmonyHelpers.PatchBySequence(itemblip1, TargetSequence, InjectedSequence, HarmonyHelpers.PatchMode.REPLACE);
                TargetSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Color), "get_yellow")),
            };
                InjectedSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Global),"itemrgb")),
            };
                IEnumerable<CodeInstruction> itemblip3 = HarmonyHelpers.PatchBySequence(itemblip2, TargetSequence, InjectedSequence, HarmonyHelpers.PatchMode.REPLACE);
                TargetSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Color), "get_yellow")),
            };
                InjectedSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Global),"itemrgb")),
            };
                IEnumerable<CodeInstruction> researchblip = HarmonyHelpers.PatchBySequence(itemblip3, TargetSequence, InjectedSequence, HarmonyHelpers.PatchMode.REPLACE);
                TargetSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldc_R4, .2f),
                new CodeInstruction(OpCodes.Ldc_R4, 1f),
                new CodeInstruction(OpCodes.Ldc_R4, 1f),
                new CodeInstruction(OpCodes.Newobj)
            };
                InjectedSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Global),"researchrgb")),
            };
                IEnumerable<CodeInstruction> doorblip = HarmonyHelpers.PatchBySequence(researchblip, TargetSequence, InjectedSequence, HarmonyHelpers.PatchMode.REPLACE, HarmonyHelpers.CheckMode.NONNULL);
                TargetSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Color), "get_blue")),
            };
                InjectedSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Global),"doorrgb")),
            };
                IEnumerable<CodeInstruction> npcblip = HarmonyHelpers.PatchBySequence(doorblip, TargetSequence, InjectedSequence, HarmonyHelpers.PatchMode.REPLACE);
                TargetSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Color), "get_white")),
            };
                InjectedSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Global),"npcrgb")),
            };
                return HarmonyHelpers.PatchBySequence(npcblip, TargetSequence, InjectedSequence, HarmonyHelpers.PatchMode.REPLACE, HarmonyHelpers.CheckMode.NONNULL);
            }
        }
    }
}
