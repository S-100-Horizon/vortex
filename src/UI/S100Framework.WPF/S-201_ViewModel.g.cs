using System;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using S100Framework.DomainModel.S201;
using S100Framework.DomainModel.S201.ComplexAttributes;
using S100Framework.DomainModel.S201.InformationTypes;
using S100Framework.DomainModel.S201.FeatureTypes;

namespace S100Framework.WPF.ViewModel.S201
{
    internal static class Preamble
    {
        public static ImmutableDictionary<string, Func<ViewModelBase>> _creators => ImmutableDictionary.Create<string, Func<ViewModelBase>>().AddRange(new Dictionary<string, Func<ViewModelBase>> { { typeof(DomainModel.S201.InformationTypes.AtoNStatusInformation).Name, () =>
        {
            return new AtoNStatusInformationViewModel();
        } }, { typeof(DomainModel.S201.InformationTypes.SpatialUncertainty).Name, () =>
        {
            return new SpatialUncertaintyViewModel();
        } }, { typeof(DomainModel.S201.FeatureTypes.Aggregation).Name, () =>
        {
            return new AggregationViewModel();
        } }, { typeof(DomainModel.S201.FeatureTypes.Association).Name, () =>
        {
            return new AssociationViewModel();
        } }, { typeof(DomainModel.S201.FeatureTypes.DataCoverage).Name, () =>
        {
            return new DataCoverageViewModel();
        } }, { typeof(DomainModel.S201.FeatureTypes.LocalDirectionOfBuoyage).Name, () =>
        {
            return new LocalDirectionOfBuoyageViewModel();
        } }, { typeof(DomainModel.S201.FeatureTypes.NavigationalSystemOfMarks).Name, () =>
        {
            return new NavigationalSystemOfMarksViewModel();
        } }, { typeof(DomainModel.S201.FeatureTypes.QualityOfNonBathymetricData).Name, () =>
        {
            return new QualityOfNonBathymetricDataViewModel();
        } }, { typeof(DomainModel.S201.FeatureTypes.SoundingDatum).Name, () =>
        {
            return new SoundingDatumViewModel();
        } }, { typeof(DomainModel.S201.FeatureTypes.VerticalDatumOfData).Name, () =>
        {
            return new VerticalDatumOfDataViewModel();
        } }, });
    }

    public class changeDetailsViewModel : ViewModelBase
    {
        private buoyChange? _buoyChange = default;
        [Category("changeDetails")]
        public buoyChange? buoyChange
        {
            get
            {
                return _buoyChange;
            }

            set
            {
                SetValue(ref _buoyChange, value);
            }
        }

        private lightChange _lightChange;
        [Category("changeDetails")]
        public lightChange lightChange
        {
            get
            {
                return _lightChange;
            }

            set
            {
                SetValue(ref _lightChange, value);
            }
        }

        private beaconChange _beaconChange;
        [Category("changeDetails")]
        public beaconChange beaconChange
        {
            get
            {
                return _beaconChange;
            }

            set
            {
                SetValue(ref _beaconChange, value);
            }
        }

        private leadingLightsChange _leadingLightsChange;
        [Category("changeDetails")]
        public leadingLightsChange leadingLightsChange
        {
            get
            {
                return _leadingLightsChange;
            }

            set
            {
                SetValue(ref _leadingLightsChange, value);
            }
        }

        private fogSignals _fogSignals;
        [Category("changeDetails")]
        public fogSignals fogSignals
        {
            get
            {
                return _fogSignals;
            }

            set
            {
                SetValue(ref _fogSignals, value);
            }
        }

        private radioAidsChange _radioAidsChange;
        [Category("changeDetails")]
        public radioAidsChange radioAidsChange
        {
            get
            {
                return _radioAidsChange;
            }

            set
            {
                SetValue(ref _radioAidsChange, value);
            }
        }

