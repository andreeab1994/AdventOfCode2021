using System.Collections.Generic;

namespace Day2
{
    public static class DataProcessor
    {
        public static List<NavigationCommand> ConvertData(IEnumerable<string> input)
        {
            var output = new List<NavigationCommand>();
            foreach (var item in input)
            {
                var result = item.Split(" ");
                output.Add(new NavigationCommand(NavigationCommand.GetCommandType(result[0]), int.Parse(result[1])));
            }

            return output;
        }
    }
}
