using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalfbyteMedia.Craftopia.ModInstaller.Controlls.RequiredFiles
{
    public class FileFinsihedEventArgs
    {
        public FileMeta FileMeta { get; set; }
        public bool Success { get; set; }
    }
}
