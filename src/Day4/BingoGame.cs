using System.Collections.Generic;

namespace Day4
{
    public class BingoGame
    {
        public BingoGame()
        {
            BingoSets = new List<BingoSet>();
            BingoSetsPlayed = new List<BingoSet>();
            PlayLosingGame = false;
        }

        public List<BingoSet> BingoSetsPlayed { get; set; }

        public string[] PlayingNumbers { get; set; }
        public List<BingoSet> BingoSets { get; set; }

        public bool PlayLosingGame { get; set; }

        public int Play()
        {
            var bingoSetsCount = BingoSets.Count;

            for (var i = 0; i < bingoSetsCount; i++)
            {
                BingoSetsPlayed.Add(new BingoSet());
            }

            foreach (var number in PlayingNumbers)
            {
                for (var bingoSets = 0; bingoSets < BingoSets.Count; bingoSets++)
                {
                    var position = BingoSets[bingoSets].CheckNumber(number);

                    if (position == null) continue;
                    
                    var currentBingoSetsPlayed = BingoSetsPlayed[bingoSets];
                    currentBingoSetsPlayed.Table[position.Value.row, position.Value.column] =
                        number;

                    if (PlayLosingGame)
                    {
                        var winningSet = CheckWinningPossibilityMultipleSets();
                        if (winningSet.Count == BingoSets.Count)
                        {
                            return CalculateWinningScore(bingoSets, number);
                        }
                    }
                    else
                    {
                        var winningSet = CheckWinningPossibility();
                        if (winningSet != null)
                        {
                            return CalculateWinningScore(winningSet.Value.setIndex, number);
                        }
                    }
                }
            }

            return 0;
        }

       

        private int CalculateWinningScore(int valueSetIndex, string numberCalled)
        {
            var playedSet = BingoSetsPlayed[valueSetIndex];
            var currentSet = BingoSets[valueSetIndex];
            var rows = currentSet.Table.GetLength(0);
            var columns = currentSet.Table.GetLength(1);

            var score = 0;

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    if (playedSet.Table[i, j] == null)
                    {
                        score += int.Parse(currentSet.Table[i, j]);
                    }
                }
            }

            return score * int.Parse(numberCalled);

        }

        private (bool winningSet, int setIndex)? CheckWinningPossibility()
        {
            for (var i = 0; i < BingoSetsPlayed.Count; i++)
            {
                if(BingoSetsPlayed[i].CheckWinningRow())
                {
                    return (true, i);
                }

                if (BingoSetsPlayed[i].CheckWinningColumn())
                {
                    return (true, i);
                }
            }

            return null;
        }

        private List<int> CheckWinningPossibilityMultipleSets()
        {
            var winningSets = new List<int>();
            for (var i = 0; i < BingoSetsPlayed.Count; i++)
            {
                if (BingoSetsPlayed[i].CheckWinningRow() || BingoSetsPlayed[i].CheckWinningColumn())
                {
                    winningSets.Add(i);
                }
            }

            return winningSets;
        }
    }
}
