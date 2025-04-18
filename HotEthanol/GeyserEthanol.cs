using HarmonyLib;
using STRINGS;

namespace HotEthanol;

public class GeyserEthanol
{
    public const string HotEthanol = "hot_ethanol";
    
    [HarmonyPatch(typeof(GeyserGenericConfig), "GenerateConfigs")]
    public class GeyserGenericConfig_GenerateConfigs_Patch
    {
        private static void Postfix(List<GeyserGenericConfig.GeyserPrefabParams> __result)
        {
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyserliquidethanolchilled_kanim", 4, 2, new GeyserConfigurator.GeyserType(HotEthanol, SimHashes.Ethanol, GeyserConfigurator.GeyserShape.Liquid, 263.15f, 1000f, 2000f, 500f, null), true));
        }
    }
}