using System;
using System.Linq;
using System.Collections.Generic;

namespace CodeAdvent2021
{
    class Program
    {
        static void Main(string[] args)
        {
            int DayNumber = 12;
            int PartNumber = 2;
            bool UseOverwrite = true;
            string UserResponse;

            List<DayBase> Days = new List<DayBase>() {  new Day1(), new Day2(), new Day3(), new Day4(), new Day5(), new Day6(), new Day7(), new Day8(), new Day9(), new Day10(),
                                                        new Day11(), new Day12() };

            if (UseOverwrite)
            {
                if (DayNumber <= Days.Count && DayNumber > 0)
                {
                    Days[DayNumber - 1].RunDay(PartNumber);
                }
                else
                    Console.WriteLine("Tried to run a day that didn't exist!");
            }
            else
            {
                Console.WriteLine("Pick A day you want to run (1-25):");
                bool ValidInput = false;

                while (!ValidInput)
                {
                    UserResponse = Console.ReadLine();
                    if (!int.TryParse(UserResponse, out DayNumber))
                        Console.WriteLine("Please enter a valid number");
                    else if (DayNumber > Days.Count)
                        Console.WriteLine("Sorry, that day is not implemented yet :(");
                    else if (DayNumber < 1)
                        Console.WriteLine("Must enter a number greater then 0");
                    else
                        ValidInput = true;
                }

                Console.WriteLine("Pick which part you want to run (1/2): ");
                ValidInput = false;
                while (!ValidInput)
                {
                    UserResponse = Console.ReadLine();
                    if (!int.TryParse(UserResponse, out PartNumber))
                        Console.WriteLine("Please enter a valid number");
                    else if (!(PartNumber == 1 || PartNumber == 2))
                        Console.WriteLine("part number must be either a 1 or 2");
                    else
                        ValidInput = true;
                }

                Console.WriteLine("now running day " + DayNumber + " part " + PartNumber);
                Days[DayNumber - 1].RunDay(PartNumber);
            }
        }
    }
}
