using S100Framework.DomainModel.S501;
using S100Framework.DomainModel.S501.ComplexAttributes;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

#nullable enable
namespace S100Framework.WPF.ViewModel.S501
{
    internal static class Preamble {
        public static ImmutableDictionary<string, Func<ViewModelBase>> _creators => ImmutableDictionary.Create<string, Func<ViewModelBase>>().AddRange(new Dictionary<string, Func<ViewModelBase>> { { "ReferenceToAPublication", () =>
        {
            return new ReferenceToAPublicationViewModel();
        } }, { "InstallationBuoy", () =>
        {
            return new InstallationBuoyViewModel();
        } }, { "DepthArea", () =>
        {
            return new DepthAreaViewModel();
        } }, { "RadioCallingInPoint", () =>
        {
            return new RadioCallingInPointViewModel();
        } }, { "PatrolArea", () =>
        {
            return new PatrolAreaViewModel();
        } }, { "Checkpoint", () =>
        {
            return new CheckpointViewModel();
        } }, { "MarineManagementArea", () =>
        {
            return new MarineManagementAreaViewModel();
        } }, { "DepthContour", () =>
        {
            return new DepthContourViewModel();
        } }, { "EnvironmentallySensitiveSeaArea", () =>
        {
            return new EnvironmentallySensitiveSeaAreaViewModel();
        } }, { "Road", () =>
        {
            return new RoadViewModel();
        } }, { "River", () =>
        {
            return new RiverViewModel();
        } }, { "MilitaryPracticeArea", () =>
        {
            return new MilitaryPracticeAreaViewModel();
        } }, { "DiscolouredWater", () =>
        {
            return new DiscolouredWaterViewModel();
        } }, { "CardinalBuoy", () =>
        {
            return new CardinalBuoyViewModel();
        } }, { "SafeWaterBuoy", () =>
        {
            return new SafeWaterBuoyViewModel();
        } }, { "RadioStation", () =>
        {
            return new RadioStationViewModel();
        } }, { "MilitaryExerciseAirspace", () =>
        {
            return new MilitaryExerciseAirspaceViewModel();
        } }, { "ContiguousZone", () =>
        {
            return new ContiguousZoneViewModel();
        } }, { "NormalBaseline", () =>
        {
            return new NormalBaselineViewModel();
        } }, { "CableArea", () =>
        {
            return new CableAreaViewModel();
        } }, { "ContinentalShelfArea", () =>
        {
            return new ContinentalShelfAreaViewModel();
        } }, { "InternalWaters", () =>
        {
            return new InternalWatersViewModel();
        } }, { "AdministrationArea", () =>
        {
            return new AdministrationAreaViewModel();
        } }, { "Bollard", () =>
        {
            return new BollardViewModel();
        } }, { "Dolphin", () =>
        {
            return new DolphinViewModel();
        } }, { "RadarRange", () =>
        {
            return new RadarRangeViewModel();
        } }, { "IsolatedDangerBeacon", () =>
        {
            return new IsolatedDangerBeaconViewModel();
        } }, { "IsolatedDangerBuoy", () =>
        {
            return new IsolatedDangerBuoyViewModel();
        } }, { "SubmarineTransitLane", () =>
        {
            return new SubmarineTransitLaneViewModel();
        } }, { "MaritimeSafetyInformationArea", () =>
        {
            return new MaritimeSafetyInformationAreaViewModel();
        } }, { "AirspaceRestriction", () =>
        {
            return new AirspaceRestrictionViewModel();
        } }, { "Sounding", () =>
        {
            return new SoundingViewModel();
        } }, { "TrafficSeparationSchemeBoundary", () =>
        {
            return new TrafficSeparationSchemeBoundaryViewModel();
        } }, { "DumpingGround", () =>
        {
            return new DumpingGroundViewModel();
        } }, { "AirportAirfield", () =>
        {
            return new AirportAirfieldViewModel();
        } }, { "FoulGround", () =>
        {
            return new FoulGroundViewModel();
        } }, { "LightAirObstruction", () =>
        {
            return new LightAirObstructionViewModel();
        } }, { "MooringBuoy", () =>
        {
            return new MooringBuoyViewModel();
        } }, { "UnderwaterAwashRock", () =>
        {
            return new UnderwaterAwashRockViewModel();
        } }, { "CableOverhead", () =>
        {
            return new CableOverheadViewModel();
        } }, { "ControlledAirspace", () =>
        {
            return new ControlledAirspaceViewModel();
        } }, { "Obstruction", () =>
        {
            return new ObstructionViewModel();
        } }, { "FishingGround", () =>
        {
            return new FishingGroundViewModel();
        } }, { "FishingFacility", () =>
        {
            return new FishingFacilityViewModel();
        } }, { "NavigationSystem", () =>
        {
            return new NavigationSystemViewModel();
        } }, { "TrafficSeparationSchemeCrossing", () =>
        {
            return new TrafficSeparationSchemeCrossingViewModel();
        } }, { "TrafficSeparationSchemeLanePart", () =>
        {
            return new TrafficSeparationSchemeLanePartViewModel();
        } }, { "TerritorialSeaArea", () =>
        {
            return new TerritorialSeaAreaViewModel();
        } }, { "LateralBeacon", () =>
        {
            return new LateralBeaconViewModel();
        } }, { "CoastGuardStation", () =>
        {
            return new CoastGuardStationViewModel();
        } }, { "SeparationZoneOrLine", () =>
        {
            return new SeparationZoneOrLineViewModel();
        } }, { "BottomFeature", () =>
        {
            return new BottomFeatureViewModel();
        } }, { "ArchipelagicBaseline", () =>
        {
            return new ArchipelagicBaselineViewModel();
        } }, { "SmallBottomObject", () =>
        {
            return new SmallBottomObjectViewModel();
        } }, { "ExclusiveEconomicZone", () =>
        {
            return new ExclusiveEconomicZoneViewModel();
        } }, { "RadarStation", () =>
        {
            return new RadarStationViewModel();
        } }, { "DivingLocation", () =>
        {
            return new DivingLocationViewModel();
        } }, { "RestrictedArea", () =>
        {
            return new RestrictedAreaViewModel();
        } }, { "CableSubmarine", () =>
        {
            return new CableSubmarineViewModel();
        } }, { "Wreck", () =>
        {
            return new WreckViewModel();
        } }, { "QRoute", () =>
        {
            return new QRouteViewModel();
        } }, { "CompletenessOfProductSpecification", () =>
        {
            return new CompletenessOfProductSpecificationViewModel();
        } }, { "RescueStation", () =>
        {
            return new RescueStationViewModel();
        } }, { "CardinalBeacon", () =>
        {
            return new CardinalBeaconViewModel();
        } }, { "LightVessel", () =>
        {
            return new LightVesselViewModel();
        } }, { "FisheryZone", () =>
        {
            return new FisheryZoneViewModel();
        } }, { "DredgedArea", () =>
        {
            return new DredgedAreaViewModel();
        } }, { "FerryRoute", () =>
        {
            return new FerryRouteViewModel();
        } }, { "ShorelineConstruction", () =>
        {
            return new ShorelineConstructionViewModel();
        } }, { "CautionArea", () =>
        {
            return new CautionAreaViewModel();
        } }, { "DeepWaterRoutePart", () =>
        {
            return new DeepWaterRoutePartViewModel();
        } }, { "CurrentNonGravitational", () =>
        {
            return new CurrentNonGravitationalViewModel();
        } }, { "DataCoverage", () =>
        {
            return new DataCoverageViewModel();
        } }, { "SeabedArea", () =>
        {
            return new SeabedAreaViewModel();
        } }, { "SpecialPurposeGeneralBuoy", () =>
        {
            return new SpecialPurposeGeneralBuoyViewModel();
        } }, { "LightSectored", () =>
        {
            return new LightSectoredViewModel();
        } }, { "IceLine", () =>
        {
            return new IceLineViewModel();
        } }, { "AnchorageArea", () =>
        {
            return new AnchorageAreaViewModel();
        } }, { "LateralBuoy", () =>
        {
            return new LateralBuoyViewModel();
        } }, { "TrafficSeparationSchemeRoundabout", () =>
        {
            return new TrafficSeparationSchemeRoundaboutViewModel();
        } }, { "DeepWaterRouteCentreline", () =>
        {
            return new DeepWaterRouteCentrelineViewModel();
        } }, { "LightFloat", () =>
        {
            return new LightFloatViewModel();
        } }, { "LightAllAround", () =>
        {
            return new LightAllAroundViewModel();
        } }, { "Coastline", () =>
        {
            return new CoastlineViewModel();
        } }, { "SeaAreaNamedWaterArea", () =>
        {
            return new SeaAreaNamedWaterAreaViewModel();
        } }, { "DropZone", () =>
        {
            return new DropZoneViewModel();
        } }, { "Conveyor", () =>
        {
            return new ConveyorViewModel();
        } }, { "LineOfDelimitation", () =>
        {
            return new LineOfDelimitationViewModel();
        } }, { "StraightTerritorialSeaBaseline", () =>
        {
            return new StraightTerritorialSeaBaselineViewModel();
        } }, { "SafeWaterBeacon", () =>
        {
            return new SafeWaterBeaconViewModel();
        } }, { "SpecialPurposeGeneralBeacon", () =>
        {
            return new SpecialPurposeGeneralBeaconViewModel();
        } }, });
    }

    public class Handles : iHandles {
        public static IDictionary<Type, Func<InformationAssociationConnector[]>> AssociationConnectorInformations => new Dictionary<Type, Func<InformationAssociationConnector[]>>
        {
        };
        public static IDictionary<Type, Func<FeatureAssociationConnector[]>> AssociationConnectorFeatures => new Dictionary<Type, Func<FeatureAssociationConnector[]>>
        {
        };
    }

    [CategoryOrder("qRouteChannelWidth", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class qRouteChannelWidthViewModel : ViewModelBase {
        private Decimal _rightQRouteWidth;
        [Category("qRouteChannelWidth")]
        public Decimal rightQRouteWidth {
            get {
                return _rightQRouteWidth;
            }

            set {
                SetValue(ref _rightQRouteWidth, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.qRouteChannelWidth instance) {
            rightQRouteWidth = instance.rightQRouteWidth;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.qRouteChannelWidth
            {
                rightQRouteWidth = this.rightQRouteWidth,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.qRouteChannelWidth Model => new()
        {
            rightQRouteWidth = this._rightQRouteWidth,
        };

        public qRouteChannelWidthViewModel() : base() {
        }

        public override string? ToString() => $"Q-Route Channel Width";
    }

    [CategoryOrder("detectionDateRange", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class detectionDateRangeViewModel : ViewModelBase {
        private DateOnly? _lastDetectionYear = default;
        [Category("detectionDateRange")]
        public DateOnly? lastDetectionYear {
            get {
                return _lastDetectionYear;
            }

            set {
                SetValue(ref _lastDetectionYear, value);
            }
        }

        private DateOnly? _firstDetectionYear = default;
        [Category("detectionDateRange")]
        public DateOnly? firstDetectionYear {
            get {
                return _firstDetectionYear;
            }

            set {
                SetValue(ref _firstDetectionYear, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.detectionDateRange instance) {
            lastDetectionYear = instance.lastDetectionYear;
            firstDetectionYear = instance.firstDetectionYear;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.detectionDateRange
            {
                lastDetectionYear = this.lastDetectionYear,
                firstDetectionYear = this.firstDetectionYear,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.detectionDateRange Model => new()
        {
            lastDetectionYear = this._lastDetectionYear,
            firstDetectionYear = this._firstDetectionYear,
        };

        public detectionDateRangeViewModel() : base() {
        }

        public override string? ToString() => $"Detection Date Range";
    }

    [CategoryOrder("multiplicityOfFeatures", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class multiplicityOfFeaturesViewModel : ViewModelBase {
        private Int32? _numberOfFeatures = default;
        [Category("multiplicityOfFeatures")]
        public Int32? numberOfFeatures {
            get {
                return _numberOfFeatures;
            }

            set {
                SetValue(ref _numberOfFeatures, value);
            }
        }

        private Boolean _multiplicityKnown;
        [Category("multiplicityOfFeatures")]
        public Boolean multiplicityKnown {
            get {
                return _multiplicityKnown;
            }

            set {
                SetValue(ref _multiplicityKnown, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.multiplicityOfFeatures instance) {
            numberOfFeatures = instance.numberOfFeatures;
            multiplicityKnown = instance.multiplicityKnown;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.multiplicityOfFeatures
            {
                numberOfFeatures = this.numberOfFeatures,
                multiplicityKnown = this.multiplicityKnown,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.multiplicityOfFeatures Model => new()
        {
            numberOfFeatures = this._numberOfFeatures,
            multiplicityKnown = this._multiplicityKnown,
        };

        public multiplicityOfFeaturesViewModel() : base() {
        }

        public override string? ToString() => $"Multiplicity of Features";
    }

    [CategoryOrder("onlineResource", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class onlineResourceViewModel : ViewModelBase {
        private String _headline = string.Empty;
        [Category("onlineResource")]
        public String headline {
            get {
                return _headline;
            }

            set {
                SetValue(ref _headline, value);
            }
        }

        private String _linkage = string.Empty;
        [Category("onlineResource")]
        public String linkage {
            get {
                return _linkage;
            }

            set {
                SetValue(ref _linkage, value);
            }
        }

        private String _nameOfResource = string.Empty;
        [Category("onlineResource")]
        public String nameOfResource {
            get {
                return _nameOfResource;
            }

            set {
                SetValue(ref _nameOfResource, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.onlineResource instance) {
            headline = instance.headline;
            linkage = instance.linkage;
            nameOfResource = instance.nameOfResource;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.onlineResource
            {
                headline = this.headline,
                linkage = this.linkage,
                nameOfResource = this.nameOfResource,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.onlineResource Model => new()
        {
            headline = this._headline,
            linkage = this._linkage,
            nameOfResource = this._nameOfResource,
        };

        public onlineResourceViewModel() : base() {
        }

        public override string? ToString() => $"Online Resource";
    }

    [CategoryOrder("featureName", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class featureNameViewModel : ViewModelBase {
        private nameUsage? _nameUsage = default;
        [Category("featureName")]
        public nameUsage? nameUsage {
            get {
                return _nameUsage;
            }

            set {
                SetValue(ref _nameUsage, value);
            }
        }

        private String _name = string.Empty;
        [Category("featureName")]
        public String name {
            get {
                return _name;
            }

            set {
                SetValue(ref _name, value);
            }
        }

        private String _language = string.Empty;
        [Category("featureName")]
        public String language {
            get {
                return _language;
            }

            set {
                SetValue(ref _language, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.featureName instance) {
            nameUsage = instance.nameUsage;
            name = instance.name;
            language = instance.language;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.featureName
            {
                nameUsage = this.nameUsage,
                name = this.name,
                language = this.language,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.featureName Model => new()
        {
            nameUsage = this._nameUsage,
            name = this._name,
            language = this._language,
        };

        public featureNameViewModel() : base() {
        }

        public override string? ToString() => $"Feature Name";
    }

    [CategoryOrder("fixedDateRange", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class fixedDateRangeViewModel : ViewModelBase {
        private DateOnly? _dateStart = default;
        [Category("fixedDateRange")]
        public DateOnly? dateStart {
            get {
                return _dateStart;
            }

            set {
                SetValue(ref _dateStart, value);
            }
        }

        private DateOnly? _dateEnd = default;
        [Category("fixedDateRange")]
        public DateOnly? dateEnd {
            get {
                return _dateEnd;
            }

            set {
                SetValue(ref _dateEnd, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.fixedDateRange instance) {
            dateStart = instance.dateStart;
            dateEnd = instance.dateEnd;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.fixedDateRange
            {
                dateStart = this.dateStart,
                dateEnd = this.dateEnd,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.fixedDateRange Model => new()
        {
            dateStart = this._dateStart,
            dateEnd = this._dateEnd,
        };

        public fixedDateRangeViewModel() : base() {
        }

        public override string? ToString() => $"Fixed Date Range";
    }

    [CategoryOrder("altitudeRange", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class altitudeRangeViewModel : ViewModelBase {
        private Int32 _minimumAltitude;
        [Category("altitudeRange")]
        public Int32 minimumAltitude {
            get {
                return _minimumAltitude;
            }

            set {
                SetValue(ref _minimumAltitude, value);
            }
        }

        private Int32 _maximumAltitude;
        [Category("altitudeRange")]
        public Int32 maximumAltitude {
            get {
                return _maximumAltitude;
            }

            set {
                SetValue(ref _maximumAltitude, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.altitudeRange instance) {
            minimumAltitude = instance.minimumAltitude;
            maximumAltitude = instance.maximumAltitude;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.altitudeRange
            {
                minimumAltitude = this.minimumAltitude,
                maximumAltitude = this.maximumAltitude,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.altitudeRange Model => new()
        {
            minimumAltitude = this._minimumAltitude,
            maximumAltitude = this._maximumAltitude,
        };

        public altitudeRangeViewModel() : base() {
        }

        public override string? ToString() => $"Altitude Range";
    }

#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    [CategoryOrder("altitude", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class altitudeViewModel : ViewModelBase
#pragma warning restore CS8981
    {
        private Int32 _minimumAltitude;
        [Category("altitude")]
        public Int32 minimumAltitude {
            get {
                return _minimumAltitude;
            }

            set {
                SetValue(ref _minimumAltitude, value);
            }
        }

        private Int32 _maximumAltitude;
        [Category("altitude")]
        public Int32 maximumAltitude {
            get {
                return _maximumAltitude;
            }

            set {
                SetValue(ref _maximumAltitude, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.altitude instance) {
            minimumAltitude = instance.minimumAltitude;
            maximumAltitude = instance.maximumAltitude;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.altitude
            {
                minimumAltitude = this.minimumAltitude,
                maximumAltitude = this.maximumAltitude,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.altitude Model => new()
        {
            minimumAltitude = this._minimumAltitude,
            maximumAltitude = this._maximumAltitude,
        };

        public altitudeViewModel() : base() {
        }

        public override string? ToString() => $"Altitude";
    }

    [CategoryOrder("lastSourceInformation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class lastSourceInformationViewModel : ViewModelBase {
        private lastSensor? _lastSensor = default;
        [Category("lastSourceInformation")]
        public lastSensor? lastSensor {
            get {
                return _lastSensor;
            }

            set {
                SetValue(ref _lastSensor, value);
            }
        }

        private String _lastSource = string.Empty;
        [Category("lastSourceInformation")]
        public String lastSource {
            get {
                return _lastSource;
            }

            set {
                SetValue(ref _lastSource, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("lastSourceInformation")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.lastSourceInformation instance) {
            lastSensor = instance.lastSensor;
            lastSource = instance.lastSource;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.lastSourceInformation
            {
                lastSensor = this.lastSensor,
                lastSource = this.lastSource,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.lastSourceInformation Model => new()
        {
            lastSensor = this._lastSensor,
            lastSource = this._lastSource,
            reportedDate = this._reportedDate,
        };

        public lastSourceInformationViewModel() : base() {
        }

        public override string? ToString() => $"Last Source Information";
    }

#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    [CategoryOrder("information", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class informationViewModel : ViewModelBase
#pragma warning restore CS8981
    {
        private String _headline = string.Empty;
        [Category("information")]
        public String headline {
            get {
                return _headline;
            }

            set {
                SetValue(ref _headline, value);
            }
        }

        private String _language = string.Empty;
        [Category("information")]
        public String language {
            get {
                return _language;
            }

            set {
                SetValue(ref _language, value);
            }
        }

        private String _fileLocator = string.Empty;
        [Category("information")]
        public String fileLocator {
            get {
                return _fileLocator;
            }

            set {
                SetValue(ref _fileLocator, value);
            }
        }

        private String _text = string.Empty;
        [Category("information")]
        public String text {
            get {
                return _text;
            }

            set {
                SetValue(ref _text, value);
            }
        }

        private String _fileReference = string.Empty;
        [Category("information")]
        public String fileReference {
            get {
                return _fileReference;
            }

            set {
                SetValue(ref _fileReference, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.information instance) {
            headline = instance.headline;
            language = instance.language;
            fileLocator = instance.fileLocator;
            text = instance.text;
            fileReference = instance.fileReference;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.information
            {
                headline = this.headline,
                language = this.language,
                fileLocator = this.fileLocator,
                text = this.text,
                fileReference = this.fileReference,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.information Model => new()
        {
            headline = this._headline,
            language = this._language,
            fileLocator = this._fileLocator,
            text = this._text,
            fileReference = this._fileReference,
        };

        public informationViewModel() : base() {
        }

        public override string? ToString() => $"Information";
    }

    [CategoryOrder("firstSourceInformation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class firstSourceInformationViewModel : ViewModelBase {
        private firstSensor _firstSensor;
        [Category("firstSourceInformation")]
        public firstSensor firstSensor {
            get {
                return _firstSensor;
            }

            set {
                SetValue(ref _firstSensor, value);
            }
        }

        private String _firstSource = string.Empty;
        [Category("firstSourceInformation")]
        public String firstSource {
            get {
                return _firstSource;
            }

            set {
                SetValue(ref _firstSource, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("firstSourceInformation")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.firstSourceInformation instance) {
            firstSensor = instance.firstSensor;
            firstSource = instance.firstSource;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.firstSourceInformation
            {
                firstSensor = this.firstSensor,
                firstSource = this.firstSource,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.firstSourceInformation Model => new()
        {
            firstSensor = this._firstSensor,
            firstSource = this._firstSource,
            reportedDate = this._reportedDate,
        };

        public firstSourceInformationViewModel() : base() {
        }

        public override string? ToString() => $"First Source Information";
    }

    [CategoryOrder("horizontalClearanceFixed", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class horizontalClearanceFixedViewModel : ViewModelBase {
        private Decimal _horizontalClearanceValue;
        [Category("horizontalClearanceFixed")]
        public Decimal horizontalClearanceValue {
            get {
                return _horizontalClearanceValue;
            }

            set {
                SetValue(ref _horizontalClearanceValue, value);
            }
        }

        private Decimal? _horizontalDistanceUncertainty = default;
        [Category("horizontalClearanceFixed")]
        public Decimal? horizontalDistanceUncertainty {
            get {
                return _horizontalDistanceUncertainty;
            }

            set {
                SetValue(ref _horizontalDistanceUncertainty, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.horizontalClearanceFixed instance) {
            horizontalClearanceValue = instance.horizontalClearanceValue;
            horizontalDistanceUncertainty = instance.horizontalDistanceUncertainty;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.horizontalClearanceFixed
            {
                horizontalClearanceValue = this.horizontalClearanceValue,
                horizontalDistanceUncertainty = this.horizontalDistanceUncertainty,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.horizontalClearanceFixed Model => new()
        {
            horizontalClearanceValue = this._horizontalClearanceValue,
            horizontalDistanceUncertainty = this._horizontalDistanceUncertainty,
        };

        public horizontalClearanceFixedViewModel() : base() {
        }

        public override string? ToString() => $"Horizontal Clearance Fixed";
    }

    [CategoryOrder("verticalUncertainty", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class verticalUncertaintyViewModel : ViewModelBase {
        private Decimal? _uncertaintyVariableFactor = default;
        [Category("verticalUncertainty")]
        public Decimal? uncertaintyVariableFactor {
            get {
                return _uncertaintyVariableFactor;
            }

            set {
                SetValue(ref _uncertaintyVariableFactor, value);
            }
        }

        private Decimal _uncertaintyFixed;
        [Category("verticalUncertainty")]
        public Decimal uncertaintyFixed {
            get {
                return _uncertaintyFixed;
            }

            set {
                SetValue(ref _uncertaintyFixed, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.verticalUncertainty instance) {
            uncertaintyVariableFactor = instance.uncertaintyVariableFactor;
            uncertaintyFixed = instance.uncertaintyFixed;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.verticalUncertainty
            {
                uncertaintyVariableFactor = this.uncertaintyVariableFactor,
                uncertaintyFixed = this.uncertaintyFixed,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.verticalUncertainty Model => new()
        {
            uncertaintyVariableFactor = this._uncertaintyVariableFactor,
            uncertaintyFixed = this._uncertaintyFixed,
        };

        public verticalUncertaintyViewModel() : base() {
        }

        public override string? ToString() => $"Vertical Uncertainty";
    }

    [CategoryOrder("frequencyPair", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class frequencyPairViewModel : ViewModelBase {
        private Int32? _frequencyShoreStationReceives = default;
        [Category("frequencyPair")]
        public Int32? frequencyShoreStationReceives {
            get {
                return _frequencyShoreStationReceives;
            }

            set {
                SetValue(ref _frequencyShoreStationReceives, value);
            }
        }

        private Int32 _frequencyShoreStationTransmits;
        [Category("frequencyPair")]
        public Int32 frequencyShoreStationTransmits {
            get {
                return _frequencyShoreStationTransmits;
            }

            set {
                SetValue(ref _frequencyShoreStationTransmits, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.frequencyPair instance) {
            frequencyShoreStationReceives = instance.frequencyShoreStationReceives;
            frequencyShoreStationTransmits = instance.frequencyShoreStationTransmits;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.frequencyPair
            {
                frequencyShoreStationReceives = this.frequencyShoreStationReceives,
                frequencyShoreStationTransmits = this.frequencyShoreStationTransmits,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.frequencyPair Model => new()
        {
            frequencyShoreStationReceives = this._frequencyShoreStationReceives,
            frequencyShoreStationTransmits = this._frequencyShoreStationTransmits,
        };

        public frequencyPairViewModel() : base() {
        }

        public override string? ToString() => $"Frequency Pair";
    }

    [CategoryOrder("vesselMeasurementsSpecification", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class vesselMeasurementsSpecificationViewModel : ViewModelBase {
        private Decimal _vesselsCharacteristicsValue;
        [Category("vesselMeasurementsSpecification")]
        public Decimal vesselsCharacteristicsValue {
            get {
                return _vesselsCharacteristicsValue;
            }

            set {
                SetValue(ref _vesselsCharacteristicsValue, value);
            }
        }

        private vesselsCharacteristics _vesselsCharacteristics;
        [Category("vesselMeasurementsSpecification")]
        public vesselsCharacteristics vesselsCharacteristics {
            get {
                return _vesselsCharacteristics;
            }

            set {
                SetValue(ref _vesselsCharacteristics, value);
            }
        }

        private vesselsCharacteristicsUnit _vesselsCharacteristicsUnit;
        [Category("vesselMeasurementsSpecification")]
        public vesselsCharacteristicsUnit vesselsCharacteristicsUnit {
            get {
                return _vesselsCharacteristicsUnit;
            }

            set {
                SetValue(ref _vesselsCharacteristicsUnit, value);
            }
        }

        private comparisonOperator? _comparisonOperator = default;
        [Category("vesselMeasurementsSpecification")]
        public comparisonOperator? comparisonOperator {
            get {
                return _comparisonOperator;
            }

            set {
                SetValue(ref _comparisonOperator, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.vesselMeasurementsSpecification instance) {
            vesselsCharacteristicsValue = instance.vesselsCharacteristicsValue;
            vesselsCharacteristics = instance.vesselsCharacteristics;
            vesselsCharacteristicsUnit = instance.vesselsCharacteristicsUnit;
            comparisonOperator = instance.comparisonOperator;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.vesselMeasurementsSpecification
            {
                vesselsCharacteristicsValue = this.vesselsCharacteristicsValue,
                vesselsCharacteristics = this.vesselsCharacteristics,
                vesselsCharacteristicsUnit = this.vesselsCharacteristicsUnit,
                comparisonOperator = this.comparisonOperator,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.vesselMeasurementsSpecification Model => new()
        {
            vesselsCharacteristicsValue = this._vesselsCharacteristicsValue,
            vesselsCharacteristics = this._vesselsCharacteristics,
            vesselsCharacteristicsUnit = this._vesselsCharacteristicsUnit,
            comparisonOperator = this._comparisonOperator,
        };

        public vesselMeasurementsSpecificationViewModel() : base() {
        }

        public override string? ToString() => $"Vessel Measurements Specification";
    }

    [CategoryOrder("surfaceCharacteristics", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class surfaceCharacteristicsViewModel : ViewModelBase {
        private Int32? _underlyingLayer = default;
        [Category("surfaceCharacteristics")]
        public Int32? underlyingLayer {
            get {
                return _underlyingLayer;
            }

            set {
                SetValue(ref _underlyingLayer, value);
            }
        }

        [Category("surfaceCharacteristics")]
        public ObservableCollection<natureOfSurfaceQualifyingTerms> natureOfSurfaceQualifyingTerms { get; set; } = new();

        private natureOfSurface? _natureOfSurface = default;
        [Category("surfaceCharacteristics")]
        public natureOfSurface? natureOfSurface {
            get {
                return _natureOfSurface;
            }

            set {
                SetValue(ref _natureOfSurface, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.surfaceCharacteristics instance) {
            underlyingLayer = instance.underlyingLayer;
            natureOfSurfaceQualifyingTerms.Clear();
            if (instance.natureOfSurfaceQualifyingTerms is not null)
                foreach (var e in instance.natureOfSurfaceQualifyingTerms)
                    natureOfSurfaceQualifyingTerms.Add(e);
            natureOfSurface = instance.natureOfSurface;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.surfaceCharacteristics
            {
                underlyingLayer = this.underlyingLayer,
                natureOfSurfaceQualifyingTerms = this.natureOfSurfaceQualifyingTerms.ToList(),
                natureOfSurface = this.natureOfSurface,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.surfaceCharacteristics Model => new()
        {
            underlyingLayer = this._underlyingLayer,
            natureOfSurfaceQualifyingTerms = this.natureOfSurfaceQualifyingTerms.ToList(),
            natureOfSurface = this._natureOfSurface,
        };

        public surfaceCharacteristicsViewModel() : base() {
            natureOfSurfaceQualifyingTerms.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(natureOfSurfaceQualifyingTerms));
            };
        }

        public override string? ToString() => $"Surface Characteristics";
    }

    [CategoryOrder("magneticInformation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class magneticInformationViewModel : ViewModelBase {
        private strengthOfMagneticAnomaly? _strengthOfMagneticAnomaly = default;
        [Category("magneticInformation")]
        public strengthOfMagneticAnomaly? strengthOfMagneticAnomaly {
            get {
                return _strengthOfMagneticAnomaly;
            }

            set {
                SetValue(ref _strengthOfMagneticAnomaly, value);
            }
        }

        private Int32? _magneticIntensity = default;
        [Category("magneticInformation")]
        public Int32? magneticIntensity {
            get {
                return _magneticIntensity;
            }

            set {
                SetValue(ref _magneticIntensity, value);
            }
        }

        private magneticAnomalyDetectorSignature _magneticAnomalyDetectorSignature;
        [Category("magneticInformation")]
        public magneticAnomalyDetectorSignature magneticAnomalyDetectorSignature {
            get {
                return _magneticAnomalyDetectorSignature;
            }

            set {
                SetValue(ref _magneticAnomalyDetectorSignature, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.magneticInformation instance) {
            strengthOfMagneticAnomaly = instance.strengthOfMagneticAnomaly;
            magneticIntensity = instance.magneticIntensity;
            magneticAnomalyDetectorSignature = instance.magneticAnomalyDetectorSignature;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.magneticInformation
            {
                strengthOfMagneticAnomaly = this.strengthOfMagneticAnomaly,
                magneticIntensity = this.magneticIntensity,
                magneticAnomalyDetectorSignature = this.magneticAnomalyDetectorSignature,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.magneticInformation Model => new()
        {
            strengthOfMagneticAnomaly = this._strengthOfMagneticAnomaly,
            magneticIntensity = this._magneticIntensity,
            magneticAnomalyDetectorSignature = this._magneticAnomalyDetectorSignature,
        };

        public magneticInformationViewModel() : base() {
        }

        public override string? ToString() => $"Magnetic Information";
    }

#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    [CategoryOrder("speed", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class speedViewModel : ViewModelBase
#pragma warning restore CS8981
    {
        private Decimal? _speedMinimum = default;
        [Category("speed")]
        public Decimal? speedMinimum {
            get {
                return _speedMinimum;
            }

            set {
                SetValue(ref _speedMinimum, value);
            }
        }

        private Decimal _speedMaximum;
        [Category("speed")]
        public Decimal speedMaximum {
            get {
                return _speedMaximum;
            }

            set {
                SetValue(ref _speedMaximum, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.speed instance) {
            speedMinimum = instance.speedMinimum;
            speedMaximum = instance.speedMaximum;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.speed
            {
                speedMinimum = this.speedMinimum,
                speedMaximum = this.speedMaximum,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.speed Model => new()
        {
            speedMinimum = this._speedMinimum,
            speedMaximum = this._speedMaximum,
        };

        public speedViewModel() : base() {
        }

        public override string? ToString() => $"Speed";
    }

    [CategoryOrder("verticalClearanceFixed", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class verticalClearanceFixedViewModel : ViewModelBase {
        private verticalUncertaintyViewModel? _verticalUncertainty;
        [Category("verticalClearanceFixed")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public verticalUncertaintyViewModel? verticalUncertainty {
            get {
                return _verticalUncertainty;
            }

            set {
                SetValue(ref _verticalUncertainty, value);
            }
        }

        private Decimal _verticalClearanceValue;
        [Category("verticalClearanceFixed")]
        public Decimal verticalClearanceValue {
            get {
                return _verticalClearanceValue;
            }

            set {
                SetValue(ref _verticalClearanceValue, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.verticalClearanceFixed instance) {
            verticalUncertainty = new();
            if (instance.verticalUncertainty != null) {
                verticalUncertainty = new();
                verticalUncertainty.Load(instance.verticalUncertainty);
            }

            verticalClearanceValue = instance.verticalClearanceValue;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.verticalClearanceFixed
            {
                verticalUncertainty = this.verticalUncertainty?.Model,
                verticalClearanceValue = this.verticalClearanceValue,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.verticalClearanceFixed Model => new()
        {
            verticalUncertainty = this._verticalUncertainty?.Model,
            verticalClearanceValue = this._verticalClearanceValue,
        };

        public verticalClearanceFixedViewModel() : base() {
        }

        public override string? ToString() => $"Vertical Clearance Fixed";
    }

    [CategoryOrder("sourceIdentification", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class sourceIdentificationViewModel : ViewModelBase {
        private String _producerNation = string.Empty;
        [Category("sourceIdentification")]
        public String producerNation {
            get {
                return _producerNation;
            }

            set {
                SetValue(ref _producerNation, value);
            }
        }

        private String _sourceType = string.Empty;
        [Category("sourceIdentification")]
        public String sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private String _productionAgency = string.Empty;
        [Category("sourceIdentification")]
        public String productionAgency {
            get {
                return _productionAgency;
            }

            set {
                SetValue(ref _productionAgency, value);
            }
        }

        private String _sourceID = string.Empty;
        [Category("sourceIdentification")]
        public String sourceID {
            get {
                return _sourceID;
            }

            set {
                SetValue(ref _sourceID, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.sourceIdentification instance) {
            producerNation = instance.producerNation;
            sourceType = instance.sourceType;
            productionAgency = instance.productionAgency;
            sourceID = instance.sourceID;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.sourceIdentification
            {
                producerNation = this.producerNation,
                sourceType = this.sourceType,
                productionAgency = this.productionAgency,
                sourceID = this.sourceID,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.sourceIdentification Model => new()
        {
            producerNation = this._producerNation,
            sourceType = this._sourceType,
            productionAgency = this._productionAgency,
            sourceID = this._sourceID,
        };

        public sourceIdentificationViewModel() : base() {
        }

        public override string? ToString() => $"Source Identification";
    }

    [CategoryOrder("horizontalPositionUncertainty", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class horizontalPositionUncertaintyViewModel : ViewModelBase {
        private Decimal _uncertaintyFixed;
        [Category("horizontalPositionUncertainty")]
        public Decimal uncertaintyFixed {
            get {
                return _uncertaintyFixed;
            }

            set {
                SetValue(ref _uncertaintyFixed, value);
            }
        }

        private Decimal? _uncertaintyVariableFactor = default;
        [Category("horizontalPositionUncertainty")]
        public Decimal? uncertaintyVariableFactor {
            get {
                return _uncertaintyVariableFactor;
            }

            set {
                SetValue(ref _uncertaintyVariableFactor, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.horizontalPositionUncertainty instance) {
            uncertaintyFixed = instance.uncertaintyFixed;
            uncertaintyVariableFactor = instance.uncertaintyVariableFactor;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.horizontalPositionUncertainty
            {
                uncertaintyFixed = this.uncertaintyFixed,
                uncertaintyVariableFactor = this.uncertaintyVariableFactor,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.horizontalPositionUncertainty Model => new()
        {
            uncertaintyFixed = this._uncertaintyFixed,
            uncertaintyVariableFactor = this._uncertaintyVariableFactor,
        };

        public horizontalPositionUncertaintyViewModel() : base() {
        }

        public override string? ToString() => $"Horizontal Position Uncertainty";
    }

#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    [CategoryOrder("orientation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class orientationViewModel : ViewModelBase
#pragma warning restore CS8981
    {
        private Decimal _orientationValue;
        [Category("orientation")]
        public Decimal orientationValue {
            get {
                return _orientationValue;
            }

            set {
                SetValue(ref _orientationValue, value);
            }
        }

        private Decimal? _orientationUncertainty = default;
        [Category("orientation")]
        public Decimal? orientationUncertainty {
            get {
                return _orientationUncertainty;
            }

            set {
                SetValue(ref _orientationUncertainty, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.orientation instance) {
            orientationValue = instance.orientationValue;
            orientationUncertainty = instance.orientationUncertainty;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.orientation
            {
                orientationValue = this.orientationValue,
                orientationUncertainty = this.orientationUncertainty,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.orientation Model => new()
        {
            orientationValue = this._orientationValue,
            orientationUncertainty = this._orientationUncertainty,
        };

        public orientationViewModel() : base() {
        }

        public override string? ToString() => $"Orientation";
    }

    [CategoryOrder("directionHeading", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class directionHeadingViewModel : ViewModelBase {
        private Decimal _headingDownBearing;
        [Category("directionHeading")]
        public Decimal headingDownBearing {
            get {
                return _headingDownBearing;
            }

            set {
                SetValue(ref _headingDownBearing, value);
            }
        }

        private Decimal _headingUpBearing;
        [Category("directionHeading")]
        public Decimal headingUpBearing {
            get {
                return _headingUpBearing;
            }

            set {
                SetValue(ref _headingUpBearing, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.directionHeading instance) {
            headingDownBearing = instance.headingDownBearing;
            headingUpBearing = instance.headingUpBearing;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.directionHeading
            {
                headingDownBearing = this.headingDownBearing,
                headingUpBearing = this.headingUpBearing,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.directionHeading Model => new()
        {
            headingDownBearing = this._headingDownBearing,
            headingUpBearing = this._headingUpBearing,
        };

        public directionHeadingViewModel() : base() {
        }

        public override string? ToString() => $"Direction Heading";
    }

    [CategoryOrder("flightLevel", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class flightLevelViewModel : ViewModelBase {
        private Int32 _minimumFlightLevel;
        [Category("flightLevel")]
        public Int32 minimumFlightLevel {
            get {
                return _minimumFlightLevel;
            }

            set {
                SetValue(ref _minimumFlightLevel, value);
            }
        }

        private Int32 _maximumFlightLevel;
        [Category("flightLevel")]
        public Int32 maximumFlightLevel {
            get {
                return _maximumFlightLevel;
            }

            set {
                SetValue(ref _maximumFlightLevel, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.flightLevel instance) {
            minimumFlightLevel = instance.minimumFlightLevel;
            maximumFlightLevel = instance.maximumFlightLevel;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.flightLevel
            {
                minimumFlightLevel = this.minimumFlightLevel,
                maximumFlightLevel = this.maximumFlightLevel,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.flightLevel Model => new()
        {
            minimumFlightLevel = this._minimumFlightLevel,
            maximumFlightLevel = this._maximumFlightLevel,
        };

        public flightLevelViewModel() : base() {
        }

        public override string? ToString() => $"Flight Level ";
    }

    [CategoryOrder("vesselSpeedLimit", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class vesselSpeedLimitViewModel : ViewModelBase {
        private speedUnits _speedUnits;
        [Category("vesselSpeedLimit")]
        public speedUnits speedUnits {
            get {
                return _speedUnits;
            }

            set {
                SetValue(ref _speedUnits, value);
            }
        }

        private String _vesselClass = string.Empty;
        [Category("vesselSpeedLimit")]
        public String vesselClass {
            get {
                return _vesselClass;
            }

            set {
                SetValue(ref _vesselClass, value);
            }
        }

        private Decimal _speedLimit;
        [Category("vesselSpeedLimit")]
        public Decimal speedLimit {
            get {
                return _speedLimit;
            }

            set {
                SetValue(ref _speedLimit, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.vesselSpeedLimit instance) {
            speedUnits = instance.speedUnits;
            vesselClass = instance.vesselClass;
            speedLimit = instance.speedLimit;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.vesselSpeedLimit
            {
                speedUnits = this.speedUnits,
                vesselClass = this.vesselClass,
                speedLimit = this.speedLimit,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.vesselSpeedLimit Model => new()
        {
            speedUnits = this._speedUnits,
            vesselClass = this._vesselClass,
            speedLimit = this._speedLimit,
        };

        public vesselSpeedLimitViewModel() : base() {
        }

        public override string? ToString() => $"Vessel Speed Limit";
    }

    [CategoryOrder("periodicDateRange", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class periodicDateRangeViewModel : ViewModelBase {
        private DateOnly _dateStart;
        [Category("periodicDateRange")]
        public DateOnly dateStart {
            get {
                return _dateStart;
            }

            set {
                SetValue(ref _dateStart, value);
            }
        }

        private DateOnly _dateEnd;
        [Category("periodicDateRange")]
        public DateOnly dateEnd {
            get {
                return _dateEnd;
            }

            set {
                SetValue(ref _dateEnd, value);
            }
        }

        private DateOnly _periodicDateEnd;
        [Category("periodicDateRange")]
        public DateOnly periodicDateEnd {
            get {
                return _periodicDateEnd;
            }

            set {
                SetValue(ref _periodicDateEnd, value);
            }
        }

        private DateOnly _periodicDateStart;
        [Category("periodicDateRange")]
        public DateOnly periodicDateStart {
            get {
                return _periodicDateStart;
            }

            set {
                SetValue(ref _periodicDateStart, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.periodicDateRange instance) {
            dateStart = instance.dateStart;
            dateEnd = instance.dateEnd;
            periodicDateEnd = instance.periodicDateEnd;
            periodicDateStart = instance.periodicDateStart;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.periodicDateRange
            {
                dateStart = this.dateStart,
                dateEnd = this.dateEnd,
                periodicDateEnd = this.periodicDateEnd,
                periodicDateStart = this.periodicDateStart,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.periodicDateRange Model => new()
        {
            dateStart = this._dateStart,
            dateEnd = this._dateEnd,
            periodicDateEnd = this._periodicDateEnd,
            periodicDateStart = this._periodicDateStart,
        };

        public periodicDateRangeViewModel() : base() {
        }

        public override string? ToString() => $"Periodic Date Range";
    }

    [CategoryOrder("shapeInformation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class shapeInformationViewModel : ViewModelBase {
        private String _text = string.Empty;
        [Category("shapeInformation")]
        public String text {
            get {
                return _text;
            }

            set {
                SetValue(ref _text, value);
            }
        }

        private String _language = string.Empty;
        [Category("shapeInformation")]
        public String language {
            get {
                return _language;
            }

            set {
                SetValue(ref _language, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.shapeInformation instance) {
            text = instance.text;
            language = instance.language;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.shapeInformation
            {
                text = this.text,
                language = this.language,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.shapeInformation Model => new()
        {
            text = this._text,
            language = this._language,
        };

        public shapeInformationViewModel() : base() {
        }

        public override string? ToString() => $"Shape Information";
    }

    [CategoryOrder("signalSequence", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class signalSequenceViewModel : ViewModelBase {
        private signalStatus _signalStatus;
        [Category("signalSequence")]
        public signalStatus signalStatus {
            get {
                return _signalStatus;
            }

            set {
                SetValue(ref _signalStatus, value);
            }
        }

        private Decimal _signalDuration;
        [Category("signalSequence")]
        public Decimal signalDuration {
            get {
                return _signalDuration;
            }

            set {
                SetValue(ref _signalDuration, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.signalSequence instance) {
            signalStatus = instance.signalStatus;
            signalDuration = instance.signalDuration;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.signalSequence
            {
                signalStatus = this.signalStatus,
                signalDuration = this.signalDuration,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.signalSequence Model => new()
        {
            signalStatus = this._signalStatus,
            signalDuration = this._signalDuration,
        };

        public signalSequenceViewModel() : base() {
        }

        public override string? ToString() => $"Signal Sequence";
    }

    [CategoryOrder("sectorInformation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class sectorInformationViewModel : ViewModelBase {
        private String _text = string.Empty;
        [Category("sectorInformation")]
        public String text {
            get {
                return _text;
            }

            set {
                SetValue(ref _text, value);
            }
        }

        private String _language = string.Empty;
        [Category("sectorInformation")]
        public String language {
            get {
                return _language;
            }

            set {
                SetValue(ref _language, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.sectorInformation instance) {
            text = instance.text;
            language = instance.language;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.sectorInformation
            {
                text = this.text,
                language = this.language,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.sectorInformation Model => new()
        {
            text = this._text,
            language = this._language,
        };

        public sectorInformationViewModel() : base() {
        }

        public override string? ToString() => $"Sector Information";
    }

    [CategoryOrder("directionalCharacter", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class directionalCharacterViewModel : ViewModelBase {
        private orientationViewModel _orientation;
        [Category("directionalCharacter")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public orientationViewModel orientation {
            get {
                return _orientation;
            }

            set {
                SetValue(ref _orientation, value);
            }
        }

        private Boolean? _moireEffect = default;
        [Category("directionalCharacter")]
        public Boolean? moireEffect {
            get {
                return _moireEffect;
            }

            set {
                SetValue(ref _moireEffect, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.directionalCharacter instance) {
            orientation = new();
            if (instance.orientation != null) {
                orientation = new();
                orientation.Load(instance.orientation);
            }

            moireEffect = instance.moireEffect;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.directionalCharacter
            {
                orientation = this.orientation?.Model,
                moireEffect = this.moireEffect,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.directionalCharacter Model => new()
        {
            orientation = this._orientation?.Model,
            moireEffect = this._moireEffect,
        };

        public directionalCharacterViewModel() : base() {
        }

        public override string? ToString() => $"Directional Character";
    }

    [CategoryOrder("sectorLimitTwo", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class sectorLimitTwoViewModel : ViewModelBase {
        private Decimal? _sectorLineLength = default;
        [Category("sectorLimitTwo")]
        public Decimal? sectorLineLength {
            get {
                return _sectorLineLength;
            }

            set {
                SetValue(ref _sectorLineLength, value);
            }
        }

        private Decimal _sectorBearing;
        [Category("sectorLimitTwo")]
        public Decimal sectorBearing {
            get {
                return _sectorBearing;
            }

            set {
                SetValue(ref _sectorBearing, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.sectorLimitTwo instance) {
            sectorLineLength = instance.sectorLineLength;
            sectorBearing = instance.sectorBearing;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.sectorLimitTwo
            {
                sectorLineLength = this.sectorLineLength,
                sectorBearing = this.sectorBearing,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.sectorLimitTwo Model => new()
        {
            sectorLineLength = this._sectorLineLength,
            sectorBearing = this._sectorBearing,
        };

        public sectorLimitTwoViewModel() : base() {
        }

        public override string? ToString() => $"Sector Limit Two";
    }

    [CategoryOrder("sectorLimitOne", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class sectorLimitOneViewModel : ViewModelBase {
        private Decimal? _sectorLineLength = default;
        [Category("sectorLimitOne")]
        public Decimal? sectorLineLength {
            get {
                return _sectorLineLength;
            }

            set {
                SetValue(ref _sectorLineLength, value);
            }
        }

        private Decimal _sectorBearing;
        [Category("sectorLimitOne")]
        public Decimal sectorBearing {
            get {
                return _sectorBearing;
            }

            set {
                SetValue(ref _sectorBearing, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.sectorLimitOne instance) {
            sectorLineLength = instance.sectorLineLength;
            sectorBearing = instance.sectorBearing;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.sectorLimitOne
            {
                sectorLineLength = this.sectorLineLength,
                sectorBearing = this.sectorBearing,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.sectorLimitOne Model => new()
        {
            sectorLineLength = this._sectorLineLength,
            sectorBearing = this._sectorBearing,
        };

        public sectorLimitOneViewModel() : base() {
        }

        public override string? ToString() => $"Sector Limit One";
    }

#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    [CategoryOrder("topmark", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class topmarkViewModel : ViewModelBase
#pragma warning restore CS8981
    {
        private topmarkDaymarkShape _topmarkDaymarkShape;
        [Category("topmark")]
        public topmarkDaymarkShape topmarkDaymarkShape {
            get {
                return _topmarkDaymarkShape;
            }

            set {
                SetValue(ref _topmarkDaymarkShape, value);
            }
        }

        private colourPattern? _colourPattern = default;
        [Category("topmark")]
        public colourPattern? colourPattern {
            get {
                return _colourPattern;
            }

            set {
                SetValue(ref _colourPattern, value);
            }
        }

        private colour? _colour = default;
        [Category("topmark")]
        public colour? colour {
            get {
                return _colour;
            }

            set {
                SetValue(ref _colour, value);
            }
        }

        [Category("topmark")]
        public ObservableCollection<shapeInformation> shapeInformation { get; set; } = new();

        public void Load(DomainModel.S501.ComplexAttributes.topmark instance) {
            topmarkDaymarkShape = instance.topmarkDaymarkShape;
            colourPattern = instance.colourPattern;
            colour = instance.colour;
            shapeInformation.Clear();
            if (instance.shapeInformation is not null)
                foreach (var e in instance.shapeInformation)
                    shapeInformation.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.topmark
            {
                topmarkDaymarkShape = this.topmarkDaymarkShape,
                colourPattern = this.colourPattern,
                colour = this.colour,
                shapeInformation = this.shapeInformation.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.topmark Model => new()
        {
            topmarkDaymarkShape = this._topmarkDaymarkShape,
            colourPattern = this._colourPattern,
            colour = this._colour,
            shapeInformation = this.shapeInformation.ToList(),
        };

        public topmarkViewModel() : base() {
            shapeInformation.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(shapeInformation));
            };
        }

        public override string? ToString() => $"Topmark";
    }

    [CategoryOrder("rythmOfLight", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class rythmOfLightViewModel : ViewModelBase {
        [Category("rythmOfLight")]
        public ObservableCollection<signalSequence> signalSequence { get; set; } = new();

        private Decimal? _signalPeriod = default;
        [Category("rythmOfLight")]
        public Decimal? signalPeriod {
            get {
                return _signalPeriod;
            }

            set {
                SetValue(ref _signalPeriod, value);
            }
        }

        [Category("rythmOfLight")]
        public ObservableCollection<String> signalGroup { get; set; } = new();

        private lightCharacteristic _lightCharacteristic;
        [Category("rythmOfLight")]
        public lightCharacteristic lightCharacteristic {
            get {
                return _lightCharacteristic;
            }

            set {
                SetValue(ref _lightCharacteristic, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.rythmOfLight instance) {
            signalSequence.Clear();
            if (instance.signalSequence is not null)
                foreach (var e in instance.signalSequence)
                    signalSequence.Add(e);
            signalPeriod = instance.signalPeriod;
            signalGroup.Clear();
            if (instance.signalGroup is not null)
                foreach (var e in instance.signalGroup)
                    signalGroup.Add(e);
            lightCharacteristic = instance.lightCharacteristic;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.rythmOfLight
            {
                signalSequence = this.signalSequence.ToList(),
                signalPeriod = this.signalPeriod,
                signalGroup = this.signalGroup.ToList(),
                lightCharacteristic = this.lightCharacteristic,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.rythmOfLight Model => new()
        {
            signalSequence = this.signalSequence.ToList(),
            signalPeriod = this._signalPeriod,
            signalGroup = this.signalGroup.ToList(),
            lightCharacteristic = this._lightCharacteristic,
        };

        public rythmOfLightViewModel() : base() {
            signalSequence.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(signalSequence));
            };
            signalGroup.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(signalGroup));
            };
        }

        public override string? ToString() => $"rythmOfLight (missing name)";
    }

    [CategoryOrder("verticalClearanceSafe", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class verticalClearanceSafeViewModel : ViewModelBase {
        private verticalUncertaintyViewModel? _verticalUncertainty;
        [Category("verticalClearanceSafe")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public verticalUncertaintyViewModel? verticalUncertainty {
            get {
                return _verticalUncertainty;
            }

            set {
                SetValue(ref _verticalUncertainty, value);
            }
        }

        private Decimal _verticalClearanceValue;
        [Category("verticalClearanceSafe")]
        public Decimal verticalClearanceValue {
            get {
                return _verticalClearanceValue;
            }

            set {
                SetValue(ref _verticalClearanceValue, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.verticalClearanceSafe instance) {
            verticalUncertainty = new();
            if (instance.verticalUncertainty != null) {
                verticalUncertainty = new();
                verticalUncertainty.Load(instance.verticalUncertainty);
            }

            verticalClearanceValue = instance.verticalClearanceValue;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.verticalClearanceSafe
            {
                verticalUncertainty = this.verticalUncertainty?.Model,
                verticalClearanceValue = this.verticalClearanceValue,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.verticalClearanceSafe Model => new()
        {
            verticalUncertainty = this._verticalUncertainty?.Model,
            verticalClearanceValue = this._verticalClearanceValue,
        };

        public verticalClearanceSafeViewModel() : base() {
        }

        public override string? ToString() => $"Vertical Clearance Safe";
    }

    [CategoryOrder("sectorLimit", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class sectorLimitViewModel : ViewModelBase {
        private sectorLimitOneViewModel _sectorLimitOne;
        [Category("sectorLimit")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sectorLimitOneViewModel sectorLimitOne {
            get {
                return _sectorLimitOne;
            }

            set {
                SetValue(ref _sectorLimitOne, value);
            }
        }

        private sectorLimitTwoViewModel _sectorLimitTwo;
        [Category("sectorLimit")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sectorLimitTwoViewModel sectorLimitTwo {
            get {
                return _sectorLimitTwo;
            }

            set {
                SetValue(ref _sectorLimitTwo, value);
            }
        }

        public void Load(DomainModel.S501.ComplexAttributes.sectorLimit instance) {
            sectorLimitOne = new();
            if (instance.sectorLimitOne != null) {
                sectorLimitOne = new();
                sectorLimitOne.Load(instance.sectorLimitOne);
            }

            sectorLimitTwo = new();
            if (instance.sectorLimitTwo != null) {
                sectorLimitTwo = new();
                sectorLimitTwo.Load(instance.sectorLimitTwo);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.sectorLimit
            {
                sectorLimitOne = this.sectorLimitOne?.Model,
                sectorLimitTwo = this.sectorLimitTwo?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.sectorLimit Model => new()
        {
            sectorLimitOne = this._sectorLimitOne?.Model,
            sectorLimitTwo = this._sectorLimitTwo?.Model,
        };

        public sectorLimitViewModel() : base() {
        }

        public override string? ToString() => $"Sector Limit";
    }

    [CategoryOrder("lightSector", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class lightSectorViewModel : ViewModelBase {
        private sectorLimitViewModel? _sectorLimit;
        [Category("lightSector")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sectorLimitViewModel? sectorLimit {
            get {
                return _sectorLimit;
            }

            set {
                SetValue(ref _sectorLimit, value);
            }
        }

        [Category("lightSector")]
        public ObservableCollection<sectorInformation> sectorInformation { get; set; } = new();

        [Category("lightSector")]
        public ObservableCollection<lightVisibility> lightVisibility { get; set; } = new();

        private Decimal? _valueOfNominalRange = default;
        [Category("lightSector")]
        public Decimal? valueOfNominalRange {
            get {
                return _valueOfNominalRange;
            }

            set {
                SetValue(ref _valueOfNominalRange, value);
            }
        }

        private Boolean? _sectorArcExtension = default;
        [Category("lightSector")]
        public Boolean? sectorArcExtension {
            get {
                return _sectorArcExtension;
            }

            set {
                SetValue(ref _sectorArcExtension, value);
            }
        }

        private directionalCharacterViewModel? _directionalCharacter;
        [Category("lightSector")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public directionalCharacterViewModel? directionalCharacter {
            get {
                return _directionalCharacter;
            }

            set {
                SetValue(ref _directionalCharacter, value);
            }
        }

        [Category("lightSector")]
        public ObservableCollection<colour> colour { get; set; } = new();

        public void Load(DomainModel.S501.ComplexAttributes.lightSector instance) {
            sectorLimit = new();
            if (instance.sectorLimit != null) {
                sectorLimit = new();
                sectorLimit.Load(instance.sectorLimit);
            }

            sectorInformation.Clear();
            if (instance.sectorInformation is not null)
                foreach (var e in instance.sectorInformation)
                    sectorInformation.Add(e);
            lightVisibility.Clear();
            if (instance.lightVisibility is not null)
                foreach (var e in instance.lightVisibility)
                    lightVisibility.Add(e);
            valueOfNominalRange = instance.valueOfNominalRange;
            sectorArcExtension = instance.sectorArcExtension;
            directionalCharacter = new();
            if (instance.directionalCharacter != null) {
                directionalCharacter = new();
                directionalCharacter.Load(instance.directionalCharacter);
            }

            colour.Clear();
            if (instance.colour is not null)
                foreach (var e in instance.colour)
                    colour.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.lightSector
            {
                sectorLimit = this.sectorLimit?.Model,
                sectorInformation = this.sectorInformation.ToList(),
                lightVisibility = this.lightVisibility.ToList(),
                valueOfNominalRange = this.valueOfNominalRange,
                sectorArcExtension = this.sectorArcExtension,
                directionalCharacter = this.directionalCharacter?.Model,
                colour = this.colour.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.lightSector Model => new()
        {
            sectorLimit = this._sectorLimit?.Model,
            sectorInformation = this.sectorInformation.ToList(),
            lightVisibility = this.lightVisibility.ToList(),
            valueOfNominalRange = this._valueOfNominalRange,
            sectorArcExtension = this._sectorArcExtension,
            directionalCharacter = this._directionalCharacter?.Model,
            colour = this.colour.ToList(),
        };

        public lightSectorViewModel() : base() {
            sectorInformation.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(sectorInformation));
            };
            lightVisibility.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(lightVisibility));
            };
            colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(colour));
            };
        }

        public override string? ToString() => $"Light Sector";
    }

    [CategoryOrder("sectorCharacteristics", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class sectorCharacteristicsViewModel : ViewModelBase {
        [Category("sectorCharacteristics")]
        public ObservableCollection<signalSequence> signalSequence { get; set; } = new();

        private Decimal? _signalPeriod = default;
        [Category("sectorCharacteristics")]
        public Decimal? signalPeriod {
            get {
                return _signalPeriod;
            }

            set {
                SetValue(ref _signalPeriod, value);
            }
        }

        [Category("sectorCharacteristics")]
        public ObservableCollection<lightSector> lightSector { get; set; } = new();

        private lightCharacteristic _lightCharacteristic;
        [Category("sectorCharacteristics")]
        public lightCharacteristic lightCharacteristic {
            get {
                return _lightCharacteristic;
            }

            set {
                SetValue(ref _lightCharacteristic, value);
            }
        }

        [Category("sectorCharacteristics")]
        public ObservableCollection<String> signalGroup { get; set; } = new();

        public void Load(DomainModel.S501.ComplexAttributes.sectorCharacteristics instance) {
            signalSequence.Clear();
            if (instance.signalSequence is not null)
                foreach (var e in instance.signalSequence)
                    signalSequence.Add(e);
            signalPeriod = instance.signalPeriod;
            lightSector.Clear();
            if (instance.lightSector is not null)
                foreach (var e in instance.lightSector)
                    lightSector.Add(e);
            lightCharacteristic = instance.lightCharacteristic;
            signalGroup.Clear();
            if (instance.signalGroup is not null)
                foreach (var e in instance.signalGroup)
                    signalGroup.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.ComplexAttributes.sectorCharacteristics
            {
                signalSequence = this.signalSequence.ToList(),
                signalPeriod = this.signalPeriod,
                lightSector = this.lightSector.ToList(),
                lightCharacteristic = this.lightCharacteristic,
                signalGroup = this.signalGroup.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.ComplexAttributes.sectorCharacteristics Model => new()
        {
            signalSequence = this.signalSequence.ToList(),
            signalPeriod = this._signalPeriod,
            lightSector = this.lightSector.ToList(),
            lightCharacteristic = this._lightCharacteristic,
            signalGroup = this.signalGroup.ToList(),
        };

        public sectorCharacteristicsViewModel() : base() {
            signalSequence.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(signalSequence));
            };
            lightSector.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(lightSector));
            };
            signalGroup.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(signalGroup));
            };
        }

        public override string? ToString() => $"Sector Characteristics";
    }

    [CategoryOrder("ReferenceToAPublication", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ReferenceToAPublicationViewModel : ViewModelBase {
        private DateOnly? _editionDate = default;
        [Category("ReferenceToAPublication")]
        public DateOnly? editionDate {
            get {
                return _editionDate;
            }

            set {
                SetValue(ref _editionDate, value);
            }
        }

        private String _editionNumber = string.Empty;
        [Category("ReferenceToAPublication")]
        public String editionNumber {
            get {
                return _editionNumber;
            }

            set {
                SetValue(ref _editionNumber, value);
            }
        }

        [Category("ReferenceToAPublication")]
        public ObservableCollection<onlineResource> onlineResource { get; set; } = new();

        [Category("ReferenceToAPublication")]
        public ObservableCollection<information> information { get; set; } = new();

        public class ReferenceToAPublicationRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["ReferenceToAPublication"];
        }

        public void Load(DomainModel.S501.InformationTypes.ReferenceToAPublication instance) {
            editionDate = instance.editionDate;
            editionNumber = instance.editionNumber;
            onlineResource.Clear();
            if (instance.onlineResource is not null)
                foreach (var e in instance.onlineResource)
                    onlineResource.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.InformationTypes.ReferenceToAPublication
            {
                editionDate = this.editionDate,
                editionNumber = this.editionNumber,
                onlineResource = this.onlineResource.ToList(),
                information = this.information.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.InformationTypes.ReferenceToAPublication Model => new()
        {
            editionDate = this._editionDate,
            editionNumber = this._editionNumber,
            onlineResource = this.onlineResource.ToList(),
            information = this.information.ToList(),
        };

        public ReferenceToAPublicationViewModel() : base() {
            onlineResource.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(onlineResource));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"ReferenceToAPublication (missing Name)";
    }

    [CategoryOrder("InstallationBuoy", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class InstallationBuoyViewModel : ViewModelBase {
        [Category("InstallationBuoy")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private colourPattern? _colourPattern = default;
        [Category("InstallationBuoy")]
        public colourPattern? colourPattern {
            get {
                return _colourPattern;
            }

            set {
                SetValue(ref _colourPattern, value);
            }
        }

        [Category("InstallationBuoy")]
        public ObservableCollection<product> product { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InstallationBuoy")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InstallationBuoy")]
        public ObservableCollection<status> status { get; set; } = new();

        private visualProminence? _visualProminence = default;
        [Category("InstallationBuoy")]
        public visualProminence? visualProminence {
            get {
                return _visualProminence;
            }

            set {
                SetValue(ref _visualProminence, value);
            }
        }

        [Category("InstallationBuoy")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("InstallationBuoy")]
        public ObservableCollection<colour> colour { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("InstallationBuoy")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("InstallationBuoy")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        private String _pictorialRepresentation = string.Empty;
        [Category("InstallationBuoy")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        private buoyShape _buoyShape;
        [Category("InstallationBuoy")]
        public buoyShape buoyShape {
            get {
                return _buoyShape;
            }

            set {
                SetValue(ref _buoyShape, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("InstallationBuoy")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        [Category("InstallationBuoy")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        private Boolean? _radarConspicuous = default;
        [Category("InstallationBuoy")]
        public Boolean? radarConspicuous {
            get {
                return _radarConspicuous;
            }

            set {
                SetValue(ref _radarConspicuous, value);
            }
        }

        private categoryOfInstallationBuoy? _categoryOfInstallationBuoy = default;
        [Category("InstallationBuoy")]
        public categoryOfInstallationBuoy? categoryOfInstallationBuoy {
            get {
                return _categoryOfInstallationBuoy;
            }

            set {
                SetValue(ref _categoryOfInstallationBuoy, value);
            }
        }

        public class InstallationBuoyRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["InstallationBuoy"];
        }

        public void Load(DomainModel.S501.FeatureTypes.InstallationBuoy instance) {
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            colourPattern = instance.colourPattern;
            product.Clear();
            if (instance.product is not null)
                foreach (var e in instance.product)
                    product.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            visualProminence = instance.visualProminence;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            colour.Clear();
            if (instance.colour is not null)
                foreach (var e in instance.colour)
                    colour.Add(e);
            scaleMinimum = instance.scaleMinimum;
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            pictorialRepresentation = instance.pictorialRepresentation;
            buoyShape = instance.buoyShape;
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            natureOfConstruction.Clear();
            if (instance.natureOfConstruction is not null)
                foreach (var e in instance.natureOfConstruction)
                    natureOfConstruction.Add(e);
            radarConspicuous = instance.radarConspicuous;
            categoryOfInstallationBuoy = instance.categoryOfInstallationBuoy;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.InstallationBuoy
            {
                featureName = this.featureName.ToList(),
                colourPattern = this.colourPattern,
                product = this.product.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                status = this.status.ToList(),
                visualProminence = this.visualProminence,
                information = this.information.ToList(),
                colour = this.colour.ToList(),
                scaleMinimum = this.scaleMinimum,
                periodicDateRange = this.periodicDateRange.ToList(),
                pictorialRepresentation = this.pictorialRepresentation,
                buoyShape = this.buoyShape,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                natureOfConstruction = this.natureOfConstruction.ToList(),
                radarConspicuous = this.radarConspicuous,
                categoryOfInstallationBuoy = this.categoryOfInstallationBuoy,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.InstallationBuoy Model => new()
        {
            featureName = this.featureName.ToList(),
            colourPattern = this._colourPattern,
            product = this.product.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            status = this.status.ToList(),
            visualProminence = this._visualProminence,
            information = this.information.ToList(),
            colour = this.colour.ToList(),
            scaleMinimum = this._scaleMinimum,
            periodicDateRange = this.periodicDateRange.ToList(),
            pictorialRepresentation = this._pictorialRepresentation,
            buoyShape = this._buoyShape,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            natureOfConstruction = this.natureOfConstruction.ToList(),
            radarConspicuous = this._radarConspicuous,
            categoryOfInstallationBuoy = this._categoryOfInstallationBuoy,
        };

        public InstallationBuoyViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            product.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(product));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(colour));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(natureOfConstruction));
            };
        }

        public override string? ToString() => $"Installation Buoy";
    }

    [CategoryOrder("DepthArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class DepthAreaViewModel : ViewModelBase {
        private Decimal _depthRangeMaximumValue;
        [Category("DepthArea")]
        public Decimal depthRangeMaximumValue {
            get {
                return _depthRangeMaximumValue;
            }

            set {
                SetValue(ref _depthRangeMaximumValue, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("DepthArea")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        [Category("DepthArea")]
        public ObservableCollection<information> information { get; set; } = new();

        private Decimal _depthRangeMinimumValue;
        [Category("DepthArea")]
        public Decimal depthRangeMinimumValue {
            get {
                return _depthRangeMinimumValue;
            }

            set {
                SetValue(ref _depthRangeMinimumValue, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("DepthArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        public class DepthAreaRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["DepthArea"];
        }

        public void Load(DomainModel.S501.FeatureTypes.DepthArea instance) {
            depthRangeMaximumValue = instance.depthRangeMaximumValue;
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            depthRangeMinimumValue = instance.depthRangeMinimumValue;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.DepthArea
            {
                depthRangeMaximumValue = this.depthRangeMaximumValue,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                information = this.information.ToList(),
                depthRangeMinimumValue = this.depthRangeMinimumValue,
                sourceIdentification = this.sourceIdentification?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.DepthArea Model => new()
        {
            depthRangeMaximumValue = this._depthRangeMaximumValue,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            information = this.information.ToList(),
            depthRangeMinimumValue = this._depthRangeMinimumValue,
            sourceIdentification = this._sourceIdentification?.Model,
        };

        public DepthAreaViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Depth Area";
    }

    [CategoryOrder("RadioCallingInPoint", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class RadioCallingInPointViewModel : ViewModelBase {
        private categoryOfReportingRadioCallingInPoint? _categoryOfReportingRadioCallingInPoint = default;
        [Category("RadioCallingInPoint")]
        public categoryOfReportingRadioCallingInPoint? categoryOfReportingRadioCallingInPoint {
            get {
                return _categoryOfReportingRadioCallingInPoint;
            }

            set {
                SetValue(ref _categoryOfReportingRadioCallingInPoint, value);
            }
        }

        [Category("RadioCallingInPoint")]
        public ObservableCollection<information> information { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("RadioCallingInPoint")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("RadioCallingInPoint")]
        public ObservableCollection<String> communicationChannel { get; set; } = new();

        [Category("RadioCallingInPoint")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        private String _interoperabilityIdentifier = string.Empty;
        [Category("RadioCallingInPoint")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        [Category("RadioCallingInPoint")]
        public ObservableCollection<Decimal> orientationValue { get; set; } = new();

        [Category("RadioCallingInPoint")]
        public ObservableCollection<status> status { get; set; } = new();

        [Category("RadioCallingInPoint")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("RadioCallingInPoint")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private trafficFlow _trafficFlow;
        [Category("RadioCallingInPoint")]
        public trafficFlow trafficFlow {
            get {
                return _trafficFlow;
            }

            set {
                SetValue(ref _trafficFlow, value);
            }
        }

        public class RadioCallingInPointRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["RadioCallingInPoint"];
        }

        public void Load(DomainModel.S501.FeatureTypes.RadioCallingInPoint instance) {
            categoryOfReportingRadioCallingInPoint = instance.categoryOfReportingRadioCallingInPoint;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            scaleMinimum = instance.scaleMinimum;
            communicationChannel.Clear();
            if (instance.communicationChannel is not null)
                foreach (var e in instance.communicationChannel)
                    communicationChannel.Add(e);
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            orientationValue.Clear();
            if (instance.orientationValue is not null)
                foreach (var e in instance.orientationValue)
                    orientationValue.Add(e);
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            trafficFlow = instance.trafficFlow;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.RadioCallingInPoint
            {
                categoryOfReportingRadioCallingInPoint = this.categoryOfReportingRadioCallingInPoint,
                information = this.information.ToList(),
                scaleMinimum = this.scaleMinimum,
                communicationChannel = this.communicationChannel.ToList(),
                periodicDateRange = this.periodicDateRange.ToList(),
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                orientationValue = this.orientationValue.ToList(),
                status = this.status.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                trafficFlow = this.trafficFlow,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.RadioCallingInPoint Model => new()
        {
            categoryOfReportingRadioCallingInPoint = this._categoryOfReportingRadioCallingInPoint,
            information = this.information.ToList(),
            scaleMinimum = this._scaleMinimum,
            communicationChannel = this.communicationChannel.ToList(),
            periodicDateRange = this.periodicDateRange.ToList(),
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            orientationValue = this.orientationValue.ToList(),
            status = this.status.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            trafficFlow = this._trafficFlow,
        };

        public RadioCallingInPointViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            communicationChannel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(communicationChannel));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            orientationValue.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(orientationValue));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
        }

        public override string? ToString() => $"Radio Calling-In Point";
    }

    [CategoryOrder("PatrolArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class PatrolAreaViewModel : ViewModelBase {
        private String _agencyResponsibleForProduction = string.Empty;
        [Category("PatrolArea")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("PatrolArea")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private String _nationality = string.Empty;
        [Category("PatrolArea")]
        public String nationality {
            get {
                return _nationality;
            }

            set {
                SetValue(ref _nationality, value);
            }
        }

        private String _controllingAuthority = string.Empty;
        [Category("PatrolArea")]
        public String controllingAuthority {
            get {
                return _controllingAuthority;
            }

            set {
                SetValue(ref _controllingAuthority, value);
            }
        }

        private categoryOfPatrolArea _categoryOfPatrolArea;
        [Category("PatrolArea")]
        public categoryOfPatrolArea categoryOfPatrolArea {
            get {
                return _categoryOfPatrolArea;
            }

            set {
                SetValue(ref _categoryOfPatrolArea, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("PatrolArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        [Category("PatrolArea")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        [Category("PatrolArea")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("PatrolArea")]
        public ObservableCollection<status> status { get; set; } = new();

        public class PatrolAreaRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["PatrolArea"];
        }

        public void Load(DomainModel.S501.FeatureTypes.PatrolArea instance) {
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            reportedDate = instance.reportedDate;
            nationality = instance.nationality;
            controllingAuthority = instance.controllingAuthority;
            categoryOfPatrolArea = instance.categoryOfPatrolArea;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.PatrolArea
            {
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                reportedDate = this.reportedDate,
                nationality = this.nationality,
                controllingAuthority = this.controllingAuthority,
                categoryOfPatrolArea = this.categoryOfPatrolArea,
                sourceIdentification = this.sourceIdentification?.Model,
                featureName = this.featureName.ToList(),
                information = this.information.ToList(),
                status = this.status.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.PatrolArea Model => new()
        {
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            reportedDate = this._reportedDate,
            nationality = this._nationality,
            controllingAuthority = this._controllingAuthority,
            categoryOfPatrolArea = this._categoryOfPatrolArea,
            sourceIdentification = this._sourceIdentification?.Model,
            featureName = this.featureName.ToList(),
            information = this.information.ToList(),
            status = this.status.ToList(),
        };

        public PatrolAreaViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
        }

        public override string? ToString() => $"Patrol Area";
    }

    [CategoryOrder("Checkpoint", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class CheckpointViewModel : ViewModelBase {
        private String _controllingAuthority = string.Empty;
        [Category("Checkpoint")]
        public String controllingAuthority {
            get {
                return _controllingAuthority;
            }

            set {
                SetValue(ref _controllingAuthority, value);
            }
        }

        [Category("Checkpoint")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private String _agencyResponsibleForProduction = string.Empty;
        [Category("Checkpoint")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        [Category("Checkpoint")]
        public ObservableCollection<status> status { get; set; } = new();

        [Category("Checkpoint")]
        public ObservableCollection<information> information { get; set; } = new();

        private String _interoperabilityIdentifier = string.Empty;
        [Category("Checkpoint")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("Checkpoint")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private categoryOfCheckpoint? _categoryOfCheckpoint = default;
        [Category("Checkpoint")]
        public categoryOfCheckpoint? categoryOfCheckpoint {
            get {
                return _categoryOfCheckpoint;
            }

            set {
                SetValue(ref _categoryOfCheckpoint, value);
            }
        }

        public class CheckpointRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["Checkpoint"];
        }

        public void Load(DomainModel.S501.FeatureTypes.Checkpoint instance) {
            controllingAuthority = instance.controllingAuthority;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            scaleMinimum = instance.scaleMinimum;
            categoryOfCheckpoint = instance.categoryOfCheckpoint;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.Checkpoint
            {
                controllingAuthority = this.controllingAuthority,
                featureName = this.featureName.ToList(),
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                status = this.status.ToList(),
                information = this.information.ToList(),
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                scaleMinimum = this.scaleMinimum,
                categoryOfCheckpoint = this.categoryOfCheckpoint,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.Checkpoint Model => new()
        {
            controllingAuthority = this._controllingAuthority,
            featureName = this.featureName.ToList(),
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            status = this.status.ToList(),
            information = this.information.ToList(),
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            scaleMinimum = this._scaleMinimum,
            categoryOfCheckpoint = this._categoryOfCheckpoint,
        };

        public CheckpointViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Checkpoint";
    }

    [CategoryOrder("MarineManagementArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class MarineManagementAreaViewModel : ViewModelBase {
        private restriction? _restriction = default;
        [Category("MarineManagementArea")]
        public restriction? restriction {
            get {
                return _restriction;
            }

            set {
                SetValue(ref _restriction, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("MarineManagementArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        [Category("MarineManagementArea")]
        public ObservableCollection<speciesGrouping> speciesGrouping { get; set; } = new();

        [Category("MarineManagementArea")]
        public ObservableCollection<String> nationalMaritimeAuthority { get; set; } = new();

        private jurisdiction _jurisdiction;
        [Category("MarineManagementArea")]
        public jurisdiction jurisdiction {
            get {
                return _jurisdiction;
            }

            set {
                SetValue(ref _jurisdiction, value);
            }
        }

        [Category("MarineManagementArea")]
        public ObservableCollection<information> information { get; set; } = new();

        private categoryofMarineProtectedArea? _categoryofMarineProtectedArea = default;
        [Category("MarineManagementArea")]
        public categoryofMarineProtectedArea? categoryofMarineProtectedArea {
            get {
                return _categoryofMarineProtectedArea;
            }

            set {
                SetValue(ref _categoryofMarineProtectedArea, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("MarineManagementArea")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private String _agencyResponsibleForProduction = string.Empty;
        [Category("MarineManagementArea")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        [Category("MarineManagementArea")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private String _controllingAuthority = string.Empty;
        [Category("MarineManagementArea")]
        public String controllingAuthority {
            get {
                return _controllingAuthority;
            }

            set {
                SetValue(ref _controllingAuthority, value);
            }
        }

        private String _pictorialRepresentation = string.Empty;
        [Category("MarineManagementArea")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        private status? _status = default;
        [Category("MarineManagementArea")]
        public status? status {
            get {
                return _status;
            }

            set {
                SetValue(ref _status, value);
            }
        }

        [Category("MarineManagementArea")]
        public ObservableCollection<categoryofRestrictions> categoryofRestrictions { get; set; } = new();

        [Category("MarineManagementArea")]
        public ObservableCollection<String> species { get; set; } = new();

        public class MarineManagementAreaRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["MarineManagementArea"];
        }

        public void Load(DomainModel.S501.FeatureTypes.MarineManagementArea instance) {
            restriction = instance.restriction;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            speciesGrouping.Clear();
            if (instance.speciesGrouping is not null)
                foreach (var e in instance.speciesGrouping)
                    speciesGrouping.Add(e);
            nationalMaritimeAuthority.Clear();
            if (instance.nationalMaritimeAuthority is not null)
                foreach (var e in instance.nationalMaritimeAuthority)
                    nationalMaritimeAuthority.Add(e);
            jurisdiction = instance.jurisdiction;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            categoryofMarineProtectedArea = instance.categoryofMarineProtectedArea;
            reportedDate = instance.reportedDate;
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            controllingAuthority = instance.controllingAuthority;
            pictorialRepresentation = instance.pictorialRepresentation;
            status = instance.status;
            categoryofRestrictions.Clear();
            if (instance.categoryofRestrictions is not null)
                foreach (var e in instance.categoryofRestrictions)
                    categoryofRestrictions.Add(e);
            species.Clear();
            if (instance.species is not null)
                foreach (var e in instance.species)
                    species.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.MarineManagementArea
            {
                restriction = this.restriction,
                sourceIdentification = this.sourceIdentification?.Model,
                speciesGrouping = this.speciesGrouping.ToList(),
                nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
                jurisdiction = this.jurisdiction,
                information = this.information.ToList(),
                categoryofMarineProtectedArea = this.categoryofMarineProtectedArea,
                reportedDate = this.reportedDate,
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                featureName = this.featureName.ToList(),
                controllingAuthority = this.controllingAuthority,
                pictorialRepresentation = this.pictorialRepresentation,
                status = this.status,
                categoryofRestrictions = this.categoryofRestrictions.ToList(),
                species = this.species.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.MarineManagementArea Model => new()
        {
            restriction = this._restriction,
            sourceIdentification = this._sourceIdentification?.Model,
            speciesGrouping = this.speciesGrouping.ToList(),
            nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
            jurisdiction = this._jurisdiction,
            information = this.information.ToList(),
            categoryofMarineProtectedArea = this._categoryofMarineProtectedArea,
            reportedDate = this._reportedDate,
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            featureName = this.featureName.ToList(),
            controllingAuthority = this._controllingAuthority,
            pictorialRepresentation = this._pictorialRepresentation,
            status = this._status,
            categoryofRestrictions = this.categoryofRestrictions.ToList(),
            species = this.species.ToList(),
        };

        public MarineManagementAreaViewModel() : base() {
            speciesGrouping.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(speciesGrouping));
            };
            nationalMaritimeAuthority.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(nationalMaritimeAuthority));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            categoryofRestrictions.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(categoryofRestrictions));
            };
            species.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(species));
            };
        }

        public override string? ToString() => $"Marine Management Area";
    }

    [CategoryOrder("DepthContour", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class DepthContourViewModel : ViewModelBase {
        [Category("DepthContour")]
        public ObservableCollection<information> information { get; set; } = new();

        private verticalUncertaintyViewModel? _verticalUncertainty;
        [Category("DepthContour")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public verticalUncertaintyViewModel? verticalUncertainty {
            get {
                return _verticalUncertainty;
            }

            set {
                SetValue(ref _verticalUncertainty, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("DepthContour")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private Decimal _valueOfDepthContour;
        [Category("DepthContour")]
        public Decimal valueOfDepthContour {
            get {
                return _valueOfDepthContour;
            }

            set {
                SetValue(ref _valueOfDepthContour, value);
            }
        }

        private String _agencyResponsibleForProduction = string.Empty;
        [Category("DepthContour")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("DepthContour")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("DepthContour")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        public class DepthContourRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["DepthContour"];
        }

        public void Load(DomainModel.S501.FeatureTypes.DepthContour instance) {
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            verticalUncertainty = new();
            if (instance.verticalUncertainty != null) {
                verticalUncertainty = new();
                verticalUncertainty.Load(instance.verticalUncertainty);
            }

            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            valueOfDepthContour = instance.valueOfDepthContour;
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            scaleMinimum = instance.scaleMinimum;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.DepthContour
            {
                information = this.information.ToList(),
                verticalUncertainty = this.verticalUncertainty?.Model,
                sourceIdentification = this.sourceIdentification?.Model,
                valueOfDepthContour = this.valueOfDepthContour,
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                scaleMinimum = this.scaleMinimum,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.DepthContour Model => new()
        {
            information = this.information.ToList(),
            verticalUncertainty = this._verticalUncertainty?.Model,
            sourceIdentification = this._sourceIdentification?.Model,
            valueOfDepthContour = this._valueOfDepthContour,
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            scaleMinimum = this._scaleMinimum,
        };

        public DepthContourViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Depth Contour";
    }

    [CategoryOrder("EnvironmentallySensitiveSeaArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class EnvironmentallySensitiveSeaAreaViewModel : ViewModelBase {
        [Category("EnvironmentallySensitiveSeaArea")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private String _controllingAuthority = string.Empty;
        [Category("EnvironmentallySensitiveSeaArea")]
        public String controllingAuthority {
            get {
                return _controllingAuthority;
            }

            set {
                SetValue(ref _controllingAuthority, value);
            }
        }

        [Category("EnvironmentallySensitiveSeaArea")]
        public ObservableCollection<information> information { get; set; } = new();

        public class EnvironmentallySensitiveSeaAreaRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["EnvironmentallySensitiveSeaArea"];
        }

        public void Load(DomainModel.S501.FeatureTypes.EnvironmentallySensitiveSeaArea instance) {
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            controllingAuthority = instance.controllingAuthority;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.EnvironmentallySensitiveSeaArea
            {
                featureName = this.featureName.ToList(),
                controllingAuthority = this.controllingAuthority,
                information = this.information.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.EnvironmentallySensitiveSeaArea Model => new()
        {
            featureName = this.featureName.ToList(),
            controllingAuthority = this._controllingAuthority,
            information = this.information.ToList(),
        };

        public EnvironmentallySensitiveSeaAreaViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Environmentally Sensitive Sea Area";
    }

    [CategoryOrder("Road", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class RoadViewModel : ViewModelBase {
        [Category("Road")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        [Category("Road")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private String _pictorialRepresentation = string.Empty;
        [Category("Road")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("Road")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private categoryOfRoad? _categoryOfRoad = default;
        [Category("Road")]
        public categoryOfRoad? categoryOfRoad {
            get {
                return _categoryOfRoad;
            }

            set {
                SetValue(ref _categoryOfRoad, value);
            }
        }

        private condition? _condition = default;
        [Category("Road")]
        public condition? condition {
            get {
                return _condition;
            }

            set {
                SetValue(ref _condition, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("Road")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        [Category("Road")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("Road")]
        public ObservableCollection<status> status { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("Road")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        public class RoadRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["Road"];
        }

        public void Load(DomainModel.S501.FeatureTypes.Road instance) {
            natureOfConstruction.Clear();
            if (instance.natureOfConstruction is not null)
                foreach (var e in instance.natureOfConstruction)
                    natureOfConstruction.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            pictorialRepresentation = instance.pictorialRepresentation;
            reportedDate = instance.reportedDate;
            categoryOfRoad = instance.categoryOfRoad;
            condition = instance.condition;
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            scaleMinimum = instance.scaleMinimum;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.Road
            {
                natureOfConstruction = this.natureOfConstruction.ToList(),
                featureName = this.featureName.ToList(),
                pictorialRepresentation = this.pictorialRepresentation,
                reportedDate = this.reportedDate,
                categoryOfRoad = this.categoryOfRoad,
                condition = this.condition,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                information = this.information.ToList(),
                status = this.status.ToList(),
                scaleMinimum = this.scaleMinimum,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.Road Model => new()
        {
            natureOfConstruction = this.natureOfConstruction.ToList(),
            featureName = this.featureName.ToList(),
            pictorialRepresentation = this._pictorialRepresentation,
            reportedDate = this._reportedDate,
            categoryOfRoad = this._categoryOfRoad,
            condition = this._condition,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            information = this.information.ToList(),
            status = this.status.ToList(),
            scaleMinimum = this._scaleMinimum,
        };

        public RoadViewModel() : base() {
            natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(natureOfConstruction));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
        }

        public override string? ToString() => $"Road";
    }

    [CategoryOrder("River", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class RiverViewModel : ViewModelBase {
        private Int32? _scaleMinimum = default;
        [Category("River")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("River")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        [Category("River")]
        public ObservableCollection<status> status { get; set; } = new();

        private String _interoperabilityIdentifier = string.Empty;
        [Category("River")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        [Category("River")]
        public ObservableCollection<information> information { get; set; } = new();

        public class RiverRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["River"];
        }

        public void Load(DomainModel.S501.FeatureTypes.River instance) {
            scaleMinimum = instance.scaleMinimum;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.River
            {
                scaleMinimum = this.scaleMinimum,
                featureName = this.featureName.ToList(),
                status = this.status.ToList(),
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                information = this.information.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.River Model => new()
        {
            scaleMinimum = this._scaleMinimum,
            featureName = this.featureName.ToList(),
            status = this.status.ToList(),
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            information = this.information.ToList(),
        };

        public RiverViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"River";
    }

    [CategoryOrder("MilitaryPracticeArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class MilitaryPracticeAreaViewModel : ViewModelBase {
        private altitudeRangeViewModel? _altitudeRange;
        [Category("MilitaryPracticeArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public altitudeRangeViewModel? altitudeRange {
            get {
                return _altitudeRange;
            }

            set {
                SetValue(ref _altitudeRange, value);
            }
        }

        private String _depthRestriction = string.Empty;
        [Category("MilitaryPracticeArea")]
        public String depthRestriction {
            get {
                return _depthRestriction;
            }

            set {
                SetValue(ref _depthRestriction, value);
            }
        }

        private depthUnits? _depthUnits = default;
        [Category("MilitaryPracticeArea")]
        public depthUnits? depthUnits {
            get {
                return _depthUnits;
            }

            set {
                SetValue(ref _depthUnits, value);
            }
        }

        [Category("MilitaryPracticeArea")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        private String _nationality = string.Empty;
        [Category("MilitaryPracticeArea")]
        public String nationality {
            get {
                return _nationality;
            }

            set {
                SetValue(ref _nationality, value);
            }
        }

        [Category("MilitaryPracticeArea")]
        public ObservableCollection<restriction> restriction { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("MilitaryPracticeArea")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("MilitaryPracticeArea")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("MilitaryPracticeArea")]
        public ObservableCollection<typeofMilitaryActivity> typeofMilitaryActivity { get; set; } = new();

        private String _activePeriod = string.Empty;
        [Category("MilitaryPracticeArea")]
        public String activePeriod {
            get {
                return _activePeriod;
            }

            set {
                SetValue(ref _activePeriod, value);
            }
        }

        [Category("MilitaryPracticeArea")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private Int32? _minimumSafeDepth = default;
        [Category("MilitaryPracticeArea")]
        public Int32? minimumSafeDepth {
            get {
                return _minimumSafeDepth;
            }

            set {
                SetValue(ref _minimumSafeDepth, value);
            }
        }

        [Category("MilitaryPracticeArea")]
        public ObservableCollection<categoryofMilitaryPracticeArea> categoryofMilitaryPracticeArea { get; set; } = new();

        private Int32? _bottomVerticalSafetySeparation = default;
        [Category("MilitaryPracticeArea")]
        public Int32? bottomVerticalSafetySeparation {
            get {
                return _bottomVerticalSafetySeparation;
            }

            set {
                SetValue(ref _bottomVerticalSafetySeparation, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("MilitaryPracticeArea")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private String _agencyResponsibleForProduction = string.Empty;
        [Category("MilitaryPracticeArea")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        private areaCategory? _areaCategory = default;
        [Category("MilitaryPracticeArea")]
        public areaCategory? areaCategory {
            get {
                return _areaCategory;
            }

            set {
                SetValue(ref _areaCategory, value);
            }
        }

        private verticalDatum? _verticalDatum = default;
        [Category("MilitaryPracticeArea")]
        public verticalDatum? verticalDatum {
            get {
                return _verticalDatum;
            }

            set {
                SetValue(ref _verticalDatum, value);
            }
        }

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("MilitaryPracticeArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("MilitaryPracticeArea")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("MilitaryPracticeArea")]
        public ObservableCollection<status> status { get; set; } = new();

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("MilitaryPracticeArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private String _controllingAuthority = string.Empty;
        [Category("MilitaryPracticeArea")]
        public String controllingAuthority {
            get {
                return _controllingAuthority;
            }

            set {
                SetValue(ref _controllingAuthority, value);
            }
        }

        public class MilitaryPracticeAreaRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["MilitaryPracticeArea"];
        }

        public void Load(DomainModel.S501.FeatureTypes.MilitaryPracticeArea instance) {
            altitudeRange = new();
            if (instance.altitudeRange != null) {
                altitudeRange = new();
                altitudeRange.Load(instance.altitudeRange);
            }

            depthRestriction = instance.depthRestriction;
            depthUnits = instance.depthUnits;
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            nationality = instance.nationality;
            restriction.Clear();
            if (instance.restriction is not null)
                foreach (var e in instance.restriction)
                    restriction.Add(e);
            scaleMinimum = instance.scaleMinimum;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            typeofMilitaryActivity.Clear();
            if (instance.typeofMilitaryActivity is not null)
                foreach (var e in instance.typeofMilitaryActivity)
                    typeofMilitaryActivity.Add(e);
            activePeriod = instance.activePeriod;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            minimumSafeDepth = instance.minimumSafeDepth;
            categoryofMilitaryPracticeArea.Clear();
            if (instance.categoryofMilitaryPracticeArea is not null)
                foreach (var e in instance.categoryofMilitaryPracticeArea)
                    categoryofMilitaryPracticeArea.Add(e);
            bottomVerticalSafetySeparation = instance.bottomVerticalSafetySeparation;
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            areaCategory = instance.areaCategory;
            verticalDatum = instance.verticalDatum;
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            reportedDate = instance.reportedDate;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            controllingAuthority = instance.controllingAuthority;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.MilitaryPracticeArea
            {
                altitudeRange = this.altitudeRange?.Model,
                depthRestriction = this.depthRestriction,
                depthUnits = this.depthUnits,
                periodicDateRange = this.periodicDateRange.ToList(),
                nationality = this.nationality,
                restriction = this.restriction.ToList(),
                scaleMinimum = this.scaleMinimum,
                information = this.information.ToList(),
                typeofMilitaryActivity = this.typeofMilitaryActivity.ToList(),
                activePeriod = this.activePeriod,
                featureName = this.featureName.ToList(),
                minimumSafeDepth = this.minimumSafeDepth,
                categoryofMilitaryPracticeArea = this.categoryofMilitaryPracticeArea.ToList(),
                bottomVerticalSafetySeparation = this.bottomVerticalSafetySeparation,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                areaCategory = this.areaCategory,
                verticalDatum = this.verticalDatum,
                fixedDateRange = this.fixedDateRange?.Model,
                reportedDate = this.reportedDate,
                status = this.status.ToList(),
                sourceIdentification = this.sourceIdentification?.Model,
                controllingAuthority = this.controllingAuthority,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.MilitaryPracticeArea Model => new()
        {
            altitudeRange = this._altitudeRange?.Model,
            depthRestriction = this._depthRestriction,
            depthUnits = this._depthUnits,
            periodicDateRange = this.periodicDateRange.ToList(),
            nationality = this._nationality,
            restriction = this.restriction.ToList(),
            scaleMinimum = this._scaleMinimum,
            information = this.information.ToList(),
            typeofMilitaryActivity = this.typeofMilitaryActivity.ToList(),
            activePeriod = this._activePeriod,
            featureName = this.featureName.ToList(),
            minimumSafeDepth = this._minimumSafeDepth,
            categoryofMilitaryPracticeArea = this.categoryofMilitaryPracticeArea.ToList(),
            bottomVerticalSafetySeparation = this._bottomVerticalSafetySeparation,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            areaCategory = this._areaCategory,
            verticalDatum = this._verticalDatum,
            fixedDateRange = this._fixedDateRange?.Model,
            reportedDate = this._reportedDate,
            status = this.status.ToList(),
            sourceIdentification = this._sourceIdentification?.Model,
            controllingAuthority = this._controllingAuthority,
        };

        public MilitaryPracticeAreaViewModel() : base() {
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(restriction));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            typeofMilitaryActivity.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(typeofMilitaryActivity));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            categoryofMilitaryPracticeArea.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(categoryofMilitaryPracticeArea));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
        }

        public override string? ToString() => $"Military Practice Area";
    }

    [CategoryOrder("DiscolouredWater", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class DiscolouredWaterViewModel : ViewModelBase {
        [Category("DiscolouredWater")]
        public ObservableCollection<information> information { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("DiscolouredWater")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("DiscolouredWater")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        public class DiscolouredWaterRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["DiscolouredWater"];
        }

        public void Load(DomainModel.S501.FeatureTypes.DiscolouredWater instance) {
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            scaleMinimum = instance.scaleMinimum;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.DiscolouredWater
            {
                information = this.information.ToList(),
                scaleMinimum = this.scaleMinimum,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.DiscolouredWater Model => new()
        {
            information = this.information.ToList(),
            scaleMinimum = this._scaleMinimum,
            reportedDate = this._reportedDate,
        };

        public DiscolouredWaterViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Discoloured Water";
    }

    [CategoryOrder("CardinalBuoy", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class CardinalBuoyViewModel : ViewModelBase {
        private categoryOfCardinalMark _categoryOfCardinalMark;
        [Category("CardinalBuoy")]
        public categoryOfCardinalMark categoryOfCardinalMark {
            get {
                return _categoryOfCardinalMark;
            }

            set {
                SetValue(ref _categoryOfCardinalMark, value);
            }
        }

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("CardinalBuoy")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("CardinalBuoy")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("CardinalBuoy")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("CardinalBuoy")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        private buoyShape _buoyShape;
        [Category("CardinalBuoy")]
        public buoyShape buoyShape {
            get {
                return _buoyShape;
            }

            set {
                SetValue(ref _buoyShape, value);
            }
        }

        private Decimal? _verticalLength = default;
        [Category("CardinalBuoy")]
        public Decimal? verticalLength {
            get {
                return _verticalLength;
            }

            set {
                SetValue(ref _verticalLength, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("CardinalBuoy")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        [Category("CardinalBuoy")]
        public ObservableCollection<status> status { get; set; } = new();

        private Boolean? _radarConspicuous = default;
        [Category("CardinalBuoy")]
        public Boolean? radarConspicuous {
            get {
                return _radarConspicuous;
            }

            set {
                SetValue(ref _radarConspicuous, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("CardinalBuoy")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("CardinalBuoy")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        private marksNavigationalSystemOf? _marksNavigationalSystemOf = default;
        [Category("CardinalBuoy")]
        public marksNavigationalSystemOf? marksNavigationalSystemOf {
            get {
                return _marksNavigationalSystemOf;
            }

            set {
                SetValue(ref _marksNavigationalSystemOf, value);
            }
        }

        [Category("CardinalBuoy")]
        public ObservableCollection<colour> colour { get; set; } = new();

        private colourPattern? _colourPattern = default;
        [Category("CardinalBuoy")]
        public colourPattern? colourPattern {
            get {
                return _colourPattern;
            }

            set {
                SetValue(ref _colourPattern, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("CardinalBuoy")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private topmarkViewModel? _topmark;
        [Category("CardinalBuoy")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public topmarkViewModel? topmark {
            get {
                return _topmark;
            }

            set {
                SetValue(ref _topmark, value);
            }
        }

        [Category("CardinalBuoy")]
        public ObservableCollection<information> information { get; set; } = new();

        private String _pictorialRepresentation = string.Empty;
        [Category("CardinalBuoy")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        public class CardinalBuoyRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["CardinalBuoy"];
        }

        public void Load(DomainModel.S501.FeatureTypes.CardinalBuoy instance) {
            categoryOfCardinalMark = instance.categoryOfCardinalMark;
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            scaleMinimum = instance.scaleMinimum;
            natureOfConstruction.Clear();
            if (instance.natureOfConstruction is not null)
                foreach (var e in instance.natureOfConstruction)
                    natureOfConstruction.Add(e);
            buoyShape = instance.buoyShape;
            verticalLength = instance.verticalLength;
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            radarConspicuous = instance.radarConspicuous;
            reportedDate = instance.reportedDate;
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
            colour.Clear();
            if (instance.colour is not null)
                foreach (var e in instance.colour)
                    colour.Add(e);
            colourPattern = instance.colourPattern;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            topmark = new();
            if (instance.topmark != null) {
                topmark = new();
                topmark.Load(instance.topmark);
            }

            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            pictorialRepresentation = instance.pictorialRepresentation;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.CardinalBuoy
            {
                categoryOfCardinalMark = this.categoryOfCardinalMark,
                fixedDateRange = this.fixedDateRange?.Model,
                featureName = this.featureName.ToList(),
                scaleMinimum = this.scaleMinimum,
                natureOfConstruction = this.natureOfConstruction.ToList(),
                buoyShape = this.buoyShape,
                verticalLength = this.verticalLength,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                status = this.status.ToList(),
                radarConspicuous = this.radarConspicuous,
                reportedDate = this.reportedDate,
                periodicDateRange = this.periodicDateRange.ToList(),
                marksNavigationalSystemOf = this.marksNavigationalSystemOf,
                colour = this.colour.ToList(),
                colourPattern = this.colourPattern,
                sourceIdentification = this.sourceIdentification?.Model,
                topmark = this.topmark?.Model,
                information = this.information.ToList(),
                pictorialRepresentation = this.pictorialRepresentation,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.CardinalBuoy Model => new()
        {
            categoryOfCardinalMark = this._categoryOfCardinalMark,
            fixedDateRange = this._fixedDateRange?.Model,
            featureName = this.featureName.ToList(),
            scaleMinimum = this._scaleMinimum,
            natureOfConstruction = this.natureOfConstruction.ToList(),
            buoyShape = this._buoyShape,
            verticalLength = this._verticalLength,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            status = this.status.ToList(),
            radarConspicuous = this._radarConspicuous,
            reportedDate = this._reportedDate,
            periodicDateRange = this.periodicDateRange.ToList(),
            marksNavigationalSystemOf = this._marksNavigationalSystemOf,
            colour = this.colour.ToList(),
            colourPattern = this._colourPattern,
            sourceIdentification = this._sourceIdentification?.Model,
            topmark = this._topmark?.Model,
            information = this.information.ToList(),
            pictorialRepresentation = this._pictorialRepresentation,
        };

        public CardinalBuoyViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(natureOfConstruction));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(colour));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Cardinal Buoy";
    }

    [CategoryOrder("SafeWaterBuoy", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class SafeWaterBuoyViewModel : ViewModelBase {
        private buoyShape _buoyShape;
        [Category("SafeWaterBuoy")]
        public buoyShape buoyShape {
            get {
                return _buoyShape;
            }

            set {
                SetValue(ref _buoyShape, value);
            }
        }

        [Category("SafeWaterBuoy")]
        public ObservableCollection<colour> colour { get; set; } = new();

        private Decimal? _verticalLength = default;
        [Category("SafeWaterBuoy")]
        public Decimal? verticalLength {
            get {
                return _verticalLength;
            }

            set {
                SetValue(ref _verticalLength, value);
            }
        }

        private String _pictorialRepresentation = string.Empty;
        [Category("SafeWaterBuoy")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        [Category("SafeWaterBuoy")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        private topmarkViewModel? _topmark;
        [Category("SafeWaterBuoy")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public topmarkViewModel? topmark {
            get {
                return _topmark;
            }

            set {
                SetValue(ref _topmark, value);
            }
        }

        [Category("SafeWaterBuoy")]
        public ObservableCollection<status> status { get; set; } = new();

        private marksNavigationalSystemOf? _marksNavigationalSystemOf = default;
        [Category("SafeWaterBuoy")]
        public marksNavigationalSystemOf? marksNavigationalSystemOf {
            get {
                return _marksNavigationalSystemOf;
            }

            set {
                SetValue(ref _marksNavigationalSystemOf, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("SafeWaterBuoy")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("SafeWaterBuoy")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("SafeWaterBuoy")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("SafeWaterBuoy")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        [Category("SafeWaterBuoy")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private String _interoperabilityIdentifier = string.Empty;
        [Category("SafeWaterBuoy")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("SafeWaterBuoy")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private colourPattern? _colourPattern = default;
        [Category("SafeWaterBuoy")]
        public colourPattern? colourPattern {
            get {
                return _colourPattern;
            }

            set {
                SetValue(ref _colourPattern, value);
            }
        }

        private Boolean? _radarConspicuous = default;
        [Category("SafeWaterBuoy")]
        public Boolean? radarConspicuous {
            get {
                return _radarConspicuous;
            }

            set {
                SetValue(ref _radarConspicuous, value);
            }
        }

        [Category("SafeWaterBuoy")]
        public ObservableCollection<information> information { get; set; } = new();

        public class SafeWaterBuoyRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["SafeWaterBuoy"];
        }

        public void Load(DomainModel.S501.FeatureTypes.SafeWaterBuoy instance) {
            buoyShape = instance.buoyShape;
            colour.Clear();
            if (instance.colour is not null)
                foreach (var e in instance.colour)
                    colour.Add(e);
            verticalLength = instance.verticalLength;
            pictorialRepresentation = instance.pictorialRepresentation;
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            topmark = new();
            if (instance.topmark != null) {
                topmark = new();
                topmark.Load(instance.topmark);
            }

            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            scaleMinimum = instance.scaleMinimum;
            natureOfConstruction.Clear();
            if (instance.natureOfConstruction is not null)
                foreach (var e in instance.natureOfConstruction)
                    natureOfConstruction.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            reportedDate = instance.reportedDate;
            colourPattern = instance.colourPattern;
            radarConspicuous = instance.radarConspicuous;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.SafeWaterBuoy
            {
                buoyShape = this.buoyShape,
                colour = this.colour.ToList(),
                verticalLength = this.verticalLength,
                pictorialRepresentation = this.pictorialRepresentation,
                periodicDateRange = this.periodicDateRange.ToList(),
                topmark = this.topmark?.Model,
                status = this.status.ToList(),
                marksNavigationalSystemOf = this.marksNavigationalSystemOf,
                sourceIdentification = this.sourceIdentification?.Model,
                fixedDateRange = this.fixedDateRange?.Model,
                scaleMinimum = this.scaleMinimum,
                natureOfConstruction = this.natureOfConstruction.ToList(),
                featureName = this.featureName.ToList(),
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                reportedDate = this.reportedDate,
                colourPattern = this.colourPattern,
                radarConspicuous = this.radarConspicuous,
                information = this.information.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.SafeWaterBuoy Model => new()
        {
            buoyShape = this._buoyShape,
            colour = this.colour.ToList(),
            verticalLength = this._verticalLength,
            pictorialRepresentation = this._pictorialRepresentation,
            periodicDateRange = this.periodicDateRange.ToList(),
            topmark = this._topmark?.Model,
            status = this.status.ToList(),
            marksNavigationalSystemOf = this._marksNavigationalSystemOf,
            sourceIdentification = this._sourceIdentification?.Model,
            fixedDateRange = this._fixedDateRange?.Model,
            scaleMinimum = this._scaleMinimum,
            natureOfConstruction = this.natureOfConstruction.ToList(),
            featureName = this.featureName.ToList(),
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            reportedDate = this._reportedDate,
            colourPattern = this._colourPattern,
            radarConspicuous = this._radarConspicuous,
            information = this.information.ToList(),
        };

        public SafeWaterBuoyViewModel() : base() {
            colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(colour));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(natureOfConstruction));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Safe Water Buoy";
    }

    [CategoryOrder("RadioStation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class RadioStationViewModel : ViewModelBase {
        [Category("RadioStation")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("RadioStation")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("RadioStation")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("RadioStation")]
        public ObservableCollection<information> information { get; set; } = new();

        private frequencyPairViewModel? _frequencyPair;
        [Category("RadioStation")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public frequencyPairViewModel? frequencyPair {
            get {
                return _frequencyPair;
            }

            set {
                SetValue(ref _frequencyPair, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("RadioStation")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private String _callsign = string.Empty;
        [Category("RadioStation")]
        public String callsign {
            get {
                return _callsign;
            }

            set {
                SetValue(ref _callsign, value);
            }
        }

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("RadioStation")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private String _communicationChannel = string.Empty;
        [Category("RadioStation")]
        public String communicationChannel {
            get {
                return _communicationChannel;
            }

            set {
                SetValue(ref _communicationChannel, value);
            }
        }

        [Category("RadioStation")]
        public ObservableCollection<status> status { get; set; } = new();

        [Category("RadioStation")]
        public ObservableCollection<categoryOfRadioStation> categoryOfRadioStation { get; set; } = new();

        [Category("RadioStation")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        private Decimal? _estimatedRangeofTransmission = default;
        [Category("RadioStation")]
        public Decimal? estimatedRangeofTransmission {
            get {
                return _estimatedRangeofTransmission;
            }

            set {
                SetValue(ref _estimatedRangeofTransmission, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("RadioStation")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        public class RadioStationRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["RadioStation"];
        }

        public void Load(DomainModel.S501.FeatureTypes.RadioStation instance) {
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            scaleMinimum = instance.scaleMinimum;
            reportedDate = instance.reportedDate;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            frequencyPair = new();
            if (instance.frequencyPair != null) {
                frequencyPair = new();
                frequencyPair.Load(instance.frequencyPair);
            }

            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            callsign = instance.callsign;
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            communicationChannel = instance.communicationChannel;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            categoryOfRadioStation.Clear();
            if (instance.categoryOfRadioStation is not null)
                foreach (var e in instance.categoryOfRadioStation)
                    categoryOfRadioStation.Add(e);
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            estimatedRangeofTransmission = instance.estimatedRangeofTransmission;
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.RadioStation
            {
                featureName = this.featureName.ToList(),
                scaleMinimum = this.scaleMinimum,
                reportedDate = this.reportedDate,
                information = this.information.ToList(),
                frequencyPair = this.frequencyPair?.Model,
                sourceIdentification = this.sourceIdentification?.Model,
                callsign = this.callsign,
                fixedDateRange = this.fixedDateRange?.Model,
                communicationChannel = this.communicationChannel,
                status = this.status.ToList(),
                categoryOfRadioStation = this.categoryOfRadioStation.ToList(),
                periodicDateRange = this.periodicDateRange.ToList(),
                estimatedRangeofTransmission = this.estimatedRangeofTransmission,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.RadioStation Model => new()
        {
            featureName = this.featureName.ToList(),
            scaleMinimum = this._scaleMinimum,
            reportedDate = this._reportedDate,
            information = this.information.ToList(),
            frequencyPair = this._frequencyPair?.Model,
            sourceIdentification = this._sourceIdentification?.Model,
            callsign = this._callsign,
            fixedDateRange = this._fixedDateRange?.Model,
            communicationChannel = this._communicationChannel,
            status = this.status.ToList(),
            categoryOfRadioStation = this.categoryOfRadioStation.ToList(),
            periodicDateRange = this.periodicDateRange.ToList(),
            estimatedRangeofTransmission = this._estimatedRangeofTransmission,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
        };

        public RadioStationViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            categoryOfRadioStation.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(categoryOfRadioStation));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
        }

        public override string? ToString() => $"Radio Station";
    }

    [CategoryOrder("MilitaryExerciseAirspace", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class MilitaryExerciseAirspaceViewModel : ViewModelBase {
        [Category("MilitaryExerciseAirspace")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        [Category("MilitaryExerciseAirspace")]
        public ObservableCollection<information> information { get; set; } = new();

        private String _pictorialRepresentation = string.Empty;
        [Category("MilitaryExerciseAirspace")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        private String _controllingAuthority = string.Empty;
        [Category("MilitaryExerciseAirspace")]
        public String controllingAuthority {
            get {
                return _controllingAuthority;
            }

            set {
                SetValue(ref _controllingAuthority, value);
            }
        }

        private String _activePeriod = string.Empty;
        [Category("MilitaryExerciseAirspace")]
        public String activePeriod {
            get {
                return _activePeriod;
            }

            set {
                SetValue(ref _activePeriod, value);
            }
        }

        private altitudeViewModel? _altitude;
        [Category("MilitaryExerciseAirspace")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public altitudeViewModel? altitude {
            get {
                return _altitude;
            }

            set {
                SetValue(ref _altitude, value);
            }
        }

        private String _agencyResponsibleForProduction = string.Empty;
        [Category("MilitaryExerciseAirspace")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        private flightLevelViewModel? _flightLevel;
        [Category("MilitaryExerciseAirspace")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public flightLevelViewModel? flightLevel {
            get {
                return _flightLevel;
            }

            set {
                SetValue(ref _flightLevel, value);
            }
        }

        public class MilitaryExerciseAirspaceRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["MilitaryExerciseAirspace"];
        }

        public void Load(DomainModel.S501.FeatureTypes.MilitaryExerciseAirspace instance) {
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            pictorialRepresentation = instance.pictorialRepresentation;
            controllingAuthority = instance.controllingAuthority;
            activePeriod = instance.activePeriod;
            altitude = new();
            if (instance.altitude != null) {
                altitude = new();
                altitude.Load(instance.altitude);
            }

            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            flightLevel = new();
            if (instance.flightLevel != null) {
                flightLevel = new();
                flightLevel.Load(instance.flightLevel);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.MilitaryExerciseAirspace
            {
                featureName = this.featureName.ToList(),
                information = this.information.ToList(),
                pictorialRepresentation = this.pictorialRepresentation,
                controllingAuthority = this.controllingAuthority,
                activePeriod = this.activePeriod,
                altitude = this.altitude?.Model,
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                flightLevel = this.flightLevel?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.MilitaryExerciseAirspace Model => new()
        {
            featureName = this.featureName.ToList(),
            information = this.information.ToList(),
            pictorialRepresentation = this._pictorialRepresentation,
            controllingAuthority = this._controllingAuthority,
            activePeriod = this._activePeriod,
            altitude = this._altitude?.Model,
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            flightLevel = this._flightLevel?.Model,
        };

        public MilitaryExerciseAirspaceViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Military Exercise Airspace";
    }

    [CategoryOrder("ContiguousZone", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ContiguousZoneViewModel : ViewModelBase {
        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("ContiguousZone")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("ContiguousZone")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("ContiguousZone")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("ContiguousZone")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("ContiguousZone")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("ContiguousZone")]
        public ObservableCollection<status> status { get; set; } = new();

        private Boolean? _inDispute = default;
        [Category("ContiguousZone")]
        public Boolean? inDispute {
            get {
                return _inDispute;
            }

            set {
                SetValue(ref _inDispute, value);
            }
        }

        [Category("ContiguousZone")]
        public ObservableCollection<String> nationality { get; set; } = new();

        [Category("ContiguousZone")]
        public ObservableCollection<String> nationalMaritimeAuthority { get; set; } = new();

        [Category("ContiguousZone")]
        public ObservableCollection<information> information { get; set; } = new();

        public class ContiguousZoneRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["ContiguousZone"];
        }

        public void Load(DomainModel.S501.FeatureTypes.ContiguousZone instance) {
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            scaleMinimum = instance.scaleMinimum;
            reportedDate = instance.reportedDate;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            inDispute = instance.inDispute;
            nationality.Clear();
            if (instance.nationality is not null)
                foreach (var e in instance.nationality)
                    nationality.Add(e);
            nationalMaritimeAuthority.Clear();
            if (instance.nationalMaritimeAuthority is not null)
                foreach (var e in instance.nationalMaritimeAuthority)
                    nationalMaritimeAuthority.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.ContiguousZone
            {
                sourceIdentification = this.sourceIdentification?.Model,
                fixedDateRange = this.fixedDateRange?.Model,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                scaleMinimum = this.scaleMinimum,
                reportedDate = this.reportedDate,
                status = this.status.ToList(),
                inDispute = this.inDispute,
                nationality = this.nationality.ToList(),
                nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
                information = this.information.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.ContiguousZone Model => new()
        {
            sourceIdentification = this._sourceIdentification?.Model,
            fixedDateRange = this._fixedDateRange?.Model,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            scaleMinimum = this._scaleMinimum,
            reportedDate = this._reportedDate,
            status = this.status.ToList(),
            inDispute = this._inDispute,
            nationality = this.nationality.ToList(),
            nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
            information = this.information.ToList(),
        };

        public ContiguousZoneViewModel() : base() {
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            nationality.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(nationality));
            };
            nationalMaritimeAuthority.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(nationalMaritimeAuthority));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Contiguous Zone";
    }

    [CategoryOrder("NormalBaseline", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class NormalBaselineViewModel : ViewModelBase {
        [Category("NormalBaseline")]
        public ObservableCollection<information> information { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("NormalBaseline")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("NormalBaseline")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private String _nationality = string.Empty;
        [Category("NormalBaseline")]
        public String nationality {
            get {
                return _nationality;
            }

            set {
                SetValue(ref _nationality, value);
            }
        }

        private String _agencyResponsibleForProduction = string.Empty;
        [Category("NormalBaseline")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        private status? _status = default;
        [Category("NormalBaseline")]
        public status? status {
            get {
                return _status;
            }

            set {
                SetValue(ref _status, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("NormalBaseline")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        public class NormalBaselineRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["NormalBaseline"];
        }

        public void Load(DomainModel.S501.FeatureTypes.NormalBaseline instance) {
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            scaleMinimum = instance.scaleMinimum;
            reportedDate = instance.reportedDate;
            nationality = instance.nationality;
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            status = instance.status;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.NormalBaseline
            {
                information = this.information.ToList(),
                scaleMinimum = this.scaleMinimum,
                reportedDate = this.reportedDate,
                nationality = this.nationality,
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                status = this.status,
                sourceIdentification = this.sourceIdentification?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.NormalBaseline Model => new()
        {
            information = this.information.ToList(),
            scaleMinimum = this._scaleMinimum,
            reportedDate = this._reportedDate,
            nationality = this._nationality,
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            status = this._status,
            sourceIdentification = this._sourceIdentification?.Model,
        };

        public NormalBaselineViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Normal Baseline";
    }

    [CategoryOrder("CableArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class CableAreaViewModel : ViewModelBase {
        [Category("CableArea")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("CableArea")]
        public ObservableCollection<status> status { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("CableArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("CableArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        [Category("CableArea")]
        public ObservableCollection<vesselSpeedLimit> vesselSpeedLimit { get; set; } = new();

        [Category("CableArea")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private DateOnly? _reportedDate = default;
        [Category("CableArea")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("CableArea")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("CableArea")]
        public ObservableCollection<restriction> restriction { get; set; } = new();

        private String _interoperabilityIdentifier = string.Empty;
        [Category("CableArea")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        [Category("CableArea")]
        public ObservableCollection<categoryOfCable> categoryOfCable { get; set; } = new();

        public class CableAreaRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["CableArea"];
        }

        public void Load(DomainModel.S501.FeatureTypes.CableArea instance) {
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            vesselSpeedLimit.Clear();
            if (instance.vesselSpeedLimit is not null)
                foreach (var e in instance.vesselSpeedLimit)
                    vesselSpeedLimit.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            reportedDate = instance.reportedDate;
            scaleMinimum = instance.scaleMinimum;
            restriction.Clear();
            if (instance.restriction is not null)
                foreach (var e in instance.restriction)
                    restriction.Add(e);
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            categoryOfCable.Clear();
            if (instance.categoryOfCable is not null)
                foreach (var e in instance.categoryOfCable)
                    categoryOfCable.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.CableArea
            {
                information = this.information.ToList(),
                status = this.status.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                sourceIdentification = this.sourceIdentification?.Model,
                vesselSpeedLimit = this.vesselSpeedLimit.ToList(),
                featureName = this.featureName.ToList(),
                reportedDate = this.reportedDate,
                scaleMinimum = this.scaleMinimum,
                restriction = this.restriction.ToList(),
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                categoryOfCable = this.categoryOfCable.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.CableArea Model => new()
        {
            information = this.information.ToList(),
            status = this.status.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            sourceIdentification = this._sourceIdentification?.Model,
            vesselSpeedLimit = this.vesselSpeedLimit.ToList(),
            featureName = this.featureName.ToList(),
            reportedDate = this._reportedDate,
            scaleMinimum = this._scaleMinimum,
            restriction = this.restriction.ToList(),
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            categoryOfCable = this.categoryOfCable.ToList(),
        };

        public CableAreaViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            vesselSpeedLimit.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(vesselSpeedLimit));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(restriction));
            };
            categoryOfCable.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(categoryOfCable));
            };
        }

        public override string? ToString() => $"Cable Area";
    }

    [CategoryOrder("ContinentalShelfArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ContinentalShelfAreaViewModel : ViewModelBase {
        private status? _status = default;
        [Category("ContinentalShelfArea")]
        public status? status {
            get {
                return _status;
            }

            set {
                SetValue(ref _status, value);
            }
        }

        private Boolean? _inDispute = default;
        [Category("ContinentalShelfArea")]
        public Boolean? inDispute {
            get {
                return _inDispute;
            }

            set {
                SetValue(ref _inDispute, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("ContinentalShelfArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        [Category("ContinentalShelfArea")]
        public ObservableCollection<String> nationalMaritimeAuthority { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("ContinentalShelfArea")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("ContinentalShelfArea")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        [Category("ContinentalShelfArea")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("ContinentalShelfArea")]
        public ObservableCollection<String> nationality { get; set; } = new();

        private String _interoperabilityIdentifier = string.Empty;
        [Category("ContinentalShelfArea")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        public class ContinentalShelfAreaRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["ContinentalShelfArea"];
        }

        public void Load(DomainModel.S501.FeatureTypes.ContinentalShelfArea instance) {
            status = instance.status;
            inDispute = instance.inDispute;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            nationalMaritimeAuthority.Clear();
            if (instance.nationalMaritimeAuthority is not null)
                foreach (var e in instance.nationalMaritimeAuthority)
                    nationalMaritimeAuthority.Add(e);
            scaleMinimum = instance.scaleMinimum;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            nationality.Clear();
            if (instance.nationality is not null)
                foreach (var e in instance.nationality)
                    nationality.Add(e);
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.ContinentalShelfArea
            {
                status = this.status,
                inDispute = this.inDispute,
                sourceIdentification = this.sourceIdentification?.Model,
                nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
                scaleMinimum = this.scaleMinimum,
                featureName = this.featureName.ToList(),
                information = this.information.ToList(),
                nationality = this.nationality.ToList(),
                interoperabilityIdentifier = this.interoperabilityIdentifier,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.ContinentalShelfArea Model => new()
        {
            status = this._status,
            inDispute = this._inDispute,
            sourceIdentification = this._sourceIdentification?.Model,
            nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
            scaleMinimum = this._scaleMinimum,
            featureName = this.featureName.ToList(),
            information = this.information.ToList(),
            nationality = this.nationality.ToList(),
            interoperabilityIdentifier = this._interoperabilityIdentifier,
        };

        public ContinentalShelfAreaViewModel() : base() {
            nationalMaritimeAuthority.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(nationalMaritimeAuthority));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            nationality.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(nationality));
            };
        }

        public override string? ToString() => $"Continental Shelf Area";
    }

    [CategoryOrder("InternalWaters", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class InternalWatersViewModel : ViewModelBase {
        [Category("InternalWaters")]
        public ObservableCollection<String> nationality { get; set; } = new();

        [Category("InternalWaters")]
        public ObservableCollection<String> nationalMaritimeAuthority { get; set; } = new();

        private Boolean? _inDispute = default;
        [Category("InternalWaters")]
        public Boolean? inDispute {
            get {
                return _inDispute;
            }

            set {
                SetValue(ref _inDispute, value);
            }
        }

        private String _agencyResponsibleForProduction = string.Empty;
        [Category("InternalWaters")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("InternalWaters")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        [Category("InternalWaters")]
        public ObservableCollection<information> information { get; set; } = new();

        private Boolean? _lineTypeGeodesic = default;
        [Category("InternalWaters")]
        public Boolean? lineTypeGeodesic {
            get {
                return _lineTypeGeodesic;
            }

            set {
                SetValue(ref _lineTypeGeodesic, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InternalWaters")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private status? _status = default;
        [Category("InternalWaters")]
        public status? status {
            get {
                return _status;
            }

            set {
                SetValue(ref _status, value);
            }
        }

        public class InternalWatersRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["InternalWaters"];
        }

        public void Load(DomainModel.S501.FeatureTypes.InternalWaters instance) {
            nationality.Clear();
            if (instance.nationality is not null)
                foreach (var e in instance.nationality)
                    nationality.Add(e);
            nationalMaritimeAuthority.Clear();
            if (instance.nationalMaritimeAuthority is not null)
                foreach (var e in instance.nationalMaritimeAuthority)
                    nationalMaritimeAuthority.Add(e);
            inDispute = instance.inDispute;
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            lineTypeGeodesic = instance.lineTypeGeodesic;
            reportedDate = instance.reportedDate;
            status = instance.status;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.InternalWaters
            {
                nationality = this.nationality.ToList(),
                nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
                inDispute = this.inDispute,
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                sourceIdentification = this.sourceIdentification?.Model,
                information = this.information.ToList(),
                lineTypeGeodesic = this.lineTypeGeodesic,
                reportedDate = this.reportedDate,
                status = this.status,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.InternalWaters Model => new()
        {
            nationality = this.nationality.ToList(),
            nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
            inDispute = this._inDispute,
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            sourceIdentification = this._sourceIdentification?.Model,
            information = this.information.ToList(),
            lineTypeGeodesic = this._lineTypeGeodesic,
            reportedDate = this._reportedDate,
            status = this._status,
        };

        public InternalWatersViewModel() : base() {
            nationality.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(nationality));
            };
            nationalMaritimeAuthority.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(nationalMaritimeAuthority));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Internal Waters";
    }

    [CategoryOrder("AdministrationArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class AdministrationAreaViewModel : ViewModelBase {
        private String _pictorialRepresentation = string.Empty;
        [Category("AdministrationArea")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        private Boolean? _inDispute = default;
        [Category("AdministrationArea")]
        public Boolean? inDispute {
            get {
                return _inDispute;
            }

            set {
                SetValue(ref _inDispute, value);
            }
        }

        private jurisdiction _jurisdiction;
        [Category("AdministrationArea")]
        public jurisdiction jurisdiction {
            get {
                return _jurisdiction;
            }

            set {
                SetValue(ref _jurisdiction, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("AdministrationArea")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("AdministrationArea")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("AdministrationArea")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        [Category("AdministrationArea")]
        public ObservableCollection<String> nationality { get; set; } = new();

        public class AdministrationAreaRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["AdministrationArea"];
        }

        public void Load(DomainModel.S501.FeatureTypes.AdministrationArea instance) {
            pictorialRepresentation = instance.pictorialRepresentation;
            inDispute = instance.inDispute;
            jurisdiction = instance.jurisdiction;
            scaleMinimum = instance.scaleMinimum;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            nationality.Clear();
            if (instance.nationality is not null)
                foreach (var e in instance.nationality)
                    nationality.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.AdministrationArea
            {
                pictorialRepresentation = this.pictorialRepresentation,
                inDispute = this.inDispute,
                jurisdiction = this.jurisdiction,
                scaleMinimum = this.scaleMinimum,
                information = this.information.ToList(),
                featureName = this.featureName.ToList(),
                nationality = this.nationality.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.AdministrationArea Model => new()
        {
            pictorialRepresentation = this._pictorialRepresentation,
            inDispute = this._inDispute,
            jurisdiction = this._jurisdiction,
            scaleMinimum = this._scaleMinimum,
            information = this.information.ToList(),
            featureName = this.featureName.ToList(),
            nationality = this.nationality.ToList(),
        };

        public AdministrationAreaViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            nationality.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(nationality));
            };
        }

        public override string? ToString() => $"Administration Area";
    }

    [CategoryOrder("Bollard", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class BollardViewModel : ViewModelBase {
        private Int32? _scaleMinimum = default;
        [Category("Bollard")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("Bollard")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("Bollard")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("Bollard")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("Bollard")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("Bollard")]
        public ObservableCollection<information> information { get; set; } = new();

        private String _pictorialRepresentation = string.Empty;
        [Category("Bollard")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        private condition? _condition = default;
        [Category("Bollard")]
        public condition? condition {
            get {
                return _condition;
            }

            set {
                SetValue(ref _condition, value);
            }
        }

        [Category("Bollard")]
        public ObservableCollection<status> status { get; set; } = new();

        public class BollardRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["Bollard"];
        }

        public void Load(DomainModel.S501.FeatureTypes.Bollard instance) {
            scaleMinimum = instance.scaleMinimum;
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            reportedDate = instance.reportedDate;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            pictorialRepresentation = instance.pictorialRepresentation;
            condition = instance.condition;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.Bollard
            {
                scaleMinimum = this.scaleMinimum,
                periodicDateRange = this.periodicDateRange.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                reportedDate = this.reportedDate,
                information = this.information.ToList(),
                pictorialRepresentation = this.pictorialRepresentation,
                condition = this.condition,
                status = this.status.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.Bollard Model => new()
        {
            scaleMinimum = this._scaleMinimum,
            periodicDateRange = this.periodicDateRange.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            reportedDate = this._reportedDate,
            information = this.information.ToList(),
            pictorialRepresentation = this._pictorialRepresentation,
            condition = this._condition,
            status = this.status.ToList(),
        };

        public BollardViewModel() : base() {
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
        }

        public override string? ToString() => $"Bollard";
    }

    [CategoryOrder("Dolphin", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class DolphinViewModel : ViewModelBase {
        private String _pictorialRepresentation = string.Empty;
        [Category("Dolphin")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        private Decimal? _verticalLength = default;
        [Category("Dolphin")]
        public Decimal? verticalLength {
            get {
                return _verticalLength;
            }

            set {
                SetValue(ref _verticalLength, value);
            }
        }

        private colourPattern? _colourPattern = default;
        [Category("Dolphin")]
        public colourPattern? colourPattern {
            get {
                return _colourPattern;
            }

            set {
                SetValue(ref _colourPattern, value);
            }
        }

        private categoryOfDolphin _categoryOfDolphin;
        [Category("Dolphin")]
        public categoryOfDolphin categoryOfDolphin {
            get {
                return _categoryOfDolphin;
            }

            set {
                SetValue(ref _categoryOfDolphin, value);
            }
        }

        [Category("Dolphin")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        private visualProminence? _visualProminence = default;
        [Category("Dolphin")]
        public visualProminence? visualProminence {
            get {
                return _visualProminence;
            }

            set {
                SetValue(ref _visualProminence, value);
            }
        }

        [Category("Dolphin")]
        public ObservableCollection<colour> colour { get; set; } = new();

        [Category("Dolphin")]
        public ObservableCollection<information> information { get; set; } = new();

        private Decimal? _elevation = default;
        [Category("Dolphin")]
        public Decimal? elevation {
            get {
                return _elevation;
            }

            set {
                SetValue(ref _elevation, value);
            }
        }

        [Category("Dolphin")]
        public ObservableCollection<status> status { get; set; } = new();

        [Category("Dolphin")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private Boolean? _radarConspicuous = default;
        [Category("Dolphin")]
        public Boolean? radarConspicuous {
            get {
                return _radarConspicuous;
            }

            set {
                SetValue(ref _radarConspicuous, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("Dolphin")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private condition? _condition = default;
        [Category("Dolphin")]
        public condition? condition {
            get {
                return _condition;
            }

            set {
                SetValue(ref _condition, value);
            }
        }

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("Dolphin")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("Dolphin")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private Decimal? _height = default;
        [Category("Dolphin")]
        public Decimal? height {
            get {
                return _height;
            }

            set {
                SetValue(ref _height, value);
            }
        }

        [Category("Dolphin")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        public class DolphinRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["Dolphin"];
        }

        public void Load(DomainModel.S501.FeatureTypes.Dolphin instance) {
            pictorialRepresentation = instance.pictorialRepresentation;
            verticalLength = instance.verticalLength;
            colourPattern = instance.colourPattern;
            categoryOfDolphin = instance.categoryOfDolphin;
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            visualProminence = instance.visualProminence;
            colour.Clear();
            if (instance.colour is not null)
                foreach (var e in instance.colour)
                    colour.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            elevation = instance.elevation;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            radarConspicuous = instance.radarConspicuous;
            reportedDate = instance.reportedDate;
            condition = instance.condition;
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            scaleMinimum = instance.scaleMinimum;
            height = instance.height;
            natureOfConstruction.Clear();
            if (instance.natureOfConstruction is not null)
                foreach (var e in instance.natureOfConstruction)
                    natureOfConstruction.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.Dolphin
            {
                pictorialRepresentation = this.pictorialRepresentation,
                verticalLength = this.verticalLength,
                colourPattern = this.colourPattern,
                categoryOfDolphin = this.categoryOfDolphin,
                periodicDateRange = this.periodicDateRange.ToList(),
                visualProminence = this.visualProminence,
                colour = this.colour.ToList(),
                information = this.information.ToList(),
                elevation = this.elevation,
                status = this.status.ToList(),
                featureName = this.featureName.ToList(),
                radarConspicuous = this.radarConspicuous,
                reportedDate = this.reportedDate,
                condition = this.condition,
                fixedDateRange = this.fixedDateRange?.Model,
                scaleMinimum = this.scaleMinimum,
                height = this.height,
                natureOfConstruction = this.natureOfConstruction.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.Dolphin Model => new()
        {
            pictorialRepresentation = this._pictorialRepresentation,
            verticalLength = this._verticalLength,
            colourPattern = this._colourPattern,
            categoryOfDolphin = this._categoryOfDolphin,
            periodicDateRange = this.periodicDateRange.ToList(),
            visualProminence = this._visualProminence,
            colour = this.colour.ToList(),
            information = this.information.ToList(),
            elevation = this._elevation,
            status = this.status.ToList(),
            featureName = this.featureName.ToList(),
            radarConspicuous = this._radarConspicuous,
            reportedDate = this._reportedDate,
            condition = this._condition,
            fixedDateRange = this._fixedDateRange?.Model,
            scaleMinimum = this._scaleMinimum,
            height = this._height,
            natureOfConstruction = this.natureOfConstruction.ToList(),
        };

        public DolphinViewModel() : base() {
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(colour));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(natureOfConstruction));
            };
        }

        public override string? ToString() => $"Dolphin";
    }

    [CategoryOrder("RadarRange", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class RadarRangeViewModel : ViewModelBase {
        [Category("RadarRange")]
        public ObservableCollection<information> information { get; set; } = new();

        private String _interoperabilityIdentifier = string.Empty;
        [Category("RadarRange")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        [Category("RadarRange")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("RadarRange")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("RadarRange")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("RadarRange")]
        public ObservableCollection<String> communicationChannel { get; set; } = new();

        [Category("RadarRange")]
        public ObservableCollection<status> status { get; set; } = new();

        public class RadarRangeRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["RadarRange"];
        }

        public void Load(DomainModel.S501.FeatureTypes.RadarRange instance) {
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            scaleMinimum = instance.scaleMinimum;
            communicationChannel.Clear();
            if (instance.communicationChannel is not null)
                foreach (var e in instance.communicationChannel)
                    communicationChannel.Add(e);
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.RadarRange
            {
                information = this.information.ToList(),
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                scaleMinimum = this.scaleMinimum,
                communicationChannel = this.communicationChannel.ToList(),
                status = this.status.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.RadarRange Model => new()
        {
            information = this.information.ToList(),
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            scaleMinimum = this._scaleMinimum,
            communicationChannel = this.communicationChannel.ToList(),
            status = this.status.ToList(),
        };

        public RadarRangeViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            communicationChannel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(communicationChannel));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
        }

        public override string? ToString() => $"Radar Range";
    }

    [CategoryOrder("IsolatedDangerBeacon", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class IsolatedDangerBeaconViewModel : ViewModelBase {
        private condition? _condition = default;
        [Category("IsolatedDangerBeacon")]
        public condition? condition {
            get {
                return _condition;
            }

            set {
                SetValue(ref _condition, value);
            }
        }

        [Category("IsolatedDangerBeacon")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        private DateOnly? _reportedDate = default;
        [Category("IsolatedDangerBeacon")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private beaconShape _beaconShape;
        [Category("IsolatedDangerBeacon")]
        public beaconShape beaconShape {
            get {
                return _beaconShape;
            }

            set {
                SetValue(ref _beaconShape, value);
            }
        }

        private Boolean? _radarConspicuous = default;
        [Category("IsolatedDangerBeacon")]
        public Boolean? radarConspicuous {
            get {
                return _radarConspicuous;
            }

            set {
                SetValue(ref _radarConspicuous, value);
            }
        }

        [Category("IsolatedDangerBeacon")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        [Category("IsolatedDangerBeacon")]
        public ObservableCollection<status> status { get; set; } = new();

        [Category("IsolatedDangerBeacon")]
        public ObservableCollection<information> information { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("IsolatedDangerBeacon")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private Decimal? _elevation = default;
        [Category("IsolatedDangerBeacon")]
        public Decimal? elevation {
            get {
                return _elevation;
            }

            set {
                SetValue(ref _elevation, value);
            }
        }

        private String _agencyResponsibleForProduction = string.Empty;
        [Category("IsolatedDangerBeacon")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        private String _pictorialRepresentation = string.Empty;
        [Category("IsolatedDangerBeacon")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("IsolatedDangerBeacon")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private topmarkViewModel? _topmark;
        [Category("IsolatedDangerBeacon")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public topmarkViewModel? topmark {
            get {
                return _topmark;
            }

            set {
                SetValue(ref _topmark, value);
            }
        }

        private marksNavigationalSystemOf? _marksNavigationalSystemOf = default;
        [Category("IsolatedDangerBeacon")]
        public marksNavigationalSystemOf? marksNavigationalSystemOf {
            get {
                return _marksNavigationalSystemOf;
            }

            set {
                SetValue(ref _marksNavigationalSystemOf, value);
            }
        }

        private Decimal? _height = default;
        [Category("IsolatedDangerBeacon")]
        public Decimal? height {
            get {
                return _height;
            }

            set {
                SetValue(ref _height, value);
            }
        }

        private visualProminence? _visualProminence = default;
        [Category("IsolatedDangerBeacon")]
        public visualProminence? visualProminence {
            get {
                return _visualProminence;
            }

            set {
                SetValue(ref _visualProminence, value);
            }
        }

        private Decimal? _verticalLength = default;
        [Category("IsolatedDangerBeacon")]
        public Decimal? verticalLength {
            get {
                return _verticalLength;
            }

            set {
                SetValue(ref _verticalLength, value);
            }
        }

        [Category("IsolatedDangerBeacon")]
        public ObservableCollection<colour> colour { get; set; } = new();

        [Category("IsolatedDangerBeacon")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("IsolatedDangerBeacon")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("IsolatedDangerBeacon")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private colourPattern? _colourPattern = default;
        [Category("IsolatedDangerBeacon")]
        public colourPattern? colourPattern {
            get {
                return _colourPattern;
            }

            set {
                SetValue(ref _colourPattern, value);
            }
        }

        public class IsolatedDangerBeaconRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["IsolatedDangerBeacon"];
        }

        public void Load(DomainModel.S501.FeatureTypes.IsolatedDangerBeacon instance) {
            condition = instance.condition;
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            reportedDate = instance.reportedDate;
            beaconShape = instance.beaconShape;
            radarConspicuous = instance.radarConspicuous;
            natureOfConstruction.Clear();
            if (instance.natureOfConstruction is not null)
                foreach (var e in instance.natureOfConstruction)
                    natureOfConstruction.Add(e);
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            scaleMinimum = instance.scaleMinimum;
            elevation = instance.elevation;
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            pictorialRepresentation = instance.pictorialRepresentation;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            topmark = new();
            if (instance.topmark != null) {
                topmark = new();
                topmark.Load(instance.topmark);
            }

            marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
            height = instance.height;
            visualProminence = instance.visualProminence;
            verticalLength = instance.verticalLength;
            colour.Clear();
            if (instance.colour is not null)
                foreach (var e in instance.colour)
                    colour.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            colourPattern = instance.colourPattern;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.IsolatedDangerBeacon
            {
                condition = this.condition,
                periodicDateRange = this.periodicDateRange.ToList(),
                reportedDate = this.reportedDate,
                beaconShape = this.beaconShape,
                radarConspicuous = this.radarConspicuous,
                natureOfConstruction = this.natureOfConstruction.ToList(),
                status = this.status.ToList(),
                information = this.information.ToList(),
                scaleMinimum = this.scaleMinimum,
                elevation = this.elevation,
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                pictorialRepresentation = this.pictorialRepresentation,
                sourceIdentification = this.sourceIdentification?.Model,
                topmark = this.topmark?.Model,
                marksNavigationalSystemOf = this.marksNavigationalSystemOf,
                height = this.height,
                visualProminence = this.visualProminence,
                verticalLength = this.verticalLength,
                colour = this.colour.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                colourPattern = this.colourPattern,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.IsolatedDangerBeacon Model => new()
        {
            condition = this._condition,
            periodicDateRange = this.periodicDateRange.ToList(),
            reportedDate = this._reportedDate,
            beaconShape = this._beaconShape,
            radarConspicuous = this._radarConspicuous,
            natureOfConstruction = this.natureOfConstruction.ToList(),
            status = this.status.ToList(),
            information = this.information.ToList(),
            scaleMinimum = this._scaleMinimum,
            elevation = this._elevation,
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            pictorialRepresentation = this._pictorialRepresentation,
            sourceIdentification = this._sourceIdentification?.Model,
            topmark = this._topmark?.Model,
            marksNavigationalSystemOf = this._marksNavigationalSystemOf,
            height = this._height,
            visualProminence = this._visualProminence,
            verticalLength = this._verticalLength,
            colour = this.colour.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            colourPattern = this._colourPattern,
        };

        public IsolatedDangerBeaconViewModel() : base() {
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(natureOfConstruction));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(colour));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
        }

        public override string? ToString() => $"Isolated Danger Beacon";
    }

    [CategoryOrder("IsolatedDangerBuoy", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class IsolatedDangerBuoyViewModel : ViewModelBase {
        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("IsolatedDangerBuoy")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private topmarkViewModel? _topmark;
        [Category("IsolatedDangerBuoy")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public topmarkViewModel? topmark {
            get {
                return _topmark;
            }

            set {
                SetValue(ref _topmark, value);
            }
        }

        [Category("IsolatedDangerBuoy")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private Boolean? _radarConspicuous = default;
        [Category("IsolatedDangerBuoy")]
        public Boolean? radarConspicuous {
            get {
                return _radarConspicuous;
            }

            set {
                SetValue(ref _radarConspicuous, value);
            }
        }

        private Decimal? _verticalLength = default;
        [Category("IsolatedDangerBuoy")]
        public Decimal? verticalLength {
            get {
                return _verticalLength;
            }

            set {
                SetValue(ref _verticalLength, value);
            }
        }

        [Category("IsolatedDangerBuoy")]
        public ObservableCollection<colour> colour { get; set; } = new();

        private String _interoperabilityIdentifier = string.Empty;
        [Category("IsolatedDangerBuoy")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        [Category("IsolatedDangerBuoy")]
        public ObservableCollection<information> information { get; set; } = new();

        private marksNavigationalSystemOf? _marksNavigationalSystemOf = default;
        [Category("IsolatedDangerBuoy")]
        public marksNavigationalSystemOf? marksNavigationalSystemOf {
            get {
                return _marksNavigationalSystemOf;
            }

            set {
                SetValue(ref _marksNavigationalSystemOf, value);
            }
        }

        private buoyShape _buoyShape;
        [Category("IsolatedDangerBuoy")]
        public buoyShape buoyShape {
            get {
                return _buoyShape;
            }

            set {
                SetValue(ref _buoyShape, value);
            }
        }

        [Category("IsolatedDangerBuoy")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        private colourPattern? _colourPattern = default;
        [Category("IsolatedDangerBuoy")]
        public colourPattern? colourPattern {
            get {
                return _colourPattern;
            }

            set {
                SetValue(ref _colourPattern, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("IsolatedDangerBuoy")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private String _pictorialRepresentation = string.Empty;
        [Category("IsolatedDangerBuoy")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        [Category("IsolatedDangerBuoy")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        [Category("IsolatedDangerBuoy")]
        public ObservableCollection<status> status { get; set; } = new();

        public class IsolatedDangerBuoyRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["IsolatedDangerBuoy"];
        }

        public void Load(DomainModel.S501.FeatureTypes.IsolatedDangerBuoy instance) {
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            topmark = new();
            if (instance.topmark != null) {
                topmark = new();
                topmark.Load(instance.topmark);
            }

            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            radarConspicuous = instance.radarConspicuous;
            verticalLength = instance.verticalLength;
            colour.Clear();
            if (instance.colour is not null)
                foreach (var e in instance.colour)
                    colour.Add(e);
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
            buoyShape = instance.buoyShape;
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            colourPattern = instance.colourPattern;
            scaleMinimum = instance.scaleMinimum;
            pictorialRepresentation = instance.pictorialRepresentation;
            natureOfConstruction.Clear();
            if (instance.natureOfConstruction is not null)
                foreach (var e in instance.natureOfConstruction)
                    natureOfConstruction.Add(e);
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.IsolatedDangerBuoy
            {
                fixedDateRange = this.fixedDateRange?.Model,
                topmark = this.topmark?.Model,
                featureName = this.featureName.ToList(),
                radarConspicuous = this.radarConspicuous,
                verticalLength = this.verticalLength,
                colour = this.colour.ToList(),
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                information = this.information.ToList(),
                marksNavigationalSystemOf = this.marksNavigationalSystemOf,
                buoyShape = this.buoyShape,
                periodicDateRange = this.periodicDateRange.ToList(),
                colourPattern = this.colourPattern,
                scaleMinimum = this.scaleMinimum,
                pictorialRepresentation = this.pictorialRepresentation,
                natureOfConstruction = this.natureOfConstruction.ToList(),
                status = this.status.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.IsolatedDangerBuoy Model => new()
        {
            fixedDateRange = this._fixedDateRange?.Model,
            topmark = this._topmark?.Model,
            featureName = this.featureName.ToList(),
            radarConspicuous = this._radarConspicuous,
            verticalLength = this._verticalLength,
            colour = this.colour.ToList(),
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            information = this.information.ToList(),
            marksNavigationalSystemOf = this._marksNavigationalSystemOf,
            buoyShape = this._buoyShape,
            periodicDateRange = this.periodicDateRange.ToList(),
            colourPattern = this._colourPattern,
            scaleMinimum = this._scaleMinimum,
            pictorialRepresentation = this._pictorialRepresentation,
            natureOfConstruction = this.natureOfConstruction.ToList(),
            status = this.status.ToList(),
        };

        public IsolatedDangerBuoyViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(colour));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(natureOfConstruction));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
        }

        public override string? ToString() => $"Isolated Danger Buoy";
    }

    [CategoryOrder("SubmarineTransitLane", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class SubmarineTransitLaneViewModel : ViewModelBase {
        [Category("SubmarineTransitLane")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private String _interoperabilityIdentifier = string.Empty;
        [Category("SubmarineTransitLane")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private String _nationality = string.Empty;
        [Category("SubmarineTransitLane")]
        public String nationality {
            get {
                return _nationality;
            }

            set {
                SetValue(ref _nationality, value);
            }
        }

        private Int32? _bottomVerticalSafetySeparation = default;
        [Category("SubmarineTransitLane")]
        public Int32? bottomVerticalSafetySeparation {
            get {
                return _bottomVerticalSafetySeparation;
            }

            set {
                SetValue(ref _bottomVerticalSafetySeparation, value);
            }
        }

        [Category("SubmarineTransitLane")]
        public ObservableCollection<vesselSpeedLimit> vesselSpeedLimit { get; set; } = new();

        private String _controllingAuthority = string.Empty;
        [Category("SubmarineTransitLane")]
        public String controllingAuthority {
            get {
                return _controllingAuthority;
            }

            set {
                SetValue(ref _controllingAuthority, value);
            }
        }

        [Category("SubmarineTransitLane")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("SubmarineTransitLane")]
        public ObservableCollection<restriction> restriction { get; set; } = new();

        private String _agencyResponsibleForProduction = string.Empty;
        [Category("SubmarineTransitLane")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        private Int32? _minimumSafeDepth = default;
        [Category("SubmarineTransitLane")]
        public Int32? minimumSafeDepth {
            get {
                return _minimumSafeDepth;
            }

            set {
                SetValue(ref _minimumSafeDepth, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("SubmarineTransitLane")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        public class SubmarineTransitLaneRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["SubmarineTransitLane"];
        }

        public void Load(DomainModel.S501.FeatureTypes.SubmarineTransitLane instance) {
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            nationality = instance.nationality;
            bottomVerticalSafetySeparation = instance.bottomVerticalSafetySeparation;
            vesselSpeedLimit.Clear();
            if (instance.vesselSpeedLimit is not null)
                foreach (var e in instance.vesselSpeedLimit)
                    vesselSpeedLimit.Add(e);
            controllingAuthority = instance.controllingAuthority;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            restriction.Clear();
            if (instance.restriction is not null)
                foreach (var e in instance.restriction)
                    restriction.Add(e);
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            minimumSafeDepth = instance.minimumSafeDepth;
            scaleMinimum = instance.scaleMinimum;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.SubmarineTransitLane
            {
                featureName = this.featureName.ToList(),
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                nationality = this.nationality,
                bottomVerticalSafetySeparation = this.bottomVerticalSafetySeparation,
                vesselSpeedLimit = this.vesselSpeedLimit.ToList(),
                controllingAuthority = this.controllingAuthority,
                information = this.information.ToList(),
                restriction = this.restriction.ToList(),
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                minimumSafeDepth = this.minimumSafeDepth,
                scaleMinimum = this.scaleMinimum,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.SubmarineTransitLane Model => new()
        {
            featureName = this.featureName.ToList(),
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            nationality = this._nationality,
            bottomVerticalSafetySeparation = this._bottomVerticalSafetySeparation,
            vesselSpeedLimit = this.vesselSpeedLimit.ToList(),
            controllingAuthority = this._controllingAuthority,
            information = this.information.ToList(),
            restriction = this.restriction.ToList(),
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            minimumSafeDepth = this._minimumSafeDepth,
            scaleMinimum = this._scaleMinimum,
        };

        public SubmarineTransitLaneViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            vesselSpeedLimit.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(vesselSpeedLimit));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(restriction));
            };
        }

        public override string? ToString() => $"Submarine Transit Lane";
    }

    [CategoryOrder("MaritimeSafetyInformationArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class MaritimeSafetyInformationAreaViewModel : ViewModelBase {
        private DateOnly? _reportedDate = default;
        [Category("MaritimeSafetyInformationArea")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("MaritimeSafetyInformationArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        [Category("MaritimeSafetyInformationArea")]
        public ObservableCollection<information> information { get; set; } = new();

        private String _agencyResponsibleForProduction = string.Empty;
        [Category("MaritimeSafetyInformationArea")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        [Category("MaritimeSafetyInformationArea")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        public class MaritimeSafetyInformationAreaRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["MaritimeSafetyInformationArea"];
        }

        public void Load(DomainModel.S501.FeatureTypes.MaritimeSafetyInformationArea instance) {
            reportedDate = instance.reportedDate;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.MaritimeSafetyInformationArea
            {
                reportedDate = this.reportedDate,
                sourceIdentification = this.sourceIdentification?.Model,
                information = this.information.ToList(),
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                featureName = this.featureName.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.MaritimeSafetyInformationArea Model => new()
        {
            reportedDate = this._reportedDate,
            sourceIdentification = this._sourceIdentification?.Model,
            information = this.information.ToList(),
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            featureName = this.featureName.ToList(),
        };

        public MaritimeSafetyInformationAreaViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
        }

        public override string? ToString() => $"MaritimeSafetyInformationArea (missing Name)";
    }

    [CategoryOrder("AirspaceRestriction", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class AirspaceRestrictionViewModel : ViewModelBase {
        [Category("AirspaceRestriction")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private String _agencyResponsibleForProduction = string.Empty;
        [Category("AirspaceRestriction")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        private flightLevelViewModel? _flightLevel;
        [Category("AirspaceRestriction")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public flightLevelViewModel? flightLevel {
            get {
                return _flightLevel;
            }

            set {
                SetValue(ref _flightLevel, value);
            }
        }

        private String _controllingAuthority = string.Empty;
        [Category("AirspaceRestriction")]
        public String controllingAuthority {
            get {
                return _controllingAuthority;
            }

            set {
                SetValue(ref _controllingAuthority, value);
            }
        }

        private altitudeRangeViewModel? _altitudeRange;
        [Category("AirspaceRestriction")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public altitudeRangeViewModel? altitudeRange {
            get {
                return _altitudeRange;
            }

            set {
                SetValue(ref _altitudeRange, value);
            }
        }

        [Category("AirspaceRestriction")]
        public ObservableCollection<information> information { get; set; } = new();

        private verticalDatum? _verticalDatum = default;
        [Category("AirspaceRestriction")]
        public verticalDatum? verticalDatum {
            get {
                return _verticalDatum;
            }

            set {
                SetValue(ref _verticalDatum, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("AirspaceRestriction")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("AirspaceRestriction")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private heightLengthUnits? _heightLengthUnits = default;
        [Category("AirspaceRestriction")]
        public heightLengthUnits? heightLengthUnits {
            get {
                return _heightLengthUnits;
            }

            set {
                SetValue(ref _heightLengthUnits, value);
            }
        }

        private catagoryOfAirspaceRestriction? _catagoryOfAirspaceRestriction = default;
        [Category("AirspaceRestriction")]
        public catagoryOfAirspaceRestriction? catagoryOfAirspaceRestriction {
            get {
                return _catagoryOfAirspaceRestriction;
            }

            set {
                SetValue(ref _catagoryOfAirspaceRestriction, value);
            }
        }

        public class AirspaceRestrictionRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["AirspaceRestriction"];
        }

        public void Load(DomainModel.S501.FeatureTypes.AirspaceRestriction instance) {
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            flightLevel = new();
            if (instance.flightLevel != null) {
                flightLevel = new();
                flightLevel.Load(instance.flightLevel);
            }

            controllingAuthority = instance.controllingAuthority;
            altitudeRange = new();
            if (instance.altitudeRange != null) {
                altitudeRange = new();
                altitudeRange.Load(instance.altitudeRange);
            }

            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            verticalDatum = instance.verticalDatum;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            reportedDate = instance.reportedDate;
            heightLengthUnits = instance.heightLengthUnits;
            catagoryOfAirspaceRestriction = instance.catagoryOfAirspaceRestriction;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.AirspaceRestriction
            {
                featureName = this.featureName.ToList(),
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                flightLevel = this.flightLevel?.Model,
                controllingAuthority = this.controllingAuthority,
                altitudeRange = this.altitudeRange?.Model,
                information = this.information.ToList(),
                verticalDatum = this.verticalDatum,
                sourceIdentification = this.sourceIdentification?.Model,
                reportedDate = this.reportedDate,
                heightLengthUnits = this.heightLengthUnits,
                catagoryOfAirspaceRestriction = this.catagoryOfAirspaceRestriction,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.AirspaceRestriction Model => new()
        {
            featureName = this.featureName.ToList(),
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            flightLevel = this._flightLevel?.Model,
            controllingAuthority = this._controllingAuthority,
            altitudeRange = this._altitudeRange?.Model,
            information = this.information.ToList(),
            verticalDatum = this._verticalDatum,
            sourceIdentification = this._sourceIdentification?.Model,
            reportedDate = this._reportedDate,
            heightLengthUnits = this._heightLengthUnits,
            catagoryOfAirspaceRestriction = this._catagoryOfAirspaceRestriction,
        };

        public AirspaceRestrictionViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Airspace Restriction";
    }

    [CategoryOrder("Sounding", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class SoundingViewModel : ViewModelBase {
        private status? _status = default;
        [Category("Sounding")]
        public status? status {
            get {
                return _status;
            }

            set {
                SetValue(ref _status, value);
            }
        }

        [Category("Sounding")]
        public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("Sounding")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("Sounding")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("Sounding")]
        public ObservableCollection<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = new();

        [Category("Sounding")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("Sounding")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("Sounding")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private Boolean? _displayUncertainties = default;
        [Category("Sounding")]
        public Boolean? displayUncertainties {
            get {
                return _displayUncertainties;
            }

            set {
                SetValue(ref _displayUncertainties, value);
            }
        }

        public class SoundingRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["Sounding"];
        }

        public void Load(DomainModel.S501.FeatureTypes.Sounding instance) {
            status = instance.status;
            techniqueOfVerticalMeasurement.Clear();
            if (instance.techniqueOfVerticalMeasurement is not null)
                foreach (var e in instance.techniqueOfVerticalMeasurement)
                    techniqueOfVerticalMeasurement.Add(e);
            scaleMinimum = instance.scaleMinimum;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            qualityOfVerticalMeasurement.Clear();
            if (instance.qualityOfVerticalMeasurement is not null)
                foreach (var e in instance.qualityOfVerticalMeasurement)
                    qualityOfVerticalMeasurement.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            reportedDate = instance.reportedDate;
            displayUncertainties = instance.displayUncertainties;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.Sounding
            {
                status = this.status,
                techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
                scaleMinimum = this.scaleMinimum,
                information = this.information.ToList(),
                qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement.ToList(),
                featureName = this.featureName.ToList(),
                sourceIdentification = this.sourceIdentification?.Model,
                reportedDate = this.reportedDate,
                displayUncertainties = this.displayUncertainties,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.Sounding Model => new()
        {
            status = this._status,
            techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
            scaleMinimum = this._scaleMinimum,
            information = this.information.ToList(),
            qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement.ToList(),
            featureName = this.featureName.ToList(),
            sourceIdentification = this._sourceIdentification?.Model,
            reportedDate = this._reportedDate,
            displayUncertainties = this._displayUncertainties,
        };

        public SoundingViewModel() : base() {
            techniqueOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(techniqueOfVerticalMeasurement));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            qualityOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(qualityOfVerticalMeasurement));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
        }

        public override string? ToString() => $"Sounding";
    }

    [CategoryOrder("TrafficSeparationSchemeBoundary", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class TrafficSeparationSchemeBoundaryViewModel : ViewModelBase {
        private String _interoperabilityIdentifier = string.Empty;
        [Category("TrafficSeparationSchemeBoundary")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        [Category("TrafficSeparationSchemeBoundary")]
        public ObservableCollection<status> status { get; set; } = new();

        private DateOnly? _reportedDate = default;
        [Category("TrafficSeparationSchemeBoundary")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("TrafficSeparationSchemeBoundary")]
        public ObservableCollection<information> information { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("TrafficSeparationSchemeBoundary")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("TrafficSeparationSchemeBoundary")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("TrafficSeparationSchemeBoundary")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        public class TrafficSeparationSchemeBoundaryRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["TrafficSeparationSchemeBoundary"];
        }

        public void Load(DomainModel.S501.FeatureTypes.TrafficSeparationSchemeBoundary instance) {
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            reportedDate = instance.reportedDate;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            scaleMinimum = instance.scaleMinimum;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.TrafficSeparationSchemeBoundary
            {
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                status = this.status.ToList(),
                reportedDate = this.reportedDate,
                information = this.information.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                sourceIdentification = this.sourceIdentification?.Model,
                scaleMinimum = this.scaleMinimum,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.TrafficSeparationSchemeBoundary Model => new()
        {
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            status = this.status.ToList(),
            reportedDate = this._reportedDate,
            information = this.information.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            sourceIdentification = this._sourceIdentification?.Model,
            scaleMinimum = this._scaleMinimum,
        };

        public TrafficSeparationSchemeBoundaryViewModel() : base() {
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Traffic Separation Scheme Boundary";
    }

    [CategoryOrder("DumpingGround", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class DumpingGroundViewModel : ViewModelBase {
        [Category("DumpingGround")]
        public ObservableCollection<categoryOfDumpingGround> categoryOfDumpingGround { get; set; } = new();

        [Category("DumpingGround")]
        public ObservableCollection<restriction> restriction { get; set; } = new();

        [Category("DumpingGround")]
        public ObservableCollection<status> status { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("DumpingGround")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private DateOnly? _dateDisused = default;
        [Category("DumpingGround")]
        public DateOnly? dateDisused {
            get {
                return _dateDisused;
            }

            set {
                SetValue(ref _dateDisused, value);
            }
        }

        [Category("DumpingGround")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        [Category("DumpingGround")]
        public ObservableCollection<information> information { get; set; } = new();

        public class DumpingGroundRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["DumpingGround"];
        }

        public void Load(DomainModel.S501.FeatureTypes.DumpingGround instance) {
            categoryOfDumpingGround.Clear();
            if (instance.categoryOfDumpingGround is not null)
                foreach (var e in instance.categoryOfDumpingGround)
                    categoryOfDumpingGround.Add(e);
            restriction.Clear();
            if (instance.restriction is not null)
                foreach (var e in instance.restriction)
                    restriction.Add(e);
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            scaleMinimum = instance.scaleMinimum;
            dateDisused = instance.dateDisused;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.DumpingGround
            {
                categoryOfDumpingGround = this.categoryOfDumpingGround.ToList(),
                restriction = this.restriction.ToList(),
                status = this.status.ToList(),
                scaleMinimum = this.scaleMinimum,
                dateDisused = this.dateDisused,
                featureName = this.featureName.ToList(),
                information = this.information.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.DumpingGround Model => new()
        {
            categoryOfDumpingGround = this.categoryOfDumpingGround.ToList(),
            restriction = this.restriction.ToList(),
            status = this.status.ToList(),
            scaleMinimum = this._scaleMinimum,
            dateDisused = this._dateDisused,
            featureName = this.featureName.ToList(),
            information = this.information.ToList(),
        };

        public DumpingGroundViewModel() : base() {
            categoryOfDumpingGround.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(categoryOfDumpingGround));
            };
            restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(restriction));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Dumping Ground";
    }

    [CategoryOrder("AirportAirfield", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class AirportAirfieldViewModel : ViewModelBase {
        [Category("AirportAirfield")]
        public ObservableCollection<categoryOfAirportAirfield> categoryOfAirportAirfield { get; set; } = new();

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("AirportAirfield")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        [Category("AirportAirfield")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        private condition? _condition = default;
        [Category("AirportAirfield")]
        public condition? condition {
            get {
                return _condition;
            }

            set {
                SetValue(ref _condition, value);
            }
        }

        private Int32? _runwayLength = default;
        [Category("AirportAirfield")]
        public Int32? runwayLength {
            get {
                return _runwayLength;
            }

            set {
                SetValue(ref _runwayLength, value);
            }
        }

        private heightLengthUnits? _heightLengthUnits = default;
        [Category("AirportAirfield")]
        public heightLengthUnits? heightLengthUnits {
            get {
                return _heightLengthUnits;
            }

            set {
                SetValue(ref _heightLengthUnits, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("AirportAirfield")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private String _controllingAuthority = string.Empty;
        [Category("AirportAirfield")]
        public String controllingAuthority {
            get {
                return _controllingAuthority;
            }

            set {
                SetValue(ref _controllingAuthority, value);
            }
        }

        private Decimal? _elevation = default;
        [Category("AirportAirfield")]
        public Decimal? elevation {
            get {
                return _elevation;
            }

            set {
                SetValue(ref _elevation, value);
            }
        }

        private verticalDatum? _verticalDatum = default;
        [Category("AirportAirfield")]
        public verticalDatum? verticalDatum {
            get {
                return _verticalDatum;
            }

            set {
                SetValue(ref _verticalDatum, value);
            }
        }

        private String _agencyResponsibleForProduction = string.Empty;
        [Category("AirportAirfield")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        private String _pictorialRepresentation = string.Empty;
        [Category("AirportAirfield")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        private String _iCAOcode = string.Empty;
        [Category("AirportAirfield")]
        public String iCAOcode {
            get {
                return _iCAOcode;
            }

            set {
                SetValue(ref _iCAOcode, value);
            }
        }

        [Category("AirportAirfield")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("AirportAirfield")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        [Category("AirportAirfield")]
        public ObservableCollection<status> status { get; set; } = new();

        private DateOnly? _reportedDate = default;
        [Category("AirportAirfield")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("AirportAirfield")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        public class AirportAirfieldRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["AirportAirfield"];
        }

        public void Load(DomainModel.S501.FeatureTypes.AirportAirfield instance) {
            categoryOfAirportAirfield.Clear();
            if (instance.categoryOfAirportAirfield is not null)
                foreach (var e in instance.categoryOfAirportAirfield)
                    categoryOfAirportAirfield.Add(e);
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            condition = instance.condition;
            runwayLength = instance.runwayLength;
            heightLengthUnits = instance.heightLengthUnits;
            scaleMinimum = instance.scaleMinimum;
            controllingAuthority = instance.controllingAuthority;
            elevation = instance.elevation;
            verticalDatum = instance.verticalDatum;
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            pictorialRepresentation = instance.pictorialRepresentation;
            iCAOcode = instance.iCAOcode;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            reportedDate = instance.reportedDate;
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.AirportAirfield
            {
                categoryOfAirportAirfield = this.categoryOfAirportAirfield.ToList(),
                sourceIdentification = this.sourceIdentification?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                condition = this.condition,
                runwayLength = this.runwayLength,
                heightLengthUnits = this.heightLengthUnits,
                scaleMinimum = this.scaleMinimum,
                controllingAuthority = this.controllingAuthority,
                elevation = this.elevation,
                verticalDatum = this.verticalDatum,
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                pictorialRepresentation = this.pictorialRepresentation,
                iCAOcode = this.iCAOcode,
                information = this.information.ToList(),
                featureName = this.featureName.ToList(),
                status = this.status.ToList(),
                reportedDate = this.reportedDate,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.AirportAirfield Model => new()
        {
            categoryOfAirportAirfield = this.categoryOfAirportAirfield.ToList(),
            sourceIdentification = this._sourceIdentification?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            condition = this._condition,
            runwayLength = this._runwayLength,
            heightLengthUnits = this._heightLengthUnits,
            scaleMinimum = this._scaleMinimum,
            controllingAuthority = this._controllingAuthority,
            elevation = this._elevation,
            verticalDatum = this._verticalDatum,
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            pictorialRepresentation = this._pictorialRepresentation,
            iCAOcode = this._iCAOcode,
            information = this.information.ToList(),
            featureName = this.featureName.ToList(),
            status = this.status.ToList(),
            reportedDate = this._reportedDate,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
        };

        public AirportAirfieldViewModel() : base() {
            categoryOfAirportAirfield.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(categoryOfAirportAirfield));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
        }

        public override string? ToString() => $"Airport/Airfield";
    }

    [CategoryOrder("FoulGround", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class FoulGroundViewModel : ViewModelBase {
        [Category("FoulGround")]
        public ObservableCollection<status> status { get; set; } = new();

        private Decimal? _valueOfSounding = default;
        [Category("FoulGround")]
        public Decimal? valueOfSounding {
            get {
                return _valueOfSounding;
            }

            set {
                SetValue(ref _valueOfSounding, value);
            }
        }

        [Category("FoulGround")]
        public ObservableCollection<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = new();

        [Category("FoulGround")]
        public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = new();

        private DateOnly? _reportedDate = default;
        [Category("FoulGround")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("FoulGround")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private verticalUncertaintyViewModel? _verticalUncertainty;
        [Category("FoulGround")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public verticalUncertaintyViewModel? verticalUncertainty {
            get {
                return _verticalUncertainty;
            }

            set {
                SetValue(ref _verticalUncertainty, value);
            }
        }

        [Category("FoulGround")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        [Category("FoulGround")]
        public ObservableCollection<information> information { get; set; } = new();

        public class FoulGroundRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["FoulGround"];
        }

        public void Load(DomainModel.S501.FeatureTypes.FoulGround instance) {
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            valueOfSounding = instance.valueOfSounding;
            qualityOfVerticalMeasurement.Clear();
            if (instance.qualityOfVerticalMeasurement is not null)
                foreach (var e in instance.qualityOfVerticalMeasurement)
                    qualityOfVerticalMeasurement.Add(e);
            techniqueOfVerticalMeasurement.Clear();
            if (instance.techniqueOfVerticalMeasurement is not null)
                foreach (var e in instance.techniqueOfVerticalMeasurement)
                    techniqueOfVerticalMeasurement.Add(e);
            reportedDate = instance.reportedDate;
            scaleMinimum = instance.scaleMinimum;
            verticalUncertainty = new();
            if (instance.verticalUncertainty != null) {
                verticalUncertainty = new();
                verticalUncertainty.Load(instance.verticalUncertainty);
            }

            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.FoulGround
            {
                status = this.status.ToList(),
                valueOfSounding = this.valueOfSounding,
                qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement.ToList(),
                techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
                reportedDate = this.reportedDate,
                scaleMinimum = this.scaleMinimum,
                verticalUncertainty = this.verticalUncertainty?.Model,
                featureName = this.featureName.ToList(),
                information = this.information.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.FoulGround Model => new()
        {
            status = this.status.ToList(),
            valueOfSounding = this._valueOfSounding,
            qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement.ToList(),
            techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
            reportedDate = this._reportedDate,
            scaleMinimum = this._scaleMinimum,
            verticalUncertainty = this._verticalUncertainty?.Model,
            featureName = this.featureName.ToList(),
            information = this.information.ToList(),
        };

        public FoulGroundViewModel() : base() {
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            qualityOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(qualityOfVerticalMeasurement));
            };
            techniqueOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(techniqueOfVerticalMeasurement));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Foul Ground";
    }

    [CategoryOrder("LightAirObstruction", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class LightAirObstructionViewModel : ViewModelBase {
        private String _pictorialRepresentation = string.Empty;
        [Category("LightAirObstruction")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        private Decimal? _valueOfNominalRange = default;
        [Category("LightAirObstruction")]
        public Decimal? valueOfNominalRange {
            get {
                return _valueOfNominalRange;
            }

            set {
                SetValue(ref _valueOfNominalRange, value);
            }
        }

        private multiplicityOfFeaturesViewModel? _multiplicityOfFeatures;
        [Category("LightAirObstruction")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public multiplicityOfFeaturesViewModel? multiplicityOfFeatures {
            get {
                return _multiplicityOfFeatures;
            }

            set {
                SetValue(ref _multiplicityOfFeatures, value);
            }
        }

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("LightAirObstruction")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("LightAirObstruction")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        private rythmOfLightViewModel? _rythmOfLight;
        [Category("LightAirObstruction")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public rythmOfLightViewModel? rythmOfLight {
            get {
                return _rythmOfLight;
            }

            set {
                SetValue(ref _rythmOfLight, value);
            }
        }

        [Category("LightAirObstruction")]
        public ObservableCollection<status> status { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("LightAirObstruction")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private Int32? _flareBearing = default;
        [Category("LightAirObstruction")]
        public Int32? flareBearing {
            get {
                return _flareBearing;
            }

            set {
                SetValue(ref _flareBearing, value);
            }
        }

        private Decimal? _height = default;
        [Category("LightAirObstruction")]
        public Decimal? height {
            get {
                return _height;
            }

            set {
                SetValue(ref _height, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("LightAirObstruction")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private heightLengthUnits? _heightLengthUnits = default;
        [Category("LightAirObstruction")]
        public heightLengthUnits? heightLengthUnits {
            get {
                return _heightLengthUnits;
            }

            set {
                SetValue(ref _heightLengthUnits, value);
            }
        }

        [Category("LightAirObstruction")]
        public ObservableCollection<lightVisibility> lightVisibility { get; set; } = new();

        [Category("LightAirObstruction")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private Decimal? _relativeHorizontalAccuracy = default;
        [Category("LightAirObstruction")]
        public Decimal? relativeHorizontalAccuracy {
            get {
                return _relativeHorizontalAccuracy;
            }

            set {
                SetValue(ref _relativeHorizontalAccuracy, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("LightAirObstruction")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("LightAirObstruction")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private verticalDatum? _verticalDatum = default;
        [Category("LightAirObstruction")]
        public verticalDatum? verticalDatum {
            get {
                return _verticalDatum;
            }

            set {
                SetValue(ref _verticalDatum, value);
            }
        }

        private Decimal? _relativeVerticalAccuracy = default;
        [Category("LightAirObstruction")]
        public Decimal? relativeVerticalAccuracy {
            get {
                return _relativeVerticalAccuracy;
            }

            set {
                SetValue(ref _relativeVerticalAccuracy, value);
            }
        }

        private exhibitionConditionOfLight? _exhibitionConditionOfLight = default;
        [Category("LightAirObstruction")]
        public exhibitionConditionOfLight? exhibitionConditionOfLight {
            get {
                return _exhibitionConditionOfLight;
            }

            set {
                SetValue(ref _exhibitionConditionOfLight, value);
            }
        }

        [Category("LightAirObstruction")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("LightAirObstruction")]
        public ObservableCollection<colour> colour { get; set; } = new();

        public class LightAirObstructionRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["LightAirObstruction"];
        }

        public void Load(DomainModel.S501.FeatureTypes.LightAirObstruction instance) {
            pictorialRepresentation = instance.pictorialRepresentation;
            valueOfNominalRange = instance.valueOfNominalRange;
            multiplicityOfFeatures = new();
            if (instance.multiplicityOfFeatures != null) {
                multiplicityOfFeatures = new();
                multiplicityOfFeatures.Load(instance.multiplicityOfFeatures);
            }

            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rythmOfLight = new();
            if (instance.rythmOfLight != null) {
                rythmOfLight = new();
                rythmOfLight.Load(instance.rythmOfLight);
            }

            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            scaleMinimum = instance.scaleMinimum;
            flareBearing = instance.flareBearing;
            height = instance.height;
            reportedDate = instance.reportedDate;
            heightLengthUnits = instance.heightLengthUnits;
            lightVisibility.Clear();
            if (instance.lightVisibility is not null)
                foreach (var e in instance.lightVisibility)
                    lightVisibility.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            relativeHorizontalAccuracy = instance.relativeHorizontalAccuracy;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            verticalDatum = instance.verticalDatum;
            relativeVerticalAccuracy = instance.relativeVerticalAccuracy;
            exhibitionConditionOfLight = instance.exhibitionConditionOfLight;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            colour.Clear();
            if (instance.colour is not null)
                foreach (var e in instance.colour)
                    colour.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.LightAirObstruction
            {
                pictorialRepresentation = this.pictorialRepresentation,
                valueOfNominalRange = this.valueOfNominalRange,
                multiplicityOfFeatures = this.multiplicityOfFeatures?.Model,
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rythmOfLight = this.rythmOfLight?.Model,
                status = this.status.ToList(),
                scaleMinimum = this.scaleMinimum,
                flareBearing = this.flareBearing,
                height = this.height,
                reportedDate = this.reportedDate,
                heightLengthUnits = this.heightLengthUnits,
                lightVisibility = this.lightVisibility.ToList(),
                featureName = this.featureName.ToList(),
                relativeHorizontalAccuracy = this.relativeHorizontalAccuracy,
                sourceIdentification = this.sourceIdentification?.Model,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                verticalDatum = this.verticalDatum,
                relativeVerticalAccuracy = this.relativeVerticalAccuracy,
                exhibitionConditionOfLight = this.exhibitionConditionOfLight,
                information = this.information.ToList(),
                colour = this.colour.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.LightAirObstruction Model => new()
        {
            pictorialRepresentation = this._pictorialRepresentation,
            valueOfNominalRange = this._valueOfNominalRange,
            multiplicityOfFeatures = this._multiplicityOfFeatures?.Model,
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rythmOfLight = this._rythmOfLight?.Model,
            status = this.status.ToList(),
            scaleMinimum = this._scaleMinimum,
            flareBearing = this._flareBearing,
            height = this._height,
            reportedDate = this._reportedDate,
            heightLengthUnits = this._heightLengthUnits,
            lightVisibility = this.lightVisibility.ToList(),
            featureName = this.featureName.ToList(),
            relativeHorizontalAccuracy = this._relativeHorizontalAccuracy,
            sourceIdentification = this._sourceIdentification?.Model,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            verticalDatum = this._verticalDatum,
            relativeVerticalAccuracy = this._relativeVerticalAccuracy,
            exhibitionConditionOfLight = this._exhibitionConditionOfLight,
            information = this.information.ToList(),
            colour = this.colour.ToList(),
        };

        public LightAirObstructionViewModel() : base() {
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            lightVisibility.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(lightVisibility));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(colour));
            };
        }

        public override string? ToString() => $"Light Air Obstruction";
    }

    [CategoryOrder("MooringBuoy", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class MooringBuoyViewModel : ViewModelBase {
        private Decimal? _maximumPermittedVesselLength = default;
        [Category("MooringBuoy")]
        public Decimal? maximumPermittedVesselLength {
            get {
                return _maximumPermittedVesselLength;
            }

            set {
                SetValue(ref _maximumPermittedVesselLength, value);
            }
        }

        private Decimal? _maximumPermittedDraught = default;
        [Category("MooringBuoy")]
        public Decimal? maximumPermittedDraught {
            get {
                return _maximumPermittedDraught;
            }

            set {
                SetValue(ref _maximumPermittedDraught, value);
            }
        }

        [Category("MooringBuoy")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("MooringBuoy")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        private colourPattern? _colourPattern = default;
        [Category("MooringBuoy")]
        public colourPattern? colourPattern {
            get {
                return _colourPattern;
            }

            set {
                SetValue(ref _colourPattern, value);
            }
        }

        [Category("MooringBuoy")]
        public ObservableCollection<colour> colour { get; set; } = new();

        [Category("MooringBuoy")]
        public ObservableCollection<status> status { get; set; } = new();

        [Category("MooringBuoy")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("MooringBuoy")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private buoyShape _buoyShape;
        [Category("MooringBuoy")]
        public buoyShape buoyShape {
            get {
                return _buoyShape;
            }

            set {
                SetValue(ref _buoyShape, value);
            }
        }

        private Decimal? _verticalLength = default;
        [Category("MooringBuoy")]
        public Decimal? verticalLength {
            get {
                return _verticalLength;
            }

            set {
                SetValue(ref _verticalLength, value);
            }
        }

        private String _pictorialRepresentation = string.Empty;
        [Category("MooringBuoy")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        private Boolean? _visitorsMooring = default;
        [Category("MooringBuoy")]
        public Boolean? visitorsMooring {
            get {
                return _visitorsMooring;
            }

            set {
                SetValue(ref _visitorsMooring, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("MooringBuoy")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        [Category("MooringBuoy")]
        public ObservableCollection<information> information { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("MooringBuoy")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        public class MooringBuoyRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["MooringBuoy"];
        }

        public void Load(DomainModel.S501.FeatureTypes.MooringBuoy instance) {
            maximumPermittedVesselLength = instance.maximumPermittedVesselLength;
            maximumPermittedDraught = instance.maximumPermittedDraught;
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            natureOfConstruction.Clear();
            if (instance.natureOfConstruction is not null)
                foreach (var e in instance.natureOfConstruction)
                    natureOfConstruction.Add(e);
            colourPattern = instance.colourPattern;
            colour.Clear();
            if (instance.colour is not null)
                foreach (var e in instance.colour)
                    colour.Add(e);
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            scaleMinimum = instance.scaleMinimum;
            buoyShape = instance.buoyShape;
            verticalLength = instance.verticalLength;
            pictorialRepresentation = instance.pictorialRepresentation;
            visitorsMooring = instance.visitorsMooring;
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.MooringBuoy
            {
                maximumPermittedVesselLength = this.maximumPermittedVesselLength,
                maximumPermittedDraught = this.maximumPermittedDraught,
                periodicDateRange = this.periodicDateRange.ToList(),
                natureOfConstruction = this.natureOfConstruction.ToList(),
                colourPattern = this.colourPattern,
                colour = this.colour.ToList(),
                status = this.status.ToList(),
                featureName = this.featureName.ToList(),
                scaleMinimum = this.scaleMinimum,
                buoyShape = this.buoyShape,
                verticalLength = this.verticalLength,
                pictorialRepresentation = this.pictorialRepresentation,
                visitorsMooring = this.visitorsMooring,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                information = this.information.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.MooringBuoy Model => new()
        {
            maximumPermittedVesselLength = this._maximumPermittedVesselLength,
            maximumPermittedDraught = this._maximumPermittedDraught,
            periodicDateRange = this.periodicDateRange.ToList(),
            natureOfConstruction = this.natureOfConstruction.ToList(),
            colourPattern = this._colourPattern,
            colour = this.colour.ToList(),
            status = this.status.ToList(),
            featureName = this.featureName.ToList(),
            scaleMinimum = this._scaleMinimum,
            buoyShape = this._buoyShape,
            verticalLength = this._verticalLength,
            pictorialRepresentation = this._pictorialRepresentation,
            visitorsMooring = this._visitorsMooring,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            information = this.information.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
        };

        public MooringBuoyViewModel() : base() {
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(natureOfConstruction));
            };
            colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(colour));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Mooring Buoy";
    }

    [CategoryOrder("UnderwaterAwashRock", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class UnderwaterAwashRockViewModel : ViewModelBase {
        private Decimal _valueOfSounding;
        [Category("UnderwaterAwashRock")]
        public Decimal valueOfSounding {
            get {
                return _valueOfSounding;
            }

            set {
                SetValue(ref _valueOfSounding, value);
            }
        }

        private verticalUncertaintyViewModel? _verticalUncertainty;
        [Category("UnderwaterAwashRock")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public verticalUncertaintyViewModel? verticalUncertainty {
            get {
                return _verticalUncertainty;
            }

            set {
                SetValue(ref _verticalUncertainty, value);
            }
        }

        private Decimal? _horizontalWidth = default;
        [Category("UnderwaterAwashRock")]
        public Decimal? horizontalWidth {
            get {
                return _horizontalWidth;
            }

            set {
                SetValue(ref _horizontalWidth, value);
            }
        }

        private waterLevelEffect _waterLevelEffect;
        [Category("UnderwaterAwashRock")]
        public waterLevelEffect waterLevelEffect {
            get {
                return _waterLevelEffect;
            }

            set {
                SetValue(ref _waterLevelEffect, value);
            }
        }

        private Decimal? _surroundingDepth = default;
        [Category("UnderwaterAwashRock")]
        public Decimal? surroundingDepth {
            get {
                return _surroundingDepth;
            }

            set {
                SetValue(ref _surroundingDepth, value);
            }
        }

        [Category("UnderwaterAwashRock")]
        public ObservableCollection<information> information { get; set; } = new();

        private natureOfSurface? _natureOfSurface = default;
        [Category("UnderwaterAwashRock")]
        public natureOfSurface? natureOfSurface {
            get {
                return _natureOfSurface;
            }

            set {
                SetValue(ref _natureOfSurface, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("UnderwaterAwashRock")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private Boolean? _displayUncertainties = default;
        [Category("UnderwaterAwashRock")]
        public Boolean? displayUncertainties {
            get {
                return _displayUncertainties;
            }

            set {
                SetValue(ref _displayUncertainties, value);
            }
        }

        private expositionOfSounding? _expositionOfSounding = default;
        [Category("UnderwaterAwashRock")]
        public expositionOfSounding? expositionOfSounding {
            get {
                return _expositionOfSounding;
            }

            set {
                SetValue(ref _expositionOfSounding, value);
            }
        }

        private Decimal? _defaultClearanceDepth = default;
        [Category("UnderwaterAwashRock")]
        public Decimal? defaultClearanceDepth {
            get {
                return _defaultClearanceDepth;
            }

            set {
                SetValue(ref _defaultClearanceDepth, value);
            }
        }

        [Category("UnderwaterAwashRock")]
        public ObservableCollection<status> status { get; set; } = new();

        [Category("UnderwaterAwashRock")]
        public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = new();

        private Decimal? _verticalLength = default;
        [Category("UnderwaterAwashRock")]
        public Decimal? verticalLength {
            get {
                return _verticalLength;
            }

            set {
                SetValue(ref _verticalLength, value);
            }
        }

        [Category("UnderwaterAwashRock")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private Decimal? _horizontalLength = default;
        [Category("UnderwaterAwashRock")]
        public Decimal? horizontalLength {
            get {
                return _horizontalLength;
            }

            set {
                SetValue(ref _horizontalLength, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("UnderwaterAwashRock")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("UnderwaterAwashRock")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private firstSourceInformationViewModel? _firstSourceInformation;
        [Category("UnderwaterAwashRock")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public firstSourceInformationViewModel? firstSourceInformation {
            get {
                return _firstSourceInformation;
            }

            set {
                SetValue(ref _firstSourceInformation, value);
            }
        }

        private lastSourceInformationViewModel? _lastSourceInformation;
        [Category("UnderwaterAwashRock")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public lastSourceInformationViewModel? lastSourceInformation {
            get {
                return _lastSourceInformation;
            }

            set {
                SetValue(ref _lastSourceInformation, value);
            }
        }

        private qualityOfVerticalMeasurement? _qualityOfVerticalMeasurement = default;
        [Category("UnderwaterAwashRock")]
        public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement {
            get {
                return _qualityOfVerticalMeasurement;
            }

            set {
                SetValue(ref _qualityOfVerticalMeasurement, value);
            }
        }

        public class UnderwaterAwashRockRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["UnderwaterAwashRock"];
        }

        public void Load(DomainModel.S501.FeatureTypes.UnderwaterAwashRock instance) {
            valueOfSounding = instance.valueOfSounding;
            verticalUncertainty = new();
            if (instance.verticalUncertainty != null) {
                verticalUncertainty = new();
                verticalUncertainty.Load(instance.verticalUncertainty);
            }

            horizontalWidth = instance.horizontalWidth;
            waterLevelEffect = instance.waterLevelEffect;
            surroundingDepth = instance.surroundingDepth;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            natureOfSurface = instance.natureOfSurface;
            scaleMinimum = instance.scaleMinimum;
            displayUncertainties = instance.displayUncertainties;
            expositionOfSounding = instance.expositionOfSounding;
            defaultClearanceDepth = instance.defaultClearanceDepth;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            techniqueOfVerticalMeasurement.Clear();
            if (instance.techniqueOfVerticalMeasurement is not null)
                foreach (var e in instance.techniqueOfVerticalMeasurement)
                    techniqueOfVerticalMeasurement.Add(e);
            verticalLength = instance.verticalLength;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            horizontalLength = instance.horizontalLength;
            reportedDate = instance.reportedDate;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            firstSourceInformation = new();
            if (instance.firstSourceInformation != null) {
                firstSourceInformation = new();
                firstSourceInformation.Load(instance.firstSourceInformation);
            }

            lastSourceInformation = new();
            if (instance.lastSourceInformation != null) {
                lastSourceInformation = new();
                lastSourceInformation.Load(instance.lastSourceInformation);
            }

            qualityOfVerticalMeasurement = instance.qualityOfVerticalMeasurement;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.UnderwaterAwashRock
            {
                valueOfSounding = this.valueOfSounding,
                verticalUncertainty = this.verticalUncertainty?.Model,
                horizontalWidth = this.horizontalWidth,
                waterLevelEffect = this.waterLevelEffect,
                surroundingDepth = this.surroundingDepth,
                information = this.information.ToList(),
                natureOfSurface = this.natureOfSurface,
                scaleMinimum = this.scaleMinimum,
                displayUncertainties = this.displayUncertainties,
                expositionOfSounding = this.expositionOfSounding,
                defaultClearanceDepth = this.defaultClearanceDepth,
                status = this.status.ToList(),
                techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
                verticalLength = this.verticalLength,
                featureName = this.featureName.ToList(),
                horizontalLength = this.horizontalLength,
                reportedDate = this.reportedDate,
                sourceIdentification = this.sourceIdentification?.Model,
                firstSourceInformation = this.firstSourceInformation?.Model,
                lastSourceInformation = this.lastSourceInformation?.Model,
                qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.UnderwaterAwashRock Model => new()
        {
            valueOfSounding = this._valueOfSounding,
            verticalUncertainty = this._verticalUncertainty?.Model,
            horizontalWidth = this._horizontalWidth,
            waterLevelEffect = this._waterLevelEffect,
            surroundingDepth = this._surroundingDepth,
            information = this.information.ToList(),
            natureOfSurface = this._natureOfSurface,
            scaleMinimum = this._scaleMinimum,
            displayUncertainties = this._displayUncertainties,
            expositionOfSounding = this._expositionOfSounding,
            defaultClearanceDepth = this._defaultClearanceDepth,
            status = this.status.ToList(),
            techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
            verticalLength = this._verticalLength,
            featureName = this.featureName.ToList(),
            horizontalLength = this._horizontalLength,
            reportedDate = this._reportedDate,
            sourceIdentification = this._sourceIdentification?.Model,
            firstSourceInformation = this._firstSourceInformation?.Model,
            lastSourceInformation = this._lastSourceInformation?.Model,
            qualityOfVerticalMeasurement = this._qualityOfVerticalMeasurement,
        };

        public UnderwaterAwashRockViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            techniqueOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(techniqueOfVerticalMeasurement));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
        }

        public override string? ToString() => $"Underwater/Awash Rock";
    }

    [CategoryOrder("CableOverhead", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class CableOverheadViewModel : ViewModelBase {
        private condition? _condition = default;
        [Category("CableOverhead")]
        public condition? condition {
            get {
                return _condition;
            }

            set {
                SetValue(ref _condition, value);
            }
        }

        [Category("CableOverhead")]
        public ObservableCollection<status> status { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("CableOverhead")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private verticalDatum? _verticalDatum = default;
        [Category("CableOverhead")]
        public verticalDatum? verticalDatum {
            get {
                return _verticalDatum;
            }

            set {
                SetValue(ref _verticalDatum, value);
            }
        }

        private categoryOfCable? _categoryOfCable = default;
        [Category("CableOverhead")]
        public categoryOfCable? categoryOfCable {
            get {
                return _categoryOfCable;
            }

            set {
                SetValue(ref _categoryOfCable, value);
            }
        }

        private verticalClearanceSafeViewModel? _verticalClearanceSafe;
        [Category("CableOverhead")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public verticalClearanceSafeViewModel? verticalClearanceSafe {
            get {
                return _verticalClearanceSafe;
            }

            set {
                SetValue(ref _verticalClearanceSafe, value);
            }
        }

        [Category("CableOverhead")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private DateOnly? _reportedDate = default;
        [Category("CableOverhead")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private verticalClearanceFixedViewModel? _verticalClearanceFixed;
        [Category("CableOverhead")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public verticalClearanceFixedViewModel? verticalClearanceFixed {
            get {
                return _verticalClearanceFixed;
            }

            set {
                SetValue(ref _verticalClearanceFixed, value);
            }
        }

        private multiplicityOfFeaturesViewModel? _multiplicityOfFeatures;
        [Category("CableOverhead")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public multiplicityOfFeaturesViewModel? multiplicityOfFeatures {
            get {
                return _multiplicityOfFeatures;
            }

            set {
                SetValue(ref _multiplicityOfFeatures, value);
            }
        }

        private visualProminence? _visualProminence = default;
        [Category("CableOverhead")]
        public visualProminence? visualProminence {
            get {
                return _visualProminence;
            }

            set {
                SetValue(ref _visualProminence, value);
            }
        }

        [Category("CableOverhead")]
        public ObservableCollection<information> information { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("CableOverhead")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private Boolean? _radarConspicuous = default;
        [Category("CableOverhead")]
        public Boolean? radarConspicuous {
            get {
                return _radarConspicuous;
            }

            set {
                SetValue(ref _radarConspicuous, value);
            }
        }

        private Decimal? _iceFactor = default;
        [Category("CableOverhead")]
        public Decimal? iceFactor {
            get {
                return _iceFactor;
            }

            set {
                SetValue(ref _iceFactor, value);
            }
        }

        public class CableOverheadRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["CableOverhead"];
        }

        public void Load(DomainModel.S501.FeatureTypes.CableOverhead instance) {
            condition = instance.condition;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            verticalDatum = instance.verticalDatum;
            categoryOfCable = instance.categoryOfCable;
            verticalClearanceSafe = new();
            if (instance.verticalClearanceSafe != null) {
                verticalClearanceSafe = new();
                verticalClearanceSafe.Load(instance.verticalClearanceSafe);
            }

            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            reportedDate = instance.reportedDate;
            verticalClearanceFixed = new();
            if (instance.verticalClearanceFixed != null) {
                verticalClearanceFixed = new();
                verticalClearanceFixed.Load(instance.verticalClearanceFixed);
            }

            multiplicityOfFeatures = new();
            if (instance.multiplicityOfFeatures != null) {
                multiplicityOfFeatures = new();
                multiplicityOfFeatures.Load(instance.multiplicityOfFeatures);
            }

            visualProminence = instance.visualProminence;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            scaleMinimum = instance.scaleMinimum;
            radarConspicuous = instance.radarConspicuous;
            iceFactor = instance.iceFactor;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.CableOverhead
            {
                condition = this.condition,
                status = this.status.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                verticalDatum = this.verticalDatum,
                categoryOfCable = this.categoryOfCable,
                verticalClearanceSafe = this.verticalClearanceSafe?.Model,
                featureName = this.featureName.ToList(),
                reportedDate = this.reportedDate,
                verticalClearanceFixed = this.verticalClearanceFixed?.Model,
                multiplicityOfFeatures = this.multiplicityOfFeatures?.Model,
                visualProminence = this.visualProminence,
                information = this.information.ToList(),
                scaleMinimum = this.scaleMinimum,
                radarConspicuous = this.radarConspicuous,
                iceFactor = this.iceFactor,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.CableOverhead Model => new()
        {
            condition = this._condition,
            status = this.status.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            verticalDatum = this._verticalDatum,
            categoryOfCable = this._categoryOfCable,
            verticalClearanceSafe = this._verticalClearanceSafe?.Model,
            featureName = this.featureName.ToList(),
            reportedDate = this._reportedDate,
            verticalClearanceFixed = this._verticalClearanceFixed?.Model,
            multiplicityOfFeatures = this._multiplicityOfFeatures?.Model,
            visualProminence = this._visualProminence,
            information = this.information.ToList(),
            scaleMinimum = this._scaleMinimum,
            radarConspicuous = this._radarConspicuous,
            iceFactor = this._iceFactor,
        };

        public CableOverheadViewModel() : base() {
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Cable Overhead";
    }

    [CategoryOrder("ControlledAirspace", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ControlledAirspaceViewModel : ViewModelBase {
        private controlledAirspaceClassDesignation? _controlledAirspaceClassDesignation = default;
        [Category("ControlledAirspace")]
        public controlledAirspaceClassDesignation? controlledAirspaceClassDesignation {
            get {
                return _controlledAirspaceClassDesignation;
            }

            set {
                SetValue(ref _controlledAirspaceClassDesignation, value);
            }
        }

        [Category("ControlledAirspace")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("ControlledAirspace")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private categoryOfControlledAirspace? _categoryOfControlledAirspace = default;
        [Category("ControlledAirspace")]
        public categoryOfControlledAirspace? categoryOfControlledAirspace {
            get {
                return _categoryOfControlledAirspace;
            }

            set {
                SetValue(ref _categoryOfControlledAirspace, value);
            }
        }

        private String _controllingAuthority = string.Empty;
        [Category("ControlledAirspace")]
        public String controllingAuthority {
            get {
                return _controllingAuthority;
            }

            set {
                SetValue(ref _controllingAuthority, value);
            }
        }

        private altitudeViewModel? _altitude;
        [Category("ControlledAirspace")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public altitudeViewModel? altitude {
            get {
                return _altitude;
            }

            set {
                SetValue(ref _altitude, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("ControlledAirspace")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private verticalDatum? _verticalDatum = default;
        [Category("ControlledAirspace")]
        public verticalDatum? verticalDatum {
            get {
                return _verticalDatum;
            }

            set {
                SetValue(ref _verticalDatum, value);
            }
        }

        private heightLengthUnits? _heightLengthUnits = default;
        [Category("ControlledAirspace")]
        public heightLengthUnits? heightLengthUnits {
            get {
                return _heightLengthUnits;
            }

            set {
                SetValue(ref _heightLengthUnits, value);
            }
        }

        private String _agencyResponsibleForProduction = string.Empty;
        [Category("ControlledAirspace")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("ControlledAirspace")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private flightLevelViewModel? _flightLevel;
        [Category("ControlledAirspace")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public flightLevelViewModel? flightLevel {
            get {
                return _flightLevel;
            }

            set {
                SetValue(ref _flightLevel, value);
            }
        }

        public class ControlledAirspaceRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["ControlledAirspace"];
        }

        public void Load(DomainModel.S501.FeatureTypes.ControlledAirspace instance) {
            controlledAirspaceClassDesignation = instance.controlledAirspaceClassDesignation;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            categoryOfControlledAirspace = instance.categoryOfControlledAirspace;
            controllingAuthority = instance.controllingAuthority;
            altitude = new();
            if (instance.altitude != null) {
                altitude = new();
                altitude.Load(instance.altitude);
            }

            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            verticalDatum = instance.verticalDatum;
            heightLengthUnits = instance.heightLengthUnits;
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            reportedDate = instance.reportedDate;
            flightLevel = new();
            if (instance.flightLevel != null) {
                flightLevel = new();
                flightLevel.Load(instance.flightLevel);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.ControlledAirspace
            {
                controlledAirspaceClassDesignation = this.controlledAirspaceClassDesignation,
                information = this.information.ToList(),
                featureName = this.featureName.ToList(),
                categoryOfControlledAirspace = this.categoryOfControlledAirspace,
                controllingAuthority = this.controllingAuthority,
                altitude = this.altitude?.Model,
                sourceIdentification = this.sourceIdentification?.Model,
                verticalDatum = this.verticalDatum,
                heightLengthUnits = this.heightLengthUnits,
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                reportedDate = this.reportedDate,
                flightLevel = this.flightLevel?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.ControlledAirspace Model => new()
        {
            controlledAirspaceClassDesignation = this._controlledAirspaceClassDesignation,
            information = this.information.ToList(),
            featureName = this.featureName.ToList(),
            categoryOfControlledAirspace = this._categoryOfControlledAirspace,
            controllingAuthority = this._controllingAuthority,
            altitude = this._altitude?.Model,
            sourceIdentification = this._sourceIdentification?.Model,
            verticalDatum = this._verticalDatum,
            heightLengthUnits = this._heightLengthUnits,
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            reportedDate = this._reportedDate,
            flightLevel = this._flightLevel?.Model,
        };

        public ControlledAirspaceViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
        }

        public override string? ToString() => $"Controlled Airspace";
    }

    [CategoryOrder("Obstruction", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ObstructionViewModel : ViewModelBase {
        [Category("Obstruction")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        private String _controllingAuthority = string.Empty;
        [Category("Obstruction")]
        public String controllingAuthority {
            get {
                return _controllingAuthority;
            }

            set {
                SetValue(ref _controllingAuthority, value);
            }
        }

        [Category("Obstruction")]
        public ObservableCollection<product> product { get; set; } = new();

        private Boolean? _existenceOfRestrictedArea = default;
        [Category("Obstruction")]
        public Boolean? existenceOfRestrictedArea {
            get {
                return _existenceOfRestrictedArea;
            }

            set {
                SetValue(ref _existenceOfRestrictedArea, value);
            }
        }

        private Decimal? _horizontalDistanceUncertainty = default;
        [Category("Obstruction")]
        public Decimal? horizontalDistanceUncertainty {
            get {
                return _horizontalDistanceUncertainty;
            }

            set {
                SetValue(ref _horizontalDistanceUncertainty, value);
            }
        }

        private lastSourceInformationViewModel? _lastSourceInformation;
        [Category("Obstruction")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public lastSourceInformationViewModel? lastSourceInformation {
            get {
                return _lastSourceInformation;
            }

            set {
                SetValue(ref _lastSourceInformation, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("Obstruction")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private expositionOfSounding? _expositionOfSounding = default;
        [Category("Obstruction")]
        public expositionOfSounding? expositionOfSounding {
            get {
                return _expositionOfSounding;
            }

            set {
                SetValue(ref _expositionOfSounding, value);
            }
        }

        private firstSourceInformationViewModel? _firstSourceInformation;
        [Category("Obstruction")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public firstSourceInformationViewModel? firstSourceInformation {
            get {
                return _firstSourceInformation;
            }

            set {
                SetValue(ref _firstSourceInformation, value);
            }
        }

        private DateOnly? _abandonmentDate = default;
        [Category("Obstruction")]
        public DateOnly? abandonmentDate {
            get {
                return _abandonmentDate;
            }

            set {
                SetValue(ref _abandonmentDate, value);
            }
        }

        private Decimal? _verticalLength = default;
        [Category("Obstruction")]
        public Decimal? verticalLength {
            get {
                return _verticalLength;
            }

            set {
                SetValue(ref _verticalLength, value);
            }
        }

        private Decimal? _soundingDepth = default;
        [Category("Obstruction")]
        public Decimal? soundingDepth {
            get {
                return _soundingDepth;
            }

            set {
                SetValue(ref _soundingDepth, value);
            }
        }

        private orientationViewModel? _orientation;
        [Category("Obstruction")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public orientationViewModel? orientation {
            get {
                return _orientation;
            }

            set {
                SetValue(ref _orientation, value);
            }
        }

        private soundingDatum? _soundingDatum = default;
        [Category("Obstruction")]
        public soundingDatum? soundingDatum {
            get {
                return _soundingDatum;
            }

            set {
                SetValue(ref _soundingDatum, value);
            }
        }

        [Category("Obstruction")]
        public ObservableCollection<information> information { get; set; } = new();

        private magneticInformationViewModel? _magneticInformation;
        [Category("Obstruction")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public magneticInformationViewModel? magneticInformation {
            get {
                return _magneticInformation;
            }

            set {
                SetValue(ref _magneticInformation, value);
            }
        }

        private Decimal? _horizontalWidth = default;
        [Category("Obstruction")]
        public Decimal? horizontalWidth {
            get {
                return _horizontalWidth;
            }

            set {
                SetValue(ref _horizontalWidth, value);
            }
        }

        [Category("Obstruction")]
        public ObservableCollection<status> status { get; set; } = new();

        private verticalUncertaintyViewModel? _verticalUncertainty;
        [Category("Obstruction")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public verticalUncertaintyViewModel? verticalUncertainty {
            get {
                return _verticalUncertainty;
            }

            set {
                SetValue(ref _verticalUncertainty, value);
            }
        }

        private condition? _condition = default;
        [Category("Obstruction")]
        public condition? condition {
            get {
                return _condition;
            }

            set {
                SetValue(ref _condition, value);
            }
        }

        private Int32? _generalWaterDepth = default;
        [Category("Obstruction")]
        public Int32? generalWaterDepth {
            get {
                return _generalWaterDepth;
            }

            set {
                SetValue(ref _generalWaterDepth, value);
            }
        }

        [Category("Obstruction")]
        public ObservableCollection<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = new();

        private detectionDateRangeViewModel? _detectionDateRange;
        [Category("Obstruction")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public detectionDateRangeViewModel? detectionDateRange {
            get {
                return _detectionDateRange;
            }

            set {
                SetValue(ref _detectionDateRange, value);
            }
        }

        private String _oprtor = string.Empty;
        [Category("Obstruction")]
        public String oprtor {
            get {
                return _oprtor;
            }

            set {
                SetValue(ref _oprtor, value);
            }
        }

        private verticalDatum? _verticalDatum = default;
        [Category("Obstruction")]
        public verticalDatum? verticalDatum {
            get {
                return _verticalDatum;
            }

            set {
                SetValue(ref _verticalDatum, value);
            }
        }

        private Decimal? _height = default;
        [Category("Obstruction")]
        public Decimal? height {
            get {
                return _height;
            }

            set {
                SetValue(ref _height, value);
            }
        }

        private sonarSignalStrength? _sonarSignalStrength = default;
        [Category("Obstruction")]
        public sonarSignalStrength? sonarSignalStrength {
            get {
                return _sonarSignalStrength;
            }

            set {
                SetValue(ref _sonarSignalStrength, value);
            }
        }

        private Boolean? _radarConspicuous = default;
        [Category("Obstruction")]
        public Boolean? radarConspicuous {
            get {
                return _radarConspicuous;
            }

            set {
                SetValue(ref _radarConspicuous, value);
            }
        }

        private Decimal? _maximumPermittedDraught = default;
        [Category("Obstruction")]
        public Decimal? maximumPermittedDraught {
            get {
                return _maximumPermittedDraught;
            }

            set {
                SetValue(ref _maximumPermittedDraught, value);
            }
        }

        [Category("Obstruction")]
        public ObservableCollection<natureOfSurface> natureOfSurface { get; set; } = new();

        private DateOnly? _spuddedDate = default;
        [Category("Obstruction")]
        public DateOnly? spuddedDate {
            get {
                return _spuddedDate;
            }

            set {
                SetValue(ref _spuddedDate, value);
            }
        }

        private categoryOfObstruction? _categoryOfObstruction = default;
        [Category("Obstruction")]
        public categoryOfObstruction? categoryOfObstruction {
            get {
                return _categoryOfObstruction;
            }

            set {
                SetValue(ref _categoryOfObstruction, value);
            }
        }

        private visualProminence? _visualProminence = default;
        [Category("Obstruction")]
        public visualProminence? visualProminence {
            get {
                return _visualProminence;
            }

            set {
                SetValue(ref _visualProminence, value);
            }
        }

        private DateOnly? _dateSunk = default;
        [Category("Obstruction")]
        public DateOnly? dateSunk {
            get {
                return _dateSunk;
            }

            set {
                SetValue(ref _dateSunk, value);
            }
        }

        private Decimal? _horizontalLength = default;
        [Category("Obstruction")]
        public Decimal? horizontalLength {
            get {
                return _horizontalLength;
            }

            set {
                SetValue(ref _horizontalLength, value);
            }
        }

        [Category("Obstruction")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("Obstruction")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private String _currentScourDimensions = string.Empty;
        [Category("Obstruction")]
        public String currentScourDimensions {
            get {
                return _currentScourDimensions;
            }

            set {
                SetValue(ref _currentScourDimensions, value);
            }
        }

        [Category("Obstruction")]
        public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = new();

        private DateOnly? _reportedDate = default;
        [Category("Obstruction")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private cardinalPointOrientation? _cardinalPointOrientation = default;
        [Category("Obstruction")]
        public cardinalPointOrientation? cardinalPointOrientation {
            get {
                return _cardinalPointOrientation;
            }

            set {
                SetValue(ref _cardinalPointOrientation, value);
            }
        }

        private Decimal? _valueOfSounding = default;
        [Category("Obstruction")]
        public Decimal? valueOfSounding {
            get {
                return _valueOfSounding;
            }

            set {
                SetValue(ref _valueOfSounding, value);
            }
        }

        private waterLevelEffect _waterLevelEffect;
        [Category("Obstruction")]
        public waterLevelEffect waterLevelEffect {
            get {
                return _waterLevelEffect;
            }

            set {
                SetValue(ref _waterLevelEffect, value);
            }
        }

        private String _nation = string.Empty;
        [Category("Obstruction")]
        public String nation {
            get {
                return _nation;
            }

            set {
                SetValue(ref _nation, value);
            }
        }

        private Decimal? _defaultClearanceDepth = default;
        [Category("Obstruction")]
        public Decimal? defaultClearanceDepth {
            get {
                return _defaultClearanceDepth;
            }

            set {
                SetValue(ref _defaultClearanceDepth, value);
            }
        }

        private Boolean? _displayUncertainties = default;
        [Category("Obstruction")]
        public Boolean? displayUncertainties {
            get {
                return _displayUncertainties;
            }

            set {
                SetValue(ref _displayUncertainties, value);
            }
        }

        public class ObstructionRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["Obstruction"];
        }

        public void Load(DomainModel.S501.FeatureTypes.Obstruction instance) {
            natureOfConstruction.Clear();
            if (instance.natureOfConstruction is not null)
                foreach (var e in instance.natureOfConstruction)
                    natureOfConstruction.Add(e);
            controllingAuthority = instance.controllingAuthority;
            product.Clear();
            if (instance.product is not null)
                foreach (var e in instance.product)
                    product.Add(e);
            existenceOfRestrictedArea = instance.existenceOfRestrictedArea;
            horizontalDistanceUncertainty = instance.horizontalDistanceUncertainty;
            lastSourceInformation = new();
            if (instance.lastSourceInformation != null) {
                lastSourceInformation = new();
                lastSourceInformation.Load(instance.lastSourceInformation);
            }

            scaleMinimum = instance.scaleMinimum;
            expositionOfSounding = instance.expositionOfSounding;
            firstSourceInformation = new();
            if (instance.firstSourceInformation != null) {
                firstSourceInformation = new();
                firstSourceInformation.Load(instance.firstSourceInformation);
            }

            abandonmentDate = instance.abandonmentDate;
            verticalLength = instance.verticalLength;
            soundingDepth = instance.soundingDepth;
            orientation = new();
            if (instance.orientation != null) {
                orientation = new();
                orientation.Load(instance.orientation);
            }

            soundingDatum = instance.soundingDatum;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            magneticInformation = new();
            if (instance.magneticInformation != null) {
                magneticInformation = new();
                magneticInformation.Load(instance.magneticInformation);
            }

            horizontalWidth = instance.horizontalWidth;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            verticalUncertainty = new();
            if (instance.verticalUncertainty != null) {
                verticalUncertainty = new();
                verticalUncertainty.Load(instance.verticalUncertainty);
            }

            condition = instance.condition;
            generalWaterDepth = instance.generalWaterDepth;
            qualityOfVerticalMeasurement.Clear();
            if (instance.qualityOfVerticalMeasurement is not null)
                foreach (var e in instance.qualityOfVerticalMeasurement)
                    qualityOfVerticalMeasurement.Add(e);
            detectionDateRange = new();
            if (instance.detectionDateRange != null) {
                detectionDateRange = new();
                detectionDateRange.Load(instance.detectionDateRange);
            }

            oprtor = instance.oprtor;
            verticalDatum = instance.verticalDatum;
            height = instance.height;
            sonarSignalStrength = instance.sonarSignalStrength;
            radarConspicuous = instance.radarConspicuous;
            maximumPermittedDraught = instance.maximumPermittedDraught;
            natureOfSurface.Clear();
            if (instance.natureOfSurface is not null)
                foreach (var e in instance.natureOfSurface)
                    natureOfSurface.Add(e);
            spuddedDate = instance.spuddedDate;
            categoryOfObstruction = instance.categoryOfObstruction;
            visualProminence = instance.visualProminence;
            dateSunk = instance.dateSunk;
            horizontalLength = instance.horizontalLength;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            currentScourDimensions = instance.currentScourDimensions;
            techniqueOfVerticalMeasurement.Clear();
            if (instance.techniqueOfVerticalMeasurement is not null)
                foreach (var e in instance.techniqueOfVerticalMeasurement)
                    techniqueOfVerticalMeasurement.Add(e);
            reportedDate = instance.reportedDate;
            cardinalPointOrientation = instance.cardinalPointOrientation;
            valueOfSounding = instance.valueOfSounding;
            waterLevelEffect = instance.waterLevelEffect;
            nation = instance.nation;
            defaultClearanceDepth = instance.defaultClearanceDepth;
            displayUncertainties = instance.displayUncertainties;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.Obstruction
            {
                natureOfConstruction = this.natureOfConstruction.ToList(),
                controllingAuthority = this.controllingAuthority,
                product = this.product.ToList(),
                existenceOfRestrictedArea = this.existenceOfRestrictedArea,
                horizontalDistanceUncertainty = this.horizontalDistanceUncertainty,
                lastSourceInformation = this.lastSourceInformation?.Model,
                scaleMinimum = this.scaleMinimum,
                expositionOfSounding = this.expositionOfSounding,
                firstSourceInformation = this.firstSourceInformation?.Model,
                abandonmentDate = this.abandonmentDate,
                verticalLength = this.verticalLength,
                soundingDepth = this.soundingDepth,
                orientation = this.orientation?.Model,
                soundingDatum = this.soundingDatum,
                information = this.information.ToList(),
                magneticInformation = this.magneticInformation?.Model,
                horizontalWidth = this.horizontalWidth,
                status = this.status.ToList(),
                verticalUncertainty = this.verticalUncertainty?.Model,
                condition = this.condition,
                generalWaterDepth = this.generalWaterDepth,
                qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement.ToList(),
                detectionDateRange = this.detectionDateRange?.Model,
                oprtor = this.oprtor,
                verticalDatum = this.verticalDatum,
                height = this.height,
                sonarSignalStrength = this.sonarSignalStrength,
                radarConspicuous = this.radarConspicuous,
                maximumPermittedDraught = this.maximumPermittedDraught,
                natureOfSurface = this.natureOfSurface.ToList(),
                spuddedDate = this.spuddedDate,
                categoryOfObstruction = this.categoryOfObstruction,
                visualProminence = this.visualProminence,
                dateSunk = this.dateSunk,
                horizontalLength = this.horizontalLength,
                featureName = this.featureName.ToList(),
                sourceIdentification = this.sourceIdentification?.Model,
                currentScourDimensions = this.currentScourDimensions,
                techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
                reportedDate = this.reportedDate,
                cardinalPointOrientation = this.cardinalPointOrientation,
                valueOfSounding = this.valueOfSounding,
                waterLevelEffect = this.waterLevelEffect,
                nation = this.nation,
                defaultClearanceDepth = this.defaultClearanceDepth,
                displayUncertainties = this.displayUncertainties,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.Obstruction Model => new()
        {
            natureOfConstruction = this.natureOfConstruction.ToList(),
            controllingAuthority = this._controllingAuthority,
            product = this.product.ToList(),
            existenceOfRestrictedArea = this._existenceOfRestrictedArea,
            horizontalDistanceUncertainty = this._horizontalDistanceUncertainty,
            lastSourceInformation = this._lastSourceInformation?.Model,
            scaleMinimum = this._scaleMinimum,
            expositionOfSounding = this._expositionOfSounding,
            firstSourceInformation = this._firstSourceInformation?.Model,
            abandonmentDate = this._abandonmentDate,
            verticalLength = this._verticalLength,
            soundingDepth = this._soundingDepth,
            orientation = this._orientation?.Model,
            soundingDatum = this._soundingDatum,
            information = this.information.ToList(),
            magneticInformation = this._magneticInformation?.Model,
            horizontalWidth = this._horizontalWidth,
            status = this.status.ToList(),
            verticalUncertainty = this._verticalUncertainty?.Model,
            condition = this._condition,
            generalWaterDepth = this._generalWaterDepth,
            qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement.ToList(),
            detectionDateRange = this._detectionDateRange?.Model,
            oprtor = this._oprtor,
            verticalDatum = this._verticalDatum,
            height = this._height,
            sonarSignalStrength = this._sonarSignalStrength,
            radarConspicuous = this._radarConspicuous,
            maximumPermittedDraught = this._maximumPermittedDraught,
            natureOfSurface = this.natureOfSurface.ToList(),
            spuddedDate = this._spuddedDate,
            categoryOfObstruction = this._categoryOfObstruction,
            visualProminence = this._visualProminence,
            dateSunk = this._dateSunk,
            horizontalLength = this._horizontalLength,
            featureName = this.featureName.ToList(),
            sourceIdentification = this._sourceIdentification?.Model,
            currentScourDimensions = this._currentScourDimensions,
            techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
            reportedDate = this._reportedDate,
            cardinalPointOrientation = this._cardinalPointOrientation,
            valueOfSounding = this._valueOfSounding,
            waterLevelEffect = this._waterLevelEffect,
            nation = this._nation,
            defaultClearanceDepth = this._defaultClearanceDepth,
            displayUncertainties = this._displayUncertainties,
        };

        public ObstructionViewModel() : base() {
            natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(natureOfConstruction));
            };
            product.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(product));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            qualityOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(qualityOfVerticalMeasurement));
            };
            natureOfSurface.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(natureOfSurface));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            techniqueOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(techniqueOfVerticalMeasurement));
            };
        }

        public override string? ToString() => $"Obstruction";
    }

    [CategoryOrder("FishingGround", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class FishingGroundViewModel : ViewModelBase {
        [Category("FishingGround")]
        public ObservableCollection<status> status { get; set; } = new();

        private DateOnly? _reportedDate = default;
        [Category("FishingGround")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("FishingGround")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        [Category("FishingGround")]
        public ObservableCollection<vesselSpeedLimit> vesselSpeedLimit { get; set; } = new();

        [Category("FishingGround")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("FishingGround")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("FishingGround")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("FishingGround")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        [Category("FishingGround")]
        public ObservableCollection<restriction> restriction { get; set; } = new();

        [Category("FishingGround")]
        public ObservableCollection<information> information { get; set; } = new();

        public class FishingGroundRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["FishingGround"];
        }

        public void Load(DomainModel.S501.FeatureTypes.FishingGround instance) {
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            reportedDate = instance.reportedDate;
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            vesselSpeedLimit.Clear();
            if (instance.vesselSpeedLimit is not null)
                foreach (var e in instance.vesselSpeedLimit)
                    vesselSpeedLimit.Add(e);
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            scaleMinimum = instance.scaleMinimum;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            restriction.Clear();
            if (instance.restriction is not null)
                foreach (var e in instance.restriction)
                    restriction.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.FishingGround
            {
                status = this.status.ToList(),
                reportedDate = this.reportedDate,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                vesselSpeedLimit = this.vesselSpeedLimit.ToList(),
                periodicDateRange = this.periodicDateRange.ToList(),
                sourceIdentification = this.sourceIdentification?.Model,
                scaleMinimum = this.scaleMinimum,
                featureName = this.featureName.ToList(),
                restriction = this.restriction.ToList(),
                information = this.information.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.FishingGround Model => new()
        {
            status = this.status.ToList(),
            reportedDate = this._reportedDate,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            vesselSpeedLimit = this.vesselSpeedLimit.ToList(),
            periodicDateRange = this.periodicDateRange.ToList(),
            sourceIdentification = this._sourceIdentification?.Model,
            scaleMinimum = this._scaleMinimum,
            featureName = this.featureName.ToList(),
            restriction = this.restriction.ToList(),
            information = this.information.ToList(),
        };

        public FishingGroundViewModel() : base() {
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            vesselSpeedLimit.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(vesselSpeedLimit));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(restriction));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Fishing Ground";
    }

    [CategoryOrder("FishingFacility", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class FishingFacilityViewModel : ViewModelBase {
        [Category("FishingFacility")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("FishingFacility")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        private condition? _condition = default;
        [Category("FishingFacility")]
        public condition? condition {
            get {
                return _condition;
            }

            set {
                SetValue(ref _condition, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("FishingFacility")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private Decimal? _verticalLength = default;
        [Category("FishingFacility")]
        public Decimal? verticalLength {
            get {
                return _verticalLength;
            }

            set {
                SetValue(ref _verticalLength, value);
            }
        }

        [Category("FishingFacility")]
        public ObservableCollection<status> status { get; set; } = new();

        private categoryOfFishingFacility? _categoryOfFishingFacility = default;
        [Category("FishingFacility")]
        public categoryOfFishingFacility? categoryOfFishingFacility {
            get {
                return _categoryOfFishingFacility;
            }

            set {
                SetValue(ref _categoryOfFishingFacility, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("FishingFacility")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("FishingFacility")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private DateOnly? _reportedDate = default;
        [Category("FishingFacility")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        public class FishingFacilityRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["FishingFacility"];
        }

        public void Load(DomainModel.S501.FeatureTypes.FishingFacility instance) {
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            condition = instance.condition;
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            verticalLength = instance.verticalLength;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            categoryOfFishingFacility = instance.categoryOfFishingFacility;
            scaleMinimum = instance.scaleMinimum;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            reportedDate = instance.reportedDate;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.FishingFacility
            {
                information = this.information.ToList(),
                periodicDateRange = this.periodicDateRange.ToList(),
                condition = this.condition,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                verticalLength = this.verticalLength,
                status = this.status.ToList(),
                categoryOfFishingFacility = this.categoryOfFishingFacility,
                scaleMinimum = this.scaleMinimum,
                featureName = this.featureName.ToList(),
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.FishingFacility Model => new()
        {
            information = this.information.ToList(),
            periodicDateRange = this.periodicDateRange.ToList(),
            condition = this._condition,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            verticalLength = this._verticalLength,
            status = this.status.ToList(),
            categoryOfFishingFacility = this._categoryOfFishingFacility,
            scaleMinimum = this._scaleMinimum,
            featureName = this.featureName.ToList(),
            reportedDate = this._reportedDate,
        };

        public FishingFacilityViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
        }

        public override string? ToString() => $"Fishing Facility";
    }

    [CategoryOrder("NavigationSystem", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class NavigationSystemViewModel : ViewModelBase {
        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("NavigationSystem")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        [Category("NavigationSystem")]
        public ObservableCollection<information> information { get; set; } = new();

        private String _agencyResponsibleForProduction = string.Empty;
        [Category("NavigationSystem")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        private categoryOfRadioStation? _categoryOfRadioStation = default;
        [Category("NavigationSystem")]
        public categoryOfRadioStation? categoryOfRadioStation {
            get {
                return _categoryOfRadioStation;
            }

            set {
                SetValue(ref _categoryOfRadioStation, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("NavigationSystem")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private String _callsign = string.Empty;
        [Category("NavigationSystem")]
        public String callsign {
            get {
                return _callsign;
            }

            set {
                SetValue(ref _callsign, value);
            }
        }

        [Category("NavigationSystem")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private String _communicationChannel = string.Empty;
        [Category("NavigationSystem")]
        public String communicationChannel {
            get {
                return _communicationChannel;
            }

            set {
                SetValue(ref _communicationChannel, value);
            }
        }

        private Int32? _signalFrequency = default;
        [Category("NavigationSystem")]
        public Int32? signalFrequency {
            get {
                return _signalFrequency;
            }

            set {
                SetValue(ref _signalFrequency, value);
            }
        }

        public class NavigationSystemRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["NavigationSystem"];
        }

        public void Load(DomainModel.S501.FeatureTypes.NavigationSystem instance) {
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            categoryOfRadioStation = instance.categoryOfRadioStation;
            reportedDate = instance.reportedDate;
            callsign = instance.callsign;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            communicationChannel = instance.communicationChannel;
            signalFrequency = instance.signalFrequency;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.NavigationSystem
            {
                sourceIdentification = this.sourceIdentification?.Model,
                information = this.information.ToList(),
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                categoryOfRadioStation = this.categoryOfRadioStation,
                reportedDate = this.reportedDate,
                callsign = this.callsign,
                featureName = this.featureName.ToList(),
                communicationChannel = this.communicationChannel,
                signalFrequency = this.signalFrequency,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.NavigationSystem Model => new()
        {
            sourceIdentification = this._sourceIdentification?.Model,
            information = this.information.ToList(),
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            categoryOfRadioStation = this._categoryOfRadioStation,
            reportedDate = this._reportedDate,
            callsign = this._callsign,
            featureName = this.featureName.ToList(),
            communicationChannel = this._communicationChannel,
            signalFrequency = this._signalFrequency,
        };

        public NavigationSystemViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
        }

        public override string? ToString() => $"Navigation System";
    }

    [CategoryOrder("TrafficSeparationSchemeCrossing", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class TrafficSeparationSchemeCrossingViewModel : ViewModelBase {
        [Category("TrafficSeparationSchemeCrossing")]
        public ObservableCollection<restriction> restriction { get; set; } = new();

        [Category("TrafficSeparationSchemeCrossing")]
        public ObservableCollection<vesselSpeedLimit> vesselSpeedLimit { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("TrafficSeparationSchemeCrossing")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("TrafficSeparationSchemeCrossing")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("TrafficSeparationSchemeCrossing")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        [Category("TrafficSeparationSchemeCrossing")]
        public ObservableCollection<status> status { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("TrafficSeparationSchemeCrossing")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("TrafficSeparationSchemeCrossing")]
        public ObservableCollection<information> information { get; set; } = new();

        private DateOnly? _reportedDate = default;
        [Category("TrafficSeparationSchemeCrossing")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        public class TrafficSeparationSchemeCrossingRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["TrafficSeparationSchemeCrossing"];
        }

        public void Load(DomainModel.S501.FeatureTypes.TrafficSeparationSchemeCrossing instance) {
            restriction.Clear();
            if (instance.restriction is not null)
                foreach (var e in instance.restriction)
                    restriction.Add(e);
            vesselSpeedLimit.Clear();
            if (instance.vesselSpeedLimit is not null)
                foreach (var e in instance.vesselSpeedLimit)
                    vesselSpeedLimit.Add(e);
            scaleMinimum = instance.scaleMinimum;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            reportedDate = instance.reportedDate;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.TrafficSeparationSchemeCrossing
            {
                restriction = this.restriction.ToList(),
                vesselSpeedLimit = this.vesselSpeedLimit.ToList(),
                scaleMinimum = this.scaleMinimum,
                sourceIdentification = this.sourceIdentification?.Model,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                status = this.status.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                information = this.information.ToList(),
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.TrafficSeparationSchemeCrossing Model => new()
        {
            restriction = this.restriction.ToList(),
            vesselSpeedLimit = this.vesselSpeedLimit.ToList(),
            scaleMinimum = this._scaleMinimum,
            sourceIdentification = this._sourceIdentification?.Model,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            status = this.status.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            information = this.information.ToList(),
            reportedDate = this._reportedDate,
        };

        public TrafficSeparationSchemeCrossingViewModel() : base() {
            restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(restriction));
            };
            vesselSpeedLimit.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(vesselSpeedLimit));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Traffic Separation Scheme Crossing";
    }

    [CategoryOrder("TrafficSeparationSchemeLanePart", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class TrafficSeparationSchemeLanePartViewModel : ViewModelBase {
        [Category("TrafficSeparationSchemeLanePart")]
        public ObservableCollection<information> information { get; set; } = new();

        private DateOnly? _reportedDate = default;
        [Category("TrafficSeparationSchemeLanePart")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("TrafficSeparationSchemeLanePart")]
        public ObservableCollection<vesselSpeedLimit> vesselSpeedLimit { get; set; } = new();

        private String _interoperabilityIdentifier = string.Empty;
        [Category("TrafficSeparationSchemeLanePart")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        [Category("TrafficSeparationSchemeLanePart")]
        public ObservableCollection<restriction> restriction { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("TrafficSeparationSchemeLanePart")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private Decimal? _orientationValue = default;
        [Category("TrafficSeparationSchemeLanePart")]
        public Decimal? orientationValue {
            get {
                return _orientationValue;
            }

            set {
                SetValue(ref _orientationValue, value);
            }
        }

        [Category("TrafficSeparationSchemeLanePart")]
        public ObservableCollection<status> status { get; set; } = new();

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("TrafficSeparationSchemeLanePart")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("TrafficSeparationSchemeLanePart")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        public class TrafficSeparationSchemeLanePartRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["TrafficSeparationSchemeLanePart"];
        }

        public void Load(DomainModel.S501.FeatureTypes.TrafficSeparationSchemeLanePart instance) {
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            reportedDate = instance.reportedDate;
            vesselSpeedLimit.Clear();
            if (instance.vesselSpeedLimit is not null)
                foreach (var e in instance.vesselSpeedLimit)
                    vesselSpeedLimit.Add(e);
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            restriction.Clear();
            if (instance.restriction is not null)
                foreach (var e in instance.restriction)
                    restriction.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            orientationValue = instance.orientationValue;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            scaleMinimum = instance.scaleMinimum;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.TrafficSeparationSchemeLanePart
            {
                information = this.information.ToList(),
                reportedDate = this.reportedDate,
                vesselSpeedLimit = this.vesselSpeedLimit.ToList(),
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                restriction = this.restriction.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                orientationValue = this.orientationValue,
                status = this.status.ToList(),
                sourceIdentification = this.sourceIdentification?.Model,
                scaleMinimum = this.scaleMinimum,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.TrafficSeparationSchemeLanePart Model => new()
        {
            information = this.information.ToList(),
            reportedDate = this._reportedDate,
            vesselSpeedLimit = this.vesselSpeedLimit.ToList(),
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            restriction = this.restriction.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            orientationValue = this._orientationValue,
            status = this.status.ToList(),
            sourceIdentification = this._sourceIdentification?.Model,
            scaleMinimum = this._scaleMinimum,
        };

        public TrafficSeparationSchemeLanePartViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            vesselSpeedLimit.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(vesselSpeedLimit));
            };
            restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(restriction));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
        }

        public override string? ToString() => $"Traffic Separation Scheme Lane Part";
    }

    [CategoryOrder("TerritorialSeaArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class TerritorialSeaAreaViewModel : ViewModelBase {
        [Category("TerritorialSeaArea")]
        public ObservableCollection<String> nationality { get; set; } = new();

        [Category("TerritorialSeaArea")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private status? _status = default;
        [Category("TerritorialSeaArea")]
        public status? status {
            get {
                return _status;
            }

            set {
                SetValue(ref _status, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("TerritorialSeaArea")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private String _agencyResponsibleForProduction = string.Empty;
        [Category("TerritorialSeaArea")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        [Category("TerritorialSeaArea")]
        public ObservableCollection<vesselSpeedLimit> vesselSpeedLimit { get; set; } = new();

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("TerritorialSeaArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("TerritorialSeaArea")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("TerritorialSeaArea")]
        public ObservableCollection<restriction> restriction { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("TerritorialSeaArea")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("TerritorialSeaArea")]
        public ObservableCollection<String> nationalMaritimeAuthority { get; set; } = new();

        [Category("TerritorialSeaArea")]
        public ObservableCollection<information> information { get; set; } = new();

        public class TerritorialSeaAreaRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["TerritorialSeaArea"];
        }

        public void Load(DomainModel.S501.FeatureTypes.TerritorialSeaArea instance) {
            nationality.Clear();
            if (instance.nationality is not null)
                foreach (var e in instance.nationality)
                    nationality.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            status = instance.status;
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            vesselSpeedLimit.Clear();
            if (instance.vesselSpeedLimit is not null)
                foreach (var e in instance.vesselSpeedLimit)
                    vesselSpeedLimit.Add(e);
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            reportedDate = instance.reportedDate;
            restriction.Clear();
            if (instance.restriction is not null)
                foreach (var e in instance.restriction)
                    restriction.Add(e);
            scaleMinimum = instance.scaleMinimum;
            nationalMaritimeAuthority.Clear();
            if (instance.nationalMaritimeAuthority is not null)
                foreach (var e in instance.nationalMaritimeAuthority)
                    nationalMaritimeAuthority.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.TerritorialSeaArea
            {
                nationality = this.nationality.ToList(),
                featureName = this.featureName.ToList(),
                status = this.status,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                vesselSpeedLimit = this.vesselSpeedLimit.ToList(),
                sourceIdentification = this.sourceIdentification?.Model,
                reportedDate = this.reportedDate,
                restriction = this.restriction.ToList(),
                scaleMinimum = this.scaleMinimum,
                nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
                information = this.information.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.TerritorialSeaArea Model => new()
        {
            nationality = this.nationality.ToList(),
            featureName = this.featureName.ToList(),
            status = this._status,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            vesselSpeedLimit = this.vesselSpeedLimit.ToList(),
            sourceIdentification = this._sourceIdentification?.Model,
            reportedDate = this._reportedDate,
            restriction = this.restriction.ToList(),
            scaleMinimum = this._scaleMinimum,
            nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
            information = this.information.ToList(),
        };

        public TerritorialSeaAreaViewModel() : base() {
            nationality.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(nationality));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            vesselSpeedLimit.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(vesselSpeedLimit));
            };
            restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(restriction));
            };
            nationalMaritimeAuthority.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(nationalMaritimeAuthority));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Territorial Sea Area";
    }

    [CategoryOrder("LateralBeacon", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class LateralBeaconViewModel : ViewModelBase {
        private Decimal? _elevation = default;
        [Category("LateralBeacon")]
        public Decimal? elevation {
            get {
                return _elevation;
            }

            set {
                SetValue(ref _elevation, value);
            }
        }

        private beaconShape _beaconShape;
        [Category("LateralBeacon")]
        public beaconShape beaconShape {
            get {
                return _beaconShape;
            }

            set {
                SetValue(ref _beaconShape, value);
            }
        }

        private marksNavigationalSystemOf? _marksNavigationalSystemOf = default;
        [Category("LateralBeacon")]
        public marksNavigationalSystemOf? marksNavigationalSystemOf {
            get {
                return _marksNavigationalSystemOf;
            }

            set {
                SetValue(ref _marksNavigationalSystemOf, value);
            }
        }

        private String _pictorialRepresentation = string.Empty;
        [Category("LateralBeacon")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        private categoryOfLateralMark _categoryOfLateralMark;
        [Category("LateralBeacon")]
        public categoryOfLateralMark categoryOfLateralMark {
            get {
                return _categoryOfLateralMark;
            }

            set {
                SetValue(ref _categoryOfLateralMark, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("LateralBeacon")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("LateralBeacon")]
        public ObservableCollection<status> status { get; set; } = new();

        private visualProminence? _visualProminence = default;
        [Category("LateralBeacon")]
        public visualProminence? visualProminence {
            get {
                return _visualProminence;
            }

            set {
                SetValue(ref _visualProminence, value);
            }
        }

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("LateralBeacon")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private Decimal? _verticalLength = default;
        [Category("LateralBeacon")]
        public Decimal? verticalLength {
            get {
                return _verticalLength;
            }

            set {
                SetValue(ref _verticalLength, value);
            }
        }

        [Category("LateralBeacon")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("LateralBeacon")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private Boolean? _radarConspicuous = default;
        [Category("LateralBeacon")]
        public Boolean? radarConspicuous {
            get {
                return _radarConspicuous;
            }

            set {
                SetValue(ref _radarConspicuous, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("LateralBeacon")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        [Category("LateralBeacon")]
        public ObservableCollection<information> information { get; set; } = new();

        private colourPattern? _colourPattern = default;
        [Category("LateralBeacon")]
        public colourPattern? colourPattern {
            get {
                return _colourPattern;
            }

            set {
                SetValue(ref _colourPattern, value);
            }
        }

        [Category("LateralBeacon")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("LateralBeacon")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private topmarkViewModel? _topmark;
        [Category("LateralBeacon")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public topmarkViewModel? topmark {
            get {
                return _topmark;
            }

            set {
                SetValue(ref _topmark, value);
            }
        }

        private Decimal? _height = default;
        [Category("LateralBeacon")]
        public Decimal? height {
            get {
                return _height;
            }

            set {
                SetValue(ref _height, value);
            }
        }

        private condition? _condition = default;
        [Category("LateralBeacon")]
        public condition? condition {
            get {
                return _condition;
            }

            set {
                SetValue(ref _condition, value);
            }
        }

        [Category("LateralBeacon")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        [Category("LateralBeacon")]
        public ObservableCollection<colour> colour { get; set; } = new();

        public class LateralBeaconRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["LateralBeacon"];
        }

        public void Load(DomainModel.S501.FeatureTypes.LateralBeacon instance) {
            elevation = instance.elevation;
            beaconShape = instance.beaconShape;
            marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
            pictorialRepresentation = instance.pictorialRepresentation;
            categoryOfLateralMark = instance.categoryOfLateralMark;
            reportedDate = instance.reportedDate;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            visualProminence = instance.visualProminence;
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            verticalLength = instance.verticalLength;
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            radarConspicuous = instance.radarConspicuous;
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            colourPattern = instance.colourPattern;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            scaleMinimum = instance.scaleMinimum;
            topmark = new();
            if (instance.topmark != null) {
                topmark = new();
                topmark.Load(instance.topmark);
            }

            height = instance.height;
            condition = instance.condition;
            natureOfConstruction.Clear();
            if (instance.natureOfConstruction is not null)
                foreach (var e in instance.natureOfConstruction)
                    natureOfConstruction.Add(e);
            colour.Clear();
            if (instance.colour is not null)
                foreach (var e in instance.colour)
                    colour.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.LateralBeacon
            {
                elevation = this.elevation,
                beaconShape = this.beaconShape,
                marksNavigationalSystemOf = this.marksNavigationalSystemOf,
                pictorialRepresentation = this.pictorialRepresentation,
                categoryOfLateralMark = this.categoryOfLateralMark,
                reportedDate = this.reportedDate,
                status = this.status.ToList(),
                visualProminence = this.visualProminence,
                fixedDateRange = this.fixedDateRange?.Model,
                verticalLength = this.verticalLength,
                periodicDateRange = this.periodicDateRange.ToList(),
                sourceIdentification = this.sourceIdentification?.Model,
                radarConspicuous = this.radarConspicuous,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                information = this.information.ToList(),
                colourPattern = this.colourPattern,
                featureName = this.featureName.ToList(),
                scaleMinimum = this.scaleMinimum,
                topmark = this.topmark?.Model,
                height = this.height,
                condition = this.condition,
                natureOfConstruction = this.natureOfConstruction.ToList(),
                colour = this.colour.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.LateralBeacon Model => new()
        {
            elevation = this._elevation,
            beaconShape = this._beaconShape,
            marksNavigationalSystemOf = this._marksNavigationalSystemOf,
            pictorialRepresentation = this._pictorialRepresentation,
            categoryOfLateralMark = this._categoryOfLateralMark,
            reportedDate = this._reportedDate,
            status = this.status.ToList(),
            visualProminence = this._visualProminence,
            fixedDateRange = this._fixedDateRange?.Model,
            verticalLength = this._verticalLength,
            periodicDateRange = this.periodicDateRange.ToList(),
            sourceIdentification = this._sourceIdentification?.Model,
            radarConspicuous = this._radarConspicuous,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            information = this.information.ToList(),
            colourPattern = this._colourPattern,
            featureName = this.featureName.ToList(),
            scaleMinimum = this._scaleMinimum,
            topmark = this._topmark?.Model,
            height = this._height,
            condition = this._condition,
            natureOfConstruction = this.natureOfConstruction.ToList(),
            colour = this.colour.ToList(),
        };

        public LateralBeaconViewModel() : base() {
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(natureOfConstruction));
            };
            colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(colour));
            };
        }

        public override string? ToString() => $"Lateral Beacon";
    }

    [CategoryOrder("CoastGuardStation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class CoastGuardStationViewModel : ViewModelBase {
        [Category("CoastGuardStation")]
        public ObservableCollection<status> status { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("CoastGuardStation")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("CoastGuardStation")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("CoastGuardStation")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("CoastGuardStation")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private Boolean? _isMRCC = default;
        [Category("CoastGuardStation")]
        public Boolean? isMRCC {
            get {
                return _isMRCC;
            }

            set {
                SetValue(ref _isMRCC, value);
            }
        }

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("CoastGuardStation")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("CoastGuardStation")]
        public ObservableCollection<String> communicationsChannel { get; set; } = new();

        public class CoastGuardStationRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["CoastGuardStation"];
        }

        public void Load(DomainModel.S501.FeatureTypes.CoastGuardStation instance) {
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            scaleMinimum = instance.scaleMinimum;
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            isMRCC = instance.isMRCC;
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            communicationsChannel.Clear();
            if (instance.communicationsChannel is not null)
                foreach (var e in instance.communicationsChannel)
                    communicationsChannel.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.CoastGuardStation
            {
                status = this.status.ToList(),
                scaleMinimum = this.scaleMinimum,
                periodicDateRange = this.periodicDateRange.ToList(),
                information = this.information.ToList(),
                featureName = this.featureName.ToList(),
                isMRCC = this.isMRCC,
                fixedDateRange = this.fixedDateRange?.Model,
                communicationsChannel = this.communicationsChannel.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.CoastGuardStation Model => new()
        {
            status = this.status.ToList(),
            scaleMinimum = this._scaleMinimum,
            periodicDateRange = this.periodicDateRange.ToList(),
            information = this.information.ToList(),
            featureName = this.featureName.ToList(),
            isMRCC = this._isMRCC,
            fixedDateRange = this._fixedDateRange?.Model,
            communicationsChannel = this.communicationsChannel.ToList(),
        };

        public CoastGuardStationViewModel() : base() {
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            communicationsChannel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(communicationsChannel));
            };
        }

        public override string? ToString() => $"Coast Guard Station";
    }

    [CategoryOrder("SeparationZoneOrLine", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class SeparationZoneOrLineViewModel : ViewModelBase {
        private DateOnly? _reportedDate = default;
        [Category("SeparationZoneOrLine")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("SeparationZoneOrLine")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        [Category("SeparationZoneOrLine")]
        public ObservableCollection<status> status { get; set; } = new();

        [Category("SeparationZoneOrLine")]
        public ObservableCollection<information> information { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("SeparationZoneOrLine")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("SeparationZoneOrLine")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("SeparationZoneOrLine")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        public class SeparationZoneOrLineRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["SeparationZoneOrLine"];
        }

        public void Load(DomainModel.S501.FeatureTypes.SeparationZoneOrLine instance) {
            reportedDate = instance.reportedDate;
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            scaleMinimum = instance.scaleMinimum;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.SeparationZoneOrLine
            {
                reportedDate = this.reportedDate,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                status = this.status.ToList(),
                information = this.information.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                scaleMinimum = this.scaleMinimum,
                sourceIdentification = this.sourceIdentification?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.SeparationZoneOrLine Model => new()
        {
            reportedDate = this._reportedDate,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            status = this.status.ToList(),
            information = this.information.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            scaleMinimum = this._scaleMinimum,
            sourceIdentification = this._sourceIdentification?.Model,
        };

        public SeparationZoneOrLineViewModel() : base() {
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Separation Zone or Line";
    }

    [CategoryOrder("BottomFeature", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class BottomFeatureViewModel : ViewModelBase {
        [Category("BottomFeature")]
        public ObservableCollection<information> information { get; set; } = new();

        private Int32? _migrationDirection = default;
        [Category("BottomFeature")]
        public Int32? migrationDirection {
            get {
                return _migrationDirection;
            }

            set {
                SetValue(ref _migrationDirection, value);
            }
        }

        [Category("BottomFeature")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private Decimal? _horizontalLength = default;
        [Category("BottomFeature")]
        public Decimal? horizontalLength {
            get {
                return _horizontalLength;
            }

            set {
                SetValue(ref _horizontalLength, value);
            }
        }

        private bottomFeatureClassification? _bottomFeatureClassification = default;
        [Category("BottomFeature")]
        public bottomFeatureClassification? bottomFeatureClassification {
            get {
                return _bottomFeatureClassification;
            }

            set {
                SetValue(ref _bottomFeatureClassification, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("BottomFeature")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private Decimal? _verticalLength = default;
        [Category("BottomFeature")]
        public Decimal? verticalLength {
            get {
                return _verticalLength;
            }

            set {
                SetValue(ref _verticalLength, value);
            }
        }

        public class BottomFeatureRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["BottomFeature"];
        }

        public void Load(DomainModel.S501.FeatureTypes.BottomFeature instance) {
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            migrationDirection = instance.migrationDirection;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            horizontalLength = instance.horizontalLength;
            bottomFeatureClassification = instance.bottomFeatureClassification;
            reportedDate = instance.reportedDate;
            verticalLength = instance.verticalLength;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.BottomFeature
            {
                information = this.information.ToList(),
                migrationDirection = this.migrationDirection,
                featureName = this.featureName.ToList(),
                horizontalLength = this.horizontalLength,
                bottomFeatureClassification = this.bottomFeatureClassification,
                reportedDate = this.reportedDate,
                verticalLength = this.verticalLength,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.BottomFeature Model => new()
        {
            information = this.information.ToList(),
            migrationDirection = this._migrationDirection,
            featureName = this.featureName.ToList(),
            horizontalLength = this._horizontalLength,
            bottomFeatureClassification = this._bottomFeatureClassification,
            reportedDate = this._reportedDate,
            verticalLength = this._verticalLength,
        };

        public BottomFeatureViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
        }

        public override string? ToString() => $"Bottom Feature";
    }

    [CategoryOrder("ArchipelagicBaseline", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ArchipelagicBaselineViewModel : ViewModelBase {
        private DateOnly? _reportedDate = default;
        [Category("ArchipelagicBaseline")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private status? _status = default;
        [Category("ArchipelagicBaseline")]
        public status? status {
            get {
                return _status;
            }

            set {
                SetValue(ref _status, value);
            }
        }

        private Boolean? _inDispute = default;
        [Category("ArchipelagicBaseline")]
        public Boolean? inDispute {
            get {
                return _inDispute;
            }

            set {
                SetValue(ref _inDispute, value);
            }
        }

        private String _nationality = string.Empty;
        [Category("ArchipelagicBaseline")]
        public String nationality {
            get {
                return _nationality;
            }

            set {
                SetValue(ref _nationality, value);
            }
        }

        [Category("ArchipelagicBaseline")]
        public ObservableCollection<information> information { get; set; } = new();

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("ArchipelagicBaseline")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private String _agencyResponsibleForProduction = string.Empty;
        [Category("ArchipelagicBaseline")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("ArchipelagicBaseline")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        public class ArchipelagicBaselineRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["ArchipelagicBaseline"];
        }

        public void Load(DomainModel.S501.FeatureTypes.ArchipelagicBaseline instance) {
            reportedDate = instance.reportedDate;
            status = instance.status;
            inDispute = instance.inDispute;
            nationality = instance.nationality;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            scaleMinimum = instance.scaleMinimum;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.ArchipelagicBaseline
            {
                reportedDate = this.reportedDate,
                status = this.status,
                inDispute = this.inDispute,
                nationality = this.nationality,
                information = this.information.ToList(),
                sourceIdentification = this.sourceIdentification?.Model,
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                scaleMinimum = this.scaleMinimum,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.ArchipelagicBaseline Model => new()
        {
            reportedDate = this._reportedDate,
            status = this._status,
            inDispute = this._inDispute,
            nationality = this._nationality,
            information = this.information.ToList(),
            sourceIdentification = this._sourceIdentification?.Model,
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            scaleMinimum = this._scaleMinimum,
        };

        public ArchipelagicBaselineViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Archipelagic Baseline";
    }

    [CategoryOrder("SmallBottomObject", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class SmallBottomObjectViewModel : ViewModelBase {
        private String _agencyResponsibleForProduction = string.Empty;
        [Category("SmallBottomObject")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        private statusOfSmallBottomObject? _statusOfSmallBottomObject = default;
        [Category("SmallBottomObject")]
        public statusOfSmallBottomObject? statusOfSmallBottomObject {
            get {
                return _statusOfSmallBottomObject;
            }

            set {
                SetValue(ref _statusOfSmallBottomObject, value);
            }
        }

        [Category("SmallBottomObject")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        [Category("SmallBottomObject")]
        public ObservableCollection<information> information { get; set; } = new();

        private Decimal _valueOfSounding;
        [Category("SmallBottomObject")]
        public Decimal valueOfSounding {
            get {
                return _valueOfSounding;
            }

            set {
                SetValue(ref _valueOfSounding, value);
            }
        }

        public class SmallBottomObjectRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["SmallBottomObject"];
        }

        public void Load(DomainModel.S501.FeatureTypes.SmallBottomObject instance) {
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            statusOfSmallBottomObject = instance.statusOfSmallBottomObject;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            valueOfSounding = instance.valueOfSounding;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.SmallBottomObject
            {
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                statusOfSmallBottomObject = this.statusOfSmallBottomObject,
                featureName = this.featureName.ToList(),
                information = this.information.ToList(),
                valueOfSounding = this.valueOfSounding,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.SmallBottomObject Model => new()
        {
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            statusOfSmallBottomObject = this._statusOfSmallBottomObject,
            featureName = this.featureName.ToList(),
            information = this.information.ToList(),
            valueOfSounding = this._valueOfSounding,
        };

        public SmallBottomObjectViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Small Bottom Object ";
    }

    [CategoryOrder("ExclusiveEconomicZone", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ExclusiveEconomicZoneViewModel : ViewModelBase {
        [Category("ExclusiveEconomicZone")]
        public ObservableCollection<String> nationalMaritimeAuthority { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("ExclusiveEconomicZone")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("ExclusiveEconomicZone")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        [Category("ExclusiveEconomicZone")]
        public ObservableCollection<information> information { get; set; } = new();

        private DateOnly? _reportedDate = default;
        [Category("ExclusiveEconomicZone")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("ExclusiveEconomicZone")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private String _interoperabilityIdentifier = string.Empty;
        [Category("ExclusiveEconomicZone")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private Boolean? _inDispute = default;
        [Category("ExclusiveEconomicZone")]
        public Boolean? inDispute {
            get {
                return _inDispute;
            }

            set {
                SetValue(ref _inDispute, value);
            }
        }

        [Category("ExclusiveEconomicZone")]
        public ObservableCollection<String> nationality { get; set; } = new();

        public class ExclusiveEconomicZoneRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["ExclusiveEconomicZone"];
        }

        public void Load(DomainModel.S501.FeatureTypes.ExclusiveEconomicZone instance) {
            nationalMaritimeAuthority.Clear();
            if (instance.nationalMaritimeAuthority is not null)
                foreach (var e in instance.nationalMaritimeAuthority)
                    nationalMaritimeAuthority.Add(e);
            scaleMinimum = instance.scaleMinimum;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            reportedDate = instance.reportedDate;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            inDispute = instance.inDispute;
            nationality.Clear();
            if (instance.nationality is not null)
                foreach (var e in instance.nationality)
                    nationality.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.ExclusiveEconomicZone
            {
                nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
                scaleMinimum = this.scaleMinimum,
                sourceIdentification = this.sourceIdentification?.Model,
                information = this.information.ToList(),
                reportedDate = this.reportedDate,
                featureName = this.featureName.ToList(),
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                inDispute = this.inDispute,
                nationality = this.nationality.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.ExclusiveEconomicZone Model => new()
        {
            nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
            scaleMinimum = this._scaleMinimum,
            sourceIdentification = this._sourceIdentification?.Model,
            information = this.information.ToList(),
            reportedDate = this._reportedDate,
            featureName = this.featureName.ToList(),
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            inDispute = this._inDispute,
            nationality = this.nationality.ToList(),
        };

        public ExclusiveEconomicZoneViewModel() : base() {
            nationalMaritimeAuthority.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(nationalMaritimeAuthority));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            nationality.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(nationality));
            };
        }

        public override string? ToString() => $"Exclusive Economic Zone";
    }

    [CategoryOrder("RadarStation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class RadarStationViewModel : ViewModelBase {
        [Category("RadarStation")]
        public ObservableCollection<status> status { get; set; } = new();

        private categoryOfRadarStation? _categoryOfRadarStation = default;
        [Category("RadarStation")]
        public categoryOfRadarStation? categoryOfRadarStation {
            get {
                return _categoryOfRadarStation;
            }

            set {
                SetValue(ref _categoryOfRadarStation, value);
            }
        }

        private Decimal? _height = default;
        [Category("RadarStation")]
        public Decimal? height {
            get {
                return _height;
            }

            set {
                SetValue(ref _height, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("RadarStation")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private String _callsign = string.Empty;
        [Category("RadarStation")]
        public String callsign {
            get {
                return _callsign;
            }

            set {
                SetValue(ref _callsign, value);
            }
        }

        [Category("RadarStation")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("RadarStation")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("RadarStation")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("RadarStation")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("RadarStation")]
        public ObservableCollection<String> communicationChannel { get; set; } = new();

        private Decimal? _valueOfMaximumRange = default;
        [Category("RadarStation")]
        public Decimal? valueOfMaximumRange {
            get {
                return _valueOfMaximumRange;
            }

            set {
                SetValue(ref _valueOfMaximumRange, value);
            }
        }

        public class RadarStationRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["RadarStation"];
        }

        public void Load(DomainModel.S501.FeatureTypes.RadarStation instance) {
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            categoryOfRadarStation = instance.categoryOfRadarStation;
            height = instance.height;
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            callsign = instance.callsign;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            scaleMinimum = instance.scaleMinimum;
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            communicationChannel.Clear();
            if (instance.communicationChannel is not null)
                foreach (var e in instance.communicationChannel)
                    communicationChannel.Add(e);
            valueOfMaximumRange = instance.valueOfMaximumRange;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.RadarStation
            {
                status = this.status.ToList(),
                categoryOfRadarStation = this.categoryOfRadarStation,
                height = this.height,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                callsign = this.callsign,
                featureName = this.featureName.ToList(),
                scaleMinimum = this.scaleMinimum,
                periodicDateRange = this.periodicDateRange.ToList(),
                information = this.information.ToList(),
                communicationChannel = this.communicationChannel.ToList(),
                valueOfMaximumRange = this.valueOfMaximumRange,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.RadarStation Model => new()
        {
            status = this.status.ToList(),
            categoryOfRadarStation = this._categoryOfRadarStation,
            height = this._height,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            callsign = this._callsign,
            featureName = this.featureName.ToList(),
            scaleMinimum = this._scaleMinimum,
            periodicDateRange = this.periodicDateRange.ToList(),
            information = this.information.ToList(),
            communicationChannel = this.communicationChannel.ToList(),
            valueOfMaximumRange = this._valueOfMaximumRange,
        };

        public RadarStationViewModel() : base() {
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            communicationChannel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(communicationChannel));
            };
        }

        public override string? ToString() => $"Radar Station";
    }

    [CategoryOrder("DivingLocation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class DivingLocationViewModel : ViewModelBase {
        private Decimal? _waterClarity = default;
        [Category("DivingLocation")]
        public Decimal? waterClarity {
            get {
                return _waterClarity;
            }

            set {
                SetValue(ref _waterClarity, value);
            }
        }

        [Category("DivingLocation")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private divingActivity? _divingActivity = default;
        [Category("DivingLocation")]
        public divingActivity? divingActivity {
            get {
                return _divingActivity;
            }

            set {
                SetValue(ref _divingActivity, value);
            }
        }

        public class DivingLocationRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["DivingLocation"];
        }

        public void Load(DomainModel.S501.FeatureTypes.DivingLocation instance) {
            waterClarity = instance.waterClarity;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            divingActivity = instance.divingActivity;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.DivingLocation
            {
                waterClarity = this.waterClarity,
                featureName = this.featureName.ToList(),
                divingActivity = this.divingActivity,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.DivingLocation Model => new()
        {
            waterClarity = this._waterClarity,
            featureName = this.featureName.ToList(),
            divingActivity = this._divingActivity,
        };

        public DivingLocationViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
        }

        public override string? ToString() => $"Diving Location";
    }

    [CategoryOrder("RestrictedArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class RestrictedAreaViewModel : ViewModelBase {
        [Category("RestrictedArea")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("RestrictedArea")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("RestrictedArea")]
        public ObservableCollection<categoryOfRestrictedArea> categoryOfRestrictedArea { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("RestrictedArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private String _nationality = string.Empty;
        [Category("RestrictedArea")]
        public String nationality {
            get {
                return _nationality;
            }

            set {
                SetValue(ref _nationality, value);
            }
        }

        [Category("RestrictedArea")]
        public ObservableCollection<status> status { get; set; } = new();

        [Category("RestrictedArea")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("RestrictedArea")]
        public ObservableCollection<vesselSpeedLimit> vesselSpeedLimit { get; set; } = new();

        [Category("RestrictedArea")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        private String _interoperabilityIdentifier = string.Empty;
        [Category("RestrictedArea")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private String _controllingAuthority = string.Empty;
        [Category("RestrictedArea")]
        public String controllingAuthority {
            get {
                return _controllingAuthority;
            }

            set {
                SetValue(ref _controllingAuthority, value);
            }
        }

        [Category("RestrictedArea")]
        public ObservableCollection<restriction> restriction { get; set; } = new();

        public class RestrictedAreaRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["RestrictedArea"];
        }

        public void Load(DomainModel.S501.FeatureTypes.RestrictedArea instance) {
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            scaleMinimum = instance.scaleMinimum;
            categoryOfRestrictedArea.Clear();
            if (instance.categoryOfRestrictedArea is not null)
                foreach (var e in instance.categoryOfRestrictedArea)
                    categoryOfRestrictedArea.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            nationality = instance.nationality;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            vesselSpeedLimit.Clear();
            if (instance.vesselSpeedLimit is not null)
                foreach (var e in instance.vesselSpeedLimit)
                    vesselSpeedLimit.Add(e);
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            controllingAuthority = instance.controllingAuthority;
            restriction.Clear();
            if (instance.restriction is not null)
                foreach (var e in instance.restriction)
                    restriction.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.RestrictedArea
            {
                featureName = this.featureName.ToList(),
                scaleMinimum = this.scaleMinimum,
                categoryOfRestrictedArea = this.categoryOfRestrictedArea.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                nationality = this.nationality,
                status = this.status.ToList(),
                information = this.information.ToList(),
                vesselSpeedLimit = this.vesselSpeedLimit.ToList(),
                periodicDateRange = this.periodicDateRange.ToList(),
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                controllingAuthority = this.controllingAuthority,
                restriction = this.restriction.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.RestrictedArea Model => new()
        {
            featureName = this.featureName.ToList(),
            scaleMinimum = this._scaleMinimum,
            categoryOfRestrictedArea = this.categoryOfRestrictedArea.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            nationality = this._nationality,
            status = this.status.ToList(),
            information = this.information.ToList(),
            vesselSpeedLimit = this.vesselSpeedLimit.ToList(),
            periodicDateRange = this.periodicDateRange.ToList(),
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            controllingAuthority = this._controllingAuthority,
            restriction = this.restriction.ToList(),
        };

        public RestrictedAreaViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            categoryOfRestrictedArea.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(categoryOfRestrictedArea));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            vesselSpeedLimit.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(vesselSpeedLimit));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(restriction));
            };
        }

        public override string? ToString() => $"Restricted Area";
    }

    [CategoryOrder("CableSubmarine", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class CableSubmarineViewModel : ViewModelBase {
        [Category("CableSubmarine")]
        public ObservableCollection<status> status { get; set; } = new();

        private Decimal? _depthRangeMinimumValue = default;
        [Category("CableSubmarine")]
        public Decimal? depthRangeMinimumValue {
            get {
                return _depthRangeMinimumValue;
            }

            set {
                SetValue(ref _depthRangeMinimumValue, value);
            }
        }

        private Decimal? _buriedDepth = default;
        [Category("CableSubmarine")]
        public Decimal? buriedDepth {
            get {
                return _buriedDepth;
            }

            set {
                SetValue(ref _buriedDepth, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("CableSubmarine")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("CableSubmarine")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        [Category("CableSubmarine")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private categoryOfCable? _categoryOfCable = default;
        [Category("CableSubmarine")]
        public categoryOfCable? categoryOfCable {
            get {
                return _categoryOfCable;
            }

            set {
                SetValue(ref _categoryOfCable, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("CableSubmarine")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private condition? _condition = default;
        [Category("CableSubmarine")]
        public condition? condition {
            get {
                return _condition;
            }

            set {
                SetValue(ref _condition, value);
            }
        }

        [Category("CableSubmarine")]
        public ObservableCollection<information> information { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("CableSubmarine")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private String _agencyResponsibleForProduction = string.Empty;
        [Category("CableSubmarine")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("CableSubmarine")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        public class CableSubmarineRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["CableSubmarine"];
        }

        public void Load(DomainModel.S501.FeatureTypes.CableSubmarine instance) {
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            depthRangeMinimumValue = instance.depthRangeMinimumValue;
            buriedDepth = instance.buriedDepth;
            reportedDate = instance.reportedDate;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            categoryOfCable = instance.categoryOfCable;
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            condition = instance.condition;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            scaleMinimum = instance.scaleMinimum;
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.CableSubmarine
            {
                status = this.status.ToList(),
                depthRangeMinimumValue = this.depthRangeMinimumValue,
                buriedDepth = this.buriedDepth,
                reportedDate = this.reportedDate,
                sourceIdentification = this.sourceIdentification?.Model,
                featureName = this.featureName.ToList(),
                categoryOfCable = this.categoryOfCable,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                condition = this.condition,
                information = this.information.ToList(),
                scaleMinimum = this.scaleMinimum,
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                fixedDateRange = this.fixedDateRange?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.CableSubmarine Model => new()
        {
            status = this.status.ToList(),
            depthRangeMinimumValue = this._depthRangeMinimumValue,
            buriedDepth = this._buriedDepth,
            reportedDate = this._reportedDate,
            sourceIdentification = this._sourceIdentification?.Model,
            featureName = this.featureName.ToList(),
            categoryOfCable = this._categoryOfCable,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            condition = this._condition,
            information = this.information.ToList(),
            scaleMinimum = this._scaleMinimum,
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            fixedDateRange = this._fixedDateRange?.Model,
        };

        public CableSubmarineViewModel() : base() {
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Cable Submarine";
    }

    [CategoryOrder("Wreck", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class WreckViewModel : ViewModelBase {
        private Decimal? _surroundingDepth = default;
        [Category("Wreck")]
        public Decimal? surroundingDepth {
            get {
                return _surroundingDepth;
            }

            set {
                SetValue(ref _surroundingDepth, value);
            }
        }

        [Category("Wreck")]
        public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = new();

        private horizontalPositionUncertaintyViewModel? _horizontalPositionUncertainty;
        [Category("Wreck")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public horizontalPositionUncertaintyViewModel? horizontalPositionUncertainty {
            get {
                return _horizontalPositionUncertainty;
            }

            set {
                SetValue(ref _horizontalPositionUncertainty, value);
            }
        }

        private visualProminence? _visualProminence = default;
        [Category("Wreck")]
        public visualProminence? visualProminence {
            get {
                return _visualProminence;
            }

            set {
                SetValue(ref _visualProminence, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("Wreck")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private Decimal? _horizontalLength = default;
        [Category("Wreck")]
        public Decimal? horizontalLength {
            get {
                return _horizontalLength;
            }

            set {
                SetValue(ref _horizontalLength, value);
            }
        }

        private Boolean? _radarConspicuous = default;
        [Category("Wreck")]
        public Boolean? radarConspicuous {
            get {
                return _radarConspicuous;
            }

            set {
                SetValue(ref _radarConspicuous, value);
            }
        }

        private String _currentScourDimensions = string.Empty;
        [Category("Wreck")]
        public String currentScourDimensions {
            get {
                return _currentScourDimensions;
            }

            set {
                SetValue(ref _currentScourDimensions, value);
            }
        }

        [Category("Wreck")]
        public ObservableCollection<status> status { get; set; } = new();

        private sonarSignalStrength? _sonarSignalStrength = default;
        [Category("Wreck")]
        public sonarSignalStrength? sonarSignalStrength {
            get {
                return _sonarSignalStrength;
            }

            set {
                SetValue(ref _sonarSignalStrength, value);
            }
        }

        [Category("Wreck")]
        public ObservableCollection<information> information { get; set; } = new();

        private magneticInformationViewModel? _magneticInformation;
        [Category("Wreck")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public magneticInformationViewModel? magneticInformation {
            get {
                return _magneticInformation;
            }

            set {
                SetValue(ref _magneticInformation, value);
            }
        }

        private String _agencyResponsibleForProduction = string.Empty;
        [Category("Wreck")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        [Category("Wreck")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        private Decimal? _defaultClearanceDepth = default;
        [Category("Wreck")]
        public Decimal? defaultClearanceDepth {
            get {
                return _defaultClearanceDepth;
            }

            set {
                SetValue(ref _defaultClearanceDepth, value);
            }
        }

        private natureOfSurface? _natureOfSurface = default;
        [Category("Wreck")]
        public natureOfSurface? natureOfSurface {
            get {
                return _natureOfSurface;
            }

            set {
                SetValue(ref _natureOfSurface, value);
            }
        }

        private Decimal? _orientationValue = default;
        [Category("Wreck")]
        public Decimal? orientationValue {
            get {
                return _orientationValue;
            }

            set {
                SetValue(ref _orientationValue, value);
            }
        }

        private String _typeOfWreck = string.Empty;
        [Category("Wreck")]
        public String typeOfWreck {
            get {
                return _typeOfWreck;
            }

            set {
                SetValue(ref _typeOfWreck, value);
            }
        }

        private waterLevelEffect _waterLevelEffect;
        [Category("Wreck")]
        public waterLevelEffect waterLevelEffect {
            get {
                return _waterLevelEffect;
            }

            set {
                SetValue(ref _waterLevelEffect, value);
            }
        }

        private Decimal? _verticalLength = default;
        [Category("Wreck")]
        public Decimal? verticalLength {
            get {
                return _verticalLength;
            }

            set {
                SetValue(ref _verticalLength, value);
            }
        }

        private categoryOfWreck? _categoryOfWreck = default;
        [Category("Wreck")]
        public categoryOfWreck? categoryOfWreck {
            get {
                return _categoryOfWreck;
            }

            set {
                SetValue(ref _categoryOfWreck, value);
            }
        }

        private qualityOfHorizontalMeasurement? _qualityOfHorizontalMeasurement = default;
        [Category("Wreck")]
        public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement {
            get {
                return _qualityOfHorizontalMeasurement;
            }

            set {
                SetValue(ref _qualityOfHorizontalMeasurement, value);
            }
        }

        private verticalUncertaintyViewModel? _verticalUncertainty;
        [Category("Wreck")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public verticalUncertaintyViewModel? verticalUncertainty {
            get {
                return _verticalUncertainty;
            }

            set {
                SetValue(ref _verticalUncertainty, value);
            }
        }

        private Decimal? _height = default;
        [Category("Wreck")]
        public Decimal? height {
            get {
                return _height;
            }

            set {
                SetValue(ref _height, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("Wreck")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private String _debrisField = string.Empty;
        [Category("Wreck")]
        public String debrisField {
            get {
                return _debrisField;
            }

            set {
                SetValue(ref _debrisField, value);
            }
        }

        [Category("Wreck")]
        public ObservableCollection<String> nationality { get; set; } = new();

        private lastSourceInformationViewModel? _lastSourceInformation;
        [Category("Wreck")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public lastSourceInformationViewModel? lastSourceInformation {
            get {
                return _lastSourceInformation;
            }

            set {
                SetValue(ref _lastSourceInformation, value);
            }
        }

        private qualityOfVerticalMeasurement? _qualityOfVerticalMeasurement = default;
        [Category("Wreck")]
        public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement {
            get {
                return _qualityOfVerticalMeasurement;
            }

            set {
                SetValue(ref _qualityOfVerticalMeasurement, value);
            }
        }

        private cardinalPointOrientation? _cardinalPointOrientation = default;
        [Category("Wreck")]
        public cardinalPointOrientation? cardinalPointOrientation {
            get {
                return _cardinalPointOrientation;
            }

            set {
                SetValue(ref _cardinalPointOrientation, value);
            }
        }

        [Category("Wreck")]
        public ObservableCollection<vesselMeasurementsSpecification> vesselMeasurementsSpecification { get; set; } = new();

        private Boolean? _existenceOfRestrictedArea = default;
        [Category("Wreck")]
        public Boolean? existenceOfRestrictedArea {
            get {
                return _existenceOfRestrictedArea;
            }

            set {
                SetValue(ref _existenceOfRestrictedArea, value);
            }
        }

        private DateOnly? _dateSunk = default;
        [Category("Wreck")]
        public DateOnly? dateSunk {
            get {
                return _dateSunk;
            }

            set {
                SetValue(ref _dateSunk, value);
            }
        }

        private firstSourceInformationViewModel? _firstSourceInformation;
        [Category("Wreck")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public firstSourceInformationViewModel? firstSourceInformation {
            get {
                return _firstSourceInformation;
            }

            set {
                SetValue(ref _firstSourceInformation, value);
            }
        }

        private Decimal? _horizontalWidth = default;
        [Category("Wreck")]
        public Decimal? horizontalWidth {
            get {
                return _horizontalWidth;
            }

            set {
                SetValue(ref _horizontalWidth, value);
            }
        }

        private Decimal? _valueOfSounding = default;
        [Category("Wreck")]
        public Decimal? valueOfSounding {
            get {
                return _valueOfSounding;
            }

            set {
                SetValue(ref _valueOfSounding, value);
            }
        }

        [Category("Wreck")]
        public ObservableCollection<product> product { get; set; } = new();

        private String _pictorialRepresentation = string.Empty;
        [Category("Wreck")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        private Boolean? _displayUncertainties = default;
        [Category("Wreck")]
        public Boolean? displayUncertainties {
            get {
                return _displayUncertainties;
            }

            set {
                SetValue(ref _displayUncertainties, value);
            }
        }

        private expositionOfSounding? _expositionOfSounding = default;
        [Category("Wreck")]
        public expositionOfSounding? expositionOfSounding {
            get {
                return _expositionOfSounding;
            }

            set {
                SetValue(ref _expositionOfSounding, value);
            }
        }

        [Category("Wreck")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        public class WreckRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["Wreck"];
        }

        public void Load(DomainModel.S501.FeatureTypes.Wreck instance) {
            surroundingDepth = instance.surroundingDepth;
            techniqueOfVerticalMeasurement.Clear();
            if (instance.techniqueOfVerticalMeasurement is not null)
                foreach (var e in instance.techniqueOfVerticalMeasurement)
                    techniqueOfVerticalMeasurement.Add(e);
            horizontalPositionUncertainty = new();
            if (instance.horizontalPositionUncertainty != null) {
                horizontalPositionUncertainty = new();
                horizontalPositionUncertainty.Load(instance.horizontalPositionUncertainty);
            }

            visualProminence = instance.visualProminence;
            reportedDate = instance.reportedDate;
            horizontalLength = instance.horizontalLength;
            radarConspicuous = instance.radarConspicuous;
            currentScourDimensions = instance.currentScourDimensions;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            sonarSignalStrength = instance.sonarSignalStrength;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            magneticInformation = new();
            if (instance.magneticInformation != null) {
                magneticInformation = new();
                magneticInformation.Load(instance.magneticInformation);
            }

            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            natureOfConstruction.Clear();
            if (instance.natureOfConstruction is not null)
                foreach (var e in instance.natureOfConstruction)
                    natureOfConstruction.Add(e);
            defaultClearanceDepth = instance.defaultClearanceDepth;
            natureOfSurface = instance.natureOfSurface;
            orientationValue = instance.orientationValue;
            typeOfWreck = instance.typeOfWreck;
            waterLevelEffect = instance.waterLevelEffect;
            verticalLength = instance.verticalLength;
            categoryOfWreck = instance.categoryOfWreck;
            qualityOfHorizontalMeasurement = instance.qualityOfHorizontalMeasurement;
            verticalUncertainty = new();
            if (instance.verticalUncertainty != null) {
                verticalUncertainty = new();
                verticalUncertainty.Load(instance.verticalUncertainty);
            }

            height = instance.height;
            scaleMinimum = instance.scaleMinimum;
            debrisField = instance.debrisField;
            nationality.Clear();
            if (instance.nationality is not null)
                foreach (var e in instance.nationality)
                    nationality.Add(e);
            lastSourceInformation = new();
            if (instance.lastSourceInformation != null) {
                lastSourceInformation = new();
                lastSourceInformation.Load(instance.lastSourceInformation);
            }

            qualityOfVerticalMeasurement = instance.qualityOfVerticalMeasurement;
            cardinalPointOrientation = instance.cardinalPointOrientation;
            vesselMeasurementsSpecification.Clear();
            if (instance.vesselMeasurementsSpecification is not null)
                foreach (var e in instance.vesselMeasurementsSpecification)
                    vesselMeasurementsSpecification.Add(e);
            existenceOfRestrictedArea = instance.existenceOfRestrictedArea;
            dateSunk = instance.dateSunk;
            firstSourceInformation = new();
            if (instance.firstSourceInformation != null) {
                firstSourceInformation = new();
                firstSourceInformation.Load(instance.firstSourceInformation);
            }

            horizontalWidth = instance.horizontalWidth;
            valueOfSounding = instance.valueOfSounding;
            product.Clear();
            if (instance.product is not null)
                foreach (var e in instance.product)
                    product.Add(e);
            pictorialRepresentation = instance.pictorialRepresentation;
            displayUncertainties = instance.displayUncertainties;
            expositionOfSounding = instance.expositionOfSounding;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.Wreck
            {
                surroundingDepth = this.surroundingDepth,
                techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
                horizontalPositionUncertainty = this.horizontalPositionUncertainty?.Model,
                visualProminence = this.visualProminence,
                reportedDate = this.reportedDate,
                horizontalLength = this.horizontalLength,
                radarConspicuous = this.radarConspicuous,
                currentScourDimensions = this.currentScourDimensions,
                status = this.status.ToList(),
                sonarSignalStrength = this.sonarSignalStrength,
                information = this.information.ToList(),
                magneticInformation = this.magneticInformation?.Model,
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                natureOfConstruction = this.natureOfConstruction.ToList(),
                defaultClearanceDepth = this.defaultClearanceDepth,
                natureOfSurface = this.natureOfSurface,
                orientationValue = this.orientationValue,
                typeOfWreck = this.typeOfWreck,
                waterLevelEffect = this.waterLevelEffect,
                verticalLength = this.verticalLength,
                categoryOfWreck = this.categoryOfWreck,
                qualityOfHorizontalMeasurement = this.qualityOfHorizontalMeasurement,
                verticalUncertainty = this.verticalUncertainty?.Model,
                height = this.height,
                scaleMinimum = this.scaleMinimum,
                debrisField = this.debrisField,
                nationality = this.nationality.ToList(),
                lastSourceInformation = this.lastSourceInformation?.Model,
                qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement,
                cardinalPointOrientation = this.cardinalPointOrientation,
                vesselMeasurementsSpecification = this.vesselMeasurementsSpecification.ToList(),
                existenceOfRestrictedArea = this.existenceOfRestrictedArea,
                dateSunk = this.dateSunk,
                firstSourceInformation = this.firstSourceInformation?.Model,
                horizontalWidth = this.horizontalWidth,
                valueOfSounding = this.valueOfSounding,
                product = this.product.ToList(),
                pictorialRepresentation = this.pictorialRepresentation,
                displayUncertainties = this.displayUncertainties,
                expositionOfSounding = this.expositionOfSounding,
                featureName = this.featureName.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.Wreck Model => new()
        {
            surroundingDepth = this._surroundingDepth,
            techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
            horizontalPositionUncertainty = this._horizontalPositionUncertainty?.Model,
            visualProminence = this._visualProminence,
            reportedDate = this._reportedDate,
            horizontalLength = this._horizontalLength,
            radarConspicuous = this._radarConspicuous,
            currentScourDimensions = this._currentScourDimensions,
            status = this.status.ToList(),
            sonarSignalStrength = this._sonarSignalStrength,
            information = this.information.ToList(),
            magneticInformation = this._magneticInformation?.Model,
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            natureOfConstruction = this.natureOfConstruction.ToList(),
            defaultClearanceDepth = this._defaultClearanceDepth,
            natureOfSurface = this._natureOfSurface,
            orientationValue = this._orientationValue,
            typeOfWreck = this._typeOfWreck,
            waterLevelEffect = this._waterLevelEffect,
            verticalLength = this._verticalLength,
            categoryOfWreck = this._categoryOfWreck,
            qualityOfHorizontalMeasurement = this._qualityOfHorizontalMeasurement,
            verticalUncertainty = this._verticalUncertainty?.Model,
            height = this._height,
            scaleMinimum = this._scaleMinimum,
            debrisField = this._debrisField,
            nationality = this.nationality.ToList(),
            lastSourceInformation = this._lastSourceInformation?.Model,
            qualityOfVerticalMeasurement = this._qualityOfVerticalMeasurement,
            cardinalPointOrientation = this._cardinalPointOrientation,
            vesselMeasurementsSpecification = this.vesselMeasurementsSpecification.ToList(),
            existenceOfRestrictedArea = this._existenceOfRestrictedArea,
            dateSunk = this._dateSunk,
            firstSourceInformation = this._firstSourceInformation?.Model,
            horizontalWidth = this._horizontalWidth,
            valueOfSounding = this._valueOfSounding,
            product = this.product.ToList(),
            pictorialRepresentation = this._pictorialRepresentation,
            displayUncertainties = this._displayUncertainties,
            expositionOfSounding = this._expositionOfSounding,
            featureName = this.featureName.ToList(),
        };

        public WreckViewModel() : base() {
            techniqueOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(techniqueOfVerticalMeasurement));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(natureOfConstruction));
            };
            nationality.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(nationality));
            };
            vesselMeasurementsSpecification.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(vesselMeasurementsSpecification));
            };
            product.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(product));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
        }

        public override string? ToString() => $"Wreck";
    }

    [CategoryOrder("QRoute", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class QRouteViewModel : ViewModelBase {
        private String _agencyResponsibleForProduction = string.Empty;
        [Category("QRoute")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        [Category("QRoute")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("QRoute")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        [Category("QRoute")]
        public ObservableCollection<status> status { get; set; } = new();

        private qRouteChannelWidthViewModel? _qRouteChannelWidth;
        [Category("QRoute")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public qRouteChannelWidthViewModel? qRouteChannelWidth {
            get {
                return _qRouteChannelWidth;
            }

            set {
                SetValue(ref _qRouteChannelWidth, value);
            }
        }

        private directionHeadingViewModel? _directionHeading;
        [Category("QRoute")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public directionHeadingViewModel? directionHeading {
            get {
                return _directionHeading;
            }

            set {
                SetValue(ref _directionHeading, value);
            }
        }

        private String _nationality = string.Empty;
        [Category("QRoute")]
        public String nationality {
            get {
                return _nationality;
            }

            set {
                SetValue(ref _nationality, value);
            }
        }

        public class QRouteRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["QRoute"];
        }

        public void Load(DomainModel.S501.FeatureTypes.QRoute instance) {
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            qRouteChannelWidth = new();
            if (instance.qRouteChannelWidth != null) {
                qRouteChannelWidth = new();
                qRouteChannelWidth.Load(instance.qRouteChannelWidth);
            }

            directionHeading = new();
            if (instance.directionHeading != null) {
                directionHeading = new();
                directionHeading.Load(instance.directionHeading);
            }

            nationality = instance.nationality;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.QRoute
            {
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                information = this.information.ToList(),
                featureName = this.featureName.ToList(),
                status = this.status.ToList(),
                qRouteChannelWidth = this.qRouteChannelWidth?.Model,
                directionHeading = this.directionHeading?.Model,
                nationality = this.nationality,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.QRoute Model => new()
        {
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            information = this.information.ToList(),
            featureName = this.featureName.ToList(),
            status = this.status.ToList(),
            qRouteChannelWidth = this._qRouteChannelWidth?.Model,
            directionHeading = this._directionHeading?.Model,
            nationality = this._nationality,
        };

        public QRouteViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
        }

        public override string? ToString() => $"Q-Route";
    }

    [CategoryOrder("CompletenessOfProductSpecification", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class CompletenessOfProductSpecificationViewModel : ViewModelBase {
        private String _agencyResponsibleForProduction = string.Empty;
        [Category("CompletenessOfProductSpecification")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        private categoryOfCompleteness _categoryOfCompleteness;
        [Category("CompletenessOfProductSpecification")]
        public categoryOfCompleteness categoryOfCompleteness {
            get {
                return _categoryOfCompleteness;
            }

            set {
                SetValue(ref _categoryOfCompleteness, value);
            }
        }

        private String _copyrightStatement = string.Empty;
        [Category("CompletenessOfProductSpecification")]
        public String copyrightStatement {
            get {
                return _copyrightStatement;
            }

            set {
                SetValue(ref _copyrightStatement, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("CompletenessOfProductSpecification")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("CompletenessOfProductSpecification")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        [Category("CompletenessOfProductSpecification")]
        public ObservableCollection<information> information { get; set; } = new();

        public class CompletenessOfProductSpecificationRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["CompletenessOfProductSpecification"];
        }

        public void Load(DomainModel.S501.FeatureTypes.CompletenessOfProductSpecification instance) {
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            categoryOfCompleteness = instance.categoryOfCompleteness;
            copyrightStatement = instance.copyrightStatement;
            reportedDate = instance.reportedDate;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.CompletenessOfProductSpecification
            {
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                categoryOfCompleteness = this.categoryOfCompleteness,
                copyrightStatement = this.copyrightStatement,
                reportedDate = this.reportedDate,
                sourceIdentification = this.sourceIdentification?.Model,
                information = this.information.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.CompletenessOfProductSpecification Model => new()
        {
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            categoryOfCompleteness = this._categoryOfCompleteness,
            copyrightStatement = this._copyrightStatement,
            reportedDate = this._reportedDate,
            sourceIdentification = this._sourceIdentification?.Model,
            information = this.information.ToList(),
        };

        public CompletenessOfProductSpecificationViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"CompletenessOfProductSpecification (missing Name)";
    }

    [CategoryOrder("RescueStation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class RescueStationViewModel : ViewModelBase {
        [Category("RescueStation")]
        public ObservableCollection<status> status { get; set; } = new();

        [Category("RescueStation")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("RescueStation")]
        public ObservableCollection<String> communicationChannel { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("RescueStation")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("RescueStation")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private String _interoperabilityIdentifier = string.Empty;
        [Category("RescueStation")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        [Category("RescueStation")]
        public ObservableCollection<categoryOfRescueStation> categoryOfRescueStation { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("RescueStation")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("RescueStation")]
        public ObservableCollection<information> information { get; set; } = new();

        public class RescueStationRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["RescueStation"];
        }

        public void Load(DomainModel.S501.FeatureTypes.RescueStation instance) {
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            communicationChannel.Clear();
            if (instance.communicationChannel is not null)
                foreach (var e in instance.communicationChannel)
                    communicationChannel.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            categoryOfRescueStation.Clear();
            if (instance.categoryOfRescueStation is not null)
                foreach (var e in instance.categoryOfRescueStation)
                    categoryOfRescueStation.Add(e);
            scaleMinimum = instance.scaleMinimum;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.RescueStation
            {
                status = this.status.ToList(),
                periodicDateRange = this.periodicDateRange.ToList(),
                communicationChannel = this.communicationChannel.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                featureName = this.featureName.ToList(),
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                categoryOfRescueStation = this.categoryOfRescueStation.ToList(),
                scaleMinimum = this.scaleMinimum,
                information = this.information.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.RescueStation Model => new()
        {
            status = this.status.ToList(),
            periodicDateRange = this.periodicDateRange.ToList(),
            communicationChannel = this.communicationChannel.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            featureName = this.featureName.ToList(),
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            categoryOfRescueStation = this.categoryOfRescueStation.ToList(),
            scaleMinimum = this._scaleMinimum,
            information = this.information.ToList(),
        };

        public RescueStationViewModel() : base() {
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            communicationChannel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(communicationChannel));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            categoryOfRescueStation.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(categoryOfRescueStation));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Rescue Station";
    }

    [CategoryOrder("CardinalBeacon", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class CardinalBeaconViewModel : ViewModelBase {
        [Category("CardinalBeacon")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("CardinalBeacon")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        private colourPattern? _colourPattern = default;
        [Category("CardinalBeacon")]
        public colourPattern? colourPattern {
            get {
                return _colourPattern;
            }

            set {
                SetValue(ref _colourPattern, value);
            }
        }

        private Boolean? _radarConspicuous = default;
        [Category("CardinalBeacon")]
        public Boolean? radarConspicuous {
            get {
                return _radarConspicuous;
            }

            set {
                SetValue(ref _radarConspicuous, value);
            }
        }

        private beaconShape _beaconShape;
        [Category("CardinalBeacon")]
        public beaconShape beaconShape {
            get {
                return _beaconShape;
            }

            set {
                SetValue(ref _beaconShape, value);
            }
        }

        private topmarkViewModel? _topmark;
        [Category("CardinalBeacon")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public topmarkViewModel? topmark {
            get {
                return _topmark;
            }

            set {
                SetValue(ref _topmark, value);
            }
        }

        private categoryOfCardinalMark _categoryOfCardinalMark;
        [Category("CardinalBeacon")]
        public categoryOfCardinalMark categoryOfCardinalMark {
            get {
                return _categoryOfCardinalMark;
            }

            set {
                SetValue(ref _categoryOfCardinalMark, value);
            }
        }

        private marksNavigationalSystemOf? _marksNavigationalSystemOf = default;
        [Category("CardinalBeacon")]
        public marksNavigationalSystemOf? marksNavigationalSystemOf {
            get {
                return _marksNavigationalSystemOf;
            }

            set {
                SetValue(ref _marksNavigationalSystemOf, value);
            }
        }

        [Category("CardinalBeacon")]
        public ObservableCollection<status> status { get; set; } = new();

        private Decimal? _height = default;
        [Category("CardinalBeacon")]
        public Decimal? height {
            get {
                return _height;
            }

            set {
                SetValue(ref _height, value);
            }
        }

        [Category("CardinalBeacon")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("CardinalBeacon")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private Decimal? _verticalLength = default;
        [Category("CardinalBeacon")]
        public Decimal? verticalLength {
            get {
                return _verticalLength;
            }

            set {
                SetValue(ref _verticalLength, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("CardinalBeacon")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("CardinalBeacon")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("CardinalBeacon")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        [Category("CardinalBeacon")]
        public ObservableCollection<colour> colour { get; set; } = new();

        private Decimal? _elevation = default;
        [Category("CardinalBeacon")]
        public Decimal? elevation {
            get {
                return _elevation;
            }

            set {
                SetValue(ref _elevation, value);
            }
        }

        private String _pictorialRepresentation = string.Empty;
        [Category("CardinalBeacon")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        private condition? _condition = default;
        [Category("CardinalBeacon")]
        public condition? condition {
            get {
                return _condition;
            }

            set {
                SetValue(ref _condition, value);
            }
        }

        private visualProminence? _visualProminence = default;
        [Category("CardinalBeacon")]
        public visualProminence? visualProminence {
            get {
                return _visualProminence;
            }

            set {
                SetValue(ref _visualProminence, value);
            }
        }

        [Category("CardinalBeacon")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        public class CardinalBeaconRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["CardinalBeacon"];
        }

        public void Load(DomainModel.S501.FeatureTypes.CardinalBeacon instance) {
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            natureOfConstruction.Clear();
            if (instance.natureOfConstruction is not null)
                foreach (var e in instance.natureOfConstruction)
                    natureOfConstruction.Add(e);
            colourPattern = instance.colourPattern;
            radarConspicuous = instance.radarConspicuous;
            beaconShape = instance.beaconShape;
            topmark = new();
            if (instance.topmark != null) {
                topmark = new();
                topmark.Load(instance.topmark);
            }

            categoryOfCardinalMark = instance.categoryOfCardinalMark;
            marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            height = instance.height;
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            verticalLength = instance.verticalLength;
            scaleMinimum = instance.scaleMinimum;
            reportedDate = instance.reportedDate;
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            colour.Clear();
            if (instance.colour is not null)
                foreach (var e in instance.colour)
                    colour.Add(e);
            elevation = instance.elevation;
            pictorialRepresentation = instance.pictorialRepresentation;
            condition = instance.condition;
            visualProminence = instance.visualProminence;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.CardinalBeacon
            {
                information = this.information.ToList(),
                natureOfConstruction = this.natureOfConstruction.ToList(),
                colourPattern = this.colourPattern,
                radarConspicuous = this.radarConspicuous,
                beaconShape = this.beaconShape,
                topmark = this.topmark?.Model,
                categoryOfCardinalMark = this.categoryOfCardinalMark,
                marksNavigationalSystemOf = this.marksNavigationalSystemOf,
                status = this.status.ToList(),
                height = this.height,
                periodicDateRange = this.periodicDateRange.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                verticalLength = this.verticalLength,
                scaleMinimum = this.scaleMinimum,
                reportedDate = this.reportedDate,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                colour = this.colour.ToList(),
                elevation = this.elevation,
                pictorialRepresentation = this.pictorialRepresentation,
                condition = this.condition,
                visualProminence = this.visualProminence,
                featureName = this.featureName.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.CardinalBeacon Model => new()
        {
            information = this.information.ToList(),
            natureOfConstruction = this.natureOfConstruction.ToList(),
            colourPattern = this._colourPattern,
            radarConspicuous = this._radarConspicuous,
            beaconShape = this._beaconShape,
            topmark = this._topmark?.Model,
            categoryOfCardinalMark = this._categoryOfCardinalMark,
            marksNavigationalSystemOf = this._marksNavigationalSystemOf,
            status = this.status.ToList(),
            height = this._height,
            periodicDateRange = this.periodicDateRange.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            verticalLength = this._verticalLength,
            scaleMinimum = this._scaleMinimum,
            reportedDate = this._reportedDate,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            colour = this.colour.ToList(),
            elevation = this._elevation,
            pictorialRepresentation = this._pictorialRepresentation,
            condition = this._condition,
            visualProminence = this._visualProminence,
            featureName = this.featureName.ToList(),
        };

        public CardinalBeaconViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(natureOfConstruction));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(colour));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
        }

        public override string? ToString() => $"Cardinal Beacon";
    }

    [CategoryOrder("LightVessel", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class LightVesselViewModel : ViewModelBase {
        [Category("LightVessel")]
        public ObservableCollection<status> status { get; set; } = new();

        private visualProminence? _visualProminence = default;
        [Category("LightVessel")]
        public visualProminence? visualProminence {
            get {
                return _visualProminence;
            }

            set {
                SetValue(ref _visualProminence, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("LightVessel")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("LightVessel")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private Boolean? _radarConspicuous = default;
        [Category("LightVessel")]
        public Boolean? radarConspicuous {
            get {
                return _radarConspicuous;
            }

            set {
                SetValue(ref _radarConspicuous, value);
            }
        }

        [Category("LightVessel")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private String _pictorialRepresentation = string.Empty;
        [Category("LightVessel")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        private Decimal? _horizontalLength = default;
        [Category("LightVessel")]
        public Decimal? horizontalLength {
            get {
                return _horizontalLength;
            }

            set {
                SetValue(ref _horizontalLength, value);
            }
        }

        [Category("LightVessel")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("LightVessel")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("LightVessel")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("LightVessel")]
        public ObservableCollection<colour> colour { get; set; } = new();

        private colourPattern? _colourPattern = default;
        [Category("LightVessel")]
        public colourPattern? colourPattern {
            get {
                return _colourPattern;
            }

            set {
                SetValue(ref _colourPattern, value);
            }
        }

        [Category("LightVessel")]
        public ObservableCollection<information> information { get; set; } = new();

        private Decimal? _horizontalWidth = default;
        [Category("LightVessel")]
        public Decimal? horizontalWidth {
            get {
                return _horizontalWidth;
            }

            set {
                SetValue(ref _horizontalWidth, value);
            }
        }

        private Decimal? _verticalLength = default;
        [Category("LightVessel")]
        public Decimal? verticalLength {
            get {
                return _verticalLength;
            }

            set {
                SetValue(ref _verticalLength, value);
            }
        }

        public class LightVesselRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["LightVessel"];
        }

        public void Load(DomainModel.S501.FeatureTypes.LightVessel instance) {
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            visualProminence = instance.visualProminence;
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            scaleMinimum = instance.scaleMinimum;
            radarConspicuous = instance.radarConspicuous;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            pictorialRepresentation = instance.pictorialRepresentation;
            horizontalLength = instance.horizontalLength;
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            natureOfConstruction.Clear();
            if (instance.natureOfConstruction is not null)
                foreach (var e in instance.natureOfConstruction)
                    natureOfConstruction.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            colour.Clear();
            if (instance.colour is not null)
                foreach (var e in instance.colour)
                    colour.Add(e);
            colourPattern = instance.colourPattern;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            horizontalWidth = instance.horizontalWidth;
            verticalLength = instance.verticalLength;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.LightVessel
            {
                status = this.status.ToList(),
                visualProminence = this.visualProminence,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                scaleMinimum = this.scaleMinimum,
                radarConspicuous = this.radarConspicuous,
                featureName = this.featureName.ToList(),
                pictorialRepresentation = this.pictorialRepresentation,
                horizontalLength = this.horizontalLength,
                periodicDateRange = this.periodicDateRange.ToList(),
                natureOfConstruction = this.natureOfConstruction.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                colour = this.colour.ToList(),
                colourPattern = this.colourPattern,
                information = this.information.ToList(),
                horizontalWidth = this.horizontalWidth,
                verticalLength = this.verticalLength,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.LightVessel Model => new()
        {
            status = this.status.ToList(),
            visualProminence = this._visualProminence,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            scaleMinimum = this._scaleMinimum,
            radarConspicuous = this._radarConspicuous,
            featureName = this.featureName.ToList(),
            pictorialRepresentation = this._pictorialRepresentation,
            horizontalLength = this._horizontalLength,
            periodicDateRange = this.periodicDateRange.ToList(),
            natureOfConstruction = this.natureOfConstruction.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            colour = this.colour.ToList(),
            colourPattern = this._colourPattern,
            information = this.information.ToList(),
            horizontalWidth = this._horizontalWidth,
            verticalLength = this._verticalLength,
        };

        public LightVesselViewModel() : base() {
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(natureOfConstruction));
            };
            colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(colour));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Light Vessel";
    }

    [CategoryOrder("FisheryZone", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class FisheryZoneViewModel : ViewModelBase {
        private String _interoperabilityIdentifier = string.Empty;
        [Category("FisheryZone")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private String _nationality = string.Empty;
        [Category("FisheryZone")]
        public String nationality {
            get {
                return _nationality;
            }

            set {
                SetValue(ref _nationality, value);
            }
        }

        [Category("FisheryZone")]
        public ObservableCollection<String> nationalMaritimeAuthority { get; set; } = new();

        [Category("FisheryZone")]
        public ObservableCollection<String> species { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("FisheryZone")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("FisheryZone")]
        public ObservableCollection<information> information { get; set; } = new();

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("FisheryZone")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        [Category("FisheryZone")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private status? _status = default;
        [Category("FisheryZone")]
        public status? status {
            get {
                return _status;
            }

            set {
                SetValue(ref _status, value);
            }
        }

        public class FisheryZoneRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["FisheryZone"];
        }

        public void Load(DomainModel.S501.FeatureTypes.FisheryZone instance) {
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            nationality = instance.nationality;
            nationalMaritimeAuthority.Clear();
            if (instance.nationalMaritimeAuthority is not null)
                foreach (var e in instance.nationalMaritimeAuthority)
                    nationalMaritimeAuthority.Add(e);
            species.Clear();
            if (instance.species is not null)
                foreach (var e in instance.species)
                    species.Add(e);
            scaleMinimum = instance.scaleMinimum;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            status = instance.status;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.FisheryZone
            {
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                nationality = this.nationality,
                nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
                species = this.species.ToList(),
                scaleMinimum = this.scaleMinimum,
                information = this.information.ToList(),
                sourceIdentification = this.sourceIdentification?.Model,
                featureName = this.featureName.ToList(),
                status = this.status,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.FisheryZone Model => new()
        {
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            nationality = this._nationality,
            nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
            species = this.species.ToList(),
            scaleMinimum = this._scaleMinimum,
            information = this.information.ToList(),
            sourceIdentification = this._sourceIdentification?.Model,
            featureName = this.featureName.ToList(),
            status = this._status,
        };

        public FisheryZoneViewModel() : base() {
            nationalMaritimeAuthority.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(nationalMaritimeAuthority));
            };
            species.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(species));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
        }

        public override string? ToString() => $"Fishery Zone";
    }

    [CategoryOrder("DredgedArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class DredgedAreaViewModel : ViewModelBase {
        private Decimal? _maximumPermittedDraught = default;
        [Category("DredgedArea")]
        public Decimal? maximumPermittedDraught {
            get {
                return _maximumPermittedDraught;
            }

            set {
                SetValue(ref _maximumPermittedDraught, value);
            }
        }

        private verticalUncertaintyViewModel? _verticalUncertainty;
        [Category("DredgedArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public verticalUncertaintyViewModel? verticalUncertainty {
            get {
                return _verticalUncertainty;
            }

            set {
                SetValue(ref _verticalUncertainty, value);
            }
        }

        private DateOnly? _dredgedDate = default;
        [Category("DredgedArea")]
        public DateOnly? dredgedDate {
            get {
                return _dredgedDate;
            }

            set {
                SetValue(ref _dredgedDate, value);
            }
        }

        [Category("DredgedArea")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private Decimal? _depthRangeMaximumValue = default;
        [Category("DredgedArea")]
        public Decimal? depthRangeMaximumValue {
            get {
                return _depthRangeMaximumValue;
            }

            set {
                SetValue(ref _depthRangeMaximumValue, value);
            }
        }

        private qualityOfVerticalMeasurement? _qualityOfVerticalMeasurement = default;
        [Category("DredgedArea")]
        public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement {
            get {
                return _qualityOfVerticalMeasurement;
            }

            set {
                SetValue(ref _qualityOfVerticalMeasurement, value);
            }
        }

        [Category("DredgedArea")]
        public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = new();

        private Decimal _depthRangeMinimumValue;
        [Category("DredgedArea")]
        public Decimal depthRangeMinimumValue {
            get {
                return _depthRangeMinimumValue;
            }

            set {
                SetValue(ref _depthRangeMinimumValue, value);
            }
        }

        [Category("DredgedArea")]
        public ObservableCollection<restriction> restriction { get; set; } = new();

        [Category("DredgedArea")]
        public ObservableCollection<information> information { get; set; } = new();

        public class DredgedAreaRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["DredgedArea"];
        }

        public void Load(DomainModel.S501.FeatureTypes.DredgedArea instance) {
            maximumPermittedDraught = instance.maximumPermittedDraught;
            verticalUncertainty = new();
            if (instance.verticalUncertainty != null) {
                verticalUncertainty = new();
                verticalUncertainty.Load(instance.verticalUncertainty);
            }

            dredgedDate = instance.dredgedDate;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            depthRangeMaximumValue = instance.depthRangeMaximumValue;
            qualityOfVerticalMeasurement = instance.qualityOfVerticalMeasurement;
            techniqueOfVerticalMeasurement.Clear();
            if (instance.techniqueOfVerticalMeasurement is not null)
                foreach (var e in instance.techniqueOfVerticalMeasurement)
                    techniqueOfVerticalMeasurement.Add(e);
            depthRangeMinimumValue = instance.depthRangeMinimumValue;
            restriction.Clear();
            if (instance.restriction is not null)
                foreach (var e in instance.restriction)
                    restriction.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.DredgedArea
            {
                maximumPermittedDraught = this.maximumPermittedDraught,
                verticalUncertainty = this.verticalUncertainty?.Model,
                dredgedDate = this.dredgedDate,
                featureName = this.featureName.ToList(),
                depthRangeMaximumValue = this.depthRangeMaximumValue,
                qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement,
                techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
                depthRangeMinimumValue = this.depthRangeMinimumValue,
                restriction = this.restriction.ToList(),
                information = this.information.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.DredgedArea Model => new()
        {
            maximumPermittedDraught = this._maximumPermittedDraught,
            verticalUncertainty = this._verticalUncertainty?.Model,
            dredgedDate = this._dredgedDate,
            featureName = this.featureName.ToList(),
            depthRangeMaximumValue = this._depthRangeMaximumValue,
            qualityOfVerticalMeasurement = this._qualityOfVerticalMeasurement,
            techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
            depthRangeMinimumValue = this._depthRangeMinimumValue,
            restriction = this.restriction.ToList(),
            information = this.information.ToList(),
        };

        public DredgedAreaViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            techniqueOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(techniqueOfVerticalMeasurement));
            };
            restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(restriction));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Dredged Area";
    }

    [CategoryOrder("FerryRoute", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class FerryRouteViewModel : ViewModelBase {
        [Category("FerryRoute")]
        public ObservableCollection<status> status { get; set; } = new();

        private String _interoperabilityIdentifier = string.Empty;
        [Category("FerryRoute")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("FerryRoute")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("FerryRoute")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("FerryRoute")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        [Category("FerryRoute")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        private String _agencyResponsibleForProduction = string.Empty;
        [Category("FerryRoute")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        private String _pictorialRepresentation = string.Empty;
        [Category("FerryRoute")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FerryRoute")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FerryRoute")]
        public ObservableCollection<categoryOfFerry> categoryOfFerry { get; set; } = new();

        [Category("FerryRoute")]
        public ObservableCollection<information> information { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FerryRoute")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        public class FerryRouteRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["FerryRoute"];
        }

        public void Load(DomainModel.S501.FeatureTypes.FerryRoute instance) {
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            scaleMinimum = instance.scaleMinimum;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            pictorialRepresentation = instance.pictorialRepresentation;
            reportedDate = instance.reportedDate;
            categoryOfFerry.Clear();
            if (instance.categoryOfFerry is not null)
                foreach (var e in instance.categoryOfFerry)
                    categoryOfFerry.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.FerryRoute
            {
                status = this.status.ToList(),
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                scaleMinimum = this.scaleMinimum,
                featureName = this.featureName.ToList(),
                sourceIdentification = this.sourceIdentification?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                pictorialRepresentation = this.pictorialRepresentation,
                reportedDate = this.reportedDate,
                categoryOfFerry = this.categoryOfFerry.ToList(),
                information = this.information.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.FerryRoute Model => new()
        {
            status = this.status.ToList(),
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            scaleMinimum = this._scaleMinimum,
            featureName = this.featureName.ToList(),
            sourceIdentification = this._sourceIdentification?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            pictorialRepresentation = this._pictorialRepresentation,
            reportedDate = this._reportedDate,
            categoryOfFerry = this.categoryOfFerry.ToList(),
            information = this.information.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
        };

        public FerryRouteViewModel() : base() {
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            categoryOfFerry.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(categoryOfFerry));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Ferry Route";
    }

    [CategoryOrder("ShorelineConstruction", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ShorelineConstructionViewModel : ViewModelBase {
        private Decimal? _horizontalLength = default;
        [Category("ShorelineConstruction")]
        public Decimal? horizontalLength {
            get {
                return _horizontalLength;
            }

            set {
                SetValue(ref _horizontalLength, value);
            }
        }

        private gradientOfSlope? _gradientOfSlope = default;
        [Category("ShorelineConstruction")]
        public gradientOfSlope? gradientOfSlope {
            get {
                return _gradientOfSlope;
            }

            set {
                SetValue(ref _gradientOfSlope, value);
            }
        }

        [Category("ShorelineConstruction")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private condition? _condition = default;
        [Category("ShorelineConstruction")]
        public condition? condition {
            get {
                return _condition;
            }

            set {
                SetValue(ref _condition, value);
            }
        }

        private visualProminence? _visualProminence = default;
        [Category("ShorelineConstruction")]
        public visualProminence? visualProminence {
            get {
                return _visualProminence;
            }

            set {
                SetValue(ref _visualProminence, value);
            }
        }

        [Category("ShorelineConstruction")]
        public ObservableCollection<colour> colour { get; set; } = new();

        private Decimal? _horizontalWidth = default;
        [Category("ShorelineConstruction")]
        public Decimal? horizontalWidth {
            get {
                return _horizontalWidth;
            }

            set {
                SetValue(ref _horizontalWidth, value);
            }
        }

        private Boolean? _radarConspicuous = default;
        [Category("ShorelineConstruction")]
        public Boolean? radarConspicuous {
            get {
                return _radarConspicuous;
            }

            set {
                SetValue(ref _radarConspicuous, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("ShorelineConstruction")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private horizontalClearanceFixedViewModel? _horizontalClearanceFixed;
        [Category("ShorelineConstruction")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public horizontalClearanceFixedViewModel? horizontalClearanceFixed {
            get {
                return _horizontalClearanceFixed;
            }

            set {
                SetValue(ref _horizontalClearanceFixed, value);
            }
        }

        private String _pictorialRepresentation = string.Empty;
        [Category("ShorelineConstruction")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        [Category("ShorelineConstruction")]
        public ObservableCollection<status> status { get; set; } = new();

        private Decimal? _verticalLength = default;
        [Category("ShorelineConstruction")]
        public Decimal? verticalLength {
            get {
                return _verticalLength;
            }

            set {
                SetValue(ref _verticalLength, value);
            }
        }

        [Category("ShorelineConstruction")]
        public ObservableCollection<information> information { get; set; } = new();

        private waterLevelEffect _waterLevelEffect;
        [Category("ShorelineConstruction")]
        public waterLevelEffect waterLevelEffect {
            get {
                return _waterLevelEffect;
            }

            set {
                SetValue(ref _waterLevelEffect, value);
            }
        }

        [Category("ShorelineConstruction")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("ShorelineConstruction")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private categoryOfShorelineConstruction? _categoryOfShorelineConstruction = default;
        [Category("ShorelineConstruction")]
        public categoryOfShorelineConstruction? categoryOfShorelineConstruction {
            get {
                return _categoryOfShorelineConstruction;
            }

            set {
                SetValue(ref _categoryOfShorelineConstruction, value);
            }
        }

        private colourPattern? _colourPattern = default;
        [Category("ShorelineConstruction")]
        public colourPattern? colourPattern {
            get {
                return _colourPattern;
            }

            set {
                SetValue(ref _colourPattern, value);
            }
        }

        private Decimal? _height = default;
        [Category("ShorelineConstruction")]
        public Decimal? height {
            get {
                return _height;
            }

            set {
                SetValue(ref _height, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("ShorelineConstruction")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        public class ShorelineConstructionRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["ShorelineConstruction"];
        }

        public void Load(DomainModel.S501.FeatureTypes.ShorelineConstruction instance) {
            horizontalLength = instance.horizontalLength;
            gradientOfSlope = instance.gradientOfSlope;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            condition = instance.condition;
            visualProminence = instance.visualProminence;
            colour.Clear();
            if (instance.colour is not null)
                foreach (var e in instance.colour)
                    colour.Add(e);
            horizontalWidth = instance.horizontalWidth;
            radarConspicuous = instance.radarConspicuous;
            scaleMinimum = instance.scaleMinimum;
            horizontalClearanceFixed = new();
            if (instance.horizontalClearanceFixed != null) {
                horizontalClearanceFixed = new();
                horizontalClearanceFixed.Load(instance.horizontalClearanceFixed);
            }

            pictorialRepresentation = instance.pictorialRepresentation;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            verticalLength = instance.verticalLength;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            waterLevelEffect = instance.waterLevelEffect;
            natureOfConstruction.Clear();
            if (instance.natureOfConstruction is not null)
                foreach (var e in instance.natureOfConstruction)
                    natureOfConstruction.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            categoryOfShorelineConstruction = instance.categoryOfShorelineConstruction;
            colourPattern = instance.colourPattern;
            height = instance.height;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.ShorelineConstruction
            {
                horizontalLength = this.horizontalLength,
                gradientOfSlope = this.gradientOfSlope,
                featureName = this.featureName.ToList(),
                condition = this.condition,
                visualProminence = this.visualProminence,
                colour = this.colour.ToList(),
                horizontalWidth = this.horizontalWidth,
                radarConspicuous = this.radarConspicuous,
                scaleMinimum = this.scaleMinimum,
                horizontalClearanceFixed = this.horizontalClearanceFixed?.Model,
                pictorialRepresentation = this.pictorialRepresentation,
                status = this.status.ToList(),
                verticalLength = this.verticalLength,
                information = this.information.ToList(),
                waterLevelEffect = this.waterLevelEffect,
                natureOfConstruction = this.natureOfConstruction.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                categoryOfShorelineConstruction = this.categoryOfShorelineConstruction,
                colourPattern = this.colourPattern,
                height = this.height,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.ShorelineConstruction Model => new()
        {
            horizontalLength = this._horizontalLength,
            gradientOfSlope = this._gradientOfSlope,
            featureName = this.featureName.ToList(),
            condition = this._condition,
            visualProminence = this._visualProminence,
            colour = this.colour.ToList(),
            horizontalWidth = this._horizontalWidth,
            radarConspicuous = this._radarConspicuous,
            scaleMinimum = this._scaleMinimum,
            horizontalClearanceFixed = this._horizontalClearanceFixed?.Model,
            pictorialRepresentation = this._pictorialRepresentation,
            status = this.status.ToList(),
            verticalLength = this._verticalLength,
            information = this.information.ToList(),
            waterLevelEffect = this._waterLevelEffect,
            natureOfConstruction = this.natureOfConstruction.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            categoryOfShorelineConstruction = this._categoryOfShorelineConstruction,
            colourPattern = this._colourPattern,
            height = this._height,
            reportedDate = this._reportedDate,
        };

        public ShorelineConstructionViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(colour));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(natureOfConstruction));
            };
        }

        public override string? ToString() => $"Shoreline Construction";
    }

    [CategoryOrder("CautionArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class CautionAreaViewModel : ViewModelBase {
        private DateOnly? _reportedDate = default;
        [Category("CautionArea")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("CautionArea")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("CautionArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private status? _status = default;
        [Category("CautionArea")]
        public status? status {
            get {
                return _status;
            }

            set {
                SetValue(ref _status, value);
            }
        }

        private condition? _condition = default;
        [Category("CautionArea")]
        public condition? condition {
            get {
                return _condition;
            }

            set {
                SetValue(ref _condition, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("CautionArea")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private String _pictorialRepresentation = string.Empty;
        [Category("CautionArea")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        [Category("CautionArea")]
        public ObservableCollection<information> information { get; set; } = new();

        public class CautionAreaRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["CautionArea"];
        }

        public void Load(DomainModel.S501.FeatureTypes.CautionArea instance) {
            reportedDate = instance.reportedDate;
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            status = instance.status;
            condition = instance.condition;
            scaleMinimum = instance.scaleMinimum;
            pictorialRepresentation = instance.pictorialRepresentation;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.CautionArea
            {
                reportedDate = this.reportedDate,
                periodicDateRange = this.periodicDateRange.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                status = this.status,
                condition = this.condition,
                scaleMinimum = this.scaleMinimum,
                pictorialRepresentation = this.pictorialRepresentation,
                information = this.information.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.CautionArea Model => new()
        {
            reportedDate = this._reportedDate,
            periodicDateRange = this.periodicDateRange.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            status = this._status,
            condition = this._condition,
            scaleMinimum = this._scaleMinimum,
            pictorialRepresentation = this._pictorialRepresentation,
            information = this.information.ToList(),
        };

        public CautionAreaViewModel() : base() {
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Caution Area";
    }

    [CategoryOrder("DeepWaterRoutePart", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class DeepWaterRoutePartViewModel : ViewModelBase {
        private Boolean? _imoAdopted = default;
        [Category("DeepWaterRoutePart")]
        public Boolean? imoAdopted {
            get {
                return _imoAdopted;
            }

            set {
                SetValue(ref _imoAdopted, value);
            }
        }

        private verticalUncertaintyViewModel? _verticalUncertainty;
        [Category("DeepWaterRoutePart")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public verticalUncertaintyViewModel? verticalUncertainty {
            get {
                return _verticalUncertainty;
            }

            set {
                SetValue(ref _verticalUncertainty, value);
            }
        }

        [Category("DeepWaterRoutePart")]
        public ObservableCollection<information> information { get; set; } = new();

        private trafficFlow _trafficFlow;
        [Category("DeepWaterRoutePart")]
        public trafficFlow trafficFlow {
            get {
                return _trafficFlow;
            }

            set {
                SetValue(ref _trafficFlow, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("DeepWaterRoutePart")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("DeepWaterRoutePart")]
        public ObservableCollection<vesselSpeedLimit> vesselSpeedLimit { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("DeepWaterRoutePart")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("DeepWaterRoutePart")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private Decimal _depthRangeMinimumValue;
        [Category("DeepWaterRoutePart")]
        public Decimal depthRangeMinimumValue {
            get {
                return _depthRangeMinimumValue;
            }

            set {
                SetValue(ref _depthRangeMinimumValue, value);
            }
        }

        [Category("DeepWaterRoutePart")]
        public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = new();

        [Category("DeepWaterRoutePart")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        [Category("DeepWaterRoutePart")]
        public ObservableCollection<status> status { get; set; } = new();

        private Decimal _orientationValue;
        [Category("DeepWaterRoutePart")]
        public Decimal orientationValue {
            get {
                return _orientationValue;
            }

            set {
                SetValue(ref _orientationValue, value);
            }
        }

        [Category("DeepWaterRoutePart")]
        public ObservableCollection<restriction> restriction { get; set; } = new();

        [Category("DeepWaterRoutePart")]
        public ObservableCollection<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = new();

        public class DeepWaterRoutePartRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["DeepWaterRoutePart"];
        }

        public void Load(DomainModel.S501.FeatureTypes.DeepWaterRoutePart instance) {
            imoAdopted = instance.imoAdopted;
            verticalUncertainty = new();
            if (instance.verticalUncertainty != null) {
                verticalUncertainty = new();
                verticalUncertainty.Load(instance.verticalUncertainty);
            }

            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            trafficFlow = instance.trafficFlow;
            scaleMinimum = instance.scaleMinimum;
            vesselSpeedLimit.Clear();
            if (instance.vesselSpeedLimit is not null)
                foreach (var e in instance.vesselSpeedLimit)
                    vesselSpeedLimit.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            depthRangeMinimumValue = instance.depthRangeMinimumValue;
            techniqueOfVerticalMeasurement.Clear();
            if (instance.techniqueOfVerticalMeasurement is not null)
                foreach (var e in instance.techniqueOfVerticalMeasurement)
                    techniqueOfVerticalMeasurement.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            orientationValue = instance.orientationValue;
            restriction.Clear();
            if (instance.restriction is not null)
                foreach (var e in instance.restriction)
                    restriction.Add(e);
            qualityOfVerticalMeasurement.Clear();
            if (instance.qualityOfVerticalMeasurement is not null)
                foreach (var e in instance.qualityOfVerticalMeasurement)
                    qualityOfVerticalMeasurement.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.DeepWaterRoutePart
            {
                imoAdopted = this.imoAdopted,
                verticalUncertainty = this.verticalUncertainty?.Model,
                information = this.information.ToList(),
                trafficFlow = this.trafficFlow,
                scaleMinimum = this.scaleMinimum,
                vesselSpeedLimit = this.vesselSpeedLimit.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                depthRangeMinimumValue = this.depthRangeMinimumValue,
                techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
                featureName = this.featureName.ToList(),
                status = this.status.ToList(),
                orientationValue = this.orientationValue,
                restriction = this.restriction.ToList(),
                qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.DeepWaterRoutePart Model => new()
        {
            imoAdopted = this._imoAdopted,
            verticalUncertainty = this._verticalUncertainty?.Model,
            information = this.information.ToList(),
            trafficFlow = this._trafficFlow,
            scaleMinimum = this._scaleMinimum,
            vesselSpeedLimit = this.vesselSpeedLimit.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            depthRangeMinimumValue = this._depthRangeMinimumValue,
            techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
            featureName = this.featureName.ToList(),
            status = this.status.ToList(),
            orientationValue = this._orientationValue,
            restriction = this.restriction.ToList(),
            qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement.ToList(),
        };

        public DeepWaterRoutePartViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            vesselSpeedLimit.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(vesselSpeedLimit));
            };
            techniqueOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(techniqueOfVerticalMeasurement));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(restriction));
            };
            qualityOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(qualityOfVerticalMeasurement));
            };
        }

        public override string? ToString() => $"Deep Water Route Part";
    }

    [CategoryOrder("CurrentNonGravitational", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class CurrentNonGravitationalViewModel : ViewModelBase {
        [Category("CurrentNonGravitational")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        [Category("CurrentNonGravitational")]
        public ObservableCollection<information> information { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("CurrentNonGravitational")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private orientationViewModel _orientation;
        [Category("CurrentNonGravitational")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public orientationViewModel orientation {
            get {
                return _orientation;
            }

            set {
                SetValue(ref _orientation, value);
            }
        }

        [Category("CurrentNonGravitational")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("CurrentNonGravitational")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private speedViewModel _speed;
        [Category("CurrentNonGravitational")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public speedViewModel speed {
            get {
                return _speed;
            }

            set {
                SetValue(ref _speed, value);
            }
        }

        private status? _status = default;
        [Category("CurrentNonGravitational")]
        public status? status {
            get {
                return _status;
            }

            set {
                SetValue(ref _status, value);
            }
        }

        public class CurrentNonGravitationalRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["CurrentNonGravitational"];
        }

        public void Load(DomainModel.S501.FeatureTypes.CurrentNonGravitational instance) {
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            scaleMinimum = instance.scaleMinimum;
            orientation = new();
            if (instance.orientation != null) {
                orientation = new();
                orientation.Load(instance.orientation);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            speed = new();
            if (instance.speed != null) {
                speed = new();
                speed.Load(instance.speed);
            }

            status = instance.status;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.CurrentNonGravitational
            {
                featureName = this.featureName.ToList(),
                information = this.information.ToList(),
                scaleMinimum = this.scaleMinimum,
                orientation = this.orientation?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                speed = this.speed?.Model,
                status = this.status,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.CurrentNonGravitational Model => new()
        {
            featureName = this.featureName.ToList(),
            information = this.information.ToList(),
            scaleMinimum = this._scaleMinimum,
            orientation = this._orientation?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            speed = this._speed?.Model,
            status = this._status,
        };

        public CurrentNonGravitationalViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
        }

        public override string? ToString() => $"Current - Non-Gravitational";
    }

    [CategoryOrder("DataCoverage", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class DataCoverageViewModel : ViewModelBase {
        private Int32? _drawingIndex = default;
        [Category("DataCoverage")]
        public Int32? drawingIndex {
            get {
                return _drawingIndex;
            }

            set {
                SetValue(ref _drawingIndex, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("DataCoverage")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private categoryOfCoverage? _categoryOfCoverage = default;
        [Category("DataCoverage")]
        public categoryOfCoverage? categoryOfCoverage {
            get {
                return _categoryOfCoverage;
            }

            set {
                SetValue(ref _categoryOfCoverage, value);
            }
        }

        private Int32 _optimumDisplayScale;
        [Category("DataCoverage")]
        public Int32 optimumDisplayScale {
            get {
                return _optimumDisplayScale;
            }

            set {
                SetValue(ref _optimumDisplayScale, value);
            }
        }

        private Int32 _minimumDisplayScale;
        [Category("DataCoverage")]
        public Int32 minimumDisplayScale {
            get {
                return _minimumDisplayScale;
            }

            set {
                SetValue(ref _minimumDisplayScale, value);
            }
        }

        [Category("DataCoverage")]
        public ObservableCollection<information> information { get; set; } = new();

        private Int32 _maximumDisplayScale;
        [Category("DataCoverage")]
        public Int32 maximumDisplayScale {
            get {
                return _maximumDisplayScale;
            }

            set {
                SetValue(ref _maximumDisplayScale, value);
            }
        }

        public class DataCoverageRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["DataCoverage"];
        }

        public void Load(DomainModel.S501.FeatureTypes.DataCoverage instance) {
            drawingIndex = instance.drawingIndex;
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            categoryOfCoverage = instance.categoryOfCoverage;
            optimumDisplayScale = instance.optimumDisplayScale;
            minimumDisplayScale = instance.minimumDisplayScale;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            maximumDisplayScale = instance.maximumDisplayScale;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.DataCoverage
            {
                drawingIndex = this.drawingIndex,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                categoryOfCoverage = this.categoryOfCoverage,
                optimumDisplayScale = this.optimumDisplayScale,
                minimumDisplayScale = this.minimumDisplayScale,
                information = this.information.ToList(),
                maximumDisplayScale = this.maximumDisplayScale,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.DataCoverage Model => new()
        {
            drawingIndex = this._drawingIndex,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            categoryOfCoverage = this._categoryOfCoverage,
            optimumDisplayScale = this._optimumDisplayScale,
            minimumDisplayScale = this._minimumDisplayScale,
            information = this.information.ToList(),
            maximumDisplayScale = this._maximumDisplayScale,
        };

        public DataCoverageViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Data Coverage";
    }

    [CategoryOrder("SeabedArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class SeabedAreaViewModel : ViewModelBase {
        [Category("SeabedArea")]
        public ObservableCollection<information> information { get; set; } = new();

        private String _agencyResponsibleForProduction = string.Empty;
        [Category("SeabedArea")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("SeabedArea")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private waterLevelEffect _waterLevelEffect;
        [Category("SeabedArea")]
        public waterLevelEffect waterLevelEffect {
            get {
                return _waterLevelEffect;
            }

            set {
                SetValue(ref _waterLevelEffect, value);
            }
        }

        [Category("SeabedArea")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        [Category("SeabedArea")]
        public ObservableCollection<surfaceCharacteristics> surfaceCharacteristics { get; set; } = new();

        private Decimal? _attenuation = default;
        [Category("SeabedArea")]
        public Decimal? attenuation {
            get {
                return _attenuation;
            }

            set {
                SetValue(ref _attenuation, value);
            }
        }

        public class SeabedAreaRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["SeabedArea"];
        }

        public void Load(DomainModel.S501.FeatureTypes.SeabedArea instance) {
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            scaleMinimum = instance.scaleMinimum;
            waterLevelEffect = instance.waterLevelEffect;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            surfaceCharacteristics.Clear();
            if (instance.surfaceCharacteristics is not null)
                foreach (var e in instance.surfaceCharacteristics)
                    surfaceCharacteristics.Add(e);
            attenuation = instance.attenuation;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.SeabedArea
            {
                information = this.information.ToList(),
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                scaleMinimum = this.scaleMinimum,
                waterLevelEffect = this.waterLevelEffect,
                featureName = this.featureName.ToList(),
                surfaceCharacteristics = this.surfaceCharacteristics.ToList(),
                attenuation = this.attenuation,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.SeabedArea Model => new()
        {
            information = this.information.ToList(),
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            scaleMinimum = this._scaleMinimum,
            waterLevelEffect = this._waterLevelEffect,
            featureName = this.featureName.ToList(),
            surfaceCharacteristics = this.surfaceCharacteristics.ToList(),
            attenuation = this._attenuation,
        };

        public SeabedAreaViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            surfaceCharacteristics.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(surfaceCharacteristics));
            };
        }

        public override string? ToString() => $"Seabed Area";
    }

    [CategoryOrder("SpecialPurposeGeneralBuoy", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class SpecialPurposeGeneralBuoyViewModel : ViewModelBase {
        [Category("SpecialPurposeGeneralBuoy")]
        public ObservableCollection<information> information { get; set; } = new();

        private buoyShape _buoyShape;
        [Category("SpecialPurposeGeneralBuoy")]
        public buoyShape buoyShape {
            get {
                return _buoyShape;
            }

            set {
                SetValue(ref _buoyShape, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("SpecialPurposeGeneralBuoy")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("SpecialPurposeGeneralBuoy")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("SpecialPurposeGeneralBuoy")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private colourPattern? _colourPattern = default;
        [Category("SpecialPurposeGeneralBuoy")]
        public colourPattern? colourPattern {
            get {
                return _colourPattern;
            }

            set {
                SetValue(ref _colourPattern, value);
            }
        }

        [Category("SpecialPurposeGeneralBuoy")]
        public ObservableCollection<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark { get; set; } = new();

        private String _pictorialRepresentation = string.Empty;
        [Category("SpecialPurposeGeneralBuoy")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        [Category("SpecialPurposeGeneralBuoy")]
        public ObservableCollection<status> status { get; set; } = new();

        private Decimal? _verticalLength = default;
        [Category("SpecialPurposeGeneralBuoy")]
        public Decimal? verticalLength {
            get {
                return _verticalLength;
            }

            set {
                SetValue(ref _verticalLength, value);
            }
        }

        private Boolean? _radarConspicuous = default;
        [Category("SpecialPurposeGeneralBuoy")]
        public Boolean? radarConspicuous {
            get {
                return _radarConspicuous;
            }

            set {
                SetValue(ref _radarConspicuous, value);
            }
        }

        private topmarkViewModel? _topmark;
        [Category("SpecialPurposeGeneralBuoy")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public topmarkViewModel? topmark {
            get {
                return _topmark;
            }

            set {
                SetValue(ref _topmark, value);
            }
        }

        [Category("SpecialPurposeGeneralBuoy")]
        public ObservableCollection<colour> colour { get; set; } = new();

        private marksNavigationalSystemOf? _marksNavigationalSystemOf = default;
        [Category("SpecialPurposeGeneralBuoy")]
        public marksNavigationalSystemOf? marksNavigationalSystemOf {
            get {
                return _marksNavigationalSystemOf;
            }

            set {
                SetValue(ref _marksNavigationalSystemOf, value);
            }
        }

        [Category("SpecialPurposeGeneralBuoy")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        [Category("SpecialPurposeGeneralBuoy")]
        public ObservableCollection<fixedDateRange> fixedDateRange { get; set; } = new();

        private String _interoperabilityIdentifier = string.Empty;
        [Category("SpecialPurposeGeneralBuoy")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        [Category("SpecialPurposeGeneralBuoy")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        public class SpecialPurposeGeneralBuoyRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["SpecialPurposeGeneralBuoy"];
        }

        public void Load(DomainModel.S501.FeatureTypes.SpecialPurposeGeneralBuoy instance) {
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            buoyShape = instance.buoyShape;
            scaleMinimum = instance.scaleMinimum;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            colourPattern = instance.colourPattern;
            categoryOfSpecialPurposeMark.Clear();
            if (instance.categoryOfSpecialPurposeMark is not null)
                foreach (var e in instance.categoryOfSpecialPurposeMark)
                    categoryOfSpecialPurposeMark.Add(e);
            pictorialRepresentation = instance.pictorialRepresentation;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            verticalLength = instance.verticalLength;
            radarConspicuous = instance.radarConspicuous;
            topmark = new();
            if (instance.topmark != null) {
                topmark = new();
                topmark.Load(instance.topmark);
            }

            colour.Clear();
            if (instance.colour is not null)
                foreach (var e in instance.colour)
                    colour.Add(e);
            marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
            natureOfConstruction.Clear();
            if (instance.natureOfConstruction is not null)
                foreach (var e in instance.natureOfConstruction)
                    natureOfConstruction.Add(e);
            fixedDateRange.Clear();
            if (instance.fixedDateRange is not null)
                foreach (var e in instance.fixedDateRange)
                    fixedDateRange.Add(e);
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.SpecialPurposeGeneralBuoy
            {
                information = this.information.ToList(),
                buoyShape = this.buoyShape,
                scaleMinimum = this.scaleMinimum,
                featureName = this.featureName.ToList(),
                sourceIdentification = this.sourceIdentification?.Model,
                colourPattern = this.colourPattern,
                categoryOfSpecialPurposeMark = this.categoryOfSpecialPurposeMark.ToList(),
                pictorialRepresentation = this.pictorialRepresentation,
                status = this.status.ToList(),
                verticalLength = this.verticalLength,
                radarConspicuous = this.radarConspicuous,
                topmark = this.topmark?.Model,
                colour = this.colour.ToList(),
                marksNavigationalSystemOf = this.marksNavigationalSystemOf,
                natureOfConstruction = this.natureOfConstruction.ToList(),
                fixedDateRange = this.fixedDateRange.ToList(),
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                periodicDateRange = this.periodicDateRange.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.SpecialPurposeGeneralBuoy Model => new()
        {
            information = this.information.ToList(),
            buoyShape = this._buoyShape,
            scaleMinimum = this._scaleMinimum,
            featureName = this.featureName.ToList(),
            sourceIdentification = this._sourceIdentification?.Model,
            colourPattern = this._colourPattern,
            categoryOfSpecialPurposeMark = this.categoryOfSpecialPurposeMark.ToList(),
            pictorialRepresentation = this._pictorialRepresentation,
            status = this.status.ToList(),
            verticalLength = this._verticalLength,
            radarConspicuous = this._radarConspicuous,
            topmark = this._topmark?.Model,
            colour = this.colour.ToList(),
            marksNavigationalSystemOf = this._marksNavigationalSystemOf,
            natureOfConstruction = this.natureOfConstruction.ToList(),
            fixedDateRange = this.fixedDateRange.ToList(),
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            periodicDateRange = this.periodicDateRange.ToList(),
        };

        public SpecialPurposeGeneralBuoyViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            categoryOfSpecialPurposeMark.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(categoryOfSpecialPurposeMark));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(colour));
            };
            natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(natureOfConstruction));
            };
            fixedDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(fixedDateRange));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
        }

        public override string? ToString() => $"Special Purpose/General Buoy";
    }

    [CategoryOrder("LightSectored", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class LightSectoredViewModel : ViewModelBase {
        [Category("LightSectored")]
        public ObservableCollection<status> status { get; set; } = new();

        private Decimal? _relativeHorizontalAccuracy = default;
        [Category("LightSectored")]
        public Decimal? relativeHorizontalAccuracy {
            get {
                return _relativeHorizontalAccuracy;
            }

            set {
                SetValue(ref _relativeHorizontalAccuracy, value);
            }
        }

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("LightSectored")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("LightSectored")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        private Decimal? _relativeVerticalAccuracy = default;
        [Category("LightSectored")]
        public Decimal? relativeVerticalAccuracy {
            get {
                return _relativeVerticalAccuracy;
            }

            set {
                SetValue(ref _relativeVerticalAccuracy, value);
            }
        }

        [Category("LightSectored")]
        public ObservableCollection<categoryOfLight> categoryOfLight { get; set; } = new();

        private exhibitionConditionOfLight? _exhibitionConditionOfLight = default;
        [Category("LightSectored")]
        public exhibitionConditionOfLight? exhibitionConditionOfLight {
            get {
                return _exhibitionConditionOfLight;
            }

            set {
                SetValue(ref _exhibitionConditionOfLight, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("LightSectored")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("LightSectored")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("LightSectored")]
        public ObservableCollection<information> information { get; set; } = new();

        private String _pictorialRepresentation = string.Empty;
        [Category("LightSectored")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        private Decimal? _height = default;
        [Category("LightSectored")]
        public Decimal? height {
            get {
                return _height;
            }

            set {
                SetValue(ref _height, value);
            }
        }

        private heightLengthUnits? _heightLengthUnits = default;
        [Category("LightSectored")]
        public heightLengthUnits? heightLengthUnits {
            get {
                return _heightLengthUnits;
            }

            set {
                SetValue(ref _heightLengthUnits, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("LightSectored")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        [Category("LightSectored")]
        public ObservableCollection<sectorCharacteristics> sectorCharacteristics { get; set; } = new();

        private verticalDatum? _verticalDatum = default;
        [Category("LightSectored")]
        public verticalDatum? verticalDatum {
            get {
                return _verticalDatum;
            }

            set {
                SetValue(ref _verticalDatum, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("LightSectored")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private signalGeneration? _signalGeneration = default;
        [Category("LightSectored")]
        public signalGeneration? signalGeneration {
            get {
                return _signalGeneration;
            }

            set {
                SetValue(ref _signalGeneration, value);
            }
        }

        private marksNavigationalSystemOf? _marksNavigationalSystemOf = default;
        [Category("LightSectored")]
        public marksNavigationalSystemOf? marksNavigationalSystemOf {
            get {
                return _marksNavigationalSystemOf;
            }

            set {
                SetValue(ref _marksNavigationalSystemOf, value);
            }
        }

        [Category("LightSectored")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        public class LightSectoredRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["LightSectored"];
        }

        public void Load(DomainModel.S501.FeatureTypes.LightSectored instance) {
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            relativeHorizontalAccuracy = instance.relativeHorizontalAccuracy;
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            relativeVerticalAccuracy = instance.relativeVerticalAccuracy;
            categoryOfLight.Clear();
            if (instance.categoryOfLight is not null)
                foreach (var e in instance.categoryOfLight)
                    categoryOfLight.Add(e);
            exhibitionConditionOfLight = instance.exhibitionConditionOfLight;
            reportedDate = instance.reportedDate;
            scaleMinimum = instance.scaleMinimum;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            pictorialRepresentation = instance.pictorialRepresentation;
            height = instance.height;
            heightLengthUnits = instance.heightLengthUnits;
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            sectorCharacteristics.Clear();
            if (instance.sectorCharacteristics is not null)
                foreach (var e in instance.sectorCharacteristics)
                    sectorCharacteristics.Add(e);
            verticalDatum = instance.verticalDatum;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            signalGeneration = instance.signalGeneration;
            marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.LightSectored
            {
                status = this.status.ToList(),
                relativeHorizontalAccuracy = this.relativeHorizontalAccuracy,
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                relativeVerticalAccuracy = this.relativeVerticalAccuracy,
                categoryOfLight = this.categoryOfLight.ToList(),
                exhibitionConditionOfLight = this.exhibitionConditionOfLight,
                reportedDate = this.reportedDate,
                scaleMinimum = this.scaleMinimum,
                information = this.information.ToList(),
                pictorialRepresentation = this.pictorialRepresentation,
                height = this.height,
                heightLengthUnits = this.heightLengthUnits,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                sectorCharacteristics = this.sectorCharacteristics.ToList(),
                verticalDatum = this.verticalDatum,
                sourceIdentification = this.sourceIdentification?.Model,
                signalGeneration = this.signalGeneration,
                marksNavigationalSystemOf = this.marksNavigationalSystemOf,
                featureName = this.featureName.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.LightSectored Model => new()
        {
            status = this.status.ToList(),
            relativeHorizontalAccuracy = this._relativeHorizontalAccuracy,
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            relativeVerticalAccuracy = this._relativeVerticalAccuracy,
            categoryOfLight = this.categoryOfLight.ToList(),
            exhibitionConditionOfLight = this._exhibitionConditionOfLight,
            reportedDate = this._reportedDate,
            scaleMinimum = this._scaleMinimum,
            information = this.information.ToList(),
            pictorialRepresentation = this._pictorialRepresentation,
            height = this._height,
            heightLengthUnits = this._heightLengthUnits,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            sectorCharacteristics = this.sectorCharacteristics.ToList(),
            verticalDatum = this._verticalDatum,
            sourceIdentification = this._sourceIdentification?.Model,
            signalGeneration = this._signalGeneration,
            marksNavigationalSystemOf = this._marksNavigationalSystemOf,
            featureName = this.featureName.ToList(),
        };

        public LightSectoredViewModel() : base() {
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            categoryOfLight.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(categoryOfLight));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            sectorCharacteristics.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(sectorCharacteristics));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
        }

        public override string? ToString() => $"Light Sectored";
    }

    [CategoryOrder("IceLine", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class IceLineViewModel : ViewModelBase {
        [Category("IceLine")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("IceLine")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        public class IceLineRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["IceLine"];
        }

        public void Load(DomainModel.S501.FeatureTypes.IceLine instance) {
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.IceLine
            {
                information = this.information.ToList(),
                featureName = this.featureName.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.IceLine Model => new()
        {
            information = this.information.ToList(),
            featureName = this.featureName.ToList(),
        };

        public IceLineViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
        }

        public override string? ToString() => $"Ice Line";
    }

    [CategoryOrder("AnchorageArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class AnchorageAreaViewModel : ViewModelBase {
        [Category("AnchorageArea")]
        public ObservableCollection<restriction> restriction { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("AnchorageArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private periodicDateRangeViewModel? _periodicDateRange;
        [Category("AnchorageArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public periodicDateRangeViewModel? periodicDateRange {
            get {
                return _periodicDateRange;
            }

            set {
                SetValue(ref _periodicDateRange, value);
            }
        }

        [Category("AnchorageArea")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        [Category("AnchorageArea")]
        public ObservableCollection<categoryOfAnchorage> categoryOfAnchorage { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("AnchorageArea")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("AnchorageArea")]
        public ObservableCollection<status> status { get; set; } = new();

        [Category("AnchorageArea")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("AnchorageArea")]
        public ObservableCollection<categoryOfCargo> categoryOfCargo { get; set; } = new();

        public class AnchorageAreaRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["AnchorageArea"];
        }

        public void Load(DomainModel.S501.FeatureTypes.AnchorageArea instance) {
            restriction.Clear();
            if (instance.restriction is not null)
                foreach (var e in instance.restriction)
                    restriction.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange = new();
            if (instance.periodicDateRange != null) {
                periodicDateRange = new();
                periodicDateRange.Load(instance.periodicDateRange);
            }

            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            categoryOfAnchorage.Clear();
            if (instance.categoryOfAnchorage is not null)
                foreach (var e in instance.categoryOfAnchorage)
                    categoryOfAnchorage.Add(e);
            scaleMinimum = instance.scaleMinimum;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            categoryOfCargo.Clear();
            if (instance.categoryOfCargo is not null)
                foreach (var e in instance.categoryOfCargo)
                    categoryOfCargo.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.AnchorageArea
            {
                restriction = this.restriction.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange?.Model,
                featureName = this.featureName.ToList(),
                categoryOfAnchorage = this.categoryOfAnchorage.ToList(),
                scaleMinimum = this.scaleMinimum,
                status = this.status.ToList(),
                information = this.information.ToList(),
                categoryOfCargo = this.categoryOfCargo.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.AnchorageArea Model => new()
        {
            restriction = this.restriction.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this._periodicDateRange?.Model,
            featureName = this.featureName.ToList(),
            categoryOfAnchorage = this.categoryOfAnchorage.ToList(),
            scaleMinimum = this._scaleMinimum,
            status = this.status.ToList(),
            information = this.information.ToList(),
            categoryOfCargo = this.categoryOfCargo.ToList(),
        };

        public AnchorageAreaViewModel() : base() {
            restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(restriction));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            categoryOfAnchorage.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(categoryOfAnchorage));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            categoryOfCargo.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(categoryOfCargo));
            };
        }

        public override string? ToString() => $"Anchorage Area";
    }

    [CategoryOrder("LateralBuoy", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class LateralBuoyViewModel : ViewModelBase {
        private Boolean? _radarConspicuous = default;
        [Category("LateralBuoy")]
        public Boolean? radarConspicuous {
            get {
                return _radarConspicuous;
            }

            set {
                SetValue(ref _radarConspicuous, value);
            }
        }

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("LateralBuoy")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("LateralBuoy")]
        public ObservableCollection<colour> colour { get; set; } = new();

        private String _interoperabilityIdentifier = string.Empty;
        [Category("LateralBuoy")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private String _pictorialRepresentation = string.Empty;
        [Category("LateralBuoy")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        [Category("LateralBuoy")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("LateralBuoy")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        [Category("LateralBuoy")]
        public ObservableCollection<status> status { get; set; } = new();

        private categoryOfLateralMark _categoryOfLateralMark;
        [Category("LateralBuoy")]
        public categoryOfLateralMark categoryOfLateralMark {
            get {
                return _categoryOfLateralMark;
            }

            set {
                SetValue(ref _categoryOfLateralMark, value);
            }
        }

        [Category("LateralBuoy")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        private colourPattern? _colourPattern = default;
        [Category("LateralBuoy")]
        public colourPattern? colourPattern {
            get {
                return _colourPattern;
            }

            set {
                SetValue(ref _colourPattern, value);
            }
        }

        private buoyShape _buoyShape;
        [Category("LateralBuoy")]
        public buoyShape buoyShape {
            get {
                return _buoyShape;
            }

            set {
                SetValue(ref _buoyShape, value);
            }
        }

        private topmarkViewModel? _topmark;
        [Category("LateralBuoy")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public topmarkViewModel? topmark {
            get {
                return _topmark;
            }

            set {
                SetValue(ref _topmark, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("LateralBuoy")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("LateralBuoy")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        private marksNavigationalSystemOf? _marksNavigationalSystemOf = default;
        [Category("LateralBuoy")]
        public marksNavigationalSystemOf? marksNavigationalSystemOf {
            get {
                return _marksNavigationalSystemOf;
            }

            set {
                SetValue(ref _marksNavigationalSystemOf, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("LateralBuoy")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private Decimal? _verticalLength = default;
        [Category("LateralBuoy")]
        public Decimal? verticalLength {
            get {
                return _verticalLength;
            }

            set {
                SetValue(ref _verticalLength, value);
            }
        }

        public class LateralBuoyRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["LateralBuoy"];
        }

        public void Load(DomainModel.S501.FeatureTypes.LateralBuoy instance) {
            radarConspicuous = instance.radarConspicuous;
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            colour.Clear();
            if (instance.colour is not null)
                foreach (var e in instance.colour)
                    colour.Add(e);
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            pictorialRepresentation = instance.pictorialRepresentation;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            categoryOfLateralMark = instance.categoryOfLateralMark;
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            colourPattern = instance.colourPattern;
            buoyShape = instance.buoyShape;
            topmark = new();
            if (instance.topmark != null) {
                topmark = new();
                topmark.Load(instance.topmark);
            }

            scaleMinimum = instance.scaleMinimum;
            natureOfConstruction.Clear();
            if (instance.natureOfConstruction is not null)
                foreach (var e in instance.natureOfConstruction)
                    natureOfConstruction.Add(e);
            marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            verticalLength = instance.verticalLength;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.LateralBuoy
            {
                radarConspicuous = this.radarConspicuous,
                fixedDateRange = this.fixedDateRange?.Model,
                colour = this.colour.ToList(),
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                pictorialRepresentation = this.pictorialRepresentation,
                information = this.information.ToList(),
                featureName = this.featureName.ToList(),
                status = this.status.ToList(),
                categoryOfLateralMark = this.categoryOfLateralMark,
                periodicDateRange = this.periodicDateRange.ToList(),
                colourPattern = this.colourPattern,
                buoyShape = this.buoyShape,
                topmark = this.topmark?.Model,
                scaleMinimum = this.scaleMinimum,
                natureOfConstruction = this.natureOfConstruction.ToList(),
                marksNavigationalSystemOf = this.marksNavigationalSystemOf,
                sourceIdentification = this.sourceIdentification?.Model,
                verticalLength = this.verticalLength,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.LateralBuoy Model => new()
        {
            radarConspicuous = this._radarConspicuous,
            fixedDateRange = this._fixedDateRange?.Model,
            colour = this.colour.ToList(),
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            pictorialRepresentation = this._pictorialRepresentation,
            information = this.information.ToList(),
            featureName = this.featureName.ToList(),
            status = this.status.ToList(),
            categoryOfLateralMark = this._categoryOfLateralMark,
            periodicDateRange = this.periodicDateRange.ToList(),
            colourPattern = this._colourPattern,
            buoyShape = this._buoyShape,
            topmark = this._topmark?.Model,
            scaleMinimum = this._scaleMinimum,
            natureOfConstruction = this.natureOfConstruction.ToList(),
            marksNavigationalSystemOf = this._marksNavigationalSystemOf,
            sourceIdentification = this._sourceIdentification?.Model,
            verticalLength = this._verticalLength,
        };

        public LateralBuoyViewModel() : base() {
            colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(colour));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(natureOfConstruction));
            };
        }

        public override string? ToString() => $"Lateral Buoy";
    }

    [CategoryOrder("TrafficSeparationSchemeRoundabout", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class TrafficSeparationSchemeRoundaboutViewModel : ViewModelBase {
        [Category("TrafficSeparationSchemeRoundabout")]
        public ObservableCollection<vesselSpeedLimit> vesselSpeedLimit { get; set; } = new();

        private String _interoperabilityIdentifier = string.Empty;
        [Category("TrafficSeparationSchemeRoundabout")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("TrafficSeparationSchemeRoundabout")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("TrafficSeparationSchemeRoundabout")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("TrafficSeparationSchemeRoundabout")]
        public ObservableCollection<information> information { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("TrafficSeparationSchemeRoundabout")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("TrafficSeparationSchemeRoundabout")]
        public ObservableCollection<status> status { get; set; } = new();

        private DateOnly? _reportedDate = default;
        [Category("TrafficSeparationSchemeRoundabout")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("TrafficSeparationSchemeRoundabout")]
        public ObservableCollection<restriction> restriction { get; set; } = new();

        public class TrafficSeparationSchemeRoundaboutRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["TrafficSeparationSchemeRoundabout"];
        }

        public void Load(DomainModel.S501.FeatureTypes.TrafficSeparationSchemeRoundabout instance) {
            vesselSpeedLimit.Clear();
            if (instance.vesselSpeedLimit is not null)
                foreach (var e in instance.vesselSpeedLimit)
                    vesselSpeedLimit.Add(e);
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            scaleMinimum = instance.scaleMinimum;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            reportedDate = instance.reportedDate;
            restriction.Clear();
            if (instance.restriction is not null)
                foreach (var e in instance.restriction)
                    restriction.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.TrafficSeparationSchemeRoundabout
            {
                vesselSpeedLimit = this.vesselSpeedLimit.ToList(),
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                sourceIdentification = this.sourceIdentification?.Model,
                scaleMinimum = this.scaleMinimum,
                information = this.information.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                status = this.status.ToList(),
                reportedDate = this.reportedDate,
                restriction = this.restriction.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.TrafficSeparationSchemeRoundabout Model => new()
        {
            vesselSpeedLimit = this.vesselSpeedLimit.ToList(),
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            sourceIdentification = this._sourceIdentification?.Model,
            scaleMinimum = this._scaleMinimum,
            information = this.information.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            status = this.status.ToList(),
            reportedDate = this._reportedDate,
            restriction = this.restriction.ToList(),
        };

        public TrafficSeparationSchemeRoundaboutViewModel() : base() {
            vesselSpeedLimit.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(vesselSpeedLimit));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(restriction));
            };
        }

        public override string? ToString() => $"Traffic Separation Scheme Roundabout";
    }

    [CategoryOrder("DeepWaterRouteCentreline", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class DeepWaterRouteCentrelineViewModel : ViewModelBase {
        [Category("DeepWaterRouteCentreline")]
        public ObservableCollection<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = new();

        private Decimal _orientationValue;
        [Category("DeepWaterRouteCentreline")]
        public Decimal orientationValue {
            get {
                return _orientationValue;
            }

            set {
                SetValue(ref _orientationValue, value);
            }
        }

        [Category("DeepWaterRouteCentreline")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private trafficFlow _trafficFlow;
        [Category("DeepWaterRouteCentreline")]
        public trafficFlow trafficFlow {
            get {
                return _trafficFlow;
            }

            set {
                SetValue(ref _trafficFlow, value);
            }
        }

        private verticalUncertaintyViewModel? _verticalUncertainty;
        [Category("DeepWaterRouteCentreline")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public verticalUncertaintyViewModel? verticalUncertainty {
            get {
                return _verticalUncertainty;
            }

            set {
                SetValue(ref _verticalUncertainty, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("DeepWaterRouteCentreline")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("DeepWaterRouteCentreline")]
        public ObservableCollection<status> status { get; set; } = new();

        private Boolean? _imoAdopted = default;
        [Category("DeepWaterRouteCentreline")]
        public Boolean? imoAdopted {
            get {
                return _imoAdopted;
            }

            set {
                SetValue(ref _imoAdopted, value);
            }
        }

        [Category("DeepWaterRouteCentreline")]
        public ObservableCollection<information> information { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("DeepWaterRouteCentreline")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("DeepWaterRouteCentreline")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private Decimal? _depthRangeMinimumValue = default;
        [Category("DeepWaterRouteCentreline")]
        public Decimal? depthRangeMinimumValue {
            get {
                return _depthRangeMinimumValue;
            }

            set {
                SetValue(ref _depthRangeMinimumValue, value);
            }
        }

        private Boolean _basedOnFixedMarks;
        [Category("DeepWaterRouteCentreline")]
        public Boolean basedOnFixedMarks {
            get {
                return _basedOnFixedMarks;
            }

            set {
                SetValue(ref _basedOnFixedMarks, value);
            }
        }

        [Category("DeepWaterRouteCentreline")]
        public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = new();

        public class DeepWaterRouteCentrelineRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["DeepWaterRouteCentreline"];
        }

        public void Load(DomainModel.S501.FeatureTypes.DeepWaterRouteCentreline instance) {
            qualityOfVerticalMeasurement.Clear();
            if (instance.qualityOfVerticalMeasurement is not null)
                foreach (var e in instance.qualityOfVerticalMeasurement)
                    qualityOfVerticalMeasurement.Add(e);
            orientationValue = instance.orientationValue;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            trafficFlow = instance.trafficFlow;
            verticalUncertainty = new();
            if (instance.verticalUncertainty != null) {
                verticalUncertainty = new();
                verticalUncertainty.Load(instance.verticalUncertainty);
            }

            scaleMinimum = instance.scaleMinimum;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            imoAdopted = instance.imoAdopted;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            depthRangeMinimumValue = instance.depthRangeMinimumValue;
            basedOnFixedMarks = instance.basedOnFixedMarks;
            techniqueOfVerticalMeasurement.Clear();
            if (instance.techniqueOfVerticalMeasurement is not null)
                foreach (var e in instance.techniqueOfVerticalMeasurement)
                    techniqueOfVerticalMeasurement.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.DeepWaterRouteCentreline
            {
                qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement.ToList(),
                orientationValue = this.orientationValue,
                featureName = this.featureName.ToList(),
                trafficFlow = this.trafficFlow,
                verticalUncertainty = this.verticalUncertainty?.Model,
                scaleMinimum = this.scaleMinimum,
                status = this.status.ToList(),
                imoAdopted = this.imoAdopted,
                information = this.information.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                depthRangeMinimumValue = this.depthRangeMinimumValue,
                basedOnFixedMarks = this.basedOnFixedMarks,
                techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.DeepWaterRouteCentreline Model => new()
        {
            qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement.ToList(),
            orientationValue = this._orientationValue,
            featureName = this.featureName.ToList(),
            trafficFlow = this._trafficFlow,
            verticalUncertainty = this._verticalUncertainty?.Model,
            scaleMinimum = this._scaleMinimum,
            status = this.status.ToList(),
            imoAdopted = this._imoAdopted,
            information = this.information.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            depthRangeMinimumValue = this._depthRangeMinimumValue,
            basedOnFixedMarks = this._basedOnFixedMarks,
            techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
        };

        public DeepWaterRouteCentrelineViewModel() : base() {
            qualityOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(qualityOfVerticalMeasurement));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            techniqueOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(techniqueOfVerticalMeasurement));
            };
        }

        public override string? ToString() => $"Deep Water Route Centreline";
    }

    [CategoryOrder("LightFloat", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class LightFloatViewModel : ViewModelBase {
        private Decimal? _verticalLength = default;
        [Category("LightFloat")]
        public Decimal? verticalLength {
            get {
                return _verticalLength;
            }

            set {
                SetValue(ref _verticalLength, value);
            }
        }

        [Category("LightFloat")]
        public ObservableCollection<status> status { get; set; } = new();

        private colourPattern? _colourPattern = default;
        [Category("LightFloat")]
        public colourPattern? colourPattern {
            get {
                return _colourPattern;
            }

            set {
                SetValue(ref _colourPattern, value);
            }
        }

        [Category("LightFloat")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("LightFloat")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        [Category("LightFloat")]
        public ObservableCollection<colour> colour { get; set; } = new();

        private Decimal? _horizontalWidth = default;
        [Category("LightFloat")]
        public Decimal? horizontalWidth {
            get {
                return _horizontalWidth;
            }

            set {
                SetValue(ref _horizontalWidth, value);
            }
        }

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("LightFloat")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private Decimal? _horizontalLength = default;
        [Category("LightFloat")]
        public Decimal? horizontalLength {
            get {
                return _horizontalLength;
            }

            set {
                SetValue(ref _horizontalLength, value);
            }
        }

        private visualProminence? _visualProminence = default;
        [Category("LightFloat")]
        public visualProminence? visualProminence {
            get {
                return _visualProminence;
            }

            set {
                SetValue(ref _visualProminence, value);
            }
        }

        private Boolean? _radarConspicuous = default;
        [Category("LightFloat")]
        public Boolean? radarConspicuous {
            get {
                return _radarConspicuous;
            }

            set {
                SetValue(ref _radarConspicuous, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("LightFloat")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private String _pictorialRepresentation = string.Empty;
        [Category("LightFloat")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        private topmarkViewModel? _topmark;
        [Category("LightFloat")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public topmarkViewModel? topmark {
            get {
                return _topmark;
            }

            set {
                SetValue(ref _topmark, value);
            }
        }

        [Category("LightFloat")]
        public ObservableCollection<information> information { get; set; } = new();

        private Int32? _scaleMinimum = default;
        [Category("LightFloat")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("LightFloat")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        public class LightFloatRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["LightFloat"];
        }

        public void Load(DomainModel.S501.FeatureTypes.LightFloat instance) {
            verticalLength = instance.verticalLength;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            colourPattern = instance.colourPattern;
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            natureOfConstruction.Clear();
            if (instance.natureOfConstruction is not null)
                foreach (var e in instance.natureOfConstruction)
                    natureOfConstruction.Add(e);
            colour.Clear();
            if (instance.colour is not null)
                foreach (var e in instance.colour)
                    colour.Add(e);
            horizontalWidth = instance.horizontalWidth;
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            horizontalLength = instance.horizontalLength;
            visualProminence = instance.visualProminence;
            radarConspicuous = instance.radarConspicuous;
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            pictorialRepresentation = instance.pictorialRepresentation;
            topmark = new();
            if (instance.topmark != null) {
                topmark = new();
                topmark.Load(instance.topmark);
            }

            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            scaleMinimum = instance.scaleMinimum;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.LightFloat
            {
                verticalLength = this.verticalLength,
                status = this.status.ToList(),
                colourPattern = this.colourPattern,
                periodicDateRange = this.periodicDateRange.ToList(),
                natureOfConstruction = this.natureOfConstruction.ToList(),
                colour = this.colour.ToList(),
                horizontalWidth = this.horizontalWidth,
                fixedDateRange = this.fixedDateRange?.Model,
                horizontalLength = this.horizontalLength,
                visualProminence = this.visualProminence,
                radarConspicuous = this.radarConspicuous,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                pictorialRepresentation = this.pictorialRepresentation,
                topmark = this.topmark?.Model,
                information = this.information.ToList(),
                scaleMinimum = this.scaleMinimum,
                featureName = this.featureName.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.LightFloat Model => new()
        {
            verticalLength = this._verticalLength,
            status = this.status.ToList(),
            colourPattern = this._colourPattern,
            periodicDateRange = this.periodicDateRange.ToList(),
            natureOfConstruction = this.natureOfConstruction.ToList(),
            colour = this.colour.ToList(),
            horizontalWidth = this._horizontalWidth,
            fixedDateRange = this._fixedDateRange?.Model,
            horizontalLength = this._horizontalLength,
            visualProminence = this._visualProminence,
            radarConspicuous = this._radarConspicuous,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            pictorialRepresentation = this._pictorialRepresentation,
            topmark = this._topmark?.Model,
            information = this.information.ToList(),
            scaleMinimum = this._scaleMinimum,
            featureName = this.featureName.ToList(),
        };

        public LightFloatViewModel() : base() {
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(natureOfConstruction));
            };
            colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(colour));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
        }

        public override string? ToString() => $"Light Float";
    }

    [CategoryOrder("LightAllAround", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class LightAllAroundViewModel : ViewModelBase {
        private Decimal? _verticalLength = default;
        [Category("LightAllAround")]
        public Decimal? verticalLength {
            get {
                return _verticalLength;
            }

            set {
                SetValue(ref _verticalLength, value);
            }
        }

        private marksNavigationalSystemOf? _marksNavigationalSystemOf = default;
        [Category("LightAllAround")]
        public marksNavigationalSystemOf? marksNavigationalSystemOf {
            get {
                return _marksNavigationalSystemOf;
            }

            set {
                SetValue(ref _marksNavigationalSystemOf, value);
            }
        }

        private signalGeneration? _signalGeneration = default;
        [Category("LightAllAround")]
        public signalGeneration? signalGeneration {
            get {
                return _signalGeneration;
            }

            set {
                SetValue(ref _signalGeneration, value);
            }
        }

        private Decimal? _valueOfNominalRange = default;
        [Category("LightAllAround")]
        public Decimal? valueOfNominalRange {
            get {
                return _valueOfNominalRange;
            }

            set {
                SetValue(ref _valueOfNominalRange, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("LightAllAround")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        [Category("LightAllAround")]
        public ObservableCollection<status> status { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("LightAllAround")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("LightAllAround")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private multiplicityOfFeaturesViewModel _multiplicityOfFeatures;
        [Category("LightAllAround")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public multiplicityOfFeaturesViewModel multiplicityOfFeatures {
            get {
                return _multiplicityOfFeatures;
            }

            set {
                SetValue(ref _multiplicityOfFeatures, value);
            }
        }

        private exhibitionConditionOfLight? _exhibitionConditionOfLight = default;
        [Category("LightAllAround")]
        public exhibitionConditionOfLight? exhibitionConditionOfLight {
            get {
                return _exhibitionConditionOfLight;
            }

            set {
                SetValue(ref _exhibitionConditionOfLight, value);
            }
        }

        private Decimal? _height = default;
        [Category("LightAllAround")]
        public Decimal? height {
            get {
                return _height;
            }

            set {
                SetValue(ref _height, value);
            }
        }

        private Decimal? _relativeHorizontalAccuracy = default;
        [Category("LightAllAround")]
        public Decimal? relativeHorizontalAccuracy {
            get {
                return _relativeHorizontalAccuracy;
            }

            set {
                SetValue(ref _relativeHorizontalAccuracy, value);
            }
        }

        private verticalDatum? _verticalDatum = default;
        [Category("LightAllAround")]
        public verticalDatum? verticalDatum {
            get {
                return _verticalDatum;
            }

            set {
                SetValue(ref _verticalDatum, value);
            }
        }

        [Category("LightAllAround")]
        public ObservableCollection<information> information { get; set; } = new();

        private Boolean? _majorLight = default;
        [Category("LightAllAround")]
        public Boolean? majorLight {
            get {
                return _majorLight;
            }

            set {
                SetValue(ref _majorLight, value);
            }
        }

        private lightVisibility? _lightVisibility = default;
        [Category("LightAllAround")]
        public lightVisibility? lightVisibility {
            get {
                return _lightVisibility;
            }

            set {
                SetValue(ref _lightVisibility, value);
            }
        }

        private Int32? _flareBearing = default;
        [Category("LightAllAround")]
        public Int32? flareBearing {
            get {
                return _flareBearing;
            }

            set {
                SetValue(ref _flareBearing, value);
            }
        }

        private heightLengthUnits? _heightLengthUnits = default;
        [Category("LightAllAround")]
        public heightLengthUnits? heightLengthUnits {
            get {
                return _heightLengthUnits;
            }

            set {
                SetValue(ref _heightLengthUnits, value);
            }
        }

        [Category("LightAllAround")]
        public ObservableCollection<categoryOfLight> categoryOfLight { get; set; } = new();

        private rythmOfLightViewModel _rythmOfLight;
        [Category("LightAllAround")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public rythmOfLightViewModel rythmOfLight {
            get {
                return _rythmOfLight;
            }

            set {
                SetValue(ref _rythmOfLight, value);
            }
        }

        [Category("LightAllAround")]
        public ObservableCollection<colour> colour { get; set; } = new();

        [Category("LightAllAround")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("LightAllAround")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        public class LightAllAroundRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["LightAllAround"];
        }

        public void Load(DomainModel.S501.FeatureTypes.LightAllAround instance) {
            verticalLength = instance.verticalLength;
            marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
            signalGeneration = instance.signalGeneration;
            valueOfNominalRange = instance.valueOfNominalRange;
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            scaleMinimum = instance.scaleMinimum;
            multiplicityOfFeatures = new();
            if (instance.multiplicityOfFeatures != null) {
                multiplicityOfFeatures = new();
                multiplicityOfFeatures.Load(instance.multiplicityOfFeatures);
            }

            exhibitionConditionOfLight = instance.exhibitionConditionOfLight;
            height = instance.height;
            relativeHorizontalAccuracy = instance.relativeHorizontalAccuracy;
            verticalDatum = instance.verticalDatum;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            majorLight = instance.majorLight;
            lightVisibility = instance.lightVisibility;
            flareBearing = instance.flareBearing;
            heightLengthUnits = instance.heightLengthUnits;
            categoryOfLight.Clear();
            if (instance.categoryOfLight is not null)
                foreach (var e in instance.categoryOfLight)
                    categoryOfLight.Add(e);
            rythmOfLight = new();
            if (instance.rythmOfLight != null) {
                rythmOfLight = new();
                rythmOfLight.Load(instance.rythmOfLight);
            }

            colour.Clear();
            if (instance.colour is not null)
                foreach (var e in instance.colour)
                    colour.Add(e);
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.LightAllAround
            {
                verticalLength = this.verticalLength,
                marksNavigationalSystemOf = this.marksNavigationalSystemOf,
                signalGeneration = this.signalGeneration,
                valueOfNominalRange = this.valueOfNominalRange,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                status = this.status.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                scaleMinimum = this.scaleMinimum,
                multiplicityOfFeatures = this.multiplicityOfFeatures?.Model,
                exhibitionConditionOfLight = this.exhibitionConditionOfLight,
                height = this.height,
                relativeHorizontalAccuracy = this.relativeHorizontalAccuracy,
                verticalDatum = this.verticalDatum,
                information = this.information.ToList(),
                majorLight = this.majorLight,
                lightVisibility = this.lightVisibility,
                flareBearing = this.flareBearing,
                heightLengthUnits = this.heightLengthUnits,
                categoryOfLight = this.categoryOfLight.ToList(),
                rythmOfLight = this.rythmOfLight?.Model,
                colour = this.colour.ToList(),
                periodicDateRange = this.periodicDateRange.ToList(),
                featureName = this.featureName.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.LightAllAround Model => new()
        {
            verticalLength = this._verticalLength,
            marksNavigationalSystemOf = this._marksNavigationalSystemOf,
            signalGeneration = this._signalGeneration,
            valueOfNominalRange = this._valueOfNominalRange,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            status = this.status.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            scaleMinimum = this._scaleMinimum,
            multiplicityOfFeatures = this._multiplicityOfFeatures?.Model,
            exhibitionConditionOfLight = this._exhibitionConditionOfLight,
            height = this._height,
            relativeHorizontalAccuracy = this._relativeHorizontalAccuracy,
            verticalDatum = this._verticalDatum,
            information = this.information.ToList(),
            majorLight = this._majorLight,
            lightVisibility = this._lightVisibility,
            flareBearing = this._flareBearing,
            heightLengthUnits = this._heightLengthUnits,
            categoryOfLight = this.categoryOfLight.ToList(),
            rythmOfLight = this._rythmOfLight?.Model,
            colour = this.colour.ToList(),
            periodicDateRange = this.periodicDateRange.ToList(),
            featureName = this.featureName.ToList(),
        };

        public LightAllAroundViewModel() : base() {
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            categoryOfLight.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(categoryOfLight));
            };
            colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(colour));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
        }

        public override string? ToString() => $"Light All Around";
    }

    [CategoryOrder("Coastline", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class CoastlineViewModel : ViewModelBase {
        [Category("Coastline")]
        public ObservableCollection<colour> colour { get; set; } = new();

        [Category("Coastline")]
        public ObservableCollection<information> information { get; set; } = new();

        private categoryOfCoastline? _categoryOfCoastline = default;
        [Category("Coastline")]
        public categoryOfCoastline? categoryOfCoastline {
            get {
                return _categoryOfCoastline;
            }

            set {
                SetValue(ref _categoryOfCoastline, value);
            }
        }

        private Decimal? _elevation = default;
        [Category("Coastline")]
        public Decimal? elevation {
            get {
                return _elevation;
            }

            set {
                SetValue(ref _elevation, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("Coastline")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("Coastline")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        [Category("Coastline")]
        public ObservableCollection<natureOfSurface> natureOfSurface { get; set; } = new();

        [Category("Coastline")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private visualProminence? _visualProminence = default;
        [Category("Coastline")]
        public visualProminence? visualProminence {
            get {
                return _visualProminence;
            }

            set {
                SetValue(ref _visualProminence, value);
            }
        }

        private String _pictorialRepresentation = string.Empty;
        [Category("Coastline")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("Coastline")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private Boolean? _radarConspicuous = default;
        [Category("Coastline")]
        public Boolean? radarConspicuous {
            get {
                return _radarConspicuous;
            }

            set {
                SetValue(ref _radarConspicuous, value);
            }
        }

        public class CoastlineRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["Coastline"];
        }

        public void Load(DomainModel.S501.FeatureTypes.Coastline instance) {
            colour.Clear();
            if (instance.colour is not null)
                foreach (var e in instance.colour)
                    colour.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            categoryOfCoastline = instance.categoryOfCoastline;
            elevation = instance.elevation;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            natureOfSurface.Clear();
            if (instance.natureOfSurface is not null)
                foreach (var e in instance.natureOfSurface)
                    natureOfSurface.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            visualProminence = instance.visualProminence;
            pictorialRepresentation = instance.pictorialRepresentation;
            reportedDate = instance.reportedDate;
            radarConspicuous = instance.radarConspicuous;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.Coastline
            {
                colour = this.colour.ToList(),
                information = this.information.ToList(),
                categoryOfCoastline = this.categoryOfCoastline,
                elevation = this.elevation,
                sourceIdentification = this.sourceIdentification?.Model,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                natureOfSurface = this.natureOfSurface.ToList(),
                featureName = this.featureName.ToList(),
                visualProminence = this.visualProminence,
                pictorialRepresentation = this.pictorialRepresentation,
                reportedDate = this.reportedDate,
                radarConspicuous = this.radarConspicuous,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.Coastline Model => new()
        {
            colour = this.colour.ToList(),
            information = this.information.ToList(),
            categoryOfCoastline = this._categoryOfCoastline,
            elevation = this._elevation,
            sourceIdentification = this._sourceIdentification?.Model,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            natureOfSurface = this.natureOfSurface.ToList(),
            featureName = this.featureName.ToList(),
            visualProminence = this._visualProminence,
            pictorialRepresentation = this._pictorialRepresentation,
            reportedDate = this._reportedDate,
            radarConspicuous = this._radarConspicuous,
        };

        public CoastlineViewModel() : base() {
            colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(colour));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            natureOfSurface.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(natureOfSurface));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
        }

        public override string? ToString() => $"Coastline";
    }

    [CategoryOrder("SeaAreaNamedWaterArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class SeaAreaNamedWaterAreaViewModel : ViewModelBase {
        private categoryOfSeaArea? _categoryOfSeaArea = default;
        [Category("SeaAreaNamedWaterArea")]
        public categoryOfSeaArea? categoryOfSeaArea {
            get {
                return _categoryOfSeaArea;
            }

            set {
                SetValue(ref _categoryOfSeaArea, value);
            }
        }

        [Category("SeaAreaNamedWaterArea")]
        public ObservableCollection<information> information { get; set; } = new();

        private DateOnly? _reportedDate = default;
        [Category("SeaAreaNamedWaterArea")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("SeaAreaNamedWaterArea")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private gradient? _gradient = default;
        [Category("SeaAreaNamedWaterArea")]
        public gradient? gradient {
            get {
                return _gradient;
            }

            set {
                SetValue(ref _gradient, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("SeaAreaNamedWaterArea")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private qualityOfHorizontalMeasurement? _qualityOfHorizontalMeasurement = default;
        [Category("SeaAreaNamedWaterArea")]
        public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement {
            get {
                return _qualityOfHorizontalMeasurement;
            }

            set {
                SetValue(ref _qualityOfHorizontalMeasurement, value);
            }
        }

        public class SeaAreaNamedWaterAreaRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["SeaAreaNamedWaterArea"];
        }

        public void Load(DomainModel.S501.FeatureTypes.SeaAreaNamedWaterArea instance) {
            categoryOfSeaArea = instance.categoryOfSeaArea;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            reportedDate = instance.reportedDate;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            gradient = instance.gradient;
            scaleMinimum = instance.scaleMinimum;
            qualityOfHorizontalMeasurement = instance.qualityOfHorizontalMeasurement;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.SeaAreaNamedWaterArea
            {
                categoryOfSeaArea = this.categoryOfSeaArea,
                information = this.information.ToList(),
                reportedDate = this.reportedDate,
                featureName = this.featureName.ToList(),
                gradient = this.gradient,
                scaleMinimum = this.scaleMinimum,
                qualityOfHorizontalMeasurement = this.qualityOfHorizontalMeasurement,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.SeaAreaNamedWaterArea Model => new()
        {
            categoryOfSeaArea = this._categoryOfSeaArea,
            information = this.information.ToList(),
            reportedDate = this._reportedDate,
            featureName = this.featureName.ToList(),
            gradient = this._gradient,
            scaleMinimum = this._scaleMinimum,
            qualityOfHorizontalMeasurement = this._qualityOfHorizontalMeasurement,
        };

        public SeaAreaNamedWaterAreaViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
        }

        public override string? ToString() => $"Sea Area/Named Water Area";
    }

    [CategoryOrder("DropZone", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class DropZoneViewModel : ViewModelBase {
        [Category("DropZone")]
        public ObservableCollection<information> information { get; set; } = new();

        public class DropZoneRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["DropZone"];
        }

        public void Load(DomainModel.S501.FeatureTypes.DropZone instance) {
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.DropZone
            {
                information = this.information.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.DropZone Model => new()
        {
            information = this.information.ToList(),
        };

        public DropZoneViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Drop Zone";
    }

    [CategoryOrder("Conveyor", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ConveyorViewModel : ViewModelBase {
        private categoryOfConveyor? _categoryOfConveyor = default;
        [Category("Conveyor")]
        public categoryOfConveyor? categoryOfConveyor {
            get {
                return _categoryOfConveyor;
            }

            set {
                SetValue(ref _categoryOfConveyor, value);
            }
        }

        [Category("Conveyor")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private condition? _condition = default;
        [Category("Conveyor")]
        public condition? condition {
            get {
                return _condition;
            }

            set {
                SetValue(ref _condition, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("Conveyor")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("Conveyor")]
        public ObservableCollection<colour> colour { get; set; } = new();

        [Category("Conveyor")]
        public ObservableCollection<information> information { get; set; } = new();

        private visualProminence? _visualProminence = default;
        [Category("Conveyor")]
        public visualProminence? visualProminence {
            get {
                return _visualProminence;
            }

            set {
                SetValue(ref _visualProminence, value);
            }
        }

        private Decimal? _height = default;
        [Category("Conveyor")]
        public Decimal? height {
            get {
                return _height;
            }

            set {
                SetValue(ref _height, value);
            }
        }

        private Boolean? _radarConspicuous = default;
        [Category("Conveyor")]
        public Boolean? radarConspicuous {
            get {
                return _radarConspicuous;
            }

            set {
                SetValue(ref _radarConspicuous, value);
            }
        }

        private multiplicityOfFeaturesViewModel? _multiplicityOfFeatures;
        [Category("Conveyor")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public multiplicityOfFeaturesViewModel? multiplicityOfFeatures {
            get {
                return _multiplicityOfFeatures;
            }

            set {
                SetValue(ref _multiplicityOfFeatures, value);
            }
        }

        [Category("Conveyor")]
        public ObservableCollection<status> status { get; set; } = new();

        private Decimal? _liftingCapacity = default;
        [Category("Conveyor")]
        public Decimal? liftingCapacity {
            get {
                return _liftingCapacity;
            }

            set {
                SetValue(ref _liftingCapacity, value);
            }
        }

        private verticalClearanceFixedViewModel? _verticalClearanceFixed;
        [Category("Conveyor")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public verticalClearanceFixedViewModel? verticalClearanceFixed {
            get {
                return _verticalClearanceFixed;
            }

            set {
                SetValue(ref _verticalClearanceFixed, value);
            }
        }

        private verticalDatum? _verticalDatum = default;
        [Category("Conveyor")]
        public verticalDatum? verticalDatum {
            get {
                return _verticalDatum;
            }

            set {
                SetValue(ref _verticalDatum, value);
            }
        }

        private String _pictorialRepresentation = string.Empty;
        [Category("Conveyor")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("Conveyor")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private colourPattern? _colourPattern = default;
        [Category("Conveyor")]
        public colourPattern? colourPattern {
            get {
                return _colourPattern;
            }

            set {
                SetValue(ref _colourPattern, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("Conveyor")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        [Category("Conveyor")]
        public ObservableCollection<product> product { get; set; } = new();

        private Decimal? _verticalLength = default;
        [Category("Conveyor")]
        public Decimal? verticalLength {
            get {
                return _verticalLength;
            }

            set {
                SetValue(ref _verticalLength, value);
            }
        }

        public class ConveyorRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["Conveyor"];
        }

        public void Load(DomainModel.S501.FeatureTypes.Conveyor instance) {
            categoryOfConveyor = instance.categoryOfConveyor;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            condition = instance.condition;
            reportedDate = instance.reportedDate;
            colour.Clear();
            if (instance.colour is not null)
                foreach (var e in instance.colour)
                    colour.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            visualProminence = instance.visualProminence;
            height = instance.height;
            radarConspicuous = instance.radarConspicuous;
            multiplicityOfFeatures = new();
            if (instance.multiplicityOfFeatures != null) {
                multiplicityOfFeatures = new();
                multiplicityOfFeatures.Load(instance.multiplicityOfFeatures);
            }

            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            liftingCapacity = instance.liftingCapacity;
            verticalClearanceFixed = new();
            if (instance.verticalClearanceFixed != null) {
                verticalClearanceFixed = new();
                verticalClearanceFixed.Load(instance.verticalClearanceFixed);
            }

            verticalDatum = instance.verticalDatum;
            pictorialRepresentation = instance.pictorialRepresentation;
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            colourPattern = instance.colourPattern;
            scaleMinimum = instance.scaleMinimum;
            product.Clear();
            if (instance.product is not null)
                foreach (var e in instance.product)
                    product.Add(e);
            verticalLength = instance.verticalLength;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.Conveyor
            {
                categoryOfConveyor = this.categoryOfConveyor,
                featureName = this.featureName.ToList(),
                condition = this.condition,
                reportedDate = this.reportedDate,
                colour = this.colour.ToList(),
                information = this.information.ToList(),
                visualProminence = this.visualProminence,
                height = this.height,
                radarConspicuous = this.radarConspicuous,
                multiplicityOfFeatures = this.multiplicityOfFeatures?.Model,
                status = this.status.ToList(),
                liftingCapacity = this.liftingCapacity,
                verticalClearanceFixed = this.verticalClearanceFixed?.Model,
                verticalDatum = this.verticalDatum,
                pictorialRepresentation = this.pictorialRepresentation,
                fixedDateRange = this.fixedDateRange?.Model,
                colourPattern = this.colourPattern,
                scaleMinimum = this.scaleMinimum,
                product = this.product.ToList(),
                verticalLength = this.verticalLength,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.Conveyor Model => new()
        {
            categoryOfConveyor = this._categoryOfConveyor,
            featureName = this.featureName.ToList(),
            condition = this._condition,
            reportedDate = this._reportedDate,
            colour = this.colour.ToList(),
            information = this.information.ToList(),
            visualProminence = this._visualProminence,
            height = this._height,
            radarConspicuous = this._radarConspicuous,
            multiplicityOfFeatures = this._multiplicityOfFeatures?.Model,
            status = this.status.ToList(),
            liftingCapacity = this._liftingCapacity,
            verticalClearanceFixed = this._verticalClearanceFixed?.Model,
            verticalDatum = this._verticalDatum,
            pictorialRepresentation = this._pictorialRepresentation,
            fixedDateRange = this._fixedDateRange?.Model,
            colourPattern = this._colourPattern,
            scaleMinimum = this._scaleMinimum,
            product = this.product.ToList(),
            verticalLength = this._verticalLength,
        };

        public ConveyorViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(colour));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            product.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(product));
            };
        }

        public override string? ToString() => $"Conveyor";
    }

    [CategoryOrder("LineOfDelimitation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class LineOfDelimitationViewModel : ViewModelBase {
        [Category("LineOfDelimitation")]
        public ObservableCollection<String> nationalMaritimeAuthority { get; set; } = new();

        private boundaryStatusType? _boundaryStatusType = default;
        [Category("LineOfDelimitation")]
        public boundaryStatusType? boundaryStatusType {
            get {
                return _boundaryStatusType;
            }

            set {
                SetValue(ref _boundaryStatusType, value);
            }
        }

        [Category("LineOfDelimitation")]
        public ObservableCollection<information> information { get; set; } = new();

        private DateOnly? _reportedDate = default;
        [Category("LineOfDelimitation")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("LineOfDelimitation")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private jurisdiction? _jurisdiction = default;
        [Category("LineOfDelimitation")]
        public jurisdiction? jurisdiction {
            get {
                return _jurisdiction;
            }

            set {
                SetValue(ref _jurisdiction, value);
            }
        }

        private categoryofBoundaryLine? _categoryofBoundaryLine = default;
        [Category("LineOfDelimitation")]
        public categoryofBoundaryLine? categoryofBoundaryLine {
            get {
                return _categoryofBoundaryLine;
            }

            set {
                SetValue(ref _categoryofBoundaryLine, value);
            }
        }

        private Boolean? _inDispute = default;
        [Category("LineOfDelimitation")]
        public Boolean? inDispute {
            get {
                return _inDispute;
            }

            set {
                SetValue(ref _inDispute, value);
            }
        }

        public class LineOfDelimitationRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["LineOfDelimitation"];
        }

        public void Load(DomainModel.S501.FeatureTypes.LineOfDelimitation instance) {
            nationalMaritimeAuthority.Clear();
            if (instance.nationalMaritimeAuthority is not null)
                foreach (var e in instance.nationalMaritimeAuthority)
                    nationalMaritimeAuthority.Add(e);
            boundaryStatusType = instance.boundaryStatusType;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            reportedDate = instance.reportedDate;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            jurisdiction = instance.jurisdiction;
            categoryofBoundaryLine = instance.categoryofBoundaryLine;
            inDispute = instance.inDispute;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.LineOfDelimitation
            {
                nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
                boundaryStatusType = this.boundaryStatusType,
                information = this.information.ToList(),
                reportedDate = this.reportedDate,
                sourceIdentification = this.sourceIdentification?.Model,
                jurisdiction = this.jurisdiction,
                categoryofBoundaryLine = this.categoryofBoundaryLine,
                inDispute = this.inDispute,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.LineOfDelimitation Model => new()
        {
            nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
            boundaryStatusType = this._boundaryStatusType,
            information = this.information.ToList(),
            reportedDate = this._reportedDate,
            sourceIdentification = this._sourceIdentification?.Model,
            jurisdiction = this._jurisdiction,
            categoryofBoundaryLine = this._categoryofBoundaryLine,
            inDispute = this._inDispute,
        };

        public LineOfDelimitationViewModel() : base() {
            nationalMaritimeAuthority.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(nationalMaritimeAuthority));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Line of Delimitation";
    }

    [CategoryOrder("StraightTerritorialSeaBaseline", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class StraightTerritorialSeaBaselineViewModel : ViewModelBase {
        private String _nationality = string.Empty;
        [Category("StraightTerritorialSeaBaseline")]
        public String nationality {
            get {
                return _nationality;
            }

            set {
                SetValue(ref _nationality, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("StraightTerritorialSeaBaseline")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("StraightTerritorialSeaBaseline")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("StraightTerritorialSeaBaseline")]
        public ObservableCollection<information> information { get; set; } = new();

        private status? _status = default;
        [Category("StraightTerritorialSeaBaseline")]
        public status? status {
            get {
                return _status;
            }

            set {
                SetValue(ref _status, value);
            }
        }

        private Boolean? _inDispute = default;
        [Category("StraightTerritorialSeaBaseline")]
        public Boolean? inDispute {
            get {
                return _inDispute;
            }

            set {
                SetValue(ref _inDispute, value);
            }
        }

        private String _agencyResponsibleForProduction = string.Empty;
        [Category("StraightTerritorialSeaBaseline")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("StraightTerritorialSeaBaseline")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        public class StraightTerritorialSeaBaselineRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["StraightTerritorialSeaBaseline"];
        }

        public void Load(DomainModel.S501.FeatureTypes.StraightTerritorialSeaBaseline instance) {
            nationality = instance.nationality;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            reportedDate = instance.reportedDate;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            status = instance.status;
            inDispute = instance.inDispute;
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            scaleMinimum = instance.scaleMinimum;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.StraightTerritorialSeaBaseline
            {
                nationality = this.nationality,
                sourceIdentification = this.sourceIdentification?.Model,
                reportedDate = this.reportedDate,
                information = this.information.ToList(),
                status = this.status,
                inDispute = this.inDispute,
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                scaleMinimum = this.scaleMinimum,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.StraightTerritorialSeaBaseline Model => new()
        {
            nationality = this._nationality,
            sourceIdentification = this._sourceIdentification?.Model,
            reportedDate = this._reportedDate,
            information = this.information.ToList(),
            status = this._status,
            inDispute = this._inDispute,
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            scaleMinimum = this._scaleMinimum,
        };

        public StraightTerritorialSeaBaselineViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Straight Territorial Sea Baseline";
    }

    [CategoryOrder("SafeWaterBeacon", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class SafeWaterBeaconViewModel : ViewModelBase {
        [Category("SafeWaterBeacon")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("SafeWaterBeacon")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private Decimal? _elevation = default;
        [Category("SafeWaterBeacon")]
        public Decimal? elevation {
            get {
                return _elevation;
            }

            set {
                SetValue(ref _elevation, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("SafeWaterBeacon")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private Decimal? _height = default;
        [Category("SafeWaterBeacon")]
        public Decimal? height {
            get {
                return _height;
            }

            set {
                SetValue(ref _height, value);
            }
        }

        private topmarkViewModel? _topmark;
        [Category("SafeWaterBeacon")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public topmarkViewModel? topmark {
            get {
                return _topmark;
            }

            set {
                SetValue(ref _topmark, value);
            }
        }

        [Category("SafeWaterBeacon")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        private Boolean? _radarConspicuous = default;
        [Category("SafeWaterBeacon")]
        public Boolean? radarConspicuous {
            get {
                return _radarConspicuous;
            }

            set {
                SetValue(ref _radarConspicuous, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("SafeWaterBeacon")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private condition? _condition = default;
        [Category("SafeWaterBeacon")]
        public condition? condition {
            get {
                return _condition;
            }

            set {
                SetValue(ref _condition, value);
            }
        }

        private colourPattern? _colourPattern = default;
        [Category("SafeWaterBeacon")]
        public colourPattern? colourPattern {
            get {
                return _colourPattern;
            }

            set {
                SetValue(ref _colourPattern, value);
            }
        }

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("SafeWaterBeacon")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private Decimal? _verticalLength = default;
        [Category("SafeWaterBeacon")]
        public Decimal? verticalLength {
            get {
                return _verticalLength;
            }

            set {
                SetValue(ref _verticalLength, value);
            }
        }

        private beaconShape _beaconShape;
        [Category("SafeWaterBeacon")]
        public beaconShape beaconShape {
            get {
                return _beaconShape;
            }

            set {
                SetValue(ref _beaconShape, value);
            }
        }

        [Category("SafeWaterBeacon")]
        public ObservableCollection<status> status { get; set; } = new();

        private String _pictorialRepresentation = string.Empty;
        [Category("SafeWaterBeacon")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        private marksNavigationalSystemOf? _marksNavigationalSystemOf = default;
        [Category("SafeWaterBeacon")]
        public marksNavigationalSystemOf? marksNavigationalSystemOf {
            get {
                return _marksNavigationalSystemOf;
            }

            set {
                SetValue(ref _marksNavigationalSystemOf, value);
            }
        }

        private String _interoperabilityIdentifier = string.Empty;
        [Category("SafeWaterBeacon")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("SafeWaterBeacon")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        [Category("SafeWaterBeacon")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("SafeWaterBeacon")]
        public ObservableCollection<colour> colour { get; set; } = new();

        private visualProminence? _visualProminence = default;
        [Category("SafeWaterBeacon")]
        public visualProminence? visualProminence {
            get {
                return _visualProminence;
            }

            set {
                SetValue(ref _visualProminence, value);
            }
        }

        public class SafeWaterBeaconRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["SafeWaterBeacon"];
        }

        public void Load(DomainModel.S501.FeatureTypes.SafeWaterBeacon instance) {
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            elevation = instance.elevation;
            scaleMinimum = instance.scaleMinimum;
            height = instance.height;
            topmark = new();
            if (instance.topmark != null) {
                topmark = new();
                topmark.Load(instance.topmark);
            }

            natureOfConstruction.Clear();
            if (instance.natureOfConstruction is not null)
                foreach (var e in instance.natureOfConstruction)
                    natureOfConstruction.Add(e);
            radarConspicuous = instance.radarConspicuous;
            reportedDate = instance.reportedDate;
            condition = instance.condition;
            colourPattern = instance.colourPattern;
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            verticalLength = instance.verticalLength;
            beaconShape = instance.beaconShape;
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            pictorialRepresentation = instance.pictorialRepresentation;
            marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            colour.Clear();
            if (instance.colour is not null)
                foreach (var e in instance.colour)
                    colour.Add(e);
            visualProminence = instance.visualProminence;
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.SafeWaterBeacon
            {
                information = this.information.ToList(),
                featureName = this.featureName.ToList(),
                elevation = this.elevation,
                scaleMinimum = this.scaleMinimum,
                height = this.height,
                topmark = this.topmark?.Model,
                natureOfConstruction = this.natureOfConstruction.ToList(),
                radarConspicuous = this.radarConspicuous,
                reportedDate = this.reportedDate,
                condition = this.condition,
                colourPattern = this.colourPattern,
                fixedDateRange = this.fixedDateRange?.Model,
                verticalLength = this.verticalLength,
                beaconShape = this.beaconShape,
                status = this.status.ToList(),
                pictorialRepresentation = this.pictorialRepresentation,
                marksNavigationalSystemOf = this.marksNavigationalSystemOf,
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                sourceIdentification = this.sourceIdentification?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                colour = this.colour.ToList(),
                visualProminence = this.visualProminence,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.SafeWaterBeacon Model => new()
        {
            information = this.information.ToList(),
            featureName = this.featureName.ToList(),
            elevation = this._elevation,
            scaleMinimum = this._scaleMinimum,
            height = this._height,
            topmark = this._topmark?.Model,
            natureOfConstruction = this.natureOfConstruction.ToList(),
            radarConspicuous = this._radarConspicuous,
            reportedDate = this._reportedDate,
            condition = this._condition,
            colourPattern = this._colourPattern,
            fixedDateRange = this._fixedDateRange?.Model,
            verticalLength = this._verticalLength,
            beaconShape = this._beaconShape,
            status = this.status.ToList(),
            pictorialRepresentation = this._pictorialRepresentation,
            marksNavigationalSystemOf = this._marksNavigationalSystemOf,
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            sourceIdentification = this._sourceIdentification?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            colour = this.colour.ToList(),
            visualProminence = this._visualProminence,
        };

        public SafeWaterBeaconViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(natureOfConstruction));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(colour));
            };
        }

        public override string? ToString() => $"Safe Water Beacon";
    }

    [CategoryOrder("SpecialPurposeGeneralBeacon", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class SpecialPurposeGeneralBeaconViewModel : ViewModelBase {
        private sourceIdentificationViewModel? _sourceIdentification;
        [Category("SpecialPurposeGeneralBeacon")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIdentificationViewModel? sourceIdentification {
            get {
                return _sourceIdentification;
            }

            set {
                SetValue(ref _sourceIdentification, value);
            }
        }

        [Category("SpecialPurposeGeneralBeacon")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("SpecialPurposeGeneralBeacon")]
        public ObservableCollection<status> status { get; set; } = new();

        [Category("SpecialPurposeGeneralBeacon")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        private String _interoperabilityIdentifier = string.Empty;
        [Category("SpecialPurposeGeneralBeacon")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("SpecialPurposeGeneralBeacon")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        private Decimal? _height = default;
        [Category("SpecialPurposeGeneralBeacon")]
        public Decimal? height {
            get {
                return _height;
            }

            set {
                SetValue(ref _height, value);
            }
        }

        private condition? _condition = default;
        [Category("SpecialPurposeGeneralBeacon")]
        public condition? condition {
            get {
                return _condition;
            }

            set {
                SetValue(ref _condition, value);
            }
        }

        private Decimal? _verticalLength = default;
        [Category("SpecialPurposeGeneralBeacon")]
        public Decimal? verticalLength {
            get {
                return _verticalLength;
            }

            set {
                SetValue(ref _verticalLength, value);
            }
        }

        private Decimal? _elevation = default;
        [Category("SpecialPurposeGeneralBeacon")]
        public Decimal? elevation {
            get {
                return _elevation;
            }

            set {
                SetValue(ref _elevation, value);
            }
        }

        private colourPattern? _colourPattern = default;
        [Category("SpecialPurposeGeneralBeacon")]
        public colourPattern? colourPattern {
            get {
                return _colourPattern;
            }

            set {
                SetValue(ref _colourPattern, value);
            }
        }

        private Boolean? _radarConspicuous = default;
        [Category("SpecialPurposeGeneralBeacon")]
        public Boolean? radarConspicuous {
            get {
                return _radarConspicuous;
            }

            set {
                SetValue(ref _radarConspicuous, value);
            }
        }

        private String _pictorialRepresentation = string.Empty;
        [Category("SpecialPurposeGeneralBeacon")]
        public String pictorialRepresentation {
            get {
                return _pictorialRepresentation;
            }

            set {
                SetValue(ref _pictorialRepresentation, value);
            }
        }

        private beaconShape _beaconShape;
        [Category("SpecialPurposeGeneralBeacon")]
        public beaconShape beaconShape {
            get {
                return _beaconShape;
            }

            set {
                SetValue(ref _beaconShape, value);
            }
        }

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("SpecialPurposeGeneralBeacon")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private topmarkViewModel? _topmark;
        [Category("SpecialPurposeGeneralBeacon")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public topmarkViewModel? topmark {
            get {
                return _topmark;
            }

            set {
                SetValue(ref _topmark, value);
            }
        }

        [Category("SpecialPurposeGeneralBeacon")]
        public ObservableCollection<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark { get; set; } = new();

        private marksNavigationalSystemOf? _marksNavigationalSystemOf = default;
        [Category("SpecialPurposeGeneralBeacon")]
        public marksNavigationalSystemOf? marksNavigationalSystemOf {
            get {
                return _marksNavigationalSystemOf;
            }

            set {
                SetValue(ref _marksNavigationalSystemOf, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("SpecialPurposeGeneralBeacon")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private visualProminence? _visualProminence = default;
        [Category("SpecialPurposeGeneralBeacon")]
        public visualProminence? visualProminence {
            get {
                return _visualProminence;
            }

            set {
                SetValue(ref _visualProminence, value);
            }
        }

        [Category("SpecialPurposeGeneralBeacon")]
        public ObservableCollection<colour> colour { get; set; } = new();

        [Category("SpecialPurposeGeneralBeacon")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        [Category("SpecialPurposeGeneralBeacon")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        public class SpecialPurposeGeneralBeaconRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["SpecialPurposeGeneralBeacon"];
        }

        public void Load(DomainModel.S501.FeatureTypes.SpecialPurposeGeneralBeacon instance) {
            sourceIdentification = new();
            if (instance.sourceIdentification != null) {
                sourceIdentification = new();
                sourceIdentification.Load(instance.sourceIdentification);
            }

            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            natureOfConstruction.Clear();
            if (instance.natureOfConstruction is not null)
                foreach (var e in instance.natureOfConstruction)
                    natureOfConstruction.Add(e);
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            scaleMinimum = instance.scaleMinimum;
            height = instance.height;
            condition = instance.condition;
            verticalLength = instance.verticalLength;
            elevation = instance.elevation;
            colourPattern = instance.colourPattern;
            radarConspicuous = instance.radarConspicuous;
            pictorialRepresentation = instance.pictorialRepresentation;
            beaconShape = instance.beaconShape;
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            topmark = new();
            if (instance.topmark != null) {
                topmark = new();
                topmark.Load(instance.topmark);
            }

            categoryOfSpecialPurposeMark.Clear();
            if (instance.categoryOfSpecialPurposeMark is not null)
                foreach (var e in instance.categoryOfSpecialPurposeMark)
                    categoryOfSpecialPurposeMark.Add(e);
            marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
            reportedDate = instance.reportedDate;
            visualProminence = instance.visualProminence;
            colour.Clear();
            if (instance.colour is not null)
                foreach (var e in instance.colour)
                    colour.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S501.FeatureTypes.SpecialPurposeGeneralBeacon
            {
                sourceIdentification = this.sourceIdentification?.Model,
                information = this.information.ToList(),
                status = this.status.ToList(),
                natureOfConstruction = this.natureOfConstruction.ToList(),
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                scaleMinimum = this.scaleMinimum,
                height = this.height,
                condition = this.condition,
                verticalLength = this.verticalLength,
                elevation = this.elevation,
                colourPattern = this.colourPattern,
                radarConspicuous = this.radarConspicuous,
                pictorialRepresentation = this.pictorialRepresentation,
                beaconShape = this.beaconShape,
                fixedDateRange = this.fixedDateRange?.Model,
                topmark = this.topmark?.Model,
                categoryOfSpecialPurposeMark = this.categoryOfSpecialPurposeMark.ToList(),
                marksNavigationalSystemOf = this.marksNavigationalSystemOf,
                reportedDate = this.reportedDate,
                visualProminence = this.visualProminence,
                colour = this.colour.ToList(),
                featureName = this.featureName.ToList(),
                periodicDateRange = this.periodicDateRange.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S501.FeatureTypes.SpecialPurposeGeneralBeacon Model => new()
        {
            sourceIdentification = this._sourceIdentification?.Model,
            information = this.information.ToList(),
            status = this.status.ToList(),
            natureOfConstruction = this.natureOfConstruction.ToList(),
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            scaleMinimum = this._scaleMinimum,
            height = this._height,
            condition = this._condition,
            verticalLength = this._verticalLength,
            elevation = this._elevation,
            colourPattern = this._colourPattern,
            radarConspicuous = this._radarConspicuous,
            pictorialRepresentation = this._pictorialRepresentation,
            beaconShape = this._beaconShape,
            fixedDateRange = this._fixedDateRange?.Model,
            topmark = this._topmark?.Model,
            categoryOfSpecialPurposeMark = this.categoryOfSpecialPurposeMark.ToList(),
            marksNavigationalSystemOf = this._marksNavigationalSystemOf,
            reportedDate = this._reportedDate,
            visualProminence = this._visualProminence,
            colour = this.colour.ToList(),
            featureName = this.featureName.ToList(),
            periodicDateRange = this.periodicDateRange.ToList(),
        };

        public SpecialPurposeGeneralBeaconViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(natureOfConstruction));
            };
            categoryOfSpecialPurposeMark.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(categoryOfSpecialPurposeMark));
            };
            colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(colour));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
        }

        public override string? ToString() => $"Special Purpose/General Beacon";
    }
}