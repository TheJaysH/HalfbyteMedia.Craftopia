using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HalfbyteMedia.Craftopia.ModInstaller.Controlls.BaseControl;

namespace HalfbyteMedia.Craftopia.ModInstaller.Controlls
{
    public interface IControlValid<T> where T: BaseEventArgs
    {
        public event ControlValidEventHandler<T> OnControlValid;
    }
}
