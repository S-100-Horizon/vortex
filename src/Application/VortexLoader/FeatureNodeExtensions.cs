using ArcGIS.Core.Data;
using S100Framework.DomainModel;

namespace S100Framework.Applications
{

    internal static class FeatureNodeExtensions
    {

        private static List<object> _informationBindingList = null!;

        internal static void SetInformationBindings(this FeatureNode featureNode, List<object> informationBinding) {
            _informationBindingList = informationBinding;
        }
        internal static List<object> GetInformationBindings(this FeatureNode featureNode) {
            return _informationBindingList;
        }

    }
}
