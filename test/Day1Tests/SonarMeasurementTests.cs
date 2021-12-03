using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day1;
using FluentAssertions;
using NUnit.Framework;

namespace Day1Tests
{
    internal class SonarMeasurementTests
    {
        [Test(Description = ".")]
        [TestCase(new[] { 3, 4, 6,2,1 }, 3)]
        public void CompareDepths(int[] commands, int expectedDepthIncreases)
        {
            var sonarSweep = SonarSweep.Create();
            for (var i = 1; i < commands.Length; i++)
            {
                sonarSweep.CompareDepths(commands[i],commands[i-1]);
            }

            sonarSweep.DepthIncreases.Should().Be(expectedDepthIncreases);
        }
    }
}
