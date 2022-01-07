using FileSystemAnalizer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileSystemAnalizer.App
{
    public class ScannerApp
    {
        public ScannerApp()
        {

        }

        public IFolderScanData Scan(string path)
        {
            if (!Directory.Exists(path))
                throw new ArgumentException();
            var result = new FolderScanData(path);
            result.InspectAll();
            return result;
        }
    }
}
