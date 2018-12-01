using FileScanner.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScanner.Interfaces.Algorithms
{
    public interface IProcessingSystem
    {
        IFileDetailCollection AddedFiles { get; set; }

        IFileDetailCollection UpdatedFiles { get; set; }

        IEnumerable<string> RemovedFiles { get; set; }

        bool ProcessFileDetails();
    }
}
