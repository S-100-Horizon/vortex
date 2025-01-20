using S100Framework.WPF.ViewModel;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;

namespace VortexConceptApplication
{



    public class AidsToNavigationAssociationViewModel : S100Framework.WPF.ViewModel.S101.AidsToNavigationAssociationViewModel
    {

    }

    public class UpdatedInformationViewModel : S100Framework.WPF.ViewModel.S101.UpdatedInformationViewModel
    {
        //private string _refId = string.Empty;

        ////[Editor(typeof(RefIdEditor), typeof(RefIdEditor))]
        //public string RefId {
        //    get { return _refId; }
        //    set { this.SetValue(ref _refId, value); }
        //}

        public ObservableCollection<FeatureRefIdViewModel> TestRefId { get; set; } = new ObservableCollection<FeatureRefIdViewModel>();
    }

    public class MyConverter : IMultiValueConverter
    {
        private object? m_rootViewModel;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            m_rootViewModel = values[1] as object;  //Access to Root ViewModel.

            return values[0];
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            return new object[] { value };
        }
    }
}
