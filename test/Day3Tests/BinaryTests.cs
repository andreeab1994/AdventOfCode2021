using System;
using Day3;
using FluentAssertions;
using NUnit.Framework;
using Utils;

namespace Day3Tests
{
    internal sealed class BinaryTests
    {
        [Test(Description = ".")]
        public void Challenge1Example()
        {
            var logs = DataLoader.LoadLines("test.txt");

            var binaryDiagnostic = new BinaryDiagnostic(logs);
            binaryDiagnostic.Process();
            
            binaryDiagnostic.GammaRate.Should().Be(22);
            binaryDiagnostic.EpsilonRate.Should().Be(9);
            binaryDiagnostic.GetPowerConsumption().Should().Be(198);
        }

        [Test(Description = ".")]
        public void Challenge2Example()
        {
            var logs = DataLoader.LoadLines("test.txt");

            var lifeSupportRating = new LifeSupportRating(logs);
            lifeSupportRating.Process();

            lifeSupportRating.OxygenGeneratorRating.Should().Be(23);
            lifeSupportRating.Co2ScrubberRating.Should().Be(10);
            lifeSupportRating.Rating.Should().Be(230);
        }

        [Test(Description = ".")]
        public void Challenge1()
        {
            var logs = DataLoader.LoadLines("challengeInput.txt");

            var binaryDiagnostic = new BinaryDiagnostic(logs);
            binaryDiagnostic.Process();

            var powerConsumption = binaryDiagnostic.GetPowerConsumption();
            Console.WriteLine(powerConsumption);
            powerConsumption.Should().Be(3429254);

        }

        [Test(Description = ".")]
        public void Challenge2()
        {
            var logs = DataLoader.LoadLines("challengeInput.txt");

            var lifeSupportRating = new LifeSupportRating(logs);
            lifeSupportRating.Process();

            Console.WriteLine(lifeSupportRating.Rating);
            lifeSupportRating.Rating.Should().Be(5410338);
        }
    }
}
