using ArcGIS.Core.CIM;
using ArcGIS.Core.Data.UtilityNetwork.Trace;
using ArcGIS.Core.Data.UtilityNetwork;
using ArcGIS.Core.Internal.CIM;
using ArcGIS.Desktop.Editing.Attributes;
using ArcGIS.Desktop.Internal.Mapping;
using CommandLine.Text;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.SignalR;
using Microsoft.VisualBasic;
using S100Framework.DomainModel.S101.ComplexAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace S100Framework.Applications
{
    public static class DateHelper
    {

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


        internal static bool TryGetPeriodicDateRange(string? start, string? end, out List<periodicDateRange>? value) {
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
            var dateStartConverted = DateHelper.TryConvertToDateOnly(start, out DateOnly dateStart);

            if (!dateStartConverted) {
                value = null;
                return false;
            }

            var dateEndConverted = DateHelper.TryConvertToDateOnly(end, out DateOnly dateEnd);

            value = new surveyDateRange();

            value.dateStart = dateStart;
            if (dateEndConverted) {
                value.dateEnd = dateEnd;
            } 

            return true;
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
