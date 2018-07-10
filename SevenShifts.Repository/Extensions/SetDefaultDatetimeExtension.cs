using System;

namespace SevenShifts.Repository.Extensions
{
    public static class CustomExtensions 
    {
       public static string FixWrongDateTimeValue(this String text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            return text.Replace("0000-00-00 00:00:00", default(DateTime).ToString());
        }
    }
}
