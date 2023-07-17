using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSaver.Core.Resources.Application.Verification
{
    public class AppInfoChecker
    {
        public static bool CheckIfAppInfoFileIsValid()
        {
			try
			{
                if (File.Exists("Data/app.info"))
                {
                    if (IsAllDataPresent())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
			catch (Exception)
			{
                return false;
			}
        }
        private static bool IsAllDataPresent()
        {
            try
            {
                string[] f_lines;
                f_lines = File.ReadAllLines("Data/app.info");
                int count = 0;
                foreach (string line in f_lines)
                {
                    count++;
                }
                if (count == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
