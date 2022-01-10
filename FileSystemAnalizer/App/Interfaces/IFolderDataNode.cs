using FileSystemAnalizer.Domain;
using System.Collections.Generic;

namespace FileSystemAnalizer.App
{
    public interface IFolderDataNode : IDataNode<IFolderScanData>
    {
        IEnumerable<IFolderDataNode> FolderDataNodes { get; }

        IEnumerable<IFileDataNode> FileDataNodes { get; }

        void AddNode(IFolderDataNode folderNode);

        void AddNode(IFileDataNode fileNode);

        void ClearNodes();
    }
}
