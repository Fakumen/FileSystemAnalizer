using FileSystemAnalyzer.Infrastructure;
using System.Collections.Generic;

namespace FileSystemAnalyzer.Domain
{
    public interface IFolderScanData : IFileSystemScanData, ILazyDataLoader<IFolderScanData>
    {
        long TotalFilesCount { get; }

        long TotalFoldersCount { get; }

        long FoldersCount { get; }

        long FilesCount { get; }

        long TotalElementsCount { get; }

        IEnumerable<IFolderScanData> Folders { get; }

        IEnumerable<IFileScanData> Files { get; }

        bool IsInspected { get; }

        void Inspect();
    }
}
