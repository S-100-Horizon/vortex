using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

namespace S100FC
{
    public enum Closure : int
    {
        openInterval = 0,
        geLtInterval = 1,
        gtLeInterval = 2,
        closedInterval = 3,
        gtSemiInterval = 4,
        geSemiInterval = 5,
        ltSemiInterval = 6,
        leSemiInterval = 7,
    }

    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class OrderAttribute(int order) : System.Attribute
    {
        public int Order { get; set; } = order;
    }

    public abstract class ConstraintAttribute() : System.Attribute
    {
    }

    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
    public class PrecisionConstraintAttribute(int precision) : ConstraintAttribute
    {
        public int Precision = precision;
    }

    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
    public class StringLengthConstraintAttribute(int stringLength) : ConstraintAttribute
    {
        public int StringLength = stringLength;
    }

    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
    public class TextPatternConstraint(string textPattern) : ConstraintAttribute
    {
        public string TextPattern = textPattern;

        public Regex Regex = new Regex(textPattern, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
    }

    public abstract class RangeConstraintAttribute(Closure closure) : ConstraintAttribute
    {
        public Closure Closure = closure;
    }

    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
    public class RangeConstraintRealAttribute(double lowerBound, double upperBound, Closure closure) : RangeConstraintAttribute(closure)
    {
        public double LowerBound = lowerBound;
        public double UpperBound = upperBound;
    }

    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
    public class RangeConstraintIntegerAttribute(int lowerBound, int upperBound, Closure closure) : RangeConstraintAttribute(closure)
    {
        public int LowerBound = lowerBound;
        public int UpperBound = upperBound;
    }
}

namespace S100FC.S100
{
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
                var timeString = reader.GetString();
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

    [Serializable]
    [XmlType(Namespace = "http://www.iho.int/s100/xc/5.2")]
    public enum S100_SupportFileFormat
    {
        [XmlEnum("TXT_UTF-8")]
        TXT,
        [XmlEnum("JPEG2000")]
        JPEG2000,
        [XmlEnum("HTML")]
        HTML,
        [XmlEnum("XML")]
        XML,
        [XmlEnum("XSLT")]
        XSLT,
        [XmlEnum("VIDEO")]
        VIDEO,
        [XmlEnum("TIFF")]
        TIFF,
        [XmlEnum("PDF/AorUA")]
        PDF,
        [XmlEnum("LUA")]
        LUA,
        [XmlEnum("other")]
        other,

    }
}

namespace S100FC
{
    public enum Primitives
    {
        noGeometry,
        point,
        pointSet,
        curve,
        surface,
    }

    public record listedValue(string label, string defintion, int code);

    public abstract class attributeBinding
    {
        [JsonIgnore]
        public abstract string S100FC_code { get; }

        [JsonIgnore]
        public abstract string S100FC_name { get; }

        [JsonIgnore]
        public abstract bool HasValue { get; }
    }

    public abstract class SimpleAttribute : attributeBinding
    {
        [JsonIgnore]
        public abstract string valueType { get; }
    }

    public abstract class BooleanAttribute : SimpleAttribute
    {
        [JsonIgnore]
        public override string valueType => "boolean";

        public Boolean? value { get; set; } = default;

        [JsonIgnore]
        public override bool HasValue => value.HasValue;
    }

    public abstract class IntegerAttribute : SimpleAttribute
    {
        [JsonIgnore]
        public override string valueType => "integer";

        public int? value { get; set; } = default;

        [JsonIgnore]
        public override bool HasValue => value.HasValue;
    }

    public abstract class RealAttribute : SimpleAttribute
    {
        [JsonIgnore]
        public override string valueType => "real";

        public decimal? value { get; set; } = default;

        [JsonIgnore]
        public override bool HasValue => value.HasValue;
    }

    public abstract class TextAttribute : SimpleAttribute
    {
        [JsonIgnore]
        public override string valueType => "text";

        public String? value { get; set; } = default;

        [JsonIgnore]
        public override bool HasValue => value != null;
    }

    public abstract class S100_TruncatedDateAttribute : SimpleAttribute
    {
        [JsonIgnore]
        public override string valueType => "S100_TruncatedDate";

        public String? value { get; set; } = default;

        [JsonIgnore]
        public override bool HasValue => value != null;
    }

