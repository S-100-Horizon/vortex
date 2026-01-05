using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.AttributeModel.S101;
using S100Framework.AttributeModel.S101.ComplexAttributes;
using S100Framework.AttributeModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_RegulatedAreasAndLimitsP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "RegulatedAreasAndLimitsP";
            var ps101 = "S-101";

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("point"));

            using var regulatedAreasAndLimitsP = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            Subtypes.Instance.RegisterSubtypes(regulatedAreasAndLimitsP);

            int recordCount = 0;

            using var buffer = featureClass.CreateRowBuffer();

            using var cursor = regulatedAreasAndLimitsP.Search(filter, true);

            while (cursor.MoveNext()) {
                recordCount += 1;
                var feature = (Feature)cursor.Current;
                var current = new RegulatedAreasAndLimitsP(feature); // (Row)cursor.Current;

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;

                if (FeatureRelations.Instance.IsSlave(globalid)) {
                    continue;
                }

                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    throw new Exception("Ups. Not supported");
                }



                var fcSubtype = current.FCSUBTYPE ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;
                var status = current.STATUS ?? default;
                var verlen = current.VERLEN ?? default;

                switch (fcSubtype) {
                    case 1: { // ACHARE_AnchorageArea
                            var instance = new AnchorageArea();


                            if (current.CATACH == "8") {
                                throw new NotSupportedException("Anchorage area category 8 not implemented. Create mooring area.");
                            }

                            if (current.CATACH != default) {
                                instance.categoryOfAnchorage = EnumHelper.GetEnumValues<AnchorageArea, categoryOfAnchorage>(current.CATACH);
                            }

                            // new S-101
                            //instance.categoryOfCargo
                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);


                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            // TODO: interoperabilityIdentifier

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.RESTRN != default) {
                                instance.restriction = EnumHelper.GetEnumValues<AnchorageArea, restriction>(current.RESTRN);
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.INFORM is not null && instance.restriction is not null && instance.restriction.Contains(restriction.SpeedRestricted)) {
                                instance.vesselSpeedLimit = ImporterNIS.GetVesselSpeedLimit(current.INFORM);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }


                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            ImporterNIS.SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));


                        }
                        break;
                    case 5: { // ACHBRT_AnchorBerth
                            throw new NotImplementedException($"No ACHBRT_AnchorBerth in DK or GL. {tableName}");
                        }
                    case 10: { // CTSARE_CargoTranshipmentArea
                            throw new NotImplementedException($"No CTSARE_CargoTranshipmentArea in DK or GL. {tableName}");

                        }
                    case 15: { // DMPGRD_DumpingGround
                            var instance = new DumpingGround();

                            if (current.CATDPG != default) {
                                instance.categoryOfDumpingGround = EnumHelper.GetEnumValues<DumpingGround, categoryOfDumpingGround>(current.CATDPG);
                            }

                            // TODO: DateDisused

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            // TODO: interoperabilityIdentifier


                            if (current.RESTRN != default) {
                                instance.restriction = EnumHelper.GetEnumValues<DumpingGround, restriction>(current.RESTRN);
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.INFORM is not null && instance.restriction is not null && instance.restriction.Contains(restriction.SpeedRestricted)) {
                                instance.vesselSpeedLimit = ImporterNIS.GetVesselSpeedLimit(current.INFORM);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            ImporterNIS.SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;
                    case 25: { // ICNARE_IncinerationArea
                            throw new NotImplementedException($"No ICNARE_IncinerationArea in DK or GL. {tableName}");

                            //The S-57 Object class ICNARE will not be converted. 
                            //https://iho.int/uploads/user/pubs/standards/s-65/S-65%20Annex%20B_Ed%201.2.0_Final.pdf

                        }
                    case 30: { // LOGPON_LogPond
                            throw new NotImplementedException($"No LOGPON_LogPond in DK or GL. {tableName}");


                        }
                    case 35: { // MARCUL_MarineFarmCulture
                            var instance = new MarineFarmCulture() {
                                waterLevelEffect = default,
                            };


                            if (current.CATMFA != null) {
                                instance.categoryOfMarineFarmCulture = EnumHelper.GetEnumValue<MarineFarmCulture, categoryOfMarineFarmCulture>(current.CATMFA);
                            }

                            if (current.EXPSOU.HasValue) {
                                instance.expositionOfSounding = EnumHelper.GetEnumValue<MarineFarmCulture, expositionOfSounding>(current.EXPSOU.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);


                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            // TODO: HEIGHT

                            // TODO: interoperability identifier

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.QUASOU != default) {
                                instance.qualityOfVerticalMeasurement = EnumHelper.GetEnumValues<MarineFarmCulture, qualityOfVerticalMeasurement>(current.QUASOU);
                            }

                            if (current.RESTRN != default) {
                                instance.restriction = EnumHelper.GetEnumValues<MarineFarmCulture, restriction>(current.RESTRN);
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VALSOU.HasValue && current.VALSOU.Value != -32767d) {
                                instance.valueOfSounding = current.VALSOU.Value;
                            }
                            else {
                                instance.valueOfSounding = default(double?);
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }
                            else if (current.VERLEN.HasValue && current.VERLEN.Value == -32767d) {
                                instance.verticalLength = default(double?);
                            }

                            // TODO: VerticalUncertainty

                            if (current.INFORM is not null && instance.restriction is not null && instance.restriction.Contains(restriction.SpeedRestricted)) {
                                instance.vesselSpeedLimit = ImporterNIS.GetVesselSpeedLimit(current.INFORM);
                            }

                            if (current.WATLEV.HasValue) {
                                instance.waterLevelEffect = EnumHelper.GetEnumValue<MarineFarmCulture, waterLevelEffect>(current.WATLEV);
                            }

                            //if (plts_comp_scale != default) {
                            //  instance.scaleMinimum = plts_comp_scale;
                            //}

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            ImporterNIS.SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;
                    case 40: { // SPLARE_SeaPlaneLandingArea
                            var instance = new SeaplaneLandingArea() {
                            };

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.RESTRN != null) {
                                instance.restriction = EnumHelper.GetEnumValues<SeaplaneLandingArea, restriction>(current.RESTRN);
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.INFORM is not null && instance.restriction is not null && instance.restriction.Contains(restriction.SpeedRestricted)) {
                                instance.vesselSpeedLimit = ImporterNIS.GetVesselSpeedLimit(current.INFORM);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            ImporterNIS.SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));


                            //throw new NotImplementedException($"No SPLARE_SeaPlaneLandingArea in DK or GL. {tableName}");
                        }
                        break;
                    default:
                        // code block
                        System.Diagnostics.Debugger.Break();
                        break;
                }
            }
            Logger.Current.DataTotalCount(tableName, recordCount, ConversionAnalytics.Instance.GetConvertedCount(tableName));
        }
    }
}




