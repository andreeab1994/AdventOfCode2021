using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    public class Crabs
    {
        public Crabs(IEnumerable<string> input)
        {
            CrabsList = ConvertDataChallenge(input);
        }

        public List<int> CrabsList { get; set; }

        public static List<int> ConvertDataChallenge(IEnumerable<string> input)
        {
            var enumerable = input.ToList();
            var list = new List<int>();

            foreach (var line in enumerable)
            {
                var crabs = line.Split(",");

                foreach (var crab in crabs)
                {
                    list.Add(int.Parse(crab));
                }
            }

            return list;
        }


        public long CalculateFuelConsumption(bool useCrabEngineering = false)
        {
            var calculations = new Dictionary<int, long>();

            for (var i = 1; i <= CrabsList.Count; i++)
            {
                var iteration = new Dictionary<int, long>();
       
                for (var c = 0; c < CrabsList.Count; c++)
                {
                    var result = Math.Abs(i - CrabsList[c]);
                    Console.WriteLine($"Move from position {CrabsList[c]} to position {i} => {result} fuel");
                    if (useCrabEngineering)
                    {
                        var crabFuel = 0;
                        for (var unit = 1; unit <= result; unit++)
                        {
                            crabFuel += unit;
                        }
                        iteration[c] = crabFuel;
                    }
                    else
                    {
                        iteration[c] = result;
                    }
                }

                var sum = iteration.Sum(t => t.Value);
                calculations[i] = sum;
            }

            return calculations.Min(t => t.Value);
        }
    }
}
