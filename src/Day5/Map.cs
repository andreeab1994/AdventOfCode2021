using System;
using System.Collections.Generic;

namespace Day5;

public class Map
{
    public Coordinates Point1 { get; set; }

    public Coordinates Point2 { get; set; }

    public List<Coordinates> GetCoordinates(bool includeDiagonal = false)
    {
        var list = new List<Coordinates>();

        if (Point1.X == Point2.X)
        {
            var yMin = Math.Min(Point1.Y, Point2.Y);
            var yMax = Math.Max(Point1.Y, Point2.Y);

            for (var i = yMin; i <= yMax; i++)
            {
                var coords = new Coordinates(Point1.X, i);
                list.Add(coords);
            }

        }
        else if (Point1.Y == Point2.Y)
        {
            var xMin = Math.Min(Point1.X, Point2.X);
            var xMax = Math.Max(Point1.X, Point2.X);

            for (var i = xMin; i <= xMax; i++)
            {
                var coords = new Coordinates(i, Point1.Y);
                list.Add(coords);
            }
        }
        else if(includeDiagonal)
        {

            var xDirection = Point2.X > Point1.X ? 1 : -1;
            var yDirection = Point2.Y > Point1.Y ? 1 : -1;
            var count = Math.Abs(Point2.X - Point1.X) + 1;

            for (var i = 0; i < count; i++)
            {
                var coords = new Coordinates(Point1.X + i * xDirection, Point1.Y + i * yDirection);
                list.Add(coords);
            }
        }

        return list;
    }
}