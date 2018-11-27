using FileScanner.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScanner.Objects
{
    public class FileDetailCollection : HashSet<IFileDetails>, IFileDetailCollection
    {
        /// <summary>
        /// Indictates if a file has already been scanned.
        /// </summary>
        /// <param name="Filename">The name of the file we are scanning</param>
        /// <returns>True if the file has been scanned.</returns>
        public bool FileHasBeenScanned(string Filename)
        {
            return this.Any(f => f.Path.ToUpper() == Filename.ToUpper());
        }

    }
}
