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

    [System.SerializableAttribute()]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public abstract class InformationAssociation
    {
        public InformationAssociation()
        {
        }
    }

    [System.SerializableAttribute()]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public abstract class FeatureAssociation
    {
        public FeatureAssociation()
        {
        }
    }
}