        private atonCommissioning _atonCommissioning;
        [Category("changeDetails")]
        public atonCommissioning atonCommissioning
        {
            get
            {
                return _atonCommissioning;
            }

            set
            {
                SetValue(ref _atonCommissioning, value);
            }
        }

        private atonReplacement _atonReplacement;
        [Category("changeDetails")]
        public atonReplacement atonReplacement
        {
            get
            {
                return _atonReplacement;
            }

            set
            {
                SetValue(ref _atonReplacement, value);
            }
        }

        private atonRemoval _atonRemoval;
        [Category("changeDetails")]
        public atonRemoval atonRemoval
        {
            get
            {
                return _atonRemoval;
            }

            set
            {
                SetValue(ref _atonRemoval, value);
            }
        }

        public void Load(DomainModel.S201.ComplexAttributes.changeDetails instance)
        {
            buoyChange = instance.buoyChange;
            lightChange = instance.lightChange;
            beaconChange = instance.beaconChange;
            leadingLightsChange = instance.leadingLightsChange;
            fogSignals = instance.fogSignals;
            radioAidsChange = instance.radioAidsChange;
            atonCommissioning = instance.atonCommissioning;
            atonReplacement = instance.atonReplacement;
            atonRemoval = instance.atonRemoval;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S201.ComplexAttributes.changeDetails
            {
                buoyChange = this.buoyChange,
                lightChange = this.lightChange,
                beaconChange = this.beaconChange,
                leadingLightsChange = this.leadingLightsChange,
                fogSignals = this.fogSignals,
                radioAidsChange = this.radioAidsChange,
                atonCommissioning = this.atonCommissioning,
                atonReplacement = this.atonReplacement,
                atonRemoval = this.atonRemoval,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S201.ComplexAttributes.changeDetails Model => new()
        {
            buoyChange = this._buoyChange,
            lightChange = this._lightChange,
            beaconChange = this._beaconChange,
            leadingLightsChange = this._leadingLightsChange,
            fogSignals = this._fogSignals,
            radioAidsChange = this._radioAidsChange,
            atonCommissioning = this._atonCommissioning,
            atonReplacement = this._atonReplacement,
            atonRemoval = this._atonRemoval,
        };

        public changeDetailsViewModel()
        {
        }
    }

    public class contactAddressViewModel : ViewModelBase
    {
        [Category("contactAddress")]
        public ObservableCollection<String> deliveryPoint { get; set; } = new();

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

        private String _country = string.Empty;
        [Category("contactAddress")]
        public String country
        {
            get
            {
                return _country;
            }

            set
            {
                SetValue(ref _country, value);
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

        public void Load(DomainModel.S201.ComplexAttributes.contactAddress instance)
        {
            deliveryPoint.Clear();
            if (instance.deliveryPoint is not null)
                foreach (var e in instance.deliveryPoint)
                    deliveryPoint.Add(e);
            cityName = instance.cityName;
            administrativeDivision = instance.administrativeDivision;
            country = instance.country;
            postalCode = instance.postalCode;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S201.ComplexAttributes.contactAddress
            {
                deliveryPoint = this.deliveryPoint.ToList(),
                cityName = this.cityName,
                administrativeDivision = this.administrativeDivision,
                country = this.country,
                postalCode = this.postalCode,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S201.ComplexAttributes.contactAddress Model => new()
        {
            deliveryPoint = this.deliveryPoint.ToList(),
            cityName = this._cityName,
            administrativeDivision = this._administrativeDivision,
            country = this._country,
            postalCode = this._postalCode,
        };

        public contactAddressViewModel()
        {
            deliveryPoint.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(deliveryPoint));
            };
        }
    }

    public class surveyDateRangeViewModel : ViewModelBase
    {
        private DateOnly _dateEnd;
        [Category("surveyDateRange")]
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

        private DateOnly? _dateStart = default;
        [Category("surveyDateRange")]
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

        public void Load(DomainModel.S201.ComplexAttributes.surveyDateRange instance)
        {
            dateEnd = instance.dateEnd;
            dateStart = instance.dateStart;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S201.ComplexAttributes.surveyDateRange
            {
                dateEnd = this.dateEnd,
                dateStart = this.dateStart,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S201.ComplexAttributes.surveyDateRange Model => new()
        {
            dateEnd = this._dateEnd,
            dateStart = this._dateStart,
        };

        public surveyDateRangeViewModel()
        {
        }
    }

    public class AtoNStatusInformationViewModel : ViewModelBase
    {
        private changeDetailsViewModel _changeDetails;
        [Category("AtoNStatusInformation")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public changeDetailsViewModel changeDetails
        {
            get
            {
                return _changeDetails;
            }

            set
            {
                SetValue(ref _changeDetails, value);
            }
        }

        private changeTypes? _changeTypes = default;
        [Category("AtoNStatusInformation")]
        public changeTypes? changeTypes
        {
            get
            {
                return _changeTypes;
            }

            set
            {
                SetValue(ref _changeTypes, value);
            }
        }

        public void Load(DomainModel.S201.InformationTypes.AtoNStatusInformation instance)
        {
            changeDetails = new();
            if (instance.changeDetails != null)
            {
                changeDetails = new();
                changeDetails.Load(instance.changeDetails);
            }

            changeTypes = instance.changeTypes;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S201.InformationTypes.AtoNStatusInformation
            {
                changeDetails = this.changeDetails?.Model,
                changeTypes = this.changeTypes,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S201.InformationTypes.AtoNStatusInformation Model => new()
        {
            changeDetails = this._changeDetails?.Model,
            changeTypes = this._changeTypes,
        };

        public AtoNStatusInformationViewModel()
        {
        }
    }

    public class SpatialUncertaintyViewModel : ViewModelBase
    {
        private qualityOfPosition? _qualityOfPosition = default;
        [Category("SpatialUncertainty")]
        public qualityOfPosition? qualityOfPosition
        {
            get
            {
                return _qualityOfPosition;
            }

            set
            {
                SetValue(ref _qualityOfPosition, value);
            }
        }

        private Decimal? _positionalAccuracy = default;
        [Category("SpatialUncertainty")]
        public Decimal? positionalAccuracy
        {
            get
            {
                return _positionalAccuracy;
            }

            set
            {
                SetValue(ref _positionalAccuracy, value);
            }
        }

        public void Load(DomainModel.S201.InformationTypes.SpatialUncertainty instance)
        {
            qualityOfPosition = instance.qualityOfPosition;
            positionalAccuracy = instance.positionalAccuracy;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S201.InformationTypes.SpatialUncertainty
            {
                qualityOfPosition = this.qualityOfPosition,
                positionalAccuracy = this.positionalAccuracy,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S201.InformationTypes.SpatialUncertainty Model => new()
        {
            qualityOfPosition = this._qualityOfPosition,
            positionalAccuracy = this._positionalAccuracy,
        };

        public SpatialUncertaintyViewModel()
        {
        }
    }

    public class AggregationViewModel : ViewModelBase
    {
        private categoryOfAggregation _categoryOfAggregation;
        [S100Framework.DomainModel.CodeListAttribute(nameof(categoryOfAggregationList))]
        [Editor(typeof(Editors.CodeListComboEditor), typeof(Editors.CodeListComboEditor))]
        [Category("Aggregation")]
        public categoryOfAggregation categoryOfAggregation
        {
            get
            {
                return _categoryOfAggregation;
            }

            set
            {
                SetValue(ref _categoryOfAggregation, value);
            }
        }

        [Browsable(false)]
        public categoryOfAggregation[] categoryOfAggregationList => CodeList.categoryOfAggregations.ToArray();

        public void Load(DomainModel.S201.FeatureTypes.Aggregation instance)
        {
            categoryOfAggregation = instance.categoryOfAggregation;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S201.FeatureTypes.Aggregation
            {
                categoryOfAggregation = this.categoryOfAggregation,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S201.FeatureTypes.Aggregation Model => new()
        {
            categoryOfAggregation = this._categoryOfAggregation,
        };

        public AggregationViewModel()
        {
        }
    }

    public class AssociationViewModel : ViewModelBase
    {
        private categoryOfAssociation _categoryOfAssociation;
        [S100Framework.DomainModel.CodeListAttribute(nameof(categoryOfAssociationList))]
        [Editor(typeof(Editors.CodeListComboEditor), typeof(Editors.CodeListComboEditor))]
        [Category("Association")]
        public categoryOfAssociation categoryOfAssociation
        {
            get
            {
                return _categoryOfAssociation;
            }

            set
            {
                SetValue(ref _categoryOfAssociation, value);
            }
        }

        [Browsable(false)]
        public categoryOfAssociation[] categoryOfAssociationList => CodeList.categoryOfAssociations.ToArray();

        public void Load(DomainModel.S201.FeatureTypes.Association instance)
        {
            categoryOfAssociation = instance.categoryOfAssociation;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S201.FeatureTypes.Association
            {
                categoryOfAssociation = this.categoryOfAssociation,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S201.FeatureTypes.Association Model => new()
        {
            categoryOfAssociation = this._categoryOfAssociation,
        };

        public AssociationViewModel()
        {
        }
    }

    public class DataCoverageViewModel : ViewModelBase
    {
        private Int32 _maximumDisplayScale;
        [Category("DataCoverage")]
        public Int32 maximumDisplayScale
        {
            get
            {
                return _maximumDisplayScale;
            }

            set
            {
                SetValue(ref _maximumDisplayScale, value);
            }
        }

        private Int32 _minimumDisplayScale;
        [Category("DataCoverage")]
        public Int32 minimumDisplayScale
        {
            get
            {
                return _minimumDisplayScale;
            }

            set
            {
                SetValue(ref _minimumDisplayScale, value);
            }
        }

        public void Load(DomainModel.S201.FeatureTypes.DataCoverage instance)
        {
            maximumDisplayScale = instance.maximumDisplayScale;
            minimumDisplayScale = instance.minimumDisplayScale;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S201.FeatureTypes.DataCoverage
            {
                maximumDisplayScale = this.maximumDisplayScale,
                minimumDisplayScale = this.minimumDisplayScale,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S201.FeatureTypes.DataCoverage Model => new()
        {
            maximumDisplayScale = this._maximumDisplayScale,
            minimumDisplayScale = this._minimumDisplayScale,
        };

        public DataCoverageViewModel()
        {
        }
    }

    public class LocalDirectionOfBuoyageViewModel : ViewModelBase
    {
        private Decimal _orientation;
        [Category("LocalDirectionOfBuoyage")]
        public Decimal orientation
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

        private Int32? _scaleMinimum = default;
        [Category("LocalDirectionOfBuoyage")]
        public Int32? scaleMinimum
        {
            get
            {
                return _scaleMinimum;
            }

            set
            {
                SetValue(ref _scaleMinimum, value);
            }
        }

        public void Load(DomainModel.S201.FeatureTypes.LocalDirectionOfBuoyage instance)
        {
            orientation = instance.orientation;
            scaleMinimum = instance.scaleMinimum;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S201.FeatureTypes.LocalDirectionOfBuoyage
            {
                orientation = this.orientation,
                scaleMinimum = this.scaleMinimum,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S201.FeatureTypes.LocalDirectionOfBuoyage Model => new()
        {
            orientation = this._orientation,
            scaleMinimum = this._scaleMinimum,
        };

        public LocalDirectionOfBuoyageViewModel()
        {
        }
    }

    public class NavigationalSystemOfMarksViewModel : ViewModelBase
    {
        private marksNavigationalSystemOf _marksNavigationalSystemOf;
        [Category("NavigationalSystemOfMarks")]
        public marksNavigationalSystemOf marksNavigationalSystemOf
        {
            get
            {
                return _marksNavigationalSystemOf;
            }

            set
            {
                SetValue(ref _marksNavigationalSystemOf, value);
            }
        }

        public void Load(DomainModel.S201.FeatureTypes.NavigationalSystemOfMarks instance)
        {
            marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S201.FeatureTypes.NavigationalSystemOfMarks
            {
                marksNavigationalSystemOf = this.marksNavigationalSystemOf,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S201.FeatureTypes.NavigationalSystemOfMarks Model => new()
        {
            marksNavigationalSystemOf = this._marksNavigationalSystemOf,
        };

        public NavigationalSystemOfMarksViewModel()
        {
        }
    }

    public class QualityOfNonBathymetricDataViewModel : ViewModelBase
    {
        private categoryOfTemporalVariation _categoryOfTemporalVariation;
        [Category("QualityOfNonBathymetricData")]
        public categoryOfTemporalVariation categoryOfTemporalVariation
        {
            get
            {
                return _categoryOfTemporalVariation;
            }

            set
            {
                SetValue(ref _categoryOfTemporalVariation, value);
            }
        }

        private Decimal? _directionUncertainty = default;
        [Category("QualityOfNonBathymetricData")]
        public Decimal? directionUncertainty
        {
            get
            {
                return _directionUncertainty;
            }

            set
            {
                SetValue(ref _directionUncertainty, value);
            }
        }

        private Decimal? _horizontalDistanceUncertainty = default;
        [Category("QualityOfNonBathymetricData")]
        public Decimal? horizontalDistanceUncertainty
        {
            get
            {
                return _horizontalDistanceUncertainty;
            }

            set
            {
                SetValue(ref _horizontalDistanceUncertainty, value);
            }
        }

        private Decimal _horizontalPositionUncertainty;
        [Category("QualityOfNonBathymetricData")]
        public Decimal horizontalPositionUncertainty
        {
            get
            {
                return _horizontalPositionUncertainty;
            }

            set
            {
                SetValue(ref _horizontalPositionUncertainty, value);
            }
        }

        private String _information = string.Empty;
        [Category("QualityOfNonBathymetricData")]
        public String information
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

        private String _informationInNationalLanguage = string.Empty;
        [Category("QualityOfNonBathymetricData")]
        public String informationInNationalLanguage
        {
            get
            {
                return _informationInNationalLanguage;
            }

            set
            {
                SetValue(ref _informationInNationalLanguage, value);
            }
        }

        private String _textualDescription = string.Empty;
        [Category("QualityOfNonBathymetricData")]
        public String textualDescription
        {
            get
            {
                return _textualDescription;
            }

            set
            {
                SetValue(ref _textualDescription, value);
            }
        }

        private String _textualDescriptionInNationalLanguage = string.Empty;
        [Category("QualityOfNonBathymetricData")]
        public String textualDescriptionInNationalLanguage
        {
            get
            {
                return _textualDescriptionInNationalLanguage;
            }

            set
            {
                SetValue(ref _textualDescriptionInNationalLanguage, value);
            }
        }

        private Decimal? _verticalUncertainty = default;
        [Category("QualityOfNonBathymetricData")]
        public Decimal? verticalUncertainty
        {
            get
            {
                return _verticalUncertainty;
            }

            set
            {
                SetValue(ref _verticalUncertainty, value);
            }
        }

        private surveyDateRangeViewModel? _surveyDateRange;
        [Category("QualityOfNonBathymetricData")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public surveyDateRangeViewModel? surveyDateRange
        {
            get
            {
                return _surveyDateRange;
            }

            set
            {
                SetValue(ref _surveyDateRange, value);
            }
        }

        public void Load(DomainModel.S201.FeatureTypes.QualityOfNonBathymetricData instance)
        {
            categoryOfTemporalVariation = instance.categoryOfTemporalVariation;
            directionUncertainty = instance.directionUncertainty;
            horizontalDistanceUncertainty = instance.horizontalDistanceUncertainty;
            horizontalPositionUncertainty = instance.horizontalPositionUncertainty;
            information = instance.information;
            informationInNationalLanguage = instance.informationInNationalLanguage;
            textualDescription = instance.textualDescription;
            textualDescriptionInNationalLanguage = instance.textualDescriptionInNationalLanguage;
            verticalUncertainty = instance.verticalUncertainty;
            surveyDateRange = new();
            if (instance.surveyDateRange != null)
            {
                surveyDateRange = new();
                surveyDateRange.Load(instance.surveyDateRange);
            }
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S201.FeatureTypes.QualityOfNonBathymetricData
            {
                categoryOfTemporalVariation = this.categoryOfTemporalVariation,
                directionUncertainty = this.directionUncertainty,
                horizontalDistanceUncertainty = this.horizontalDistanceUncertainty,
                horizontalPositionUncertainty = this.horizontalPositionUncertainty,
                information = this.information,
                informationInNationalLanguage = this.informationInNationalLanguage,
                textualDescription = this.textualDescription,
                textualDescriptionInNationalLanguage = this.textualDescriptionInNationalLanguage,
                verticalUncertainty = this.verticalUncertainty,
                surveyDateRange = this.surveyDateRange?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S201.FeatureTypes.QualityOfNonBathymetricData Model => new()
        {
            categoryOfTemporalVariation = this._categoryOfTemporalVariation,
            directionUncertainty = this._directionUncertainty,
            horizontalDistanceUncertainty = this._horizontalDistanceUncertainty,
            horizontalPositionUncertainty = this._horizontalPositionUncertainty,
            information = this._information,
            informationInNationalLanguage = this._informationInNationalLanguage,
            textualDescription = this._textualDescription,
            textualDescriptionInNationalLanguage = this._textualDescriptionInNationalLanguage,
            verticalUncertainty = this._verticalUncertainty,
            surveyDateRange = this._surveyDateRange?.Model,
        };

        public QualityOfNonBathymetricDataViewModel()
        {
        }
    }

    public class SoundingDatumViewModel : ViewModelBase
    {
        private verticalDatum _verticalDatum;
        [Category("SoundingDatum")]
        public verticalDatum verticalDatum
        {
            get
            {
                return _verticalDatum;
            }

            set
            {
                SetValue(ref _verticalDatum, value);
            }
        }

        public void Load(DomainModel.S201.FeatureTypes.SoundingDatum instance)
        {
            verticalDatum = instance.verticalDatum;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S201.FeatureTypes.SoundingDatum
            {
                verticalDatum = this.verticalDatum,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S201.FeatureTypes.SoundingDatum Model => new()
        {
            verticalDatum = this._verticalDatum,
        };

        public SoundingDatumViewModel()
        {
        }
    }

    public class VerticalDatumOfDataViewModel : ViewModelBase
    {
        private verticalDatum _verticalDatum;
        [Category("VerticalDatumOfData")]
        public verticalDatum verticalDatum
        {
            get
            {
                return _verticalDatum;
            }

            set
            {
                SetValue(ref _verticalDatum, value);
            }
        }

        public void Load(DomainModel.S201.FeatureTypes.VerticalDatumOfData instance)
        {
            verticalDatum = instance.verticalDatum;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S201.FeatureTypes.VerticalDatumOfData
            {
                verticalDatum = this.verticalDatum,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S201.FeatureTypes.VerticalDatumOfData Model => new()
        {
            verticalDatum = this._verticalDatum,
        };

        public VerticalDatumOfDataViewModel()
        {
        }
    }
}