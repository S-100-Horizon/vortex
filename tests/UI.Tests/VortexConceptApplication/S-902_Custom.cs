using S100Framework.DomainModel;
using S100Framework.DomainModel.Bindings;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace S100Framework.WPF.ViewModel.S902
{
    public class informationBinding
    {
        public string? RefId { get; set; } = default;

        public InformationAssociation? association { get; set; }
        public Type? informationType { get; set; }

        public informationBindingDescriptor? informationBindingDescriptor { get; set; }
    }

    public class S131_FeatureTypeTest : DomainModel.S131.FeatureTypes.FeatureType
    {
        //    public static informationBindingDescriptor[] informationBindings => new informationBindingDescriptor[] {
        //        new informationBindingDescriptor<DomainModel.S131.Associations.InformationAssociations.PermissionType>(roleType.association, 0, int.MaxValue, "permission", [typeof(Applicability),typeof(AbstractRxN)]),
        //        new informationBindingDescriptor<DomainModel.S131.Associations.InformationAssociations.AssociatedRxN>(roleType.association, 0, int.MaxValue, "theRxN", [typeof(AbstractRxN)]),
        //        new informationBindingDescriptor<DomainModel.S131.Associations.InformationAssociations.AdditionalInformation>(roleType.association, 0, int.MaxValue, "providesInformation", [typeof(NauticalInformation)]),
        //    };
    }

    public class informationBindingViewModel : ViewModelBase
    {
        private string? _refId;

        [ExpandableObject]
        public string? RefId {
            get { return _refId; }
            set { base.SetValue(ref _refId, value); }
        }

        private InformationAssociation? _association;

        [ExpandableObject]
        [Editor(typeof(associationEditor), typeof(associationEditor))]
        public InformationAssociation? association {
            get { return _association; }
            set { base.SetValue(ref _association, value); }
        }

        private Type? _informationType;

        [Editor(typeof(informationTypeSelector), typeof(informationTypeSelector))]
        public Type? informationType {
            get { return _informationType; }
            set { base.SetValue(ref _informationType, value); }
        }

        [Browsable(false)]
        public ObservableCollection<Type> informationTypes { get; init; } = new ObservableCollection<Type>();


        private informationBindingDescriptor? _informationBindingDescriptor;

        [Browsable(false)]
        public informationBindingDescriptor? informationBindingDescriptor {
            get { return _informationBindingDescriptor; }
            set {
                base.SetValue(ref (_informationBindingDescriptor), value);
                association = (InformationAssociation?)Activator.CreateInstance(value!.GetType().GenericTypeArguments[0]);
                informationTypes.Clear();
                foreach (var e in value!.informationTypes)
                    informationTypes.Add(e);
            }
        }

        public override string Serialize() {
            throw new NotImplementedException();
        }
    }

    public class S131_FeatureTypeTestViewModel : ViewModelBase
    {
        private informationBindingViewModel _informationBinding1;

        [ExpandableObject]
        public informationBindingViewModel informationBinding {
            get { return _informationBinding1; }
            set { base.SetValue(ref _informationBinding1, value); }
        }

        [Browsable(false)]
        public informationBindingDescriptor[] informationBindingDescriptors => DomainModel.S131.FeatureTypes.FeatureType.informationBindings;

        public void Load(S131_FeatureTypeTest instance) {
            _informationBinding1 = new informationBindingViewModel() {
                //association = new DomainModel.S131.Associations.InformationAssociations.PermissionType(),
                //informationBindingDescriptor = S131_FeatureTypeTest.informationBindingDescriptors[0],
            };
        }

        public override string Serialize() {
            throw new NotImplementedException();
        }
    }



    public sealed class associationEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    {
        public FrameworkElement ResolveEditor(PropertyItem propertyItem) {
            var viewModel = (S131_FeatureTypeTestViewModel)((PropertyItem)propertyItem.ParentElement).Instance;

            var comboBox = new ComboBox {
                Name = $"_comboBox{Guid.NewGuid():N}",
                DisplayMemberPath = "associationName",
            };

            var bindingItemsSourceProperty = new Binding() { Source = viewModel.informationBindingDescriptors, Mode = BindingMode.OneWay };
            BindingOperations.SetBinding(comboBox, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

            var bindingSelectedItemProperty = new Binding("informationBindingDescriptor") { Source = propertyItem.Instance, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
            BindingOperations.SetBinding(comboBox, ComboBox.SelectedItemProperty, bindingSelectedItemProperty);

            return comboBox;
        }
    }

    public sealed class informationTypeSelector : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    {
        public FrameworkElement ResolveEditor(PropertyItem propertyItem) {
            var viewModel = (informationBindingViewModel)propertyItem.Instance;

            var comboBox = new ComboBox {
                Name = $"_comboBox{Guid.NewGuid():N}",
                DisplayMemberPath = "Name",
            };

            var bindingItemsSourceProperty = new Binding() { Source = viewModel.informationTypes, Mode = BindingMode.OneWay };
            BindingOperations.SetBinding(comboBox, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

            var bindingSelectedItemProperty = new Binding("informationType") { Source = propertyItem.Instance, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
            BindingOperations.SetBinding(comboBox, ComboBox.SelectedItemProperty, bindingSelectedItemProperty);

            return comboBox;

        }
    }

}

/*
			<S100FC:informationBinding roleType="association">
				<S100FC:multiplicity>
					<S100Base:lower>0</S100Base:lower>
					<S100Base:upper xsi:nil="true" infinite="true"/>
				</S100FC:multiplicity>
				<S100FC:association ref="AdditionalInformation"/>
				<S100FC:role ref="providesInformation"/>
				<S100FC:informationType ref="NauticalInformation"/>
			</S100FC:informationBinding>
 */