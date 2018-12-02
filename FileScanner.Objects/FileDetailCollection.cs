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
        public FileDetailCollection(IEnumerable<IFileDetails> collection) : base(collection)
        {
        }

        public FileDetailCollection()
        {
        }

        /// <summary>
        /// Indictates if a file has already been scanned.
        /// </summary>
        /// <param name="Filename">The name of the file we are scanning</param>
        /// <returns>True if the file has been scanned.</returns>
        public bool FileHasBeenScanned(string Filename)
        {
            return this.Any(f => f.Path.ToUpper() == Filename.ToUpper());
        }

        /// <summary>
        /// Gets the details for the files where the name of the file is in the passed collection
        /// </summary>
        /// <param name="existingFiles">A collection of file names</param>
        /// <returns></returns>
        public IEnumerable<IFileDetails> GetDetails(IEnumerable<string> existingFiles)
        {
            IEnumerable<IFileDetails> existing = this.Where(f => existingFiles.Contains(f.Path));
            return existing;
            
        }

        /// <summary>
        /// Returns a count of the files
        /// </summary>
        /// <returns>The number of file elements being scanned.</returns>
        public int FileCount
        {
            get
            {
                return this.Count;
            }
        }

        /// <summary>
        /// Gets the paths of all files in the collection
        /// </summary>
        public IEnumerable<string> Files
        {
            get
            {
                return this.Select(f => f.Path);
            }
        }

    }
}
