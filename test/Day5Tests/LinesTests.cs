using System;
using Day5;
using FluentAssertions;
using NUnit.Framework;
using Utils;

namespace Day5Tests
{
    internal class LinesTests
    {
        [Test(Description = "Challenge 1 example")]
        public void Challenge1Example()
        {
            var input = DataLoader.LoadLines("test.txt");
            var lines = DataProcessor.ConvertDataLines(input);

            var points = lines.CalculateAll();
            lines.Print2DArray<int>();
            points.Should().Be(5);
        }

        [Test(Description = "Challenge 1")]
        public void Challenge1()
        {
            var input = DataLoader.LoadLines("challengeInput.txt");
            var lines = DataProcessor.ConvertDataLines(input);

            var points = lines.CalculateAll();
            Console.WriteLine(points);
            points.Should().Be(7644);
        }

        [Test(Description = "Challenge 2 example")]
        public void Challenge2Example()
        {
            var input = DataLoader.LoadLines("test.txt");
            var lines = DataProcessor.ConvertDataLines(input);

            var points = lines.CalculateAll(true);
            lines.Print2DArray<int>();

            points.Should().Be(12);
        }

        [Test(Description = "Challenge 2")]
        public void Challenge2()
        {
            var input = DataLoader.LoadLines("challengeInput.txt");
            var lines = DataProcessor.ConvertDataLines(input);

            var points = lines.CalculateAll(true);
            lines.Print2DArray<int>();
            Console.WriteLine(points);
            points.Should().Be(18627);

        }
    }
}
