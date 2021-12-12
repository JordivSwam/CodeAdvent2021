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


//Day template


//public override bool RunPart1()
//{
//    if (LoadInput())
//    {
//        int awnser = 0;
//        Console.WriteLine("The awnser to day X part 1 is: " + awnser);
//        return true;
//    }
//    return false;
//}

//public override bool RunPart2()
//{
//    if (LoadInput())
//    {
//        int awnser = 0;
//        Console.WriteLine("The awnser to day X part 2 is: " + awnser);
//        return true;
//    }
//    return false;
//}
//public override bool LoadInput()
//{
//    if (base.LoadInput())
//    {
//        while (!MyFileStream.EndOfStream)
//        {

//        }
//        return true;
//    }
//    return false;
//}