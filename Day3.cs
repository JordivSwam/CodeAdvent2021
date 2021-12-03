using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    class Day3 : DayBase
    {
        public List<string> BinaryNumbers = new List<string>();

        private List<string> FilteredNumbers = new List<string>();

        public int TrueCount;
        public int FalseCount;

        public int GammaRate;
        public int EpsilonRate;

        public int Oxygen = 0;
        public int CO2 = 0;

        private bool lookForMost = true;

        public override bool RunPart1()
        {
            if (LoadInput())
            {
                for (int i = 0; i < BinaryNumbers[0].Length; i++)
                {
                    GammaRate = GammaRate << 1;
                    EpsilonRate = EpsilonRate << 1;
                    TrueCount = 0;
                    FalseCount = 0;
                    foreach (string number in BinaryNumbers)
                    {
                        if (number[i] == '1')
                        {
                            TrueCount++;
                        }
                        else
                            FalseCount++;
                    }
                    if (TrueCount > FalseCount)
                    {
                        GammaRate += 1;
                    }
                    else
                        EpsilonRate += 1;
                }
                int awnser = EpsilonRate * GammaRate;
                Console.WriteLine("The awnser to day 3 part 1 is: " + awnser);
                return true;
            }
            return false;
        }

        public override bool RunPart2()
        {
            if (LoadInput())
            {
                for(int j = 0; j < 2; j++)
                {
                FilteredNumbers = BinaryNumbers;
                    for (int i = 0; i < BinaryNumbers[0].Length; i++)
                    {
                        TrueCount = 0;
                        FalseCount = 0;
                        foreach (string number in FilteredNumbers)
                        {
                            if (number[i] == '1')
                            {
                                TrueCount++;
                            }
                            else
                                FalseCount++;
                        }
                        List<string> tempList = new List<string>();
                        foreach (string number in FilteredNumbers)
                        {
                            bool IsMost = !(number[i] == '1' ^ TrueCount >= FalseCount);
                            if (!(IsMost ^ lookForMost))
                            {
                                tempList.Add(number);
                            }
                        }
                        FilteredNumbers = tempList;
                        if (FilteredNumbers.Count == 1)
                        {
                            int num = Convert.ToInt32(FilteredNumbers[0], 2);
                            if (lookForMost)
                                Oxygen = num;
                            else
                                CO2 = num;
                            lookForMost = !lookForMost;
                            break;
                        }
                    }
                }
                int awnser = Oxygen * CO2;
                Console.WriteLine("The awnser to day 3 part 2 is: " + awnser);
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
                    BinaryNumbers.Add(MyFileStream.ReadLine());
                }
                return true;
            }
            return false;
        }
    }
}
