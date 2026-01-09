using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.AttributeModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_TracksAndRoutesL(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "TracksAndRoutesL";



            using var tracksAndRoutesL = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            Subtypes.Instance.RegisterSubtypes(tracksAndRoutesL);


            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("curve"));


            using var buffer = featureClass.CreateRowBuffer();

            using var cursor = tracksAndRoutesL.Search(filter, true);
            int recordCount = 0;

            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new TracksAndRoutesL(feature);

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

                switch (fcSubtype) {
                    case 1: { // DWRTCL_DeepWaterRouteCenterline
                            throw new NotImplementedException($"No DWRTCL_DeepWaterRouteCenterline in DK or GL. {tableName}");
                        }
                    case 5: { // FERYRT_FerryRoute
                            var instance = new FerryRoute();

                            if (current.CATFRY.HasValue) {
                                var categoryOfFerry = EnumHelper.GetEnumValues(current.CATFRY.Value);
                                if (categoryOfFerry is not null && categoryOfFerry.Any()) {
                                    instance.categoryOfFerry = categoryOfFerry[0];
                                    instance.categoryOfFerry_optional = categoryOfFerry[1..];
                                }
                            }

                            instance.featureName_optional = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange_optional = dateRange;
                            }

                            // TODO: interoperabilityIdentifier

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange_optional = periodicDateRange;
                            }

                            if (current.STATUS != default) {
                                instance.status_optional = GetStatus(current.STATUS);
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
                                relatedEquipment?.CreateRelatedLineEquipment(current, instance, featureN);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;
                    case 10: { // NAVLNE_NavigationLine
                            var instance = new NavigationLine();

                            if (current.CATNAV.HasValue) {
                                instance.categoryOfNavigationLine = EnumHelper.GetEnumValue(current.CATNAV.Value);
                            }

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange_optional = dateRange;
                            }

                            // TODO: interoperabilityIdentifier

                            // TODO: measured distance

                            if (current.ORIENT.HasValue) {
                                instance.orientation = new AttributeModel.S101.ComplexAttributes.orientation() {
                                    orientationValue = current.ORIENT.Value,
                                    // TODO: oriantationUncertainty
                                    //orientationUncertainty = ,
                                };
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange_optional = periodicDateRange;
                            }

                            if (current.STATUS != default) {
                                instance.status_optional = GetStatus(current.STATUS);
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
                                relatedEquipment?.CreateRelatedLineEquipment(current, instance, featureN);
                            }


                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;
                    case 15: { // RADLNE_RadarLine

                            throw new NotImplementedException($"No RADLNE_RadarLine in DK or GL. {tableName}");
                        }
                    case 20: { // RCRTCL_RecommendedRouteCenterline
                            var instance = new RecommendedRouteCentreline {
                            };

                            if (current.CATTRK.HasValue) {
                                if (current.CATTRK.Value == 1) {
                                    instance.basedOnFixedMarks = true;
                                }
                                else if (current.CATTRK.Value == 2) {
                                    instance.basedOnFixedMarks = false;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, tableName, longname, $"Cannot convert value {current.CATTRK.Value} to basedOnFixedMarks boolean. Only values 1 and 2 are supported.");
                                }
                            }

                            if (current.DRVAL1.HasValue && current.DRVAL1.Value != -32767d) {
                                instance.depthRangeMinimumValue_optional = current.DRVAL1.Value;
                            }

                            instance.featureName_optional = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange_optional = dateRange;
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.ORIENT.HasValue && current.ORIENT.Value != -32767d) {
                                instance.orientationValue_optional = current.ORIENT.Value;
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange_optional = periodicDateRange;
                            }

                            if (current.QUASOU != default) {
                                var qualityOfVerticalMeasurement = EnumHelper.GetEnumValues(current.QUASOU);
                                if (qualityOfVerticalMeasurement is not null && qualityOfVerticalMeasurement.Any())
                                    instance.qualityOfVerticalMeasurement_optional = qualityOfVerticalMeasurement;
                            }

                            if (current.STATUS != default) {
                                instance.status_optional = GetStatus(current.STATUS);
                            }

                            if (current.TECSOU != null) {
                                var techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues(current.TECSOU);
                                if (techniqueOfVerticalMeasurement is not null && techniqueOfVerticalMeasurement.Any())
                                    instance.techniqueOfVerticalMeasurement_optional = techniqueOfVerticalMeasurement;
                            }


                            if (current.TRAFIC.HasValue) {
                                instance.trafficFlow_optional = EnumHelper.GetEnumValue(current.TRAFIC.Value);
                            }

                            if (current.SOUACC.HasValue) {
                                instance.verticalUncertainty_optional = new() {
                                    uncertaintyFixed = current.SOUACC.Value
                                };
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
                                relatedEquipment?.CreateRelatedLineEquipment(current, instance, featureN);
                            }


                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;
                    case 25: { // RDOCAL_RadioCallingInPoint
                            var instance = new RadioCallingInPoint {
                            };

                            if (current.COMCHA != default) {
                                instance.communicationChannel_optional = GetCommunicationChannel(current.COMCHA);
                            }

                            instance.featureName_optional = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange_optional = dateRange;
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.ORIENT.HasValue && current.ORIENT.Value != -32767d) {
                                instance.orientationValue_optional = [current.ORIENT.Value];
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange_optional = periodicDateRange;
                            }

                            if (current.STATUS != default) {
                                instance.status_optional = GetStatus(current.STATUS);
                            }

                            if (current.TRAFIC.HasValue) {
                                instance.trafficFlow = EnumHelper.GetEnumValue(current.TRAFIC.Value);
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
                                relatedEquipment?.CreateRelatedLineEquipment(current, instance, featureN);
                            }


                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;
                    case 30: { // RECTRC_RecommendedTrack
                            var instance = new RecommendedTrack {
                            };

                            if (current.CATTRK.HasValue) {
                                if (current.CATTRK.Value == 1) {
                                    instance.basedOnFixedMarks = true;
                                }
                                else if (current.CATTRK.Value == 2) {
                                    instance.basedOnFixedMarks = false;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, tableName, longname, $"Cannot convert value {current.CATTRK.Value} to basedOnFixedMarks boolean. Only values 1 and 2 are supported.");
                                }
                            }

                            if (current.DRVAL1.HasValue) {
                                instance.depthRangeMinimumValue_optional = current.DRVAL1.Value;
                            }

                            instance.featureName_optional = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange_optional = dateRange;
                            }

                            // TODO: interoperabilityIdentifier

                            // TODO: maximumPermittedDraught

                            if (current.ORIENT.HasValue && current.ORIENT.Value != -32767d) {
                                instance.orientationValue = current.ORIENT.Value;
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange_optional = periodicDateRange;
                            }

                            if (current.QUASOU != default) {
                                var qualityOfVerticalMeasurement = EnumHelper.GetEnumValues(current.QUASOU);
                                if (qualityOfVerticalMeasurement is not null && qualityOfVerticalMeasurement.Any())
                                    instance.qualityOfVerticalMeasurement_optional = qualityOfVerticalMeasurement;
                            }

                            if (current.STATUS != default) {
                                instance.status_optional = GetStatus(current.STATUS);
                            }

                            if (current.TECSOU != null) {
                                var techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues(current.TECSOU);
                                if (techniqueOfVerticalMeasurement is not null && techniqueOfVerticalMeasurement.Any())
                                    instance.techniqueOfVerticalMeasurement_optional = techniqueOfVerticalMeasurement;
                            }

                            if (current.TRAFIC.HasValue) {
                                instance.trafficFlow = EnumHelper.GetEnumValue(current.TRAFIC.Value);
                            }

                            if (current.SOUACC.HasValue) {
                                instance.verticalUncertainty_optional = new() {
                                    uncertaintyFixed = current.SOUACC.Value
                                };
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
                                relatedEquipment?.CreateRelatedLineEquipment(current, instance, featureN);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;
                    case 40: { // TSELNE_TrafficSeparationLine
                            var instance = new SeparationZoneOrLine();

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange_optional = dateRange;
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.STATUS != default) {
                                instance.status_optional = GetStatus(current.STATUS);
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
                                relatedEquipment?.CreateRelatedLineEquipment(current, instance, featureN);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;
                    case 45: { // TSSBND_TrafficSeparationSchemeBoundary
                            var instance = new TrafficSeparationSchemeBoundary();

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange_optional = dateRange;
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.STATUS != default) {
                                instance.status_optional = GetStatus(current.STATUS);
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
                                relatedEquipment?.CreateRelatedLineEquipment(current, instance, featureN);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
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
