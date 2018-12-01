using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileScanner.Interfaces.Algorithms;
using FileScanner.Interfaces.Objects;
using FileScanner.Objects;
using FileScanner.UnitySystem;
using Unity;

namespace FileScanner.Console
{
    class Program
    {
        /// <summary>
        /// Contains details about the paths of the data files
        /// </summary>
        private static IPathProperties _PathProperties;

        private static IProcessingSystem _processingSystem;


        static void Main(string[] args)
        {
            DisplayHelpers.DisplayWelcomeMessage();
            System.Threading.Thread.Sleep(0);
            Initalize();

            PerformProcessing();


            DisplayHelpers.DisplayGoodbyeMessage();
            System.Threading.Thread.Sleep(1000);


        }

        /// <summary>
        /// Initalize the unity system and so on
        /// </summary>
        private static void Initalize()
        {
            UnitySystem.Bootstrapper.InitalizeUnity();
            _processingSystem = UnitySystem.Bootstrapper.UnityContainer.Resolve<IProcessingSystem>();
        }

        /// <summary>
        /// Performs the main processing.
        /// </summary>
        private static void PerformProcessing()
        {
            // Load the data files.
            LoadDataFiles();

            // Execute the main processing run, assumung the files have been loaded during
            /// during the LoadDataFiles procedure.
            if (!_processingSystem.ExecuteMainProcessing())
                throw new Exception("there was an issue in the main processing of the system");
        }

        /// <summary>
        /// Load the datafiles given in the properties of the application
        /// </summary>
        private static void LoadDataFiles()
        {
            string directories = Properties.Settings.Default.DirectoryPath;
            string files = Properties.Settings.Default.FileDetails;

            _PathProperties = new PathProperties()
            {
                ListOfDirectoriesToBeScanned = directories,
                PathToHashCollection = files
            };

            _processingSystem.PathProperties = _PathProperties;
            if (!_processingSystem.GetFileInformation())
                throw new ArgumentNullException("fileError", "the files could not be loaded");
           
        }
    }
}
