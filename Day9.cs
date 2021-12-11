using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    class Day9 : DayBase
    {

        public List<List<int>> heightmap = new List<List<int>>();

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
            throw new NotImplementedException();
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
            int num = 0;
            int checkX = 0;
            int checkY = 0;
            int risk = 0;
            for (int x = 0; x < heightmap.Count; x++)
            {
                for (int y = 0; y < heightmap[0].Count; y++)
                {
                    num = heightmap[x][y];
                    checkX = x - 1;
                    if (checkX >= 0 && heightmap[checkX][y] <= num)
                        continue;
                    checkX = x + 1;
                    if (checkX < heightmap.Count && heightmap[checkX][y] <= num)
                        continue;
                    checkY = y - 1;
                    if (checkY >= 0 && heightmap[x][checkY] <= num)
                        continue;
                    checkY = y + 1;
                    if (checkY < heightmap[0].Count && heightmap[x][checkY] <= num)
                        continue;

                    risk += num + 1;
                }
            }
            return risk;
        }

    }
}
