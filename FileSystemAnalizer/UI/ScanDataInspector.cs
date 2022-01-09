using FileSystemAnalizer.App;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSystemAnalizer.UI
{
    public class ScanDataInspector : IScanDataInspector
    {
        private readonly PictureBox pictureBox;
        public ScanDataInspector(PictureBox iconBox, )
        {
            iconBox.
        }

        public void DisplayDetailedScanDataInformation(IFolderDataNode folderDataNode)
        {
            var data = folderDataNode.ScanData;
            var sizeUnits = data.Size.BestFittingUnits;
            var size = data.IsInspected ? $"{data.Size.GetInUnits(sizeUnits):f1} {sizeUnits}" : "???";
            folderDataNode.Label = $"{data.Name} [{size}]";
        }

        public void DisplayDetailedScanDataInformation(IFileDataNode fileDataNode)
        {
            var data = fileDataNode.ScanData;
            var icon = Icon.ExtractAssociatedIcon(data.Path);
            pictureBox.Image = icon;
            throw new NotImplementedException();
        }
    }
}
