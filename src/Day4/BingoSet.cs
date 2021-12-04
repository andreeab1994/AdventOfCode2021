namespace Day4;

public class BingoSet
{
    public BingoSet()
    {
        Table = new string[5, 5];
    }

    public string[,] Table { get; set; }

    public (int row, int column)? CheckNumber(string playingNumber)
    {
        var rows = Table.GetLength(0);
        var cols = Table.GetLength(1);

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (Table[i, j].Equals(playingNumber))
                {
                    return (i, j);
                }
            }
        }

        return null;
    }


    public bool CheckWinningRow()
    {
        var rows = Table.GetLength(0);
        for (var i = 0; i < rows; i++)
        {
            if (Table[i, 0] != null && Table[i, 1] != null && Table[i, 2] != null && Table[i, 3] != null && Table[i, 4] != null)
            {
                return true;
            }
        }

        return false;
    }

    public bool CheckWinningColumn()
    {
        var columns = Table.GetLength(1);
        for (var i = 0; i < columns; i++)
        {
            if (Table[0,i] != null && Table[1, i] != null && Table[2, i] != null && Table[3, i] != null && Table[4, i] != null)
            {
                return true;
            }
        }

        return false;
    }
}