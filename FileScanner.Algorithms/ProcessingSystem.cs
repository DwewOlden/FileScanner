using FileScanner.Interfaces;
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
        public ProcessingSystem(IScanningLocations scanningLocations,IDirectoryScanner directoryScanner,IMD5Calculator mD5Calculator)
        {
            scanningLocations_ = scanningLocations;
            directoryScanner_ = directoryScanner;
            mD5Calculator_ = mD5Calculator;
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

        /// <summary>
        /// An instance of the MD5 Hash Calculator.
        /// </summary>
        private readonly IMD5Calculator mD5Calculator_;

       

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

            CalculateListContents(fileList);
 
            PerformCompressionOnNewOrUpdatedFiles();
            
            
            return false;

        }

        /// <summary>
        /// Gets the paths to all new or amended paths and passes those to the zip
        /// manager for compression.
        /// </summary>
        private void PerformCompressionOnNewOrUpdatedFiles()
        {
            List<string> toBeCompressed = new List<string>();

            toBeCompressed.AddRange(UpdatedFiles.Files);
            toBeCompressed.AddRange(AddedFiles.Files);


        }

        /// <summary>
        /// Generates lists of file that have been added, amended or deleted.
        /// </summary>
        private void CalculateListContents(IEnumerable<string> fileList)
        {
            GenerateListOfNewFiles(fileList);
            GenerateListOfAmendedFiles(fileList);
            GeneratedListOfDeletedFiles(fileList);
            
        }

        /// <summary>
        /// Checks if any files have been deleted
        /// </summary>
        /// <param name="fileList">A list of all files being scanned</param>
        private void GeneratedListOfDeletedFiles(IEnumerable<string> fileList)
        {
            List<string> removedFiles = new List<string>();
            IEnumerable<string> existingFiles = scanningLocations_.FileDetails.Files;

            foreach (string file in existingFiles)
                if (!fileList.Contains(file))
                    removedFiles.Add(file);

            RemovedFiles = removedFiles;
            
        }

        /// <summary>
        /// Checks if any files have been amended
        /// </summary>
        /// <param name="fileList">A list of all files being scanned</param>
        private void GenerateListOfAmendedFiles(IEnumerable<string> fileList)
        {
            List<string> existingFiles = new List<string>();
           
            foreach (string currentFile in fileList)
                if (scanningLocations_.FileDetails.Files.Contains(currentFile))
                    existingFiles.Add(currentFile);

            IEnumerable<IFileDetails> existingDetails = scanningLocations_.FileDetails.GetDetails(existingFiles);
            
            UpdatedFiles = CheckForUpdatesToExistingFiles(existingDetails);
        }

        /// <summary>
        /// Determines which members of the passed collection have been amended since last scan
        /// </summary>
        /// <param name="existingDetails">A collection of file details, all of which have previusly been scanned</param>
        /// <returns>A collection of files that have been changed, together the new hash values</returns>
        private IFileDetailCollection CheckForUpdatesToExistingFiles(IEnumerable<IFileDetails> existingDetails)
        {
            List<IFileDetails> amendedFiles = new List<IFileDetails>();

            foreach (IFileDetails existingDetail in existingDetails)
            {
                string hash = mD5Calculator_.CalculateHash(existingDetail.Path);
                if (hash != existingDetail.Hash)
                {
                    IFileDetails updated = GenerateMD5Checksum(existingDetail.Path);
                    amendedFiles.Add(updated);
                }
            }

            return new FileDetailCollection(amendedFiles);
        }

        /// <summary>
        /// Checks if any file have been added 
        /// </summary>
        /// <param name="fileList">A list of all files being scanned</param>
        private void GenerateListOfNewFiles(IEnumerable<string> fileList)
        {

            List<string> newFiles = new List<string>();

            foreach (string currentFile in fileList)
                if (!scanningLocations_.FileDetails.Files.Contains(currentFile))
                    newFiles.Add(currentFile);

            AddedFiles = GenerateMD5Checksums(newFiles);
            
        }

        /// <summary>
        /// Generates a collection of checksums for the passed collection of files.
        /// </summary>
        /// <param name="newFiles">A collection of files, each of which will require a new MD5 checksum</param>
        /// <returns>A new collection of MD5</returns>
        private IFileDetailCollection GenerateMD5Checksums(IEnumerable<string> newFiles)
        {
            FileDetailCollection collection = new FileDetailCollection();

            foreach (string file in newFiles)
                if (System.IO.File.Exists(file))
                {
                    IFileDetails d = GenerateMD5Checksum(file);
                    collection.Add(d);
                }

            return collection;
        }

        /// <summary>
        /// Generates the MD5 checksum for the file at the passed path
        /// </summary>
        /// <param name="file">A path to a file </param>
        /// <returns>A file detail object, giving the the path and hash</returns>
        private IFileDetails GenerateMD5Checksum(string file)
        {
            string md5 = mD5Calculator_.CalculateHash(file);
            IFileDetails fileDetails = new FileDetails()
            {
                Hash = md5,
                Path = file
            };

            return fileDetails;
        }
    }
}
