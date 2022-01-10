namespace FileSystemAnalyzer.App
{
    public interface IScanDataInspector
    {
        void DisplayDetailedScanDataInformation(IFolderDataNode folderDataNode);
        void DisplayDetailedScanDataInformation(IFileDataNode fileDataNode);
    }
}
