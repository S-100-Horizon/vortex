using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class Converters
    {
        internal static CardinalBeacon CreateCardinalBeacon(AidsToNavigationP current, int? scaleMinimum, Geodatabase source) {
            var instance = new CardinalBeacon {
                beaconShape = default,
                categoryOfCardinalMark = default,
            };

            if (current.BCNSHP.HasValue) {
                instance.beaconShape = EnumHelper.GetEnumValue<CardinalBeacon, beaconShape>(current.BCNSHP);
            }

            if (current.CATCAM.HasValue) {
                instance.categoryOfCardinalMark = EnumHelper.GetEnumValue<CardinalBeacon, categoryOfCardinalMark>(current.CATCAM.Value);
            }

            if (current.COLOUR != default) {
                instance.colour = ImporterNIS.GetColours<CardinalBeacon>(current.COLOUR);
            }

            if (current.COLPAT != default) {
                instance.colourPattern = ImporterNIS.GetColourPattern(current.COLPAT);
            }

            if (current.CONDTN.HasValue) {
                instance.condition = ImporterNIS.GetCondition(current.CONDTN.Value);
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

            if (current.MARSYS.HasValue) {
                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<CardinalBeacon, marksNavigationalSystemOf>(current.MARSYS.Value);
            }

            if (current.NATCON != default) {
                instance.natureOfConstruction = EnumHelper.GetEnumValues<CardinalBeacon, natureOfConstruction>(current.NATCON);
            }

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange = periodicDateRange;
            }

            if (current.CONRAD.HasValue) {
                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
            }
            if (!string.IsNullOrEmpty(current.SORDAT)) {
                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                    instance.reportedDate = result;
                }
                else {
                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                }
            }

            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }

            var topmark = ImporterNIS.relatedEquipment?.GetTopMark<CardinalBeacon>(current);
            if (topmark != null) {
                instance.topmark = topmark;
            }

            if (current.VERLEN.HasValue) {
                instance.verticalLength = current.VERLEN.Value;
            }

            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                instance.visualProminence = EnumHelper.GetEnumValue<CardinalBeacon, visualProminence>(current.CONVIS.Value);
            }


            if (current.PICREP != default) {
                instance.pictorialRepresentation = current.PICREP;
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

            ImporterNIS.AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);

            return instance;
        }
    }
}
