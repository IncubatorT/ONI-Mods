using HarmonyLib;
using KMod;

namespace Ethanol_vapor_vent
{
	public class EthanolVent : UserMod2
	{
		/*[HarmonyPatch(typeof(Db))]
		[HarmonyPatch("Initialize")]
		public class Db_Initialize_Patch
		{
			public static void Prefix()
			{
				Debug.Log("I execute before Db.Initialize!");
			}

			public static void Postfix()
			{
				Debug.Log("I execute after Db.Initialize!");
			}
		}*/
		
		[HarmonyPatch(typeof(GeyserGenericConfig))]
		[HarmonyPatch("GenerateConfigs")]
		public class GeyserGenericConfig_GenerateConfigs_Patch
		{
			private static void Postfix(List<GeyserGenericConfig.GeyserPrefabParams> __result)
			{
				Strings.Add($"STRINGS.CREATURES.SPECIES.GEYSER.{Id.ToUpper()}.NAME", Name);
				Strings.Add($"STRINGS.CREATURES.SPECIES.GEYSER.{Id.ToUpper()}.DESC", Description);

				__result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyserliquidethanolchilled_kanim", 4, 2, new GeyserConfigurator.GeyserType(Id, SimHashes.Ethanol, GeyserConfigurator.GeyserShape.Liquid, 263.15f, 1000f, 2000f, 500f), false));
			}
		}
		
		public override void OnLoad(Harmony harmony)
		{
			base.OnLoad(harmony);
		}

		public override void OnAllModsLoaded(Harmony harmony, IReadOnlyList<Mod> mods)
		{
			base.OnAllModsLoaded(harmony, mods);
		}
	}
}
