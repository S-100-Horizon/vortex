using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace S100Framework.DomainModel
{
    public record listedValue(string label, string defintion, int code);

    public abstract class Attribute
    {
        public string name { get; init; } = string.Empty;
        public string code { get; init; } = string.Empty;
    }

    public class SimpleAttribute : Attribute
    {
        public string valueType { get; init; } = string.Empty;
    }

    public class SimpleEnumerationAttribute : SimpleAttribute
    {        
        public listedValue[] listedValues { get; set; } = [];
    }

    public class SimpleCodeListAttribute : SimpleAttribute
    {
        public listedValue[] listedValues { get; set; } = [];
    }

    public class ComplextAttribute : Attribute
    {
        public AttributeBinding[] subAttributeBindings { get; set; } = [];
    }

    public class AttributeBinding
    {
        public string Name => attribute!.code;

        public Attribute? attribute { get; init; }

        public int[]? permitedValues { get; init; } = [];

        public int lower { get; init; } = 0;
        public int upper { get; init; } = int.MaxValue;

        public bool IsCollection => this.upper > 1;
        public bool IsMandatory => this.lower > 0;
        public bool IsOptional => this.lower == 0;

        public int FreeSeats { get; set; } = int.MaxValue;
    }

    public abstract class AttributeValue
    {
        public string code { get; set; } = string.Empty;
        public AttributeBinding? attributeBinding { get; set; }
    }

    public class SimpleAttributeValue : AttributeValue
    {
        public object? Value { get; set; }
    }

    public class ComplextAttributeValue : AttributeValue
    {
        public AttributeValue[] attributeValues { get; set; } = [];
    }
}
