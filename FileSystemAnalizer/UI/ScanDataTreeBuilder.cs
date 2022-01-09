using FileSystemAnalizer.App;
using FileSystemAnalizer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSystemAnalizer.UI
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

        public void Build(IFolderScanData rootFolderData)
        {
            treeView.Nodes.Clear();
            var rootFolderNode = new FolderDataNode(rootFolderData);
            treeView.Nodes.Add(rootFolderNode);
            scanRootNode = rootFolderNode;
            rootFolderNode.CreateAllSubNodes();
        }

        public void SortNodesBy<TKey>(Func<IDataNode<IFileSystemScanData>, TKey> keySelector) where TKey : IComparable
        {
            if (scanRootNode == null)
                return;
            SortSubNodes(scanRootNode, keySelector);
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
    }
}
