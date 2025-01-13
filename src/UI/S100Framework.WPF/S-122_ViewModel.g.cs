using S100Framework.DomainModel.Bindings;
using S100Framework.DomainModel.S122;
using S100Framework.DomainModel.S122.ComplexAttributes;
using S100Framework.DomainModel.S122.FeatureTypes;
using S100Framework.DomainModel.S122.InformationTypes;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;


namespace S100Framework.WPF.ViewModel.S122
{

    internal static class Preamble
    {
        public static ImmutableDictionary<string, Func<ViewModelBase>> _creators => ImmutableDictionary.Create<string, Func<ViewModelBase>>().AddRange(new Dictionary<string, Func<ViewModelBase>> {
            { typeof(DomainModel.S122.InformationTypes.InformationType).Name, ()=> {
                return new InformationTypeViewModel();
              }
            },
            { typeof(DomainModel.S122.InformationTypes.AbstractRxN).Name, ()=> {
                return new AbstractRxNViewModel();
              }
            },
            { typeof(DomainModel.S122.InformationTypes.NauticalInformation).Name, ()=> {
                return new NauticalInformationViewModel();
              }
            },
            { typeof(DomainModel.S122.InformationTypes.Regulations).Name, ()=> {
                return new RegulationsViewModel();
              }
            },
            { typeof(DomainModel.S122.InformationTypes.Restrictions).Name, ()=> {
                return new RestrictionsViewModel();
              }
            },
            { typeof(DomainModel.S122.InformationTypes.Recommendations).Name, ()=> {
                return new RecommendationsViewModel();
              }
            },
            { typeof(DomainModel.S122.InformationTypes.Authority).Name, ()=> {
                return new AuthorityViewModel();
              }
            },
            { typeof(DomainModel.S122.InformationTypes.ContactDetails).Name, ()=> {
                return new ContactDetailsViewModel();
              }
            },
            { typeof(DomainModel.S122.InformationTypes.NonStandardWorkingDay).Name, ()=> {
                return new NonStandardWorkingDayViewModel();
              }
            },
            { typeof(DomainModel.S122.InformationTypes.ServiceHours).Name, ()=> {
                return new ServiceHoursViewModel();
              }
            },
            { typeof(DomainModel.S122.InformationTypes.Applicability).Name, ()=> {
                return new ApplicabilityViewModel();
              }
            },
            { typeof(DomainModel.S122.FeatureTypes.RestrictedArea).Name, ()=> {
                return new RestrictedAreaViewModel();
              }
            },
            { typeof(DomainModel.S122.FeatureTypes.MarineProtectedArea).Name, ()=> {
                return new MarineProtectedAreaViewModel();
              }
            },
            { typeof(DomainModel.S122.FeatureTypes.VesselTrafficServiceArea).Name, ()=> {
                return new VesselTrafficServiceAreaViewModel();
              }
            },
            { typeof(DomainModel.S122.FeatureTypes.DataCoverage).Name, ()=> {
                return new DataCoverageViewModel();
              }
            },
            { typeof(DomainModel.S122.FeatureTypes.TextPlacement).Name, ()=> {
                return new TextPlacementViewModel();
              }
            },
        });
    }

