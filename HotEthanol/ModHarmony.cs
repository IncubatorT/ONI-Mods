using HarmonyLib;
using KMod;

namespace HotEthanol
{
	public class ModHarmony : UserMod2
	{
		/*[HarmonyPatch(typeof(Db))]
		[HarmonyPatch("Initialize")]
		public class Db_Initialize_Patch
		{
			public static void Prefix()
			{
				// Debug.Log("I execute before Db.Initialize!");
			}

			public static void Postfix()
			{
				// Debug.Log("I execute after Db.Initialize!");
				// ModUtil.RegisterForTranslation(typeof(STRINGS.CREATURES));
			}
		}*/
		
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
