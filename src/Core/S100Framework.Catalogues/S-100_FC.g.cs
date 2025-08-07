using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace S100Framework.Catalogues
{
    public class S100_TruncatedDate
    {
        public string Value { get; set; }
    }
}

namespace S100Framework.DomainModel.S100
{
    #region SimpleTypes

    [Serializable]
    [XmlType(Namespace = "http://www.iho.int/s100gml/5.0")]
    public enum MD_TopicCategoryCode
    {
        [XmlEnum("farming")]
        Farming,
        [XmlEnum("biota")]
        Biota,
        [XmlEnum("boundaries")]
        Boundaries,
        [XmlEnum("climatologyMeteorologyAtmosphere")]
        ClimatologyMeteorologyAtmosphere,
        [XmlEnum("economy")]
        Economy,
        [XmlEnum("elevation")]
        Elevation,
        [XmlEnum("environment")]
        Environment,
        [XmlEnum("geoscientificInformation")]
        GeoscientificInformation,
        [XmlEnum("health")]
        Health,
        [XmlEnum("imageryBaseMapsEarthCover")]
        ImageryBaseMapsEarthCover,
        [XmlEnum("intelligenceMilitary")]
        IntelligenceMilitary,
        [XmlEnum("inlandWaters")]
        InlandWaters,
        [XmlEnum("location")]
        Location,
        [XmlEnum("oceans")]
        Oceans,
        [XmlEnum("planningCadastre")]
        PlanningCadastre,
        [XmlEnum("society")]
        Society,
        [XmlEnum("structure")]
        Structure,
        [XmlEnum("transportation")]
        Transportation,
        [XmlEnum("utilitiesCommunication")]
        UtilitiesCommunication,
    }

    [Serializable]
    [XmlType(Namespace = "http://www.iho.int/s100gml/5.0")]
    public enum datasetPurposeType
    {
        [XmlEnum("base")]
        Base,
        [XmlEnum("update")]
        Update,
    }

    #endregion


    #region ComplexTypes

    #endregion

    [System.Serializable()]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
    [XmlType(Namespace = "http://www.iho.int/s100gml/5.0")]
    public partial class DataSetIdentification
    {
        [XmlElement(Order = 0)]
        public string encodingSpecification { get; init; } = "S-100 Part 10b";

        [XmlElement(Order = 1)]
        public string encodingSpecificationEdition { get; init; } = "1.0";

        [XmlElement(Order = 2)]
        public string productIdentifier { get; set; }

        [XmlElement(Order = 3)]
        public string productEdition { get; set; }

        [XmlElement(Order = 4)]
        public string applicationProfile { get; set; }

        [XmlElement(Order = 5)]
        public string datasetFileIdentifier { get; set; }

        [XmlElement(Order = 6)]
        public string datasetTitle { get; set; }

        [XmlElement(DataType = "date", Order = 7)]
        public DateTime datasetReferenceDate { get; set; }

        [XmlElement(Order = 8)]
        public string datasetLanguage { get; set; } = "eng";

        [XmlElement(Order = 9)]
        public string datasetAbstract { get; set; }

        [XmlElement("datasetTopicCategory", Order = 10)]
        public List<MD_TopicCategoryCode> datasetTopicCategory { get; set; } = new List<MD_TopicCategoryCode>();

        [XmlElement(Order = 11)]
        public datasetPurposeType datasetPurpose { get; set; }

        [XmlElement(DataType = "nonNegativeInteger", Order = 12)]
        public string updateNumber { get; set; }
    }


    [Serializable]
    public abstract class DatasetBase
    {
        [XmlElement(Order = 0)]
        public DataSetIdentification DatasetIdentificationInformation { get; set; }
    }

    [Serializable]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
    public abstract class MembersBase
    {
        public abstract List<object> elements { get; set; }
    }


    public readonly struct TimeOfDay
    {
        // represent the number of ticks map to the time of the day. 1 ticks = 100-nanosecond in time measurements.
        private readonly long _ticks;

        // MinTimeTicks is the ticks for the midnight time 00:00:00.000 AM
        private const long MinTimeTicks = 0;

        // MaxTimeTicks is the max tick value for the time in the day. It is calculated using DateTime.Today.AddTicks(-1).TimeOfDay.Ticks +1 to include 24:00.
        private const long MaxTimeTicks = 863_999_999_999 + 1;

        /// <summary>
        /// Represents the smallest possible value of TimeOfDay.
        /// </summary>
        public static TimeOfDay MinValue => new TimeOfDay((ulong)MinTimeTicks);

        /// <summary>
        /// Represents the largest possible value of TimeOfDay.
        /// </summary>
        public static TimeOfDay MaxValue => new TimeOfDay((ulong)MaxTimeTicks);

        /// <summary>
        /// Initializes a new instance of the TimeOfDay structure to the specified hour and the minute.
        /// </summary>
        /// <param name="hour">The hours (0 through 23).</param>
        /// <param name="minute">The minutes (0 through 59).</param>
        public TimeOfDay(int hour, int minute) : this(TimeOfDay.TimeToTicks(hour, minute)) { }


        /// <summary>
        /// Initializes a new instance of the TimeOfDay structure using a specified number of ticks.
        /// </summary>
        /// <param name="ticks">A time of day expressed in the number of 100-nanosecond units since 00:00:00.0000000.</param>
        public TimeOfDay(long ticks) {
            if ((ulong)ticks > MaxTimeTicks) {
                throw new ArgumentOutOfRangeException(nameof(ticks), "Ticks must be between 0 and and TimeOfDay.MaxValue.Ticks.");
            }

            _ticks = ticks;
        }

        // exist to bypass the check in the public constructor.
        internal TimeOfDay(ulong ticks) => _ticks = (long)ticks;

        internal const int MicrosecondsPerMillisecond = 1000;
        private const long TicksPerMicrosecond = 10;
        private const long TicksPerMillisecond = TicksPerMicrosecond * MicrosecondsPerMillisecond;

        private const int HoursPerDay = 24;
        private const long TicksPerSecond = TicksPerMillisecond * 1000;
        private const long TicksPerMinute = TicksPerSecond * 60;
        private const long TicksPerHour = TicksPerMinute * 60;
        private const long TicksPerDay = TicksPerHour * HoursPerDay;

        // Return the tick count corresponding to the given hour, minute, second.
        // Will check the if the parameters are valid.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong TimeToTicks(int hour, int minute) {
            if ((uint)hour > 24 || (uint)minute >= 60) {
                throw new System.ArgumentOutOfRangeException(null, "Hour and Minute parameters describe an un-representable TimeOfDay.");
            }

            int totalSeconds = hour * 3600 + minute * 60;
            return (uint)totalSeconds * (ulong)TicksPerSecond;
        }
    }
}
