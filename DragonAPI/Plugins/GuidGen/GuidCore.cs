using System;

namespace DragonAPI.Plugins.GuidGen
{
    public class GuidCore
    {
        public static Guid GenerateGuid()
        {
            return Guid.NewGuid();
        }
        public static string GenerateGuidToString()
        {
            return Guid.NewGuid().ToString();
        }
        public static Guid GenerateEmptyGuid()
        {
            return Guid.Empty;
        }
    }
}
