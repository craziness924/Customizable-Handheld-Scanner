using PulsarPluginLoader; //

namespace EnhancedHandHeldScanner
{
    public class Plugin : PulsarPlugin
    {
        public override string Version => "1.0";

        public override string Author => "craziness924";

        public override string Name => "CustomizableHandHeldScanner";

        public override string HarmonyIdentifier()
        {
            return "craziness924.CustomizableHandHeldScanner";
        }
    }
}
