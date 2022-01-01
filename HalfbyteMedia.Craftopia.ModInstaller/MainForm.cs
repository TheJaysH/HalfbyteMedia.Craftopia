using HalfbyteMedia.Craftopia.ModInstaller.Controlls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalfbyteMedia.Craftopia.ModInstaller
{
    public partial class MainForm : Form
    {
       

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           
            listBox_Steps.Select();
            listBox_Steps.SelectedIndexChanged += ListBox_Steps_SelectedIndexChanged;

            listBox_Steps.SelectedIndex = 0;
        }

        private void ListBox_Steps_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listBox = (ListBox)sender;
            var selectedIndex = listBox.SelectedIndex; 
            
            SetControl((ControlType)selectedIndex);
        }

        private void SetControl(ControlType controlType, object data = null)
        {
            splitContainer_Main.Panel1.Controls.Clear();
            
            switch (controlType)
            {
                case ControlType.Disclaimer:
                    splitContainer_Main.Panel1.Controls.Add(new UserControl_Disclaimer() {
                        Dock = DockStyle.Fill
                    });
                    break;
                case ControlType.Setup:
                    break;
                case ControlType.RequiredFiles:
                    break;
                default:
                    break;
            }
        }
    }
}
