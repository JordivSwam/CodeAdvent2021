using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    class Day1 : DayBase
    {
        private List<int> PuzzleInput = new List<int>();
        private int PreviousNumber = 0;

        private int Day1Awnser = 0;
        private int Day2Awnser = 0;

        public override bool RunPart1()
        {
            if (LoadInput())
            {
                while (!MyFileStream.EndOfStream)
                {
                    PuzzleInput.Add(int.Parse(MyFileStream.ReadLine()));
                }

                bool first = true;
                foreach (int Number in PuzzleInput)
                {
                    if (!first)
                    {
                        if (PreviousNumber - Number < 0)
                            Day1Awnser++;
                    }
                    else
                        first = false;
                    PreviousNumber = Number;
                }

                Console.WriteLine("The awnser to day 1 is: " + Day1Awnser);
                return true;
            }
            return false;
        }

        public override bool RunPart2()
        {
            if (LoadInput())
            {
                while (!MyFileStream.EndOfStream)
                {
                    PuzzleInput.Add(int.Parse(MyFileStream.ReadLine()));
                }

                int CurrentNumber = 0;
                int PreviousNumber = 0;
                bool first = true;

                for (int i = 0; i < PuzzleInput.Count; i++)
                {
                    if (PuzzleInput.Count > i + 2)
                    {
                        CurrentNumber = PuzzleInput[i] + PuzzleInput[i + 1] + PuzzleInput[i + 2];
                        if (!first)
                        {
                            if (PreviousNumber - CurrentNumber < 0)
                            {
                                Day2Awnser++;
                            }
                        }
                        else
                            first = false;
                        PreviousNumber = CurrentNumber;
                    }
                    else
                        break;
                }
                Console.WriteLine("The awnser to day 2 is: " + Day2Awnser);
                return true;
            }
            return false;
        }
    }

}
