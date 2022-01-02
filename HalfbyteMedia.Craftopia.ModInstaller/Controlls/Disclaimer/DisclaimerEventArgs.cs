using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalfbyteMedia.Craftopia.ModInstaller.Controlls.Disclaimer
{
    public class DisclaimerEventArgs
    {
        public bool EulaAccepted { get; }
        public DisclaimerEventArgs(bool eulaAccepted)
        {
            EulaAccepted = eulaAccepted;
        }
    }
}
