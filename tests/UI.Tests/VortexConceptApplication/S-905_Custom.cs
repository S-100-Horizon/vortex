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

        //public ObservableCollection<FeatureRefIdViewModel> TestRefId { get; set; } = new ObservableCollection<FeatureRefIdViewModel>();

        public UpdatedInformationViewModel() : base() {

            //var fromJson = new S100Framework.DomainModel.FeatureAssociation {
            //    Code = "UpdatedInformation",
            //    AssociationConnectorTypeName = "AdministrationArea",
            //    RefIds = new[] {
            //        new S100Framework.DomainModel.RefId {
            //            Type = "",
            //            Role = "theUpdate",
            //            Value = "Hello",
            //        },
            //        new S100Framework.DomainModel.RefId {
            //            Type = "UpdateInformation",
            //            Role = "theUpdatedObject",
            //            Value = "World (1)",
            //        },
            //        new S100Framework.DomainModel.RefId {
            //            Type = "UpdateInformation",
            //            Role = "theUpdatedObject",
            //            Value = "World (2)",
            //        }
            //    },
            //};

            ////var a = base.associationConnectorFeatures[typeof(S100Framework.WPF.ViewModel.S101.UpdatedInformationViewModel)]();

            //associationConnector = base.associationConnectorFeatures.Single(e => e.FeatureType.Equals(fromJson.AssociationConnectorTypeName));

            //var refId = new AdministrationAreaViewModel.AdministrationAreaRefIdViewModel();
            //refId.FeatureType = refId.AssociationTypes[0];
            //refId.RefId = "Hello";

            //((SingleFeatureBindingViewModel<AdministrationAreaViewModel.AdministrationAreaRefIdViewModel>)base.theUpdate!).RefId = refId;

            //var theUpdatedObject = ((MultiFeatureBindingViewModel<UpdatedInformationViewModel.theUpdateAdministrationAreaRefIdViewModel>)base.theUpdatedObject!);

            //for (var i = 0; i < 2; i++) {
            //    var r = new UpdatedInformationViewModel.theUpdateAdministrationAreaRefIdViewModel();
            //    r.FeatureType = typeof(UpdateInformation).Name;
            //    r.RefId = $"World ({i})";
            //    theUpdatedObject.RefId.Add(r);
            //}
        }
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

namespace S100Framework.DomainModel
{
    [System.SerializableAttribute()]
    public class RefId
    {
        public required string Value { get; set; }
        public required string Type { get; set; }
        public required string Role { get; set; }
    }

    [System.SerializableAttribute()]
    public class FeatureAssociation
    {
        public required string Code { get; set; }
        public required string AssociationConnectorTypeName { get; set; }
        public RefId[] RefIds { get; set; } = new RefId[0];
    }

    public class UpdatedInformation : FeatureAssociation
    {

    }
}