using S100Framework.WPF.ViewModel;

namespace S100Framework.WPF
{
    public static class Helper
    {
        public static ViewModelBase? CreateViewModel(string ps, Type type) {
            if (string.IsNullOrEmpty(ps)) return null;

            return ps.ToLowerInvariant() switch {
                "s101" or "s-101" => S100Framework.WPF.ViewModel.S101.Preamble._creators.ContainsKey(type.Name) ? S100Framework.WPF.ViewModel.S101.Preamble._creators[type.Name]() : null,
                "s124" or "s-124" => S100Framework.WPF.ViewModel.S124.Preamble._creators.ContainsKey(type.Name) ? S100Framework.WPF.ViewModel.S124.Preamble._creators[type.Name]() : null,
                "s128" or "s-128" => S100Framework.WPF.ViewModel.S128.Preamble._creators.ContainsKey(type.Name) ? S100Framework.WPF.ViewModel.S128.Preamble._creators[type.Name]() : null,
                "s131" or "s-131" => S100Framework.WPF.ViewModel.S131.Preamble._creators.ContainsKey(type.Name) ? S100Framework.WPF.ViewModel.S131.Preamble._creators[type.Name]() : null,
                //"s201" or "s-201" => S100Framework.WPF.ViewModel.S201.Preamble._creators.ContainsKey(type.Name) ? S100Framework.WPF.ViewModel.S201.Preamble._creators[type.Name]() : null,
                _ => null
            };
        }

        public static ViewModelBase? CreateViewModel(string ps, string type) {
            if (string.IsNullOrEmpty(ps)) return null;

            return ps.ToLowerInvariant() switch {
                "s101" or "s-101" => S100Framework.WPF.ViewModel.S101.Preamble._creators.ContainsKey(type) ? S100Framework.WPF.ViewModel.S101.Preamble._creators[type]() : null,
                "s124" or "s-124" => S100Framework.WPF.ViewModel.S124.Preamble._creators.ContainsKey(type) ? S100Framework.WPF.ViewModel.S124.Preamble._creators[type]() : null,
                "s128" or "s-128" => S100Framework.WPF.ViewModel.S128.Preamble._creators.ContainsKey(type) ? S100Framework.WPF.ViewModel.S128.Preamble._creators[type]() : null,
                "s131" or "s-131" => S100Framework.WPF.ViewModel.S131.Preamble._creators.ContainsKey(type) ? S100Framework.WPF.ViewModel.S131.Preamble._creators[type]() : null,
                //"s201" or "s-201" => S100Framework.WPF.ViewModel.S201.Preamble._creators.ContainsKey(type.Name) ? S100Framework.WPF.ViewModel.S201.Preamble._creators[type.Name]() : null,
                _ => null
            };
        }

    }
}
