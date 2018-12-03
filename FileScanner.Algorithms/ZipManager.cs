using FileScanner.Interfaces.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace FileScanner.Algorithms
{
    /// <summary>
    /// Implements the zip management functionality. This ensures requires will be 
    /// zipped and copied over to the correct location(s).
    /// </summary>
    public class ZipManager : IZipManager
    {
        /// <summary>
        /// The location where the compressed file will be copied to
        /// </summary>
        public string DestinationFolder
        {
            get;
            set;
        }

        /// <summary>
        /// Zips the passed collection of files and places the result into the 
        /// folder indicated in the DestinationFolder property
        /// </summary>
        /// <param name="FilesToBeCompressed">A collection of file paths, each of which will be compressed
        /// in this operation</param>
        /// <returns>True if all operations were successfull, false if they were not</returns>
        public bool PerformZip(IEnumerable<string> FilesToBeCompressed)
        {
            if (!CollectionIsValid(FilesToBeCompressed))
                return false;

            string destinationPath = GetDestinationPath();
            DeleteFileIfNeeded(destinationPath);

            using (ZipArchive compressedFile = ZipFile.Open(destinationPath, ZipArchiveMode.Create))
            {
                foreach (string FileToBeCompressed in FilesToBeCompressed)
                {
                    if (System.IO.File.Exists(FileToBeCompressed))
                    {
                        string entryName = FileToBeCompressed.Replace(@"C:\", string.Empty);
                        entryName = entryName.Replace(@"\", "_");
                        compressedFile.CreateEntryFromFile(FileToBeCompressed, entryName);
                    }
                }
            }

            return true;
            
        }

        /// <summary>
        /// Removes any instance of file, as it will crash if we try and write 
        /// another record with the same name
        /// </summary>
        /// <param name="destinationPath">The path to the file</param>
        private void DeleteFileIfNeeded(string destinationPath)
        {
            if (System.IO.File.Exists(destinationPath))
                System.IO.File.Delete(destinationPath);
        }

        /// <summary>
        /// Determines the path where the zip compressed file will be stored
        /// </summary>
        /// <returns>The path (including name) of the path zip of the zip destination </returns>
        private string GetDestinationPath()
        {
            if (string.IsNullOrEmpty(DestinationFolder))
                throw new ArgumentOutOfRangeException("destinationFolder", "the destination folder has not been specified");

            if (!System.IO.Directory.Exists(DestinationFolder))
                throw new ArgumentOutOfRangeException("destinationFolder", "the destination folder is not accessibile (or does not exist)");

            string fileName = GenerateFileName();
            return string.Format(@"{0}\{1}.zip", DestinationFolder, fileName);

        }

        /// <summary>
        /// Get the path, this is based on the current date
        /// </summary>
        /// <returns>The name of the file the compressed file will be saved under</returns>
        private string GenerateFileName()
        {
            DateTime now = DateTime.Now;
            string fileName = string.Format("{0}{1}{2}", now.Year, now.Month, now.Day);

            return fileName;
        }



        /// <summary>
        /// Checks if the passed collection is valid
        /// </summary>
        /// <param name="FilesToBeCompressed">A collection of file paths, each of which will be compressed</param>
        /// <returns>True if the collecion is valid, false if it was not</returns>
        private bool CollectionIsValid(IEnumerable<string> FilesToBeCompressed)
        {
            if (FilesToBeCompressed == null)
                return false;

            if (FilesToBeCompressed.Count() == 0)
                return false;

            return true;
        }
    }
}
