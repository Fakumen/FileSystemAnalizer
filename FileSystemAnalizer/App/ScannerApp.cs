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
        //public event Action<IDataNode<IScanData>> ScanFinished
        private IScanDataTreeBuilder treeBuilder => lazyTreeBuilder.Value;
        private readonly Lazy<IScanDataTreeBuilder> lazyTreeBuilder;

        private readonly Func<IFolderScanData, IFolderDataNode> folderNodeFactory;
        private readonly Func<IFileScanData, IFileDataNode> fileNodeFactory;
        public ScannerApp(Lazy<IScanDataTreeBuilder> treeBuilder)
        {
            lazyTreeBuilder = treeBuilder;
        }
        //public ScannerApp(Func<IScanDataTreeBuilder> treeBuilderFactory)
        //{
        //    lazyTreeBuilder = new Lazy<IScanDataTreeBuilder>(treeBuilderFactory);
        //}

        private IFolderScanData Scan(string path)
        {
            var result = new FolderScanData(path);
            InspectAll(result);
            return result;
        }

        public void InspectAll(IFolderScanData folderData)
        {
            folderData.Inspect();
            foreach (var f in folderData.Folders)
                InspectAll(f);
        }

        public void CreateAllSubNodes(IFolderDataNode folderDataNode)
        {
            var rootFolderData = folderDataNode.ScanData;
            foreach (var folderData in rootFolderData.Folders)
            {
                var folderNode = folderNodeFactory(folderData);
                folderDataNode.AddNode(folderNode);
                CreateAllSubNodes(folderNode);
            }
            foreach (var fileData in rootFolderData.Files)
            {
                folderDataNode.AddNode(fileNodeFactory(fileData));
            }
        }

        public void OnStartScanButtonClick(
            string path, 
            Func<IFolderScanData, IFolderDataNode> folderNodeFactory,
            Func<IFileScanData, IFileDataNode> fileNodeFactory)
        {
            var firstFolderData = Scan(path);
            treeBuilder.Clear();
            var rootFolderNode = folderNodeFactory(firstFolderData);
            rootFolderNode.FillAllSubNodes();
            //CreateAllSubNodes(rootFolderNode);
            treeBuilder.AddNode(rootFolderNode);

        }

        public void OnSelectNode(IDataNode<IScanData> node)
        {
            node.Label = $"{node.ScanData.Path}";
            if (node is IFileDataNode)
            {

            }
            else if (node is IFolderDataNode)
            {

            }
        }
    }
}