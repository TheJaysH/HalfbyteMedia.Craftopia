using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HalfbyteMedia.Craftopia.Core.Utilities
{
    public class RegistryUtils
    {
        public static void SetDeveloperMode(bool enabaled = true)
        {
            string path = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\AppModelUnlock";
            using RegistryKey appModelUnlock = Registry.LocalMachine.OpenSubKey(path);
            appModelUnlock.SetValue("AllowDevelopmentWithoutDevLicense", enabaled ? 1 : 0, RegistryValueKind.DWord);
        }

        public static bool GetDeveloperMode()
        {
            string path = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\AppModelUnlock";
            using RegistryKey appModelUnlock = Registry.LocalMachine.OpenSubKey(path);
            return (string)appModelUnlock.GetValue("AllowDevelopmentWithoutDevLicense") == "1";
        }

        public static bool IsVCInstalled(int version = 2015)
        {
            string dependenciesPath = @"SOFTWARE\Classes\Installer\Dependencies";

            using (RegistryKey dependencies = Registry.LocalMachine.OpenSubKey(dependenciesPath))
            {
                if (dependencies == null) return false;

                foreach (string subKeyName in dependencies.GetSubKeyNames().Where(n => !n.ToLower().Contains("dotnet") && !n.ToLower().Contains("microsoft")))
                {
                    using RegistryKey subDir = Registry.LocalMachine.OpenSubKey(dependenciesPath + "\\" + subKeyName);
                    var value = subDir.GetValue("DisplayName")?.ToString() ?? null;
                    if (string.IsNullOrEmpty(value))
                    {
                        continue;
                    }
                    if (Environment.Is64BitOperatingSystem)
                    {
                        if (Regex.IsMatch(value, $@"C\+\+ {version}.*\((x64|x86)\)"))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (Regex.IsMatch(value, $@"C\+\+ {version}.*\(x86\)"))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
