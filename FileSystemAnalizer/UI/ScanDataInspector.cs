using FileSystemAnalizer.App;
using FileSystemAnalizer.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace FileSystemAnalizer.UI
{
    public class ScanDataInspector : IScanDataInspector
    {
        private readonly PictureBox iconBox;
        private readonly ListBox propertiesBox;
        public ScanDataInspector(PictureBox iconBox, ListBox propertiesBox)
        {
            this.iconBox = iconBox;
            this.propertiesBox = propertiesBox;
        }

        public void DisplayDetailedScanDataInformation(IFolderDataNode folderDataNode)
        {
            var data = folderDataNode.ScanData;
            //var sizeUnits = data.Size.BestFittingUnits;
            //var size = data.IsInspected ? $"{data.Size.GetInUnits(sizeUnits):f1} {sizeUnits}" : "???";
            //folderDataNode.Label = $"{data.Name} [{size}]";
            iconBox.Image = null;
            propertiesBox.Items.Clear();
            AddCommonProperties(folderDataNode);
        }

        public void DisplayDetailedScanDataInformation(IFileDataNode fileDataNode)
        {
            var data = fileDataNode.ScanData;
            using (var icon = Icon.ExtractAssociatedIcon(data.Path))
                iconBox.Image = icon.ToBitmap();
            propertiesBox.Items.Clear();
            AddCommonProperties(fileDataNode);
        }

        private void AddCommonProperties(IDataNode<IFileSystemScanData> commonDataNode)
        {
            var data = commonDataNode.ScanData;
            var properties = data.GetType().GetProperties();
            foreach (var p in properties)
            {
                propertiesBox.Items.Add($"{p.Name}: {p.GetValue(data)}");
            }
        }
    }
}
