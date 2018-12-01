using FileScanner.Interfaces.Algorithms;
using FileScanner.Interfaces.IO;
using FileScanner.Interfaces.Objects;
using FileScanner.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScanner.Algorithms
{
    /// <summary>
    /// Controls the flow of the whole system.
    /// </summary>
    public class ProcessingSystem : IProcessingSystem
    {

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ProcessingSystem(IScanningLocations scanningLocations,IDirectoryScanner directoryScanner)
        {
            scanningLocations_ = scanningLocations;
            directoryScanner_ = directoryScanner;
        }

        #endregion

        #region Variables

        /// <summary>
        /// Loads the data files and collections
        /// </summary>
        private readonly IScanningLocations scanningLocations_;
        
        #endregion

        #region Properties

        /// <summary>
        /// The details of the file paths.
        /// </summary>
        public IPathProperties PathProperties { get; set; }

        /// <summary>
        /// Details of any files that have been added to the system.
        /// </summary>
        public IFileDetailCollection AddedFiles { get; set; }

        /// <summary>
        /// Details of any files that have been updated to the system
        /// </summary>
        public IFileDetailCollection UpdatedFiles { get; set; }

        /// <summary>
        /// The paths of any files that have been removed
        /// </summary>
        public IEnumerable<string> RemovedFiles { get; set; }

        #endregion

        #region Processors

        /// <summary>
        /// An instance of the directectory of the scanner. 
        /// </summary>
        private readonly IDirectoryScanner directoryScanner_;

       

        #endregion

        /// <summary>
        /// Reads and validates the data files from the path properties object
        /// </summary>
        /// <returns>True if the process has a successfull run</returns>
        public bool GetFileInformation()
        {
            if (PathProperties == null)
                throw new ArgumentOutOfRangeException("PathProperties", "the path properties object is currently null");

            InitalizeCollections();
            
            return true;
        }

        /// <summary>
        /// Gets the informations from the files.
        /// </summary>
        /// <remarks>The paths to the files are specified in the PathProperties object</remarks>
        private bool InitalizeCollections()
        {
            if (!scanningLocations_.Populate(PathProperties))
                throw new ArgumentNullException("PathProperties", "unable to load the contents of the path files");

            if (scanningLocations_.Directories.Count() == 0)
                throw new ArgumentOutOfRangeException("Scanning Directories", "the scanning direcories cannot be null");
               
            return true;

        }

        /// <summary>
        /// Performs the main processing for the system
        /// </summary>
        /// <returns>True if the processing was able to complete without any issues false otherwise</returns>
        public bool ExecuteMainProcessing()
        {

            IEnumerable<string> fileList = directoryScanner_.GetFilesInDirectories(scanningLocations_.Directories);
            if (fileList.Count() == 0)
                return true;





            return false;

        }
    }
}
