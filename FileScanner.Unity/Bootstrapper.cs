using FileScanner.Algorithms;
using FileScanner.Interfaces;
using FileScanner.Interfaces.Algorithms;
using FileScanner.Interfaces.IO;
using FileScanner.Interfaces.Objects;
using FileScanner.IO;
using FileScanner.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace FileScanner.Unity
{
    /// <summary>
    /// A class that will initalize the unty system.
    /// </summary>
    public static class Bootstrapper
    {
        public static readonly UnityContainer UnityContainer = new UnityContainer();

        /// <summary>
        /// Registers the interfaces with the implemention. 
        /// </summary>
        /// <remarks>
        /// split into sections for readability only,
        /// </remarks>
        public static void InitalizeUnity()
        {
            RegisterProcessors();
            RegisterIOHelpers();
            RegisterObjects();
            
        }

        /// <summary>
        /// Register the IO helpers associated with the system
        /// </summary>
        private static void RegisterIOHelpers()
        {
            UnityContainer.RegisterType<IFileLoader, FileLoader>();
        }

        /// <summary>
        /// Register the support objects.
        /// </summary>
        private static void RegisterObjects()
        {
            UnityContainer.RegisterType<IFileDetailCollection, FileDetailCollection>();
            UnityContainer.RegisterType<IFileDetails, FileDetails>();
            UnityContainer.RegisterType<IPathProperties, PathProperties>();
            UnityContainer.RegisterType<IScanningLocations, ScanningLocations>();
        }
        
        /// <summary>
        /// Register the processors
        /// </summary>
        private static void RegisterProcessors()
        {
            UnityContainer.RegisterType<IDirectoryScanner, DirectoryScanner>();
            UnityContainer.RegisterType<IProcessingSystem, ProcessingSystem>();
            UnityContainer.RegisterType<IMD5Calculator, MD5Calculator>();
        }

    }
}
