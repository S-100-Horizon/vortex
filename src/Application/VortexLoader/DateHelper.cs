using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VortexLoader
{
    public static class DateHelper
    {

        public static bool TryConvertToDateOnly(string dateString, out DateOnly dateOnly) {
            if (dateString.Length != 8 || !int.TryParse(dateString, out _)) {
                dateOnly = default;
                return false;
            }

            int year = int.Parse(dateString.Substring(0, 4));
            int month = int.Parse(dateString.Substring(4, 2));
            int day = int.Parse(dateString.Substring(6, 2));

            dateOnly = new DateOnly(year, month, day);
            return true;
        }
    }
}
