using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VortexLoader
{
    public static class DateHelper
    {
        public static DateOnly ConvertToDateOnly(string dateString) {
            if (dateString.Length != 8 || !int.TryParse(dateString, out _)) {
                throw new FormatException("Input string must be in 'yyyymmdd' format.");
            }

            int year = int.Parse(dateString.Substring(0, 4));
            int month = int.Parse(dateString.Substring(4, 2));
            int day = int.Parse(dateString.Substring(6, 2));

            return new DateOnly(year, month, day);
        }
    }
}
