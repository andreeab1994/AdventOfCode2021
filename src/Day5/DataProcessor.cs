using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public static class DataProcessor
    {
        public static LinesMap ConvertDataLines(IEnumerable<string> input)
        {
            var dataLines = new LinesMap();

            var enumerable = input.ToList();
            foreach (var destination in enumerable)
            {
                var coords = destination.Replace(" -> ", " ").Split(" ");
                var point1 = new Coordinates(coords[0].Split(","));
                var point2 = new Coordinates(coords[1].Split(","));
                var map = new Map { Point1 = point1, Point2 = point2 };

                dataLines.AddMap(map);
            }

            return dataLines;
        }
    }
}
