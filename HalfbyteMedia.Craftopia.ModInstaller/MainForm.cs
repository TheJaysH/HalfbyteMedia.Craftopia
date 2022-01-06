using HalfbyteMedia.Craftopia.Core.Logging;
using HalfbyteMedia.Craftopia.Core.Utilities;
using HalfbyteMedia.Craftopia.ModInstaller.Controlls;
using HalfbyteMedia.Craftopia.ModInstaller.Controlls.Disclaimer;
using HalfbyteMedia.Craftopia.ModInstaller.Controlls.ReqiredFiles;
using HalfbyteMedia.Craftopia.ModInstaller.Controlls.ModCraftopia;
using HalfbyteMedia.Craftopia.ModInstaller.Controlls.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalfbyteMedia.Craftopia.ModInstaller
{
    public partial class MainForm : Form
    {
        private int CurrentIndex { get; set; }
        public Dictionary<ControlType, BaseControl> UserControls { get; set; } = new();
        public Logger Logger { get; set; }

        public static MainForm Instance { get; private set; }

        public string InstallPath { get; private set; }

        public MainForm()
        {
            InitializeLogger();
            InitializeComponent();
            InitializeControls();

            Instance = this;
        }

        private void InitializeLogger()
        {
            Logger = new Logger(Properties.Settings.Default.LOG_PATH);
        }

        private void InitializeControls()
        {

            var values = Enum.GetValues(typeof(ControlType));

            foreach (ControlType value in values)
            {
                listBox_Steps.Items.Add(value.GetControlTypeString());
            }


            var disclaimer = new UserControl_Disclaimer();
            var setup = new UserControl_Setup();
            var requiredFiles = new UserControl_RequiredFiles();
            var modCraftopia = new UserControl_ModCraftopia();
            
            disclaimer.OnControlValid += Disclaimer_OnControlValid;
            setup.OnControlValid += Setup_OnControlValid;
            requiredFiles.OnControlValid += RequiredFiles_OnControlValid;

            UserControls.Add(ControlType.Disclaimer, disclaimer);
            UserControls.Add(ControlType.Setup, setup);
            UserControls.Add(ControlType.RequiredFiles, requiredFiles);
            UserControls.Add(ControlType.ModCraftopia, modCraftopia);

            splitContainer_Main.Panel1.ControlAdded += Panel1_ControlAdded;
        }

        private void Panel1_ControlAdded(object sender, ControlEventArgs e)
        {
            //button_Next.Enabled = false;

            var control = sender;
            var userControl = UserControls.Values.Where(c => c.Equals(control)).FirstOrDefault();



            Debug.WriteLine(userControl);
        }

        private void RequiredFiles_OnControlValid(object sender, BaseEventArgs e)
        {
            if (button_Next.InvokeRequired)
                button_Next.Invoke(new MethodInvoker(() =>
                {
                    button_Next.Enabled = e.ControlValid;
                }));
            else
                button_Next.Enabled = e.ControlValid;
        }

        private void Setup_OnControlValid(object sender, SetupEventArgs e)
        {
            button_Next.Enabled = e.ControlValid;           
            InstallPath = e.DirectoryInfo.FullName;
        }

        private void Disclaimer_OnControlValid(object sender, BaseEventArgs e)
        {
            button_Next.Enabled = e.ControlValid;
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
                        button_Back.Enabled = false;
                        button_Next.Enabled = true;
                        break;
                    case ControlType.RequiredFiles:
                        button_Back.Enabled = false;
                        button_Next.Enabled = false;
                        break;
                    case ControlType.ModCraftopia:
                        button_Back.Enabled = false;
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

       

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Any progress will be lost. Are you sure?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Application.Exit();
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
