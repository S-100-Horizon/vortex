using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class Converters
    {

        internal static Daymark CreateDaymark(AidsToNavigationP current, Geodatabase source) {
            var instance = new Daymark {
                topmarkDaymarkShape = default,
            };

            if (current.CATSPM != default) {
                instance.categoryOfSpecialPurposeMark = EnumHelper.GetEnumValues<categoryOfSpecialPurposeMark>(current.CATSPM);
            }

            if (current.COLOUR != default) {
                instance.colour = EnumHelper.GetEnumValues<colour>(current.COLOUR);
            }

            if (current.COLPAT != default) {
                instance.colourPattern = ImporterNIS.GetColourPattern(current.COLPAT);
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
                instance.height = current.HEIGHT.Value;
            }

            // TODO: interoperabilityidentifier

            if (current.NATCON != default) {
                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
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
                instance.topmarkDaymarkShape = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
            }

            if (current.VERLEN.HasValue) {
                instance.verticalLength = current.VERLEN.Value;
            }

            // TODO: shapeInformation

            if (current.PICREP != default) {
                instance.pictorialRepresentation = current.PICREP;
            }

            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                string subtype = "";

                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
            }

            return instance;
        }



    }
}
