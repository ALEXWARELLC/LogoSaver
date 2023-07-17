using System;
using System.Collections.Generic;
using System.IO;

namespace DragonAPI.Logging
{
    public class Log
    {
        static List<string> MessagesToLog = new List<string>();
        public enum LogTypes
        {
            INFO,
            WARNING,
            ERROR,
            FATAL
        }
        public static void LogMessage(LogTypes LogType, string Message)
        {
            switch (LogType)
            {
                case LogTypes.INFO:
                    MessagesToLog.Add($"[INFO]: {Message}");
                    Console.WriteLine($"[INFO]: {Message}");
                    break;
                case LogTypes.WARNING:
                    MessagesToLog.Add($"[WARN]: {Message}");
                    Console.WriteLine($"[WARN]: {Message}");
                    break;
                case LogTypes.ERROR:
                    MessagesToLog.Add($"[ERROR]: {Message}");
                    Console.WriteLine($"[ERROR]: {Message}");
                    break;
                case LogTypes.FATAL:
                    MessagesToLog.Add($"[FATAL]: {Message}");
                    Console.WriteLine($"[FATAL]: {Message}");
                    break;
                default:
                    MessagesToLog.Add(Message);
                    Console.WriteLine(Message);
                    break;
            }
        }
        public static void DumpLogToFile(string Location, bool ExitingApp)
        {
            if (ExitingApp)
            {
                LogMessage(LogTypes.INFO, $"Application is exiting, dumping log to file: {Location}...");
                if (File.Exists(Location))
                {
                    File.Delete(Location);
                    File.WriteAllLines(Location, MessagesToLog.ToArray());
                }
                else
                {
                    File.WriteAllLines(Location, MessagesToLog.ToArray());
                }
            }
        }
    }
}
