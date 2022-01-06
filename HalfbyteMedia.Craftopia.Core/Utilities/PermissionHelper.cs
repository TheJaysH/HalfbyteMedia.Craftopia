using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HalfbyteMedia.Craftopia.Core.Utilities
{
    public static class PermissionHelper
    {
        public static void TakeOwership(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            var directorySecurity = directoryInfo.GetAccessControl();

            directorySecurity.SetOwner(WindowsIdentity.GetCurrent().User);
            Directory.SetAccessControl(path, directorySecurity);
        }


        // Adds an ACL entry on the specified file for the specified account.
        public static void AddFileSecurity(string fileName, string account,
            FileSystemRights rights, AccessControlType controlType)
        {

            // Get a FileSecurity object that represents the
            // current security settings.
            FileSecurity fSecurity = File.GetAccessControl(fileName);

            // Add the FileSystemAccessRule to the security settings.
            fSecurity.AddAccessRule(new FileSystemAccessRule(account,
                rights, controlType));

            // Set the new access settings.
            File.SetAccessControl(fileName, fSecurity);
        }

        // Removes an ACL entry on the specified file for the specified account.
        public static void RemoveFileSecurity(string fileName, string account,
            FileSystemRights rights, AccessControlType controlType)
        {

            // Get a FileSecurity object that represents the
            // current security settings.
            FileSecurity fSecurity = File.GetAccessControl(fileName);

            // Remove the FileSystemAccessRule from the security settings.
            fSecurity.RemoveAccessRule(new FileSystemAccessRule(account,
                rights, controlType));

            // Set the new access settings.
            File.SetAccessControl(fileName, fSecurity);
        }


        public static void AddDirectorySecurity(string path, string account,
           FileSystemRights rights, AccessControlType controlType)
        {
            var fSecurity = Directory.GetAccessControl(path);

            fSecurity.AddAccessRule(new FileSystemAccessRule(account,
                rights, controlType));

            Directory.SetAccessControl(path, fSecurity);
        }

        // Removes an ACL entry on the specified file for the specified account.
        public static void RemoveDirectorySecurity(string path, string account,
            FileSystemRights rights, AccessControlType controlType)
        {
            var fSecurity = Directory.GetAccessControl(path);

            fSecurity.RemoveAccessRule(new FileSystemAccessRule(account,
                rights, controlType));

            Directory.SetAccessControl(path, fSecurity);
        }
    }
}