    public abstract class DateAttribute : SimpleAttribute
    {
        [JsonIgnore]
        public override string valueType => "date";

        public DateOnly? value { get; set; } = default;

        [JsonIgnore]
        public override bool HasValue => value.HasValue;
    }

    public abstract class DateTimeAttribute : SimpleAttribute
    {
        [JsonIgnore]
        public override string valueType => "datetime";

        public DateTime? value { get; set; } = default;

        [JsonIgnore]
        public override bool HasValue => value.HasValue;
    }

    public abstract class TimeAttribute : SimpleAttribute
    {
        [JsonIgnore]
        public override string valueType => "time";

        public S100FC.S100.Time? value { get; set; } = default;

        [JsonIgnore]
        public override bool HasValue => value.HasValue;
    }

    public abstract class UrnTimeAttribute : SimpleAttribute
    {
        [JsonIgnore]
        public override string valueType => "URN";

        public String? value { get; set; } = default;

        [JsonIgnore]
        public override bool HasValue => value != null;
    }

    public abstract class UrlTimeAttribute : SimpleAttribute
    {
        [JsonIgnore]
        public override string valueType => "URL";

        public String? value { get; set; } = default;

        [JsonIgnore]
        public override bool HasValue => value != null;
    }

    public abstract class UriTimeAttribute : SimpleAttribute
    {
        [JsonIgnore]
        public override string valueType => "URI";

        public String? value { get; set; } = default;

        [JsonIgnore]
        public override bool HasValue => value != null;
    }

    public abstract class EnumerationAttribute : SimpleAttribute
    {
        [JsonIgnore]
        public override string valueType => "enumeration";

        //[JsonIgnore]
        //public abstract listedValue[] listedValues { get; }

        public int? value { get; set; } = default;

        [JsonIgnore]
        public override bool HasValue => value.HasValue;
    }

    public abstract class CodeListAttribute : SimpleAttribute
    {
        [JsonIgnore]
        public override string valueType => "S100_CodeList";

        //[JsonIgnore]
        //public abstract listedValue[] listedValues { get; }

        public int? value { get; set; } = default;

        [JsonIgnore]
        public override bool HasValue => value.HasValue;
    }



    public interface IAttributeBindings
    {
    }

    public interface IInformationBindings
    {
        informationBindingDefinition[] GetInformationBindingsDefinitions();

        static abstract informationBindingDefinition[] informationBindingsDefinitions { get; }
    }

    public interface IFeatureBindings
    {
        informationBindingDefinition[] GetInformationBindingsDefinitions();
        featureBindingDefinition[] GetFeatureBindingsDefinitions();

        static abstract featureBindingDefinition[] featureBindingsDefinitions { get; }
    }

    public abstract class ComplexAttribute : attributeBinding, IAttributeBindings
    {
        [JsonInclude]
        [JsonPropertyName("attr")]
        public attributeBinding[] attributeBindings { get; protected set; } = [];

        [JsonIgnore]
        public virtual attributeBindingDefinition[] attributeBindingsCatalogue { get; } = [];

        public attributeBindingDefinition[] mandatoryBindings() {
            return [.. attributeBindingsCatalogue!.Where(e => e.lower > 0)];
        }

        public int? FreeSeats(string code) {
            var binding = attributeBindingsCatalogue!.SingleOrDefault(e => e.attribute.Equals(code));
            if (binding == null)
                return null;
            return (binding.upper - this.attributeBindings.Where(e => e.GetType().Name.Equals(code)).Count());
        }

        public void SetAttribute(attributeBinding attribute) {
            if (attribute == null) return;
            var binding = attributeBindingsCatalogue!.Single(e => e.attribute.Equals(attribute.S100FC_code));
            if (binding.upper == 1) {
                var value = this.attributeBindings.SingleOrDefault(e => e.S100FC_code.Equals(attribute.S100FC_code));
                if (value == default) {
                    this.attributeBindings = [.. this.attributeBindings, attribute];
                }
                else {
                    var index = Array.IndexOf(this.attributeBindings, value);
                    this.attributeBindings[index] = attribute;
                }
            }
            else {
                this.attributeBindings = [.. this.attributeBindings, attribute];
            }
        }

