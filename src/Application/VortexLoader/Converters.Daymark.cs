using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.AttributeModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class Converters
    {

        internal static Daymark CreateDaymark(AidsToNavigationP current, int? scaleMinimum, Geodatabase source) {
            var instance = new Daymark {
            };

            if (current.CATSPM != default) {
                var categoryOfSpecialPurposeMark = EnumHelper.GetEnumValues(current.CATSPM);
                if (categoryOfSpecialPurposeMark != null && categoryOfSpecialPurposeMark.Any())
                    instance.categoryOfSpecialPurposeMark_optional = categoryOfSpecialPurposeMark;
            }

            if (current.COLOUR != default) {
                var colours = ImporterNIS.GetColours(current.COLOUR);
                if (colours != null && colours.Any()) {
                    instance.colour.value = colours[0];
                    if (colours.Count() > 1)
                        instance.colour_optional = colours[1..];
                }
            }

            if (current.COLPAT != default) {
                if (current.COLPAT.Contains(",")) {
                    var colpats = current.COLPAT.Split(',');
                    Logger.Current.DataError(current.OBJECTID ?? -1, current.TableName!, current.LNAM ?? "Unknown LNAM", $"Illegal COLPAT: {current.COLPAT}. Only {colpats[0]} is used. The colors needs reviewing.");
                    instance.colourPattern_optional = ImporterNIS.GetColourPattern(colpats[0])?.value;
                }
                else {
                    instance.colourPattern_optional = ImporterNIS.GetColourPattern(current.COLPAT)?.value;
                }
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

            // TODO: interoperabilityidentifier

            if (current.NATCON != default) {
                var natureOfConstruction = EnumHelper.GetEnumValues(current.NATCON);
                if (natureOfConstruction != null && natureOfConstruction.Any())
                    instance.natureOfConstruction_optional = natureOfConstruction;
            }

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange_optional = [.. periodicDateRange];
            }

            if (current.CONRAD.HasValue) {
                instance.radarConspicuous_optional = current.CONRAD.Value == 2 ? false : true;
            }

            if (current.STATUS != default) {
                instance.status_optional = ImporterNIS.GetStatus(current.STATUS);
            }

            if (current.TOPSHP.HasValue) {
                instance.topmarkDaymarkShape!.value = EnumHelper.GetEnumValue(current.TOPSHP.Value);
            }

            if (current.VERLEN.HasValue) {
                instance.verticalLength_optional = current.VERLEN.Value;
            }

            // TODO: shapeInformation

            if (current.PICREP != default) {
                instance.pictorialRepresentation_optional = ImporterNIS.FixFilename(current.PICREP);
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
