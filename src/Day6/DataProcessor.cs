using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    public static class DataProcessor
    {
        public static List<int> ConvertDataChallenge(IEnumerable<string> input)
        {
            var enumerable = input.ToList();
            var list = new List<int>();
            
            foreach (var line in enumerable)
            {
                var fishes = line.Split(",");

                foreach (var fish in fishes)
                {
                   list.Add(int.Parse(fish));
                }
            }

            return list;
        }
    }
}
