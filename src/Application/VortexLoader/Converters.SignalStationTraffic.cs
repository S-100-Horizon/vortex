using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.AttributeModel.S101;
using S100Framework.AttributeModel.S101.FeatureTypes;
using VortexLoader;

namespace S100Framework.Applications
{
    internal static partial class Converters
    {
        internal static SignalStationTraffic CreateSignalStationTraffic(PortsAndServicesP current, int? scaleMinimum, Geodatabase source) {

            var instance = new SignalStationTraffic();

            if (ConversionAnalytics.Instance.IsConverted(current.GlobalId)) {
                ;
            }



            if (current.CATSIT != default) {
                var categoryOfSignalStationTraffic = EnumHelper.GetEnumValues(current.CATSIT);
                if (categoryOfSignalStationTraffic != null && categoryOfSignalStationTraffic.Any()) {
                    instance.categoryOfSignalStationTraffic = categoryOfSignalStationTraffic[0];
                    instance.categoryOfSignalStationTraffic_optional = categoryOfSignalStationTraffic[1..];
                }
            }

            if (current.COMCHA != default) {
                instance.communicationChannel_optional = current.COMCHA.Split(',').ToArray<string>();
            }

            instance.featureName_optional = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
            if (dateRange != default) {
                instance.fixedDateRange_optional = dateRange;
            }

            // TODO: interoperabilityIdentifier

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange_optional = periodicDateRange;
            }

            if (current.STATUS != default) {
                instance.status_optional = ImporterNIS.GetStatus(current.STATUS);
            }

            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                string subtype = "";
                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                instance.scaleMinimum_optional = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
            }

            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
            instance.information_optional = result.information.ToArray();
            instance.SetInformationBindings(result.InformationBindings.ToArray());

            return instance;
        }
    }
}

