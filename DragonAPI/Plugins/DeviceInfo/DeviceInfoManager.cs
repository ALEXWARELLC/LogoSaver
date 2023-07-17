using System;
using System.Collections;

namespace DragonAPI.Plugins.DeviceInfo
{
    public class DeviceInfoManager
    {
        public static string GetPCName()
        {
            return Environment.MachineName;
        }
        public static IDictionary GetEnvironmentArgs()
        {
            return Environment.GetEnvironmentVariables();
        }
        public class AppDomainInfo
        {
            public static ActivationContext GetActivationContext()
            {
                return AppDomain.CurrentDomain.ActivationContext;
            }
        }
    }
}
