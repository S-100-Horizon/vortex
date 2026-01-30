using ArcGIS.Core.Data;
using S100FC.S101.FeatureTypes;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;

namespace S100Framework.Applications
{
    internal static partial class Converters
    {
        internal static FogSignal CreateFogSignal(S57Object structure, int? scaleMinimum, Geodatabase source) {

            var instance = new FogSignal {
            };

            var current = structure as AidsToNavigationP;

            if (current == null) {
                throw new NotSupportedException("structure is not an AidsToNavigation");
            }

            if (current.CATFOG.HasValue != default) {
                instance.categoryOfFogSignal = EnumHelper.GetEnumValue(current.CATFOG.Value);
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

            if (current.SIGFRQ.HasValue) {
                instance.signalFrequency = current.SIGFRQ.Value;
            }
            if (current.SIGGEN.HasValue) {
                instance.signalGeneration = EnumHelper.GetEnumValue(current.SIGGEN.Value);
            }
            if (current.SIGGRP != default) {
                instance.signalGroup = current.SIGGRP;
            }

            if (current.SIGPER != default) {
                instance.signalPeriod = current.SIGPER == -32767m ? null : current.SIGPER;
            }

            if (current.SIGSEQ != default) {
                instance.signalSequence = ImporterNIS.GetSignalSequences(current.SIGSEQ);
            }

            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            // TODO: interoperabilityidentifier

            if (current.VALMXR.HasValue) {
                instance.valueOfMaximumRange = current.VALMXR.Value;
            }

            if (scaleMinimum.HasValue) {
                instance.scaleMinimum = scaleMinimum;
            }
            else if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                string subtype = "";

                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                var scamin = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                if (scamin.HasValue)
                    instance.scaleMinimum = scamin.Value;
            }

            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
            instance.information = result.information.ToArray();
            instance.SetInformationBindings(result.InformationBindings.ToArray());

            return instance;
        }
    }
}


