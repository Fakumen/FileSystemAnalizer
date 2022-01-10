using FileSystemAnalizer.Domain;
using System;
using System.IO;

namespace FileSystemAnalizer.App
{
    public class Scanner<TFolderData> where TFolderData : IFolderScanData
    {
        private readonly Func<DirectoryInfo, TFolderData> folderDataFactory;
        public Scanner(Func<DirectoryInfo, TFolderData> folderDataFactory)
        {
            this.folderDataFactory = folderDataFactory;
        }

        public TFolderData Scan(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                throw new DirectoryNotFoundException();
            var result = folderDataFactory(new DirectoryInfo(folderPath));
            InspectAll(result);
            return result;
        }

        private void InspectAll(IFolderScanData folderData)
        {
            folderData.Inspect();
            foreach (var f in folderData.Folders)
                InspectAll(f);
        }
    }
}
