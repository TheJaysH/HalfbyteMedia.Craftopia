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
        private int CurrentIndex { get; set; } = 0;
        private Dictionary<ControlType,UserControl> UserControls { get; set; }

        public MainForm()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            UserControls = new Dictionary<ControlType, UserControl>();

            var disclaimer = new UserControl_Disclaimer()
            {
                Dock = DockStyle.Fill
            };
            disclaimer.DisclaimerEvent += Disclaimer_DisclaimerEvent;

            var setup = new UserControl_Setup()
            {
                Dock = DockStyle.Fill
            };

            
            UserControls.Add(ControlType.Disclaimer, disclaimer);
            UserControls.Add(ControlType.Setup, setup);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {                       
            listBox_Steps.SelectedIndexChanged += ListBox_Steps_SelectedIndexChanged;

            listBox_Steps.SelectedIndex = CurrentIndex;

            listBox_Steps.Enabled = false;
            listBox_Steps.BackColor = Color.White;
            listBox_Steps.ForeColor = Color.Black;
        }

        private void ListBox_Steps_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listBox = (ListBox)sender;
            var selectedIndex = listBox.SelectedIndex; 
            
            SetControl((ControlType)selectedIndex);
        }

        private void SetControl(ControlType controlType)
        {
            try
            {
                listBox_Steps.SelectedIndex = CurrentIndex;

                splitContainer_Main.Panel1.Controls.Clear();
                splitContainer_Main.Panel1.Controls.Add(UserControls[controlType]);

                switch (controlType)
                {
                    case ControlType.Disclaimer:
                        button_Back.Enabled = false;
                        button_Next.Enabled = false;
                        break;
                    case ControlType.Setup:
                        //button_Back.Enabled = true;
                        //button_Next.Enabled = false;
                        break;
                    case ControlType.RequiredFiles:
                        button_Back.Enabled = true;
                        button_Next.Enabled = false;
                        break;
                    default:
                        break;
                }

                splitContainer_Main.Panel1.Select();
            }
            catch (Exception)
            {
                //throw;
            }

        }

        private void Disclaimer_DisclaimerEvent(object sender, Controlls.ControlEventArgs.DisclaimerEventArgs e)
        {
            button_Next.Enabled = e.EulaAccepted;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to quit?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void button_Next_Click(object sender, EventArgs e)
        {           
            CurrentIndex += 1;
            SetControl((ControlType)CurrentIndex);
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            CurrentIndex -= 1;
            SetControl((ControlType)CurrentIndex);
        }
    }
}
