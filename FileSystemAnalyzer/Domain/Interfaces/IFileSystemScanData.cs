using System;
using System.IO;

namespace FileSystemAnalyzer.Domain
{
    public interface IFileSystemScanData
    {
        string Path { get; }
        string Name { get; }
        SizeData Size { get; }
        DateTime CreationTime { get; }
        DateTime LastAccessTime { get; }
        DateTime LastWriteTime { get; }
        FileAttributes Attributes { get; }
    }
}
