using ArcGIS.Core.Data;
using S100FC;
using S100FC.S101.ComplexAttributes;
using S100FC.S101.FeatureAssociation;
using S100FC.S101.FeatureTypes;
using S100FC.S101.SimpleAttributes;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_CulturalFeaturesA(Geodatabase source, Geodatabase target, QueryFilter filter) {


            var tableName = "CulturalFeaturesA";

            using var culturalFeaturesA = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            Subtypes.Instance.RegisterSubtypes(culturalFeaturesA);

            using var surface = target.OpenDataset<FeatureClass>(target.GetName("surface"));
            using var featureType = target.OpenDataset<Table>(target.GetName("featuretype"));

            using var buffer = featureType.CreateRowBuffer();

            using var bufferSurface = surface.CreateRowBuffer();

            // Bridges - Store an aggregation per bridge
            if (createBridgesAndRelations) {
                Bridges.Initialize(source, target);

                foreach (var bridge in Bridges.Instance.BridgeElements()) {
                    var instance = new Bridge();


                    buffer["ps"] = ps101;
                    buffer["code"] = instance.GetType().Name;


                    buffer["flatten"] = instance.Flatten();

                    //SetShape(buffer, bridge.DissolvedGeometry);
                    //SetUsageBand(buffer, ImporterNIS._compilationScale);

                    var featureN = featureType.CreateRow(buffer);
                    var name = featureN.UID();

                    bridge.Name = name;

                    //// Create association to use in bridge relations
                    //var featureAssociationBuffer = featureAssociation.CreateRowBuffer();

                    //featureAssociationBuffer["ps"] = ImporterNIS.ps101;
                    //featureAssociationBuffer["code"] = "BridgeAggregation";
                    //featureAssociation

                    //var association = featureAssociation.CreateRow(featureAssociationBuffer);
                    //string featureAssociationName = association.Crc32();
                    //bridge.BridgeAggregationName = featureAssociationName;

                    //ConversionAnalytics.Instance.AddConverted("DerivedBridgeElement", Guid.Empty, name);

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
                    case 1: { // AIRARE_AirportAirfield
                            var instance = new AirportAirfield();

                            if (current.CATAIR != default) {
                                var categoryOfAirportAirfield = EnumHelper.GetEnumValues(current.CATAIR);
                                if (categoryOfAirportAirfield is not null && categoryOfAirportAirfield.Any())
                                    instance.categoryOfAirportAirfield = categoryOfAirportAirfield;
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            // TODO: interoperabilityIdentifier

                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                    instance.reportedDate = reportedDate;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
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

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;


                            bufferSurface["flatten"] = instance.Flatten();
                            bufferSurface["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                        }
                        break;

                    case 5: { // BRIDGE_Bridge  // SPANS
                              //var instance = new Bridge();

                            BridgeElement relatedBridge = null!;

                            if (createBridgesAndRelations) {
                                var relatedBridges = Bridges.Instance.GetBridgeElementsContainingOID(current.TableName!, current.OBJECTID!.Value);
                                if (relatedBridges.Count() != 1) {
                                    throw new NotSupportedException("Unsupported number bridge relations. Must be 1");
                                }
                                relatedBridge = relatedBridges[0];
                            }

                            bool openingBridge = false;
                            List<bridgeFunction> bridgeFunctionValue = [];
                            int? scaleMinimum = default;
                            //List<colour> colours = new();
                            //colourPattern? colourPatterns = default;
                            //condition? conditionValue = default;
                            //List<status> statusValue = new();
                            //List<natureOfConstruction> natureOfConstructionValues = new();
                            var horclr = current.HORCLR ?? default;
                            var horacc = current.HORACC ?? default;

                            if ((current.CATBRG != default && current.CATBRG!.Contains(","))) {
                                Logger.Current.DataError(current.OBJECTID ?? -1, current.TableName, current.LNAM, "Bridge with multiple categories not supported. To be implemented.");
                                continue;
                            }




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
                                bridgeFunctionValue = [3,   /*bridgeFunction.Pedestrian*/];
                            }
                            else if (current.CATBRG != default && current.CATBRG == "10") {
                                openingBridge = false;
                            }
                            else if (current.CATBRG != default && current.CATBRG == "11") {
                                openingBridge = false;
                                bridgeFunctionValue = [4,   /*bridgeFunction.Aqueduct*/];
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

                                scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
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

                            verticalUncertainty verticalUncertaintyValue = null!;

                            if (openingBridge) {
                                SpanOpening instance = null!;
                                if (current.VERACC.HasValue) {
                                    verticalUncertaintyValue = new verticalUncertainty() {
                                        uncertaintyFixed = current.VERACC.Value != -32767m ? current.VERACC.Value : null,
                                    };


                                    instance = new SpanOpening() {
                                        verticalClearanceClosed = new verticalClearanceClosed() {
                                            verticalClearanceValue = current.VERCCL.HasValue && current.VERCCL.Value != -32767m ? current.VERCCL!.Value : default(decimal?),
                                            verticalUncertainty = verticalUncertaintyValue,
                                        }
                                        ,
                                        verticalClearanceOpen = new verticalClearanceOpen() {
                                            verticalClearanceValue = current.VERCOP.HasValue && current.VERCOP.Value != -32767m ? current.VERCOP!.Value : default(decimal?),
                                            //Where VERCOP has a value or is populated with an empty (null) value, vertical clearance unlimited will be populated as False.
                                            verticalClearanceUnlimited = current.VERCOP.HasValue ? !(current.VERCOP!.Value == default(decimal)) : default
                                        }
                                    };
                                }
                                else {
                                    instance = new SpanOpening() {
                                        verticalClearanceClosed = new verticalClearanceClosed() {
                                            verticalClearanceValue = current.VERCCL.HasValue && current.VERCCL.Value != -32767m ? current.VERCCL!.Value : default(decimal?),
                                        }
                                        ,
                                        verticalClearanceOpen = new verticalClearanceOpen() {
                                            verticalClearanceValue = current.VERCOP.HasValue && current.VERCOP.Value != -32767m ? current.VERCOP!.Value : default(decimal?),
                                            //Where VERCOP has a value or is populated with an empty (null) value, vertical clearance unlimited will be populated as False.
                                            verticalClearanceUnlimited = current.VERCOP.HasValue ? !(current.VERCOP!.Value == default(decimal)) : default
                                        }
                                    };

                                }
                                instance.horizontalClearanceFixed = new horizontalClearanceFixed() {
                                    horizontalClearanceValue = current.HORCLR.HasValue && current.HORCLR.Value != -32767m ? current.HORCLR!.Value : default(decimal?),
                                    horizontalDistanceUncertainty = current.HORACC.HasValue && current.HORACC.Value != -32767m ? current.HORACC!.Value : default(decimal?),
                                };


                                DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                                if (dateRange != default) {
                                    instance.fixedDateRange = dateRange;
                                }

                                var verticalDatum = ImporterNIS.GetVerticalDatum(current.VERDAT);
                                if (verticalDatum != null) {
                                    var update = true;
                                    foreach (var elm in VerticalDatums.Instance.Touch(current.SHAPE!)) {
                                        if (elm.Item2.value == verticalDatum.value) {
                                            update = false;
                                        }
                                    }
                                    if (update)
                                        instance.verticalDatum = verticalDatum.value;
                                }

                                var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                                instance.information = result.information.ToArray();
                                instance.SetInformationBindings(result.InformationBindings.ToArray());

                                bufferSurface["ps"] = ps101;
                                bufferSurface["code"] = instance.GetType().Name;


                                bufferSurface["flatten"] = instance.Flatten();
                                bufferSurface["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);


                                SetShape(bufferSurface, current.SHAPE);
                                SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                                var featureN = surface.CreateRow(bufferSurface);
                                var name = featureN.UID();


                                if (createBridgesAndRelations) {
                                    Bridges.Instance.AddRelation(relatedBridge!.Name, name, typeof(SpanOpening), current.OBJNAM, current.NOBJNM);

                                    // Create link to bridge - SpanOpening
                                    featureBinding[] bindings = [new featureBinding<BridgeAggregation> {
                                        role = "theCollection",
                                        roleType = "aggregation",
                                        featureId = relatedBridge.Name,
                                        featureType = nameof(Bridge),
                                    }];

                                    featureN["featurebindings"] = System.Text.Json.JsonSerializer.Serialize(bindings, ImporterNIS.jsonSerializerOptions);
                                    featureN.Store();
                                }

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment!.CreateRelatedAreaEquipment(current, instance, featureN, instance.scaleMinimum);
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                            }

                            if (!openingBridge) {
                                if (createBridgesAndRelations) {
                                    var relatedBridges = Bridges.Instance.GetBridgeElementsContainingOID(current.TableName!, current.OBJECTID!.Value);
                                    if (relatedBridges.Count() != 1) {
                                        throw new NotSupportedException("Unsupported number bridge relations. Must be 1");
                                    }
                                    relatedBridge = relatedBridges[0];
                                }

                                SpanFixed instance = null!;

                                if (current.VERACC.HasValue) {
                                    verticalUncertaintyValue = new verticalUncertainty() {
                                        uncertaintyFixed = current.VERACC.Value != -32767m ? current.VERACC.Value : null,
                                    };

                                    instance = new SpanFixed() {
                                        verticalClearanceFixed = new verticalClearanceFixed() {
                                            verticalClearanceValue = current.VERCLR.HasValue && current.VERCLR.Value != -32767m ? current.VERCLR!.Value : null,
                                            verticalUncertainty = verticalUncertaintyValue
                                        }
                                    };
                                }
                                else {
                                    instance = new SpanFixed() {
                                        verticalClearanceFixed = new verticalClearanceFixed() {
                                            verticalClearanceValue = current.VERCLR.HasValue && current.VERCLR.Value != -32767m ? current.VERCLR!.Value : null,
                                        }

                                    };

                                }

                                instance.horizontalClearanceFixed = new horizontalClearanceFixed() {
                                    horizontalClearanceValue = current.HORCLR.HasValue && current.HORCLR.Value != -32767m ? current.HORCLR!.Value : default(decimal?),
                                    horizontalDistanceUncertainty = current.HORACC.HasValue && current.HORACC.Value != -32767m ? current.HORACC!.Value : default(decimal?)
                                };

                                var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                                instance.information = result.information.ToArray();
                                instance.SetInformationBindings(result.InformationBindings.ToArray());

                                if (current.PICREP != default) {
                                    instance.pictorialRepresentation = FixFilename(current.PICREP);
                                }

                                var verticalDatum = ImporterNIS.GetVerticalDatum(current.VERDAT);
                                if (verticalDatum != null) {
                                    var update = true;
                                    foreach (var elm in VerticalDatums.Instance.Touch(current.SHAPE!)) {
                                        if (elm.Item2.value == verticalDatum.value) {
                                            update = false;
                                        }
                                    }
                                    if (update)
                                        instance.verticalDatum = verticalDatum.value;
                                }

                                bufferSurface["ps"] = ps101;
                                bufferSurface["code"] = instance.GetType().Name;


                                bufferSurface["flatten"] = instance.Flatten();
                                bufferSurface["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);


                                SetShape(bufferSurface, current.SHAPE);
                                SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                                var featureN = surface.CreateRow(bufferSurface);
                                var name = featureN.UID();

                                if (createBridgesAndRelations) {
                                    Bridges.Instance.AddRelation(relatedBridge!.Name, name, typeof(SpanFixed), current.OBJNAM, current.NOBJNM);

                                    // Create link to bridge - Spanfixed
                                    featureBinding[] bindings = [new featureBinding<BridgeAggregation> {
                                        role = "theCollection",
                                        roleType = "aggregation",
                                        featureId = relatedBridge.Name,
                                        featureType = nameof(Bridge),
                                    }];

                                    featureN["featurebindings"] = System.Text.Json.JsonSerializer.Serialize(bindings, ImporterNIS.jsonSerializerOptions);
                                    featureN.Store();

                                }

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment!.CreateRelatedAreaEquipment(current, instance, featureN, instance.scaleMinimum);
                                }


                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

                            }

                        }
                        break;

                    case 10: { // BUAARE_BuiltUpArea
                            var instance = new BuiltUpArea();

                            if (current.CATBUA.HasValue) {
                                instance.categoryOfBuiltUpArea = EnumHelper.GetEnumValue(current.CATBUA.Value);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value != -32767m ? current.HEIGHT.Value : null;
                            }
                            else {

                            }

                            // TODO: interoperabilityIdentifier

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                    instance.reportedDate = reportedDate;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.CONVIS.HasValue /*&& current.CONVIS.Value != -32767*/) {
                                instance.visualProminence = EnumHelper.GetEnumValue(current.CONVIS.Value);
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

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            /*
                                S - 101 includes the system attribute in the water to indicate that a building that is located offshore is to
                                be included in ECDIS Base display.This attribute is populated automatically during the conversion
                                process based on the underlying Skin of the Earth feature.As such, there is no requirement to include
                                an ECDIS Base display feature coincident with the S - 101 Building feature so as to ensure display of a
                                feature at the position of the building in ECDIS Base display.Data Producers should consider removing
                                these features from their S-101 data during the conversion process.
                            */
                            instance.inTheWater = !LandAreas.Instance.Touch(current!.SHAPE!).Any();

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;


                            bufferSurface["flatten"] = instance.Flatten();
                            bufferSurface["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = featureN.UID();

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                        }
                        break;

                    case 15: { // BUISGL_BuildingSingle
                            var instance = new Building();

                            if (current.BUISHP != null) {
                                instance.buildingShape = EnumHelper.GetEnumValue(current.BUISHP);
                            }

                            if (current.COLOUR != default) {
                                var colour = GetColours(current.COLOUR);
                                if (colour is not null && colour.Any())
                                    instance.colour = colour;
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT)!.value;
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            if (current.ELEVAT.HasValue) {
                                instance.elevation = current.ELEVAT.Value;
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            if (current.FUNCTN != default) {
                                var function = EnumHelper.GetEnumValues(current.FUNCTN);
                                if (function is not null && function.Any())
                                    instance.function = function;
                            }
                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value != -32767m ? current.HEIGHT.Value : null;
                            }
                            else {

                            }

                            // TODO: interoperabilityIdentifier

                            // TODO: multiplicity of features

                            if (current.NATCON != default) {
                                var natureOfConstruction = EnumHelper.GetEnumValues(current.NATCON);
                                if (natureOfConstruction is not null && natureOfConstruction.Any())
                                    instance.natureOfConstruction = natureOfConstruction;
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }
                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                    instance.reportedDate = reportedDate;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value != -32767m ? current.VERLEN.Value : null;
                            }

                            if (current.CONVIS.HasValue /*&& current.CONVIS.Value != -32767*/) {
                                instance.visualProminence = EnumHelper.GetEnumValue(current.CONVIS.Value);
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

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            instance.inTheWater = !LandAreas.Instance.Touch(current!.SHAPE!).Any();

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;


                            bufferSurface["flatten"] = instance.Flatten();
                            bufferSurface["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                        }
                        break;

                    case 20: { // CONVYR_Conveyor
                            var instance = new Conveyor();

                            if (current.CATCON.HasValue) {
                                instance.categoryOfConveyor = EnumHelper.GetEnumValue(current.CATCON.Value);
                            }
                            if (current.COLOUR != default) {
                                var colour = GetColours(current.COLOUR);
                                if (colour is not null && colour.Any())
                                    instance.colour = colour;
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT)!.value;
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value != -32767m ? current.HEIGHT.Value : null;
                            }
                            else {

                            }

                            // TODO: interoperabilityIdentifier

                            if (current.LIFCAP.HasValue) {
                                instance.liftingCapacity = current.LIFCAP.Value;
                            }

                            //TODO: multiplicityOfFeatures

                            if (current.PRODCT != null) {
                                var product = EnumHelper.GetEnumValues(current.PRODCT);
                                if (product is not null && product.Any())
                                    instance.product = product;
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }
                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                    instance.reportedDate = reportedDate;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
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

                            var verticalDatum = ImporterNIS.GetVerticalDatum(current.VERDAT);
                            if (verticalDatum != null) {
                                var update = true;
                                foreach (var elm in VerticalDatums.Instance.Touch(current.SHAPE!)) {
                                    if (elm.Item2.value == verticalDatum.value) {
                                        update = false;
                                    }
                                }
                                if (update)
                                    instance.verticalDatum = verticalDatum.value;
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value != -32767m ? current.VERLEN.Value : null;
                            }

                            if (current.CONVIS.HasValue /*&& current.CONVIS.Value != -32767*/) {
                                instance.visualProminence = EnumHelper.GetEnumValue(current.CONVIS.Value);
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

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;


                            bufferSurface["flatten"] = instance.Flatten();
                            bufferSurface["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                        }
                        break;

                    case 25: { // DAMCON_Dam
                            var instance = new Dam();

                            if (current.CATDAM.HasValue) {
                                instance.categoryOfDam = EnumHelper.GetEnumValue(current.CATDAM.Value);
                            }

                            if (current.COLOUR != default) {
                                var colour = GetColours(current.COLOUR);
                                if (colour is not null && colour.Any())
                                    instance.colour = colour;
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT)!.value;
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }
                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value != -32767m ? current.HEIGHT.Value : null;
                            }
                            else {

                            }

                            // TODO: interoperabilityIdentifier

                            if (current.NATCON != default) {
                                var natureOfConstruction = EnumHelper.GetEnumValues(current.NATCON);
                                if (natureOfConstruction is not null && natureOfConstruction.Any())
                                    instance.natureOfConstruction = natureOfConstruction;
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }


                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value != -32767m ? current.VERLEN.Value : null;
                            }
                            else {
                                //instance.verticalLength = default(decimal?);
                            }

                            if (current.CONVIS.HasValue /*&& current.CONVIS.Value != -32767*/) {
                                instance.visualProminence = EnumHelper.GetEnumValue(current.CONVIS.Value);
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

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;


                            bufferSurface["flatten"] = instance.Flatten();
                            bufferSurface["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                        }
                        break;
                    case 30: { // FORSTC_FortifiedStructure
                            var instance = new FortifiedStructure();

                            if (current.CATFOR.HasValue) {
                                instance.categoryOfFortifiedStructure = EnumHelper.GetEnumValue(current.CATFOR.Value);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value != -32767m ? current.HEIGHT.Value : null;
                            }
                            else {

                            }

                            // TODO: interoperabilityIdentifier

                            if (current.NATCON != default) {
                                var natureOfConstruction = EnumHelper.GetEnumValues(current.NATCON);
                                if (natureOfConstruction is not null && natureOfConstruction.Any())
                                    instance.natureOfConstruction = natureOfConstruction;
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                    instance.reportedDate = reportedDate;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value != -32767m ? current.VERLEN.Value : null;
                            }

                            if (current.CONVIS.HasValue /*&& current.CONVIS.Value != -32767*/) {
                                instance.visualProminence = EnumHelper.GetEnumValue(current.CONVIS.Value);
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

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            instance.inTheWater = !LandAreas.Instance.Touch(current!.SHAPE!).Any();



                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;


                            bufferSurface["flatten"] = instance.Flatten();
                            bufferSurface["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions));
                        }
                        break;

                    case 35: { // LNDMRK_Landmark
                            if (current.CATLMK == "19") {
                                var windturbine = ImporterNIS._converterRegistry.Convert<WindTurbine>(current);

                                bufferSurface["ps"] = ps101;
                                bufferSurface["code"] = windturbine.GetType().Name;

                                System.Text.Json.JsonSerializer.Serialize(windturbine, jsonSerializerOptions);
                                bufferSurface["flatten"] = windturbine.Flatten();
                                bufferSurface["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(windturbine.GetInformationBindings(), jsonSerializerOptions);

                                SetShape(bufferSurface, current.SHAPE);
                                SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                                var windturbineFeature = surface.CreateRow(bufferSurface);

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment?.CreateRelatedAreaEquipment(current, windturbine, windturbineFeature, windturbine.scaleMinimum);
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, windturbineFeature.UID() ?? "Unknown structure name");
                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(windturbine, jsonSerializerOptions));
                                continue;
                            }

                            var instance = new Landmark {
                                visualProminence = default,
                            };

                            if (current.CATLMK != default) {
                                var categoryOfLandmark = EnumHelper.GetEnumValues(current.CATLMK);
                                if (categoryOfLandmark is not null)
                                    instance.categoryOfLandmark = categoryOfLandmark;
                            }

                            // TODO: CATSPM

                            if (current.COLOUR != default) {
                                var colour = GetColours(current.COLOUR);
                                if (colour is not null && colour.Any())
                                    instance.colour = colour;
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT)!.value;
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            if (current.ELEVAT.HasValue) {
                                instance.elevation = current.ELEVAT.Value;
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            if (current.FUNCTN != null) {
                                var function = EnumHelper.GetEnumValues(current.FUNCTN);
                                if (function is not null && function.Any())
                                    instance.function = function;
                            }

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value != -32767m ? current.HEIGHT.Value : null;
                            }
                            else {

                            }

                            // TODO: interoperabilityIdentifier

                            // TODO: multiplicityOfFeatures

                            if (current.NATCON != default) {
                                var natureOfConstruction = EnumHelper.GetEnumValues(current.NATCON);
                                if (natureOfConstruction is not null && natureOfConstruction.Any())
                                    instance.natureOfConstruction = natureOfConstruction;
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }
                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                    instance.reportedDate = reportedDate;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value != -32767m ? current.VERLEN.Value : null;
                            }

                            if (current.CONVIS.HasValue) {
                                instance.visualProminence = EnumHelper.GetEnumValue(current.CONVIS.Value);
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

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            instance.inTheWater = !LandAreas.Instance.Touch(current!.SHAPE!).Any();


                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;


                            bufferSurface["flatten"] = instance.Flatten();
                            bufferSurface["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                        }
                        break;

                    case 40: { // PRDARE_ProductionStorageArea
                            var instance = new ProductionStorageArea {
                                categoryOfProductionArea = default,
                            };

                            if (current.CATPRA.HasValue) {
                                instance.categoryOfProductionArea = EnumHelper.GetEnumValue(current.CATPRA.Value);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            if (current.ELEVAT.HasValue) {
                                instance.elevation = current.ELEVAT.Value;
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value != -32767m ? current.HEIGHT.Value : null;
                            }
                            else {

                            }

                            // TODO: interoperabilityIdentifier

                            if (current.PRODCT != null) {
                                var product = EnumHelper.GetEnumValues(current.PRODCT);
                                if (product is not null && product.Any())
                                    instance.product = product;
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }
                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                    instance.reportedDate = reportedDate;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value != -32767m ? current.VERLEN.Value : null;
                            }
                            else {
                                //instance.verticalLength = default(decimal?);
                            }

                            if (current.CONVIS.HasValue) {
                                instance.visualProminence = EnumHelper.GetEnumValue(current.CONVIS.Value);
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

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;


                            bufferSurface["flatten"] = instance.Flatten();
                            bufferSurface["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
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

                            if (current.CATPYL.HasValue) {
                                instance.categoryOfPylon = EnumHelper.GetEnumValue(current.CATPYL.Value);
                            }

                            if (current.COLOUR != default) {
                                var colour = GetColours(current.COLOUR);
                                if (colour is not null && colour.Any())
                                    instance.colour = colour;
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT)!.value;
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value != -32767m ? current.HEIGHT.Value : null;
                            }
                            else {

                            }

                            // TODO: interoperabilityIdentifier

                            // TODO: multiplicityOfFeatures

                            if (current.NATCON != default) {
                                var natureOfConstruction = EnumHelper.GetEnumValues(current.NATCON);
                                if (natureOfConstruction is not null && natureOfConstruction.Any())
                                    instance.natureOfConstruction = natureOfConstruction;
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }
                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                    instance.reportedDate = reportedDate;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value != -32767m ? current.VERLEN.Value : null;
                            }
                            else {
                                //instance.verticalLength = default(decimal?);
                            }

                            if (current.CONVIS.HasValue) {
                                instance.visualProminence = EnumHelper.GetEnumValue(current.CONVIS.Value);
                            }

                            if (current.WATLEV.HasValue) {
                                instance.waterLevelEffect = EnumHelper.GetEnumValue(current.WATLEV);
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

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;


                            bufferSurface["flatten"] = instance.Flatten();
                            bufferSurface["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = featureN.UID();

                            if (createBridgesAndRelations) {

                                Bridges.Instance.AddRelation(relatedBridge!.Name, name, typeof(PylonBridgeSupport), current.OBJNAM, current.NOBJNM);

                                // Create link to bridge - PylonBridgeSupport
                                featureBinding[] bindings = [new featureBinding<BridgeAggregation> {
                                        role = "theCollection",
                                        roleType = "aggregation",
                                        featureId = relatedBridge.Name,
                                        featureType = nameof(Bridge),
                                    }];

                                featureN["featurebindings"] = System.Text.Json.JsonSerializer.Serialize(bindings, ImporterNIS.jsonSerializerOptions);
                                featureN.Store();

                            }

                            //FeatureRelations.Instance.AddRelation(new(typeof(Bridge), relatedBridge, new(instance.GetType(), name), featureN, s101MasterFeature, _featureAssociation);
                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedAreaEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                        }
                        break;

                    case 50: { // ROADWY_Road
                            var instance = new Road();

                            if (current.CATROD.HasValue) {
                                instance.categoryOfRoad = EnumHelper.GetEnumValue(current.CATROD.Value);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            // TODO: interoperabilityIdentifier

                            if (current.NATCON != default) {
                                var natureOfConstruction = EnumHelper.GetEnumValues(current.NATCON);
                                if (natureOfConstruction is not null && natureOfConstruction.Any())
                                    instance.natureOfConstruction = natureOfConstruction;
                            }
                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                    instance.reportedDate = reportedDate;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
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

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;


                            bufferSurface["flatten"] = instance.Flatten();
                            bufferSurface["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                        }
                        break;

                    case 55: { // RUNWAY_Runway
                            var instance = new Runway();

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            // TODO: interoperabilityIdentifier

                            if (current.NATCON != default) {
                                var natureOfConstruction = EnumHelper.GetEnumValues(current.NATCON);
                                if (natureOfConstruction is not null && natureOfConstruction.Any())
                                    instance.natureOfConstruction = natureOfConstruction;
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }
                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                    instance.reportedDate = reportedDate;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
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

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;


                            bufferSurface["flatten"] = instance.Flatten();
                            bufferSurface["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                        }
                        break;

                    case 60: { // SILTNK_SiloTank
                            var instance = new SiloTank();

                            if (current.BUISHP.HasValue) {
                                instance.buildingShape = EnumHelper.GetEnumValue(current.BUISHP.Value);
                            }

                            if (current.CATSIL.HasValue) {
                                instance.categoryOfSiloTank = EnumHelper.GetEnumValue(current.CATSIL.Value);
                            }

                            if (current.COLOUR != default) {
                                var colour = GetColours(current.COLOUR);
                                if (colour is not null && colour.Any())
                                    instance.colour = colour;
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT)!.value;
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            if (current.ELEVAT.HasValue) {
                                instance.elevation = current.ELEVAT.Value;
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value != -32767m ? current.HEIGHT.Value : null;
                            }

                            // TODO: interoperabilityIdentifier

                            // TODO: multiplicityOfFeatures

                            if (current.NATCON != default) {
                                var natureOfConstruction = EnumHelper.GetEnumValues(current.NATCON);
                                if (natureOfConstruction is not null && natureOfConstruction.Any())
                                    instance.natureOfConstruction = natureOfConstruction;
                            }

                            if (current.PRODCT != null) {
                                var product = EnumHelper.GetEnumValues(current.PRODCT);
                                if (product is not null && product.Any())
                                    instance.product = product;
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }
                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                    instance.reportedDate = reportedDate;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value != -32767m ? current.VERLEN.Value : null;
                            }
                            else {
                                //instance.verticalLength = default(decimal?);
                            }

                            if (current.CONVIS.HasValue) {
                                instance.visualProminence = EnumHelper.GetEnumValue(current.CONVIS.Value);
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

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;


                            bufferSurface["flatten"] = instance.Flatten();
                            bufferSurface["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                        }
                        break;

                    case 65: { // TUNNEL_Tunnel
                            var instance = new Tunnel();

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            instance.horizontalClearanceFixed = new horizontalClearanceFixed() {
                                horizontalClearanceValue = current.HORCLR.HasValue && current.HORCLR.Value != -32767m ? current.HORCLR!.Value : default(decimal?),
                                horizontalDistanceUncertainty = current.HORACC.HasValue && current.HORACC.Value != -32767m ? current.HORACC!.Value : default(decimal?),
                            };

                            // TODO: interoperabilityIdentifier

                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                    instance.reportedDate = reportedDate;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
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
                                //verticalClearanceValue = default(decimal?)
                                //verticalClearanceValue = current.VERCOP.HasValue && current.VERCOP.Value != -32767m ? current.VERCOP.Value : default(decimal?),
                                //verticalClearanceValue = current.VERCLR.HasValue && current.VERCLR.Value != -32767m ? current.VERCLR.Value : default(decimal?),
                                verticalClearanceValue = current.VERCCL.HasValue && current.VERCCL.Value != -32767m ? current.VERCCL.Value : default(decimal?),
                            };


                            var verticalDatum = ImporterNIS.GetVerticalDatum(current.VERDAT);
                            if (verticalDatum != null) {
                                var update = true;
                                foreach (var elm in VerticalDatums.Instance.Touch(current.SHAPE!)) {
                                    if (elm.Item2.value == verticalDatum.value) {
                                        update = false;
                                    }
                                }
                                if (update)
                                    instance.verticalDatum = verticalDatum.value;
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

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;


                            bufferSurface["flatten"] = instance.Flatten();
                            bufferSurface["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
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