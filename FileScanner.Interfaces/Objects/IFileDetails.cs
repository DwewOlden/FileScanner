using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScanner.Interfaces.Objects
{
    /// <summary>
    /// The path and hash of a file
    /// </summary>
    public interface IFileDetails
    {
        string Path { get; set; }

        string Hash { get; set; }
    }
}
