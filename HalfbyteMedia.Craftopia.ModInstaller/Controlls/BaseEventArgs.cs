using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalfbyteMedia.Craftopia.ModInstaller.Controlls
{
    public class BaseEventArgs
    {
        public bool ControlValid { get; set; }

        public BaseEventArgs() { }

        public BaseEventArgs(bool controlValid)
        {
            ControlValid = controlValid;
        }        

        public static BaseEventArgs GetValidEventArgs(bool controlValid = true)
        {
            return new BaseEventArgs(controlValid);
        }
    }
}
