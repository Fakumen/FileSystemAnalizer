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
}
