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
    /// Writes the file details collection to the file
    /// </summary>
    public class FileWriter : IFileWriter
    {
        /// <summary>
        /// Writes the files
        /// </summary>
        /// <param name="pathProperties">Contains the path where we want to stop the file</param>
        /// <param name="details">The collection of files to be saved</param>
        /// <returns></returns>
        public bool WriteFile(IPathProperties pathProperties, IFileDetailCollection details)
        {
            StreamWriter writer = new StreamWriter(pathProperties.PathToHashCollection);

            foreach (IFileDetails record in (FileDetailCollection)details)
            {
                string output = string.Format("{0}##!##{1}", record.Path, record.Hash);
                writer.WriteLine(output);
                writer.Flush();
            }

            writer.Close();
            writer.Dispose();
            writer = null;

            return true;



        }
    }
}
