using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
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
        [JsonIgnore]
        [XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
        public string gmlId { get; set; }

        [XmlElement(Order = 0, Namespace = "http://www.iho.int/s100gml/5.0")]
        public DataSetIdentification DatasetIdentificationInformation { get; set; }

        [JsonIgnore]
        [XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public abstract string SchemaLocation { get; set; }
    }

    [Serializable]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
    public abstract class MembersBase
    {
        public abstract List<object> elements { get; set; }
    }

    [JsonConverter(typeof(TimeJsonConverter))]
    public readonly struct Time
    {
        private readonly long _ticks;

        private const long MinTimeTicks = 0;

        private const long MaxTimeTicks = 863_999_999_999 + 1;

        public const long MinutesPerHour = TicksPerHour / TicksPerMinute;                           //              60

        /// <summary>
        /// Represents the smallest possible value of Time.
        /// </summary>
        public static Time MinValue => new Time((ulong)MinTimeTicks);

        /// <summary>
        /// Represents the largest possible value of Time.
        /// </summary>
        public static Time MaxValue => new Time((ulong)MaxTimeTicks);

        /// <summary>
        /// Initializes a new instance of the Time structure to the specified hour and the minute.
        /// </summary>
        /// <param name="hour">The hours (0 through 23).</param>
        /// <param name="minute">The minutes (0 through 59).</param>
        public Time(int hour, int minute) : this(Time.TimeToTicks(hour, minute)) { }

        /// <summary>
        /// Initializes a new instance of the Time structure using a specified number of ticks.
        /// </summary>
        /// <param name="ticks">A time of day expressed in the number of 100-nanosecond units since 00:00:00.0000000.</param>
        public Time(long ticks) {
            if ((ulong)ticks > MaxTimeTicks) {
                throw new ArgumentOutOfRangeException(nameof(ticks), "Ticks must be between 0 and and Time.MaxValue.Ticks.");
            }

            _ticks = ticks;
        }

        public int Hours => _ticks == MaxTimeTicks ? 24 : (int)(_ticks / TicksPerHour % HoursPerDay);

        public int Minutes => (int)(_ticks / TicksPerMinute % MinutesPerHour);

        internal Time(ulong ticks) => _ticks = (long)ticks;

        internal const int MicrosecondsPerMillisecond = 1000;
        private const long TicksPerMicrosecond = 10;
        private const long TicksPerMillisecond = TicksPerMicrosecond * MicrosecondsPerMillisecond;

        private const int HoursPerDay = 24;
        private const long TicksPerSecond = TicksPerMillisecond * 1000;
        private const long TicksPerMinute = TicksPerSecond * 60;
        private const long TicksPerHour = TicksPerMinute * 60;
        private const long TicksPerDay = TicksPerHour * HoursPerDay;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong TimeToTicks(int hour, int minute) {
            if ((uint)hour > 24 || (uint)minute >= 60) {
                throw new System.ArgumentOutOfRangeException(null, "Hour and Minute parameters describe an un-representable TimeOfDay.");
            }

            int totalSeconds = hour * 3600 + minute * 60;
            return (uint)totalSeconds * (ulong)TicksPerSecond;
        }

        internal DateTime ToDateTime() => new DateTime(_ticks);

        internal TimeSpan ToTimeSpan() => new TimeSpan(_ticks);

        public override string ToString() => $"{Hours:00}:{Minutes:00}";

        public static Time Parse(string s) {
            var values = s.Split(':');
            if (values.Length >= 2 && int.TryParse(values[0], out int hours) && int.TryParse(values[1], out int minutes))
                return new Time(int.Parse(values[0]), int.Parse(values[1]));
            throw new JsonException("Expected time in 'hh:mm' format.");
        }
    }

    public class TimeJsonConverter : JsonConverter<Time>
    {
        public override Time Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            if (reader.TokenType == JsonTokenType.String) {
                string? timeString = reader.GetString();
                var values = timeString.Split(':');
                if (values.Length == 2 && int.TryParse(values[0], out int hours) && int.TryParse(values[1], out int minutes))
                    return new Time(int.Parse(values[0]), int.Parse(values[1]));
            }
            throw new JsonException("Expected time in 'hh:mm' format.");
        }

        public override void Write(Utf8JsonWriter writer, Time value, JsonSerializerOptions options) {
            writer.WriteStringValue(value.ToString());
        }
    }
}
