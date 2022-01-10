using FileSystemAnalizer.Domain;
using System;

namespace FileSystemAnalizer.App
{
    public interface IScanDataTreeBuilder
    {
        void Build(IFolderScanData rootFolderData, Func<IFileSystemScanData, bool> selector);

        void SortTree<TKey>(Func<IDataNode<IFileSystemScanData>, TKey> keySelector, bool byDescending)
            where TKey : IComparable;
    }
}
