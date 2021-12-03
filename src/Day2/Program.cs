using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Challenge1();

            Challenge2();
        }

        private static void Challenge2()
        {
            const string fileName = "input.txt";
            var horizontalPosition = 0;
            var depth = 0;
            var aim = 0;

            var input = ReadTextFile(fileName);

            var processedInput = TransformInput(input);

            (horizontalPosition, depth, aim) = CalculatePosition(processedInput, horizontalPosition, depth, aim);
            Console.WriteLine($"Your horizontal position is: {horizontalPosition}");
            Console.WriteLine($"Your depth is: {depth}");
            Console.WriteLine($"Your aim is: {aim}");


            var multiplicationResult = horizontalPosition * depth;
            Console.WriteLine($"Horizontal position * Depth = {multiplicationResult}");
        }

        private static (int horizontalPosition, int depth, int aim) CalculatePosition(List<Tuple<string, int>> processedInput, int horizontalPosition, int depth, int aim)
        {
            foreach (var pair in processedInput)
            {
                if (pair.Item1 == "down")
                {
                    aim += pair.Item2;
                    Console.WriteLine($"({pair.Item1},{pair.Item2})-Aim increased => {aim}");
                }

                if (pair.Item1 == "up")
                {
                    aim -= pair.Item2;
                    Console.WriteLine($"({pair.Item1},{pair.Item2})-Aim decreased => {aim}");
                }

                if (pair.Item1 == "forward")
                {
                    horizontalPosition += pair.Item2;
                    Console.WriteLine($"({pair.Item1},{pair.Item2})-Horizontal position increased => {horizontalPosition}");

                    depth += (aim * pair.Item2);

                    Console.WriteLine($"({pair.Item1},{pair.Item2})-Depth increased => {depth}");

                }
            }

            return (horizontalPosition, depth, aim);
        }

        private static (int horizontalPosition, int depth) CalculatePosition(List<Tuple<string, int>> processedInput, int horizontalPosition, int depth)
        {
            foreach (var pair in processedInput)
            {
                if (pair.Item1 == "forward")
                {
                    horizontalPosition += pair.Item2;
                    Console.WriteLine($"({pair.Item1},{pair.Item2})-Horizontal position increased => {horizontalPosition}");
                }

                if (pair.Item1 == "down")
                {
                    depth += pair.Item2;
                    Console.WriteLine($"({pair.Item1},{pair.Item2})-Depth increased => {depth}");
                }

                if (pair.Item1 == "up")
                {
                    depth -= pair.Item2;
                    Console.WriteLine($"({pair.Item1},{pair.Item2})-Depth decreased => {depth}");
                }
            }

            return (horizontalPosition, depth);
        }

        private static void Challenge1()
        {
            const string fileName = "input.txt";
            var horizontalPosition = 0;
            var depth = 0;

            var input = ReadTextFile(fileName);

            var processedInput = TransformInput(input);

            (horizontalPosition, depth) = CalculatePosition(processedInput, horizontalPosition, depth);
            Console.WriteLine($"Your horizontal position is: {horizontalPosition}");
            Console.WriteLine($"Your depth is: {depth}");

            var multiplicationResult = horizontalPosition * depth;
            Console.WriteLine($"Horizontal position * Depth = {multiplicationResult}");
            //Console.WriteLine(input);
        }

       

        private static List<Tuple<string,int>> TransformInput(List<string> input)
        {
            var output = new List<Tuple<string, int>>();
            foreach (var item in input)
            {
                var result = item.Split(" ");
                output.Add(Tuple.Create(result[0], int.Parse(result[1])));
            }

            return output;
        }


        private static List<string> ReadTextFile(string fileName)
        {
            var path = Path.Combine(Environment.CurrentDirectory, fileName);

            var file = File.ReadLines(path);
            var count = file.ToList().Count;
            Console.WriteLine($"Total number of items: {count}");

            return file.ToList();
        }
    }
}
