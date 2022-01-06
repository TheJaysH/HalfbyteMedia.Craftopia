using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace HalfbyteMedia.Craftopia.Core.Utilities
{
    public class PowershellUtils
    {
        public static void RemoveAppXPackage(string package)
        {
            try
            {
                PowerShell.Create().AddCommand("Remove-AppxPackage").AddParameter("Package", package).Invoke();                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AddAppXPackage(string path)
        {
            try
            {
                PowerShell.Create().AddCommand("Add-AppxPackage").AddParameter("Path", path).AddParameter("Register").Invoke();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
