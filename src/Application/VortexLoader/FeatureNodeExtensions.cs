using ArcGIS.Core.Data;
using S100Framework.DomainModel;

namespace S100Framework.Applications
{

    internal static class FeatureNodeExtensions
    {

        private static List<DomainModel.informationBinding> _informationBindingList = null!;

        internal static void SetInformationBindings(this FeatureNode featureNode, List<DomainModel.informationBinding> informationBinding) {
            _informationBindingList = informationBinding;
        }
        internal static List<DomainModel.informationBinding> GetInformationBindings(this FeatureNode featureNode) {
            return _informationBindingList;
        }

    }
}
