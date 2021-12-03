using System.Collections.Generic;
using static System.Int32;

namespace Day1
{
    internal class DataProcessor
    {
        public static List<SonarMeasurement> ConvertData(IEnumerable<string> input)
        {
            var output = new List<SonarMeasurement>();
            foreach (var item in input)
            {
                output.Add(new SonarMeasurement(Parse(item)));
            }

            return output;
        }
    }
}
