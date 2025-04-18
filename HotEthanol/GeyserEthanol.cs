using HarmonyLib;
using STRINGS;

namespace HotEthanol;

public class GeyserEthanol
{
    public const string HotEthanol = "hot_ethanol";
    /*
    public static LocString NAME = (LocString) UI.FormatAsLink("Ethanol Vapor Vent", "GeyserGeneric_HOT_ETHANOL");
    public static LocString DESC = (LocString) ("A highly pressurized vent that periodically erupts with boiling " + UI.FormatAsLink("Ethanol", "ETHANOL") + ".");
    */
    
    
    
    [HarmonyPatch(typeof(GeyserGenericConfig), "GenerateConfigs")]
    public class GeyserGenericConfig_GenerateConfigs_Patch
    {
        private static void Postfix(List<GeyserGenericConfig.GeyserPrefabParams> __result)
        {
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyserliquidethanolchilled_kanim", 4, 2, new GeyserConfigurator.GeyserType(HotEthanol, SimHashes.Ethanol, GeyserConfigurator.GeyserShape.Liquid, 263.15f, 1000f, 2000f, 500f, null), true));
        }
    }
}