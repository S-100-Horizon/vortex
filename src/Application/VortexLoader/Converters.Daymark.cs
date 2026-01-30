using ArcGIS.Core.Data;
using S100FC.S101.FeatureTypes;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;

namespace S100Framework.Applications
{
    internal static partial class Converters
    {

        internal static Daymark CreateDaymark(AidsToNavigationP current, int? scaleMinimum, Geodatabase source) {
            var instance = new Daymark {
            };

            if (current.CATSPM != default) {
                var categoryOfSpecialPurposeMark = EnumHelper.GetEnumValues(current.CATSPM);
                if (categoryOfSpecialPurposeMark is not null)
                    instance.categoryOfSpecialPurposeMark = categoryOfSpecialPurposeMark;
            }

            if (current.COLOUR != default) {
                var colours = ImporterNIS.GetColours(current.COLOUR);
                if (colours is not null)
                    instance.colour = colours;
            }

            if (current.COLPAT != default) {
                if (current.COLPAT.Contains(",")) {
                    var colpats = current.COLPAT.Split(',');
                    Logger.Current.DataError(current.OBJECTID ?? -1, current.TableName!, current.LNAM ?? "Unknown LNAM", $"Illegal COLPAT: {current.COLPAT}. Only {colpats[0]} is used. The colors needs reviewing.");
                    instance.colourPattern = ImporterNIS.GetColourPattern(colpats[0])?.value;
                }
                else {
                    instance.colourPattern = ImporterNIS.GetColourPattern(current.COLPAT)?.value;
                }
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

            // TODO: interoperabilityidentifier

            if (current.NATCON != default) {
                var natureOfConstruction = EnumHelper.GetEnumValues(current.NATCON);
                if (natureOfConstruction != null && natureOfConstruction.Any())
                    instance.natureOfConstruction = natureOfConstruction;
            }

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange = [.. periodicDateRange];
            }

            if (current.CONRAD.HasValue) {
                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
            }

            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }

            if (current.TOPSHP.HasValue) {
                instance.topmarkDaymarkShape = EnumHelper.GetEnumValue(current.TOPSHP.Value);
            }

            if (current.VERLEN.HasValue) {
                instance.verticalLength = current.VERLEN.Value != -32767m ? current.VERLEN.Value : null;
            }

            // TODO: shapeInformation

            if (current.PICREP != default) {
                instance.pictorialRepresentation = ImporterNIS.FixFilename(current.PICREP);
            }

            if (scaleMinimum.HasValue) {
                instance.scaleMinimum = scaleMinimum;
            }
            else if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
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
