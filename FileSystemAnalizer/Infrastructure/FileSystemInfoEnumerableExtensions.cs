using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemAnalizer.Infrastructure
{
    public static class FileSystemInfoEnumerableExtensions
    {
        public static IEnumerable<DirectoryInfo> SafeEnumerateDirectories(this DirectoryInfo directoryInfo, out bool isFailed)
        {
            IEnumerable<DirectoryInfo> directories = Enumerable.Empty<DirectoryInfo>();
            isFailed = false;
            try
            {
                directories = directoryInfo.EnumerateDirectories();
            }
            catch
            {
                isFailed = true;
            }
            return directories;
        }

        public static IEnumerable<FileInfo> SafeEnumerateFiles(this DirectoryInfo directoryInfo, out bool isFailed)
        {
            IEnumerable<FileInfo> files = Enumerable.Empty<FileInfo>();
            isFailed = false;
            try
            {
                files = directoryInfo.EnumerateFiles();
            }
            catch
            {
                isFailed = true;
            }
            return files;
        }
    }
}
