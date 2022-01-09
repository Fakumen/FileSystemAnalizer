using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemAnalizer.App
{
    public interface IScanDataInspector
    {
        void DisplayDetailedScanDataInformation(IFolderDataNode folderDataNode);
        void DisplayDetailedScanDataInformation(IFileDataNode fileDataNode);
    }
}
