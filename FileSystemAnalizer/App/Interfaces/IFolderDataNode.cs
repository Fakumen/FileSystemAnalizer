using FileSystemAnalyzer.Domain;
using System.Collections.Generic;

namespace FileSystemAnalyzer.App
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
