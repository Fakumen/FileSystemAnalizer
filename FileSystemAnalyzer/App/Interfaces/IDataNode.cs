using FileSystemAnalyzer.Domain;

namespace FileSystemAnalyzer.App
{
    public interface IDataNode<out TScanData>
        where TScanData : IFileSystemScanData
    {
        TScanData ScanData { get; }
        string Label { get; set; }
    }
}
