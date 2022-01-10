using FileSystemAnalyzer.Domain;
using System;

namespace FileSystemAnalyzer.App
{
    public interface IScanDataTreeBuilder
    {
        void Build(IFolderScanData rootFolderData, Func<IFileSystemScanData, bool> selector);

        void SortTree<TKey>(Func<IDataNode<IFileSystemScanData>, TKey> keySelector, bool byDescending)
            where TKey : IComparable;
    }
}
