using System;
using System.Collections.Generic;
using System.Linq;

namespace Day5
{
    public class LinesMap
    {
        private readonly List<Map> _linesMap = new();

        public int[,] DrawingMap { get; set; }

        public int GridXMin { get; set; }
        public int GridYMin { get; set; }
        public int GridXMax { get; set; }
        public int GridYMax { get; set; }

        public void AddMap(Map map)
        {
            _linesMap.Add(map);
        }

        public int CalculateAll(bool includeDiagonal = false)
        {
            var score = 0;

            CreateGrid();

            foreach (var line in _linesMap)
            {
                var coords = line.GetCoordinates(includeDiagonal);
                foreach (var item in coords)
                {
                    var value = DrawingMap[item.Y, item.X];
                    DrawingMap[item.Y, item.X] = value + 1;
                }
            }

            for (var i = GridXMin; i <= GridXMax; i++)
            {
                for (var j = GridYMin; j <= GridYMax; j++)
                {
                    if (DrawingMap[i, j] >= 2)
                    {
                        score++;
                    }
                }
            }

            return score;
        }

        private void CreateGrid()
        {
            var point1XMin = _linesMap.GroupBy(t => t.Point1.X).Select(t => t.Key).Min();
            var point2XMin = _linesMap.GroupBy(t => t.Point2.X).Select(t => t.Key).Min();

            var point1XMax = _linesMap.GroupBy(t => t.Point1.X).Select(t => t.Key).Max();
            var point2XMax = _linesMap.GroupBy(t => t.Point2.X).Select(t => t.Key).Max();

            var point1YMin = _linesMap.GroupBy(t => t.Point1.Y).Select(t => t.Key).Min();
            var point2YMin = _linesMap.GroupBy(t => t.Point2.Y).Select(t => t.Key).Min();

            var point1YMax = _linesMap.GroupBy(t => t.Point1.Y).Select(t => t.Key).Max();
            var point2YMax = _linesMap.GroupBy(t => t.Point2.Y).Select(t => t.Key).Max();


            var xMin = Math.Min(point1XMin, point2XMin);
            var xMax = Math.Max(point1XMax, point2XMax);

            var yMin = Math.Min(point1YMin, point2YMin);
            var yMax = Math.Max(point1YMax, point2YMax);
            
            GridXMin = xMin;
            GridXMax = xMax;

            GridYMin = yMin;
            GridYMax = yMax;

            DrawingMap = new int[yMax + 1, xMax + 1];
        }


        public void Print2DArray<T>()
        {
            for (int i = 0; i < DrawingMap.GetLength(0); i++)
            {
                for (int j = 0; j < DrawingMap.GetLength(1); j++)
                {
                    if (DrawingMap[i, j] == 0)
                    {
                        Console.Write("." + "\t");
                    }
                    else
                    {
                        Console.Write(DrawingMap[i, j] + "\t");
                    }

                }
                Console.WriteLine();
            }
        }
    }
}
