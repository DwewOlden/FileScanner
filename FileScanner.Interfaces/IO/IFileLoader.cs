using FileScanner.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScanner.Interfaces.IO
{
    /// <summary>
    /// Functionality related to the data files.
    /// </summary>
    public interface IFileLoader
    {
        IEnumerable<string> GetListOfDirectories(IPathProperties pathProperties);

        IFileDetailCollection GetListOfFileHashSets(IPathProperties pathProperties);
    }
}
