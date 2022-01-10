using System;
using System.IO;

namespace FileSystemAnalyzer.Domain
{
    public sealed class FileScanData : IFileScanData
    {
        public string Path => fileInfo.FullName;
        public string Name => fileInfo.Name;
        public string Extension => fileInfo.Extension;
        public SizeData Size { get; }
        public DateTime CreationTime => fileInfo.CreationTime;
        public DateTime LastAccessTime => fileInfo.LastAccessTime;
        public DateTime LastWriteTime => fileInfo.LastWriteTime;
        public FileAttributes Attributes => fileInfo.Attributes;

        private readonly FileInfo fileInfo;

        public FileScanData(FileInfo fileInfo)
        {
            this.fileInfo = fileInfo;
            Size = new SizeData(fileInfo.Length);
        }
    }
}
