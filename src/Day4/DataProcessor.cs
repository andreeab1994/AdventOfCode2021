using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    public static class DataProcessor
    {
        public static BingoGame ConvertData(IEnumerable<string> input)
        {
            var output = new BingoGame();
            var enumerable = input.ToList();
            for (var i = 0; i < enumerable.Count(); i++)
            {
                if (i == 0)
                {
                    var numbers = enumerable[i];
                    output.PlayingNumbers = numbers.Split(","); 
                }
                else
                {
                    // one entry line, i spaces, and blocks
                    var skip = 1 + i + (5 * (i-1));
                    var set = enumerable.Skip(skip).Take(5);
                    if (set.Count() != 0)
                    {
                        output.BingoSets.Add(ProcessBingoSet(set, output));
                    }
                    
                }
            }

            return output;
        }

        private static BingoSet ProcessBingoSet(IEnumerable<string> set, BingoGame output)
        {
            var bingoSet = new BingoSet();
            
            var list = set.ToList();

            for (var row = 0; row < list.Count; row++)
            {
                var values = SanitiseInput(list[row]);
            
                for (var column = 0; column < list.Count; column++)
                {
                    bingoSet.Table[row, column] = values[column];
                }
            }

            return bingoSet;
        }

        private static string[] SanitiseInput(string input)
        {
            return input.Trim().Replace("  ", " ").Split(" ");
        }
    }
}
