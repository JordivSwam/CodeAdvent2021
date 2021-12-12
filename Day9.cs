using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CodeAdvent2021
{
    class Day9 : DayBase
    {

        public class Basin
        {
            public Basin(int x, int y)
            {
                Stack.Add(new Tuple<int, int>(x, y));
            }

            List<Tuple<int,int>> Stack = new List<Tuple<int, int>>();
            List<Tuple<int, int>> Coordinates = new List<Tuple<int, int>>();

            public int size { get { return Coordinates.Count;}}

            public void ExploreBasin(List<List<int>> Heightmap)
            {
                while (Stack.Count != 0)
                {
                    Tuple<int,int> TestLocation = Stack[0];
                    int x = TestLocation.Item1;
                    int y = TestLocation.Item2;
                    if (Heightmap[x][y] != 9 && !Coordinates.Contains(TestLocation))
                    {
                        Coordinates.Add(TestLocation);
                        if (x + 1 < Heightmap.Count)
                            Stack.Add(new Tuple<int, int>(x + 1, y));
                        if (x - 1 >= 0)
                            Stack.Add(new Tuple<int, int>(x - 1, y));
                        if (y + 1 < Heightmap[0].Count)
                            Stack.Add(new Tuple<int, int>(x, y + 1));
                        if (y - 1 >= 0)
                            Stack.Add(new Tuple<int, int>(x, y - 1));
                    }
                    Stack.RemoveAt(0);
                }
            }
        }

        public List<List<int>> heightmap = new List<List<int>>();
        public List<Basin> Basins = new List<Basin>();

        public override bool RunPart1()
        {
            if (LoadInput())
            {
                int awnser = GetRiskScore();
                Console.WriteLine("The awnser to day 9 part 1 is: " + awnser);
                return true;
            }
            return false;
        }

        public override bool RunPart2()
        {
            if (LoadInput())
            {
                int one=0, two=0, three=0;
                int awnser = 0;
                FindAllBasins();
                foreach (Basin b in Basins)
                {
                    b.ExploreBasin(heightmap);
                }
                foreach (Basin b in Basins)
                {
                    if (b.size > one)
                    {
                        three = two;
                        two = one;
                        one = b.size;
                    }
                    else if (b.size > two)
                    {
                        three = two;
                        two = b.size;
                    }
                    else if (b.size > three)
                    {
                        three = b.size;
                    }
                }
                awnser = one * two * three;
                Console.WriteLine("The awnser to day 9 part 1 is: " + awnser);
                return true;
            }
            return false;
        }

        public override bool LoadInput()
        {
            if (base.LoadInput())
            {
                while (!MyFileStream.EndOfStream)
                {
                    string line = MyFileStream.ReadLine();

                    if (heightmap.Count == 0)
                    {
                        for (int i = 0; i < line.Length; i++)
                            heightmap.Add(new List<int>());
                    }
                    int count = 0;
                    foreach (char num in line)
                    {
                        heightmap[count].Add((int)Char.GetNumericValue(num));
                        count++;
                    }
                }
                return true;
            }
            return false;
        }

        public int GetRiskScore()
        {
            int risk = 0;
            for (int x = 0; x < heightmap.Count; x++)
            {
                for (int y = 0; y < heightmap[0].Count; y++)
                {
                    if(IsLowPoint(x,y))

                    risk += heightmap[x][y] + 1;
                }
            }
            return risk;
        }

        public void FindAllBasins()
        {
            for (int x = 0; x < heightmap.Count; x++)
            {
                for (int y = 0; y < heightmap[0].Count; y++)
                {
                    if (IsLowPoint(x, y))
                    {
                        Basins.Add(new Basin(x, y));
                    }
                }
            }
        }

                public bool IsLowPoint(int x, int y)
        {
            int num = heightmap[x][y];
            int checkX = x - 1;
            if (checkX >= 0 && heightmap[checkX][y] <= num)
                return false;
            checkX = x + 1;
            if (checkX < heightmap.Count && heightmap[checkX][y] <= num)
                return false;
            int checkY = y - 1;
            if (checkY >= 0 && heightmap[x][checkY] <= num)
                return false;
            checkY = y + 1;
            if (checkY < heightmap[0].Count && heightmap[x][checkY] <= num)
                return false;

            return true;
        }

    }
}
