using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sel_CSharp002.FileFolderHelper
{
    public class FileHelper
    {
        public string CopyFileSourceToDestination(string src,string dest)
        {
            if (File.Exists(dest))
            {
                File.Copy(src, dest, false);
            }
            return dest;
        }
        public bool DeleteAllFilesFromDirectory(string path)
        {
            bool IsStatus = false;
            try
            {
                DirectoryInfo di = new DirectoryInfo(path);
                FileInfo[] files=di.GetFiles();
                foreach(var file in files)
                {
                    file.Delete();
                }IsStatus = true;
            }
            catch(Exception) { IsStatus = false; throw; }

            return IsStatus;
        }
    }
}
