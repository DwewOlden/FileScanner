using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScanner.Interfaces.Objects
{
    public interface IPathProperties
    {
        string ListOfDirectoriesToBeScanned { get; set; }

        string PathToHashCollection { get; set; }

        string ZipFileLocation { get; set; }
    }
}
