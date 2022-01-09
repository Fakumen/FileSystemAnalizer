using FileSystemAnalizer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemAnalizer.App
{
    public interface IFolderDataNode : IDataNode<IFolderScanData>
    {
        IEnumerable<IFolderDataNode> FolderDataNodes { get; }

        IEnumerable<IFileDataNode> FileDataNodes { get; }

        void AddNode(IFolderDataNode folderNode);

        void AddNode(IFileDataNode fileNode);

        void ClearNodes();

        void CreateAllSubNodes();
    }

    public static class IFolderDataNodeExtensions
    {
        public static void FillAllSubNodes(this IFolderDataNode rootFolderNode, 
            Func<IFolderScanData, IFolderDataNode> folderNodeFactory,
            Func<IFileScanData, IFileDataNode> fileNodeFactory)
        {
            foreach (var folderData in rootFolderNode.ScanData.Folders)
            {
                var folderNode = folderNodeFactory(folderData);
                rootFolderNode.AddNode(folderNode);
                folderNode.CreateAllSubNodes();
            }
            //Заполнены все подпапки
            foreach (var fileData in rootFolderNode.ScanData.Files)
            {
                var fileNode = fileNodeFactory(fileData);
                rootFolderNode.AddNode(fileNode);
            }
            //Заполнены все файлы
        }
    }
}
