using System;
using System.Collections.Generic;
using System.IO;

namespace Utils
{
    public static class DataLoader
    {
        public static IEnumerable<string> LoadLines(string fileName)
        {
            var projectRoot = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
            var dataPath = Path.Combine(projectRoot, "Data");
            var path = Path.Combine(dataPath, fileName);

            return File.ReadLines(path);
        }
    }
}
