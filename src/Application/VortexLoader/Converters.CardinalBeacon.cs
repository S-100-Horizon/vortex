using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.AttributeModel.S101;
using S100Framework.AttributeModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class Converters
    {
        internal static CardinalBeacon CreateCardinalBeacon(AidsToNavigationP current, int? scaleMinimum, Geodatabase source) {
            var instance = new CardinalBeacon {
                //beaconShape = default,
                //categoryOfCardinalMark = default,
            };

            if (current.BCNSHP.HasValue) {
                instance.beaconShape!.value = EnumHelper.GetEnumValue(current.BCNSHP);
            }

            if (current.CATCAM.HasValue) {
                instance.categoryOfCardinalMark!.value = EnumHelper.GetEnumValue(current.CATCAM.Value);
            }

            if (current.COLOUR != default) {
                var colours = ImporterNIS.GetColours<CardinalBeacon>(current.COLOUR);
                if (colours != null && colours.Any()) {
                    instance.colour[0].value = colours[0];
                    if (colours.Count() > 1)
                        instance.colour_optional = colours[1..];
                }
                //instance.colour = ImporterNIS.GetColours<CardinalBeacon>(current.COLOUR);
            }


            if (current.COLPAT != default) {
                instance.colourPattern_optional = ImporterNIS.GetColourPattern(current.COLPAT)?.value;
            }

            if (current.CONDTN.HasValue) {
                instance.condition_optional = ImporterNIS.GetCondition(current.CONDTN.Value).value;
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
                instance.height_optional = default(double?);
            }

            // TODO: interoperabilityidentifier

            if (current.MARSYS.HasValue) {
                instance.marksNavigationalSystemOf_optional = EnumHelper.GetEnumValue(current.MARSYS.Value);
            }

            if (current.NATCON != default) {
                instance.natureOfConstruction_optional = EnumHelper.GetEnumValues(current.NATCON)!;
            }

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange_optional = [.. periodicDateRange];
            }

            if (current.CONRAD.HasValue) {
                instance.radarConspicuous_optional = current.CONRAD.Value == 2 ? false : true;
            }
            if (!string.IsNullOrEmpty(current.SORDAT)) {
                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                    instance.reportedDate_optional = result;
                }
                else {
                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                }
            }

            if (current.STATUS != default) {
                var status = ImporterNIS.GetStatus(current.STATUS);
                if (status != null && status.Any())
                    instance.status_optional = status;
            }

            var topmark = ImporterNIS.relatedEquipment?.GetTopMark<CardinalBeacon>(current);
            if (topmark != null) {
                instance.topmark_optional = topmark;
            }

            if (current.VERLEN.HasValue) {
                instance.verticalLength_optional = current.VERLEN.Value;
            }

            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                instance.visualProminence_optional = EnumHelper.GetEnumValue(current.CONVIS.Value);
            }


            if (current.PICREP != default) {
                instance.pictorialRepresentation_optional = ImporterNIS.FixFilename(current.PICREP) ?? default;
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

            instance.SetInformationBindings(ImporterNIS.AddInformation(instance.information_optional, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));



            return instance;
        }
    }
}
