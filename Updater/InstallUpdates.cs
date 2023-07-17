using System;
using System.IO;
using System.IO.Compression;

namespace Updater
{
    public class InstallUpdates
    {
        public static void StartApplicationUpdate()
        {
            if (File.Exists("Updates/update.zip"))
            {
                ZipFile.ExtractToDirectory("Updates/update.zip",Directory.GetCurrentDirectory());
                File.Delete("Updates/update.zip");
            }
        }
    }
}
