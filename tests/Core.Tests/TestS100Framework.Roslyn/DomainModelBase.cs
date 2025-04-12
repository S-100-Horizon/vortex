using System;
using System.Linq;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace S100Framework.DomainModel {
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class EnumerationAttribute : System.Attribute {
        private string _propertyName;
        public string PropertyName => _propertyName;

        public EnumerationAttribute(string propertyName) {
            _propertyName = propertyName;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class EnumerationValueAttribute : System.Attribute {
        private int _propertyValue;
        public int PropertyValue => _propertyValue;

        public EnumerationValueAttribute(int propertyValue) {
            _propertyValue = propertyValue;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class CodeListAttribute : System.Attribute {
        private string _propertyName;
        public string PropertyName => _propertyName;

        public CodeListAttribute(string propertyName) {
            _propertyName = propertyName;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class RoleAttribute : System.Attribute {
        private string _roleName;
        public string RoleName => _roleName;

        public RoleAttribute(string roleName) {
            _roleName = roleName;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredAttribute : System.Attribute {
    }

    [System.SerializableAttribute()]
    public abstract class Node {
        public virtual string Code { get; set; } = string.Empty;
    }

    [System.SerializableAttribute()]
    public abstract class InformationNode : Node {
    }

    [System.SerializableAttribute()]
    public abstract class FeatureNode : Node {
    }

    [System.SerializableAttribute()]
    public class RefId {
        public required string? Value { get; set; }
        public required string? Type { get; set; }
        public required string Role { get; set; }
    }

    [System.SerializableAttribute()]
    public abstract class Association {
    }

    [System.SerializableAttribute()]
    public abstract class InformationAssociation : Association {
    }

    [System.SerializableAttribute()]
    public abstract class FeatureAssociation : Association {
    }

    public class informationBinding {
        public string roleType { get; set; } = string.Empty;
        public string association { get; set; } = string.Empty;
        public string role { get; set; } = string.Empty;
        public string? associationId { get; set; } = null;
        public string? informationId { get; set; } = null;
        public string? PID { get; set; } = null;
    }

    public class informationBindingDefinition {
        public roleType roleType { get; set; }
        public int lower { get; set; }
        public int? upper { get; set; }
        public bool infinite => !upper.HasValue;
        public string association { get; set; } = string.Empty;
        public string role { get; set; } = string.Empty;
        public string[] informationTypes { get; set; } = [];

        public override string ToString() => $"{association}, {role}";
    }

    public class featureBinding {
        public string roleType { get; set; } = string.Empty;
        public string association { get; set; } = string.Empty;
        public string role { get; set; } = string.Empty;
        public string? associationId { get; set; } = null;
        public string? featureId { get; set; } = null;
        public string? PID { get; set; } = null;
    }

    public class featureBindingDefinition {
        public roleType roleType { get; set; }
        public int lower { get; set; }
        public int? upper { get; set; }
        public bool infinite => !upper.HasValue;
        public string association { get; set; } = string.Empty;
        public string role { get; set; } = string.Empty;
        public string[] featureTypes { get; set; } = [];

        public override string ToString() => $"{association}, {role}";
    }

    public enum roleType {
        association,
        aggregation,
        composition,
    }
}