using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.AttributeModel.S101.ComplexAttributes;
using S100Framework.AttributeModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class Converters
    {

        internal static LightAllAround CreateLightAllAround(AidsToNavigationP current, int? scaleMinimum, Geodatabase source) {
            var instance = new LightAllAround {
                rhythmOfLight = default!,
            };

            if (current.CATLIT != null) {
                var categoryOfLight = EnumHelper.GetEnumValues(current.CATLIT);
                if (categoryOfLight is not null && categoryOfLight.Any())
                    instance.categoryOfLight_optional = categoryOfLight;
            }

            if (current.COLOUR != default) {
                var colours = ImporterNIS.GetColours(current.COLOUR);
                if (colours != null && colours.Any()) {
                    instance.colour.value = colours[0];
                    if (colours.Count() > 1)
                        instance.colour_optional = colours[1..];
                }
            }

            if (current.EXCLIT.HasValue) {
                instance.exhibitionConditionOfLight_optional = EnumHelper.GetEnumValue(current.EXCLIT.Value);
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

            // TODO: interoperabilityidentifier

            if (current.LITVIS != null) {
                instance.lightVisibility_optional = EnumHelper.GetEnumValue(current.LITVIS);
            }

            /*
                The S-101 Boolean _s101type attribute major light has been introduced in S-101 to aid in improved
                portrayal of lights in ECDIS. This attribute will be populated as True during the automated conversion
                process for all lights having a nominal range of 10 Nautical Miles or greater.
            */

            if (current.VALNMR.HasValue) {
                instance.valueOfNominalRange_optional = current.VALNMR.Value;

                if (current.VALNMR.Value >= 10.0d) {
                    instance.majorLight_optional = true;
                }
            }

            if (current.MARSYS.HasValue) {
                instance.marksNavigationalSystemOf_optional = EnumHelper.GetEnumValue(current.MARSYS.Value);
            }

            if (current.MLTYLT.HasValue) {
                instance.multiplicityOfFeatures_optional = new multiplicityOfFeatures() {
                    multiplicityKnown = true,
                    numberOfFeatures_optional = current.MLTYLT
                };
            }

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange_optional = periodicDateRange;
            }

            instance.rhythmOfLight = ImporterNIS.GetRythmOfLight<LightAllAround>(current);

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var fixedDateRange);
            if (dateRange != default) {
                instance.fixedDateRange_optional = fixedDateRange;
            }

            if (current.SIGGEN != null) {
                instance.signalGeneration_optional = EnumHelper.GetEnumValue(current.SIGGEN.Value);
            }

            if (current.STATUS != default) {
                instance.status_optional = ImporterNIS.GetStatus(current.STATUS);
            }

            if (current.VALNMR.HasValue) {
                instance.valueOfNominalRange_optional = current.VALNMR.Value;
            }

            if (current.VERLEN.HasValue) {
                instance.verticalLength_optional = current.VERLEN.Value;
                var verticalDatum = ImporterNIS.GetVerticalDatum(current.VERDAT ?? 3);
                if (verticalDatum != default)
                    instance.verticalDatum_optional = verticalDatum.value;
            }


            //if (plts_comp_scale != default) {
            //  instance.scaleMinimum = plts_comp_scale;
            //}

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
