using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.AttributeModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class Converters
    {
        internal static LightFogDetector CreateLightFogDetector(AidsToNavigationP current, int? scaleMinimum, Geodatabase source) {
            var instance = new LightFogDetector();

            if (current.COLOUR != default) {
                var colours = ImporterNIS.GetColours(current.COLOUR);
                if (colours is not null && colours.Any())
                    instance.colour_optional = colours;
            }

            instance.featureName_optional = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
            if (dateRange != default) {
                instance.fixedDateRange_optional = dateRange;
            }

            // flareBearing is not populated. New field.                            
            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                instance.height_optional = current.HEIGHT.Value;
            }

            // DODO: Interoperability identifier

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange_optional = periodicDateRange;
            }

            instance.rhythmOfLight_optional = ImporterNIS.GetRythmOfLight<LightFogDetector>(current);

            if (current.SIGGEN != null) {
                instance.signalGeneration_optional = EnumHelper.GetEnumValue(current.SIGGEN.Value);
            }

            if (current.STATUS != default) {
                instance.status_optional = ImporterNIS.GetStatus(current.STATUS);
            }

            // covered by meta feature hence not to be set
            if (current.VERLEN.HasValue) {
                instance.verticalLength_optional = current.VERLEN.Value;
                var verticalDatum = ImporterNIS.GetVerticalDatum(current.VERDAT ?? 3);
                if (verticalDatum != default)
                    instance.verticalDatum_optional = verticalDatum.value;
            }

            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                instance.height_optional = current.HEIGHT.Value;
            }
            else {
                instance.height_optional = default(double?);
            }

            if (scaleMinimum.HasValue) {
                instance.scaleMinimum_optional = scaleMinimum;
            }
            else if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                string subtype = "";

                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                instance.scaleMinimum_optional = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
            }

            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
            instance.information_optional = result.information.ToArray();
            instance.SetInformationBindings(result.InformationBindings.ToArray());

            return instance;
        }
    }
}
