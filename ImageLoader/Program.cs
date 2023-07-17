using System;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;

namespace ImageLoader
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (WindowsIdentity id = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(id);
                if (principal.IsInRole(WindowsBuiltInRole.Administrator))
                {
                    int count = 0;
                    foreach (string arg in args)
                    {
                        count++;
                    }
                    Console.WriteLine(count);
                    if (count == 1)
                    {
                        if (args[0] == "clear")
                        {
                            Console.WriteLine("Clearing Images...");
                            foreach (var item in Directory.GetFiles("Core/Resources/Images"))
                            {
                                Console.WriteLine(item);
                                File.Delete(item);
                            }
                        }
                    }
                    DragonAPI.Logging.Log.LogMessage(DragonAPI.Logging.Log.LogTypes.INFO, "Creating directories required to load images into LogoSaver...");
                    if (!Directory.Exists("Core/Resources/Images"))
                    {
                        Directory.CreateDirectory("Core/Resources/Images");
                    }
                    DragonAPI.Logging.Log.LogMessage(DragonAPI.Logging.Log.LogTypes.INFO, "Initializing OpenFileDialog...");
                    OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image Files|*.png;*.jpg;*.jpeg;*.gif", Title = "Load your Images into LogoSaver...", Multiselect = true, FileName = "" };
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        DragonAPI.Logging.Log.LogMessage(DragonAPI.Logging.Log.LogTypes.INFO, "OpenFileDialog returned 'OK'. Loading images into 'Core/Resources/Images/'. ");
                        foreach (string file in ofd.FileNames)
                        {
                            Console.WriteLine($"Copying: {new FileInfo(file).FullName}.{new FileInfo(file).Extension}");
                            File.Copy(file, $"Core/Resources/Images/{Path.GetFileName(file)}");
                        }
                        foreach (var arg in args)
                        {
                            if (arg == "fromls")
                            {
                                MessageBox.Show("To use these images, please restart LogoSaver by hitting Escape on your keyboard.", "Restart Required", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            }
                        }
                    }
                }
                else
                {
                    DragonAPI.Logging.Log.LogMessage(DragonAPI.Logging.Log.LogTypes.FATAL, "We cannot load any images into LogoSaver as this may or may not require administrator permissions.");
                    MessageBox.Show("We cannot load any images into LogoSaver as this may or may not require administrator permissions. Please make sure you have run 'ImageLoader.exe' with Administrator permissions.", "Administrator Permissions Required | ImageLoader - LogoSaver");
                }
            }
        }
    }
}
