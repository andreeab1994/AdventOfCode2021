using static System.Int32;

namespace Day5
{
    public class Coordinates
    {
        public Coordinates(string[] split)
        {
            X = Parse(split[0]);
            Y = Parse(split[1]);
        }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
