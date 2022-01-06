using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalfbyteMedia.Craftopia.ModInstaller.Controlls.Disclaimer
{
    public partial class UserControl_Disclaimer : BaseControl, IControlValid<BaseEventArgs>
    {        
        public event ControlValidEventHandler<BaseEventArgs> OnControlValid;

        public UserControl_Disclaimer()
        {
            InitializeComponent();
        }

        

        private void UserControl_Disclaimer_Load(object sender, EventArgs e)
        {
            richTextBox1.Rtf = Properties.Resources.EULA;
            checkBox_DisclaimerAccepted.CheckedChanged += CheckBox1_CheckedChanged;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;
            IsValid = checkbox.Checked;
            OnControlValid?.Invoke(this, BaseEventArgs.GetValidEventArgs(checkbox.Checked));
        }
    }

}
