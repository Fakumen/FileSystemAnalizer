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
    public class FileDataNode : TreeNode, IFileDataNode
    {
        public IFileScanData ScanData { get; }
        public string Label
        {
            get => Text;
            set => Text = value;
        }

        public FileDataNode(IFileScanData fileData)
        {
            ScanData = fileData;
            var sizeUnits = ScanData.Size.BestFittingUnits;
            Text = $"{ScanData.Name} [{ScanData.Size.GetInUnits(sizeUnits):f1} {sizeUnits.ToString()}]";
            SelectedImageKey = ImageKey = IconPool.FileIconKey;
        }
    }
}
