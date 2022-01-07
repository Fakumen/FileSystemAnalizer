using FileSystemAnalizer.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemAnalizer.App
{
    public class ScannerApp
    {
        //public event Action<IDataNode<IScanData>> ScanFinished
        public ScannerApp()
        {

        }

        private IFolderScanData Scan(string path)
        {
            var result = new FolderScanData(path);
            result.InspectAll();
            return result;
        }

        public void OnStartScanButtonClick(string path, Action<IFolderScanData> createNode)
        {
            var firstFolderScanData = Scan(path);
            createNode(firstFolderScanData);
        }
    }
}