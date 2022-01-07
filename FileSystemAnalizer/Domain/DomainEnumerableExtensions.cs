﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemAnalizer.Domain
{
    public static class DomainEnumerableExtensions
    {
        public static IEnumerable<TInfo> Filter<TInfo>(this IEnumerable<TInfo> fileSystemInfos, bool skipSystemEntries)
            where TInfo : FileSystemInfo
            => fileSystemInfos.Where(info => !skipSystemEntries || !info.Attributes.HasFlag(FileAttributes.System));

        public static IEnumerable<DirectoryInfo> SafeEnumerateDirectories(this DirectoryInfo directoryInfo)
        {
            IEnumerable<DirectoryInfo> directories = Enumerable.Empty<DirectoryInfo>();
            try
            {
                directories = directoryInfo.EnumerateDirectories();
            }
            catch
            {
                //обработка папок, к которым нет доступа
            }
            return directories;
        }

        public static IEnumerable<FileInfo> SafeEnumerateFiles(this DirectoryInfo directoryInfo)
        {
            IEnumerable<FileInfo> directories = Enumerable.Empty<FileInfo>();
            try
            {
                directories = directoryInfo.EnumerateFiles();
            }
            catch
            {
                //обработка файлов, к которым нет доступа
            }
            return directories;
        }
    }
}