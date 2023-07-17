using System;
using System.Windows.Forms;

namespace Updater
{
    public partial class WND_MAIN : Form
    {
        public WND_MAIN()
        {
            InitializeComponent();
        }

        private void CHECK_UPDATE_READY(object sender, EventArgs e)
        {
            InstallUpdates.StartApplicationUpdate();
            Close();
        }
    }
}
