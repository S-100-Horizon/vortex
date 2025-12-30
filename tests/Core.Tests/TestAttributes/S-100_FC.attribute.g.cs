using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace S100Framework.AttributeModel
{
    public record listedValue(string label, string defintion, int code);

    public abstract class Attribute
    {
        [JsonIgnore]
        public abstract string S100FC_code { get; }
        [JsonIgnore]
        public abstract string S100FC_name { get; }
    }

    public abstract class SimpleAttribute : Attribute
    {
        [JsonIgnore]
        public abstract string valueType { get; }
    }

    public abstract class SimpleEnumerationAttribute : SimpleAttribute
    {
        [JsonIgnore]
        public override string valueType => "enumeration";

        [JsonIgnore]
        public abstract listedValue[] listedValues { get; }
    }

    public abstract class SimpleCodeListAttribute : SimpleAttribute
    {
        [JsonIgnore]
        public override string valueType => "S100_CodeList";

        [JsonIgnore]
        public abstract listedValue[] listedValues { get; }
    }

    public abstract class ComplexAttribute : Attribute
    {
        public abstract Attribute[] subAttributes { get; }

        [JsonIgnore]
        public Attribute[] subAttributesOptional { get; set; } = [];

        public abstract AttributeBinding[] subAttributeBindings();
        
        public AttributeBinding[] mandatoryBindings() {
            return [.. this.subAttributeBindings().Where(e => e.lower > 0)];
        }

        public int? FreeSeats(string code) {
            var binding = this.subAttributeBindings().SingleOrDefault(e => e.attribute.Equals(code));
            if (binding == null)
                return null;
            return (binding.upper - this.subAttributes.Where(e => e.GetType().Name.Equals(code)).Count());
        }
    }

    public abstract class FeatureType
    {
        [JsonIgnore]
        public abstract string S100FC_code { get; }
        [JsonIgnore]
        public abstract string S100FC_name { get; }

        public abstract Attribute[] attributes { get; }

        [JsonIgnore]
        public Attribute[] attributesOptional { get; set; } = [];

        public abstract AttributeBinding[] attributeBindings();

        public AttributeBinding[] mandatoryBindings() {
            return [.. this.attributeBindings().Where(e => e.lower > 0)];
        }

    }

    public class AttributeBinding
    {
        public string attribute { get; init; } = string.Empty;

        public int[]? permitedValues { get; init; } = default;

        public int lower { get; init; } = 0;
        public int upper { get; init; } = int.MaxValue;

        public bool IsCollection => this.upper > 1;
        public bool IsMandatory => this.lower > 0;
        public bool IsOptional => this.lower == 0;

        public int FreeSeats { get; set; } = int.MaxValue;
    }

    //public abstract class AttributeValue
    //{

    //}

    //public class AttributeValue<TAttribute> : AttributeValue where TAttribute : Attribute
    //{
    //    public TAttribute? Value { get; set; } = default;
    //}
}