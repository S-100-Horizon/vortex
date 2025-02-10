using System;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Reflection;
using S100Framework.DomainModel;
using S100Framework.DomainModel.Bindings;
using S100Framework.DomainModel.S124;
using S100Framework.DomainModel.S124.ComplexAttributes;
using S100Framework.DomainModel.S124.InformationTypes;
using S100Framework.DomainModel.S124.FeatureTypes;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

#nullable enable
namespace S100Framework.WPF.ViewModel.S124 {
    internal static class Preamble {
        public static ImmutableDictionary<string, Func<ViewModelBase>> _creators => ImmutableDictionary.Create<string, Func<ViewModelBase>>().AddRange(new Dictionary<string, Func<ViewModelBase>> { { "NAVWARNPreamble", () =>
        {
            return new NAVWARNPreambleViewModel();
        } }, { "References", () =>
        {
            return new ReferencesViewModel();
        } }, { "NAVWARNPart", () =>
        {
            return new NAVWARNPartViewModel();
        } }, { "NAVWARNAreaAffected", () =>
        {
            return new NAVWARNAreaAffectedViewModel();
        } }, { "TextPlacement", () =>
        {
            return new TextPlacementViewModel();
        } }, { "AreaAffected", () =>
        {
            return new AreaAffectedViewModel();
        } }, { "TextAssociation", () =>
        {
            return new TextAssociationViewModel();
        } }, { "NWPreambleContent", () =>
        {
            return new NWPreambleContentViewModel();
        } }, { "NWReferences", () =>
        {
            return new NWReferencesViewModel();
        } }, });
    }

    public class Handles : iHandles {
        public static IDictionary<Type, Func<InformationAssociationConnector[]>> AssociationConnectorInformations => new Dictionary<Type, Func<InformationAssociationConnector[]>>
        {
            {
                typeof(NWReferencesViewModel),
                () => [new InformationAssociationConnector<NAVWARNPreamble>()
                {
                    roleType = roleType.association,
                    role = "theReferences",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = ["References"],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<NWReferencesViewModel.theReferencesNAVWARNPreambleRefIdViewModel>("NWReferences"),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<NAVWARNPreambleViewModel.NAVWARNPreambleRefIdViewModel>("NAVWARNPreamble"),
                }

                ]
            },
            {
                typeof(NWPreambleContentViewModel),
                () => [new InformationAssociationConnector<NAVWARNPart>()
                {
                    roleType = roleType.association,
                    role = "header",
                    Lower = 1,
                    Upper = 1,
                    AssociationTypes = ["NAVWARNPreamble"],
                    CreateForeignInformationBinding = () => new SingleInformationBindingViewModel<NWPreambleContentViewModel.headerNAVWARNPartRefIdViewModel>("NWPreambleContent"),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<NAVWARNPartViewModel.NAVWARNPartRefIdViewModel>("NAVWARNPart"),
                }

                ]
            },
        };
        public static IDictionary<Type, Func<FeatureAssociationConnector[]>> AssociationConnectorFeatures => new Dictionary<Type, Func<FeatureAssociationConnector[]>>
        {
            {
                typeof(TextAssociationViewModel),
                () => [new FeatureAssociationConnector<TextPlacement>()
                {
                    roleType = roleType.composition,
                    role = "identifies",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = ["NAVWARNPart"],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<TextAssociationViewModel.identifiesTextPlacementRefIdViewModel>("TextAssociation"),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<TextPlacementViewModel.TextPlacementRefIdViewModel>("TextPlacement"),
                }, new FeatureAssociationConnector<NAVWARNPart>()
                {
                    roleType = roleType.association,
                    role = "positions",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = ["TextPlacement"],
                    CreateForeignFeatureBinding = () => new MultiFeatureBindingViewModel<TextAssociationViewModel.positionsNAVWARNPartRefIdViewModel>("TextAssociation"),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<NAVWARNPartViewModel.NAVWARNPartRefIdViewModel>("NAVWARNPart"),
                }

                ]
            },
            {
                typeof(AreaAffectedViewModel),
                () => [new FeatureAssociationConnector<NAVWARNPart>()
                {
                    roleType = roleType.association,
                    role = "affects",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = ["NAVWARNAreaAffected"],
                    CreateForeignFeatureBinding = () => new MultiFeatureBindingViewModel<AreaAffectedViewModel.affectsNAVWARNPartRefIdViewModel>("AreaAffected"),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<NAVWARNPartViewModel.NAVWARNPartRefIdViewModel>("NAVWARNPart"),
                }, new FeatureAssociationConnector<NAVWARNAreaAffected>()
                {
                    roleType = roleType.association,
                    role = "impacts",
                    Lower = 1,
                    Upper = 1,
                    AssociationTypes = ["NAVWARNPart"],
                    CreateForeignFeatureBinding = () => new SingleFeatureBindingViewModel<AreaAffectedViewModel.impactsNAVWARNAreaAffectedRefIdViewModel>("AreaAffected"),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<NAVWARNAreaAffectedViewModel.NAVWARNAreaAffectedRefIdViewModel>("NAVWARNAreaAffected"),
                }

                ]
            },
        };
    }

