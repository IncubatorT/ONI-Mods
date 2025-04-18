using Ethanol_vapor_vent.STRINGS;
using HarmonyLib;


namespace Ethanol_vapor_vent;

public class Local
{
    /*[HarmonyPatch(typeof(GlobalAssets), "OnPrefabInit")]
    public class GlobalAssets_Patch
    {
        public static void Postfix()
        {
            // LocString.CreateLocStringKeys(typeof ());
            Strings.Add($"STRINGS.CREATURES.SPECIES.GEYSER.{GeyserEthanol.HotEthanol.ToUpper()}.NAME", CREATURES.HOT_ETHANOL.NAME);
            Strings.Add($"STRINGS.CREATURES.SPECIES.GEYSER.{GeyserEthanol.HotEthanol.ToUpper()}.DESC", CREATURES.HOT_ETHANOL.DESC);
            // ModUtil.RegisterForTranslation(typeof(CREATURES));
        }
    }*/
    
    [HarmonyPatch(typeof(LocString), "CreateLocStringKeys")]
    public class LocString_Patch
    {
        public static void Prefix()
        {
            // LocString.CreateLocStringKeys(typeof ());
            Strings.Add($"STRINGS.CREATURES.SPECIES.GEYSER.{GeyserEthanol.HotEthanol.ToUpper()}.NAME", CREATURES.HOT_ETHANOL.NAME);
            Strings.Add($"STRINGS.CREATURES.SPECIES.GEYSER.{GeyserEthanol.HotEthanol.ToUpper()}.DESC", CREATURES.HOT_ETHANOL.DESC); 
            // ModUtil.RegisterForTranslation(typeof(CREATURES));
        }
    }
}