using HarmonyLib;
using HotEthanol.STRINGS;

namespace HotEthanol;

public class AdditionalStrings
{
    [HarmonyPatch(typeof(GlobalAssets), "OnPrefabInit")]
    public class GlobalAssets_Patch
    {
        public static void Postfix()
        {
            Strings.Add($"STRINGS.CREATURES.SPECIES.GEYSER.{GeyserEthanol.HotEthanol.ToUpper()}.NAME", CREATURES.HOT_ETHANOL.NAME);
            Strings.Add($"STRINGS.CREATURES.SPECIES.GEYSER.{GeyserEthanol.HotEthanol.ToUpper()}.DESC", CREATURES.HOT_ETHANOL.DESC); 
        }
    }
}