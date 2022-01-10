using System;

namespace FileSystemAnalyzer.Infrastructure
{
    public interface ILazyDataLoader<TData>
    {
        bool IsDataReady { get; }
        event Action<TData> DataReady;
    }
}
