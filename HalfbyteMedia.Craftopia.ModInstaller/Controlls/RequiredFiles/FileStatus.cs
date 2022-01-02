using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalfbyteMedia.Craftopia.ModInstaller.Controlls.RequiredFiles
{
    public enum FileStatus
    {
        WAITING,
        DOWNLOADING,
        INSTALLING,
        FINISHED,
        ERROR,
    }
  
    public static class FileStatusExtensions
    {
        public static string GetStatusString(this FileStatus fileStatus)
        {
            switch (fileStatus)
            {
                case FileStatus.WAITING:
                    return "Waiting to download";
                case FileStatus.DOWNLOADING:
                    return "Downloading";
                case FileStatus.FINISHED:
                    return "Finished";
                case FileStatus.INSTALLING:
                    return "Installing";
                case FileStatus.ERROR:
                    return "Error";
                default:
                    return "Unknown";
            }
        }
    }
}
