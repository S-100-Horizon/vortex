using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class Converters
    {

        internal static Daymark CreateDaymark(AidsToNavigationP current, int? scaleMinimum, Geodatabase source) {
            var instance = new Daymark {
                topmarkDaymarkShape = default,
            };

            if (current.CATSPM != default) {
                instance.categoryOfSpecialPurposeMark = EnumHelper.GetEnumValues<Daymark,categoryOfSpecialPurposeMark>(current.CATSPM);
            }

            if (current.COLOUR != default) {
                instance.colour = EnumHelper.GetEnumValues<Daymark,colour>(current.COLOUR);
            }



            if (current.COLPAT != default) {
                if (current.COLPAT.Contains(",")) {
                    var colpats = current.COLPAT.Split(',');
                    Logger.Current.DataError(current.OBJECTID ?? -1, current.TableName!, current.LNAM ?? "Unknown LNAM", $"Illegal COLPAT: {current.COLPAT}. Using 1st value.");
                    instance.colourPattern = ImporterNIS.GetColourPattern(colpats[0]);

                }
                else {
                    instance.colourPattern = ImporterNIS.GetColourPattern(current.COLPAT);
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

            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                instance.height = current.HEIGHT.Value;
            }
            else {
                instance.height = default(double?);
            }

            // TODO: interoperabilityidentifier

            if (current.NATCON != default) {
                instance.natureOfConstruction = EnumHelper.GetEnumValues<Daymark,natureOfConstruction>(current.NATCON);
            }

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange = periodicDateRange;
            }

            if (current.CONRAD.HasValue) {
                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
            }

            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }

            if (current.TOPSHP.HasValue) {
                instance.topmarkDaymarkShape = EnumHelper.GetEnumValue<Daymark,topmarkDaymarkShape>(current.TOPSHP.Value);
            }

            if (current.VERLEN.HasValue) {
                instance.verticalLength = current.VERLEN.Value;
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

                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
            }

            instance.SetInformationBindings(ImporterNIS.AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

            return instance;
        }
    }
}
