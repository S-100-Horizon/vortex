using S100Framework.DomainModel;
using S100Framework.DomainModel.Bindings;
using S100Framework.DomainModel.S101.FeatureTypes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace S100Framework.WPF.ViewModel.S903
{
    public abstract class S100_FC_FeatureAssociation
    {
        public abstract string Code { get; }

        [Browsable(false)]
        public abstract string[] Roles { get; }

        [Browsable(false)]
        public abstract S100_FC_AssociationConnector[] associationConnectors { get; }
    }

    public abstract class S100_FC_AssociationConnector
    {
        public roleType roleType { get; set; }

        public string role { get; set; }

        [Browsable(false)]
        public Type[] AssociationTypes { get; set; } = [];

        [PropertyOrder(1)]
        public int Lower { get; set; } = 0;

        [PropertyOrder(2)]
        public int? Upper { get; set; } = default;

        public abstract Type FeatureType { get; }
    }

    public class S100_FC_AssociationConnector<T> : S100_FC_AssociationConnector where T : FeatureTypeBase
    {
        public override Type FeatureType => typeof(T);

        public string DisplayName => $"{typeof(T).Name}, {base.role}";
    }

    public abstract class S100_FC_FeatureBinding
    {
        [Browsable(false)]
        public Type[] FeatureTypes { get; set; } = [];
    }

    public class S100_FC_FeatureBindingSingle : S100_FC_FeatureBinding
    {
        public string RefId { get; set; } = string.Empty;
    }

    public class S100_FC_FeatureBindingOptional : S100_FC_FeatureBinding
    {
        public string? RefId { get; set; } = default;
    }

    public class S100_FC_FeatureBindingMulti : S100_FC_FeatureBinding
    {
        public List<string> RefIds { get; set; } = new List<string>();
    }


    public sealed class FeatureBindingEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    {
        public FrameworkElement ResolveEditor(PropertyItem propertyItem) {
            var viewModel = (S100_FC_FeatureAssociation)propertyItem.Instance;

            var comboBox = new ComboBox {
                Name = $"_comboBox{Guid.NewGuid():N}",
                DisplayMemberPath = "DisplayName",
            };

            var bindingItemsSourceProperty = new Binding() { Source = viewModel.associationConnectors, Mode = BindingMode.OneWay };
            BindingOperations.SetBinding(comboBox, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

            var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
            BindingOperations.SetBinding(comboBox, ComboBox.SelectedItemProperty, bindingSelectedItemProperty);

            //TODO: Dynamic read value from instance!!!!
            //comboBox.SelectedIndex = 0;
            return comboBox;
        }
    }

    public class IslandAggregation : S100_FC_FeatureAssociation, INotifyPropertyChanged
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

        [PropertyOrder(0)]
        public override string Code => "IslandAggregation";

        public override string[] Roles => ["theCollection", "theComponent"];

        private S100_FC_AssociationConnector? _associationConnector;

        [Editor(typeof(FeatureBindingEditor), typeof(FeatureBindingEditor))]
        [ExpandableObject]
        public S100_FC_AssociationConnector? associationConnector {
            get { return _associationConnector; }
            set {
                this.SetValue(ref _associationConnector, value);

                theCollection = null;
                theComponent = null;

                theComponent = value?.role switch {
                    "theCollection" => new S100_FC_FeatureBindingMulti() {
                        FeatureTypes = value.AssociationTypes,
                    },
                    "theComponent" => new S100_FC_FeatureBindingSingle() {
                        FeatureTypes = [value.FeatureType],
                    },
                    _ => null,
                };

                theCollection = value?.role switch {
                    "theCollection" => new S100_FC_FeatureBindingSingle() {
                        FeatureTypes = [value.FeatureType]
                    },
                    "theComponent" => new S100_FC_FeatureBindingOptional() {
                        FeatureTypes = value.AssociationTypes,
                    },
                    _ => null,
                };
            }
        }

        private S100_FC_FeatureBinding? _theComponent;

        [ExpandableObject]
        public S100_FC_FeatureBinding? theComponent {
            get { return _theComponent; }
            set { this.SetValue(ref _theComponent, value); }
        }

        private S100_FC_FeatureBinding? _theCollection;

        [ExpandableObject]
        public S100_FC_FeatureBinding? theCollection {
            get { return _theCollection; }
            set { this.SetValue(ref _theCollection, value); }
        }

        public override S100_FC_AssociationConnector[] associationConnectors => IslandAggregation._associationConnectors;

        public static S100_FC_AssociationConnector[] _associationConnectors => new S100_FC_AssociationConnector[] {
            new S100_FC_AssociationConnector<LandArea>() {
                roleType = roleType.aggregation,
                role = "theCollection",
                AssociationTypes = [typeof(IslandGroup)],
                Lower = 0,
                Upper = 1,
            },
            new S100_FC_AssociationConnector<IslandGroup>() {
                roleType = roleType.aggregation,
                role = "theCollection",
                AssociationTypes = [typeof(IslandGroup)],
                Lower = 0,
                Upper = 1,
            },
            new S100_FC_AssociationConnector<IslandGroup>() {
                roleType = roleType.association,
                role = "theComponent",
                AssociationTypes = [typeof(LandArea),typeof(IslandGroup)],
                Lower = 0,
                Upper = default,
            },
        };

        public static IslandAggregation TestIslandGroup => new IslandAggregation() {
            //theComponentConnector = _associationConnectors[2],
            //theComponent = new S100_FC_FeatureBindingMulti<LandArea>() {

            //},
            //theCollectionConnector = _associationConnectors[0],
            //theCollection = new S100_FC_FeatureBindingOptional<IslandGroup>() {

            //},
        };

        /*
            <S100FC:featureBinding roleType="association">
                <S100FC:multiplicity>
                    <S100Base:lower>0</S100Base:lower>
                    <S100Base:upper xsi:nil="true" infinite="true" />
                </S100FC:multiplicity>
                <S100FC:association ref="IslandAggregation" />
                <S100FC:role ref="theComponent" />
                <S100FC:featureType ref="LandArea" />
                <S100FC:featureType ref="IslandGroup" />
            </S100FC:featureBinding>
            <S100FC:featureBinding roleType="aggregation">
                <S100FC:multiplicity>
                    <S100Base:lower>0</S100Base:lower>
                    <S100Base:upper xsi:nil="false" infinite="false">1</S100Base:upper>
                </S100FC:multiplicity>
                <S100FC:association ref="IslandAggregation" />
                <S100FC:role ref="theCollection" />
                <S100FC:featureType ref="IslandGroup" />
            </S100FC:featureBinding>
         */
        //public static IslandAggregation TestIslandGroup => new IslandAggregation {
        //    theCollection = new S100_FC_S100_FC_AssociationEndpointOptional {
        //        roleType = roleType.aggregation,
        //        FeatureTypes = [typeof(IslandGroup)],
        //    },

        //    theComponent = new S100_FC_S100_FC_AssociationEndpointMulti(lower: 0) {
        //        roleType = roleType.association,
        //        FeatureTypes = [typeof(LandArea),typeof(IslandGroup)],
        //    },
        //};

        /*
            <S100FC:featureBinding roleType="aggregation">
                <S100FC:multiplicity>
                    <S100Base:lower>0</S100Base:lower>
                    <S100Base:upper xsi:nil="false" infinite="false">1</S100Base:upper>
                </S100FC:multiplicity>
                <S100FC:association ref="IslandAggregation" />
                <S100FC:role ref="theCollection" />
                <S100FC:featureType ref="IslandGroup" />
            </S100FC:featureBinding>
         */
        //public static IslandAggregation TestLandArea => new IslandAggregation {
        //    theCollection = new S100_FC_FeatureBinding {
        //        roleType = roleType.aggregation,
        //        Lower = 0,
        //        Upper = 1,
        //        Role = "theCollection",
        //        FeatureTypes = [typeof(IslandGroup)]
        //    },
        //};

    }

}

