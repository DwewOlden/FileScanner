using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScanner.Interfaces.Algorithms
{
    /// <summary>
    /// Manages the process of adding a series of files to a zip file 
    /// and then copies the files to the long term storage directory
    /// </summary>
    public interface IZipManager
    {
        /// <summary>
        /// The location where the compressed file will be copied to
        /// </summary>
        string DestinationFolder { get; set; }

        /// <summary>
        /// Zips the passed collection of files and places the result into the 
        /// folder indicated in the DestinationFolder property
        /// </summary>
        /// <param name="FilesToBeCompressed">A collection of file paths, each of which will be compressed
        /// in this operation</param>
        /// <returns>True if all operations were successfull, false if they were not</returns>
        bool PerformZip(IEnumerable<string> FilesToBeCompressed);

    }
}
