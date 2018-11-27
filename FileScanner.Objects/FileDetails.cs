using FileScanner.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScanner.Objects
{
    /// <summary>
    /// Stores the file names and MD5 Checksum of a file
    /// </summary>
    public class FileDetails : IFileDetails
    {
        public string Path { get; set; }
        
        public string Hash { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Path, Hash);
        }

        public override int GetHashCode()
        {
            return Hash.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (this.GetType() != obj.GetType())
                return false;

            IFileDetails d = (IFileDetails)obj;
            if (d.Hash == this.Hash && d.Path == this.Hash)
                return true;
            else
                return false;
        }
    }
}
