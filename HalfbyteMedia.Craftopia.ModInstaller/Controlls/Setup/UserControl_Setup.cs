using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalfbyteMedia.Craftopia.Core.Utilities;

namespace HalfbyteMedia.Craftopia.ModInstaller.Controlls.Setup
{
    public partial class UserControl_Setup : BaseControl, IControlValid<SetupEventArgs>
    {
        public event ControlValidEventHandler<SetupEventArgs> OnControlValid;

        public DirectoryInfo DirectoryInfo { get; private set; }

        public UserControl_Setup()
        {

            InitializeComponent();
            Load += UserControl_Setup_Load1;
            textBox_InstallDirectory.TextChanged += TextBox_InstallDirectory_TextChanged;

            ValidatePath();

        }

        private void UserControl_Setup_Load1(object sender, EventArgs e)
        {
            ValidatePath();
        }

        private void ValidatePath()
        {
            errorProvider_InstallDirectory.SetError(textBox_InstallDirectory, string.Empty);
            IsValid = true;

            if (textBox_InstallDirectory.Text == string.Empty)
            {
                errorProvider_InstallDirectory.SetError(textBox_InstallDirectory, "Path must not be empty");
                IsValid = false;
            }

            if (textBox_InstallDirectory.Text.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
            {
                errorProvider_InstallDirectory.SetError(textBox_InstallDirectory, "Invalid Characters in Path");
                IsValid = false;

            }

            try
            {
                DirectoryInfo = new DirectoryInfo(textBox_InstallDirectory.Text);                
            }
            catch (Exception ex)
            {
                errorProvider_InstallDirectory.SetError(textBox_InstallDirectory, ex.Message);

                IsValid = false;
            }

            OnControlValid?.Invoke(textBox_InstallDirectory, new SetupEventArgs(DirectoryInfo, IsValid));
        }

        private void TextBox_InstallDirectory_TextChanged(object sender, EventArgs e)
        {
            ValidatePath();
        }

        private void UserControl_Setup_Load(object sender, EventArgs e)
        {
            textBox_InstallDirectory.Text = Properties.Settings.Default.DEFAULT_INSTALL_DIRECTORY;
        }

        private void button_Browse_Click(object sender, EventArgs e)
        {
            var folderBrowser = new HalfbyteMedia.Craftopia.Core.Utilities.FolderPicker
            {
                InputPath = @"C:\",
            };

            if (folderBrowser.ShowDialog(this.Handle) == true)
            {
                textBox_InstallDirectory.Text = Path.GetDirectoryName(folderBrowser.ResultPath);                
            }
        }
    }
}