        public void RemoveAttribute(attributeBinding attribute) {
            if (attribute == null) return;
            var binding = attributeBindingsCatalogue!.Single(e => e.attribute.Equals(attribute.S100FC_code));
            this.attributeBindings = [.. this.attributeBindings.Where(e => e != attribute)];
            if (binding.lower > this.attributeBindings.Count(e => e.S100FC_code.Equals(attribute.S100FC_code))) {
                this.attributeBindings = [.. this.attributeBindings, binding.CreateInstance()!];
            }
        }

        protected void SetAttribute(string code, attributeBinding?[] attributes) {
            if (attributes == null || !attributes.Any()) {
                this.attributeBindings = [.. this.attributeBindings.Where(e => !e.S100FC_code.Equals(code))];

                foreach (var binding in attributeBindingsCatalogue.Where(e => e.attribute.Equals(code) && e.lower > 0)) {
                    for (int i = 0; i < binding.lower; i++) {
                        this.SetAttribute(binding.CreateInstance()!);
                    }
                }
            }
            else {
                this.attributeBindings = [.. this.attributeBindings.Where(e => !e.S100FC_code.Equals(code)), .. attributes!];
            }

            //foreach (var a in attribute) {
            //    var binding = attributeBindingsCatalogue!.Single(e => e.attribute.Equals(a.S100FC_code));
            //    if (binding.upper == 1) {
            //        var value = this.attributeBindings.SingleOrDefault(e => e.S100FC_code.Equals(a.S100FC_code));
            //        if (value == default) {
            //            this.attributeBindings = [.. this.attributeBindings, a];
            //        }
            //        else {
            //            var index = Array.IndexOf(this.attributeBindings, value);
            //            this.attributeBindings[index] = a;
            //        }
            //    }
            //    else {
            //        this.attributeBindings = [.. this.attributeBindings, a];
            //    }
            //}
        }

        protected TAttribute? GetAttributeValue<TAttribute>(string name) where TAttribute : attributeBinding {
            return this.attributeBindings.SingleOrDefault(e => e.S100FC_code.Equals(name)) as TAttribute;
        }

        protected TAttribute[] GetAttributeValues<TAttribute>(string name) where TAttribute : attributeBinding {
            return this.attributeBindings.Where(e => e.S100FC_code.Equals(name)).Cast<TAttribute>().ToArray();
        }

        public ComplexAttribute() {
            foreach (var binding in attributeBindingsCatalogue.Where(e => e.lower > 0)) {
                for (int i = 0; i < binding.lower; i++)
                    this.SetAttribute(binding.CreateInstance()!);
            }
        }

        [JsonIgnore]
        public override bool HasValue => true;  //TODO: HasValue on ComplexAttribute!!!

        public virtual bool IsValid() => true;
    }

    public abstract class InformationType : IAttributeBindings
    {
        [JsonIgnore]
        public abstract string S100FC_code { get; }

        [JsonIgnore]
        public abstract string S100FC_name { get; }

        [JsonInclude]
        [JsonPropertyName("attr")]
        public attributeBinding[] attributeBindings { get; protected set; } = [];

        //[JsonIgnore]
        //public informationBinding[] informationBindings { get; set; } = [];

        [JsonIgnore]
        public virtual attributeBindingDefinition[] attributeBindingsCatalogue { get; } = [];

        public abstract informationBindingDefinition[] GetInformationBindingsDefinitions();

        public attributeBindingDefinition[] mandatoryBindings() {
            return [.. attributeBindingsCatalogue!.Where(e => e.lower > 0)];
        }

        public void SetAttribute(attributeBinding attribute) {
            if (attribute == null) return;
            var binding = attributeBindingsCatalogue!.Single(e => e.attribute.Equals(attribute.S100FC_code));
            if (binding.upper == 1) {
                var value = this.attributeBindings.SingleOrDefault(e => e.S100FC_code.Equals(attribute.S100FC_code));
                if (value == default) {
                    this.attributeBindings = [.. this.attributeBindings, attribute];
                }
                else {
                    var index = Array.IndexOf(this.attributeBindings, value);
                    this.attributeBindings[index] = attribute;
                }
            }
            else {
                this.attributeBindings = [.. this.attributeBindings, attribute];
            }
        }

