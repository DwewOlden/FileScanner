using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileScanner.Algorithms
{
    /// <summary>
    /// Functionality related to the MD5 hash calculation
    /// </summary>
    public class MD5Calculator : FileScanner.Interfaces.IMD5Calculator
    {
        private readonly MD5 _calculator;

        public MD5Calculator()
        {
            _calculator = MD5.Create();
        }

        /// <summary>
        /// Calculates the MD5 had for the file with the passed path
        /// </summary>
        /// <param name="Path">The path of the file we want to calculate the MD5 hash of</param>
        /// <returns>The MD5 has for the file with the path passed.</returns>
        public string CalculateHash(string Path)
        {

            using (System.IO.FileStream stream = File.OpenRead(Path))
            {
                var bytes = _calculator.ComputeHash(stream);
                return BytesToString(bytes);
            }
        }

        /// <summary>
        /// Converts an array of bytes to a string
        /// </summary>
        /// <param name="bytes">An array of bytes</param>
        /// <returns>A string represening the byte array</returns>
        private string BytesToString(byte[] bytes)
        {
            var bytesAsString = "";

            foreach (byte b in bytes)
                bytesAsString += b.ToString("x2");

            return bytesAsString.ToUpper();
        }
    }
}
