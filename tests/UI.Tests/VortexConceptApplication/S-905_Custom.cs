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
            //            Type = "AdministrationArea",
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

            //associationConnector = base.associationConnectorFeatures.Single(e => e.FeatureType.Equals(fromJson.AssociationConnectorTypeName));

            //base.theUpdate?.Load(fromJson, "theUpdate");

            //base.theUpdatedObject?.Load(fromJson, "theUpdatedObject");
        }

        //public void Load(S100Framework.DomainModel.FeatureAssociation featureAssociation) {
        //    associationConnector = base.associationConnectorFeatures.Single(e => e.FeatureType.Equals(featureAssociation.AssociationConnectorTypeName));

        //    base.theUpdate?.Load(featureAssociation, "theUpdate");

        //    base.theUpdatedObject?.Load(featureAssociation, "theUpdatedObject");            
        //}

        //public string Serialize() {
        //    var instance = new FeatureAssociation {
        //        Code = this.Code,
        //        AssociationConnectorTypeName = associationConnector!.FeatureType,
        //    };

        //    base.theUpdatedObject?.Save(instance, "theUpdatedObject");
        //    base.theUpdate?.Save(instance, "theUpdate");


        //    return System.Text.Json.JsonSerializer.Serialize(instance);
        //}
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
