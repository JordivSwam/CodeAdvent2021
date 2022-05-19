using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    class Day14 : DayBase
    {

        class PolymerPair
        {
            public string Pair;
            public UInt64 count;
            public char output;
        }

        Dictionary<char, UInt64> elementCount = new Dictionary<char, UInt64>();

        Dictionary<string, PolymerPair> Polymer = new Dictionary<string, PolymerPair>();
        Dictionary<string, PolymerPair> ReadPolymer = new Dictionary<string, PolymerPair>();

        public override bool RunPart1()
        {
            if (LoadInput())
            {
                for (int i = 0; i < 10; i++)
                {
                    RunTick();
                }
                UInt64 awnser = EvaluateScore();
                Console.WriteLine("The awnser to day 13 part 1 is: " + awnser);
                return true;
            }
            return false;
        }

        public override bool RunPart2()
        {
            if (LoadInput())
            {
                //Console.WriteLine(OperatingString);
                for (int i = 0; i < 40; i++)
                {
                    RunTick();
                    //Console.WriteLine(OperatingString);
                }
                UInt64 awnser = EvaluateScore();
                Console.WriteLine("The awnser to day 13 part 2 is: " + awnser);
                return true;
            }
            return false;
        }
        public override bool LoadInput()
        {
            if (base.LoadInput())
            {
                string StartingPolymer = MyFileStream.ReadLine();
                MyFileStream.ReadLine(); // skip the space

                while (!MyFileStream.EndOfStream)
                {
                    string input = MyFileStream.ReadLine();
                    PolymerPair p = new PolymerPair();
                    p.Pair = input.Substring(0, 2);
                    p.output = input[6];
                    p.count = 0;

                    if (!elementCount.ContainsKey(p.output))
                        elementCount.Add(p.output, 0);

                    Polymer.Add(p.Pair, p);
                }
                for (int i = 0; i < StartingPolymer.Length; i++)
                {
                    char first = StartingPolymer[i];
                    if (elementCount.ContainsKey(StartingPolymer[i]))
                    {
                        elementCount[first]++;
                    }
                    else
                    {
                        elementCount.Add(first, 1);
                    }

                    if (i != StartingPolymer.Length - 1)
                    {
                        char second = StartingPolymer[i + 1];
                        string test = first.ToString() + second.ToString();
                        Polymer[test].count++;
                    }
                }

                foreach (KeyValuePair<string, PolymerPair> pair in Polymer)
                {
                    PolymerPair p = new PolymerPair();
                    p.count = pair.Value.count;
                    p.Pair = pair.Value.Pair;
                    p.output = pair.Value.output;
                    
                    ReadPolymer.Add(p.Pair,p);
                }

                return true;
            }
            return false;
        }

        private void RunTick()
        {
            foreach (KeyValuePair<string, PolymerPair> pair in ReadPolymer)
            {
                if (pair.Value.count == 0)
                    continue;

                elementCount[pair.Value.output] += pair.Value.count;

                string first = pair.Value.Pair[0].ToString() + pair.Value.output.ToString();
                string second = pair.Value.output.ToString() + pair.Value.Pair[1].ToString();

                Polymer[first].count += pair.Value.count;
                Polymer[second].count += pair.Value.count;

                Polymer[pair.Value.Pair].count -= pair.Value.count;
            }

            foreach (KeyValuePair<string, PolymerPair> pair in Polymer)
            {
                ReadPolymer[pair.Key].count = pair.Value.count;
            }
            return;
        }

        private UInt64 EvaluateScore()
        {
            UInt64 min = UInt64.MaxValue;
            UInt64 max = UInt64.MinValue;

            foreach (KeyValuePair<char, UInt64> element in elementCount)
            {
                if (element.Value > max)
                    max = element.Value;
                if (element.Value < min)
                    min = element.Value;
            }

            Console.WriteLine("max element occurs: " + max + " times. and min element occurs: " + min + " times.");
            return max - min;
        }
    }
}
