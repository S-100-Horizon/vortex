using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S100Framework
{
    public class PropertyCollection
    {
        public static PropertyDescriptorCollection GetPropertyItemCollection(object instance) {
            PropertyDescriptorCollection descriptors;

            var tc = TypeDescriptor.GetConverter(instance);
            if (tc == null || !tc.GetPropertiesSupported()) {
                if (instance is ICustomTypeDescriptor) {
                    descriptors = ((ICustomTypeDescriptor)instance).GetProperties();
                }
                //ICustomTypeProvider is only available in .net 4.5 and over. Use reflection so the .net 4.0 and .net 3.5 still works.
                else if (instance.GetType().GetInterface("ICustomTypeProvider", true) != null) {
                    var methodInfo = instance.GetType().GetMethod("GetCustomType")!;
                    var result = methodInfo.Invoke(instance, null) as Type;
                    descriptors = TypeDescriptor.GetProperties(result!);
                }
                else {
                    descriptors = TypeDescriptor.GetProperties(instance.GetType());
                }
            }
            else {
                descriptors = tc.GetProperties(instance)!;
            }

            return descriptors;
        }
    }
}
