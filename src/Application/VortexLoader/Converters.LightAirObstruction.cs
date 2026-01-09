using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.AttributeModel.S101.ComplexAttributes;
using S100Framework.AttributeModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class Converters
    {


        internal static LightAirObstruction CreateLightAirObstruction(AidsToNavigationP current, int? scaleMinimum, Geodatabase source) {
            var instance = new LightAirObstruction();

            if (current.COLOUR != default) {
                var colours = ImporterNIS.GetColours(current.COLOUR);
                if (colours != null && colours.Any()) {
                    instance.colour_optional = colours;
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

            // TODO: Interoperability identifier                            
            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                instance.height_optional = current.HEIGHT.Value;
            }

            if (current.LITVIS != null) {
                var lightVisibility = EnumHelper.GetEnumValues(current.LITVIS);
                if (lightVisibility != null && lightVisibility.Any())
                    instance.lightVisibility_optional = lightVisibility;
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

            instance.rhythmOfLight_optional = ImporterNIS.GetRythmOfLight<LightAirObstruction>(current);

            if (current.STATUS != default) {
                instance.status_optional = ImporterNIS.GetStatus(current.STATUS);
            }

            if (current.VALNMR.HasValue) {
                instance.valueOfNominalRange_optional = current.VALNMR.Value;
            }

            var verticalDatum = ImporterNIS.GetVerticalDatum(current.VERDAT ?? 3);
            if (verticalDatum != null) {
                var update = true;
                foreach (var elm in VerticalDatums.Instance.Touch(current.SHAPE!)) {
                    if (elm.Item2.value == verticalDatum.value) {
                        update = false;
                    }
                }
                if (update)
                    instance.verticalDatum_optional = verticalDatum.value;
            }

            //Just to catch a lightairobstruction outside a VerticalDatum area
            //if (System.Diagnostics.Debugger.IsAttached && instance.verticalDatum != null) {
            //    System.Diagnostics.Debugger.Break();
            //}


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
