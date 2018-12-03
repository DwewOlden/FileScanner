using FileScanner.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScanner.Objects
{
    /// <summary>
    /// A set of path properties
    /// </summary>
    public class PathProperties : IPathProperties
    {
        public string ListOfDirectoriesToBeScanned { get; set; }

        public string PathToHashCollection { get; set; }

        public string ZipFileLocation { get; set; }
    }
}
