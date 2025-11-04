using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class Converters
    {


        internal static LightAirObstruction CreateLightAirObstruction(AidsToNavigationP current, int? scaleMinimum, Geodatabase source) {
            var instance = new LightAirObstruction();

            if (current.COLOUR != default) {
                instance.colour = ImporterNIS.GetColours< LightAirObstruction>(current.COLOUR);
            }

            if (current.EXCLIT.HasValue) {
                instance.exhibitionConditionOfLight = EnumHelper.GetEnumValue<LightAirObstruction,exhibitionConditionOfLight>(current.EXCLIT.Value);
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
            if (dateRange != default) {
                instance.fixedDateRange = dateRange;
            }

            // flareBearing is not populated. New field.

            // TODO: Interoperability identifier                            
            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                instance.height = current.HEIGHT.Value;
            }
            else {
                instance.height = default(double?);
            }

            if (current.LITVIS != null) {
                instance.lightVisibility = EnumHelper.GetEnumValues<LightAirObstruction,lightVisibility>(current.LITVIS);
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

            instance.rhythmOfLight = ImporterNIS.GetRythmOfLight<LightAirObstruction>(current);

            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }

            if (current.VALNMR.HasValue) {
                instance.valueOfNominalRange = current.VALNMR.Value;
            }

            instance.verticalDatum = ImporterNIS.GetVerticalDatum<LightAirObstruction>(current.VERDAT ?? 3);
            foreach (var elm in VerticalDatums.Instance.Touch(current.SHAPE!)) {
                if (elm.Item2 == instance.verticalDatum) {
                    instance.verticalDatum = null;
                }
            }

            //Just to catch a lightairobstruction outside a VerticalDatum area
            //if (System.Diagnostics.Debugger.IsAttached && instance.verticalDatum != null) {
            //    System.Diagnostics.Debugger.Break();
            //}
                

            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                string subtype = "";
                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
            }


            instance.SetInformationBindings(ImporterNIS.AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

            return instance;
        }


    }
}
