using FileScanner.Interfaces.IO;
using FileScanner.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            throw new NotImplementedException();
        }
    }
}
