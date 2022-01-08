using FileSystemAnalizer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemAnalizer.App
{
    public interface IFolderDataNode<TFolderNode, TFileNode> : IDataNode<IFolderScanData>
        where TFolderNode : IFolderDataNode<TFolderNode, TFileNode>
        where TFileNode : IFileDataNode
    {
        void AddNode(TFolderNode folderNode);
        void AddNode(TFileNode fileNode);
    }
}
