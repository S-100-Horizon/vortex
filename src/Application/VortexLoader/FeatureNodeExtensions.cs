using ArcGIS.Core.Data;
using S100Framework.DomainModel;

namespace S100Framework.Applications
{

    internal static class FeatureNodeExtensions
    {

        private static List<informationBinding> _informationBindingList = null!;

        internal static void SetInformationBindings(this FeatureNode featureNode, List<informationBinding> informationBinding) {
            _informationBindingList = informationBinding;
        }
        internal static List<informationBinding> GetInformationBindings(this FeatureNode featureNode) {
            if (_informationBindingList.Count == 0)
                return null!;
            
            return _informationBindingList;
        }

    }
}
