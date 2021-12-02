using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    class Day2 : DayBase
    {

        public List<string> instructions = new List<string>();

        public int Horizontal = 0;
        public int Depth = 0;
        public int Aim = 0;

        public override bool RunPart1()
        {
            if (LoadInput())
            {
                string operation;
                int value;
                int seperatorIndex;
                foreach (string instruction in instructions)
                {
                    seperatorIndex = instruction.IndexOf(' ');
                    operation = instruction.Substring(0, seperatorIndex);
                    value = int.Parse(instruction.Substring(seperatorIndex + 1));

                    if (operation == "forward")
                        Horizontal += value;
                    else if (operation == "down")
                        Depth += value;
                    else if (operation == "up")
                        Depth -= value;
                    else
                        throw new NotImplementedException();
                }

                Console.WriteLine("The awnser for day 2 part 1 is: " + (Horizontal * Depth));
                return true;
            }
            return false;
        }

        public override bool RunPart2()
        {
            if (LoadInput())
            {
                string operation;
                int value;
                int seperatorIndex;
                foreach (string instruction in instructions)
                {
                    seperatorIndex = instruction.IndexOf(' ');
                    operation = instruction.Substring(0, seperatorIndex);
                    value = int.Parse(instruction.Substring(seperatorIndex + 1));

                    if (operation == "forward")
                    {
                        Horizontal += value;
                        Depth += value * Aim;
                    }
                    else if (operation == "down")
                    {
                        Aim += value;
                    }
                    else if (operation == "up")
                    {
                        Aim -= value;
                    }
                    else
                        throw new NotImplementedException();
                }

                Console.WriteLine("The awnser for day 2 part 2 is: " + (Horizontal * Depth));
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
                    instructions.Add(MyFileStream.ReadLine());
                }
                return true;
            }
            return false;
        }

    }
}
