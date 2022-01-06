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

namespace HalfbyteMedia.Craftopia.ModInstaller.Controlls.ModCraftopia
{
    public partial class UserControl_ModCraftopia : BaseControl
    {

        public TaskItem<Process> TaskStartCraftopia { get; set; }
        public TaskItem<bool> TaskSetPermissions { get; set; }
        public TaskItem<bool> TaskDumpFiles { get; set; }
        public TaskItem<bool> TaskInstallBepInEx { get; set; }
        public TaskItem<bool> TaskReinstallCraftopia { get; set; }        

        public UserControl_ModCraftopia()
        {
            InitializeComponent();


            TaskStartCraftopia = new TaskItem<Process>("Starting Craftopia", new Func<Process>(() =>
            {

                var process = GetCraftopia();
                process.WaitForStartup();
                process.MinimizeWindow();

                return process;
            }));
            TaskSetPermissions = new TaskItem<bool>("Setting File Permissions");
            TaskDumpFiles = new TaskItem<bool>("Dumping Craftopia Files");
            TaskInstallBepInEx = new TaskItem<bool>("Installing BepInEx");
            TaskReinstallCraftopia = new TaskItem<bool>("Reinstalling Craftopia");            

            flowLayoutPanel1.Controls.Add(TaskStartCraftopia);
            flowLayoutPanel1.Controls.Add(TaskSetPermissions);            
            flowLayoutPanel1.Controls.Add(TaskDumpFiles);
            flowLayoutPanel1.Controls.Add(TaskInstallBepInEx);
            flowLayoutPanel1.Controls.Add(TaskReinstallCraftopia);           
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

            try
            {

                var button = (Button)sender;
                button.Enabled = false;

                var craftopiaProcess = await TaskStartCraftopia.Run();
                var packageDirectory = new FileInfo(craftopiaProcess.MainModule.FileName).Directory;
                var workingDirectory = new FileInfo(Process.GetCurrentProcess().MainModule.FileName).Directory;

                craftopiaProcess.KeepMinimised();

                TaskSetPermissions.InitializeAction(new Func<bool>(() =>
                {
                    try
                    {
                        Process process = Process.GetCurrentProcess();
                        using (new PrivilegeEnabler(process, Privilege.TakeOwnership))
                        {
                            PermissionHelper.TakeOwership(packageDirectory.FullName);
                        }
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }

                }));

                var packageName = packageDirectory.Name;

                var setPermissions = await TaskSetPermissions.Run();

                TaskDumpFiles.InitializeAction(new Func<bool>(() =>
                {
                    
                    var dumperPath = Path.Combine(workingDirectory.FullName, "UWP Dumper\\UWPInjector.exe");

                    Directory.CreateDirectory(MainForm.Instance.InstallPath);

                    var dumpProcess = ProcessHelper.StartProcess(dumperPath, new string[] 
                    {
                        "-c", "-p", craftopiaProcess.Id.ToString(), "-d", MainForm.Instance.InstallPath 
                    }, true);

                    dumpProcess.OutputDataReceived += DumpProcess_OutputDataReceived;
                    dumpProcess.ErrorDataReceived += DumpProcess_ErrorDataReceived;

                    dumpProcess.BeginOutputReadLine();
                    dumpProcess.BeginErrorReadLine();

                    // Wait 1 hour
                    dumpProcess.WaitForExit(3600000);

                    craftopiaProcess.Kill();

                    return dumpProcess.ExitCode == 0;
                }));

                var filesDumped = await TaskDumpFiles.Run();

                TaskInstallBepInEx.InitializeAction(new Func<bool>(() =>
                {
                    var bepInExPath = new DirectoryInfo(Path.Combine(workingDirectory.FullName, "BepInEx"));
                    try
                    {
                        PathHelper.CopyFilesRecursively(bepInExPath.FullName, MainForm.Instance.InstallPath);
                    }
                    catch (Exception)
                    {
                        return false;
                    }

                    return true;
                }));

                var bepInExInstalled = TaskInstallBepInEx.Run();

                TaskReinstallCraftopia.InitializeAction(new Func<bool>(() =>
                {
                    try
                    {
                        var devModeEnabled = RegistryUtils.GetDeveloperMode();

                        if (!devModeEnabled)
                            RegistryUtils.SetDeveloperMode();

                        PowershellUtils.RemoveAppXPackage(packageName);
                        PowershellUtils.AddAppXPackage(Path.Combine(MainForm.Instance.InstallPath, "appxmanifest.xml"));

                        if (!devModeEnabled)
                            RegistryUtils.SetDeveloperMode(false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Failed to Install Craftopia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    return true;
                }));

                var installedCraftopia = await TaskReinstallCraftopia.Run();

            }
            catch (Exception)
            {
                button_Begin.Enabled = true;
                button_Begin.Text = "Retry";
            }
        }

        private void DumpProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            var process = (Process)sender;
            if (!string.IsNullOrEmpty(e.Data) && !process.HasExited)                      
                process.Kill();
        }

        private void DumpProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            try
            {
                var process = (Process)sender;

                //TODO: this is horrible, but we don't seem to get all the stdout. and sadly the `-c` argument doesn't work.
                //      so this is a dirty fix to ensure the process closes.
                process.StandardInput.WriteLine(" ");
            }
            catch (Exception)
            {
            }                      
        }
    }
}
