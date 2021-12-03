using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day2;
using FluentAssertions;
using NUnit.Framework;
using Utils;

namespace Day2Tests
{
    internal class ChallengeTests
    {
        [Test(Description = "")]
        public void ExampleChallenge1()
        {
            var navigation = Navigation.Create();

            var dataLoader = DataLoader.LoadLines("test.txt");
            var commands = DataProcessor.ConvertData(dataLoader);

            foreach (var command in commands)
            {
                command.Execute(navigation);
            }

            navigation.Values.Should().Be((15, 10, 0));
            navigation.Result.Should().Be(150);
        }

        [Test(Description = "")]
        public void CompleteChallenge1()
        {
            var navigation = Navigation.Create();

            var dataLoader = DataLoader.LoadLines("challengeInput.txt");
            var commands = DataProcessor.ConvertData(dataLoader);

            foreach (var command in commands)
            {
                command.Execute(navigation);
            }

            Console.WriteLine(navigation.Result);
        }

        [Test(Description = "")]
        public void ExampleChallenge2()
        {
            var navigation = Navigation.CreateWithAim();

            var dataLoader = DataLoader.LoadLines("test.txt");
            var commands = DataProcessor.ConvertData(dataLoader);

            foreach (var command in commands)
            {
                command.Execute(navigation);
            }

            navigation.Values.Should().Be((15, 60, 10));
            navigation.Result.Should().Be(900);
        }

        [Test(Description = "")]
        public void CompleteChallenge2()
        {
            var navigation = Navigation.CreateWithAim();

            var dataLoader = DataLoader.LoadLines("challengeInput.txt");
            var commands = DataProcessor.ConvertData(dataLoader);

            foreach (var command in commands)
            {
                command.Execute(navigation);
            }

            Console.WriteLine(navigation.Result);
        }
    }
}
