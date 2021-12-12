using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    class Day11 : DayBase
    {
        public List<List<short>> Grid = new List<List<short>>();
        public List<Tuple<int, int>> Stack = new List<Tuple<int, int>>();

        public override bool RunPart1()
        {
            if (LoadInput())
            {
                int awnser = 0;
                for (int i = 0; i < 100; i++)
                {
                    awnser += RunTick();
                }
                Console.WriteLine("The awnser to day 11 part 1 is: " + awnser);
                return true;
            }
            return false;
        }

        public override bool RunPart2()
        {
            if (LoadInput())
            {
                int awnser = 0;
                int TargetFlashCount = Grid.Count * Grid[0].Count;
                bool awnserFound = false;
                while (!awnserFound)
                {
                    awnser++;
                    if (TargetFlashCount == RunTick())
                    {
                        awnserFound = true;
                    }
                }
                Console.WriteLine("The awnser to day 11 part 2 is: " + awnser);
                return true;
            }
            return false;
        }


        public int RunTick()
        {
            for (int x = 0; x < Grid.Count; x++)    //increment all and add all 10's to the stack
            {
                for (int y = 0; y < Grid[0].Count; y++)
                {
                    Grid[x][y]++;
                    if (Grid[x][y] == 10)
                        Stack.Add(new Tuple<int, int>(x, y));
                }
            }

            Tuple<int, int> coord;
            while (Stack.Count != 0) //run through the stack incrementing those next to the 10's and adding them to the stack if they reach 10
            {
                coord = Stack[0];
                int targetX;
                int targetY;
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if (!(i == 0 && j == 0))
                        {
                            targetX = coord.Item1 + i;
                            targetY = coord.Item2 + j;
                            if (Checkbounds(targetX, targetY))
                            {
                                Grid[targetX][targetY]++;
                                if (Grid[targetX][targetY] == 10)
                                    Stack.Add(new Tuple<int, int>(targetX, targetY));
                            }
                        }
                    }
                }
                Stack.RemoveAt(0);
            }

            int numFlashes = 0;

            for (int x = 0; x < Grid.Count; x++)    //increment all and add all 10's to the stack
            {
                for (int y = 0; y < Grid[0].Count; y++)
                {
                    if (Grid[x][y] > 9)
                    {
                        numFlashes++;
                        Grid[x][y] = 0;
                    }
                }
            }
            return numFlashes;
        }

        public bool Checkbounds(int x, int y)
        {
            if (x >= 0 && x < Grid.Count && y >= 0 && y < Grid[0].Count)
                return true;
            else
                return false;
        }

        public override bool LoadInput()
        {
            if (base.LoadInput())
            {
                string line = MyFileStream.ReadLine();

                int count = 0;
                foreach(char c in line)
                {
                    Grid.Add(new List<short>());
                    Grid[count].Add(short.Parse(c.ToString()));
                    count++;
                }
                while (!MyFileStream.EndOfStream)
                {
                    count = 0;
                    line = MyFileStream.ReadLine();
                    foreach (char c in line)
                    {
                        Grid[count].Add(short.Parse(c.ToString()));
                        count++;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
