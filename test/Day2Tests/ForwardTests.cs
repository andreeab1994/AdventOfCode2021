using System;
using System.Linq;
using Day2;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using Utils;

namespace Day2Tests
{
    internal sealed class ForwardTests
    {
        [Test(Description = ".")]
        [TestCase(new[] {3,4,6}, 13,0,0)]
        public void Forward(int[] commands, int expectedHorizontalPosition, int expectedDepth, int expectedAim)
        {
            var navigation = Navigation.Create();
            foreach (var command in commands)
            {
                navigation.Forward(command);
            }

            navigation.Values.Should().Be((expectedHorizontalPosition, expectedDepth, expectedAim));
        }

        [Test(Description = "")]
        [TestCase(new[] { 3, 4, 6 }, 13, 0, 0)]
        public void ForwardWithAim(int[] commands, int expectedHorizontalPosition, int expectedDepth, int expectedAim)
        {
            var navigation = Navigation.CreateWithAim();

            foreach (var command in commands)
            {
                navigation.Forward(command);
            }
            navigation.Values.Should().Be((expectedHorizontalPosition, expectedDepth, expectedAim));
        }
    }
}
