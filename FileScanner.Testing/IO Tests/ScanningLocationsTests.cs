using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using FileScanner.Interfaces.IO;
using FileScanner.Interfaces.Objects;
using FileScanner.Objects;

namespace FileScanner.Testing.IO_Tests
{
    [TestFixture]
    public class ScanningLocationsTests
    {

        [Test]
        [Category("UnitTesting")]
        public void FileScannedCheck()
        {
            var k = GetTestDirList();
            var k2 = GetFileDetailCollection();
            var m = GetPathProperties();

            Mock<IFileLoader> mockFileLoader = new Mock<IFileLoader>();
            mockFileLoader.Setup(f => f.GetListOfDirectories(It.IsAny<IPathProperties>())).Returns(k);
            mockFileLoader.Setup(f => f.GetListOfFileHashSets(It.IsAny<IPathProperties>())).Returns(k2);

            IScanningLocations scanningLocations = new ScanningLocations(mockFileLoader.Object);
            bool outcome = scanningLocations.Populate(m);

            Assert.AreEqual(true, outcome);
            Assert.AreEqual(true, scanningLocations.FileDetails.FileHasBeenScanned("B"));
            
        }
        
        [Test]
        [Category("UnitTesting")]
        public void TestFileLoading()
        {
            var k = GetTestDirList();
            var k2 = GetFileDetailCollection();
            var m = GetPathProperties();

            Mock<IFileLoader> mockFileLoader = new Mock<IFileLoader>();
            mockFileLoader.Setup(f => f.GetListOfDirectories(It.IsAny<IPathProperties>())).Returns(k);
            mockFileLoader.Setup(f => f.GetListOfFileHashSets(It.IsAny<IPathProperties>())).Returns(k2);

            IScanningLocations scanningLocations = new ScanningLocations(mockFileLoader.Object);
            bool outcome = scanningLocations.Populate(m);

            Assert.AreEqual(true, outcome);
            Assert.AreEqual(3, scanningLocations.Directories.Count());
            Assert.AreEqual(2, scanningLocations.FileDetails.FileCount);
        }

        public IFileDetailCollection GetFileDetailCollection()
        {
            var l = new FileDetailCollection()
            {
                new FileDetails()
                {
                    Hash = "A",
                    Path = "A"
                },

                new FileDetails()
                {
                    Hash = "B",
                    Path = "B"
                }
            };

            return l;
        }

        public IEnumerable<string> GetTestDirList()
            {
                var l = new List<string>()
            {
                @"C:\temp\A\",
                @"C:\temp\B\",
                @"C:\temp\C\"
            };

                return l.AsEnumerable();
            }

            public IPathProperties GetPathProperties()
            {
                var v = new PathProperties()
                {
                    ListOfDirectoriesToBeScanned = "A",
                    PathToHashCollection = "B"
                };

                return v;
            }
        
        }
    }
