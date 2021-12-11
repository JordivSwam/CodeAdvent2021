using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    class Day7 : DayBase
    {
        public List<int> Positions = new List<int>();

        public override bool RunPart1()
        {
            if (LoadInput())
            {
                int max = GetHighestPosition();
                int cost = int.MaxValue;
                for (int i = 0; i <= max; i++)
                {
                    int temp = FindFuelCost(i);
                    if (temp < cost)
                        cost = temp;
                }
                Console.WriteLine("The awnser to day 7 part 1 is: " + cost);
                return true;
            }
            return false;
        }

        public override bool RunPart2()
        {
            if (LoadInput())
            {
                int max = GetHighestPosition();
                int cost = int.MaxValue;
                for (int i = 0; i <= max; i++)
                {
                    int temp = FindFuelCost2(i);
                    if (temp < cost)
                        cost = temp;
                }
                Console.WriteLine("The awnser to day 7 part 2 is: " + cost);
                return true;
            }
            return false;
        }

        public override bool LoadInput()
        {
            if (base.LoadInput())
            {
                string[] entries = MyFileStream.ReadLine().Split(',');
                foreach (string entry in entries)
                {
                    Positions.Add(int.Parse(entry));
                }
                return true;
            }
            return false;
        }


        private int FindFuelCost(int targetPosition)
        {
            int cost = 0;
            foreach (int position in Positions)
            {
                cost += Math.Abs(position - targetPosition);
            }
            return cost;
        }

        private int FindFuelCost2(int targetPosition)
        {
            int dist = 0;
            int cost = 0;
            foreach (int position in Positions)
            {
                dist = Math.Abs(position - targetPosition);
                for (int i = 0; i < dist; i++)
                {
                    cost += i + 1;
                }
            }
            return cost;
        }

        private int GetHighestPosition()
        {
            int highest = 0;
            foreach (int position in Positions)
            {
                if (position > highest)
                    highest = position;
            }
            return highest;
        }

    }
}