/*
    LandArea:
            <S100FC:featureBinding roleType="aggregation">
                <S100FC:multiplicity>
                    <S100Base:lower>0</S100Base:lower>
                    <S100Base:upper xsi:nil="false" infinite="false">1</S100Base:upper>
                </S100FC:multiplicity>
                <S100FC:association ref="IslandAggregation" />
                <S100FC:role ref="theCollection" />
                <S100FC:featureType ref="IslandGroup" />
            </S100FC:featureBinding>


    IslandGroup:
            <S100FC:featureBinding roleType="association">
                <S100FC:multiplicity>
                    <S100Base:lower>0</S100Base:lower>
                    <S100Base:upper xsi:nil="true" infinite="true" />
                </S100FC:multiplicity>
                <S100FC:association ref="IslandAggregation" />
                <S100FC:role ref="theComponent" />
                <S100FC:featureType ref="LandArea" />
                <S100FC:featureType ref="IslandGroup" />
            </S100FC:featureBinding>
            <S100FC:featureBinding roleType="aggregation">
                <S100FC:multiplicity>
                    <S100Base:lower>0</S100Base:lower>
                    <S100Base:upper xsi:nil="false" infinite="false">1</S100Base:upper>
                </S100FC:multiplicity>
                <S100FC:association ref="IslandAggregation" />
                <S100FC:role ref="theCollection" />
                <S100FC:featureType ref="IslandGroup" />
            </S100FC:featureBinding>

 */



/*
    Building:
            <S100FC:featureBinding roleType="aggregation">
                <S100FC:multiplicity>
                    <S100Base:lower>0</S100Base:lower>
                    <S100Base:upper xsi:nil="false" infinite="false">1</S100Base:upper>
                </S100FC:multiplicity>
                <S100FC:association ref="AidsToNavigationAssociation" />
                <S100FC:role ref="theCollection" />
                <S100FC:featureType ref="DeepWaterRoute" />
                <S100FC:featureType ref="FairwaySystem" />
                <S100FC:featureType ref="TrafficSeparationScheme" />
                <S100FC:featureType ref="TwoWayRoute" />
            </S100FC:featureBinding>

    BRIDGE:
            <S100FC:featureBinding roleType="aggregation">
                <S100FC:multiplicity>
                    <S100Base:lower>0</S100Base:lower>
                    <S100Base:upper xsi:nil="false" infinite="false">1</S100Base:upper>
                </S100FC:multiplicity>
                <S100FC:association ref="AidsToNavigationAssociation" />
                <S100FC:role ref="theCollection" />
                <S100FC:featureType ref="FairwaySystem" />
                <S100FC:featureType ref="TrafficSeparationScheme" />
                <S100FC:featureType ref="TwoWayRoute" />
            </S100FC:featureBinding>

 */