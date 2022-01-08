using FileSystemAnalizer.App;
using FileSystemAnalizer.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSystemAnalizer.UI
{
    public class FolderDataNode : TreeNode, IFolderDataNode
    {
        public IFolderScanData ScanData { get; }
        public string Label
        {
            get => Text;
            set => Text = value;
        }

        public FolderDataNode(IFolderScanData folderData)
        {
            ScanData = folderData;
            var sizeUnits = ScanData.Size.BestFittingUnits;
            Text = $"{ScanData.Name} [{ScanData.Size.GetInUnits(sizeUnits):f1} {sizeUnits.ToString()}]";
            SelectedImageKey = ImageKey = IconPool.FolderIconKey;
        }

        public void AddNode(IFileDataNode fileNode)
        {
            Nodes.Add(fileNode as FileDataNode);
        }

        public void AddNode(IFolderDataNode folderNode)
        {
            Nodes.Add(folderNode as FolderDataNode);
        }
    }
}
