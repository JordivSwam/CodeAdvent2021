using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodeAdvent2021
{
    public abstract class DayBase
    {

        public StreamReader MyFileStream;

        public bool RunDay(int part)
        {
            if (part == 1)
                return RunPart1();
            else if (part == 2)
                return RunPart2();
            else
                Console.WriteLine("Invalid number given");
            return false;
        }

        public abstract bool RunPart1();
        public abstract bool RunPart2();

        public virtual bool LoadInput()
        {
            string directory = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Resources" , this.GetType().Name, "PuzzleInput.txt");

            if (File.Exists(directory))
            {
                MyFileStream = new StreamReader(directory);
                return true;
            }
            return false;
        }

    }
}
