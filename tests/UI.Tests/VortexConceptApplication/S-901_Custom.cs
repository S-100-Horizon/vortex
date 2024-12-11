using S100Framework.DomainModel;
using S100Framework.DomainModel.Bindings;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.Associations.InformationAssociations;
using S100Framework.DomainModel.S101.InformationTypes;
using S100Framework.DomainModel.S122.InformationTypes;
using S100Framework.DomainModel.S201.FeatureTypes;
using S100Framework.WPF.ViewModel.S901;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

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

    public interface IBindingAttribute
    {
        public string Association { get; }
        public string Type { get; }
    }

    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class InformationBindingAttribute<TAssociation, TInformationType> : System.Attribute, IBindingAttribute where TAssociation : InformationAssociation where TInformationType : InformationTypeBase
    {
        public InformationBindingAttribute() {

        }

        public string Association => typeof(TAssociation).Name;

        public string Type => typeof(TInformationType).Name;
    }

    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class FeatureBindingAttribute<T> : System.Attribute where T : FeatureAssociation
    {
        public FeatureBindingAttribute() {

        }
    }
}

namespace S100Framework.WPF.ViewModel.S901
{
    public class informationBindingViewModel2 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T backingFiled, T value, [CallerMemberName] string? propertyName = null) {
            if (string.IsNullOrWhiteSpace(propertyName)) return;

            if (EqualityComparer<T>.Default.Equals(backingFiled, value)) return;
            backingFiled = value;
            OnPropertyChanged(propertyName);
        }

        private string? _linkId;

        [Editor(typeof(Editors.BindingConnectorEditor), typeof(Editors.BindingConnectorEditor))]
        public string? LinkId {
            get {
                return _linkId;
            }

            set {
                SetValue(ref _linkId, value);
            }
        }

        private informationBinding? _informationBinding;

        //[Editor(typeof(Editors.BindingConnectorEditor), typeof(Editors.BindingConnectorEditor))]
        [Browsable(false)]
        public informationBinding? informationBinding {
            get {
                return _informationBinding;
            }

            set {
                SetValue(ref _informationBinding, value);
            }
        }

        [Browsable(false)]
        public string Name => $"{_linkId} {informationBinding?.informationType}";
    }
    public class informationBindingViewModel2<T> : informationBindingViewModel2 where T : new()
    {
        public informationBindingViewModel2() {
            _value = new T();
        }

        private T _value;

        [Editor(typeof(Editors.BindingConnectorEditor), typeof(Editors.BindingConnectorEditor))]
        [ExpandableObject]
        [ReadOnly(true)]
        public T Value {
            get { return _value; }
            set {
                SetValue(ref _value, value);
            }
        }
    }

    public class informationBinding3<T> where T : InformationAssociation, new()
    {
        public string ReferenceId { get; set; } = string.Empty;

        public T Association { get; set; } = new();
    }

    public class informationBinding3ViewModel<T> : INotifyPropertyChanged where T : InformationAssociation, new()
    {
        public informationBinding3ViewModel() {
            Association = new();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T backingFiled, T value, [CallerMemberName] string? propertyName = null) {
            if (string.IsNullOrWhiteSpace(propertyName)) return;

            if (EqualityComparer<T>.Default.Equals(backingFiled, value)) return;
            backingFiled = value;
            OnPropertyChanged(propertyName);
        }

        private string _referenceId;

        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.PropertyOrder(1)]
        public string ReferenceId {
            get {
                return _referenceId;
            }
            set {
                SetValue(ref _referenceId, value);
            }
        }

        private T _association;

        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.PropertyOrder(1000)]
        public T Association {
            get {
                return _association;
            }
            set {
                SetValue(ref _association, value);
            }
        }
    }

    public class TestComposition : InformationAssociation
    {
        public TestComposition() {
        }

        public static Role[] Roles => new[]
        {   Role.theQualityInformation, };

        public string Test1 { get;set; }
        public decimal Test2 { get; set; }
    }

    public partial class QualityOfBathymetricDataViewModel
    {

        //  CUSTOM
        [Category("Development - S901")]
        //[Editor(typeof(Editors.BindingConnectorEditor), typeof(Editors.BindingConnectorEditor))]
        [InformationBinding<DomainModel.S101.Associations.InformationAssociations.QualityOfBathymetricDataComposition, SpatialQuality>()]
        public ObservableCollection<informationBinding3ViewModel<QualityOfBathymetricDataComposition>> theQualityInformationSpatialQuality { get; set; } = new();


        //[Category("Development - S901")]
        //[Editor(typeof(Editors.BindingConnectorEditor), typeof(Editors.BindingConnectorEditor))]
        //[InformationBinding<DomainModel.S101.Associations.InformationAssociations.QualityOfBathymetricDataComposition, SpatialQuality>()]
        //public ObservableCollection<informationBindingViewModel> theQualityInformationSpatialQuality1 { get; set; } = new();

        //[Category("Development - S901")]        
        //[InformationBinding<DomainModel.S101.Associations.InformationAssociations.QualityOfBathymetricDataComposition, SpatialQuality>()]
        //public ObservableCollection<informationBindingViewModel> theQualityInformationSpatialQuality2 { get; set; } = new();

        //[Category("Development S-922")]
        //[Editor(typeof(Editors.BindingConnectorEditor), typeof(Editors.BindingConnectorEditor))]
        //[InformationBinding<DomainModel.S122.Associations.InformationAssociations.PermissionType, Regulations>()]
        //public ObservableCollection<informationBindingViewModel2<DomainModel.S122.Associations.InformationAssociations.PermissionType>> thePermissionType1 { get; set; } = new();

        //[Category("Development S-922")]
        //[InformationBinding<DomainModel.S122.Associations.InformationAssociations.PermissionType, Regulations>()]
        //public ObservableCollection<informationBindingViewModel2<DomainModel.S122.Associations.InformationAssociations.PermissionType>> thePermissionType2 { get; set; } = new();


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

namespace S100Framework.WPF.ViewModel.S922
{
    public partial class VesselTrafficServiceAreaViewModel
    {

        //  CUSTOM
        [Category("Development S-922")]
        [Editor(typeof(Editors.BindingConnectorEditor), typeof(Editors.BindingConnectorEditor))]
        [InformationBinding<DomainModel.S122.Associations.InformationAssociations.PermissionType, Regulations>()]
        public ObservableCollection<informationBindingViewModel> theQualityInformationSpatialQuality1 { get; set; } = new();

        [Category("Development S-922")]
        [InformationBinding<DomainModel.S122.Associations.InformationAssociations.PermissionType, Regulations>()]
        public ObservableCollection<informationBindingViewModel> theQualityInformationSpatialQuality2 { get; set; } = new();


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

    public class QualityOfBathymetricDataCustom : S101.FeatureTypes.QualityOfBathymetricData
    {
        //public Guid? QualityOfBathymetricDataComposition {get;set;}

        //public List<Guid>? QualityOfBathymetricDataCompositionArray { get; set; }
    }
}