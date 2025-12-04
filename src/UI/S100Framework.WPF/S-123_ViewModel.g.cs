using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Reflection;
using System.ComponentModel;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S123;
using S100Framework.DomainModel.S123.ComplexAttributes;
using S100Framework.DomainModel.S123.InformationTypes;
using S100Framework.DomainModel.S123.FeatureTypes;
using S100Framework.DomainModel.S123.InformationAssociations;
using S100Framework.DomainModel.S123.FeatureAssociations;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using System.Text.Json;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.WPF.ViewModel.S123 {
	internal static class Bootstrap {
		public static AssociationViewModel CreateInformationAssociation(string type, string? name = default) => type switch {
			"AdditionalInformation" => new AdditionalInformationViewModel { Name = name },
			"AssociatedRxN" => new AssociatedRxNViewModel { Name = name },
			"AuthorityContact" => new AuthorityContactViewModel { Name = name },
			"AuthorityHours" => new AuthorityHoursViewModel { Name = name },
			"AvailableQoS" => new AvailableQoSViewModel { Name = name },
			"BroadcastService" => new BroadcastServiceViewModel { Name = name },
			"BroadcastTransmission" => new BroadcastTransmissionViewModel { Name = name },
			"ConnectivityService" => new ConnectivityServiceViewModel { Name = name },
			"ExceptionalWorkday" => new ExceptionalWorkdayViewModel { Name = name },
			"InclusionType" => new InclusionTypeViewModel { Name = name },
			"LocationHours" => new LocationHoursViewModel { Name = name },
			"PermissionType" => new PermissionTypeViewModel { Name = name },
			"RadioServiceControl" => new RadioServiceControlViewModel { Name = name },
			"relatedOrganisation" => new relatedOrganisationViewModel { Name = name },
			"ServiceContact" => new ServiceContactViewModel { Name = name },
			"ServiceCoordination" => new ServiceCoordinationViewModel { Name = name },
			"SpatialAssociation" => new SpatialAssociationViewModel { Name = name },
			"TMAS" => new TMASViewModel { Name = name },
			"TransmissionService" => new TransmissionServiceViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static AssociationViewModel CreateFeatureAssociation(string type, string? name = default) => type switch {
			"coreAggregation" => new coreAggregationViewModel { Name = name },
			"fuzzyZoneAggregation" => new fuzzyZoneAggregationViewModel { Name = name },
			"ServiceProvisionArea" => new ServiceProvisionAreaViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static InformationViewModel CreateInformationType(string type, string? name = default) => type switch {
			"Applicability" => new ApplicabilityViewModel { Name = name },
			"Authority" => new AuthorityViewModel { Name = name },
			"BroadcastDetails" => new BroadcastDetailsViewModel { Name = name },
			"ConnectivityQualityOfService" => new ConnectivityQualityOfServiceViewModel { Name = name },
			"ContactDetails" => new ContactDetailsViewModel { Name = name },
			"NauticalInformation" => new NauticalInformationViewModel { Name = name },
			"NonStandardWorkingDay" => new NonStandardWorkingDayViewModel { Name = name },
			"RadioControlCentre" => new RadioControlCentreViewModel { Name = name },
			"Recommendations" => new RecommendationsViewModel { Name = name },
			"Regulations" => new RegulationsViewModel { Name = name },
			"Restrictions" => new RestrictionsViewModel { Name = name },
			"ServiceHours" => new ServiceHoursViewModel { Name = name },
			"SpatialQuality" => new SpatialQualityViewModel { Name = name },
			"TelemedicalAssistanceService" => new TelemedicalAssistanceServiceViewModel { Name = name },
			"TransmissionDetails" => new TransmissionDetailsViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static FeatureViewModel CreateFeatureType(string type, string? name = default) => type switch {
			"ConnectivitySubscriptionArea" => new ConnectivitySubscriptionAreaViewModel { Name = name },
			"GMDSSArea" => new GMDSSAreaViewModel { Name = name },
			"IndeterminateZone" => new IndeterminateZoneViewModel { Name = name },
			"MetArea" => new MetAreaViewModel { Name = name },
			"NavArea" => new NavAreaViewModel { Name = name },
			"NavtexServiceArea" => new NavtexServiceAreaViewModel { Name = name },
			"RadioServiceArea" => new RadioServiceAreaViewModel { Name = name },
			"RadioStation" => new RadioStationViewModel { Name = name },
			"SARRegion" => new SARRegionViewModel { Name = name },
			"WeatherForecastAndWarningArea" => new WeatherForecastAndWarningAreaViewModel { Name = name },
			"RadioServiceAreaAggregate" => new RadioServiceAreaAggregateViewModel { Name = name },
			"DataCoverage" => new DataCoverageViewModel { Name = name },
			"QualityOfNonBathymetricData" => new QualityOfNonBathymetricDataViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static ICollection<string> InformationAssociationBindings(string association, string role) => (association, role) switch {
			("AdditionalInformation", "theInformation") => ["NauticalInformation"],
			("InclusionType", "isApplicableTo") => ["Applicability"],
			("relatedOrganisation", "theOrganisation") => ["Authority"],
			("InclusionType", "theApplicableRxN") => ["AbstractRxN"],
			("AuthorityContact", "theContactDetails") => ["ContactDetails"],
			("AuthorityHours", "theServiceHours") => ["ServiceHours"],
			("BroadcastTransmission", "theTransmissionDetails") => ["TransmissionDetails"],
			("AuthorityContact", "theAuthority") => ["Authority","RadioControlCentre"],
			("ExceptionalWorkday", "theServiceHours_nsdy") => ["ServiceHours"],
			("TMAS", "theTMAS") => ["TelemedicalAssistanceService"],
			("AuthorityHours", "theAuthority") => ["Authority","RadioControlCentre"],
			("ExceptionalWorkday", "partialWorkingDay") => ["NonStandardWorkingDay"],
			("RadioServiceControl", "theControlCentre") => ["RadioControlCentre"],
			("BroadcastTransmission", "theBroadcastDetails") => ["BroadcastDetails"],
			("AssociatedRxN", "theRxN") => ["AbstractRxN"],
			("PermissionType", "permission") => ["Applicability"],
			("ConnectivityService", "connectivityServiceProvider") => ["Authority"],
			("ServiceContact", "theContactDetails") => ["ContactDetails"],
			("LocationHours", "theServiceHours") => ["ServiceHours"],
			("AvailableQoS", "theQoS") => ["ConnectivityQualityOfService"],
			("ServiceCoordination", "coordinatingAuthority") => ["Authority"],
			("BroadcastService", "theBroadcastDetails") => ["BroadcastDetails"],
			("TransmissionService", "theTransmissionDetails") => ["TransmissionDetails"],
			_ => throw new InvalidOperationException(),
		};

		public static ICollection<string> FeatureAssociationBindings(string association, string role) => (association, role) switch {
			("ServiceProvisionArea", "serviceProvider") => ["RadioStation"],
			("fuzzyZoneAggregation", "theCollection") => ["FuzzyAreaAggregate"],
			("coreAggregation", "theCollection") => ["RadioServiceAreaAggregate"],
			("ServiceProvisionArea", "serviceArea") => ["ConnectivitySubscriptionArea","GMDSSArea","MetArea","NavArea","NavtexServiceArea","RadioServiceArea","WeatherForecastAndWarningArea"],
			("fuzzyZoneAggregation", "theComponent") => ["IndeterminateZone"],
			("coreAggregation", "theComponent") => ["RadioServiceArea"],
			_ => throw new InvalidOperationException(),
		};
	}

	/// <summary>
	/// Description of the radio service for area A3 of the Global Maritime Distress and Safety System (GMDSS).
	/// </summary>
	[CategoryOrder("areaA3ServiceDescription",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class areaA3ServiceDescriptionViewModel : ComplexViewModel<areaA3ServiceDescription> {
		[Multiplicity(1)]
		public ObservableCollection<servingMobileSatelliteService> servingMobileSatelliteService  { get; set; } = new ();

		[Browsable(false)]
		public servingMobileSatelliteService[] servingMobileSatelliteServiceList => [(servingMobileSatelliteService)1,(servingMobileSatelliteService)2];

		private String? _satelliteOceanRegion  = default;

		[Editor(typeof(Editors.HorizonEditor<areaA3ServiceDescription>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? satelliteOceanRegion {
			get {
				return _satelliteOceanRegion;
			}
			set {
				SetValue(ref _satelliteOceanRegion, value);
			}
		}

		private String? _mSICoastalWarningArea  = default;

		[Editor(typeof(Editors.HorizonEditor<areaA3ServiceDescription>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? mSICoastalWarningArea {
			get {
				return _mSICoastalWarningArea;
			}
			set {
				SetValue(ref _mSICoastalWarningArea, value);
			}
		}


		public areaA3ServiceDescriptionViewModel Load(areaA3ServiceDescription instance) {
			servingMobileSatelliteService.Clear();
			if (instance.servingMobileSatelliteService is not null) {
				foreach(var e in instance.servingMobileSatelliteService)
					servingMobileSatelliteService.Add(e);
			}
			satelliteOceanRegion = instance.satelliteOceanRegion;
			mSICoastalWarningArea = instance.mSICoastalWarningArea;
			return this;
		}

		public override string Serialize() {
			var instance = new areaA3ServiceDescription {
				servingMobileSatelliteService = this.servingMobileSatelliteService.ToList(),
				satelliteOceanRegion = this.satelliteOceanRegion,
				mSICoastalWarningArea = this.mSICoastalWarningArea,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public areaA3ServiceDescription Model => new () {
			servingMobileSatelliteService = this.servingMobileSatelliteService.ToList(),
			satelliteOceanRegion = this._satelliteOceanRegion,
			mSICoastalWarningArea = this._mSICoastalWarningArea,
		};

		public override string? ToString() => $"Area A3 Service Description";

		public areaA3ServiceDescriptionViewModel() : base() {
			servingMobileSatelliteService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(servingMobileSatelliteService));
			};
		}
	}


	/// <summary>
	/// Details related to the content of the broadcast.
	/// </summary>
	[CategoryOrder("broadcastContent",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class broadcastContentViewModel : ComplexViewModel<broadcastContent> {
		[Multiplicity(1)]
		public ObservableCollection<typeOfBroadcastContent> typeOfBroadcastContent  { get; set; } = new ();

		[Browsable(false)]
		public typeOfBroadcastContent[] typeOfBroadcastContentList => [(typeOfBroadcastContent)1,(typeOfBroadcastContent)2,(typeOfBroadcastContent)3,(typeOfBroadcastContent)4,(typeOfBroadcastContent)5,(typeOfBroadcastContent)6,(typeOfBroadcastContent)7,(typeOfBroadcastContent)8];

		[Optional]
		public ObservableCollection<String> subjectOrMessageTypeCode  { get; set; } = new ();

		private String? _subjectDescription  = default;

		[Editor(typeof(Editors.HorizonEditor<broadcastContent>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? subjectDescription {
			get {
				return _subjectDescription;
			}
			set {
				SetValue(ref _subjectDescription, value);
			}
		}

		private S100Framework.DomainModel.S100.Time? _observationTime  = default;

		[Editor(typeof(Editors.HorizonEditor<broadcastContent>), typeof(Editors.HorizonEditor))]
		[Optional]
		public S100Framework.DomainModel.S100.Time? observationTime {
			get {
				return _observationTime;
			}
			set {
				SetValue(ref _observationTime, value);
			}
		}

		private transmissionRegularity? _transmissionRegularity  = default;

		[Editor(typeof(Editors.HorizonEditor<broadcastContent>), typeof(Editors.HorizonEditor))]
		[Optional]
		public transmissionRegularity? transmissionRegularity {
			get {
				return _transmissionRegularity;
			}
			set {
				SetValue(ref _transmissionRegularity, value);
			}
		}

		[Browsable(false)]
		public transmissionRegularity[] transmissionRegularityList => [(transmissionRegularity)1,(transmissionRegularity)2,(transmissionRegularity)3,(transmissionRegularity)4,(transmissionRegularity)5];


		public broadcastContentViewModel Load(broadcastContent instance) {
			typeOfBroadcastContent.Clear();
			if (instance.typeOfBroadcastContent is not null) {
				foreach(var e in instance.typeOfBroadcastContent)
					typeOfBroadcastContent.Add(e);
			}
			subjectOrMessageTypeCode.Clear();
			if (instance.subjectOrMessageTypeCode is not null) {
				foreach(var e in instance.subjectOrMessageTypeCode)
					subjectOrMessageTypeCode.Add(e);
			}
			subjectDescription = instance.subjectDescription;
			observationTime = instance.observationTime;
			transmissionRegularity = instance.transmissionRegularity;
			return this;
		}

		public override string Serialize() {
			var instance = new broadcastContent {
				typeOfBroadcastContent = this.typeOfBroadcastContent.ToList(),
				subjectOrMessageTypeCode = this.subjectOrMessageTypeCode.ToList(),
				subjectDescription = this.subjectDescription,
				observationTime = this.observationTime,
				transmissionRegularity = this.transmissionRegularity,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public broadcastContent Model => new () {
			typeOfBroadcastContent = this.typeOfBroadcastContent.ToList(),
			subjectOrMessageTypeCode = this.subjectOrMessageTypeCode.ToList(),
			subjectDescription = this._subjectDescription,
			observationTime = this._observationTime,
			transmissionRegularity = this._transmissionRegularity,
		};

		public override string? ToString() => $"Broadcast Content";

		public broadcastContentViewModel() : base() {
			typeOfBroadcastContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(typeOfBroadcastContent));
			};
			subjectOrMessageTypeCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(subjectOrMessageTypeCode));
			};
		}
	}


	/// <summary>
	/// Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.
	/// </summary>
	[CategoryOrder("contactAddress",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class contactAddressViewModel : ComplexViewModel<contactAddress> {
		private String? _deliveryPoint  = default;

		[Editor(typeof(Editors.HorizonEditor<contactAddress>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? deliveryPoint {
			get {
				return _deliveryPoint;
			}
			set {
				SetValue(ref _deliveryPoint, value);
			}
		}

		private String? _cityName  = default;

		[Editor(typeof(Editors.HorizonEditor<contactAddress>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? cityName {
			get {
				return _cityName;
			}
			set {
				SetValue(ref _cityName, value);
			}
		}

		private String? _administrativeDivision  = default;

		[Editor(typeof(Editors.HorizonEditor<contactAddress>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? administrativeDivision {
			get {
				return _administrativeDivision;
			}
			set {
				SetValue(ref _administrativeDivision, value);
			}
		}

		private String? _countryName  = default;

		[Editor(typeof(Editors.HorizonEditor<contactAddress>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? countryName {
			get {
				return _countryName;
			}
			set {
				SetValue(ref _countryName, value);
			}
		}

		private String? _postalCode  = default;

		[Editor(typeof(Editors.HorizonEditor<contactAddress>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? postalCode {
			get {
				return _postalCode;
			}
			set {
				SetValue(ref _postalCode, value);
			}
		}


		public contactAddressViewModel Load(contactAddress instance) {
			deliveryPoint = instance.deliveryPoint;
			cityName = instance.cityName;
			administrativeDivision = instance.administrativeDivision;
			countryName = instance.countryName;
			postalCode = instance.postalCode;
			return this;
		}

		public override string Serialize() {
			var instance = new contactAddress {
				deliveryPoint = this.deliveryPoint,
				cityName = this.cityName,
				administrativeDivision = this.administrativeDivision,
				countryName = this.countryName,
				postalCode = this.postalCode,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public contactAddress Model => new () {
			deliveryPoint = this._deliveryPoint,
			cityName = this._cityName,
			administrativeDivision = this._administrativeDivision,
			countryName = this._countryName,
			postalCode = this._postalCode,
		};

		public override string? ToString() => $"Contact Address";
	}


	/// <summary>
	/// Details related to the indication of the radio coverage.
	/// </summary>
	[CategoryOrder("coverageIndication",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class coverageIndicationViewModel : ComplexViewModel<coverageIndication> {
		private int? _minimumReceivedPower  = default;

		[Editor(typeof(Editors.HorizonEditor<coverageIndication>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? minimumReceivedPower {
			get {
				return _minimumReceivedPower;
			}
			set {
				SetValue(ref _minimumReceivedPower, value);
			}
		}

		private double? _presumedReceiverAntennaHeight  = default;

		[Editor(typeof(Editors.HorizonEditor<coverageIndication>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? presumedReceiverAntennaHeight {
			get {
				return _presumedReceiverAntennaHeight;
			}
			set {
				SetValue(ref _presumedReceiverAntennaHeight, value);
			}
		}

		private int? _minimumSignalToInterferenceNoiseRatio  = default;

		[Editor(typeof(Editors.HorizonEditor<coverageIndication>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? minimumSignalToInterferenceNoiseRatio {
			get {
				return _minimumSignalToInterferenceNoiseRatio;
			}
			set {
				SetValue(ref _minimumSignalToInterferenceNoiseRatio, value);
			}
		}

		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)14,(status)16,(status)17,(status)24,(status)25,(status)26,(status)27];

		[Optional]
		public ObservableCollection<String> text  { get; set; } = new ();


		public coverageIndicationViewModel Load(coverageIndication instance) {
			minimumReceivedPower = instance.minimumReceivedPower;
			presumedReceiverAntennaHeight = instance.presumedReceiverAntennaHeight;
			minimumSignalToInterferenceNoiseRatio = instance.minimumSignalToInterferenceNoiseRatio;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			text.Clear();
			if (instance.text is not null) {
				foreach(var e in instance.text)
					text.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new coverageIndication {
				minimumReceivedPower = this.minimumReceivedPower,
				presumedReceiverAntennaHeight = this.presumedReceiverAntennaHeight,
				minimumSignalToInterferenceNoiseRatio = this.minimumSignalToInterferenceNoiseRatio,
				status = this.status.ToList(),
				text = this.text.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public coverageIndication Model => new () {
			minimumReceivedPower = this._minimumReceivedPower,
			presumedReceiverAntennaHeight = this._presumedReceiverAntennaHeight,
			minimumSignalToInterferenceNoiseRatio = this._minimumSignalToInterferenceNoiseRatio,
			status = this.status.ToList(),
			text = this.text.ToList(),
		};

		public override string? ToString() => $"Coverage Indication";

		public coverageIndicationViewModel() : base() {
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			text.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(text));
			};
		}
	}


	/// <summary>
	/// Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.
	/// </summary>
	[CategoryOrder("featureName",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class featureNameViewModel : ComplexViewModel<featureName> {
		private String _language  = string.Empty;

		[Editor(typeof(Editors.HorizonEditor<featureName>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}

		private String _name  = string.Empty;

		[Editor(typeof(Editors.HorizonEditor<featureName>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String name {
			get {
				return _name;
			}
			set {
				SetValue(ref _name, value);
			}
		}

		private nameUsage? _nameUsage  = default;

		[Editor(typeof(Editors.HorizonEditor<featureName>), typeof(Editors.HorizonEditor))]
		[Optional]
		public nameUsage? nameUsage {
			get {
				return _nameUsage;
			}
			set {
				SetValue(ref _nameUsage, value);
			}
		}

		[Browsable(false)]
		public nameUsage[] nameUsageList => [(nameUsage)1,(nameUsage)2,(nameUsage)3];


		public featureNameViewModel Load(featureName instance) {
			language = instance.language;
			name = instance.name;
			nameUsage = instance.nameUsage;
			return this;
		}

		public override string Serialize() {
			var instance = new featureName {
				language = this.language,
				name = this.name,
				nameUsage = this.nameUsage,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public featureName Model => new () {
			language = this._language,
			name = this._name,
			nameUsage = this._nameUsage,
		};

		public override string? ToString() => $"Feature Name";
	}


	/// <summary>
	/// An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.
	/// </summary>
	[CategoryOrder("fixedDateRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class fixedDateRangeViewModel : ComplexViewModel<fixedDateRange> {
		private String? _dateStart  = default;

		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? dateStart {
			get {
				return _dateStart;
			}
			set {
				SetValue(ref _dateStart, value);
			}
		}

		private String? _dateEnd  = default;

		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? dateEnd {
			get {
				return _dateEnd;
			}
			set {
				SetValue(ref _dateEnd, value);
			}
		}

		private S100Framework.DomainModel.S100.Time? _timeOfDayStart  = default;

		[Editor(typeof(Editors.HorizonEditor<fixedDateRange>), typeof(Editors.HorizonEditor))]
		[Optional]
		public S100Framework.DomainModel.S100.Time? timeOfDayStart {
			get {
				return _timeOfDayStart;
			}
			set {
				SetValue(ref _timeOfDayStart, value);
			}
		}

		private S100Framework.DomainModel.S100.Time? _timeOfDayEnd  = default;

		[Editor(typeof(Editors.HorizonEditor<fixedDateRange>), typeof(Editors.HorizonEditor))]
		[Optional]
		public S100Framework.DomainModel.S100.Time? timeOfDayEnd {
			get {
				return _timeOfDayEnd;
			}
			set {
				SetValue(ref _timeOfDayEnd, value);
			}
		}


		public fixedDateRangeViewModel Load(fixedDateRange instance) {
			dateStart = instance.dateStart;
			dateEnd = instance.dateEnd;
			timeOfDayStart = instance.timeOfDayStart;
			timeOfDayEnd = instance.timeOfDayEnd;
			return this;
		}

		public override string Serialize() {
			var instance = new fixedDateRange {
				dateStart = this.dateStart,
				dateEnd = this.dateEnd,
				timeOfDayStart = this.timeOfDayStart,
				timeOfDayEnd = this.timeOfDayEnd,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public fixedDateRange Model => new () {
			dateStart = this._dateStart,
			dateEnd = this._dateEnd,
			timeOfDayStart = this._timeOfDayStart,
			timeOfDayEnd = this._timeOfDayEnd,
		};

		public override string? ToString() => $"Fixed Date Range";
	}


	/// <summary>
	/// A pair of frequencies for transmitting and receiving radio signals. The shore station transmits and receives on the frequencies indicated.
	/// </summary>
	[CategoryOrder("frequencyPair",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class frequencyPairViewModel : ComplexViewModel<frequencyPair> {
		private int? _frequencyShoreStationReceives  = default;

		[Editor(typeof(Editors.HorizonEditor<frequencyPair>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? frequencyShoreStationReceives {
			get {
				return _frequencyShoreStationReceives;
			}
			set {
				SetValue(ref _frequencyShoreStationReceives, value);
			}
		}

		private int _frequencyShoreStationTransmits  = default;

		[Editor(typeof(Editors.HorizonEditor<frequencyPair>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public int frequencyShoreStationTransmits {
			get {
				return _frequencyShoreStationTransmits;
			}
			set {
				SetValue(ref _frequencyShoreStationTransmits, value);
			}
		}


		public frequencyPairViewModel Load(frequencyPair instance) {
			frequencyShoreStationReceives = instance.frequencyShoreStationReceives;
			frequencyShoreStationTransmits = instance.frequencyShoreStationTransmits;
			return this;
		}

		public override string Serialize() {
			var instance = new frequencyPair {
				frequencyShoreStationReceives = this.frequencyShoreStationReceives,
				frequencyShoreStationTransmits = this.frequencyShoreStationTransmits,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public frequencyPair Model => new () {
			frequencyShoreStationReceives = this._frequencyShoreStationReceives,
			frequencyShoreStationTransmits = this._frequencyShoreStationTransmits,
		};

		public override string? ToString() => $"Frequency Pair";
	}


	/// <summary>
	/// Frequency range of the electromagnetic spectrum in which the transmission is provided.
	/// </summary>
	[CategoryOrder("frequencyRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class frequencyRangeViewModel : ComplexViewModel<frequencyRange> {
		private int _frequencyLimitLower  = default;

		[Editor(typeof(Editors.HorizonEditor<frequencyRange>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public int frequencyLimitLower {
			get {
				return _frequencyLimitLower;
			}
			set {
				SetValue(ref _frequencyLimitLower, value);
			}
		}

		private int _frequencyLimitUpper  = default;

		[Editor(typeof(Editors.HorizonEditor<frequencyRange>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public int frequencyLimitUpper {
			get {
				return _frequencyLimitUpper;
			}
			set {
				SetValue(ref _frequencyLimitUpper, value);
			}
		}


		public frequencyRangeViewModel Load(frequencyRange instance) {
			frequencyLimitLower = instance.frequencyLimitLower;
			frequencyLimitUpper = instance.frequencyLimitUpper;
			return this;
		}

		public override string Serialize() {
			var instance = new frequencyRange {
				frequencyLimitLower = this.frequencyLimitLower,
				frequencyLimitUpper = this.frequencyLimitUpper,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public frequencyRange Model => new () {
			frequencyLimitLower = this._frequencyLimitLower,
			frequencyLimitUpper = this._frequencyLimitUpper,
		};

		public override string? ToString() => $"Frequency Range";
	}


	/// <summary>
	/// Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.
	/// </summary>
	[CategoryOrder("graphic",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class graphicViewModel : ComplexViewModel<graphic> {
		private String _pictorialRepresentation  = string.Empty;

		[Editor(typeof(Editors.HorizonEditor<graphic>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _pictureCaption  = default;

		[Editor(typeof(Editors.HorizonEditor<graphic>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictureCaption {
			get {
				return _pictureCaption;
			}
			set {
				SetValue(ref _pictureCaption, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Editor(typeof(Editors.HorizonEditor<graphic>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _pictureInformation  = default;

		[Editor(typeof(Editors.HorizonEditor<graphic>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictureInformation {
			get {
				return _pictureInformation;
			}
			set {
				SetValue(ref _pictureInformation, value);
			}
		}


		public graphicViewModel Load(graphic instance) {
			pictorialRepresentation = instance.pictorialRepresentation;
			pictureCaption = instance.pictureCaption;
			sourceDate = instance.sourceDate;
			pictureInformation = instance.pictureInformation;
			return this;
		}

		public override string Serialize() {
			var instance = new graphic {
				pictorialRepresentation = this.pictorialRepresentation,
				pictureCaption = this.pictureCaption,
				sourceDate = this.sourceDate,
				pictureInformation = this.pictureInformation,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public graphic Model => new () {
			pictorialRepresentation = this._pictorialRepresentation,
			pictureCaption = this._pictureCaption,
			sourceDate = this._sourceDate,
			pictureInformation = this._pictureInformation,
		};

		public override string? ToString() => $"Graphic";
	}


	/// <summary>
	/// The best estimate of the accuracy of a position.
	/// </summary>
	[CategoryOrder("horizontalPositionUncertainty",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class horizontalPositionUncertaintyViewModel : ComplexViewModel<horizontalPositionUncertainty> {
		private double _uncertaintyFixed  = default;

		[Editor(typeof(Editors.HorizonEditor<horizontalPositionUncertainty>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double uncertaintyFixed {
			get {
				return _uncertaintyFixed;
			}
			set {
				SetValue(ref _uncertaintyFixed, value);
			}
		}

		private double? _uncertaintyVariableFactor  = default;

		[Editor(typeof(Editors.HorizonEditor<horizontalPositionUncertainty>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? uncertaintyVariableFactor {
			get {
				return _uncertaintyVariableFactor;
			}
			set {
				SetValue(ref _uncertaintyVariableFactor, value);
			}
		}


		public horizontalPositionUncertaintyViewModel Load(horizontalPositionUncertainty instance) {
			uncertaintyFixed = instance.uncertaintyFixed;
			uncertaintyVariableFactor = instance.uncertaintyVariableFactor;
			return this;
		}

		public override string Serialize() {
			var instance = new horizontalPositionUncertainty {
				uncertaintyFixed = this.uncertaintyFixed,
				uncertaintyVariableFactor = this.uncertaintyVariableFactor,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public horizontalPositionUncertainty Model => new () {
			uncertaintyFixed = this._uncertaintyFixed,
			uncertaintyVariableFactor = this._uncertaintyVariableFactor,
		};

		public override string? ToString() => $"Horizontal Position Uncertainty";
	}


	/// <summary>
	/// Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.
	/// </summary>
	[CategoryOrder("information",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class informationViewModel : ComplexViewModel<information> {
		private String? _fileLocator  = default;

		[Editor(typeof(Editors.HorizonEditor<information>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? fileLocator {
			get {
				return _fileLocator;
			}
			set {
				SetValue(ref _fileLocator, value);
			}
		}

		private String? _fileReference  = default;

		[Editor(typeof(Editors.HorizonEditor<information>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? fileReference {
			get {
				return _fileReference;
			}
			set {
				SetValue(ref _fileReference, value);
			}
		}

		private String? _headline  = default;

		[Editor(typeof(Editors.HorizonEditor<information>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? headline {
			get {
				return _headline;
			}
			set {
				SetValue(ref _headline, value);
			}
		}

		private String _language  = string.Empty;

		[Editor(typeof(Editors.HorizonEditor<information>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}

		private String? _text  = default;

		[Editor(typeof(Editors.HorizonEditor<information>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? text {
			get {
				return _text;
			}
			set {
				SetValue(ref _text, value);
			}
		}


		public informationViewModel Load(information instance) {
			fileLocator = instance.fileLocator;
			fileReference = instance.fileReference;
			headline = instance.headline;
			language = instance.language;
			text = instance.text;
			return this;
		}

		public override string Serialize() {
			var instance = new information {
				fileLocator = this.fileLocator,
				fileReference = this.fileReference,
				headline = this.headline,
				language = this.language,
				text = this.text,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public information Model => new () {
			fileLocator = this._fileLocator,
			fileReference = this._fileReference,
			headline = this._headline,
			language = this._language,
			text = this._text,
		};

		public override string? ToString() => $"Information";
	}


	/// <summary>
	/// Information about online sources from which a resource or data can be obtained.
	/// </summary>
	[CategoryOrder("onlineResource",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class onlineResourceViewModel : ComplexViewModel<onlineResource> {
		private String? _headline  = default;

		[Editor(typeof(Editors.HorizonEditor<onlineResource>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? headline {
			get {
				return _headline;
			}
			set {
				SetValue(ref _headline, value);
			}
		}

		private String _linkage  = string.Empty;

		[Editor(typeof(Editors.HorizonEditor<onlineResource>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String linkage {
			get {
				return _linkage;
			}
			set {
				SetValue(ref _linkage, value);
			}
		}

		private String? _nameOfResource  = default;

		[Editor(typeof(Editors.HorizonEditor<onlineResource>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? nameOfResource {
			get {
				return _nameOfResource;
			}
			set {
				SetValue(ref _nameOfResource, value);
			}
		}


		public onlineResourceViewModel Load(onlineResource instance) {
			headline = instance.headline;
			linkage = instance.linkage;
			nameOfResource = instance.nameOfResource;
			return this;
		}

		public override string Serialize() {
			var instance = new onlineResource {
				headline = this.headline,
				linkage = this.linkage,
				nameOfResource = this.nameOfResource,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public onlineResource Model => new () {
			headline = this._headline,
			linkage = this._linkage,
			nameOfResource = this._nameOfResource,
		};

		public override string? ToString() => $"Online Resource";
	}


	/// <summary>
	/// The active period of a recurring event or occurrence.
	/// </summary>
	[CategoryOrder("periodicDateRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class periodicDateRangeViewModel : ComplexViewModel<periodicDateRange> {
		private String _dateStart  = string.Empty;

		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Mandatory]
		public String dateStart {
			get {
				return _dateStart;
			}
			set {
				SetValue(ref _dateStart, value);
			}
		}

		private String _dateEnd  = string.Empty;

		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Mandatory]
		public String dateEnd {
			get {
				return _dateEnd;
			}
			set {
				SetValue(ref _dateEnd, value);
			}
		}


		public periodicDateRangeViewModel Load(periodicDateRange instance) {
			dateStart = instance.dateStart;
			dateEnd = instance.dateEnd;
			return this;
		}

		public override string Serialize() {
			var instance = new periodicDateRange {
				dateStart = this.dateStart,
				dateEnd = this.dateEnd,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public periodicDateRange Model => new () {
			dateStart = this._dateStart,
			dateEnd = this._dateEnd,
		};

		public override string? ToString() => $"Periodic Date Range";
	}


	/// <summary>
	/// Details related to the radio channel used in the radio service.
	/// </summary>
	[CategoryOrder("radioChannelDetails",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class radioChannelDetailsViewModel : ComplexViewModel<radioChannelDetails> {
		[Optional]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();

		[Optional]
		public ObservableCollection<frequencyPairViewModel> frequencyPair  { get; set; } = new ();

		[Optional]
		public ObservableCollection<int> dataTransmissionRate  { get; set; } = new ();

		private Boolean _transmissionOfTrafficLists  = false;

		[Editor(typeof(Editors.HorizonEditor<radioChannelDetails>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public Boolean transmissionOfTrafficLists {
			get {
				return _transmissionOfTrafficLists;
			}
			set {
				SetValue(ref _transmissionOfTrafficLists, value);
			}
		}

		private String? _hoursOfWatch  = default;

		[Editor(typeof(Editors.HorizonEditor<radioChannelDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? hoursOfWatch {
			get {
				return _hoursOfWatch;
			}
			set {
				SetValue(ref _hoursOfWatch, value);
			}
		}


		public radioChannelDetailsViewModel Load(radioChannelDetails instance) {
			communicationChannel.Clear();
			if (instance.communicationChannel is not null) {
				foreach(var e in instance.communicationChannel)
					communicationChannel.Add(e);
			}
			frequencyPair.Clear();
			if (instance.frequencyPair is not null) {
				foreach(var e in instance.frequencyPair)
					frequencyPair.Add(new frequencyPairViewModel().Load(e));
			}
			dataTransmissionRate.Clear();
			if (instance.dataTransmissionRate is not null) {
				foreach(var e in instance.dataTransmissionRate)
					dataTransmissionRate.Add(e);
			}
			transmissionOfTrafficLists = instance.transmissionOfTrafficLists;
			hoursOfWatch = instance.hoursOfWatch;
			return this;
		}

		public override string Serialize() {
			var instance = new radioChannelDetails {
				communicationChannel = this.communicationChannel.ToList(),
				frequencyPair = this.frequencyPair.Select(e => e.Model).ToList(),
				dataTransmissionRate = this.dataTransmissionRate.ToList(),
				transmissionOfTrafficLists = this.transmissionOfTrafficLists,
				hoursOfWatch = this.hoursOfWatch,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public radioChannelDetails Model => new () {
			communicationChannel = this.communicationChannel.ToList(),
			frequencyPair = this.frequencyPair.Select(e => e.Model).ToList(),
			dataTransmissionRate = this.dataTransmissionRate.ToList(),
			transmissionOfTrafficLists = this._transmissionOfTrafficLists,
			hoursOfWatch = this._hoursOfWatch,
		};

		public override string? ToString() => $"Radio Channel Details";

		public radioChannelDetailsViewModel() : base() {
			communicationChannel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(communicationChannel));
			};
			frequencyPair.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(frequencyPair));
			};
			dataTransmissionRate.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(dataTransmissionRate));
			};
		}
	}


	/// <summary>
	/// Identifiers of the radio station in various maritime radiocommunication services.
	/// </summary>
	[CategoryOrder("radiocommunicationIdentifier",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class radiocommunicationIdentifierViewModel : ComplexViewModel<radiocommunicationIdentifier> {
		[Optional]
		public ObservableCollection<String> callSign  { get; set; } = new ();

		[Optional]
		public ObservableCollection<String> mMSICode  { get; set; } = new ();

		[Optional]
		public ObservableCollection<int> selectiveCallNumber  { get; set; } = new ();

		[Optional]
		public ObservableCollection<String> coastStationIdentificationCode  { get; set; } = new ();


		public radiocommunicationIdentifierViewModel Load(radiocommunicationIdentifier instance) {
			callSign.Clear();
			if (instance.callSign is not null) {
				foreach(var e in instance.callSign)
					callSign.Add(e);
			}
			mMSICode.Clear();
			if (instance.mMSICode is not null) {
				foreach(var e in instance.mMSICode)
					mMSICode.Add(e);
			}
			selectiveCallNumber.Clear();
			if (instance.selectiveCallNumber is not null) {
				foreach(var e in instance.selectiveCallNumber)
					selectiveCallNumber.Add(e);
			}
			coastStationIdentificationCode.Clear();
			if (instance.coastStationIdentificationCode is not null) {
				foreach(var e in instance.coastStationIdentificationCode)
					coastStationIdentificationCode.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new radiocommunicationIdentifier {
				callSign = this.callSign.ToList(),
				mMSICode = this.mMSICode.ToList(),
				selectiveCallNumber = this.selectiveCallNumber.ToList(),
				coastStationIdentificationCode = this.coastStationIdentificationCode.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public radiocommunicationIdentifier Model => new () {
			callSign = this.callSign.ToList(),
			mMSICode = this.mMSICode.ToList(),
			selectiveCallNumber = this.selectiveCallNumber.ToList(),
			coastStationIdentificationCode = this.coastStationIdentificationCode.ToList(),
		};

		public override string? ToString() => $"Radiocommunication Identifier";

		public radiocommunicationIdentifierViewModel() : base() {
			callSign.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(callSign));
			};
			mMSICode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(mMSICode));
			};
			selectiveCallNumber.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(selectiveCallNumber));
			};
			coastStationIdentificationCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(coastStationIdentificationCode));
			};
		}
	}


	/// <summary>
	/// A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.
	/// </summary>
	[CategoryOrder("rxNCode",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class rxNCodeViewModel : ComplexViewModel<rxNCode> {
		private String? _headline  = default;

		[Editor(typeof(Editors.HorizonEditor<rxNCode>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? headline {
			get {
				return _headline;
			}
			set {
				SetValue(ref _headline, value);
			}
		}

		private categoryOfRxN? _categoryOfRxN  = default;

		[Editor(typeof(Editors.HorizonEditor<rxNCode>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfRxN? categoryOfRxN {
			get {
				return _categoryOfRxN;
			}
			set {
				SetValue(ref _categoryOfRxN, value);
			}
		}

		private actionOrActivity? _actionOrActivity  = default;

		[Editor(typeof(Editors.HorizonEditor<rxNCode>), typeof(Editors.HorizonEditor))]
		[Optional]
		public actionOrActivity? actionOrActivity {
			get {
				return _actionOrActivity;
			}
			set {
				SetValue(ref _actionOrActivity, value);
			}
		}


		public rxNCodeViewModel Load(rxNCode instance) {
			headline = instance.headline;
			categoryOfRxN = instance.categoryOfRxN;
			actionOrActivity = instance.actionOrActivity;
			return this;
		}

		public override string Serialize() {
			var instance = new rxNCode {
				headline = this.headline,
				categoryOfRxN = this.categoryOfRxN,
				actionOrActivity = this.actionOrActivity,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public rxNCode Model => new () {
			headline = this._headline,
			categoryOfRxN = this._categoryOfRxN,
			actionOrActivity = this._actionOrActivity,
		};

		public override string? ToString() => $"RxN Code";
	}


	/// <summary>
	/// The nature and timings of a daily schedule by days of the week.
	/// </summary>
	[CategoryOrder("scheduleByDayOfWeek",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class scheduleByDayOfWeekViewModel : ComplexViewModel<scheduleByDayOfWeek> {
		private categoryOfSchedule? _categoryOfSchedule  = default;

		[Editor(typeof(Editors.HorizonEditor<scheduleByDayOfWeek>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfSchedule? categoryOfSchedule {
			get {
				return _categoryOfSchedule;
			}
			set {
				SetValue(ref _categoryOfSchedule, value);
			}
		}

		[Browsable(false)]
		public categoryOfSchedule[] categoryOfScheduleList => [(categoryOfSchedule)1,(categoryOfSchedule)2,(categoryOfSchedule)3];

		[Multiplicity(1, 10)]
		public ObservableCollection<timeIntervalsByDayOfWeekViewModel> timeIntervalsByDayOfWeek  { get; set; } = new ();


		public scheduleByDayOfWeekViewModel Load(scheduleByDayOfWeek instance) {
			categoryOfSchedule = instance.categoryOfSchedule;
			timeIntervalsByDayOfWeek.Clear();
			if (instance.timeIntervalsByDayOfWeek is not null) {
				foreach(var e in instance.timeIntervalsByDayOfWeek)
					timeIntervalsByDayOfWeek.Add(new timeIntervalsByDayOfWeekViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new scheduleByDayOfWeek {
				categoryOfSchedule = this.categoryOfSchedule,
				timeIntervalsByDayOfWeek = this.timeIntervalsByDayOfWeek.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public scheduleByDayOfWeek Model => new () {
			categoryOfSchedule = this._categoryOfSchedule,
			timeIntervalsByDayOfWeek = this.timeIntervalsByDayOfWeek.Select(e => e.Model).ToList(),
		};

		public override string? ToString() => $"Schedule by Day of Week";

		public scheduleByDayOfWeekViewModel() : base() {
			timeIntervalsByDayOfWeek.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(timeIntervalsByDayOfWeek));
			};
		}
	}


	/// <summary>
	/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. The sector limit specifies the limits of the sector In a clockwise direction around the central feature (for example a light).
	/// </summary>
	[CategoryOrder("sectorLimit",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorLimitViewModel : ComplexViewModel<sectorLimit> {
		private sectorLimitOneViewModel _sectorLimitOne  = default;

		[ExpandableObject]
		[Mandatory]
		public sectorLimitOneViewModel sectorLimitOne {
			get {
				return _sectorLimitOne;
			}
			set {
				SetValue(ref _sectorLimitOne, value);
			}
		}

		private sectorLimitTwoViewModel _sectorLimitTwo  = default;

		[ExpandableObject]
		[Mandatory]
		public sectorLimitTwoViewModel sectorLimitTwo {
			get {
				return _sectorLimitTwo;
			}
			set {
				SetValue(ref _sectorLimitTwo, value);
			}
		}


		public sectorLimitViewModel Load(sectorLimit instance) {
			sectorLimitOne = new ();
			if (instance.sectorLimitOne != default) {
				sectorLimitOne.Load(instance.sectorLimitOne);
			}
			sectorLimitTwo = new ();
			if (instance.sectorLimitTwo != default) {
				sectorLimitTwo.Load(instance.sectorLimitTwo);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new sectorLimit {
				sectorLimitOne = this.sectorLimitOne?.Model,
				sectorLimitTwo = this.sectorLimitTwo?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public sectorLimit Model => new () {
			sectorLimitOne = this._sectorLimitOne?.Model,
			sectorLimitTwo = this._sectorLimitTwo?.Model,
		};

		public override string? ToString() => $"Sector Limit";
	}


	/// <summary>
	/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit one specifies the first limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).
	/// </summary>
	[CategoryOrder("sectorLimitOne",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorLimitOneViewModel : ComplexViewModel<sectorLimitOne> {
		private double _sectorBearing  = default;

		[Editor(typeof(Editors.HorizonEditor<sectorLimitOne>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double sectorBearing {
			get {
				return _sectorBearing;
			}
			set {
				SetValue(ref _sectorBearing, value);
			}
		}

		private double? _sectorLineLength  = default;

		[Editor(typeof(Editors.HorizonEditor<sectorLimitOne>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? sectorLineLength {
			get {
				return _sectorLineLength;
			}
			set {
				SetValue(ref _sectorLineLength, value);
			}
		}


		public sectorLimitOneViewModel Load(sectorLimitOne instance) {
			sectorBearing = instance.sectorBearing;
			sectorLineLength = instance.sectorLineLength;
			return this;
		}

		public override string Serialize() {
			var instance = new sectorLimitOne {
				sectorBearing = this.sectorBearing,
				sectorLineLength = this.sectorLineLength,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public sectorLimitOne Model => new () {
			sectorBearing = this._sectorBearing,
			sectorLineLength = this._sectorLineLength,
		};

		public override string? ToString() => $"Sector Limit One";
	}


	/// <summary>
	/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit two specifies the second limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).
	/// </summary>
	[CategoryOrder("sectorLimitTwo",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorLimitTwoViewModel : ComplexViewModel<sectorLimitTwo> {
		private double _sectorBearing  = default;

		[Editor(typeof(Editors.HorizonEditor<sectorLimitTwo>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double sectorBearing {
			get {
				return _sectorBearing;
			}
			set {
				SetValue(ref _sectorBearing, value);
			}
		}

		private double? _sectorLineLength  = default;

		[Editor(typeof(Editors.HorizonEditor<sectorLimitTwo>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? sectorLineLength {
			get {
				return _sectorLineLength;
			}
			set {
				SetValue(ref _sectorLineLength, value);
			}
		}


		public sectorLimitTwoViewModel Load(sectorLimitTwo instance) {
			sectorBearing = instance.sectorBearing;
			sectorLineLength = instance.sectorLineLength;
			return this;
		}

		public override string Serialize() {
			var instance = new sectorLimitTwo {
				sectorBearing = this.sectorBearing,
				sectorLineLength = this.sectorLineLength,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public sectorLimitTwo Model => new () {
			sectorBearing = this._sectorBearing,
			sectorLineLength = this._sectorLineLength,
		};

		public override string? ToString() => $"Sector Limit Two";
	}


	/// <summary>
	/// Provides an indication of the vertical and horizontal positional uncertainty of bathymetric data, optionally within a specified date range.
	/// </summary>
	[CategoryOrder("spatialAccuracy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class spatialAccuracyViewModel : ComplexViewModel<spatialAccuracy> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

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

		private horizontalPositionUncertaintyViewModel? _horizontalPositionUncertainty  = default;

		[ExpandableObject]
		[Optional]
		public horizontalPositionUncertaintyViewModel? horizontalPositionUncertainty {
			get {
				return _horizontalPositionUncertainty;
			}
			set {
				SetValue(ref _horizontalPositionUncertainty, value);
			}
		}

		private verticalUncertaintyViewModel? _verticalUncertainty  = default;

		[ExpandableObject]
		[Optional]
		public verticalUncertaintyViewModel? verticalUncertainty {
			get {
				return _verticalUncertainty;
			}
			set {
				SetValue(ref _verticalUncertainty, value);
			}
		}


		public spatialAccuracyViewModel Load(spatialAccuracy instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			horizontalPositionUncertainty = new ();
			if (instance.horizontalPositionUncertainty != default) {
				horizontalPositionUncertainty.Load(instance.horizontalPositionUncertainty);
			}
			verticalUncertainty = new ();
			if (instance.verticalUncertainty != default) {
				verticalUncertainty.Load(instance.verticalUncertainty);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new spatialAccuracy {
				fixedDateRange = this.fixedDateRange?.Model,
				horizontalPositionUncertainty = this.horizontalPositionUncertainty?.Model,
				verticalUncertainty = this.verticalUncertainty?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public spatialAccuracy Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			horizontalPositionUncertainty = this._horizontalPositionUncertainty?.Model,
			verticalUncertainty = this._verticalUncertainty?.Model,
		};

		public override string? ToString() => $"Spatial Accuracy";
	}


	/// <summary>
	/// The complex attribute describes the period of the hydrographic survey, as the time between its sub-attributes.
	/// </summary>
	[CategoryOrder("surveyDateRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class surveyDateRangeViewModel : ComplexViewModel<surveyDateRange> {
		private String? _dateStart  = default;

		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? dateStart {
			get {
				return _dateStart;
			}
			set {
				SetValue(ref _dateStart, value);
			}
		}

		private String _dateEnd  = string.Empty;

		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Mandatory]
		public String dateEnd {
			get {
				return _dateEnd;
			}
			set {
				SetValue(ref _dateEnd, value);
			}
		}


		public surveyDateRangeViewModel Load(surveyDateRange instance) {
			dateStart = instance.dateStart;
			dateEnd = instance.dateEnd;
			return this;
		}

		public override string Serialize() {
			var instance = new surveyDateRange {
				dateStart = this.dateStart,
				dateEnd = this.dateEnd,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public surveyDateRange Model => new () {
			dateStart = this._dateStart,
			dateEnd = this._dateEnd,
		};

		public override string? ToString() => $"Survey Date Range";
	}


	/// <summary>
	/// A means or channel of communicating at a distance by electrical or electromagnetic means such as telegraphy, telephony, or broadcasting.
	/// </summary>
	[CategoryOrder("telecommunications",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class telecommunicationsViewModel : ComplexViewModel<telecommunications> {
		private String? _contactInstructions  = default;

		[Editor(typeof(Editors.HorizonEditor<telecommunications>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? contactInstructions {
			get {
				return _contactInstructions;
			}
			set {
				SetValue(ref _contactInstructions, value);
			}
		}

		private String _telecommunicationIdentifier  = string.Empty;

		[Editor(typeof(Editors.HorizonEditor<telecommunications>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String telecommunicationIdentifier {
			get {
				return _telecommunicationIdentifier;
			}
			set {
				SetValue(ref _telecommunicationIdentifier, value);
			}
		}

		private telecommunicationService? _telecommunicationService  = default;

		[Editor(typeof(Editors.HorizonEditor<telecommunications>), typeof(Editors.HorizonEditor))]
		[Optional]
		public telecommunicationService? telecommunicationService {
			get {
				return _telecommunicationService;
			}
			set {
				SetValue(ref _telecommunicationService, value);
			}
		}

		[Browsable(false)]
		public telecommunicationService[] telecommunicationServiceList => [(telecommunicationService)1,(telecommunicationService)2,(telecommunicationService)3,(telecommunicationService)4,(telecommunicationService)5,(telecommunicationService)6,(telecommunicationService)7,(telecommunicationService)8];


		public telecommunicationsViewModel Load(telecommunications instance) {
			contactInstructions = instance.contactInstructions;
			telecommunicationIdentifier = instance.telecommunicationIdentifier;
			telecommunicationService = instance.telecommunicationService;
			return this;
		}

		public override string Serialize() {
			var instance = new telecommunications {
				contactInstructions = this.contactInstructions,
				telecommunicationIdentifier = this.telecommunicationIdentifier,
				telecommunicationService = this.telecommunicationService,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public telecommunications Model => new () {
			contactInstructions = this._contactInstructions,
			telecommunicationIdentifier = this._telecommunicationIdentifier,
			telecommunicationService = this._telecommunicationService,
		};

		public override string? ToString() => $"Telecommunications";
	}


	/// <summary>
	/// Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.
	/// </summary>
	[CategoryOrder("textContent",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class textContentViewModel : ComplexViewModel<textContent> {
		private categoryOfText? _categoryOfText  = default;

		[Editor(typeof(Editors.HorizonEditor<textContent>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfText? categoryOfText {
			get {
				return _categoryOfText;
			}
			set {
				SetValue(ref _categoryOfText, value);
			}
		}

		[Browsable(false)]
		public categoryOfText[] categoryOfTextList => [(categoryOfText)1,(categoryOfText)2,(categoryOfText)3];

		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private onlineResourceViewModel? _onlineResource  = default;

		[ExpandableObject]
		[Optional]
		public onlineResourceViewModel? onlineResource {
			get {
				return _onlineResource;
			}
			set {
				SetValue(ref _onlineResource, value);
			}
		}

		private String? _source  = default;

		[Editor(typeof(Editors.HorizonEditor<textContent>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}


		public textContentViewModel Load(textContent instance) {
			categoryOfText = instance.categoryOfText;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			onlineResource = new ();
			if (instance.onlineResource != default) {
				onlineResource.Load(instance.onlineResource);
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			return this;
		}

		public override string Serialize() {
			var instance = new textContent {
				categoryOfText = this.categoryOfText,
				information = this.information.Select(e => e.Model).ToList(),
				onlineResource = this.onlineResource?.Model,
				source = this.source,
				reportedDate = this.reportedDate,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public textContent Model => new () {
			categoryOfText = this._categoryOfText,
			information = this.information.Select(e => e.Model).ToList(),
			onlineResource = this._onlineResource?.Model,
			source = this._source,
			reportedDate = this._reportedDate,
		};

		public override string? ToString() => $"Text Content";

		public textContentViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}


	/// <summary>
	/// The regular weekly operation times of a service or schedule.
	/// </summary>
	[CategoryOrder("timeIntervalsByDayOfWeek",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class timeIntervalsByDayOfWeekViewModel : ComplexViewModel<timeIntervalsByDayOfWeek> {
		[Multiplicity(0, 7)]
		public ObservableCollection<dayOfWeek> dayOfWeek  { get; set; } = new ();

		[Browsable(false)]
		public dayOfWeek[] dayOfWeekList => [(dayOfWeek)1,(dayOfWeek)2,(dayOfWeek)3,(dayOfWeek)4,(dayOfWeek)5,(dayOfWeek)6,(dayOfWeek)7];

		private Boolean? _dayOfWeekIsRange  = default;

		[Editor(typeof(Editors.HorizonEditor<timeIntervalsByDayOfWeek>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? dayOfWeekIsRange {
			get {
				return _dayOfWeekIsRange;
			}
			set {
				SetValue(ref _dayOfWeekIsRange, value);
			}
		}

		[Optional]
		public ObservableCollection<S100Framework.DomainModel.S100.Time> timeOfDayStart  { get; set; } = new ();

		[Optional]
		public ObservableCollection<S100Framework.DomainModel.S100.Time> timeOfDayEnd  { get; set; } = new ();


		public timeIntervalsByDayOfWeekViewModel Load(timeIntervalsByDayOfWeek instance) {
			dayOfWeek.Clear();
			if (instance.dayOfWeek is not null) {
				foreach(var e in instance.dayOfWeek)
					dayOfWeek.Add(e);
			}
			dayOfWeekIsRange = instance.dayOfWeekIsRange;
			timeOfDayStart.Clear();
			if (instance.timeOfDayStart is not null) {
				foreach(var e in instance.timeOfDayStart)
					timeOfDayStart.Add(e);
			}
			timeOfDayEnd.Clear();
			if (instance.timeOfDayEnd is not null) {
				foreach(var e in instance.timeOfDayEnd)
					timeOfDayEnd.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new timeIntervalsByDayOfWeek {
				dayOfWeek = this.dayOfWeek.ToList(),
				dayOfWeekIsRange = this.dayOfWeekIsRange,
				timeOfDayStart = this.timeOfDayStart.ToList(),
				timeOfDayEnd = this.timeOfDayEnd.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public timeIntervalsByDayOfWeek Model => new () {
			dayOfWeek = this.dayOfWeek.ToList(),
			dayOfWeekIsRange = this._dayOfWeekIsRange,
			timeOfDayStart = this.timeOfDayStart.ToList(),
			timeOfDayEnd = this.timeOfDayEnd.ToList(),
		};

		public override string? ToString() => $"Time Intervals by Day of Week";

		public timeIntervalsByDayOfWeekViewModel() : base() {
			dayOfWeek.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(dayOfWeek));
			};
			timeOfDayStart.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(timeOfDayStart));
			};
			timeOfDayEnd.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(timeOfDayEnd));
			};
		}
	}


	/// <summary>
	/// One or more times in the day when the radio station starts a routine transmission, normally expressed in UTC or local time.
	/// </summary>
	[CategoryOrder("timesOfTransmission",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class timesOfTransmissionViewModel : ComplexViewModel<timesOfTransmission> {
		private int? _minutePastEvenHours  = default;

		[Editor(typeof(Editors.HorizonEditor<timesOfTransmission>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? minutePastEvenHours {
			get {
				return _minutePastEvenHours;
			}
			set {
				SetValue(ref _minutePastEvenHours, value);
			}
		}

		private int? _minutePastOddHours  = default;

		[Editor(typeof(Editors.HorizonEditor<timesOfTransmission>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? minutePastOddHours {
			get {
				return _minutePastOddHours;
			}
			set {
				SetValue(ref _minutePastOddHours, value);
			}
		}

		private int? _minutePastEveryHour  = default;

		[Editor(typeof(Editors.HorizonEditor<timesOfTransmission>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? minutePastEveryHour {
			get {
				return _minutePastEveryHour;
			}
			set {
				SetValue(ref _minutePastEveryHour, value);
			}
		}

		[Optional]
		public ObservableCollection<S100Framework.DomainModel.S100.Time> transmissionTime  { get; set; } = new ();


		public timesOfTransmissionViewModel Load(timesOfTransmission instance) {
			minutePastEvenHours = instance.minutePastEvenHours;
			minutePastOddHours = instance.minutePastOddHours;
			minutePastEveryHour = instance.minutePastEveryHour;
			transmissionTime.Clear();
			if (instance.transmissionTime is not null) {
				foreach(var e in instance.transmissionTime)
					transmissionTime.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new timesOfTransmission {
				minutePastEvenHours = this.minutePastEvenHours,
				minutePastOddHours = this.minutePastOddHours,
				minutePastEveryHour = this.minutePastEveryHour,
				transmissionTime = this.transmissionTime.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public timesOfTransmission Model => new () {
			minutePastEvenHours = this._minutePastEvenHours,
			minutePastOddHours = this._minutePastOddHours,
			minutePastEveryHour = this._minutePastEveryHour,
			transmissionTime = this.transmissionTime.ToList(),
		};

		public override string? ToString() => $"Times of Transmission";

		public timesOfTransmissionViewModel() : base() {
			transmissionTime.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(transmissionTime));
			};
		}
	}


	/// <summary>
	/// The best estimate of the vertical accuracy of depths, heights, vertical distances and vertical clearances.
	/// </summary>
	[CategoryOrder("verticalUncertainty",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class verticalUncertaintyViewModel : ComplexViewModel<verticalUncertainty> {
		private double _uncertaintyFixed  = default;

		[Editor(typeof(Editors.HorizonEditor<verticalUncertainty>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double uncertaintyFixed {
			get {
				return _uncertaintyFixed;
			}
			set {
				SetValue(ref _uncertaintyFixed, value);
			}
		}

		private double? _uncertaintyVariableFactor  = default;

		[Editor(typeof(Editors.HorizonEditor<verticalUncertainty>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? uncertaintyVariableFactor {
			get {
				return _uncertaintyVariableFactor;
			}
			set {
				SetValue(ref _uncertaintyVariableFactor, value);
			}
		}


		public verticalUncertaintyViewModel Load(verticalUncertainty instance) {
			uncertaintyFixed = instance.uncertaintyFixed;
			uncertaintyVariableFactor = instance.uncertaintyVariableFactor;
			return this;
		}

		public override string Serialize() {
			var instance = new verticalUncertainty {
				uncertaintyFixed = this.uncertaintyFixed,
				uncertaintyVariableFactor = this.uncertaintyVariableFactor,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public verticalUncertainty Model => new () {
			uncertaintyFixed = this._uncertaintyFixed,
			uncertaintyVariableFactor = this._uncertaintyVariableFactor,
		};

		public override string? ToString() => $"Vertical Uncertainty";
	}


	/// <summary>
	/// Combinations of values of measurable characteristics or dimensions of vessels, used to specify size and tonnage ranges.
	/// </summary>
	[CategoryOrder("vesselMeasurementsSpecification",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class vesselMeasurementsSpecificationViewModel : ComplexViewModel<vesselMeasurementsSpecification> {
		private vesselsCharacteristics _vesselsCharacteristics  = default;

		[Editor(typeof(Editors.HorizonEditor<vesselMeasurementsSpecification>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public vesselsCharacteristics vesselsCharacteristics {
			get {
				return _vesselsCharacteristics;
			}
			set {
				SetValue(ref _vesselsCharacteristics, value);
			}
		}

		[Browsable(false)]
		public vesselsCharacteristics[] vesselsCharacteristicsList => [(vesselsCharacteristics)1,(vesselsCharacteristics)2,(vesselsCharacteristics)3,(vesselsCharacteristics)4,(vesselsCharacteristics)6,(vesselsCharacteristics)7,(vesselsCharacteristics)8,(vesselsCharacteristics)9,(vesselsCharacteristics)10,(vesselsCharacteristics)11,(vesselsCharacteristics)12,(vesselsCharacteristics)13];

		private double _vesselsCharacteristicsValue  = default;

		[Editor(typeof(Editors.HorizonEditor<vesselMeasurementsSpecification>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double vesselsCharacteristicsValue {
			get {
				return _vesselsCharacteristicsValue;
			}
			set {
				SetValue(ref _vesselsCharacteristicsValue, value);
			}
		}

		private vesselsCharacteristicsUnit _vesselsCharacteristicsUnit  = default;

		[Editor(typeof(Editors.HorizonEditor<vesselMeasurementsSpecification>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public vesselsCharacteristicsUnit vesselsCharacteristicsUnit {
			get {
				return _vesselsCharacteristicsUnit;
			}
			set {
				SetValue(ref _vesselsCharacteristicsUnit, value);
			}
		}

		[Browsable(false)]
		public vesselsCharacteristicsUnit[] vesselsCharacteristicsUnitList => [(vesselsCharacteristicsUnit)1,(vesselsCharacteristicsUnit)3,(vesselsCharacteristicsUnit)4,(vesselsCharacteristicsUnit)5,(vesselsCharacteristicsUnit)6,(vesselsCharacteristicsUnit)7,(vesselsCharacteristicsUnit)9];

		private comparisonOperator _comparisonOperator  = default;

		[Editor(typeof(Editors.HorizonEditor<vesselMeasurementsSpecification>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public comparisonOperator comparisonOperator {
			get {
				return _comparisonOperator;
			}
			set {
				SetValue(ref _comparisonOperator, value);
			}
		}

		[Browsable(false)]
		public comparisonOperator[] comparisonOperatorList => [(comparisonOperator)1,(comparisonOperator)2,(comparisonOperator)3,(comparisonOperator)4,(comparisonOperator)5,(comparisonOperator)6];


		public vesselMeasurementsSpecificationViewModel Load(vesselMeasurementsSpecification instance) {
			vesselsCharacteristics = instance.vesselsCharacteristics;
			vesselsCharacteristicsValue = instance.vesselsCharacteristicsValue;
			vesselsCharacteristicsUnit = instance.vesselsCharacteristicsUnit;
			comparisonOperator = instance.comparisonOperator;
			return this;
		}

		public override string Serialize() {
			var instance = new vesselMeasurementsSpecification {
				vesselsCharacteristics = this.vesselsCharacteristics,
				vesselsCharacteristicsValue = this.vesselsCharacteristicsValue,
				vesselsCharacteristicsUnit = this.vesselsCharacteristicsUnit,
				comparisonOperator = this.comparisonOperator,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public vesselMeasurementsSpecification Model => new () {
			vesselsCharacteristics = this._vesselsCharacteristics,
			vesselsCharacteristicsValue = this._vesselsCharacteristicsValue,
			vesselsCharacteristicsUnit = this._vesselsCharacteristicsUnit,
			comparisonOperator = this._comparisonOperator,
		};

		public override string? ToString() => $"Vessel Measurements Specification";
	}



	/// <summary>
	/// A feature association for the binding between at least one instance of a geo feature and an instance of an information type.
	/// </summary>
	[CategoryOrder("AdditionalInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AdditionalInformationViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new AdditionalInformation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Additional information";
	}



	/// <summary>
	/// Association between a geographic location and a regulation, restriction, recommendation, or nautical information
	/// </summary>
	[CategoryOrder("AssociatedRxN",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AssociatedRxNViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new AssociatedRxN {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Associated RxN";
	}



	/// <summary>
	/// Contact information for an authority
	/// </summary>
	[CategoryOrder("AuthorityContact",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AuthorityContactViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new AuthorityContact {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Authority contact";
	}



	/// <summary>
	/// Service hours for an authority
	/// </summary>
	[CategoryOrder("AuthorityHours",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AuthorityHoursViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new AuthorityHours {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Authority hours";
	}



	/// <summary>
	/// Available Quality of Service (QoS) within the area.
	/// </summary>
	[CategoryOrder("AvailableQoS",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AvailableQoSViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new AvailableQoS {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Available Quality of Service";
	}



	/// <summary>
	/// The broadcast content and schedule of a service area or facility
	/// </summary>
	[CategoryOrder("BroadcastService",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BroadcastServiceViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new BroadcastService {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Broadcast Service";
	}



	/// <summary>
	/// The transmission details for the broadcast or the broadcast details available from the transmission
	/// </summary>
	[CategoryOrder("BroadcastTransmission",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BroadcastTransmissionViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new BroadcastTransmission {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Broadcast Transmission";
	}



	/// <summary>
	/// The service that allows users to connect to the internet.
	/// </summary>
	[CategoryOrder("ConnectivityService",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ConnectivityServiceViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new ConnectivityService {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Connectivity Service";
	}



	/// <summary>
	/// Exception to the usual working day
	/// </summary>
	[CategoryOrder("ExceptionalWorkday",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ExceptionalWorkdayViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new ExceptionalWorkday {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Exceptional workday";
	}



	/// <summary>
	/// Association class specifying the relationship between the subset of vessels described by an APPLIC data object and a regulation (restriction, recommendation, or nautical information).
	/// </summary>
	[CategoryOrder("InclusionType",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class InclusionTypeViewModel : InformationAssociationViewModel {
		private membership _membership  = default;

		[Category("InclusionType")]
		[Editor(typeof(Editors.HorizonEditor<InclusionType>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public membership membership {
			get {
				return _membership;
			}
			set {
				SetValue(ref _membership, value);
			}
		}

		[Browsable(false)]
		public membership[] membershipList => [(membership)1,(membership)2];


		public override string Serialize() {
			var instance = new InclusionType {
				membership = this.membership,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"InclusionType";
	}



	/// <summary>
	/// Working hours for a service or facility described by a geographic location
	/// </summary>
	[CategoryOrder("LocationHours",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LocationHoursViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new LocationHours {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Location hours";
	}



	/// <summary>
	/// Association class for associations describing whether the subsets of vessels determined by the ship characteristics specified in APPLIC may (or must, etc.) transit,  enter, or use  a feature.
	/// </summary>
	[CategoryOrder("PermissionType",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PermissionTypeViewModel : InformationAssociationViewModel {
		private categoryOfRelationship _categoryOfRelationship  = default;

		[Category("PermissionType")]
		[Editor(typeof(Editors.HorizonEditor<PermissionType>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public categoryOfRelationship categoryOfRelationship {
			get {
				return _categoryOfRelationship;
			}
			set {
				SetValue(ref _categoryOfRelationship, value);
			}
		}

		[Browsable(false)]
		public categoryOfRelationship[] categoryOfRelationshipList => [(categoryOfRelationship)1,(categoryOfRelationship)2,(categoryOfRelationship)3,(categoryOfRelationship)4,(categoryOfRelationship)5,(categoryOfRelationship)6];


		public override string Serialize() {
			var instance = new PermissionType {
				categoryOfRelationship = this.categoryOfRelationship,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Permission Type";
	}



	/// <summary>
	/// The radio control centre for a marine radio service
	/// </summary>
	[CategoryOrder("RadioServiceControl",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RadioServiceControlViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new RadioServiceControl {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Radio Service Control";
	}



	/// <summary>
	/// Related organisation
	/// </summary>
	[CategoryOrder("relatedOrganisation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class relatedOrganisationViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new relatedOrganisation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Related organisation";
	}



	/// <summary>
	/// Contact details for a service or facility
	/// </summary>
	[CategoryOrder("ServiceContact",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ServiceContactViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new ServiceContact {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Service contact";
	}



	/// <summary>
	/// The coordinating authority for a service area
	/// </summary>
	[CategoryOrder("ServiceCoordination",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ServiceCoordinationViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new ServiceCoordination {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Service Coordination";
	}



	/// <summary>
	/// An association for the binding between a spatial type and its spatial quality information.
	/// </summary>
	[CategoryOrder("SpatialAssociation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SpatialAssociationViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new SpatialAssociation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Spatial Association";
	}



	/// <summary>
	/// Available Telemedical Assistance Service and related coordination centre.
	/// </summary>
	[CategoryOrder("TMAS",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TMASViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new TMAS {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Available Telemedical Assistance Service";
	}



	/// <summary>
	/// The radio transmission of a service area or facility
	/// </summary>
	[CategoryOrder("TransmissionService",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TransmissionServiceViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new TransmissionService {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Transmission Service";
	}



	/// <summary>
	/// A feature association for the binding between an aggregation feature that describes areas of varying uncertainty about a service or phenomenon and a geographic feature describing the service or phenomenon.
	/// </summary>
	[CategoryOrder("coreAggregation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class coreAggregationViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new coreAggregation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Core aggregation";
	}



	/// <summary>
	/// A feature association for the binding between an aggregation feature that describes areas of varying uncertainty about a service or phenomenon and zones of uncertainty about the service or phenomenon.
	/// </summary>
	[CategoryOrder("fuzzyZoneAggregation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class fuzzyZoneAggregationViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new fuzzyZoneAggregation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Fuzzy zone aggregation";
	}



	/// <summary>
	/// Association linking the location from which a service is provided and the area(s) served.
	/// </summary>
	[CategoryOrder("ServiceProvisionArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ServiceProvisionAreaViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new ServiceProvisionArea {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Service provision area";
	}



	/// <summary>
	/// Describes the relationship between vessel characteristics and: (i) the applicability of an associated information object or feature to the vessel; or, (ii) the use of a facility, place, or service by the vessel; or, (iii) passage of the vessel through an area.
	/// </summary>
	[CategoryOrder("Applicability",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ApplicabilityViewModel : InformationViewModel<Applicability> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private Boolean? _inBallast  = default;

		[Category("Applicability")]
		[Editor(typeof(Editors.HorizonEditor<Applicability>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? inBallast {
			get {
				return _inBallast;
			}
			set {
				SetValue(ref _inBallast, value);
			}
		}

		[Category("Applicability")]
		[Optional]
		public ObservableCollection<categoryOfVessel> categoryOfVessel  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfVessel[] categoryOfVesselList =>  CodeList.categoryOfVessels.ToArray();

		private categoryOfVesselRegistry? _categoryOfVesselRegistry  = default;

		[Category("Applicability")]
		[Editor(typeof(Editors.HorizonEditor<Applicability>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfVesselRegistry? categoryOfVesselRegistry {
			get {
				return _categoryOfVesselRegistry;
			}
			set {
				SetValue(ref _categoryOfVesselRegistry, value);
			}
		}

		[Browsable(false)]
		public categoryOfVesselRegistry[] categoryOfVesselRegistryList => [(categoryOfVesselRegistry)1,(categoryOfVesselRegistry)2];

		[Category("Applicability")]
		[Optional]
		public ObservableCollection<categoryOfCargo> categoryOfCargo  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfCargo[] categoryOfCargoList => [(categoryOfCargo)1,(categoryOfCargo)2,(categoryOfCargo)3,(categoryOfCargo)4,(categoryOfCargo)5,(categoryOfCargo)6,(categoryOfCargo)7,(categoryOfCargo)8,(categoryOfCargo)9,(categoryOfCargo)10,(categoryOfCargo)11,(categoryOfCargo)12,(categoryOfCargo)13,(categoryOfCargo)14,(categoryOfCargo)15];

		[Category("Applicability")]
		[Optional]
		public ObservableCollection<categoryOfDangerousOrHazardousCargo> categoryOfDangerousOrHazardousCargo  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfDangerousOrHazardousCargo[] categoryOfDangerousOrHazardousCargoList => [(categoryOfDangerousOrHazardousCargo)1,(categoryOfDangerousOrHazardousCargo)2,(categoryOfDangerousOrHazardousCargo)3,(categoryOfDangerousOrHazardousCargo)4,(categoryOfDangerousOrHazardousCargo)5,(categoryOfDangerousOrHazardousCargo)6,(categoryOfDangerousOrHazardousCargo)7,(categoryOfDangerousOrHazardousCargo)8,(categoryOfDangerousOrHazardousCargo)9,(categoryOfDangerousOrHazardousCargo)10,(categoryOfDangerousOrHazardousCargo)11,(categoryOfDangerousOrHazardousCargo)12,(categoryOfDangerousOrHazardousCargo)13,(categoryOfDangerousOrHazardousCargo)14,(categoryOfDangerousOrHazardousCargo)15,(categoryOfDangerousOrHazardousCargo)16,(categoryOfDangerousOrHazardousCargo)17,(categoryOfDangerousOrHazardousCargo)18,(categoryOfDangerousOrHazardousCargo)19,(categoryOfDangerousOrHazardousCargo)20,(categoryOfDangerousOrHazardousCargo)21];

		private logicalConnectives? _logicalConnectives  = default;

		[Category("Applicability")]
		[Editor(typeof(Editors.HorizonEditor<Applicability>), typeof(Editors.HorizonEditor))]
		[Optional]
		public logicalConnectives? logicalConnectives {
			get {
				return _logicalConnectives;
			}
			set {
				SetValue(ref _logicalConnectives, value);
			}
		}

		[Browsable(false)]
		public logicalConnectives[] logicalConnectivesList => [(logicalConnectives)1,(logicalConnectives)2];

		private int? _thicknessOfIceCapability  = default;

		[Category("Applicability")]
		[Editor(typeof(Editors.HorizonEditor<Applicability>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? thicknessOfIceCapability {
			get {
				return _thicknessOfIceCapability;
			}
			set {
				SetValue(ref _thicknessOfIceCapability, value);
			}
		}

		private String? _vesselPerformance  = default;

		[Category("Applicability")]
		[Editor(typeof(Editors.HorizonEditor<Applicability>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? vesselPerformance {
			get {
				return _vesselPerformance;
			}
			set {
				SetValue(ref _vesselPerformance, value);
			}
		}

		[Category("Applicability")]
		[Optional]
		public ObservableCollection<vesselMeasurementsSpecificationViewModel> vesselMeasurementsSpecification  { get; set; } = new ();

		[Category("Applicability")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		#region InformationBindings

		public class InclusionTypeViewModel : ViewModelBase, IInformationBinding {
			public InclusionTypeViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "InclusionType",
					role = "theApplicableRxN",
					roleType = roleType.association,
					informationTypes = ["AbstractRxN"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<InclusionType> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = InclusionType,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<ApplicabilityViewModel.InclusionTypeViewModel> InclusionTypes { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. InclusionTypes.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public ApplicabilityViewModel Load(Applicability instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			inBallast = instance.inBallast;
			categoryOfVessel.Clear();
			if (instance.categoryOfVessel is not null) {
				foreach(var e in instance.categoryOfVessel)
					categoryOfVessel.Add(e);
			}
			categoryOfVesselRegistry = instance.categoryOfVesselRegistry;
			categoryOfCargo.Clear();
			if (instance.categoryOfCargo is not null) {
				foreach(var e in instance.categoryOfCargo)
					categoryOfCargo.Add(e);
			}
			categoryOfDangerousOrHazardousCargo.Clear();
			if (instance.categoryOfDangerousOrHazardousCargo is not null) {
				foreach(var e in instance.categoryOfDangerousOrHazardousCargo)
					categoryOfDangerousOrHazardousCargo.Add(e);
			}
			logicalConnectives = instance.logicalConnectives;
			thicknessOfIceCapability = instance.thicknessOfIceCapability;
			vesselPerformance = instance.vesselPerformance;
			vesselMeasurementsSpecification.Clear();
			if (instance.vesselMeasurementsSpecification is not null) {
				foreach(var e in instance.vesselMeasurementsSpecification)
					vesselMeasurementsSpecification.Add(new vesselMeasurementsSpecificationViewModel().Load(e));
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Applicability {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				inBallast = this.inBallast,
				categoryOfVessel = this.categoryOfVessel.ToList(),
				categoryOfVesselRegistry = this.categoryOfVesselRegistry,
				categoryOfCargo = this.categoryOfCargo.ToList(),
				categoryOfDangerousOrHazardousCargo = this.categoryOfDangerousOrHazardousCargo.ToList(),
				logicalConnectives = this.logicalConnectives,
				thicknessOfIceCapability = this.thicknessOfIceCapability,
				vesselPerformance = this.vesselPerformance,
				vesselMeasurementsSpecification = this.vesselMeasurementsSpecification.Select(e => e.Model).ToList(),
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Applicability Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			inBallast = this._inBallast,
			categoryOfVessel = this.categoryOfVessel.ToList(),
			categoryOfVesselRegistry = this._categoryOfVesselRegistry,
			categoryOfCargo = this.categoryOfCargo.ToList(),
			categoryOfDangerousOrHazardousCargo = this.categoryOfDangerousOrHazardousCargo.ToList(),
			logicalConnectives = this._logicalConnectives,
			thicknessOfIceCapability = this._thicknessOfIceCapability,
			vesselPerformance = this._vesselPerformance,
			vesselMeasurementsSpecification = this.vesselMeasurementsSpecification.Select(e => e.Model).ToList(),
			information = this.information.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Applicability._informationBindingDefinitions;

		public ApplicabilityViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Applicability";

		public ApplicabilityViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			categoryOfVessel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfVessel));
			};
			categoryOfCargo.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfCargo));
			};
			categoryOfDangerousOrHazardousCargo.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfDangerousOrHazardousCargo));
			};
			vesselMeasurementsSpecification.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(vesselMeasurementsSpecification));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			InclusionTypes.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(InclusionTypes));
			};
		}
	}



	/// <summary>
	/// A person or organisation having political or administrative power and control.
	/// </summary>
	[CategoryOrder("Authority",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AuthorityViewModel : InformationViewModel<Authority> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private categoryOfAuthority? _categoryOfAuthority  = default;

		[Category("Authority")]
		[Editor(typeof(Editors.HorizonEditor<Authority>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfAuthority? categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

		[Browsable(false)]
		public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2,(categoryOfAuthority)3,(categoryOfAuthority)4,(categoryOfAuthority)5,(categoryOfAuthority)6,(categoryOfAuthority)7,(categoryOfAuthority)8,(categoryOfAuthority)9,(categoryOfAuthority)10,(categoryOfAuthority)11,(categoryOfAuthority)12,(categoryOfAuthority)13,(categoryOfAuthority)14,(categoryOfAuthority)15,(categoryOfAuthority)16];

		private textContentViewModel? _textContent  = default;

		[Category("Authority")]
		[ExpandableObject]
		[Optional]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}


		#region InformationBindings

		public class AuthorityContactViewModel : ViewModelBase, IInformationBinding {
			public AuthorityContactViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "AuthorityContact",
					role = "theContactDetails",
					roleType = roleType.association,
					informationTypes = ["ContactDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<AuthorityContact> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = AuthorityContact,
			};
		}

		public class AuthorityHoursViewModel : ViewModelBase, IInformationBinding {
			public AuthorityHoursViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "AuthorityHours",
					role = "theServiceHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<AuthorityHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = AuthorityHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<AuthorityViewModel.AuthorityContactViewModel> AuthorityContacts { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<AuthorityViewModel.AuthorityHoursViewModel> AuthorityHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. AuthorityContacts.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. AuthorityHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public AuthorityViewModel Load(Authority instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			categoryOfAuthority = instance.categoryOfAuthority;
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Authority {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				categoryOfAuthority = this.categoryOfAuthority,
				textContent = this.textContent?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Authority Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			categoryOfAuthority = this._categoryOfAuthority,
			textContent = this._textContent?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Authority._informationBindingDefinitions;

		public AuthorityViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Authority";

		public AuthorityViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			AuthorityContacts.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(AuthorityContacts));
			};
			AuthorityHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(AuthorityHours));
			};
		}
	}



	/// <summary>
	/// Description of the content and schedule of a service using broadcast technology of radiocommunications to deliver information (to every receiver within a direct range). Online resource to access the content may also be included.
	/// </summary>
	[CategoryOrder("BroadcastDetails",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BroadcastDetailsViewModel : InformationViewModel<BroadcastDetails> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		[Category("BroadcastDetails")]
		[Optional]
		public ObservableCollection<String> language  { get; set; } = new ();

		private categoryOfBroadcastCommunication? _categoryOfBroadcastCommunication  = default;

		[Category("BroadcastDetails")]
		[Editor(typeof(Editors.HorizonEditor<BroadcastDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfBroadcastCommunication? categoryOfBroadcastCommunication {
			get {
				return _categoryOfBroadcastCommunication;
			}
			set {
				SetValue(ref _categoryOfBroadcastCommunication, value);
			}
		}

		[Browsable(false)]
		public categoryOfBroadcastCommunication[] categoryOfBroadcastCommunicationList => [(categoryOfBroadcastCommunication)1,(categoryOfBroadcastCommunication)2,(categoryOfBroadcastCommunication)3,(categoryOfBroadcastCommunication)4];

		[Category("BroadcastDetails")]
		[Multiplicity(1)]
		public ObservableCollection<broadcastContentViewModel> broadcastContent  { get; set; } = new ();

		[Category("BroadcastDetails")]
		[Optional]
		public ObservableCollection<timesOfTransmissionViewModel> timesOfTransmission  { get; set; } = new ();

		[Category("BroadcastDetails")]
		[Optional]
		public ObservableCollection<timeIntervalsByDayOfWeekViewModel> timeIntervalsByDayOfWeek  { get; set; } = new ();

		private onlineResourceViewModel? _onlineResource  = default;

		[Category("BroadcastDetails")]
		[ExpandableObject]
		[Optional]
		public onlineResourceViewModel? onlineResource {
			get {
				return _onlineResource;
			}
			set {
				SetValue(ref _onlineResource, value);
			}
		}


		#region InformationBindings

		public class BroadcastTransmissionViewModel : ViewModelBase, IInformationBinding {
			public BroadcastTransmissionViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "BroadcastTransmission",
					role = "theTransmissionDetails",
					roleType = roleType.association,
					informationTypes = ["TransmissionDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<BroadcastTransmission> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = BroadcastTransmission,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<BroadcastDetailsViewModel.BroadcastTransmissionViewModel> BroadcastTransmissions { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. BroadcastTransmissions.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public BroadcastDetailsViewModel Load(BroadcastDetails instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			language.Clear();
			if (instance.language is not null) {
				foreach(var e in instance.language)
					language.Add(e);
			}
			categoryOfBroadcastCommunication = instance.categoryOfBroadcastCommunication;
			broadcastContent.Clear();
			if (instance.broadcastContent is not null) {
				foreach(var e in instance.broadcastContent)
					broadcastContent.Add(new broadcastContentViewModel().Load(e));
			}
			timesOfTransmission.Clear();
			if (instance.timesOfTransmission is not null) {
				foreach(var e in instance.timesOfTransmission)
					timesOfTransmission.Add(new timesOfTransmissionViewModel().Load(e));
			}
			timeIntervalsByDayOfWeek.Clear();
			if (instance.timeIntervalsByDayOfWeek is not null) {
				foreach(var e in instance.timeIntervalsByDayOfWeek)
					timeIntervalsByDayOfWeek.Add(new timeIntervalsByDayOfWeekViewModel().Load(e));
			}
			onlineResource = new ();
			if (instance.onlineResource != default) {
				onlineResource.Load(instance.onlineResource);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new BroadcastDetails {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				language = this.language.ToList(),
				categoryOfBroadcastCommunication = this.categoryOfBroadcastCommunication,
				broadcastContent = this.broadcastContent.Select(e => e.Model).ToList(),
				timesOfTransmission = this.timesOfTransmission.Select(e => e.Model).ToList(),
				timeIntervalsByDayOfWeek = this.timeIntervalsByDayOfWeek.Select(e => e.Model).ToList(),
				onlineResource = this.onlineResource?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public BroadcastDetails Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			language = this.language.ToList(),
			categoryOfBroadcastCommunication = this._categoryOfBroadcastCommunication,
			broadcastContent = this.broadcastContent.Select(e => e.Model).ToList(),
			timesOfTransmission = this.timesOfTransmission.Select(e => e.Model).ToList(),
			timeIntervalsByDayOfWeek = this.timeIntervalsByDayOfWeek.Select(e => e.Model).ToList(),
			onlineResource = this._onlineResource?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => BroadcastDetails._informationBindingDefinitions;

		public BroadcastDetailsViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Broadcast Details";

		public BroadcastDetailsViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			language.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(language));
			};
			broadcastContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(broadcastContent));
			};
			timesOfTransmission.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(timesOfTransmission));
			};
			timeIntervalsByDayOfWeek.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(timeIntervalsByDayOfWeek));
			};
			BroadcastTransmissions.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(BroadcastTransmissions));
			};
		}
	}



	/// <summary>
	/// Information related to the Quality of Service (QoS) of the connectivity.
	/// </summary>
	[CategoryOrder("ConnectivityQualityOfService",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ConnectivityQualityOfServiceViewModel : InformationViewModel<ConnectivityQualityOfService> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		[Category("ConnectivityQualityOfService")]
		[Optional]
		public ObservableCollection<typeOfConnectivityResource> typeOfConnectivityResource  { get; set; } = new ();

		[Browsable(false)]
		public typeOfConnectivityResource[] typeOfConnectivityResourceList => [(typeOfConnectivityResource)1,(typeOfConnectivityResource)2,(typeOfConnectivityResource)3,(typeOfConnectivityResource)4];

		private double? _uplinkBandwidth  = default;

		[Category("ConnectivityQualityOfService")]
		[Editor(typeof(Editors.HorizonEditor<ConnectivityQualityOfService>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? uplinkBandwidth {
			get {
				return _uplinkBandwidth;
			}
			set {
				SetValue(ref _uplinkBandwidth, value);
			}
		}

		private double? _downlinkBandwidth  = default;

		[Category("ConnectivityQualityOfService")]
		[Editor(typeof(Editors.HorizonEditor<ConnectivityQualityOfService>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? downlinkBandwidth {
			get {
				return _downlinkBandwidth;
			}
			set {
				SetValue(ref _downlinkBandwidth, value);
			}
		}

		private double? _packetDelay  = default;

		[Category("ConnectivityQualityOfService")]
		[Editor(typeof(Editors.HorizonEditor<ConnectivityQualityOfService>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? packetDelay {
			get {
				return _packetDelay;
			}
			set {
				SetValue(ref _packetDelay, value);
			}
		}

		private int? _maximumDataBurstVolume  = default;

		[Category("ConnectivityQualityOfService")]
		[Editor(typeof(Editors.HorizonEditor<ConnectivityQualityOfService>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? maximumDataBurstVolume {
			get {
				return _maximumDataBurstVolume;
			}
			set {
				SetValue(ref _maximumDataBurstVolume, value);
			}
		}

		[Category("ConnectivityQualityOfService")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)14,(status)16,(status)17,(status)25,(status)26,(status)27];

		[Category("ConnectivityQualityOfService")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		public ConnectivityQualityOfServiceViewModel Load(ConnectivityQualityOfService instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			typeOfConnectivityResource.Clear();
			if (instance.typeOfConnectivityResource is not null) {
				foreach(var e in instance.typeOfConnectivityResource)
					typeOfConnectivityResource.Add(e);
			}
			uplinkBandwidth = instance.uplinkBandwidth;
			downlinkBandwidth = instance.downlinkBandwidth;
			packetDelay = instance.packetDelay;
			maximumDataBurstVolume = instance.maximumDataBurstVolume;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new ConnectivityQualityOfService {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				typeOfConnectivityResource = this.typeOfConnectivityResource.ToList(),
				uplinkBandwidth = this.uplinkBandwidth,
				downlinkBandwidth = this.downlinkBandwidth,
				packetDelay = this.packetDelay,
				maximumDataBurstVolume = this.maximumDataBurstVolume,
				status = this.status.ToList(),
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ConnectivityQualityOfService Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			typeOfConnectivityResource = this.typeOfConnectivityResource.ToList(),
			uplinkBandwidth = this._uplinkBandwidth,
			downlinkBandwidth = this._downlinkBandwidth,
			packetDelay = this._packetDelay,
			maximumDataBurstVolume = this._maximumDataBurstVolume,
			status = this.status.ToList(),
			information = this.information.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => ConnectivityQualityOfService._informationBindingDefinitions;

		public ConnectivityQualityOfServiceViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Connectivity Quality of Service";

		public ConnectivityQualityOfServiceViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			typeOfConnectivityResource.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(typeOfConnectivityResource));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}



	/// <summary>
	/// Information on how to reach a person or organisation by postal, internet, telephone, telex and radio systems.
	/// </summary>
	[CategoryOrder("ContactDetails",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ContactDetailsViewModel : InformationViewModel<ContactDetails> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private String? _contactInstructions  = default;

		[Category("ContactDetails")]
		[Editor(typeof(Editors.HorizonEditor<ContactDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? contactInstructions {
			get {
				return _contactInstructions;
			}
			set {
				SetValue(ref _contactInstructions, value);
			}
		}

		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<contactAddressViewModel> contactAddress  { get; set; } = new ();

		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<frequencyPairViewModel> frequencyPair  { get; set; } = new ();

		private informationViewModel? _information  = default;

		[Category("ContactDetails")]
		[ExpandableObject]
		[Optional]
		public informationViewModel? information {
			get {
				return _information;
			}
			set {
				SetValue(ref _information, value);
			}
		}

		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<onlineResourceViewModel> onlineResource  { get; set; } = new ();

		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<telecommunicationsViewModel> telecommunications  { get; set; } = new ();

		private String? _callName  = default;

		[Category("ContactDetails")]
		[Editor(typeof(Editors.HorizonEditor<ContactDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? callName {
			get {
				return _callName;
			}
			set {
				SetValue(ref _callName, value);
			}
		}

		private String? _callSign  = default;

		[Category("ContactDetails")]
		[Editor(typeof(Editors.HorizonEditor<ContactDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? callSign {
			get {
				return _callSign;
			}
			set {
				SetValue(ref _callSign, value);
			}
		}

		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();

		private String? _mMSICode  = default;

		[Category("ContactDetails")]
		[Editor(typeof(Editors.HorizonEditor<ContactDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? mMSICode {
			get {
				return _mMSICode;
			}
			set {
				SetValue(ref _mMSICode, value);
			}
		}

		private String? _language  = default;

		[Category("ContactDetails")]
		[Editor(typeof(Editors.HorizonEditor<ContactDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}


		#region InformationBindings

		public class AuthorityContactViewModel : ViewModelBase, IInformationBinding {
			public AuthorityContactViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "AuthorityContact",
					role = "theAuthority",
					roleType = roleType.association,
					informationTypes = ["Authority","RadioControlCentre"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<AuthorityContact> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = AuthorityContact,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<ContactDetailsViewModel.AuthorityContactViewModel> AuthorityContacts { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. AuthorityContacts.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public ContactDetailsViewModel Load(ContactDetails instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			contactInstructions = instance.contactInstructions;
			contactAddress.Clear();
			if (instance.contactAddress is not null) {
				foreach(var e in instance.contactAddress)
					contactAddress.Add(new contactAddressViewModel().Load(e));
			}
			frequencyPair.Clear();
			if (instance.frequencyPair is not null) {
				foreach(var e in instance.frequencyPair)
					frequencyPair.Add(new frequencyPairViewModel().Load(e));
			}
			information = new ();
			if (instance.information != default) {
				information.Load(instance.information);
			}
			onlineResource.Clear();
			if (instance.onlineResource is not null) {
				foreach(var e in instance.onlineResource)
					onlineResource.Add(new onlineResourceViewModel().Load(e));
			}
			telecommunications.Clear();
			if (instance.telecommunications is not null) {
				foreach(var e in instance.telecommunications)
					telecommunications.Add(new telecommunicationsViewModel().Load(e));
			}
			callName = instance.callName;
			callSign = instance.callSign;
			communicationChannel.Clear();
			if (instance.communicationChannel is not null) {
				foreach(var e in instance.communicationChannel)
					communicationChannel.Add(e);
			}
			mMSICode = instance.mMSICode;
			language = instance.language;
			return this;
		}

		public override string Serialize() {
			var instance = new ContactDetails {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				contactInstructions = this.contactInstructions,
				contactAddress = this.contactAddress.Select(e => e.Model).ToList(),
				frequencyPair = this.frequencyPair.Select(e => e.Model).ToList(),
				information = this.information?.Model,
				onlineResource = this.onlineResource.Select(e => e.Model).ToList(),
				telecommunications = this.telecommunications.Select(e => e.Model).ToList(),
				callName = this.callName,
				callSign = this.callSign,
				communicationChannel = this.communicationChannel.ToList(),
				mMSICode = this.mMSICode,
				language = this.language,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ContactDetails Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			contactInstructions = this._contactInstructions,
			contactAddress = this.contactAddress.Select(e => e.Model).ToList(),
			frequencyPair = this.frequencyPair.Select(e => e.Model).ToList(),
			information = this._information?.Model,
			onlineResource = this.onlineResource.Select(e => e.Model).ToList(),
			telecommunications = this.telecommunications.Select(e => e.Model).ToList(),
			callName = this._callName,
			callSign = this._callSign,
			communicationChannel = this.communicationChannel.ToList(),
			mMSICode = this._mMSICode,
			language = this._language,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => ContactDetails._informationBindingDefinitions;

		public ContactDetailsViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Contact Details";

		public ContactDetailsViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			contactAddress.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(contactAddress));
			};
			frequencyPair.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(frequencyPair));
			};
			onlineResource.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(onlineResource));
			};
			telecommunications.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(telecommunications));
			};
			communicationChannel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(communicationChannel));
			};
			AuthorityContacts.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(AuthorityContacts));
			};
		}
	}



	/// <summary>
	/// Nautical information about a related area or facility.
	/// </summary>
	[CategoryOrder("NauticalInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NauticalInformationViewModel : InformationViewModel<NauticalInformation> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private categoryOfAuthority? _categoryOfAuthority  = default;

		[Category("AbstractRxN")]
		[Editor(typeof(Editors.HorizonEditor<AbstractRxN>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfAuthority? categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

		[Browsable(false)]
		public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2,(categoryOfAuthority)3,(categoryOfAuthority)4,(categoryOfAuthority)5,(categoryOfAuthority)6,(categoryOfAuthority)7,(categoryOfAuthority)8,(categoryOfAuthority)9,(categoryOfAuthority)10,(categoryOfAuthority)11,(categoryOfAuthority)12,(categoryOfAuthority)13,(categoryOfAuthority)14,(categoryOfAuthority)15,(categoryOfAuthority)16];

		private textContentViewModel? _textContent  = default;

		[Category("AbstractRxN")]
		[ExpandableObject]
		[Optional]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}

		private graphicViewModel? _graphic  = default;

		[Category("AbstractRxN")]
		[ExpandableObject]
		[Optional]
		public graphicViewModel? graphic {
			get {
				return _graphic;
			}
			set {
				SetValue(ref _graphic, value);
			}
		}

		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();


		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		public NauticalInformationViewModel Load(NauticalInformation instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			categoryOfAuthority = instance.categoryOfAuthority;
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
			}
			graphic = new ();
			if (instance.graphic != default) {
				graphic.Load(instance.graphic);
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new NauticalInformation {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				categoryOfAuthority = this.categoryOfAuthority,
				textContent = this.textContent?.Model,
				graphic = this.graphic?.Model,
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public NauticalInformation Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			categoryOfAuthority = this._categoryOfAuthority,
			textContent = this._textContent?.Model,
			graphic = this._graphic?.Model,
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => NauticalInformation._informationBindingDefinitions;

		public NauticalInformationViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Nautical Information";

		public NauticalInformationViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(rxNCode));
			};
		}
	}



	/// <summary>
	/// Days when many services are not available. Often days of festivity or recreation or public holidays when normal working hours are limited, especially a national or religious festival, etc.
	/// </summary>
	[CategoryOrder("NonStandardWorkingDay",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NonStandardWorkingDayViewModel : InformationViewModel<NonStandardWorkingDay> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		[Category("NonStandardWorkingDay")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("NonStandardWorkingDay")]
		[Optional]
		public ObservableCollection<String> dateFixed  { get; set; } = new ();

		[Category("NonStandardWorkingDay")]
		[Optional]
		public ObservableCollection<String> dateVariable  { get; set; } = new ();


		#region InformationBindings

		public class ExceptionalWorkdayViewModel : ViewModelBase, IInformationBinding {
			public ExceptionalWorkdayViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "ExceptionalWorkday",
					role = "theServiceHours_nsdy",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ExceptionalWorkday> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ExceptionalWorkday,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<NonStandardWorkingDayViewModel.ExceptionalWorkdayViewModel> ExceptionalWorkdays { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. ExceptionalWorkdays.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public NonStandardWorkingDayViewModel Load(NonStandardWorkingDay instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			dateFixed.Clear();
			if (instance.dateFixed is not null) {
				foreach(var e in instance.dateFixed)
					dateFixed.Add(e);
			}
			dateVariable.Clear();
			if (instance.dateVariable is not null) {
				foreach(var e in instance.dateVariable)
					dateVariable.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new NonStandardWorkingDay {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				information = this.information.Select(e => e.Model).ToList(),
				dateFixed = this.dateFixed.ToList(),
				dateVariable = this.dateVariable.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public NonStandardWorkingDay Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			information = this.information.Select(e => e.Model).ToList(),
			dateFixed = this.dateFixed.ToList(),
			dateVariable = this.dateVariable.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => NonStandardWorkingDay._informationBindingDefinitions;

		public NonStandardWorkingDayViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Non-Standard Working Day";

		public NonStandardWorkingDayViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			dateFixed.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(dateFixed));
			};
			dateVariable.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(dateVariable));
			};
			ExceptionalWorkdays.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ExceptionalWorkdays));
			};
		}
	}



	/// <summary>
	/// The control centre of the radio service or radio stations
	/// </summary>
	[CategoryOrder("RadioControlCentre",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RadioControlCentreViewModel : InformationViewModel<RadioControlCentre> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private Boolean _isMRCC  = false;

		[Category("RadioControlCentre")]
		[Editor(typeof(Editors.HorizonEditor<RadioControlCentre>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public Boolean isMRCC {
			get {
				return _isMRCC;
			}
			set {
				SetValue(ref _isMRCC, value);
			}
		}

		private Boolean _acceptAMVER  = false;

		[Category("RadioControlCentre")]
		[Editor(typeof(Editors.HorizonEditor<RadioControlCentre>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public Boolean acceptAMVER {
			get {
				return _acceptAMVER;
			}
			set {
				SetValue(ref _acceptAMVER, value);
			}
		}

		[Category("RadioControlCentre")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private String? _hoursOfWatch  = default;

		[Category("RadioControlCentre")]
		[Editor(typeof(Editors.HorizonEditor<RadioControlCentre>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? hoursOfWatch {
			get {
				return _hoursOfWatch;
			}
			set {
				SetValue(ref _hoursOfWatch, value);
			}
		}


		#region InformationBindings

		public class AuthorityContactViewModel : ViewModelBase, IInformationBinding {
			public AuthorityContactViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "AuthorityContact",
					role = "theContactDetails",
					roleType = roleType.association,
					informationTypes = ["ContactDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<AuthorityContact> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = AuthorityContact,
			};
		}

		public class AuthorityHoursViewModel : ViewModelBase, IInformationBinding {
			public AuthorityHoursViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "AuthorityHours",
					role = "theServiceHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<AuthorityHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = AuthorityHours,
			};
		}

		public class TMASViewModel : ViewModelBase, IInformationBinding {
			public TMASViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "TMAS",
					role = "theTMAS",
					roleType = roleType.association,
					informationTypes = ["TelemedicalAssistanceService"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<TMAS> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = TMAS,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<RadioControlCentreViewModel.AuthorityContactViewModel> AuthorityContacts { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<RadioControlCentreViewModel.AuthorityHoursViewModel> AuthorityHours { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<RadioControlCentreViewModel.TMASViewModel> TMAS { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. AuthorityContacts.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. AuthorityHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. TMAS.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public RadioControlCentreViewModel Load(RadioControlCentre instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			isMRCC = instance.isMRCC;
			acceptAMVER = instance.acceptAMVER;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			hoursOfWatch = instance.hoursOfWatch;
			return this;
		}

		public override string Serialize() {
			var instance = new RadioControlCentre {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				isMRCC = this.isMRCC,
				acceptAMVER = this.acceptAMVER,
				information = this.information.Select(e => e.Model).ToList(),
				hoursOfWatch = this.hoursOfWatch,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RadioControlCentre Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			isMRCC = this._isMRCC,
			acceptAMVER = this._acceptAMVER,
			information = this.information.Select(e => e.Model).ToList(),
			hoursOfWatch = this._hoursOfWatch,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => RadioControlCentre._informationBindingDefinitions;

		public RadioControlCentreViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Radio Control Centre";

		public RadioControlCentreViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			AuthorityContacts.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(AuthorityContacts));
			};
			AuthorityHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(AuthorityHours));
			};
			TMAS.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(TMAS));
			};
		}
	}



	/// <summary>
	/// Recommendations for a related area or facility.
	/// </summary>
	[CategoryOrder("Recommendations",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RecommendationsViewModel : InformationViewModel<Recommendations> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private categoryOfAuthority? _categoryOfAuthority  = default;

		[Category("AbstractRxN")]
		[Editor(typeof(Editors.HorizonEditor<AbstractRxN>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfAuthority? categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

		[Browsable(false)]
		public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2,(categoryOfAuthority)3,(categoryOfAuthority)4,(categoryOfAuthority)5,(categoryOfAuthority)6,(categoryOfAuthority)7,(categoryOfAuthority)8,(categoryOfAuthority)9,(categoryOfAuthority)10,(categoryOfAuthority)11,(categoryOfAuthority)12,(categoryOfAuthority)13,(categoryOfAuthority)14,(categoryOfAuthority)15,(categoryOfAuthority)16];

		private textContentViewModel? _textContent  = default;

		[Category("AbstractRxN")]
		[ExpandableObject]
		[Optional]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}

		private graphicViewModel? _graphic  = default;

		[Category("AbstractRxN")]
		[ExpandableObject]
		[Optional]
		public graphicViewModel? graphic {
			get {
				return _graphic;
			}
			set {
				SetValue(ref _graphic, value);
			}
		}

		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();


		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		public RecommendationsViewModel Load(Recommendations instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			categoryOfAuthority = instance.categoryOfAuthority;
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
			}
			graphic = new ();
			if (instance.graphic != default) {
				graphic.Load(instance.graphic);
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Recommendations {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				categoryOfAuthority = this.categoryOfAuthority,
				textContent = this.textContent?.Model,
				graphic = this.graphic?.Model,
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Recommendations Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			categoryOfAuthority = this._categoryOfAuthority,
			textContent = this._textContent?.Model,
			graphic = this._graphic?.Model,
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Recommendations._informationBindingDefinitions;

		public RecommendationsViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Recommendations";

		public RecommendationsViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(rxNCode));
			};
		}
	}



	/// <summary>
	/// Regulations for a related area or facility.
	/// </summary>
	[CategoryOrder("Regulations",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RegulationsViewModel : InformationViewModel<Regulations> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private categoryOfAuthority? _categoryOfAuthority  = default;

		[Category("AbstractRxN")]
		[Editor(typeof(Editors.HorizonEditor<AbstractRxN>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfAuthority? categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

		[Browsable(false)]
		public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2,(categoryOfAuthority)3,(categoryOfAuthority)4,(categoryOfAuthority)5,(categoryOfAuthority)6,(categoryOfAuthority)7,(categoryOfAuthority)8,(categoryOfAuthority)9,(categoryOfAuthority)10,(categoryOfAuthority)11,(categoryOfAuthority)12,(categoryOfAuthority)13,(categoryOfAuthority)14,(categoryOfAuthority)15,(categoryOfAuthority)16];

		private textContentViewModel? _textContent  = default;

		[Category("AbstractRxN")]
		[ExpandableObject]
		[Optional]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}

		private graphicViewModel? _graphic  = default;

		[Category("AbstractRxN")]
		[ExpandableObject]
		[Optional]
		public graphicViewModel? graphic {
			get {
				return _graphic;
			}
			set {
				SetValue(ref _graphic, value);
			}
		}

		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();


		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		public RegulationsViewModel Load(Regulations instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			categoryOfAuthority = instance.categoryOfAuthority;
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
			}
			graphic = new ();
			if (instance.graphic != default) {
				graphic.Load(instance.graphic);
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Regulations {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				categoryOfAuthority = this.categoryOfAuthority,
				textContent = this.textContent?.Model,
				graphic = this.graphic?.Model,
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Regulations Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			categoryOfAuthority = this._categoryOfAuthority,
			textContent = this._textContent?.Model,
			graphic = this._graphic?.Model,
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Regulations._informationBindingDefinitions;

		public RegulationsViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Regulations";

		public RegulationsViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(rxNCode));
			};
		}
	}



	/// <summary>
	/// Restrictions for a related area or facility.
	/// </summary>
	[CategoryOrder("Restrictions",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RestrictionsViewModel : InformationViewModel<Restrictions> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private categoryOfAuthority? _categoryOfAuthority  = default;

		[Category("AbstractRxN")]
		[Editor(typeof(Editors.HorizonEditor<AbstractRxN>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfAuthority? categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

		[Browsable(false)]
		public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2,(categoryOfAuthority)3,(categoryOfAuthority)4,(categoryOfAuthority)5,(categoryOfAuthority)6,(categoryOfAuthority)7,(categoryOfAuthority)8,(categoryOfAuthority)9,(categoryOfAuthority)10,(categoryOfAuthority)11,(categoryOfAuthority)12,(categoryOfAuthority)13,(categoryOfAuthority)14,(categoryOfAuthority)15,(categoryOfAuthority)16];

		private textContentViewModel? _textContent  = default;

		[Category("AbstractRxN")]
		[ExpandableObject]
		[Optional]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}

		private graphicViewModel? _graphic  = default;

		[Category("AbstractRxN")]
		[ExpandableObject]
		[Optional]
		public graphicViewModel? graphic {
			get {
				return _graphic;
			}
			set {
				SetValue(ref _graphic, value);
			}
		}

		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();


		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		public RestrictionsViewModel Load(Restrictions instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			categoryOfAuthority = instance.categoryOfAuthority;
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
			}
			graphic = new ();
			if (instance.graphic != default) {
				graphic.Load(instance.graphic);
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Restrictions {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				categoryOfAuthority = this.categoryOfAuthority,
				textContent = this.textContent?.Model,
				graphic = this.graphic?.Model,
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Restrictions Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			categoryOfAuthority = this._categoryOfAuthority,
			textContent = this._textContent?.Model,
			graphic = this._graphic?.Model,
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Restrictions._informationBindingDefinitions;

		public RestrictionsViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Restrictions";

		public RestrictionsViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(rxNCode));
			};
		}
	}



	/// <summary>
	/// The time when a service is available and known exceptions.
	/// </summary>
	[CategoryOrder("ServiceHours",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ServiceHoursViewModel : InformationViewModel<ServiceHours> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		[Category("ServiceHours")]
		[Multiplicity(1)]
		public ObservableCollection<scheduleByDayOfWeekViewModel> scheduleByDayOfWeek  { get; set; } = new ();

		[Category("ServiceHours")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		#region InformationBindings

		public class AuthorityHoursViewModel : ViewModelBase, IInformationBinding {
			public AuthorityHoursViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "AuthorityHours",
					role = "theAuthority",
					roleType = roleType.association,
					informationTypes = ["Authority","RadioControlCentre"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<AuthorityHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = AuthorityHours,
			};
		}

		public class ExceptionalWorkdayViewModel : ViewModelBase, IInformationBinding {
			public ExceptionalWorkdayViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "ExceptionalWorkday",
					role = "partialWorkingDay",
					roleType = roleType.association,
					informationTypes = ["NonStandardWorkingDay"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ExceptionalWorkday> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ExceptionalWorkday,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<ServiceHoursViewModel.AuthorityHoursViewModel> AuthorityHours { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<ServiceHoursViewModel.ExceptionalWorkdayViewModel> ExceptionalWorkdays { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. AuthorityHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. ExceptionalWorkdays.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public ServiceHoursViewModel Load(ServiceHours instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			scheduleByDayOfWeek.Clear();
			if (instance.scheduleByDayOfWeek is not null) {
				foreach(var e in instance.scheduleByDayOfWeek)
					scheduleByDayOfWeek.Add(new scheduleByDayOfWeekViewModel().Load(e));
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new ServiceHours {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				scheduleByDayOfWeek = this.scheduleByDayOfWeek.Select(e => e.Model).ToList(),
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ServiceHours Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			scheduleByDayOfWeek = this.scheduleByDayOfWeek.Select(e => e.Model).ToList(),
			information = this.information.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => ServiceHours._informationBindingDefinitions;

		public ServiceHoursViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Service Hours";

		public ServiceHoursViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			scheduleByDayOfWeek.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(scheduleByDayOfWeek));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			AuthorityHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(AuthorityHours));
			};
			ExceptionalWorkdays.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ExceptionalWorkdays));
			};
		}
	}



	/// <summary>
	/// The indication of the quality of the locational information for features in a dataset.
	/// </summary>
	[CategoryOrder("SpatialQuality",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SpatialQualityViewModel : InformationViewModel<SpatialQuality> {
		private qualityOfHorizontalMeasurement? _qualityOfHorizontalMeasurement  = default;

		[Category("SpatialQuality")]
		[Editor(typeof(Editors.HorizonEditor<SpatialQuality>), typeof(Editors.HorizonEditor))]
		[Optional]
		public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement {
			get {
				return _qualityOfHorizontalMeasurement;
			}
			set {
				SetValue(ref _qualityOfHorizontalMeasurement, value);
			}
		}

		[Browsable(false)]
		public qualityOfHorizontalMeasurement[] qualityOfHorizontalMeasurementList => [(qualityOfHorizontalMeasurement)4];

		private spatialAccuracyViewModel? _spatialAccuracy  = default;

		[Category("SpatialQuality")]
		[ExpandableObject]
		[Optional]
		public spatialAccuracyViewModel? spatialAccuracy {
			get {
				return _spatialAccuracy;
			}
			set {
				SetValue(ref _spatialAccuracy, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		public SpatialQualityViewModel Load(SpatialQuality instance) {
			qualityOfHorizontalMeasurement = instance.qualityOfHorizontalMeasurement;
			spatialAccuracy = new ();
			if (instance.spatialAccuracy != default) {
				spatialAccuracy.Load(instance.spatialAccuracy);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new SpatialQuality {
				qualityOfHorizontalMeasurement = this.qualityOfHorizontalMeasurement,
				spatialAccuracy = this.spatialAccuracy?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SpatialQuality Model => new () {
			qualityOfHorizontalMeasurement = this._qualityOfHorizontalMeasurement,
			spatialAccuracy = this._spatialAccuracy?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => SpatialQuality._informationBindingDefinitions;

		public SpatialQualityViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Spatial Quality";
	}



	/// <summary>
	/// A service to provide decision support and advice to the seafarer on board responsible for medical care.
	/// </summary>
	[CategoryOrder("TelemedicalAssistanceService",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TelemedicalAssistanceServiceViewModel : InformationViewModel<TelemedicalAssistanceService> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private String? _contactInstructions  = default;

		[Category("TelemedicalAssistanceService")]
		[Editor(typeof(Editors.HorizonEditor<TelemedicalAssistanceService>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? contactInstructions {
			get {
				return _contactInstructions;
			}
			set {
				SetValue(ref _contactInstructions, value);
			}
		}

		private informationViewModel? _information  = default;

		[Category("TelemedicalAssistanceService")]
		[ExpandableObject]
		[Optional]
		public informationViewModel? information {
			get {
				return _information;
			}
			set {
				SetValue(ref _information, value);
			}
		}

		[Category("TelemedicalAssistanceService")]
		[Optional]
		public ObservableCollection<onlineResourceViewModel> onlineResource  { get; set; } = new ();

		[Category("TelemedicalAssistanceService")]
		[Optional]
		public ObservableCollection<telecommunicationsViewModel> telecommunications  { get; set; } = new ();

		private String? _languageInformation  = default;

		[Category("TelemedicalAssistanceService")]
		[Editor(typeof(Editors.HorizonEditor<TelemedicalAssistanceService>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? languageInformation {
			get {
				return _languageInformation;
			}
			set {
				SetValue(ref _languageInformation, value);
			}
		}


		#region InformationBindings

		public class RadioServiceControlViewModel : ViewModelBase, IInformationBinding {
			public RadioServiceControlViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "RadioServiceControl",
					role = "theControlCentre",
					roleType = roleType.association,
					informationTypes = ["RadioControlCentre"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<RadioServiceControl> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = RadioServiceControl,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<TelemedicalAssistanceServiceViewModel.RadioServiceControlViewModel> RadioServiceControls { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. RadioServiceControls.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public TelemedicalAssistanceServiceViewModel Load(TelemedicalAssistanceService instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			contactInstructions = instance.contactInstructions;
			information = new ();
			if (instance.information != default) {
				information.Load(instance.information);
			}
			onlineResource.Clear();
			if (instance.onlineResource is not null) {
				foreach(var e in instance.onlineResource)
					onlineResource.Add(new onlineResourceViewModel().Load(e));
			}
			telecommunications.Clear();
			if (instance.telecommunications is not null) {
				foreach(var e in instance.telecommunications)
					telecommunications.Add(new telecommunicationsViewModel().Load(e));
			}
			languageInformation = instance.languageInformation;
			return this;
		}

		public override string Serialize() {
			var instance = new TelemedicalAssistanceService {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				contactInstructions = this.contactInstructions,
				information = this.information?.Model,
				onlineResource = this.onlineResource.Select(e => e.Model).ToList(),
				telecommunications = this.telecommunications.Select(e => e.Model).ToList(),
				languageInformation = this.languageInformation,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public TelemedicalAssistanceService Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			contactInstructions = this._contactInstructions,
			information = this._information?.Model,
			onlineResource = this.onlineResource.Select(e => e.Model).ToList(),
			telecommunications = this.telecommunications.Select(e => e.Model).ToList(),
			languageInformation = this._languageInformation,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => TelemedicalAssistanceService._informationBindingDefinitions;

		public TelemedicalAssistanceServiceViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Telemedical Assistance Service";

		public TelemedicalAssistanceServiceViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			onlineResource.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(onlineResource));
			};
			telecommunications.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(telecommunications));
			};
			RadioServiceControls.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(RadioServiceControls));
			};
		}
	}



	/// <summary>
	/// Description of the radiocommunication service with respect to the radio method and radio channels for the transfer of information by means of signals.
	/// </summary>
	[CategoryOrder("TransmissionDetails",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TransmissionDetailsViewModel : InformationViewModel<TransmissionDetails> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private typeOfRadioService? _typeOfRadioService  = default;

		[Category("TransmissionDetails")]
		[Editor(typeof(Editors.HorizonEditor<TransmissionDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
		public typeOfRadioService? typeOfRadioService {
			get {
				return _typeOfRadioService;
			}
			set {
				SetValue(ref _typeOfRadioService, value);
			}
		}

		[Browsable(false)]
		public typeOfRadioService[] typeOfRadioServiceList => [(typeOfRadioService)1,(typeOfRadioService)2,(typeOfRadioService)3,(typeOfRadioService)4,(typeOfRadioService)5,(typeOfRadioService)6,(typeOfRadioService)7,(typeOfRadioService)8,(typeOfRadioService)9,(typeOfRadioService)10,(typeOfRadioService)11,(typeOfRadioService)12,(typeOfRadioService)13];

		private frequencyBand? _frequencyBand  = default;

		[Category("TransmissionDetails")]
		[Editor(typeof(Editors.HorizonEditor<TransmissionDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
		public frequencyBand? frequencyBand {
			get {
				return _frequencyBand;
			}
			set {
				SetValue(ref _frequencyBand, value);
			}
		}

		[Browsable(false)]
		public frequencyBand[] frequencyBandList => [(frequencyBand)1,(frequencyBand)2,(frequencyBand)3,(frequencyBand)4,(frequencyBand)5,(frequencyBand)6];

		private String? _classOfEmission  = default;

		[Category("TransmissionDetails")]
		[Editor(typeof(Editors.HorizonEditor<TransmissionDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? classOfEmission {
			get {
				return _classOfEmission;
			}
			set {
				SetValue(ref _classOfEmission, value);
			}
		}

		private String? _communicationStandard  = default;

		[Category("TransmissionDetails")]
		[Editor(typeof(Editors.HorizonEditor<TransmissionDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? communicationStandard {
			get {
				return _communicationStandard;
			}
			set {
				SetValue(ref _communicationStandard, value);
			}
		}

		[Category("TransmissionDetails")]
		[Multiplicity(1)]
		public ObservableCollection<radioChannelDetailsViewModel> radioChannelDetails  { get; set; } = new ();


		#region InformationBindings

		public class BroadcastTransmissionViewModel : ViewModelBase, IInformationBinding {
			public BroadcastTransmissionViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "BroadcastTransmission",
					role = "theBroadcastDetails",
					roleType = roleType.association,
					informationTypes = ["BroadcastDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<BroadcastTransmission> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = BroadcastTransmission,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<TransmissionDetailsViewModel.BroadcastTransmissionViewModel> BroadcastTransmissions { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. BroadcastTransmissions.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public TransmissionDetailsViewModel Load(TransmissionDetails instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			typeOfRadioService = instance.typeOfRadioService;
			frequencyBand = instance.frequencyBand;
			classOfEmission = instance.classOfEmission;
			communicationStandard = instance.communicationStandard;
			radioChannelDetails.Clear();
			if (instance.radioChannelDetails is not null) {
				foreach(var e in instance.radioChannelDetails)
					radioChannelDetails.Add(new radioChannelDetailsViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new TransmissionDetails {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				typeOfRadioService = this.typeOfRadioService,
				frequencyBand = this.frequencyBand,
				classOfEmission = this.classOfEmission,
				communicationStandard = this.communicationStandard,
				radioChannelDetails = this.radioChannelDetails.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public TransmissionDetails Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			typeOfRadioService = this._typeOfRadioService,
			frequencyBand = this._frequencyBand,
			classOfEmission = this._classOfEmission,
			communicationStandard = this._communicationStandard,
			radioChannelDetails = this.radioChannelDetails.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => TransmissionDetails._informationBindingDefinitions;

		public TransmissionDetailsViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Transmission Details";

		public TransmissionDetailsViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			radioChannelDetails.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(radioChannelDetails));
			};
			BroadcastTransmissions.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(BroadcastTransmissions));
			};
		}
	}



	/// <summary>
	/// An area of connectivity coverage available for the subscription of connectivity service.
	/// </summary>
	[CategoryOrder("ConnectivitySubscriptionArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ConnectivitySubscriptionAreaViewModel : FeatureViewModel<ConnectivitySubscriptionArea> {
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _source  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("FeatureType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private String? _interoperabilityIdentifier  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		private categoryOfConnectivitySubscription? _categoryOfConnectivitySubscription  = default;

		[Category("ConnectivitySubscriptionArea")]
		[Editor(typeof(Editors.HorizonEditor<ConnectivitySubscriptionArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfConnectivitySubscription? categoryOfConnectivitySubscription {
			get {
				return _categoryOfConnectivitySubscription;
			}
			set {
				SetValue(ref _categoryOfConnectivitySubscription, value);
			}
		}

		[Browsable(false)]
		public categoryOfConnectivitySubscription[] categoryOfConnectivitySubscriptionList => [(categoryOfConnectivitySubscription)1,(categoryOfConnectivitySubscription)2,(categoryOfConnectivitySubscription)3,(categoryOfConnectivitySubscription)4];

		private String? _communicationStandard  = default;

		[Category("ConnectivitySubscriptionArea")]
		[Editor(typeof(Editors.HorizonEditor<ConnectivitySubscriptionArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? communicationStandard {
			get {
				return _communicationStandard;
			}
			set {
				SetValue(ref _communicationStandard, value);
			}
		}

		private double? _estimatedRangeOfTransmission  = default;

		[Category("ConnectivitySubscriptionArea")]
		[Editor(typeof(Editors.HorizonEditor<ConnectivitySubscriptionArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? estimatedRangeOfTransmission {
			get {
				return _estimatedRangeOfTransmission;
			}
			set {
				SetValue(ref _estimatedRangeOfTransmission, value);
			}
		}

		private double? _baseStationAntennaHeight  = default;

		[Category("ConnectivitySubscriptionArea")]
		[Editor(typeof(Editors.HorizonEditor<ConnectivitySubscriptionArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? baseStationAntennaHeight {
			get {
				return _baseStationAntennaHeight;
			}
			set {
				SetValue(ref _baseStationAntennaHeight, value);
			}
		}

		[Category("ConnectivitySubscriptionArea")]
		[Optional]
		public ObservableCollection<frequencyRangeViewModel> frequencyRange  { get; set; } = new ();

		[Category("ConnectivitySubscriptionArea")]
		[Optional]
		public ObservableCollection<sectorLimitViewModel> sectorLimit  { get; set; } = new ();

		private coverageIndicationViewModel? _coverageIndication  = default;

		[Category("ConnectivitySubscriptionArea")]
		[ExpandableObject]
		[Optional]
		public coverageIndicationViewModel? coverageIndication {
			get {
				return _coverageIndication;
			}
			set {
				SetValue(ref _coverageIndication, value);
			}
		}


		#region InformationBindings

		public class ConnectivityServiceViewModel : ViewModelBase, IInformationBinding {
			public ConnectivityServiceViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "ConnectivityService",
					role = "connectivityServiceProvider",
					roleType = roleType.association,
					informationTypes = ["Authority"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ConnectivityService> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ConnectivityService,
			};
		}

		public class ServiceContactViewModel : ViewModelBase, IInformationBinding {
			public ServiceContactViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceContact",
					role = "theContactDetails",
					roleType = roleType.association,
					informationTypes = ["ContactDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceContact> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceContact,
			};
		}

		public class LocationHoursViewModel : ViewModelBase, IInformationBinding {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "theServiceHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		public class AvailableQoSViewModel : ViewModelBase, IInformationBinding {
			public AvailableQoSViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "AvailableQoS",
					role = "theQoS",
					roleType = roleType.association,
					informationTypes = ["ConnectivityQualityOfService"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<AvailableQoS> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = AvailableQoS,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<ConnectivitySubscriptionAreaViewModel.ConnectivityServiceViewModel> ConnectivityServices { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<ConnectivitySubscriptionAreaViewModel.ServiceContactViewModel> ServiceContacts { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<ConnectivitySubscriptionAreaViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<ConnectivitySubscriptionAreaViewModel.AvailableQoSViewModel> AvailableQoS { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. ConnectivityServices.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. ServiceContacts.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. AvailableQoS.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		#region FeatureBindings

		public class ServiceProvisionAreaViewModel : ViewModelBase, IFeatureBinding {
			public ServiceProvisionAreaViewModel() {
				if (featureBindings.Length == 1)
					this.role = featureBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.FeatureBindingRoleEditor), typeof(Editors.FeatureBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.FeatureBindingLinkEditor), typeof(Editors.FeatureBindingLinkEditor))]
			public string featureId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _featureType = default;

			[ReadOnly(true)]
			public string? featureType {
				get { return _featureType; }
				set {
					SetValue(ref _featureType, value);
				}
			}

			private S123.ServiceProvisionAreaViewModel _association = new();

			[ExpandableObject]
			public S123.ServiceProvisionAreaViewModel association {
				get { return _association; }
				set {
					SetValue(ref _association, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceProvisionArea",
					role = "serviceProvider",
					roleType = roleType.association,
					featureTypes = ["RadioStation"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<ServiceProvisionArea> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceProvisionArea,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<ConnectivitySubscriptionAreaViewModel.ServiceProvisionAreaViewModel> ServiceProvisionAreas { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. ServiceProvisionAreas.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public ConnectivitySubscriptionAreaViewModel Load(ConnectivitySubscriptionArea instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			categoryOfConnectivitySubscription = instance.categoryOfConnectivitySubscription;
			communicationStandard = instance.communicationStandard;
			estimatedRangeOfTransmission = instance.estimatedRangeOfTransmission;
			baseStationAntennaHeight = instance.baseStationAntennaHeight;
			frequencyRange.Clear();
			if (instance.frequencyRange is not null) {
				foreach(var e in instance.frequencyRange)
					frequencyRange.Add(new frequencyRangeViewModel().Load(e));
			}
			sectorLimit.Clear();
			if (instance.sectorLimit is not null) {
				foreach(var e in instance.sectorLimit)
					sectorLimit.Add(new sectorLimitViewModel().Load(e));
			}
			coverageIndication = new ();
			if (instance.coverageIndication != default) {
				coverageIndication.Load(instance.coverageIndication);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new ConnectivitySubscriptionArea {
				textContent = this.textContent.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				categoryOfConnectivitySubscription = this.categoryOfConnectivitySubscription,
				communicationStandard = this.communicationStandard,
				estimatedRangeOfTransmission = this.estimatedRangeOfTransmission,
				baseStationAntennaHeight = this.baseStationAntennaHeight,
				frequencyRange = this.frequencyRange.Select(e => e.Model).ToList(),
				sectorLimit = this.sectorLimit.Select(e => e.Model).ToList(),
				coverageIndication = this.coverageIndication?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ConnectivitySubscriptionArea Model => new () {
			textContent = this.textContent.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			categoryOfConnectivitySubscription = this._categoryOfConnectivitySubscription,
			communicationStandard = this._communicationStandard,
			estimatedRangeOfTransmission = this._estimatedRangeOfTransmission,
			baseStationAntennaHeight = this._baseStationAntennaHeight,
			frequencyRange = this.frequencyRange.Select(e => e.Model).ToList(),
			sectorLimit = this.sectorLimit.Select(e => e.Model).ToList(),
			coverageIndication = this._coverageIndication?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => ConnectivitySubscriptionArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. ConnectivitySubscriptionArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => ConnectivitySubscriptionArea._featureBindingDefinitions;

		public ConnectivitySubscriptionAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public ConnectivitySubscriptionAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Connectivity Subscription Area";

		public ConnectivitySubscriptionAreaViewModel() : base() {
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			frequencyRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(frequencyRange));
			};
			sectorLimit.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sectorLimit));
			};
			ConnectivityServices.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ConnectivityServices));
			};
			ServiceContacts.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceContacts));
			};
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
			AvailableQoS.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(AvailableQoS));
			};
			ServiceProvisionAreas.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ServiceProvisionAreas));
			};
		}
	}



	/// <summary>
	/// An area defined for a global communications service based upon automated systems, both satellite based and terrestrial, to provide distress alerting and promulgation of maritime safety information for mariners.
	/// </summary>
	[CategoryOrder("GMDSSArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class GMDSSAreaViewModel : FeatureViewModel<GMDSSArea> {
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _source  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("FeatureType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private String? _interoperabilityIdentifier  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		private String _idNAVAREA  = string.Empty;

		[Category("GMDSSArea")]
		[Editor(typeof(Editors.HorizonEditor<GMDSSArea>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String idNAVAREA {
			get {
				return _idNAVAREA;
			}
			set {
				SetValue(ref _idNAVAREA, value);
			}
		}

		private String? _nationality  = default;

		[Category("GMDSSArea")]
		[Editor(typeof(Editors.HorizonEditor<GMDSSArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? nationality {
			get {
				return _nationality;
			}
			set {
				SetValue(ref _nationality, value);
			}
		}

		private categoryOfGMDSSArea _categoryOfGMDSSArea  = default;

		[Category("GMDSSArea")]
		[Editor(typeof(Editors.HorizonEditor<GMDSSArea>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public categoryOfGMDSSArea categoryOfGMDSSArea {
			get {
				return _categoryOfGMDSSArea;
			}
			set {
				SetValue(ref _categoryOfGMDSSArea, value);
			}
		}

		[Browsable(false)]
		public categoryOfGMDSSArea[] categoryOfGMDSSAreaList => [(categoryOfGMDSSArea)1,(categoryOfGMDSSArea)2,(categoryOfGMDSSArea)3,(categoryOfGMDSSArea)4];

		[Category("GMDSSArea")]
		[Optional]
		public ObservableCollection<areaA3ServiceDescriptionViewModel> areaA3ServiceDescription  { get; set; } = new ();


		#region InformationBindings

		public class ServiceCoordinationViewModel : ViewModelBase, IInformationBinding {
			public ServiceCoordinationViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceCoordination",
					role = "coordinatingAuthority",
					roleType = roleType.association,
					informationTypes = ["Authority"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceCoordination> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceCoordination,
			};
		}

		public class RadioServiceControlViewModel : ViewModelBase, IInformationBinding {
			public RadioServiceControlViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "RadioServiceControl",
					role = "theControlCentre",
					roleType = roleType.association,
					informationTypes = ["RadioControlCentre"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<RadioServiceControl> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = RadioServiceControl,
			};
		}

		public class ServiceContactViewModel : ViewModelBase, IInformationBinding {
			public ServiceContactViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceContact",
					role = "theContactDetails",
					roleType = roleType.association,
					informationTypes = ["ContactDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceContact> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceContact,
			};
		}

		public class LocationHoursViewModel : ViewModelBase, IInformationBinding {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "theServiceHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<GMDSSAreaViewModel.ServiceCoordinationViewModel> ServiceCoordinations { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<GMDSSAreaViewModel.RadioServiceControlViewModel> RadioServiceControls { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<GMDSSAreaViewModel.ServiceContactViewModel> ServiceContacts { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<GMDSSAreaViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. ServiceCoordinations.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. RadioServiceControls.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. ServiceContacts.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		#region FeatureBindings

		public class ServiceProvisionAreaViewModel : ViewModelBase, IFeatureBinding {
			public ServiceProvisionAreaViewModel() {
				if (featureBindings.Length == 1)
					this.role = featureBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.FeatureBindingRoleEditor), typeof(Editors.FeatureBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.FeatureBindingLinkEditor), typeof(Editors.FeatureBindingLinkEditor))]
			public string featureId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _featureType = default;

			[ReadOnly(true)]
			public string? featureType {
				get { return _featureType; }
				set {
					SetValue(ref _featureType, value);
				}
			}

			private S123.ServiceProvisionAreaViewModel _association = new();

			[ExpandableObject]
			public S123.ServiceProvisionAreaViewModel association {
				get { return _association; }
				set {
					SetValue(ref _association, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceProvisionArea",
					role = "serviceProvider",
					roleType = roleType.association,
					featureTypes = ["RadioStation"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<ServiceProvisionArea> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceProvisionArea,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<GMDSSAreaViewModel.ServiceProvisionAreaViewModel> ServiceProvisionAreas { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. ServiceProvisionAreas.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public GMDSSAreaViewModel Load(GMDSSArea instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			idNAVAREA = instance.idNAVAREA;
			nationality = instance.nationality;
			categoryOfGMDSSArea = instance.categoryOfGMDSSArea;
			areaA3ServiceDescription.Clear();
			if (instance.areaA3ServiceDescription is not null) {
				foreach(var e in instance.areaA3ServiceDescription)
					areaA3ServiceDescription.Add(new areaA3ServiceDescriptionViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new GMDSSArea {
				textContent = this.textContent.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				idNAVAREA = this.idNAVAREA,
				nationality = this.nationality,
				categoryOfGMDSSArea = this.categoryOfGMDSSArea,
				areaA3ServiceDescription = this.areaA3ServiceDescription.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public GMDSSArea Model => new () {
			textContent = this.textContent.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			idNAVAREA = this._idNAVAREA,
			nationality = this._nationality,
			categoryOfGMDSSArea = this._categoryOfGMDSSArea,
			areaA3ServiceDescription = this.areaA3ServiceDescription.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => GMDSSArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. GMDSSArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => GMDSSArea._featureBindingDefinitions;

		public GMDSSAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public GMDSSAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"GMDSS Area";

		public GMDSSAreaViewModel() : base() {
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			areaA3ServiceDescription.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(areaA3ServiceDescription));
			};
			ServiceCoordinations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceCoordinations));
			};
			RadioServiceControls.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(RadioServiceControls));
			};
			ServiceContacts.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceContacts));
			};
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
			ServiceProvisionAreas.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ServiceProvisionAreas));
			};
		}
	}



	/// <summary>
	/// A region in which the perception of a phenomenon or the availability of a service is known only to a specified level of confidence.
	/// </summary>
	[CategoryOrder("IndeterminateZone",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class IndeterminateZoneViewModel : FeatureViewModel<IndeterminateZone> {
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _source  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("FeatureType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private String? _interoperabilityIdentifier  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		private informationConfidence? _informationConfidence  = default;

		[Category("IndeterminateZone")]
		[Editor(typeof(Editors.HorizonEditor<IndeterminateZone>), typeof(Editors.HorizonEditor))]
		[Optional]
		public informationConfidence? informationConfidence {
			get {
				return _informationConfidence;
			}
			set {
				SetValue(ref _informationConfidence, value);
			}
		}

		[Browsable(false)]
		public informationConfidence[] informationConfidenceList => [(informationConfidence)1,(informationConfidence)2,(informationConfidence)3,(informationConfidence)4];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		#region FeatureBindings

		public class fuzzyZoneAggregationViewModel : ViewModelBase, IFeatureBinding {
			public fuzzyZoneAggregationViewModel() {
				if (featureBindings.Length == 1)
					this.role = featureBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.FeatureBindingRoleEditor), typeof(Editors.FeatureBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.FeatureBindingLinkEditor), typeof(Editors.FeatureBindingLinkEditor))]
			public string featureId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _featureType = default;

			[ReadOnly(true)]
			public string? featureType {
				get { return _featureType; }
				set {
					SetValue(ref _featureType, value);
				}
			}

			private S123.fuzzyZoneAggregationViewModel _association = new();

			[ExpandableObject]
			public S123.fuzzyZoneAggregationViewModel association {
				get { return _association; }
				set {
					SetValue(ref _association, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 1,
					upper = 1,
					association = "fuzzyZoneAggregation",
					role = "theCollection",
					roleType = roleType.composition,
					featureTypes = ["FuzzyAreaAggregate"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<fuzzyZoneAggregation> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = fuzzyZoneAggregation,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<IndeterminateZoneViewModel.fuzzyZoneAggregationViewModel> fuzzyZoneAggregations { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. fuzzyZoneAggregations.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public IndeterminateZoneViewModel Load(IndeterminateZone instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			informationConfidence = instance.informationConfidence;
			return this;
		}

		public override string Serialize() {
			var instance = new IndeterminateZone {
				textContent = this.textContent.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				informationConfidence = this.informationConfidence,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public IndeterminateZone Model => new () {
			textContent = this.textContent.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			informationConfidence = this._informationConfidence,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => IndeterminateZone._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. IndeterminateZone._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => IndeterminateZone._featureBindingDefinitions;

		public IndeterminateZoneViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public IndeterminateZoneViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Indeterminate Zone";

		public IndeterminateZoneViewModel() : base() {
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			fuzzyZoneAggregations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(fuzzyZoneAggregations));
			};
		}
	}



	/// <summary>
	/// A geographical sea area (which may include inland seas, lakes and waterways navigable by seagoing ships) established for the purpose of coordinating the broadcast of marine meteorological information.
	/// </summary>
	[CategoryOrder("MetArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class MetAreaViewModel : FeatureViewModel<MetArea> {
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _source  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("FeatureType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private String? _interoperabilityIdentifier  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		private String _idMETAREA  = string.Empty;

		[Category("MetArea")]
		[Editor(typeof(Editors.HorizonEditor<MetArea>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String idMETAREA {
			get {
				return _idMETAREA;
			}
			set {
				SetValue(ref _idMETAREA, value);
			}
		}

		[Category("MetArea")]
		[Optional]
		public ObservableCollection<onlineResourceViewModel> onlineResource  { get; set; } = new ();


		#region InformationBindings

		public class ServiceCoordinationViewModel : ViewModelBase, IInformationBinding {
			public ServiceCoordinationViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceCoordination",
					role = "coordinatingAuthority",
					roleType = roleType.association,
					informationTypes = ["Authority"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceCoordination> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceCoordination,
			};
		}

		public class ServiceContactViewModel : ViewModelBase, IInformationBinding {
			public ServiceContactViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceContact",
					role = "theContactDetails",
					roleType = roleType.association,
					informationTypes = ["ContactDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceContact> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceContact,
			};
		}

		public class LocationHoursViewModel : ViewModelBase, IInformationBinding {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "theServiceHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		public class BroadcastServiceViewModel : ViewModelBase, IInformationBinding {
			public BroadcastServiceViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "BroadcastService",
					role = "theBroadcastDetails",
					roleType = roleType.association,
					informationTypes = ["BroadcastDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<BroadcastService> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = BroadcastService,
			};
		}

		public class TransmissionServiceViewModel : ViewModelBase, IInformationBinding {
			public TransmissionServiceViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "TransmissionService",
					role = "theTransmissionDetails",
					roleType = roleType.association,
					informationTypes = ["TransmissionDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<TransmissionService> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = TransmissionService,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<MetAreaViewModel.ServiceCoordinationViewModel> ServiceCoordinations { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<MetAreaViewModel.ServiceContactViewModel> ServiceContacts { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<MetAreaViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<MetAreaViewModel.BroadcastServiceViewModel> BroadcastServices { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<MetAreaViewModel.TransmissionServiceViewModel> TransmissionServices { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. ServiceCoordinations.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. ServiceContacts.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. BroadcastServices.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. TransmissionServices.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		#region FeatureBindings

		public class ServiceProvisionAreaViewModel : ViewModelBase, IFeatureBinding {
			public ServiceProvisionAreaViewModel() {
				if (featureBindings.Length == 1)
					this.role = featureBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.FeatureBindingRoleEditor), typeof(Editors.FeatureBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.FeatureBindingLinkEditor), typeof(Editors.FeatureBindingLinkEditor))]
			public string featureId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _featureType = default;

			[ReadOnly(true)]
			public string? featureType {
				get { return _featureType; }
				set {
					SetValue(ref _featureType, value);
				}
			}

			private S123.ServiceProvisionAreaViewModel _association = new();

			[ExpandableObject]
			public S123.ServiceProvisionAreaViewModel association {
				get { return _association; }
				set {
					SetValue(ref _association, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceProvisionArea",
					role = "serviceProvider",
					roleType = roleType.association,
					featureTypes = ["RadioStation"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<ServiceProvisionArea> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceProvisionArea,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<MetAreaViewModel.ServiceProvisionAreaViewModel> ServiceProvisionAreas { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. ServiceProvisionAreas.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public MetAreaViewModel Load(MetArea instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			idMETAREA = instance.idMETAREA;
			onlineResource.Clear();
			if (instance.onlineResource is not null) {
				foreach(var e in instance.onlineResource)
					onlineResource.Add(new onlineResourceViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new MetArea {
				textContent = this.textContent.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				idMETAREA = this.idMETAREA,
				onlineResource = this.onlineResource.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public MetArea Model => new () {
			textContent = this.textContent.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			idMETAREA = this._idMETAREA,
			onlineResource = this.onlineResource.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => MetArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. MetArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => MetArea._featureBindingDefinitions;

		public MetAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public MetAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"METAREA";

		public MetAreaViewModel() : base() {
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			onlineResource.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(onlineResource));
			};
			ServiceCoordinations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceCoordinations));
			};
			ServiceContacts.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceContacts));
			};
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
			BroadcastServices.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(BroadcastServices));
			};
			TransmissionServices.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(TransmissionServices));
			};
			ServiceProvisionAreas.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ServiceProvisionAreas));
			};
		}
	}



	/// <summary>
	/// A geographical sea area (which may include inland seas, lakes and waterways navigable by seagoing ships) established for the purpose of coordinating the broadcast of navigational warnings.
	/// </summary>
	[CategoryOrder("NavArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NavAreaViewModel : FeatureViewModel<NavArea> {
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _source  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("FeatureType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private String? _interoperabilityIdentifier  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		private String _idNAVAREA  = string.Empty;

		[Category("NavArea")]
		[Editor(typeof(Editors.HorizonEditor<NavArea>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String idNAVAREA {
			get {
				return _idNAVAREA;
			}
			set {
				SetValue(ref _idNAVAREA, value);
			}
		}

		[Category("NavArea")]
		[Optional]
		public ObservableCollection<onlineResourceViewModel> onlineResource  { get; set; } = new ();


		#region InformationBindings

		public class ServiceCoordinationViewModel : ViewModelBase, IInformationBinding {
			public ServiceCoordinationViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceCoordination",
					role = "coordinatingAuthority",
					roleType = roleType.association,
					informationTypes = ["Authority"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceCoordination> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceCoordination,
			};
		}

		public class ServiceContactViewModel : ViewModelBase, IInformationBinding {
			public ServiceContactViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceContact",
					role = "theContactDetails",
					roleType = roleType.association,
					informationTypes = ["ContactDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceContact> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceContact,
			};
		}

		public class LocationHoursViewModel : ViewModelBase, IInformationBinding {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "theServiceHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		public class BroadcastServiceViewModel : ViewModelBase, IInformationBinding {
			public BroadcastServiceViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "BroadcastService",
					role = "theBroadcastDetails",
					roleType = roleType.association,
					informationTypes = ["BroadcastDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<BroadcastService> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = BroadcastService,
			};
		}

		public class TransmissionServiceViewModel : ViewModelBase, IInformationBinding {
			public TransmissionServiceViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "TransmissionService",
					role = "theTransmissionDetails",
					roleType = roleType.association,
					informationTypes = ["TransmissionDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<TransmissionService> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = TransmissionService,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<NavAreaViewModel.ServiceCoordinationViewModel> ServiceCoordinations { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<NavAreaViewModel.ServiceContactViewModel> ServiceContacts { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<NavAreaViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<NavAreaViewModel.BroadcastServiceViewModel> BroadcastServices { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<NavAreaViewModel.TransmissionServiceViewModel> TransmissionServices { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. ServiceCoordinations.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. ServiceContacts.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. BroadcastServices.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. TransmissionServices.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		#region FeatureBindings

		public class ServiceProvisionAreaViewModel : ViewModelBase, IFeatureBinding {
			public ServiceProvisionAreaViewModel() {
				if (featureBindings.Length == 1)
					this.role = featureBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.FeatureBindingRoleEditor), typeof(Editors.FeatureBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.FeatureBindingLinkEditor), typeof(Editors.FeatureBindingLinkEditor))]
			public string featureId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _featureType = default;

			[ReadOnly(true)]
			public string? featureType {
				get { return _featureType; }
				set {
					SetValue(ref _featureType, value);
				}
			}

			private S123.ServiceProvisionAreaViewModel _association = new();

			[ExpandableObject]
			public S123.ServiceProvisionAreaViewModel association {
				get { return _association; }
				set {
					SetValue(ref _association, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceProvisionArea",
					role = "serviceProvider",
					roleType = roleType.association,
					featureTypes = ["RadioStation"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<ServiceProvisionArea> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceProvisionArea,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<NavAreaViewModel.ServiceProvisionAreaViewModel> ServiceProvisionAreas { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. ServiceProvisionAreas.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public NavAreaViewModel Load(NavArea instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			idNAVAREA = instance.idNAVAREA;
			onlineResource.Clear();
			if (instance.onlineResource is not null) {
				foreach(var e in instance.onlineResource)
					onlineResource.Add(new onlineResourceViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new NavArea {
				textContent = this.textContent.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				idNAVAREA = this.idNAVAREA,
				onlineResource = this.onlineResource.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public NavArea Model => new () {
			textContent = this.textContent.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			idNAVAREA = this._idNAVAREA,
			onlineResource = this.onlineResource.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => NavArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. NavArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => NavArea._featureBindingDefinitions;

		public NavAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public NavAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"NAVAREA";

		public NavAreaViewModel() : base() {
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			onlineResource.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(onlineResource));
			};
			ServiceCoordinations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceCoordinations));
			};
			ServiceContacts.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceContacts));
			};
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
			BroadcastServices.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(BroadcastServices));
			};
			TransmissionServices.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(TransmissionServices));
			};
			ServiceProvisionAreas.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ServiceProvisionAreas));
			};
		}
	}



	/// <summary>
	/// A unique and precisely defined sea area, wholly contained within the NAVTEX coverage area, for which maritime safety information is provided from a particular NAVTEX transmitter.
	/// </summary>
	[CategoryOrder("NavtexServiceArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NavtexServiceAreaViewModel : FeatureViewModel<NavtexServiceArea> {
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _source  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("FeatureType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private String? _interoperabilityIdentifier  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		private typeOfNAVTEXService _typeOfNAVTEXService  = default;

		[Category("NavtexServiceArea")]
		[Editor(typeof(Editors.HorizonEditor<NavtexServiceArea>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public typeOfNAVTEXService typeOfNAVTEXService {
			get {
				return _typeOfNAVTEXService;
			}
			set {
				SetValue(ref _typeOfNAVTEXService, value);
			}
		}

		[Browsable(false)]
		public typeOfNAVTEXService[] typeOfNAVTEXServiceList => [(typeOfNAVTEXService)1,(typeOfNAVTEXService)2];

		private String _idNAVAREA  = string.Empty;

		[Category("NavtexServiceArea")]
		[Editor(typeof(Editors.HorizonEditor<NavtexServiceArea>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String idNAVAREA {
			get {
				return _idNAVAREA;
			}
			set {
				SetValue(ref _idNAVAREA, value);
			}
		}

		private String _transmitterIdentificationCharacter  = string.Empty;

		[Category("NavtexServiceArea")]
		[Editor(typeof(Editors.HorizonEditor<NavtexServiceArea>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String transmitterIdentificationCharacter {
			get {
				return _transmitterIdentificationCharacter;
			}
			set {
				SetValue(ref _transmitterIdentificationCharacter, value);
			}
		}

		private String? _nationality  = default;

		[Category("NavtexServiceArea")]
		[Editor(typeof(Editors.HorizonEditor<NavtexServiceArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? nationality {
			get {
				return _nationality;
			}
			set {
				SetValue(ref _nationality, value);
			}
		}

		private status? _status  = default;

		[Category("NavtexServiceArea")]
		[Editor(typeof(Editors.HorizonEditor<NavtexServiceArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public status? status {
			get {
				return _status;
			}
			set {
				SetValue(ref _status, value);
			}
		}

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)4,(status)7];


		#region InformationBindings

		public class ServiceCoordinationViewModel : ViewModelBase, IInformationBinding {
			public ServiceCoordinationViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceCoordination",
					role = "coordinatingAuthority",
					roleType = roleType.association,
					informationTypes = ["Authority"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceCoordination> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceCoordination,
			};
		}

		public class ServiceContactViewModel : ViewModelBase, IInformationBinding {
			public ServiceContactViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceContact",
					role = "theContactDetails",
					roleType = roleType.association,
					informationTypes = ["ContactDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceContact> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceContact,
			};
		}

		public class LocationHoursViewModel : ViewModelBase, IInformationBinding {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "theServiceHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		public class BroadcastServiceViewModel : ViewModelBase, IInformationBinding {
			public BroadcastServiceViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "BroadcastService",
					role = "theBroadcastDetails",
					roleType = roleType.association,
					informationTypes = ["BroadcastDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<BroadcastService> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = BroadcastService,
			};
		}

		public class TransmissionServiceViewModel : ViewModelBase, IInformationBinding {
			public TransmissionServiceViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "TransmissionService",
					role = "theTransmissionDetails",
					roleType = roleType.association,
					informationTypes = ["TransmissionDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<TransmissionService> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = TransmissionService,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<NavtexServiceAreaViewModel.ServiceCoordinationViewModel> ServiceCoordinations { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<NavtexServiceAreaViewModel.ServiceContactViewModel> ServiceContacts { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<NavtexServiceAreaViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<NavtexServiceAreaViewModel.BroadcastServiceViewModel> BroadcastServices { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<NavtexServiceAreaViewModel.TransmissionServiceViewModel> TransmissionServices { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. ServiceCoordinations.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. ServiceContacts.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. BroadcastServices.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. TransmissionServices.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		#region FeatureBindings

		public class ServiceProvisionAreaViewModel : ViewModelBase, IFeatureBinding {
			public ServiceProvisionAreaViewModel() {
				if (featureBindings.Length == 1)
					this.role = featureBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.FeatureBindingRoleEditor), typeof(Editors.FeatureBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.FeatureBindingLinkEditor), typeof(Editors.FeatureBindingLinkEditor))]
			public string featureId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _featureType = default;

			[ReadOnly(true)]
			public string? featureType {
				get { return _featureType; }
				set {
					SetValue(ref _featureType, value);
				}
			}

			private S123.ServiceProvisionAreaViewModel _association = new();

			[ExpandableObject]
			public S123.ServiceProvisionAreaViewModel association {
				get { return _association; }
				set {
					SetValue(ref _association, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceProvisionArea",
					role = "serviceProvider",
					roleType = roleType.association,
					featureTypes = ["RadioStation"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<ServiceProvisionArea> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceProvisionArea,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<NavtexServiceAreaViewModel.ServiceProvisionAreaViewModel> ServiceProvisionAreas { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. ServiceProvisionAreas.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public NavtexServiceAreaViewModel Load(NavtexServiceArea instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			typeOfNAVTEXService = instance.typeOfNAVTEXService;
			idNAVAREA = instance.idNAVAREA;
			transmitterIdentificationCharacter = instance.transmitterIdentificationCharacter;
			nationality = instance.nationality;
			status = instance.status;
			return this;
		}

		public override string Serialize() {
			var instance = new NavtexServiceArea {
				textContent = this.textContent.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				typeOfNAVTEXService = this.typeOfNAVTEXService,
				idNAVAREA = this.idNAVAREA,
				transmitterIdentificationCharacter = this.transmitterIdentificationCharacter,
				nationality = this.nationality,
				status = this.status,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public NavtexServiceArea Model => new () {
			textContent = this.textContent.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			typeOfNAVTEXService = this._typeOfNAVTEXService,
			idNAVAREA = this._idNAVAREA,
			transmitterIdentificationCharacter = this._transmitterIdentificationCharacter,
			nationality = this._nationality,
			status = this._status,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => NavtexServiceArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. NavtexServiceArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => NavtexServiceArea._featureBindingDefinitions;

		public NavtexServiceAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public NavtexServiceAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"NAVTEX Service Area";

		public NavtexServiceAreaViewModel() : base() {
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			ServiceCoordinations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceCoordinations));
			};
			ServiceContacts.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceContacts));
			};
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
			BroadcastServices.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(BroadcastServices));
			};
			TransmissionServices.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(TransmissionServices));
			};
			ServiceProvisionAreas.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ServiceProvisionAreas));
			};
		}
	}



	/// <summary>
	/// The area where a radio service can be obtained and the characteristics of the radio transmission.
	/// </summary>
	[CategoryOrder("RadioServiceArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RadioServiceAreaViewModel : FeatureViewModel<RadioServiceArea> {
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _source  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("FeatureType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private String? _interoperabilityIdentifier  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		private String? _languageInformation  = default;

		[Category("RadioServiceArea")]
		[Editor(typeof(Editors.HorizonEditor<RadioServiceArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? languageInformation {
			get {
				return _languageInformation;
			}
			set {
				SetValue(ref _languageInformation, value);
			}
		}

		private double? _transmissionPower  = default;

		[Category("RadioServiceArea")]
		[Editor(typeof(Editors.HorizonEditor<RadioServiceArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? transmissionPower {
			get {
				return _transmissionPower;
			}
			set {
				SetValue(ref _transmissionPower, value);
			}
		}

		private Boolean? _transmissionOfTrafficLists  = default;

		[Category("RadioServiceArea")]
		[Editor(typeof(Editors.HorizonEditor<RadioServiceArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? transmissionOfTrafficLists {
			get {
				return _transmissionOfTrafficLists;
			}
			set {
				SetValue(ref _transmissionOfTrafficLists, value);
			}
		}

		private status? _status  = default;

		[Category("RadioServiceArea")]
		[Editor(typeof(Editors.HorizonEditor<RadioServiceArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public status? status {
			get {
				return _status;
			}
			set {
				SetValue(ref _status, value);
			}
		}

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)14,(status)16,(status)17];

		private String? _hoursOfWatch  = default;

		[Category("RadioServiceArea")]
		[Editor(typeof(Editors.HorizonEditor<RadioServiceArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? hoursOfWatch {
			get {
				return _hoursOfWatch;
			}
			set {
				SetValue(ref _hoursOfWatch, value);
			}
		}


		#region InformationBindings

		public class ServiceCoordinationViewModel : ViewModelBase, IInformationBinding {
			public ServiceCoordinationViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceCoordination",
					role = "coordinatingAuthority",
					roleType = roleType.association,
					informationTypes = ["Authority"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceCoordination> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceCoordination,
			};
		}

		public class RadioServiceControlViewModel : ViewModelBase, IInformationBinding {
			public RadioServiceControlViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "RadioServiceControl",
					role = "theControlCentre",
					roleType = roleType.association,
					informationTypes = ["RadioControlCentre"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<RadioServiceControl> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = RadioServiceControl,
			};
		}

		public class ServiceContactViewModel : ViewModelBase, IInformationBinding {
			public ServiceContactViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceContact",
					role = "theContactDetails",
					roleType = roleType.association,
					informationTypes = ["ContactDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceContact> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceContact,
			};
		}

		public class LocationHoursViewModel : ViewModelBase, IInformationBinding {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "theServiceHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		public class BroadcastServiceViewModel : ViewModelBase, IInformationBinding {
			public BroadcastServiceViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "BroadcastService",
					role = "theBroadcastDetails",
					roleType = roleType.association,
					informationTypes = ["BroadcastDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<BroadcastService> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = BroadcastService,
			};
		}

		public class TransmissionServiceViewModel : ViewModelBase, IInformationBinding {
			public TransmissionServiceViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "TransmissionService",
					role = "theTransmissionDetails",
					roleType = roleType.association,
					informationTypes = ["TransmissionDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<TransmissionService> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = TransmissionService,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<RadioServiceAreaViewModel.ServiceCoordinationViewModel> ServiceCoordinations { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<RadioServiceAreaViewModel.RadioServiceControlViewModel> RadioServiceControls { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<RadioServiceAreaViewModel.ServiceContactViewModel> ServiceContacts { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<RadioServiceAreaViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<RadioServiceAreaViewModel.BroadcastServiceViewModel> BroadcastServices { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<RadioServiceAreaViewModel.TransmissionServiceViewModel> TransmissionServices { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. ServiceCoordinations.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. RadioServiceControls.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. ServiceContacts.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. BroadcastServices.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. TransmissionServices.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		#region FeatureBindings

		public class ServiceProvisionAreaViewModel : ViewModelBase, IFeatureBinding {
			public ServiceProvisionAreaViewModel() {
				if (featureBindings.Length == 1)
					this.role = featureBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.FeatureBindingRoleEditor), typeof(Editors.FeatureBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.FeatureBindingLinkEditor), typeof(Editors.FeatureBindingLinkEditor))]
			public string featureId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _featureType = default;

			[ReadOnly(true)]
			public string? featureType {
				get { return _featureType; }
				set {
					SetValue(ref _featureType, value);
				}
			}

			private S123.ServiceProvisionAreaViewModel _association = new();

			[ExpandableObject]
			public S123.ServiceProvisionAreaViewModel association {
				get { return _association; }
				set {
					SetValue(ref _association, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceProvisionArea",
					role = "serviceProvider",
					roleType = roleType.association,
					featureTypes = ["RadioStation"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<ServiceProvisionArea> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceProvisionArea,
			};
		}

		public class coreAggregationViewModel : ViewModelBase, IFeatureBinding {
			public coreAggregationViewModel() {
				if (featureBindings.Length == 1)
					this.role = featureBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.FeatureBindingRoleEditor), typeof(Editors.FeatureBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.FeatureBindingLinkEditor), typeof(Editors.FeatureBindingLinkEditor))]
			public string featureId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _featureType = default;

			[ReadOnly(true)]
			public string? featureType {
				get { return _featureType; }
				set {
					SetValue(ref _featureType, value);
				}
			}

			private S123.coreAggregationViewModel _association = new();

			[ExpandableObject]
			public S123.coreAggregationViewModel association {
				get { return _association; }
				set {
					SetValue(ref _association, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 0,
					upper = 1,
					association = "coreAggregation",
					role = "theCollection",
					roleType = roleType.aggregation,
					featureTypes = ["RadioServiceAreaAggregate"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<coreAggregation> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = coreAggregation,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<RadioServiceAreaViewModel.ServiceProvisionAreaViewModel> ServiceProvisionAreas { get; set; } = new();

		[Category("FeatureBindings")]
		public ObservableCollection<RadioServiceAreaViewModel.coreAggregationViewModel> coreAggregations { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. ServiceProvisionAreas.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. coreAggregations.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public RadioServiceAreaViewModel Load(RadioServiceArea instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			languageInformation = instance.languageInformation;
			transmissionPower = instance.transmissionPower;
			transmissionOfTrafficLists = instance.transmissionOfTrafficLists;
			status = instance.status;
			hoursOfWatch = instance.hoursOfWatch;
			return this;
		}

		public override string Serialize() {
			var instance = new RadioServiceArea {
				textContent = this.textContent.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				languageInformation = this.languageInformation,
				transmissionPower = this.transmissionPower,
				transmissionOfTrafficLists = this.transmissionOfTrafficLists,
				status = this.status,
				hoursOfWatch = this.hoursOfWatch,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RadioServiceArea Model => new () {
			textContent = this.textContent.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			languageInformation = this._languageInformation,
			transmissionPower = this._transmissionPower,
			transmissionOfTrafficLists = this._transmissionOfTrafficLists,
			status = this._status,
			hoursOfWatch = this._hoursOfWatch,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => RadioServiceArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. RadioServiceArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => RadioServiceArea._featureBindingDefinitions;

		public RadioServiceAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public RadioServiceAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Radio Service Area";

		public RadioServiceAreaViewModel() : base() {
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			ServiceCoordinations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceCoordinations));
			};
			RadioServiceControls.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(RadioServiceControls));
			};
			ServiceContacts.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceContacts));
			};
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
			BroadcastServices.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(BroadcastServices));
			};
			TransmissionServices.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(TransmissionServices));
			};
			ServiceProvisionAreas.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ServiceProvisionAreas));
			};
			coreAggregations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(coreAggregations));
			};
		}
	}



	/// <summary>
	/// A place equipped to transmit radio waves. Such a station may be either stationary or mobile, and may also be provided with a radio receiver.
	/// </summary>
	[CategoryOrder("RadioStation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RadioStationViewModel : FeatureViewModel<RadioStation> {
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _source  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("FeatureType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private String? _interoperabilityIdentifier  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		private categoryOfRadioStation? _categoryOfRadioStation  = default;

		[Category("RadioStation")]
		[Editor(typeof(Editors.HorizonEditor<RadioStation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfRadioStation? categoryOfRadioStation {
			get {
				return _categoryOfRadioStation;
			}
			set {
				SetValue(ref _categoryOfRadioStation, value);
			}
		}

		[Browsable(false)]
		public categoryOfRadioStation[] categoryOfRadioStationList => [(categoryOfRadioStation)5,(categoryOfRadioStation)9,(categoryOfRadioStation)10,(categoryOfRadioStation)19,(categoryOfRadioStation)20];

		private double? _estimatedRangeOfTransmission  = default;

		[Category("RadioStation")]
		[Editor(typeof(Editors.HorizonEditor<RadioStation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? estimatedRangeOfTransmission {
			get {
				return _estimatedRangeOfTransmission;
			}
			set {
				SetValue(ref _estimatedRangeOfTransmission, value);
			}
		}

		private String? _transmissionContent  = default;

		[Category("RadioStation")]
		[Editor(typeof(Editors.HorizonEditor<RadioStation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? transmissionContent {
			get {
				return _transmissionContent;
			}
			set {
				SetValue(ref _transmissionContent, value);
			}
		}

		private Boolean? _remoteControlled  = default;

		[Category("RadioStation")]
		[Editor(typeof(Editors.HorizonEditor<RadioStation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? remoteControlled {
			get {
				return _remoteControlled;
			}
			set {
				SetValue(ref _remoteControlled, value);
			}
		}

		private status? _status  = default;

		[Category("RadioStation")]
		[Editor(typeof(Editors.HorizonEditor<RadioStation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public status? status {
			get {
				return _status;
			}
			set {
				SetValue(ref _status, value);
			}
		}

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)16,(status)17];

		private radiocommunicationIdentifierViewModel? _radiocommunicationIdentifier  = default;

		[Category("RadioStation")]
		[ExpandableObject]
		[Optional]
		public radiocommunicationIdentifierViewModel? radiocommunicationIdentifier {
			get {
				return _radiocommunicationIdentifier;
			}
			set {
				SetValue(ref _radiocommunicationIdentifier, value);
			}
		}

		[Category("RadioStation")]
		[Optional]
		public ObservableCollection<sectorLimitViewModel> sectorLimit  { get; set; } = new ();

		private String? _hoursOfWatch  = default;

		[Category("RadioStation")]
		[Editor(typeof(Editors.HorizonEditor<RadioStation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? hoursOfWatch {
			get {
				return _hoursOfWatch;
			}
			set {
				SetValue(ref _hoursOfWatch, value);
			}
		}


		#region InformationBindings

		public class ServiceCoordinationViewModel : ViewModelBase, IInformationBinding {
			public ServiceCoordinationViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceCoordination",
					role = "coordinatingAuthority",
					roleType = roleType.association,
					informationTypes = ["Authority"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceCoordination> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceCoordination,
			};
		}

		public class RadioServiceControlViewModel : ViewModelBase, IInformationBinding {
			public RadioServiceControlViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "RadioServiceControl",
					role = "theControlCentre",
					roleType = roleType.association,
					informationTypes = ["RadioControlCentre"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<RadioServiceControl> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = RadioServiceControl,
			};
		}

		public class ServiceContactViewModel : ViewModelBase, IInformationBinding {
			public ServiceContactViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceContact",
					role = "theContactDetails",
					roleType = roleType.association,
					informationTypes = ["ContactDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceContact> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceContact,
			};
		}

		public class LocationHoursViewModel : ViewModelBase, IInformationBinding {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "theServiceHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		public class BroadcastServiceViewModel : ViewModelBase, IInformationBinding {
			public BroadcastServiceViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "BroadcastService",
					role = "theBroadcastDetails",
					roleType = roleType.association,
					informationTypes = ["BroadcastDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<BroadcastService> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = BroadcastService,
			};
		}

		public class TransmissionServiceViewModel : ViewModelBase, IInformationBinding {
			public TransmissionServiceViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "TransmissionService",
					role = "theTransmissionDetails",
					roleType = roleType.association,
					informationTypes = ["TransmissionDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<TransmissionService> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = TransmissionService,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<RadioStationViewModel.ServiceCoordinationViewModel> ServiceCoordinations { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<RadioStationViewModel.RadioServiceControlViewModel> RadioServiceControls { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<RadioStationViewModel.ServiceContactViewModel> ServiceContacts { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<RadioStationViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<RadioStationViewModel.BroadcastServiceViewModel> BroadcastServices { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<RadioStationViewModel.TransmissionServiceViewModel> TransmissionServices { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. ServiceCoordinations.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. RadioServiceControls.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. ServiceContacts.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. BroadcastServices.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. TransmissionServices.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		#region FeatureBindings

		public class ServiceProvisionAreaViewModel : ViewModelBase, IFeatureBinding {
			public ServiceProvisionAreaViewModel() {
				if (featureBindings.Length == 1)
					this.role = featureBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.FeatureBindingRoleEditor), typeof(Editors.FeatureBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.FeatureBindingLinkEditor), typeof(Editors.FeatureBindingLinkEditor))]
			public string featureId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _featureType = default;

			[ReadOnly(true)]
			public string? featureType {
				get { return _featureType; }
				set {
					SetValue(ref _featureType, value);
				}
			}

			private S123.ServiceProvisionAreaViewModel _association = new();

			[ExpandableObject]
			public S123.ServiceProvisionAreaViewModel association {
				get { return _association; }
				set {
					SetValue(ref _association, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceProvisionArea",
					role = "serviceArea",
					roleType = roleType.association,
					featureTypes = ["ConnectivitySubscriptionArea","GMDSSArea","MetArea","NavArea","NavtexServiceArea","RadioServiceArea","WeatherForecastAndWarningArea"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<ServiceProvisionArea> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceProvisionArea,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<RadioStationViewModel.ServiceProvisionAreaViewModel> ServiceProvisionAreas { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. ServiceProvisionAreas.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public RadioStationViewModel Load(RadioStation instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			categoryOfRadioStation = instance.categoryOfRadioStation;
			estimatedRangeOfTransmission = instance.estimatedRangeOfTransmission;
			transmissionContent = instance.transmissionContent;
			remoteControlled = instance.remoteControlled;
			status = instance.status;
			radiocommunicationIdentifier = new ();
			if (instance.radiocommunicationIdentifier != default) {
				radiocommunicationIdentifier.Load(instance.radiocommunicationIdentifier);
			}
			sectorLimit.Clear();
			if (instance.sectorLimit is not null) {
				foreach(var e in instance.sectorLimit)
					sectorLimit.Add(new sectorLimitViewModel().Load(e));
			}
			hoursOfWatch = instance.hoursOfWatch;
			return this;
		}

		public override string Serialize() {
			var instance = new RadioStation {
				textContent = this.textContent.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				categoryOfRadioStation = this.categoryOfRadioStation,
				estimatedRangeOfTransmission = this.estimatedRangeOfTransmission,
				transmissionContent = this.transmissionContent,
				remoteControlled = this.remoteControlled,
				status = this.status,
				radiocommunicationIdentifier = this.radiocommunicationIdentifier?.Model,
				sectorLimit = this.sectorLimit.Select(e => e.Model).ToList(),
				hoursOfWatch = this.hoursOfWatch,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RadioStation Model => new () {
			textContent = this.textContent.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			categoryOfRadioStation = this._categoryOfRadioStation,
			estimatedRangeOfTransmission = this._estimatedRangeOfTransmission,
			transmissionContent = this._transmissionContent,
			remoteControlled = this._remoteControlled,
			status = this._status,
			radiocommunicationIdentifier = this._radiocommunicationIdentifier?.Model,
			sectorLimit = this.sectorLimit.Select(e => e.Model).ToList(),
			hoursOfWatch = this._hoursOfWatch,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => RadioStation._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. RadioStation._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => RadioStation._featureBindingDefinitions;

		public RadioStationViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public RadioStationViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Radio Station";

		public RadioStationViewModel() : base() {
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			sectorLimit.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sectorLimit));
			};
			ServiceCoordinations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceCoordinations));
			};
			RadioServiceControls.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(RadioServiceControls));
			};
			ServiceContacts.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceContacts));
			};
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
			BroadcastServices.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(BroadcastServices));
			};
			TransmissionServices.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(TransmissionServices));
			};
			ServiceProvisionAreas.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ServiceProvisionAreas));
			};
		}
	}



	/// <summary>
	/// A defined geographical area where a specific country or organization is designated to coordinate and provide search and rescue services.
	/// </summary>
	[CategoryOrder("SARRegion",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SARRegionViewModel : FeatureViewModel<SARRegion> {
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _source  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("FeatureType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private String? _interoperabilityIdentifier  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		private String? _nationality  = default;

		[Category("SARRegion")]
		[Editor(typeof(Editors.HorizonEditor<SARRegion>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? nationality {
			get {
				return _nationality;
			}
			set {
				SetValue(ref _nationality, value);
			}
		}


		#region InformationBindings

		public class ServiceCoordinationViewModel : ViewModelBase, IInformationBinding {
			public ServiceCoordinationViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceCoordination",
					role = "coordinatingAuthority",
					roleType = roleType.association,
					informationTypes = ["Authority"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceCoordination> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceCoordination,
			};
		}

		public class RadioServiceControlViewModel : ViewModelBase, IInformationBinding {
			public RadioServiceControlViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "RadioServiceControl",
					role = "theControlCentre",
					roleType = roleType.association,
					informationTypes = ["RadioControlCentre"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<RadioServiceControl> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = RadioServiceControl,
			};
		}

		public class TMASViewModel : ViewModelBase, IInformationBinding {
			public TMASViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "TMAS",
					role = "theTMAS",
					roleType = roleType.association,
					informationTypes = ["TelemedicalAssistanceService"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<TMAS> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = TMAS,
			};
		}

		public class ServiceContactViewModel : ViewModelBase, IInformationBinding {
			public ServiceContactViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceContact",
					role = "theContactDetails",
					roleType = roleType.association,
					informationTypes = ["ContactDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceContact> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceContact,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<SARRegionViewModel.ServiceCoordinationViewModel> ServiceCoordinations { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<SARRegionViewModel.RadioServiceControlViewModel> RadioServiceControls { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<SARRegionViewModel.TMASViewModel> TMAS { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<SARRegionViewModel.ServiceContactViewModel> ServiceContacts { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. ServiceCoordinations.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. RadioServiceControls.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. TMAS.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. ServiceContacts.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public SARRegionViewModel Load(SARRegion instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			nationality = instance.nationality;
			return this;
		}

		public override string Serialize() {
			var instance = new SARRegion {
				textContent = this.textContent.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				nationality = this.nationality,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SARRegion Model => new () {
			textContent = this.textContent.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			nationality = this._nationality,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => SARRegion._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. SARRegion._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => SARRegion._featureBindingDefinitions;

		public SARRegionViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public SARRegionViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Search and Rescue Region";

		public SARRegionViewModel() : base() {
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			ServiceCoordinations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceCoordinations));
			};
			RadioServiceControls.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(RadioServiceControls));
			};
			TMAS.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(TMAS));
			};
			ServiceContacts.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceContacts));
			};
		}
	}



	/// <summary>
	/// An area for which weather forecasts and warnings are provided for specified periods.
	/// </summary>
	[CategoryOrder("WeatherForecastAndWarningArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class WeatherForecastAndWarningAreaViewModel : FeatureViewModel<WeatherForecastAndWarningArea> {
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _source  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("FeatureType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private String? _interoperabilityIdentifier  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		private categoryOfForecastOrWarningArea _categoryOfForecastOrWarningArea  = default;

		[Category("WeatherForecastAndWarningArea")]
		[Editor(typeof(Editors.HorizonEditor<WeatherForecastAndWarningArea>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public categoryOfForecastOrWarningArea categoryOfForecastOrWarningArea {
			get {
				return _categoryOfForecastOrWarningArea;
			}
			set {
				SetValue(ref _categoryOfForecastOrWarningArea, value);
			}
		}

		[Browsable(false)]
		public categoryOfForecastOrWarningArea[] categoryOfForecastOrWarningAreaList => [(categoryOfForecastOrWarningArea)1,(categoryOfForecastOrWarningArea)2,(categoryOfForecastOrWarningArea)3,(categoryOfForecastOrWarningArea)4,(categoryOfForecastOrWarningArea)5,(categoryOfForecastOrWarningArea)6,(categoryOfForecastOrWarningArea)7];

		private String? _idMETAREA  = default;

		[Category("WeatherForecastAndWarningArea")]
		[Editor(typeof(Editors.HorizonEditor<WeatherForecastAndWarningArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? idMETAREA {
			get {
				return _idMETAREA;
			}
			set {
				SetValue(ref _idMETAREA, value);
			}
		}

		private String? _nationality  = default;

		[Category("WeatherForecastAndWarningArea")]
		[Editor(typeof(Editors.HorizonEditor<WeatherForecastAndWarningArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? nationality {
			get {
				return _nationality;
			}
			set {
				SetValue(ref _nationality, value);
			}
		}

		private status? _status  = default;

		[Category("WeatherForecastAndWarningArea")]
		[Editor(typeof(Editors.HorizonEditor<WeatherForecastAndWarningArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public status? status {
			get {
				return _status;
			}
			set {
				SetValue(ref _status, value);
			}
		}

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)14];


		#region InformationBindings

		public class ServiceCoordinationViewModel : ViewModelBase, IInformationBinding {
			public ServiceCoordinationViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceCoordination",
					role = "coordinatingAuthority",
					roleType = roleType.association,
					informationTypes = ["Authority"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceCoordination> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceCoordination,
			};
		}

		public class ServiceContactViewModel : ViewModelBase, IInformationBinding {
			public ServiceContactViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceContact",
					role = "theContactDetails",
					roleType = roleType.association,
					informationTypes = ["ContactDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceContact> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceContact,
			};
		}

		public class LocationHoursViewModel : ViewModelBase, IInformationBinding {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "theServiceHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		public class BroadcastServiceViewModel : ViewModelBase, IInformationBinding {
			public BroadcastServiceViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "BroadcastService",
					role = "theBroadcastDetails",
					roleType = roleType.association,
					informationTypes = ["BroadcastDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<BroadcastService> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = BroadcastService,
			};
		}

		public class TransmissionServiceViewModel : ViewModelBase, IInformationBinding {
			public TransmissionServiceViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "TransmissionService",
					role = "theTransmissionDetails",
					roleType = roleType.association,
					informationTypes = ["TransmissionDetails"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<TransmissionService> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = TransmissionService,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<WeatherForecastAndWarningAreaViewModel.ServiceCoordinationViewModel> ServiceCoordinations { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<WeatherForecastAndWarningAreaViewModel.ServiceContactViewModel> ServiceContacts { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<WeatherForecastAndWarningAreaViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<WeatherForecastAndWarningAreaViewModel.BroadcastServiceViewModel> BroadcastServices { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<WeatherForecastAndWarningAreaViewModel.TransmissionServiceViewModel> TransmissionServices { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. ServiceCoordinations.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. ServiceContacts.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. BroadcastServices.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. TransmissionServices.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		#region FeatureBindings

		public class ServiceProvisionAreaViewModel : ViewModelBase, IFeatureBinding {
			public ServiceProvisionAreaViewModel() {
				if (featureBindings.Length == 1)
					this.role = featureBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.FeatureBindingRoleEditor), typeof(Editors.FeatureBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.FeatureBindingLinkEditor), typeof(Editors.FeatureBindingLinkEditor))]
			public string featureId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _featureType = default;

			[ReadOnly(true)]
			public string? featureType {
				get { return _featureType; }
				set {
					SetValue(ref _featureType, value);
				}
			}

			private S123.ServiceProvisionAreaViewModel _association = new();

			[ExpandableObject]
			public S123.ServiceProvisionAreaViewModel association {
				get { return _association; }
				set {
					SetValue(ref _association, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 0,
					upper = default,
					association = "ServiceProvisionArea",
					role = "serviceProvider",
					roleType = roleType.association,
					featureTypes = ["RadioStation"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<ServiceProvisionArea> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceProvisionArea,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<WeatherForecastAndWarningAreaViewModel.ServiceProvisionAreaViewModel> ServiceProvisionAreas { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. ServiceProvisionAreas.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public WeatherForecastAndWarningAreaViewModel Load(WeatherForecastAndWarningArea instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			categoryOfForecastOrWarningArea = instance.categoryOfForecastOrWarningArea;
			idMETAREA = instance.idMETAREA;
			nationality = instance.nationality;
			status = instance.status;
			return this;
		}

		public override string Serialize() {
			var instance = new WeatherForecastAndWarningArea {
				textContent = this.textContent.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				categoryOfForecastOrWarningArea = this.categoryOfForecastOrWarningArea,
				idMETAREA = this.idMETAREA,
				nationality = this.nationality,
				status = this.status,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public WeatherForecastAndWarningArea Model => new () {
			textContent = this.textContent.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			categoryOfForecastOrWarningArea = this._categoryOfForecastOrWarningArea,
			idMETAREA = this._idMETAREA,
			nationality = this._nationality,
			status = this._status,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => WeatherForecastAndWarningArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. WeatherForecastAndWarningArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => WeatherForecastAndWarningArea._featureBindingDefinitions;

		public WeatherForecastAndWarningAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public WeatherForecastAndWarningAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Weather Forecast and Warning Area";

		public WeatherForecastAndWarningAreaViewModel() : base() {
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			ServiceCoordinations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceCoordinations));
			};
			ServiceContacts.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceContacts));
			};
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
			BroadcastServices.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(BroadcastServices));
			};
			TransmissionServices.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(TransmissionServices));
			};
			ServiceProvisionAreas.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ServiceProvisionAreas));
			};
		}
	}



	/// <summary>
	/// Aggregation of areas where radio services from a single radio service are available to different levels of reliability.
	/// </summary>
	[CategoryOrder("RadioServiceAreaAggregate",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RadioServiceAreaAggregateViewModel : FeatureViewModel<RadioServiceAreaAggregate> {
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _source  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("FeatureType")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private String? _interoperabilityIdentifier  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}



		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		#region FeatureBindings

		public class coreAggregationViewModel : ViewModelBase, IFeatureBinding {
			public coreAggregationViewModel() {
				if (featureBindings.Length == 1)
					this.role = featureBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.FeatureBindingRoleEditor), typeof(Editors.FeatureBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.FeatureBindingLinkEditor), typeof(Editors.FeatureBindingLinkEditor))]
			public string featureId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _featureType = default;

			[ReadOnly(true)]
			public string? featureType {
				get { return _featureType; }
				set {
					SetValue(ref _featureType, value);
				}
			}

			private S123.coreAggregationViewModel _association = new();

			[ExpandableObject]
			public S123.coreAggregationViewModel association {
				get { return _association; }
				set {
					SetValue(ref _association, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 1,
					upper = 1,
					association = "coreAggregation",
					role = "theComponent",
					roleType = roleType.aggregation,
					featureTypes = ["RadioServiceArea"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<coreAggregation> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = coreAggregation,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<RadioServiceAreaAggregateViewModel.coreAggregationViewModel> coreAggregations { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. coreAggregations.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public RadioServiceAreaAggregateViewModel Load(RadioServiceAreaAggregate instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			source = instance.source;
			reportedDate = instance.reportedDate;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			return this;
		}

		public override string Serialize() {
			var instance = new RadioServiceAreaAggregate {
				textContent = this.textContent.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				source = this.source,
				reportedDate = this.reportedDate,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RadioServiceAreaAggregate Model => new () {
			textContent = this.textContent.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => RadioServiceAreaAggregate._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. RadioServiceAreaAggregate._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => RadioServiceAreaAggregate._featureBindingDefinitions;

		public RadioServiceAreaAggregateViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public RadioServiceAreaAggregateViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Radio Service Area Aggregate";

		public RadioServiceAreaAggregateViewModel() : base() {
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			coreAggregations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(coreAggregations));
			};
		}
	}



	/// <summary>
	/// A geographical area that describes the coverage and extent of spatial objects.
	/// </summary>
	[CategoryOrder("DataCoverage",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DataCoverageViewModel : FeatureViewModel<DataCoverage> {
		private int _maximumDisplayScale  = default;

		[Category("DataCoverage")]
		[Editor(typeof(Editors.HorizonEditor<DataCoverage>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public int maximumDisplayScale {
			get {
				return _maximumDisplayScale;
			}
			set {
				SetValue(ref _maximumDisplayScale, value);
			}
		}

		private int _minimumDisplayScale  = default;

		[Category("DataCoverage")]
		[Editor(typeof(Editors.HorizonEditor<DataCoverage>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public int minimumDisplayScale {
			get {
				return _minimumDisplayScale;
			}
			set {
				SetValue(ref _minimumDisplayScale, value);
			}
		}

		private int? _optimumDisplayScale  = default;

		[Category("DataCoverage")]
		[Editor(typeof(Editors.HorizonEditor<DataCoverage>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? optimumDisplayScale {
			get {
				return _optimumDisplayScale;
			}
			set {
				SetValue(ref _optimumDisplayScale, value);
			}
		}

		[Category("DataCoverage")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public DataCoverageViewModel Load(DataCoverage instance) {
			maximumDisplayScale = instance.maximumDisplayScale;
			minimumDisplayScale = instance.minimumDisplayScale;
			optimumDisplayScale = instance.optimumDisplayScale;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new DataCoverage {
				maximumDisplayScale = this.maximumDisplayScale,
				minimumDisplayScale = this.minimumDisplayScale,
				optimumDisplayScale = this.optimumDisplayScale,
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DataCoverage Model => new () {
			maximumDisplayScale = this._maximumDisplayScale,
			minimumDisplayScale = this._minimumDisplayScale,
			optimumDisplayScale = this._optimumDisplayScale,
			information = this.information.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => DataCoverage._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. DataCoverage._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => DataCoverage._featureBindingDefinitions;

		public DataCoverageViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public DataCoverageViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Data Coverage";

		public DataCoverageViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}



	/// <summary>
	/// An area within which a uniform assessment of the quality of the non-bathymetric data exists.
	/// </summary>
	[CategoryOrder("QualityOfNonBathymetricData",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class QualityOfNonBathymetricDataViewModel : FeatureViewModel<QualityOfNonBathymetricData> {
		private categoryOfTemporalVariation? _categoryOfTemporalVariation  = default;

		[Category("QualityOfNonBathymetricData")]
		[Editor(typeof(Editors.HorizonEditor<QualityOfNonBathymetricData>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfTemporalVariation? categoryOfTemporalVariation {
			get {
				return _categoryOfTemporalVariation;
			}
			set {
				SetValue(ref _categoryOfTemporalVariation, value);
			}
		}

		[Browsable(false)]
		public categoryOfTemporalVariation[] categoryOfTemporalVariationList => [(categoryOfTemporalVariation)1,(categoryOfTemporalVariation)4,(categoryOfTemporalVariation)5];

		private double? _horizontalDistanceUncertainty  = default;

		[Category("QualityOfNonBathymetricData")]
		[Editor(typeof(Editors.HorizonEditor<QualityOfNonBathymetricData>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalDistanceUncertainty {
			get {
				return _horizontalDistanceUncertainty;
			}
			set {
				SetValue(ref _horizontalDistanceUncertainty, value);
			}
		}

		private horizontalPositionUncertaintyViewModel? _horizontalPositionUncertainty  = default;

		[Category("QualityOfNonBathymetricData")]
		[ExpandableObject]
		[Optional]
		public horizontalPositionUncertaintyViewModel? horizontalPositionUncertainty {
			get {
				return _horizontalPositionUncertainty;
			}
			set {
				SetValue(ref _horizontalPositionUncertainty, value);
			}
		}

		private double? _orientationUncertainty  = default;

		[Category("QualityOfNonBathymetricData")]
		[Editor(typeof(Editors.HorizonEditor<QualityOfNonBathymetricData>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? orientationUncertainty {
			get {
				return _orientationUncertainty;
			}
			set {
				SetValue(ref _orientationUncertainty, value);
			}
		}

		private surveyDateRangeViewModel? _surveyDateRange  = default;

		[Category("QualityOfNonBathymetricData")]
		[ExpandableObject]
		[Optional]
		public surveyDateRangeViewModel? surveyDateRange {
			get {
				return _surveyDateRange;
			}
			set {
				SetValue(ref _surveyDateRange, value);
			}
		}

		private verticalUncertaintyViewModel? _verticalUncertainty  = default;

		[Category("QualityOfNonBathymetricData")]
		[ExpandableObject]
		[Optional]
		public verticalUncertaintyViewModel? verticalUncertainty {
			get {
				return _verticalUncertainty;
			}
			set {
				SetValue(ref _verticalUncertainty, value);
			}
		}

		[Category("QualityOfNonBathymetricData")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public QualityOfNonBathymetricDataViewModel Load(QualityOfNonBathymetricData instance) {
			categoryOfTemporalVariation = instance.categoryOfTemporalVariation;
			horizontalDistanceUncertainty = instance.horizontalDistanceUncertainty;
			horizontalPositionUncertainty = new ();
			if (instance.horizontalPositionUncertainty != default) {
				horizontalPositionUncertainty.Load(instance.horizontalPositionUncertainty);
			}
			orientationUncertainty = instance.orientationUncertainty;
			surveyDateRange = new ();
			if (instance.surveyDateRange != default) {
				surveyDateRange.Load(instance.surveyDateRange);
			}
			verticalUncertainty = new ();
			if (instance.verticalUncertainty != default) {
				verticalUncertainty.Load(instance.verticalUncertainty);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new QualityOfNonBathymetricData {
				categoryOfTemporalVariation = this.categoryOfTemporalVariation,
				horizontalDistanceUncertainty = this.horizontalDistanceUncertainty,
				horizontalPositionUncertainty = this.horizontalPositionUncertainty?.Model,
				orientationUncertainty = this.orientationUncertainty,
				surveyDateRange = this.surveyDateRange?.Model,
				verticalUncertainty = this.verticalUncertainty?.Model,
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public QualityOfNonBathymetricData Model => new () {
			categoryOfTemporalVariation = this._categoryOfTemporalVariation,
			horizontalDistanceUncertainty = this._horizontalDistanceUncertainty,
			horizontalPositionUncertainty = this._horizontalPositionUncertainty?.Model,
			orientationUncertainty = this._orientationUncertainty,
			surveyDateRange = this._surveyDateRange?.Model,
			verticalUncertainty = this._verticalUncertainty?.Model,
			information = this.information.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => QualityOfNonBathymetricData._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. QualityOfNonBathymetricData._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => QualityOfNonBathymetricData._featureBindingDefinitions;

		public QualityOfNonBathymetricDataViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public QualityOfNonBathymetricDataViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Quality of Non-Bathymetric Data";

		public QualityOfNonBathymetricDataViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}



	public static class InformationBindingExtension {
		public static ApplicabilityViewModel LoadInformationBinding(this ApplicabilityViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<InclusionType> inclusionType) {
					instance.InclusionTypes.Add(new ApplicabilityViewModel.InclusionTypeViewModel {
						informationId = inclusionType.referenceId,
						informationType = inclusionType.informationType,
						role = inclusionType.role,
					});
				}
			}
			return instance;
		}

		public static AuthorityViewModel LoadInformationBinding(this AuthorityViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<AuthorityContact> authorityContact) {
					instance.AuthorityContacts.Add(new AuthorityViewModel.AuthorityContactViewModel {
						informationId = authorityContact.referenceId,
						informationType = authorityContact.informationType,
						role = authorityContact.role,
					});
				}
				if(informationBinding is informationBinding<AuthorityHours> authorityHours) {
					instance.AuthorityHours.Add(new AuthorityViewModel.AuthorityHoursViewModel {
						informationId = authorityHours.referenceId,
						informationType = authorityHours.informationType,
						role = authorityHours.role,
					});
				}
			}
			return instance;
		}

		public static BroadcastDetailsViewModel LoadInformationBinding(this BroadcastDetailsViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<BroadcastTransmission> broadcastTransmission) {
					instance.BroadcastTransmissions.Add(new BroadcastDetailsViewModel.BroadcastTransmissionViewModel {
						informationId = broadcastTransmission.referenceId,
						informationType = broadcastTransmission.informationType,
						role = broadcastTransmission.role,
					});
				}
			}
			return instance;
		}

		public static ConnectivityQualityOfServiceViewModel LoadInformationBinding(this ConnectivityQualityOfServiceViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static ContactDetailsViewModel LoadInformationBinding(this ContactDetailsViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<AuthorityContact> authorityContact) {
					instance.AuthorityContacts.Add(new ContactDetailsViewModel.AuthorityContactViewModel {
						informationId = authorityContact.referenceId,
						informationType = authorityContact.informationType,
						role = authorityContact.role,
					});
				}
			}
			return instance;
		}

		public static NauticalInformationViewModel LoadInformationBinding(this NauticalInformationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static NonStandardWorkingDayViewModel LoadInformationBinding(this NonStandardWorkingDayViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ExceptionalWorkday> exceptionalWorkday) {
					instance.ExceptionalWorkdays.Add(new NonStandardWorkingDayViewModel.ExceptionalWorkdayViewModel {
						informationId = exceptionalWorkday.referenceId,
						informationType = exceptionalWorkday.informationType,
						role = exceptionalWorkday.role,
					});
				}
			}
			return instance;
		}

		public static RadioControlCentreViewModel LoadInformationBinding(this RadioControlCentreViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<AuthorityContact> authorityContact) {
					instance.AuthorityContacts.Add(new RadioControlCentreViewModel.AuthorityContactViewModel {
						informationId = authorityContact.referenceId,
						informationType = authorityContact.informationType,
						role = authorityContact.role,
					});
				}
				if(informationBinding is informationBinding<AuthorityHours> authorityHours) {
					instance.AuthorityHours.Add(new RadioControlCentreViewModel.AuthorityHoursViewModel {
						informationId = authorityHours.referenceId,
						informationType = authorityHours.informationType,
						role = authorityHours.role,
					});
				}
				if(informationBinding is informationBinding<TMAS> tMAS) {
					instance.TMAS.Add(new RadioControlCentreViewModel.TMASViewModel {
						informationId = tMAS.referenceId,
						informationType = tMAS.informationType,
						role = tMAS.role,
					});
				}
			}
			return instance;
		}

		public static RecommendationsViewModel LoadInformationBinding(this RecommendationsViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RegulationsViewModel LoadInformationBinding(this RegulationsViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RestrictionsViewModel LoadInformationBinding(this RestrictionsViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static ServiceHoursViewModel LoadInformationBinding(this ServiceHoursViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<AuthorityHours> authorityHours) {
					instance.AuthorityHours.Add(new ServiceHoursViewModel.AuthorityHoursViewModel {
						informationId = authorityHours.referenceId,
						informationType = authorityHours.informationType,
						role = authorityHours.role,
					});
				}
				if(informationBinding is informationBinding<ExceptionalWorkday> exceptionalWorkday) {
					instance.ExceptionalWorkdays.Add(new ServiceHoursViewModel.ExceptionalWorkdayViewModel {
						informationId = exceptionalWorkday.referenceId,
						informationType = exceptionalWorkday.informationType,
						role = exceptionalWorkday.role,
					});
				}
			}
			return instance;
		}

		public static SpatialQualityViewModel LoadInformationBinding(this SpatialQualityViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static TelemedicalAssistanceServiceViewModel LoadInformationBinding(this TelemedicalAssistanceServiceViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<RadioServiceControl> radioServiceControl) {
					instance.RadioServiceControls.Add(new TelemedicalAssistanceServiceViewModel.RadioServiceControlViewModel {
						informationId = radioServiceControl.referenceId,
						informationType = radioServiceControl.informationType,
						role = radioServiceControl.role,
					});
				}
			}
			return instance;
		}

		public static TransmissionDetailsViewModel LoadInformationBinding(this TransmissionDetailsViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<BroadcastTransmission> broadcastTransmission) {
					instance.BroadcastTransmissions.Add(new TransmissionDetailsViewModel.BroadcastTransmissionViewModel {
						informationId = broadcastTransmission.referenceId,
						informationType = broadcastTransmission.informationType,
						role = broadcastTransmission.role,
					});
				}
			}
			return instance;
		}

		public static ConnectivitySubscriptionAreaViewModel LoadInformationBinding(this ConnectivitySubscriptionAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ConnectivityService> connectivityService) {
					instance.ConnectivityServices.Add(new ConnectivitySubscriptionAreaViewModel.ConnectivityServiceViewModel {
						informationId = connectivityService.referenceId,
						informationType = connectivityService.informationType,
						role = connectivityService.role,
					});
				}
				if(informationBinding is informationBinding<ServiceContact> serviceContact) {
					instance.ServiceContacts.Add(new ConnectivitySubscriptionAreaViewModel.ServiceContactViewModel {
						informationId = serviceContact.referenceId,
						informationType = serviceContact.informationType,
						role = serviceContact.role,
					});
				}
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new ConnectivitySubscriptionAreaViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
				if(informationBinding is informationBinding<AvailableQoS> availableQoS) {
					instance.AvailableQoS.Add(new ConnectivitySubscriptionAreaViewModel.AvailableQoSViewModel {
						informationId = availableQoS.referenceId,
						informationType = availableQoS.informationType,
						role = availableQoS.role,
					});
				}
			}
			return instance;
		}

		public static GMDSSAreaViewModel LoadInformationBinding(this GMDSSAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceCoordination> serviceCoordination) {
					instance.ServiceCoordinations.Add(new GMDSSAreaViewModel.ServiceCoordinationViewModel {
						informationId = serviceCoordination.referenceId,
						informationType = serviceCoordination.informationType,
						role = serviceCoordination.role,
					});
				}
				if(informationBinding is informationBinding<RadioServiceControl> radioServiceControl) {
					instance.RadioServiceControls.Add(new GMDSSAreaViewModel.RadioServiceControlViewModel {
						informationId = radioServiceControl.referenceId,
						informationType = radioServiceControl.informationType,
						role = radioServiceControl.role,
					});
				}
				if(informationBinding is informationBinding<ServiceContact> serviceContact) {
					instance.ServiceContacts.Add(new GMDSSAreaViewModel.ServiceContactViewModel {
						informationId = serviceContact.referenceId,
						informationType = serviceContact.informationType,
						role = serviceContact.role,
					});
				}
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new GMDSSAreaViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static IndeterminateZoneViewModel LoadInformationBinding(this IndeterminateZoneViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static MetAreaViewModel LoadInformationBinding(this MetAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceCoordination> serviceCoordination) {
					instance.ServiceCoordinations.Add(new MetAreaViewModel.ServiceCoordinationViewModel {
						informationId = serviceCoordination.referenceId,
						informationType = serviceCoordination.informationType,
						role = serviceCoordination.role,
					});
				}
				if(informationBinding is informationBinding<ServiceContact> serviceContact) {
					instance.ServiceContacts.Add(new MetAreaViewModel.ServiceContactViewModel {
						informationId = serviceContact.referenceId,
						informationType = serviceContact.informationType,
						role = serviceContact.role,
					});
				}
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new MetAreaViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
				if(informationBinding is informationBinding<BroadcastService> broadcastService) {
					instance.BroadcastServices.Add(new MetAreaViewModel.BroadcastServiceViewModel {
						informationId = broadcastService.referenceId,
						informationType = broadcastService.informationType,
						role = broadcastService.role,
					});
				}
				if(informationBinding is informationBinding<TransmissionService> transmissionService) {
					instance.TransmissionServices.Add(new MetAreaViewModel.TransmissionServiceViewModel {
						informationId = transmissionService.referenceId,
						informationType = transmissionService.informationType,
						role = transmissionService.role,
					});
				}
			}
			return instance;
		}

		public static NavAreaViewModel LoadInformationBinding(this NavAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceCoordination> serviceCoordination) {
					instance.ServiceCoordinations.Add(new NavAreaViewModel.ServiceCoordinationViewModel {
						informationId = serviceCoordination.referenceId,
						informationType = serviceCoordination.informationType,
						role = serviceCoordination.role,
					});
				}
				if(informationBinding is informationBinding<ServiceContact> serviceContact) {
					instance.ServiceContacts.Add(new NavAreaViewModel.ServiceContactViewModel {
						informationId = serviceContact.referenceId,
						informationType = serviceContact.informationType,
						role = serviceContact.role,
					});
				}
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new NavAreaViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
				if(informationBinding is informationBinding<BroadcastService> broadcastService) {
					instance.BroadcastServices.Add(new NavAreaViewModel.BroadcastServiceViewModel {
						informationId = broadcastService.referenceId,
						informationType = broadcastService.informationType,
						role = broadcastService.role,
					});
				}
				if(informationBinding is informationBinding<TransmissionService> transmissionService) {
					instance.TransmissionServices.Add(new NavAreaViewModel.TransmissionServiceViewModel {
						informationId = transmissionService.referenceId,
						informationType = transmissionService.informationType,
						role = transmissionService.role,
					});
				}
			}
			return instance;
		}

		public static NavtexServiceAreaViewModel LoadInformationBinding(this NavtexServiceAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceCoordination> serviceCoordination) {
					instance.ServiceCoordinations.Add(new NavtexServiceAreaViewModel.ServiceCoordinationViewModel {
						informationId = serviceCoordination.referenceId,
						informationType = serviceCoordination.informationType,
						role = serviceCoordination.role,
					});
				}
				if(informationBinding is informationBinding<ServiceContact> serviceContact) {
					instance.ServiceContacts.Add(new NavtexServiceAreaViewModel.ServiceContactViewModel {
						informationId = serviceContact.referenceId,
						informationType = serviceContact.informationType,
						role = serviceContact.role,
					});
				}
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new NavtexServiceAreaViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
				if(informationBinding is informationBinding<BroadcastService> broadcastService) {
					instance.BroadcastServices.Add(new NavtexServiceAreaViewModel.BroadcastServiceViewModel {
						informationId = broadcastService.referenceId,
						informationType = broadcastService.informationType,
						role = broadcastService.role,
					});
				}
				if(informationBinding is informationBinding<TransmissionService> transmissionService) {
					instance.TransmissionServices.Add(new NavtexServiceAreaViewModel.TransmissionServiceViewModel {
						informationId = transmissionService.referenceId,
						informationType = transmissionService.informationType,
						role = transmissionService.role,
					});
				}
			}
			return instance;
		}

		public static RadioServiceAreaViewModel LoadInformationBinding(this RadioServiceAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceCoordination> serviceCoordination) {
					instance.ServiceCoordinations.Add(new RadioServiceAreaViewModel.ServiceCoordinationViewModel {
						informationId = serviceCoordination.referenceId,
						informationType = serviceCoordination.informationType,
						role = serviceCoordination.role,
					});
				}
				if(informationBinding is informationBinding<RadioServiceControl> radioServiceControl) {
					instance.RadioServiceControls.Add(new RadioServiceAreaViewModel.RadioServiceControlViewModel {
						informationId = radioServiceControl.referenceId,
						informationType = radioServiceControl.informationType,
						role = radioServiceControl.role,
					});
				}
				if(informationBinding is informationBinding<ServiceContact> serviceContact) {
					instance.ServiceContacts.Add(new RadioServiceAreaViewModel.ServiceContactViewModel {
						informationId = serviceContact.referenceId,
						informationType = serviceContact.informationType,
						role = serviceContact.role,
					});
				}
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new RadioServiceAreaViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
				if(informationBinding is informationBinding<BroadcastService> broadcastService) {
					instance.BroadcastServices.Add(new RadioServiceAreaViewModel.BroadcastServiceViewModel {
						informationId = broadcastService.referenceId,
						informationType = broadcastService.informationType,
						role = broadcastService.role,
					});
				}
				if(informationBinding is informationBinding<TransmissionService> transmissionService) {
					instance.TransmissionServices.Add(new RadioServiceAreaViewModel.TransmissionServiceViewModel {
						informationId = transmissionService.referenceId,
						informationType = transmissionService.informationType,
						role = transmissionService.role,
					});
				}
			}
			return instance;
		}

		public static RadioStationViewModel LoadInformationBinding(this RadioStationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceCoordination> serviceCoordination) {
					instance.ServiceCoordinations.Add(new RadioStationViewModel.ServiceCoordinationViewModel {
						informationId = serviceCoordination.referenceId,
						informationType = serviceCoordination.informationType,
						role = serviceCoordination.role,
					});
				}
				if(informationBinding is informationBinding<RadioServiceControl> radioServiceControl) {
					instance.RadioServiceControls.Add(new RadioStationViewModel.RadioServiceControlViewModel {
						informationId = radioServiceControl.referenceId,
						informationType = radioServiceControl.informationType,
						role = radioServiceControl.role,
					});
				}
				if(informationBinding is informationBinding<ServiceContact> serviceContact) {
					instance.ServiceContacts.Add(new RadioStationViewModel.ServiceContactViewModel {
						informationId = serviceContact.referenceId,
						informationType = serviceContact.informationType,
						role = serviceContact.role,
					});
				}
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new RadioStationViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
				if(informationBinding is informationBinding<BroadcastService> broadcastService) {
					instance.BroadcastServices.Add(new RadioStationViewModel.BroadcastServiceViewModel {
						informationId = broadcastService.referenceId,
						informationType = broadcastService.informationType,
						role = broadcastService.role,
					});
				}
				if(informationBinding is informationBinding<TransmissionService> transmissionService) {
					instance.TransmissionServices.Add(new RadioStationViewModel.TransmissionServiceViewModel {
						informationId = transmissionService.referenceId,
						informationType = transmissionService.informationType,
						role = transmissionService.role,
					});
				}
			}
			return instance;
		}

		public static SARRegionViewModel LoadInformationBinding(this SARRegionViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceCoordination> serviceCoordination) {
					instance.ServiceCoordinations.Add(new SARRegionViewModel.ServiceCoordinationViewModel {
						informationId = serviceCoordination.referenceId,
						informationType = serviceCoordination.informationType,
						role = serviceCoordination.role,
					});
				}
				if(informationBinding is informationBinding<RadioServiceControl> radioServiceControl) {
					instance.RadioServiceControls.Add(new SARRegionViewModel.RadioServiceControlViewModel {
						informationId = radioServiceControl.referenceId,
						informationType = radioServiceControl.informationType,
						role = radioServiceControl.role,
					});
				}
				if(informationBinding is informationBinding<TMAS> tMAS) {
					instance.TMAS.Add(new SARRegionViewModel.TMASViewModel {
						informationId = tMAS.referenceId,
						informationType = tMAS.informationType,
						role = tMAS.role,
					});
				}
				if(informationBinding is informationBinding<ServiceContact> serviceContact) {
					instance.ServiceContacts.Add(new SARRegionViewModel.ServiceContactViewModel {
						informationId = serviceContact.referenceId,
						informationType = serviceContact.informationType,
						role = serviceContact.role,
					});
				}
			}
			return instance;
		}

		public static WeatherForecastAndWarningAreaViewModel LoadInformationBinding(this WeatherForecastAndWarningAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceCoordination> serviceCoordination) {
					instance.ServiceCoordinations.Add(new WeatherForecastAndWarningAreaViewModel.ServiceCoordinationViewModel {
						informationId = serviceCoordination.referenceId,
						informationType = serviceCoordination.informationType,
						role = serviceCoordination.role,
					});
				}
				if(informationBinding is informationBinding<ServiceContact> serviceContact) {
					instance.ServiceContacts.Add(new WeatherForecastAndWarningAreaViewModel.ServiceContactViewModel {
						informationId = serviceContact.referenceId,
						informationType = serviceContact.informationType,
						role = serviceContact.role,
					});
				}
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new WeatherForecastAndWarningAreaViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
				if(informationBinding is informationBinding<BroadcastService> broadcastService) {
					instance.BroadcastServices.Add(new WeatherForecastAndWarningAreaViewModel.BroadcastServiceViewModel {
						informationId = broadcastService.referenceId,
						informationType = broadcastService.informationType,
						role = broadcastService.role,
					});
				}
				if(informationBinding is informationBinding<TransmissionService> transmissionService) {
					instance.TransmissionServices.Add(new WeatherForecastAndWarningAreaViewModel.TransmissionServiceViewModel {
						informationId = transmissionService.referenceId,
						informationType = transmissionService.informationType,
						role = transmissionService.role,
					});
				}
			}
			return instance;
		}

		public static RadioServiceAreaAggregateViewModel LoadInformationBinding(this RadioServiceAreaAggregateViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static DataCoverageViewModel LoadInformationBinding(this DataCoverageViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static QualityOfNonBathymetricDataViewModel LoadInformationBinding(this QualityOfNonBathymetricDataViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

	}

	public static class FeatureBindingExtension {
		public static ConnectivitySubscriptionAreaViewModel LoadFeatureBinding(this ConnectivitySubscriptionAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<ServiceProvisionArea> serviceProvisionArea) {
					instance.ServiceProvisionAreas.Add(new ConnectivitySubscriptionAreaViewModel.ServiceProvisionAreaViewModel {
						featureId = serviceProvisionArea.referenceId,
						featureType = serviceProvisionArea.featureType,
						role = serviceProvisionArea.role,
					});
				}
			}
			return instance;
		}

		public static GMDSSAreaViewModel LoadFeatureBinding(this GMDSSAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<ServiceProvisionArea> serviceProvisionArea) {
					instance.ServiceProvisionAreas.Add(new GMDSSAreaViewModel.ServiceProvisionAreaViewModel {
						featureId = serviceProvisionArea.referenceId,
						featureType = serviceProvisionArea.featureType,
						role = serviceProvisionArea.role,
					});
				}
			}
			return instance;
		}

		public static IndeterminateZoneViewModel LoadFeatureBinding(this IndeterminateZoneViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<fuzzyZoneAggregation> fuzzyZoneAggregation) {
					instance.fuzzyZoneAggregations.Add(new IndeterminateZoneViewModel.fuzzyZoneAggregationViewModel {
						featureId = fuzzyZoneAggregation.referenceId,
						featureType = fuzzyZoneAggregation.featureType,
						role = fuzzyZoneAggregation.role,
					});
				}
			}
			return instance;
		}

		public static MetAreaViewModel LoadFeatureBinding(this MetAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<ServiceProvisionArea> serviceProvisionArea) {
					instance.ServiceProvisionAreas.Add(new MetAreaViewModel.ServiceProvisionAreaViewModel {
						featureId = serviceProvisionArea.referenceId,
						featureType = serviceProvisionArea.featureType,
						role = serviceProvisionArea.role,
					});
				}
			}
			return instance;
		}

		public static NavAreaViewModel LoadFeatureBinding(this NavAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<ServiceProvisionArea> serviceProvisionArea) {
					instance.ServiceProvisionAreas.Add(new NavAreaViewModel.ServiceProvisionAreaViewModel {
						featureId = serviceProvisionArea.referenceId,
						featureType = serviceProvisionArea.featureType,
						role = serviceProvisionArea.role,
					});
				}
			}
			return instance;
		}

		public static NavtexServiceAreaViewModel LoadFeatureBinding(this NavtexServiceAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<ServiceProvisionArea> serviceProvisionArea) {
					instance.ServiceProvisionAreas.Add(new NavtexServiceAreaViewModel.ServiceProvisionAreaViewModel {
						featureId = serviceProvisionArea.referenceId,
						featureType = serviceProvisionArea.featureType,
						role = serviceProvisionArea.role,
					});
				}
			}
			return instance;
		}

		public static RadioServiceAreaViewModel LoadFeatureBinding(this RadioServiceAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<ServiceProvisionArea> serviceProvisionArea) {
					instance.ServiceProvisionAreas.Add(new RadioServiceAreaViewModel.ServiceProvisionAreaViewModel {
						featureId = serviceProvisionArea.referenceId,
						featureType = serviceProvisionArea.featureType,
						role = serviceProvisionArea.role,
					});
				}
				if(featureBinding is featureBinding<coreAggregation> coreAggregation) {
					instance.coreAggregations.Add(new RadioServiceAreaViewModel.coreAggregationViewModel {
						featureId = coreAggregation.referenceId,
						featureType = coreAggregation.featureType,
						role = coreAggregation.role,
					});
				}
			}
			return instance;
		}

		public static RadioStationViewModel LoadFeatureBinding(this RadioStationViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<ServiceProvisionArea> serviceProvisionArea) {
					instance.ServiceProvisionAreas.Add(new RadioStationViewModel.ServiceProvisionAreaViewModel {
						featureId = serviceProvisionArea.referenceId,
						featureType = serviceProvisionArea.featureType,
						role = serviceProvisionArea.role,
					});
				}
			}
			return instance;
		}

		public static SARRegionViewModel LoadFeatureBinding(this SARRegionViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static WeatherForecastAndWarningAreaViewModel LoadFeatureBinding(this WeatherForecastAndWarningAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<ServiceProvisionArea> serviceProvisionArea) {
					instance.ServiceProvisionAreas.Add(new WeatherForecastAndWarningAreaViewModel.ServiceProvisionAreaViewModel {
						featureId = serviceProvisionArea.referenceId,
						featureType = serviceProvisionArea.featureType,
						role = serviceProvisionArea.role,
					});
				}
			}
			return instance;
		}

		public static RadioServiceAreaAggregateViewModel LoadFeatureBinding(this RadioServiceAreaAggregateViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<coreAggregation> coreAggregation) {
					instance.coreAggregations.Add(new RadioServiceAreaAggregateViewModel.coreAggregationViewModel {
						featureId = coreAggregation.referenceId,
						featureType = coreAggregation.featureType,
						role = coreAggregation.role,
					});
				}
			}
			return instance;
		}

		public static DataCoverageViewModel LoadFeatureBinding(this DataCoverageViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static QualityOfNonBathymetricDataViewModel LoadFeatureBinding(this QualityOfNonBathymetricDataViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

	}

}
