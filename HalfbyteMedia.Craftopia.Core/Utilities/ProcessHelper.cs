using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HalfbyteMedia.Craftopia.Core.Utilities
{
    public static class ProcessHelper
    {       
        public static Process StartProcess(string name, string[] args, bool redirect = false)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = name,
                    Arguments = string.Join(" ", args),                    
                    //LoadUserProfile = true,
                    //UserName = Environment.UserName,
                    //Domain = Environment.UserDomainName,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardInput = redirect,
                    RedirectStandardError = redirect,
                    RedirectStandardOutput = redirect,
                }
            };

            process.Start();

            return process;
        }

        public static Process GetProcess(string processName)
        {
            return Process.GetProcessesByName(processName).FirstOrDefault();
        }


    }

    public static class ProcessExtenstions
    {
        public const int NORMAL = 1;
        public const int HIDE = 0;
        public const int RESTORE = 9;
        public const int SHOW = 5;
        public const int MAXIMIXED = 3;
        public const int MINIMIZE = 6;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static void WaitForStartup(this Process process)
        {
            var started = false;
            while(!started && !process.HasExited)
            {
                try
                {
                    process.Refresh();
                    started = ShowWindow(process.MainWindowHandle, NORMAL);
                    Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                
            }
        }

        public static void KeepMinimised(this Process process)
        {
            var t = new Thread(() =>
            {
                try
                {
                    while (!process.HasExited)
                    {
                        ShowWindow(process.MainWindowHandle, MINIMIZE);
                        Thread.Sleep(100);
                    }
                }
                catch (Exception)
                {
                }  
            })
            {
                IsBackground = true,
            };

            t.Start();
        }

        public static void MinimizeWindow(this Process process)
        {
            try
            {
                ShowWindow(process.MainWindowHandle, MINIMIZE);
            }
            catch (Exception)
            {
            }
        }

        public static void MaximiseWindow(this Process process)
        {
            try
            {
                ShowWindow(process.MainWindowHandle, MAXIMIXED);
            }
            catch (Exception)
            {
            }
        }
    }
}
