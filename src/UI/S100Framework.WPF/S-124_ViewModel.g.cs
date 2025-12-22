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
using System.Text.Json;

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
	[Description("Identifies paper charts, ENCs or publications that are affected by the information.")]
	[CategoryOrder("affectedChartPublications",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class affectedChartPublicationsViewModel : ComplexViewModel<affectedChartPublications> {
		private chartAffectedViewModel? _chartAffected  = default;

		[Description("Name or number of affected national paper chart or ENC.")]
		[ExpandableObject]
		[Optional]
		public chartAffectedViewModel? chartAffected {
			get {
				return _chartAffected;
			}
			set {
				SetValue(ref _chartAffected, value);
			}
		}

		private String? _chartPublicationIdentifier  = default;

		[Description("Identifier for the chart or publication (using the MRN format).")]
		//[Editor(typeof(Editors.HorizonEditor<affectedChartPublications>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? chartPublicationIdentifier {
			get {
				return _chartPublicationIdentifier;
			}
			set {
				SetValue(ref _chartPublicationIdentifier, value);
			}
		}

		private String? _internationalChartAffected  = default;

		[Description("International paper chart number. (Not used if chartAffected carry an ENC name).")]
		//[Editor(typeof(Editors.HorizonEditor<affectedChartPublications>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? internationalChartAffected {
			get {
				return _internationalChartAffected;
			}
			set {
				SetValue(ref _internationalChartAffected, value);
			}
		}

		private String _language  = string.Empty;

		[Description("The method of human communication, either spoken or written, consisting of the use of words in a structured and conventional way.")]
		//[Editor(typeof(Editors.HorizonEditor<affectedChartPublications>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}

		private String? _publicationAffected  = default;

		[Description("Name of affected publication.")]
		//[Editor(typeof(Editors.HorizonEditor<affectedChartPublications>), typeof(Editors.HorizonEditor))]
		[Optional]
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
	[Description("Name or number of affected national paper chart or ENC.")]
	[CategoryOrder("chartAffected",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class chartAffectedViewModel : ComplexViewModel<chartAffected> {
		private String _chartNumber  = string.Empty;

		[Description("Chart number. Note, can be either paper chart number or ENC file name.")]
		//[Editor(typeof(Editors.HorizonEditor<chartAffected>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String chartNumber {
			get {
				return _chartNumber;
			}
			set {
				SetValue(ref _chartNumber, value);
			}
		}

		private String? _chartPlanNumber  = default;

		[Description("Plan number when a chart has more than one panel.")]
		//[Editor(typeof(Editors.HorizonEditor<chartAffected>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? chartPlanNumber {
			get {
				return _chartPlanNumber;
			}
			set {
				SetValue(ref _chartPlanNumber, value);
			}
		}

		private DateOnly _editionDate  = default;

		[Description("Date of publishing for example of a publication, chart, or product.")]
		//[Editor(typeof(Editors.HorizonEditor<chartAffected>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public DateOnly editionDate {
			get {
				return _editionDate;
			}
			set {
				SetValue(ref _editionDate, value);
			}
		}

		private DateOnly? _lastNoticeDate  = default;

		[Description("Date of the last notice to mariner, such as was applied to a chart or publication.")]
		//[Editor(typeof(Editors.HorizonEditor<chartAffected>), typeof(Editors.HorizonEditor))]
		[Optional]
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
	[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
	[CategoryOrder("fixedDateRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class fixedDateRangeViewModel : ComplexViewModel<fixedDateRange> {
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
	[Description("The general area used to identify which broad geographic region the message affects. The geographical name which is selected for the general area should be one that can be found on charts and in nautical publications. (S-53, 6).")]
	[CategoryOrder("generalArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class generalAreaViewModel : ComplexViewModel<generalArea> {
		private String? _localityIdentifier  = default;

		[Description("Globally unique identifier for the area or locality in the MRN format.")]
		//[Editor(typeof(Editors.HorizonEditor<generalArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? localityIdentifier {
			get {
				return _localityIdentifier;
			}
			set {
				SetValue(ref _localityIdentifier, value);
			}
		}

		[Description("Name of an area locality as defined by a competent authority.")]
		[Multiplicity(1)]
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
	[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
	[CategoryOrder("information",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class informationViewModel : ComplexViewModel<information> {
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

		private String _text  = string.Empty;

		[Description("A non-formatted digital text string.")]
		//[Editor(typeof(Editors.HorizonEditor<information>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
	[Description("Name and/or identifier of an area locality.")]
	[CategoryOrder("locality",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class localityViewModel : ComplexViewModel<locality> {
		private String? _localityIdentifier  = default;

		[Description("Globally unique identifier for the area or locality in the MRN format.")]
		//[Editor(typeof(Editors.HorizonEditor<locality>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? localityIdentifier {
			get {
				return _localityIdentifier;
			}
			set {
				SetValue(ref _localityIdentifier, value);
			}
		}

		[Description("Name of an area locality as defined by a competent authority.")]
		[Multiplicity(1)]
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
	[Description("Name of an area locality as defined by a competent authority.")]
	[CategoryOrder("locationName",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class locationNameViewModel : ComplexViewModel<locationName> {
		private String _language  = string.Empty;

		[Description("The method of human communication, either spoken or written, consisting of the use of words in a structured and conventional way.")]
		//[Editor(typeof(Editors.HorizonEditor<locationName>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}

		private String _text  = string.Empty;

		[Description("A non-formatted digital text string.")]
		//[Editor(typeof(Editors.HorizonEditor<locationName>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
	[Description("Message series identification of the warning or notice.")]
	[CategoryOrder("messageSeriesIdentifier",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class messageSeriesIdentifierViewModel : ComplexViewModel<messageSeriesIdentifier> {
		private String _agencyResponsibleForProduction  = string.Empty;

		[Description("Identifies the agency which produced the data.")]
		//[Editor(typeof(Editors.HorizonEditor<messageSeriesIdentifier>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}

		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		//[Editor(typeof(Editors.HorizonEditor<messageSeriesIdentifier>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		private String _nameOfSeries  = string.Empty;

		[Description("The NAVAREA or METAREA. Example: NAVAREA IV. Distinction: generalArea, locality")]
		//[Editor(typeof(Editors.HorizonEditor<messageSeriesIdentifier>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String nameOfSeries {
			get {
				return _nameOfSeries;
			}
			set {
				SetValue(ref _nameOfSeries, value);
			}
		}

		private String? _nationality  = default;

		[Description("Identifier of membership of a particular nation.")]
		//[Editor(typeof(Editors.HorizonEditor<messageSeriesIdentifier>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? nationality {
			get {
				return _nationality;
			}
			set {
				SetValue(ref _nationality, value);
			}
		}

		private int _warningNumber  = default;

		[Description("The consecutive number re-starts each calendar year at 1 (Leading zeros are not mandatory).")]
		//[Editor(typeof(Editors.HorizonEditor<messageSeriesIdentifier>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public int warningNumber {
			get {
				return _warningNumber;
			}
			set {
				SetValue(ref _warningNumber, value);
			}
		}

		private warningType _warningType  = default;

		[Description("The scope of the MSI warning - NAVAREA, sub-area, etc.")]
		//[Editor(typeof(Editors.HorizonEditor<messageSeriesIdentifier>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12])]
		[Mandatory]
		public warningType warningType {
			get {
				return _warningType;
			}
			set {
				SetValue(ref _warningType, value);
			}
		}

		private int _year  = default;

		[Description("A period of one revolution of the earth around the sun.")]
		//[Editor(typeof(Editors.HorizonEditor<messageSeriesIdentifier>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
	[Description("Title of the navigational warning.")]
	[CategoryOrder("navwarnTitle",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class navwarnTitleViewModel : ComplexViewModel<navwarnTitle> {
		private String _language  = string.Empty;

		[Description("The method of human communication, either spoken or written, consisting of the use of words in a structured and conventional way.")]
		//[Editor(typeof(Editors.HorizonEditor<navwarnTitle>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}

		private String _text  = string.Empty;

		[Description("A non-formatted digital text string.")]
		//[Editor(typeof(Editors.HorizonEditor<navwarnTitle>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
	[Description("Detailed information about a warning.")]
	[CategoryOrder("warningInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class warningInformationViewModel : ComplexViewModel<warningInformation> {
		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Detailed type of a warning or hazard.")]
		[Optional]
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
	[Description("Reference to an object or feature that is external to the dataset.")]
	[CategoryOrder("featureReference",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class featureReferenceViewModel : ComplexViewModel<featureReference> {
		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Optional]
		public ObservableCollection<String> atoNNumber  { get; set; } = new ();

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Optional]
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
	[Description("Provides an indication of the vertical and horizontal positional uncertainty of bathymetric data, optionally within a specified date range.")]
	[CategoryOrder("spatialAccuracy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class spatialAccuracyViewModel : ComplexViewModel<spatialAccuracy> {
		private horizontalPositionUncertaintyViewModel _horizontalPositionUncertainty  = default;

		[Description("The best estimate of the accuracy of a position.")]
		[ExpandableObject]
		[Mandatory]
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
	[Description("The binding between a navigational warning preamble and the body.")]
	[CategoryOrder("navwarnPreambleContent",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class navwarnPreambleContentViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new navwarnPreambleContent {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"navwarnPreambleContent";
	}



	/// <summary>
	/// The relationship between a navigational warning and previous information relevant to its purpose.
	/// </summary>
	[Description("The relationship between a navigational warning and previous information relevant to its purpose.")]
	[CategoryOrder("navwarnReferences",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class navwarnReferencesViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new navwarnReferences {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"navwarnReferences";
	}



	/// <summary>
	/// a feature association for the binding between a geo feature and the cartographically positioned location for text.
	/// </summary>
	[Description("a feature association for the binding between a geo feature and the cartographically positioned location for text.")]
	[CategoryOrder("TextAssociation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TextAssociationViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new TextAssociation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Text association";
	}



	/// <summary>
	/// Association between a warning and the area impacted.
	/// </summary>
	[Description("Association between a warning and the area impacted.")]
	[CategoryOrder("areaAffected",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class areaAffectedViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new areaAffected {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Area Affected";
	}



	/// <summary>
	/// References to for example a navigational warning, nautical publication or chart.
	/// </summary>
	[Description("References to for example a navigational warning, nautical publication or chart.")]
	[CategoryOrder("References",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ReferencesViewModel : InformationViewModel<References> {
		[Description("Message series identification of the warning or notice.")]
		[Category("References")]
		[Optional]
		public ObservableCollection<messageSeriesIdentifierViewModel> messageSeriesIdentifier  { get; set; } = new ();

		private Boolean _noMessageOnHand  = false;

		[Description("An indication of no active message.")]
		[Category("References")]
		//[Editor(typeof(Editors.HorizonEditor<References>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public Boolean noMessageOnHand {
			get {
				return _noMessageOnHand;
			}
			set {
				SetValue(ref _noMessageOnHand, value);
			}
		}

		private referenceCategory _referenceCategory  = default;

		[Description("Category of reference.")]
		[Category("References")]
		//[Editor(typeof(Editors.HorizonEditor<References>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Mandatory]
		public referenceCategory referenceCategory {
			get {
				return _referenceCategory;
			}
			set {
				SetValue(ref _referenceCategory, value);
			}
		}


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("navwarnReferences","theWarning",["NavwarnPreamble"], lower:1, upper:1)]
		public ObservableCollection<InformationRefViewModel> navwarnReferences { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. navwarnReferences.Select(e => new informationBinding<DomainModel.S124.InformationAssociations.navwarnReferences> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion

		public ReferencesViewModel Load(References instance) {
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.References.informationBindingDefinitions;

		public ReferencesViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

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
	[Description("Preamble information for warnings, notices and other types of messages in a navigational warning scheme.")]
	[CategoryOrder("NavwarnPreamble",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NavwarnPreambleViewModel : InformationViewModel<NavwarnPreamble> {
		[Description("Identifies paper charts, ENCs or publications that are affected by the information.")]
		[Category("NavwarnPreamble")]
		[Optional]
		public ObservableCollection<affectedChartPublicationsViewModel> affectedChartPublications  { get; set; } = new ();

		[Description("The general area used to identify which broad geographic region the message affects. The geographical name which is selected for the general area should be one that can be found on charts and in nautical publications. (S-53, 6).")]
		[Category("NavwarnPreamble")]
		[Multiplicity(1)]
		public ObservableCollection<generalAreaViewModel> generalArea  { get; set; } = new ();

		[Description("Name and/or identifier of an area locality.")]
		[Category("NavwarnPreamble")]
		[Optional]
		public ObservableCollection<localityViewModel> locality  { get; set; } = new ();

		private messageSeriesIdentifierViewModel _messageSeriesIdentifier  = default;

		[Description("Message series identification of the warning or notice.")]
		[Category("NavwarnPreamble")]
		[ExpandableObject]
		[Mandatory]
		public messageSeriesIdentifierViewModel messageSeriesIdentifier {
			get {
				return _messageSeriesIdentifier;
			}
			set {
				SetValue(ref _messageSeriesIdentifier, value);
			}
		}

		[Description("Title of the navigational warning.")]
		[Category("NavwarnPreamble")]
		[Optional]
		public ObservableCollection<navwarnTitleViewModel> navwarnTitle  { get; set; } = new ();

		private DateTime? _cancellationDate  = default;

		[Description("Date and time of cancelling a notice or warning.")]
		[Category("NavwarnPreamble")]
		//[Editor(typeof(Editors.HorizonEditor<NavwarnPreamble>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateTime? cancellationDate {
			get {
				return _cancellationDate;
			}
			set {
				SetValue(ref _cancellationDate, value);
			}
		}

		private Boolean _intService  = false;

		[Description("An indication of an international service, true = yes, false = no.")]
		[Category("NavwarnPreamble")]
		//[Editor(typeof(Editors.HorizonEditor<NavwarnPreamble>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public Boolean intService {
			get {
				return _intService;
			}
			set {
				SetValue(ref _intService, value);
			}
		}

		private navwarnTypeGeneral _navwarnTypeGeneral  = default;

		[Description("General type of a navigational warning or navigational hazard.")]
		[Category("NavwarnPreamble")]
		//[Editor(typeof(Editors.HorizonEditor<NavwarnPreamble>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20])]
		[Mandatory]
		public navwarnTypeGeneral navwarnTypeGeneral {
			get {
				return _navwarnTypeGeneral;
			}
			set {
				SetValue(ref _navwarnTypeGeneral, value);
			}
		}

		private DateTime _publicationTime  = default;

		[Description("Date and time of publication of the notice or warning.")]
		[Category("NavwarnPreamble")]
		//[Editor(typeof(Editors.HorizonEditor<NavwarnPreamble>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public DateTime publicationTime {
			get {
				return _publicationTime;
			}
			set {
				SetValue(ref _publicationTime, value);
			}
		}


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("navwarnReferences","theReferences",["References"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> navwarnReferences { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. navwarnReferences.Select(e => new informationBinding<DomainModel.S124.InformationAssociations.navwarnReferences> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion

		public NavwarnPreambleViewModel Load(NavwarnPreamble instance) {
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.NavwarnPreamble.informationBindingDefinitions;

		public NavwarnPreambleViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

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
	[Description("The indication of the quality of the locational information for features in a dataset.")]
	[CategoryOrder("SpatialQuality",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SpatialQualityViewModel : InformationViewModel<SpatialQuality> {
		private qualityOfHorizontalMeasurement? _qualityOfHorizontalMeasurement  = default;

		[Description("The degree of reliability attributed to a position.")]
		[Category("SpatialQuality")]
		//[Editor(typeof(Editors.HorizonEditor<SpatialQuality>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11])]
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
	/// Navigational warning information that may be geo-located.
	/// </summary>
	[Description("Navigational warning information that may be geo-located.")]
	[CategoryOrder("NavwarnPart",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NavwarnPartViewModel : FeatureViewModel<NavwarnPart> {
		private restriction? _restriction  = default;

		[Description("The official legal statute of each kind of restricted area.")]
		[Category("NavwarnPart")]
		//[Editor(typeof(Editors.HorizonEditor<NavwarnPart>), typeof(Editors.HorizonEditor))]
		[PermittedValues([7,8,14,25,27])]
		[Optional]
		public restriction? restriction {
			get {
				return _restriction;
			}
			set {
				SetValue(ref _restriction, value);
			}
		}

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("NavwarnPart")]
		[Optional]
		public ObservableCollection<fixedDateRangeViewModel> fixedDateRange  { get; set; } = new ();

		private warningInformationViewModel _warningInformation  = default;

		[Description("Detailed information about a warning.")]
		[Category("NavwarnPart")]
		[ExpandableObject]
		[Mandatory]
		public warningInformationViewModel warningInformation {
			get {
				return _warningInformation;
			}
			set {
				SetValue(ref _warningInformation, value);
			}
		}

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("NavwarnPart")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Description("Reference to an object or feature that is external to the dataset.")]
		[Category("NavwarnPart")]
		[Optional]
		public ObservableCollection<featureReferenceViewModel> featureReference  { get; set; } = new ();


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("navwarnPreambleContent","header",["NavwarnPreamble"], lower:1, upper:1)]
		public ObservableCollection<InformationRefViewModel> navwarnPreambleContents { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. navwarnPreambleContents.Select(e => new informationBinding<DomainModel.S124.InformationAssociations.navwarnPreambleContent> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("areaAffected","affects",["NavwarnAreaAffected"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> areaAffecteds { get; set; } = new();

		[Category("FeatureBindings")]
		[FeatureBinding("TextAssociation","thePositionProvider",["TextPlacement"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> TextAssociations { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. areaAffecteds.Select(e => new featureBinding<DomainModel.S124.FeatureAssociations.areaAffected> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. TextAssociations.Select(e => new featureBinding<DomainModel.S124.FeatureAssociations.TextAssociation> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public NavwarnPartViewModel Load(NavwarnPart instance) {
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.NavwarnPart.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.NavwarnPart.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.NavwarnPart.featureBindingDefinitions;

		public NavwarnPartViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public NavwarnPartViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
			areaAffecteds.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(areaAffecteds));
			};
			TextAssociations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(TextAssociations));
			};
		}
	}



	/// <summary>
	/// An area affected by some event marked by a navigational warning.
	/// </summary>
	[Description("An area affected by some event marked by a navigational warning.")]
	[CategoryOrder("NavwarnAreaAffected",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NavwarnAreaAffectedViewModel : FeatureViewModel<NavwarnAreaAffected> {


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("areaAffected","impacts",["NavwarnPart"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> areaAffecteds { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. areaAffecteds.Select(e => new featureBinding<DomainModel.S124.FeatureAssociations.areaAffected> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public NavwarnAreaAffectedViewModel Load(NavwarnAreaAffected instance) {

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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.NavwarnAreaAffected.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.NavwarnAreaAffected.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.NavwarnAreaAffected.featureBindingDefinitions;

		public NavwarnAreaAffectedViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public NavwarnAreaAffectedViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"NAVWARN Area Affected";

		public NavwarnAreaAffectedViewModel() : base() {
			areaAffecteds.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(areaAffecteds));
			};
		}
	}



	/// <summary>
	/// The Text Placement feature is used in association with the Feature Name attribute or a light description to optimize text positioning in ECDIS.
	/// </summary>
	[Description("The Text Placement feature is used in association with the Feature Name attribute or a light description to optimize text positioning in ECDIS.")]
	[CategoryOrder("TextPlacement",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TextPlacementViewModel : FeatureViewModel<TextPlacement> {
		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("TextPlacement")]
		//[Editor(typeof(Editors.HorizonEditor<TextPlacement>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private String _text  = string.Empty;

		[Description("A non-formatted digital text string.")]
		[Category("TextPlacement")]
		//[Editor(typeof(Editors.HorizonEditor<TextPlacement>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String text {
			get {
				return _text;
			}
			set {
				SetValue(ref _text, value);
			}
		}

		private int _textOffsetBearing  = default;

		[Description("The angular distance measured from true north that text associated with a feature is positioned from the feature in an end-user system.")]
		[Category("TextPlacement")]
		//[Editor(typeof(Editors.HorizonEditor<TextPlacement>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public int textOffsetBearing {
			get {
				return _textOffsetBearing;
			}
			set {
				SetValue(ref _textOffsetBearing, value);
			}
		}

		private int _textOffsetDistance  = default;

		[Description("The distance that text associated with a feature is positioned from the feature in an end-user system.")]
		[Category("TextPlacement")]
		//[Editor(typeof(Editors.HorizonEditor<TextPlacement>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public int textOffsetDistance {
			get {
				return _textOffsetDistance;
			}
			set {
				SetValue(ref _textOffsetDistance, value);
			}
		}

		private Boolean _textRotation  = false;

		[Description("A statement that expresses if text associated with a feature is to be rotated in the ECDIS display or not.")]
		[Category("TextPlacement")]
		//[Editor(typeof(Editors.HorizonEditor<TextPlacement>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public Boolean textRotation {
			get {
				return _textRotation;
			}
			set {
				SetValue(ref _textRotation, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("TextAssociation","theCartographicText",["NavwarnPart"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> TextAssociations { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. TextAssociations.Select(e => new featureBinding<DomainModel.S124.FeatureAssociations.TextAssociation> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public TextPlacementViewModel Load(TextPlacement instance) {
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.TextPlacement.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.TextPlacement.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.TextPlacement.featureBindingDefinitions;

		public TextPlacementViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public TextPlacementViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Text Placement";

		public TextPlacementViewModel() : base() {
			TextAssociations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(TextAssociations));
			};
		}
	}



	public static class InformationBindingExtension {
		public static ReferencesViewModel LoadInformationBinding(this ReferencesViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<navwarnReferences> navwarnReferences) {
					instance.navwarnReferences.Add(new InformationRefViewModel {
						informationId = navwarnReferences.referenceId,
						informationType = navwarnReferences.informationType,
						role = navwarnReferences.role,
					});
				}
			}
			return instance;
		}

		public static NavwarnPreambleViewModel LoadInformationBinding(this NavwarnPreambleViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<navwarnReferences> navwarnReferences) {
					instance.navwarnReferences.Add(new InformationRefViewModel {
						informationId = navwarnReferences.referenceId,
						informationType = navwarnReferences.informationType,
						role = navwarnReferences.role,
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

		public static NavwarnPartViewModel LoadInformationBinding(this NavwarnPartViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<navwarnPreambleContent> navwarnPreambleContent) {
					instance.navwarnPreambleContents.Add(new InformationRefViewModel {
						informationId = navwarnPreambleContent.referenceId,
						informationType = navwarnPreambleContent.informationType,
						role = navwarnPreambleContent.role,
					});
				}
			}
			return instance;
		}

		public static NavwarnAreaAffectedViewModel LoadInformationBinding(this NavwarnAreaAffectedViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static TextPlacementViewModel LoadInformationBinding(this TextPlacementViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

	}

	public static class FeatureBindingExtension {
		public static NavwarnPartViewModel LoadFeatureBinding(this NavwarnPartViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<areaAffected> areaAffected) {
					instance.areaAffecteds.Add(new FeatureRefViewModel {
						featureId = areaAffected.referenceId,
						featureType = areaAffected.featureType,
						role = areaAffected.role,
					});
				}
				if(featureBinding is featureBinding<TextAssociation> textAssociation) {
					instance.TextAssociations.Add(new FeatureRefViewModel {
						featureId = textAssociation.referenceId,
						featureType = textAssociation.featureType,
						role = textAssociation.role,
					});
				}
			}
			return instance;
		}

		public static NavwarnAreaAffectedViewModel LoadFeatureBinding(this NavwarnAreaAffectedViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<areaAffected> areaAffected) {
					instance.areaAffecteds.Add(new FeatureRefViewModel {
						featureId = areaAffected.referenceId,
						featureType = areaAffected.featureType,
						role = areaAffected.role,
					});
				}
			}
			return instance;
		}

		public static TextPlacementViewModel LoadFeatureBinding(this TextPlacementViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<TextAssociation> textAssociation) {
					instance.TextAssociations.Add(new FeatureRefViewModel {
						featureId = textAssociation.referenceId,
						featureType = textAssociation.featureType,
						role = textAssociation.role,
					});
				}
			}
			return instance;
		}

	}

}
