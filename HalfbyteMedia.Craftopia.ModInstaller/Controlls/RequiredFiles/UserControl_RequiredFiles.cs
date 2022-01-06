using HalfbyteMedia.Craftopia.Core.Utilities;
using HalfbyteMedia.Craftopia.ModInstaller.Controlls.RequiredFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalfbyteMedia.Craftopia.ModInstaller.Controlls.ReqiredFiles
{
    public partial class UserControl_RequiredFiles : BaseControl, IControlValid<BaseEventArgs>
    {       
        public event ControlValidEventHandler<BaseEventArgs> OnControlValid;

        public List<FileMeta> Files { get; private set; } = new();

        private int TasksCompleted { get; set; }

        public UserControl_RequiredFiles()
        {
            InitializeComponent();
            InitializeListBox();

            progressBar1.Style = ProgressBarStyle.Blocks;
        }


        private void InitializeListBox()
        {
            var files = Properties.Settings.Default.FILE_DOWNLOADS.Cast<string>();

            foreach (var fileString in files)
            {
                try
                {
                    var split = fileString.Split('|');
                    var name = split[0];
                    var installable = split[1];
                    var url = split[2];
                    var fileName = url.Substring(url.LastIndexOf('/') + 1);

                    var meta = new FileMeta(name, fileName, url, installable == "i");

                    var item = new ListViewItem(name)
                    {
                        Tag = meta
                    };

                    item.SubItems.Add(meta.FileStatus.GetStatusString());

                    listView_Files.Items.Add(item);
                    Files.Add(meta);
                }
                catch (Exception)
                {
                    throw;
                }
                
            }
            
        }

        private void UserControl_RequiredFiles_Load(object sender, EventArgs e)
        {
        }

        private void TaskCompleted(object sender, bool controlReady = true)
        {
            //TODO: This is kinda messy, and not thread safe.

            TasksCompleted += 1;

            if (TasksCompleted == Files.Count)
            {
                if (progressBar1.InvokeRequired)
                    progressBar1.Invoke(new MethodInvoker(() =>
                    {
                        progressBar1.Style = ProgressBarStyle.Blocks;
                    }));
                else
                    progressBar1.Style = ProgressBarStyle.Blocks;

                IsValid = controlReady;
                OnControlValid?.Invoke(sender, BaseEventArgs.GetValidEventArgs(controlReady));
            }
        }

        private void SetRowStatus(ListViewItem row, string text)
        {
            if (listView_Files.InvokeRequired)
                listView_Files.Invoke(new MethodInvoker(delegate
                {
                    row.SubItems[1].Text = text;
                }));
            else
                row.SubItems[1].Text = text;
        }

        private void button_Begin_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;            
            var rows = listView_Files.Items;

            button.Enabled = false;
            progressBar1.Enabled = true;
            progressBar1.Style = ProgressBarStyle.Marquee;


            foreach (ListViewItem row in rows)
            {
                Task.Run(() =>
                {
                    var meta = (FileMeta)row.Tag;
                    
                    try
                    {
                        meta.FileStatus = FileStatus.DOWNLOADING;

                        SetRowStatus(row, meta.FileStatus.GetStatusString());

                        if (!meta.Exists())
                        {
                            WebUtils.DownloadFile(meta.Url, meta.FileName);
                        }
                        

                        if (meta.Installable)
                        {
                            if (meta.FileName.StartsWith("vc_redist") && RegistryUtils.IsVCInstalled())
                            {
                                meta.FileStatus = FileStatus.NOT_REQUIRED;
                                SetRowStatus(row, meta.FileStatus.GetStatusString());
                            }
                            else
                            {
                                meta.FileStatus = FileStatus.INSTALLING;
                                SetRowStatus(row, meta.FileStatus.GetStatusString());

                                Process.Start(meta.FileName).WaitForExit();
                                meta.FileStatus = FileStatus.FINISHED;
                                SetRowStatus(row, meta.FileStatus.GetStatusString());
                            }
                        }

                        if (meta.FileInfo.Extension.Equals(".zip"))
                        {
                            if (Directory.Exists(meta.Name))
                                Directory.Delete(meta.Name, true);

                            ZipFile.ExtractToDirectory(meta.FileInfo.FullName, Path.Combine(meta.FileInfo.DirectoryName, meta.Name));
                            
                            meta.FileStatus = FileStatus.FINISHED;
                            SetRowStatus(row, meta.FileStatus.GetStatusString());
                        }

                       
                        TaskCompleted(sender);

                    }
                    catch (Exception ex)
                    {
                        meta.FileStatus = FileStatus.ERROR;
                        SetRowStatus(row, meta.FileStatus.GetStatusString());
                        
                        TaskCompleted(sender, false);
                        
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                });

                
            }
        }
    }
}
