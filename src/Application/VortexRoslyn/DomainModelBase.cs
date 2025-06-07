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