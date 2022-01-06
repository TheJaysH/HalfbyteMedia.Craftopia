using HalfbyteMedia.Craftopia.ModInstaller.Controlls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalfbyteMedia.Craftopia.ModInstaller.Controlls.Setup
{
    public class SetupEventArgs : BaseEventArgs
    {
        public DirectoryInfo DirectoryInfo { get; set; }
        public SetupEventArgs(DirectoryInfo directoryInfo, bool controlValid = true )
        {
            DirectoryInfo = directoryInfo;
            ControlValid = controlValid;
            
        }

    }
}
