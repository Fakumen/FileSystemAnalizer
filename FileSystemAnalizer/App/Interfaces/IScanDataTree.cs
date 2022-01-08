using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemAnalizer.App
{
    public interface IScanDataTreeBuilder
    {
        void Clear();
        void AddNode(IFolderDataNode node);
        void AddNode(IFileDataNode node);
    }
}
