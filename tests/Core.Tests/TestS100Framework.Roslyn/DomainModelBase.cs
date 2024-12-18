namespace S100Framework.DomainModel
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class CodeListAttribute : System.Attribute
    {
        private string _propertyName;
        public string PropertyName => _propertyName;

        public CodeListAttribute(string propertyName) {
            _propertyName = propertyName;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class RoleAttribute : System.Attribute
    {
        private string _roleName;
        public string RoleName => _roleName;

        public RoleAttribute(string roleName) {
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

        public abstract class informationBinding
        {
            public abstract Type[] informationTypes { get; }
        }

        public abstract class featureBinding
        {
            public abstract Type[] featureTypes { get; }
        }
    }
}