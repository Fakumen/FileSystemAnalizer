using FileSystemAnalizer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemAnalizer.App
{
    public interface IScanDataTreeBuilder
    {
        void Build(IFolderScanData rootFolderData, Func<IFileSystemScanData, bool> selector);

        void SortNodesBy<TKey>(Func<IDataNode<IFileSystemScanData>, TKey> keySelector) where TKey : IComparable;

        void SortNodesByDescending<TKey>(Func<IDataNode<IFileSystemScanData>, TKey> keySelector) where TKey : IComparable;
    }
}
