using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace LogoSaver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml, This is required for LogoSaver to function.
    /// </summary>
    public partial class MainWindow : Window
    {
        //Variables (Local)
        List<BitmapImage> ImageStorage;
        int LoopCounter = 0;
        //Methods (Public & Private)
        public MainWindow()
        {
            //Keep this for now, remove this when LogoSaver exit's Pre-Release.
            Thread.Sleep(1000);
            RunStartup();
        }
        public void RunStartup()
        {
            DragonAPI.Core.StartDragonAPI();
            InitStartup();
            InitializeComponent();
            RefreshWindow();
            CompleteStartup();
        }
        public void InitStartup()
        {
            GetConfiguration();
            ImageStorage = new List<BitmapImage>();
            ConfigureImagesToShow();
        }
        public void RefreshWindow()
        {
            ConfigureWindowBorders();
            RefreshWindowSize();
        }
        public void CompleteStartup()
        {
            if (Core.ConfigurationManager.Configuration.CONFIG_APP_STARTUPAUDIO)
            {
                DragonAPI.AudioController.PlayStartupSound();
            }
        }
        private void GetConfiguration()
        {
            Core.ConfigurationManager.UnloadConfiguration();
            Core.ConfigurationManager.GetConfigurationFromFile("Configuration/app.json");
        }
        private void ConfigureImagesToShow()
        {
            foreach (string pth in Directory.GetFiles("Core/Resources/Images/"))
            {
                ImageStorage.Add(new BitmapImage(new Uri("file:///" + AppDomain.CurrentDomain.BaseDirectory + pth)));
            }
            if (ImageStorage.Count == 0)
            {
                if (MessageBox.Show("There are no images to show. Please add some images to Core/Resources/Images/ and open LogoSaver again.", "FATAL ERROR | No Images could be found.", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK) == MessageBoxResult.OK)
                {
                    Process.Start(new ProcessStartInfo() { FileName = "ImageLoader.exe" });
                    Application.Current.Shutdown();
                    return;
                }
            }
        }
        private void ConfigureWindowBorders()
        {
            if (Core.ConfigurationManager.Configuration.CONFIG_APP_BORDERS)
            {
                BorderThickness = new Thickness(1, 1, 1, 1);
            }
            else
            {
                BorderThickness = new Thickness(0, 0, 0, 0);
            }
        }
        private void RefreshWindowSize()
        {
            Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            Width = System.Windows.SystemParameters.PrimaryScreenWidth;
        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            
            DispatcherTimer timer = new DispatcherTimer();
            if (ImageStorage.Count != 0)
            {
                SOURCE_IMG.Source = ImageStorage[0];
                timer.Tick += SLIDESHOW_IMAGES;
                timer.Interval = new TimeSpan(0, 0, 5);
                timer.Start();
            }
        }
        private void SLIDESHOW_IMAGES(object sender, EventArgs e)
        {
            
            LoopCounter += 1;
            if (LoopCounter >= ImageStorage.Count)
            {
                LoopCounter = -1;
            }
            else
            {
                SOURCE_IMG.Source = ImageStorage[LoopCounter];
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
                    DragonAPI.Logging.Log.LogMessage(DragonAPI.Logging.Log.LogTypes.INFO, $"{e.Key.ToString()} pressed. Starting ImageLoader.exe...");
                    Process.Start(new ProcessStartInfo() { FileName = "ImageLoader.exe" });
                    return;
                case Key.Home:
                    DragonAPI.Logging.Log.LogMessage(DragonAPI.Logging.Log.LogTypes.INFO, $"{e.Key.ToString()} pressed. Opening Core.UI.Windows.WND_ABOUT...");
                    new Core.UI.Windows.WND_ABOUT().ShowDialog();
                    return;
                default:
                    DragonAPI.Logging.Log.LogMessage(DragonAPI.Logging.Log.LogTypes.WARNING, $"{e.Key.ToString()} does not have a endpoint. No action taken.");
                    return;
            }
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            DragonAPI.Core.StopDragonAPI();
        }
    }
}
