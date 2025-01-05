using S100Framework.DomainModel;
using S100Framework.DomainModel.Bindings;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel.S201.FeatureTypes;
using S100Framework.WPF.Editors;
using S100Framework.WPF.ViewModel.S101;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid;

namespace S100Framework.WPF.ViewModel.S903
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class InformationTypeAttribute : System.Attribute
    {
        private Type _informationType;

        public Type informationType => _informationType;

        public InformationTypeAttribute(Type informationType) {
            _informationType = informationType;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class FeatureTypeAttribute : System.Attribute
    {
        private Type _featureType;

        public Type FeatureType => _featureType;

        public FeatureTypeAttribute(Type featureType) {
            _featureType = featureType;
        }
    }


    public class S101_PileTest : DomainModel.S101.FeatureTypes.Pile
    {
        [FeatureType(typeof(ArchipelagicSeaLane))]
        [FeatureType(typeof(DeepWaterRoute))]
        [FeatureType(typeof(FairwaySystem))]
        [FeatureType(typeof(TrafficSeparationScheme))]
        [FeatureType(typeof(TwoWayRoute))]
        public featureBinding<DomainModel.S101.Associations.FeatureAssociations.AidsToNavigationAssociation>? theCollectionOfAidsToNavigationAssociationTest { get; set; }
    }

    public abstract class FeatureBindingViewModelTest : INotifyPropertyChanged
    {
        private FeatureTypeAttribute[] _featureTypes;

        public FeatureTypeAttribute[] featureTypes => _featureTypes;

        public FeatureBindingViewModelTest(IEnumerable<FeatureTypeAttribute> featureTypes) {
            _featureTypes = featureTypes.ToArray();
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
    }

    public class FeatureBindingViewModelTest<TAssociation> : FeatureBindingViewModelTest where TAssociation : FeatureAssociation, new()
    {
        public FeatureBindingViewModelTest(IEnumerable<FeatureTypeAttribute> featureTypes) : base(featureTypes) {
        }

        private string? _refId;

        [ExpandableObject]
        public string? RefId {
            get { return _refId; }
            set { this.SetValue(ref _refId, value); }
        }

        private TAssociation _association = new TAssociation();

        [ExpandableObject]
        //[Editor(typeof(AssociationEditor), typeof(AssociationEditor))]
        public TAssociation association {
            get { return _association; }
            set { this.SetValue(ref _association, value); }
        }

        private string? _featureType;

        [Editor(typeof(FeatureTypeEditor), typeof(FeatureTypeEditor))]
        public string? featureType {
            get { return _featureType; }
            set { this.SetValue(ref _featureType, value); }
        }
    }

    public class S101_PileTestViewModel : PileViewModel
    {
        //  public informationBinding<Associations.InformationAssociations.AdditionalInformation>? theInformationOfAdditionalInformation { get; set; }

        private FeatureBindingViewModelTest<DomainModel.S101.Associations.FeatureAssociations.AidsToNavigationAssociation> _theCollectionOfAidsToNavigationAssociationTest = new(typeof(S100Framework.WPF.ViewModel.S903.S101_PileTest).GetProperty("theCollectionOfAidsToNavigationAssociationTest")!.GetCustomAttributes<FeatureTypeAttribute>());

        [ExpandableObject]
        public FeatureBindingViewModelTest<DomainModel.S101.Associations.FeatureAssociations.AidsToNavigationAssociation> theCollectionOfAidsToNavigationAssociationTest {
            get { return _theCollectionOfAidsToNavigationAssociationTest; }
            set { base.SetValue(ref _theCollectionOfAidsToNavigationAssociationTest, value); }
        }
    }

    public sealed class FeatureTypeEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    {
        public FrameworkElement ResolveEditor(PropertyItem propertyItem) {
            var viewModel = (FeatureBindingViewModelTest)propertyItem.Instance;

            var comboBox = new ComboBox {
                Name = $"_comboBox{Guid.NewGuid():N}",
                DisplayMemberPath = "Name",
            };

            var bindingItemsSourceProperty = new Binding() { Source = viewModel.featureTypes, Mode = BindingMode.OneWay };
            BindingOperations.SetBinding(comboBox, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

            var bindingSelectedItemProperty = new Binding("informationType") { Source = propertyItem.Instance, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
            BindingOperations.SetBinding(comboBox, ComboBox.SelectedItemProperty, bindingSelectedItemProperty);

            return comboBox;

        }
    }
}
