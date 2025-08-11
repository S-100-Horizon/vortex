using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class Converters
    {
        internal static LightFogDetector CreateLightFogDetector(AidsToNavigationP current, int? scaleMinimum, Geodatabase source) {
            var instance = new LightFogDetector();

            if (current.COLOUR != default) {
                instance.colour = ImporterNIS.GetColours(current.COLOUR);
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
            if (dateRange != default) {
                instance.fixedDateRange = dateRange;
            }

            // flareBearing is not populated. New field.

            if (current.HEIGHT.HasValue) {
                instance.height = current.HEIGHT.Value;
            }

            // DODO: Interoperability identifier

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange = periodicDateRange;
            }

            instance.rhythmOfLight = ImporterNIS.GetRythmOfLight(current);

            if (current.SIGGEN != null) {
                instance.signalGeneration = EnumHelper.GetEnumValue<signalGeneration>(current.SIGGEN.Value);
            }

            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }

            // covered by meta feature hence not to be set
            //instance.verticalDatum = ImporterNIS.GetVerticalDatum(current.VERDAT ?? 3);

            if (current.VERLEN.HasValue) {
                instance.verticalLength = current.VERLEN.Value;
            }

            if (current.HEIGHT.HasValue) {
                instance.height = current.HEIGHT.Value;
            }

            if (scaleMinimum.HasValue) {
                instance.scaleMinimum = scaleMinimum;
            }
            else if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                string subtype = "";

                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
            }




            return instance;
        }


    }
}