        public void RemoveAttribute(attributeBinding attribute) {
            if (attribute == null) return;
            var binding = attributeBindingsCatalogue!.Single(e => e.attribute.Equals(attribute.S100FC_code));
            this.attributeBindings = [.. this.attributeBindings.Where(e => e != attribute)];
            if (binding.lower > this.attributeBindings.Count(e => e.S100FC_code.Equals(attribute.S100FC_code))) {
                this.attributeBindings = [.. this.attributeBindings, binding.CreateInstance()!];
            }
        }

        public void SetAttribute(string code, attributeBinding?[] attributes) {
            if (attributes == null || !attributes.Any()) {
                this.attributeBindings = [.. this.attributeBindings.Where(e => !e.S100FC_code.Equals(code))];

                foreach (var binding in attributeBindingsCatalogue.Where(e => e.attribute.Equals(code) && e.lower > 0)) {
                    for (int i = 0; i < binding.lower; i++) {
                        this.SetAttribute(binding.CreateInstance()!);
                    }
                }
            }
            else {
                this.attributeBindings = [.. this.attributeBindings.Where(e => !e.S100FC_code.Equals(code)), .. attributes!];
            }

            //foreach (var a in attribute) {
            //    var binding = attributeBindingsCatalogue!.Single(e => e.attribute.Equals(a.S100FC_code));
            //    if (binding.upper == 1) {
            //        var value = this.attributeBindings.SingleOrDefault(e => e.S100FC_code.Equals(a.S100FC_code));
            //        if (value == default) {
            //            this.attributeBindings = [.. this.attributeBindings, a];
            //        }
            //        else {
            //            var index = Array.IndexOf(this.attributeBindings, value);
            //            this.attributeBindings[index] = a;
            //        }
            //    }
            //    else {
            //        this.attributeBindings = [.. this.attributeBindings, a];
            //    }
            //}
        }

        protected TAttribute? GetAttributeValue<TAttribute>(string name) where TAttribute : attributeBinding {
            return this.attributeBindings.SingleOrDefault(e => e.S100FC_code.Equals(name)) as TAttribute;
        }

        protected TAttribute[] GetAttributeValues<TAttribute>(string name) where TAttribute : attributeBinding {
            return this.attributeBindings.Where(e => e.S100FC_code.Equals(name)).Cast<TAttribute>().ToArray();
        }

        public InformationType() {
            foreach (var binding in attributeBindingsCatalogue.Where(e => e.lower > 0)) {
                for (int i = 0; i < binding.lower; i++)
                    this.SetAttribute(binding.CreateInstance()!);
            }
        }

        public virtual bool IsValid() => true;
    }

    public abstract class FeatureType : IAttributeBindings
    {
        [JsonIgnore]
        public abstract string S100FC_code { get; }

        [JsonIgnore]
        public abstract string S100FC_name { get; }

        [JsonInclude]
        [JsonPropertyName("attr")]
        public attributeBinding[] attributeBindings { get; protected set; } = [];

        //[JsonIgnore]
        //public informationBinding[] informationBindings { get; set; } = [];

        //[JsonIgnore]
        //public featureBinding[] featureBindings { get; set; } = [];

        [JsonIgnore]
        public abstract Primitives[] permittedPrimitives { get; }

        [JsonIgnore]
        public virtual attributeBindingDefinition[] attributeBindingsCatalogue { get; } = [];

        public abstract informationBindingDefinition[] GetInformationBindingsDefinitions();

        public abstract featureBindingDefinition[] GetFeatureBindingsDefinitions();

        public attributeBindingDefinition[] mandatoryBindings() {
            return [.. attributeBindingsCatalogue!.Where(e => e.lower > 0)];
        }

        public void SetAttribute(attributeBinding attribute) {
            if (attribute == null) return;
            var binding = attributeBindingsCatalogue!.Single(e => e.attribute.Equals(attribute.S100FC_code));
            if (binding.upper == 1) {
                var value = this.attributeBindings.SingleOrDefault(e => e.S100FC_code.Equals(attribute.S100FC_code));
                if (value == default) {
                    //if (attribute.HasValue) //TODO:  NULL ???
                    this.attributeBindings = [.. this.attributeBindings, attribute];
                }
                else {
                    var index = Array.IndexOf(this.attributeBindings, value);
                    this.attributeBindings[index] = attribute;
                }
            }
            else {
                this.attributeBindings = [.. this.attributeBindings, attribute];
            }
        }

