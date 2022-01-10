using FileSystemAnalyzer.App;
using FileSystemAnalyzer.Domain;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FileSystemAnalyzer.UI
{
    public class ScanDataTreeBuilder : IScanDataTreeBuilder
    {
        private readonly TreeView treeView;
        private IFolderDataNode scanRootNode;

        public ScanDataTreeBuilder(TreeView treeView, ImageList imageList)
        {
            this.treeView = treeView;
            treeView.ImageList = imageList;
        }

        public void Build(IFolderScanData rootFolderData, Func<IFileSystemScanData, bool> selector)
        {
            treeView.Nodes.Clear();
            var rootFolderNode = new FolderDataNode(rootFolderData);
            treeView.Nodes.Add(rootFolderNode);
            scanRootNode = rootFolderNode;
            CreateAllSubNodes(rootFolderNode, selector);
        }

        public void CreateAllSubNodes(FolderDataNode rootFolderNode, Func<IFileSystemScanData, bool> selector)
        {
            foreach (var folderData in rootFolderNode.ScanData.Folders
                .Where(selector)
                .Cast<IFolderScanData>()
                .Select(n => new FolderDataNode(n)))
            {
                rootFolderNode.AddNode(folderData);
                CreateAllSubNodes(folderData, selector);
            }
            foreach (var fileData in rootFolderNode.ScanData.Files
                .Where(selector)
                .Cast<IFileScanData>()
                .Select(n => new FileDataNode(n)))
            {
                rootFolderNode.AddNode(fileData);
            }
        }

        public void SortTree<TKey>(Func<IDataNode<IFileSystemScanData>, TKey> keySelector, bool byDescending)
            where TKey : IComparable
        {
            if (scanRootNode == null)
                return;
            if (byDescending)
            {
                SortSubNodesByDescending(scanRootNode, keySelector);
            }
            else
            {
                SortSubNodes(scanRootNode, keySelector);
            }
        }

        private void SortSubNodes<TKey>(
            IFolderDataNode folderNode, 
            Func<IDataNode<IFileSystemScanData>, TKey> keySelector) where TKey : IComparable
        {
            var sortedFolderNodes = folderNode.FolderDataNodes.OrderBy(keySelector).Cast<IFolderDataNode>().ToList();
            var sortedFileNodes = folderNode.FileDataNodes.OrderBy(keySelector).Cast<IFileDataNode>().ToList();
            folderNode.ClearNodes();
            foreach (var node in sortedFolderNodes)
            {
                folderNode.AddNode(node);
                SortSubNodes(node, keySelector);
            }
            foreach (var node in sortedFileNodes)
                folderNode.AddNode(node);
        }

        private void SortSubNodesByDescending<TKey>(
            IFolderDataNode folderNode,
            Func<IDataNode<IFileSystemScanData>, TKey> keySelector) where TKey : IComparable
        {
            var sortedFolderNodes = folderNode.FolderDataNodes.OrderByDescending(keySelector).Cast<IFolderDataNode>().ToList();
            var sortedFileNodes = folderNode.FileDataNodes.OrderByDescending(keySelector).Cast<IFileDataNode>().ToList();
            folderNode.ClearNodes();
            foreach (var node in sortedFolderNodes)
            {
                folderNode.AddNode(node);
                SortSubNodesByDescending(node, keySelector);
            }
            foreach (var node in sortedFileNodes)
                folderNode.AddNode(node);
        }
    }
}
