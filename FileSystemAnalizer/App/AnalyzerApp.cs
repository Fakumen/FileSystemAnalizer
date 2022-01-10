using FileSystemAnalizer.Domain;
using System;
using System.IO;

namespace FileSystemAnalizer.App
{
    public class AnalyzerApp
    {
        private IScanDataTreeBuilder scanDataTreeBuilder => lazyTreeBuilder.Value;
        private readonly Lazy<IScanDataTreeBuilder> lazyTreeBuilder;
        private IScanDataInspector dataInspector => lazyDataInspector.Value;
        private readonly Lazy<IScanDataInspector> lazyDataInspector;

        private readonly Scanner<IFolderScanData> folderScanner;

        private bool sortByDescending;

        public AnalyzerApp(Scanner<IFolderScanData> folderScanner, Lazy<IScanDataTreeBuilder> treeBuilder, Lazy<IScanDataInspector> dataInspector)
        {
            lazyTreeBuilder = treeBuilder;
            lazyDataInspector = dataInspector;
            this.folderScanner = folderScanner;
        }

        public void OnStartScanButtonClick(string path)
        {
            var firstFolderData = folderScanner.Scan(path);
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
            scanDataTreeBuilder.SortTree(n => n.ScanData.Size.SizeInBytes, sortByDescending);
            sortByDescending = !sortByDescending;
        }
    }
}