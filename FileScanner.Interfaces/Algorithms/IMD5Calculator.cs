using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScanner.Interfaces
{
    /// <summary>
    /// Methods used to calculate the MD5 hash of file.
    /// </summary>
    public interface IMD5Calculator
    {
        string CalculateHash(string Path);
    }
}
