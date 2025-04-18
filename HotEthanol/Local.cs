using System.Reflection;
using HarmonyLib;
using HotEthanol.STRINGS;


namespace HotEthanol;

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
            Strings.Add($"STRINGS.CREATURES.SPECIES.GEYSER.{GeyserEthanol.HotEthanol.ToUpper()}.NAME", CREATURES.HOT_ETHANOL.NAME);
            Strings.Add($"STRINGS.CREATURES.SPECIES.GEYSER.{GeyserEthanol.HotEthanol.ToUpper()}.DESC", CREATURES.HOT_ETHANOL.DESC); 
        }
    }
    
    [HarmonyPatch(typeof (Localization), "Initialize")]
    public class Localization_Initialize_Patch
    {
        private static void Postfix()
        {
            Localization.RegisterForTranslation(typeof (CREATURES));
            string str1 = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException(), "strings");
            Localization.GenerateStringsTemplate(typeof (CREATURES), str1);
            Localization.Locale locale = Localization.GetLocale();
            string str2 = locale == null ? "en" : locale.Code;
            string path = System.IO.Path.Combine(str1, str2 + ".po");
            Dictionary<string, string> dictionary1 = new Dictionary<string, string>();
            if (File.Exists(path))
            {
                Dictionary<string, string> dictionary2 = Localization.LoadStringsFile(path, false);
                TextLoad(dictionary2);
                Localization.OverloadStrings(dictionary2);
                
                Debug.Log((object) ("Update language: " + str2));
            }
            else
            {
                TextLoad(dictionary1);
                Localization.OverloadStrings(dictionary1);
                Debug.Log("xxxxxxxxxxxxxxxxxxxxxxxxx");
            }
        }
    }

    private static void TextLoad(Dictionary<string, string> locDic)
    {
        foreach (var keyValuePair in locDic)
        {
            Strings.Add(keyValuePair.Key, locDic[keyValuePair.Key]);
        }
    }
    
}