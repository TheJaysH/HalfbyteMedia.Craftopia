using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalfbyteMedia.Craftopia.ModInstaller.Controlls.RequiredFiles
{
    public class FileMeta
    {
       
        public string Name { get; set; }

        public FileInfo FileInfo { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
        public bool Installable { get; set; }
        public FileStatus FileStatus { get; set; }

        public FileMeta(string name, string fileName, string url, bool installable = false, FileStatus fileStatus = FileStatus.WAITING)
        {
            Name = name;
            FileName = fileName;
            Url = url;
            Installable = installable;
            FileStatus = fileStatus;
            FileInfo = new FileInfo(fileName);
        }

        public bool Exists()
        {
            return FileInfo.Exists;
        }

    }
}
