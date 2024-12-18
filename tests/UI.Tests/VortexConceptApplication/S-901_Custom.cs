using S100Framework.DomainModel;
using S100Framework.DomainModel.Bindings;
using S100Framework.DomainModel.S101.InformationTypes;
using S100Framework.DomainModel.S122.Associations.InformationAssociations;
using S100Framework.DomainModel.S122.InformationTypes;
using S100Framework.WPF.ViewModel.S901;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

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

        [Editor(typeof(InformationTypeSelector), typeof(InformationTypeSelector))]
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

    public class informationBinding4ViewModel : INotifyPropertyChanged
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

        private additionalInformation _additionalInformation = new additionalInformation();

        public additionalInformation additionalInformation {
            get {
                return _additionalInformation;
            }
            set {
                SetValue(ref _additionalInformation, value);
            }
        }

        public DomainModel.S122.Role Role => DomainModel.S122.Role.providesInformation;

        public Type informationType => typeof(DomainModel.S122.InformationTypes.NauticalInformation);
    }

    /*
            public InformationAssociation? association { get; set; }
            public string? role { get; set; }
            public string? informationType { get; set; }
     */

    public sealed class InformationTypeCollectionEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.CollectionEditor
    {
        /*
                     <xctk:PropertyGrid.EditorDefinitions>
                        <xctk:EditorTemplateDefinition TargetProperties="ReferenceId">
                            <xctk:EditorTemplateDefinition.EditingTemplate>
                                <DataTemplate>
                                    <ComboBox ItemsSource="{Binding Instance.Hello}"/>
                                </DataTemplate>
                            </xctk:EditorTemplateDefinition.EditingTemplate>
                        </xctk:EditorTemplateDefinition>
                    </xctk:PropertyGrid.EditorDefinitions>* 
         */

        public override FrameworkElement ResolveEditor(PropertyItem propertyItem) {
            var editor = (PropertyGridEditorCollectionControl)base.ResolveEditor(propertyItem);

            editor.CollectionUpdated += this.Editor_CollectionUpdated;

            editor.Tag = propertyItem.Instance;

            ((INotifyCollectionChanged)editor.ItemsSource).CollectionChanged += this.InformationTypeCollectionEditor_CollectionChanged;

            return editor;
        }

        protected override void ResolveValueBinding(PropertyItem propertyItem) {
            base.ResolveValueBinding(propertyItem);
        }

        private void InformationTypeCollectionEditor_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
            ;
        }

        private void Editor_CollectionUpdated(object sender, RoutedEventArgs e) {
            ;
        }

        public string[] Hello => new[] {
            "Hello3",
            "Hello4"
        };
    }

    public sealed class InformationTypeSelector : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    {
        //public DomainModel.Bindings.informationBinding[] informationBindingsItems => new DomainModel.Bindings.informationBinding[] {
        //        NAVWARNPart.headerNAVWARNPreamble,
        //    };

        public FrameworkElement ResolveEditor(Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem propertyItem) {
            if (propertyItem.Instance is ViewModelBase) {

                var viewModel = (ViewModelBase)propertyItem.Instance;

                if (viewModel.Host is not null) {
                    var comboBox = new ComboBox {
                        Name = $"_comboBox{Guid.NewGuid():N}",
                        DisplayMemberPath = "Name",
                    };

                    var bindingItemsSourceProperty = new Binding() { Source = viewModel.Host.GetSource(propertyItem), Mode = BindingMode.OneWay };
                    BindingOperations.SetBinding(comboBox, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

                    return comboBox;
                }
            }
            var text = propertyItem.DisplayName;

            var connector = (dynamic)propertyItem.Instance;

            //if (connector.informationBinding is null)
            //    text += " null";
            return new Label {
                Content = text,
                IsEnabled = true,
            };
        }
    }

    public class TestComposition : InformationAssociation
    {
        public TestComposition() {
        }

        public static DomainModel.S101.Role[] Roles => new[]
        {   DomainModel.S101.Role.theQualityInformation, };

        public string Test1 { get; set; }
        public decimal Test2 { get; set; }
    }

    public partial class QualityOfBathymetricDataViewModel
    {
        [Browsable(false)]
        public string[] Hello => new[] {
            "Hello1",
            "Hello2"
        };

        //  CUSTOM
        [Category("Development - S901")]
        [Editor(typeof(InformationTypeCollectionEditor), typeof(InformationTypeCollectionEditor))]
        [InformationBinding<DomainModel.S101.Associations.InformationAssociations.QualityOfBathymetricDataComposition, SpatialQuality>()]
        public ObservableCollection<informationBinding3ViewModel<TestComposition>> theQualityInformationSpatialQuality { get; set; } = new();


        //[Category("Development - S901")]
        //[ExpandableObject]
        //public informationBinding3ViewModel<TestComposition>[] theQualityInformationSpatialQualityArray { get; set; } = new[] {
        //    new informationBinding3ViewModel<TestComposition>(),
        //    new informationBinding3ViewModel<TestComposition>(),
        //    new informationBinding3ViewModel<TestComposition>(),
        //};


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