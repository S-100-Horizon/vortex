using ArcGIS.Core.CIM;
using S100Framework.DomainModel.S101.ComplexAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace S100Framework.Applications
{
    public static class DateHelper
    {
        public static readonly Regex regexTruncatedDateValidation = new(@"^(\d{4}|-{4})(\d{2}|-{2})(\d{2}|-{2})$");

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


        internal static bool TryGetPeriodicDateRange(string? start, string? end, out List<periodicDateRange> value) {
            if (start != default) {
                if (end != default) {
                    if (regexTruncatedDateValidation.IsMatch(end) && regexTruncatedDateValidation.IsMatch(start)) {
                        value = new List<periodicDateRange>() {
                                new periodicDateRange() {
                                    dateStart = start,
                                    dateEnd = end
                                }
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
