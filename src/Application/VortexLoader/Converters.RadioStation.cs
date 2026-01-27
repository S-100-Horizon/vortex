using ArcGIS.Core.Data;
using S100FC.S101.FeatureTypes;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;


namespace S100Framework.Applications
{
    internal static partial class Converters
    {
        internal static RadioStation CreateRadioStation(AidsToNavigationP current, int? scaleMinimum, Geodatabase source) {
            var instance = new RadioStation();

            if (current.CALSGN != default) {
                instance.callSign = current.CALSGN;
            }

            if (current.CATROS != null) {
                var subtype = Subtypes.Instance.TryGetSubtype(current.TableName!, current.FCSUBTYPE!.Value, out var val) ? val : "Unknown";

                var category = current.CATROS switch {
                    "1" => null,
                    "2" => null,
                    "3" => null,
                    "4" => null,
                    "5" => "5",
                    "6" => null,
                    "7" => null,
                    "8" => null,
                    "9" => null,
                    "10" => "10",
                    "11" => "11",
                    "12" => "11",
                    "13" => "11",
                    "14" => "14",
                    "19" => "19",
                    "20" => "20",
                    "-32767" => null,
                    _ => throw new NotSupportedException($"Cannot convert radiostation category {current.CATROS} aton: globalid:{current.GLOBALID}")
                };

                if (category != null) {
                    var categoryOfRadioStation = EnumHelper.GetEnumValues(category);
                    if (categoryOfRadioStation is not null && categoryOfRadioStation.Any())
                        instance.categoryOfRadioStation = categoryOfRadioStation;
                }
                else {
                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Radiostation of type {subtype} is not converted.");
                }
            }

            if (current.COMCHA != default) {
                instance.communicationChannel = ImporterNIS.GetCommunicationChannel(current.COMCHA);
            }

            if (current.ESTRNG.HasValue) {
                instance.estimatedRangeOfTransmission = current.ESTRNG.Value;
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
            if (dateRange != default) {
                instance.fixedDateRange = dateRange;
            }

            if (current.SIGFRQ.HasValue) {
                instance.frequencyPair = ImporterNIS.GetFrequencyPair(current.SIGFRQ.Value);
            }

            // TODO: interoperabilityidentifier

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange = periodicDateRange;
            }

            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }

            if (scaleMinimum.HasValue) {
                instance.scaleMinimum = scaleMinimum;
            }
            else if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                string subtype = "";

                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                var scamin = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                if (scamin.HasValue)
                    instance.scaleMinimum = scamin.Value;
            }

            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
            instance.information = result.information.ToArray();
            instance.SetInformationBindings(result.InformationBindings.ToArray());

            return instance;
        }
    }
}
