using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Reflection;
using System.ComponentModel;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S124;
using S100Framework.DomainModel.S124.ComplexAttributes;
using S100Framework.DomainModel.S124.InformationTypes;
using S100Framework.DomainModel.S124.FeatureTypes;
using S100Framework.DomainModel.S124.InformationAssociations;
using S100Framework.DomainModel.S124.FeatureAssociations;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.WPF.ViewModel.S124 {
	internal static class Bootstrap {
		public static AssociationViewModel CreateInformationAssociation(string type, string? name = default) => type switch {
			"navwarnPreambleContent" => new navwarnPreambleContentViewModel { Name = name },
			"navwarnReferences" => new navwarnReferencesViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static AssociationViewModel CreateFeatureAssociation(string type, string? name = default) => type switch {
			"TextAssociation" => new TextAssociationViewModel { Name = name },
			"areaAffected" => new areaAffectedViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static InformationViewModel CreateInformationType(string type, string? name = default) => type switch {
			"References" => new ReferencesViewModel { Name = name },
			"NavwarnPreamble" => new NavwarnPreambleViewModel { Name = name },
			"SpatialQuality" => new SpatialQualityViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static FeatureViewModel CreateFeatureType(string type, string? name = default) => type switch {
			"NavwarnPart" => new NavwarnPartViewModel { Name = name },
			"NavwarnAreaAffected" => new NavwarnAreaAffectedViewModel { Name = name },
			"TextPlacement" => new TextPlacementViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static ICollection<string> InformationAssociationBindings(string association, string role) => (association, role) switch {
			("navwarnReferences", "theWarning") => ["NavwarnPreamble"],
			("navwarnReferences", "theReferences") => ["References"],
			("navwarnPreambleContent", "header") => ["NavwarnPreamble"],
			_ => throw new InvalidOperationException(),
		};

		public static ICollection<string> FeatureAssociationBindings(string association, string role) => (association, role) switch {
			("areaAffected", "affects") => ["NavwarnAreaAffected"],
			("TextAssociation", "thePositionProvider") => ["TextPlacement"],
			("areaAffected", "impacts") => ["NavwarnPart"],
			("TextAssociation", "theCartographicText") => ["NavwarnPart"],
			_ => throw new InvalidOperationException(),
		};
	}

	/// <summary>
	/// Identifies paper charts, ENCs or publications that are affected by the information.
	/// </summary>
	[CategoryOrder("affectedChartPublications",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class affectedChartPublicationsViewModel : ViewModelBase {
		private chartAffectedViewModel? _chartAffected  = default;

		[Category("affectedChartPublications")]
		[ExpandableObject]
		public chartAffectedViewModel? chartAffected {
			get {
				return _chartAffected;
			}
			set {
				SetValue(ref _chartAffected, value);
			}
		}
		private String? _chartPublicationIdentifier  = default;

		public String? chartPublicationIdentifier {
			get {
				return _chartPublicationIdentifier;
			}
			set {
				SetValue(ref _chartPublicationIdentifier, value);
			}
		}
		private String? _internationalChartAffected  = default;

		public String? internationalChartAffected {
			get {
				return _internationalChartAffected;
			}
			set {
				SetValue(ref _internationalChartAffected, value);
			}
		}
		private String _language  = string.Empty;

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}
		private String? _publicationAffected  = default;

		public String? publicationAffected {
			get {
				return _publicationAffected;
			}
			set {
				SetValue(ref _publicationAffected, value);
			}
		}


		public affectedChartPublicationsViewModel Load(affectedChartPublications instance) {
			chartAffected = new ();
			if (instance.chartAffected != default) {
				chartAffected.Load(instance.chartAffected);
			}
			chartPublicationIdentifier = instance.chartPublicationIdentifier;
			internationalChartAffected = instance.internationalChartAffected;
			language = instance.language;
			publicationAffected = instance.publicationAffected;
			return this;
		}

		public override string Serialize() {
			var instance = new affectedChartPublications {
				chartAffected = this.chartAffected?.Model,
				chartPublicationIdentifier = this.chartPublicationIdentifier,
				internationalChartAffected = this.internationalChartAffected,
				language = this.language,
				publicationAffected = this.publicationAffected,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public affectedChartPublications Model => new () {
			chartAffected = this._chartAffected?.Model,
			chartPublicationIdentifier = this._chartPublicationIdentifier,
			internationalChartAffected = this._internationalChartAffected,
			language = this._language,
			publicationAffected = this._publicationAffected,
		};

		public override string? ToString() => $"Affected Chart Publications";
	}
	/// <summary>
	/// Name or number of affected national paper chart or ENC.
	/// </summary>
	[CategoryOrder("chartAffected",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class chartAffectedViewModel : ViewModelBase {
		private String _chartNumber  = string.Empty;

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String chartNumber {
			get {
				return _chartNumber;
			}
			set {
				SetValue(ref _chartNumber, value);
			}
		}
		private String? _chartPlanNumber  = default;

		public String? chartPlanNumber {
			get {
				return _chartPlanNumber;
			}
			set {
				SetValue(ref _chartPlanNumber, value);
			}
		}
		private DateOnly _editionDate  = default;

		[Editor(typeof(Editors.UnknownEditor<DateOnly?>), typeof(Editors.UnknownEditor<DateOnly?>))]
		public DateOnly editionDate {
			get {
				return _editionDate;
			}
			set {
				SetValue(ref _editionDate, value);
			}
		}
		private DateOnly? _lastNoticeDate  = default;

		public DateOnly? lastNoticeDate {
			get {
				return _lastNoticeDate;
			}
			set {
				SetValue(ref _lastNoticeDate, value);
			}
		}


		public chartAffectedViewModel Load(chartAffected instance) {
			chartNumber = instance.chartNumber;
			chartPlanNumber = instance.chartPlanNumber;
			editionDate = instance.editionDate;
			lastNoticeDate = instance.lastNoticeDate;
			return this;
		}

		public override string Serialize() {
			var instance = new chartAffected {
				chartNumber = this.chartNumber,
				chartPlanNumber = this.chartPlanNumber,
				editionDate = this.editionDate,
				lastNoticeDate = this.lastNoticeDate,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public chartAffected Model => new () {
			chartNumber = this._chartNumber,
			chartPlanNumber = this._chartPlanNumber,
			editionDate = this._editionDate,
			lastNoticeDate = this._lastNoticeDate,
		};

		public override string? ToString() => $"Chart Affected";
	}
	/// <summary>
	/// An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.
	/// </summary>
	[CategoryOrder("fixedDateRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class fixedDateRangeViewModel : ViewModelBase {
		private String? _dateEnd  = default;

		[S100TruncatedDateAttribute]
		public String? dateEnd {
			get {
				return _dateEnd;
			}
			set {
				SetValue(ref _dateEnd, value);
			}
		}
		private String? _dateStart  = default;

		[S100TruncatedDateAttribute]
		public String? dateStart {
			get {
				return _dateStart;
			}
			set {
				SetValue(ref _dateStart, value);
			}
		}
		private TimeOnly? _timeOfDayEnd  = default;

		public TimeOnly? timeOfDayEnd {
			get {
				return _timeOfDayEnd;
			}
			set {
				SetValue(ref _timeOfDayEnd, value);
			}
		}
		private TimeOnly? _timeOfDayStart  = default;

		public TimeOnly? timeOfDayStart {
			get {
				return _timeOfDayStart;
			}
			set {
				SetValue(ref _timeOfDayStart, value);
			}
		}


		public fixedDateRangeViewModel Load(fixedDateRange instance) {
			dateEnd = instance.dateEnd;
			dateStart = instance.dateStart;
			timeOfDayEnd = instance.timeOfDayEnd;
			timeOfDayStart = instance.timeOfDayStart;
			return this;
		}

		public override string Serialize() {
			var instance = new fixedDateRange {
				dateEnd = this.dateEnd,
				dateStart = this.dateStart,
				timeOfDayEnd = this.timeOfDayEnd,
				timeOfDayStart = this.timeOfDayStart,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public fixedDateRange Model => new () {
			dateEnd = this._dateEnd,
			dateStart = this._dateStart,
			timeOfDayEnd = this._timeOfDayEnd,
			timeOfDayStart = this._timeOfDayStart,
		};

		public override string? ToString() => $"Fixed Date Range";
	}
	/// <summary>
	/// The general area used to identify which broad geographic region the message affects. The geographical name which is selected for the general area should be one that can be found on charts and in nautical publications. (S-53, 6).
	/// </summary>
	[CategoryOrder("generalArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class generalAreaViewModel : ViewModelBase {
		private String? _localityIdentifier  = default;

		public String? localityIdentifier {
			get {
				return _localityIdentifier;
			}
			set {
				SetValue(ref _localityIdentifier, value);
			}
		}
		[Category("generalArea")]
		public ObservableCollection<locationNameViewModel> locationName  { get; set; } = new ();


		public generalAreaViewModel Load(generalArea instance) {
			localityIdentifier = instance.localityIdentifier;
			locationName.Clear();
			if (instance.locationName is not null) {
				foreach(var e in instance.locationName)
					locationName.Add(new locationNameViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new generalArea {
				localityIdentifier = this.localityIdentifier,
				locationName = this.locationName.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public generalArea Model => new () {
			localityIdentifier = this._localityIdentifier,
			locationName = this.locationName.Select(e => e.Model).ToList(),
		};

		public override string? ToString() => $"General Area";

		public generalAreaViewModel() : base() {
			locationName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(locationName));
			};
		}
	}
	/// <summary>
	/// Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.
	/// </summary>
	[CategoryOrder("information",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class informationViewModel : ViewModelBase {
		private String _language  = string.Empty;

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}
		private String _text  = string.Empty;

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String text {
			get {
				return _text;
			}
			set {
				SetValue(ref _text, value);
			}
		}


		public informationViewModel Load(information instance) {
			language = instance.language;
			text = instance.text;
			return this;
		}

		public override string Serialize() {
			var instance = new information {
				language = this.language,
				text = this.text,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public information Model => new () {
			language = this._language,
			text = this._text,
		};

		public override string? ToString() => $"Information";
	}
	/// <summary>
	/// Name and/or identifier of an area locality.
	/// </summary>
	[CategoryOrder("locality",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class localityViewModel : ViewModelBase {
		private String? _localityIdentifier  = default;

		public String? localityIdentifier {
			get {
				return _localityIdentifier;
			}
			set {
				SetValue(ref _localityIdentifier, value);
			}
		}
		[Category("locality")]
		public ObservableCollection<locationNameViewModel> locationName  { get; set; } = new ();


		public localityViewModel Load(locality instance) {
			localityIdentifier = instance.localityIdentifier;
			locationName.Clear();
			if (instance.locationName is not null) {
				foreach(var e in instance.locationName)
					locationName.Add(new locationNameViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new locality {
				localityIdentifier = this.localityIdentifier,
				locationName = this.locationName.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public locality Model => new () {
			localityIdentifier = this._localityIdentifier,
			locationName = this.locationName.Select(e => e.Model).ToList(),
		};

		public override string? ToString() => $"Locality";

		public localityViewModel() : base() {
			locationName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(locationName));
			};
		}
	}
	/// <summary>
	/// Name of an area locality as defined by a competent authority.
	/// </summary>
	[CategoryOrder("locationName",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class locationNameViewModel : ViewModelBase {
		private String _language  = string.Empty;

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}
		private String _text  = string.Empty;

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String text {
			get {
				return _text;
			}
			set {
				SetValue(ref _text, value);
			}
		}


		public locationNameViewModel Load(locationName instance) {
			language = instance.language;
			text = instance.text;
			return this;
		}

		public override string Serialize() {
			var instance = new locationName {
				language = this.language,
				text = this.text,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public locationName Model => new () {
			language = this._language,
			text = this._text,
		};

		public override string? ToString() => $"Location Name";
	}
	/// <summary>
	/// Message series identification of the warning or notice.
	/// </summary>
	[CategoryOrder("messageSeriesIdentifier",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class messageSeriesIdentifierViewModel : ViewModelBase {
		private String _agencyResponsibleForProduction  = string.Empty;

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		private String? _interoperabilityIdentifier  = default;

		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private String _nameOfSeries  = string.Empty;

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String nameOfSeries {
			get {
				return _nameOfSeries;
			}
			set {
				SetValue(ref _nameOfSeries, value);
			}
		}
		private String? _nationality  = default;

		public String? nationality {
			get {
				return _nationality;
			}
			set {
				SetValue(ref _nationality, value);
			}
		}
		private int _warningNumber  = default;

		[Editor(typeof(Editors.UnknownEditor<int?>), typeof(Editors.UnknownEditor<int?>))]
		public int warningNumber {
			get {
				return _warningNumber;
			}
			set {
				SetValue(ref _warningNumber, value);
			}
		}
		private warningType _warningType  = default;

		[Editor(typeof(Editors.UnknownEditor<warningType?>), typeof(Editors.UnknownEditor<warningType?>))]
		[DomainModel.EnumerationAttribute(nameof(warningTypeList), typeof(warningType))]
		public warningType warningType {
			get {
				return _warningType;
			}
			set {
				SetValue(ref _warningType, value);
			}
		}

		[Browsable(false)]
		public warningType[] warningTypeList => [(warningType)1,(warningType)2,(warningType)3,(warningType)4,(warningType)5,(warningType)6,(warningType)7,(warningType)8,(warningType)9,(warningType)10,(warningType)11,(warningType)12];
		private int _year  = default;

		[Editor(typeof(Editors.UnknownEditor<int?>), typeof(Editors.UnknownEditor<int?>))]
		public int year {
			get {
				return _year;
			}
			set {
				SetValue(ref _year, value);
			}
		}


		public messageSeriesIdentifierViewModel Load(messageSeriesIdentifier instance) {
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			nameOfSeries = instance.nameOfSeries;
			nationality = instance.nationality;
			warningNumber = instance.warningNumber;
			warningType = instance.warningType;
			year = instance.year;
			return this;
		}

		public override string Serialize() {
			var instance = new messageSeriesIdentifier {
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				nameOfSeries = this.nameOfSeries,
				nationality = this.nationality,
				warningNumber = this.warningNumber,
				warningType = this.warningType,
				year = this.year,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public messageSeriesIdentifier Model => new () {
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			nameOfSeries = this._nameOfSeries,
			nationality = this._nationality,
			warningNumber = this._warningNumber,
			warningType = this._warningType,
			year = this._year,
		};

		public override string? ToString() => $"Message Series Identifier";
	}
	/// <summary>
	/// Title of the navigational warning.
	/// </summary>
	[CategoryOrder("navwarnTitle",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class navwarnTitleViewModel : ViewModelBase {
		private String _language  = string.Empty;

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}
		private String _text  = string.Empty;

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String text {
			get {
				return _text;
			}
			set {
				SetValue(ref _text, value);
			}
		}


		public navwarnTitleViewModel Load(navwarnTitle instance) {
			language = instance.language;
			text = instance.text;
			return this;
		}

		public override string Serialize() {
			var instance = new navwarnTitle {
				language = this.language,
				text = this.text,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public navwarnTitle Model => new () {
			language = this._language,
			text = this._text,
		};

		public override string? ToString() => $"NAVWARN Title";
	}
	/// <summary>
	/// Detailed information about a warning.
	/// </summary>
	[CategoryOrder("warningInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class warningInformationViewModel : ViewModelBase {
		[Category("warningInformation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("warningInformation")]
		public ObservableCollection<navwarnTypeDetails> navwarnTypeDetails  { get; set; } = new ();


		public warningInformationViewModel Load(warningInformation instance) {
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			navwarnTypeDetails.Clear();
			if (instance.navwarnTypeDetails is not null) {
				foreach(var e in instance.navwarnTypeDetails)
					navwarnTypeDetails.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new warningInformation {
				information = this.information.Select(e => e.Model).ToList(),
				navwarnTypeDetails = this.navwarnTypeDetails.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public warningInformation Model => new () {
			information = this.information.Select(e => e.Model).ToList(),
			navwarnTypeDetails = this.navwarnTypeDetails.ToList(),
		};

		public override string? ToString() => $"Warning Information";

		public warningInformationViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			navwarnTypeDetails.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(navwarnTypeDetails));
			};
		}
	}
	/// <summary>
	/// Reference to an object or feature that is external to the dataset.
	/// </summary>
	[CategoryOrder("featureReference",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class featureReferenceViewModel : ViewModelBase {
		[Category("featureReference")]
		public ObservableCollection<String> atoNNumber  { get; set; } = new ();
		[Category("featureReference")]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();


		public featureReferenceViewModel Load(featureReference instance) {
			atoNNumber.Clear();
			if (instance.atoNNumber is not null) {
				foreach(var e in instance.atoNNumber)
					atoNNumber.Add(e);
			}
			interoperabilityIdentifier.Clear();
			if (instance.interoperabilityIdentifier is not null) {
				foreach(var e in instance.interoperabilityIdentifier)
					interoperabilityIdentifier.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new featureReference {
				atoNNumber = this.atoNNumber.ToList(),
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public featureReference Model => new () {
			atoNNumber = this.atoNNumber.ToList(),
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
		};

		public override string? ToString() => $"Feature Reference";

		public featureReferenceViewModel() : base() {
			atoNNumber.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(atoNNumber));
			};
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
			};
		}
	}
	/// <summary>
	/// Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.
	/// </summary>
	[CategoryOrder("featureName",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class featureNameViewModel : ViewModelBase {
		private String _language  = string.Empty;

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}
		private String _name  = string.Empty;

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String name {
			get {
				return _name;
			}
			set {
				SetValue(ref _name, value);
			}
		}
		private nameUsage? _nameUsage  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(nameUsageList), typeof(nameUsage))]
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
	/// The best estimate of the accuracy of a position.
	/// </summary>
	[CategoryOrder("horizontalPositionUncertainty",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class horizontalPositionUncertaintyViewModel : ViewModelBase {
		private decimal _uncertaintyFixed  = default;

		[Editor(typeof(Editors.UnknownEditor<decimal?>), typeof(Editors.UnknownEditor<decimal?>))]
		public decimal uncertaintyFixed {
			get {
				return _uncertaintyFixed;
			}
			set {
				SetValue(ref _uncertaintyFixed, value);
			}
		}


		public horizontalPositionUncertaintyViewModel Load(horizontalPositionUncertainty instance) {
			uncertaintyFixed = instance.uncertaintyFixed;
			return this;
		}

		public override string Serialize() {
			var instance = new horizontalPositionUncertainty {
				uncertaintyFixed = this.uncertaintyFixed,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public horizontalPositionUncertainty Model => new () {
			uncertaintyFixed = this._uncertaintyFixed,
		};

		public override string? ToString() => $"Horizontal Position Uncertainty";
	}
	/// <summary>
	/// Provides an indication of the vertical and horizontal positional uncertainty of bathymetric data, optionally within a specified date range.
	/// </summary>
	[CategoryOrder("spatialAccuracy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class spatialAccuracyViewModel : ViewModelBase {
		private horizontalPositionUncertaintyViewModel _horizontalPositionUncertainty  = default;

		[Category("spatialAccuracy")]
		[ExpandableObject]
		public horizontalPositionUncertaintyViewModel horizontalPositionUncertainty {
			get {
				return _horizontalPositionUncertainty;
			}
			set {
				SetValue(ref _horizontalPositionUncertainty, value);
			}
		}


		public spatialAccuracyViewModel Load(spatialAccuracy instance) {
			horizontalPositionUncertainty = new ();
			if (instance.horizontalPositionUncertainty != default) {
				horizontalPositionUncertainty.Load(instance.horizontalPositionUncertainty);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new spatialAccuracy {
				horizontalPositionUncertainty = this.horizontalPositionUncertainty?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public spatialAccuracy Model => new () {
			horizontalPositionUncertainty = this._horizontalPositionUncertainty?.Model,
		};

		public override string? ToString() => $"Spatial Accuracy";
	}

	/// <summary>
	/// The binding between a navigational warning preamble and the body.
	/// </summary>
	[CategoryOrder("navwarnPreambleContent",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class navwarnPreambleContentViewModel : AssociationViewModel {


		public navwarnPreambleContentViewModel Load(navwarnPreambleContent instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new navwarnPreambleContent {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public navwarnPreambleContent Model => new () {

		};

		public override string? ToString() => $"navwarnPreambleContent";
	}

	/// <summary>
	/// The relationship between a navigational warning and previous information relevant to its purpose.
	/// </summary>
	[CategoryOrder("navwarnReferences",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class navwarnReferencesViewModel : AssociationViewModel {


		public navwarnReferencesViewModel Load(navwarnReferences instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new navwarnReferences {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public navwarnReferences Model => new () {

		};

		public override string? ToString() => $"navwarnReferences";
	}

	/// <summary>
	/// a feature association for the binding between a geo feature and the cartographically positioned location for text.
	/// </summary>
	[CategoryOrder("TextAssociation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TextAssociationViewModel : AssociationViewModel {


		public TextAssociationViewModel Load(TextAssociation instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new TextAssociation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public TextAssociation Model => new () {

		};

		public override string? ToString() => $"Text association";
	}

	/// <summary>
	/// Association between a warning and the area impacted.
	/// </summary>
	[CategoryOrder("areaAffected",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class areaAffectedViewModel : AssociationViewModel {


		public areaAffectedViewModel Load(areaAffected instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new areaAffected {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public areaAffected Model => new () {

		};

		public override string? ToString() => $"Area Affected";
	}

	/// <summary>
	/// References to for example a navigational warning, nautical publication or chart.
	/// </summary>
	[CategoryOrder("References",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ReferencesViewModel : InformationViewModel<References> {
		[Category("References")]
		public ObservableCollection<messageSeriesIdentifierViewModel> messageSeriesIdentifier  { get; set; } = new ();
		private Boolean _noMessageOnHand  = false;

		[Category("References")]
		[Editor(typeof(Editors.UnknownEditor<Boolean?>), typeof(Editors.UnknownEditor<Boolean?>))]
		public Boolean noMessageOnHand {
			get {
				return _noMessageOnHand;
			}
			set {
				SetValue(ref _noMessageOnHand, value);
			}
		}
		private referenceCategory _referenceCategory  = default;

		[Category("References")]
		[Editor(typeof(Editors.UnknownEditor<referenceCategory?>), typeof(Editors.UnknownEditor<referenceCategory?>))]
		[DomainModel.EnumerationAttribute(nameof(referenceCategoryList), typeof(referenceCategory))]
		public referenceCategory referenceCategory {
			get {
				return _referenceCategory;
			}
			set {
				SetValue(ref _referenceCategory, value);
			}
		}

		[Browsable(false)]
		public referenceCategory[] referenceCategoryList => [(referenceCategory)1,(referenceCategory)2,(referenceCategory)3];


		public override InformationViewModel<References> Load(References instance) {
			messageSeriesIdentifier.Clear();
			if (instance.messageSeriesIdentifier is not null) {
				foreach(var e in instance.messageSeriesIdentifier)
					messageSeriesIdentifier.Add(new messageSeriesIdentifierViewModel().Load(e));
			}
			noMessageOnHand = instance.noMessageOnHand;
			referenceCategory = instance.referenceCategory;
			return this;
		}

		public override string Serialize() {
			var instance = new References {
				messageSeriesIdentifier = this.messageSeriesIdentifier.Select(e => e.Model).ToList(),
				noMessageOnHand = this.noMessageOnHand,
				referenceCategory = this.referenceCategory,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public References Model => new () {
			messageSeriesIdentifier = this.messageSeriesIdentifier.Select(e => e.Model).ToList(),
			noMessageOnHand = this._noMessageOnHand,
			referenceCategory = this._referenceCategory,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => References._informationBindingDefinitions;

		public override string? ToString() => $"References";

		public ReferencesViewModel() : base() {
			messageSeriesIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(messageSeriesIdentifier));
			};
		}
	}

	/// <summary>
	/// Preamble information for warnings, notices and other types of messages in a navigational warning scheme.
	/// </summary>
	[CategoryOrder("NavwarnPreamble",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NavwarnPreambleViewModel : InformationViewModel<NavwarnPreamble> {
		[Category("NavwarnPreamble")]
		public ObservableCollection<affectedChartPublicationsViewModel> affectedChartPublications  { get; set; } = new ();
		[Category("NavwarnPreamble")]
		public ObservableCollection<generalAreaViewModel> generalArea  { get; set; } = new ();
		[Category("NavwarnPreamble")]
		public ObservableCollection<localityViewModel> locality  { get; set; } = new ();
		private messageSeriesIdentifierViewModel _messageSeriesIdentifier  = default;

		[Category("NavwarnPreamble")]
		[ExpandableObject]
		public messageSeriesIdentifierViewModel messageSeriesIdentifier {
			get {
				return _messageSeriesIdentifier;
			}
			set {
				SetValue(ref _messageSeriesIdentifier, value);
			}
		}
		[Category("NavwarnPreamble")]
		public ObservableCollection<navwarnTitleViewModel> navwarnTitle  { get; set; } = new ();
		private DateTime? _cancellationDate  = default;

		[Category("NavwarnPreamble")]
		public DateTime? cancellationDate {
			get {
				return _cancellationDate;
			}
			set {
				SetValue(ref _cancellationDate, value);
			}
		}
		private Boolean _intService  = false;

		[Category("NavwarnPreamble")]
		[Editor(typeof(Editors.UnknownEditor<Boolean?>), typeof(Editors.UnknownEditor<Boolean?>))]
		public Boolean intService {
			get {
				return _intService;
			}
			set {
				SetValue(ref _intService, value);
			}
		}
		private navwarnTypeGeneral _navwarnTypeGeneral  = default;

		[Category("NavwarnPreamble")]
		[Editor(typeof(Editors.UnknownEditor<navwarnTypeGeneral?>), typeof(Editors.UnknownEditor<navwarnTypeGeneral?>))]
		public navwarnTypeGeneral navwarnTypeGeneral {
			get {
				return _navwarnTypeGeneral;
			}
			set {
				SetValue(ref _navwarnTypeGeneral, value);
			}
		}

		[Browsable(false)]
		public navwarnTypeGeneral[] navwarnTypeGeneralList =>  CodeList.navwarnTypeGenerals.ToArray();
		private DateTime _publicationTime  = default;

		[Category("NavwarnPreamble")]
		[Editor(typeof(Editors.UnknownEditor<DateTime?>), typeof(Editors.UnknownEditor<DateTime?>))]
		public DateTime publicationTime {
			get {
				return _publicationTime;
			}
			set {
				SetValue(ref _publicationTime, value);
			}
		}


		public override InformationViewModel<NavwarnPreamble> Load(NavwarnPreamble instance) {
			affectedChartPublications.Clear();
			if (instance.affectedChartPublications is not null) {
				foreach(var e in instance.affectedChartPublications)
					affectedChartPublications.Add(new affectedChartPublicationsViewModel().Load(e));
			}
			generalArea.Clear();
			if (instance.generalArea is not null) {
				foreach(var e in instance.generalArea)
					generalArea.Add(new generalAreaViewModel().Load(e));
			}
			locality.Clear();
			if (instance.locality is not null) {
				foreach(var e in instance.locality)
					locality.Add(new localityViewModel().Load(e));
			}
			messageSeriesIdentifier = new ();
			if (instance.messageSeriesIdentifier != default) {
				messageSeriesIdentifier.Load(instance.messageSeriesIdentifier);
			}
			navwarnTitle.Clear();
			if (instance.navwarnTitle is not null) {
				foreach(var e in instance.navwarnTitle)
					navwarnTitle.Add(new navwarnTitleViewModel().Load(e));
			}
			cancellationDate = instance.cancellationDate;
			intService = instance.intService;
			navwarnTypeGeneral = instance.navwarnTypeGeneral;
			publicationTime = instance.publicationTime;
			return this;
		}

		public override string Serialize() {
			var instance = new NavwarnPreamble {
				affectedChartPublications = this.affectedChartPublications.Select(e => e.Model).ToList(),
				generalArea = this.generalArea.Select(e => e.Model).ToList(),
				locality = this.locality.Select(e => e.Model).ToList(),
				messageSeriesIdentifier = this.messageSeriesIdentifier?.Model,
				navwarnTitle = this.navwarnTitle.Select(e => e.Model).ToList(),
				cancellationDate = this.cancellationDate,
				intService = this.intService,
				navwarnTypeGeneral = this.navwarnTypeGeneral,
				publicationTime = this.publicationTime,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public NavwarnPreamble Model => new () {
			affectedChartPublications = this.affectedChartPublications.Select(e => e.Model).ToList(),
			generalArea = this.generalArea.Select(e => e.Model).ToList(),
			locality = this.locality.Select(e => e.Model).ToList(),
			messageSeriesIdentifier = this._messageSeriesIdentifier?.Model,
			navwarnTitle = this.navwarnTitle.Select(e => e.Model).ToList(),
			cancellationDate = this._cancellationDate,
			intService = this._intService,
			navwarnTypeGeneral = this._navwarnTypeGeneral,
			publicationTime = this._publicationTime,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => NavwarnPreamble._informationBindingDefinitions;

		public override string? ToString() => $"NAVWARN Preamble";

		public NavwarnPreambleViewModel() : base() {
			affectedChartPublications.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(affectedChartPublications));
			};
			generalArea.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(generalArea));
			};
			locality.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(locality));
			};
			navwarnTitle.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(navwarnTitle));
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(qualityOfHorizontalMeasurementList), typeof(qualityOfHorizontalMeasurement))]
		public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement {
			get {
				return _qualityOfHorizontalMeasurement;
			}
			set {
				SetValue(ref _qualityOfHorizontalMeasurement, value);
			}
		}

		[Browsable(false)]
		public qualityOfHorizontalMeasurement[] qualityOfHorizontalMeasurementList => [(qualityOfHorizontalMeasurement)1,(qualityOfHorizontalMeasurement)2,(qualityOfHorizontalMeasurement)3,(qualityOfHorizontalMeasurement)4,(qualityOfHorizontalMeasurement)5,(qualityOfHorizontalMeasurement)6,(qualityOfHorizontalMeasurement)7,(qualityOfHorizontalMeasurement)8,(qualityOfHorizontalMeasurement)9,(qualityOfHorizontalMeasurement)10,(qualityOfHorizontalMeasurement)11];
		private spatialAccuracyViewModel? _spatialAccuracy  = default;

		[Category("SpatialQuality")]
		[ExpandableObject]
		public spatialAccuracyViewModel? spatialAccuracy {
			get {
				return _spatialAccuracy;
			}
			set {
				SetValue(ref _spatialAccuracy, value);
			}
		}


		public override InformationViewModel<SpatialQuality> Load(SpatialQuality instance) {
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

		public override string? ToString() => $"Spatial Quality";
	}

	/// <summary>
	/// Navigational warning information that may be geo-located.
	/// </summary>
	[CategoryOrder("NavwarnPart",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NavwarnPartViewModel : FeatureViewModel<NavwarnPart> {
		private restriction? _restriction  = default;

		[Category("NavwarnPart")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(restrictionList), typeof(restriction))]
		public restriction? restriction {
			get {
				return _restriction;
			}
			set {
				SetValue(ref _restriction, value);
			}
		}

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)7,(restriction)8,(restriction)14,(restriction)25,(restriction)27];
		[Category("NavwarnPart")]
		public ObservableCollection<fixedDateRangeViewModel> fixedDateRange  { get; set; } = new ();
		private warningInformationViewModel _warningInformation  = default;

		[Category("NavwarnPart")]
		[ExpandableObject]
		public warningInformationViewModel warningInformation {
			get {
				return _warningInformation;
			}
			set {
				SetValue(ref _warningInformation, value);
			}
		}
		[Category("NavwarnPart")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("NavwarnPart")]
		public ObservableCollection<featureReferenceViewModel> featureReference  { get; set; } = new ();


		public override FeatureViewModel<NavwarnPart> Load(NavwarnPart instance) {
			restriction = instance.restriction;
			fixedDateRange.Clear();
			if (instance.fixedDateRange is not null) {
				foreach(var e in instance.fixedDateRange)
					fixedDateRange.Add(new fixedDateRangeViewModel().Load(e));
			}
			warningInformation = new ();
			if (instance.warningInformation != default) {
				warningInformation.Load(instance.warningInformation);
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			featureReference.Clear();
			if (instance.featureReference is not null) {
				foreach(var e in instance.featureReference)
					featureReference.Add(new featureReferenceViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new NavwarnPart {
				restriction = this.restriction,
				fixedDateRange = this.fixedDateRange.Select(e => e.Model).ToList(),
				warningInformation = this.warningInformation?.Model,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				featureReference = this.featureReference.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public NavwarnPart Model => new () {
			restriction = this._restriction,
			fixedDateRange = this.fixedDateRange.Select(e => e.Model).ToList(),
			warningInformation = this._warningInformation?.Model,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			featureReference = this.featureReference.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => NavwarnPart._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. NavwarnPart._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => NavwarnPart._featureBindingDefinitions;

		public override string? ToString() => $"NAVWARN Part";

		public NavwarnPartViewModel() : base() {
			fixedDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(fixedDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			featureReference.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureReference));
			};
		}
	}

	/// <summary>
	/// An area affected by some event marked by a navigational warning.
	/// </summary>
	[CategoryOrder("NavwarnAreaAffected",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NavwarnAreaAffectedViewModel : FeatureViewModel<NavwarnAreaAffected> {


		public override FeatureViewModel<NavwarnAreaAffected> Load(NavwarnAreaAffected instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new NavwarnAreaAffected {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public NavwarnAreaAffected Model => new () {

		};
		public override informationBindingDefinition[] informationBindingDefinitions => NavwarnAreaAffected._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. NavwarnAreaAffected._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => NavwarnAreaAffected._featureBindingDefinitions;

		public override string? ToString() => $"NAVWARN Area Affected";
	}

	/// <summary>
	/// The Text Placement feature is used in association with the Feature Name attribute or a light description to optimize text positioning in ECDIS.
	/// </summary>
	[CategoryOrder("TextPlacement",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TextPlacementViewModel : FeatureViewModel<TextPlacement> {
		private int? _scaleMinimum  = default;

		[Category("TextPlacement")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private String _text  = string.Empty;

		[Category("TextPlacement")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String text {
			get {
				return _text;
			}
			set {
				SetValue(ref _text, value);
			}
		}
		private int _textOffsetBearing  = default;

		[Category("TextPlacement")]
		[Editor(typeof(Editors.UnknownEditor<int?>), typeof(Editors.UnknownEditor<int?>))]
		public int textOffsetBearing {
			get {
				return _textOffsetBearing;
			}
			set {
				SetValue(ref _textOffsetBearing, value);
			}
		}
		private int _textOffsetDistance  = default;

		[Category("TextPlacement")]
		[Editor(typeof(Editors.UnknownEditor<int?>), typeof(Editors.UnknownEditor<int?>))]
		public int textOffsetDistance {
			get {
				return _textOffsetDistance;
			}
			set {
				SetValue(ref _textOffsetDistance, value);
			}
		}
		private Boolean _textRotation  = false;

		[Category("TextPlacement")]
		[Editor(typeof(Editors.UnknownEditor<Boolean?>), typeof(Editors.UnknownEditor<Boolean?>))]
		public Boolean textRotation {
			get {
				return _textRotation;
			}
			set {
				SetValue(ref _textRotation, value);
			}
		}


		public override FeatureViewModel<TextPlacement> Load(TextPlacement instance) {
			scaleMinimum = instance.scaleMinimum;
			text = instance.text;
			textOffsetBearing = instance.textOffsetBearing;
			textOffsetDistance = instance.textOffsetDistance;
			textRotation = instance.textRotation;
			return this;
		}

		public override string Serialize() {
			var instance = new TextPlacement {
				scaleMinimum = this.scaleMinimum,
				text = this.text,
				textOffsetBearing = this.textOffsetBearing,
				textOffsetDistance = this.textOffsetDistance,
				textRotation = this.textRotation,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public TextPlacement Model => new () {
			scaleMinimum = this._scaleMinimum,
			text = this._text,
			textOffsetBearing = this._textOffsetBearing,
			textOffsetDistance = this._textOffsetDistance,
			textRotation = this._textRotation,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => TextPlacement._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. TextPlacement._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => TextPlacement._featureBindingDefinitions;

		public override string? ToString() => $"Text Placement";
	}

}