        public void RemoveAttribute(attributeBinding attribute) {
            if (attribute == null) return;
            var binding = attributeBindingsCatalogue!.Single(e => e.attribute.Equals(attribute.S100FC_code));
            this.attributeBindings = [.. this.attributeBindings.Where(e => e != attribute)];
            if (binding.lower > this.attributeBindings.Count(e => e.S100FC_code.Equals(attribute.S100FC_code))) {
                this.attributeBindings = [.. this.attributeBindings, binding.CreateInstance()!];
            }
        }

        public void SetAttribute(string code, attributeBinding?[] attributes) {
            if (attributes == null || !attributes.Any()) {
                this.attributeBindings = [.. this.attributeBindings.Where(e => !e.S100FC_code.Equals(code))];

                foreach (var binding in attributeBindingsCatalogue.Where(e => e.attribute.Equals(code) && e.lower > 0)) {
                    for (int i = 0; i < binding.lower; i++) {
                        this.SetAttribute(binding.CreateInstance()!);
                    }
                }
            }
            else {
                this.attributeBindings = [.. this.attributeBindings.Where(e => !e.S100FC_code.Equals(code)), .. attributes!];
            }
        }

        protected TAttribute? GetAttributeValue<TAttribute>(string name) where TAttribute : attributeBinding {
            return this.attributeBindings.SingleOrDefault(e => e.S100FC_code.Equals(name)) as TAttribute;
        }

        protected TAttribute[] GetAttributeValues<TAttribute>(string name) where TAttribute : attributeBinding {
            return this.attributeBindings.Where(e => e.S100FC_code.Equals(name)).Cast<TAttribute>().ToArray();
        }

        public FeatureType() {
            foreach (var binding in attributeBindingsCatalogue.Where(e => e.lower > 0)) {
                for (int i = 0; i < binding.lower; i++)
                    this.SetAttribute(binding.CreateInstance()!);
            }
        }

        public virtual bool Validate(ICollection<string>? errors = default) => true;
    }

    public class attributeBindingDefinition
    {
        public string attribute { get; init; } = string.Empty;

        public int[]? permitedValues { get; init; } = default;

        public int lower { get; init; } = 0;
        public int upper { get; init; } = int.MaxValue;

        public int order { get; init; } = 0;

        public bool IsCollection => this.upper > 1;
        public bool IsMandatory => this.lower > 0;
        public bool IsOptional => this.lower == 0;

        public Func<attributeBinding?> CreateInstance { get; init; } = () => null;
    }

    public class informationBindingDefinition
    {
        public string roleType { get; init; } = string.Empty;
        public string role { get; init; } = string.Empty;
        public string association { get; init; } = string.Empty;

        public int lower { get; init; } = 0;
        public int upper { get; init; } = int.MaxValue;

        public bool IsCollection => this.upper > 1;
        public bool IsMandatory => this.lower > 0;
        public bool IsOptional => this.lower == 0;

        public string[] informationTypes { get; init; } = [];

        public Func<informationBinding?> CreateInstance { get; init; } = () => null;
    }

    public class featureBindingDefinition
    {
        public string roleType { get; init; } = string.Empty;
        public string role { get; init; } = string.Empty;
        public string association { get; init; } = string.Empty;

        public int lower { get; init; } = 0;
        public int upper { get; init; } = int.MaxValue;

        public bool IsCollection => this.upper > 1;
        public bool IsMandatory => this.lower > 0;
        public bool IsOptional => this.lower == 0;

        public string[] featureTypes { get; init; } = [];

        public Func<featureBinding?> CreateInstance { get; init; } = () => null;
    }

    public abstract class Association
    {
        [JsonIgnore]
        public abstract string S100FC_code { get; }

        [JsonIgnore]
        public abstract string S100FC_name { get; }

        [JsonInclude]
        public attributeBinding[] attributes { get; protected set; } = [];

        [JsonIgnore]
        public virtual attributeBindingDefinition[] attributeBindingsCatalogue { get; } = [];

