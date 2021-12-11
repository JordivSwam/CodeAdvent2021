using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    class Day6 : DayBase
    {

        public List<UInt64> FishCount = new List<UInt64>();

        public override bool RunPart1()
        {
            if (LoadInput())
            {
                for (int i = 0; i < 80; i++)
                {
                    RunTick();
                }
                Console.WriteLine("The awnser to day 6 part 1 is: " + GetFishCount());
                return true;
            }
            return false;
        }

        public override bool RunPart2()
        {
            if (LoadInput())
            {
                for (int i = 0; i < 256; i++)
                {
                    RunTick();
                }
                Console.WriteLine("The awnser to day 6 part 1 is: " + GetFishCount());
                return true;
            }
            return false;
        }

        public override bool LoadInput()
        {
            if (base.LoadInput())
            {
                for (int i = 0; i < 9; i++)
                    FishCount.Add(0);

                string[] timers = MyFileStream.ReadLine().Split(',');
                foreach (string time in timers)
                {
                    FishCount[int.Parse(time)]++;
                }
                return true;
            }
            return false;
        }

        public void RunTick()
        {
            UInt64 NewFishCount = 0;
            for(int i = 0; i < FishCount.Count; i++)
            {
                if (i == 0)
                    NewFishCount = FishCount[0];
                if (i < FishCount.Count - 1)
                    FishCount[i] = FishCount[i + 1];
                else
                    FishCount[i] = 0;
            }
            FishCount[6] += NewFishCount;
            FishCount[8] += NewFishCount;
        }

        public UInt64 GetFishCount()
        {
            UInt64 awnser = 0;
            foreach (UInt64 fish in FishCount)
            {
                awnser += fish;
            }
            return awnser;
        }

    }
}
