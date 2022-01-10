using FileSystemAnalizer.Domain;

namespace FileSystemAnalizer.App
{
    public interface IDataNode<out TScanData>
        where TScanData : IFileSystemScanData
    {
        TScanData ScanData { get; }
        string Label { get; set; }
    }
}
