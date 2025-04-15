using System;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Reflection;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S501;
using S100Framework.DomainModel.S501.ComplexAttributes;
using S100Framework.DomainModel.S501.InformationTypes;
using S100Framework.DomainModel.S501.FeatureTypes;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

#nullable enable
namespace S100Framework.WPF.ViewModel.S501 {
    internal static class Bootstrap {
        public static AssociationViewModel CreateInformationAssociation(string type, string? pid = default) => type switch
        {
            _ => throw new InvalidOperationException(),
        };
        public static AssociationViewModel CreateFeatureAssociation(string type, string? pid = default) => type switch
        {
            _ => throw new InvalidOperationException(),
        };
        public static InformationViewModel CreateInformationType(string type, string? pid = default) => type switch
        {
            "ReferenceToAPublication" => new ReferenceToAPublicationViewModel
            {
                PID = pid
            },
            _ => throw new InvalidOperationException(),
        };
        public static FeatureViewModel CreateFeatureType(string type, string? pid = default) => type switch
        {
            "InstallationBuoy" => new InstallationBuoyViewModel
            {
                PID = pid
            },
            "DepthArea" => new DepthAreaViewModel
            {
                PID = pid
            },
            "RadioCallingInPoint" => new RadioCallingInPointViewModel
            {
                PID = pid
            },
            "PatrolArea" => new PatrolAreaViewModel
            {
                PID = pid
            },
            "Checkpoint" => new CheckpointViewModel
            {
                PID = pid
            },
            "MarineManagementArea" => new MarineManagementAreaViewModel
            {
                PID = pid
            },
            "DepthContour" => new DepthContourViewModel
            {
                PID = pid
            },
            "EnvironmentallySensitiveSeaArea" => new EnvironmentallySensitiveSeaAreaViewModel
            {
                PID = pid
            },
            "Road" => new RoadViewModel
            {
                PID = pid
            },
            "River" => new RiverViewModel
            {
                PID = pid
            },
            "MilitaryPracticeArea" => new MilitaryPracticeAreaViewModel
            {
                PID = pid
            },
            "DiscolouredWater" => new DiscolouredWaterViewModel
            {
                PID = pid
            },
            "CardinalBuoy" => new CardinalBuoyViewModel
            {
                PID = pid
            },
            "SafeWaterBuoy" => new SafeWaterBuoyViewModel
            {
                PID = pid
            },
            "RadioStation" => new RadioStationViewModel
            {
                PID = pid
            },
            "MilitaryExerciseAirspace" => new MilitaryExerciseAirspaceViewModel
            {
                PID = pid
            },
            "ContiguousZone" => new ContiguousZoneViewModel
            {
                PID = pid
            },
            "NormalBaseline" => new NormalBaselineViewModel
            {
                PID = pid
            },
            "CableArea" => new CableAreaViewModel
            {
                PID = pid
            },
            "ContinentalShelfArea" => new ContinentalShelfAreaViewModel
            {
                PID = pid
            },
            "InternalWaters" => new InternalWatersViewModel
            {
                PID = pid
            },
            "AdministrationArea" => new AdministrationAreaViewModel
            {
                PID = pid
            },
            "Bollard" => new BollardViewModel
            {
                PID = pid
            },
            "Dolphin" => new DolphinViewModel
            {
                PID = pid
            },
            "RadarRange" => new RadarRangeViewModel
            {
                PID = pid
            },
            "IsolatedDangerBeacon" => new IsolatedDangerBeaconViewModel
            {
                PID = pid
            },
            "IsolatedDangerBuoy" => new IsolatedDangerBuoyViewModel
            {
                PID = pid
            },
            "SubmarineTransitLane" => new SubmarineTransitLaneViewModel
            {
                PID = pid
            },
            "MaritimeSafetyInformationArea" => new MaritimeSafetyInformationAreaViewModel
            {
                PID = pid
            },
            "AirspaceRestriction" => new AirspaceRestrictionViewModel
            {
                PID = pid
            },
            "Sounding" => new SoundingViewModel
            {
                PID = pid
            },
            "TrafficSeparationSchemeBoundary" => new TrafficSeparationSchemeBoundaryViewModel
            {
                PID = pid
            },
            "DumpingGround" => new DumpingGroundViewModel
            {
                PID = pid
            },
            "AirportAirfield" => new AirportAirfieldViewModel
            {
                PID = pid
            },
            "FoulGround" => new FoulGroundViewModel
            {
                PID = pid
            },
            "LightAirObstruction" => new LightAirObstructionViewModel
            {
                PID = pid
            },
            "MooringBuoy" => new MooringBuoyViewModel
            {
                PID = pid
            },
            "UnderwaterAwashRock" => new UnderwaterAwashRockViewModel
            {
                PID = pid
            },
            "CableOverhead" => new CableOverheadViewModel
            {
                PID = pid
            },
            "ControlledAirspace" => new ControlledAirspaceViewModel
            {
                PID = pid
            },
            "Obstruction" => new ObstructionViewModel
            {
                PID = pid
            },
            "FishingGround" => new FishingGroundViewModel
            {
                PID = pid
            },
            "FishingFacility" => new FishingFacilityViewModel
            {
                PID = pid
            },
            "NavigationSystem" => new NavigationSystemViewModel
            {
                PID = pid
            },
            "TrafficSeparationSchemeCrossing" => new TrafficSeparationSchemeCrossingViewModel
            {
                PID = pid
            },
            "TrafficSeparationSchemeLanePart" => new TrafficSeparationSchemeLanePartViewModel
            {
                PID = pid
            },
            "TerritorialSeaArea" => new TerritorialSeaAreaViewModel
            {
                PID = pid
            },
            "LateralBeacon" => new LateralBeaconViewModel
            {
                PID = pid
            },
            "CoastGuardStation" => new CoastGuardStationViewModel
            {
                PID = pid
            },
            "SeparationZoneOrLine" => new SeparationZoneOrLineViewModel
            {
                PID = pid
            },
            "BottomFeature" => new BottomFeatureViewModel
            {
                PID = pid
            },
            "ArchipelagicBaseline" => new ArchipelagicBaselineViewModel
            {
                PID = pid
            },
            "SmallBottomObject" => new SmallBottomObjectViewModel
            {
                PID = pid
            },
            "ExclusiveEconomicZone" => new ExclusiveEconomicZoneViewModel
            {
                PID = pid
            },
            "RadarStation" => new RadarStationViewModel
            {
                PID = pid
            },
            "DivingLocation" => new DivingLocationViewModel
            {
                PID = pid
            },
            "RestrictedArea" => new RestrictedAreaViewModel
            {
                PID = pid
            },
            "CableSubmarine" => new CableSubmarineViewModel
            {
                PID = pid
            },
            "Wreck" => new WreckViewModel
            {
                PID = pid
            },
            "QRoute" => new QRouteViewModel
            {
                PID = pid
            },
            "CompletenessOfProductSpecification" => new CompletenessOfProductSpecificationViewModel
            {
                PID = pid
            },
            "RescueStation" => new RescueStationViewModel
            {
                PID = pid
            },
            "CardinalBeacon" => new CardinalBeaconViewModel
            {
                PID = pid
            },
            "LightVessel" => new LightVesselViewModel
            {
                PID = pid
            },
            "FisheryZone" => new FisheryZoneViewModel
            {
                PID = pid
            },
            "DredgedArea" => new DredgedAreaViewModel
            {
                PID = pid
            },
            "FerryRoute" => new FerryRouteViewModel
            {
                PID = pid
            },
            "ShorelineConstruction" => new ShorelineConstructionViewModel
            {
                PID = pid
            },
            "CautionArea" => new CautionAreaViewModel
            {
                PID = pid
            },
            "DeepWaterRoutePart" => new DeepWaterRoutePartViewModel
            {
                PID = pid
            },
            "CurrentNonGravitational" => new CurrentNonGravitationalViewModel
            {
                PID = pid
            },
            "DataCoverage" => new DataCoverageViewModel
            {
                PID = pid
            },
            "SeabedArea" => new SeabedAreaViewModel
            {
                PID = pid
            },
            "SpecialPurposeGeneralBuoy" => new SpecialPurposeGeneralBuoyViewModel
            {
                PID = pid
            },
            "LightSectored" => new LightSectoredViewModel
            {
                PID = pid
            },
            "IceLine" => new IceLineViewModel
            {
                PID = pid
            },
            "AnchorageArea" => new AnchorageAreaViewModel
            {
                PID = pid
            },
            "LateralBuoy" => new LateralBuoyViewModel
            {
                PID = pid
            },
            "TrafficSeparationSchemeRoundabout" => new TrafficSeparationSchemeRoundaboutViewModel
            {
                PID = pid
            },
            "DeepWaterRouteCentreline" => new DeepWaterRouteCentrelineViewModel
            {
                PID = pid
            },
            "LightFloat" => new LightFloatViewModel
            {
                PID = pid
            },
            "LightAllAround" => new LightAllAroundViewModel
            {
                PID = pid
            },
            "Coastline" => new CoastlineViewModel
            {
                PID = pid
            },
            "SeaAreaNamedWaterArea" => new SeaAreaNamedWaterAreaViewModel
            {
                PID = pid
            },
            "DropZone" => new DropZoneViewModel
            {
                PID = pid
            },
            "Conveyor" => new ConveyorViewModel
            {
                PID = pid
            },
            "LineOfDelimitation" => new LineOfDelimitationViewModel
            {
                PID = pid
            },
            "StraightTerritorialSeaBaseline" => new StraightTerritorialSeaBaselineViewModel
            {
                PID = pid
            },
            "SafeWaterBeacon" => new SafeWaterBeaconViewModel
            {
                PID = pid
            },
            "SpecialPurposeGeneralBeacon" => new SpecialPurposeGeneralBeaconViewModel
            {
                PID = pid
            },
            _ => throw new InvalidOperationException(),
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
        [DomainModel.EnumerationAttribute(nameof(nameUsageList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [Browsable(false)]
        public nameUsage[] nameUsageList => [(nameUsage)1, (nameUsage)2];

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
        [DomainModel.EnumerationAttribute(nameof(lastSensorList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [Browsable(false)]
        public lastSensor[] lastSensorList => [(lastSensor)501, (lastSensor)502, (lastSensor)503, (lastSensor)504, (lastSensor)506, (lastSensor)509];

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
        [DomainModel.EnumerationAttribute(nameof(firstSensorList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [Browsable(false)]
        public firstSensor[] firstSensorList => [(firstSensor)501, (firstSensor)502, (firstSensor)503, (firstSensor)504, (firstSensor)506, (firstSensor)509];

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
        [DomainModel.EnumerationAttribute(nameof(vesselsCharacteristicsList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(vesselsCharacteristicsUnitList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(comparisonOperatorList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("vesselMeasurementsSpecification")]
        public comparisonOperator? comparisonOperator {
            get {
                return _comparisonOperator;
            }

            set {
                SetValue(ref _comparisonOperator, value);
            }
        }

        [Browsable(false)]
        public vesselsCharacteristics[] vesselsCharacteristicsList => [(vesselsCharacteristics)1, (vesselsCharacteristics)2, (vesselsCharacteristics)3, (vesselsCharacteristics)4, (vesselsCharacteristics)6, (vesselsCharacteristics)10, (vesselsCharacteristics)11];

        [Browsable(false)]
        public vesselsCharacteristicsUnit[] vesselsCharacteristicsUnitList => [(vesselsCharacteristicsUnit)1, (vesselsCharacteristicsUnit)3, (vesselsCharacteristicsUnit)4, (vesselsCharacteristicsUnit)5, (vesselsCharacteristicsUnit)6, (vesselsCharacteristicsUnit)7];

        [Browsable(false)]
        public comparisonOperator[] comparisonOperatorList => [(comparisonOperator)1, (comparisonOperator)2, (comparisonOperator)3, (comparisonOperator)4, (comparisonOperator)5, (comparisonOperator)6];

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

        [DomainModel.EnumerationAttribute(nameof(natureOfSurfaceQualifyingTermsList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("surfaceCharacteristics")]
        public ObservableCollection<natureOfSurfaceQualifyingTerms> natureOfSurfaceQualifyingTerms { get; set; } = new();

        private natureOfSurface? _natureOfSurface = default;
        [DomainModel.EnumerationAttribute(nameof(natureOfSurfaceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("surfaceCharacteristics")]
        public natureOfSurface? natureOfSurface {
            get {
                return _natureOfSurface;
            }

            set {
                SetValue(ref _natureOfSurface, value);
            }
        }

        [Browsable(false)]
        public natureOfSurfaceQualifyingTerms[] natureOfSurfaceQualifyingTermsList => [(natureOfSurfaceQualifyingTerms)1, (natureOfSurfaceQualifyingTerms)2, (natureOfSurfaceQualifyingTerms)3, (natureOfSurfaceQualifyingTerms)4, (natureOfSurfaceQualifyingTerms)5, (natureOfSurfaceQualifyingTerms)6, (natureOfSurfaceQualifyingTerms)7, (natureOfSurfaceQualifyingTerms)8, (natureOfSurfaceQualifyingTerms)9, (natureOfSurfaceQualifyingTerms)10];

        [Browsable(false)]
        public natureOfSurface[] natureOfSurfaceList => [(natureOfSurface)1, (natureOfSurface)2, (natureOfSurface)3, (natureOfSurface)4, (natureOfSurface)5, (natureOfSurface)6, (natureOfSurface)7, (natureOfSurface)8, (natureOfSurface)9, (natureOfSurface)11, (natureOfSurface)14, (natureOfSurface)17, (natureOfSurface)18];

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
        [DomainModel.EnumerationAttribute(nameof(strengthOfMagneticAnomalyList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(magneticAnomalyDetectorSignatureList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("magneticInformation")]
        public magneticAnomalyDetectorSignature magneticAnomalyDetectorSignature {
            get {
                return _magneticAnomalyDetectorSignature;
            }

            set {
                SetValue(ref _magneticAnomalyDetectorSignature, value);
            }
        }

        [Browsable(false)]
        public strengthOfMagneticAnomaly[] strengthOfMagneticAnomalyList => [(strengthOfMagneticAnomaly)501, (strengthOfMagneticAnomaly)502, (strengthOfMagneticAnomaly)503, (strengthOfMagneticAnomaly)504];

        [Browsable(false)]
        public magneticAnomalyDetectorSignature[] magneticAnomalyDetectorSignatureList => [(magneticAnomalyDetectorSignature)501, (magneticAnomalyDetectorSignature)502, (magneticAnomalyDetectorSignature)503, (magneticAnomalyDetectorSignature)504];

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
        [DomainModel.EnumerationAttribute(nameof(speedUnitsList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [Browsable(false)]
        public speedUnits[] speedUnitsList => [(speedUnits)2, (speedUnits)3, (speedUnits)4];

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
        [DomainModel.EnumerationAttribute(nameof(signalStatusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [Browsable(false)]
        public signalStatus[] signalStatusList => [(signalStatus)1, (signalStatus)2];

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
        [DomainModel.EnumerationAttribute(nameof(topmarkDaymarkShapeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(colourPatternList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(colourList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [Browsable(false)]
        public topmarkDaymarkShape[] topmarkDaymarkShapeList => [(topmarkDaymarkShape)1, (topmarkDaymarkShape)2, (topmarkDaymarkShape)3, (topmarkDaymarkShape)4, (topmarkDaymarkShape)5, (topmarkDaymarkShape)6, (topmarkDaymarkShape)7, (topmarkDaymarkShape)8, (topmarkDaymarkShape)9, (topmarkDaymarkShape)10, (topmarkDaymarkShape)11, (topmarkDaymarkShape)12, (topmarkDaymarkShape)13, (topmarkDaymarkShape)14, (topmarkDaymarkShape)15, (topmarkDaymarkShape)16, (topmarkDaymarkShape)17, (topmarkDaymarkShape)18, (topmarkDaymarkShape)19, (topmarkDaymarkShape)20, (topmarkDaymarkShape)21, (topmarkDaymarkShape)22, (topmarkDaymarkShape)23, (topmarkDaymarkShape)24, (topmarkDaymarkShape)25, (topmarkDaymarkShape)26, (topmarkDaymarkShape)27, (topmarkDaymarkShape)28, (topmarkDaymarkShape)29, (topmarkDaymarkShape)30, (topmarkDaymarkShape)31, (topmarkDaymarkShape)32, (topmarkDaymarkShape)33];

        [Browsable(false)]
        public colourPattern[] colourPatternList => [(colourPattern)1, (colourPattern)2, (colourPattern)3, (colourPattern)4, (colourPattern)5, (colourPattern)6];

        [Browsable(false)]
        public colour[] colourList => [(colour)1, (colour)2, (colour)3, (colour)4, (colour)5, (colour)6, (colour)7, (colour)8, (colour)9, (colour)10, (colour)11, (colour)12, (colour)13];

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
        [DomainModel.EnumerationAttribute(nameof(lightCharacteristicList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("rythmOfLight")]
        public lightCharacteristic lightCharacteristic {
            get {
                return _lightCharacteristic;
            }

            set {
                SetValue(ref _lightCharacteristic, value);
            }
        }

        [Browsable(false)]
        public lightCharacteristic[] lightCharacteristicList => [(lightCharacteristic)1, (lightCharacteristic)2, (lightCharacteristic)3, (lightCharacteristic)4, (lightCharacteristic)5, (lightCharacteristic)6, (lightCharacteristic)7, (lightCharacteristic)8, (lightCharacteristic)11, (lightCharacteristic)12, (lightCharacteristic)13, (lightCharacteristic)14, (lightCharacteristic)15, (lightCharacteristic)16, (lightCharacteristic)17, (lightCharacteristic)18, (lightCharacteristic)19, (lightCharacteristic)25, (lightCharacteristic)26, (lightCharacteristic)27, (lightCharacteristic)28, (lightCharacteristic)29];

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

        [DomainModel.EnumerationAttribute(nameof(lightVisibilityList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(colourList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("lightSector")]
        public ObservableCollection<colour> colour { get; set; } = new();

        [Browsable(false)]
        public lightVisibility[] lightVisibilityList => [(lightVisibility)1, (lightVisibility)2, (lightVisibility)3, (lightVisibility)4, (lightVisibility)5, (lightVisibility)6, (lightVisibility)8, (lightVisibility)9];

        [Browsable(false)]
        public colour[] colourList => [(colour)1, (colour)3, (colour)4, (colour)5, (colour)6, (colour)9, (colour)10, (colour)11];

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
        [DomainModel.EnumerationAttribute(nameof(lightCharacteristicList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [Browsable(false)]
        public lightCharacteristic[] lightCharacteristicList => [(lightCharacteristic)1, (lightCharacteristic)2, (lightCharacteristic)3, (lightCharacteristic)4, (lightCharacteristic)5, (lightCharacteristic)6, (lightCharacteristic)7, (lightCharacteristic)8, (lightCharacteristic)11, (lightCharacteristic)12, (lightCharacteristic)13, (lightCharacteristic)14, (lightCharacteristic)15, (lightCharacteristic)16, (lightCharacteristic)17, (lightCharacteristic)18, (lightCharacteristic)19, (lightCharacteristic)25, (lightCharacteristic)26, (lightCharacteristic)27, (lightCharacteristic)28, (lightCharacteristic)29];

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
    public partial class ReferenceToAPublicationViewModel : InformationViewModel<ReferenceToAPublication> {
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
        public override informationBindingDefinition[] informationBindingDefinitions => ReferenceToAPublication._informationBindingDefinitions;

        public override InformationViewModel<ReferenceToAPublication> Load(DomainModel.S501.InformationTypes.ReferenceToAPublication instance) {
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
            return this;
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
    public partial class InstallationBuoyViewModel : FeatureViewModel<InstallationBuoy> {
        [Category("InstallationBuoy")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private colourPattern? _colourPattern = default;
        [DomainModel.EnumerationAttribute(nameof(colourPatternList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("InstallationBuoy")]
        public colourPattern? colourPattern {
            get {
                return _colourPattern;
            }

            set {
                SetValue(ref _colourPattern, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(productList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("InstallationBuoy")]
        public ObservableCollection<status> status { get; set; } = new();

        private visualProminence? _visualProminence = default;
        [DomainModel.EnumerationAttribute(nameof(visualProminenceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(colourList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(buoyShapeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(natureOfConstructionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(categoryOfInstallationBuoyList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("InstallationBuoy")]
        public categoryOfInstallationBuoy? categoryOfInstallationBuoy {
            get {
                return _categoryOfInstallationBuoy;
            }

            set {
                SetValue(ref _categoryOfInstallationBuoy, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => InstallationBuoy._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => InstallationBuoy._featureBindingDefinitions;

        [Browsable(false)]
        public colourPattern[] colourPatternList => [(colourPattern)1, (colourPattern)2, (colourPattern)3, (colourPattern)4, (colourPattern)5, (colourPattern)6];

        [Browsable(false)]
        public product[] productList => [(product)1, (product)2, (product)18, (product)19];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)4, (status)5, (status)7, (status)8, (status)18];

        [Browsable(false)]
        public visualProminence[] visualProminenceList => [(visualProminence)1, (visualProminence)2, (visualProminence)3];

        [Browsable(false)]
        public colour[] colourList => [(colour)1, (colour)2, (colour)3, (colour)4, (colour)5, (colour)6, (colour)7, (colour)8, (colour)9, (colour)10, (colour)11, (colour)12, (colour)13];

        [Browsable(false)]
        public buoyShape[] buoyShapeList => [(buoyShape)1, (buoyShape)2, (buoyShape)3, (buoyShape)4, (buoyShape)5, (buoyShape)6, (buoyShape)7, (buoyShape)8];

        [Browsable(false)]
        public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)7, (natureOfConstruction)11];

        [Browsable(false)]
        public categoryOfInstallationBuoy[] categoryOfInstallationBuoyList => [(categoryOfInstallationBuoy)1, (categoryOfInstallationBuoy)2];

        public override FeatureViewModel<InstallationBuoy> Load(DomainModel.S501.FeatureTypes.InstallationBuoy instance) {
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
            return this;
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
    public partial class DepthAreaViewModel : FeatureViewModel<DepthArea> {
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

        public override informationBindingDefinition[] informationBindingDefinitions => DepthArea._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => DepthArea._featureBindingDefinitions;

        public override FeatureViewModel<DepthArea> Load(DomainModel.S501.FeatureTypes.DepthArea instance) {
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

            return this;
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
    public partial class RadioCallingInPointViewModel : FeatureViewModel<RadioCallingInPoint> {
        private categoryOfReportingRadioCallingInPoint? _categoryOfReportingRadioCallingInPoint = default;
        [DomainModel.EnumerationAttribute(nameof(categoryOfReportingRadioCallingInPointList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(trafficFlowList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("RadioCallingInPoint")]
        public trafficFlow trafficFlow {
            get {
                return _trafficFlow;
            }

            set {
                SetValue(ref _trafficFlow, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => RadioCallingInPoint._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => RadioCallingInPoint._featureBindingDefinitions;

        [Browsable(false)]
        public categoryOfReportingRadioCallingInPoint[] categoryOfReportingRadioCallingInPointList => [(categoryOfReportingRadioCallingInPoint)501];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)3, (status)4, (status)5, (status)6, (status)7, (status)9, (status)501];

        [Browsable(false)]
        public trafficFlow[] trafficFlowList => [(trafficFlow)1, (trafficFlow)2, (trafficFlow)3, (trafficFlow)4];

        public override FeatureViewModel<RadioCallingInPoint> Load(DomainModel.S501.FeatureTypes.RadioCallingInPoint instance) {
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
            return this;
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
    public partial class PatrolAreaViewModel : FeatureViewModel<PatrolArea> {
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
        [DomainModel.EnumerationAttribute(nameof(categoryOfPatrolAreaList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("PatrolArea")]
        public ObservableCollection<status> status { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => PatrolArea._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => PatrolArea._featureBindingDefinitions;

        [Browsable(false)]
        public categoryOfPatrolArea[] categoryOfPatrolAreaList => [(categoryOfPatrolArea)501, (categoryOfPatrolArea)502];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)501];

        public override FeatureViewModel<PatrolArea> Load(DomainModel.S501.FeatureTypes.PatrolArea instance) {
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
            return this;
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
    public partial class CheckpointViewModel : FeatureViewModel<Checkpoint> {
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(categoryOfCheckpointList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("Checkpoint")]
        public categoryOfCheckpoint? categoryOfCheckpoint {
            get {
                return _categoryOfCheckpoint;
            }

            set {
                SetValue(ref _categoryOfCheckpoint, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => Checkpoint._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => Checkpoint._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)5, (status)7, (status)9, (status)12];

        [Browsable(false)]
        public categoryOfCheckpoint[] categoryOfCheckpointList => [(categoryOfCheckpoint)1, (categoryOfCheckpoint)501];

        public override FeatureViewModel<Checkpoint> Load(DomainModel.S501.FeatureTypes.Checkpoint instance) {
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
            return this;
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
    public partial class MarineManagementAreaViewModel : FeatureViewModel<MarineManagementArea> {
        private restriction? _restriction = default;
        [DomainModel.EnumerationAttribute(nameof(restrictionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(speciesGroupingList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("MarineManagementArea")]
        public ObservableCollection<speciesGrouping> speciesGrouping { get; set; } = new();

        [Category("MarineManagementArea")]
        public ObservableCollection<String> nationalMaritimeAuthority { get; set; } = new();

        private jurisdiction _jurisdiction;
        [DomainModel.EnumerationAttribute(nameof(jurisdictionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(categoryofMarineProtectedAreaList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("MarineManagementArea")]
        public status? status {
            get {
                return _status;
            }

            set {
                SetValue(ref _status, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(categoryofRestrictionsList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("MarineManagementArea")]
        public ObservableCollection<categoryofRestrictions> categoryofRestrictions { get; set; } = new();

        [Category("MarineManagementArea")]
        public ObservableCollection<String> species { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => MarineManagementArea._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => MarineManagementArea._featureBindingDefinitions;

        [Browsable(false)]
        public restriction[] restrictionList => [(restriction)1, (restriction)2, (restriction)3, (restriction)4, (restriction)5, (restriction)6, (restriction)7, (restriction)8, (restriction)9, (restriction)10, (restriction)11, (restriction)12, (restriction)13, (restriction)14, (restriction)15, (restriction)16, (restriction)17, (restriction)18, (restriction)19, (restriction)20, (restriction)21, (restriction)22, (restriction)23, (restriction)24, (restriction)25, (restriction)26, (restriction)27];

        [Browsable(false)]
        public speciesGrouping[] speciesGroupingList => [(speciesGrouping)501, (speciesGrouping)502, (speciesGrouping)503, (speciesGrouping)504, (speciesGrouping)505, (speciesGrouping)506, (speciesGrouping)507, (speciesGrouping)508, (speciesGrouping)509, (speciesGrouping)510];

        [Browsable(false)]
        public jurisdiction[] jurisdictionList => [(jurisdiction)1, (jurisdiction)2, (jurisdiction)2];

        [Browsable(false)]
        public categoryofMarineProtectedArea[] categoryofMarineProtectedAreaList => [(categoryofMarineProtectedArea)1, (categoryofMarineProtectedArea)2, (categoryofMarineProtectedArea)3, (categoryofMarineProtectedArea)4, (categoryofMarineProtectedArea)5, (categoryofMarineProtectedArea)6, (categoryofMarineProtectedArea)7];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)3, (status)4, (status)5, (status)6, (status)7, (status)8, (status)9, (status)13, (status)14, (status)16, (status)17, (status)519];

        [Browsable(false)]
        public categoryofRestrictions[] categoryofRestrictionsList => [(categoryofRestrictions)4, (categoryofRestrictions)5, (categoryofRestrictions)6, (categoryofRestrictions)7, (categoryofRestrictions)10, (categoryofRestrictions)20, (categoryofRestrictions)22, (categoryofRestrictions)23, (categoryofRestrictions)27, (categoryofRestrictions)28, (categoryofRestrictions)31, (categoryofRestrictions)32];

        public override FeatureViewModel<MarineManagementArea> Load(DomainModel.S501.FeatureTypes.MarineManagementArea instance) {
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
            return this;
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
    public partial class DepthContourViewModel : FeatureViewModel<DepthContour> {
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

        public override informationBindingDefinition[] informationBindingDefinitions => DepthContour._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => DepthContour._featureBindingDefinitions;

        public override FeatureViewModel<DepthContour> Load(DomainModel.S501.FeatureTypes.DepthContour instance) {
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
            return this;
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
    public partial class EnvironmentallySensitiveSeaAreaViewModel : FeatureViewModel<EnvironmentallySensitiveSeaArea> {
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
        public override informationBindingDefinition[] informationBindingDefinitions => EnvironmentallySensitiveSeaArea._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => EnvironmentallySensitiveSeaArea._featureBindingDefinitions;

        public override FeatureViewModel<EnvironmentallySensitiveSeaArea> Load(DomainModel.S501.FeatureTypes.EnvironmentallySensitiveSeaArea instance) {
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            controllingAuthority = instance.controllingAuthority;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            return this;
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
    public partial class RoadViewModel : FeatureViewModel<Road> {
        [DomainModel.EnumerationAttribute(nameof(natureOfConstructionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(categoryOfRoadList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(conditionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => Road._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => Road._featureBindingDefinitions;

        [Browsable(false)]
        public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)4, (natureOfConstruction)5];

        [Browsable(false)]
        public categoryOfRoad[] categoryOfRoadList => [(categoryOfRoad)1, (categoryOfRoad)2, (categoryOfRoad)3, (categoryOfRoad)4, (categoryOfRoad)5, (categoryOfRoad)6];

        [Browsable(false)]
        public condition[] conditionList => [(condition)1, (condition)2, (condition)5, (condition)501];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)4, (status)6, (status)7, (status)8, (status)12, (status)13, (status)14];

        public override FeatureViewModel<Road> Load(DomainModel.S501.FeatureTypes.Road instance) {
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
            return this;
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
    public partial class RiverViewModel : FeatureViewModel<River> {
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        public override informationBindingDefinition[] informationBindingDefinitions => River._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => River._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)5];

        public override FeatureViewModel<River> Load(DomainModel.S501.FeatureTypes.River instance) {
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
            return this;
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
    public partial class MilitaryPracticeAreaViewModel : FeatureViewModel<MilitaryPracticeArea> {
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
        [DomainModel.EnumerationAttribute(nameof(depthUnitsList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(restrictionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(typeofMilitaryActivityList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(categoryofMilitaryPracticeAreaList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(areaCategoryList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(verticalDatumList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => MilitaryPracticeArea._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => MilitaryPracticeArea._featureBindingDefinitions;

        [Browsable(false)]
        public depthUnits[] depthUnitsList => [(depthUnits)1];

        [Browsable(false)]
        public restriction[] restrictionList => [(restriction)1, (restriction)2, (restriction)3, (restriction)4, (restriction)5, (restriction)6, (restriction)7, (restriction)8, (restriction)9, (restriction)10, (restriction)11, (restriction)12, (restriction)13, (restriction)15, (restriction)16, (restriction)17, (restriction)18, (restriction)19, (restriction)20, (restriction)21, (restriction)22, (restriction)23, (restriction)24, (restriction)25, (restriction)26, (restriction)27, (restriction)39];

        [Browsable(false)]
        public typeofMilitaryActivity[] typeofMilitaryActivityList => [(typeofMilitaryActivity)501, (typeofMilitaryActivity)502, (typeofMilitaryActivity)503, (typeofMilitaryActivity)504, (typeofMilitaryActivity)505, (typeofMilitaryActivity)506, (typeofMilitaryActivity)507, (typeofMilitaryActivity)508, (typeofMilitaryActivity)509, (typeofMilitaryActivity)510, (typeofMilitaryActivity)511, (typeofMilitaryActivity)512, (typeofMilitaryActivity)513, (typeofMilitaryActivity)514, (typeofMilitaryActivity)515, (typeofMilitaryActivity)516, (typeofMilitaryActivity)517, (typeofMilitaryActivity)518, (typeofMilitaryActivity)519, (typeofMilitaryActivity)520, (typeofMilitaryActivity)521, (typeofMilitaryActivity)522, (typeofMilitaryActivity)523, (typeofMilitaryActivity)524, (typeofMilitaryActivity)525, (typeofMilitaryActivity)526, (typeofMilitaryActivity)527, (typeofMilitaryActivity)528, (typeofMilitaryActivity)529, (typeofMilitaryActivity)530, (typeofMilitaryActivity)531, (typeofMilitaryActivity)532, (typeofMilitaryActivity)533, (typeofMilitaryActivity)534, (typeofMilitaryActivity)535, (typeofMilitaryActivity)536, (typeofMilitaryActivity)537, (typeofMilitaryActivity)538, (typeofMilitaryActivity)539, (typeofMilitaryActivity)540, (typeofMilitaryActivity)541, (typeofMilitaryActivity)542, (typeofMilitaryActivity)543, (typeofMilitaryActivity)544, (typeofMilitaryActivity)545, (typeofMilitaryActivity)546, (typeofMilitaryActivity)547, (typeofMilitaryActivity)598, (typeofMilitaryActivity)599];

        [Browsable(false)]
        public categoryofMilitaryPracticeArea[] categoryofMilitaryPracticeAreaList => [(categoryofMilitaryPracticeArea)2, (categoryofMilitaryPracticeArea)3, (categoryofMilitaryPracticeArea)4, (categoryofMilitaryPracticeArea)5, (categoryofMilitaryPracticeArea)501, (categoryofMilitaryPracticeArea)502, (categoryofMilitaryPracticeArea)503, (categoryofMilitaryPracticeArea)506, (categoryofMilitaryPracticeArea)507, (categoryofMilitaryPracticeArea)508, (categoryofMilitaryPracticeArea)510, (categoryofMilitaryPracticeArea)599];

        [Browsable(false)]
        public areaCategory[] areaCategoryList => [(areaCategory)501, (areaCategory)502];

        [Browsable(false)]
        public verticalDatum[] verticalDatumList => [(verticalDatum)3, (verticalDatum)16, (verticalDatum)17, (verticalDatum)18, (verticalDatum)19, (verticalDatum)20, (verticalDatum)21, (verticalDatum)24, (verticalDatum)25, (verticalDatum)26, (verticalDatum)28, (verticalDatum)29, (verticalDatum)30, (verticalDatum)44, (verticalDatum)501];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)5, (status)6, (status)7, (status)16, (status)17, (status)501, (status)503, (status)517, (status)520];

        public override FeatureViewModel<MilitaryPracticeArea> Load(DomainModel.S501.FeatureTypes.MilitaryPracticeArea instance) {
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
            return this;
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
    public partial class DiscolouredWaterViewModel : FeatureViewModel<DiscolouredWater> {
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

        public override informationBindingDefinition[] informationBindingDefinitions => DiscolouredWater._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => DiscolouredWater._featureBindingDefinitions;

        public override FeatureViewModel<DiscolouredWater> Load(DomainModel.S501.FeatureTypes.DiscolouredWater instance) {
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            scaleMinimum = instance.scaleMinimum;
            reportedDate = instance.reportedDate;
            return this;
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
    public partial class CardinalBuoyViewModel : FeatureViewModel<CardinalBuoy> {
        private categoryOfCardinalMark _categoryOfCardinalMark;
        [DomainModel.EnumerationAttribute(nameof(categoryOfCardinalMarkList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(natureOfConstructionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("CardinalBuoy")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        private buoyShape _buoyShape;
        [DomainModel.EnumerationAttribute(nameof(buoyShapeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("CardinalBuoy")]
        public marksNavigationalSystemOf? marksNavigationalSystemOf {
            get {
                return _marksNavigationalSystemOf;
            }

            set {
                SetValue(ref _marksNavigationalSystemOf, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(colourList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("CardinalBuoy")]
        public ObservableCollection<colour> colour { get; set; } = new();

        private colourPattern? _colourPattern = default;
        [DomainModel.EnumerationAttribute(nameof(colourPatternList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => CardinalBuoy._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => CardinalBuoy._featureBindingDefinitions;

        [Browsable(false)]
        public categoryOfCardinalMark[] categoryOfCardinalMarkList => [(categoryOfCardinalMark)1, (categoryOfCardinalMark)2, (categoryOfCardinalMark)3, (categoryOfCardinalMark)4];

        [Browsable(false)]
        public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)6, (natureOfConstruction)7, (natureOfConstruction)8, (natureOfConstruction)11];

        [Browsable(false)]
        public buoyShape[] buoyShapeList => [(buoyShape)1, (buoyShape)2, (buoyShape)3, (buoyShape)4, (buoyShape)5, (buoyShape)6, (buoyShape)7, (buoyShape)8];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)5, (status)7, (status)8, (status)18];

        [Browsable(false)]
        public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1, (marksNavigationalSystemOf)2, (marksNavigationalSystemOf)9, (marksNavigationalSystemOf)11];

        [Browsable(false)]
        public colour[] colourList => [(colour)1, (colour)2, (colour)3, (colour)4, (colour)5, (colour)6, (colour)7, (colour)8, (colour)9, (colour)10, (colour)11, (colour)12, (colour)13];

        [Browsable(false)]
        public colourPattern[] colourPatternList => [(colourPattern)1, (colourPattern)2, (colourPattern)3, (colourPattern)4, (colourPattern)5, (colourPattern)6];

        public override FeatureViewModel<CardinalBuoy> Load(DomainModel.S501.FeatureTypes.CardinalBuoy instance) {
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
            return this;
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
    public partial class SafeWaterBuoyViewModel : FeatureViewModel<SafeWaterBuoy> {
        private buoyShape _buoyShape;
        [DomainModel.EnumerationAttribute(nameof(buoyShapeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("SafeWaterBuoy")]
        public buoyShape buoyShape {
            get {
                return _buoyShape;
            }

            set {
                SetValue(ref _buoyShape, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(colourList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("SafeWaterBuoy")]
        public ObservableCollection<status> status { get; set; } = new();

        private marksNavigationalSystemOf? _marksNavigationalSystemOf = default;
        [DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(natureOfConstructionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(colourPatternList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        public override informationBindingDefinition[] informationBindingDefinitions => SafeWaterBuoy._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => SafeWaterBuoy._featureBindingDefinitions;

        [Browsable(false)]
        public buoyShape[] buoyShapeList => [(buoyShape)1, (buoyShape)2, (buoyShape)3, (buoyShape)4, (buoyShape)5, (buoyShape)6, (buoyShape)7, (buoyShape)8];

        [Browsable(false)]
        public colour[] colourList => [(colour)1, (colour)2, (colour)3, (colour)4, (colour)5, (colour)6, (colour)7, (colour)8, (colour)9, (colour)10, (colour)11, (colour)12, (colour)13];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)5, (status)7, (status)8, (status)18];

        [Browsable(false)]
        public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1, (marksNavigationalSystemOf)2, (marksNavigationalSystemOf)9, (marksNavigationalSystemOf)11];

        [Browsable(false)]
        public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)6, (natureOfConstruction)7, (natureOfConstruction)8, (natureOfConstruction)11];

        [Browsable(false)]
        public colourPattern[] colourPatternList => [(colourPattern)1, (colourPattern)2, (colourPattern)3, (colourPattern)4, (colourPattern)5, (colourPattern)6];

        public override FeatureViewModel<SafeWaterBuoy> Load(DomainModel.S501.FeatureTypes.SafeWaterBuoy instance) {
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
            return this;
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
    public partial class RadioStationViewModel : FeatureViewModel<RadioStation> {
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("RadioStation")]
        public ObservableCollection<status> status { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(categoryOfRadioStationList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => RadioStation._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => RadioStation._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)4, (status)5, (status)7, (status)8];

        [Browsable(false)]
        public categoryOfRadioStation[] categoryOfRadioStationList => [(categoryOfRadioStation)5, (categoryOfRadioStation)10, (categoryOfRadioStation)11, (categoryOfRadioStation)14, (categoryOfRadioStation)19, (categoryOfRadioStation)20];

        public override FeatureViewModel<RadioStation> Load(DomainModel.S501.FeatureTypes.RadioStation instance) {
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
            return this;
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
    public partial class MilitaryExerciseAirspaceViewModel : FeatureViewModel<MilitaryExerciseAirspace> {
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

        public override informationBindingDefinition[] informationBindingDefinitions => MilitaryExerciseAirspace._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => MilitaryExerciseAirspace._featureBindingDefinitions;

        public override FeatureViewModel<MilitaryExerciseAirspace> Load(DomainModel.S501.FeatureTypes.MilitaryExerciseAirspace instance) {
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

            return this;
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
    public partial class ContiguousZoneViewModel : FeatureViewModel<ContiguousZone> {
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        public override informationBindingDefinition[] informationBindingDefinitions => ContiguousZone._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => ContiguousZone._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)502, (status)504, (status)520];

        public override FeatureViewModel<ContiguousZone> Load(DomainModel.S501.FeatureTypes.ContiguousZone instance) {
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
            return this;
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
    public partial class NormalBaselineViewModel : FeatureViewModel<NormalBaseline> {
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
        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => NormalBaseline._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => NormalBaseline._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)502, (status)504];

        public override FeatureViewModel<NormalBaseline> Load(DomainModel.S501.FeatureTypes.NormalBaseline instance) {
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

            return this;
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
    public partial class CableAreaViewModel : FeatureViewModel<CableArea> {
        [Category("CableArea")]
        public ObservableCollection<information> information { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(restrictionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(categoryOfCableList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("CableArea")]
        public ObservableCollection<categoryOfCable> categoryOfCable { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => CableArea._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => CableArea._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)7, (status)13];

        [Browsable(false)]
        public restriction[] restrictionList => [(restriction)1, (restriction)2, (restriction)3, (restriction)4, (restriction)5, (restriction)6, (restriction)7, (restriction)8, (restriction)9, (restriction)11, (restriction)12, (restriction)13, (restriction)14, (restriction)16, (restriction)17, (restriction)18, (restriction)20, (restriction)23, (restriction)24, (restriction)25, (restriction)27, (restriction)39];

        [Browsable(false)]
        public categoryOfCable[] categoryOfCableList => [(categoryOfCable)1, (categoryOfCable)7, (categoryOfCable)10];

        public override FeatureViewModel<CableArea> Load(DomainModel.S501.FeatureTypes.CableArea instance) {
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
            return this;
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
    public partial class ContinentalShelfAreaViewModel : FeatureViewModel<ContinentalShelfArea> {
        private status? _status = default;
        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => ContinentalShelfArea._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => ContinentalShelfArea._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)502, (status)504, (status)520];

        public override FeatureViewModel<ContinentalShelfArea> Load(DomainModel.S501.FeatureTypes.ContinentalShelfArea instance) {
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
            return this;
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
    public partial class InternalWatersViewModel : FeatureViewModel<InternalWaters> {
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
        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("InternalWaters")]
        public status? status {
            get {
                return _status;
            }

            set {
                SetValue(ref _status, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => InternalWaters._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => InternalWaters._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)502, (status)504, (status)520];

        public override FeatureViewModel<InternalWaters> Load(DomainModel.S501.FeatureTypes.InternalWaters instance) {
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
            return this;
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
    public partial class AdministrationAreaViewModel : FeatureViewModel<AdministrationArea> {
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
        [DomainModel.EnumerationAttribute(nameof(jurisdictionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        public override informationBindingDefinition[] informationBindingDefinitions => AdministrationArea._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => AdministrationArea._featureBindingDefinitions;

        [Browsable(false)]
        public jurisdiction[] jurisdictionList => [(jurisdiction)1, (jurisdiction)2, (jurisdiction)3];

        public override FeatureViewModel<AdministrationArea> Load(DomainModel.S501.FeatureTypes.AdministrationArea instance) {
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
            return this;
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
    public partial class BollardViewModel : FeatureViewModel<Bollard> {
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
        [DomainModel.EnumerationAttribute(nameof(conditionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("Bollard")]
        public condition? condition {
            get {
                return _condition;
            }

            set {
                SetValue(ref _condition, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("Bollard")]
        public ObservableCollection<status> status { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => Bollard._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => Bollard._featureBindingDefinitions;

        [Browsable(false)]
        public condition[] conditionList => [(condition)1, (condition)2, (condition)5];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)3, (status)4, (status)6, (status)7, (status)8, (status)12, (status)14, (status)18];

        public override FeatureViewModel<Bollard> Load(DomainModel.S501.FeatureTypes.Bollard instance) {
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
            return this;
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
    public partial class DolphinViewModel : FeatureViewModel<Dolphin> {
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
        [DomainModel.EnumerationAttribute(nameof(colourPatternList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(categoryOfDolphinList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(visualProminenceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("Dolphin")]
        public visualProminence? visualProminence {
            get {
                return _visualProminence;
            }

            set {
                SetValue(ref _visualProminence, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(colourList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(conditionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(natureOfConstructionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("Dolphin")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => Dolphin._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => Dolphin._featureBindingDefinitions;

        [Browsable(false)]
        public colourPattern[] colourPatternList => [(colourPattern)1, (colourPattern)2, (colourPattern)3, (colourPattern)4, (colourPattern)5, (colourPattern)6];

        [Browsable(false)]
        public categoryOfDolphin[] categoryOfDolphinList => [(categoryOfDolphin)1, (categoryOfDolphin)2, (categoryOfDolphin)3, (categoryOfDolphin)4];

        [Browsable(false)]
        public visualProminence[] visualProminenceList => [(visualProminence)1, (visualProminence)2, (visualProminence)3];

        [Browsable(false)]
        public colour[] colourList => [(colour)1, (colour)2, (colour)3, (colour)4, (colour)5, (colour)6, (colour)7, (colour)8, (colour)9, (colour)10, (colour)11, (colour)12, (colour)13];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)3, (status)4, (status)5, (status)6, (status)7, (status)8, (status)12, (status)14, (status)18];

        [Browsable(false)]
        public condition[] conditionList => [(condition)1, (condition)2, (condition)5];

        [Browsable(false)]
        public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1, (natureOfConstruction)2, (natureOfConstruction)6, (natureOfConstruction)7];

        public override FeatureViewModel<Dolphin> Load(DomainModel.S501.FeatureTypes.Dolphin instance) {
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
            return this;
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
    public partial class RadarRangeViewModel : FeatureViewModel<RadarRange> {
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("RadarRange")]
        public ObservableCollection<status> status { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => RadarRange._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => RadarRange._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)4, (status)7];

        public override FeatureViewModel<RadarRange> Load(DomainModel.S501.FeatureTypes.RadarRange instance) {
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
            return this;
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
    public partial class IsolatedDangerBeaconViewModel : FeatureViewModel<IsolatedDangerBeacon> {
        private condition? _condition = default;
        [DomainModel.EnumerationAttribute(nameof(conditionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(beaconShapeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(natureOfConstructionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("IsolatedDangerBeacon")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(visualProminenceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(colourList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(colourPatternList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("IsolatedDangerBeacon")]
        public colourPattern? colourPattern {
            get {
                return _colourPattern;
            }

            set {
                SetValue(ref _colourPattern, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => IsolatedDangerBeacon._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => IsolatedDangerBeacon._featureBindingDefinitions;

        [Browsable(false)]
        public condition[] conditionList => [(condition)1, (condition)2, (condition)3, (condition)5];

        [Browsable(false)]
        public beaconShape[] beaconShapeList => [(beaconShape)1, (beaconShape)2, (beaconShape)3, (beaconShape)4, (beaconShape)5, (beaconShape)6, (beaconShape)7];

        [Browsable(false)]
        public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1, (natureOfConstruction)2, (natureOfConstruction)6, (natureOfConstruction)7, (natureOfConstruction)8];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)4, (status)5, (status)7, (status)8, (status)12, (status)18];

        [Browsable(false)]
        public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1, (marksNavigationalSystemOf)2, (marksNavigationalSystemOf)9, (marksNavigationalSystemOf)11];

        [Browsable(false)]
        public visualProminence[] visualProminenceList => [(visualProminence)1, (visualProminence)2, (visualProminence)3];

        [Browsable(false)]
        public colour[] colourList => [(colour)1, (colour)2, (colour)3, (colour)4, (colour)5, (colour)6, (colour)7, (colour)8, (colour)9, (colour)10, (colour)11, (colour)12, (colour)13];

        [Browsable(false)]
        public colourPattern[] colourPatternList => [(colourPattern)1, (colourPattern)2, (colourPattern)3, (colourPattern)4, (colourPattern)5, (colourPattern)6];

        public override FeatureViewModel<IsolatedDangerBeacon> Load(DomainModel.S501.FeatureTypes.IsolatedDangerBeacon instance) {
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
            return this;
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
    public partial class IsolatedDangerBuoyViewModel : FeatureViewModel<IsolatedDangerBuoy> {
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

        [DomainModel.EnumerationAttribute(nameof(colourList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(buoyShapeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(colourPatternList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(natureOfConstructionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("IsolatedDangerBuoy")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("IsolatedDangerBuoy")]
        public ObservableCollection<status> status { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => IsolatedDangerBuoy._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => IsolatedDangerBuoy._featureBindingDefinitions;

        [Browsable(false)]
        public colour[] colourList => [(colour)1, (colour)2, (colour)3, (colour)4, (colour)5, (colour)6, (colour)7, (colour)8, (colour)9, (colour)10, (colour)11, (colour)12, (colour)13];

        [Browsable(false)]
        public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1, (marksNavigationalSystemOf)2, (marksNavigationalSystemOf)9, (marksNavigationalSystemOf)11];

        [Browsable(false)]
        public buoyShape[] buoyShapeList => [(buoyShape)1, (buoyShape)2, (buoyShape)3, (buoyShape)4, (buoyShape)5, (buoyShape)6, (buoyShape)7, (buoyShape)8];

        [Browsable(false)]
        public colourPattern[] colourPatternList => [(colourPattern)1, (colourPattern)2, (colourPattern)3, (colourPattern)4, (colourPattern)5, (colourPattern)6];

        [Browsable(false)]
        public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)6, (natureOfConstruction)7, (natureOfConstruction)8, (natureOfConstruction)11];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)5, (status)7, (status)8, (status)18];

        public override FeatureViewModel<IsolatedDangerBuoy> Load(DomainModel.S501.FeatureTypes.IsolatedDangerBuoy instance) {
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
            return this;
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
    public partial class SubmarineTransitLaneViewModel : FeatureViewModel<SubmarineTransitLane> {
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

        [DomainModel.EnumerationAttribute(nameof(restrictionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => SubmarineTransitLane._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => SubmarineTransitLane._featureBindingDefinitions;

        [Browsable(false)]
        public restriction[] restrictionList => [(restriction)1, (restriction)2, (restriction)3, (restriction)4, (restriction)5, (restriction)6, (restriction)7, (restriction)8, (restriction)9, (restriction)10, (restriction)11, (restriction)12, (restriction)13, (restriction)16, (restriction)17, (restriction)18, (restriction)19, (restriction)20, (restriction)21, (restriction)22, (restriction)23, (restriction)24, (restriction)25, (restriction)27];

        public override FeatureViewModel<SubmarineTransitLane> Load(DomainModel.S501.FeatureTypes.SubmarineTransitLane instance) {
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
            return this;
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
    public partial class MaritimeSafetyInformationAreaViewModel : FeatureViewModel<MaritimeSafetyInformationArea> {
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
        public override informationBindingDefinition[] informationBindingDefinitions => MaritimeSafetyInformationArea._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => MaritimeSafetyInformationArea._featureBindingDefinitions;

        public override FeatureViewModel<MaritimeSafetyInformationArea> Load(DomainModel.S501.FeatureTypes.MaritimeSafetyInformationArea instance) {
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
            return this;
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
    public partial class AirspaceRestrictionViewModel : FeatureViewModel<AirspaceRestriction> {
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
        [DomainModel.EnumerationAttribute(nameof(verticalDatumList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(heightLengthUnitsList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(catagoryOfAirspaceRestrictionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("AirspaceRestriction")]
        public catagoryOfAirspaceRestriction? catagoryOfAirspaceRestriction {
            get {
                return _catagoryOfAirspaceRestriction;
            }

            set {
                SetValue(ref _catagoryOfAirspaceRestriction, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => AirspaceRestriction._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => AirspaceRestriction._featureBindingDefinitions;

        [Browsable(false)]
        public verticalDatum[] verticalDatumList => [(verticalDatum)3, (verticalDatum)16, (verticalDatum)17, (verticalDatum)18, (verticalDatum)19, (verticalDatum)20, (verticalDatum)21, (verticalDatum)24, (verticalDatum)25, (verticalDatum)26, (verticalDatum)28, (verticalDatum)29, (verticalDatum)30, (verticalDatum)44];

        [Browsable(false)]
        public heightLengthUnits[] heightLengthUnitsList => [(heightLengthUnits)2];

        [Browsable(false)]
        public catagoryOfAirspaceRestriction[] catagoryOfAirspaceRestrictionList => [(catagoryOfAirspaceRestriction)501, (catagoryOfAirspaceRestriction)502, (catagoryOfAirspaceRestriction)503];

        public override FeatureViewModel<AirspaceRestriction> Load(DomainModel.S501.FeatureTypes.AirspaceRestriction instance) {
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
            return this;
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
    public partial class SoundingViewModel : FeatureViewModel<Sounding> {
        private status? _status = default;
        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("Sounding")]
        public status? status {
            get {
                return _status;
            }

            set {
                SetValue(ref _status, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(techniqueOfVerticalMeasurementList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(qualityOfVerticalMeasurementList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => Sounding._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => Sounding._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)18];

        [Browsable(false)]
        public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1, (techniqueOfVerticalMeasurement)2, (techniqueOfVerticalMeasurement)3, (techniqueOfVerticalMeasurement)4, (techniqueOfVerticalMeasurement)5, (techniqueOfVerticalMeasurement)8, (techniqueOfVerticalMeasurement)9, (techniqueOfVerticalMeasurement)10, (techniqueOfVerticalMeasurement)11, (techniqueOfVerticalMeasurement)12, (techniqueOfVerticalMeasurement)13, (techniqueOfVerticalMeasurement)15, (techniqueOfVerticalMeasurement)16, (techniqueOfVerticalMeasurement)17, (techniqueOfVerticalMeasurement)18];

        [Browsable(false)]
        public qualityOfVerticalMeasurement[] qualityOfVerticalMeasurementList => [(qualityOfVerticalMeasurement)1, (qualityOfVerticalMeasurement)3, (qualityOfVerticalMeasurement)4, (qualityOfVerticalMeasurement)8, (qualityOfVerticalMeasurement)9];

        public override FeatureViewModel<Sounding> Load(DomainModel.S501.FeatureTypes.Sounding instance) {
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
            return this;
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
    public partial class TrafficSeparationSchemeBoundaryViewModel : FeatureViewModel<TrafficSeparationSchemeBoundary> {
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationSchemeBoundary._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeBoundary._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)3, (status)9, (status)28];

        public override FeatureViewModel<TrafficSeparationSchemeBoundary> Load(DomainModel.S501.FeatureTypes.TrafficSeparationSchemeBoundary instance) {
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
            return this;
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
    public partial class DumpingGroundViewModel : FeatureViewModel<DumpingGround> {
        [DomainModel.EnumerationAttribute(nameof(categoryOfDumpingGroundList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("DumpingGround")]
        public ObservableCollection<categoryOfDumpingGround> categoryOfDumpingGround { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(restrictionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("DumpingGround")]
        public ObservableCollection<restriction> restriction { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        public override informationBindingDefinition[] informationBindingDefinitions => DumpingGround._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => DumpingGround._featureBindingDefinitions;

        [Browsable(false)]
        public categoryOfDumpingGround[] categoryOfDumpingGroundList => [(categoryOfDumpingGround)2, (categoryOfDumpingGround)3, (categoryOfDumpingGround)4, (categoryOfDumpingGround)5, (categoryOfDumpingGround)6];

        [Browsable(false)]
        public restriction[] restrictionList => [(restriction)1, (restriction)2, (restriction)3, (restriction)4, (restriction)5, (restriction)6, (restriction)7, (restriction)8, (restriction)9, (restriction)10, (restriction)11, (restriction)12, (restriction)13, (restriction)17, (restriction)18, (restriction)19, (restriction)20, (restriction)21, (restriction)22, (restriction)23, (restriction)24, (restriction)25, (restriction)27];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)4, (status)6, (status)7];

        public override FeatureViewModel<DumpingGround> Load(DomainModel.S501.FeatureTypes.DumpingGround instance) {
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
            return this;
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
    public partial class AirportAirfieldViewModel : FeatureViewModel<AirportAirfield> {
        [DomainModel.EnumerationAttribute(nameof(categoryOfAirportAirfieldList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(conditionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(heightLengthUnitsList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(verticalDatumList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => AirportAirfield._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => AirportAirfield._featureBindingDefinitions;

        [Browsable(false)]
        public categoryOfAirportAirfield[] categoryOfAirportAirfieldList => [(categoryOfAirportAirfield)1, (categoryOfAirportAirfield)2, (categoryOfAirportAirfield)3, (categoryOfAirportAirfield)4, (categoryOfAirportAirfield)5, (categoryOfAirportAirfield)6, (categoryOfAirportAirfield)8, (categoryOfAirportAirfield)9];

        [Browsable(false)]
        public condition[] conditionList => [(condition)1, (condition)2, (condition)3, (condition)5];

        [Browsable(false)]
        public heightLengthUnits[] heightLengthUnitsList => [(heightLengthUnits)2];

        [Browsable(false)]
        public verticalDatum[] verticalDatumList => [(verticalDatum)3, (verticalDatum)16, (verticalDatum)17, (verticalDatum)18, (verticalDatum)19, (verticalDatum)20, (verticalDatum)21, (verticalDatum)24, (verticalDatum)25, (verticalDatum)26, (verticalDatum)28, (verticalDatum)29, (verticalDatum)30, (verticalDatum)44];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)4, (status)5, (status)6, (status)7, (status)8, (status)12, (status)14];

        public override FeatureViewModel<AirportAirfield> Load(DomainModel.S501.FeatureTypes.AirportAirfield instance) {
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
            return this;
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
    public partial class FoulGroundViewModel : FeatureViewModel<FoulGround> {
        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(qualityOfVerticalMeasurementList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("FoulGround")]
        public ObservableCollection<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(techniqueOfVerticalMeasurementList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        public override informationBindingDefinition[] informationBindingDefinitions => FoulGround._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => FoulGround._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)13, (status)18, (status)28];

        [Browsable(false)]
        public qualityOfVerticalMeasurement[] qualityOfVerticalMeasurementList => [(qualityOfVerticalMeasurement)1, (qualityOfVerticalMeasurement)2, (qualityOfVerticalMeasurement)3, (qualityOfVerticalMeasurement)4, (qualityOfVerticalMeasurement)6, (qualityOfVerticalMeasurement)7, (qualityOfVerticalMeasurement)8, (qualityOfVerticalMeasurement)9];

        [Browsable(false)]
        public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1, (techniqueOfVerticalMeasurement)2, (techniqueOfVerticalMeasurement)3, (techniqueOfVerticalMeasurement)4, (techniqueOfVerticalMeasurement)5, (techniqueOfVerticalMeasurement)8, (techniqueOfVerticalMeasurement)9, (techniqueOfVerticalMeasurement)10, (techniqueOfVerticalMeasurement)11, (techniqueOfVerticalMeasurement)12, (techniqueOfVerticalMeasurement)13, (techniqueOfVerticalMeasurement)15, (techniqueOfVerticalMeasurement)16, (techniqueOfVerticalMeasurement)17, (techniqueOfVerticalMeasurement)18];

        public override FeatureViewModel<FoulGround> Load(DomainModel.S501.FeatureTypes.FoulGround instance) {
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
            return this;
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
    public partial class LightAirObstructionViewModel : FeatureViewModel<LightAirObstruction> {
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(heightLengthUnitsList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("LightAirObstruction")]
        public heightLengthUnits? heightLengthUnits {
            get {
                return _heightLengthUnits;
            }

            set {
                SetValue(ref _heightLengthUnits, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(lightVisibilityList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(verticalDatumList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(exhibitionConditionOfLightList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(colourList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("LightAirObstruction")]
        public ObservableCollection<colour> colour { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => LightAirObstruction._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => LightAirObstruction._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)4, (status)5, (status)6, (status)7, (status)8, (status)11, (status)14, (status)15, (status)16, (status)17];

        [Browsable(false)]
        public heightLengthUnits[] heightLengthUnitsList => [(heightLengthUnits)1];

        [Browsable(false)]
        public lightVisibility[] lightVisibilityList => [(lightVisibility)1, (lightVisibility)2, (lightVisibility)3, (lightVisibility)4, (lightVisibility)5, (lightVisibility)6, (lightVisibility)7, (lightVisibility)8, (lightVisibility)9];

        [Browsable(false)]
        public verticalDatum[] verticalDatumList => [(verticalDatum)3, (verticalDatum)16, (verticalDatum)17, (verticalDatum)18, (verticalDatum)19, (verticalDatum)20, (verticalDatum)21, (verticalDatum)24, (verticalDatum)25, (verticalDatum)26, (verticalDatum)28, (verticalDatum)29, (verticalDatum)30, (verticalDatum)44];

        [Browsable(false)]
        public exhibitionConditionOfLight[] exhibitionConditionOfLightList => [(exhibitionConditionOfLight)1, (exhibitionConditionOfLight)2, (exhibitionConditionOfLight)3, (exhibitionConditionOfLight)4];

        [Browsable(false)]
        public colour[] colourList => [(colour)1, (colour)3, (colour)4, (colour)5, (colour)6, (colour)9, (colour)10, (colour)11];

        public override FeatureViewModel<LightAirObstruction> Load(DomainModel.S501.FeatureTypes.LightAirObstruction instance) {
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
            return this;
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
    public partial class MooringBuoyViewModel : FeatureViewModel<MooringBuoy> {
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

        [DomainModel.EnumerationAttribute(nameof(natureOfConstructionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("MooringBuoy")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        private colourPattern? _colourPattern = default;
        [DomainModel.EnumerationAttribute(nameof(colourPatternList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("MooringBuoy")]
        public colourPattern? colourPattern {
            get {
                return _colourPattern;
            }

            set {
                SetValue(ref _colourPattern, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(colourList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("MooringBuoy")]
        public ObservableCollection<colour> colour { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(buoyShapeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => MooringBuoy._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => MooringBuoy._featureBindingDefinitions;

        [Browsable(false)]
        public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)7, (natureOfConstruction)8, (natureOfConstruction)11];

        [Browsable(false)]
        public colourPattern[] colourPatternList => [(colourPattern)1, (colourPattern)2, (colourPattern)3, (colourPattern)4, (colourPattern)5, (colourPattern)6];

        [Browsable(false)]
        public colour[] colourList => [(colour)1, (colour)2, (colour)3, (colour)4, (colour)5, (colour)6, (colour)7, (colour)8, (colour)9, (colour)10, (colour)11, (colour)12, (colour)13];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)4, (status)5, (status)7, (status)8, (status)18];

        [Browsable(false)]
        public buoyShape[] buoyShapeList => [(buoyShape)1, (buoyShape)2, (buoyShape)3, (buoyShape)4, (buoyShape)5, (buoyShape)6, (buoyShape)7, (buoyShape)8];

        public override FeatureViewModel<MooringBuoy> Load(DomainModel.S501.FeatureTypes.MooringBuoy instance) {
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

            return this;
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
    public partial class UnderwaterAwashRockViewModel : FeatureViewModel<UnderwaterAwashRock> {
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
        [DomainModel.EnumerationAttribute(nameof(waterLevelEffectList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(natureOfSurfaceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(expositionOfSoundingList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("UnderwaterAwashRock")]
        public ObservableCollection<status> status { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(techniqueOfVerticalMeasurementList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(qualityOfVerticalMeasurementList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("UnderwaterAwashRock")]
        public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement {
            get {
                return _qualityOfVerticalMeasurement;
            }

            set {
                SetValue(ref _qualityOfVerticalMeasurement, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => UnderwaterAwashRock._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => UnderwaterAwashRock._featureBindingDefinitions;

        [Browsable(false)]
        public waterLevelEffect[] waterLevelEffectList => [(waterLevelEffect)3, (waterLevelEffect)4, (waterLevelEffect)5];

        [Browsable(false)]
        public natureOfSurface[] natureOfSurfaceList => [(natureOfSurface)14, (natureOfSurface)18];

        [Browsable(false)]
        public expositionOfSounding[] expositionOfSoundingList => [(expositionOfSounding)1, (expositionOfSounding)2];

        [Browsable(false)]
        public status[] statusList => [(status)18];

        [Browsable(false)]
        public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1, (techniqueOfVerticalMeasurement)2, (techniqueOfVerticalMeasurement)3, (techniqueOfVerticalMeasurement)4, (techniqueOfVerticalMeasurement)5, (techniqueOfVerticalMeasurement)8, (techniqueOfVerticalMeasurement)9, (techniqueOfVerticalMeasurement)10, (techniqueOfVerticalMeasurement)11, (techniqueOfVerticalMeasurement)12, (techniqueOfVerticalMeasurement)13, (techniqueOfVerticalMeasurement)15, (techniqueOfVerticalMeasurement)16, (techniqueOfVerticalMeasurement)17, (techniqueOfVerticalMeasurement)18];

        [Browsable(false)]
        public qualityOfVerticalMeasurement[] qualityOfVerticalMeasurementList => [(qualityOfVerticalMeasurement)1, (qualityOfVerticalMeasurement)2, (qualityOfVerticalMeasurement)3, (qualityOfVerticalMeasurement)4, (qualityOfVerticalMeasurement)6, (qualityOfVerticalMeasurement)7, (qualityOfVerticalMeasurement)8, (qualityOfVerticalMeasurement)9];

        public override FeatureViewModel<UnderwaterAwashRock> Load(DomainModel.S501.FeatureTypes.UnderwaterAwashRock instance) {
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
            return this;
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
    public partial class CableOverheadViewModel : FeatureViewModel<CableOverhead> {
        private condition? _condition = default;
        [DomainModel.EnumerationAttribute(nameof(conditionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("CableOverhead")]
        public condition? condition {
            get {
                return _condition;
            }

            set {
                SetValue(ref _condition, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(verticalDatumList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(categoryOfCableList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(visualProminenceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => CableOverhead._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => CableOverhead._featureBindingDefinitions;

        [Browsable(false)]
        public condition[] conditionList => [(condition)1, (condition)5];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)4, (status)5, (status)7, (status)12, (status)28];

        [Browsable(false)]
        public verticalDatum[] verticalDatumList => [(verticalDatum)3, (verticalDatum)13, (verticalDatum)16, (verticalDatum)17, (verticalDatum)18, (verticalDatum)19, (verticalDatum)20, (verticalDatum)21, (verticalDatum)24, (verticalDatum)25, (verticalDatum)26, (verticalDatum)28, (verticalDatum)29, (verticalDatum)30, (verticalDatum)44];

        [Browsable(false)]
        public categoryOfCable[] categoryOfCableList => [(categoryOfCable)1, (categoryOfCable)3];

        [Browsable(false)]
        public visualProminence[] visualProminenceList => [(visualProminence)1, (visualProminence)2, (visualProminence)3];

        public override FeatureViewModel<CableOverhead> Load(DomainModel.S501.FeatureTypes.CableOverhead instance) {
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
            return this;
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
    public partial class ControlledAirspaceViewModel : FeatureViewModel<ControlledAirspace> {
        private controlledAirspaceClassDesignation? _controlledAirspaceClassDesignation = default;
        [DomainModel.EnumerationAttribute(nameof(controlledAirspaceClassDesignationList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(categoryOfControlledAirspaceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(verticalDatumList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(heightLengthUnitsList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => ControlledAirspace._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => ControlledAirspace._featureBindingDefinitions;

        [Browsable(false)]
        public controlledAirspaceClassDesignation[] controlledAirspaceClassDesignationList => [(controlledAirspaceClassDesignation)501, (controlledAirspaceClassDesignation)502, (controlledAirspaceClassDesignation)503, (controlledAirspaceClassDesignation)504, (controlledAirspaceClassDesignation)505, (controlledAirspaceClassDesignation)506, (controlledAirspaceClassDesignation)507];

        [Browsable(false)]
        public categoryOfControlledAirspace[] categoryOfControlledAirspaceList => [(categoryOfControlledAirspace)501, (categoryOfControlledAirspace)502, (categoryOfControlledAirspace)503, (categoryOfControlledAirspace)504, (categoryOfControlledAirspace)505, (categoryOfControlledAirspace)506, (categoryOfControlledAirspace)507, (categoryOfControlledAirspace)508, (categoryOfControlledAirspace)509, (categoryOfControlledAirspace)510, (categoryOfControlledAirspace)511, (categoryOfControlledAirspace)512, (categoryOfControlledAirspace)513, (categoryOfControlledAirspace)514, (categoryOfControlledAirspace)515, (categoryOfControlledAirspace)516, (categoryOfControlledAirspace)517, (categoryOfControlledAirspace)518, (categoryOfControlledAirspace)519, (categoryOfControlledAirspace)520, (categoryOfControlledAirspace)521, (categoryOfControlledAirspace)522];

        [Browsable(false)]
        public verticalDatum[] verticalDatumList => [(verticalDatum)3, (verticalDatum)16, (verticalDatum)17, (verticalDatum)18, (verticalDatum)19, (verticalDatum)20, (verticalDatum)21, (verticalDatum)24, (verticalDatum)25, (verticalDatum)26, (verticalDatum)28, (verticalDatum)29, (verticalDatum)30, (verticalDatum)44];

        [Browsable(false)]
        public heightLengthUnits[] heightLengthUnitsList => [(heightLengthUnits)2];

        public override FeatureViewModel<ControlledAirspace> Load(DomainModel.S501.FeatureTypes.ControlledAirspace instance) {
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

            return this;
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
    public partial class ObstructionViewModel : FeatureViewModel<Obstruction> {
        [DomainModel.EnumerationAttribute(nameof(natureOfConstructionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(productList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(expositionOfSoundingList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(soundingDatumList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(conditionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(qualityOfVerticalMeasurementList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(verticalDatumList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(sonarSignalStrengthList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(natureOfSurfaceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(categoryOfObstructionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(visualProminenceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(techniqueOfVerticalMeasurementList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(cardinalPointOrientationList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(waterLevelEffectList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => Obstruction._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => Obstruction._featureBindingDefinitions;

        [Browsable(false)]
        public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1, (natureOfConstruction)2, (natureOfConstruction)3, (natureOfConstruction)4, (natureOfConstruction)5, (natureOfConstruction)6, (natureOfConstruction)7, (natureOfConstruction)8, (natureOfConstruction)11, (natureOfConstruction)12];

        [Browsable(false)]
        public product[] productList => [(product)1, (product)3, (product)4, (product)5, (product)6, (product)7, (product)8, (product)9, (product)10, (product)11, (product)12, (product)13, (product)14, (product)15, (product)16, (product)17, (product)18, (product)19, (product)20, (product)21, (product)22, (product)23, (product)25, (product)502, (product)503, (product)505, (product)506, (product)507, (product)508, (product)509, (product)510, (product)511, (product)513, (product)514, (product)515, (product)516, (product)517, (product)519, (product)520, (product)521, (product)522, (product)523, (product)524, (product)525, (product)526, (product)527, (product)528, (product)529, (product)530, (product)531, (product)532, (product)533, (product)534, (product)535, (product)536, (product)537, (product)540, (product)541, (product)542];

        [Browsable(false)]
        public expositionOfSounding[] expositionOfSoundingList => [(expositionOfSounding)1, (expositionOfSounding)2, (expositionOfSounding)3];

        [Browsable(false)]
        public soundingDatum[] soundingDatumList => [(soundingDatum)501, (soundingDatum)502, (soundingDatum)503, (soundingDatum)504, (soundingDatum)505, (soundingDatum)506, (soundingDatum)507, (soundingDatum)508, (soundingDatum)509, (soundingDatum)510, (soundingDatum)511, (soundingDatum)512, (soundingDatum)513, (soundingDatum)514, (soundingDatum)515, (soundingDatum)519, (soundingDatum)522, (soundingDatum)523, (soundingDatum)524, (soundingDatum)525, (soundingDatum)526, (soundingDatum)527, (soundingDatum)531, (soundingDatum)532];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)4, (status)5, (status)7, (status)8, (status)13, (status)18, (status)28, (status)501, (status)503, (status)505, (status)506, (status)507, (status)508, (status)509, (status)510, (status)511, (status)512, (status)516, (status)517, (status)518];

        [Browsable(false)]
        public condition[] conditionList => [(condition)1, (condition)2, (condition)5];

        [Browsable(false)]
        public qualityOfVerticalMeasurement[] qualityOfVerticalMeasurementList => [(qualityOfVerticalMeasurement)1, (qualityOfVerticalMeasurement)2, (qualityOfVerticalMeasurement)3, (qualityOfVerticalMeasurement)4, (qualityOfVerticalMeasurement)6, (qualityOfVerticalMeasurement)7, (qualityOfVerticalMeasurement)8, (qualityOfVerticalMeasurement)9];

        [Browsable(false)]
        public verticalDatum[] verticalDatumList => [(verticalDatum)3, (verticalDatum)16, (verticalDatum)17, (verticalDatum)18, (verticalDatum)19, (verticalDatum)20, (verticalDatum)21, (verticalDatum)24, (verticalDatum)25, (verticalDatum)26, (verticalDatum)28, (verticalDatum)29, (verticalDatum)30, (verticalDatum)44, (verticalDatum)501];

        [Browsable(false)]
        public sonarSignalStrength[] sonarSignalStrengthList => [(sonarSignalStrength)501, (sonarSignalStrength)502, (sonarSignalStrength)503, (sonarSignalStrength)504];

        [Browsable(false)]
        public natureOfSurface[] natureOfSurfaceList => [(natureOfSurface)1, (natureOfSurface)2, (natureOfSurface)3, (natureOfSurface)4, (natureOfSurface)5, (natureOfSurface)6, (natureOfSurface)7, (natureOfSurface)8, (natureOfSurface)9, (natureOfSurface)11, (natureOfSurface)14, (natureOfSurface)17, (natureOfSurface)18];

        [Browsable(false)]
        public categoryOfObstruction[] categoryOfObstructionList => [(categoryOfObstruction)1, (categoryOfObstruction)2, (categoryOfObstruction)3, (categoryOfObstruction)4, (categoryOfObstruction)5, (categoryOfObstruction)6, (categoryOfObstruction)8, (categoryOfObstruction)9, (categoryOfObstruction)10, (categoryOfObstruction)12, (categoryOfObstruction)13, (categoryOfObstruction)14, (categoryOfObstruction)15, (categoryOfObstruction)16, (categoryOfObstruction)17, (categoryOfObstruction)18, (categoryOfObstruction)19, (categoryOfObstruction)20, (categoryOfObstruction)21, (categoryOfObstruction)22, (categoryOfObstruction)23, (categoryOfObstruction)501, (categoryOfObstruction)502, (categoryOfObstruction)503, (categoryOfObstruction)504, (categoryOfObstruction)506, (categoryOfObstruction)508, (categoryOfObstruction)509];

        [Browsable(false)]
        public visualProminence[] visualProminenceList => [(visualProminence)1, (visualProminence)2, (visualProminence)3];

        [Browsable(false)]
        public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1, (techniqueOfVerticalMeasurement)2, (techniqueOfVerticalMeasurement)3, (techniqueOfVerticalMeasurement)4, (techniqueOfVerticalMeasurement)5, (techniqueOfVerticalMeasurement)8, (techniqueOfVerticalMeasurement)9, (techniqueOfVerticalMeasurement)10, (techniqueOfVerticalMeasurement)11, (techniqueOfVerticalMeasurement)12, (techniqueOfVerticalMeasurement)13, (techniqueOfVerticalMeasurement)15, (techniqueOfVerticalMeasurement)16, (techniqueOfVerticalMeasurement)17, (techniqueOfVerticalMeasurement)18];

        [Browsable(false)]
        public cardinalPointOrientation[] cardinalPointOrientationList => [(cardinalPointOrientation)501, (cardinalPointOrientation)502, (cardinalPointOrientation)503, (cardinalPointOrientation)504];

        [Browsable(false)]
        public waterLevelEffect[] waterLevelEffectList => [(waterLevelEffect)1, (waterLevelEffect)2, (waterLevelEffect)3, (waterLevelEffect)4, (waterLevelEffect)5, (waterLevelEffect)7];

        public override FeatureViewModel<Obstruction> Load(DomainModel.S501.FeatureTypes.Obstruction instance) {
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
            return this;
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
    public partial class FishingGroundViewModel : FeatureViewModel<FishingGround> {
        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(restrictionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("FishingGround")]
        public ObservableCollection<restriction> restriction { get; set; } = new();

        [Category("FishingGround")]
        public ObservableCollection<information> information { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => FishingGround._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => FishingGround._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)5, (status)6, (status)7, (status)8, (status)14, (status)16, (status)17, (status)28];

        [Browsable(false)]
        public restriction[] restrictionList => [(restriction)1, (restriction)2, (restriction)4, (restriction)5, (restriction)6, (restriction)8, (restriction)9, (restriction)10, (restriction)11, (restriction)12, (restriction)15, (restriction)16, (restriction)17, (restriction)18, (restriction)19, (restriction)20, (restriction)21, (restriction)22, (restriction)23, (restriction)24, (restriction)25, (restriction)26, (restriction)27, (restriction)39];

        public override FeatureViewModel<FishingGround> Load(DomainModel.S501.FeatureTypes.FishingGround instance) {
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
            return this;
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
    public partial class FishingFacilityViewModel : FeatureViewModel<FishingFacility> {
        [Category("FishingFacility")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("FishingFacility")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        private condition? _condition = default;
        [DomainModel.EnumerationAttribute(nameof(conditionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("FishingFacility")]
        public ObservableCollection<status> status { get; set; } = new();

        private categoryOfFishingFacility? _categoryOfFishingFacility = default;
        [DomainModel.EnumerationAttribute(nameof(categoryOfFishingFacilityList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => FishingFacility._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => FishingFacility._featureBindingDefinitions;

        [Browsable(false)]
        public condition[] conditionList => [(condition)1, (condition)2, (condition)5];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)4, (status)5, (status)6, (status)7, (status)8, (status)12, (status)18, (status)28];

        [Browsable(false)]
        public categoryOfFishingFacility[] categoryOfFishingFacilityList => [(categoryOfFishingFacility)1, (categoryOfFishingFacility)2, (categoryOfFishingFacility)3, (categoryOfFishingFacility)4];

        public override FeatureViewModel<FishingFacility> Load(DomainModel.S501.FeatureTypes.FishingFacility instance) {
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
            return this;
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
    public partial class NavigationSystemViewModel : FeatureViewModel<NavigationSystem> {
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
        [DomainModel.EnumerationAttribute(nameof(categoryOfRadioStationList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => NavigationSystem._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => NavigationSystem._featureBindingDefinitions;

        [Browsable(false)]
        public categoryOfRadioStation[] categoryOfRadioStationList => [(categoryOfRadioStation)1, (categoryOfRadioStation)2, (categoryOfRadioStation)3, (categoryOfRadioStation)4, (categoryOfRadioStation)5, (categoryOfRadioStation)6, (categoryOfRadioStation)7, (categoryOfRadioStation)8, (categoryOfRadioStation)9, (categoryOfRadioStation)10, (categoryOfRadioStation)11, (categoryOfRadioStation)12, (categoryOfRadioStation)13, (categoryOfRadioStation)14, (categoryOfRadioStation)19, (categoryOfRadioStation)20, (categoryOfRadioStation)504, (categoryOfRadioStation)505, (categoryOfRadioStation)506, (categoryOfRadioStation)508, (categoryOfRadioStation)509, (categoryOfRadioStation)510];

        public override FeatureViewModel<NavigationSystem> Load(DomainModel.S501.FeatureTypes.NavigationSystem instance) {
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
            return this;
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
    public partial class TrafficSeparationSchemeCrossingViewModel : FeatureViewModel<TrafficSeparationSchemeCrossing> {
        [DomainModel.EnumerationAttribute(nameof(restrictionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationSchemeCrossing._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeCrossing._featureBindingDefinitions;

        [Browsable(false)]
        public restriction[] restrictionList => [(restriction)1, (restriction)2, (restriction)3, (restriction)4, (restriction)5, (restriction)6, (restriction)8, (restriction)9, (restriction)10, (restriction)11, (restriction)12, (restriction)13, (restriction)16, (restriction)17, (restriction)18, (restriction)19, (restriction)20, (restriction)21, (restriction)22, (restriction)23, (restriction)24, (restriction)25, (restriction)27];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)3, (status)6, (status)9];

        public override FeatureViewModel<TrafficSeparationSchemeCrossing> Load(DomainModel.S501.FeatureTypes.TrafficSeparationSchemeCrossing instance) {
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
            return this;
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
    public partial class TrafficSeparationSchemeLanePartViewModel : FeatureViewModel<TrafficSeparationSchemeLanePart> {
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

        [DomainModel.EnumerationAttribute(nameof(restrictionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationSchemeLanePart._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeLanePart._featureBindingDefinitions;

        [Browsable(false)]
        public restriction[] restrictionList => [(restriction)1, (restriction)2, (restriction)3, (restriction)4, (restriction)5, (restriction)6, (restriction)8, (restriction)9, (restriction)10, (restriction)11, (restriction)12, (restriction)13, (restriction)16, (restriction)17, (restriction)18, (restriction)19, (restriction)20, (restriction)21, (restriction)22, (restriction)23, (restriction)24, (restriction)25, (restriction)27];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)3, (status)9, (status)28];

        public override FeatureViewModel<TrafficSeparationSchemeLanePart> Load(DomainModel.S501.FeatureTypes.TrafficSeparationSchemeLanePart instance) {
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
            return this;
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
    public partial class TerritorialSeaAreaViewModel : FeatureViewModel<TerritorialSeaArea> {
        [Category("TerritorialSeaArea")]
        public ObservableCollection<String> nationality { get; set; } = new();

        [Category("TerritorialSeaArea")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private status? _status = default;
        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(restrictionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        public override informationBindingDefinition[] informationBindingDefinitions => TerritorialSeaArea._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => TerritorialSeaArea._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)502, (status)504, (status)520];

        [Browsable(false)]
        public restriction[] restrictionList => [(restriction)2, (restriction)4, (restriction)6, (restriction)8, (restriction)9, (restriction)10, (restriction)12, (restriction)17, (restriction)18, (restriction)19, (restriction)20, (restriction)21, (restriction)22, (restriction)23, (restriction)24, (restriction)27];

        public override FeatureViewModel<TerritorialSeaArea> Load(DomainModel.S501.FeatureTypes.TerritorialSeaArea instance) {
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
            return this;
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
    public partial class LateralBeaconViewModel : FeatureViewModel<LateralBeacon> {
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
        [DomainModel.EnumerationAttribute(nameof(beaconShapeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(categoryOfLateralMarkList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("LateralBeacon")]
        public ObservableCollection<status> status { get; set; } = new();

        private visualProminence? _visualProminence = default;
        [DomainModel.EnumerationAttribute(nameof(visualProminenceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(colourPatternList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(conditionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("LateralBeacon")]
        public condition? condition {
            get {
                return _condition;
            }

            set {
                SetValue(ref _condition, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(natureOfConstructionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("LateralBeacon")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(colourList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("LateralBeacon")]
        public ObservableCollection<colour> colour { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => LateralBeacon._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => LateralBeacon._featureBindingDefinitions;

        [Browsable(false)]
        public beaconShape[] beaconShapeList => [(beaconShape)1, (beaconShape)2, (beaconShape)3, (beaconShape)4, (beaconShape)5, (beaconShape)6, (beaconShape)7];

        [Browsable(false)]
        public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1, (marksNavigationalSystemOf)2, (marksNavigationalSystemOf)9, (marksNavigationalSystemOf)11];

        [Browsable(false)]
        public categoryOfLateralMark[] categoryOfLateralMarkList => [(categoryOfLateralMark)1, (categoryOfLateralMark)2, (categoryOfLateralMark)3, (categoryOfLateralMark)4];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)4, (status)5, (status)7, (status)8, (status)12, (status)18];

        [Browsable(false)]
        public visualProminence[] visualProminenceList => [(visualProminence)1, (visualProminence)2, (visualProminence)3];

        [Browsable(false)]
        public colourPattern[] colourPatternList => [(colourPattern)1, (colourPattern)2, (colourPattern)3, (colourPattern)4, (colourPattern)5, (colourPattern)6];

        [Browsable(false)]
        public condition[] conditionList => [(condition)1, (condition)2, (condition)5];

        [Browsable(false)]
        public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1, (natureOfConstruction)2, (natureOfConstruction)6, (natureOfConstruction)7, (natureOfConstruction)8];

        [Browsable(false)]
        public colour[] colourList => [(colour)1, (colour)2, (colour)3, (colour)4, (colour)5, (colour)6, (colour)7, (colour)8, (colour)9, (colour)10, (colour)11, (colour)12, (colour)13];

        public override FeatureViewModel<LateralBeacon> Load(DomainModel.S501.FeatureTypes.LateralBeacon instance) {
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
            return this;
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
    public partial class CoastGuardStationViewModel : FeatureViewModel<CoastGuardStation> {
        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        public override informationBindingDefinition[] informationBindingDefinitions => CoastGuardStation._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => CoastGuardStation._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)4, (status)5, (status)16, (status)17];

        public override FeatureViewModel<CoastGuardStation> Load(DomainModel.S501.FeatureTypes.CoastGuardStation instance) {
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
            return this;
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
    public partial class SeparationZoneOrLineViewModel : FeatureViewModel<SeparationZoneOrLine> {
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => SeparationZoneOrLine._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => SeparationZoneOrLine._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)3, (status)9, (status)28];

        public override FeatureViewModel<SeparationZoneOrLine> Load(DomainModel.S501.FeatureTypes.SeparationZoneOrLine instance) {
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

            return this;
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
    public partial class BottomFeatureViewModel : FeatureViewModel<BottomFeature> {
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
        [DomainModel.EnumerationAttribute(nameof(bottomFeatureClassificationList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => BottomFeature._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => BottomFeature._featureBindingDefinitions;

        [Browsable(false)]
        public bottomFeatureClassification[] bottomFeatureClassificationList => [(bottomFeatureClassification)502, (bottomFeatureClassification)510];

        public override FeatureViewModel<BottomFeature> Load(DomainModel.S501.FeatureTypes.BottomFeature instance) {
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
            return this;
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
    public partial class ArchipelagicBaselineViewModel : FeatureViewModel<ArchipelagicBaseline> {
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
        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => ArchipelagicBaseline._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => ArchipelagicBaseline._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)502, (status)504];

        public override FeatureViewModel<ArchipelagicBaseline> Load(DomainModel.S501.FeatureTypes.ArchipelagicBaseline instance) {
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
            return this;
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
    public partial class SmallBottomObjectViewModel : FeatureViewModel<SmallBottomObject> {
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
        [DomainModel.EnumerationAttribute(nameof(statusOfSmallBottomObjectList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => SmallBottomObject._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => SmallBottomObject._featureBindingDefinitions;

        [Browsable(false)]
        public statusOfSmallBottomObject[] statusOfSmallBottomObjectList => [(statusOfSmallBottomObject)504];

        public override FeatureViewModel<SmallBottomObject> Load(DomainModel.S501.FeatureTypes.SmallBottomObject instance) {
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
            return this;
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
    public partial class ExclusiveEconomicZoneViewModel : FeatureViewModel<ExclusiveEconomicZone> {
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
        public override informationBindingDefinition[] informationBindingDefinitions => ExclusiveEconomicZone._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => ExclusiveEconomicZone._featureBindingDefinitions;

        public override FeatureViewModel<ExclusiveEconomicZone> Load(DomainModel.S501.FeatureTypes.ExclusiveEconomicZone instance) {
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
            return this;
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
    public partial class RadarStationViewModel : FeatureViewModel<RadarStation> {
        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("RadarStation")]
        public ObservableCollection<status> status { get; set; } = new();

        private categoryOfRadarStation? _categoryOfRadarStation = default;
        [DomainModel.EnumerationAttribute(nameof(categoryOfRadarStationList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => RadarStation._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => RadarStation._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)4, (status)7, (status)8];

        [Browsable(false)]
        public categoryOfRadarStation[] categoryOfRadarStationList => [(categoryOfRadarStation)1, (categoryOfRadarStation)2];

        public override FeatureViewModel<RadarStation> Load(DomainModel.S501.FeatureTypes.RadarStation instance) {
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
            return this;
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
    public partial class DivingLocationViewModel : FeatureViewModel<DivingLocation> {
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
        [DomainModel.EnumerationAttribute(nameof(divingActivityList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("DivingLocation")]
        public divingActivity? divingActivity {
            get {
                return _divingActivity;
            }

            set {
                SetValue(ref _divingActivity, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => DivingLocation._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => DivingLocation._featureBindingDefinitions;

        [Browsable(false)]
        public divingActivity[] divingActivityList => [(divingActivity)501, (divingActivity)502, (divingActivity)503];

        public override FeatureViewModel<DivingLocation> Load(DomainModel.S501.FeatureTypes.DivingLocation instance) {
            waterClarity = instance.waterClarity;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            divingActivity = instance.divingActivity;
            return this;
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
    public partial class RestrictedAreaViewModel : FeatureViewModel<RestrictedArea> {
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

        [DomainModel.EnumerationAttribute(nameof(categoryOfRestrictedAreaList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(restrictionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("RestrictedArea")]
        public ObservableCollection<restriction> restriction { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => RestrictedArea._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => RestrictedArea._featureBindingDefinitions;

        [Browsable(false)]
        public categoryOfRestrictedArea[] categoryOfRestrictedAreaList => [(categoryOfRestrictedArea)1, (categoryOfRestrictedArea)4, (categoryOfRestrictedArea)5, (categoryOfRestrictedArea)6, (categoryOfRestrictedArea)7, (categoryOfRestrictedArea)8, (categoryOfRestrictedArea)9, (categoryOfRestrictedArea)10, (categoryOfRestrictedArea)12, (categoryOfRestrictedArea)14, (categoryOfRestrictedArea)18, (categoryOfRestrictedArea)19, (categoryOfRestrictedArea)20, (categoryOfRestrictedArea)21, (categoryOfRestrictedArea)22, (categoryOfRestrictedArea)23, (categoryOfRestrictedArea)24, (categoryOfRestrictedArea)25, (categoryOfRestrictedArea)27, (categoryOfRestrictedArea)28, (categoryOfRestrictedArea)29, (categoryOfRestrictedArea)30, (categoryOfRestrictedArea)31, (categoryOfRestrictedArea)32, (categoryOfRestrictedArea)501];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)3, (status)4, (status)5, (status)6, (status)7, (status)9, (status)18, (status)28, (status)501];

        [Browsable(false)]
        public restriction[] restrictionList => [(restriction)1, (restriction)2, (restriction)3, (restriction)4, (restriction)5, (restriction)6, (restriction)7, (restriction)8, (restriction)9, (restriction)10, (restriction)11, (restriction)12, (restriction)13, (restriction)14, (restriction)15, (restriction)16, (restriction)17, (restriction)18, (restriction)19, (restriction)20, (restriction)21, (restriction)22, (restriction)23, (restriction)24, (restriction)25, (restriction)26, (restriction)27, (restriction)39, (restriction)42];

        public override FeatureViewModel<RestrictedArea> Load(DomainModel.S501.FeatureTypes.RestrictedArea instance) {
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
            return this;
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
    public partial class CableSubmarineViewModel : FeatureViewModel<CableSubmarine> {
        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(categoryOfCableList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(conditionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => CableSubmarine._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => CableSubmarine._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)4, (status)13, (status)18];

        [Browsable(false)]
        public categoryOfCable[] categoryOfCableList => [(categoryOfCable)1, (categoryOfCable)6, (categoryOfCable)7, (categoryOfCable)9, (categoryOfCable)10];

        [Browsable(false)]
        public condition[] conditionList => [(condition)1, (condition)5];

        public override FeatureViewModel<CableSubmarine> Load(DomainModel.S501.FeatureTypes.CableSubmarine instance) {
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

            return this;
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
    public partial class WreckViewModel : FeatureViewModel<Wreck> {
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

        [DomainModel.EnumerationAttribute(nameof(techniqueOfVerticalMeasurementList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(visualProminenceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("Wreck")]
        public ObservableCollection<status> status { get; set; } = new();

        private sonarSignalStrength? _sonarSignalStrength = default;
        [DomainModel.EnumerationAttribute(nameof(sonarSignalStrengthList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(natureOfConstructionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(natureOfSurfaceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(waterLevelEffectList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(categoryOfWreckList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(qualityOfHorizontalMeasurementList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(qualityOfVerticalMeasurementList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(cardinalPointOrientationList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(productList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(expositionOfSoundingList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        public override informationBindingDefinition[] informationBindingDefinitions => Wreck._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => Wreck._featureBindingDefinitions;

        [Browsable(false)]
        public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1, (techniqueOfVerticalMeasurement)2, (techniqueOfVerticalMeasurement)3, (techniqueOfVerticalMeasurement)4, (techniqueOfVerticalMeasurement)5, (techniqueOfVerticalMeasurement)8, (techniqueOfVerticalMeasurement)9, (techniqueOfVerticalMeasurement)10, (techniqueOfVerticalMeasurement)11, (techniqueOfVerticalMeasurement)12, (techniqueOfVerticalMeasurement)13, (techniqueOfVerticalMeasurement)15, (techniqueOfVerticalMeasurement)16, (techniqueOfVerticalMeasurement)17, (techniqueOfVerticalMeasurement)18];

        [Browsable(false)]
        public visualProminence[] visualProminenceList => [(visualProminence)1, (visualProminence)2, (visualProminence)3];

        [Browsable(false)]
        public status[] statusList => [(status)7, (status)13, (status)18];

        [Browsable(false)]
        public sonarSignalStrength[] sonarSignalStrengthList => [(sonarSignalStrength)501, (sonarSignalStrength)502, (sonarSignalStrength)503, (sonarSignalStrength)504];

        [Browsable(false)]
        public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)6, (natureOfConstruction)7, (natureOfConstruction)8];

        [Browsable(false)]
        public natureOfSurface[] natureOfSurfaceList => [(natureOfSurface)1, (natureOfSurface)2, (natureOfSurface)3, (natureOfSurface)4, (natureOfSurface)5, (natureOfSurface)6, (natureOfSurface)7, (natureOfSurface)8, (natureOfSurface)9, (natureOfSurface)11, (natureOfSurface)14, (natureOfSurface)17, (natureOfSurface)18];

        [Browsable(false)]
        public waterLevelEffect[] waterLevelEffectList => [(waterLevelEffect)1, (waterLevelEffect)2, (waterLevelEffect)3, (waterLevelEffect)4, (waterLevelEffect)5];

        [Browsable(false)]
        public categoryOfWreck[] categoryOfWreckList => [(categoryOfWreck)1, (categoryOfWreck)2, (categoryOfWreck)3, (categoryOfWreck)4, (categoryOfWreck)5];

        [Browsable(false)]
        public qualityOfHorizontalMeasurement[] qualityOfHorizontalMeasurementList => [(qualityOfHorizontalMeasurement)4, (qualityOfHorizontalMeasurement)5];

        [Browsable(false)]
        public qualityOfVerticalMeasurement[] qualityOfVerticalMeasurementList => [(qualityOfVerticalMeasurement)1, (qualityOfVerticalMeasurement)2, (qualityOfVerticalMeasurement)3, (qualityOfVerticalMeasurement)4, (qualityOfVerticalMeasurement)6, (qualityOfVerticalMeasurement)7, (qualityOfVerticalMeasurement)8, (qualityOfVerticalMeasurement)9];

        [Browsable(false)]
        public cardinalPointOrientation[] cardinalPointOrientationList => [(cardinalPointOrientation)501, (cardinalPointOrientation)502, (cardinalPointOrientation)503, (cardinalPointOrientation)504];

        [Browsable(false)]
        public product[] productList => [(product)1, (product)2, (product)3, (product)4, (product)5, (product)6, (product)7, (product)8, (product)9, (product)10, (product)11, (product)12, (product)13, (product)14, (product)15, (product)16, (product)17, (product)18, (product)19, (product)20, (product)21, (product)22, (product)23, (product)24, (product)25];

        [Browsable(false)]
        public expositionOfSounding[] expositionOfSoundingList => [(expositionOfSounding)1, (expositionOfSounding)2, (expositionOfSounding)3];

        public override FeatureViewModel<Wreck> Load(DomainModel.S501.FeatureTypes.Wreck instance) {
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
            return this;
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
    public partial class QRouteViewModel : FeatureViewModel<QRoute> {
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => QRoute._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => QRoute._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)2, (status)503];

        public override FeatureViewModel<QRoute> Load(DomainModel.S501.FeatureTypes.QRoute instance) {
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
            return this;
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
    public partial class CompletenessOfProductSpecificationViewModel : FeatureViewModel<CompletenessOfProductSpecification> {
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
        [DomainModel.EnumerationAttribute(nameof(categoryOfCompletenessList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        public override informationBindingDefinition[] informationBindingDefinitions => CompletenessOfProductSpecification._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => CompletenessOfProductSpecification._featureBindingDefinitions;

        [Browsable(false)]
        public categoryOfCompleteness[] categoryOfCompletenessList => [(categoryOfCompleteness)501, (categoryOfCompleteness)502];

        public override FeatureViewModel<CompletenessOfProductSpecification> Load(DomainModel.S501.FeatureTypes.CompletenessOfProductSpecification instance) {
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
            return this;
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
    public partial class RescueStationViewModel : FeatureViewModel<RescueStation> {
        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(categoryOfRescueStationList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        public override informationBindingDefinition[] informationBindingDefinitions => RescueStation._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => RescueStation._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)4, (status)5, (status)7, (status)8, (status)14, (status)16, (status)17];

        [Browsable(false)]
        public categoryOfRescueStation[] categoryOfRescueStationList => [(categoryOfRescueStation)1, (categoryOfRescueStation)2, (categoryOfRescueStation)4, (categoryOfRescueStation)5, (categoryOfRescueStation)6, (categoryOfRescueStation)7, (categoryOfRescueStation)8];

        public override FeatureViewModel<RescueStation> Load(DomainModel.S501.FeatureTypes.RescueStation instance) {
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
            return this;
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
    public partial class CardinalBeaconViewModel : FeatureViewModel<CardinalBeacon> {
        [Category("CardinalBeacon")]
        public ObservableCollection<information> information { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(natureOfConstructionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("CardinalBeacon")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        private colourPattern? _colourPattern = default;
        [DomainModel.EnumerationAttribute(nameof(colourPatternList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(beaconShapeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(categoryOfCardinalMarkList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("CardinalBeacon")]
        public marksNavigationalSystemOf? marksNavigationalSystemOf {
            get {
                return _marksNavigationalSystemOf;
            }

            set {
                SetValue(ref _marksNavigationalSystemOf, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(colourList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(conditionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(visualProminenceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        public override informationBindingDefinition[] informationBindingDefinitions => CardinalBeacon._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => CardinalBeacon._featureBindingDefinitions;

        [Browsable(false)]
        public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1, (natureOfConstruction)2, (natureOfConstruction)6, (natureOfConstruction)7, (natureOfConstruction)8];

        [Browsable(false)]
        public colourPattern[] colourPatternList => [(colourPattern)1, (colourPattern)2, (colourPattern)3, (colourPattern)4, (colourPattern)5, (colourPattern)6];

        [Browsable(false)]
        public beaconShape[] beaconShapeList => [(beaconShape)1, (beaconShape)2, (beaconShape)3, (beaconShape)5, (beaconShape)6, (beaconShape)7];

        [Browsable(false)]
        public categoryOfCardinalMark[] categoryOfCardinalMarkList => [(categoryOfCardinalMark)1, (categoryOfCardinalMark)2, (categoryOfCardinalMark)3, (categoryOfCardinalMark)4];

        [Browsable(false)]
        public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1, (marksNavigationalSystemOf)2, (marksNavigationalSystemOf)9, (marksNavigationalSystemOf)11];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)4, (status)5, (status)7, (status)8, (status)12, (status)18];

        [Browsable(false)]
        public colour[] colourList => [(colour)1, (colour)2, (colour)3, (colour)4, (colour)5, (colour)6, (colour)7, (colour)8, (colour)9, (colour)10, (colour)11, (colour)12, (colour)13];

        [Browsable(false)]
        public condition[] conditionList => [(condition)1, (condition)2, (condition)3, (condition)5];

        [Browsable(false)]
        public visualProminence[] visualProminenceList => [(visualProminence)1, (visualProminence)2, (visualProminence)3];

        public override FeatureViewModel<CardinalBeacon> Load(DomainModel.S501.FeatureTypes.CardinalBeacon instance) {
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
            return this;
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
    public partial class LightVesselViewModel : FeatureViewModel<LightVessel> {
        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("LightVessel")]
        public ObservableCollection<status> status { get; set; } = new();

        private visualProminence? _visualProminence = default;
        [DomainModel.EnumerationAttribute(nameof(visualProminenceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(natureOfConstructionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(colourList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("LightVessel")]
        public ObservableCollection<colour> colour { get; set; } = new();

        private colourPattern? _colourPattern = default;
        [DomainModel.EnumerationAttribute(nameof(colourPatternList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => LightVessel._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => LightVessel._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)4, (status)5, (status)7, (status)8, (status)14, (status)16, (status)17];

        [Browsable(false)]
        public visualProminence[] visualProminenceList => [(visualProminence)1, (visualProminence)2, (visualProminence)3];

        [Browsable(false)]
        public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)6, (natureOfConstruction)7];

        [Browsable(false)]
        public colour[] colourList => [(colour)1, (colour)2, (colour)3, (colour)4, (colour)5, (colour)6, (colour)7, (colour)8, (colour)9, (colour)10, (colour)11, (colour)12, (colour)13];

        [Browsable(false)]
        public colourPattern[] colourPatternList => [(colourPattern)1, (colourPattern)2, (colourPattern)3, (colourPattern)4, (colourPattern)5, (colourPattern)6];

        public override FeatureViewModel<LightVessel> Load(DomainModel.S501.FeatureTypes.LightVessel instance) {
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
            return this;
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
    public partial class FisheryZoneViewModel : FeatureViewModel<FisheryZone> {
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
        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("FisheryZone")]
        public status? status {
            get {
                return _status;
            }

            set {
                SetValue(ref _status, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => FisheryZone._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => FisheryZone._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)5, (status)6, (status)7, (status)501, (status)502, (status)504, (status)519, (status)521];

        public override FeatureViewModel<FisheryZone> Load(DomainModel.S501.FeatureTypes.FisheryZone instance) {
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
            return this;
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
    public partial class DredgedAreaViewModel : FeatureViewModel<DredgedArea> {
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
        [DomainModel.EnumerationAttribute(nameof(qualityOfVerticalMeasurementList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("DredgedArea")]
        public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement {
            get {
                return _qualityOfVerticalMeasurement;
            }

            set {
                SetValue(ref _qualityOfVerticalMeasurement, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(techniqueOfVerticalMeasurementList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(restrictionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("DredgedArea")]
        public ObservableCollection<restriction> restriction { get; set; } = new();

        [Category("DredgedArea")]
        public ObservableCollection<information> information { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => DredgedArea._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => DredgedArea._featureBindingDefinitions;

        [Browsable(false)]
        public qualityOfVerticalMeasurement[] qualityOfVerticalMeasurementList => [(qualityOfVerticalMeasurement)10, (qualityOfVerticalMeasurement)11];

        [Browsable(false)]
        public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1, (techniqueOfVerticalMeasurement)2, (techniqueOfVerticalMeasurement)3, (techniqueOfVerticalMeasurement)8, (techniqueOfVerticalMeasurement)9, (techniqueOfVerticalMeasurement)13, (techniqueOfVerticalMeasurement)15, (techniqueOfVerticalMeasurement)16, (techniqueOfVerticalMeasurement)17, (techniqueOfVerticalMeasurement)18];

        [Browsable(false)]
        public restriction[] restrictionList => [(restriction)1, (restriction)2, (restriction)3, (restriction)4, (restriction)5, (restriction)6, (restriction)8, (restriction)11, (restriction)12, (restriction)13, (restriction)16, (restriction)17, (restriction)18, (restriction)19, (restriction)20, (restriction)21, (restriction)23, (restriction)25, (restriction)27, (restriction)39];

        public override FeatureViewModel<DredgedArea> Load(DomainModel.S501.FeatureTypes.DredgedArea instance) {
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
            return this;
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
    public partial class FerryRouteViewModel : FeatureViewModel<FerryRoute> {
        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(categoryOfFerryList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => FerryRoute._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => FerryRoute._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)4, (status)5, (status)6, (status)7, (status)8, (status)9, (status)14];

        [Browsable(false)]
        public categoryOfFerry[] categoryOfFerryList => [(categoryOfFerry)1, (categoryOfFerry)2, (categoryOfFerry)3, (categoryOfFerry)5];

        public override FeatureViewModel<FerryRoute> Load(DomainModel.S501.FeatureTypes.FerryRoute instance) {
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

            return this;
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
    public partial class ShorelineConstructionViewModel : FeatureViewModel<ShorelineConstruction> {
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
        [DomainModel.EnumerationAttribute(nameof(gradientOfSlopeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(conditionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(visualProminenceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("ShorelineConstruction")]
        public visualProminence? visualProminence {
            get {
                return _visualProminence;
            }

            set {
                SetValue(ref _visualProminence, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(colourList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(waterLevelEffectList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("ShorelineConstruction")]
        public waterLevelEffect waterLevelEffect {
            get {
                return _waterLevelEffect;
            }

            set {
                SetValue(ref _waterLevelEffect, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(natureOfConstructionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(categoryOfShorelineConstructionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(colourPatternList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => ShorelineConstruction._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => ShorelineConstruction._featureBindingDefinitions;

        [Browsable(false)]
        public gradientOfSlope[] gradientOfSlopeList => [(gradientOfSlope)501, (gradientOfSlope)502, (gradientOfSlope)503, (gradientOfSlope)504, (gradientOfSlope)505];

        [Browsable(false)]
        public condition[] conditionList => [(condition)1, (condition)2, (condition)3, (condition)5];

        [Browsable(false)]
        public visualProminence[] visualProminenceList => [(visualProminence)1, (visualProminence)2, (visualProminence)3];

        [Browsable(false)]
        public colour[] colourList => [(colour)1, (colour)2, (colour)3, (colour)4, (colour)5, (colour)6, (colour)7, (colour)8, (colour)9, (colour)10, (colour)11, (colour)12, (colour)13];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)3, (status)4, (status)6, (status)7, (status)8, (status)12, (status)13, (status)14, (status)28];

        [Browsable(false)]
        public waterLevelEffect[] waterLevelEffectList => [(waterLevelEffect)1, (waterLevelEffect)2, (waterLevelEffect)3, (waterLevelEffect)4, (waterLevelEffect)5, (waterLevelEffect)6, (waterLevelEffect)7];

        [Browsable(false)]
        public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1, (natureOfConstruction)2, (natureOfConstruction)3, (natureOfConstruction)4, (natureOfConstruction)5, (natureOfConstruction)6, (natureOfConstruction)7, (natureOfConstruction)8, (natureOfConstruction)11];

        [Browsable(false)]
        public categoryOfShorelineConstruction[] categoryOfShorelineConstructionList => [(categoryOfShorelineConstruction)1, (categoryOfShorelineConstruction)2, (categoryOfShorelineConstruction)3, (categoryOfShorelineConstruction)4, (categoryOfShorelineConstruction)5, (categoryOfShorelineConstruction)6, (categoryOfShorelineConstruction)7, (categoryOfShorelineConstruction)8, (categoryOfShorelineConstruction)9, (categoryOfShorelineConstruction)10, (categoryOfShorelineConstruction)11, (categoryOfShorelineConstruction)12, (categoryOfShorelineConstruction)13, (categoryOfShorelineConstruction)14, (categoryOfShorelineConstruction)15, (categoryOfShorelineConstruction)16, (categoryOfShorelineConstruction)17, (categoryOfShorelineConstruction)20, (categoryOfShorelineConstruction)22, (categoryOfShorelineConstruction)23, (categoryOfShorelineConstruction)501];

        [Browsable(false)]
        public colourPattern[] colourPatternList => [(colourPattern)1, (colourPattern)2, (colourPattern)3, (colourPattern)4, (colourPattern)5, (colourPattern)6];

        public override FeatureViewModel<ShorelineConstruction> Load(DomainModel.S501.FeatureTypes.ShorelineConstruction instance) {
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
            return this;
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
    public partial class CautionAreaViewModel : FeatureViewModel<CautionArea> {
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
        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(conditionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        public override informationBindingDefinition[] informationBindingDefinitions => CautionArea._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => CautionArea._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)5, (status)7];

        [Browsable(false)]
        public condition[] conditionList => [(condition)1, (condition)3, (condition)5];

        public override FeatureViewModel<CautionArea> Load(DomainModel.S501.FeatureTypes.CautionArea instance) {
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
            return this;
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
    public partial class DeepWaterRoutePartViewModel : FeatureViewModel<DeepWaterRoutePart> {
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
        [DomainModel.EnumerationAttribute(nameof(trafficFlowList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(techniqueOfVerticalMeasurementList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("DeepWaterRoutePart")]
        public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = new();

        [Category("DeepWaterRoutePart")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(restrictionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("DeepWaterRoutePart")]
        public ObservableCollection<restriction> restriction { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(qualityOfVerticalMeasurementList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("DeepWaterRoutePart")]
        public ObservableCollection<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => DeepWaterRoutePart._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => DeepWaterRoutePart._featureBindingDefinitions;

        [Browsable(false)]
        public trafficFlow[] trafficFlowList => [(trafficFlow)1, (trafficFlow)2, (trafficFlow)3, (trafficFlow)4];

        [Browsable(false)]
        public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1, (techniqueOfVerticalMeasurement)3, (techniqueOfVerticalMeasurement)5, (techniqueOfVerticalMeasurement)8, (techniqueOfVerticalMeasurement)9, (techniqueOfVerticalMeasurement)13, (techniqueOfVerticalMeasurement)15, (techniqueOfVerticalMeasurement)16, (techniqueOfVerticalMeasurement)17, (techniqueOfVerticalMeasurement)18];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)3, (status)6, (status)9, (status)28];

        [Browsable(false)]
        public restriction[] restrictionList => [(restriction)1, (restriction)2, (restriction)3, (restriction)4, (restriction)5, (restriction)6, (restriction)8, (restriction)9, (restriction)10, (restriction)11, (restriction)12, (restriction)13, (restriction)16, (restriction)17, (restriction)18, (restriction)19, (restriction)20, (restriction)21, (restriction)22, (restriction)23, (restriction)24, (restriction)25, (restriction)27];

        [Browsable(false)]
        public qualityOfVerticalMeasurement[] qualityOfVerticalMeasurementList => [(qualityOfVerticalMeasurement)1, (qualityOfVerticalMeasurement)2, (qualityOfVerticalMeasurement)3, (qualityOfVerticalMeasurement)4, (qualityOfVerticalMeasurement)6, (qualityOfVerticalMeasurement)7];

        public override FeatureViewModel<DeepWaterRoutePart> Load(DomainModel.S501.FeatureTypes.DeepWaterRoutePart instance) {
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
            return this;
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
    public partial class CurrentNonGravitationalViewModel : FeatureViewModel<CurrentNonGravitational> {
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
        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("CurrentNonGravitational")]
        public status? status {
            get {
                return _status;
            }

            set {
                SetValue(ref _status, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => CurrentNonGravitational._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => CurrentNonGravitational._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)5];

        public override FeatureViewModel<CurrentNonGravitational> Load(DomainModel.S501.FeatureTypes.CurrentNonGravitational instance) {
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
            return this;
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
    public partial class DataCoverageViewModel : FeatureViewModel<DataCoverage> {
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
        [DomainModel.EnumerationAttribute(nameof(categoryOfCoverageList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => DataCoverage._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => DataCoverage._featureBindingDefinitions;

        [Browsable(false)]
        public categoryOfCoverage[] categoryOfCoverageList => [(categoryOfCoverage)1, (categoryOfCoverage)2];

        public override FeatureViewModel<DataCoverage> Load(DomainModel.S501.FeatureTypes.DataCoverage instance) {
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
            return this;
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
    public partial class SeabedAreaViewModel : FeatureViewModel<SeabedArea> {
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
        [DomainModel.EnumerationAttribute(nameof(waterLevelEffectList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => SeabedArea._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => SeabedArea._featureBindingDefinitions;

        [Browsable(false)]
        public waterLevelEffect[] waterLevelEffectList => [(waterLevelEffect)3, (waterLevelEffect)4, (waterLevelEffect)5];

        public override FeatureViewModel<SeabedArea> Load(DomainModel.S501.FeatureTypes.SeabedArea instance) {
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
            return this;
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
    public partial class SpecialPurposeGeneralBuoyViewModel : FeatureViewModel<SpecialPurposeGeneralBuoy> {
        [Category("SpecialPurposeGeneralBuoy")]
        public ObservableCollection<information> information { get; set; } = new();

        private buoyShape _buoyShape;
        [DomainModel.EnumerationAttribute(nameof(buoyShapeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(colourPatternList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("SpecialPurposeGeneralBuoy")]
        public colourPattern? colourPattern {
            get {
                return _colourPattern;
            }

            set {
                SetValue(ref _colourPattern, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(categoryOfSpecialPurposeMarkList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(colourList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("SpecialPurposeGeneralBuoy")]
        public ObservableCollection<colour> colour { get; set; } = new();

        private marksNavigationalSystemOf? _marksNavigationalSystemOf = default;
        [DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("SpecialPurposeGeneralBuoy")]
        public marksNavigationalSystemOf? marksNavigationalSystemOf {
            get {
                return _marksNavigationalSystemOf;
            }

            set {
                SetValue(ref _marksNavigationalSystemOf, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(natureOfConstructionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        public override informationBindingDefinition[] informationBindingDefinitions => SpecialPurposeGeneralBuoy._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => SpecialPurposeGeneralBuoy._featureBindingDefinitions;

        [Browsable(false)]
        public buoyShape[] buoyShapeList => [(buoyShape)1, (buoyShape)2, (buoyShape)3, (buoyShape)4, (buoyShape)5, (buoyShape)6, (buoyShape)7, (buoyShape)8];

        [Browsable(false)]
        public colourPattern[] colourPatternList => [(colourPattern)1, (colourPattern)2, (colourPattern)3, (colourPattern)4, (colourPattern)5, (colourPattern)6];

        [Browsable(false)]
        public categoryOfSpecialPurposeMark[] categoryOfSpecialPurposeMarkList => [(categoryOfSpecialPurposeMark)1, (categoryOfSpecialPurposeMark)2, (categoryOfSpecialPurposeMark)3, (categoryOfSpecialPurposeMark)4, (categoryOfSpecialPurposeMark)5, (categoryOfSpecialPurposeMark)6, (categoryOfSpecialPurposeMark)7, (categoryOfSpecialPurposeMark)8, (categoryOfSpecialPurposeMark)9, (categoryOfSpecialPurposeMark)10, (categoryOfSpecialPurposeMark)11, (categoryOfSpecialPurposeMark)12, (categoryOfSpecialPurposeMark)14, (categoryOfSpecialPurposeMark)15, (categoryOfSpecialPurposeMark)17, (categoryOfSpecialPurposeMark)18, (categoryOfSpecialPurposeMark)19, (categoryOfSpecialPurposeMark)20, (categoryOfSpecialPurposeMark)21, (categoryOfSpecialPurposeMark)22, (categoryOfSpecialPurposeMark)23, (categoryOfSpecialPurposeMark)24, (categoryOfSpecialPurposeMark)25, (categoryOfSpecialPurposeMark)26, (categoryOfSpecialPurposeMark)27, (categoryOfSpecialPurposeMark)28, (categoryOfSpecialPurposeMark)29, (categoryOfSpecialPurposeMark)30, (categoryOfSpecialPurposeMark)31, (categoryOfSpecialPurposeMark)32, (categoryOfSpecialPurposeMark)33, (categoryOfSpecialPurposeMark)34, (categoryOfSpecialPurposeMark)35, (categoryOfSpecialPurposeMark)36, (categoryOfSpecialPurposeMark)37, (categoryOfSpecialPurposeMark)39, (categoryOfSpecialPurposeMark)40, (categoryOfSpecialPurposeMark)42, (categoryOfSpecialPurposeMark)43, (categoryOfSpecialPurposeMark)45, (categoryOfSpecialPurposeMark)46, (categoryOfSpecialPurposeMark)47, (categoryOfSpecialPurposeMark)48, (categoryOfSpecialPurposeMark)49, (categoryOfSpecialPurposeMark)50, (categoryOfSpecialPurposeMark)51, (categoryOfSpecialPurposeMark)52, (categoryOfSpecialPurposeMark)53, (categoryOfSpecialPurposeMark)54, (categoryOfSpecialPurposeMark)55, (categoryOfSpecialPurposeMark)56, (categoryOfSpecialPurposeMark)57, (categoryOfSpecialPurposeMark)58, (categoryOfSpecialPurposeMark)59, (categoryOfSpecialPurposeMark)60, (categoryOfSpecialPurposeMark)61, (categoryOfSpecialPurposeMark)62, (categoryOfSpecialPurposeMark)63];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)5, (status)7, (status)8, (status)18, (status)503];

        [Browsable(false)]
        public colour[] colourList => [(colour)1, (colour)2, (colour)3, (colour)4, (colour)5, (colour)6, (colour)7, (colour)8, (colour)9, (colour)10, (colour)11, (colour)12, (colour)13];

        [Browsable(false)]
        public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1, (marksNavigationalSystemOf)2, (marksNavigationalSystemOf)9, (marksNavigationalSystemOf)11];

        [Browsable(false)]
        public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)6, (natureOfConstruction)7, (natureOfConstruction)8, (natureOfConstruction)11];

        public override FeatureViewModel<SpecialPurposeGeneralBuoy> Load(DomainModel.S501.FeatureTypes.SpecialPurposeGeneralBuoy instance) {
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
            return this;
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
    public partial class LightSectoredViewModel : FeatureViewModel<LightSectored> {
        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(categoryOfLightList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("LightSectored")]
        public ObservableCollection<categoryOfLight> categoryOfLight { get; set; } = new();

        private exhibitionConditionOfLight? _exhibitionConditionOfLight = default;
        [DomainModel.EnumerationAttribute(nameof(exhibitionConditionOfLightList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(heightLengthUnitsList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(verticalDatumList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(signalGenerationList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        public override informationBindingDefinition[] informationBindingDefinitions => LightSectored._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => LightSectored._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)4, (status)5, (status)6, (status)7, (status)8, (status)11, (status)14, (status)15, (status)16, (status)17];

        [Browsable(false)]
        public categoryOfLight[] categoryOfLightList => [(categoryOfLight)4, (categoryOfLight)5, (categoryOfLight)8, (categoryOfLight)9, (categoryOfLight)10, (categoryOfLight)11, (categoryOfLight)12, (categoryOfLight)13, (categoryOfLight)14, (categoryOfLight)15, (categoryOfLight)17, (categoryOfLight)18, (categoryOfLight)19, (categoryOfLight)20];

        [Browsable(false)]
        public exhibitionConditionOfLight[] exhibitionConditionOfLightList => [(exhibitionConditionOfLight)1, (exhibitionConditionOfLight)2, (exhibitionConditionOfLight)4];

        [Browsable(false)]
        public heightLengthUnits[] heightLengthUnitsList => [(heightLengthUnits)1];

        [Browsable(false)]
        public verticalDatum[] verticalDatumList => [(verticalDatum)3, (verticalDatum)16, (verticalDatum)17, (verticalDatum)18, (verticalDatum)19, (verticalDatum)20, (verticalDatum)21, (verticalDatum)24, (verticalDatum)25, (verticalDatum)26, (verticalDatum)28, (verticalDatum)29, (verticalDatum)30, (verticalDatum)44];

        [Browsable(false)]
        public signalGeneration[] signalGenerationList => [(signalGeneration)5, (signalGeneration)6];

        [Browsable(false)]
        public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1, (marksNavigationalSystemOf)2, (marksNavigationalSystemOf)9, (marksNavigationalSystemOf)11];

        public override FeatureViewModel<LightSectored> Load(DomainModel.S501.FeatureTypes.LightSectored instance) {
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
            return this;
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
    public partial class IceLineViewModel : FeatureViewModel<IceLine> {
        [Category("IceLine")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("IceLine")]
        public ObservableCollection<featureName> featureName { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => IceLine._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => IceLine._featureBindingDefinitions;

        public override FeatureViewModel<IceLine> Load(DomainModel.S501.FeatureTypes.IceLine instance) {
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            return this;
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
    public partial class AnchorageAreaViewModel : FeatureViewModel<AnchorageArea> {
        [DomainModel.EnumerationAttribute(nameof(restrictionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(categoryOfAnchorageList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("AnchorageArea")]
        public ObservableCollection<status> status { get; set; } = new();

        [Category("AnchorageArea")]
        public ObservableCollection<information> information { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(categoryOfCargoList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("AnchorageArea")]
        public ObservableCollection<categoryOfCargo> categoryOfCargo { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => AnchorageArea._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => AnchorageArea._featureBindingDefinitions;

        [Browsable(false)]
        public restriction[] restrictionList => [(restriction)2, (restriction)3, (restriction)4, (restriction)5, (restriction)6, (restriction)8, (restriction)9, (restriction)10, (restriction)11, (restriction)12, (restriction)13, (restriction)15, (restriction)16, (restriction)17, (restriction)18, (restriction)19, (restriction)20, (restriction)21, (restriction)23, (restriction)24, (restriction)27, (restriction)39];

        [Browsable(false)]
        public categoryOfAnchorage[] categoryOfAnchorageList => [(categoryOfAnchorage)1, (categoryOfAnchorage)2, (categoryOfAnchorage)3, (categoryOfAnchorage)5, (categoryOfAnchorage)6, (categoryOfAnchorage)7, (categoryOfAnchorage)9, (categoryOfAnchorage)10, (categoryOfAnchorage)14, (categoryOfAnchorage)15];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)3, (status)5, (status)6, (status)7, (status)8, (status)9, (status)14];

        [Browsable(false)]
        public categoryOfCargo[] categoryOfCargoList => [(categoryOfCargo)1, (categoryOfCargo)2, (categoryOfCargo)3, (categoryOfCargo)4, (categoryOfCargo)5, (categoryOfCargo)6, (categoryOfCargo)7, (categoryOfCargo)8, (categoryOfCargo)9, (categoryOfCargo)10, (categoryOfCargo)11, (categoryOfCargo)12, (categoryOfCargo)13, (categoryOfCargo)14, (categoryOfCargo)15];

        public override FeatureViewModel<AnchorageArea> Load(DomainModel.S501.FeatureTypes.AnchorageArea instance) {
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
            return this;
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
    public partial class LateralBuoyViewModel : FeatureViewModel<LateralBuoy> {
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

        [DomainModel.EnumerationAttribute(nameof(colourList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("LateralBuoy")]
        public ObservableCollection<status> status { get; set; } = new();

        private categoryOfLateralMark _categoryOfLateralMark;
        [DomainModel.EnumerationAttribute(nameof(categoryOfLateralMarkList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(colourPatternList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(buoyShapeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(natureOfConstructionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("LateralBuoy")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        private marksNavigationalSystemOf? _marksNavigationalSystemOf = default;
        [DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => LateralBuoy._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => LateralBuoy._featureBindingDefinitions;

        [Browsable(false)]
        public colour[] colourList => [(colour)1, (colour)2, (colour)3, (colour)4, (colour)5, (colour)6, (colour)7, (colour)8, (colour)9, (colour)10, (colour)11, (colour)12, (colour)13];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)5, (status)7, (status)8, (status)18];

        [Browsable(false)]
        public categoryOfLateralMark[] categoryOfLateralMarkList => [(categoryOfLateralMark)1, (categoryOfLateralMark)2, (categoryOfLateralMark)3, (categoryOfLateralMark)4];

        [Browsable(false)]
        public colourPattern[] colourPatternList => [(colourPattern)1, (colourPattern)2, (colourPattern)3, (colourPattern)4, (colourPattern)5, (colourPattern)6];

        [Browsable(false)]
        public buoyShape[] buoyShapeList => [(buoyShape)1, (buoyShape)2, (buoyShape)3, (buoyShape)4, (buoyShape)5, (buoyShape)6, (buoyShape)7, (buoyShape)8];

        [Browsable(false)]
        public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)6, (natureOfConstruction)7, (natureOfConstruction)8, (natureOfConstruction)11];

        [Browsable(false)]
        public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1, (marksNavigationalSystemOf)2, (marksNavigationalSystemOf)9, (marksNavigationalSystemOf)11];

        public override FeatureViewModel<LateralBuoy> Load(DomainModel.S501.FeatureTypes.LateralBuoy instance) {
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
            return this;
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
    public partial class TrafficSeparationSchemeRoundaboutViewModel : FeatureViewModel<TrafficSeparationSchemeRoundabout> {
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(restrictionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("TrafficSeparationSchemeRoundabout")]
        public ObservableCollection<restriction> restriction { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationSchemeRoundabout._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeRoundabout._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)3, (status)6, (status)9];

        [Browsable(false)]
        public restriction[] restrictionList => [(restriction)1, (restriction)2, (restriction)3, (restriction)4, (restriction)5, (restriction)6, (restriction)8, (restriction)9, (restriction)10, (restriction)11, (restriction)12, (restriction)13, (restriction)16, (restriction)17, (restriction)18, (restriction)19, (restriction)20, (restriction)21, (restriction)22, (restriction)23, (restriction)24, (restriction)25, (restriction)27];

        public override FeatureViewModel<TrafficSeparationSchemeRoundabout> Load(DomainModel.S501.FeatureTypes.TrafficSeparationSchemeRoundabout instance) {
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
            return this;
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
    public partial class DeepWaterRouteCentrelineViewModel : FeatureViewModel<DeepWaterRouteCentreline> {
        [DomainModel.EnumerationAttribute(nameof(qualityOfVerticalMeasurementList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(trafficFlowList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(techniqueOfVerticalMeasurementList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("DeepWaterRouteCentreline")]
        public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => DeepWaterRouteCentreline._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => DeepWaterRouteCentreline._featureBindingDefinitions;

        [Browsable(false)]
        public qualityOfVerticalMeasurement[] qualityOfVerticalMeasurementList => [(qualityOfVerticalMeasurement)1, (qualityOfVerticalMeasurement)2, (qualityOfVerticalMeasurement)3, (qualityOfVerticalMeasurement)4, (qualityOfVerticalMeasurement)6, (qualityOfVerticalMeasurement)7];

        [Browsable(false)]
        public trafficFlow[] trafficFlowList => [(trafficFlow)1, (trafficFlow)2, (trafficFlow)3, (trafficFlow)4];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)3, (status)6, (status)9];

        [Browsable(false)]
        public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1, (techniqueOfVerticalMeasurement)3, (techniqueOfVerticalMeasurement)5, (techniqueOfVerticalMeasurement)8, (techniqueOfVerticalMeasurement)9, (techniqueOfVerticalMeasurement)13, (techniqueOfVerticalMeasurement)15, (techniqueOfVerticalMeasurement)16, (techniqueOfVerticalMeasurement)17, (techniqueOfVerticalMeasurement)18];

        public override FeatureViewModel<DeepWaterRouteCentreline> Load(DomainModel.S501.FeatureTypes.DeepWaterRouteCentreline instance) {
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
            return this;
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
    public partial class LightFloatViewModel : FeatureViewModel<LightFloat> {
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("LightFloat")]
        public ObservableCollection<status> status { get; set; } = new();

        private colourPattern? _colourPattern = default;
        [DomainModel.EnumerationAttribute(nameof(colourPatternList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(natureOfConstructionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("LightFloat")]
        public ObservableCollection<natureOfConstruction> natureOfConstruction { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(colourList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(visualProminenceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        public override informationBindingDefinition[] informationBindingDefinitions => LightFloat._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => LightFloat._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)4, (status)5, (status)7, (status)8, (status)14, (status)16, (status)17];

        [Browsable(false)]
        public colourPattern[] colourPatternList => [(colourPattern)1, (colourPattern)2, (colourPattern)3, (colourPattern)4, (colourPattern)5, (colourPattern)6];

        [Browsable(false)]
        public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)6, (natureOfConstruction)7, (natureOfConstruction)11];

        [Browsable(false)]
        public colour[] colourList => [(colour)1, (colour)2, (colour)3, (colour)4, (colour)5, (colour)6, (colour)7, (colour)8, (colour)9, (colour)10, (colour)11, (colour)12, (colour)13];

        [Browsable(false)]
        public visualProminence[] visualProminenceList => [(visualProminence)1, (visualProminence)2, (visualProminence)3];

        public override FeatureViewModel<LightFloat> Load(DomainModel.S501.FeatureTypes.LightFloat instance) {
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
            return this;
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
    public partial class LightAllAroundViewModel : FeatureViewModel<LightAllAround> {
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
        [DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(signalGenerationList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(exhibitionConditionOfLightList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(verticalDatumList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(lightVisibilityList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(heightLengthUnitsList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("LightAllAround")]
        public heightLengthUnits? heightLengthUnits {
            get {
                return _heightLengthUnits;
            }

            set {
                SetValue(ref _heightLengthUnits, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(categoryOfLightList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(colourList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("LightAllAround")]
        public ObservableCollection<colour> colour { get; set; } = new();

        [Category("LightAllAround")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("LightAllAround")]
        public ObservableCollection<featureName> featureName { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => LightAllAround._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => LightAllAround._featureBindingDefinitions;

        [Browsable(false)]
        public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1, (marksNavigationalSystemOf)2, (marksNavigationalSystemOf)9, (marksNavigationalSystemOf)11];

        [Browsable(false)]
        public signalGeneration[] signalGenerationList => [(signalGeneration)5, (signalGeneration)6];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)4, (status)5, (status)6, (status)7, (status)8, (status)11, (status)14, (status)15, (status)16, (status)17];

        [Browsable(false)]
        public exhibitionConditionOfLight[] exhibitionConditionOfLightList => [(exhibitionConditionOfLight)1, (exhibitionConditionOfLight)2, (exhibitionConditionOfLight)3, (exhibitionConditionOfLight)4];

        [Browsable(false)]
        public verticalDatum[] verticalDatumList => [(verticalDatum)3, (verticalDatum)16, (verticalDatum)17, (verticalDatum)18, (verticalDatum)19, (verticalDatum)20, (verticalDatum)21, (verticalDatum)24, (verticalDatum)25, (verticalDatum)26, (verticalDatum)28, (verticalDatum)29, (verticalDatum)30, (verticalDatum)44];

        [Browsable(false)]
        public lightVisibility[] lightVisibilityList => [(lightVisibility)1, (lightVisibility)2];

        [Browsable(false)]
        public heightLengthUnits[] heightLengthUnitsList => [(heightLengthUnits)1];

        [Browsable(false)]
        public categoryOfLight[] categoryOfLightList => [(categoryOfLight)4, (categoryOfLight)5, (categoryOfLight)8, (categoryOfLight)9, (categoryOfLight)10, (categoryOfLight)11, (categoryOfLight)12, (categoryOfLight)13, (categoryOfLight)14, (categoryOfLight)15, (categoryOfLight)17, (categoryOfLight)18, (categoryOfLight)19, (categoryOfLight)20];

        [Browsable(false)]
        public colour[] colourList => [(colour)1, (colour)3, (colour)4, (colour)5, (colour)6, (colour)9, (colour)10, (colour)11];

        public override FeatureViewModel<LightAllAround> Load(DomainModel.S501.FeatureTypes.LightAllAround instance) {
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
            return this;
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
    public partial class CoastlineViewModel : FeatureViewModel<Coastline> {
        [DomainModel.EnumerationAttribute(nameof(colourList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("Coastline")]
        public ObservableCollection<colour> colour { get; set; } = new();

        [Category("Coastline")]
        public ObservableCollection<information> information { get; set; } = new();

        private categoryOfCoastline? _categoryOfCoastline = default;
        [DomainModel.EnumerationAttribute(nameof(categoryOfCoastlineList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(natureOfSurfaceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("Coastline")]
        public ObservableCollection<natureOfSurface> natureOfSurface { get; set; } = new();

        [Category("Coastline")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private visualProminence? _visualProminence = default;
        [DomainModel.EnumerationAttribute(nameof(visualProminenceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => Coastline._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => Coastline._featureBindingDefinitions;

        [Browsable(false)]
        public colour[] colourList => [(colour)1, (colour)2, (colour)3, (colour)4, (colour)6, (colour)7, (colour)8, (colour)11, (colour)13];

        [Browsable(false)]
        public categoryOfCoastline[] categoryOfCoastlineList => [(categoryOfCoastline)1, (categoryOfCoastline)2, (categoryOfCoastline)6, (categoryOfCoastline)7, (categoryOfCoastline)8, (categoryOfCoastline)10];

        [Browsable(false)]
        public natureOfSurface[] natureOfSurfaceList => [(natureOfSurface)1, (natureOfSurface)2, (natureOfSurface)3, (natureOfSurface)4, (natureOfSurface)5, (natureOfSurface)6, (natureOfSurface)7, (natureOfSurface)8, (natureOfSurface)9, (natureOfSurface)11, (natureOfSurface)14, (natureOfSurface)17];

        [Browsable(false)]
        public visualProminence[] visualProminenceList => [(visualProminence)1, (visualProminence)2, (visualProminence)3];

        public override FeatureViewModel<Coastline> Load(DomainModel.S501.FeatureTypes.Coastline instance) {
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
            return this;
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
    public partial class SeaAreaNamedWaterAreaViewModel : FeatureViewModel<SeaAreaNamedWaterArea> {
        private categoryOfSeaArea? _categoryOfSeaArea = default;
        [DomainModel.EnumerationAttribute(nameof(categoryOfSeaAreaList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(gradientList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(qualityOfHorizontalMeasurementList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("SeaAreaNamedWaterArea")]
        public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement {
            get {
                return _qualityOfHorizontalMeasurement;
            }

            set {
                SetValue(ref _qualityOfHorizontalMeasurement, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => SeaAreaNamedWaterArea._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => SeaAreaNamedWaterArea._featureBindingDefinitions;

        [Browsable(false)]
        public categoryOfSeaArea[] categoryOfSeaAreaList => [(categoryOfSeaArea)2, (categoryOfSeaArea)3, (categoryOfSeaArea)4, (categoryOfSeaArea)5, (categoryOfSeaArea)6, (categoryOfSeaArea)7, (categoryOfSeaArea)8, (categoryOfSeaArea)9, (categoryOfSeaArea)10, (categoryOfSeaArea)11, (categoryOfSeaArea)12, (categoryOfSeaArea)13, (categoryOfSeaArea)14, (categoryOfSeaArea)15, (categoryOfSeaArea)16, (categoryOfSeaArea)17, (categoryOfSeaArea)18, (categoryOfSeaArea)19, (categoryOfSeaArea)20, (categoryOfSeaArea)21, (categoryOfSeaArea)22, (categoryOfSeaArea)23, (categoryOfSeaArea)24, (categoryOfSeaArea)25, (categoryOfSeaArea)26, (categoryOfSeaArea)27, (categoryOfSeaArea)28, (categoryOfSeaArea)29, (categoryOfSeaArea)30, (categoryOfSeaArea)31, (categoryOfSeaArea)32, (categoryOfSeaArea)33, (categoryOfSeaArea)34, (categoryOfSeaArea)35, (categoryOfSeaArea)36, (categoryOfSeaArea)37, (categoryOfSeaArea)38, (categoryOfSeaArea)39, (categoryOfSeaArea)40, (categoryOfSeaArea)41, (categoryOfSeaArea)42, (categoryOfSeaArea)43, (categoryOfSeaArea)44, (categoryOfSeaArea)45, (categoryOfSeaArea)46, (categoryOfSeaArea)47, (categoryOfSeaArea)48, (categoryOfSeaArea)49, (categoryOfSeaArea)50, (categoryOfSeaArea)51, (categoryOfSeaArea)52, (categoryOfSeaArea)53, (categoryOfSeaArea)54, (categoryOfSeaArea)55, (categoryOfSeaArea)56];

        [Browsable(false)]
        public gradient[] gradientList => [(gradient)501, (gradient)502, (gradient)503, (gradient)504, (gradient)505];

        [Browsable(false)]
        public qualityOfHorizontalMeasurement[] qualityOfHorizontalMeasurementList => [(qualityOfHorizontalMeasurement)4];

        public override FeatureViewModel<SeaAreaNamedWaterArea> Load(DomainModel.S501.FeatureTypes.SeaAreaNamedWaterArea instance) {
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
            return this;
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
    public partial class DropZoneViewModel : FeatureViewModel<DropZone> {
        [Category("DropZone")]
        public ObservableCollection<information> information { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => DropZone._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => DropZone._featureBindingDefinitions;

        public override FeatureViewModel<DropZone> Load(DomainModel.S501.FeatureTypes.DropZone instance) {
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            return this;
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
    public partial class ConveyorViewModel : FeatureViewModel<Conveyor> {
        private categoryOfConveyor? _categoryOfConveyor = default;
        [DomainModel.EnumerationAttribute(nameof(categoryOfConveyorList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(conditionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(colourList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("Conveyor")]
        public ObservableCollection<colour> colour { get; set; } = new();

        [Category("Conveyor")]
        public ObservableCollection<information> information { get; set; } = new();

        private visualProminence? _visualProminence = default;
        [DomainModel.EnumerationAttribute(nameof(visualProminenceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(verticalDatumList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(colourPatternList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(productList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => Conveyor._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => Conveyor._featureBindingDefinitions;

        [Browsable(false)]
        public categoryOfConveyor[] categoryOfConveyorList => [(categoryOfConveyor)1, (categoryOfConveyor)2, (categoryOfConveyor)3, (categoryOfConveyor)4];

        [Browsable(false)]
        public condition[] conditionList => [(condition)1, (condition)2, (condition)5];

        [Browsable(false)]
        public colour[] colourList => [(colour)1, (colour)2, (colour)3, (colour)4, (colour)5, (colour)6, (colour)7, (colour)8, (colour)9, (colour)10, (colour)11, (colour)12, (colour)13];

        [Browsable(false)]
        public visualProminence[] visualProminenceList => [(visualProminence)1, (visualProminence)2, (visualProminence)3];

        [Browsable(false)]
        public status[] statusList => [(status)4, (status)12];

        [Browsable(false)]
        public verticalDatum[] verticalDatumList => [(verticalDatum)3, (verticalDatum)13, (verticalDatum)16, (verticalDatum)17, (verticalDatum)18, (verticalDatum)19, (verticalDatum)20, (verticalDatum)21, (verticalDatum)24, (verticalDatum)25, (verticalDatum)26, (verticalDatum)28, (verticalDatum)29, (verticalDatum)30, (verticalDatum)44];

        [Browsable(false)]
        public colourPattern[] colourPatternList => [(colourPattern)1, (colourPattern)2, (colourPattern)3, (colourPattern)4, (colourPattern)5, (colourPattern)6];

        [Browsable(false)]
        public product[] productList => [(product)4, (product)5, (product)6, (product)10, (product)11, (product)12, (product)13, (product)14, (product)15, (product)16, (product)17, (product)22, (product)25];

        public override FeatureViewModel<Conveyor> Load(DomainModel.S501.FeatureTypes.Conveyor instance) {
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
            return this;
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
    public partial class LineOfDelimitationViewModel : FeatureViewModel<LineOfDelimitation> {
        [Category("LineOfDelimitation")]
        public ObservableCollection<String> nationalMaritimeAuthority { get; set; } = new();

        private boundaryStatusType? _boundaryStatusType = default;
        [DomainModel.EnumerationAttribute(nameof(boundaryStatusTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(jurisdictionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(categoryofBoundaryLineList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => LineOfDelimitation._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => LineOfDelimitation._featureBindingDefinitions;

        [Browsable(false)]
        public boundaryStatusType[] boundaryStatusTypeList => [(boundaryStatusType)501, (boundaryStatusType)502, (boundaryStatusType)504, (boundaryStatusType)599];

        [Browsable(false)]
        public jurisdiction[] jurisdictionList => [(jurisdiction)1, (jurisdiction)2, (jurisdiction)3];

        [Browsable(false)]
        public categoryofBoundaryLine[] categoryofBoundaryLineList => [(categoryofBoundaryLine)501, (categoryofBoundaryLine)506, (categoryofBoundaryLine)511, (categoryofBoundaryLine)599];

        public override FeatureViewModel<LineOfDelimitation> Load(DomainModel.S501.FeatureTypes.LineOfDelimitation instance) {
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
            return this;
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
    public partial class StraightTerritorialSeaBaselineViewModel : FeatureViewModel<StraightTerritorialSeaBaseline> {
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
        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        public override informationBindingDefinition[] informationBindingDefinitions => StraightTerritorialSeaBaseline._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => StraightTerritorialSeaBaseline._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)502, (status)504];

        public override FeatureViewModel<StraightTerritorialSeaBaseline> Load(DomainModel.S501.FeatureTypes.StraightTerritorialSeaBaseline instance) {
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
            return this;
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
    public partial class SafeWaterBeaconViewModel : FeatureViewModel<SafeWaterBeacon> {
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

        [DomainModel.EnumerationAttribute(nameof(natureOfConstructionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(conditionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(colourPatternList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(beaconShapeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("SafeWaterBeacon")]
        public beaconShape beaconShape {
            get {
                return _beaconShape;
            }

            set {
                SetValue(ref _beaconShape, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(colourList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("SafeWaterBeacon")]
        public ObservableCollection<colour> colour { get; set; } = new();

        private visualProminence? _visualProminence = default;
        [DomainModel.EnumerationAttribute(nameof(visualProminenceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("SafeWaterBeacon")]
        public visualProminence? visualProminence {
            get {
                return _visualProminence;
            }

            set {
                SetValue(ref _visualProminence, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => SafeWaterBeacon._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => SafeWaterBeacon._featureBindingDefinitions;

        [Browsable(false)]
        public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1, (natureOfConstruction)2, (natureOfConstruction)6, (natureOfConstruction)7, (natureOfConstruction)8];

        [Browsable(false)]
        public condition[] conditionList => [(condition)1, (condition)2, (condition)5];

        [Browsable(false)]
        public colourPattern[] colourPatternList => [(colourPattern)1, (colourPattern)2, (colourPattern)3, (colourPattern)4, (colourPattern)5, (colourPattern)6];

        [Browsable(false)]
        public beaconShape[] beaconShapeList => [(beaconShape)1, (beaconShape)2, (beaconShape)3, (beaconShape)4, (beaconShape)5, (beaconShape)6, (beaconShape)7];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)5, (status)7, (status)8, (status)12, (status)18];

        [Browsable(false)]
        public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1, (marksNavigationalSystemOf)2, (marksNavigationalSystemOf)9, (marksNavigationalSystemOf)11];

        [Browsable(false)]
        public colour[] colourList => [(colour)1, (colour)2, (colour)3, (colour)4, (colour)5, (colour)6, (colour)7, (colour)8, (colour)9, (colour)10, (colour)11, (colour)12, (colour)13];

        [Browsable(false)]
        public visualProminence[] visualProminenceList => [(visualProminence)1, (visualProminence)2, (visualProminence)3];

        public override FeatureViewModel<SafeWaterBeacon> Load(DomainModel.S501.FeatureTypes.SafeWaterBeacon instance) {
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
            return this;
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
    public partial class SpecialPurposeGeneralBeaconViewModel : FeatureViewModel<SpecialPurposeGeneralBeacon> {
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

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("SpecialPurposeGeneralBeacon")]
        public ObservableCollection<status> status { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(natureOfConstructionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(conditionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(colourPatternList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(beaconShapeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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

        [DomainModel.EnumerationAttribute(nameof(categoryOfSpecialPurposeMarkList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("SpecialPurposeGeneralBeacon")]
        public ObservableCollection<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark { get; set; } = new();

        private marksNavigationalSystemOf? _marksNavigationalSystemOf = default;
        [DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
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
        [DomainModel.EnumerationAttribute(nameof(visualProminenceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("SpecialPurposeGeneralBeacon")]
        public visualProminence? visualProminence {
            get {
                return _visualProminence;
            }

            set {
                SetValue(ref _visualProminence, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(colourList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("SpecialPurposeGeneralBeacon")]
        public ObservableCollection<colour> colour { get; set; } = new();

        [Category("SpecialPurposeGeneralBeacon")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        [Category("SpecialPurposeGeneralBeacon")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => SpecialPurposeGeneralBeacon._informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => SpecialPurposeGeneralBeacon._featureBindingDefinitions;

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)4, (status)5, (status)7, (status)8, (status)12, (status)18];

        [Browsable(false)]
        public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1, (natureOfConstruction)2, (natureOfConstruction)6, (natureOfConstruction)7, (natureOfConstruction)8];

        [Browsable(false)]
        public condition[] conditionList => [(condition)1, (condition)2, (condition)5];

        [Browsable(false)]
        public colourPattern[] colourPatternList => [(colourPattern)1, (colourPattern)2, (colourPattern)3, (colourPattern)4, (colourPattern)5, (colourPattern)6];

        [Browsable(false)]
        public beaconShape[] beaconShapeList => [(beaconShape)1, (beaconShape)2, (beaconShape)3, (beaconShape)4, (beaconShape)5, (beaconShape)6, (beaconShape)7];

        [Browsable(false)]
        public categoryOfSpecialPurposeMark[] categoryOfSpecialPurposeMarkList => [(categoryOfSpecialPurposeMark)1, (categoryOfSpecialPurposeMark)2, (categoryOfSpecialPurposeMark)3, (categoryOfSpecialPurposeMark)4, (categoryOfSpecialPurposeMark)5, (categoryOfSpecialPurposeMark)6, (categoryOfSpecialPurposeMark)7, (categoryOfSpecialPurposeMark)8, (categoryOfSpecialPurposeMark)10, (categoryOfSpecialPurposeMark)11, (categoryOfSpecialPurposeMark)12, (categoryOfSpecialPurposeMark)14, (categoryOfSpecialPurposeMark)16, (categoryOfSpecialPurposeMark)17, (categoryOfSpecialPurposeMark)18, (categoryOfSpecialPurposeMark)19, (categoryOfSpecialPurposeMark)20, (categoryOfSpecialPurposeMark)21, (categoryOfSpecialPurposeMark)22, (categoryOfSpecialPurposeMark)23, (categoryOfSpecialPurposeMark)24, (categoryOfSpecialPurposeMark)25, (categoryOfSpecialPurposeMark)26, (categoryOfSpecialPurposeMark)27, (categoryOfSpecialPurposeMark)28, (categoryOfSpecialPurposeMark)29, (categoryOfSpecialPurposeMark)30, (categoryOfSpecialPurposeMark)31, (categoryOfSpecialPurposeMark)32, (categoryOfSpecialPurposeMark)33, (categoryOfSpecialPurposeMark)34, (categoryOfSpecialPurposeMark)35, (categoryOfSpecialPurposeMark)36, (categoryOfSpecialPurposeMark)37, (categoryOfSpecialPurposeMark)39, (categoryOfSpecialPurposeMark)40, (categoryOfSpecialPurposeMark)41, (categoryOfSpecialPurposeMark)42, (categoryOfSpecialPurposeMark)43, (categoryOfSpecialPurposeMark)44, (categoryOfSpecialPurposeMark)45, (categoryOfSpecialPurposeMark)46, (categoryOfSpecialPurposeMark)47, (categoryOfSpecialPurposeMark)48, (categoryOfSpecialPurposeMark)49, (categoryOfSpecialPurposeMark)50, (categoryOfSpecialPurposeMark)51, (categoryOfSpecialPurposeMark)52, (categoryOfSpecialPurposeMark)53, (categoryOfSpecialPurposeMark)54, (categoryOfSpecialPurposeMark)55, (categoryOfSpecialPurposeMark)56, (categoryOfSpecialPurposeMark)57, (categoryOfSpecialPurposeMark)58, (categoryOfSpecialPurposeMark)60, (categoryOfSpecialPurposeMark)61, (categoryOfSpecialPurposeMark)62, (categoryOfSpecialPurposeMark)63];

        [Browsable(false)]
        public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1, (marksNavigationalSystemOf)2, (marksNavigationalSystemOf)9, (marksNavigationalSystemOf)11];

        [Browsable(false)]
        public visualProminence[] visualProminenceList => [(visualProminence)1, (visualProminence)2, (visualProminence)3];

        [Browsable(false)]
        public colour[] colourList => [(colour)1, (colour)2, (colour)3, (colour)4, (colour)5, (colour)6, (colour)7, (colour)8, (colour)9, (colour)10, (colour)11, (colour)12, (colour)13];

        public override FeatureViewModel<SpecialPurposeGeneralBeacon> Load(DomainModel.S501.FeatureTypes.SpecialPurposeGeneralBeacon instance) {
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
            return this;
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