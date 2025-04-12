using S100Framework.WPF.ViewModel;

namespace S100Framework.WPF
{
    public static class Helper
    {
        public static ViewModelBase? CreateInformationAssociationViewModel(string ps, string type, string pid) {
            if (string.IsNullOrEmpty(ps)) return null;

            return ps.ToLowerInvariant() switch {
                "s101" or "s-101" => ViewModel.S101.Bootstrap.CreateInformationAssociation(type, pid),
                "s122" or "s-122" => (ViewModelBase)ViewModel.S122.Bootstrap.CreateInformationAssociation(type, pid),
                "s124" or "s-124" => (ViewModelBase)ViewModel.S124.Bootstrap.CreateInformationAssociation(type, pid),
                "s128" or "s-128" => (ViewModelBase)ViewModel.S128.Bootstrap.CreateInformationAssociation(type, pid),
                "s131" or "s-131" => (ViewModelBase)ViewModel.S131.Bootstrap.CreateInformationAssociation(type, pid),
                //"s201" or "s-201" => ViewModel.S201.Bootstrap.CreateInformationAssociation(type, pid),
                "s501" or "s-501" => (ViewModelBase)ViewModel.S501.Bootstrap.CreateInformationAssociation(type, pid),
                _ => null
            };
        }

        public static ViewModelBase? CreateFeatureAssociationViewModel(string ps, string type, string pid) {
            if (string.IsNullOrEmpty(ps)) return null;

            return ps.ToLowerInvariant() switch {
                "s101" or "s-101" => ViewModel.S101.Bootstrap.CreateFeatureAssociation(type, pid),
                "s122" or "s-122" => (ViewModelBase)ViewModel.S122.Bootstrap.CreateFeatureAssociation(type, pid),
                "s124" or "s-124" => (ViewModelBase)ViewModel.S124.Bootstrap.CreateFeatureAssociation(type, pid),
                "s128" or "s-128" => (ViewModelBase)ViewModel.S128.Bootstrap.CreateFeatureAssociation(type, pid),
                "s131" or "s-131" => (ViewModelBase)ViewModel.S131.Bootstrap.CreateFeatureAssociation(type, pid),
                //"s201" or "s-201" => ViewModel.S201.Bootstrap.CreateFeatureAssociation(type, pid),
                "s501" or "s-501" => (ViewModelBase)ViewModel.S501.Bootstrap.CreateFeatureAssociation(type, pid),
                _ => null
            };
        }

        public static InformationViewModel? CreateInformationTypeViewModel(string ps, string type, string pid) {
            if (string.IsNullOrEmpty(ps)) return null;

            return ps.ToLowerInvariant() switch {
                "s101" or "s-101" => ViewModel.S101.Bootstrap.CreateInformationType(type, pid),
                "s122" or "s-122" => ViewModel.S122.Bootstrap.CreateInformationType(type, pid),
                "s124" or "s-124" => ViewModel.S124.Bootstrap.CreateInformationType(type, pid),
                "s128" or "s-128" => ViewModel.S128.Bootstrap.CreateInformationType(type, pid),
                "s131" or "s-131" => ViewModel.S131.Bootstrap.CreateInformationType(type, pid),
                //"s201" or "s-201" => ViewModel.S201.Bootstrap.CreateInformationType(type, pid),
                "s501" or "s-501" => ViewModel.S501.Bootstrap.CreateInformationType(type, pid),
                _ => null
            };
        }

        public static FeatureViewModel? CreateFeatureTypeViewModel(string ps, string type, string pid) {
            if (string.IsNullOrEmpty(ps)) return null;

            return ps.ToLowerInvariant() switch {
                "s101" or "s-101" => ViewModel.S101.Bootstrap.CreateFeatureType(type, pid),
                "s122" or "s-122" => ViewModel.S122.Bootstrap.CreateFeatureType(type, pid),
                "s124" or "s-124" => ViewModel.S124.Bootstrap.CreateFeatureType(type, pid),
                "s128" or "s-128" => ViewModel.S128.Bootstrap.CreateFeatureType(type, pid),
                "s131" or "s-131" => ViewModel.S131.Bootstrap.CreateFeatureType(type, pid),
                //"s201" or "s-201" => ViewModel.S201.Bootstrap.CreateFeatureType(type, pid),
                "s501" or "s-501" => ViewModel.S501.Bootstrap.CreateFeatureType(type, pid),
                _ => null
            };
        }

    }
}
