using System;
using QueoChallengeImplementation;

namespace Kalender
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int j = 2021; j < 2024; j++)
            {
                string[,] kalender = QueoChallengeImplementation.Calendar.GetYearSheet(j);

                int rows = kalender.GetLength(1);
                int cols = kalender.GetLength(0);

                Console.WriteLine(j);
                for (int i = 0; i < rows; i++)
                {
                    for (int y = 0; y < cols; y++)
                    {
                        Console.Write(String.Format("{0,5}", kalender[y, i]) + " ");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }
    }
}
