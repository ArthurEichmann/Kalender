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





            throw new NotImplementedException();
        }

        private static int CountDaysMonth(int year, int month)
        {
            int days = System.DateTime.DaysInMonth(year, month);
            return days;
        }

    }
}
