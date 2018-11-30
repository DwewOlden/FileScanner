using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScanner.Interfaces.Algorithms
{
    public interface IDirectoryScanner
    {
        IEnumerable<string> GetFilesInDiretory(string Directory);

        IEnumerable<string> GetFilesInDirectories(IEnumerable<string> Direcories);

    }
}
