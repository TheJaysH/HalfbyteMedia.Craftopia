using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalfbyteMedia.Craftopia.ModInstaller.Controlls
{
    public class BaseControl : UserControl 
    {
        public delegate void ControlValidEventHandler<T>(object sender, T e);

        public bool IsValid { get; set; }

        public BaseControl()
        {
            Dock = DockStyle.Fill;
        }

    }


}
