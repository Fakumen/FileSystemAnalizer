using FileSystemAnalizer.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemAnalizer.UI
{
    public class ScanDataInspector : IScanDataInspector
    {
        public ScanDataInspector()
        {

        }

        public void DisplayScanDataInformation(IFolderDataNode folderDataNode)
        {
            var data = folderDataNode.ScanData;
            var sizeUnits = data.Size.BestFittingUnits;
            var size = data.IsInspected ? $"{data.Size.GetInUnits(sizeUnits)} {sizeUnits}" : "???";
            folderDataNode.Label = $"{data.Name} [{size}]";
        }

        public void DisplayScanDataInformation(IFileDataNode fileDataNode)
        {
            throw new NotImplementedException();
        }
    }
}
