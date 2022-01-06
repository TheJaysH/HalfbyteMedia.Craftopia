using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalfbyteMedia.Craftopia.Core.Utilities
{
    public static class PathHelper
    {
        public static bool IsValidPath(this DirectoryInfo directoryInfo)
        {
            try
            {
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                    directoryInfo.Delete();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
