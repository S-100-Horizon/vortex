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
            internal static RadarStation CreateRadarStation(AidsToNavigationP current, Geodatabase source) {
            var instance = new RadarStation();

            if (current.CALSGN != default) {
                instance.callSign = current.CALSGN;
            }

            if (current.CATRAS != null) {
                instance.categoryOfRadarStation = EnumHelper.GetEnumValues<categoryOfRadarStation>(current.CATRAS);
            }

            if (current.COMCHA != default) {
                instance.communicationChannel = ImporterNIS.GetCommunicationChannel(current.COMCHA);
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            if (current.HEIGHT.HasValue) {
                instance.height = current.HEIGHT.Value;
            }

            // TODO: interoperabilityidentifier

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange = periodicDateRange;
            }

            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }

            if (current.VALMXR.HasValue) {
                instance.valueOfMaximumRange = current.VALMXR.Value;
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
