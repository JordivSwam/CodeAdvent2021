using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    public class Line2D
    {
        public int startX = 0;
        public int startY = 0;
        public int EndX = 0;
        public int EndY = 0;

        public Line2D(int x1, int y1, int x2, int y2)
        {
            startX = x1;
            startY = y1;
            EndX = x2;
            EndY = y2;
        }

        public bool IsStaight()
        {
            return (startX == EndX) || (startY == EndY);
        }

    }

    class Day5 : DayBase
    {

        public UInt16[,] Map;
        public List<Line2D> Lines = new List<Line2D>();

        public override bool RunPart1()
        {
            if (LoadInput())
            {
                foreach (Line2D line in Lines)
                {
                    if (line.IsStaight())
                    {
                        AddLineToMap(line, Map);
                    }
                }
                int awnser = CountMapOverlaps();
                Console.WriteLine("The awnser to day 5 part 1 is: " + awnser);
            }
            return false;
        }

        public override bool RunPart2()
        {
            if (LoadInput())
            {
                foreach (Line2D line in Lines)
                {
                    AddLineToMap(line, Map);
                }
                int awnser = CountMapOverlaps();
                Console.WriteLine("The awnser to day 5 part 2 is: " + awnser);
            }
            return false;
        }

        public override bool LoadInput()
        {
            int x1, y1, x2, y2;
            int maxX = 0;
            int maxY = 0;
            string line;
            string[] parts, start, end;
            if (base.LoadInput())
            {
                while (!MyFileStream.EndOfStream)
                {
                    line = MyFileStream.ReadLine();
                    parts = line.Split(" -> ");
                    start = parts[0].Split(',');
                    end = parts[1].Split(',');
                    x1 = int.Parse(start[0]);
                    y1 = int.Parse(start[1]);
                    x2 = int.Parse(end[0]);
                    y2 = int.Parse(end[1]);

                    if (x1 > x2)
                    {
                        (x1, x2) = (x2, x1);
                        (y1, y2) = (y2, y1);
                    }

                    Lines.Add(new Line2D(x1, y1, x2, y2));

                    if (x2 > maxX)
                        maxX = x2;
                    if (y2 > maxY)
                        maxY = y2;
                    if (y1 > maxY)
                        maxY = y1;
                }
                Map = new UInt16[maxX+1, maxY+1];
                return true;
            }
            return false;
        }


        public bool AddLineToMap(Line2D line, UInt16[,] map)
        {
            int small, large;
            if (line.startX == line.EndX)
            {
                if (line.startY < line.EndY)
                {
                    small = line.startY;
                    large = line.EndY;
                }
                else
                {
                    small = line.EndY;
                    large = line.startY;
                }

                for (int i = small; i < large + 1; i++)
                {
                    map[line.startX, i]++;
                }
                return true;
            }
            else if (line.startY == line.EndY)
            {
                if (line.startX < line.EndX)
                {
                    small = line.startX;
                    large = line.EndX;
                }
                else
                {
                    small = line.EndX;
                    large = line.startX;
                }

                for (int i = small; i < large + 1; i++)
                {
                    map[i, line.startY]++;
                }
                return true;
            }
            else
            {
                int mod = 1;
                if (line.startY > line.EndY)
                    mod = -1;
                for (int i = 0; i < line.EndX - line.startX + 1; i++)
                {
                    map[line.startX + i, line.startY + (i * mod)]++;
                }
            }
            return false;
        }

        public int CountMapOverlaps()
        {
            int count = 0;
            for (int x = 0; x < Map.GetLength(0); x++)
            {
                for (int y = 0; y < Map.GetLength(1); y++)
                {
                    if (Map[x, y] > 1)
                        count++;
                }
            }
            return count;
        }

        public void PrintMap()
        {
            for (int y = 0; y < Map.GetLength(1); y++)
            {
                for (int x = 0; x < Map.GetLength(0); x++)
                {
                    Console.Write(Map[x, y]);
                }
                Console.WriteLine();
            }
        }
    }
}
