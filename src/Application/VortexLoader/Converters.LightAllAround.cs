using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;
using ArcGIS.Core.Data;
using S100Framework.Applications.Singletons;

namespace S100Framework.Applications
{
    internal static partial class Converters
    {

        internal static LightAllAround CreateLightAllAround(AidsToNavigationP current, Geodatabase source) {
            var instance = new LightAllAround();

            if (current.CATLIT != null) {
                instance.categoryOfLight = EnumHelper.GetEnumValues<categoryOfLight>(current.CATLIT);
            }

            if (current.COLOUR != default) {
                instance.colour = ImporterNIS.GetColours(current.COLOUR);
            }

            if (current.EXCLIT.HasValue) {
                instance.exhibitionConditionOfLight = EnumHelper.GetEnumValue<exhibitionConditionOfLight>(current.EXCLIT.Value);
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

            // TODO: interoperabilityidentifier

            if (current.LITVIS != null) {
                instance.lightVisibility = EnumHelper.GetEnumValue<lightVisibility>(current.LITVIS);
            }

            /*
                The S-101 Boolean _s101type attribute major light has been introduced in S-101 to aid in improved
                portrayal of lights in ECDIS. This attribute will be populated as True during the automated conversion
                process for all lights having a nominal range of 10 Nautical Miles or greater.
            */

            if (current.VALNMR.HasValue) {
                instance.valueOfNominalRange = current.VALNMR.Value;

                if (current.VALNMR.Value >= 10.0m) {
                    instance.majorLight = true;
                }
            }

            if (current.MARSYS.HasValue) {
                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS.Value);
            }

            if (current.MLTYLT.HasValue) {
                instance.multiplicityOfFeatures = new multiplicityOfFeatures() {
                    multiplicityKnown = true,
                    numberOfFeatures = current.MLTYLT
                };
            }

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange = periodicDateRange;
            }

            instance.rhythmOfLight = ImporterNIS.GetRythmOfLight(current);

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var fixedDateRange);
            if (dateRange != default) {
                instance.fixedDateRange = fixedDateRange;
            }

            if (current.SIGGEN != null) {
                instance.signalGeneration = EnumHelper.GetEnumValue<signalGeneration>(current.SIGGEN.Value);
            }

            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }

            if (current.VALNMR.HasValue) {
                instance.valueOfNominalRange = current.VALNMR.Value;
            }		
            
            if (current.VERLEN.HasValue) {
                instance.verticalLength = current.VERLEN.Value;

                instance.verticalDatum = ImporterNIS.GetVerticalDatum(current.VERDAT ?? 3);
            }

            //if (plts_comp_scale != default) {
            //  instance.scaleMinimum = plts_comp_scale;
            //}

            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                string subtype = "";

                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
            }

            return instance;
        }


    }
}
