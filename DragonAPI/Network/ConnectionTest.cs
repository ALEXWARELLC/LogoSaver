using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DragonAPI.Network
{
    public class ConnectionTest
    {
        public static bool IsConnectedToInternet()
        {
            try
            {
                PingReply p_reply = new Ping().Send("google.com");
                if (p_reply.Status == IPStatus.Success)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                Logging.Log.LogMessage(Logging.Log.LogTypes.ERROR, "There was an issue connecting to the internet.");
                return false;
            }
        }
    }
}
