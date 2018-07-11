using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SevenShifts.Utils.Helpers
{
    public class EnumHelper
    {
        public static string GetDescription(Enum value)
        {
            var type = value.GetType();

            var memberInfo = type.GetMember(value.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return value.ToString();
        }
    }
}
