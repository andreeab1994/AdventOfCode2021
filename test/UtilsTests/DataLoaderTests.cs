using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Utils;

namespace UtilsTests
{
    internal class DataLoaderTests
    {
        [Test(Description = "Data loader returns text file content")]
        public void LoadLines()
        {
            var fileInput = DataLoader.LoadLines("test.txt");

            fileInput.Should().NotBeNull();
        }

        [Test(Description = "Data loader returns text file content")]
        public void LoadLinesCount()
        {
            var fileInput = DataLoader.LoadLines("test.txt");

            fileInput.Count().Should().Be(6);
        }
    }
}