        protected void SetAttribute(attributeBinding attribute) {
            if (attribute == null) return;
            var binding = attributeBindingsCatalogue!.Single(e => e.attribute.Equals(attribute.S100FC_code));
            if (binding.upper == 1) {
                var value = this.attributes.SingleOrDefault(e => e.S100FC_code.Equals(attribute.S100FC_code));
                if (value == default) {
                    this.attributes = [.. this.attributes, attribute];
                }
                else {
                    var index = Array.IndexOf(this.attributes, value);
                    this.attributes[index] = attribute;
                }
            }
            else {
                this.attributes = [.. this.attributes, attribute];
            }
        }

        protected void SetAttribute(attributeBinding[] attribute) {
            if (attribute == null) return;
            foreach (var a in attribute) {
                var binding = attributeBindingsCatalogue!.Single(e => e.attribute.Equals(a.S100FC_code));
                if (binding.upper == 1) {
                    var value = this.attributes.SingleOrDefault(e => e.S100FC_code.Equals(a.S100FC_code));
                    if (value == default) {
                        this.attributes = [.. this.attributes, a];
                    }
                    else {
                        var index = Array.IndexOf(this.attributes, value);
                        this.attributes[index] = a;
                    }
                }
                else {
                    this.attributes = [.. this.attributes, a];
                }
            }
        }

        protected TAttribute? GetAttributeValue<TAttribute>(string name) where TAttribute : attributeBinding {
            return this.attributes.SingleOrDefault(e => e.S100FC_code.Equals(name)) as TAttribute;
        }

        protected TAttribute[] GetAttributeValues<TAttribute>(string name) where TAttribute : attributeBinding {
            return this.attributes.Where(e => e.S100FC_code.Equals(name)).Cast<TAttribute>().ToArray();
        }

        public Association() {
            foreach (var binding in attributeBindingsCatalogue.Where(e => e.lower > 0)) {
                for (int i = 0; i < binding.lower; i++)
                    this.SetAttribute(binding.CreateInstance()!);
            }
        }

    }

    public interface IInformationAssociation
    {
        public abstract static string role { get; }
    }

    public abstract class InformationAssociation : Association
    {
        //[JsonIgnore]
        //public abstract string role { get; }        
    }

    public abstract class FeatureAssociation : Association
    {
        //[JsonIgnore]
        //public abstract string[] roles { get; }
    }

    public abstract class informationBinding
    {
        public string roleType { get; init; } = string.Empty;
        public string role { get; init; } = string.Empty;
        public string? informationType { get; set; } = null;
        public string informationId { get; set; } = string.Empty;

        public virtual bool Validate(ICollection<string>? errors = default) {
            if (string.IsNullOrEmpty(roleType)) return false;
            if (string.IsNullOrEmpty(role)) return false;
            if (string.IsNullOrEmpty(informationType)) return false;
            if (string.IsNullOrEmpty(informationId)) return false;
            return true;
        }
    }

    public class informationBinding<TAssociation> : informationBinding where TAssociation : InformationAssociation, new()
    {
        public TAssociation association { get; init; } = new TAssociation();

        public override bool Validate(ICollection<string>? errors = default) {
            return base.Validate(errors);
        }
    }

    public abstract class featureBinding
    {
        public string roleType { get; init; } = string.Empty;
        public string role { get; init; } = string.Empty;
        public string? featureType { get; set; } = null;
        public string featureId { get; set; } = string.Empty;

        public virtual bool Validate(ICollection<string>? errors = default) {
            if (string.IsNullOrEmpty(roleType)) return false;
            if (string.IsNullOrEmpty(role)) return false;
            if (string.IsNullOrEmpty(featureType)) return false;
            if (string.IsNullOrEmpty(featureId)) return false;
            return true;
        }
    }

    public class featureBinding<TAssociation> : featureBinding where TAssociation : FeatureAssociation, new()
    {
        public TAssociation association { get; init; } = new TAssociation();

        public override bool Validate(ICollection<string>? errors = default) {
            return base.Validate(errors);
        }
    }

    public interface ISummary
    {
        public static string Name => string.Empty;
        public static string Scope => string.Empty;
        public static string ProductId => string.Empty;
        public static Version Version => throw new NotImplementedException();
        public static DateOnly VersionDate => throw new NotImplementedException();
    }
}