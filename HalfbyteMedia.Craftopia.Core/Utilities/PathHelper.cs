using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalfbyteMedia.Craftopia.Core.Utilities
{
    public static class PathHelper
    {
        public static bool IsValidPath(this DirectoryInfo directoryInfo)
        {
            try
            {
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                    directoryInfo.Delete();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }
    }
}
