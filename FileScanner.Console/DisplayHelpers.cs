using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScanner.Console
{
    /// <summary>
    /// A simple class that displays helper messages on the console application window
    /// </summary>
    public class DisplayHelpers
    {
        /// <summary>
        /// Displays a welcome message on the screen
        /// </summary>
        public static void DisplayWelcomeMessage()
        {
            System.Console.WriteLine("FileScanner Test Program");
            System.Console.WriteLine("------------------------");
            System.Console.WriteLine(" ");
            System.Console.WriteLine("Written By Me");
            System.Console.WriteLine(" ");

            Sleep(3);
            
        }

        /// <summary>
        /// Displays a goodbye message on the screen
        /// </summary>
        public static void DisplayGoodbyeMessage()
        {
            System.Console.WriteLine(" ");
            System.Console.WriteLine("All Done Sunshine...");
            System.Console.WriteLine(" ");
            Sleep(1);
        }

        /// <summary>
        /// Puts the main thread to sleep for the passed amount of time
        /// </summary>
        /// <param name="Seconds">The amount of time (in seconds) to sleep for</param>
        private static void Sleep(int Seconds)
        {
            System.Threading.Thread.Sleep(Seconds * 1000);
        }

    }
}
