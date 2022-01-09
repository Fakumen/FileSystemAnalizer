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
            Nodes.Add((FileDataNode) fileNode);
        }

        public void AddNode(IFolderDataNode folderNode)
        {
            Nodes.Add((FolderDataNode) folderNode);
        }

        public void FillAllSubNodes()
        {
            foreach (var folderData in ScanData.Folders)
            {
                var folderNode = new FolderDataNode(folderData);
                AddNode(folderNode);
                folderNode.FillAllSubNodes();
            }
            foreach (var fileData in ScanData.Files)
            {
                var fileNode = new FileDataNode(fileData);
                AddNode(fileNode);
            }
        }

        public void FillAllSubNodesSortedBy<TKey>(Func<IFileSystemScanData, TKey> sorter)
            where TKey : IComparable
        {
            foreach (var folderData in ScanData.Folders.OrderBy(sorter).Cast<IFolderScanData>())
            {
                var folderNode = new FolderDataNode(folderData);
                AddNode(folderNode);
                folderNode.FillAllSubNodesSortedBy(sorter);
            }
            foreach (var fileData in ScanData.Files.OrderBy(sorter).Cast<IFileScanData>())
            {
                var fileNode = new FileDataNode(fileData);
                AddNode(fileNode);
            }
        }
    }
}
