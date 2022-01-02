using HalfbyteMedia.Craftopia.Core.Utilities;
using HalfbyteMedia.Craftopia.ModInstaller.Controlls.RequiredFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalfbyteMedia.Craftopia.ModInstaller.Controlls.ReqiredFiles
{
    public partial class UserControl_RequiredFiles : UserControl
    {

        public delegate void FileFinsihedEventHanler(object sender, EventArgs e);
        public event FileFinsihedEventHanler FileFinishedEvent;

        public List<FileMeta> Files { get; private set; } = new();

        public UserControl_RequiredFiles()
        {
            InitializeComponent();
            InitializeListBox();

            FileFinishedEvent += UserControl_RequiredFiles_FileFinishedEvent;
        }

        private void UserControl_RequiredFiles_FileFinishedEvent(object sender, EventArgs e)
        {
            
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

            foreach (ListViewItem row in rows)
            {
                Task.Run(() =>
                {
                    var meta = (FileMeta)row.Tag;
                    meta.FileStatus = FileStatus.DOWNLOADING;

                    SetRowStatus(row, meta.FileStatus.GetStatusString());                   

                    WebUtils.DownloadFile(meta.Url, meta.FileName);

                    if (meta.Installable)
                    {
                        meta.FileStatus = FileStatus.INSTALLING;
                        SetRowStatus(row, meta.FileStatus.GetStatusString());

                        Process.Start(meta.FileName).WaitForExit();
                    }

                    meta.FileStatus = FileStatus.FINISHED;
                    SetRowStatus(row, meta.FileStatus.GetStatusString());

                });

                
            }
        }
    }
}
