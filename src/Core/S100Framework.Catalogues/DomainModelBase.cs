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


    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredAttribute : System.Attribute
    {
    }


    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class InformationTypeAttribute : System.Attribute
    {
        private Type _informationType;
        public Type InformationType => _informationType;
        public InformationTypeAttribute(Type informationType) {
            _informationType = informationType;
        }
    }


    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class FeatureTypeAttribute : System.Attribute
    {
        private Type _featureType;
        public Type FeatureType => _featureType;
        public FeatureTypeAttribute(Type featureType) {
            _featureType = featureType;
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
            public string? RefId { get; set; }
            public string? InformationType { get; set; }
        }


        public class informationBinding<TAssociation> where TAssociation : InformationAssociation
        {
            public TAssociation? association { get; set; } = default;
        }


        public class featureBinding
        {
            public string? RefId { get; set; }
            public string? FeatureType { get; set; }
        }


        public class featureBinding<TAssociation> where TAssociation : FeatureAssociation
        {
            public TAssociation? association { get; set; } = default;
        }

    }
}