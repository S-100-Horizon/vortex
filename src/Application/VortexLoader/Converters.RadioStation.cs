using S100Framework.Applications.S57.esri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;
using ArcGIS.Core.Data;
using S100Framework.Applications.Singletons;


namespace S100Framework.Applications
{
    internal static partial class Converters {
            internal static RadioStation CreateRadioStation(AidsToNavigationP current, Geodatabase source) {
            var instance = new RadioStation();

            if (current.CALSGN != default) {
                instance.callSign = current.CALSGN;
            }

            if (current.CATROS != null) {
                instance.categoryOfRadioStation = EnumHelper.GetEnumValues<categoryOfRadioStation>(current.CATROS);
            }

            if (current.COMCHA != default) {
                instance.communicationChannel = current.COMCHA.Split(',').ToList<string>();
            }

            if (current.ESTRNG.HasValue) {
                instance.estimatedRangeOfTransmission = current.ESTRNG.Value;
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
            if (dateRange != default) {
                instance.fixedDateRange = dateRange;
            }

            if (current.SIGFRQ.HasValue) {
                instance.frequencyPair = ImporterNIS.GetFrequencyPair(current.SIGFRQ.Value);
            }

            // TODO: interoperabilityidentifier

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange = periodicDateRange;
            }

            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }

            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                string subtype = "";

                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
            }


            return instance;
        }



    }
}
