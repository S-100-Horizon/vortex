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
    public abstract class InformationTypeBase
    {
        public virtual string Code => string.Empty;
    }

    [System.SerializableAttribute()]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public abstract class FeatureTypeBase
    {
        public virtual string Code => string.Empty;
    }

    namespace Bindings
    {
        public enum roleType
        {
            association,
            aggregation,
            composition,
        }

        public class informationBinding
        {
            public InformationAssociation? association { get; set; }
            public string? role { get; set; }
            public string? informationType { get; set; }
        }

        public abstract class featureBinding
        {
        }

        public class FeatureBindingConnector
        {
            public Guid Uuid { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
            public featureBinding featureBinding { get; set; }
        }

        public abstract class featureBinding<Tassociation, TfeatureType> : featureBinding where Tassociation : FeatureAssociation where TfeatureType : class
        {
            public int Lower { get; set; } = 0;
            public int? Upper { get; set; } = default;
            public bool IsIfinite => !Upper.HasValue;
            public roleType roleType { get; set; }
            public Type association => typeof(Tassociation);
            public string? Role { get; protected set; }
            public Type featureType => typeof(TfeatureType);
        }
    }
}