using FileScanner.Algorithms;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScanner.Testing.IO_Tests
{

    [TestFixture]
    public class MD5CalculationTests
    {
        [Test]
        [Category("IntegrationTest")]
        public void MD5Test1()
        {
            var expected = "6776AB698F0A504E4FEED01C51AD1381";
            var _system = new MD5Calculator();
            var path = GetTestDataFolder("TestFile1.txt");

            var outcome = _system.CalculateHash(path);
            Assert.AreEqual(expected,outcome);
            
        }

        [Test]
        [Category("IntegrationTest")]
        public void MD5Test2()
        {
            var expected = "B8C286621A6A1B1EBAC3045F70C02083";
            var _system = new MD5Calculator();
            var path = GetTestDataFolder("TestFile2.txt");

            var outcome = _system.CalculateHash(path);
            Assert.AreEqual(expected, outcome);


        }

        [Test]
        [Category("IntegrationTest")]
        public void MD5Test3()
        {
            var expected = "25CCDEC89F782323C8B65DA051B7B4D3";
            var _system = new MD5Calculator();
            var path = GetTestDataFolder("TestFile3.txt");

            var outcome = _system.CalculateHash(path);
            Assert.AreEqual(expected, outcome);


        }

        public string GetTestDataFolder(string testDataFolder)
        {
            string startupPath = AppDomain.CurrentDomain.BaseDirectory;

            var pathItems = startupPath.Split(Path.DirectorySeparatorChar);
            var pos = pathItems.Reverse().ToList().FindIndex(x => string.Equals("bin", x));
            string projectPath = String.Join(Path.DirectorySeparatorChar.ToString(), pathItems.Take(pathItems.Length - pos - 1));

            return Path.Combine(projectPath, "Data", testDataFolder);
        }
    }
}
