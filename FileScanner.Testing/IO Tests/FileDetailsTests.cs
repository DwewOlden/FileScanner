using FileScanner.Interfaces.Objects;
using FileScanner.Objects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScanner.Testing.IO_Tests
{
    [TestFixture]
    public class FileDetailsTests
    {
        [Test]
        [Category("UnitTest")]
        public void FileEqualsTest()
        {
            var d = GetOutline();
            var d1 = GetOutline();

            Assert.AreEqual(true, d1.Equals(d));
        }

        [Test]
        [Category("UnitTest")]
        public void FileToStringTest()
        {
            var o = GetOutline().ToString();
            var p = "Path - Hash";

            Assert.AreEqual(o, p);
        }

        private IFileDetails GetOutline()
        {
            IFileDetails d = new FileDetails()
            {
                Hash = "Hash",
                Path = "Path"
            };

            return d;
        }
    }
}
