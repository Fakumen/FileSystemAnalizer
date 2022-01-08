using FileSystemAnalizer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemAnalizer.App
{
    public interface IDataNode<out TScanData>
        where TScanData : IScanData
    {
        TScanData ScanData { get; }
        string Label { get; set; }
    }
}
