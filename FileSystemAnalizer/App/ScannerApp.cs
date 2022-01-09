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
        private IScanDataInspector dataInspector => lazyDataInspector.Value;
        private readonly Lazy<IScanDataInspector> lazyDataInspector;

        private bool sortByDescending;

        public ScannerApp(Lazy<IScanDataTreeBuilder> treeBuilder, Lazy<IScanDataInspector> dataInspector)
        {
            lazyTreeBuilder = treeBuilder;
            lazyDataInspector = dataInspector;
        }

        private IFolderScanData Scan(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                throw new DirectoryNotFoundException();
            var result = new FolderScanData(new DirectoryInfo(folderPath));
            InspectAll(result);
            return result;
        }

        private void InspectAll(IFolderScanData folderData)
        {
            folderData.Inspect();
            foreach (var f in folderData.Folders)
                InspectAll(f);
        }

        public void OnStartScanButtonClick(
            string path)
        {
            var firstFolderData = Scan(path);
            scanDataTreeBuilder.Build(firstFolderData, data => true);
        }

        public void OnSelectDataNode(IDataNode<IFileSystemScanData> node)
        {
            if (node is IFileDataNode fileNode)
            {
                //при выборе ноды-файла
                dataInspector.DisplayDetailedScanDataInformation(fileNode);
            }
            else if (node is IFolderDataNode folderNode)
            {
                //при выборе ноды-папки
                dataInspector.DisplayDetailedScanDataInformation(folderNode);
            }
        }

        public void OnSortButtonClick()
        {
            if (sortByDescending)
            {
                scanDataTreeBuilder.SortNodesByDescending(n => n.ScanData.Size.SizeInBytes);
                sortByDescending = !sortByDescending;
            }
            else
            {
                scanDataTreeBuilder.SortNodesBy(n => n.ScanData.Size.SizeInBytes);
                sortByDescending = !sortByDescending;
            }
        }
    }
}