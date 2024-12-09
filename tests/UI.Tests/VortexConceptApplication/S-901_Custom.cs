using S100Framework.DomainModel;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S201.FeatureTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S100Framework.WPF.ViewModel.S901
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class WhereClauseAttribute : System.Attribute
    {
        private string _clause;
        public string WhereClause => _clause;

        public WhereClauseAttribute(string clause) {
            _clause = clause;
        }
    }
}

namespace S100Framework.WPF.ViewModel.S901
{
    public partial class QualityOfBathymetricDataViewModel
    {

        //  CUSTOM
        [Category("Development")]
        [Editor(typeof(Editors.BindingConnectorEditor), typeof(Editors.BindingConnectorEditor))]
        public ObservableCollection<informationBindingViewModel> theQualityInformationSpatialQuality { get; set; } = new();


        //private Guid? _qualityOfBathymetricDataCompositione;
        //[Category("Custom")]
        //[Editor(typeof(VortexConceptApplication.InformationTypeSelectorEditor), typeof(VortexConceptApplication.InformationTypeSelectorEditor))]
        //[WhereClause("ps = 'S-101' and code = 'SpatialQuality'")]
        //public Guid? QualityOfBathymetricDataComposition {
        //    get {
        //        return _qualityOfBathymetricDataCompositione;
        //    }

        //    set {
        //        SetValue(ref _qualityOfBathymetricDataCompositione, value);
        //    }
        //}

        //[Category("Custom")]
        //[Editor(typeof(VortexConceptApplication.InformationTypeSelectorEditor), typeof(VortexConceptApplication.InformationTypeSelectorEditor))]
        //[WhereClause("ps = 'S-101' and code = 'SpatialQuality'")]
        //public ObservableCollection<Guid> QualityOfBathymetricDataCompositionArray { get; set; } = new();

    }
}

namespace S100Framework.DomainModel.S901.FeatureTypes
{
    //public class informationBinding<Tassociation, TinformationType> 
    //    : DomainModel.Bindings.informationBinding<Tassociation, TinformationType> where Tassociation 
    //    : InformationAssociation where TinformationType : class
    //{
    //    public informationBinding() {
    //        //base.Role = Enum.GetName(role);
    //    }

    //    public Guid? InformationTypeRef { get; set; }
    //}

    public class QualityOfBathymetricDataCustom : S101.FeatureTypes.QualityOfBathymetricData {
        //public Guid? QualityOfBathymetricDataComposition {get;set;}

        //public List<Guid>? QualityOfBathymetricDataCompositionArray { get; set; }
    }
}