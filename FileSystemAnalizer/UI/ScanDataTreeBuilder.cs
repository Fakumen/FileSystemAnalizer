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
            rootFolderNode.FillAllSubNodes();
            rootFolderNode.FillAllSubNodesSortedBy(n => n.Size.SizeInBytes);
        }
    }
}