    [CategoryOrder("contactAddress", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class contactAddressViewModel : ViewModelBase
    {
        private String _deliveryPoint = string.Empty;
        [Category("contactAddress")]
        public String deliveryPoint
        {
            get
            {
                return _deliveryPoint;
            }

            set
            {
                SetValue(ref _deliveryPoint, value);
            }
        }

        private String _cityName = string.Empty;
        [Category("contactAddress")]
        public String cityName
        {
            get
            {
                return _cityName;
            }

            set
            {
                SetValue(ref _cityName, value);
            }
        }

        private String _administrativeDivision = string.Empty;
        [Category("contactAddress")]
        public String administrativeDivision
        {
            get
            {
                return _administrativeDivision;
            }

            set
            {
                SetValue(ref _administrativeDivision, value);
            }
        }

        private String _countryName = string.Empty;
        [Category("contactAddress")]
        public String countryName
        {
            get
            {
                return _countryName;
            }

            set
            {
                SetValue(ref _countryName, value);
            }
        }

        private String _postalCode = string.Empty;
        [Category("contactAddress")]
        public String postalCode
        {
            get
            {
                return _postalCode;
            }

            set
            {
                SetValue(ref _postalCode, value);
            }
        }

        public void Load(DomainModel.S122.ComplexAttributes.contactAddress instance)
        {
            deliveryPoint = instance.deliveryPoint;
            cityName = instance.cityName;
            administrativeDivision = instance.administrativeDivision;
            countryName = instance.countryName;
            postalCode = instance.postalCode;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.ComplexAttributes.contactAddress
            {
                deliveryPoint = this.deliveryPoint,
                cityName = this.cityName,
                administrativeDivision = this.administrativeDivision,
                countryName = this.countryName,
                postalCode = this.postalCode,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.contactAddress Model => new()
        {
            deliveryPoint = this._deliveryPoint,
            cityName = this._cityName,
            administrativeDivision = this._administrativeDivision,
            countryName = this._countryName,
            postalCode = this._postalCode,
        };

        public contactAddressViewModel(IViewModelHost? host = null) : base(host)
        {
        }
    }

    [CategoryOrder("featureName", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class featureNameViewModel : ViewModelBase
    {
        private Boolean? _displayName = default;
        [Category("featureName")]
        public Boolean? displayName
        {
            get
            {
                return _displayName;
            }

            set
            {
                SetValue(ref _displayName, value);
            }
        }

        private String _language = string.Empty;
        [Category("featureName")]
        public String language
        {
            get
            {
                return _language;
            }

            set
            {
                SetValue(ref _language, value);
            }
        }

        private String _name = string.Empty;
        [Category("featureName")]
        public String name
        {
            get
            {
                return _name;
            }

            set
            {
                SetValue(ref _name, value);
            }
        }

        public void Load(DomainModel.S122.ComplexAttributes.featureName instance)
        {
            displayName = instance.displayName;
            language = instance.language;
            name = instance.name;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.ComplexAttributes.featureName
            {
                displayName = this.displayName,
                language = this.language,
                name = this.name,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.featureName Model => new()
        {
            displayName = this._displayName,
            language = this._language,
            name = this._name,
        };

        public featureNameViewModel(IViewModelHost? host = null) : base(host)
        {
        }
    }

    [CategoryOrder("fixedDateRange", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class fixedDateRangeViewModel : ViewModelBase
    {
        private DateOnly? _dateStart = default;
        [Category("fixedDateRange")]
        public DateOnly? dateStart
        {
            get
            {
                return _dateStart;
            }

            set
            {
                SetValue(ref _dateStart, value);
            }
        }

        private DateOnly? _dateEnd = default;
        [Category("fixedDateRange")]
        public DateOnly? dateEnd
        {
            get
            {
                return _dateEnd;
            }

            set
            {
                SetValue(ref _dateEnd, value);
            }
        }

        public void Load(DomainModel.S122.ComplexAttributes.fixedDateRange instance)
        {
            dateStart = instance.dateStart;
            dateEnd = instance.dateEnd;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.ComplexAttributes.fixedDateRange
            {
                dateStart = this.dateStart,
                dateEnd = this.dateEnd,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.fixedDateRange Model => new()
        {
            dateStart = this._dateStart,
            dateEnd = this._dateEnd,
        };

        public fixedDateRangeViewModel(IViewModelHost? host = null) : base(host)
        {
        }
    }

    [CategoryOrder("frequencyPair", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class frequencyPairViewModel : ViewModelBase
    {
        private Int32? _frequencyShoreStationReceives = default;
        [Category("frequencyPair")]
        public Int32? frequencyShoreStationReceives
        {
            get
            {
                return _frequencyShoreStationReceives;
            }

            set
            {
                SetValue(ref _frequencyShoreStationReceives, value);
            }
        }

        private Int32? _frequencyShoreStationTransmits = default;
        [Category("frequencyPair")]
        public Int32? frequencyShoreStationTransmits
        {
            get
            {
                return _frequencyShoreStationTransmits;
            }

            set
            {
                SetValue(ref _frequencyShoreStationTransmits, value);
            }
        }

        public void Load(DomainModel.S122.ComplexAttributes.frequencyPair instance)
        {
            frequencyShoreStationReceives = instance.frequencyShoreStationReceives;
            frequencyShoreStationTransmits = instance.frequencyShoreStationTransmits;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.ComplexAttributes.frequencyPair
            {
                frequencyShoreStationReceives = this.frequencyShoreStationReceives,
                frequencyShoreStationTransmits = this.frequencyShoreStationTransmits,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.frequencyPair Model => new()
        {
            frequencyShoreStationReceives = this._frequencyShoreStationReceives,
            frequencyShoreStationTransmits = this._frequencyShoreStationTransmits,
        };

        public frequencyPairViewModel(IViewModelHost? host = null) : base(host)
        {
        }
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
        public String fileLocator
        {
            get
            {
                return _fileLocator;
            }

            set
            {
                SetValue(ref _fileLocator, value);
            }
        }

        private String _fileReference = string.Empty;
        [Category("information")]
        public String fileReference
        {
            get
            {
                return _fileReference;
            }

            set
            {
                SetValue(ref _fileReference, value);
            }
        }

        private String _headline = string.Empty;
        [Category("information")]
        public String headline
        {
            get
            {
                return _headline;
            }

            set
            {
                SetValue(ref _headline, value);
            }
        }

        private String _language = string.Empty;
        [Category("information")]
        public String language
        {
            get
            {
                return _language;
            }

            set
            {
                SetValue(ref _language, value);
            }
        }

        private String _text = string.Empty;
        [Category("information")]
        public String text
        {
            get
            {
                return _text;
            }

            set
            {
                SetValue(ref _text, value);
            }
        }

        public void Load(DomainModel.S122.ComplexAttributes.information instance)
        {
            fileLocator = instance.fileLocator;
            fileReference = instance.fileReference;
            headline = instance.headline;
            language = instance.language;
            text = instance.text;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.ComplexAttributes.information
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
        public DomainModel.S122.ComplexAttributes.information Model => new()
        {
            fileLocator = this._fileLocator,
            fileReference = this._fileReference,
            headline = this._headline,
            language = this._language,
            text = this._text,
        };

        public informationViewModel(IViewModelHost? host = null) : base(host)
        {
        }
    }

    [CategoryOrder("onlineResource", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class onlineResourceViewModel : ViewModelBase
    {
        private String _onlineResourceLinkageURL = string.Empty;
        [Category("onlineResource")]
        public String onlineResourceLinkageURL
        {
            get
            {
                return _onlineResourceLinkageURL;
            }

            set
            {
                SetValue(ref _onlineResourceLinkageURL, value);
            }
        }

        private String _protocol = string.Empty;
        [Category("onlineResource")]
        public String protocol
        {
            get
            {
                return _protocol;
            }

            set
            {
                SetValue(ref _protocol, value);
            }
        }

        private String _applicationProfile = string.Empty;
        [Category("onlineResource")]
        public String applicationProfile
        {
            get
            {
                return _applicationProfile;
            }

            set
            {
                SetValue(ref _applicationProfile, value);
            }
        }

        private String _nameOfResource = string.Empty;
        [Category("onlineResource")]
        public String nameOfResource
        {
            get
            {
                return _nameOfResource;
            }

            set
            {
                SetValue(ref _nameOfResource, value);
            }
        }

        private String _onlineResourceDescription = string.Empty;
        [Category("onlineResource")]
        public String onlineResourceDescription
        {
            get
            {
                return _onlineResourceDescription;
            }

            set
            {
                SetValue(ref _onlineResourceDescription, value);
            }
        }

        private String _protocolRequest = string.Empty;
        [Category("onlineResource")]
        public String protocolRequest
        {
            get
            {
                return _protocolRequest;
            }

            set
            {
                SetValue(ref _protocolRequest, value);
            }
        }

        private onlineFunction? _onlineFunction = default;
        [Category("onlineResource")]
        public onlineFunction? onlineFunction
        {
            get
            {
                return _onlineFunction;
            }

            set
            {
                SetValue(ref _onlineFunction, value);
            }
        }

        public void Load(DomainModel.S122.ComplexAttributes.onlineResource instance)
        {
            onlineResourceLinkageURL = instance.onlineResourceLinkageURL;
            protocol = instance.protocol;
            applicationProfile = instance.applicationProfile;
            nameOfResource = instance.nameOfResource;
            onlineResourceDescription = instance.onlineResourceDescription;
            protocolRequest = instance.protocolRequest;
            onlineFunction = instance.onlineFunction;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.ComplexAttributes.onlineResource
            {
                onlineResourceLinkageURL = this.onlineResourceLinkageURL,
                protocol = this.protocol,
                applicationProfile = this.applicationProfile,
                nameOfResource = this.nameOfResource,
                onlineResourceDescription = this.onlineResourceDescription,
                protocolRequest = this.protocolRequest,
                onlineFunction = this.onlineFunction,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.onlineResource Model => new()
        {
            onlineResourceLinkageURL = this._onlineResourceLinkageURL,
            protocol = this._protocol,
            applicationProfile = this._applicationProfile,
            nameOfResource = this._nameOfResource,
            onlineResourceDescription = this._onlineResourceDescription,
            protocolRequest = this._protocolRequest,
            onlineFunction = this._onlineFunction,
        };

        public onlineResourceViewModel(IViewModelHost? host = null) : base(host)
        {
        }
    }

#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    [CategoryOrder("orientation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class orientationViewModel : ViewModelBase
#pragma warning restore CS8981
    {
        private Decimal? _orientationUncertainty = default;
        [Category("orientation")]
        public Decimal? orientationUncertainty
        {
            get
            {
                return _orientationUncertainty;
            }

            set
            {
                SetValue(ref _orientationUncertainty, value);
            }
        }

        private Decimal _orientationValue;
        [Category("orientation")]
        public Decimal orientationValue
        {
            get
            {
                return _orientationValue;
            }

            set
            {
                SetValue(ref _orientationValue, value);
            }
        }

        public void Load(DomainModel.S122.ComplexAttributes.orientation instance)
        {
            orientationUncertainty = instance.orientationUncertainty;
            orientationValue = instance.orientationValue;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.ComplexAttributes.orientation
            {
                orientationUncertainty = this.orientationUncertainty,
                orientationValue = this.orientationValue,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.orientation Model => new()
        {
            orientationUncertainty = this._orientationUncertainty,
            orientationValue = this._orientationValue,
        };

        public orientationViewModel(IViewModelHost? host = null) : base(host)
        {
        }
    }

    [CategoryOrder("periodicDateRange", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class periodicDateRangeViewModel : ViewModelBase
    {
        private DateOnly _dateStart;
        [Category("periodicDateRange")]
        public DateOnly dateStart
        {
            get
            {
                return _dateStart;
            }

            set
            {
                SetValue(ref _dateStart, value);
            }
        }

        private DateOnly _dateEnd;
        [Category("periodicDateRange")]
        public DateOnly dateEnd
        {
            get
            {
                return _dateEnd;
            }

            set
            {
                SetValue(ref _dateEnd, value);
            }
        }

        public void Load(DomainModel.S122.ComplexAttributes.periodicDateRange instance)
        {
            dateStart = instance.dateStart;
            dateEnd = instance.dateEnd;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.ComplexAttributes.periodicDateRange
            {
                dateStart = this.dateStart,
                dateEnd = this.dateEnd,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.periodicDateRange Model => new()
        {
            dateStart = this._dateStart,
            dateEnd = this._dateEnd,
        };

        public periodicDateRangeViewModel(IViewModelHost? host = null) : base(host)
        {
        }
    }

    [CategoryOrder("rxNCode", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class rxNCodeViewModel : ViewModelBase
    {
        private categoryOfRxN? _categoryOfRxN;
        [DomainModel.CodeList(nameof(categoryOfRxNList))]
        [Editor(typeof(Editors.CodeListComboEditor), typeof(Editors.CodeListComboEditor))]
        [Category("rxNCode")]
        public categoryOfRxN? categoryOfRxN
        {
            get
            {
                return _categoryOfRxN;
            }

            set
            {
                SetValue(ref _categoryOfRxN, value);
            }
        }

        private actionOrActivity? _actionOrActivity;
        [DomainModel.CodeList(nameof(actionOrActivityList))]
        [Editor(typeof(Editors.CodeListComboEditor), typeof(Editors.CodeListComboEditor))]
        [Category("rxNCode")]
        public actionOrActivity? actionOrActivity
        {
            get
            {
                return _actionOrActivity;
            }

            set
            {
                SetValue(ref _actionOrActivity, value);
            }
        }

        private String _headline = string.Empty;
        [Category("rxNCode")]
        public String headline
        {
            get
            {
                return _headline;
            }

            set
            {
                SetValue(ref _headline, value);
            }
        }

        [Browsable(false)]
        public categoryOfRxN[] categoryOfRxNList => CodeList.categoryOfRxNS.ToArray();

        [Browsable(false)]
        public actionOrActivity[] actionOrActivityList => CodeList.actionOrActivities.ToArray();

        public void Load(DomainModel.S122.ComplexAttributes.rxNCode instance)
        {
            categoryOfRxN = instance.categoryOfRxN;
            actionOrActivity = instance.actionOrActivity;
            headline = instance.headline;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.ComplexAttributes.rxNCode
            {
                categoryOfRxN = this.categoryOfRxN,
                actionOrActivity = this.actionOrActivity,
                headline = this.headline,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.rxNCode Model => new()
        {
            categoryOfRxN = this._categoryOfRxN,
            actionOrActivity = this._actionOrActivity,
            headline = this._headline,
        };

        public rxNCodeViewModel(IViewModelHost? host = null) : base(host)
        {
        }
    }

    [CategoryOrder("sectorLimitOne", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class sectorLimitOneViewModel : ViewModelBase
    {
        private Decimal _sectorBearing;
        [Category("sectorLimitOne")]
        public Decimal sectorBearing
        {
            get
            {
                return _sectorBearing;
            }

            set
            {
                SetValue(ref _sectorBearing, value);
            }
        }

        private Int32? _sectorLineLength = default;
        [Category("sectorLimitOne")]
        public Int32? sectorLineLength
        {
            get
            {
                return _sectorLineLength;
            }

            set
            {
                SetValue(ref _sectorLineLength, value);
            }
        }

        public void Load(DomainModel.S122.ComplexAttributes.sectorLimitOne instance)
        {
            sectorBearing = instance.sectorBearing;
            sectorLineLength = instance.sectorLineLength;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.ComplexAttributes.sectorLimitOne
            {
                sectorBearing = this.sectorBearing,
                sectorLineLength = this.sectorLineLength,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.sectorLimitOne Model => new()
        {
            sectorBearing = this._sectorBearing,
            sectorLineLength = this._sectorLineLength,
        };

        public sectorLimitOneViewModel(IViewModelHost? host = null) : base(host)
        {
        }
    }

    [CategoryOrder("sectorLimitTwo", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class sectorLimitTwoViewModel : ViewModelBase
    {
        private Decimal _sectorBearing;
        [Category("sectorLimitTwo")]
        public Decimal sectorBearing
        {
            get
            {
                return _sectorBearing;
            }

            set
            {
                SetValue(ref _sectorBearing, value);
            }
        }

        private Int32? _sectorLineLength = default;
        [Category("sectorLimitTwo")]
        public Int32? sectorLineLength
        {
            get
            {
                return _sectorLineLength;
            }

            set
            {
                SetValue(ref _sectorLineLength, value);
            }
        }

        public void Load(DomainModel.S122.ComplexAttributes.sectorLimitTwo instance)
        {
            sectorBearing = instance.sectorBearing;
            sectorLineLength = instance.sectorLineLength;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.ComplexAttributes.sectorLimitTwo
            {
                sectorBearing = this.sectorBearing,
                sectorLineLength = this.sectorLineLength,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.sectorLimitTwo Model => new()
        {
            sectorBearing = this._sectorBearing,
            sectorLineLength = this._sectorLineLength,
        };

        public sectorLimitTwoViewModel(IViewModelHost? host = null) : base(host)
        {
        }
    }

    [CategoryOrder("textContent", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class textContentViewModel : ViewModelBase
    {
        private categoryOfText? _categoryOfText = default;
        [Category("textContent")]
        public categoryOfText? categoryOfText
        {
            get
            {
                return _categoryOfText;
            }

            set
            {
                SetValue(ref _categoryOfText, value);
            }
        }

        private String _source = string.Empty;
        [Category("textContent")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("textContent")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("textContent")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public void Load(DomainModel.S122.ComplexAttributes.textContent instance)
        {
            categoryOfText = instance.categoryOfText;
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.ComplexAttributes.textContent
            {
                categoryOfText = this.categoryOfText,
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.textContent Model => new()
        {
            categoryOfText = this._categoryOfText,
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public textContentViewModel(IViewModelHost? host = null) : base(host)
        {
        }
    }

    [CategoryOrder("timeIntervalsByDayOfWeek", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class timeIntervalsByDayOfWeekViewModel : ViewModelBase
    {
        [Category("timeIntervalsByDayOfWeek")]
        public ObservableCollection<dayOfWeek> dayOfWeek { get; set; } = new();

        private Boolean? _dayOfWeekIsRange = default;
        [Category("timeIntervalsByDayOfWeek")]
        public Boolean? dayOfWeekIsRange
        {
            get
            {
                return _dayOfWeekIsRange;
            }

            set
            {
                SetValue(ref _dayOfWeekIsRange, value);
            }
        }

        [Category("timeIntervalsByDayOfWeek")]
        public ObservableCollection<TimeOnly> timeOfDayEnd { get; set; } = new();

        [Category("timeIntervalsByDayOfWeek")]
        public ObservableCollection<TimeOnly> timeOfDayStart { get; set; } = new();

        public void Load(DomainModel.S122.ComplexAttributes.timeIntervalsByDayOfWeek instance)
        {
            dayOfWeek.Clear();
            if (instance.dayOfWeek is not null)
                foreach (var e in instance.dayOfWeek)
                    dayOfWeek.Add(e);
            dayOfWeekIsRange = instance.dayOfWeekIsRange;
            timeOfDayEnd.Clear();
            if (instance.timeOfDayEnd is not null)
                foreach (var e in instance.timeOfDayEnd)
                    timeOfDayEnd.Add(e);
            timeOfDayStart.Clear();
            if (instance.timeOfDayStart is not null)
                foreach (var e in instance.timeOfDayStart)
                    timeOfDayStart.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.ComplexAttributes.timeIntervalsByDayOfWeek
            {
                dayOfWeek = this.dayOfWeek.ToList(),
                dayOfWeekIsRange = this.dayOfWeekIsRange,
                timeOfDayEnd = this.timeOfDayEnd.ToList(),
                timeOfDayStart = this.timeOfDayStart.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.timeIntervalsByDayOfWeek Model => new()
        {
            dayOfWeek = this.dayOfWeek.ToList(),
            dayOfWeekIsRange = this._dayOfWeekIsRange,
            timeOfDayEnd = this.timeOfDayEnd.ToList(),
            timeOfDayStart = this.timeOfDayStart.ToList(),
        };

        public timeIntervalsByDayOfWeekViewModel(IViewModelHost? host = null) : base(host)
        {
            dayOfWeek.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(dayOfWeek));
            };
            timeOfDayEnd.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(timeOfDayEnd));
            };
            timeOfDayStart.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(timeOfDayStart));
            };
        }
    }

    [CategoryOrder("vesselsMeasurements", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class vesselsMeasurementsViewModel : ViewModelBase
    {
        private vesselsCharacteristics _vesselsCharacteristics;
        [Category("vesselsMeasurements")]
        public vesselsCharacteristics vesselsCharacteristics
        {
            get
            {
                return _vesselsCharacteristics;
            }

            set
            {
                SetValue(ref _vesselsCharacteristics, value);
            }
        }

        private Decimal _vesselsCharacteristicsValue;
        [Category("vesselsMeasurements")]
        public Decimal vesselsCharacteristicsValue
        {
            get
            {
                return _vesselsCharacteristicsValue;
            }

            set
            {
                SetValue(ref _vesselsCharacteristicsValue, value);
            }
        }

        private vesselsCharacteristicsUnit _vesselsCharacteristicsUnit;
        [Category("vesselsMeasurements")]
        public vesselsCharacteristicsUnit vesselsCharacteristicsUnit
        {
            get
            {
                return _vesselsCharacteristicsUnit;
            }

            set
            {
                SetValue(ref _vesselsCharacteristicsUnit, value);
            }
        }

        private comparisonOperator _comparisonOperator;
        [Category("vesselsMeasurements")]
        public comparisonOperator comparisonOperator
        {
            get
            {
                return _comparisonOperator;
            }

            set
            {
                SetValue(ref _comparisonOperator, value);
            }
        }

        public void Load(DomainModel.S122.ComplexAttributes.vesselsMeasurements instance)
        {
            vesselsCharacteristics = instance.vesselsCharacteristics;
            vesselsCharacteristicsValue = instance.vesselsCharacteristicsValue;
            vesselsCharacteristicsUnit = instance.vesselsCharacteristicsUnit;
            comparisonOperator = instance.comparisonOperator;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.ComplexAttributes.vesselsMeasurements
            {
                vesselsCharacteristics = this.vesselsCharacteristics,
                vesselsCharacteristicsValue = this.vesselsCharacteristicsValue,
                vesselsCharacteristicsUnit = this.vesselsCharacteristicsUnit,
                comparisonOperator = this.comparisonOperator,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.vesselsMeasurements Model => new()
        {
            vesselsCharacteristics = this._vesselsCharacteristics,
            vesselsCharacteristicsValue = this._vesselsCharacteristicsValue,
            vesselsCharacteristicsUnit = this._vesselsCharacteristicsUnit,
            comparisonOperator = this._comparisonOperator,
        };

        public vesselsMeasurementsViewModel(IViewModelHost? host = null) : base(host)
        {
        }
    }

#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    [CategoryOrder("designation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class designationViewModel : ViewModelBase
#pragma warning restore CS8981
    {
        private String _designationScheme = string.Empty;
        [Category("designation")]
        public String designationScheme
        {
            get
            {
                return _designationScheme;
            }

            set
            {
                SetValue(ref _designationScheme, value);
            }
        }

        private String _designationIdentifier = string.Empty;
        [Category("designation")]
        public String designationIdentifier
        {
            get
            {
                return _designationIdentifier;
            }

            set
            {
                SetValue(ref _designationIdentifier, value);
            }
        }

        private jurisdiction? _jurisdiction = default;
        [Category("designation")]
        public jurisdiction? jurisdiction
        {
            get
            {
                return _jurisdiction;
            }

            set
            {
                SetValue(ref _jurisdiction, value);
            }
        }

        private String _text = string.Empty;
        [Category("designation")]
        public String text
        {
            get
            {
                return _text;
            }

            set
            {
                SetValue(ref _text, value);
            }
        }

        public void Load(DomainModel.S122.ComplexAttributes.designation instance)
        {
            designationScheme = instance.designationScheme;
            designationIdentifier = instance.designationIdentifier;
            jurisdiction = instance.jurisdiction;
            text = instance.text;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.ComplexAttributes.designation
            {
                designationScheme = this.designationScheme,
                designationIdentifier = this.designationIdentifier,
                jurisdiction = this.jurisdiction,
                text = this.text,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.designation Model => new()
        {
            designationScheme = this._designationScheme,
            designationIdentifier = this._designationIdentifier,
            jurisdiction = this._jurisdiction,
            text = this._text,
        };

        public designationViewModel(IViewModelHost? host = null) : base(host)
        {
        }
    }

    [CategoryOrder("bearingInformation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class bearingInformationViewModel : ViewModelBase
    {
        private cardinalDirection? _cardinalDirection = default;
        [Category("bearingInformation")]
        public cardinalDirection? cardinalDirection
        {
            get
            {
                return _cardinalDirection;
            }

            set
            {
                SetValue(ref _cardinalDirection, value);
            }
        }

        private Decimal? _distance = default;
        [Category("bearingInformation")]
        public Decimal? distance
        {
            get
            {
                return _distance;
            }

            set
            {
                SetValue(ref _distance, value);
            }
        }

        [Category("bearingInformation")]
        public ObservableCollection<Decimal> sectorBearing { get; set; } = new();

        [Category("bearingInformation")]
        public ObservableCollection<information> information { get; set; } = new();

        private orientationViewModel? _orientation;
        [Category("bearingInformation")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public orientationViewModel? orientation
        {
            get
            {
                return _orientation;
            }

            set
            {
                SetValue(ref _orientation, value);
            }
        }

        public void Load(DomainModel.S122.ComplexAttributes.bearingInformation instance)
        {
            cardinalDirection = instance.cardinalDirection;
            distance = instance.distance;
            sectorBearing.Clear();
            if (instance.sectorBearing is not null)
                foreach (var e in instance.sectorBearing)
                    sectorBearing.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            orientation = new();
            if (instance.orientation != null)
            {
                orientation = new();
                orientation.Load(instance.orientation);
            }
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.ComplexAttributes.bearingInformation
            {
                cardinalDirection = this.cardinalDirection,
                distance = this.distance,
                sectorBearing = this.sectorBearing.ToList(),
                information = this.information.ToList(),
                orientation = this.orientation?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.bearingInformation Model => new()
        {
            cardinalDirection = this._cardinalDirection,
            distance = this._distance,
            sectorBearing = this.sectorBearing.ToList(),
            information = this.information.ToList(),
            orientation = this._orientation?.Model,
        };

        public bearingInformationViewModel(IViewModelHost? host = null) : base(host)
        {
            sectorBearing.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(sectorBearing));
            };
            information.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(information));
            };
        }
    }

#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    [CategoryOrder("graphic", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class graphicViewModel : ViewModelBase
#pragma warning restore CS8981
    {
        [Category("graphic")]
        public ObservableCollection<String> pictorialRepresentation { get; set; } = new();

        private String _pictureCaption = string.Empty;
        [Category("graphic")]
        public String pictureCaption
        {
            get
            {
                return _pictureCaption;
            }

            set
            {
                SetValue(ref _pictureCaption, value);
            }
        }

        private DateTime? _sourceDate = default;
        [Category("graphic")]
        public DateTime? sourceDate
        {
            get
            {
                return _sourceDate;
            }

            set
            {
                SetValue(ref _sourceDate, value);
            }
        }

        private String _pictureInformation = string.Empty;
        [Category("graphic")]
        public String pictureInformation
        {
            get
            {
                return _pictureInformation;
            }

            set
            {
                SetValue(ref _pictureInformation, value);
            }
        }

        private bearingInformationViewModel? _bearingInformation;
        [Category("graphic")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public bearingInformationViewModel? bearingInformation
        {
            get
            {
                return _bearingInformation;
            }

            set
            {
                SetValue(ref _bearingInformation, value);
            }
        }

        public void Load(DomainModel.S122.ComplexAttributes.graphic instance)
        {
            pictorialRepresentation.Clear();
            if (instance.pictorialRepresentation is not null)
                foreach (var e in instance.pictorialRepresentation)
                    pictorialRepresentation.Add(e);
            pictureCaption = instance.pictureCaption;
            sourceDate = instance.sourceDate;
            pictureInformation = instance.pictureInformation;
            bearingInformation = new();
            if (instance.bearingInformation != null)
            {
                bearingInformation = new();
                bearingInformation.Load(instance.bearingInformation);
            }
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.ComplexAttributes.graphic
            {
                pictorialRepresentation = this.pictorialRepresentation.ToList(),
                pictureCaption = this.pictureCaption,
                sourceDate = this.sourceDate,
                pictureInformation = this.pictureInformation,
                bearingInformation = this.bearingInformation?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.graphic Model => new()
        {
            pictorialRepresentation = this.pictorialRepresentation.ToList(),
            pictureCaption = this._pictureCaption,
            sourceDate = this._sourceDate,
            pictureInformation = this._pictureInformation,
            bearingInformation = this._bearingInformation?.Model,
        };

        public graphicViewModel(IViewModelHost? host = null) : base(host)
        {
            pictorialRepresentation.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(pictorialRepresentation));
            };
        }
    }

    [CategoryOrder("scheduleByDayOfWeek", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class scheduleByDayOfWeekViewModel : ViewModelBase
    {
        private categoryOfSchedule? _categoryOfSchedule = default;
        [Category("scheduleByDayOfWeek")]
        public categoryOfSchedule? categoryOfSchedule
        {
            get
            {
                return _categoryOfSchedule;
            }

            set
            {
                SetValue(ref _categoryOfSchedule, value);
            }
        }

        [Category("scheduleByDayOfWeek")]
        public ObservableCollection<timeIntervalsByDayOfWeek> timeIntervalsByDayOfWeek { get; set; } = new();

        public void Load(DomainModel.S122.ComplexAttributes.scheduleByDayOfWeek instance)
        {
            categoryOfSchedule = instance.categoryOfSchedule;
            timeIntervalsByDayOfWeek.Clear();
            if (instance.timeIntervalsByDayOfWeek is not null)
                foreach (var e in instance.timeIntervalsByDayOfWeek)
                    timeIntervalsByDayOfWeek.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.ComplexAttributes.scheduleByDayOfWeek
            {
                categoryOfSchedule = this.categoryOfSchedule,
                timeIntervalsByDayOfWeek = this.timeIntervalsByDayOfWeek.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.scheduleByDayOfWeek Model => new()
        {
            categoryOfSchedule = this._categoryOfSchedule,
            timeIntervalsByDayOfWeek = this.timeIntervalsByDayOfWeek.ToList(),
        };

        public scheduleByDayOfWeekViewModel(IViewModelHost? host = null) : base(host)
        {
            timeIntervalsByDayOfWeek.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(timeIntervalsByDayOfWeek));
            };
        }
    }

    [CategoryOrder("sectorLimit", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class sectorLimitViewModel : ViewModelBase
    {
        private sectorLimitOneViewModel _sectorLimitOne;
        [Category("sectorLimit")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sectorLimitOneViewModel sectorLimitOne
        {
            get
            {
                return _sectorLimitOne;
            }

            set
            {
                SetValue(ref _sectorLimitOne, value);
            }
        }

        private sectorLimitTwoViewModel _sectorLimitTwo;
        [Category("sectorLimit")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sectorLimitTwoViewModel sectorLimitTwo
        {
            get
            {
                return _sectorLimitTwo;
            }

            set
            {
                SetValue(ref _sectorLimitTwo, value);
            }
        }

        public void Load(DomainModel.S122.ComplexAttributes.sectorLimit instance)
        {
            sectorLimitOne = new();
            if (instance.sectorLimitOne != null)
            {
                sectorLimitOne = new();
                sectorLimitOne.Load(instance.sectorLimitOne);
            }

            sectorLimitTwo = new();
            if (instance.sectorLimitTwo != null)
            {
                sectorLimitTwo = new();
                sectorLimitTwo.Load(instance.sectorLimitTwo);
            }
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.ComplexAttributes.sectorLimit
            {
                sectorLimitOne = this.sectorLimitOne?.Model,
                sectorLimitTwo = this.sectorLimitTwo?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.sectorLimit Model => new()
        {
            sectorLimitOne = this._sectorLimitOne?.Model,
            sectorLimitTwo = this._sectorLimitTwo?.Model,
        };

        public sectorLimitViewModel(IViewModelHost? host = null) : base(host)
        {
        }
    }

#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    [CategoryOrder("telecommunications", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class telecommunicationsViewModel : ViewModelBase
#pragma warning restore CS8981
    {
        private categoryOfCommunicationPreference? _categoryOfCommunicationPreference = default;
        [Category("telecommunications")]
        public categoryOfCommunicationPreference? categoryOfCommunicationPreference
        {
            get
            {
                return _categoryOfCommunicationPreference;
            }

            set
            {
                SetValue(ref _categoryOfCommunicationPreference, value);
            }
        }

        private String _contactInstructions = string.Empty;
        [Category("telecommunications")]
        public String contactInstructions
        {
            get
            {
                return _contactInstructions;
            }

            set
            {
                SetValue(ref _contactInstructions, value);
            }
        }

        private String _telecomCarrier = string.Empty;
        [Category("telecommunications")]
        public String telecomCarrier
        {
            get
            {
                return _telecomCarrier;
            }

            set
            {
                SetValue(ref _telecomCarrier, value);
            }
        }

        private String _telecommunicationIdentifier = string.Empty;
        [Category("telecommunications")]
        public String telecommunicationIdentifier
        {
            get
            {
                return _telecommunicationIdentifier;
            }

            set
            {
                SetValue(ref _telecommunicationIdentifier, value);
            }
        }

        private telecommunicationService? _telecommunicationService = default;
        [Category("telecommunications")]
        public telecommunicationService? telecommunicationService
        {
            get
            {
                return _telecommunicationService;
            }

            set
            {
                SetValue(ref _telecommunicationService, value);
            }
        }

        private scheduleByDayOfWeekViewModel? _scheduleByDayOfWeek;
        [Category("telecommunications")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public scheduleByDayOfWeekViewModel? scheduleByDayOfWeek
        {
            get
            {
                return _scheduleByDayOfWeek;
            }

            set
            {
                SetValue(ref _scheduleByDayOfWeek, value);
            }
        }

        public void Load(DomainModel.S122.ComplexAttributes.telecommunications instance)
        {
            categoryOfCommunicationPreference = instance.categoryOfCommunicationPreference;
            contactInstructions = instance.contactInstructions;
            telecomCarrier = instance.telecomCarrier;
            telecommunicationIdentifier = instance.telecommunicationIdentifier;
            telecommunicationService = instance.telecommunicationService;
            scheduleByDayOfWeek = new();
            if (instance.scheduleByDayOfWeek != null)
            {
                scheduleByDayOfWeek = new();
                scheduleByDayOfWeek.Load(instance.scheduleByDayOfWeek);
            }
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.ComplexAttributes.telecommunications
            {
                categoryOfCommunicationPreference = this.categoryOfCommunicationPreference,
                contactInstructions = this.contactInstructions,
                telecomCarrier = this.telecomCarrier,
                telecommunicationIdentifier = this.telecommunicationIdentifier,
                telecommunicationService = this.telecommunicationService,
                scheduleByDayOfWeek = this.scheduleByDayOfWeek?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.telecommunications Model => new()
        {
            categoryOfCommunicationPreference = this._categoryOfCommunicationPreference,
            contactInstructions = this._contactInstructions,
            telecomCarrier = this._telecomCarrier,
            telecommunicationIdentifier = this._telecommunicationIdentifier,
            telecommunicationService = this._telecommunicationService,
            scheduleByDayOfWeek = this._scheduleByDayOfWeek?.Model,
        };

        public telecommunicationsViewModel(IViewModelHost? host = null) : base(host)
        {
        }
    }

    [CategoryOrder("InformationType", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class InformationTypeViewModel : ViewModelBase
    {
        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("InformationType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public void Load(DomainModel.S122.InformationTypes.InformationType instance)
        {
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.InformationTypes.InformationType
            {
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.InformationTypes.InformationType Model => new()
        {
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public InformationTypeViewModel(IViewModelHost? host = null) : base(host)
        {
            featureName.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
        }
    }

    [CategoryOrder("AbstractRxN", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class AbstractRxNViewModel : ViewModelBase
    {
        private categoryOfAuthority? _categoryOfAuthority = default;
        [Category("AbstractRxN")]
        public categoryOfAuthority? categoryOfAuthority
        {
            get
            {
                return _categoryOfAuthority;
            }

            set
            {
                SetValue(ref _categoryOfAuthority, value);
            }
        }

        private textContentViewModel? _textContent;
        [Category("AbstractRxN")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public textContentViewModel? textContent
        {
            get
            {
                return _textContent;
            }

            set
            {
                SetValue(ref _textContent, value);
            }
        }

        [Category("AbstractRxN")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("InformationType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public void Load(DomainModel.S122.InformationTypes.AbstractRxN instance)
        {
            categoryOfAuthority = instance.categoryOfAuthority;
            textContent = new();
            if (instance.textContent != null)
            {
                textContent = new();
                textContent.Load(instance.textContent);
            }

            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.InformationTypes.AbstractRxN
            {
                categoryOfAuthority = this.categoryOfAuthority,
                textContent = this.textContent?.Model,
                rxNCode = this.rxNCode.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.InformationTypes.AbstractRxN Model => new()
        {
            categoryOfAuthority = this._categoryOfAuthority,
            textContent = this._textContent?.Model,
            rxNCode = this.rxNCode.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public AbstractRxNViewModel(IViewModelHost? host = null) : base(host)
        {
            rxNCode.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            featureName.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
        }
    }

    [CategoryOrder("NauticalInformation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class NauticalInformationViewModel : ViewModelBase
    {
        private categoryOfAuthority? _categoryOfAuthority = default;
        [Category("AbstractRxN")]
        public categoryOfAuthority? categoryOfAuthority
        {
            get
            {
                return _categoryOfAuthority;
            }

            set
            {
                SetValue(ref _categoryOfAuthority, value);
            }
        }

        private textContentViewModel? _textContent;
        [Category("AbstractRxN")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public textContentViewModel? textContent
        {
            get
            {
                return _textContent;
            }

            set
            {
                SetValue(ref _textContent, value);
            }
        }

        [Category("AbstractRxN")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("InformationType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public void Load(DomainModel.S122.InformationTypes.NauticalInformation instance)
        {
            categoryOfAuthority = instance.categoryOfAuthority;
            textContent = new();
            if (instance.textContent != null)
            {
                textContent = new();
                textContent.Load(instance.textContent);
            }

            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.InformationTypes.NauticalInformation
            {
                categoryOfAuthority = this.categoryOfAuthority,
                textContent = this.textContent?.Model,
                rxNCode = this.rxNCode.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.InformationTypes.NauticalInformation Model => new()
        {
            categoryOfAuthority = this._categoryOfAuthority,
            textContent = this._textContent?.Model,
            rxNCode = this.rxNCode.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public NauticalInformationViewModel(IViewModelHost? host = null) : base(host)
        {
            rxNCode.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            featureName.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
        }
    }

    [CategoryOrder("Regulations", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class RegulationsViewModel : ViewModelBase
    {
        private categoryOfAuthority? _categoryOfAuthority = default;
        [Category("AbstractRxN")]
        public categoryOfAuthority? categoryOfAuthority
        {
            get
            {
                return _categoryOfAuthority;
            }

            set
            {
                SetValue(ref _categoryOfAuthority, value);
            }
        }

        private textContentViewModel? _textContent;
        [Category("AbstractRxN")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public textContentViewModel? textContent
        {
            get
            {
                return _textContent;
            }

            set
            {
                SetValue(ref _textContent, value);
            }
        }

        [Category("AbstractRxN")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("InformationType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public void Load(DomainModel.S122.InformationTypes.Regulations instance)
        {
            categoryOfAuthority = instance.categoryOfAuthority;
            textContent = new();
            if (instance.textContent != null)
            {
                textContent = new();
                textContent.Load(instance.textContent);
            }

            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.InformationTypes.Regulations
            {
                categoryOfAuthority = this.categoryOfAuthority,
                textContent = this.textContent?.Model,
                rxNCode = this.rxNCode.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.InformationTypes.Regulations Model => new()
        {
            categoryOfAuthority = this._categoryOfAuthority,
            textContent = this._textContent?.Model,
            rxNCode = this.rxNCode.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public RegulationsViewModel(IViewModelHost? host = null) : base(host)
        {
            rxNCode.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            featureName.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
        }
    }

    [CategoryOrder("Restrictions", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class RestrictionsViewModel : ViewModelBase
    {
        private categoryOfAuthority? _categoryOfAuthority = default;
        [Category("AbstractRxN")]
        public categoryOfAuthority? categoryOfAuthority
        {
            get
            {
                return _categoryOfAuthority;
            }

            set
            {
                SetValue(ref _categoryOfAuthority, value);
            }
        }

        private textContentViewModel? _textContent;
        [Category("AbstractRxN")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public textContentViewModel? textContent
        {
            get
            {
                return _textContent;
            }

            set
            {
                SetValue(ref _textContent, value);
            }
        }

        [Category("AbstractRxN")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("InformationType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public void Load(DomainModel.S122.InformationTypes.Restrictions instance)
        {
            categoryOfAuthority = instance.categoryOfAuthority;
            textContent = new();
            if (instance.textContent != null)
            {
                textContent = new();
                textContent.Load(instance.textContent);
            }

            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.InformationTypes.Restrictions
            {
                categoryOfAuthority = this.categoryOfAuthority,
                textContent = this.textContent?.Model,
                rxNCode = this.rxNCode.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.InformationTypes.Restrictions Model => new()
        {
            categoryOfAuthority = this._categoryOfAuthority,
            textContent = this._textContent?.Model,
            rxNCode = this.rxNCode.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public RestrictionsViewModel(IViewModelHost? host = null) : base(host)
        {
            rxNCode.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            featureName.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
        }
    }

    [CategoryOrder("Recommendations", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class RecommendationsViewModel : ViewModelBase
    {
        private categoryOfAuthority? _categoryOfAuthority = default;
        [Category("AbstractRxN")]
        public categoryOfAuthority? categoryOfAuthority
        {
            get
            {
                return _categoryOfAuthority;
            }

            set
            {
                SetValue(ref _categoryOfAuthority, value);
            }
        }

        private textContentViewModel? _textContent;
        [Category("AbstractRxN")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public textContentViewModel? textContent
        {
            get
            {
                return _textContent;
            }

            set
            {
                SetValue(ref _textContent, value);
            }
        }

        [Category("AbstractRxN")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("InformationType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public void Load(DomainModel.S122.InformationTypes.Recommendations instance)
        {
            categoryOfAuthority = instance.categoryOfAuthority;
            textContent = new();
            if (instance.textContent != null)
            {
                textContent = new();
                textContent.Load(instance.textContent);
            }

            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.InformationTypes.Recommendations
            {
                categoryOfAuthority = this.categoryOfAuthority,
                textContent = this.textContent?.Model,
                rxNCode = this.rxNCode.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.InformationTypes.Recommendations Model => new()
        {
            categoryOfAuthority = this._categoryOfAuthority,
            textContent = this._textContent?.Model,
            rxNCode = this.rxNCode.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public RecommendationsViewModel(IViewModelHost? host = null) : base(host)
        {
            rxNCode.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            featureName.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
        }
    }

    [CategoryOrder("Authority", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class AuthorityViewModel : ViewModelBase
    {
        private categoryOfAuthority _categoryOfAuthority;
        [Category("Authority")]
        public categoryOfAuthority categoryOfAuthority
        {
            get
            {
                return _categoryOfAuthority;
            }

            set
            {
                SetValue(ref _categoryOfAuthority, value);
            }
        }

        [Category("Authority")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("InformationType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public void Load(DomainModel.S122.InformationTypes.Authority instance)
        {
            categoryOfAuthority = instance.categoryOfAuthority;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.InformationTypes.Authority
            {
                categoryOfAuthority = this.categoryOfAuthority,
                textContent = this.textContent.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.InformationTypes.Authority Model => new()
        {
            categoryOfAuthority = this._categoryOfAuthority,
            textContent = this.textContent.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public AuthorityViewModel(IViewModelHost? host = null) : base(host)
        {
            textContent.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
            featureName.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
        }
    }

    [CategoryOrder("ContactDetails", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ContactDetailsViewModel : ViewModelBase
    {
        private String _callName = string.Empty;
        [Category("ContactDetails")]
        public String callName
        {
            get
            {
                return _callName;
            }

            set
            {
                SetValue(ref _callName, value);
            }
        }

        private String _callSign = string.Empty;
        [Category("ContactDetails")]
        public String callSign
        {
            get
            {
                return _callSign;
            }

            set
            {
                SetValue(ref _callSign, value);
            }
        }

        private categoryOfCommunicationPreference? _categoryOfCommunicationPreference = default;
        [Category("ContactDetails")]
        public categoryOfCommunicationPreference? categoryOfCommunicationPreference
        {
            get
            {
                return _categoryOfCommunicationPreference;
            }

            set
            {
                SetValue(ref _categoryOfCommunicationPreference, value);
            }
        }

        [Category("ContactDetails")]
        public ObservableCollection<String> communicationChannel { get; set; } = new();

        private String _contactInstructions = string.Empty;
        [Category("ContactDetails")]
        public String contactInstructions
        {
            get
            {
                return _contactInstructions;
            }

            set
            {
                SetValue(ref _contactInstructions, value);
            }
        }

        private String _mMSICode = string.Empty;
        [Category("ContactDetails")]
        public String mMSICode
        {
            get
            {
                return _mMSICode;
            }

            set
            {
                SetValue(ref _mMSICode, value);
            }
        }

        [Category("ContactDetails")]
        public ObservableCollection<Int32> signalFrequency { get; set; } = new();

        [Category("ContactDetails")]
        public ObservableCollection<contactAddress> contactAddress { get; set; } = new();

        [Category("ContactDetails")]
        public ObservableCollection<frequencyPair> frequencyPair { get; set; } = new();

        [Category("ContactDetails")]
        public ObservableCollection<onlineResource> onlineResource { get; set; } = new();

        [Category("ContactDetails")]
        public ObservableCollection<telecommunications> telecommunications { get; set; } = new();

        [Category("ContactDetails")]
        public ObservableCollection<information> information { get; set; } = new();

        private categoryOfAuthority? _categoryOfAuthority = default;
        [Category("AbstractRxN")]
        public categoryOfAuthority? categoryOfAuthority
        {
            get
            {
                return _categoryOfAuthority;
            }

            set
            {
                SetValue(ref _categoryOfAuthority, value);
            }
        }

        private textContentViewModel? _textContent;
        [Category("AbstractRxN")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public textContentViewModel? textContent
        {
            get
            {
                return _textContent;
            }

            set
            {
                SetValue(ref _textContent, value);
            }
        }

        [Category("AbstractRxN")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("InformationType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public void Load(DomainModel.S122.InformationTypes.ContactDetails instance)
        {
            callName = instance.callName;
            callSign = instance.callSign;
            categoryOfCommunicationPreference = instance.categoryOfCommunicationPreference;
            communicationChannel.Clear();
            if (instance.communicationChannel is not null)
                foreach (var e in instance.communicationChannel)
                    communicationChannel.Add(e);
            contactInstructions = instance.contactInstructions;
            mMSICode = instance.mMSICode;
            signalFrequency.Clear();
            if (instance.signalFrequency is not null)
                foreach (var e in instance.signalFrequency)
                    signalFrequency.Add(e);
            contactAddress.Clear();
            if (instance.contactAddress is not null)
                foreach (var e in instance.contactAddress)
                    contactAddress.Add(e);
            frequencyPair.Clear();
            if (instance.frequencyPair is not null)
                foreach (var e in instance.frequencyPair)
                    frequencyPair.Add(e);
            onlineResource.Clear();
            if (instance.onlineResource is not null)
                foreach (var e in instance.onlineResource)
                    onlineResource.Add(e);
            telecommunications.Clear();
            if (instance.telecommunications is not null)
                foreach (var e in instance.telecommunications)
                    telecommunications.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            categoryOfAuthority = instance.categoryOfAuthority;
            textContent = new();
            if (instance.textContent != null)
            {
                textContent = new();
                textContent.Load(instance.textContent);
            }

            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.InformationTypes.ContactDetails
            {
                callName = this.callName,
                callSign = this.callSign,
                categoryOfCommunicationPreference = this.categoryOfCommunicationPreference,
                communicationChannel = this.communicationChannel.ToList(),
                contactInstructions = this.contactInstructions,
                mMSICode = this.mMSICode,
                signalFrequency = this.signalFrequency.ToList(),
                contactAddress = this.contactAddress.ToList(),
                frequencyPair = this.frequencyPair.ToList(),
                onlineResource = this.onlineResource.ToList(),
                telecommunications = this.telecommunications.ToList(),
                information = this.information.ToList(),
                categoryOfAuthority = this.categoryOfAuthority,
                textContent = this.textContent?.Model,
                rxNCode = this.rxNCode.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.InformationTypes.ContactDetails Model => new()
        {
            callName = this._callName,
            callSign = this._callSign,
            categoryOfCommunicationPreference = this._categoryOfCommunicationPreference,
            communicationChannel = this.communicationChannel.ToList(),
            contactInstructions = this._contactInstructions,
            mMSICode = this._mMSICode,
            signalFrequency = this.signalFrequency.ToList(),
            contactAddress = this.contactAddress.ToList(),
            frequencyPair = this.frequencyPair.ToList(),
            onlineResource = this.onlineResource.ToList(),
            telecommunications = this.telecommunications.ToList(),
            information = this.information.ToList(),
            categoryOfAuthority = this._categoryOfAuthority,
            textContent = this._textContent?.Model,
            rxNCode = this.rxNCode.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public ContactDetailsViewModel(IViewModelHost? host = null) : base(host)
        {
            communicationChannel.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(communicationChannel));
            };
            signalFrequency.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(signalFrequency));
            };
            contactAddress.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(contactAddress));
            };
            frequencyPair.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(frequencyPair));
            };
            onlineResource.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(onlineResource));
            };
            telecommunications.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(telecommunications));
            };
            information.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(information));
            };
            rxNCode.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            featureName.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
        }
    }

    [CategoryOrder("NonStandardWorkingDay", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class NonStandardWorkingDayViewModel : ViewModelBase
    {
        [Category("NonStandardWorkingDay")]
        public ObservableCollection<DateOnly> dateFixed { get; set; } = new();

        [Category("NonStandardWorkingDay")]
        public ObservableCollection<String> dateVariable { get; set; } = new();

        [Category("NonStandardWorkingDay")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("InformationType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public void Load(DomainModel.S122.InformationTypes.NonStandardWorkingDay instance)
        {
            dateFixed.Clear();
            if (instance.dateFixed is not null)
                foreach (var e in instance.dateFixed)
                    dateFixed.Add(e);
            dateVariable.Clear();
            if (instance.dateVariable is not null)
                foreach (var e in instance.dateVariable)
                    dateVariable.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.InformationTypes.NonStandardWorkingDay
            {
                dateFixed = this.dateFixed.ToList(),
                dateVariable = this.dateVariable.ToList(),
                information = this.information.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.InformationTypes.NonStandardWorkingDay Model => new()
        {
            dateFixed = this.dateFixed.ToList(),
            dateVariable = this.dateVariable.ToList(),
            information = this.information.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public NonStandardWorkingDayViewModel(IViewModelHost? host = null) : base(host)
        {
            dateFixed.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(dateFixed));
            };
            dateVariable.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(dateVariable));
            };
            information.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
        }
    }

    [CategoryOrder("ServiceHours", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ServiceHoursViewModel : ViewModelBase
    {
        [Category("ServiceHours")]
        public ObservableCollection<scheduleByDayOfWeek> scheduleByDayOfWeek { get; set; } = new();

        private informationViewModel _information;
        [Category("ServiceHours")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public informationViewModel information
        {
            get
            {
                return _information;
            }

            set
            {
                SetValue(ref _information, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("InformationType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public void Load(DomainModel.S122.InformationTypes.ServiceHours instance)
        {
            scheduleByDayOfWeek.Clear();
            if (instance.scheduleByDayOfWeek is not null)
                foreach (var e in instance.scheduleByDayOfWeek)
                    scheduleByDayOfWeek.Add(e);
            information = new();
            if (instance.information != null)
            {
                information = new();
                information.Load(instance.information);
            }

            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.InformationTypes.ServiceHours
            {
                scheduleByDayOfWeek = this.scheduleByDayOfWeek.ToList(),
                information = this.information?.Model,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.InformationTypes.ServiceHours Model => new()
        {
            scheduleByDayOfWeek = this.scheduleByDayOfWeek.ToList(),
            information = this._information?.Model,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public ServiceHoursViewModel(IViewModelHost? host = null) : base(host)
        {
            scheduleByDayOfWeek.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(scheduleByDayOfWeek));
            };
            featureName.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
        }
    }

    [CategoryOrder("Applicability", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ApplicabilityViewModel : ViewModelBase
    {
        private Boolean? _inBallast = default;
        [Category("Applicability")]
        public Boolean? inBallast
        {
            get
            {
                return _inBallast;
            }

            set
            {
                SetValue(ref _inBallast, value);
            }
        }

        [Category("Applicability")]
        public ObservableCollection<categoryOfCargo> categoryOfCargo { get; set; } = new();

        [Category("Applicability")]
        public ObservableCollection<categoryOfDangerousOrHazardousCargo> categoryOfDangerousOrHazardousCargo { get; set; } = new();

        private categoryOfVessel? _categoryOfVessel;
        [DomainModel.CodeList(nameof(categoryOfVesselList))]
        [Editor(typeof(Editors.CodeListComboEditor), typeof(Editors.CodeListComboEditor))]
        [Category("Applicability")]
        public categoryOfVessel? categoryOfVessel
        {
            get
            {
                return _categoryOfVessel;
            }

            set
            {
                SetValue(ref _categoryOfVessel, value);
            }
        }

        private categoryOfVesselRegistry? _categoryOfVesselRegistry = default;
        [Category("Applicability")]
        public categoryOfVesselRegistry? categoryOfVesselRegistry
        {
            get
            {
                return _categoryOfVesselRegistry;
            }

            set
            {
                SetValue(ref _categoryOfVesselRegistry, value);
            }
        }

        private logicalConnectives? _logicalConnectives = default;
        [Category("Applicability")]
        public logicalConnectives? logicalConnectives
        {
            get
            {
                return _logicalConnectives;
            }

            set
            {
                SetValue(ref _logicalConnectives, value);
            }
        }

        private Int32? _thicknessOfIceCapability = default;
        [Category("Applicability")]
        public Int32? thicknessOfIceCapability
        {
            get
            {
                return _thicknessOfIceCapability;
            }

            set
            {
                SetValue(ref _thicknessOfIceCapability, value);
            }
        }

        private String _vesselPerformance = string.Empty;
        [Category("Applicability")]
        public String vesselPerformance
        {
            get
            {
                return _vesselPerformance;
            }

            set
            {
                SetValue(ref _vesselPerformance, value);
            }
        }

        [Category("Applicability")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("Applicability")]
        public ObservableCollection<vesselsMeasurements> vesselsMeasurements { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("InformationType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        [Browsable(false)]
        public categoryOfVessel[] categoryOfVesselList => CodeList.categoryOfVessels.ToArray();

        public void Load(DomainModel.S122.InformationTypes.Applicability instance)
        {
            inBallast = instance.inBallast;
            categoryOfCargo.Clear();
            if (instance.categoryOfCargo is not null)
                foreach (var e in instance.categoryOfCargo)
                    categoryOfCargo.Add(e);
            categoryOfDangerousOrHazardousCargo.Clear();
            if (instance.categoryOfDangerousOrHazardousCargo is not null)
                foreach (var e in instance.categoryOfDangerousOrHazardousCargo)
                    categoryOfDangerousOrHazardousCargo.Add(e);
            categoryOfVessel = instance.categoryOfVessel;
            categoryOfVesselRegistry = instance.categoryOfVesselRegistry;
            logicalConnectives = instance.logicalConnectives;
            thicknessOfIceCapability = instance.thicknessOfIceCapability;
            vesselPerformance = instance.vesselPerformance;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            vesselsMeasurements.Clear();
            if (instance.vesselsMeasurements is not null)
                foreach (var e in instance.vesselsMeasurements)
                    vesselsMeasurements.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.InformationTypes.Applicability
            {
                inBallast = this.inBallast,
                categoryOfCargo = this.categoryOfCargo.ToList(),
                categoryOfDangerousOrHazardousCargo = this.categoryOfDangerousOrHazardousCargo.ToList(),
                categoryOfVessel = this.categoryOfVessel,
                categoryOfVesselRegistry = this.categoryOfVesselRegistry,
                logicalConnectives = this.logicalConnectives,
                thicknessOfIceCapability = this.thicknessOfIceCapability,
                vesselPerformance = this.vesselPerformance,
                information = this.information.ToList(),
                vesselsMeasurements = this.vesselsMeasurements.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.InformationTypes.Applicability Model => new()
        {
            inBallast = this._inBallast,
            categoryOfCargo = this.categoryOfCargo.ToList(),
            categoryOfDangerousOrHazardousCargo = this.categoryOfDangerousOrHazardousCargo.ToList(),
            categoryOfVessel = this._categoryOfVessel,
            categoryOfVesselRegistry = this._categoryOfVesselRegistry,
            logicalConnectives = this._logicalConnectives,
            thicknessOfIceCapability = this._thicknessOfIceCapability,
            vesselPerformance = this._vesselPerformance,
            information = this.information.ToList(),
            vesselsMeasurements = this.vesselsMeasurements.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public ApplicabilityViewModel(IViewModelHost? host = null) : base(host)
        {
            categoryOfCargo.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(categoryOfCargo));
            };
            categoryOfDangerousOrHazardousCargo.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(categoryOfDangerousOrHazardousCargo));
            };
            information.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(information));
            };
            vesselsMeasurements.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(vesselsMeasurements));
            };
            featureName.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
        }
    }

    [CategoryOrder("RestrictedArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class RestrictedAreaViewModel : ViewModelBase
    {
        [Category("RestrictedArea")]
        public ObservableCollection<categoryOfRestrictedArea> categoryOfRestrictedArea { get; set; } = new();

        [Category("RestrictedArea")]
        public ObservableCollection<restriction> restriction { get; set; } = new();

        [Category("RestrictedArea")]
        public ObservableCollection<status> status { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        private String _interoperabilityIdentifier = string.Empty;
        [Category("FeatureType")]
        public String interoperabilityIdentifier
        {
            get
            {
                return _interoperabilityIdentifier;
            }

            set
            {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("FeatureType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public void Load(DomainModel.S122.FeatureTypes.RestrictedArea instance)
        {
            categoryOfRestrictedArea.Clear();
            if (instance.categoryOfRestrictedArea is not null)
                foreach (var e in instance.categoryOfRestrictedArea)
                    categoryOfRestrictedArea.Add(e);
            restriction.Clear();
            if (instance.restriction is not null)
                foreach (var e in instance.restriction)
                    restriction.Add(e);
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.FeatureTypes.RestrictedArea
            {
                categoryOfRestrictedArea = this.categoryOfRestrictedArea.ToList(),
                restriction = this.restriction.ToList(),
                status = this.status.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                textContent = this.textContent.ToList(),
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.FeatureTypes.RestrictedArea Model => new()
        {
            categoryOfRestrictedArea = this.categoryOfRestrictedArea.ToList(),
            restriction = this.restriction.ToList(),
            status = this.status.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            textContent = this.textContent.ToList(),
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public RestrictedAreaViewModel(IViewModelHost? host = null) : base(host)
        {
            categoryOfRestrictedArea.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(categoryOfRestrictedArea));
            };
            restriction.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(restriction));
            };
            status.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(status));
            };
            featureName.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            textContent.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("MarineProtectedArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class MarineProtectedAreaViewModel : ViewModelBase
    {
        private categoryOfMarineProtectedArea _categoryOfMarineProtectedArea;
        [DomainModel.CodeList(nameof(categoryOfMarineProtectedAreaList))]
        [Editor(typeof(Editors.CodeListComboEditor), typeof(Editors.CodeListComboEditor))]
        [Category("MarineProtectedArea")]
        public categoryOfMarineProtectedArea categoryOfMarineProtectedArea
        {
            get
            {
                return _categoryOfMarineProtectedArea;
            }

            set
            {
                SetValue(ref _categoryOfMarineProtectedArea, value);
            }
        }

        [Category("MarineProtectedArea")]
        public ObservableCollection<categoryOfRestrictedArea> categoryOfRestrictedArea { get; set; } = new();

        private jurisdiction _jurisdiction;
        [Category("MarineProtectedArea")]
        public jurisdiction jurisdiction
        {
            get
            {
                return _jurisdiction;
            }

            set
            {
                SetValue(ref _jurisdiction, value);
            }
        }

        [Category("MarineProtectedArea")]
        public ObservableCollection<restriction> restriction { get; set; } = new();

        [Category("MarineProtectedArea")]
        public ObservableCollection<status> status { get; set; } = new();

        [Category("MarineProtectedArea")]
        public ObservableCollection<designation> designation { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        private String _interoperabilityIdentifier = string.Empty;
        [Category("FeatureType")]
        public String interoperabilityIdentifier
        {
            get
            {
                return _interoperabilityIdentifier;
            }

            set
            {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("FeatureType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        [Browsable(false)]
        public categoryOfMarineProtectedArea[] categoryOfMarineProtectedAreaList => CodeList.categoryOfMarineProtectedAreas.ToArray();

        public void Load(DomainModel.S122.FeatureTypes.MarineProtectedArea instance)
        {
            categoryOfMarineProtectedArea = instance.categoryOfMarineProtectedArea;
            categoryOfRestrictedArea.Clear();
            if (instance.categoryOfRestrictedArea is not null)
                foreach (var e in instance.categoryOfRestrictedArea)
                    categoryOfRestrictedArea.Add(e);
            jurisdiction = instance.jurisdiction;
            restriction.Clear();
            if (instance.restriction is not null)
                foreach (var e in instance.restriction)
                    restriction.Add(e);
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            designation.Clear();
            if (instance.designation is not null)
                foreach (var e in instance.designation)
                    designation.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.FeatureTypes.MarineProtectedArea
            {
                categoryOfMarineProtectedArea = this.categoryOfMarineProtectedArea,
                categoryOfRestrictedArea = this.categoryOfRestrictedArea.ToList(),
                jurisdiction = this.jurisdiction,
                restriction = this.restriction.ToList(),
                status = this.status.ToList(),
                designation = this.designation.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                textContent = this.textContent.ToList(),
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.FeatureTypes.MarineProtectedArea Model => new()
        {
            categoryOfMarineProtectedArea = this._categoryOfMarineProtectedArea,
            categoryOfRestrictedArea = this.categoryOfRestrictedArea.ToList(),
            jurisdiction = this._jurisdiction,
            restriction = this.restriction.ToList(),
            status = this.status.ToList(),
            designation = this.designation.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            textContent = this.textContent.ToList(),
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public MarineProtectedAreaViewModel(IViewModelHost? host = null) : base(host)
        {
            categoryOfRestrictedArea.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(categoryOfRestrictedArea));
            };
            restriction.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(restriction));
            };
            status.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(status));
            };
            designation.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(designation));
            };
            featureName.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            textContent.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("VesselTrafficServiceArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class VesselTrafficServiceAreaViewModel : ViewModelBase
    {
        private categoryOfVesselTrafficService _categoryOfVesselTrafficService;
        [Category("VesselTrafficServiceArea")]
        public categoryOfVesselTrafficService categoryOfVesselTrafficService
        {
            get
            {
                return _categoryOfVesselTrafficService;
            }

            set
            {
                SetValue(ref _categoryOfVesselTrafficService, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        private String _interoperabilityIdentifier = string.Empty;
        [Category("FeatureType")]
        public String interoperabilityIdentifier
        {
            get
            {
                return _interoperabilityIdentifier;
            }

            set
            {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("FeatureType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public void Load(DomainModel.S122.FeatureTypes.VesselTrafficServiceArea instance)
        {
            categoryOfVesselTrafficService = instance.categoryOfVesselTrafficService;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.FeatureTypes.VesselTrafficServiceArea
            {
                categoryOfVesselTrafficService = this.categoryOfVesselTrafficService,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                textContent = this.textContent.ToList(),
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.FeatureTypes.VesselTrafficServiceArea Model => new()
        {
            categoryOfVesselTrafficService = this._categoryOfVesselTrafficService,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            textContent = this.textContent.ToList(),
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public VesselTrafficServiceAreaViewModel(IViewModelHost? host = null) : base(host)
        {
            featureName.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            textContent.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("DataCoverage", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class DataCoverageViewModel : ViewModelBase
    {
        public void Load(DomainModel.S122.FeatureTypes.DataCoverage instance)
        {
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.FeatureTypes.DataCoverage
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.FeatureTypes.DataCoverage Model => new()
        {
        };

        public DataCoverageViewModel(IViewModelHost? host = null) : base(host)
        {
        }
    }

    [CategoryOrder("TextPlacement", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class TextPlacementViewModel : ViewModelBase
    {
        public void Load(DomainModel.S122.FeatureTypes.TextPlacement instance)
        {
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S122.FeatureTypes.TextPlacement
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.FeatureTypes.TextPlacement Model => new()
        {
        };

        public TextPlacementViewModel(IViewModelHost? host = null) : base(host)
        {
        }
    }

    public class AssociatedRxNViewModel : InformationAssociationViewModel
    {
        public override string Code => "AssociatedRxN";
        public override string[] Roles => ["theRxN", "appliesInLocation"];

        private InformationBinding? _theRxN;
        [ExpandableObject]
        public InformationBinding? theRxN
        {
            get { return _theRxN; }
            set { this.SetValue(ref _theRxN, value); }
        }
        private InformationBinding? _appliesInLocation;
        [ExpandableObject]
        public InformationBinding? appliesInLocation
        {
            get { return _appliesInLocation; }
            set { this.SetValue(ref _appliesInLocation, value); }
        }

        public override InformationAssociationConnector? associationConnector
        {
            get { return _associationConnector; }
            set
            {
                this.SetValue(ref _associationConnector, value);
                theRxN = null;
                if (value is not null)
                {
                    theRxN = value?.role switch
                    {
                        "appliesInLocation" => (!value.Upper.HasValue || value.Upper.Value > 1) ? new InformationBindingMulti
                        {
                            InformationTypes = value.AssociationTypes,
                        } : value.Lower > 0 ? new InformationBindingSingle
                        {
                            InformationTypes = value.AssociationTypes,
                        } : new InformationBindingOptional
                        {
                            InformationTypes = value.AssociationTypes,
                        },
                        _ => new InformationBindingSingle()
                        {
                            InformationTypes = [value!.InformationType],
                        },
                    };
                }
                appliesInLocation = null;
                if (value is not null)
                {
                    appliesInLocation = value?.role switch
                    {
                        "theRxN" => (!value.Upper.HasValue || value.Upper.Value > 1) ? new InformationBindingMulti
                        {
                            InformationTypes = value.AssociationTypes,
                        } : value.Lower > 0 ? new InformationBindingSingle
                        {
                            InformationTypes = value.AssociationTypes,
                        } : new InformationBindingOptional
                        {
                            InformationTypes = value.AssociationTypes,
                        },
                        _ => new InformationBindingSingle()
                        {
                            InformationTypes = [value!.InformationType],
                        },
                    };
                }
            }
        }
        public override InformationAssociationConnector[] associationConnectorInformations => AssociatedRxNViewModel._associationConnectorInformations;
        public static InformationAssociationConnector[] _associationConnectorInformations => new InformationAssociationConnector[] {
                new InformationAssociationConnector<FeatureType>() {
                    roleType = roleType.association,
                    role = "theRxN",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(AbstractRxN)],
                },
            };
    }

    public class ExceptionalWorkdayViewModel : InformationAssociationViewModel
    {
        public override string Code => "ExceptionalWorkday";
        public override string[] Roles => ["partialWorkingDay", "theServiceHours_nsdy"];

        private InformationBinding? _partialWorkingDay;
        [ExpandableObject]
        public InformationBinding? partialWorkingDay
        {
            get { return _partialWorkingDay; }
            set { this.SetValue(ref _partialWorkingDay, value); }
        }
        private InformationBinding? _theServiceHours_nsdy;
        [ExpandableObject]
        public InformationBinding? theServiceHours_nsdy
        {
            get { return _theServiceHours_nsdy; }
            set { this.SetValue(ref _theServiceHours_nsdy, value); }
        }

        public override InformationAssociationConnector? associationConnector
        {
            get { return _associationConnector; }
            set
            {
                this.SetValue(ref _associationConnector, value);
                partialWorkingDay = null;
                if (value is not null)
                {
                    partialWorkingDay = value?.role switch
                    {
                        "theServiceHours_nsdy" => (!value.Upper.HasValue || value.Upper.Value > 1) ? new InformationBindingMulti
                        {
                            InformationTypes = value.AssociationTypes,
                        } : value.Lower > 0 ? new InformationBindingSingle
                        {
                            InformationTypes = value.AssociationTypes,
                        } : new InformationBindingOptional
                        {
                            InformationTypes = value.AssociationTypes,
                        },
                        _ => new InformationBindingSingle()
                        {
                            InformationTypes = [value!.InformationType],
                        },
                    };
                }
                theServiceHours_nsdy = null;
                if (value is not null)
                {
                    theServiceHours_nsdy = value?.role switch
                    {
                        "partialWorkingDay" => (!value.Upper.HasValue || value.Upper.Value > 1) ? new InformationBindingMulti
                        {
                            InformationTypes = value.AssociationTypes,
                        } : value.Lower > 0 ? new InformationBindingSingle
                        {
                            InformationTypes = value.AssociationTypes,
                        } : new InformationBindingOptional
                        {
                            InformationTypes = value.AssociationTypes,
                        },
                        _ => new InformationBindingSingle()
                        {
                            InformationTypes = [value!.InformationType],
                        },
                    };
                }
            }
        }
        public override InformationAssociationConnector[] associationConnectorInformations => ExceptionalWorkdayViewModel._associationConnectorInformations;
        public static InformationAssociationConnector[] _associationConnectorInformations => new InformationAssociationConnector[] {
                new InformationAssociationConnector<ServiceHours>() {
                    roleType = roleType.association,
                    role = "partialWorkingDay",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NonStandardWorkingDay)],
                },
                new InformationAssociationConnector<NonStandardWorkingDay>() {
                    roleType = roleType.association,
                    role = "theServiceHours_nsdy",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ServiceHours)],
                },
            };
    }

    public class ProtectedAreaAuthorityViewModel : InformationAssociationViewModel
    {
        public override string Code => "ProtectedAreaAuthority";
        public override string[] Roles => ["responsibleAuthority", "theMarineProtectedArea"];

        private InformationBinding? _responsibleAuthority;
        [ExpandableObject]
        public InformationBinding? responsibleAuthority
        {
            get { return _responsibleAuthority; }
            set { this.SetValue(ref _responsibleAuthority, value); }
        }
        private InformationBinding? _theMarineProtectedArea;
        [ExpandableObject]
        public InformationBinding? theMarineProtectedArea
        {
            get { return _theMarineProtectedArea; }
            set { this.SetValue(ref _theMarineProtectedArea, value); }
        }

        public override InformationAssociationConnector? associationConnector
        {
            get { return _associationConnector; }
            set
            {
                this.SetValue(ref _associationConnector, value);
                responsibleAuthority = null;
                if (value is not null)
                {
                    responsibleAuthority = value?.role switch
                    {
                        "theMarineProtectedArea" => (!value.Upper.HasValue || value.Upper.Value > 1) ? new InformationBindingMulti
                        {
                            InformationTypes = value.AssociationTypes,
                        } : value.Lower > 0 ? new InformationBindingSingle
                        {
                            InformationTypes = value.AssociationTypes,
                        } : new InformationBindingOptional
                        {
                            InformationTypes = value.AssociationTypes,
                        },
                        _ => new InformationBindingSingle()
                        {
                            InformationTypes = [value!.InformationType],
                        },
                    };
                }
                theMarineProtectedArea = null;
                if (value is not null)
                {
                    theMarineProtectedArea = value?.role switch
                    {
                        "responsibleAuthority" => (!value.Upper.HasValue || value.Upper.Value > 1) ? new InformationBindingMulti
                        {
                            InformationTypes = value.AssociationTypes,
                        } : value.Lower > 0 ? new InformationBindingSingle
                        {
                            InformationTypes = value.AssociationTypes,
                        } : new InformationBindingOptional
                        {
                            InformationTypes = value.AssociationTypes,
                        },
                        _ => new InformationBindingSingle()
                        {
                            InformationTypes = [value!.InformationType],
                        },
                    };
                }
            }
        }
        public override InformationAssociationConnector[] associationConnectorInformations => ProtectedAreaAuthorityViewModel._associationConnectorInformations;
        public static InformationAssociationConnector[] _associationConnectorInformations => new InformationAssociationConnector[] {
                new InformationAssociationConnector<MarineProtectedArea>() {
                    roleType = roleType.association,
                    role = "responsibleAuthority",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Authority)],
                },
            };
    }

    public class ServiceControlViewModel : InformationAssociationViewModel
    {
        public override string Code => "ServiceControl";
        public override string[] Roles => ["controlAuthority", "controlledService"];

        private InformationBinding? _controlAuthority;
        [ExpandableObject]
        public InformationBinding? controlAuthority
        {
            get { return _controlAuthority; }
            set { this.SetValue(ref _controlAuthority, value); }
        }
        private InformationBinding? _controlledService;
        [ExpandableObject]
        public InformationBinding? controlledService
        {
            get { return _controlledService; }
            set { this.SetValue(ref _controlledService, value); }
        }

        public override InformationAssociationConnector? associationConnector
        {
            get { return _associationConnector; }
            set
            {
                this.SetValue(ref _associationConnector, value);
                controlAuthority = null;
                if (value is not null)
                {
                    controlAuthority = value?.role switch
                    {
                        "controlledService" => (!value.Upper.HasValue || value.Upper.Value > 1) ? new InformationBindingMulti
                        {
                            InformationTypes = value.AssociationTypes,
                        } : value.Lower > 0 ? new InformationBindingSingle
                        {
                            InformationTypes = value.AssociationTypes,
                        } : new InformationBindingOptional
                        {
                            InformationTypes = value.AssociationTypes,
                        },
                        _ => new InformationBindingSingle()
                        {
                            InformationTypes = [value!.InformationType],
                        },
                    };
                }
                controlledService = null;
                if (value is not null)
                {
                    controlledService = value?.role switch
                    {
                        "controlAuthority" => (!value.Upper.HasValue || value.Upper.Value > 1) ? new InformationBindingMulti
                        {
                            InformationTypes = value.AssociationTypes,
                        } : value.Lower > 0 ? new InformationBindingSingle
                        {
                            InformationTypes = value.AssociationTypes,
                        } : new InformationBindingOptional
                        {
                            InformationTypes = value.AssociationTypes,
                        },
                        _ => new InformationBindingSingle()
                        {
                            InformationTypes = [value!.InformationType],
                        },
                    };
                }
            }
        }
        public override InformationAssociationConnector[] associationConnectorInformations => ServiceControlViewModel._associationConnectorInformations;
        public static InformationAssociationConnector[] _associationConnectorInformations => new InformationAssociationConnector[] {
                new InformationAssociationConnector<VesselTrafficServiceArea>() {
                    roleType = roleType.association,
                    role = "controlAuthority",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(Authority)],
                },
            };
    }

    public class RelatedOrganisationViewModel : InformationAssociationViewModel
    {
        public override string Code => "RelatedOrganisation";
        public override string[] Roles => ["theOrganisation", "theInformation"];

        private InformationBinding? _theOrganisation;
        [ExpandableObject]
        public InformationBinding? theOrganisation
        {
            get { return _theOrganisation; }
            set { this.SetValue(ref _theOrganisation, value); }
        }
        private InformationBinding? _theInformation;
        [ExpandableObject]
        public InformationBinding? theInformation
        {
            get { return _theInformation; }
            set { this.SetValue(ref _theInformation, value); }
        }

        public override InformationAssociationConnector? associationConnector
        {
            get { return _associationConnector; }
            set
            {
                this.SetValue(ref _associationConnector, value);
                theOrganisation = null;
                if (value is not null)
                {
                    theOrganisation = value?.role switch
                    {
                        "theInformation" => (!value.Upper.HasValue || value.Upper.Value > 1) ? new InformationBindingMulti
                        {
                            InformationTypes = value.AssociationTypes,
                        } : value.Lower > 0 ? new InformationBindingSingle
                        {
                            InformationTypes = value.AssociationTypes,
                        } : new InformationBindingOptional
                        {
                            InformationTypes = value.AssociationTypes,
                        },
                        _ => new InformationBindingSingle()
                        {
                            InformationTypes = [value!.InformationType],
                        },
                    };
                }
                theInformation = null;
                if (value is not null)
                {
                    theInformation = value?.role switch
                    {
                        "theOrganisation" => (!value.Upper.HasValue || value.Upper.Value > 1) ? new InformationBindingMulti
                        {
                            InformationTypes = value.AssociationTypes,
                        } : value.Lower > 0 ? new InformationBindingSingle
                        {
                            InformationTypes = value.AssociationTypes,
                        } : new InformationBindingOptional
                        {
                            InformationTypes = value.AssociationTypes,
                        },
                        _ => new InformationBindingSingle()
                        {
                            InformationTypes = [value!.InformationType],
                        },
                    };
                }
            }
        }
        public override InformationAssociationConnector[] associationConnectorInformations => RelatedOrganisationViewModel._associationConnectorInformations;
        public static InformationAssociationConnector[] _associationConnectorInformations => new InformationAssociationConnector[] {
                new InformationAssociationConnector<Authority>() {
                    roleType = roleType.association,
                    role = "theInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(AbstractRxN)],
                },
                new InformationAssociationConnector<AbstractRxN>() {
                    roleType = roleType.association,
                    role = "theOrganisation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Authority)],
                },
                new InformationAssociationConnector<NauticalInformation>() {
                    roleType = roleType.association,
                    role = "theOrganisation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Authority)],
                },
            };
    }

    public class PermissionTypeViewModel : InformationAssociationViewModel
    {
        public override string Code => "PermissionType";
        public override string[] Roles => ["vslLocation", "permission"];

        private InformationBinding? _vslLocation;
        [ExpandableObject]
        public InformationBinding? vslLocation
        {
            get { return _vslLocation; }
            set { this.SetValue(ref _vslLocation, value); }
        }
        private InformationBinding? _permission;
        [ExpandableObject]
        public InformationBinding? permission
        {
            get { return _permission; }
            set { this.SetValue(ref _permission, value); }
        }

        public override InformationAssociationConnector? associationConnector
        {
            get { return _associationConnector; }
            set
            {
                this.SetValue(ref _associationConnector, value);
                vslLocation = null;
                if (value is not null)
                {
                    vslLocation = value?.role switch
                    {
                        "permission" => (!value.Upper.HasValue || value.Upper.Value > 1) ? new InformationBindingMulti
                        {
                            InformationTypes = value.AssociationTypes,
                        } : value.Lower > 0 ? new InformationBindingSingle
                        {
                            InformationTypes = value.AssociationTypes,
                        } : new InformationBindingOptional
                        {
                            InformationTypes = value.AssociationTypes,
                        },
                        _ => new InformationBindingSingle()
                        {
                            InformationTypes = [value!.InformationType],
                        },
                    };
                }
                permission = null;
                if (value is not null)
                {
                    permission = value?.role switch
                    {
                        "vslLocation" => (!value.Upper.HasValue || value.Upper.Value > 1) ? new InformationBindingMulti
                        {
                            InformationTypes = value.AssociationTypes,
                        } : value.Lower > 0 ? new InformationBindingSingle
                        {
                            InformationTypes = value.AssociationTypes,
                        } : new InformationBindingOptional
                        {
                            InformationTypes = value.AssociationTypes,
                        },
                        _ => new InformationBindingSingle()
                        {
                            InformationTypes = [value!.InformationType],
                        },
                    };
                }
            }
        }
        public override InformationAssociationConnector[] associationConnectorInformations => PermissionTypeViewModel._associationConnectorInformations;
        public static InformationAssociationConnector[] _associationConnectorInformations => new InformationAssociationConnector[] {
            };
    }

    public class InclusionTypeViewModel : InformationAssociationViewModel
    {
        public override string Code => "InclusionType";
        public override string[] Roles => ["theApplicationRXN", "isApplicableTo"];

        private InformationBinding? _theApplicationRXN;
        [ExpandableObject]
        public InformationBinding? theApplicationRXN
        {
            get { return _theApplicationRXN; }
            set { this.SetValue(ref _theApplicationRXN, value); }
        }
        private InformationBinding? _isApplicableTo;
        [ExpandableObject]
        public InformationBinding? isApplicableTo
        {
            get { return _isApplicableTo; }
            set { this.SetValue(ref _isApplicableTo, value); }
        }

        public override InformationAssociationConnector? associationConnector
        {
            get { return _associationConnector; }
            set
            {
                this.SetValue(ref _associationConnector, value);
                theApplicationRXN = null;
                if (value is not null)
                {
                    theApplicationRXN = value?.role switch
                    {
                        "isApplicableTo" => (!value.Upper.HasValue || value.Upper.Value > 1) ? new InformationBindingMulti
                        {
                            InformationTypes = value.AssociationTypes,
                        } : value.Lower > 0 ? new InformationBindingSingle
                        {
                            InformationTypes = value.AssociationTypes,
                        } : new InformationBindingOptional
                        {
                            InformationTypes = value.AssociationTypes,
                        },
                        _ => new InformationBindingSingle()
                        {
                            InformationTypes = [value!.InformationType],
                        },
                    };
                }
                isApplicableTo = null;
                if (value is not null)
                {
                    isApplicableTo = value?.role switch
                    {
                        "theApplicationRXN" => (!value.Upper.HasValue || value.Upper.Value > 1) ? new InformationBindingMulti
                        {
                            InformationTypes = value.AssociationTypes,
                        } : value.Lower > 0 ? new InformationBindingSingle
                        {
                            InformationTypes = value.AssociationTypes,
                        } : new InformationBindingOptional
                        {
                            InformationTypes = value.AssociationTypes,
                        },
                        _ => new InformationBindingSingle()
                        {
                            InformationTypes = [value!.InformationType],
                        },
                    };
                }
            }
        }
        public override InformationAssociationConnector[] associationConnectorInformations => InclusionTypeViewModel._associationConnectorInformations;
        public static InformationAssociationConnector[] _associationConnectorInformations => new InformationAssociationConnector[] {
            };
    }

    public class AuthorityContactViewModel : InformationAssociationViewModel
    {
        public override string Code => "AuthorityContact";
        public override string[] Roles => ["theAuthority", "theContactDetails"];

        private InformationBinding? _theAuthority;
        [ExpandableObject]
        public InformationBinding? theAuthority
        {
            get { return _theAuthority; }
            set { this.SetValue(ref _theAuthority, value); }
        }
        private InformationBinding? _theContactDetails;
        [ExpandableObject]
        public InformationBinding? theContactDetails
        {
            get { return _theContactDetails; }
            set { this.SetValue(ref _theContactDetails, value); }
        }

        public override InformationAssociationConnector? associationConnector
        {
            get { return _associationConnector; }
            set
            {
                this.SetValue(ref _associationConnector, value);
                theAuthority = null;
                if (value is not null)
                {
                    theAuthority = value?.role switch
                    {
                        "theContactDetails" => (!value.Upper.HasValue || value.Upper.Value > 1) ? new InformationBindingMulti
                        {
                            InformationTypes = value.AssociationTypes,
                        } : value.Lower > 0 ? new InformationBindingSingle
                        {
                            InformationTypes = value.AssociationTypes,
                        } : new InformationBindingOptional
                        {
                            InformationTypes = value.AssociationTypes,
                        },
                        _ => new InformationBindingSingle()
                        {
                            InformationTypes = [value!.InformationType],
                        },
                    };
                }
                theContactDetails = null;
                if (value is not null)
                {
                    theContactDetails = value?.role switch
                    {
                        "theAuthority" => (!value.Upper.HasValue || value.Upper.Value > 1) ? new InformationBindingMulti
                        {
                            InformationTypes = value.AssociationTypes,
                        } : value.Lower > 0 ? new InformationBindingSingle
                        {
                            InformationTypes = value.AssociationTypes,
                        } : new InformationBindingOptional
                        {
                            InformationTypes = value.AssociationTypes,
                        },
                        _ => new InformationBindingSingle()
                        {
                            InformationTypes = [value!.InformationType],
                        },
                    };
                }
            }
        }
        public override InformationAssociationConnector[] associationConnectorInformations => AuthorityContactViewModel._associationConnectorInformations;
        public static InformationAssociationConnector[] _associationConnectorInformations => new InformationAssociationConnector[] {
                new InformationAssociationConnector<ContactDetails>() {
                    roleType = roleType.association,
                    role = "theAuthority",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Authority)],
                },
                new InformationAssociationConnector<Authority>() {
                    roleType = roleType.association,
                    role = "theContactDetails",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ContactDetails)],
                },
            };
    }

    public class AuthorityHoursViewModel : InformationAssociationViewModel
    {
        public override string Code => "AuthorityHours";
        public override string[] Roles => ["theAuthority_srvHrs", "theServiceHours"];

        private InformationBinding? _theAuthority_srvHrs;
        [ExpandableObject]
        public InformationBinding? theAuthority_srvHrs
        {
            get { return _theAuthority_srvHrs; }
            set { this.SetValue(ref _theAuthority_srvHrs, value); }
        }
        private InformationBinding? _theServiceHours;
        [ExpandableObject]
        public InformationBinding? theServiceHours
        {
            get { return _theServiceHours; }
            set { this.SetValue(ref _theServiceHours, value); }
        }

        public override InformationAssociationConnector? associationConnector
        {
            get { return _associationConnector; }
            set
            {
                this.SetValue(ref _associationConnector, value);
                theAuthority_srvHrs = null;
                if (value is not null)
                {
                    theAuthority_srvHrs = value?.role switch
                    {
                        "theServiceHours" => (!value.Upper.HasValue || value.Upper.Value > 1) ? new InformationBindingMulti
                        {
                            InformationTypes = value.AssociationTypes,
                        } : value.Lower > 0 ? new InformationBindingSingle
                        {
                            InformationTypes = value.AssociationTypes,
                        } : new InformationBindingOptional
                        {
                            InformationTypes = value.AssociationTypes,
                        },
                        _ => new InformationBindingSingle()
                        {
                            InformationTypes = [value!.InformationType],
                        },
                    };
                }
                theServiceHours = null;
                if (value is not null)
                {
                    theServiceHours = value?.role switch
                    {
                        "theAuthority_srvHrs" => (!value.Upper.HasValue || value.Upper.Value > 1) ? new InformationBindingMulti
                        {
                            InformationTypes = value.AssociationTypes,
                        } : value.Lower > 0 ? new InformationBindingSingle
                        {
                            InformationTypes = value.AssociationTypes,
                        } : new InformationBindingOptional
                        {
                            InformationTypes = value.AssociationTypes,
                        },
                        _ => new InformationBindingSingle()
                        {
                            InformationTypes = [value!.InformationType],
                        },
                    };
                }
            }
        }
        public override InformationAssociationConnector[] associationConnectorInformations => AuthorityHoursViewModel._associationConnectorInformations;
        public static InformationAssociationConnector[] _associationConnectorInformations => new InformationAssociationConnector[] {
                new InformationAssociationConnector<ServiceHours>() {
                    roleType = roleType.association,
                    role = "theAuthority_srvHrs",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Authority)],
                },
                new InformationAssociationConnector<Authority>() {
                    roleType = roleType.association,
                    role = "theServiceHours",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ServiceHours)],
                },
            };
    }

    public class additionalInformationViewModel : InformationAssociationViewModel
    {
        public override string Code => "additionalInformation";
        public override string[] Roles => ["informationProvidedFor", "providesInformation"];

        private InformationBinding? _informationProvidedFor;
        [ExpandableObject]
        public InformationBinding? informationProvidedFor
        {
            get { return _informationProvidedFor; }
            set { this.SetValue(ref _informationProvidedFor, value); }
        }
        private InformationBinding? _providesInformation;
        [ExpandableObject]
        public InformationBinding? providesInformation
        {
            get { return _providesInformation; }
            set { this.SetValue(ref _providesInformation, value); }
        }

        public override InformationAssociationConnector? associationConnector
        {
            get { return _associationConnector; }
            set
            {
                this.SetValue(ref _associationConnector, value);
                informationProvidedFor = null;
                if (value is not null)
                {
                    informationProvidedFor = value?.role switch
                    {
                        "providesInformation" => (!value.Upper.HasValue || value.Upper.Value > 1) ? new InformationBindingMulti
                        {
                            InformationTypes = value.AssociationTypes,
                        } : value.Lower > 0 ? new InformationBindingSingle
                        {
                            InformationTypes = value.AssociationTypes,
                        } : new InformationBindingOptional
                        {
                            InformationTypes = value.AssociationTypes,
                        },
                        _ => new InformationBindingSingle()
                        {
                            InformationTypes = [value!.InformationType],
                        },
                    };
                }
                providesInformation = null;
                if (value is not null)
                {
                    providesInformation = value?.role switch
                    {
                        "informationProvidedFor" => (!value.Upper.HasValue || value.Upper.Value > 1) ? new InformationBindingMulti
                        {
                            InformationTypes = value.AssociationTypes,
                        } : value.Lower > 0 ? new InformationBindingSingle
                        {
                            InformationTypes = value.AssociationTypes,
                        } : new InformationBindingOptional
                        {
                            InformationTypes = value.AssociationTypes,
                        },
                        _ => new InformationBindingSingle()
                        {
                            InformationTypes = [value!.InformationType],
                        },
                    };
                }
            }
        }
        public override InformationAssociationConnector[] associationConnectorInformations => additionalInformationViewModel._associationConnectorInformations;
        public static InformationAssociationConnector[] _associationConnectorInformations => new InformationAssociationConnector[] {
                new InformationAssociationConnector<FeatureType>() {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                },
            };
    }
}