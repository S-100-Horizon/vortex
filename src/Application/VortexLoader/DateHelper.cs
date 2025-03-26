using ArcGIS.Core.CIM;
using S100Framework.DomainModel.S101.ComplexAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S100Framework.Applications
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


        internal static bool TryGetPeriodicDateRange(string? start, string? end, out List<periodicDateRange> value) {
            if (start != default) {
                if (end != default) {
                    if (DateHelper.TryConvertToDateOnly(end, out var dateEnd)) {
                        if (DateHelper.TryConvertToDateOnly(start, out var dateStart)) {
                            value = new List<periodicDateRange>() {
                                new periodicDateRange() {
                                    dateStart = dateStart,
                                    dateEnd = dateEnd
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
            else {
                value = null;
                return false;
            }
        }

        internal static bool TryGetFixedDateRange(string? start, string? end, out fixedDateRange? value) {
            if (start != default) {
                if (end != default) {
                    if (DateHelper.TryConvertToDateOnly(end, out var dateEnd)) {
                        if (DateHelper.TryConvertToDateOnly(start, out var dateStart)) {
                            value = new fixedDateRange() {
                                dateStart = dateStart,
                                dateEnd = dateEnd
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
            else {
                value = null;
                return false;
            }
        }
    }
}
