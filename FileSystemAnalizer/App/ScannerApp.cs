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

        public void OnSelectNode(IDataNode<IScanData> node)
        {
            if (node is IFileDataNode)
            {
                var fileNode = node as IFileDataNode;
                node.Label = $"{fileNode.ScanData.Path}";
            }
            else if (node is IFolderDataNode<IFolderDataNode<>, IFileDataNode)
            {

            }
            var dataNode = node as IDataNode<IScanData>;
            node.Label = $"{dataNode.ScanData.Path}";
        }
    }
}