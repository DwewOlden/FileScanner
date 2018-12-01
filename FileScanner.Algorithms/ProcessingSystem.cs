using FileScanner.Interfaces.Algorithms;
using FileScanner.Interfaces.Objects;
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

        public ProcessingSystem()
        {

        }



        /// <summary>
        /// Details of any files that have been added to the system.
        /// </summary>
        public IFileDetailCollection AddedFiles { get; set; }

        /// <summary>
        /// Details of any files that have been updated to the system
        /// </summary>
        public IFileDetailCollection UpdatedFiles { get; set; }

        /// <summary>
        /// The paths of any files that have been
        /// </summary>
        public IEnumerable<string> RemovedFiles { get; set; }

        /// <summary>
        /// Main entry point into the system.
        /// </summary>
        /// <returns></returns>
        public bool ProcessFileDetails()
        {
            throw new NotImplementedException();
        }
    }
}
