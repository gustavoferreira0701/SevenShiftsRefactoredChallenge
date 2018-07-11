using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SevenShifts.Utils.Helpers
{
    public class DateHelper
    {
        private static Calendar calendar = new GregorianCalendar();

        public static int GetWeekNumber(DateTime date)
        {
            return calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }
    }
}
