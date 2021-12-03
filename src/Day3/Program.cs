using System;
using Utils;

namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var loadData = DataLoader.LoadLines("../text.txt");
            Console.WriteLine(loadData);
        }
    }
}
