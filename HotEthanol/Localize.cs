using System.Reflection;
using HarmonyLib;
using HotEthanol.STRINGS;


namespace HotEthanol;

public class Localize
{
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
                Debug.Log("Load language: " + str2);
            }
            else
            {
                TextLoad(dictionary1);
                Localization.OverloadStrings(dictionary1);
                Debug.LogWarning("The localization file is missing or failed to load!");
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