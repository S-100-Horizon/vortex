using S100Framework.DomainModel;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.WPF.ViewModel;
using S100Framework.WPF.ViewModel.S101;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace PropertyGridApplication
{
    public class ComplexTestViewModel : ViewModelBase
    {
        private FeatureRefViewModel? _featureRef = default;

        public FeatureRefViewModel? Feature {
            get { return _featureRef; }
            set {
                SetValue(ref _featureRef, value);
            }
        }

        private int? _dummy = default;

        [Description("Dummy value.")]
        public int? dummy {
            get {
                return _dummy;
            }
            set {
                SetValue(ref _dummy, value);
            }
        }

        #region Scaffolding
        public override string Serialize() {
            throw new NotImplementedException();
        }

        protected override void Validate() {            
        }
        #endregion
    }


    public class CustomViewModel : FeatureViewModel<LateralBuoy>
    {
        #region Properties
        private buoyShape? _buoyShape = default;

        [Description("The principal shape and/or design of a buoy.")]
        [Category("LateralBuoy")]
        [PermittedValues([1, 2, 3, 4, 5, 6, 7, 8])]
        [Mandatory]
        public buoyShape? buoyShape {
            get {
                return _buoyShape;
            }
            set {
                SetValue(ref _buoyShape, value);
            }
        }

        private categoryOfLateralMark? _categoryOfLateralMark = default;

        [Description("Classification of lateral marks in the IALA Buoyage System.")]
        [Category("LateralBuoy")]
        [PermittedValues([1, 2, 3, 4])]
        [Mandatory]
        public categoryOfLateralMark? categoryOfLateralMark {
            get {
                return _categoryOfLateralMark;
            }
            set {
                SetValue(ref _categoryOfLateralMark, value);
            }
        }

        [Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
        [Category("LateralBuoy")]
        [PermittedValues([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13])]
        [Multiplicity(1)]
        public ObservableCollection<colour> colour { get; set; } = new();

        private colourPattern? _colourPattern = default;

        [Description("A regular repeated design containing more than one colour.")]
        [Category("LateralBuoy")]
        [PermittedValues([1, 2, 3, 4, 5, 6])]
        [Optional]
        public colourPattern? colourPattern {
            get {
                return _colourPattern;
            }
            set {
                SetValue(ref _colourPattern, value);
            }
        }

        [Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
        [Category("LateralBuoy")]
        [Optional]
        public ObservableCollection<featureNameViewModel> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange = default;

        [Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
        [Category("LateralBuoy")]
        [ExpandableObject]
        [Optional]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }
            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private marksNavigationalSystemOf? _marksNavigationalSystemOf = default;

        [Description("The system of navigational buoyage a region complies with.")]
        [Category("LateralBuoy")]
        [PermittedValues([1, 2, 9, 11])]
        [Optional]
        public marksNavigationalSystemOf? marksNavigationalSystemOf {
            get {
                return _marksNavigationalSystemOf;
            }
            set {
                SetValue(ref _marksNavigationalSystemOf, value);
            }
        }
        #endregion


        public ObservableCollection<ComplexTestViewModel> ComplexList { get; set; } = new();


        #region Scaffolding
        [Category("FeatureBindings")]
        [FeatureBinding("StructureEquipment", "theEquipment", ["Daymark", "DistanceMark", "FogSignal", "LightAllAround", "LightFogDetector", "PhysicalAISAidToNavigation", "RadarTransponderBeacon", "Retroreflector", "SignalStationTraffic", "SignalStationWarning"], lower: 0, upper: 2147483647)]
        public ObservableCollection<FeatureRefViewModel> StructureEquipments { get; set; } = new();

        [Category("FeatureBindings")]
        [FeatureBinding("AidsToNavigationAssociation", "theCollection", ["ArchipelagicSeaLane", "DeepWaterRoute", "FairwaySystem", "TrafficSeparationScheme", "TwoWayRoute"], lower: 0, upper: 1)]
        public ObservableCollection<FeatureRefViewModel> AidsToNavigationAssociations { get; set; } = new();

        public override featureBinding[] GetFeatureBindings() => [
            .. StructureEquipments.Select(e => new featureBinding<S100Framework.DomainModel.S101.FeatureAssociations.StructureEquipment> {
                featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
            .. AidsToNavigationAssociations.Select(e => new featureBinding<S100Framework.DomainModel.S101.FeatureAssociations.AidsToNavigationAssociation> {
                featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
        ];

        [Category("InformationBindings")]
        [InformationBinding("AdditionalInformation", "theInformation", ["ContactDetails", "NauticalInformation"], lower: 0, upper: 1)]
        [InformationBinding("AdditionalInformation", "theOtherRole", ["ServiceHours", "NonStandardWorkingDay"], lower: 0, upper: 1)]
        public ObservableCollection<InformationRefViewModel> AdditionalInformations { get; set; } = new();

        public override informationBinding[] GetInformationBindings() => [
            .. AdditionalInformations.Select(e => new informationBinding<S100Framework.DomainModel.S101.InformationAssociations.AdditionalInformation> {
                informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
        ];

        public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.LateralBuoy.informationBindingDefinitions;
        public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.LateralBuoy.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

        public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.LateralBuoy.featureBindingDefinitions;

        public override string Serialize() {
            throw new NotImplementedException();
        }
        #endregion
    }
}
