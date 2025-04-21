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
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_hot_ethanol_kanim", 2, 4, new GeyserConfigurator.GeyserType(HotEthanol, SimHashes.EthanolGas, GeyserConfigurator.GeyserShape.Gas, 773.15f, 70f, 140f, 5f, null), true));
        }
    }
}