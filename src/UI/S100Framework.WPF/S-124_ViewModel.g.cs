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
		public static AssociationViewModel CreateInformationAssociation(string type, string? pid = default) => type switch {
			"NWPreambleContent" => new NWPreambleContentViewModel { PID = pid },
			"NWReferences" => new NWReferencesViewModel { PID = pid },
			_ or "" => throw new InvalidOperationException(),
		};

		public static AssociationViewModel CreateFeatureAssociation(string type, string? pid = default) => type switch {
			"AreaAffected" => new AreaAffectedViewModel { PID = pid },
			"TextAssociation" => new TextAssociationViewModel { PID = pid },
			_ or "" => throw new InvalidOperationException(),
		};

		public static InformationViewModel CreateInformationType(string type, string? pid = default) => type switch {
			"NAVWARNPreamble" => new NAVWARNPreambleViewModel { PID = pid },
			"References" => new ReferencesViewModel { PID = pid },
			_ or "" => throw new InvalidOperationException(),
		};

		public static FeatureViewModel CreateFeatureType(string type, string? pid = default) => type switch {
			"NAVWARNPart" => new NAVWARNPartViewModel { PID = pid },
			"NAVWARNAreaAffected" => new NAVWARNAreaAffectedViewModel { PID = pid },
			"TextPlacement" => new TextPlacementViewModel { PID = pid },
			_ or "" => throw new InvalidOperationException(),
		};

		public static ICollection<string> InformationAssociationBindings(string association, string role) => (association, role) switch {
			("NWReferences", "theReferences") => ["References"],
			("NWPreambleContent", "header") => ["NAVWARNPreamble"],
			_ => throw new InvalidOperationException(),
		};

		public static ICollection<string> FeatureAssociationBindings(string association, string role) => (association, role) switch {
			("AreaAffected", "affects") => ["NAVWARNAreaAffected"],
			("TextAssociation", "positions") => ["TextPlacement"],
			("AreaAffected", "impacts") => ["NAVWARNPart"],
			("TextAssociation", "identifies") => ["NAVWARNPart"],
			_ => throw new InvalidOperationException(),
		};
	}

	/// <summary>
	/// Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.
	/// </summary>
	[CategoryOrder("featureName",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class featureNameViewModel : ViewModelBase {
		private String _language  = string.Empty;

		[Category("featureName")]
		public String language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}
		private String _name  = string.Empty;

		[Category("featureName")]
		public String name {
			get {
				return _name;
			}
			set {
				SetValue(ref _name, value);
			}
		}
		private nameUsage? _nameUsage  = default;

		[Category("featureName")]
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

		public featureName Model => new () {
			language = this._language,
			name = this._name,
			nameUsage = this._nameUsage,
		};

		public override string? ToString() => $"Feature Name";
	}
	/// <summary>
	/// The range of time a feature is valid for.
	/// </summary>
	[CategoryOrder("dateTimeRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class dateTimeRangeViewModel : ViewModelBase {
		private DateTime _dateTimeEnd ;

		[Category("dateTimeRange")]
		public DateTime dateTimeEnd {
			get {
				return _dateTimeEnd;
			}
			set {
				SetValue(ref _dateTimeEnd, value);
			}
		}
		private DateTime _dateTimeStart ;

		[Category("dateTimeRange")]
		public DateTime dateTimeStart {
			get {
				return _dateTimeStart;
			}
			set {
				SetValue(ref _dateTimeStart, value);
			}
		}


		public dateTimeRangeViewModel Load(dateTimeRange instance) {
			dateTimeEnd = instance.dateTimeEnd;
			dateTimeStart = instance.dateTimeStart;
			return this;
		}

		public override string Serialize() {
			var instance = new dateTimeRange {
				dateTimeEnd = this.dateTimeEnd,
				dateTimeStart = this.dateTimeStart,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public dateTimeRange Model => new () {
			dateTimeEnd = this._dateTimeEnd,
			dateTimeStart = this._dateTimeStart,
		};

		public override string? ToString() => $"Date Time Range";
	}
	/// <summary>
	/// Reference to feature(s) in an ENC dataset.
	/// </summary>
	[CategoryOrder("eNCFeatureReference",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class eNCFeatureReferenceViewModel : ViewModelBase {
		private String _editionNumber  = string.Empty;

		[Category("eNCFeatureReference")]
		public String editionNumber {
			get {
				return _editionNumber;
			}
			set {
				SetValue(ref _editionNumber, value);
			}
		}
		private String _eNCName  = string.Empty;

		[Category("eNCFeatureReference")]
		public String eNCName {
			get {
				return _eNCName;
			}
			set {
				SetValue(ref _eNCName, value);
			}
		}
		[Category("eNCFeatureReference")]
		public ObservableCollection<String> featureObjectIdentifier  { get; set; } = new ();
		private String _updateNumber  = string.Empty;

		[Category("eNCFeatureReference")]
		public String updateNumber {
			get {
				return _updateNumber;
			}
			set {
				SetValue(ref _updateNumber, value);
			}
		}


		public eNCFeatureReferenceViewModel Load(eNCFeatureReference instance) {
			editionNumber = instance.editionNumber;
			eNCName = instance.eNCName;
			featureObjectIdentifier.Clear();
			if (instance.featureObjectIdentifier is not null) {
				foreach(var e in instance.featureObjectIdentifier)
					featureObjectIdentifier.Add(e);
			}
			updateNumber = instance.updateNumber;
			return this;
		}

		public override string Serialize() {
			var instance = new eNCFeatureReference {
				editionNumber = this.editionNumber,
				eNCName = this.eNCName,
				featureObjectIdentifier = this.featureObjectIdentifier.ToList(),
				updateNumber = this.updateNumber,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public eNCFeatureReference Model => new () {
			editionNumber = this._editionNumber,
			eNCName = this._eNCName,
			featureObjectIdentifier = this.featureObjectIdentifier.ToList(),
			updateNumber = this._updateNumber,
		};

		public override string? ToString() => $"ENC Feature Reference";

		public eNCFeatureReferenceViewModel() : base() {
			featureObjectIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureObjectIdentifier));
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
		public ObservableCollection<String> featureIdentifier  { get; set; } = new ();
		private dateTimeRangeViewModel _dateTimeRange ;

		[Category("featureReference")]
		public dateTimeRangeViewModel dateTimeRange {
			get {
				return _dateTimeRange;
			}
			set {
				SetValue(ref _dateTimeRange, value);
			}
		}
		[Category("featureReference")]
		public ObservableCollection<String> atoNNumber  { get; set; } = new ();
		[Category("featureReference")]
		public ObservableCollection<eNCFeatureReferenceViewModel> eNCFeatureReference  { get; set; } = new ();


		public featureReferenceViewModel Load(featureReference instance) {
			featureIdentifier.Clear();
			if (instance.featureIdentifier is not null) {
				foreach(var e in instance.featureIdentifier)
					featureIdentifier.Add(e);
			}
			dateTimeRange = new ();
			if (instance.dateTimeRange != default) {
				dateTimeRange.Load(instance.dateTimeRange);
			}
			atoNNumber.Clear();
			if (instance.atoNNumber is not null) {
				foreach(var e in instance.atoNNumber)
					atoNNumber.Add(e);
			}
			eNCFeatureReference.Clear();
			if (instance.eNCFeatureReference is not null) {
				foreach(var e in instance.eNCFeatureReference)
					eNCFeatureReference.Add(new eNCFeatureReferenceViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new featureReference {
				featureIdentifier = this.featureIdentifier.ToList(),
				dateTimeRange = this.dateTimeRange?.Model,
				atoNNumber = this.atoNNumber.ToList(),
				eNCFeatureReference = this.eNCFeatureReference.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public featureReference Model => new () {
			featureIdentifier = this.featureIdentifier.ToList(),
			dateTimeRange = this._dateTimeRange?.Model,
			atoNNumber = this.atoNNumber.ToList(),
			eNCFeatureReference = this.eNCFeatureReference.Select(e => e.Model).ToList(),
		};

		public override string? ToString() => $"Feature Reference";

		public featureReferenceViewModel() : base() {
			featureIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureIdentifier));
			};
			atoNNumber.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(atoNNumber));
			};
			eNCFeatureReference.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(eNCFeatureReference));
			};
		}
	}
	/// <summary>
	/// An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.
	/// </summary>
	[CategoryOrder("fixedDateRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class fixedDateRangeViewModel : ViewModelBase {
		private DateOnly? _dateEnd  = default;

		[Category("fixedDateRange")]
		public DateOnly? dateEnd {
			get {
				return _dateEnd;
			}
			set {
				SetValue(ref _dateEnd, value);
			}
		}
		private DateOnly? _dateStart  = default;

		[Category("fixedDateRange")]
		public DateOnly? dateStart {
			get {
				return _dateStart;
			}
			set {
				SetValue(ref _dateStart, value);
			}
		}


		public fixedDateRangeViewModel Load(fixedDateRange instance) {
			dateEnd = instance.dateEnd;
			dateStart = instance.dateStart;
			return this;
		}

		public override string Serialize() {
			var instance = new fixedDateRange {
				dateEnd = this.dateEnd,
				dateStart = this.dateStart,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public fixedDateRange Model => new () {
			dateEnd = this._dateEnd,
			dateStart = this._dateStart,
		};

		public override string? ToString() => $"Fixed Date Range";
	}
	/// <summary>
	/// Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.
	/// </summary>
	[CategoryOrder("information",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class informationViewModel : ViewModelBase {
		private String? _fileLocator  = default;

		[Category("information")]
		public String? fileLocator {
			get {
				return _fileLocator;
			}
			set {
				SetValue(ref _fileLocator, value);
			}
		}
		private String? _fileReference  = default;

		[Category("information")]
		public String? fileReference {
			get {
				return _fileReference;
			}
			set {
				SetValue(ref _fileReference, value);
			}
		}
		private String? _headline  = default;

		[Category("information")]
		public String? headline {
			get {
				return _headline;
			}
			set {
				SetValue(ref _headline, value);
			}
		}
		private String? _language  = default;

		[Category("information")]
		public String? language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}
		private String? _text  = default;

		[Category("information")]
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
	/// Detailed information about a warning.
	/// </summary>
	[CategoryOrder("warningInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class warningInformationViewModel : ViewModelBase {
		private informationViewModel? _information  = default;

		[Category("warningInformation")]
		public informationViewModel? information {
			get {
				return _information;
			}
			set {
				SetValue(ref _information, value);
			}
		}
		[Category("warningInformation")]
		public ObservableCollection<navwarnTypeDetails> navwarnTypeDetails  { get; set; } = new ();


		public warningInformationViewModel Load(warningInformation instance) {
			information = new ();
			if (instance.information != default) {
				information.Load(instance.information);
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
				information = this.information?.Model,
				navwarnTypeDetails = this.navwarnTypeDetails.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public warningInformation Model => new () {
			information = this._information?.Model,
			navwarnTypeDetails = this.navwarnTypeDetails.ToList(),
		};

		public override string? ToString() => $"Warning Information";

		public warningInformationViewModel() : base() {
			navwarnTypeDetails.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(navwarnTypeDetails));
			};
		}
	}
	/// <summary>
	/// Name or number of affected national paper chart or ENC.
	/// </summary>
	[CategoryOrder("chartAffected",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class chartAffectedViewModel : ViewModelBase {
		private String _chartNumber  = string.Empty;

		[Category("chartAffected")]
		public String chartNumber {
			get {
				return _chartNumber;
			}
			set {
				SetValue(ref _chartNumber, value);
			}
		}
		private String? _chartPlanNumber  = default;

		[Category("chartAffected")]
		public String? chartPlanNumber {
			get {
				return _chartPlanNumber;
			}
			set {
				SetValue(ref _chartPlanNumber, value);
			}
		}
		private DateOnly _editionDate ;

		[Category("chartAffected")]
		public DateOnly editionDate {
			get {
				return _editionDate;
			}
			set {
				SetValue(ref _editionDate, value);
			}
		}
		private DateOnly? _lastNoticeDate  = default;

		[Category("chartAffected")]
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

		public chartAffected Model => new () {
			chartNumber = this._chartNumber,
			chartPlanNumber = this._chartPlanNumber,
			editionDate = this._editionDate,
			lastNoticeDate = this._lastNoticeDate,
		};

		public override string? ToString() => $"Chart Affected";
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
		public chartAffectedViewModel? chartAffected {
			get {
				return _chartAffected;
			}
			set {
				SetValue(ref _chartAffected, value);
			}
		}
		private String? _chartPublicationIdentifier  = default;

		[Category("affectedChartPublications")]
		public String? chartPublicationIdentifier {
			get {
				return _chartPublicationIdentifier;
			}
			set {
				SetValue(ref _chartPublicationIdentifier, value);
			}
		}
		private String? _internationalChartAffected  = default;

		[Category("affectedChartPublications")]
		public String? internationalChartAffected {
			get {
				return _internationalChartAffected;
			}
			set {
				SetValue(ref _internationalChartAffected, value);
			}
		}
		private String? _language  = default;

		[Category("affectedChartPublications")]
		public String? language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}
		private String? _publicationAffected  = default;

		[Category("affectedChartPublications")]
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
	/// Name of an area locality as defined by a competent authority.
	/// </summary>
	[CategoryOrder("locationName",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class locationNameViewModel : ViewModelBase {
		private String? _language  = default;

		[Category("locationName")]
		public String? language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}
		private String _text  = string.Empty;

		[Category("locationName")]
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

		public locationName Model => new () {
			language = this._language,
			text = this._text,
		};

		public override string? ToString() => $"Location Name";
	}
	/// <summary>
	/// The general area used to identify which broad geographic region the message affects. The geographical name which is selected for the general area should be one that can be found on charts and in nautical publications. (S-53, 6).
	/// </summary>
	[CategoryOrder("generalArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class generalAreaViewModel : ViewModelBase {
		private String? _localityIdentifier  = default;

		[Category("generalArea")]
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
	/// Name and/or identifier of an area locality.
	/// </summary>
	[CategoryOrder("locality",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class localityViewModel : ViewModelBase {
		private String? _localityIdentifier  = default;

		[Category("locality")]
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
	/// Message series identification of the warning or notice.
	/// </summary>
	[CategoryOrder("messageSeriesIdentifier",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class messageSeriesIdentifierViewModel : ViewModelBase {
		private String _agencyResponsibleForProduction  = string.Empty;

		[Category("messageSeriesIdentifier")]
		public String agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		private String? _countryName  = default;

		[Category("messageSeriesIdentifier")]
		public String? countryName {
			get {
				return _countryName;
			}
			set {
				SetValue(ref _countryName, value);
			}
		}
		private String _nameOfSeries  = string.Empty;

		[Category("messageSeriesIdentifier")]
		public String nameOfSeries {
			get {
				return _nameOfSeries;
			}
			set {
				SetValue(ref _nameOfSeries, value);
			}
		}
		private String? _warningIdentifier  = default;

		[Category("messageSeriesIdentifier")]
		public String? warningIdentifier {
			get {
				return _warningIdentifier;
			}
			set {
				SetValue(ref _warningIdentifier, value);
			}
		}
		private int _warningNumber ;

		[Category("messageSeriesIdentifier")]
		public int warningNumber {
			get {
				return _warningNumber;
			}
			set {
				SetValue(ref _warningNumber, value);
			}
		}
		private warningType _warningType ;

		[Category("messageSeriesIdentifier")]
		public warningType warningType {
			get {
				return _warningType;
			}
			set {
				SetValue(ref _warningType, value);
			}
		}

		[Browsable(false)]
		public warningType[] warningTypeList => Enum.GetValues<warningType>();
		private int _year ;

		[Category("messageSeriesIdentifier")]
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
			countryName = instance.countryName;
			nameOfSeries = instance.nameOfSeries;
			warningIdentifier = instance.warningIdentifier;
			warningNumber = instance.warningNumber;
			warningType = instance.warningType;
			year = instance.year;
			return this;
		}

		public override string Serialize() {
			var instance = new messageSeriesIdentifier {
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				countryName = this.countryName,
				nameOfSeries = this.nameOfSeries,
				warningIdentifier = this.warningIdentifier,
				warningNumber = this.warningNumber,
				warningType = this.warningType,
				year = this.year,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public messageSeriesIdentifier Model => new () {
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			countryName = this._countryName,
			nameOfSeries = this._nameOfSeries,
			warningIdentifier = this._warningIdentifier,
			warningNumber = this._warningNumber,
			warningType = this._warningType,
			year = this._year,
		};

		public override string? ToString() => $"Message Series Identifier";
	}
	/// <summary>
	/// Title of the navigational warning.
	/// </summary>
	[CategoryOrder("nAVWARNTitle",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class nAVWARNTitleViewModel : ViewModelBase {
		private String? _language  = default;

		[Category("nAVWARNTitle")]
		public String? language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}
		private String _text  = string.Empty;

		[Category("nAVWARNTitle")]
		public String text {
			get {
				return _text;
			}
			set {
				SetValue(ref _text, value);
			}
		}


		public nAVWARNTitleViewModel Load(nAVWARNTitle instance) {
			language = instance.language;
			text = instance.text;
			return this;
		}

		public override string Serialize() {
			var instance = new nAVWARNTitle {
				language = this.language,
				text = this.text,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public nAVWARNTitle Model => new () {
			language = this._language,
			text = this._text,
		};

		public override string? ToString() => $"NAVWARN Title";
	}

	/// <summary>
	/// TBD
	/// </summary>
	[CategoryOrder("NWPreambleContent",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NWPreambleContentViewModel : AssociationViewModel {


		public NWPreambleContentViewModel Load(NWPreambleContent instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new NWPreambleContent {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public NWPreambleContent Model => new () {

		};

		public override string? ToString() => $"NW Preamble Content";
	}

	/// <summary>
	/// TBD
	/// </summary>
	[CategoryOrder("NWReferences",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NWReferencesViewModel : AssociationViewModel {


		public NWReferencesViewModel Load(NWReferences instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new NWReferences {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public NWReferences Model => new () {

		};

		public override string? ToString() => $"NW References";
	}

	/// <summary>
	/// Used to indicate an area outside of the geographic area of the associated feature that can nonetheless be influenced by that feature.
	/// </summary>
	[CategoryOrder("AreaAffected",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AreaAffectedViewModel : AssociationViewModel {


		public AreaAffectedViewModel Load(AreaAffected instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new AreaAffected {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public AreaAffected Model => new () {

		};

		public override string? ToString() => $"Area Affected Association";
	}

	/// <summary>
	/// A feature association for the binding between a geo feature and the cartographically positioned location for text.
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

		public TextAssociation Model => new () {

		};

		public override string? ToString() => $"Text association";
	}

	/// <summary>
	/// Preamble information for warnings, notices and other types of messages in a navigational warning scheme.
	/// </summary>
	[CategoryOrder("NAVWARNPreamble",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NAVWARNPreambleViewModel : InformationViewModel<NAVWARNPreamble> {
		[Category("NAVWARNPreamble")]
		public ObservableCollection<affectedChartPublicationsViewModel> affectedChartPublications  { get; set; } = new ();
		[Category("NAVWARNPreamble")]
		public ObservableCollection<generalAreaViewModel> generalArea  { get; set; } = new ();
		[Category("NAVWARNPreamble")]
		public ObservableCollection<localityViewModel> locality  { get; set; } = new ();
		private messageSeriesIdentifierViewModel _messageSeriesIdentifier ;

		[Category("NAVWARNPreamble")]
		public messageSeriesIdentifierViewModel messageSeriesIdentifier {
			get {
				return _messageSeriesIdentifier;
			}
			set {
				SetValue(ref _messageSeriesIdentifier, value);
			}
		}
		[Category("NAVWARNPreamble")]
		public ObservableCollection<nAVWARNTitleViewModel> nAVWARNTitle  { get; set; } = new ();
		private DateTime? _cancellationDate  = default;

		[Category("NAVWARNPreamble")]
		public DateTime? cancellationDate {
			get {
				return _cancellationDate;
			}
			set {
				SetValue(ref _cancellationDate, value);
			}
		}
		private Boolean _intService  = false;

		[Category("NAVWARNPreamble")]
		public Boolean intService {
			get {
				return _intService;
			}
			set {
				SetValue(ref _intService, value);
			}
		}
		private navwarnTypeGeneral _navwarnTypeGeneral ;

		[Category("NAVWARNPreamble")]
		public navwarnTypeGeneral navwarnTypeGeneral {
			get {
				return _navwarnTypeGeneral;
			}
			set {
				SetValue(ref _navwarnTypeGeneral, value);
			}
		}
		private DateTime _publicationTime ;

		[Category("NAVWARNPreamble")]
		public DateTime publicationTime {
			get {
				return _publicationTime;
			}
			set {
				SetValue(ref _publicationTime, value);
			}
		}


		public override InformationViewModel<NAVWARNPreamble> Load(NAVWARNPreamble instance) {
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
			nAVWARNTitle.Clear();
			if (instance.nAVWARNTitle is not null) {
				foreach(var e in instance.nAVWARNTitle)
					nAVWARNTitle.Add(new nAVWARNTitleViewModel().Load(e));
			}
			cancellationDate = instance.cancellationDate;
			intService = instance.intService;
			navwarnTypeGeneral = instance.navwarnTypeGeneral;
			publicationTime = instance.publicationTime;
			return this;
		}

		public override string Serialize() {
			var instance = new NAVWARNPreamble {
				affectedChartPublications = this.affectedChartPublications.Select(e => e.Model).ToList(),
				generalArea = this.generalArea.Select(e => e.Model).ToList(),
				locality = this.locality.Select(e => e.Model).ToList(),
				messageSeriesIdentifier = this.messageSeriesIdentifier?.Model,
				nAVWARNTitle = this.nAVWARNTitle.Select(e => e.Model).ToList(),
				cancellationDate = this.cancellationDate,
				intService = this.intService,
				navwarnTypeGeneral = this.navwarnTypeGeneral,
				publicationTime = this.publicationTime,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public NAVWARNPreamble Model => new () {
			affectedChartPublications = this.affectedChartPublications.Select(e => e.Model).ToList(),
			generalArea = this.generalArea.Select(e => e.Model).ToList(),
			locality = this.locality.Select(e => e.Model).ToList(),
			messageSeriesIdentifier = this._messageSeriesIdentifier?.Model,
			nAVWARNTitle = this.nAVWARNTitle.Select(e => e.Model).ToList(),
			cancellationDate = this._cancellationDate,
			intService = this._intService,
			navwarnTypeGeneral = this._navwarnTypeGeneral,
			publicationTime = this._publicationTime,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => NAVWARNPreamble._informationBindingDefinitions;

		public override string? ToString() => $"NAVWARN Preamble";

		public NAVWARNPreambleViewModel() : base() {
			affectedChartPublications.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(affectedChartPublications));
			};
			generalArea.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(generalArea));
			};
			locality.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(locality));
			};
			nAVWARNTitle.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(nAVWARNTitle));
			};
		}
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
		public Boolean noMessageOnHand {
			get {
				return _noMessageOnHand;
			}
			set {
				SetValue(ref _noMessageOnHand, value);
			}
		}
		private referenceCategory _referenceCategory ;

		[Category("References")]
		public referenceCategory referenceCategory {
			get {
				return _referenceCategory;
			}
			set {
				SetValue(ref _referenceCategory, value);
			}
		}

		[Browsable(false)]
		public referenceCategory[] referenceCategoryList => Enum.GetValues<referenceCategory>();


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
	/// Navigational warning information that may be geo-located.
	/// </summary>
	[CategoryOrder("NAVWARNPart",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NAVWARNPartViewModel : FeatureViewModel<NAVWARNPart> {
		[Category("NAVWARNPart")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("NAVWARNPart")]
		public ObservableCollection<featureReferenceViewModel> featureReference  { get; set; } = new ();
		[Category("NAVWARNPart")]
		public ObservableCollection<fixedDateRangeViewModel> fixedDateRange  { get; set; } = new ();
		private warningInformationViewModel _warningInformation ;

		[Category("NAVWARNPart")]
		public warningInformationViewModel warningInformation {
			get {
				return _warningInformation;
			}
			set {
				SetValue(ref _warningInformation, value);
			}
		}
		private restriction? _restriction  = default;

		[Category("NAVWARNPart")]
		public restriction? restriction {
			get {
				return _restriction;
			}
			set {
				SetValue(ref _restriction, value);
			}
		}

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)8,(restriction)7,(restriction)14,(restriction)25,(restriction)27];


		public override FeatureViewModel<NAVWARNPart> Load(NAVWARNPart instance) {
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
			fixedDateRange.Clear();
			if (instance.fixedDateRange is not null) {
				foreach(var e in instance.fixedDateRange)
					fixedDateRange.Add(new fixedDateRangeViewModel().Load(e));
			}
			warningInformation = new ();
			if (instance.warningInformation != default) {
				warningInformation.Load(instance.warningInformation);
			}
			restriction = instance.restriction;
			return this;
		}

		public override string Serialize() {
			var instance = new NAVWARNPart {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				featureReference = this.featureReference.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange.Select(e => e.Model).ToList(),
				warningInformation = this.warningInformation?.Model,
				restriction = this.restriction,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public NAVWARNPart Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			featureReference = this.featureReference.Select(e => e.Model).ToList(),
			fixedDateRange = this.fixedDateRange.Select(e => e.Model).ToList(),
			warningInformation = this._warningInformation?.Model,
			restriction = this._restriction,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => NAVWARNPart._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => NAVWARNPart._featureBindingDefinitions;

		public override string? ToString() => $"NAVWARN Part";

		public NAVWARNPartViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			featureReference.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureReference));
			};
			fixedDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(fixedDateRange));
			};
		}
	}

	/// <summary>
	/// Used to enhance the user’s awareness of an affected area following some incident.
	/// </summary>
	[CategoryOrder("NAVWARNAreaAffected",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NAVWARNAreaAffectedViewModel : FeatureViewModel<NAVWARNAreaAffected> {


		public override FeatureViewModel<NAVWARNAreaAffected> Load(NAVWARNAreaAffected instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new NAVWARNAreaAffected {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public NAVWARNAreaAffected Model => new () {

		};
		public override informationBindingDefinition[] informationBindingDefinitions => NAVWARNAreaAffected._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => NAVWARNAreaAffected._featureBindingDefinitions;

		public override string? ToString() => $"NAVWARN Area Affected";
	}

	/// <summary>
	/// The Text Placement feature is used in association with the Feature Name attribute or a light description to optimize text positioning in ECDIS.
	/// </summary>
	[CategoryOrder("TextPlacement",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TextPlacementViewModel : FeatureViewModel<TextPlacement> {
		private String? _text  = default;

		[Category("TextPlacement")]
		public String? text {
			get {
				return _text;
			}
			set {
				SetValue(ref _text, value);
			}
		}
		private int _textOffsetBearing ;

		[Category("TextPlacement")]
		public int textOffsetBearing {
			get {
				return _textOffsetBearing;
			}
			set {
				SetValue(ref _textOffsetBearing, value);
			}
		}
		private int _textOffsetDistance ;

		[Category("TextPlacement")]
		public int textOffsetDistance {
			get {
				return _textOffsetDistance;
			}
			set {
				SetValue(ref _textOffsetDistance, value);
			}
		}
		private Boolean? _textRotation  = default;

		[Category("TextPlacement")]
		public Boolean? textRotation {
			get {
				return _textRotation;
			}
			set {
				SetValue(ref _textRotation, value);
			}
		}
		private textType? _textType  = default;

		[Category("TextPlacement")]
		public textType? textType {
			get {
				return _textType;
			}
			set {
				SetValue(ref _textType, value);
			}
		}

		[Browsable(false)]
		public textType[] textTypeList => [(textType)1,(textType)2];
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


		public override FeatureViewModel<TextPlacement> Load(TextPlacement instance) {
			text = instance.text;
			textOffsetBearing = instance.textOffsetBearing;
			textOffsetDistance = instance.textOffsetDistance;
			textRotation = instance.textRotation;
			textType = instance.textType;
			scaleMinimum = instance.scaleMinimum;
			return this;
		}

		public override string Serialize() {
			var instance = new TextPlacement {
				text = this.text,
				textOffsetBearing = this.textOffsetBearing,
				textOffsetDistance = this.textOffsetDistance,
				textRotation = this.textRotation,
				textType = this.textType,
				scaleMinimum = this.scaleMinimum,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public TextPlacement Model => new () {
			text = this._text,
			textOffsetBearing = this._textOffsetBearing,
			textOffsetDistance = this._textOffsetDistance,
			textRotation = this._textRotation,
			textType = this._textType,
			scaleMinimum = this._scaleMinimum,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => TextPlacement._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => TextPlacement._featureBindingDefinitions;

		public override string? ToString() => $"Text Placement";
	}

}
