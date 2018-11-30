using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScanner.Interfaces.Objects
{
    /// <summary>
    /// A collection of the direcories being scanned, and the historic details of any file
    /// </summary>
    public interface IScanningLocations
    {
        /// <summary>
        /// The directories we are going to scan
        /// </summary>
        IEnumerable<string> Directories { get; set; }

        /// <summary>
        /// The details of each file we have historically scanned.
        /// </summary>
        IFileDetailCollection FileDetails { get; set; }

        /// <summary>
        /// Populates the files from the files given in the passed object
        /// </summary>
        /// <param name="pathProperties">A object containing the paths to the files
        /// containing the informtion was are going to base our processing on.</param>
        /// <returns>True if the operation was successfull, false if it was not.</returns>
        bool Populate(IPathProperties pathProperties);
    }
}
