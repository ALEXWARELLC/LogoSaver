using System;
using System.IO;
using System.Threading;

namespace DragonAPI
{
    public class Core
    {
        public static void StartDragonAPI()
        {
            Logging.Log.LogMessage(Logging.Log.LogTypes.INFO, $"========== {DateTime.Now} ==========");
            Translations.TranslationFramework.LoadTranslations(Translations.TranslationFramework.SupportedLanguages.en_AU);
        }
        public static void StopDragonAPI()
        {
            Logging.Log.LogMessage(Logging.Log.LogTypes.INFO, $"========== {DateTime.Now} ==========");
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Alexware", "DragonAPI"));
            Logging.Log.DumpLogToFile(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Alexware", "DragonAPI", $"{DateTime.Now.ToFileTime()}.log"), true);
        }
        public static void CleanLocalFiles()
        {
            Directory.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Alexware"));
        }
    }
}
