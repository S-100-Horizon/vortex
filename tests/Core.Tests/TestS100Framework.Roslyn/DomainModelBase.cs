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
    public abstract class Node
    {
        public virtual string Code => string.Empty;
    }


    [System.SerializableAttribute()]
    public abstract class InformationNode : Node
    {
    }


    [System.SerializableAttribute()]
    public abstract class FeatureNode : Node
    {
    }

    namespace Bindings
    {
        public enum roleType
        {
            association,
            aggregation,
            composition,
        }
    }
}