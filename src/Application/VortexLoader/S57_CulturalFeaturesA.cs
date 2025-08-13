using ArcGIS.Core.CIM;
using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;
using S100Framework.DomainModel.S101.FeatureTypes;
using System.ComponentModel;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_CulturalFeaturesA(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var createBridgesAndRelations = false;

            var tableName = "CulturalFeaturesA";

            using var culturalFeaturesA = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            Subtypes.Instance.RegisterSubtypes(culturalFeaturesA);

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("surface"));
            using var featureAssociation = target.OpenDataset<Table>(target.GetName("featureassociation"));

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            // Bridges
            if (createBridgesAndRelations) {
                Bridges.Initialize(source);


                foreach (var bridge in Bridges.Instance.BridgeElements()) {
                    var instance = new Bridge();

                    buffer["ps"] = ps101;
                    buffer["code"] = instance.GetType().Name;
                    buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                    SetShape(buffer, bridge.DissolvedGeometry);
                    SetUsageBand(buffer, ImporterNIS._compilationScale);

                    var featureN = featureClass.CreateRow(buffer);
                    var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                    bridge.Name = name;

                    // Create association to use in bridge relations
                    var featureAssociationBuffer = featureAssociation.CreateRowBuffer();

                    featureAssociationBuffer["ps"] = ImporterNIS.ps101;
                    featureAssociationBuffer["code"] = "BridgeAggregation";
                    var association = featureAssociation.CreateRow(featureAssociationBuffer);
                    string featureAssociationName = (string)association["name"];
                    bridge.BridgeAggregationName = featureAssociationName;
                }
            }

            using var cursor = culturalFeaturesA.Search(filter, true);
            int recordCount = 0;


            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new CulturalFeaturesA(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;

                if (ConversionAnalytics.Instance.IsConverted(globalid))
                    continue;

                var fcSubtype = current.FCSUBTYPE ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;
                var status = current.STATUS ?? default;

                switch (fcSubtype) {
                    case 1: { // AIRARE_AirportAirfield
                            var instance = new AirportAirfield();

                            if (current.CATAIR != default) {
                                instance.categoryOfAirportAirfield = EnumHelper.GetEnumValues<categoryOfAirportAirfield>(current.CATAIR);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            // TODO: interoperabilityIdentifier

                            if (current.SORDAT != default) {
                                if (DateHelper.regexTruncatedDateValidation.IsMatch(current.SORDAT)) {
                                    instance.reportedDate = current.SORDAT;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID.GetValueOrDefault(), tableName, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 5: { // BRIDGE_Bridge  // SPANS
                            //var instance = new Bridge();

                            BridgeElement relatedBridge = null;

                            if (createBridgesAndRelations) {
                                var relatedBridges = Bridges.Instance.GetBridgeElementsContainingOID(current.TableName!, current.OBJECTID!.Value);
                                if (relatedBridges.Count() != 1) {
                                    throw new NotSupportedException("Unsupported number bridge relations. Must be 1");
                                }
                                relatedBridge = relatedBridges[0];
                            }




                            bool openingBridge = false;
                            List<bridgeFunction> bridgeFunctionValue = new List<bridgeFunction>();
                            int? scaleMinimum = default;
                            List<colour> colours = new();
                            colourPattern? colourPatterns = default;
                            condition? conditionValue = default;
                            List<status> statusValue = new();
                            List<natureOfConstruction> natureOfConstructionValues = new();
                            var horclr = current.HORCLR ?? default;
                            var horacc = current.HORACC ?? default;

                            if (current.CATBRG != default && current.CATBRG == "1") {
                                openingBridge = false;
                            }
                            else if (current.CATBRG != default && current.CATBRG == "2") {
                                openingBridge = true;
                            }
                            else if (current.CATBRG != default && current.CATBRG == "3") {
                                openingBridge = true;
                            }
                            else if (current.CATBRG != default && current.CATBRG == "4") {
                                openingBridge = true;
                            }
                            else if (current.CATBRG != default && current.CATBRG == "5") {
                                openingBridge = true;
                            }
                            else if (current.CATBRG != default && current.CATBRG == "6") {
                                openingBridge = false;
                            }
                            else if (current.CATBRG != default && current.CATBRG == "7") {
                                openingBridge = true;
                            }
                            else if (current.CATBRG != default && current.CATBRG == "8") {
                                openingBridge = false;
                            }
                            else if (current.CATBRG != default && current.CATBRG == "9") {
                                openingBridge = false;
                                bridgeFunctionValue = new List<bridgeFunction>() { bridgeFunction.Pedestrian };
                            }
                            else if (current.CATBRG != default && current.CATBRG == "10") {
                                openingBridge = false;
                            }
                            else if (current.CATBRG != default && current.CATBRG == "11") {
                                openingBridge = false;
                                bridgeFunctionValue = new List<bridgeFunction>() { bridgeFunction.Aqueduct };
                            }
                            else if (current.CATBRG != default && current.CATBRG == "12") {
                                openingBridge = false;
                            }
                            else if (current.CATBRG != default && current.CATBRG == "-32767") {
                                openingBridge = false;
                                Logger.Current.DataError(objectid, tableName, longname, $"CATBRG is unknown hence OpeningBridge unknown - OpeningBridge set to false");
                            }



                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            if (current.COLOUR != default) {
                                colours = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                colourPatterns = GetColourPattern(current.COLPAT);
                            }

                            if (current.CONDTN.HasValue) {
                                conditionValue = GetCondition(current.CONDTN.Value);
                            }

                            if (current.STATUS != default) {
                                statusValue = GetStatus(current.STATUS);
                            }


                            if (current.NATCON != default) {
                                natureOfConstructionValues = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);


                            // Span
                            /*
                                For opening bridges/bridge spans the attribute VERCOP is only mandatory where there is a limited
                                vertical clearance when the bridge is open. Where VERCOP is not present for an opening
                                bridge/bridge span, the mandatory complex attribute vertical clearance open, mandatory subattribute vertical clearance unlimited will be populated as True during the automated conversion
                                process. Where VERCOP has a value or is populated with an empty (null) value, vertical clearance
                                unlimited will be populated as False.
                            */

                            

                            if (openingBridge) {
                                var instance = new SpanOpening() {
                                    verticalClearanceClosed = new verticalClearanceClosed() {
                                        verticalClearanceValue = current.VERCLR.HasValue && current.VERCLR.Value != -32767m ? current.VERCLR!.Value : default(decimal?)
                                    }
                                    ,
                                    verticalClearanceOpen = new verticalClearanceOpen() {
                                        verticalClearanceValue = current.VERCLR.HasValue && current.VERCLR.Value != -32767m ? current.VERCLR!.Value : default(decimal?),
                                        //Where VERCOP has a value or is populated with an empty (null) value, vertical clearance unlimited will be populated as False.
                                        verticalClearanceUnlimited = !current.VERCLR.HasValue || current.VERCLR.Value == default(decimal)
                                    }
                                };

                                instance.horizontalClearanceFixed = new horizontalClearanceFixed() {
                                    horizontalClearanceValue = current.HORCLR.HasValue && current.HORCLR.Value != -32767m ? current.HORCLR!.Value : default(decimal?),
                                    horizontalDistanceUncertainty = current.HORACC.HasValue && current.HORACC.Value != -32767m ? current.HORACC!.Value : default(decimal?),
                                };


                                DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                                if (dateRange != default) {
                                    instance.fixedDateRange = dateRange;
                                }

                                instance.verticalDatum = ImporterNIS.GetVerticalDatum(current.VERDAT ?? 23);


                                AddInformation(instance.information, feature);
                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                SetShape(buffer, current.SHAPE);
                                SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                                //if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                //    relatedEquipment!.CreateRelatedAreaEquipment(current, instance, featureN, instance.scaleMinimum);
                                //}
                                if (createBridgesAndRelations) {
                                    Bridges.Instance.AddRelation(relatedBridge.Name, name, typeof(SpanOpening));


                                    // Create link to bridge
                                    List<DomainModel.featureBinding> bindings = new List<DomainModel.featureBinding>();
                                    bindings.Add(new() {
                                        association = "BridgeAggregation",
                                        associationId = relatedBridge.BridgeAggregationName,
                                        featureId = relatedBridge.Name,
                                        role = "theCollection",
                                        roleType = "aggregation"
                                    });

                                    featureN["featurebindings"] = System.Text.Json.JsonSerializer.Serialize(bindings);
                                    featureN.Store();
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            }

                            if (!openingBridge) {
                                if (createBridgesAndRelations) {
                                    var relatedBridges = Bridges.Instance.GetBridgeElementsContainingOID(current.TableName!, current.OBJECTID!.Value);
                                    if (relatedBridges.Count() != 1) {
                                        throw new NotSupportedException("Unsupported number bridge relations. Must be 1");
                                    }
                                    relatedBridge = relatedBridges[0];
                                }

                                var instance = new SpanFixed() {
                                    verticalClearanceFixed = new verticalClearanceFixed() {
                                        verticalClearanceValue = current.VERCLR.HasValue && current.VERCLR.Value != -32767m ? current.VERCLR!.Value : default(decimal?),
                                    }
                                };

                                instance.horizontalClearanceFixed = new horizontalClearanceFixed() {
                                    horizontalClearanceValue = current.HORCLR.HasValue && current.HORCLR.Value != -32767m ? current.HORCLR!.Value : default(decimal?),
                                    horizontalDistanceUncertainty = current.HORACC.HasValue && current.HORACC.Value != -32767m ? current.HORACC!.Value : default(decimal?)
                                };

                                AddInformation(instance.information, feature);

                                if (current.PICREP != default) {
                                    instance.pictorialRepresentation = current.PICREP;
                                }

                                

                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                SetShape(buffer, current.SHAPE);
                                SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                                //if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                //    relatedEquipment!.CreateRelatedAreaEquipment(current, instance, featureN, instance.scaleMinimum);
                                //}
                                if (createBridgesAndRelations) {
                                    Bridges.Instance.AddRelation(relatedBridge!.Name, name, typeof(SpanFixed));
                                    // Create link to bridge
                                    List<DomainModel.featureBinding> bindings = new List<DomainModel.featureBinding>();
                                    bindings.Add(new() {
                                        association = "BridgeAggregation",
                                        associationId = relatedBridge.BridgeAggregationName,
                                        featureId = relatedBridge.Name,
                                        role = "theCollection",
                                        roleType = "aggregation"
                                    });

                                    featureN["featurebindings"] = System.Text.Json.JsonSerializer.Serialize(bindings);
                                    featureN.Store();

                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                            }

                        }
                        break;

                    case 10: { // BUAARE_BuiltUpArea
                            var instance = new BuiltUpArea();

                            if (current.CATBUA.HasValue) {
                                instance.categoryOfBuiltUpArea = EnumHelper.GetEnumValue<categoryOfBuiltUpArea>(current.CATBUA.Value);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);                            
                           if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767m) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(decimal?);
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.regexTruncatedDateValidation.IsMatch(current.SORDAT)) {
                                    instance.reportedDate = current.SORDAT;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID.GetValueOrDefault(), tableName, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            /*
                                S - 101 includes the system attribute in the water to indicate that a building that is located offshore is to
                                be included in ECDIS Base display.This attribute is populated automatically during the conversion
                                process based on the underlying Skin of the Earth feature.As such, there is no requirement to include
                                an ECDIS Base display feature coincident with the S - 101 Building feature so as to ensure display of a
                                feature at the position of the building in ECDIS Base display.Data Producers should consider removing
                                these features from their S-101 data during the conversion process.
                            */
                            // TODO: InTheWater

                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 15: { // BUISGL_BuildingSingle
                            var instance = new Building();

                            if (current.BUISHP != null) {
                                instance.buildingShape = EnumHelper.GetEnumValue<buildingShape>(current.BUISHP);
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            if (current.ELEVAT.HasValue) {
                                instance.elevation = current.ELEVAT.Value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.FUNCTN != default) {
                                instance.function = EnumHelper.GetEnumValues<function>(current.FUNCTN);
                            }                            
                           if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767m) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(decimal?);
                            }

                            // TODO: interoperabilityIdentifier

                            // TODO: multiplicity of features

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.regexTruncatedDateValidation.IsMatch(current.SORDAT)) {
                                    instance.reportedDate = current.SORDAT;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID.GetValueOrDefault(), tableName, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            // TODO: InTheWater

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 20: { // CONVYR_Conveyor
                            var instance = new Conveyor();

                            if (current.CATCON.HasValue) {
                                instance.categoryOfConveyor = EnumHelper.GetEnumValue<categoryOfConveyor>(current.CATCON.Value);
                            }
                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767m) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(decimal?);
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.LIFCAP.HasValue) {
                                instance.liftingCapacity = current.LIFCAP.Value;
                            }

                            //TODO: multiplicityOfFeatures

                            if (current.PRODCT != null) {
                                instance.product = EnumHelper.GetEnumValues<product>(current.PRODCT);
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.regexTruncatedDateValidation.IsMatch(current.SORDAT)) {
                                    instance.reportedDate = current.SORDAT;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID.GetValueOrDefault(), tableName, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            instance.verticalClearanceFixed = new() {
                                verticalUncertainty = new() {
                                    uncertaintyFixed = current.VERACC.HasValue && current.VERACC.Value != -32767m ? current.VERACC.Value : default(decimal?),
                                    uncertaintyVariableFactor = default(decimal?)
                                },
                                //verticalClearanceValue = current.VERCOP.HasValue && current.VERCOP.Value != -32767m ? current.VERCOP.Value : default(decimal?),
                                verticalClearanceValue = current.VERCLR.HasValue && current.VERCLR.Value != -32767m ? current.VERCLR.Value : default(decimal?),
                                
                            };

                            instance.verticalDatum = ImporterNIS.GetVerticalDatum(current.VERDAT ?? 3);

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 25: { // DAMCON_Dam
                            throw new NotImplementedException("DAMCON_Dam - CulturalFeaturesA");
                            //var instance = new Dam();

                            //if (current.CATDAM.HasValue) {
                            //    instance.categoryOfDam = EnumHelper.GetEnumValue<categoryOfDam>(current.CATDAM.Value);
                            //}

                            //if (current.COLOUR != default) {
                            //    instance.colour = GetColours(current.COLOUR);
                            //}

                            //if (current.COLPAT != default) {
                            //    instance.colourPattern = GetColourPattern(current.COLPAT);
                            //}

                            //if (current.CONDTN.HasValue) {
                            //    instance.condition = GetCondition(current.CONDTN.Value);
                            //}

                            //instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            //DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            //if (dateRange != default) {
                            //    instance.fixedDateRange = dateRange;
                            //}

                            //if (current.HEIGHT.HasValue) {
                            //    instance.height = current.HEIGHT.Value;
                            //}

                            //// TODO: interoperabilityIdentifier

                            //if (current.NATCON != default) {
                            //    instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            //}

                            //if (current.CONRAD.HasValue) {
                            //    instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            //}

                            //if (current.STATUS != default) {
                            //    instance.status = GetStatus(current.STATUS);
                            //}

                            //if (current.VERLEN.HasValue) {
                            //    instance.verticalLength = current.VERLEN.Value;
                            //}

                            //if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                            //    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                            //}

                            //if (current.WATLEV.HasValue) {
                            //    if (current.WATLEV.Value == -32767)
                            //        instance.waterLevelEffect = EnumHelper.GetEnumValue<waterLevelEffect>(-1);
                            //    else {
                            //        instance.waterLevelEffect = EnumHelper.GetEnumValue<waterLevelEffect>(current.WATLEV);
                            //    }
                            //}

                            //if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                            //    string subtype = "";

                            //    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                            //        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                            //    instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            //}

                            //AddInformation(instance.information, feature);

                            //buffer["ps"] = ps101;
                            //buffer["code"] = instance.GetType().Name;
                            //buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            //SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);
                            //var featureN = featureClass.CreateRow(buffer);
                            //var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            //if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                            //    relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            //}

                            //ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            //Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 30: { // FORSTC_FortifiedStructure
                            var instance = new FortifiedStructure();

                            if (current.CATFOR.HasValue) {
                                instance.categoryOfFortifiedStructure = EnumHelper.GetEnumValue<categoryOfFortifiedStructure>(current.CATFOR.Value);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);                            

                           if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767m) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(decimal?);
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.regexTruncatedDateValidation.IsMatch(current.SORDAT)) {
                                    instance.reportedDate = current.SORDAT;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID.GetValueOrDefault(), tableName, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }
                            
                            //TODO: inTheWater

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 35: { // LNDMRK_Landmark
                            if (current.CATLMK == "19") {
                                var windturbine = ImporterNIS._converterRegistry.Convert<WindTurbine>(current);

                                if (current.COLOUR != default) {
                                    windturbine.colour = GetColours(current.COLOUR);
                                }

                                if (current.COLPAT != default) {
                                    windturbine.colourPattern = GetColourPattern(current.COLPAT);
                                }

                                if (current.CONDTN.HasValue) {
                                    windturbine.condition = GetCondition(current.CONDTN.Value);
                                }

                                if (current.ELEVAT.HasValue) {
                                    windturbine.elevation = current.ELEVAT.Value;
                                }

                                windturbine.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                                DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                                if (dateRange != default) {
                                    windturbine.fixedDateRange = dateRange;
                                }

                                if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767m) {
                                    windturbine.height = current.HEIGHT.Value;
                                }
                                else {
                                    windturbine.height = default(decimal?);
                                }

                                // TODO: interoperabilityIdentifier

                                // TODO: multiplicityOfFeatures

                                if (current.NATCON != default) {
                                    windturbine.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                                }

                                if (current.CONRAD.HasValue) {
                                    windturbine.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                                }

                                if (current.SORDAT != default) {
                                    if (DateHelper.regexTruncatedDateValidation.IsMatch(current.SORDAT)) {
                                        windturbine.reportedDate = current.SORDAT;
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.GetValueOrDefault(), tableName, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                    }
                                }

                                if (current.STATUS != default) {
                                    windturbine.status = GetStatus(current.STATUS);
                                }


                                windturbine.verticalClearanceFixed = new() {
                                    verticalUncertainty = new() {
                                        uncertaintyFixed = current.VERACC.HasValue && current.VERACC.Value != -32767m ? current.VERACC.Value : default(decimal?),
                                        uncertaintyVariableFactor = default(decimal?)
                                    },
                                    //verticalClearanceValue = current.VERCOP.HasValue && current.VERCOP.Value != -32767m ? current.VERCOP.Value : default(decimal?),
                                    verticalClearanceValue = current.VERCLR.HasValue && current.VERCLR.Value != -32767m ? current.VERCLR.Value : default(decimal?),
                                };



                                if (current.VERLEN.HasValue) {
                                    windturbine.verticalLength = current.VERLEN.Value;

                                    // only set vertical datum if vertical length - 7cs err: 
                                    if (current.VERDAT.HasValue) {
                                        windturbine.verticalDatum = ImporterNIS.GetVerticalDatum(current.VERDAT ?? 3);
                                    }
                                }


                                if (current.CONVIS.HasValue) {
                                    windturbine.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }

                                if (current.WATLEV.HasValue) {
                                    windturbine.waterLevelEffect = EnumHelper.GetEnumValue<waterLevelEffect>(current.WATLEV);
                                }

                                if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                    string subtype = "";

                                    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                    windturbine.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                }

                                AddInformation(windturbine.information, feature);

                                if (current.PICREP != default) {
                                    windturbine.pictorialRepresentation = current.PICREP;
                                }

                                //TODO: inTheWater

                                buffer["ps"] = ps101;
                                buffer["code"] = windturbine.GetType().Name;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(windturbine, jsonSerializerOptions);
                                SetShape(buffer, current.SHAPE);
                                SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var windturbineFeature = featureClass.CreateRow(buffer);
                                var structureName = Convert.ToString(windturbineFeature["name"]);

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment?.CreateRelatedAreaEquipment(current, windturbine, windturbineFeature, windturbine.scaleMinimum);
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, structureName ?? "Unknown structure name");
                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(windturbine));
                                continue;
                            }

                            var instance = new Landmark {
                                visualProminence = default,
                            };

                            if (current.CATLMK != default) {
                                instance.categoryOfLandmark = EnumHelper.GetEnumValues<categoryOfLandmark>(current.CATLMK);
                            }

                            // TODO: CATSPM

                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            if (current.ELEVAT.HasValue) {
                                instance.elevation = current.ELEVAT.Value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.FUNCTN != null) {
                                instance.function = EnumHelper.GetEnumValues<function>(current.FUNCTN);
                            }                            
                           if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767m) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(decimal?);
                            }

                            // TODO: interoperabilityIdentifier

                            // TODO: multiplicityOfFeatures

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.regexTruncatedDateValidation.IsMatch(current.SORDAT)) {
                                    instance.reportedDate = current.SORDAT;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID.GetValueOrDefault(), tableName, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.CONVIS.HasValue) {
                                instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 40: { // PRDARE_ProductionStorageArea
                            var instance = new ProductionStorageArea {
                                categoryOfProductionArea = default,
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }


                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 45: { // PYLONS_PylonBridgeSupport

                            BridgeElement? relatedBridge = default;

                            if (createBridgesAndRelations) {
                                var relatedBridges = Bridges.Instance.GetBridgeElementsContainingOID(current.TableName!, current.OBJECTID!.Value);
                                if (relatedBridges.Count() != 1)
                                    throw new NotSupportedException("Multiple bridges share elements");

                                relatedBridge = relatedBridges[0];
                            }

                            var instance = new PylonBridgeSupport {
                                categoryOfPylon = default,
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            //FeatureRelations.Instance.AddRelation(new(typeof(Bridge), relatedBridge, new(instance.GetType(), name), featureN, s101MasterFeature, _featureAssociation);

                            //if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                            //    relatedEquipment!.CreateRelatedAreaEquipment(current, instance, featureN, instance.scaleMinimum);
                            //}

                            if (createBridgesAndRelations) {

                                Bridges.Instance.AddRelation(relatedBridge!.Name, name, typeof(PylonBridgeSupport));
                                // Create link to bridge
                                List<DomainModel.featureBinding> bindings = new List<DomainModel.featureBinding>();
                                bindings.Add(new() {
                                    association = "BridgeAggregation",
                                    associationId = relatedBridge.BridgeAggregationName,
                                    featureId = relatedBridge.Name,
                                    role = "theCollection",
                                    roleType = "aggregation"
                                });

                                featureN["featurebindings"] = System.Text.Json.JsonSerializer.Serialize(bindings);
                                featureN.Store();
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 50: { // ROADWY_Road
                            var instance = new Road() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 55: { // RUNWAY_Runway
                            var instance = new Runway() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 60: { // SILTNK_SiloTank
                            var instance = new SiloTank();

                            if (current.BUISHP.HasValue) {
                                instance.buildingShape = EnumHelper.GetEnumValue<buildingShape>(current.BUISHP.Value);
                            }

                            if (current.CATSIL.HasValue) {
                                instance.categoryOfSiloTank = EnumHelper.GetEnumValue<categoryOfSiloTank>(current.CATSIL.Value);
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            if (current.ELEVAT.HasValue) {
                                instance.elevation = current.ELEVAT.Value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value;
                            }

                            // TODO: interoperabilityIdentifier

                            // TODO: multiplicityOfFeatures

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PRODCT != null) {
                                instance.product = EnumHelper.GetEnumValues<product>(current.PRODCT);
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.regexTruncatedDateValidation.IsMatch(current.SORDAT)) {
                                    instance.reportedDate = current.SORDAT;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID.GetValueOrDefault(), tableName, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VERLEN.HasValue && current.VERLEN.Value != -32767m) {
                                instance.verticalLength = current.VERLEN.Value;
                            }
                            else {
                                instance.verticalLength = default(decimal?);
                            }

                            if (current.CONVIS.HasValue) {
                                instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }
                            
                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 65: { // TUNNEL_Tunnel
                            var instance = new Tunnel() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }


                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
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

            if (createBridgesAndRelations) {
                Bridges.Instance.CreateRelations();
            }

            Logger.Current.DataTotalCount(tableName, recordCount, ConversionAnalytics.Instance.GetConvertedCount(tableName));
        }
    }
}