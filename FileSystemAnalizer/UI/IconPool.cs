using FileSystemAnalizer.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSystemAnalizer.UI
{
    public static class IconPool
    {
        public const string FolderIconKey = "folder";
        public const string FileIconKey = "file";
        public static ImageList ImageList { get; }

        static IconPool()
        {
            var projectDirectory = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            ImageList = new ImageList();
            ImageList.Images.Add(FolderIconKey, Resources.folder);
            ImageList.Images.Add(FileIconKey, Resources.file);
        }
    }
}
