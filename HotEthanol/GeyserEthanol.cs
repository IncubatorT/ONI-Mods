using HarmonyLib;

namespace HotEthanol;

public class GeyserEthanol
{
    public const string HotEthanol = "hot_ethanol";
    
    /*
     * 添加间歇泉原始配置
     */
    [HarmonyPatch(typeof(GeyserGenericConfig), "GenerateConfigs")]
    public class GeyserGenericConfig_GenerateConfigs_Patch
    {
        private static void Postfix(List<GeyserGenericConfig.GeyserPrefabParams> __result)
        {
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_hot_ethanol_kanim", 2, 4, new GeyserConfigurator.GeyserType(HotEthanol, SimHashes.EthanolGas, GeyserConfigurator.GeyserShape.Gas, 773.15f, 180f, 360f, 5f, null), true));
        }
    }

    /*
     * 修补地质调谐仪配置
     */
    [HarmonyPatch(typeof(GeoTuner.Def), "GetSettingsForGeyser")]
    public class GeoTuner_Def_GetSettingsForGeyser_Patch
    {
        private static void Postfix(Geyser geyser ,ref GeoTunerConfig.GeotunedGeyserSettings __result)
        {
            if (geyser.configuration.typeId == (HashedString) HotEthanol)
            {
                __result = new GeoTunerConfig.GeotunedGeyserSettings()
                {
                    material = SimHashes.Phosphorus.CreateTag(),
                    quantity = 400f,
                    duration = 4500f,
                    template = new Geyser.GeyserModification()
                    {
                        massPerCycleModifier = 0.2f,
                        temperatureModifier = 50f,
                        iterationDurationModifier = 0.0f,
                        iterationPercentageModifier = 0.0f,
                        yearDurationModifier = 0.0f,
                        yearPercentageModifier = 0.0f,
                        maxPressureModifier = 0.0f
                    }
                };
            }
        }
    }
    
}