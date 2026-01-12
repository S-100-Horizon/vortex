using S100FC.S101.ComplexAttributes;
using System.Text.RegularExpressions;

namespace S100Framework.Applications
{
    public static class DateHelper
    {
        //public static readonly Regex regexTruncatedDateValidation = new(@"^(\d{4}|-{4})(\d{2}|-{2})(\d{2}|-{2})$");
        private static readonly Regex regexTruncatedDateValidation = new(@"^--(0[1-9]|1[0-2])(0[1-9]|[12][0-9]|3[01])$");

        public static bool TryConvertSordat(string value, out string? result) {
            // Remove non-digit characters (just in case)
            var input = new string(value.Where(char.IsDigit).ToArray());

            if (input.Length > 8)
                throw new ArgumentException("Input cannot be longer than 8 digits.");

            // Pad right with '-' to length 8
            result = input.PadRight(8, '-');

            string yearPart = result.Substring(0, 4);
            string monthPart = result.Substring(4, 2);
            string dayPart = result.Substring(6, 2);

            // Validate year: must be digits (no '-')
            if (!yearPart.All(char.IsDigit))
                //throw new ArgumentException("Year part must be 4 digits.");
                return false;

            int year = int.Parse(yearPart);

            // Validate month
            if (monthPart != "--") {
                if (!monthPart.All(char.IsDigit))
                    //throw new ArgumentException("Month part must be digits or '--'.");
                    return false;

                int month = int.Parse(monthPart);
                if (month < 1 || month > 12)
                    //throw new ArgumentException($"Invalid month value: {month}");
                    return false;
            }

            // Validate day
            if (dayPart != "--") {
                if (!dayPart.All(char.IsDigit))
                    //throw new ArgumentException("Day part must be digits or '--'.");
                    return false;

                int day = int.Parse(dayPart);

                if (monthPart == "--") {
                    // Day present but month missing → invalid
                    //throw new ArgumentException("Day provided but month is missing.");
                    return false;
                }

                int month = int.Parse(monthPart);

                // Check day validity for the month & year
                if (day < 1 || day > DateTime.DaysInMonth(year, month))
                    //throw new ArgumentException($"Invalid day value: {day} for year {year}, month {month}");
                    return false;
            }

            return true;
        }




        public static bool TryConvertToDateOnly(string? dateString, out DateOnly dateOnly) {
            if (dateString == null) {
                dateOnly = default;
                return false;
            }
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


        internal static bool TryGetPeriodicDateRange(string? start, string? end, out periodicDateRange[]? value) {
            if (start != default) {
                if (end != default) {
                    if (regexTruncatedDateValidation.IsMatch(end) && regexTruncatedDateValidation.IsMatch(start)) {
                        value = [
                                new periodicDateRange() {
                                    dateStart = $"--{start}",
                                    dateEnd = $"--{end}"
                                }
                            ];
                        return true;
                    }
                    else {
                        value = null;
                        return false;
                    }
                }
                else {
                    value = null;
                    return false;
                }
            }
            else {
                value = null;
                return false;
            }
        }


        /// <summary>
            /* Survey Data Range: In S-57, the attribute SUREND is not mandatory for M_QUAL. In S-101, the
            complex attribute survey date range, sub-attribute date end, is mandatory for Quality of Bathymetric
            Data.In order to optimise the S-57 to S-101 conversion process, Data Producers should ensure that
            the attribute SUREND is populated with appropriate values, if available, on all M_QUAL Meta Objects
            for their S-57 datasets (for example, where the seabed is likely to change over time). If this is not done,
            survey date range, sub-attribute date end will be populated as empty (null) during the automated
            conversion process.
            */
        /// </summary>
        /// <param _s101name="start"></param>
        /// <param _s101name="end"></param>
        /// <param _s101name="value"></param>
        /// <returns></returns>
        internal static bool TryGetSurveyDateRange(string? start, string? end, out surveyDateRange? value) {
            if (string.IsNullOrEmpty(start) || !DateHelper.regexTruncatedDateValidation.IsMatch(start)) {
                value = null;
                return false;
            }

            value = new surveyDateRange {
                dateEnd = default,
                dateStart = start
            };
            if (!string.IsNullOrEmpty(end) && DateHelper.regexTruncatedDateValidation.IsMatch(end)) {
                value.dateEnd = end;
            }

            return true;
        }

        internal static bool TryGetFixedDateRange(string? start, string? end, out fixedDateRange? value) {
            if (start != default) {
                if (end != default) {
                    if (regexTruncatedDateValidation.IsMatch(end) && regexTruncatedDateValidation.IsMatch(start)) {
                        value = new fixedDateRange() {
                            dateStart = start,
                            dateEnd = end
                        };
                        return true;
                    }
                    else {
                        value = null;
                        return false;
                    }
                }
                else {
                    value = null;
                    return false;
                }
            }
            else {
                value = null;
                return false;
            }
        }
    }
}
