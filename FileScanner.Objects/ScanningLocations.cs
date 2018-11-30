using FileScanner.Interfaces.IO;
using FileScanner.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScanner.Objects
{
    /// <summary>
    /// Properties for the scanning locations
    /// </summary>
    public class ScanningLocations : IScanningLocations
    {
        /// <summary>
        /// An implemention of the file loader
        /// </summary>
        private readonly IFileLoader fileLoader_;

        /// <summary>
        /// A list of the directories to be scanned
        /// </summary>
        public IEnumerable<string> Directories { get; set; }

        /// <summary>
        /// The details of each file we have historically scanned.
        /// </summary>
        public IFileDetailCollection FileDetails { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="fileLoader">An instance of the file loader object</param>
        public ScanningLocations(IFileLoader fileLoader)
        {
            fileLoader_ = fileLoader;
        }

        /// <summary>
        /// Populates the files from the files given in the passed object
        /// </summary>
        /// <param name="pathProperties">A object containing the paths to the files
        /// containing the informtion was are going to base our processing on.</param>
        /// <returns>True if the operation was successfull, false if it was not.</returns>
        public bool Populate(IPathProperties pathProperties)
        {
            Directories = fileLoader_.GetListOfDirectories(pathProperties);
            if (Directories == null)
                return false;

            FileDetails = fileLoader_.GetListOfFileHashSets(pathProperties);
            if (FileDetails == null)
                return false;

            return true;
        }
    }
}
