using FileSystemAnalyzer.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace FileSystemAnalyzer.UI
{
    public static class IconPool
    {
        public const string FolderIconKey = "folder";
        public const string FileIconKey = "file";
        public static ImageList ImageList { get; } = new ImageList();

        static IconPool()
        {
            ImageList.Images.Add(FolderIconKey, Resources.folder);
            ImageList.Images.Add(FileIconKey, Resources.file);
        }

        public static Image GetIconByKey(string key) => ImageList.Images[key];
    }
}
