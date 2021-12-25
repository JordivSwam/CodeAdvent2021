using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    class Day13 : DayBase
    {

        public HashSet<Tuple<int,int>> DotMap = new HashSet<Tuple<int, int>>();

        public List<Tuple<bool, int>> instructions = new List<Tuple<bool, int>>(); //bool, true = fold along y, flase = fold along x

        public override bool RunPart1()
        {
            if (LoadInput())
            {
                Console.WriteLine("Before folding the amount of dots are: " + DotMap.Count);
                DotMap = ApplyFold(instructions[0], DotMap);
                int awnser = DotMap.Count;
                Console.WriteLine("After the first fold the amount of dots are: " + awnser);
                Console.WriteLine("The awnser to day 13 part 1 is: " + awnser);
                return true;
            }
            return false;
        }

        public override bool RunPart2()
        {
            if (LoadInput())
            {
                foreach (Tuple<bool, int> instruction in instructions)
                {
                    DotMap = ApplyFold(instruction, DotMap);
                }
                DisplayDotMap(DotMap);
                return true;
            }
            return false;
        }


        public HashSet<Tuple<int,int>> ApplyFold(Tuple<bool, int> instruction, HashSet<Tuple<int, int>> Dots)
        {
            HashSet<Tuple<int, int>> tempMap = new HashSet<Tuple<int, int>>();
            int offset = 0;
            foreach (Tuple<int, int> dot in Dots)
            {
                if (instruction.Item1) //if fold along y
                {
                    offset = Math.Max(dot.Item2 - instruction.Item2, 0);
                    offset *= 2;
                    tempMap.Add(new Tuple<int, int>(dot.Item1, dot.Item2 - offset));
                }
                else //if fold along x
                {
                    offset = Math.Max(dot.Item1 - instruction.Item2, 0);
                    offset *= 2;
                    tempMap.Add(new Tuple<int, int>(dot.Item1 - offset, dot.Item2));
                }
            }
            return tempMap;
        }

        public void DisplayDotMap(HashSet<Tuple<int, int>> dotMap)
        {
            int xBound = 0;
            int yBound = 0;
            foreach (Tuple<int, int> dot in dotMap)
            {
                xBound = Math.Max(xBound, dot.Item1);
                yBound = Math.Max(yBound, dot.Item2);
            }
            for (int y = 0; y <= yBound; y++)
            {
                for (int x = 0; x <= xBound; x++)
                {
                    char print = '.';
                    if (DotMap.Contains(new Tuple<int, int>(x, y)))
                        print = '#';
                    Console.Write(print);
                }
                Console.WriteLine();
            }
        }

        public override bool LoadInput()
        {
            if (base.LoadInput())
            {
                string line;
                bool FirstPart = true;
                while (!MyFileStream.EndOfStream)
                {
                    line = MyFileStream.ReadLine();
                    if (line != string.Empty)
                    {
                        if (FirstPart)
                        {
                            string[] coords = line.Split(',');
                            Tuple<int, int> c = new Tuple<int, int>(int.Parse(coords[0]), int.Parse(coords[1]));
                            DotMap.Add(c);
                        }
                        else
                        {
                            bool isY = false;
                            int foldLine = 0;
                            int index = line.IndexOf('=');
                            line = line.Substring(index - 1);
                            if (line[0] == 'y')
                                isY = true;
                            foldLine = int.Parse(line.Substring(2));
                            Tuple<bool, int> instruction = new Tuple<bool, int>(isY, foldLine);
                            instructions.Add(instruction);
                        }
                    }
                    else
                    {
                        FirstPart = false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
