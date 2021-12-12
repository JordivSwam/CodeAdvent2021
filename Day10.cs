using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    class Day10 : DayBase
    {

        public class Linechecker
        {
            public List<char> OpenList = new List<char>();

            public UInt64 FixLine(string line)
            {
                ResetCount();
                Checkline(line);

                UInt64 score = 0;
                char c;

                for(int i = OpenList.Count-1; i >= 0; i--)
                {
                    c = OpenList[i];
                    score *= 5;
                    switch (c)
                    {
                        case '(':
                            score += 1;
                            break;
                        case '[':
                            score += 2;
                            break;
                        case '{':
                            score += 3;
                            break;
                        case '<':
                            score += 4;
                            break;
                    }
                }
                return score;
            }


            public char Checkline(string line)
            {
                ResetCount();
                foreach (char c in line)
                {
                    switch (c)
                    {
                        case '(':
                            OpenList.Add(c);
                            break;
                        case ')':
                            if (OpenList.Last() == '(')
                                OpenList.RemoveAt(OpenList.Count - 1);
                            else
                                return c;
                            break;
                        case '[':
                            OpenList.Add(c);
                            break;
                        case ']':
                            if (OpenList.Last() == '[')
                                OpenList.RemoveAt(OpenList.Count - 1);
                            else
                                return c;
                            break;
                        case '{':
                            OpenList.Add(c);
                            break;
                        case '}':
                            if (OpenList.Last() == '{')
                                OpenList.RemoveAt(OpenList.Count - 1);
                            else
                                return c;
                            break;
                        case '<' :
                            OpenList.Add(c);
                            break;
                        case '>':
                            if (OpenList.Last() == '<')
                                OpenList.RemoveAt(OpenList.Count - 1);
                            else
                                return c;
                            break;
                        default:
                            throw new NotImplementedException();
                            break;
                    }
                }
                return ' ';
            }

            private void ResetCount()
            {
                OpenList.Clear();
            }
        }

        public List<string> Lines = new List<string>();

        public override bool RunPart1()
        {
            if (LoadInput())
            {
                int awnser = 0;
                Linechecker check = new Linechecker();
                foreach (string line in Lines)
                {
                    char corrupted = check.Checkline(line);
                    if (corrupted != ' ')
                    {
                        if (corrupted == ')')
                            awnser += 3;
                        else if (corrupted == ']')
                            awnser += 57;
                        else if (corrupted == '}')
                            awnser += 1197;
                        else if (corrupted == '>')
                            awnser += 25137;
                    }
                }
                Console.WriteLine("The awnser to day 10 part 1 is: " + awnser);
                return true;
            }
            return false;
        }

        public override bool RunPart2()
        {
            if (LoadInput())
            {
                UInt64 awnser = 0;
                List<UInt64> scores = new List<UInt64>();
                Linechecker check = new Linechecker();
                Lines.RemoveAll(x => check.Checkline(x) != ' ');

                foreach (string line in Lines)
                {
                    scores.Add(check.FixLine(line));
                }
                scores.Sort();
                int index = ((scores.Count - 1) / 2);

                awnser = scores[index];

                Console.WriteLine("The awnser to day 10 part 2 is: " + awnser);
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
                    Lines.Add(MyFileStream.ReadLine());
                }
                return true;
            }
            return false;
        }
    }
}
