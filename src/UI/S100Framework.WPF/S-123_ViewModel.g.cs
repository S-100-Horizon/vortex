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
			"METAREA" => new METAREAViewModel { Name = name },
			"NAVAREA" => new NAVAREAViewModel { Name = name },
			"NAVTEXServiceArea" => new NAVTEXServiceAreaViewModel { Name = name },
			"RadioServiceArea" => new RadioServiceAreaViewModel { Name = name },
			"RadioStation" => new RadioStationViewModel { Name = name },
			"SearchAndRescueRegion" => new SearchAndRescueRegionViewModel { Name = name },
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
			("ServiceProvisionArea", "serviceArea") => ["ConnectivitySubscriptionArea","GMDSSArea","METAREA","NAVAREA","NAVTEXServiceArea","RadioServiceArea","WeatherForecastAndWarningArea"],
			("fuzzyZoneAggregation", "theComponent") => ["IndeterminateZone"],
			("coreAggregation", "theComponent") => ["RadioServiceArea"],
			_ => throw new InvalidOperationException(),
		};
	}

	/// <summary>
	/// Description of the radio service for area A3 of the Global Maritime Distress and Safety System (GMDSS).
	/// </summary>
	[Description("Description of the radio service for area A3 of the Global Maritime Distress and Safety System (GMDSS).")]
	[CategoryOrder("areaA3ServiceDescription",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class areaA3ServiceDescriptionViewModel : ComplexViewModel<areaA3ServiceDescription> {
		[Description("The Recognized Mobile Satellite Service (RMSS) providing the service through a satellite system that is recognized by the IMO, for use in the GMDSS")]
		[PermittedValues([1,2])]
		[Multiplicity(1)]
		public ObservableCollection<servingMobileSatelliteService> servingMobileSatelliteService  { get; set; } = new ();

		private String? _satelliteOceanRegion  = default;

		[Description("The identifier of the ocean region area, within which a station can obtain line-of-sight communication, with an Inmarsat satellite.")]
		//[Editor(typeof(Editors.HorizonEditor<areaA3ServiceDescription>), typeof(Editors.HorizonEditor))]
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

		[Description("The coastal warning area identification letter(s) to be selected to receive the Maritime Safety Information (MSI) for the corresponding coastal warning area(s).")]
		//[Editor(typeof(Editors.HorizonEditor<areaA3ServiceDescription>), typeof(Editors.HorizonEditor))]
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
	[Description("Details related to the content of the broadcast.")]
	[CategoryOrder("broadcastContent",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class broadcastContentViewModel : ComplexViewModel<broadcastContent> {
		[Description("Categorization of the broadcast content by subject.")]
		[PermittedValues([1,2,3,4,5,6,7,8])]
		[Multiplicity(1)]
		public ObservableCollection<typeOfBroadcastContent> typeOfBroadcastContent  { get; set; } = new ();

		[Description("A code specified for a communication system to indicate the subject group or message type of the transmitted content, e.g., message type of DGNSS, subject code for NAVDAT, or subject indicator character for NAVTEX.")]
		[Optional]
		public ObservableCollection<String> subjectOrMessageTypeCode  { get; set; } = new ();

		private String? _subjectDescription  = default;

		[Description("Descriptions of the subject of the transmitted message.")]
		//[Editor(typeof(Editors.HorizonEditor<broadcastContent>), typeof(Editors.HorizonEditor))]
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

		[Description("The time on each day when observations are made.")]
		//[Editor(typeof(Editors.HorizonEditor<broadcastContent>), typeof(Editors.HorizonEditor))]
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

		[Description("Classification of regularity or conditions for transmission.")]
		//[Editor(typeof(Editors.HorizonEditor<broadcastContent>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5])]
		[Optional]
		public transmissionRegularity? transmissionRegularity {
			get {
				return _transmissionRegularity;
			}
			set {
				SetValue(ref _transmissionRegularity, value);
			}
		}

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
	[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
	[CategoryOrder("contactAddress",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class contactAddressViewModel : ComplexViewModel<contactAddress> {
		private String? _deliveryPoint  = default;

		[Description("Details of where post can be delivered such as the apartment, name and/or number of a street, building or PO Box.")]
		//[Editor(typeof(Editors.HorizonEditor<contactAddress>), typeof(Editors.HorizonEditor))]
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

		[Description("The name of a town or city.")]
		//[Editor(typeof(Editors.HorizonEditor<contactAddress>), typeof(Editors.HorizonEditor))]
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

		[Description("A generic term for an administrative region within a country at a level below that of the sovereign state.")]
		//[Editor(typeof(Editors.HorizonEditor<contactAddress>), typeof(Editors.HorizonEditor))]
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

		[Description("The name of a nation.")]
		//[Editor(typeof(Editors.HorizonEditor<contactAddress>), typeof(Editors.HorizonEditor))]
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

		[Description("Known in various countries as a postcode, or ZIP code, the postal code is a series of letters and/or digits that identifies each postal delivery area.")]
		//[Editor(typeof(Editors.HorizonEditor<contactAddress>), typeof(Editors.HorizonEditor))]
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
	[Description("Details related to the indication of the radio coverage.")]
	[CategoryOrder("coverageIndication",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class coverageIndicationViewModel : ComplexViewModel<coverageIndication> {
		private double? _minimumReceivedPower  = default;

		[Description("Minimum received power in dBm.")]
		//[Editor(typeof(Editors.HorizonEditor<coverageIndication>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? minimumReceivedPower {
			get {
				return _minimumReceivedPower;
			}
			set {
				SetValue(ref _minimumReceivedPower, value);
			}
		}

		private double? _presumedReceiverAntennaHeight  = default;

		[Description("Presumed receiver antenna height for the calculation of radio coverage.")]
		//[Editor(typeof(Editors.HorizonEditor<coverageIndication>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? presumedReceiverAntennaHeight {
			get {
				return _presumedReceiverAntennaHeight;
			}
			set {
				SetValue(ref _presumedReceiverAntennaHeight, value);
			}
		}

		private double? _minimumSignalToInterferenceNoiseRatio  = default;

		[Description("The minimum value of Signal to Interference plus Noise Ratio (SINR) in dB.")]
		//[Editor(typeof(Editors.HorizonEditor<coverageIndication>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? minimumSignalToInterferenceNoiseRatio {
			get {
				return _minimumSignalToInterferenceNoiseRatio;
			}
			set {
				SetValue(ref _minimumSignalToInterferenceNoiseRatio, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[PermittedValues([1,2,4,5,7,8,14,16,17,24,25,26,27])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Description("A non-formatted digital text string.")]
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
	[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
	[CategoryOrder("featureName",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class featureNameViewModel : ComplexViewModel<featureName> {
		private String _language  = string.Empty;

		[Description("The method of human communication, either spoken or written, consisting of the use of words in a structured and conventional way.")]
		//[Editor(typeof(Editors.HorizonEditor<featureName>), typeof(Editors.HorizonEditor))]
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

		[Description("The individual name of a feature.")]
		//[Editor(typeof(Editors.HorizonEditor<featureName>), typeof(Editors.HorizonEditor))]
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

		[Description("Classification of the type and display level of the name of a feature in an end-user system.")]
		//[Editor(typeof(Editors.HorizonEditor<featureName>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public nameUsage? nameUsage {
			get {
				return _nameUsage;
			}
			set {
				SetValue(ref _nameUsage, value);
			}
		}

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
	[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
	[CategoryOrder("fixedDateRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class fixedDateRangeViewModel : ComplexViewModel<fixedDateRange> {
		private String? _dateStart  = default;

		[Description("The earliest date on which an object (for example a buoy) will be present.")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("The latest date on which an object (for example a buoy) will be present.")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("The time corresponding to the start of an active period.")]
		//[Editor(typeof(Editors.HorizonEditor<fixedDateRange>), typeof(Editors.HorizonEditor))]
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

		[Description("The time corresponding to the end of an active period.")]
		//[Editor(typeof(Editors.HorizonEditor<fixedDateRange>), typeof(Editors.HorizonEditor))]
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
	[Description("A pair of frequencies for transmitting and receiving radio signals. The shore station transmits and receives on the frequencies indicated.")]
	[CategoryOrder("frequencyPair",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class frequencyPairViewModel : ComplexViewModel<frequencyPair> {
		private int? _frequencyShoreStationReceives  = default;

		[Description("The shore station receiver frequency.")]
		//[Editor(typeof(Editors.HorizonEditor<frequencyPair>), typeof(Editors.HorizonEditor))]
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

		[Description("The shore station transmitter frequency.")]
		//[Editor(typeof(Editors.HorizonEditor<frequencyPair>), typeof(Editors.HorizonEditor))]
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
	[Description("Frequency range of the electromagnetic spectrum in which the transmission is provided.")]
	[CategoryOrder("frequencyRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class frequencyRangeViewModel : ComplexViewModel<frequencyRange> {
		private int _frequencyLimitLower  = default;

		[Description("Lower limit of the frequency range in Hz.")]
		//[Editor(typeof(Editors.HorizonEditor<frequencyRange>), typeof(Editors.HorizonEditor))]
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

		[Description("Upper limit of the frequency range in Hz.")]
		//[Editor(typeof(Editors.HorizonEditor<frequencyRange>), typeof(Editors.HorizonEditor))]
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
	[Description("Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.")]
	[CategoryOrder("graphic",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class graphicViewModel : ComplexViewModel<graphic> {
		private String _pictorialRepresentation  = string.Empty;

		[Description("The file name of an externally referenced picture file.")]
		//[Editor(typeof(Editors.HorizonEditor<graphic>), typeof(Editors.HorizonEditor))]
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

		[Description("Short description of the purpose of the image.")]
		//[Editor(typeof(Editors.HorizonEditor<graphic>), typeof(Editors.HorizonEditor))]
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

		[Description("The production date of the source; for example the date of measurement.")]
		//[Editor(typeof(Editors.HorizonEditor<graphic>), typeof(Editors.HorizonEditor))]
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

		[Description("A set of information to provide credits to picture creator, copyright owner etc.")]
		//[Editor(typeof(Editors.HorizonEditor<graphic>), typeof(Editors.HorizonEditor))]
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
	[Description("The best estimate of the accuracy of a position.")]
	[CategoryOrder("horizontalPositionUncertainty",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class horizontalPositionUncertaintyViewModel : ComplexViewModel<horizontalPositionUncertainty> {
		private double _uncertaintyFixed  = default;

		[Description("The best estimate of the fixed horizontal or vertical accuracy component for positions, depths, heights, vertical distances and vertical clearances.")]
		//[Editor(typeof(Editors.HorizonEditor<horizontalPositionUncertainty>), typeof(Editors.HorizonEditor))]
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

		[Description("The factor to be applied to the variable component of an uncertainty equation so as to provide the best estimate of the variable horizontal or vertical accuracy component for positions, depths, heights, vertical distances and vertical clearances.")]
		//[Editor(typeof(Editors.HorizonEditor<horizontalPositionUncertainty>), typeof(Editors.HorizonEditor))]
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
	[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
	[CategoryOrder("information",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class informationViewModel : ComplexViewModel<information> {
		private String? _fileLocator  = default;

		[Description("The location of a fragment of text or other information in a support file.")]
		//[Editor(typeof(Editors.HorizonEditor<information>), typeof(Editors.HorizonEditor))]
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

		[Description("The file name of an externally referenced text file.")]
		//[Editor(typeof(Editors.HorizonEditor<information>), typeof(Editors.HorizonEditor))]
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

		[Description("Words set at the head of a passage or page to introduce or categorize.")]
		//[Editor(typeof(Editors.HorizonEditor<information>), typeof(Editors.HorizonEditor))]
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

		[Description("The method of human communication, either spoken or written, consisting of the use of words in a structured and conventional way.")]
		//[Editor(typeof(Editors.HorizonEditor<information>), typeof(Editors.HorizonEditor))]
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

		[Description("A non-formatted digital text string.")]
		//[Editor(typeof(Editors.HorizonEditor<information>), typeof(Editors.HorizonEditor))]
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
	[Description("Information about online sources from which a resource or data can be obtained.")]
	[CategoryOrder("onlineResource",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class onlineResourceViewModel : ComplexViewModel<onlineResource> {
		private String? _headline  = default;

		[Description("Words set at the head of a passage or page to introduce or categorize.")]
		//[Editor(typeof(Editors.HorizonEditor<onlineResource>), typeof(Editors.HorizonEditor))]
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

		[Description("Location (address) for online access using a URL/URI address or similar addressing scheme.")]
		//[Editor(typeof(Editors.HorizonEditor<onlineResource>), typeof(Editors.HorizonEditor))]
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

		[Description("Name of the online resource.")]
		//[Editor(typeof(Editors.HorizonEditor<onlineResource>), typeof(Editors.HorizonEditor))]
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
	[Description("The active period of a recurring event or occurrence.")]
	[CategoryOrder("periodicDateRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class periodicDateRangeViewModel : ComplexViewModel<periodicDateRange> {
		private String _dateStart  = string.Empty;

		[Description("The earliest date on which an object (for example a buoy) will be present.")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("The latest date on which an object (for example a buoy) will be present.")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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
	[Description("Details related to the radio channel used in the radio service.")]
	[CategoryOrder("radioChannelDetails",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class radioChannelDetailsViewModel : ComplexViewModel<radioChannelDetails> {
		[Description("A channel number assigned to a specific radio frequency, frequencies or frequency band.")]
		[Optional]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();

		[Description("A pair of frequencies for transmitting and receiving radio signals. The shore station transmits and receives on the frequencies indicated.")]
		[Optional]
		public ObservableCollection<frequencyPairViewModel> frequencyPair  { get; set; } = new ();

		[Description("The average number of bits communicated (transmitted) in 1 second. (ITU Terms and Definitions)")]
		[Optional]
		public ObservableCollection<int> dataTransmissionRate  { get; set; } = new ();

		private Boolean _transmissionOfTrafficLists  = false;

		[Description("Describes whether a station transmits traffic lists.")]
		//[Editor(typeof(Editors.HorizonEditor<radioChannelDetails>), typeof(Editors.HorizonEditor))]
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

		[Description("The hours during which the watch on the radio channel is maintained. Hours are given in UTC, such as 0930-1000, or by using a service symbol such as \"H24\" for a 24 hour service.")]
		//[Editor(typeof(Editors.HorizonEditor<radioChannelDetails>), typeof(Editors.HorizonEditor))]
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
	[Description("Identifiers of the radio station in various maritime radiocommunication services.")]
	[CategoryOrder("radiocommunicationIdentifier",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class radiocommunicationIdentifierViewModel : ComplexViewModel<radiocommunicationIdentifier> {
		[Description("The designated call-sign of a station (radio station, radar station, pilot, ...).")]
		[Optional]
		public ObservableCollection<String> callSign  { get; set; } = new ();

		[Description("The Maritime Mobile Service Identity (MMSI) Code is formed of a series of nine digits which are transmitted over the radio path in order to uniquely identify ship stations, ship earth stations, coast stations, coast earth stations, and group calls. These identities are formed in such a way that the identity or part thereof can be used by telephone and telex subscribers connected to the general telecommunications network principally to call ships automatically.")]
		[Optional]
		public ObservableCollection<String> mMSICode  { get; set; } = new ();

		[Description("When stations of the maritime mobile service (direct printing telegraphy) use selective calling devices, their Selective Call numbers (SELCAL) are formed of four digits (coast stations).")]
		[Optional]
		public ObservableCollection<int> selectiveCallNumber  { get; set; } = new ();

		[Description("A code, issued according to a standard and coordination procedure, to identify the transmission of a coast radio station.")]
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
	[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
	[CategoryOrder("rxNCode",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class rxNCodeViewModel : ComplexViewModel<rxNCode> {
		private String? _headline  = default;

		[Description("Words set at the head of a passage or page to introduce or categorize.")]
		//[Editor(typeof(Editors.HorizonEditor<rxNCode>), typeof(Editors.HorizonEditor))]
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

		[Description("The principal subject matter of regulations, restrictions, recommendations or nautical information.")]
		//[Editor(typeof(Editors.HorizonEditor<rxNCode>), typeof(Editors.HorizonEditor))]
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

		[Description("The action or activity of a vessel.")]
		//[Editor(typeof(Editors.HorizonEditor<rxNCode>), typeof(Editors.HorizonEditor))]
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
	[Description("The nature and timings of a daily schedule by days of the week.")]
	[CategoryOrder("scheduleByDayOfWeek",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class scheduleByDayOfWeekViewModel : ComplexViewModel<scheduleByDayOfWeek> {
		private categoryOfSchedule? _categoryOfSchedule  = default;

		[Description("The type of schedule, for instance opening, closure, etc.")]
		//[Editor(typeof(Editors.HorizonEditor<scheduleByDayOfWeek>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public categoryOfSchedule? categoryOfSchedule {
			get {
				return _categoryOfSchedule;
			}
			set {
				SetValue(ref _categoryOfSchedule, value);
			}
		}

		[Description("The regular weekly operation times of a service or schedule.")]
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
	[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference. The sector limit specifies the limits of the sector In a clockwise direction around the central feature (for example a light).")]
	[CategoryOrder("sectorLimit",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorLimitViewModel : ComplexViewModel<sectorLimit> {
		private sectorLimitOneViewModel _sectorLimitOne  = default;

		[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit one specifies the first limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).")]
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

		[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit two specifies the second limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).")]
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
	[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit one specifies the first limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).")]
	[CategoryOrder("sectorLimitOne",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorLimitOneViewModel : ComplexViewModel<sectorLimitOne> {
		private double _sectorBearing  = default;

		[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector bearing specifies the limit of the sector.")]
		//[Editor(typeof(Editors.HorizonEditor<sectorLimitOne>), typeof(Editors.HorizonEditor))]
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

		[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector line length specifies the displayed length of the line, in ground units, defining the limit of the sector.")]
		//[Editor(typeof(Editors.HorizonEditor<sectorLimitOne>), typeof(Editors.HorizonEditor))]
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
	[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit two specifies the second limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).")]
	[CategoryOrder("sectorLimitTwo",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorLimitTwoViewModel : ComplexViewModel<sectorLimitTwo> {
		private double _sectorBearing  = default;

		[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector bearing specifies the limit of the sector.")]
		//[Editor(typeof(Editors.HorizonEditor<sectorLimitTwo>), typeof(Editors.HorizonEditor))]
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

		[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector line length specifies the displayed length of the line, in ground units, defining the limit of the sector.")]
		//[Editor(typeof(Editors.HorizonEditor<sectorLimitTwo>), typeof(Editors.HorizonEditor))]
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
	[Description("Provides an indication of the vertical and horizontal positional uncertainty of bathymetric data, optionally within a specified date range.")]
	[CategoryOrder("spatialAccuracy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class spatialAccuracyViewModel : ComplexViewModel<spatialAccuracy> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The best estimate of the accuracy of a position.")]
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

		[Description("The best estimate of the vertical accuracy of depths, heights, vertical distances and vertical clearances.")]
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
	[Description("The complex attribute describes the period of the hydrographic survey, as the time between its sub-attributes.")]
	[CategoryOrder("surveyDateRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class surveyDateRangeViewModel : ComplexViewModel<surveyDateRange> {
		private String? _dateStart  = default;

		[Description("The earliest date on which an object (for example a buoy) will be present.")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("The latest date on which an object (for example a buoy) will be present.")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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
	[Description("A means or channel of communicating at a distance by electrical or electromagnetic means such as telegraphy, telephony, or broadcasting.")]
	[CategoryOrder("telecommunications",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class telecommunicationsViewModel : ComplexViewModel<telecommunications> {
		private String? _contactInstructions  = default;

		[Description("Instructions provided on how to contact a particular person, organisation or service.")]
		//[Editor(typeof(Editors.HorizonEditor<telecommunications>), typeof(Editors.HorizonEditor))]
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

		[Description("An identifier, such as words, numbers, letters, symbols, or any combination of those used to establish a contact to a particular person, organisation or service.")]
		//[Editor(typeof(Editors.HorizonEditor<telecommunications>), typeof(Editors.HorizonEditor))]
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

		[Description("Classification of methods of communication over a distance by electrical, electronic, or electromagnetic means.")]
		//[Editor(typeof(Editors.HorizonEditor<telecommunications>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8])]
		[Optional]
		public telecommunicationService? telecommunicationService {
			get {
				return _telecommunicationService;
			}
			set {
				SetValue(ref _telecommunicationService, value);
			}
		}

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
	[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
	[CategoryOrder("textContent",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class textContentViewModel : ComplexViewModel<textContent> {
		private categoryOfText? _categoryOfText  = default;

		[Description("Classification of completeness of textual information in relation to the source material from which it is derived.")]
		//[Editor(typeof(Editors.HorizonEditor<textContent>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public categoryOfText? categoryOfText {
			get {
				return _categoryOfText;
			}
			set {
				SetValue(ref _categoryOfText, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private onlineResourceViewModel? _onlineResource  = default;

		[Description("Information about online sources from which a resource or data can be obtained.")]
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

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		//[Editor(typeof(Editors.HorizonEditor<textContent>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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
	[Description("The regular weekly operation times of a service or schedule.")]
	[CategoryOrder("timeIntervalsByDayOfWeek",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class timeIntervalsByDayOfWeekViewModel : ComplexViewModel<timeIntervalsByDayOfWeek> {
		[Description("Any one of seven days in a week.")]
		[PermittedValues([1,2,3,4,5,6,7])]
		[Multiplicity(0, 7)]
		public ObservableCollection<dayOfWeek> dayOfWeek  { get; set; } = new ();

		private Boolean? _dayOfWeekIsRange  = default;

		[Description("A statement expressing if the days of the week identified define a range or not.")]
		//[Editor(typeof(Editors.HorizonEditor<timeIntervalsByDayOfWeek>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? dayOfWeekIsRange {
			get {
				return _dayOfWeekIsRange;
			}
			set {
				SetValue(ref _dayOfWeekIsRange, value);
			}
		}

		[Description("The time corresponding to the start of an active period.")]
		[Optional]
		public ObservableCollection<S100Framework.DomainModel.S100.Time> timeOfDayStart  { get; set; } = new ();

		[Description("The time corresponding to the end of an active period.")]
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
	[Description("One or more times in the day when the radio station starts a routine transmission, normally expressed in UTC or local time.")]
	[CategoryOrder("timesOfTransmission",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class timesOfTransmissionViewModel : ComplexViewModel<timesOfTransmission> {
		private int? _minutePastEvenHours  = default;

		[Description("The minute past even hours when a routine transmission starts.")]
		//[Editor(typeof(Editors.HorizonEditor<timesOfTransmission>), typeof(Editors.HorizonEditor))]
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

		[Description("The minute past odd hours when a routine transmission starts.")]
		//[Editor(typeof(Editors.HorizonEditor<timesOfTransmission>), typeof(Editors.HorizonEditor))]
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

		[Description("The minute past every hour when a routine transmission starts.")]
		//[Editor(typeof(Editors.HorizonEditor<timesOfTransmission>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? minutePastEveryHour {
			get {
				return _minutePastEveryHour;
			}
			set {
				SetValue(ref _minutePastEveryHour, value);
			}
		}

		[Description("The time in the day when scheduled transmissions start.")]
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
	[Description("The best estimate of the vertical accuracy of depths, heights, vertical distances and vertical clearances.")]
	[CategoryOrder("verticalUncertainty",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class verticalUncertaintyViewModel : ComplexViewModel<verticalUncertainty> {
		private double _uncertaintyFixed  = default;

		[Description("The best estimate of the fixed horizontal or vertical accuracy component for positions, depths, heights, vertical distances and vertical clearances.")]
		//[Editor(typeof(Editors.HorizonEditor<verticalUncertainty>), typeof(Editors.HorizonEditor))]
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

		[Description("The factor to be applied to the variable component of an uncertainty equation so as to provide the best estimate of the variable horizontal or vertical accuracy component for positions, depths, heights, vertical distances and vertical clearances.")]
		//[Editor(typeof(Editors.HorizonEditor<verticalUncertainty>), typeof(Editors.HorizonEditor))]
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
	[Description("Combinations of values of measurable characteristics or dimensions of vessels, used to specify size and tonnage ranges.")]
	[CategoryOrder("vesselMeasurementsSpecification",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class vesselMeasurementsSpecificationViewModel : ComplexViewModel<vesselMeasurementsSpecification> {
		private vesselsCharacteristics _vesselsCharacteristics  = default;

		[Description("Characteristics of vessels.")]
		//[Editor(typeof(Editors.HorizonEditor<vesselMeasurementsSpecification>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,6,7,8,9,10,11,12,13])]
		[Mandatory]
		public vesselsCharacteristics vesselsCharacteristics {
			get {
				return _vesselsCharacteristics;
			}
			set {
				SetValue(ref _vesselsCharacteristics, value);
			}
		}

		private double _vesselsCharacteristicsValue  = default;

		[Description("The value of a particular characteristic such as a dimension or tonnage of a vessel.")]
		//[Editor(typeof(Editors.HorizonEditor<vesselMeasurementsSpecification>), typeof(Editors.HorizonEditor))]
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

		[Description("The unit used for vessel characteristics attribute.")]
		//[Editor(typeof(Editors.HorizonEditor<vesselMeasurementsSpecification>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,3,4,5,6,7,9])]
		[Mandatory]
		public vesselsCharacteristicsUnit vesselsCharacteristicsUnit {
			get {
				return _vesselsCharacteristicsUnit;
			}
			set {
				SetValue(ref _vesselsCharacteristicsUnit, value);
			}
		}

		private comparisonOperator _comparisonOperator  = default;

		[Description("Numerical comparison.")]
		//[Editor(typeof(Editors.HorizonEditor<vesselMeasurementsSpecification>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6])]
		[Mandatory]
		public comparisonOperator comparisonOperator {
			get {
				return _comparisonOperator;
			}
			set {
				SetValue(ref _comparisonOperator, value);
			}
		}

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
	[Description("A feature association for the binding between at least one instance of a geo feature and an instance of an information type.")]
	[CategoryOrder("AdditionalInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AdditionalInformationViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new AdditionalInformation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Additional Information";
	}



	/// <summary>
	/// Association between a geographic location and a regulation, restriction, recommendation, or nautical information
	/// </summary>
	[Description("Association between a geographic location and a regulation, restriction, recommendation, or nautical information")]
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
	[Description("Contact information for an authority")]
	[CategoryOrder("AuthorityContact",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AuthorityContactViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new AuthorityContact {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Authority Contact";
	}



	/// <summary>
	/// Service hours for an authority
	/// </summary>
	[Description("Service hours for an authority")]
	[CategoryOrder("AuthorityHours",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AuthorityHoursViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new AuthorityHours {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Authority Hours";
	}



	/// <summary>
	/// Available Quality of Service (QoS) within the area.
	/// </summary>
	[Description("Available Quality of Service (QoS) within the area.")]
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
	[Description("The broadcast content and schedule of a service area or facility")]
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
	[Description("The transmission details for the broadcast or the broadcast details available from the transmission")]
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
	[Description("The service that allows users to connect to the internet.")]
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
	[Description("Exception to the usual working day")]
	[CategoryOrder("ExceptionalWorkday",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ExceptionalWorkdayViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new ExceptionalWorkday {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Exceptional Workday";
	}



	/// <summary>
	/// Association class specifying the relationship between the subset of vessels described by an APPLIC data object and a regulation (restriction, recommendation, or nautical information).
	/// </summary>
	[Description("Association class specifying the relationship between the subset of vessels described by an APPLIC data object and a regulation (restriction, recommendation, or nautical information).")]
	[CategoryOrder("InclusionType",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class InclusionTypeViewModel : InformationAssociationViewModel {
		private membership _membership  = default;

		[Description("Indicates whether a vessel is included or excluded from the regulation/restriction/recommendation/nautical information.")]
		[Category("InclusionType")]
		//[Editor(typeof(Editors.HorizonEditor<InclusionType>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2])]
		[Mandatory]
		public membership membership {
			get {
				return _membership;
			}
			set {
				SetValue(ref _membership, value);
			}
		}


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
	[Description("Working hours for a service or facility described by a geographic location")]
	[CategoryOrder("LocationHours",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LocationHoursViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new LocationHours {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Location Hours";
	}



	/// <summary>
	/// Association class for associations describing whether the subsets of vessels determined by the ship characteristics specified in APPLIC may (or must, etc.) transit,  enter, or use  a feature.
	/// </summary>
	[Description("Association class for associations describing whether the subsets of vessels determined by the ship characteristics specified in APPLIC may (or must, etc.) transit,  enter, or use  a feature.")]
	[CategoryOrder("PermissionType",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PermissionTypeViewModel : InformationAssociationViewModel {
		private categoryOfRelationship _categoryOfRelationship  = default;

		[Description("Expresses constraints or requirements on vessel actions or activities in relation to a geographic feature, facility, or service.")]
		[Category("PermissionType")]
		//[Editor(typeof(Editors.HorizonEditor<PermissionType>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6])]
		[Mandatory]
		public categoryOfRelationship categoryOfRelationship {
			get {
				return _categoryOfRelationship;
			}
			set {
				SetValue(ref _categoryOfRelationship, value);
			}
		}


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
	[Description("The radio control centre for a marine radio service")]
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
	/// Related Organisation
	/// </summary>
	[Description("Related Organisation")]
	[CategoryOrder("relatedOrganisation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class relatedOrganisationViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new relatedOrganisation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Related Organisation";
	}



	/// <summary>
	/// Contact details for a service or facility
	/// </summary>
	[Description("Contact details for a service or facility")]
	[CategoryOrder("ServiceContact",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ServiceContactViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new ServiceContact {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Service Contact";
	}



	/// <summary>
	/// The coordinating authority for a service area
	/// </summary>
	[Description("The coordinating authority for a service area")]
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
	[Description("An association for the binding between a spatial type and its spatial quality information.")]
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
	[Description("Available Telemedical Assistance Service and related coordination centre.")]
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
	[Description("The radio transmission of a service area or facility")]
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
	[Description("A feature association for the binding between an aggregation feature that describes areas of varying uncertainty about a service or phenomenon and a geographic feature describing the service or phenomenon.")]
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
	[Description("A feature association for the binding between an aggregation feature that describes areas of varying uncertainty about a service or phenomenon and zones of uncertainty about the service or phenomenon.")]
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
	[Description("Association linking the location from which a service is provided and the area(s) served.")]
	[CategoryOrder("ServiceProvisionArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ServiceProvisionAreaViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new ServiceProvisionArea {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Service Provision Area";
	}



	/// <summary>
	/// Describes the relationship between vessel characteristics and: (i) the applicability of an associated information object or feature to the vessel; or, (ii) the use of a facility, place, or service by the vessel; or, (iii) passage of the vessel through an area.
	/// </summary>
	[Description("Describes the relationship between vessel characteristics and: (i) the applicability of an associated information object or feature to the vessel; or, (ii) the use of a facility, place, or service by the vessel; or, (iii) passage of the vessel through an area.")]
	[CategoryOrder("Applicability",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ApplicabilityViewModel : InformationViewModel<Applicability> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("InformationType")]
		//[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("Whether the vessel is in ballast.")]
		[Category("Applicability")]
		//[Editor(typeof(Editors.HorizonEditor<Applicability>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? inBallast {
			get {
				return _inBallast;
			}
			set {
				SetValue(ref _inBallast, value);
			}
		}

		[Description("Classification of vessels by function or use.")]
		[Category("Applicability")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17])]
		[Optional]
		public ObservableCollection<categoryOfVessel> categoryOfVessel  { get; set; } = new ();

		private categoryOfVesselRegistry? _categoryOfVesselRegistry  = default;

		[Description("The locality of vessel registration or enrolment relative to the nationality of a port, territorial sea, administrative area, exclusive zone or other location.")]
		[Category("Applicability")]
		//[Editor(typeof(Editors.HorizonEditor<Applicability>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2])]
		[Optional]
		public categoryOfVesselRegistry? categoryOfVesselRegistry {
			get {
				return _categoryOfVesselRegistry;
			}
			set {
				SetValue(ref _categoryOfVesselRegistry, value);
			}
		}

		[Description("Classification of the different types of cargo that a ship may be carrying.")]
		[Category("Applicability")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15])]
		[Optional]
		public ObservableCollection<categoryOfCargo> categoryOfCargo  { get; set; } = new ();

		[Description("Classification of dangerous goods or hazardous materials based on the International Maritime Dangerous Goods Code (IMDG Code).")]
		[Category("Applicability")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21])]
		[Optional]
		public ObservableCollection<categoryOfDangerousOrHazardousCargo> categoryOfDangerousOrHazardousCargo  { get; set; } = new ();

		private logicalConnectives? _logicalConnectives  = default;

		[Description("Expresses whether all the constraints described by its co-attributes must be satisfied, or only one such constraint need be satisfied.")]
		[Category("Applicability")]
		//[Editor(typeof(Editors.HorizonEditor<Applicability>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2])]
		[Optional]
		public logicalConnectives? logicalConnectives {
			get {
				return _logicalConnectives;
			}
			set {
				SetValue(ref _logicalConnectives, value);
			}
		}

		private int? _thicknessOfIceCapability  = default;

		[Description("The thickness of ice that the ship can safely transit.")]
		[Category("Applicability")]
		//[Editor(typeof(Editors.HorizonEditor<Applicability>), typeof(Editors.HorizonEditor))]
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

		[Description("A description of the required handling characteristics of a vessel including hull design, main and auxiliary machinery, cargo handling equipment, navigation equipment and manoeuvring behaviour.")]
		[Category("Applicability")]
		//[Editor(typeof(Editors.HorizonEditor<Applicability>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? vesselPerformance {
			get {
				return _vesselPerformance;
			}
			set {
				SetValue(ref _vesselPerformance, value);
			}
		}

		[Description("Combinations of values of measurable characteristics or dimensions of vessels, used to specify size and tonnage ranges.")]
		[Category("Applicability")]
		[Optional]
		public ObservableCollection<vesselMeasurementsSpecificationViewModel> vesselMeasurementsSpecification  { get; set; } = new ();

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("Applicability")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("InclusionType","theApplicableRxN",["AbstractRxN"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> InclusionTypes { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. InclusionTypes.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.InclusionType> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Applicability.informationBindingDefinitions;

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
		}
	}



	/// <summary>
	/// A person or organisation having political or administrative power and control.
	/// </summary>
	[Description("A person or organisation having political or administrative power and control.")]
	[CategoryOrder("Authority",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AuthorityViewModel : InformationViewModel<Authority> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("InformationType")]
		//[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("The type of person, government agency or organisation granted powers of managing or controlling access to and/or activity in an area.")]
		[Category("Authority")]
		//[Editor(typeof(Editors.HorizonEditor<Authority>), typeof(Editors.HorizonEditor))]
		[PermittedValues([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
		[Optional]
		public categoryOfAuthority? categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

		private textContentViewModel? _textContent  = default;

		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
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

		[Category("InformationBindings")]
		[InformationBinding("AuthorityContact","theContactDetails",["ContactDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> AuthorityContacts { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("AuthorityHours","theServiceHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> AuthorityHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. AuthorityContacts.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.AuthorityContact> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. AuthorityHours.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.AuthorityHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Authority.informationBindingDefinitions;

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
		}
	}



	/// <summary>
	/// Description of the content and schedule of a service using broadcast technology of radiocommunications to deliver information (to every receiver within a direct range). Online resource to access the content may also be included.
	/// </summary>
	[Description("Description of the content and schedule of a service using broadcast technology of radiocommunications to deliver information (to every receiver within a direct range). Online resource to access the content may also be included.")]
	[CategoryOrder("BroadcastDetails",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BroadcastDetailsViewModel : InformationViewModel<BroadcastDetails> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("InformationType")]
		//[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		[Description("The method of human communication, either spoken or written, consisting of the use of words in a structured and conventional way.")]
		[Category("BroadcastDetails")]
		[Optional]
		public ObservableCollection<String> language  { get; set; } = new ();

		private categoryOfBroadcastCommunication? _categoryOfBroadcastCommunication  = default;

		[Description("Classification of broadcast or communications based on public availability and commercial/non-commercial nature.")]
		[Category("BroadcastDetails")]
		//[Editor(typeof(Editors.HorizonEditor<BroadcastDetails>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Optional]
		public categoryOfBroadcastCommunication? categoryOfBroadcastCommunication {
			get {
				return _categoryOfBroadcastCommunication;
			}
			set {
				SetValue(ref _categoryOfBroadcastCommunication, value);
			}
		}

		[Description("Details related to the content of the broadcast.")]
		[Category("BroadcastDetails")]
		[Multiplicity(1)]
		public ObservableCollection<broadcastContentViewModel> broadcastContent  { get; set; } = new ();

		[Description("One or more times in the day when the radio station starts a routine transmission, normally expressed in UTC or local time.")]
		[Category("BroadcastDetails")]
		[Optional]
		public ObservableCollection<timesOfTransmissionViewModel> timesOfTransmission  { get; set; } = new ();

		[Description("The regular weekly operation times of a service or schedule.")]
		[Category("BroadcastDetails")]
		[Optional]
		public ObservableCollection<timeIntervalsByDayOfWeekViewModel> timeIntervalsByDayOfWeek  { get; set; } = new ();

		private onlineResourceViewModel? _onlineResource  = default;

		[Description("Information about online sources from which a resource or data can be obtained.")]
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

		[Category("InformationBindings")]
		[InformationBinding("BroadcastTransmission","theTransmissionDetails",["TransmissionDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> BroadcastTransmissions { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. BroadcastTransmissions.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.BroadcastTransmission> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.BroadcastDetails.informationBindingDefinitions;

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
		}
	}



	/// <summary>
	/// Information related to the Quality of Service (QoS) of the connectivity.
	/// </summary>
	[Description("Information related to the Quality of Service (QoS) of the connectivity.")]
	[CategoryOrder("ConnectivityQualityOfService",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ConnectivityQualityOfServiceViewModel : InformationViewModel<ConnectivityQualityOfService> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("InformationType")]
		//[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		[Description("Categorization of the connectivity resource by Quality o Service (QoS).")]
		[Category("ConnectivityQualityOfService")]
		[PermittedValues([1,2,3,4])]
		[Optional]
		public ObservableCollection<typeOfConnectivityResource> typeOfConnectivityResource  { get; set; } = new ();

		private double? _uplinkBandwidth  = default;

		[Description("Uplink bandwith in Mbps")]
		[Category("ConnectivityQualityOfService")]
		//[Editor(typeof(Editors.HorizonEditor<ConnectivityQualityOfService>), typeof(Editors.HorizonEditor))]
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

		[Description("Downlink bandwidth in Mbps")]
		[Category("ConnectivityQualityOfService")]
		//[Editor(typeof(Editors.HorizonEditor<ConnectivityQualityOfService>), typeof(Editors.HorizonEditor))]
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

		[Description("Packet delay in ms")]
		[Category("ConnectivityQualityOfService")]
		//[Editor(typeof(Editors.HorizonEditor<ConnectivityQualityOfService>), typeof(Editors.HorizonEditor))]
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

		[Description("Maximum data burst volume in bytes")]
		[Category("ConnectivityQualityOfService")]
		//[Editor(typeof(Editors.HorizonEditor<ConnectivityQualityOfService>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? maximumDataBurstVolume {
			get {
				return _maximumDataBurstVolume;
			}
			set {
				SetValue(ref _maximumDataBurstVolume, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("ConnectivityQualityOfService")]
		[PermittedValues([1,2,4,5,7,8,14,16,17,25,26,27])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("ConnectivityQualityOfService")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];

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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.ConnectivityQualityOfService.informationBindingDefinitions;

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
	[Description("Information on how to reach a person or organisation by postal, internet, telephone, telex and radio systems.")]
	[CategoryOrder("ContactDetails",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ContactDetailsViewModel : InformationViewModel<ContactDetails> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("InformationType")]
		//[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("Instructions provided on how to contact a particular person, organisation or service.")]
		[Category("ContactDetails")]
		//[Editor(typeof(Editors.HorizonEditor<ContactDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? contactInstructions {
			get {
				return _contactInstructions;
			}
			set {
				SetValue(ref _contactInstructions, value);
			}
		}

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<contactAddressViewModel> contactAddress  { get; set; } = new ();

		[Description("A pair of frequencies for transmitting and receiving radio signals. The shore station transmits and receives on the frequencies indicated.")]
		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<frequencyPairViewModel> frequencyPair  { get; set; } = new ();

		private informationViewModel? _information  = default;

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
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

		[Description("Information about online sources from which a resource or data can be obtained.")]
		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<onlineResourceViewModel> onlineResource  { get; set; } = new ();

		[Description("A means or channel of communicating at a distance by electrical or electromagnetic means such as telegraphy, telephony, or broadcasting.")]
		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<telecommunicationsViewModel> telecommunications  { get; set; } = new ();

		private String? _callName  = default;

		[Description("The designated call name of a station; for example, radio station, radar station, pilot.")]
		[Category("ContactDetails")]
		//[Editor(typeof(Editors.HorizonEditor<ContactDetails>), typeof(Editors.HorizonEditor))]
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

		[Description("The designated call-sign of a station (radio station, radar station, pilot, ...).")]
		[Category("ContactDetails")]
		//[Editor(typeof(Editors.HorizonEditor<ContactDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? callSign {
			get {
				return _callSign;
			}
			set {
				SetValue(ref _callSign, value);
			}
		}

		[Description("A channel number assigned to a specific radio frequency, frequencies or frequency band.")]
		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();

		private String? _mMSICode  = default;

		[Description("The Maritime Mobile Service Identity (MMSI) Code is formed of a series of nine digits which are transmitted over the radio path in order to uniquely identify ship stations, ship earth stations, coast stations, coast earth stations, and group calls. These identities are formed in such a way that the identity or part thereof can be used by telephone and telex subscribers connected to the general telecommunications network principally to call ships automatically.")]
		[Category("ContactDetails")]
		//[Editor(typeof(Editors.HorizonEditor<ContactDetails>), typeof(Editors.HorizonEditor))]
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

		[Description("The method of human communication, either spoken or written, consisting of the use of words in a structured and conventional way.")]
		[Category("ContactDetails")]
		//[Editor(typeof(Editors.HorizonEditor<ContactDetails>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationBindings")]
		[InformationBinding("AuthorityContact","theAuthority",["Authority","RadioControlCentre"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> AuthorityContacts { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. AuthorityContacts.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.AuthorityContact> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.ContactDetails.informationBindingDefinitions;

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
		}
	}



	/// <summary>
	/// Nautical information about a related area or facility.
	/// </summary>
	[Description("Nautical information about a related area or facility.")]
	[CategoryOrder("NauticalInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NauticalInformationViewModel : InformationViewModel<NauticalInformation> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("InformationType")]
		//[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("The type of person, government agency or organisation granted powers of managing or controlling access to and/or activity in an area.")]
		[Category("AbstractRxN")]
		//[Editor(typeof(Editors.HorizonEditor<AbstractRxN>), typeof(Editors.HorizonEditor))]
		[PermittedValues([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
		[Optional]
		public categoryOfAuthority? categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

		private textContentViewModel? _textContent  = default;

		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
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

		[Description("Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.")]
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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();



		public override informationBinding[] GetInformationBindings() => [];

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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.NauticalInformation.informationBindingDefinitions;

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
	[Description("Days when many services are not available. Often days of festivity or recreation or public holidays when normal working hours are limited, especially a national or religious festival, etc.")]
	[CategoryOrder("NonStandardWorkingDay",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NonStandardWorkingDayViewModel : InformationViewModel<NonStandardWorkingDay> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("InformationType")]
		//[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("NonStandardWorkingDay")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("The date of an event.")]
		[Category("NonStandardWorkingDay")]
		[Optional]
		public ObservableCollection<String> dateFixed  { get; set; } = new ();

		[Description("A day which is not fixed in the Gregorian calendar.")]
		[Category("NonStandardWorkingDay")]
		[Optional]
		public ObservableCollection<String> dateVariable  { get; set; } = new ();


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("ExceptionalWorkday","theServiceHours_nsdy",["ServiceHours"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ExceptionalWorkdays { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. ExceptionalWorkdays.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.ExceptionalWorkday> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.NonStandardWorkingDay.informationBindingDefinitions;

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
		}
	}



	/// <summary>
	/// The control centre of the radio service or radio stations
	/// </summary>
	[Description("The control centre of the radio service or radio stations")]
	[CategoryOrder("RadioControlCentre",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RadioControlCentreViewModel : InformationViewModel<RadioControlCentre> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("InformationType")]
		//[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("A statement that expresses if a Coast Guard station performs the function of a Maritime Rescue and Coordination Centre.")]
		[Category("RadioControlCentre")]
		//[Editor(typeof(Editors.HorizonEditor<RadioControlCentre>), typeof(Editors.HorizonEditor))]
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

		[Description("A statement that expresses if it accepts AMVER(Automated Mutual-Assistance Vessel Rescue system) reports")]
		[Category("RadioControlCentre")]
		//[Editor(typeof(Editors.HorizonEditor<RadioControlCentre>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public Boolean acceptAMVER {
			get {
				return _acceptAMVER;
			}
			set {
				SetValue(ref _acceptAMVER, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("RadioControlCentre")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private String? _hoursOfWatch  = default;

		[Description("The hours during which the watch on the radio channel is maintained. Hours are given in UTC, such as 0930-1000, or by using a service symbol such as \"H24\" for a 24 hour service.")]
		[Category("RadioControlCentre")]
		//[Editor(typeof(Editors.HorizonEditor<RadioControlCentre>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationBindings")]
		[InformationBinding("AuthorityContact","theContactDetails",["ContactDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> AuthorityContacts { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("AuthorityHours","theServiceHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> AuthorityHours { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("TMAS","theTMAS",["TelemedicalAssistanceService"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> TMAS { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. AuthorityContacts.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.AuthorityContact> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. AuthorityHours.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.AuthorityHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. TMAS.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.TMAS> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.RadioControlCentre.informationBindingDefinitions;

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
		}
	}



	/// <summary>
	/// Recommendations for a related area or facility.
	/// </summary>
	[Description("Recommendations for a related area or facility.")]
	[CategoryOrder("Recommendations",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RecommendationsViewModel : InformationViewModel<Recommendations> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("InformationType")]
		//[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("The type of person, government agency or organisation granted powers of managing or controlling access to and/or activity in an area.")]
		[Category("AbstractRxN")]
		//[Editor(typeof(Editors.HorizonEditor<AbstractRxN>), typeof(Editors.HorizonEditor))]
		[PermittedValues([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
		[Optional]
		public categoryOfAuthority? categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

		private textContentViewModel? _textContent  = default;

		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
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

		[Description("Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.")]
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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();



		public override informationBinding[] GetInformationBindings() => [];

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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Recommendations.informationBindingDefinitions;

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
	[Description("Regulations for a related area or facility.")]
	[CategoryOrder("Regulations",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RegulationsViewModel : InformationViewModel<Regulations> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("InformationType")]
		//[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("The type of person, government agency or organisation granted powers of managing or controlling access to and/or activity in an area.")]
		[Category("AbstractRxN")]
		//[Editor(typeof(Editors.HorizonEditor<AbstractRxN>), typeof(Editors.HorizonEditor))]
		[PermittedValues([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
		[Optional]
		public categoryOfAuthority? categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

		private textContentViewModel? _textContent  = default;

		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
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

		[Description("Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.")]
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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();



		public override informationBinding[] GetInformationBindings() => [];

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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Regulations.informationBindingDefinitions;

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
	[Description("Restrictions for a related area or facility.")]
	[CategoryOrder("Restrictions",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RestrictionsViewModel : InformationViewModel<Restrictions> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("InformationType")]
		//[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("The type of person, government agency or organisation granted powers of managing or controlling access to and/or activity in an area.")]
		[Category("AbstractRxN")]
		//[Editor(typeof(Editors.HorizonEditor<AbstractRxN>), typeof(Editors.HorizonEditor))]
		[PermittedValues([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
		[Optional]
		public categoryOfAuthority? categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

		private textContentViewModel? _textContent  = default;

		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
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

		[Description("Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.")]
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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();



		public override informationBinding[] GetInformationBindings() => [];

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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Restrictions.informationBindingDefinitions;

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
	[Description("The time when a service is available and known exceptions.")]
	[CategoryOrder("ServiceHours",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ServiceHoursViewModel : InformationViewModel<ServiceHours> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("InformationType")]
		//[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		[Description("The nature and timings of a daily schedule by days of the week.")]
		[Category("ServiceHours")]
		[Multiplicity(1)]
		public ObservableCollection<scheduleByDayOfWeekViewModel> scheduleByDayOfWeek  { get; set; } = new ();

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("ServiceHours")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("AuthorityHours","theAuthority",["Authority","RadioControlCentre"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> AuthorityHours { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("ExceptionalWorkday","partialWorkingDay",["NonStandardWorkingDay"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ExceptionalWorkdays { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. AuthorityHours.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.AuthorityHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. ExceptionalWorkdays.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.ExceptionalWorkday> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.ServiceHours.informationBindingDefinitions;

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
		}
	}



	/// <summary>
	/// The indication of the quality of the locational information for features in a dataset.
	/// </summary>
	[Description("The indication of the quality of the locational information for features in a dataset.")]
	[CategoryOrder("SpatialQuality",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SpatialQualityViewModel : InformationViewModel<SpatialQuality> {
		private qualityOfHorizontalMeasurement? _qualityOfHorizontalMeasurement  = default;

		[Description("The degree of reliability attributed to a position.")]
		[Category("SpatialQuality")]
		//[Editor(typeof(Editors.HorizonEditor<SpatialQuality>), typeof(Editors.HorizonEditor))]
		[PermittedValues([4])]
		[Optional]
		public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement {
			get {
				return _qualityOfHorizontalMeasurement;
			}
			set {
				SetValue(ref _qualityOfHorizontalMeasurement, value);
			}
		}

		private spatialAccuracyViewModel? _spatialAccuracy  = default;

		[Description("Provides an indication of the vertical and horizontal positional uncertainty of bathymetric data, optionally within a specified date range.")]
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


		public override informationBinding[] GetInformationBindings() => [];

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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SpatialQuality.informationBindingDefinitions;

		public SpatialQualityViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Spatial Quality";
	}



	/// <summary>
	/// A service to provide decision support and advice to the seafarer on board responsible for medical care.
	/// </summary>
	[Description("A service to provide decision support and advice to the seafarer on board responsible for medical care.")]
	[CategoryOrder("TelemedicalAssistanceService",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TelemedicalAssistanceServiceViewModel : InformationViewModel<TelemedicalAssistanceService> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("InformationType")]
		//[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("Instructions provided on how to contact a particular person, organisation or service.")]
		[Category("TelemedicalAssistanceService")]
		//[Editor(typeof(Editors.HorizonEditor<TelemedicalAssistanceService>), typeof(Editors.HorizonEditor))]
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

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
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

		[Description("Information about online sources from which a resource or data can be obtained.")]
		[Category("TelemedicalAssistanceService")]
		[Optional]
		public ObservableCollection<onlineResourceViewModel> onlineResource  { get; set; } = new ();

		[Description("A means or channel of communicating at a distance by electrical or electromagnetic means such as telegraphy, telephony, or broadcasting.")]
		[Category("TelemedicalAssistanceService")]
		[Optional]
		public ObservableCollection<telecommunicationsViewModel> telecommunications  { get; set; } = new ();

		private String? _languageInformation  = default;

		[Description("A description of the languages, alphabets and scripts in use.")]
		[Category("TelemedicalAssistanceService")]
		//[Editor(typeof(Editors.HorizonEditor<TelemedicalAssistanceService>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationBindings")]
		[InformationBinding("RadioServiceControl","theControlCentre",["RadioControlCentre"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> RadioServiceControls { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. RadioServiceControls.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.RadioServiceControl> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.TelemedicalAssistanceService.informationBindingDefinitions;

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
		}
	}



	/// <summary>
	/// Description of the radiocommunication service with respect to the radio method and radio channels for the transfer of information by means of signals.
	/// </summary>
	[Description("Description of the radiocommunication service with respect to the radio method and radio channels for the transfer of information by means of signals.")]
	[CategoryOrder("TransmissionDetails",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TransmissionDetailsViewModel : InformationViewModel<TransmissionDetails> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("InformationType")]
		//[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("InformationType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("Categorization of the radio service by the technology or system")]
		[Category("TransmissionDetails")]
		//[Editor(typeof(Editors.HorizonEditor<TransmissionDetails>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Optional]
		public typeOfRadioService? typeOfRadioService {
			get {
				return _typeOfRadioService;
			}
			set {
				SetValue(ref _typeOfRadioService, value);
			}
		}

		private frequencyBand? _frequencyBand  = default;

		[Description("A continuous set of frequencies lying between two specified limiting frequencies. (Rec. ITU-R V.662-3)")]
		[Category("TransmissionDetails")]
		//[Editor(typeof(Editors.HorizonEditor<TransmissionDetails>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6])]
		[Optional]
		public frequencyBand? frequencyBand {
			get {
				return _frequencyBand;
			}
			set {
				SetValue(ref _frequencyBand, value);
			}
		}

		private String? _classOfEmission  = default;

		[Description("The set of characteristics of an emission, designated by standard symbols, e.g. type of modulation of the main carrier, modulating signal, type of information to be transmitted, and also, if appropriate, any additional signal characteristics.")]
		[Category("TransmissionDetails")]
		//[Editor(typeof(Editors.HorizonEditor<TransmissionDetails>), typeof(Editors.HorizonEditor))]
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

		[Description("The communications standard applicable to accessing the radio service.")]
		[Category("TransmissionDetails")]
		//[Editor(typeof(Editors.HorizonEditor<TransmissionDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? communicationStandard {
			get {
				return _communicationStandard;
			}
			set {
				SetValue(ref _communicationStandard, value);
			}
		}

		[Description("Details related to the radio channel used in the radio service.")]
		[Category("TransmissionDetails")]
		[Multiplicity(1)]
		public ObservableCollection<radioChannelDetailsViewModel> radioChannelDetails  { get; set; } = new ();


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("BroadcastTransmission","theBroadcastDetails",["BroadcastDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> BroadcastTransmissions { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. BroadcastTransmissions.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.BroadcastTransmission> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.TransmissionDetails.informationBindingDefinitions;

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
		}
	}



	/// <summary>
	/// An area of connectivity coverage available for the subscription of connectivity service.
	/// </summary>
	[Description("An area of connectivity coverage available for the subscription of connectivity service.")]
	[CategoryOrder("ConnectivitySubscriptionArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ConnectivitySubscriptionAreaViewModel : FeatureViewModel<ConnectivitySubscriptionArea> {
		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("FeatureType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("Category of the communication system providing the connectivity coverage for subscription.")]
		[Category("ConnectivitySubscriptionArea")]
		//[Editor(typeof(Editors.HorizonEditor<ConnectivitySubscriptionArea>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Optional]
		public categoryOfConnectivitySubscription? categoryOfConnectivitySubscription {
			get {
				return _categoryOfConnectivitySubscription;
			}
			set {
				SetValue(ref _categoryOfConnectivitySubscription, value);
			}
		}

		private String? _communicationStandard  = default;

		[Description("The communications standard applicable to accessing the radio service.")]
		[Category("ConnectivitySubscriptionArea")]
		//[Editor(typeof(Editors.HorizonEditor<ConnectivitySubscriptionArea>), typeof(Editors.HorizonEditor))]
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

		[Description("The estimated range of a non-optical electromagnetic transmission.")]
		[Category("ConnectivitySubscriptionArea")]
		//[Editor(typeof(Editors.HorizonEditor<ConnectivitySubscriptionArea>), typeof(Editors.HorizonEditor))]
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

		[Description("Antenna height of the base station in metres.")]
		[Category("ConnectivitySubscriptionArea")]
		//[Editor(typeof(Editors.HorizonEditor<ConnectivitySubscriptionArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? baseStationAntennaHeight {
			get {
				return _baseStationAntennaHeight;
			}
			set {
				SetValue(ref _baseStationAntennaHeight, value);
			}
		}

		[Description("Frequency range of the electromagnetic spectrum in which the transmission is provided.")]
		[Category("ConnectivitySubscriptionArea")]
		[Optional]
		public ObservableCollection<frequencyRangeViewModel> frequencyRange  { get; set; } = new ();

		[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference. The sector limit specifies the limits of the sector In a clockwise direction around the central feature (for example a light).")]
		[Category("ConnectivitySubscriptionArea")]
		[Optional]
		public ObservableCollection<sectorLimitViewModel> sectorLimit  { get; set; } = new ();

		private coverageIndicationViewModel? _coverageIndication  = default;

		[Description("Details related to the indication of the radio coverage.")]
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

		[Category("InformationBindings")]
		[InformationBinding("ConnectivityService","connectivityServiceProvider",["Authority"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ConnectivityServices { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("ServiceContact","theContactDetails",["ContactDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ServiceContacts { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","theServiceHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("AvailableQoS","theQoS",["ConnectivityQualityOfService"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> AvailableQoS { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. ConnectivityServices.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.ConnectivityService> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. ServiceContacts.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.ServiceContact> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. LocationHours.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. AvailableQoS.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.AvailableQoS> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("ServiceProvisionArea","serviceProvider",["RadioStation"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> ServiceProvisionAreas { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. ServiceProvisionAreas.Select(e => new featureBinding<DomainModel.S123.FeatureAssociations.ServiceProvisionArea> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.ConnectivitySubscriptionArea.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.ConnectivitySubscriptionArea.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.ConnectivitySubscriptionArea.featureBindingDefinitions;

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
			ServiceProvisionAreas.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ServiceProvisionAreas));
			};
		}
	}



	/// <summary>
	/// An area defined for a global communications service based upon automated systems, both satellite based and terrestrial, to provide distress alerting and promulgation of maritime safety information for mariners.
	/// </summary>
	[Description("An area defined for a global communications service based upon automated systems, both satellite based and terrestrial, to provide distress alerting and promulgation of maritime safety information for mariners.")]
	[CategoryOrder("GMDSSArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class GMDSSAreaViewModel : FeatureViewModel<GMDSSArea> {
		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("FeatureType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("The identifier for a NAVAREA.")]
		[Category("GMDSSArea")]
		//[Editor(typeof(Editors.HorizonEditor<GMDSSArea>), typeof(Editors.HorizonEditor))]
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

		[Description("Identifier of membership of a particular nation.")]
		[Category("GMDSSArea")]
		//[Editor(typeof(Editors.HorizonEditor<GMDSSArea>), typeof(Editors.HorizonEditor))]
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

		[Description("Classification of GMDSS areas based on availability of GMDSS services and GMDSS equipment requirements.")]
		[Category("GMDSSArea")]
		//[Editor(typeof(Editors.HorizonEditor<GMDSSArea>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Mandatory]
		public categoryOfGMDSSArea categoryOfGMDSSArea {
			get {
				return _categoryOfGMDSSArea;
			}
			set {
				SetValue(ref _categoryOfGMDSSArea, value);
			}
		}

		[Description("Description of the radio service for area A3 of the Global Maritime Distress and Safety System (GMDSS).")]
		[Category("GMDSSArea")]
		[Optional]
		public ObservableCollection<areaA3ServiceDescriptionViewModel> areaA3ServiceDescription  { get; set; } = new ();


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("ServiceCoordination","coordinatingAuthority",["Authority"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ServiceCoordinations { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("RadioServiceControl","theControlCentre",["RadioControlCentre"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> RadioServiceControls { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("ServiceContact","theContactDetails",["ContactDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ServiceContacts { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","theServiceHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. ServiceCoordinations.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.ServiceCoordination> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. RadioServiceControls.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.RadioServiceControl> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. ServiceContacts.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.ServiceContact> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. LocationHours.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("ServiceProvisionArea","serviceProvider",["RadioStation"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> ServiceProvisionAreas { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. ServiceProvisionAreas.Select(e => new featureBinding<DomainModel.S123.FeatureAssociations.ServiceProvisionArea> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.GMDSSArea.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.GMDSSArea.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.GMDSSArea.featureBindingDefinitions;

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
			ServiceProvisionAreas.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ServiceProvisionAreas));
			};
		}
	}



	/// <summary>
	/// A region in which the perception of a phenomenon or the availability of a service is known only to a specified level of confidence.
	/// </summary>
	[Description("A region in which the perception of a phenomenon or the availability of a service is known only to a specified level of confidence.")]
	[CategoryOrder("IndeterminateZone",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class IndeterminateZoneViewModel : FeatureViewModel<IndeterminateZone> {
		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("FeatureType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("The likelihood that a vessel will experience the phenomenon described by a feature, or that the service described by the feature will be available.")]
		[Category("IndeterminateZone")]
		//[Editor(typeof(Editors.HorizonEditor<IndeterminateZone>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Optional]
		public informationConfidence? informationConfidence {
			get {
				return _informationConfidence;
			}
			set {
				SetValue(ref _informationConfidence, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("fuzzyZoneAggregation","theCollection",["FuzzyAreaAggregate"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> fuzzyZoneAggregations { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. fuzzyZoneAggregations.Select(e => new featureBinding<DomainModel.S123.FeatureAssociations.fuzzyZoneAggregation> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.IndeterminateZone.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.IndeterminateZone.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.IndeterminateZone.featureBindingDefinitions;

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
	[Description("A geographical sea area (which may include inland seas, lakes and waterways navigable by seagoing ships) established for the purpose of coordinating the broadcast of marine meteorological information.")]
	[CategoryOrder("METAREA",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class METAREAViewModel : FeatureViewModel<METAREA> {
		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("FeatureType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("The identifier for a METAREA.")]
		[Category("METAREA")]
		//[Editor(typeof(Editors.HorizonEditor<METAREA>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String idMETAREA {
			get {
				return _idMETAREA;
			}
			set {
				SetValue(ref _idMETAREA, value);
			}
		}

		[Description("Information about online sources from which a resource or data can be obtained.")]
		[Category("METAREA")]
		[Optional]
		public ObservableCollection<onlineResourceViewModel> onlineResource  { get; set; } = new ();


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("ServiceCoordination","coordinatingAuthority",["Authority"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ServiceCoordinations { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("ServiceContact","theContactDetails",["ContactDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ServiceContacts { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","theServiceHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("BroadcastService","theBroadcastDetails",["BroadcastDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> BroadcastServices { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("TransmissionService","theTransmissionDetails",["TransmissionDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> TransmissionServices { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. ServiceCoordinations.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.ServiceCoordination> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. ServiceContacts.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.ServiceContact> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. LocationHours.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. BroadcastServices.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.BroadcastService> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. TransmissionServices.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.TransmissionService> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("ServiceProvisionArea","serviceProvider",["RadioStation"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> ServiceProvisionAreas { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. ServiceProvisionAreas.Select(e => new featureBinding<DomainModel.S123.FeatureAssociations.ServiceProvisionArea> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public METAREAViewModel Load(METAREA instance) {
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
			var instance = new METAREA {
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
		public METAREA Model => new () {
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.METAREA.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.METAREA.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.METAREA.featureBindingDefinitions;

		public METAREAViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public METAREAViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"METAREA";

		public METAREAViewModel() : base() {
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
			ServiceProvisionAreas.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ServiceProvisionAreas));
			};
		}
	}



	/// <summary>
	/// The short title for a geographical sea area (may include inland seas, lakes and waterways navigable by sea-going ships) established for the purpose of coordinating the broadcast of navigational warnings. The term NAVAREA followed by a roman numeral may be used to identify a particular sea area. The delimitation of such areas is not related to and shall not prejudice the delimitation of any boundaries between States.
	/// </summary>
	[Description("The short title for a geographical sea area (may include inland seas, lakes and waterways navigable by sea-going ships) established for the purpose of coordinating the broadcast of navigational warnings. The term NAVAREA followed by a roman numeral may be used to identify a particular sea area. The delimitation of such areas is not related to and shall not prejudice the delimitation of any boundaries between States.")]
	[CategoryOrder("NAVAREA",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NAVAREAViewModel : FeatureViewModel<NAVAREA> {
		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("FeatureType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("The identifier for a NAVAREA.")]
		[Category("NAVAREA")]
		//[Editor(typeof(Editors.HorizonEditor<NAVAREA>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String idNAVAREA {
			get {
				return _idNAVAREA;
			}
			set {
				SetValue(ref _idNAVAREA, value);
			}
		}

		[Description("Information about online sources from which a resource or data can be obtained.")]
		[Category("NAVAREA")]
		[Optional]
		public ObservableCollection<onlineResourceViewModel> onlineResource  { get; set; } = new ();


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("ServiceCoordination","coordinatingAuthority",["Authority"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ServiceCoordinations { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("ServiceContact","theContactDetails",["ContactDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ServiceContacts { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","theServiceHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("BroadcastService","theBroadcastDetails",["BroadcastDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> BroadcastServices { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("TransmissionService","theTransmissionDetails",["TransmissionDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> TransmissionServices { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. ServiceCoordinations.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.ServiceCoordination> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. ServiceContacts.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.ServiceContact> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. LocationHours.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. BroadcastServices.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.BroadcastService> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. TransmissionServices.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.TransmissionService> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("ServiceProvisionArea","serviceProvider",["RadioStation"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> ServiceProvisionAreas { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. ServiceProvisionAreas.Select(e => new featureBinding<DomainModel.S123.FeatureAssociations.ServiceProvisionArea> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public NAVAREAViewModel Load(NAVAREA instance) {
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
			var instance = new NAVAREA {
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
		public NAVAREA Model => new () {
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.NAVAREA.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.NAVAREA.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.NAVAREA.featureBindingDefinitions;

		public NAVAREAViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public NAVAREAViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"NAVAREA";

		public NAVAREAViewModel() : base() {
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
			ServiceProvisionAreas.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ServiceProvisionAreas));
			};
		}
	}



	/// <summary>
	/// A unique and precisely defined sea area, wholly contained within the NAVTEX coverage area, for which maritime safety information is provided from a particular NAVTEX transmitter.
	/// </summary>
	[Description("A unique and precisely defined sea area, wholly contained within the NAVTEX coverage area, for which maritime safety information is provided from a particular NAVTEX transmitter.")]
	[CategoryOrder("NAVTEXServiceArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NAVTEXServiceAreaViewModel : FeatureViewModel<NAVTEXServiceArea> {
		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("FeatureType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("Type of service of the NAVTEX, an international one or a national one.")]
		[Category("NAVTEXServiceArea")]
		//[Editor(typeof(Editors.HorizonEditor<NAVTEXServiceArea>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2])]
		[Mandatory]
		public typeOfNAVTEXService typeOfNAVTEXService {
			get {
				return _typeOfNAVTEXService;
			}
			set {
				SetValue(ref _typeOfNAVTEXService, value);
			}
		}

		private String _idNAVAREA  = string.Empty;

		[Description("The identifier for a NAVAREA.")]
		[Category("NAVTEXServiceArea")]
		//[Editor(typeof(Editors.HorizonEditor<NAVTEXServiceArea>), typeof(Editors.HorizonEditor))]
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

		[Description("The NAVTEX transmitter identification character is a single unique letter, which is allocated to each transmitter. It is used to identify the broadcasts, which are to be accepted by the receiver, those which are to be rejected, and the time slot for the transmission.")]
		[Category("NAVTEXServiceArea")]
		//[Editor(typeof(Editors.HorizonEditor<NAVTEXServiceArea>), typeof(Editors.HorizonEditor))]
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

		[Description("Identifier of membership of a particular nation.")]
		[Category("NAVTEXServiceArea")]
		//[Editor(typeof(Editors.HorizonEditor<NAVTEXServiceArea>), typeof(Editors.HorizonEditor))]
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

		[Description("The condition of an object at a given instant in time.")]
		[Category("NAVTEXServiceArea")]
		//[Editor(typeof(Editors.HorizonEditor<NAVTEXServiceArea>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,4,7])]
		[Optional]
		public status? status {
			get {
				return _status;
			}
			set {
				SetValue(ref _status, value);
			}
		}


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("ServiceCoordination","coordinatingAuthority",["Authority"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ServiceCoordinations { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("ServiceContact","theContactDetails",["ContactDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ServiceContacts { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","theServiceHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("BroadcastService","theBroadcastDetails",["BroadcastDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> BroadcastServices { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("TransmissionService","theTransmissionDetails",["TransmissionDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> TransmissionServices { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. ServiceCoordinations.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.ServiceCoordination> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. ServiceContacts.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.ServiceContact> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. LocationHours.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. BroadcastServices.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.BroadcastService> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. TransmissionServices.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.TransmissionService> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("ServiceProvisionArea","serviceProvider",["RadioStation"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> ServiceProvisionAreas { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. ServiceProvisionAreas.Select(e => new featureBinding<DomainModel.S123.FeatureAssociations.ServiceProvisionArea> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public NAVTEXServiceAreaViewModel Load(NAVTEXServiceArea instance) {
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
			var instance = new NAVTEXServiceArea {
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
		public NAVTEXServiceArea Model => new () {
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.NAVTEXServiceArea.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.NAVTEXServiceArea.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.NAVTEXServiceArea.featureBindingDefinitions;

		public NAVTEXServiceAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public NAVTEXServiceAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"NAVTEX Service Area";

		public NAVTEXServiceAreaViewModel() : base() {
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			ServiceProvisionAreas.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ServiceProvisionAreas));
			};
		}
	}



	/// <summary>
	/// The area where a radio service can be obtained and the characteristics of the radio transmission.
	/// </summary>
	[Description("The area where a radio service can be obtained and the characteristics of the radio transmission.")]
	[CategoryOrder("RadioServiceArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RadioServiceAreaViewModel : FeatureViewModel<RadioServiceArea> {
		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("FeatureType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A description of the languages, alphabets and scripts in use.")]
		[Category("RadioServiceArea")]
		//[Editor(typeof(Editors.HorizonEditor<RadioServiceArea>), typeof(Editors.HorizonEditor))]
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

		[Description("The maximum power the radio service uses (or is authorized to use) for radio transmission.")]
		[Category("RadioServiceArea")]
		//[Editor(typeof(Editors.HorizonEditor<RadioServiceArea>), typeof(Editors.HorizonEditor))]
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

		[Description("Describes whether a station transmits traffic lists.")]
		[Category("RadioServiceArea")]
		//[Editor(typeof(Editors.HorizonEditor<RadioServiceArea>), typeof(Editors.HorizonEditor))]
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

		[Description("The condition of an object at a given instant in time.")]
		[Category("RadioServiceArea")]
		//[Editor(typeof(Editors.HorizonEditor<RadioServiceArea>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,4,5,7,8,14,16,17])]
		[Optional]
		public status? status {
			get {
				return _status;
			}
			set {
				SetValue(ref _status, value);
			}
		}

		private String? _hoursOfWatch  = default;

		[Description("The hours during which the watch on the radio channel is maintained. Hours are given in UTC, such as 0930-1000, or by using a service symbol such as \"H24\" for a 24 hour service.")]
		[Category("RadioServiceArea")]
		//[Editor(typeof(Editors.HorizonEditor<RadioServiceArea>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationBindings")]
		[InformationBinding("ServiceCoordination","coordinatingAuthority",["Authority"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ServiceCoordinations { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("RadioServiceControl","theControlCentre",["RadioControlCentre"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> RadioServiceControls { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("ServiceContact","theContactDetails",["ContactDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ServiceContacts { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","theServiceHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("BroadcastService","theBroadcastDetails",["BroadcastDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> BroadcastServices { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("TransmissionService","theTransmissionDetails",["TransmissionDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> TransmissionServices { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. ServiceCoordinations.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.ServiceCoordination> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. RadioServiceControls.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.RadioServiceControl> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. ServiceContacts.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.ServiceContact> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. LocationHours.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. BroadcastServices.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.BroadcastService> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. TransmissionServices.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.TransmissionService> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("ServiceProvisionArea","serviceProvider",["RadioStation"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> ServiceProvisionAreas { get; set; } = new();

		[Category("FeatureBindings")]
		[FeatureBinding("coreAggregation","theCollection",["RadioServiceAreaAggregate"], lower:0, upper:1)]
		public ObservableCollection<FeatureRefViewModel> coreAggregations { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. ServiceProvisionAreas.Select(e => new featureBinding<DomainModel.S123.FeatureAssociations.ServiceProvisionArea> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. coreAggregations.Select(e => new featureBinding<DomainModel.S123.FeatureAssociations.coreAggregation> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.RadioServiceArea.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.RadioServiceArea.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.RadioServiceArea.featureBindingDefinitions;

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
	[Description("A place equipped to transmit radio waves. Such a station may be either stationary or mobile, and may also be provided with a radio receiver.")]
	[CategoryOrder("RadioStation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RadioStationViewModel : FeatureViewModel<RadioStation> {
		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("FeatureType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("Classification of radio services offered by a radio station.")]
		[Category("RadioStation")]
		//[Editor(typeof(Editors.HorizonEditor<RadioStation>), typeof(Editors.HorizonEditor))]
		[PermittedValues([5,9,10,19,20])]
		[Optional]
		public categoryOfRadioStation? categoryOfRadioStation {
			get {
				return _categoryOfRadioStation;
			}
			set {
				SetValue(ref _categoryOfRadioStation, value);
			}
		}

		private double? _estimatedRangeOfTransmission  = default;

		[Description("The estimated range of a non-optical electromagnetic transmission.")]
		[Category("RadioStation")]
		//[Editor(typeof(Editors.HorizonEditor<RadioStation>), typeof(Editors.HorizonEditor))]
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

		[Description("Content of transmission.")]
		[Category("RadioStation")]
		//[Editor(typeof(Editors.HorizonEditor<RadioStation>), typeof(Editors.HorizonEditor))]
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

		[Description("A statement that expresses if it is remote controlled.")]
		[Category("RadioStation")]
		//[Editor(typeof(Editors.HorizonEditor<RadioStation>), typeof(Editors.HorizonEditor))]
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

		[Description("The condition of an object at a given instant in time.")]
		[Category("RadioStation")]
		//[Editor(typeof(Editors.HorizonEditor<RadioStation>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,4,5,7,8,16,17])]
		[Optional]
		public status? status {
			get {
				return _status;
			}
			set {
				SetValue(ref _status, value);
			}
		}

		private radiocommunicationIdentifierViewModel? _radiocommunicationIdentifier  = default;

		[Description("Identifiers of the radio station in various maritime radiocommunication services.")]
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

		[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference. The sector limit specifies the limits of the sector In a clockwise direction around the central feature (for example a light).")]
		[Category("RadioStation")]
		[Optional]
		public ObservableCollection<sectorLimitViewModel> sectorLimit  { get; set; } = new ();

		private String? _hoursOfWatch  = default;

		[Description("The hours during which the watch on the radio channel is maintained. Hours are given in UTC, such as 0930-1000, or by using a service symbol such as \"H24\" for a 24 hour service.")]
		[Category("RadioStation")]
		//[Editor(typeof(Editors.HorizonEditor<RadioStation>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationBindings")]
		[InformationBinding("ServiceCoordination","coordinatingAuthority",["Authority"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ServiceCoordinations { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("RadioServiceControl","theControlCentre",["RadioControlCentre"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> RadioServiceControls { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("ServiceContact","theContactDetails",["ContactDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ServiceContacts { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","theServiceHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("BroadcastService","theBroadcastDetails",["BroadcastDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> BroadcastServices { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("TransmissionService","theTransmissionDetails",["TransmissionDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> TransmissionServices { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. ServiceCoordinations.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.ServiceCoordination> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. RadioServiceControls.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.RadioServiceControl> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. ServiceContacts.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.ServiceContact> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. LocationHours.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. BroadcastServices.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.BroadcastService> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. TransmissionServices.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.TransmissionService> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("ServiceProvisionArea","serviceArea",["ConnectivitySubscriptionArea","GMDSSArea","METAREA","NAVAREA","NAVTEXServiceArea","RadioServiceArea","WeatherForecastAndWarningArea"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> ServiceProvisionAreas { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. ServiceProvisionAreas.Select(e => new featureBinding<DomainModel.S123.FeatureAssociations.ServiceProvisionArea> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.RadioStation.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.RadioStation.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.RadioStation.featureBindingDefinitions;

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
			ServiceProvisionAreas.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ServiceProvisionAreas));
			};
		}
	}



	/// <summary>
	/// A defined geographical area where a specific country or organization is designated to coordinate and provide search and rescue services.
	/// </summary>
	[Description("A defined geographical area where a specific country or organization is designated to coordinate and provide search and rescue services.")]
	[CategoryOrder("SearchAndRescueRegion",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SearchAndRescueRegionViewModel : FeatureViewModel<SearchAndRescueRegion> {
		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("FeatureType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("Identifier of membership of a particular nation.")]
		[Category("SearchAndRescueRegion")]
		//[Editor(typeof(Editors.HorizonEditor<SearchAndRescueRegion>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationBindings")]
		[InformationBinding("ServiceCoordination","coordinatingAuthority",["Authority"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ServiceCoordinations { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("RadioServiceControl","theControlCentre",["RadioControlCentre"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> RadioServiceControls { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("TMAS","theTMAS",["TelemedicalAssistanceService"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> TMAS { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("ServiceContact","theContactDetails",["ContactDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ServiceContacts { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. ServiceCoordinations.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.ServiceCoordination> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. RadioServiceControls.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.RadioServiceControl> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. TMAS.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.TMAS> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. ServiceContacts.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.ServiceContact> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		public override featureBinding[] GetFeatureBindings() => [];

		public SearchAndRescueRegionViewModel Load(SearchAndRescueRegion instance) {
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
			var instance = new SearchAndRescueRegion {
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
		public SearchAndRescueRegion Model => new () {
			textContent = this.textContent.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			source = this._source,
			reportedDate = this._reportedDate,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			nationality = this._nationality,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SearchAndRescueRegion.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.SearchAndRescueRegion.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.SearchAndRescueRegion.featureBindingDefinitions;

		public SearchAndRescueRegionViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public SearchAndRescueRegionViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Search and Rescue Region";

		public SearchAndRescueRegionViewModel() : base() {
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
		}
	}



	/// <summary>
	/// An area for which weather forecasts and warnings are provided for specified periods.
	/// </summary>
	[Description("An area for which weather forecasts and warnings are provided for specified periods.")]
	[CategoryOrder("WeatherForecastAndWarningArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class WeatherForecastAndWarningAreaViewModel : FeatureViewModel<WeatherForecastAndWarningArea> {
		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("FeatureType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("Classification of weather forecast and weather warning areas based on source of warnings and forecasts.")]
		[Category("WeatherForecastAndWarningArea")]
		//[Editor(typeof(Editors.HorizonEditor<WeatherForecastAndWarningArea>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7])]
		[Mandatory]
		public categoryOfForecastOrWarningArea categoryOfForecastOrWarningArea {
			get {
				return _categoryOfForecastOrWarningArea;
			}
			set {
				SetValue(ref _categoryOfForecastOrWarningArea, value);
			}
		}

		private String? _idMETAREA  = default;

		[Description("The identifier for a METAREA.")]
		[Category("WeatherForecastAndWarningArea")]
		//[Editor(typeof(Editors.HorizonEditor<WeatherForecastAndWarningArea>), typeof(Editors.HorizonEditor))]
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

		[Description("Identifier of membership of a particular nation.")]
		[Category("WeatherForecastAndWarningArea")]
		//[Editor(typeof(Editors.HorizonEditor<WeatherForecastAndWarningArea>), typeof(Editors.HorizonEditor))]
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

		[Description("The condition of an object at a given instant in time.")]
		[Category("WeatherForecastAndWarningArea")]
		//[Editor(typeof(Editors.HorizonEditor<WeatherForecastAndWarningArea>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,4,5,7,8,14])]
		[Optional]
		public status? status {
			get {
				return _status;
			}
			set {
				SetValue(ref _status, value);
			}
		}


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("ServiceCoordination","coordinatingAuthority",["Authority"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ServiceCoordinations { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("ServiceContact","theContactDetails",["ContactDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ServiceContacts { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","theServiceHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("BroadcastService","theBroadcastDetails",["BroadcastDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> BroadcastServices { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("TransmissionService","theTransmissionDetails",["TransmissionDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> TransmissionServices { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. ServiceCoordinations.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.ServiceCoordination> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. ServiceContacts.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.ServiceContact> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. LocationHours.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. BroadcastServices.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.BroadcastService> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. TransmissionServices.Select(e => new informationBinding<DomainModel.S123.InformationAssociations.TransmissionService> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("ServiceProvisionArea","serviceProvider",["RadioStation"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> ServiceProvisionAreas { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. ServiceProvisionAreas.Select(e => new featureBinding<DomainModel.S123.FeatureAssociations.ServiceProvisionArea> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.WeatherForecastAndWarningArea.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.WeatherForecastAndWarningArea.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.WeatherForecastAndWarningArea.featureBindingDefinitions;

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
			ServiceProvisionAreas.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ServiceProvisionAreas));
			};
		}
	}



	/// <summary>
	/// Aggregation of areas where radio services from a single radio service are available to different levels of reliability.
	/// </summary>
	[Description("Aggregation of areas where radio services from a single radio service are available to different levels of reliability.")]
	[CategoryOrder("RadioServiceAreaAggregate",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RadioServiceAreaAggregateViewModel : FeatureViewModel<RadioServiceAreaAggregate> {
		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[Category("FeatureType")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}




		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("coreAggregation","theComponent",["RadioServiceArea"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> coreAggregations { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. coreAggregations.Select(e => new featureBinding<DomainModel.S123.FeatureAssociations.coreAggregation> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.RadioServiceAreaAggregate.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.RadioServiceAreaAggregate.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.RadioServiceAreaAggregate.featureBindingDefinitions;

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
	[Description("A geographical area that describes the coverage and extent of spatial objects.")]
	[CategoryOrder("DataCoverage",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DataCoverageViewModel : FeatureViewModel<DataCoverage> {
		private int _maximumDisplayScale  = default;

		[Description("The value considered by the Data Producer to be the maximum (largest) scale at which the data is to be displayed before it can be considered to be \"grossly overscaled\".")]
		[Category("DataCoverage")]
		//[Editor(typeof(Editors.HorizonEditor<DataCoverage>), typeof(Editors.HorizonEditor))]
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

		[Description("The smallest intended viewing scale for the data.")]
		[Category("DataCoverage")]
		//[Editor(typeof(Editors.HorizonEditor<DataCoverage>), typeof(Editors.HorizonEditor))]
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

		[Description("The largest intended viewing scale for the data.")]
		[Category("DataCoverage")]
		//[Editor(typeof(Editors.HorizonEditor<DataCoverage>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? optimumDisplayScale {
			get {
				return _optimumDisplayScale;
			}
			set {
				SetValue(ref _optimumDisplayScale, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("DataCoverage")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.DataCoverage.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.DataCoverage.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.DataCoverage.featureBindingDefinitions;

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
	[Description("An area within which a uniform assessment of the quality of the non-bathymetric data exists.")]
	[CategoryOrder("QualityOfNonBathymetricData",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class QualityOfNonBathymetricDataViewModel : FeatureViewModel<QualityOfNonBathymetricData> {
		private categoryOfTemporalVariation? _categoryOfTemporalVariation  = default;

		[Description("An assessment of the likelihood of change over time.")]
		[Category("QualityOfNonBathymetricData")]
		//[Editor(typeof(Editors.HorizonEditor<QualityOfNonBathymetricData>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,4,5])]
		[Optional]
		public categoryOfTemporalVariation? categoryOfTemporalVariation {
			get {
				return _categoryOfTemporalVariation;
			}
			set {
				SetValue(ref _categoryOfTemporalVariation, value);
			}
		}

		private double? _horizontalDistanceUncertainty  = default;

		[Description("The best estimate of the horizontal accuracy of horizontal clearances and distances.")]
		[Category("QualityOfNonBathymetricData")]
		//[Editor(typeof(Editors.HorizonEditor<QualityOfNonBathymetricData>), typeof(Editors.HorizonEditor))]
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

		[Description("The best estimate of the accuracy of a position.")]
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

		[Description("The best estimate of the accuracy of a bearing.")]
		[Category("QualityOfNonBathymetricData")]
		//[Editor(typeof(Editors.HorizonEditor<QualityOfNonBathymetricData>), typeof(Editors.HorizonEditor))]
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

		[Description("The complex attribute describes the period of the hydrographic survey, as the time between its sub-attributes.")]
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

		[Description("The best estimate of the vertical accuracy of depths, heights, vertical distances and vertical clearances.")]
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

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("QualityOfNonBathymetricData")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.QualityOfNonBathymetricData.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.QualityOfNonBathymetricData.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.QualityOfNonBathymetricData.featureBindingDefinitions;

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
					instance.InclusionTypes.Add(new InformationRefViewModel {
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
					instance.AuthorityContacts.Add(new InformationRefViewModel {
						informationId = authorityContact.referenceId,
						informationType = authorityContact.informationType,
						role = authorityContact.role,
					});
				}
				if(informationBinding is informationBinding<AuthorityHours> authorityHours) {
					instance.AuthorityHours.Add(new InformationRefViewModel {
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
					instance.BroadcastTransmissions.Add(new InformationRefViewModel {
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
					instance.AuthorityContacts.Add(new InformationRefViewModel {
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
					instance.ExceptionalWorkdays.Add(new InformationRefViewModel {
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
					instance.AuthorityContacts.Add(new InformationRefViewModel {
						informationId = authorityContact.referenceId,
						informationType = authorityContact.informationType,
						role = authorityContact.role,
					});
				}
				if(informationBinding is informationBinding<AuthorityHours> authorityHours) {
					instance.AuthorityHours.Add(new InformationRefViewModel {
						informationId = authorityHours.referenceId,
						informationType = authorityHours.informationType,
						role = authorityHours.role,
					});
				}
				if(informationBinding is informationBinding<TMAS> tMAS) {
					instance.TMAS.Add(new InformationRefViewModel {
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
					instance.AuthorityHours.Add(new InformationRefViewModel {
						informationId = authorityHours.referenceId,
						informationType = authorityHours.informationType,
						role = authorityHours.role,
					});
				}
				if(informationBinding is informationBinding<ExceptionalWorkday> exceptionalWorkday) {
					instance.ExceptionalWorkdays.Add(new InformationRefViewModel {
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
					instance.RadioServiceControls.Add(new InformationRefViewModel {
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
					instance.BroadcastTransmissions.Add(new InformationRefViewModel {
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
					instance.ConnectivityServices.Add(new InformationRefViewModel {
						informationId = connectivityService.referenceId,
						informationType = connectivityService.informationType,
						role = connectivityService.role,
					});
				}
				if(informationBinding is informationBinding<ServiceContact> serviceContact) {
					instance.ServiceContacts.Add(new InformationRefViewModel {
						informationId = serviceContact.referenceId,
						informationType = serviceContact.informationType,
						role = serviceContact.role,
					});
				}
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new InformationRefViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
				if(informationBinding is informationBinding<AvailableQoS> availableQoS) {
					instance.AvailableQoS.Add(new InformationRefViewModel {
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
					instance.ServiceCoordinations.Add(new InformationRefViewModel {
						informationId = serviceCoordination.referenceId,
						informationType = serviceCoordination.informationType,
						role = serviceCoordination.role,
					});
				}
				if(informationBinding is informationBinding<RadioServiceControl> radioServiceControl) {
					instance.RadioServiceControls.Add(new InformationRefViewModel {
						informationId = radioServiceControl.referenceId,
						informationType = radioServiceControl.informationType,
						role = radioServiceControl.role,
					});
				}
				if(informationBinding is informationBinding<ServiceContact> serviceContact) {
					instance.ServiceContacts.Add(new InformationRefViewModel {
						informationId = serviceContact.referenceId,
						informationType = serviceContact.informationType,
						role = serviceContact.role,
					});
				}
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new InformationRefViewModel {
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

		public static METAREAViewModel LoadInformationBinding(this METAREAViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceCoordination> serviceCoordination) {
					instance.ServiceCoordinations.Add(new InformationRefViewModel {
						informationId = serviceCoordination.referenceId,
						informationType = serviceCoordination.informationType,
						role = serviceCoordination.role,
					});
				}
				if(informationBinding is informationBinding<ServiceContact> serviceContact) {
					instance.ServiceContacts.Add(new InformationRefViewModel {
						informationId = serviceContact.referenceId,
						informationType = serviceContact.informationType,
						role = serviceContact.role,
					});
				}
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new InformationRefViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
				if(informationBinding is informationBinding<BroadcastService> broadcastService) {
					instance.BroadcastServices.Add(new InformationRefViewModel {
						informationId = broadcastService.referenceId,
						informationType = broadcastService.informationType,
						role = broadcastService.role,
					});
				}
				if(informationBinding is informationBinding<TransmissionService> transmissionService) {
					instance.TransmissionServices.Add(new InformationRefViewModel {
						informationId = transmissionService.referenceId,
						informationType = transmissionService.informationType,
						role = transmissionService.role,
					});
				}
			}
			return instance;
		}

		public static NAVAREAViewModel LoadInformationBinding(this NAVAREAViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceCoordination> serviceCoordination) {
					instance.ServiceCoordinations.Add(new InformationRefViewModel {
						informationId = serviceCoordination.referenceId,
						informationType = serviceCoordination.informationType,
						role = serviceCoordination.role,
					});
				}
				if(informationBinding is informationBinding<ServiceContact> serviceContact) {
					instance.ServiceContacts.Add(new InformationRefViewModel {
						informationId = serviceContact.referenceId,
						informationType = serviceContact.informationType,
						role = serviceContact.role,
					});
				}
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new InformationRefViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
				if(informationBinding is informationBinding<BroadcastService> broadcastService) {
					instance.BroadcastServices.Add(new InformationRefViewModel {
						informationId = broadcastService.referenceId,
						informationType = broadcastService.informationType,
						role = broadcastService.role,
					});
				}
				if(informationBinding is informationBinding<TransmissionService> transmissionService) {
					instance.TransmissionServices.Add(new InformationRefViewModel {
						informationId = transmissionService.referenceId,
						informationType = transmissionService.informationType,
						role = transmissionService.role,
					});
				}
			}
			return instance;
		}

		public static NAVTEXServiceAreaViewModel LoadInformationBinding(this NAVTEXServiceAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceCoordination> serviceCoordination) {
					instance.ServiceCoordinations.Add(new InformationRefViewModel {
						informationId = serviceCoordination.referenceId,
						informationType = serviceCoordination.informationType,
						role = serviceCoordination.role,
					});
				}
				if(informationBinding is informationBinding<ServiceContact> serviceContact) {
					instance.ServiceContacts.Add(new InformationRefViewModel {
						informationId = serviceContact.referenceId,
						informationType = serviceContact.informationType,
						role = serviceContact.role,
					});
				}
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new InformationRefViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
				if(informationBinding is informationBinding<BroadcastService> broadcastService) {
					instance.BroadcastServices.Add(new InformationRefViewModel {
						informationId = broadcastService.referenceId,
						informationType = broadcastService.informationType,
						role = broadcastService.role,
					});
				}
				if(informationBinding is informationBinding<TransmissionService> transmissionService) {
					instance.TransmissionServices.Add(new InformationRefViewModel {
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
					instance.ServiceCoordinations.Add(new InformationRefViewModel {
						informationId = serviceCoordination.referenceId,
						informationType = serviceCoordination.informationType,
						role = serviceCoordination.role,
					});
				}
				if(informationBinding is informationBinding<RadioServiceControl> radioServiceControl) {
					instance.RadioServiceControls.Add(new InformationRefViewModel {
						informationId = radioServiceControl.referenceId,
						informationType = radioServiceControl.informationType,
						role = radioServiceControl.role,
					});
				}
				if(informationBinding is informationBinding<ServiceContact> serviceContact) {
					instance.ServiceContacts.Add(new InformationRefViewModel {
						informationId = serviceContact.referenceId,
						informationType = serviceContact.informationType,
						role = serviceContact.role,
					});
				}
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new InformationRefViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
				if(informationBinding is informationBinding<BroadcastService> broadcastService) {
					instance.BroadcastServices.Add(new InformationRefViewModel {
						informationId = broadcastService.referenceId,
						informationType = broadcastService.informationType,
						role = broadcastService.role,
					});
				}
				if(informationBinding is informationBinding<TransmissionService> transmissionService) {
					instance.TransmissionServices.Add(new InformationRefViewModel {
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
					instance.ServiceCoordinations.Add(new InformationRefViewModel {
						informationId = serviceCoordination.referenceId,
						informationType = serviceCoordination.informationType,
						role = serviceCoordination.role,
					});
				}
				if(informationBinding is informationBinding<RadioServiceControl> radioServiceControl) {
					instance.RadioServiceControls.Add(new InformationRefViewModel {
						informationId = radioServiceControl.referenceId,
						informationType = radioServiceControl.informationType,
						role = radioServiceControl.role,
					});
				}
				if(informationBinding is informationBinding<ServiceContact> serviceContact) {
					instance.ServiceContacts.Add(new InformationRefViewModel {
						informationId = serviceContact.referenceId,
						informationType = serviceContact.informationType,
						role = serviceContact.role,
					});
				}
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new InformationRefViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
				if(informationBinding is informationBinding<BroadcastService> broadcastService) {
					instance.BroadcastServices.Add(new InformationRefViewModel {
						informationId = broadcastService.referenceId,
						informationType = broadcastService.informationType,
						role = broadcastService.role,
					});
				}
				if(informationBinding is informationBinding<TransmissionService> transmissionService) {
					instance.TransmissionServices.Add(new InformationRefViewModel {
						informationId = transmissionService.referenceId,
						informationType = transmissionService.informationType,
						role = transmissionService.role,
					});
				}
			}
			return instance;
		}

		public static SearchAndRescueRegionViewModel LoadInformationBinding(this SearchAndRescueRegionViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceCoordination> serviceCoordination) {
					instance.ServiceCoordinations.Add(new InformationRefViewModel {
						informationId = serviceCoordination.referenceId,
						informationType = serviceCoordination.informationType,
						role = serviceCoordination.role,
					});
				}
				if(informationBinding is informationBinding<RadioServiceControl> radioServiceControl) {
					instance.RadioServiceControls.Add(new InformationRefViewModel {
						informationId = radioServiceControl.referenceId,
						informationType = radioServiceControl.informationType,
						role = radioServiceControl.role,
					});
				}
				if(informationBinding is informationBinding<TMAS> tMAS) {
					instance.TMAS.Add(new InformationRefViewModel {
						informationId = tMAS.referenceId,
						informationType = tMAS.informationType,
						role = tMAS.role,
					});
				}
				if(informationBinding is informationBinding<ServiceContact> serviceContact) {
					instance.ServiceContacts.Add(new InformationRefViewModel {
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
					instance.ServiceCoordinations.Add(new InformationRefViewModel {
						informationId = serviceCoordination.referenceId,
						informationType = serviceCoordination.informationType,
						role = serviceCoordination.role,
					});
				}
				if(informationBinding is informationBinding<ServiceContact> serviceContact) {
					instance.ServiceContacts.Add(new InformationRefViewModel {
						informationId = serviceContact.referenceId,
						informationType = serviceContact.informationType,
						role = serviceContact.role,
					});
				}
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new InformationRefViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
				if(informationBinding is informationBinding<BroadcastService> broadcastService) {
					instance.BroadcastServices.Add(new InformationRefViewModel {
						informationId = broadcastService.referenceId,
						informationType = broadcastService.informationType,
						role = broadcastService.role,
					});
				}
				if(informationBinding is informationBinding<TransmissionService> transmissionService) {
					instance.TransmissionServices.Add(new InformationRefViewModel {
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
					instance.ServiceProvisionAreas.Add(new FeatureRefViewModel {
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
					instance.ServiceProvisionAreas.Add(new FeatureRefViewModel {
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
					instance.fuzzyZoneAggregations.Add(new FeatureRefViewModel {
						featureId = fuzzyZoneAggregation.referenceId,
						featureType = fuzzyZoneAggregation.featureType,
						role = fuzzyZoneAggregation.role,
					});
				}
			}
			return instance;
		}

		public static METAREAViewModel LoadFeatureBinding(this METAREAViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<ServiceProvisionArea> serviceProvisionArea) {
					instance.ServiceProvisionAreas.Add(new FeatureRefViewModel {
						featureId = serviceProvisionArea.referenceId,
						featureType = serviceProvisionArea.featureType,
						role = serviceProvisionArea.role,
					});
				}
			}
			return instance;
		}

		public static NAVAREAViewModel LoadFeatureBinding(this NAVAREAViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<ServiceProvisionArea> serviceProvisionArea) {
					instance.ServiceProvisionAreas.Add(new FeatureRefViewModel {
						featureId = serviceProvisionArea.referenceId,
						featureType = serviceProvisionArea.featureType,
						role = serviceProvisionArea.role,
					});
				}
			}
			return instance;
		}

		public static NAVTEXServiceAreaViewModel LoadFeatureBinding(this NAVTEXServiceAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<ServiceProvisionArea> serviceProvisionArea) {
					instance.ServiceProvisionAreas.Add(new FeatureRefViewModel {
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
					instance.ServiceProvisionAreas.Add(new FeatureRefViewModel {
						featureId = serviceProvisionArea.referenceId,
						featureType = serviceProvisionArea.featureType,
						role = serviceProvisionArea.role,
					});
				}
				if(featureBinding is featureBinding<coreAggregation> coreAggregation) {
					instance.coreAggregations.Add(new FeatureRefViewModel {
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
					instance.ServiceProvisionAreas.Add(new FeatureRefViewModel {
						featureId = serviceProvisionArea.referenceId,
						featureType = serviceProvisionArea.featureType,
						role = serviceProvisionArea.role,
					});
				}
			}
			return instance;
		}

		public static SearchAndRescueRegionViewModel LoadFeatureBinding(this SearchAndRescueRegionViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static WeatherForecastAndWarningAreaViewModel LoadFeatureBinding(this WeatherForecastAndWarningAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<ServiceProvisionArea> serviceProvisionArea) {
					instance.ServiceProvisionAreas.Add(new FeatureRefViewModel {
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
					instance.coreAggregations.Add(new FeatureRefViewModel {
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
