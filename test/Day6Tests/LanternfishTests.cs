using Day6;
using FluentAssertions;
using NUnit.Framework;
using Utils;

namespace Day6Tests
{
    internal class LanternfishTests
    {
        [Test(Description = "Challenge 1 example")]
        public void Challenge1Example()
        {
            var input = DataLoader.LoadLines("test.txt");

            var report = DataProcessor.ConvertDataChallenge(input);
            var calculator = new Calculator(report);

            var fish = calculator.Calculate(18);
            fish.Should().Be(26);

        }

        [Test(Description = "Challenge 1")]
        public void Challenge1()
        {
            var input = DataLoader.LoadLines("challengeInput.txt");

            var report = DataProcessor.ConvertDataChallenge(input);
            var calculator = new Calculator(report);

            var fish = calculator.Calculate(80);
            fish.Should().Be(359344);

        }

        [Test(Description = "Challenge 2 example")]
        public void Challenge2Example()
        {
            var input = DataLoader.LoadLines("test.txt");

            var report = DataProcessor.ConvertDataChallenge(input);
            var calculator = new Calculator(report);

            var fish = calculator.Calculate(256);
            fish.Should().Be(26984457539);

        }

        [Test(Description = "Challenge 2")]
        public void Challenge2()
        {
            var input = DataLoader.LoadLines("challengeInput.txt");

            var report = DataProcessor.ConvertDataChallenge(input);
            var calculator = new Calculator(report);

            var fish = calculator.Calculate(256);
            fish.Should().Be(1629570219571);
        }

    }

}
