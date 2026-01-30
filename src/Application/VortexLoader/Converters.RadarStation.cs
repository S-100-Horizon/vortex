using ArcGIS.Core.Data;
using S100FC.S101.FeatureTypes;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;


namespace S100Framework.Applications
{
    internal static partial class Converters
    {
        internal static RadarStation CreateRadarStation(AidsToNavigationP current, int? scaleMinimum, Geodatabase source) {
            var instance = new RadarStation();

            if (current.CALSGN != default) {
                instance.callSign = current.CALSGN;
            }

            if (current.CATRAS != null) {
                var categoryOfRadarStation = EnumHelper.GetEnumValues(current.CATRAS);
                if (categoryOfRadarStation is not null && categoryOfRadarStation.Any())
                    instance.categoryOfRadarStation = categoryOfRadarStation;
            }

            if (current.COMCHA != default) {
                instance.communicationChannel = ImporterNIS.GetCommunicationChannel(current.COMCHA);
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            if (current.HEIGHT.HasValue) {
                instance.height = current.HEIGHT.Value != -32767m ? current.HEIGHT.Value : null;
            }
            else {

            }


            // TODO: interoperabilityidentifier

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange = periodicDateRange;
            }

            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }

            if (current.VALMXR.HasValue) {
                instance.valueOfMaximumRange = current.VALMXR.Value;
            }


            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
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
