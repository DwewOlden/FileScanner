using FileScanner.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScanner.Interfaces.Algorithms
{
    /// <summary>
    /// Controls the flow of the whole system.
    /// </summary>
    public interface IProcessingSystem
    {
        /// <summary>
        /// The details of the file paths.
        /// </summary>
        IPathProperties PathProperties { get; set; }

        /// <summary>
        /// Details of any files that have been added to the system.
        /// </summary>
        IFileDetailCollection AddedFiles { get; set; }

        /// <summary>
        /// Details of any files that have been updated to the system
        /// </summary>
        IFileDetailCollection UpdatedFiles { get; set; }

        /// <summary>
        /// The paths of any files that have been removed
        /// </summary>
        IEnumerable<string> RemovedFiles { get; set; }

        /// <summary>
        /// Reads and validates the data files from the path properties object
        /// </summary>
        /// <returns>True if the process has a successfull run</returns>
        bool GetFileInformation();

        /// <summary>
        /// Performs the main processing for the system
        /// </summary>
        /// <returns>True if the processing was able to complete without any issues false otherwise</returns>
        bool ExecuteMainProcessing();
    }
}
