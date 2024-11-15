using System;
using System.Linq;
using System.ComponentModel;

namespace S100Framework.DomainModel
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class CodeListAttribute : System.Attribute
    {
        private string _propertyName;
        public string PropertyName => _propertyName;

        public CodeListAttribute(string propertyName)
        {
            _propertyName = propertyName;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class RoleAttribute : System.Attribute
    {
        private string _roleName;
        public string RoleName => _roleName;

        public RoleAttribute(string roleName)
        {
            _roleName = roleName;
        }
    }

    [System.SerializableAttribute()]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public abstract class InformationAssociation
    {
    }

    [System.SerializableAttribute()]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public abstract class FeatureAssociation
    {
    }

    [System.SerializableAttribute()]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class informationBinding<T>
        where T : InformationAssociation
    {
        public string roleType { get; set; } = string.Empty;
        public string role { get; set; } = string.Empty;
        public Type? informationType { get; set; } = default;
    }

    [System.SerializableAttribute()]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class featureBinding<T>
        where T : FeatureAssociation
    {
        public string roleType { get; set; } = string.Empty;
        public string role { get; set; } = string.Empty;
        public Type? featureType { get; set; } = default;
    }
}