using PulsarPluginLoader.Chat.Commands;
using PulsarPluginLoader.Utilities;
using UnityEngine;
//colorblind command, value reset command, values command, command that sets each type of blip color
namespace EnhancedScanner
{
    class Commands : IChatCommand
    {
        public string[] CommandAliases()
        {
            return new string[] { "cuscanner", "customscanner" };
        }

        public string Description()
        {
            return "controls the behavior of the Enhanced Handheld Scanner plugin";
        }

        public bool Execute(string arguments, int SenderID)
        {
            string[] args = arguments.Split(' ');
            bool validhex = false;
            if (args.Length > 1 && args[1].Length == 6) 
            {
                validhex = ColorUtility.TryParseHtmlString("#" + args[1], out Color a);
            }
            switch (args[0].ToLower())
            {
                case "hostiles":
                    if (validhex)
                    {
                        Global.hostilehex = args[1];
                        Messaging.Notification($"Hostile color set to {args[1]}");
                    }
                    else
                    {
                        Messaging.Notification($"Invalid hex code!");
                    }
                    break;
                    case "crew":
                        if (validhex)
                        {
                            Global.crewhex = args[1];
                            Messaging.Notification($"Crew color set to {args[1]}");
                        }
                    break;
                case "npc":
                    if (validhex)
                    {
                        Global.npchex = args[1];
                        Messaging.Notification($"NPC color set to {args[1]}");
                    }
                    else
                    {
                        Messaging.Notification($"Invalid hex code!");
                    }
                    break;
                case "teleporter":
                    if (validhex)
                    {
                        Global.teleporterhex = args[1];
                        Messaging.Notification($"Teleporter color set to {args[1]}");
                    }
                    else
                    {
                        Messaging.Notification($"Invalid hex code!");
                    }
                    break;
                case "door":
                    if (validhex)
                    {
                        Global.doorhex = args[1];
                        Messaging.Notification($"Door color set to {args[1]}");
                    }
                    else
                    {
                        Messaging.Notification($"Invalid hex code!");
                    }
                    break;
                case "items":
                    if (validhex)
                    {
                        Global.itemhex = args[1];
                        Messaging.Notification($"Item color set to {args[1]}");
                    }
                    else
                    {
                        Messaging.Notification($"Invalid hex code!");
                    }
                    break;
                case "research":
                    if (validhex)
                    {
                        Global.researchhex = args[1];
                        Messaging.Notification($"Research color set to {args[1]}");
                    }
                    else
                    {
                        Messaging.Notification($"Invalid hex code!");
                    }
                    break;
                case "colorblind":
                    Global.hostilehex = "DC267F";
                    Global.crewhex = "FE6100";
                    Global.npchex = "ffffff";
                    Global.doorhex = "FEFE62";
                    Global.teleporterhex = "CC79A7";
                    Global.itemhex = "FFB000";
                    Global.researchhex = "785EF0";
                    PLXMLOptionsIO.Instance.CurrentOptions.SetStringValue("EnhancedHandheldScannerSettings", $"{Global.hostilehex} {Global.crewhex} {Global.npchex} {Global.doorhex} {Global.teleporterhex} {Global.itemhex} {Global.researchhex}"); 
                    Messaging.Notification("Colors set to colorblind friendly (hopefully) settings!");
                    break;
                case "values":
                    Messaging.Notification($"[{Global.hostilehex}](*) HOSTILE[-]\n[{ Global.crewhex}](*) CREW[-]\n[{ Global.npchex}](*) NPC[-]\n[{ Global.doorhex}](*) DOOR[-]\n[{ Global.teleporterhex}](*) TELEPORTER[-]\n[{Global.itemhex}](*) PICKUPS[-]\n[{Global.researchhex}](*) RESEARCH MATS[-]");
                    break;
                case "reset":
                    Global.hostilehex = "ff0000";
                    Global.crewhex = "00ff00";
                    Global.npchex = "ffffff";
                    Global.doorhex = "6666ff";
                    Global.teleporterhex = "ff00ff";
                    Global.itemhex = "FFFF00";
                    Global.researchhex = "44FFFF";
                    PLXMLOptionsIO.Instance.CurrentOptions.SetStringValue("EnhancedHandheldScannerSettings", $"{Global.hostilehex} {Global.crewhex} {Global.npchex} {Global.doorhex} {Global.teleporterhex} {Global.itemhex} {Global.researchhex}");
                    Messaging.Notification("All colors set to default!");
                    break;
                default:
                    Messaging.Notification("Subcommand not found");
                    break;
            }
            if (validhex)
            {
                PLXMLOptionsIO.Instance.CurrentOptions.SetStringValue("EnhancedHandheldScannerSettings", $"{Global.hostilehex} {Global.crewhex} {Global.npchex} {Global.doorhex} {Global.teleporterhex} {Global.itemhex} {Global.researchhex}");
            }
            return false;
        }

        public bool PublicCommand()
        {
            return false;
        }

        public string UsageExample()
        {
            return "/cuscanner [crew | hostiles | npc | teleporter | door | items | research | colorblind | values | reset]";
        }
    }
}
/*    color blind canidate #1    (contrasting colors)              
 *                  Global.hostilehex = "D35FB7";
                     Global.crewhex = "FEFE62";
                     Global.npchex = "ffffff";
                     Global.doorhex = "80BCFF";
                     Global.teleporterhex = "FF126A";
                     Global.itemhex = "40B0A6";
                     Global.researchhex = "E1BE6A";
   colorblind canidate #2 (wong)
                   Global.hostilehex = "E69F00";
                    Global.crewhex = "D55E00";
                    Global.npchex = "ffffff";
                    Global.doorhex = "0072B2";
                    Global.teleporterhex = "CC79A7";
                    Global.itemhex = "F0E442";
                    Global.researchhex = "0072B2";
 */