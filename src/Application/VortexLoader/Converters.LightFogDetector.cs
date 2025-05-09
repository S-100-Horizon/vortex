using S100Framework.Applications.S57.esri;
using S100Framework.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel.S101;

namespace S100Framework.Applications
{
    internal static partial class Converters
    {
        internal static LightFogDetector CreateLightFogDetector(AidsToNavigationP current) {
            var instance = new LightFogDetector();

            if (current.COLOUR != default) {
                instance.colour = ImporterNIS.GetColours(current.COLOUR);
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
            if (dateRange != default) {
                instance.fixedDateRange = dateRange;
            }

            // flareBearing is not populated. New field.

            if (current.HEIGHT.HasValue) {
                instance.height = current.HEIGHT.Value;
            }

            // DODO: Interoperability identifier

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange = periodicDateRange;
            }

            instance.rhythmOfLight = ImporterNIS.GetRythmOfLight(current);

            if (current.SIGGEN != null) {
                instance.signalGeneration = EnumHelper.GetEnumValue<signalGeneration>(current.SIGGEN.Value);
            }

            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }

            if (current.VERDAT.HasValue) {
                instance.verticalDatum = EnumHelper.GetEnumValue<verticalDatum>(current.VERDAT.Value);
            }

            if (current.VERLEN.HasValue) {
                instance.verticalLength = current.VERLEN.Value;
            }

            if (current.HEIGHT.HasValue) {
                instance.height = current.HEIGHT.Value;
            }

            return instance;
        }


    }
}
