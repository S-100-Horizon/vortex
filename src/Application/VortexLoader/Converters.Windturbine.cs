using ArcGIS.Core.Data;
using S100FC.S101.ComplexAttributes;
using S100FC.S101.FeatureTypes;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;


namespace S100Framework.Applications
{
    internal static partial class Converters
    {

        internal static WindTurbine CreateWindturbine(CulturalFeaturesP current, int? scaleMinimum, Geodatabase source) {
            var instance = new WindTurbine();

            if (current.COLOUR != default) {
                var colours = ImporterNIS.GetColours(current.COLOUR);
                if (colours is not null)
                    instance.colour = colours;
            }

            if (current.COLPAT != default) {
                instance.colourPattern = ImporterNIS.GetColourPattern(current.COLPAT)?.value;
            }

            if (current.CONDTN.HasValue) {
                instance.condition = ImporterNIS.GetCondition(current.CONDTN.Value)?.value;
            }

            if (current.ELEVAT.HasValue) {
                instance.elevation = current.ELEVAT.Value;
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
            if (dateRange != default) {
                instance.fixedDateRange = dateRange;
            }
            if (current.HEIGHT.HasValue) {
                instance.height = current.HEIGHT.Value != -32767m ? current.HEIGHT.Value : null;
            }
            else {

            }

            // TODO: interoperabilityIdentifier

            // TODO: multiplicityOfFeatures

            if (current.NATCON != default) {
                var natureOfConstruction = EnumHelper.GetEnumValues(current.NATCON);
                if (natureOfConstruction is not null && natureOfConstruction.Any())
                    instance.natureOfConstruction = natureOfConstruction;
            }

            if (current.CONRAD.HasValue) {
                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
            }
            if (!string.IsNullOrEmpty(current.SORDAT)) {
                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                    instance.reportedDate = reportedDate;
                }
                else {
                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                }
            }



            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }

            var verticalUncertainty = new verticalUncertainty();
            if (current.VERACC.HasValue)
                verticalUncertainty.uncertaintyFixed = current.VERACC.Value != -32767m ? current.VERACC.Value : null;

            var verticalClearanceFixed = new verticalClearanceFixed {
                verticalUncertainty = verticalUncertainty
            };
            if (current.VERCLR.HasValue)
                verticalClearanceFixed.verticalClearanceValue = current.VERCLR.Value != -32767m ? current.VERCLR.Value : null;

            instance.verticalClearanceFixed = new() {
                verticalUncertainty = verticalUncertainty,
            };

            if (current.VERLEN.HasValue) {
                instance.verticalLength = current.VERLEN.Value != -32767m ? current.VERLEN.Value : null;
                var verticalDatum = ImporterNIS.GetVerticalDatum(current.VERDAT);
                if (verticalDatum != default)
                    instance.verticalDatum = verticalDatum.value;
            }

            if (current.CONVIS.HasValue /*&& current.CONVIS.Value != -32767*/) {
                instance.visualProminence = EnumHelper.GetEnumValue(current.CONVIS.Value);
            }

            if (current.WATLEV.HasValue) {
                if (current.WATLEV.Value == -32767)
                    instance.waterLevelEffect = default;
                else {
                    instance.waterLevelEffect = EnumHelper.GetEnumValue(current.WATLEV);
                }
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