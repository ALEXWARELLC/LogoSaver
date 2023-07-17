using System;
using System.Windows;
using System.Windows.Input;

namespace LogoSaver.Core.UI.Windows
{
    /// <summary>
    /// Interaction logic for WND_UPDATES.xaml
    /// </summary>
    public partial class WND_UPDATES : Window
    {
        public WND_UPDATES()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void BUTTON_CLOSE_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BUTTON_CANCEL_Click(object sender, RoutedEventArgs e)
        {
            //Run Cancel code
            Close();
        }
    }
}
