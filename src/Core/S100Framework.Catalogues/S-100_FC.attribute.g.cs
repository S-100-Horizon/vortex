using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

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
        public abstract Attribute[] attributes { get; }

        [JsonIgnore]
        public Attribute[] attributesOptional { get; set; } = [];

        public abstract AttributeBinding[] attributeBindings();

        public AttributeBinding[] mandatoryBindings() {
            return [.. this.attributeBindings().Where(e => e.lower > 0)];
        }

        public int? FreeSeats(string code) {
            var binding = this.attributeBindings().SingleOrDefault(e => e.attribute.Equals(code));
            if (binding == null)
                return null;
            return (binding.upper - this.attributes.Where(e => e.GetType().Name.Equals(code)).Count());
        }

        protected void AddAttributeValue(Attribute attribute) {
            var binding = attributeBindings().Single(e => e.attribute.Equals(attribute.S100FC_code));
            if (binding.upper == 1) {
                var value = this.attributesOptional.SingleOrDefault(e => e.S100FC_code.Equals(attribute.S100FC_code));
                if (value == default) {
                    this.attributesOptional = [.. this.attributesOptional, attribute];
                }
                else {
                    var index = Array.IndexOf(this.attributesOptional, value);
                    this.attributesOptional[index] = attribute;
                }
            }
            else {
                this.attributesOptional = [.. this.attributesOptional, attribute];
            }
        }
    }

    public abstract class InformationType
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

        protected void AddAttributeValue(Attribute attribute) {
            var binding = attributeBindings().Single(e => e.attribute.Equals(attribute.S100FC_code));
            if (binding.upper == 1) {
                var value = this.attributesOptional.SingleOrDefault(e => e.S100FC_code.Equals(attribute.S100FC_code));
                if (value == default) {
                    this.attributesOptional = [.. this.attributesOptional, attribute];
                }
                else {
                    var index = Array.IndexOf(this.attributesOptional, value);
                    this.attributesOptional[index] = attribute;
                }
            }
            else {
                this.attributesOptional = [.. this.attributesOptional, attribute];
            }
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

        protected void AddAttributeValue(Attribute attribute) {
            var binding = attributeBindings().Single(e => e.attribute.Equals(attribute.S100FC_code));
            if (binding.upper == 1) {
                var value = this.attributesOptional.SingleOrDefault(e => e.S100FC_code.Equals(attribute.S100FC_code));
                if (value == default) {
                    this.attributesOptional = [.. this.attributesOptional, attribute];
                }
                else {
                    var index = Array.IndexOf(this.attributesOptional, value);
                    this.attributesOptional[index] = attribute;
                }
            }
            else {
                this.attributesOptional = [.. this.attributesOptional, attribute];
            }
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

        public Func<Attribute?> CreateInstance { get; init; } = () => null;
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