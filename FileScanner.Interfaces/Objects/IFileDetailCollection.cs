using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScanner.Interfaces.Objects
{
    public interface IFileDetailCollection
    {
        /// <summary>
        /// Determines if a file has been scan
        /// </summary>
        /// <param name="Filename">The name of the file we want the scanned status for</param>
        /// <returns>True if file has been scanned, false if it has not</returns>
        bool FileHasBeenScanned(string Filename);

        /// <summary>
        /// Counts the files 
        /// </summary>
        int FileCount { get; }

        /// <summary>
        /// Gets the paths of all files in the collection
        /// </summary>
        IEnumerable<string> Files { get; }
      
    }
}
