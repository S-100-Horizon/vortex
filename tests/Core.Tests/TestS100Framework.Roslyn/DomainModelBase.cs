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


    [System.SerializableAttribute()]
    public abstract class InformationAssociation
    {
    }


    [System.SerializableAttribute()]
    public abstract class FeatureAssociation
    {
    }


    [System.SerializableAttribute()]
    public abstract class InformationTypeBase
    {
        public virtual string Code => string.Empty;
    }


    [System.SerializableAttribute()]
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
        public interface informationBinding
        {
            public static abstract Type[] informationTypes { get; }
            public string? RefId { get; set; }
        }

        public interface featureBinding
        {
            public static abstract Type[] featureTypes { get; }
            public string? RefId { get; set; }
        }

        public abstract record BindingDescriptor(roleType roleType, int lower, int? upper, string role, Type[] types)
        {
            public abstract string associationName { get; }
        }

        public abstract record informationBindingDescriptor(roleType roleType, int lower, int? upper, string role, Type[] informationTypes) : BindingDescriptor(roleType, lower, upper, role, informationTypes)
        {
            public Type[] informationTypes => base.types;
        }

        public record informationBindingDescriptor<TAssociation>(roleType roleType, int lower, int? upper, string role, Type[] informationTypes) : informationBindingDescriptor(roleType, lower, upper, role, informationTypes) where TAssociation : InformationAssociation
        {
            public override string associationName => $"{typeof(TAssociation).Name}, {role}";
        }

        public abstract record featureBindingDescriptor(roleType roleType, int lower, int? upper, string role, Type[] featureTypes) : BindingDescriptor(roleType, lower, upper, role, featureTypes)
        {
            public Type[] featureTypes => base.types;
        }

        public record featureBindingDescriptor<TAssociation>(roleType roleType, int lower, int? upper, string role, Type[] featureTypes) : featureBindingDescriptor(roleType, lower, upper, role, featureTypes) where TAssociation : FeatureAssociation
        {
            public override string associationName => $"{typeof(TAssociation).Name}, {role}";
        }

    }
}