using FileScanner.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScanner.Interfaces.IO
{
    public interface IFileWriter
    {
        bool WriteFile(IPathProperties pathProperties, IFileDetailCollection details);
    }
}
