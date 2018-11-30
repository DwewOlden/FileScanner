using FileScanner.Interfaces.Algorithms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScanner.Algorithms
{
    /// <summary>
    /// Contains functionality to scan all the files in a set of direcories
    /// </summary>
    public class DirectoryScanner : IDirectoryScanner
    {
        /// <summary>
        /// Gets all the files in the passed collection of directories
        /// </summary>
        /// <param name="Direcories">A collection of directories</param>
        /// <returns>The entire FileInfo selection for the passed set of directories</returns>
        public IEnumerable<string> GetFilesInDirectories(IEnumerable<string> Direcories)
        {
            List<string> all = new List<string>();

            foreach (string directory in Direcories)
                all.AddRange(GetFilesInDiretory(directory));

            return all.AsEnumerable();
        }

        /// <summary>
        /// Gets all the files in the passed directory
        /// </summary>
        /// <param name="Directory">The directory containing the files we are intrested in</param>
        /// <returns>The file info selection in the passed directory</returns>
        public IEnumerable<string> GetFilesInDiretory(string Directory)
        {
            DirectoryInfo d = new DirectoryInfo(Directory);
            return d.EnumerateFiles("*.*", SearchOption.AllDirectories).Select(f=>f.FullName).AsEnumerable();
        }
    }
}
