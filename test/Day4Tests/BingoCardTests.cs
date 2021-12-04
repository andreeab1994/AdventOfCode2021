using System;
using Day4;
using FluentAssertions;
using NUnit.Framework;
using Utils;

namespace Day4Tests
{
    internal class BingoCardTests
    {
        [Test(Description = "Challenge 1 example")]
        public void Challenge1Example()
        {
            var numbers = DataLoader.LoadLines("test.txt");
            var bingoGame = DataProcessor.ConvertData(numbers);

            var score = bingoGame.Play();
            score.Should().Be(4512);
        }

        [Test(Description = "Challenge 1")]
        public void Challenge1()
        {
            var numbers = DataLoader.LoadLines("challengeInput.txt");
            var bingoGame = DataProcessor.ConvertData(numbers);

            var score = bingoGame.Play();
            Console.WriteLine(score);
        }

        [Test(Description = "Challenge 2 example")]
        public void Challenge2Example()
        {
            var numbers = DataLoader.LoadLines("test.txt");
            var bingoGame = DataProcessor.ConvertData(numbers);
            bingoGame.PlayLosingGame = true;

            var score = bingoGame.Play();
            score.Should().Be(1924);
        }

        [Test(Description = "Challenge 2")]
        public void Challenge2()
        {
            var numbers = DataLoader.LoadLines("challengeInput.txt");
            var bingoGame = DataProcessor.ConvertData(numbers);
            bingoGame.PlayLosingGame = true;

            var score = bingoGame.Play();
            Console.WriteLine(score);
        }

    }
}
