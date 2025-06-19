using ArcGIS.Core.Data;
using ArcGIS.Core.Internal.CIM;
using NetTopologySuite.Operation.Buffer;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace S100Framework.Applications
{
    internal static partial class Converters
    {
        internal static SignalStationTraffic CreateSignalStationTraffic(PortsAndServicesP current, Geodatabase source) {

            var instance = new SignalStationTraffic();
            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                string subtype = "";

                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
            }

            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            return instance;

        }
    }
}

