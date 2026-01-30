using ArcGIS.Core.Data;
using S100FC.S101.ComplexAttributes;
using S100FC.S101.FeatureTypes;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;

namespace S100Framework.Applications
{
    internal static partial class Converters
    {

        internal static LightSectored CreateLightSectored(IList<PltsSlave> slaves, int? scaleMinimum, Geodatabase source) {
            var instance = new LightSectored();

            var lights = new List<AidsToNavigationP>();
            foreach (var slave in slaves) {
                if (slave.S101Type == typeof(LightSectored)) {
                    var obj = slave.S57Object as AidsToNavigationP;
                    if (obj == null) {
                        throw new NotSupportedException($"{slave.S57Object} is not an AidsToNavigationP");
                    }
                    lights.Add(obj);
                }
            }

            var current = lights.First();
            // TODO: evaluate light sectors based on height. Assume same height for now and take data from first.
            //var current = lights.First();

            //foreach (var lightN in lights) {
            //    if (lightN.CATLIT != default) {
            //        var list = EnumHelper.GetEnumValues<categoryOfLight>(lightN.CATLIT);
            //        instance.categoryOfLight = instance.categoryOfLight.Union(list).ToList<categoryOfLight>();
            //            //var it = (List<categoryOfLight>);
            //        //instance.categoryOfLight = null;
            //    }
            //     TODO: CATLITs
            //}

            if (current.EXCLIT.HasValue) {
                instance.exhibitionConditionOfLight = EnumHelper.GetEnumValue(current.EXCLIT.Value);
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
            if (dateRange != default) {
                instance.fixedDateRange = dateRange;
            }


            if (current.HEIGHT.HasValue) {
                instance.height = current.HEIGHT.Value != -32767m ? current.HEIGHT.Value : null;
            }
            else {
                instance.height = default(decimal?);
            }


            // TODO: interoperabilityidentifier

            if (current.MARSYS.HasValue) {
                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue(current.MARSYS.Value);
            }

            if (current.MLTYLT.HasValue) {
                instance.multiplicityOfFeatures = new multiplicityOfFeatures() {
                    multiplicityKnown = true,
                    numberOfFeatures = current.MLTYLT
                };
            }

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange = periodicDateRange;
            }

            var sectorCharacteristics = ImporterNIS.GetSectorCharacteristics<LightSectored>(lights);
            if (sectorCharacteristics is not null)
                instance.sectorCharacteristics = sectorCharacteristics;

            if (current.SIGGEN != null) {
                instance.signalGeneration = EnumHelper.GetEnumValue(current.SIGGEN.Value);
            }

            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }


            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
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




        internal static LightSectored CreateLightSectored(S57Object structure, int? scaleMinimum, Geodatabase source) {
            var instance = new LightSectored();

            var lights = FeatureRelations.Instance.GetRelated<AidsToNavigationP>(typeof(LightSectored), structure.GlobalId);
            AidsToNavigationP current;
            if (lights.Count == 0) {
                current = (AidsToNavigationP)structure;
            }
            else {
                current = lights.First();
            }
            // TODO: evaluate light sectors based on height. Assume same height for now and take data from first.
            //var current = lights.First();

            //foreach (var lightN in lights) {
            //    if (lightN.CATLIT != default) {
            //        var list = EnumHelper.GetEnumValues<categoryOfLight>(lightN.CATLIT);
            //        instance.categoryOfLight = instance.categoryOfLight.Union(list).ToList<categoryOfLight>();
            //            //var it = (List<categoryOfLight>);
            //        //instance.categoryOfLight = null;
            //    }
            //     TODO: CATLITs
            //}

            if (current.EXCLIT.HasValue) {
                instance.exhibitionConditionOfLight = EnumHelper.GetEnumValue(current.EXCLIT.Value);
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
            if (dateRange != default) {
                instance.fixedDateRange = dateRange;
            }


            if (current.HEIGHT.HasValue) {
                instance.height = current.HEIGHT.Value != -32767m ? current.HEIGHT.Value : null;
            }

            // TODO: interoperabilityidentifier

            if (current.MARSYS.HasValue) {
                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue(current.MARSYS.Value);
            }

            if (current.MLTYLT.HasValue) {
                instance.multiplicityOfFeatures = new multiplicityOfFeatures() {
                    multiplicityKnown = true,
                    numberOfFeatures = current.MLTYLT
                };
            }

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange = periodicDateRange;
            }

            if (lights.Count == 0) {
                var sectorCharacteristics = ImporterNIS.GetSectorCharacteristics<LightSectored>([current]);
                if (sectorCharacteristics is not null)
                    instance.sectorCharacteristics = sectorCharacteristics;
            }
            else {
                var sectorCharacteristics = ImporterNIS.GetSectorCharacteristics<LightSectored>(lights);
                if (sectorCharacteristics is not null)
                    instance.sectorCharacteristics = sectorCharacteristics;
            }

            if (current.SIGGEN != null) {
                instance.signalGeneration = EnumHelper.GetEnumValue(current.SIGGEN.Value);
            }

            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }

            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
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
