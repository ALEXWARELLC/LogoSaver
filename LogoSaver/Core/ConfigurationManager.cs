using System;
using System.IO;

namespace LogoSaver.Core
{
    class ConfigurationManager
    {
        public static bool IsConfigLoaded = false;
        public static Core.Frameworks.Configuration Configuration { get; set; }
        public static void GetConfigurationFromFile(string ConfigFilePath)
        {
            Configuration = Newtonsoft.Json.JsonConvert.DeserializeObject<Core.Frameworks.Configuration>(File.ReadAllText(ConfigFilePath));
            IsConfigLoaded = true;
        }
        public static void UnloadConfiguration()
        {
            Configuration = null;
        }
    }
}
