using System;
using System.IO;
using Newtonsoft.Json;

namespace DragonAPI.Translations
{
    public class TranslationFramework
    {
        public static Translations Translations;
        public static void LoadTranslations(SupportedLanguages LanguageToLoad)
        {
            switch (LanguageToLoad)
            {
                case SupportedLanguages.en_AU:
                    Logging.Log.LogMessage(Logging.Log.LogTypes.INFO, "Loading Translations (en-AU)...");
                    Translations = JsonConvert.DeserializeObject<Translations>(File.ReadAllText("Translations/en-AU/dragonapi.json"));
                    break;
                case SupportedLanguages.en_US:
                    Logging.Log.LogMessage(Logging.Log.LogTypes.INFO, "Loading Translations (en-US)...");
                    Translations = JsonConvert.DeserializeObject<Translations>(File.ReadAllText("Translations/en-US/dragonapi.json"));
                    break;
                default:
                    Logging.Log.LogMessage(Logging.Log.LogTypes.ERROR, "The chosen language to load is not valid. Please check your translations exist and are valid.");
                    return;
            }
        }
        public enum SupportedLanguages
        {
            en_AU,
            en_US
        }
    }
    public class Translations
    {
        public string DRAGONAPI_ABOUT_TITLE { get; set; }
        public string DRAGONAPI_ABOUT_VERSION { get; set; }
        public string DRAGONAPI_BUTTONS_CLOSE { get; set; }
        public string DRAGONAPI_BUTTONS_OK { get; set; }
        public string DRAGONAPI_BUTTONS_RETRY { get; set; }
    }
}
