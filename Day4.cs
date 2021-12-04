using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    class Day4 : DayBase
    {

        public List<int> BingoNumbers = new List<int>();

        public List<int[,]> BingoCards = new List<int[,]>();
        public List<bool[,]> BingoHits = new List<bool[,]>();

        public override bool RunPart1()
        {
            if (LoadInput())
            {
                foreach(int number in BingoNumbers)
                {
                    int CardIndex = 0;
                    foreach (int[,] card in BingoCards)
                    {
                        if (CheckForHits(card, number, out int hitX, out int hitY))
                        {
                            BingoHits[CardIndex][hitX,hitY] = true;
                        }

                        if (CheckForWin(BingoHits[CardIndex]))
                        {
                            //win found here
                            int score = GetCardScore(card, BingoHits[CardIndex], number);
                            Console.WriteLine("Awnser to day 4 part 1 is: " + score);
                            return true;
                        }
                        CardIndex++;
                    }
                }
            }
            return false;
        }

        public override bool RunPart2()
        {
            if (LoadInput())
            {
                int LostIndex = 0;
                foreach (int number in BingoNumbers)
                {
                    int CardIndex = 0;
                    int WonCount = 0;
                    foreach (int[,] card in BingoCards)
                    {
                        if (CheckForHits(card, number, out int hitX, out int hitY))
                        {
                            BingoHits[CardIndex][hitX, hitY] = true;
                        }

                        if (CheckForWin(BingoHits[CardIndex]))
                        {
                            WonCount++;
                        }
                        else
                        {
                            LostIndex = CardIndex;
                        }

                        if (WonCount == BingoCards.Count)
                        {
                            int score = GetCardScore(BingoCards[LostIndex], BingoHits[LostIndex], number);
                            Console.WriteLine("Awnser to day 4 part 2 is: " + score);
                            return true;
                        }
                        CardIndex++;
                    }
                }
            }
            return false;
        }

        private bool CheckForHits(int[,] card, int number, out int Xhit, out int Yhit )
        {
            for (int colum = 0; colum < card.GetLength(0); colum++)
            {
                for (int row = 0; row < card.GetLength(1); row++)
                {
                    if (card[colum, row] == number)
                    {
                        Xhit = colum;
                        Yhit = row;
                        return true;
                    }
                }
            }
            Xhit = -1;
            Yhit = -1;
            return false;
        }

        private bool CheckForWin(bool[,] HitCard)
        {
            for (int i = 0; i < HitCard.GetLength(0); i++)
            {
                int hits = 0;
                for (int j = 0; j < HitCard.GetLength(1); j++)
                {
                    if (HitCard[i, j])
                        hits++;
                }
                if (hits == HitCard.GetLength(0))
                    return true;
                hits = 0;
                for (int j = 0; j < HitCard.GetLength(1); j++)
                {
                    if (HitCard[j, i])
                        hits++;
                }
                if (hits == HitCard.GetLength(0))
                    return true;
            }
            return false;
        }

        private int GetCardScore(int[,] card, bool[,] HitCard, int lastNumber)
        {
            int Sum = 0;
            for (int i = 0; i < card.GetLength(0); i++)
            {
                for (int j = 0; j < card.GetLength(1); j++)
                {
                    if (HitCard[i, j] == false)
                        Sum += card[i, j];
                }
            }
            return Sum * lastNumber;
        }

        public override bool LoadInput()
        {
            if (base.LoadInput())
            {
                int[,] TempCard = new int[5, 5];
                int colum = 0, row = 0;
                bool firstLoop = true;
                while (!MyFileStream.EndOfStream)
                {
                    string Line = MyFileStream.ReadLine();
                    if (BingoNumbers.Count == 0) //load in bingo numbers
                    {
                        string[] numbers = Line.Split(',');
                        foreach (string number in numbers)
                        {
                            BingoNumbers.Add(int.Parse(number));
                        }

                    }
                    else if (Line != "")
                    {
                        string[] numberRow = Line.Split(' ');
                        foreach (string number in numberRow)
                        {
                            if (number != "")
                            {
                                TempCard[colum, row] = int.Parse(number);
                                colum++;
                            }
                        }
                        colum = 0;
                        row++;
                        firstLoop = false;
                    }
                    else if(!firstLoop)
                    {
                        BingoCards.Add(TempCard);
                        BingoHits.Add(new bool[5, 5]);
                        colum = 0;
                        row = 0;
                        TempCard = new int[5, 5];
                    }
                }
                return true;
            }
            return false;
        }
    }
}
