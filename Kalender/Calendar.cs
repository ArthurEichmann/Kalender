using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace QueoChallengeImplementation
{

    public static class Calendar
    {
        public static string[,] GetYearSheet(int year)
        {
            string[,] calendar = new string[26, 31];
            int row = 0;
            int startRow = 0;
            int biggestRow = -2;
            int day;
            int cw = 0;
            int col = 0;
            int flagMonthChange = 0;

            for (int month = 1; month <= 12; month++)
            {
                int startCol = month % 3;   //Calculating which col start
                switch (startCol)           //getting cols for the months
                {
                    case 1:
                        startCol = 0;
                        startRow = biggestRow;
                        startRow = startRow + 2;
                        break;
                    case 2:
                        startCol = 9;
                        break;
                    case 0:
                        startCol = 18;
                        break;
                    default:
                        Console.WriteLine($"An unexpected value ({month})");
                        break;
                }

                col = startCol;
                row = startRow;
                calendar = SetMonthName(calendar, col, row, month);
                calendar = SetHeadline(calendar, col, row);

                //getting days of the month and start writing the days in to its cols
                int daysMonth = CountDaysMonth(year, month);
                for (int i = 0; i < daysMonth; i++)
                {
                    day = i + 1;
                    DateTime date = new DateTime(year, month, day);

                    col = (int)date.DayOfWeek;  //Starting col for the days
                    if (col == 0)
                    {
                        col = 7;
                    }

                    if (i == 0 || (int)date.DayOfWeek == 1)
                    {
                        row++;
                        if (month == 1 && i == 0)   //Looking for leap year and calculate the cw
                        {
                            if (col <= 4)
                            {
                                calendar[0, row] = "1";
                                cw = 1;
                            }
                            else if (col == 5)
                            {
                                calendar[0, row] = "53";
                                cw = 53;
                            }
                            else
                            {
                                calendar[0, row] = "52";
                                cw = 52;
                            }
                        }
                        else
                        {
                            if (( cw >= 52 && i > 28) || (cw >= 52 && month == 1))
                            {
                                cw = 0;
                            }

                            if (flagMonthChange != 1 || (int)date.DayOfWeek == 1)
                            {
                                cw++;
                                flagMonthChange = 0;
                            }
                        }
                    }

                    calendar[startCol, row] = cw.ToString();
                    calendar[col + startCol, row] = day.ToString();

                    if (row > biggestRow)
                    {
                        biggestRow = row;
                    }


                    if (i == daysMonth - 1)
                    {
                        flagMonthChange = 1;
                    }
                }

            }
           
            return calendar;
        }

        private static string[,] SetMonthName(string[,] calendar, int col, int row, int month)
        {
            switch (month)
            {
                case 1:
                    calendar[col, row] = "JAN";
                    break;
                case 2:
                    calendar[col, row] = "FEB";
                    break;
                case 3:
                    calendar[col, row] = "MAR";
                    break;
                case 4:
                    calendar[col, row] = "APR";
                    break;
                case 5:
                    calendar[col, row] = "MAY";
                    break;
                case 6:
                    calendar[col, row] = "JUN";
                    break;
                case 7:
                    calendar[col, row] = "JUL";
                    break;
                case 8:
                    calendar[col, row] = "AUG";
                    break;
                case 9:
                    calendar[col, row] = "SEP";
                    break;
                case 10:
                    calendar[col, row] = "OCT";
                    break;
                case 11:
                    calendar[col, row] = "NOV";
                    break;
                case 12:
                    calendar[col, row] = "DEC";
                    break;
                default:
                    Console.WriteLine($"An unexpected value ({month})");
                    break;
            }

            return calendar;
        }

        private static int CountDaysMonth(int year, int month)
        {
            int days = System.DateTime.DaysInMonth(year, month);
            return days;
        }

        private static string[,] SetHeadline(string[,] calendar, int col, int row)
        {
            col++;
            calendar[col, row] = "MON";

            col++;
            calendar[col, row] = "TUE";

            col++;
            calendar[col, row] = "WED";

            col++;
            calendar[col, row] = "THU";

            col++;
            calendar[col, row] = "FRI";

            col++;
            calendar[col, row] = "SAT";

            col++;
            calendar[col, row] = "SUN";

            return calendar;
        }


    }
}
