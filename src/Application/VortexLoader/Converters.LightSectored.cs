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
                instance.exhibitionConditionOfLight_optional = EnumHelper.GetEnumValue(current.EXCLIT.Value);
            }

            instance.featureName_optional = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
            if (dateRange != default) {
                instance.fixedDateRange_optional = dateRange;
            }


            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                instance.height_optional = current.HEIGHT.Value;
            }
            else {
                instance.height_optional = default(double?);
            }


            // TODO: interoperabilityidentifier

            if (current.MARSYS.HasValue) {
                instance.marksNavigationalSystemOf_optional = EnumHelper.GetEnumValue(current.MARSYS.Value);
            }

            if (current.MLTYLT.HasValue) {
                instance.multiplicityOfFeatures_optional = new multiplicityOfFeatures() {
                    multiplicityKnown = true,
                    numberOfFeatures_optional = current.MLTYLT
                };
            }

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange_optional = periodicDateRange;
            }

            var sectorCharacteristics = ImporterNIS.GetSectorCharacteristics<LightSectored>(lights);
            if (sectorCharacteristics is not null && sectorCharacteristics.Any()) {
                instance.sectorCharacteristics = sectorCharacteristics[0];
                instance.sectorCharacteristics_optional = sectorCharacteristics[1..];
            }

            if (current.SIGGEN != null) {
                instance.signalGeneration_optional = EnumHelper.GetEnumValue(current.SIGGEN.Value);
            }

            if (current.STATUS != default) {
                instance.status_optional = ImporterNIS.GetStatus(current.STATUS);
            }


            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
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
                instance.exhibitionConditionOfLight_optional = EnumHelper.GetEnumValue(current.EXCLIT.Value);
            }
            
            instance.featureName_optional = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
            if (dateRange != default) {
                instance.fixedDateRange_optional = dateRange;
            }


            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                instance.height_optional = current.HEIGHT.Value;
            }

            // TODO: interoperabilityidentifier

            if (current.MARSYS.HasValue) {
                instance.marksNavigationalSystemOf_optional = EnumHelper.GetEnumValue(current.MARSYS.Value);
            }

            if (current.MLTYLT.HasValue) {
                instance.multiplicityOfFeatures_optional = new multiplicityOfFeatures() {
                    multiplicityKnown = true,
                    numberOfFeatures_optional = current.MLTYLT
                };
            }

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange_optional = periodicDateRange;
            }

            if (lights.Count == 0) {
                var sectorCharacteristics = ImporterNIS.GetSectorCharacteristics<LightSectored>([current]);
                if (sectorCharacteristics is not null && sectorCharacteristics.Any()) {
                    instance.sectorCharacteristics = sectorCharacteristics[0];
                    instance.sectorCharacteristics_optional = sectorCharacteristics[1..];
                }
            }
            else {
                var sectorCharacteristics = ImporterNIS.GetSectorCharacteristics<LightSectored>(lights);
                if (sectorCharacteristics is not null && sectorCharacteristics.Any()) {
                    instance.sectorCharacteristics = sectorCharacteristics[0];
                    instance.sectorCharacteristics_optional = sectorCharacteristics[1..];
                }
            }            

            if (current.SIGGEN != null) {
                instance.signalGeneration_optional = EnumHelper.GetEnumValue(current.SIGGEN.Value);
            }

            if (current.STATUS != default) {
                instance.status_optional = ImporterNIS.GetStatus(current.STATUS);
            }

            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                string subtype = "";
                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                instance.scaleMinimum_optional = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
            }

            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
            instance.information_optional = result.information.ToArray();
            instance.SetInformationBindings(result.InformationBindings.ToArray());

            return instance;
        }
    }
}
