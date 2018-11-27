using FileScanner.Interfaces.IO;
using FileScanner.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FileScanner.Objects;

namespace FileScanner.IO
{
    /// <summary>
    /// Functionality related to the loading of the file
    /// </summary>
    public class FileLoader : IFileLoader
    {
        /// <summary>
        /// Gets a list of directories we are scanning the system
        /// </summary>
        /// <param name="pathProperties">The path properties</param>
        /// <returns>A collection of directories covered by the system</returns>
        public IEnumerable<string> GetListOfDirectories(IPathProperties pathProperties)
        {
            if (!File.Exists(pathProperties.ListOfDirectoriesToBeScanned))
                return new List<string>().AsEnumerable();

            List<string> data = new List<string>();

            StreamReader reader = new StreamReader(pathProperties.ListOfDirectoriesToBeScanned);

            string line = reader.ReadLine();
            data.Add(line);

            while(line !=null)
            {
                line = reader.ReadLine();
                data.Add(line);
            }

            return data; 
        }

        /// <summary>
        /// Gets a list of 
        /// </summary>
        /// <param name="pathProperties">The path properties</param>
        /// <returns>Loads a collection of file information</returns>
        public IFileDetailCollection GetListOfFileHashSets(IPathProperties pathProperties)
        {
            FileDetailCollection fileDetailCollection = new FileDetailCollection();

            if (!File.Exists(pathProperties.ListOfDirectoriesToBeScanned))
                return new FileDetailCollection();
            
            StreamReader reader = new StreamReader(pathProperties.ListOfDirectoriesToBeScanned);

            string line = reader.ReadLine();
            IFileDetails fileDetails = GetFileDetails(line);
            if (fileDetails !=null)
                fileDetailCollection.Add(fileDetails);
            
            while (line != null)
            {
                line = reader.ReadLine();
                fileDetails = GetFileDetails(line);
                if (fileDetails != null)
                    fileDetailCollection.Add(fileDetails);
            }

            return fileDetailCollection;

        }

        /// <summary>
        /// Gets the file information from the passed line
        /// </summary>
        /// <param name="line">The line being scanned</param>
        /// <returns>A populated details object</returns>
        private IFileDetails GetFileDetails(string line)
        {
            if (string.IsNullOrEmpty(line))
                return null;

            string[] parts = line.Split(new string[] { "##!##" }, StringSplitOptions.None);
            if (parts.Length == 2)
                return new FileDetails() { Hash = parts[1], Path = parts[0] };
            else
                return null;
        }
    }
}
