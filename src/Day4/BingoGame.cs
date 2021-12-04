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

            //start with the first playing number
            for (var number = 0; number < PlayingNumbers.Length; number++)
            {
                // check current boards
                for (var bingoSets = 0; bingoSets < BingoSets.Count; bingoSets++)
                {
                    (int row, int column)? position = BingoSets[bingoSets].CheckNumber(PlayingNumbers[number]);
                    
                    if (position != null)
                    {
                        var currentBingoSetsPlayed = BingoSetsPlayed[bingoSets];
                        currentBingoSetsPlayed.Table[position.Value.row, position.Value.column] =
                            PlayingNumbers[number];

                        if (PlayLosingGame)
                        {
                            var winningSet = CheckWinningPossibilityMultipleSets();
                            if (winningSet.Count == BingoSets.Count)
                            {
                                return CalculateWinningScore(bingoSets, PlayingNumbers[number]);
                            }
                        }
                        else
                        {
                            var winningSet = CheckWinningPossibility();
                            if (winningSet != null)
                            {
                                return CalculateWinningScore(winningSet.Value.setIndex, PlayingNumbers[number]);
                            }
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
                // check rows
                if(CheckRows(BingoSetsPlayed[i]))
                {
                    return (true, i);
                }

                //check columns
                if (CheckColumns(BingoSetsPlayed[i]))
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
                // check rows
                if (CheckRows(BingoSetsPlayed[i]) || CheckColumns(BingoSetsPlayed[i]))
                {
                    winningSets.Add(i);
                }
            }


            return winningSets;
        }

        private bool CheckColumns(BingoSet bingoSet)
        {
            return bingoSet.CheckWinningColumn();
        }

        private bool CheckRows(BingoSet bingoSet)
        {
            return bingoSet.CheckWinningRow();
        }
    }
}