    [CategoryOrder("featureName", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class featureNameViewModel : ViewModelBase {
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

        public void Load(DomainModel.S124.ComplexAttributes.featureName instance) {
            language = instance.language;
            name = instance.name;
            nameUsage = instance.nameUsage;
        }

        public override string Serialize() {
            var instance = new DomainModel.S124.ComplexAttributes.featureName
            {
                language = this.language,
                name = this.name,
                nameUsage = this.nameUsage,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S124.ComplexAttributes.featureName Model => new()
        {
            language = this._language,
            name = this._name,
            nameUsage = this._nameUsage,
        };

        public featureNameViewModel() : base() {
        }

        public override string? ToString() => $"Feature Name";
    }

    [CategoryOrder("dateTimeRange", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class dateTimeRangeViewModel : ViewModelBase {
        private DateTime _dateTimeEnd;
        [Category("dateTimeRange")]
        public DateTime dateTimeEnd {
            get {
                return _dateTimeEnd;
            }

            set {
                SetValue(ref _dateTimeEnd, value);
            }
        }

        private DateTime _dateTimeStart;
        [Category("dateTimeRange")]
        public DateTime dateTimeStart {
            get {
                return _dateTimeStart;
            }

            set {
                SetValue(ref _dateTimeStart, value);
            }
        }

        public void Load(DomainModel.S124.ComplexAttributes.dateTimeRange instance) {
            dateTimeEnd = instance.dateTimeEnd;
            dateTimeStart = instance.dateTimeStart;
        }

        public override string Serialize() {
            var instance = new DomainModel.S124.ComplexAttributes.dateTimeRange
            {
                dateTimeEnd = this.dateTimeEnd,
                dateTimeStart = this.dateTimeStart,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S124.ComplexAttributes.dateTimeRange Model => new()
        {
            dateTimeEnd = this._dateTimeEnd,
            dateTimeStart = this._dateTimeStart,
        };

        public dateTimeRangeViewModel() : base() {
        }

        public override string? ToString() => $"Date Time Range";
    }

    [CategoryOrder("eNCFeatureReference", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class eNCFeatureReferenceViewModel : ViewModelBase {
        private String _editionNumber = string.Empty;
        [Category("eNCFeatureReference")]
        public String editionNumber {
            get {
                return _editionNumber;
            }

            set {
                SetValue(ref _editionNumber, value);
            }
        }

        private String _eNCName = string.Empty;
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
        public ObservableCollection<String> featureObjectIdentifier { get; set; } = new();

        private String _updateNumber = string.Empty;
        [Category("eNCFeatureReference")]
        public String updateNumber {
            get {
                return _updateNumber;
            }

            set {
                SetValue(ref _updateNumber, value);
            }
        }

        public void Load(DomainModel.S124.ComplexAttributes.eNCFeatureReference instance) {
            editionNumber = instance.editionNumber;
            eNCName = instance.eNCName;
            featureObjectIdentifier.Clear();
            if (instance.featureObjectIdentifier is not null)
                foreach (var e in instance.featureObjectIdentifier)
                    featureObjectIdentifier.Add(e);
            updateNumber = instance.updateNumber;
        }

        public override string Serialize() {
            var instance = new DomainModel.S124.ComplexAttributes.eNCFeatureReference
            {
                editionNumber = this.editionNumber,
                eNCName = this.eNCName,
                featureObjectIdentifier = this.featureObjectIdentifier.ToList(),
                updateNumber = this.updateNumber,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S124.ComplexAttributes.eNCFeatureReference Model => new()
        {
            editionNumber = this._editionNumber,
            eNCName = this._eNCName,
            featureObjectIdentifier = this.featureObjectIdentifier.ToList(),
            updateNumber = this._updateNumber,
        };

        public eNCFeatureReferenceViewModel() : base() {
            featureObjectIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureObjectIdentifier));
            };
        }

        public override string? ToString() => $"ENC Feature Reference";
    }

    [CategoryOrder("featureReference", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class featureReferenceViewModel : ViewModelBase {
        [Category("featureReference")]
        public ObservableCollection<String> featureIdentifier { get; set; } = new();

        private dateTimeRangeViewModel _dateTimeRange;
        [Category("featureReference")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public dateTimeRangeViewModel dateTimeRange {
            get {
                return _dateTimeRange;
            }

            set {
                SetValue(ref _dateTimeRange, value);
            }
        }

        [Category("featureReference")]
        public ObservableCollection<String> atoNNumber { get; set; } = new();

        [Category("featureReference")]
        public ObservableCollection<eNCFeatureReference> eNCFeatureReference { get; set; } = new();

        public void Load(DomainModel.S124.ComplexAttributes.featureReference instance) {
            featureIdentifier.Clear();
            if (instance.featureIdentifier is not null)
                foreach (var e in instance.featureIdentifier)
                    featureIdentifier.Add(e);
            dateTimeRange = new();
            if (instance.dateTimeRange != null) {
                dateTimeRange = new();
                dateTimeRange.Load(instance.dateTimeRange);
            }

            atoNNumber.Clear();
            if (instance.atoNNumber is not null)
                foreach (var e in instance.atoNNumber)
                    atoNNumber.Add(e);
            eNCFeatureReference.Clear();
            if (instance.eNCFeatureReference is not null)
                foreach (var e in instance.eNCFeatureReference)
                    eNCFeatureReference.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S124.ComplexAttributes.featureReference
            {
                featureIdentifier = this.featureIdentifier.ToList(),
                dateTimeRange = this.dateTimeRange?.Model,
                atoNNumber = this.atoNNumber.ToList(),
                eNCFeatureReference = this.eNCFeatureReference.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S124.ComplexAttributes.featureReference Model => new()
        {
            featureIdentifier = this.featureIdentifier.ToList(),
            dateTimeRange = this._dateTimeRange?.Model,
            atoNNumber = this.atoNNumber.ToList(),
            eNCFeatureReference = this.eNCFeatureReference.ToList(),
        };

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

        public override string? ToString() => $"Feature Reference";
    }

    [CategoryOrder("fixedDateRange", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class fixedDateRangeViewModel : ViewModelBase {
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

        public void Load(DomainModel.S124.ComplexAttributes.fixedDateRange instance) {
            dateEnd = instance.dateEnd;
            dateStart = instance.dateStart;
        }

        public override string Serialize() {
            var instance = new DomainModel.S124.ComplexAttributes.fixedDateRange
            {
                dateEnd = this.dateEnd,
                dateStart = this.dateStart,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S124.ComplexAttributes.fixedDateRange Model => new()
        {
            dateEnd = this._dateEnd,
            dateStart = this._dateStart,
        };

        public fixedDateRangeViewModel() : base() {
        }

        public override string? ToString() => $"Fixed Date Range";
    }

#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    [CategoryOrder("information", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class informationViewModel : ViewModelBase
#pragma warning restore CS8981
    {
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

        public void Load(DomainModel.S124.ComplexAttributes.information instance) {
            fileLocator = instance.fileLocator;
            fileReference = instance.fileReference;
            headline = instance.headline;
            language = instance.language;
            text = instance.text;
        }

        public override string Serialize() {
            var instance = new DomainModel.S124.ComplexAttributes.information
            {
                fileLocator = this.fileLocator,
                fileReference = this.fileReference,
                headline = this.headline,
                language = this.language,
                text = this.text,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S124.ComplexAttributes.information Model => new()
        {
            fileLocator = this._fileLocator,
            fileReference = this._fileReference,
            headline = this._headline,
            language = this._language,
            text = this._text,
        };

        public informationViewModel() : base() {
        }

        public override string? ToString() => $"Information";
    }

    [CategoryOrder("warningInformation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class warningInformationViewModel : ViewModelBase {
        private informationViewModel? _information;
        [Category("warningInformation")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public informationViewModel? information {
            get {
                return _information;
            }

            set {
                SetValue(ref _information, value);
            }
        }

        [DomainModel.CodeList(nameof(navwarnTypeDetailsList))]
        [Editor(typeof(Editors.CodeListCheckComboEditor), typeof(Editors.CodeListCheckComboEditor))]
        [Category("warningInformation")]
        public ObservableCollection<navwarnTypeDetails> navwarnTypeDetails { get; set; } = new();

        [Browsable(false)]
        public navwarnTypeDetails[] navwarnTypeDetailsList => CodeList.navwarnTypeDetails.ToArray();

        public void Load(DomainModel.S124.ComplexAttributes.warningInformation instance) {
            information = new();
            if (instance.information != null) {
                information = new();
                information.Load(instance.information);
            }

            navwarnTypeDetails.Clear();
            if (instance.navwarnTypeDetails is not null)
                foreach (var e in instance.navwarnTypeDetails)
                    navwarnTypeDetails.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S124.ComplexAttributes.warningInformation
            {
                information = this.information?.Model,
                navwarnTypeDetails = this.navwarnTypeDetails.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S124.ComplexAttributes.warningInformation Model => new()
        {
            information = this._information?.Model,
            navwarnTypeDetails = this.navwarnTypeDetails.ToList(),
        };

        public warningInformationViewModel() : base() {
            navwarnTypeDetails.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(navwarnTypeDetails));
            };
        }

        public override string? ToString() => $"Warning Information";
    }

    [CategoryOrder("chartAffected", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class chartAffectedViewModel : ViewModelBase {
        private String _chartNumber = string.Empty;
        [Category("chartAffected")]
        public String chartNumber {
            get {
                return _chartNumber;
            }

            set {
                SetValue(ref _chartNumber, value);
            }
        }

        private String _chartPlanNumber = string.Empty;
        [Category("chartAffected")]
        public String chartPlanNumber {
            get {
                return _chartPlanNumber;
            }

            set {
                SetValue(ref _chartPlanNumber, value);
            }
        }

        private DateTime _editionDate;
        [Category("chartAffected")]
        public DateTime editionDate {
            get {
                return _editionDate;
            }

            set {
                SetValue(ref _editionDate, value);
            }
        }

        private DateTime? _lastNoticeDate = default;
        [Category("chartAffected")]
        public DateTime? lastNoticeDate {
            get {
                return _lastNoticeDate;
            }

            set {
                SetValue(ref _lastNoticeDate, value);
            }
        }

        public void Load(DomainModel.S124.ComplexAttributes.chartAffected instance) {
            chartNumber = instance.chartNumber;
            chartPlanNumber = instance.chartPlanNumber;
            editionDate = instance.editionDate;
            lastNoticeDate = instance.lastNoticeDate;
        }

        public override string Serialize() {
            var instance = new DomainModel.S124.ComplexAttributes.chartAffected
            {
                chartNumber = this.chartNumber,
                chartPlanNumber = this.chartPlanNumber,
                editionDate = this.editionDate,
                lastNoticeDate = this.lastNoticeDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S124.ComplexAttributes.chartAffected Model => new()
        {
            chartNumber = this._chartNumber,
            chartPlanNumber = this._chartPlanNumber,
            editionDate = this._editionDate,
            lastNoticeDate = this._lastNoticeDate,
        };

        public chartAffectedViewModel() : base() {
        }

        public override string? ToString() => $"Chart Affected";
    }

    [CategoryOrder("affectedChartPublications", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class affectedChartPublicationsViewModel : ViewModelBase {
        private chartAffectedViewModel? _chartAffected;
        [Category("affectedChartPublications")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public chartAffectedViewModel? chartAffected {
            get {
                return _chartAffected;
            }

            set {
                SetValue(ref _chartAffected, value);
            }
        }

        private String _chartPublicationIdentifier = string.Empty;
        [Category("affectedChartPublications")]
        public String chartPublicationIdentifier {
            get {
                return _chartPublicationIdentifier;
            }

            set {
                SetValue(ref _chartPublicationIdentifier, value);
            }
        }

        private String _internationalChartAffected = string.Empty;
        [Category("affectedChartPublications")]
        public String internationalChartAffected {
            get {
                return _internationalChartAffected;
            }

            set {
                SetValue(ref _internationalChartAffected, value);
            }
        }

        private String _language = string.Empty;
        [Category("affectedChartPublications")]
        public String language {
            get {
                return _language;
            }

            set {
                SetValue(ref _language, value);
            }
        }

        private String _publicationAffected = string.Empty;
        [Category("affectedChartPublications")]
        public String publicationAffected {
            get {
                return _publicationAffected;
            }

            set {
                SetValue(ref _publicationAffected, value);
            }
        }

        public void Load(DomainModel.S124.ComplexAttributes.affectedChartPublications instance) {
            chartAffected = new();
            if (instance.chartAffected != null) {
                chartAffected = new();
                chartAffected.Load(instance.chartAffected);
            }

            chartPublicationIdentifier = instance.chartPublicationIdentifier;
            internationalChartAffected = instance.internationalChartAffected;
            language = instance.language;
            publicationAffected = instance.publicationAffected;
        }

        public override string Serialize() {
            var instance = new DomainModel.S124.ComplexAttributes.affectedChartPublications
            {
                chartAffected = this.chartAffected?.Model,
                chartPublicationIdentifier = this.chartPublicationIdentifier,
                internationalChartAffected = this.internationalChartAffected,
                language = this.language,
                publicationAffected = this.publicationAffected,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S124.ComplexAttributes.affectedChartPublications Model => new()
        {
            chartAffected = this._chartAffected?.Model,
            chartPublicationIdentifier = this._chartPublicationIdentifier,
            internationalChartAffected = this._internationalChartAffected,
            language = this._language,
            publicationAffected = this._publicationAffected,
        };

        public affectedChartPublicationsViewModel() : base() {
        }

        public override string? ToString() => $"Affected Chart Publications";
    }

    [CategoryOrder("locationName", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class locationNameViewModel : ViewModelBase {
        private String _language = string.Empty;
        [Category("locationName")]
        public String language {
            get {
                return _language;
            }

            set {
                SetValue(ref _language, value);
            }
        }

        private String _text = string.Empty;
        [Category("locationName")]
        public String text {
            get {
                return _text;
            }

            set {
                SetValue(ref _text, value);
            }
        }

        public void Load(DomainModel.S124.ComplexAttributes.locationName instance) {
            language = instance.language;
            text = instance.text;
        }

        public override string Serialize() {
            var instance = new DomainModel.S124.ComplexAttributes.locationName
            {
                language = this.language,
                text = this.text,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S124.ComplexAttributes.locationName Model => new()
        {
            language = this._language,
            text = this._text,
        };

        public locationNameViewModel() : base() {
        }

        public override string? ToString() => $"Location Name";
    }

    [CategoryOrder("generalArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class generalAreaViewModel : ViewModelBase {
        private String _localityIdentifier = string.Empty;
        [Category("generalArea")]
        public String localityIdentifier {
            get {
                return _localityIdentifier;
            }

            set {
                SetValue(ref _localityIdentifier, value);
            }
        }

        [Category("generalArea")]
        public ObservableCollection<locationName> locationName { get; set; } = new();

        public void Load(DomainModel.S124.ComplexAttributes.generalArea instance) {
            localityIdentifier = instance.localityIdentifier;
            locationName.Clear();
            if (instance.locationName is not null)
                foreach (var e in instance.locationName)
                    locationName.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S124.ComplexAttributes.generalArea
            {
                localityIdentifier = this.localityIdentifier,
                locationName = this.locationName.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S124.ComplexAttributes.generalArea Model => new()
        {
            localityIdentifier = this._localityIdentifier,
            locationName = this.locationName.ToList(),
        };

        public generalAreaViewModel() : base() {
            locationName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(locationName));
            };
        }

        public override string? ToString() => $"General Area";
    }

#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    [CategoryOrder("locality", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class localityViewModel : ViewModelBase
#pragma warning restore CS8981
    {
        private String _localityIdentifier = string.Empty;
        [Category("locality")]
        public String localityIdentifier {
            get {
                return _localityIdentifier;
            }

            set {
                SetValue(ref _localityIdentifier, value);
            }
        }

        [Category("locality")]
        public ObservableCollection<locationName> locationName { get; set; } = new();

        public void Load(DomainModel.S124.ComplexAttributes.locality instance) {
            localityIdentifier = instance.localityIdentifier;
            locationName.Clear();
            if (instance.locationName is not null)
                foreach (var e in instance.locationName)
                    locationName.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S124.ComplexAttributes.locality
            {
                localityIdentifier = this.localityIdentifier,
                locationName = this.locationName.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S124.ComplexAttributes.locality Model => new()
        {
            localityIdentifier = this._localityIdentifier,
            locationName = this.locationName.ToList(),
        };

        public localityViewModel() : base() {
            locationName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(locationName));
            };
        }

        public override string? ToString() => $"Locality";
    }

    [CategoryOrder("messageSeriesIdentifier", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class messageSeriesIdentifierViewModel : ViewModelBase {
        private String _agencyResponsibleForProduction = string.Empty;
        [Category("messageSeriesIdentifier")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        private String _countryName = string.Empty;
        [Category("messageSeriesIdentifier")]
        public String countryName {
            get {
                return _countryName;
            }

            set {
                SetValue(ref _countryName, value);
            }
        }

        private String _nameOfSeries = string.Empty;
        [Category("messageSeriesIdentifier")]
        public String nameOfSeries {
            get {
                return _nameOfSeries;
            }

            set {
                SetValue(ref _nameOfSeries, value);
            }
        }

        private String _warningIdentifier = string.Empty;
        [Category("messageSeriesIdentifier")]
        public String warningIdentifier {
            get {
                return _warningIdentifier;
            }

            set {
                SetValue(ref _warningIdentifier, value);
            }
        }

        private Int32 _warningNumber;
        [Category("messageSeriesIdentifier")]
        public Int32 warningNumber {
            get {
                return _warningNumber;
            }

            set {
                SetValue(ref _warningNumber, value);
            }
        }

        private warningType _warningType;
        [Category("messageSeriesIdentifier")]
        public warningType warningType {
            get {
                return _warningType;
            }

            set {
                SetValue(ref _warningType, value);
            }
        }

        private Int32 _year;
        [Category("messageSeriesIdentifier")]
        public Int32 year {
            get {
                return _year;
            }

            set {
                SetValue(ref _year, value);
            }
        }

        public void Load(DomainModel.S124.ComplexAttributes.messageSeriesIdentifier instance) {
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            countryName = instance.countryName;
            nameOfSeries = instance.nameOfSeries;
            warningIdentifier = instance.warningIdentifier;
            warningNumber = instance.warningNumber;
            warningType = instance.warningType;
            year = instance.year;
        }

        public override string Serialize() {
            var instance = new DomainModel.S124.ComplexAttributes.messageSeriesIdentifier
            {
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

        [Browsable(false)]
        public DomainModel.S124.ComplexAttributes.messageSeriesIdentifier Model => new()
        {
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            countryName = this._countryName,
            nameOfSeries = this._nameOfSeries,
            warningIdentifier = this._warningIdentifier,
            warningNumber = this._warningNumber,
            warningType = this._warningType,
            year = this._year,
        };

        public messageSeriesIdentifierViewModel() : base() {
        }

        public override string? ToString() => $"Message Series Identifier";
    }

    [CategoryOrder("nAVWARNTitle", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class nAVWARNTitleViewModel : ViewModelBase {
        private String _language = string.Empty;
        [Category("nAVWARNTitle")]
        public String language {
            get {
                return _language;
            }

            set {
                SetValue(ref _language, value);
            }
        }

        private String _text = string.Empty;
        [Category("nAVWARNTitle")]
        public String text {
            get {
                return _text;
            }

            set {
                SetValue(ref _text, value);
            }
        }

        public void Load(DomainModel.S124.ComplexAttributes.nAVWARNTitle instance) {
            language = instance.language;
            text = instance.text;
        }

        public override string Serialize() {
            var instance = new DomainModel.S124.ComplexAttributes.nAVWARNTitle
            {
                language = this.language,
                text = this.text,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S124.ComplexAttributes.nAVWARNTitle Model => new()
        {
            language = this._language,
            text = this._text,
        };

        public nAVWARNTitleViewModel() : base() {
        }

        public override string? ToString() => $"NAVWARN Title";
    }

    [CategoryOrder("NAVWARNPreamble", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class NAVWARNPreambleViewModel : ViewModelBase {
        [Category("NAVWARNPreamble")]
        public ObservableCollection<affectedChartPublications> affectedChartPublications { get; set; } = new();

        [Category("NAVWARNPreamble")]
        public ObservableCollection<generalArea> generalArea { get; set; } = new();

        [Category("NAVWARNPreamble")]
        public ObservableCollection<locality> locality { get; set; } = new();

        private messageSeriesIdentifierViewModel _messageSeriesIdentifier;
        [Category("NAVWARNPreamble")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public messageSeriesIdentifierViewModel messageSeriesIdentifier {
            get {
                return _messageSeriesIdentifier;
            }

            set {
                SetValue(ref _messageSeriesIdentifier, value);
            }
        }

        [Category("NAVWARNPreamble")]
        public ObservableCollection<nAVWARNTitle> nAVWARNTitle { get; set; } = new();

        private DateTime? _cancellationDate = default;
        [Category("NAVWARNPreamble")]
        public DateTime? cancellationDate {
            get {
                return _cancellationDate;
            }

            set {
                SetValue(ref _cancellationDate, value);
            }
        }

        private Boolean _intService;
        [Category("NAVWARNPreamble")]
        public Boolean intService {
            get {
                return _intService;
            }

            set {
                SetValue(ref _intService, value);
            }
        }

        private navwarnTypeGeneral _navwarnTypeGeneral;
        [DomainModel.CodeList(nameof(navwarnTypeGeneralList))]
        [Editor(typeof(Editors.CodeListComboEditor), typeof(Editors.CodeListComboEditor))]
        [Category("NAVWARNPreamble")]
        public navwarnTypeGeneral navwarnTypeGeneral {
            get {
                return _navwarnTypeGeneral;
            }

            set {
                SetValue(ref _navwarnTypeGeneral, value);
            }
        }

        private DateTime _publicationTime;
        [Category("NAVWARNPreamble")]
        public DateTime publicationTime {
            get {
                return _publicationTime;
            }

            set {
                SetValue(ref _publicationTime, value);
            }
        }

        public class NAVWARNPreambleRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["NAVWARNPreamble"];
        }

        [Browsable(false)]
        public navwarnTypeGeneral[] navwarnTypeGeneralList => CodeList.navwarnTypeGenerals.ToArray();

        public void Load(DomainModel.S124.InformationTypes.NAVWARNPreamble instance) {
            affectedChartPublications.Clear();
            if (instance.affectedChartPublications is not null)
                foreach (var e in instance.affectedChartPublications)
                    affectedChartPublications.Add(e);
            generalArea.Clear();
            if (instance.generalArea is not null)
                foreach (var e in instance.generalArea)
                    generalArea.Add(e);
            locality.Clear();
            if (instance.locality is not null)
                foreach (var e in instance.locality)
                    locality.Add(e);
            messageSeriesIdentifier = new();
            if (instance.messageSeriesIdentifier != null) {
                messageSeriesIdentifier = new();
                messageSeriesIdentifier.Load(instance.messageSeriesIdentifier);
            }

            nAVWARNTitle.Clear();
            if (instance.nAVWARNTitle is not null)
                foreach (var e in instance.nAVWARNTitle)
                    nAVWARNTitle.Add(e);
            cancellationDate = instance.cancellationDate;
            intService = instance.intService;
            navwarnTypeGeneral = instance.navwarnTypeGeneral;
            publicationTime = instance.publicationTime;
        }

        public override string Serialize() {
            var instance = new DomainModel.S124.InformationTypes.NAVWARNPreamble
            {
                affectedChartPublications = this.affectedChartPublications.ToList(),
                generalArea = this.generalArea.ToList(),
                locality = this.locality.ToList(),
                messageSeriesIdentifier = this.messageSeriesIdentifier?.Model,
                nAVWARNTitle = this.nAVWARNTitle.ToList(),
                cancellationDate = this.cancellationDate,
                intService = this.intService,
                navwarnTypeGeneral = this.navwarnTypeGeneral,
                publicationTime = this.publicationTime,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S124.InformationTypes.NAVWARNPreamble Model => new()
        {
            affectedChartPublications = this.affectedChartPublications.ToList(),
            generalArea = this.generalArea.ToList(),
            locality = this.locality.ToList(),
            messageSeriesIdentifier = this._messageSeriesIdentifier?.Model,
            nAVWARNTitle = this.nAVWARNTitle.ToList(),
            cancellationDate = this._cancellationDate,
            intService = this._intService,
            navwarnTypeGeneral = this._navwarnTypeGeneral,
            publicationTime = this._publicationTime,
        };

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

        public override string? ToString() => $"NAVWARN Preamble";
    }

    [CategoryOrder("References", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ReferencesViewModel : ViewModelBase {
        [Category("References")]
        public ObservableCollection<messageSeriesIdentifier> messageSeriesIdentifier { get; set; } = new();

        private Boolean _noMessageOnHand;
        [Category("References")]
        public Boolean noMessageOnHand {
            get {
                return _noMessageOnHand;
            }

            set {
                SetValue(ref _noMessageOnHand, value);
            }
        }

        private referenceCategory _referenceCategory;
        [Category("References")]
        public referenceCategory referenceCategory {
            get {
                return _referenceCategory;
            }

            set {
                SetValue(ref _referenceCategory, value);
            }
        }

        public class ReferencesRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["References"];
        }

        public void Load(DomainModel.S124.InformationTypes.References instance) {
            messageSeriesIdentifier.Clear();
            if (instance.messageSeriesIdentifier is not null)
                foreach (var e in instance.messageSeriesIdentifier)
                    messageSeriesIdentifier.Add(e);
            noMessageOnHand = instance.noMessageOnHand;
            referenceCategory = instance.referenceCategory;
        }

        public override string Serialize() {
            var instance = new DomainModel.S124.InformationTypes.References
            {
                messageSeriesIdentifier = this.messageSeriesIdentifier.ToList(),
                noMessageOnHand = this.noMessageOnHand,
                referenceCategory = this.referenceCategory,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S124.InformationTypes.References Model => new()
        {
            messageSeriesIdentifier = this.messageSeriesIdentifier.ToList(),
            noMessageOnHand = this._noMessageOnHand,
            referenceCategory = this._referenceCategory,
        };

        public ReferencesViewModel() : base() {
            messageSeriesIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(messageSeriesIdentifier));
            };
        }

        public override string? ToString() => $"References";
    }

    [CategoryOrder("NAVWARNPart", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class NAVWARNPartViewModel : ViewModelBase {
        [Category("NAVWARNPart")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        [Category("NAVWARNPart")]
        public ObservableCollection<featureReference> featureReference { get; set; } = new();

        [Category("NAVWARNPart")]
        public ObservableCollection<fixedDateRange> fixedDateRange { get; set; } = new();

        private warningInformationViewModel _warningInformation;
        [Category("NAVWARNPart")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public warningInformationViewModel warningInformation {
            get {
                return _warningInformation;
            }

            set {
                SetValue(ref _warningInformation, value);
            }
        }

        private restriction? _restriction = default;
        [Category("NAVWARNPart")]
        public restriction? restriction {
            get {
                return _restriction;
            }

            set {
                SetValue(ref _restriction, value);
            }
        }

        public class NAVWARNPartRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["NAVWARNPart"];
        }

        public void Load(DomainModel.S124.FeatureTypes.NAVWARNPart instance) {
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            featureReference.Clear();
            if (instance.featureReference is not null)
                foreach (var e in instance.featureReference)
                    featureReference.Add(e);
            fixedDateRange.Clear();
            if (instance.fixedDateRange is not null)
                foreach (var e in instance.fixedDateRange)
                    fixedDateRange.Add(e);
            warningInformation = new();
            if (instance.warningInformation != null) {
                warningInformation = new();
                warningInformation.Load(instance.warningInformation);
            }

            restriction = instance.restriction;
        }

        public override string Serialize() {
            var instance = new DomainModel.S124.FeatureTypes.NAVWARNPart
            {
                featureName = this.featureName.ToList(),
                featureReference = this.featureReference.ToList(),
                fixedDateRange = this.fixedDateRange.ToList(),
                warningInformation = this.warningInformation?.Model,
                restriction = this.restriction,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S124.FeatureTypes.NAVWARNPart Model => new()
        {
            featureName = this.featureName.ToList(),
            featureReference = this.featureReference.ToList(),
            fixedDateRange = this.fixedDateRange.ToList(),
            warningInformation = this._warningInformation?.Model,
            restriction = this._restriction,
        };

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

        public override string? ToString() => $"NAVWARN Part";
    }

    [CategoryOrder("NAVWARNAreaAffected", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class NAVWARNAreaAffectedViewModel : ViewModelBase {
        public class NAVWARNAreaAffectedRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["NAVWARNAreaAffected"];
        }

        public void Load(DomainModel.S124.FeatureTypes.NAVWARNAreaAffected instance) {
        }

        public override string Serialize() {
            var instance = new DomainModel.S124.FeatureTypes.NAVWARNAreaAffected
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S124.FeatureTypes.NAVWARNAreaAffected Model => new()
        {
        };

        public NAVWARNAreaAffectedViewModel() : base() {
        }

        public override string? ToString() => $"NAVWARN Area Affected";
    }

    [CategoryOrder("TextPlacement", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class TextPlacementViewModel : ViewModelBase {
        private String _text = string.Empty;
        [Category("TextPlacement")]
        public String text {
            get {
                return _text;
            }

            set {
                SetValue(ref _text, value);
            }
        }

        private Int32 _textOffsetBearing;
        [Category("TextPlacement")]
        public Int32 textOffsetBearing {
            get {
                return _textOffsetBearing;
            }

            set {
                SetValue(ref _textOffsetBearing, value);
            }
        }

        private Int32 _textOffsetDistance;
        [Category("TextPlacement")]
        public Int32 textOffsetDistance {
            get {
                return _textOffsetDistance;
            }

            set {
                SetValue(ref _textOffsetDistance, value);
            }
        }

        private Boolean? _textRotation = default;
        [Category("TextPlacement")]
        public Boolean? textRotation {
            get {
                return _textRotation;
            }

            set {
                SetValue(ref _textRotation, value);
            }
        }

        private textType? _textType = default;
        [Category("TextPlacement")]
        public textType? textType {
            get {
                return _textType;
            }

            set {
                SetValue(ref _textType, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("TextPlacement")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        public class TextPlacementRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["TextPlacement"];
        }

        public void Load(DomainModel.S124.FeatureTypes.TextPlacement instance) {
            text = instance.text;
            textOffsetBearing = instance.textOffsetBearing;
            textOffsetDistance = instance.textOffsetDistance;
            textRotation = instance.textRotation;
            textType = instance.textType;
            scaleMinimum = instance.scaleMinimum;
        }

        public override string Serialize() {
            var instance = new DomainModel.S124.FeatureTypes.TextPlacement
            {
                text = this.text,
                textOffsetBearing = this.textOffsetBearing,
                textOffsetDistance = this.textOffsetDistance,
                textRotation = this.textRotation,
                textType = this.textType,
                scaleMinimum = this.scaleMinimum,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S124.FeatureTypes.TextPlacement Model => new()
        {
            text = this._text,
            textOffsetBearing = this._textOffsetBearing,
            textOffsetDistance = this._textOffsetDistance,
            textRotation = this._textRotation,
            textType = this._textType,
            scaleMinimum = this._scaleMinimum,
        };

        public TextPlacementViewModel() : base() {
        }

        public override string? ToString() => $"Text Placement";
    }

    public class AreaAffectedViewModel : FeatureAssociationViewModel {
        public override string Code => "AreaAffected";
        public override string[] Roles => ["affects", "impacts"];

        private FeatureBindingViewModel? _affects;
        [ExpandableObject]
        public FeatureBindingViewModel? affects {
            get {
                return _affects;
            }

            set {
                this.SetValue(ref _affects, value);
            }
        }

        private FeatureBindingViewModel? _impacts;
        [ExpandableObject]
        public FeatureBindingViewModel? impacts {
            get {
                return _impacts;
            }

            set {
                this.SetValue(ref _impacts, value);
            }
        }

        public override FeatureAssociationConnector? association {
            get {
                return _associationConnector;
            }

            set {
                this.SetValue(ref _associationConnector, value);
                if (value is not null) {
                    affects = value?.role switch
                    {
                        "impacts" => value.CreateForeignFeatureBinding(),
                        _ => value!.CreateLocalFeatureBinding(),
                    };
                }
                else {
                    affects = null;
                }

                if (value is not null) {
                    impacts = value?.role switch
                    {
                        "affects" => value.CreateForeignFeatureBinding(),
                        _ => value!.CreateLocalFeatureBinding(),
                    };
                }
                else {
                    impacts = null;
                }
            }
        }

        public override void Load(S100Framework.DomainModel.FeatureAssociation featureAssociation) {
            association = associationConnectorFeatures.SingleOrDefault(e => e.FeatureType.Equals(featureAssociation.AssociationConnectorTypeName));
            affects?.Load(featureAssociation, "affects");
            impacts?.Load(featureAssociation, "impacts");
        }

        public override string Serialize() {
            var instance = new FeatureAssociation
            {
                Code = this.Code,
                AssociationConnectorTypeName = association!.FeatureType,
            };
            affects?.Save(instance, "affects");
            impacts?.Save(instance, "impacts");
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public override FeatureAssociationConnector[] associationConnectorFeatures => AreaAffectedViewModel._associationConnectorFeatures;

        public class affectsNAVWARNPartRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["NAVWARNAreaAffected"];
        }

        public class impactsNAVWARNAreaAffectedRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["NAVWARNPart"];
        }

        public static FeatureAssociationConnector[] _associationConnectorFeatures => Handles.AssociationConnectorFeatures[typeof(AreaAffectedViewModel)]();
    }

    public class TextAssociationViewModel : FeatureAssociationViewModel {
        public override string Code => "TextAssociation";
        public override string[] Roles => ["identifies", "positions"];

        private FeatureBindingViewModel? _identifies;
        [ExpandableObject]
        public FeatureBindingViewModel? identifies {
            get {
                return _identifies;
            }

            set {
                this.SetValue(ref _identifies, value);
            }
        }

        private FeatureBindingViewModel? _positions;
        [ExpandableObject]
        public FeatureBindingViewModel? positions {
            get {
                return _positions;
            }

            set {
                this.SetValue(ref _positions, value);
            }
        }

        public override FeatureAssociationConnector? association {
            get {
                return _associationConnector;
            }

            set {
                this.SetValue(ref _associationConnector, value);
                if (value is not null) {
                    identifies = value?.role switch
                    {
                        "positions" => value.CreateForeignFeatureBinding(),
                        _ => value!.CreateLocalFeatureBinding(),
                    };
                }
                else {
                    identifies = null;
                }

                if (value is not null) {
                    positions = value?.role switch
                    {
                        "identifies" => value.CreateForeignFeatureBinding(),
                        _ => value!.CreateLocalFeatureBinding(),
                    };
                }
                else {
                    positions = null;
                }
            }
        }

        public override void Load(S100Framework.DomainModel.FeatureAssociation featureAssociation) {
            association = associationConnectorFeatures.SingleOrDefault(e => e.FeatureType.Equals(featureAssociation.AssociationConnectorTypeName));
            identifies?.Load(featureAssociation, "identifies");
            positions?.Load(featureAssociation, "positions");
        }

        public override string Serialize() {
            var instance = new FeatureAssociation
            {
                Code = this.Code,
                AssociationConnectorTypeName = association!.FeatureType,
            };
            identifies?.Save(instance, "identifies");
            positions?.Save(instance, "positions");
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public override FeatureAssociationConnector[] associationConnectorFeatures => TextAssociationViewModel._associationConnectorFeatures;

        public class identifiesTextPlacementRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["NAVWARNPart"];
        }

        public class positionsNAVWARNPartRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["TextPlacement"];
        }

        public static FeatureAssociationConnector[] _associationConnectorFeatures => Handles.AssociationConnectorFeatures[typeof(TextAssociationViewModel)]();
    }

    public class NWPreambleContentViewModel : InformationAssociationViewModel {
        public override string Code => "NWPreambleContent";
        public override string[] Roles => ["theWarningPart", "header"];

        private InformationBindingViewModel? _theWarningPart;
        [ExpandableObject]
        public InformationBindingViewModel? theWarningPart {
            get {
                return _theWarningPart;
            }

            set {
                this.SetValue(ref _theWarningPart, value);
            }
        }

        private InformationBindingViewModel? _header;
        [ExpandableObject]
        public InformationBindingViewModel? header {
            get {
                return _header;
            }

            set {
                this.SetValue(ref _header, value);
            }
        }

        public override InformationAssociationConnector? association {
            get {
                return _associationConnector;
            }

            set {
                this.SetValue(ref _associationConnector, value);
                if (value is not null) {
                    theWarningPart = value?.role switch
                    {
                        "header" => value.CreateForeignInformationBinding(),
                        _ => value!.CreateLocalInformationBinding(),
                    };
                }
                else {
                    theWarningPart = null;
                }

                if (value is not null) {
                    header = value?.role switch
                    {
                        "theWarningPart" => value.CreateForeignInformationBinding(),
                        _ => value!.CreateLocalInformationBinding(),
                    };
                }
                else {
                    header = null;
                }
            }
        }

        public override void Load(S100Framework.DomainModel.InformationAssociation informationAssociation) {
            association = associationConnectorInformations.SingleOrDefault(e => e.InformationType.Equals(informationAssociation.AssociationConnectorTypeName));
            theWarningPart?.Load(informationAssociation, "theWarningPart");
            header?.Load(informationAssociation, "header");
        }

        public override string Serialize() {
            var instance = new InformationAssociation
            {
                Code = this.Code,
                AssociationConnectorTypeName = association!.InformationType,
            };
            theWarningPart?.Save(instance, "theWarningPart");
            header?.Save(instance, "header");
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public override InformationAssociationConnector[] associationConnectorInformations => NWPreambleContentViewModel._associationConnectorInformations;

        public class headerNAVWARNPartRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["NAVWARNPreamble"];
        }

        public static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof(NWPreambleContentViewModel)]();
    }

    public class NWReferencesViewModel : InformationAssociationViewModel {
        public override string Code => "NWReferences";
        public override string[] Roles => ["theWarning", "theReferences"];

        private InformationBindingViewModel? _theWarning;
        [ExpandableObject]
        public InformationBindingViewModel? theWarning {
            get {
                return _theWarning;
            }

            set {
                this.SetValue(ref _theWarning, value);
            }
        }

        private InformationBindingViewModel? _theReferences;
        [ExpandableObject]
        public InformationBindingViewModel? theReferences {
            get {
                return _theReferences;
            }

            set {
                this.SetValue(ref _theReferences, value);
            }
        }

        public override InformationAssociationConnector? association {
            get {
                return _associationConnector;
            }

            set {
                this.SetValue(ref _associationConnector, value);
                if (value is not null) {
                    theWarning = value?.role switch
                    {
                        "theReferences" => value.CreateForeignInformationBinding(),
                        _ => value!.CreateLocalInformationBinding(),
                    };
                }
                else {
                    theWarning = null;
                }

                if (value is not null) {
                    theReferences = value?.role switch
                    {
                        "theWarning" => value.CreateForeignInformationBinding(),
                        _ => value!.CreateLocalInformationBinding(),
                    };
                }
                else {
                    theReferences = null;
                }
            }
        }

        public override void Load(S100Framework.DomainModel.InformationAssociation informationAssociation) {
            association = associationConnectorInformations.SingleOrDefault(e => e.InformationType.Equals(informationAssociation.AssociationConnectorTypeName));
            theWarning?.Load(informationAssociation, "theWarning");
            theReferences?.Load(informationAssociation, "theReferences");
        }

        public override string Serialize() {
            var instance = new InformationAssociation
            {
                Code = this.Code,
                AssociationConnectorTypeName = association!.InformationType,
            };
            theWarning?.Save(instance, "theWarning");
            theReferences?.Save(instance, "theReferences");
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public override InformationAssociationConnector[] associationConnectorInformations => NWReferencesViewModel._associationConnectorInformations;

        public class theReferencesNAVWARNPreambleRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["References"];
        }

        public static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof(NWReferencesViewModel)]();
    }
}