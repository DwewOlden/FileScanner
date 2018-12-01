using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileScanner.Interfaces.Objects;
using FileScanner.Unity;

namespace FileScanner.Console
{
    class Program
    {

        private static IPathProperties _PathProperties;


        static void Main(string[] args)
        {
            DisplayHelpers.DisplayWelcomeMessage();
            System.Threading.Thread.Sleep(3000);
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
            Unity.Bootstrapper.InitalizeUnity();
        }

        /// <summary>
        /// Performs the main processing.
        /// </summary>
        private static void PerformProcessing()
        {
            throw new NotImplementedException();
        }
    }
}
