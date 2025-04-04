using S100Framework.WPF.ViewModel;

namespace S100Framework.WPF
{
    public static class Helper
    {
        public static ViewModelBase? CreateViewModel(string ps, Type type) {
            if (string.IsNullOrEmpty(ps)) return null;

            return ps.ToLowerInvariant() switch {
                "s101" or "s-101" => ViewModel.S101.Bootstrap.Exist(type.Name) ? ViewModel.S101.Bootstrap.Create(type.Name) : null,
                "s122" or "s-122" => ViewModel.S122.Bootstrap.Exist(type.Name) ? ViewModel.S122.Bootstrap.Create(type.Name) : null,
                "s124" or "s-124" => ViewModel.S124.Bootstrap.Exist(type.Name) ? ViewModel.S124.Bootstrap.Create(type.Name) : null,
                "s128" or "s-128" => ViewModel.S128.Bootstrap.Exist(type.Name) ? ViewModel.S128.Bootstrap.Create(type.Name) : null,
                "s131" or "s-131" => ViewModel.S131.Bootstrap.Exist(type.Name) ? ViewModel.S131.Bootstrap.Create(type.Name) : null,
                //"s201" or "s-201" => ViewModel.S201.Bootstrap.Exist(type.Name) ? ViewModel.S201.Bootstrap.Create(type.Name) : null,
                "s501" or "s-501" => ViewModel.S501.Bootstrap.Exist(type.Name) ? ViewModel.S501.Bootstrap.Create(type.Name) : null,
                _ => null
            };
        }

        public static ViewModelBase? CreateViewModel(string ps, string type) {
            if (string.IsNullOrEmpty(ps)) return null;

            return ps.ToLowerInvariant() switch {
                "s101" or "s-101" => ViewModel.S101.Bootstrap.Exist(type) ? ViewModel.S101.Bootstrap.Create(type) : null,
                "s122" or "s-122" => ViewModel.S122.Bootstrap.Exist(type) ? ViewModel.S122.Bootstrap.Create(type) : null,
                "s124" or "s-124" => ViewModel.S124.Bootstrap.Exist(type) ? ViewModel.S124.Bootstrap.Create(type) : null,
                "s128" or "s-128" => ViewModel.S128.Bootstrap.Exist(type) ? ViewModel.S128.Bootstrap.Create(type) : null,
                "s131" or "s-131" => ViewModel.S131.Bootstrap.Exist(type) ? ViewModel.S131.Bootstrap.Create(type) : null,
                //"s201" or "s-201" => ViewModel.S201.Bootstrap.Exist(type.Name) ? ViewModel.S201.Bootstrap.Create(type) : null,
                "s501" or "s-501" => ViewModel.S501.Bootstrap.Exist(type) ? ViewModel.S501.Bootstrap.Create(type) : null,
                _ => null
            };
        }

    }
}
