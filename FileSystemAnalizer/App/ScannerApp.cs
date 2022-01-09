using FileSystemAnalizer.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemAnalizer.App
{
    public class ScannerApp
    {
        private IScanDataTreeBuilder scanDataTreeBuilder => lazyTreeBuilder.Value;
        private readonly Lazy<IScanDataTreeBuilder> lazyTreeBuilder;

        public ScannerApp(Lazy<IScanDataTreeBuilder> treeBuilder)
        {
            lazyTreeBuilder = treeBuilder;
        }

        private IFolderScanData Scan(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                throw new DirectoryNotFoundException();
            var result = new FolderScanData(new DirectoryInfo(folderPath));
            InspectAll(result);
            return result;
        }

        public void InspectAll(IFolderScanData folderData)
        {
            folderData.Inspect();
            foreach (var f in folderData.Folders)
                InspectAll(f);
        }

        public void OnStartScanButtonClick(
            string path)
        {
            var firstFolderData = Scan(path);
            scanDataTreeBuilder.Build(firstFolderData);

        }

        public void OnSelectDataNode(IDataNode<IFileSystemScanData> node)
        {
            if (node is IFileDataNode)
            {
                node.Label = $"{node.ScanData.Path}";
            }
            else if (node is IFolderDataNode)
            {

            }
        }
    }
}