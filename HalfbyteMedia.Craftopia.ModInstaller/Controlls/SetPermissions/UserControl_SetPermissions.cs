using HalfbyteMedia.Craftopia.Core.Components.TaskItem;
using HalfbyteMedia.Craftopia.Core.Utilities;
using ProcessPrivileges;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalfbyteMedia.Craftopia.ModInstaller.Controlls.SetPermissions
{
    public partial class UserControl_SetPermissions : BaseControl
    {
        //public List<TaskItem> TaskItems { get; set; } = new();

        public TaskItem<Process> TaskStartCraftopia { get; set; }
        //public TaskItem<string> TaskGetWorkingDirectory { get; set; }
        public TaskItem<bool> TaskSetPermissions { get; set; }
        public TaskItem<bool> TaskDumpFiles { get; set; }

        public UserControl_SetPermissions()
        {
            InitializeComponent();


            TaskStartCraftopia = new TaskItem<Process>("Start Craftopia", new Func<Process>(() =>
            {

                var process = GetCraftopia();
                process.WaitForStartup();
                process.MinimizeWindow();

                return process;
            }));


         


            //flowLayoutPanel1.Controls.AddRange(TaskItems.ToArray());
            flowLayoutPanel1.Controls.Add(TaskStartCraftopia);
            //flowLayoutPanel1.Controls.Add(TaskGetWorkingDirectory);
        }

        private void StartCraftopia()
        {
            ProcessHelper.StartProcess("explorer.exe", new string[] { Properties.Settings.Default.RUN_CRAFTOPIA }).WaitForExit();


        }

        private bool CraftopiaRunning()
        {
            return ProcessHelper.GetProcess("Craftopia") != null;
        }

        private Process GetCraftopia()
        {
           
            if (!CraftopiaRunning())
            {
                StartCraftopia();
            }

            while (!CraftopiaRunning())
            {
                Thread.Sleep(100);
            }
                                  
            return ProcessHelper.GetProcess("Craftopia");
        }

        private async void button_Begin_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;

            button.Enabled = false;


            var craftopiaProcess = await TaskStartCraftopia.Run();

            if (craftopiaProcess == null)
            {
                button.Text = "Retry";
                button.Enabled = true;
                return;
            }

            //craftopiaProcess.KeepMinimised();

            TaskSetPermissions = new TaskItem<bool>("Set File Permissions", new Func<bool>(() =>
            {
                var path = new FileInfo(craftopiaProcess.MainModule.FileName).DirectoryName;

                try
                {
                    Process process = Process.GetCurrentProcess();
                    using (new PrivilegeEnabler(process, Privilege.TakeOwnership))
                    {
                        PermissionHelper.TakeOwership(path);
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
               
            }));
            flowLayoutPanel1.Controls.Add(TaskSetPermissions);

            var setPermissions = await TaskSetPermissions.Run();

            TaskDumpFiles = new TaskItem<bool>("Dump Craftopia Files", new Func<bool>(() =>
            {
                var workingDirectory = new FileInfo(Process.GetCurrentProcess().MainModule.FileName).Directory;
                var dumperPath = Path.Combine(workingDirectory.FullName, "UWP Dumper\\UWPInjector.exe");

                var dumpProcess = ProcessHelper.StartProcess(dumperPath, new string[] { "-c", "-p", craftopiaProcess.Id.ToString(), "-d", MainForm.Instance.InstallPath }, true);

                dumpProcess.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                {
                    var process = (Process)sender;
                    //if (string.IsNullOrEmpty(e.Data))
                    //    return;

                    Debug.WriteLine(e.Data);

                    if (e.Data.Contains("Press any key to continue . . ."))
                    {
                        dumpProcess.StandardInput.WriteLine(" ");
                    }
                };

                dumpProcess.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                {
                    var process = (Process)sender;
                    if (string.IsNullOrEmpty(e.Data))
                        return;

                    Debug.WriteLine(e.Data);


                    dumpProcess.StandardInput.WriteLine(" ");
                }; 

                dumpProcess.BeginOutputReadLine();
                dumpProcess.BeginErrorReadLine();

                dumpProcess.StandardInput.WriteLine(" ");
                dumpProcess.StandardInput.WriteLine(" ");
                dumpProcess.StandardInput.WriteLine(" ");

                dumpProcess.WaitForExit();


                return dumpProcess.ExitCode == 0;
            }));

            flowLayoutPanel1.Controls.Add(TaskDumpFiles);

            var filesDumped = await TaskDumpFiles.Run();

        }

        
    }
}
