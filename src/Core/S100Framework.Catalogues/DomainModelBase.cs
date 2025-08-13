using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace S100Framework.DomainModel
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class EnumerationAttribute : System.Attribute
    {
        private string _propertyName;
        public string PropertyName => _propertyName;

        private Type? _enumType;
        public Type? EnumType => _enumType;

        public EnumerationAttribute(string propertyName, Type? type = default) {
            _propertyName = propertyName;
            _enumType = type;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class EnumerationValueAttribute : System.Attribute
    {
        private int[] _propertyValues;
        public int[] PropertyValues => _propertyValues;

        public EnumerationValueAttribute(int propertyValue) {
            _propertyValues = [propertyValue];
        }

        public EnumerationValueAttribute(int[] propertyValues) {
            _propertyValues = propertyValues;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class CodeListAttribute : System.Attribute
    {
        private string _propertyName;
        public string PropertyName => _propertyName;

        public CodeListAttribute(string propertyName) {
            _propertyName = propertyName;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
    public class SpatialAssocationAttribute : System.Attribute
    {

    }


    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredAttribute : System.Attribute
    {
    }

    public interface IInformationBindingDefinition
    {
        informationBindingDefinition[] informationBindingDefinitions { get; }
    }

    public interface IFeatureBindingDefinition
    {
        informationBindingDefinition[] informationBindingDefinitions { get; }

        featureBindingDefinition[] featureBindingDefinitions { get; }

        Primitives[] primitives { get; }
    }

    [System.SerializableAttribute()]
    public abstract class Node
    {
        [XmlIgnore]
        public virtual string Code { get; set; } = string.Empty;
    }

    [System.SerializableAttribute()]
    public abstract class InformationNode : Node
    {
        public abstract informationBindingDefinition[] informationBindingDefinitions { get; }
    }

    [System.SerializableAttribute()]
    public abstract class FeatureNode : Node
    {
        public abstract informationBindingDefinition[] informationBindingDefinitions { get; }
        public abstract featureBindingDefinition[] featureBindingDefinitions { get; }

        public abstract Primitives[] primitives { get; }
    }

    [System.SerializableAttribute()]
    public abstract class Association
    {
        public virtual string Code { get; set; } = string.Empty;
    }

    [System.SerializableAttribute()]
    public abstract class InformationAssociation : Association
    {
    }

    [System.SerializableAttribute()]
    public abstract class FeatureAssociation : Association
    {
    }

    public class informationBinding
    {
        public string roleType { get; set; } = string.Empty;
        public string association { get; set; } = string.Empty;
        public string role { get; set; } = string.Empty;
        public string? associationId { get; set; } = null;
        public string? informationId { get; set; } = null;
    }

    public class informationBindingDefinition
    {
        public roleType roleType { get; set; }
        public int lower { get; set; }
        public int? upper { get; set; }
        public bool infinite => !upper.HasValue;
        public string association { get; set; } = string.Empty;
        public string role { get; set; } = string.Empty;
        public string[] informationTypes { get; set; } = [];

        public Primitives[] primitives { get; set; } = [];

        public override string ToString() => $"{association}, {role}";
    }

    public class featureBinding
    {
        public string roleType { get; set; } = string.Empty;
        public string association { get; set; } = string.Empty;
        public string role { get; set; } = string.Empty;
        public string? associationId { get; set; } = null;
        public string? featureId { get; set; } = null;
    }

    public class featureBindingDefinition
    {
        public roleType roleType { get; set; }
        public int lower { get; set; }
        public int? upper { get; set; }
        public bool infinite => !upper.HasValue;
        public string association { get; set; } = string.Empty;
        public string role { get; set; } = string.Empty;
        public string[] featureTypes { get; set; } = [];

        public override string ToString() => $"{association}, {role}";
    }

    public enum roleType
    {
        association,
        aggregation,
        composition,
    }

    public enum Primitives
    {
        noGeometry,
        point,
        pointSet,
        curve,
        surface,
    }
}


namespace S100Framework.DomainModel
{
    public enum TristateStatus
    {
        [EnumMember(Value = "<unknown>")]
        Unknown,    // Default state, or explicitly unknown

        [EnumMember(Value = "<value>>")]
        Value,   // Contains a valid value (which could be null for reference types)

        [EnumMember(Value = "<null>")]
        Null      // Explicitly set to a "null" or "not applicable" state
    }

    public struct Tristate<T> : IEquatable<Tristate<T>>
    {
        private T? _value;
        private TristateStatus _status = TristateStatus.Null;

        public TristateStatus Status {
            get { return _status; }
            set {
                if (value == _status) return;
                _status = value;
                _value = _status switch {
                    TristateStatus.Null => default,
                    TristateStatus.Unknown => default,
                    _ => _value,
                };
            }
        }

        public static Tristate<T> Null { get; } = new Tristate<T>(TristateStatus.Null);
        public static Tristate<T> Unknown { get; } = new Tristate<T>(TristateStatus.Unknown);

        private Tristate(TristateStatus status) {
            if (status == TristateStatus.Value)
                throw new ArgumentException("This constructor is for Null/Unknown states only.");

            Status = status;
            _value = default;
        }

        public Tristate(T value) {
            if (value == null) {
                Status = TristateStatus.Null;
                _value = default(T);
            }
            else {
                Status = TristateStatus.Value;
                _value = value;
            }
        }

        public bool HasValue => Status == TristateStatus.Value;
        public bool IsNull => Status == TristateStatus.Null;
        public bool IsUnknown => Status == TristateStatus.Unknown;

        public T? Value {
            get {
                if (!HasValue) {
                    return default;
                    throw new InvalidOperationException("Tristate does not have a value.");
                }
                return _value!;
            }
            set {
                System.Diagnostics.Debugger.Break();
            }
        }

        public static implicit operator Tristate<T>(T value) => new Tristate<T>(value);

        //public override string ToString() {
        //    return this.Status switch {
        //        //TristateStatus.Value => _value.ToString(),
        //        TristateStatus.Null => "[Null]",
        //        TristateStatus.Unknown => "[Unknown]",
        //        _ => string.Empty
        //    };
        //}

        public override bool Equals(object obj) => obj is Tristate<T> other && Equals(other);

        public bool Equals(Tristate<T> other) {
            if (Status != other.Status) return false;
            if (!HasValue) return true; // Both are Null or both are Unknown
            return System.Collections.Generic.EqualityComparer<T>.Default.Equals(_value, other._value);
        }

        public override int GetHashCode() {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + Status.GetHashCode();
                if (HasValue) {
                    hash = hash * 23 + _value.GetHashCode();
                }
                return hash;
            }
        }

        public static bool operator ==(Tristate<T> left, Tristate<T> right) => left.Equals(right);
        public static bool operator !=(Tristate<T> left, Tristate<T> right) => !left.Equals(right);
    }

    public class SerializableEnumerable<T> : IXmlSerializable where T : notnull
    {
        private T _value;

        // Implicit conversions to and from the underlying enum for ease of use
        public static implicit operator T(SerializableEnumerable<T> o) {
            return o._value;
        }

        public static implicit operator SerializableEnumerable<T>(T o) {
            return new SerializableEnumerable<T>(o);
        }

        public SerializableEnumerable() { }

        public SerializableEnumerable(T value) {
            this._value = value;
        }

        public XmlSchema GetSchema() {
            return null;
        }

        public void ReadXml(XmlReader reader) {
            // Not implemented as the primary focus is on serialization for this example.
            // For deserialization, you would read the attribute and text and convert back to the enum.
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer) {
            // Write the 'code' attribute with the integer value of the enum
            writer.WriteAttributeString("code", $"{Convert.ToInt32(this._value)}");

            // Get the EnumMemberAttribute value for the text content
            var memberInfo = typeof(T).GetMember($"{this._value}").FirstOrDefault();
            if (memberInfo != null) {
                var enumMemberAttribute = memberInfo.GetCustomAttributes(typeof(EnumMemberAttribute), false).FirstOrDefault() as EnumMemberAttribute;
                if (enumMemberAttribute != null) {
                    writer.WriteString(enumMemberAttribute.Value);
                }
            }
        }
    }

}