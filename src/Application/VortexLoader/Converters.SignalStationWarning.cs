using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S100Framework.Applications.Singletons;

namespace S100Framework.Applications
{
    internal static partial class Converters
    {

        internal static SignalStationWarning CreateSignalStationWarning(PortsAndServicesP current, Geodatabase source) {

            var instance = new SignalStationWarning();

            if (current.CATSIW != default) {
                instance.categoryOfSignalStationWarning = EnumHelper.GetEnumValues<categoryOfSignalStationWarning>(current.CATSIW);
            }

            if (current.COMCHA != default) {
                instance.communicationChannel = current.COMCHA.Split(',').ToList<string>();
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);


            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
            if (dateRange != default) {
                instance.fixedDateRange = dateRange;
            }

            // DODO: Interoperability identifier

            // TODO: Maximum permitted draught



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
