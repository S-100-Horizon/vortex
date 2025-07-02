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
            internal static RadarTransponderBeacon CreateRadarTransponderBeacon(AidsToNavigationP current, Geodatabase source) {
            var instance = new RadarTransponderBeacon {
                categoryOfRadarTransponderBeacon = default,
            };

            if (current.CATROS != null) {
                instance.categoryOfRadarTransponderBeacon = EnumHelper.GetEnumValue<categoryOfRadarTransponderBeacon>(current.CATROS);
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
            if (dateRange != default) {
                instance.fixedDateRange = dateRange;
            }

            // TODO: interoperabilityidentifier

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange = periodicDateRange;
            }

            if (current.RADWAL != default) {
                if (ImporterNIS.TryGetRadarWaveLengths(current.RADWAL, out var lengths)) {
                    instance.radarWaveLength = lengths;
                }
            }

            if (current.SECTR1.HasValue && current.SECTR2.HasValue) {
                instance.sectorLimit = new sectorLimit() {
                    sectorLimitOne = new sectorLimitOne {
                        sectorBearing = current.SECTR1.Value,
                    },
                    sectorLimitTwo = new sectorLimitTwo {
                        sectorBearing = current.SECTR2.Value
                    }
                };
            }

            var rhythmOfLight = ImporterNIS.GetRythmOfLight(current);

            if (current.SIGGRP != default) {
                instance.signalGroup = current.SIGGRP;
            }

            if (current.SIGSEQ != default) {
                instance.signalSequence = rhythmOfLight.signalSequence;
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

                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
            }

            return instance;
        }



    }
}
