using S100Framework.Applications.S57.esri;
using S100Framework.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S501.ComplexAttributes;

namespace S100Framework.Applications
{
    internal static partial class Converters {
            internal static CardinalBeacon CreateCardinalBeacon(AidsToNavigationP current) {
            var instance = new CardinalBeacon();

            if (current.BCNSHP.HasValue) {
                instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>(current.BCNSHP);
            }

            if (current.CATCAM.HasValue) {
                instance.categoryOfCardinalMark = EnumHelper.GetEnumValue<categoryOfCardinalMark>(current.CATCAM.Value);
            }

            if (current.COLOUR != default) {
                instance.colour = ImporterNIS.GetColours(current.COLOUR);
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

            if (current.HEIGHT.HasValue) {
                instance.height = current.HEIGHT.Value;
            }

            // TODO: interoperabilityidentifier

            if (current.MARSYS.HasValue) {
                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS.Value);
            }

            if (current.NATCON != default) {
                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
            }

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange = periodicDateRange;
            }

            if (current.CONRAD.HasValue) {
                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
            }

            if (current.SORDAT != default) {
                if (DateHelper.TryConvertToDateOnly(current.SORDAT, out var dateOnly)) {
                    instance.reportedDate = dateOnly;
                }
                else {
                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                }
            }

            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }

            var topmark = ImporterNIS.relatedEquipment?.GetTopMark(current);
            if (topmark != null) {
                instance.topmark = topmark;
            }

            if (current.VERLEN.HasValue) {
                instance.verticalLength = current.VERLEN.Value;
            }

            if (current.CONVIS.HasValue) {
                instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
            }


            if (current.PICREP != default) {
                instance.pictorialRepresentation = current.PICREP;
            }

            return instance;
        }



    }
}
