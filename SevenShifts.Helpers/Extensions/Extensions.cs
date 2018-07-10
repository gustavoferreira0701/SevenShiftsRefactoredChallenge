using System;
using System.Collections.Generic;
using System.Text;

namespace SevenShifts.Helpers.Extensions
{
    public static class Extensions
    {
        public static double LimitToTimeFormat(this double value)
        {
            return Math.Round(value, 2);
        }

        public static bool IsNullOrDefault(this DateTime date)
        {
            return date == null || date == default(DateTime);
        }
    }
}
