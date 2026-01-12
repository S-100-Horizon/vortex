using S100FC;

namespace S100Framework.Applications
{

    internal static class FeatureNodeExtensions
    {

        private static informationBinding[]? _informationBindingList = null;

        internal static void SetInformationBindings(this FeatureType featureNode, informationBinding[]? informationBinding) {
            _informationBindingList = informationBinding;
        }
        internal static informationBinding[]? GetInformationBindings(this FeatureType featureNode) {
            if (_informationBindingList is null || !_informationBindingList.Any())
                return [];

            return _informationBindingList;
        }

    }
}
