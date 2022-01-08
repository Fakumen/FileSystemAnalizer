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

        public void AddNode(IFolderDataNode node)
            => treeView.Nodes.Add((FolderDataNode) node);

        public void AddNode(IFileDataNode node)
            => treeView.Nodes.Add((FileDataNode) node);

        public void Clear() => treeView.Nodes.Clear();
    }
}
