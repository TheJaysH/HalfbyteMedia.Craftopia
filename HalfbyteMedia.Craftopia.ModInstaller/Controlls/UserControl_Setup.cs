using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalfbyteMedia.Craftopia.ModInstaller.Controlls
{
    public partial class UserControl_Setup : UserControl
    {
        public UserControl_Setup()
        {
            InitializeComponent();
        }

        private void UserControl_Setup_Load(object sender, EventArgs e)
        {
            textBox_InstallDirectory.Text = Properties.Settings.Default.DEFAULT_INSTALL_DIRECTORY;
        }
    }
}
