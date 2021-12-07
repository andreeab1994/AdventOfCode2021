using System;
using Day7;
using FluentAssertions;
using NUnit.Framework;
using Utils;

namespace Day7Tests
{
    internal class CrabsTests
    {
        [Test(Description = "Challenge 1 example")]
        public void Challenge1Example()
        {
            var input = DataLoader.LoadLines("test.txt");

            var crabs = new Crabs(input);


            var calc = crabs.CalculateFuelConsumption();
            calc.Should().Be(37);

        }

        [Test(Description = "Challenge 1 ")]
        public void Challenge1()
        {
            var input = DataLoader.LoadLines("challengeInput.txt");

            var crabs = new Crabs(input);


            var calc = crabs.CalculateFuelConsumption();
            calc.Should().Be(355521);
            Console.WriteLine(calc);
        }

        [Test(Description = "Challenge 2 example")]
        public void Challenge2Example()
        {
            var input = DataLoader.LoadLines("test.txt");

            var crabs = new Crabs(input);

            var calc = crabs.CalculateFuelConsumption(true);
            calc.Should().Be(168);

        }

        [Test(Description = "Challenge 2")]
        public void Challenge2()
        {
            var input = DataLoader.LoadLines("challengeInput.txt");

            var crabs = new Crabs(input);

            var calc = crabs.CalculateFuelConsumption(true);
            calc.Should().Be(100148777);
            Console.WriteLine(calc);
        }

    }
}
