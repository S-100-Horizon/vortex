using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.AttributeModel.S101.FeatureTypes;


namespace S100Framework.Applications
{
    internal static partial class Converters
    {
        internal static RadarStation CreateRadarStation(AidsToNavigationP current, int? scaleMinimum, Geodatabase source) {
            var instance = new RadarStation();

            if (current.CALSGN != default) {
                instance.callSign_optional = current.CALSGN;
            }

            if (current.CATRAS != null) {
                var categoryOfRadarStation = EnumHelper.GetEnumValues(current.CATRAS);
                if (categoryOfRadarStation is not null && categoryOfRadarStation.Any())
                    instance.categoryOfRadarStation_optional = categoryOfRadarStation;
            }

            if (current.COMCHA != default) {
                instance.communicationChannel_optional = ImporterNIS.GetCommunicationChannel(current.COMCHA);
            }

            instance.featureName_optional = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                instance.height_optional = current.HEIGHT.Value;
            }
            else {

            }


            // TODO: interoperabilityidentifier

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange_optional = periodicDateRange;
            }

            if (current.STATUS != default) {
                instance.status_optional = ImporterNIS.GetStatus(current.STATUS);
            }

            if (current.VALMXR.HasValue) {
                instance.valueOfMaximumRange_optional = current.VALMXR.Value;
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
