using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    class Day8 : DayBase
    {
        public class Display
        {
            public List<string> Combinations = new List<string>();
            public List<string> Outputs = new List<string>();

            public List<string> SortedCombinations = new List<string>(new string[10]);
            private bool decoded = false;

            public int OutputUniqueCount()
            {
                int result = 0;
                foreach (string output in Outputs)
                {
                    if (output.Length == 2 || output.Length == 3 || output.Length == 4 || output.Length == 7)
                        result++;
                }
                return result;
            }

            public void DecodeCombinations()
            {
                DecodeUniques();
                DecodeDuplicates();
                decoded = true;
            }

            public List<int> GetOutput()
            {
                List<int> Awnser = new List<int>();
                if (!decoded)
                    DecodeCombinations();
                foreach (string output in Outputs)
                {
                    int index = 0;
                    bool match = false;
                    foreach (string Sorted in SortedCombinations)
                    {
                        if (Sorted.Length == output.Length)
                        {
                            match = true;
                            foreach (char segment in output)
                            {
                                if (!Sorted.Contains(segment))
                                {
                                    match = false;
                                    break;
                                }
                            }
                            if (match)
                            {
                                Awnser.Add(index);
                                break;
                            }
                        }
                        index++;
                    }
                }
                return Awnser;
            }

            private void DecodeUniques()
            {
                foreach (string output in Combinations)
                {
                    switch (output.Length)
                    {
                        case 2:
                            SortedCombinations[1] = output;
                            break;
                        case 4:
                            SortedCombinations[4] = output;
                            break;
                        case 3:
                            SortedCombinations[7] = output;
                            break;
                        case 7:
                            SortedCombinations[8] = output;
                            break;
                        default:
                            break;
                    }
                }
            }

            private void DecodeDuplicates()
            {
                List<char> OneSegments = SortedCombinations[1].ToList();
                List<char> FourSegemnts = SortedCombinations[4].ToList();
                List<char> FourOneXORSegments = SortedCombinations[4].ToList();

                foreach (char segment in OneSegments)
                {
                    FourOneXORSegments.Remove(segment);
                }

                foreach (string output in Combinations)
                {
                    if (output.Length == 6)
                    {
                        bool IsSix = false;
                        foreach (char segment in OneSegments)
                        {
                            if (!output.Contains(segment))
                            {
                                IsSix = true;
                                break;
                            }
                        }
                        if (IsSix)
                            SortedCombinations[6] = output;
                        else
                        {
                            bool isNine = true;
                            foreach (char segment in FourSegemnts)
                            {
                                if (!output.Contains(segment))
                                {
                                    isNine = false;
                                    break;
                                }
                            }
                            if (isNine)
                                SortedCombinations[9] = output;
                            else
                                SortedCombinations[0] = output;
                        }
                    }
                    else if (output.Length == 5)
                    {
                        bool isThree = true;
                        foreach (char segment in OneSegments)
                        {
                            if (!output.Contains(segment))
                            {
                                isThree = false;
                                break;
                            }
                        }
                        if (isThree)
                            SortedCombinations[3] = output;
                        else
                        {
                            bool IsFive = true;
                            foreach (char segment in FourOneXORSegments)
                            {
                                if (!output.Contains(segment))
                                {
                                    IsFive = false;
                                    break;
                                }
                            }
                            if (IsFive)
                                SortedCombinations[5] = output;
                            else
                                SortedCombinations[2] = output;
                        }
                    }
                }
            }
        }

        public List<Display> displays = new List<Display>();

        public override bool RunPart1()
        {
            if (LoadInput())
            {
                int awnser = 0;
                foreach (Display dis in displays)
                {
                    awnser += dis.OutputUniqueCount();
                }
                Console.WriteLine("The awnser to day 8 part 1 is: " + awnser);
                return true;
            }
            return false;
        }

        public override bool RunPart2()
        {
            if (LoadInput())
            {
                int awnser = 0;
                foreach (Display dis in displays)
                {
                    dis.DecodeCombinations();
                    List<int> output = dis.GetOutput();
                    string number = string.Empty;
                    foreach (int num in output)
                    {
                        number += num.ToString();
                    }
                    awnser += int.Parse(number);
                }
                Console.WriteLine("The awnser to day 8 part 1 is: " + awnser);
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
                    string Com = MyFileStream.ReadLine();
                    string Out = string.Empty;

                    if (Com.IndexOf('|') == Com.Length-1)
                    {
                        Out = MyFileStream.ReadLine();
                        Com = Com.Trim('|');
                    }
                    else
                    {
                        string[] temp = Com.Split('|');
                        Com = temp[0];
                        Out = temp[1];
                    }
                        
                    Com = Com.Trim(' ');
                    Display dis = new Display();
                    dis.Combinations = Com.Split(' ').ToList();
                    dis.Outputs = Out.Split(' ').ToList();
                    displays.Add(dis);
                }
                return true;
            }
            return false;
        }
    }
}
