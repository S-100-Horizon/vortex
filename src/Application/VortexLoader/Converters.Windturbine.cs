using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.AttributeModel.S101.ComplexAttributes;
using S100Framework.AttributeModel.S101.FeatureTypes;


namespace S100Framework.Applications
{
    internal static partial class Converters
    {

        internal static WindTurbine CreateWindturbine(CulturalFeaturesP current, int? scaleMinimum, Geodatabase source) {
            var instance = new WindTurbine();

            if (current.COLOUR != default) {
                var colour = ImporterNIS.GetColours(current.COLOUR);
                if (colour is not null && colour.Any())
                    instance.colour_optional = colour;
            }

            if (current.COLPAT != default) {
                instance.colourPattern_optional = ImporterNIS.GetColourPattern(current.COLPAT)?.value;
            }

            if (current.CONDTN.HasValue) {
                instance.condition_optional = ImporterNIS.GetCondition(current.CONDTN.Value)?.value;
            }

            if (current.ELEVAT.HasValue) {
                instance.elevation_optional = current.ELEVAT.Value;
            }

            instance.featureName_optional = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
            if (dateRange != default) {
                instance.fixedDateRange_optional = dateRange;
            }
            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                instance.height_optional = current.HEIGHT.Value;
            }
            else {

            }

            // TODO: interoperabilityIdentifier

            // TODO: multiplicityOfFeatures

            if (current.NATCON != default) {
                var natureOfConstruction = EnumHelper.GetEnumValues(current.NATCON);
                if (natureOfConstruction is not null && natureOfConstruction.Any())
                    instance.natureOfConstruction_optional = natureOfConstruction;
            }

            if (current.CONRAD.HasValue) {
                instance.radarConspicuous_optional = current.CONRAD.Value == 2 ? false : true;
            }
            if (!string.IsNullOrEmpty(current.SORDAT)) {
                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                    instance.reportedDate_optional = reportedDate;
                }
                else {
                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                }
            }



            if (current.STATUS != default) {
                instance.status_optional = ImporterNIS.GetStatus(current.STATUS);
            }

            var verticalUncertainty = new verticalUncertainty();
            if (current.VERACC.HasValue && current.VERACC.Value != -32767d)
                verticalUncertainty.uncertaintyFixed = current.VERACC.Value;

            var verticalClearanceFixed = new verticalClearanceFixed {
                verticalUncertainty_optional = verticalUncertainty
            };
            if (current.VERCLR.HasValue && current.VERCLR.Value != -32767d)
                verticalClearanceFixed.verticalClearanceValue = current.VERCLR.Value;

            instance.verticalClearanceFixed_optional = new() {
                verticalUncertainty_optional = verticalUncertainty,
            };

            if (current.VERLEN.HasValue) {
                instance.verticalLength_optional = current.VERLEN.Value;
                instance.verticalDatum_optional = ImporterNIS.GetVerticalDatum(current.VERDAT ?? 3)?.value;

            }

            if (current.CONVIS.HasValue /*&& current.CONVIS.Value != -32767*/) {
                instance.visualProminence_optional = EnumHelper.GetEnumValue(current.CONVIS.Value);
            }

            if (current.WATLEV.HasValue) {
                if (current.WATLEV.Value == -32767)
                    instance.waterLevelEffect_optional = default;
                else {
                    instance.waterLevelEffect_optional = EnumHelper.GetEnumValue(current.WATLEV);
                }
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