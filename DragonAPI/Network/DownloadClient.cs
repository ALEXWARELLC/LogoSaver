using System;
using System.IO;
using System.Net;

namespace DragonAPI.Network
{
    public class DownloadClient
    {
        public static void DownloadFile(string URL, string TargetPath)
        {
            int bytesProcessed = 0;
            Stream remoteStream = null;
            Stream localStream = null;
            WebResponse response = null;
            try
            {
                WebRequest request = WebRequest.Create(URL);
                if (request != null)
                {
                    double TotalBytesToReceive = 0;
                    var SizeWebRequest = HttpWebRequest.Create(new Uri(URL));
                    SizeWebRequest.Method = "HEAD";
                    using (var webResponse = SizeWebRequest.GetResponse())
                    {
                        var filesize = webResponse.Headers.Get("Content-Length");
                        TotalBytesToReceive = Convert.ToDouble(filesize);
                    }
                    response = request.GetResponse();
                    if (response != null)
                    {
                        remoteStream = response.GetResponseStream();
                        string filepath = TargetPath;
                        localStream = File.Create(filepath);
                        byte[] buffer = new byte[2048];
                        int bytesRead = 0;
                        do
                        {
                            bytesRead = remoteStream.Read(buffer, 0, buffer.Length);
                            localStream.Write(buffer, 0, bytesRead);
                            bytesProcessed += bytesRead;
                            double bytesIn = double.Parse(bytesProcessed.ToString());
                            double percentage = bytesIn / TotalBytesToReceive * 100;
                            percentage = Math.Round(percentage, 0);

                        } while (bytesRead > 0);
                    }
                }
            }
            catch (Exception)
            {
                Logging.Log.LogMessage(Logging.Log.LogTypes.ERROR, "Unable to complete download. There was an issue trying to get the Downloadable Content. Please check you can connect to the internet and try again.");
            }
            finally
            {
                if (response != null)
                {
                    response.Close();

                }
                if (localStream != null)
                {
                    localStream.Close();
                }
                if (remoteStream != null)
                {
                    remoteStream.Close();
                }
            }
        }
    }
}
