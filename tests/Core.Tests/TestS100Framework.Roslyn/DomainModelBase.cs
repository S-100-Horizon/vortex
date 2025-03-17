using System;
using System.Linq;
using System.ComponentModel;

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
        public virtual string Code => string.Empty;
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
    }

    [System.SerializableAttribute()]
    public class RoleRefId : RefId {
        public required string Role { get; set; }
    }

    [System.SerializableAttribute()]
    public abstract class Association {
        public required string Code { get; set; }
        public required roleType roleType { get; set; }
        public required string AssociationConnectorTypeName { get; set; }

        public abstract string[]? this[string role] { get; }

        public RefId[] RefIds { get; set; } = new RefId[0];
    }

    [System.SerializableAttribute()]
    public abstract class InformationAssociation : Association {
        public RefId[] RefIds { get; set; } = new RefId[0];
    }

    [System.SerializableAttribute()]
    public abstract class FeatureAssociation : Association {
        public RoleRefId[] RefIds { get; set; } = new RoleRefId[0];
    }

    public enum roleType {
        association,
        aggregation,
        composition,
    }
}