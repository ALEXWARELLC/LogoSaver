using System;
using System.Diagnostics;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace LogoSaver.Core.UI.Windows
{
    /// <summary>
    /// Interaction logic for WND_ABOUT.xaml
    /// </summary>
    public partial class WND_ABOUT : Window
    {
        
        public WND_ABOUT()
        {
            InitializeComponent();
            LABEL_VERSION.Content = $"v{Core.About.AppInfo.S_VERSION}";
            if (ConfigurationManager.IsConfigLoaded)
            {
                if (ConfigurationManager.Configuration.CONFIG_APP_BETA)
                {
                    LABEL_TITLE.Content = "LogoSaver Beta";
                }
                else
                {
                    LABEL_TITLE.Content = "LogoSaver";
                }
            }
            else
            {
                LABEL_TITLE.Content = "LogoSaver";
            }
        }
        private void BUTTON_CLOSEWINDOW_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    Application.Current.Shutdown();
                    return;
                case Key.End:
                    Process.Start(new ProcessStartInfo() { FileName = "ImageLoader.exe" });
                    return;
                default:
                    DragonAPI.Logging.Log.LogMessage(DragonAPI.Logging.Log.LogTypes.INFO, $"{e.Key.ToString()} does not have a endpoint.");
                    return;
            }
        }
    }
}
