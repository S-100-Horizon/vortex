using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.AttributeModel.S101;
using S100Framework.AttributeModel.S101.ComplexAttributes;
using S100Framework.AttributeModel.S101.FeatureTypes;


namespace S100Framework.Applications
{
    internal static partial class Converters
    {
        internal static RadarTransponderBeacon CreateRadarTransponderBeacon(AidsToNavigationP current, int? scaleMinimum, Geodatabase source) {
            var instance = new RadarTransponderBeacon {
                categoryOfRadarTransponderBeacon = default,
            };

            if (current.CATRTB != null) {
                instance.categoryOfRadarTransponderBeacon = EnumHelper.GetEnumValue(current.CATRTB);
            }

            instance.featureName_optional = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
            if (dateRange != default) {
                instance.fixedDateRange_optional = dateRange;
            }

            // TODO: interoperabilityidentifier

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange_optional = periodicDateRange;
            }

            if (current.RADWAL != default) {
                if (ImporterNIS.TryGetRadarWaveLengths(current.RADWAL, out var lengths)) {
                    instance.radarWaveLength_optional = lengths;
                }
            }

            if (current.SECTR1.HasValue && current.SECTR2.HasValue) {
                instance.sectorLimit_optional = new sectorLimit() {
                    sectorLimitOne = new sectorLimitOne {
                        sectorBearing = current.SECTR1.Value,
                    },
                    sectorLimitTwo = new sectorLimitTwo {
                        sectorBearing = current.SECTR2.Value
                    }
                };
            }

            var rhythmOfLight = ImporterNIS.GetRythmOfLight<RadarTransponderBeacon>(current);

            if (current.SIGGRP != default) {
                instance.signalGroup_optional = current.SIGGRP;
            }

            if (current.SIGSEQ != default) {
                instance.signalSequence_optional = rhythmOfLight.signalSequence;
            }

            if (current.STATUS != default) {
                instance.status_optional = ImporterNIS.GetStatus(current.STATUS);
            }

            if (current.VALMXR.HasValue) {
                instance.valueOfMaximumRange_optional = current.VALMXR.Value;
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

            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
            instance.information_optional = result.information.ToArray();
            instance.SetInformationBindings(result.InformationBindings.ToArray());

            return instance;
        }



    }
}
