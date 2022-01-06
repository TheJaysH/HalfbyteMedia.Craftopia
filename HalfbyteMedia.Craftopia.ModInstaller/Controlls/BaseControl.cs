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
    public partial class BaseControl : UserControl
    {
        public delegate void ControlValidEventHandler<T>(object sender, T e);

        public bool IsValid { get; set; }

        public BaseControl()
        {
            Dock = DockStyle.Fill;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseControl
            // 
            this.Name = "BaseControl";
            this.Size = new System.Drawing.Size(314, 150);
            this.ResumeLayout(false);

        }
    }
}
