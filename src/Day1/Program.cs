using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Int32;

namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------Day 1 Challenge------------------------");

            var input = ReadTextFile();

            Challenge1(input);

            Challenge2(input);
        }

        private static void Challenge2(List<string> input)
        {
            var number = ProcessMeasurementsCh2(input);
            Console.WriteLine($"TOTAL sliding windows increasing is: {number}");
        }

        private static int ProcessMeasurementsCh2(List<string> input)
        {
            var count = 0;

            for (var i = 0; i < input.Count; i++)
            {
                try
                {
                    // get sum of group 1
                    var elementOne = Parse(input[i]);
                    var elementTwoAndFour = Parse(input[i + 1]);
                    var elementThreeAndFive = Parse(input[i + 2]);

                    var firstSum = SumGroup(elementOne, elementTwoAndFour, elementThreeAndFive);

                    var elementSix = Parse(input[i + 3]);
                    var secondSum = SumGroup(elementTwoAndFour, elementThreeAndFive, elementSix);

                    Console.WriteLine($"Group 1 ({elementOne},{elementTwoAndFour},{elementThreeAndFive}) = {firstSum}");
                    Console.WriteLine($"Group 2 ({elementTwoAndFour},{elementThreeAndFive},{elementSix}) = {secondSum}");

                    if (secondSum > firstSum)
                    {
                        Console.WriteLine("Group 2 > Group 1");
                        Console.WriteLine(" ");
                        count++;
                    }
                    else
                    {
                        Console.WriteLine("No count here, just carry on....");
                        Console.WriteLine(" ");
                    }

                    if (secondSum == firstSum)
                    {
                        Console.WriteLine("UPS, these 2 are equal");
                        Console.WriteLine(" ");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"No group of 3 available, {ex.Message}");
                    Console.WriteLine(" ");
                    return count;
                }

                // get sum of group 2

                //compare sum , if > increase count
            }

            return count;

        }

        private static int SumGroup(int firstElement, int secondElement, int thirdElement)
        {
            return firstElement + secondElement + thirdElement;
        }

        private static void Challenge1(List<string> input)
        {
            var numberOfHigherMeasurements = ProcessMeasurementsCh1(input);
            Console.WriteLine($"Number of elements increasing is: {numberOfHigherMeasurements}");
        }

        private static int ProcessMeasurementsCh1(List<string> input)
        {
            var count = 0;

            for (var i = 0; i < input.Count; i++)
            {

                if (i != 0 && TryParse(input[i], out int currentNumber) && TryParse(input[i - 1], out int previousNumber))
                {
                    if (currentNumber > previousNumber)
                    {
                        count++;
                    }

                    if (currentNumber == previousNumber)
                    {
                        Console.WriteLine("UPSSSSSS, theey're equal...");
                    }
                }
            }

            return count;
        }

        private static List<string> ReadTextFile()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "input.txt");

            var file = File.ReadLines(path);
            var count = file.ToList().Count;
            Console.WriteLine($"Total number of items: {count}");

            return file.ToList();
        }
    }
    
}
