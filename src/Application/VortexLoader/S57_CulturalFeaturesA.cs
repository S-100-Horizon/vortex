using ArcGIS.Core.CIM;
using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;
using S100Framework.DomainModel.S101.FeatureTypes;
using System.ComponentModel;
using VortexLoader.Singletons;
using YamlDotNet.Serialization;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_CulturalFeaturesA(Geodatabase source, Geodatabase target, QueryFilter filter) {


            var tableName = "CulturalFeaturesA";

            using var culturalFeaturesA = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            Subtypes.Instance.RegisterSubtypes(culturalFeaturesA);

            using var surface = target.OpenDataset<FeatureClass>(target.GetName("surface"));
            using var featureAssociation = target.OpenDataset<Table>(target.GetName("featureassociation"));
            using var featureType = target.OpenDataset<Table>(target.GetName("featuretype"));

            using var bufferFeatureType = featureType.CreateRowBuffer();

            using var bufferSurface = surface.CreateRowBuffer();

            // Bridges - Store an aggregation per bridge
            if (createBridgesAndRelations) {
                Bridges.Initialize(source, target);

                foreach (var bridge in Bridges.Instance.BridgeElements()) {
                    var instance = new Bridge();

                    bufferFeatureType["ps"] = ps101;
                    bufferFeatureType["code"] = instance.GetType().Name;
                    bufferFeatureType["edition"] = ImporterNIS.s101version;
                    bufferFeatureType["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);

                    //SetShape(buffer, bridge.DissolvedGeometry);
                    //SetUsageBand(buffer, ImporterNIS._compilationScale);

                    var featureN = featureType.CreateRow(bufferFeatureType);
                    var name = $"{featureN.Crc32()}";

                    bridge.Name = name;

                    // Create association to use in bridge relations
                    var featureAssociationBuffer = featureAssociation.CreateRowBuffer();

                    featureAssociationBuffer["ps"] = ImporterNIS.ps101;
                    featureAssociationBuffer["code"] = "BridgeAggregation";
                    featureAssociationBuffer["edition"] = ImporterNIS.s101version;

                    var association = featureAssociation.CreateRow(featureAssociationBuffer);
                    string featureAssociationName = $"{association.Crc32()}";
                    bridge.BridgeAggregationName = featureAssociationName;

                    ConversionAnalytics.Instance.AddConverted("DerivedBridgeElement", Guid.Empty, name);

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

                                instance.categoryOfAirportAirfield = EnumHelper.GetEnumValues<AirportAirfield, categoryOfAirportAirfield>(current.CATAIR);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            // TODO: interoperabilityIdentifier

                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                                    instance.reportedDate = result;
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

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;
                            bufferSurface["edition"] = ImporterNIS.s101version;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = $"{featureN.Crc32()}";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
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
                            List<bridgeFunction> bridgeFunctionValue = new List<bridgeFunction>();
                            int? scaleMinimum = default;
                            //List<colour> colours = new();
                            //colourPattern? colourPatterns = default;
                            //condition? conditionValue = default;
                            //List<status> statusValue = new();
                            //List<natureOfConstruction> natureOfConstructionValues = new();
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
                                if (current.VERACC.HasValue && current.VERACC.Value != -32767d) {
                                    verticalUncertaintyValue = new verticalUncertainty() {
                                        uncertaintyFixed = current.VERACC.Value,
                                    };


                                    instance = new SpanOpening() {
                                        verticalClearanceClosed = new verticalClearanceClosed() {
                                            verticalClearanceValue = current.VERCCL.HasValue && current.VERCCL.Value != -32767d ? current.VERCCL!.Value : default(double?),
                                            verticalUncertainty = verticalUncertaintyValue,
                                        }
                                        ,
                                        verticalClearanceOpen = new verticalClearanceOpen() {
                                            verticalClearanceValue = current.VERCOP.HasValue && current.VERCOP.Value != -32767d ? current.VERCOP!.Value : default(double?),
                                            //Where VERCOP has a value or is populated with an empty (null) value, vertical clearance unlimited will be populated as False.
                                            verticalClearanceUnlimited = current.VERCOP.HasValue ? !(current.VERCOP!.Value == default(double)) : null
                                        }
                                    };
                                }
                                else {
                                    instance = new SpanOpening() {
                                        verticalClearanceClosed = new verticalClearanceClosed() {
                                            verticalClearanceValue = current.VERCCL.HasValue && current.VERCCL.Value != -32767d ? current.VERCCL!.Value : default(double?),
                                        }
                                        ,
                                        verticalClearanceOpen = new verticalClearanceOpen() {
                                            verticalClearanceValue = current.VERCOP.HasValue && current.VERCOP.Value != -32767d ? current.VERCOP!.Value : default(double?),
                                            //Where VERCOP has a value or is populated with an empty (null) value, vertical clearance unlimited will be populated as False.
                                            verticalClearanceUnlimited = current.VERCOP.HasValue ? !(current.VERCOP!.Value == default(double)) : null
                                        }
                                    };

                                }
                                instance.horizontalClearanceFixed = new horizontalClearanceFixed() {
                                    horizontalClearanceValue = current.HORCLR.HasValue && current.HORCLR.Value != -32767d ? current.HORCLR!.Value : default(double?),
                                    horizontalDistanceUncertainty = current.HORACC.HasValue && current.HORACC.Value != -32767d ? current.HORACC!.Value : default(double?),
                                };


                                DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                                if (dateRange != default) {
                                    instance.fixedDateRange = dateRange;
                                }

                                instance.verticalDatum = ImporterNIS.GetVerticalDatum<SpanOpening>(current.VERDAT ?? 3);

                                // Clear vdat if covered by a metadata object with same vdat
                                foreach (var elm in VerticalDatums.Instance.Touch(current.SHAPE!)) {
                                    if (elm.Item2 == instance.verticalDatum) {
                                        instance.verticalDatum = null;
                                    }
                                }

                                instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));
                                bufferSurface["ps"] = ps101;
                                bufferSurface["code"] = instance.GetType().Name;
                                bufferSurface["edition"] = ImporterNIS.s101version;
                                bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                SetShape(bufferSurface, current.SHAPE);
                                SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                                var featureN = surface.CreateRow(bufferSurface);
                                var name = $"{featureN.Crc32()}";


                                if (createBridgesAndRelations) {
                                    Bridges.Instance.AddRelation(relatedBridge!.Name, name, typeof(SpanOpening), current.OBJNAM, current.NOBJNM);

                                    // Create link to bridge - SpanOpening
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

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment!.CreateRelatedAreaEquipment(current, instance, featureN, instance.scaleMinimum);
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

                                SpanFixed instance = null!;

                                if (current.VERACC.HasValue && current.VERACC.Value != -32767d) {
                                    verticalUncertaintyValue = new verticalUncertainty() {
                                        uncertaintyFixed = current.VERACC.Value,
                                    };

                                    instance = new SpanFixed() {
                                        verticalClearanceFixed = new verticalClearanceFixed() {
                                            verticalClearanceValue = current.VERCLR.HasValue && current.VERCLR.Value != -32767d ? current.VERCLR!.Value : default(double?),
                                            verticalUncertainty = verticalUncertaintyValue
                                        }
                                    };
                                }
                                else {
                                    instance = new SpanFixed() {
                                        verticalClearanceFixed = new verticalClearanceFixed() {
                                            verticalClearanceValue = current.VERCLR.HasValue && current.VERCLR.Value != -32767d ? current.VERCLR!.Value : default(double?),
                                        }

                                    };

                                }

                                instance.horizontalClearanceFixed = new horizontalClearanceFixed() {
                                    horizontalClearanceValue = current.HORCLR.HasValue && current.HORCLR.Value != -32767d ? current.HORCLR!.Value : default(double?),
                                    horizontalDistanceUncertainty = current.HORACC.HasValue && current.HORACC.Value != -32767d ? current.HORACC!.Value : default(double?)
                                };

                                instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                                if (current.PICREP != default) {
                                    instance.pictorialRepresentation = FixFilename(current.PICREP);
                                }

                                instance.verticalDatum = ImporterNIS.GetVerticalDatum<SpanOpening>(current.VERDAT ?? 3);
                                // Clear vdat if covered by a metadata object with same vdat
                                foreach (var elm in VerticalDatums.Instance.Touch(current.SHAPE!)) {
                                    if (elm.Item2 == instance.verticalDatum) {
                                        instance.verticalDatum = null;
                                    }
                                }

                                bufferSurface["ps"] = ps101;
                                bufferSurface["code"] = instance.GetType().Name;
                                bufferSurface["edition"] = ImporterNIS.s101version;
                                bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                SetShape(bufferSurface, current.SHAPE);
                                SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                                var featureN = surface.CreateRow(bufferSurface);
                                var name = $"{featureN.Crc32()}";

                                if (createBridgesAndRelations) {
                                    Bridges.Instance.AddRelation(relatedBridge!.Name, name, typeof(SpanFixed), current.OBJNAM, current.NOBJNM);

                                    // Create link to bridge - Spanfixed
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

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment!.CreateRelatedAreaEquipment(current, instance, featureN, instance.scaleMinimum);
                                }


                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                            }

                        }
                        break;

                    case 10: { // BUAARE_BuiltUpArea
                            var instance = new BuiltUpArea();

                            if (current.CATBUA.HasValue) {
                                instance.categoryOfBuiltUpArea = EnumHelper.GetEnumValue<BuiltUpArea, categoryOfBuiltUpArea>(current.CATBUA.Value);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(double?);
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                                    instance.reportedDate = result;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                instance.visualProminence = EnumHelper.GetEnumValue<BuiltUpArea, visualProminence>(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

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
                            if (LandAreas.Instance.Touch(current!.SHAPE!).Count() > 0) {
                                instance.inTheWater = false;
                            }
                            else {
                                instance.inTheWater = true;
                            }

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;
                            bufferSurface["edition"] = ImporterNIS.s101version;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = $"{featureN.Crc32()}";

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
                                instance.buildingShape = EnumHelper.GetEnumValue<Building, buildingShape>(current.BUISHP);
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours<Building>(current.COLOUR);
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
                                instance.function = EnumHelper.GetEnumValues<Building, function>(current.FUNCTN);
                            }
                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(double?);
                            }

                            // TODO: interoperabilityIdentifier

                            // TODO: multiplicity of features

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<Building, natureOfConstruction>(current.NATCON);
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }
                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                                    instance.reportedDate = result;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                instance.visualProminence = EnumHelper.GetEnumValue<Conveyor, visualProminence>(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            if (LandAreas.Instance.Touch(current!.SHAPE!).Count() > 0) {
                                instance.inTheWater = false;
                            }
                            else {
                                instance.inTheWater = true;
                            }

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;
                            bufferSurface["edition"] = ImporterNIS.s101version;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = $"{featureN.Crc32()}";

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
                                instance.categoryOfConveyor = EnumHelper.GetEnumValue<Conveyor, categoryOfConveyor>(current.CATCON.Value);
                            }
                            if (current.COLOUR != default) {
                                instance.colour = GetColours<Conveyor>(current.COLOUR);
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

                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(double?);
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.LIFCAP.HasValue) {
                                instance.liftingCapacity = current.LIFCAP.Value;
                            }

                            //TODO: multiplicityOfFeatures

                            if (current.PRODCT != null) {
                                instance.product = EnumHelper.GetEnumValues<Conveyor, product>(current.PRODCT);
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }
                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                                    instance.reportedDate = result;
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
                                    uncertaintyFixed = current.VERACC.HasValue && current.VERACC.Value != -32767d ? current.VERACC.Value : default(double?),
                                    uncertaintyVariableFactor = default(double?)
                                },
                                //verticalClearanceValue = current.VERCOP.HasValue && current.VERCOP.Value != -32767d ? current.VERCOP.Value : default(double?),
                                verticalClearanceValue = current.VERCLR.HasValue && current.VERCLR.Value != -32767d ? current.VERCLR.Value : default(double?),

                            };

                            instance.verticalDatum = ImporterNIS.GetVerticalDatum<Conveyor>(current.VERDAT ?? 3);

                            foreach (var elm in VerticalDatums.Instance.Touch(current.SHAPE!)) {
                                if (elm.Item2 == instance.verticalDatum) {
                                    instance.verticalDatum = null;
                                }
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                instance.visualProminence = EnumHelper.GetEnumValue<Conveyor, visualProminence>(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;
                            bufferSurface["edition"] = ImporterNIS.s101version;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = $"{featureN.Crc32()}";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 25: { // DAMCON_Dam
                            throw new NotImplementedException("DAMCON_Dam - CulturalFeaturesA");
                        }
                    case 30: { // FORSTC_FortifiedStructure
                            var instance = new FortifiedStructure();

                            if (current.CATFOR.HasValue) {
                                instance.categoryOfFortifiedStructure = EnumHelper.GetEnumValue<FortifiedStructure, categoryOfFortifiedStructure>(current.CATFOR.Value);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(double?);
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<FortifiedStructure, natureOfConstruction>(current.NATCON);
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                                    instance.reportedDate = result;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                instance.visualProminence = EnumHelper.GetEnumValue<FortifiedStructure, visualProminence>(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            if (LandAreas.Instance.Touch(current!.SHAPE!).Count() > 0) {
                                instance.inTheWater = false;
                            }
                            else {
                                instance.inTheWater = true;
                            }



                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;
                            bufferSurface["edition"] = ImporterNIS.s101version;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = $"{featureN.Crc32()}";

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

                                bufferSurface["ps"] = ps101;
                                bufferSurface["code"] = windturbine.GetType().Name;
                                bufferSurface["edition"] = ImporterNIS.s101version;
                                bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(windturbine, jsonSerializerOptions);
                                SetShape(bufferSurface, current.SHAPE);
                                SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                                var windturbineFeature = surface.CreateRow(bufferSurface);

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment?.CreateRelatedAreaEquipment(current, windturbine, windturbineFeature, windturbine.scaleMinimum);
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, $"{windturbineFeature.Crc32()}" ?? "Unknown structure name");
                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(windturbine));
                                continue;
                            }

                            var instance = new Landmark {
                                visualProminence = default,
                            };

                            if (current.CATLMK != default) {
                                instance.categoryOfLandmark = EnumHelper.GetEnumValues<Landmark, categoryOfLandmark>(current.CATLMK);
                            }

                            // TODO: CATSPM

                            if (current.COLOUR != default) {
                                instance.colour = GetColours<Landmark>(current.COLOUR);
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
                                instance.function = EnumHelper.GetEnumValues<Landmark, function>(current.FUNCTN);
                            }

                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(double?);
                            }

                            // TODO: interoperabilityIdentifier

                            // TODO: multiplicityOfFeatures

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<Landmark, natureOfConstruction>(current.NATCON);
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }
                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                                    instance.reportedDate = result;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.CONVIS.HasValue) {
                                instance.visualProminence = EnumHelper.GetEnumValue<Landmark, visualProminence>(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            if (LandAreas.Instance.Touch(current!.SHAPE!).Count() > 0) {
                                instance.inTheWater = false;
                            }
                            else {
                                instance.inTheWater = true;
                            }


                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;
                            bufferSurface["edition"] = ImporterNIS.s101version;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = $"{featureN.Crc32()}";

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

                            if (current.CATPRA.HasValue) {
                                instance.categoryOfProductionArea = EnumHelper.GetEnumValue<ProductionStorageArea, categoryOfProductionArea>(current.CATPRA.Value);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            if (current.ELEVAT.HasValue) {
                                instance.elevation = current.ELEVAT.Value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(double?);
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.PRODCT != null) {
                                instance.product = EnumHelper.GetEnumValues<ProductionStorageArea, product>(current.PRODCT);
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }
                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                                    instance.reportedDate = result;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VERLEN.HasValue && current.VERLEN.Value != -32767d) {
                                instance.verticalLength = current.VERLEN.Value;
                            }
                            else {
                                instance.verticalLength = default(double?);
                            }

                            if (current.CONVIS.HasValue) {
                                instance.visualProminence = EnumHelper.GetEnumValue<ProductionStorageArea, visualProminence>(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;
                            bufferSurface["edition"] = ImporterNIS.s101version;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = $"{featureN.Crc32()}";

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

                            if (current.CATPYL.HasValue) {
                                instance.categoryOfPylon = EnumHelper.GetEnumValue<PylonBridgeSupport, categoryOfPylon>(current.CATPYL.Value);
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours<PylonBridgeSupport>(current.COLOUR);
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

                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(double?);
                            }

                            // TODO: interoperabilityIdentifier

                            // TODO: multiplicityOfFeatures

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<PylonBridgeSupport, natureOfConstruction>(current.NATCON);
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }
                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                                    instance.reportedDate = result;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VERLEN.HasValue && current.VERLEN.Value != -32767d) {
                                instance.verticalLength = current.VERLEN.Value;
                            }
                            else {
                                instance.verticalLength = default(double?);
                            }

                            if (current.CONVIS.HasValue) {
                                instance.visualProminence = EnumHelper.GetEnumValue<PylonBridgeSupport, visualProminence>(current.CONVIS.Value);
                            }

                            if (current.WATLEV.HasValue) {
                                instance.waterLevelEffect = EnumHelper.GetEnumValue<PylonBridgeSupport, waterLevelEffect>(current.WATLEV);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;
                            bufferSurface["edition"] = ImporterNIS.s101version;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = $"{featureN.Crc32()}";

                            if (createBridgesAndRelations) {

                                Bridges.Instance.AddRelation(relatedBridge!.Name, name, typeof(PylonBridgeSupport), current.OBJNAM, current.NOBJNM);

                                // Create link to bridge - PylonBridgeSupport
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

                            //FeatureRelations.Instance.AddRelation(new(typeof(Bridge), relatedBridge, new(instance.GetType(), name), featureN, s101MasterFeature, _featureAssociation);
                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedAreaEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 50: { // ROADWY_Road
                            var instance = new Road();

                            if (current.CATROD.HasValue) {
                                instance.categoryOfRoad = EnumHelper.GetEnumValue<Road, categoryOfRoad>(current.CATROD.Value);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            // TODO: interoperabilityIdentifier

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<Road, natureOfConstruction>(current.NATCON);
                            }
                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                                    instance.reportedDate = result;
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
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;
                            bufferSurface["edition"] = ImporterNIS.s101version;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = $"{featureN.Crc32()}";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 55: { // RUNWAY_Runway
                            var instance = new Runway();

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            // TODO: interoperabilityIdentifier

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<Runway, natureOfConstruction>(current.NATCON);
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }
                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                                    instance.reportedDate = result;
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
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;
                            bufferSurface["edition"] = ImporterNIS.s101version;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = $"{featureN.Crc32()}";

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
                                instance.buildingShape = EnumHelper.GetEnumValue<SiloTank, buildingShape>(current.BUISHP.Value);
                            }

                            if (current.CATSIL.HasValue) {
                                instance.categoryOfSiloTank = EnumHelper.GetEnumValue<SiloTank, categoryOfSiloTank>(current.CATSIL.Value);
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours<SiloTank>(current.COLOUR);
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
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<SiloTank, natureOfConstruction>(current.NATCON);
                            }

                            if (current.PRODCT != null) {
                                instance.product = EnumHelper.GetEnumValues<SiloTank, product>(current.PRODCT);
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }
                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                                    instance.reportedDate = result;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VERLEN.HasValue && current.VERLEN.Value != -32767d) {
                                instance.verticalLength = current.VERLEN.Value;
                            }
                            else {
                                instance.verticalLength = default(double?);
                            }

                            if (current.CONVIS.HasValue) {
                                instance.visualProminence = EnumHelper.GetEnumValue<SiloTank, visualProminence>(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;
                            bufferSurface["edition"] = ImporterNIS.s101version;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = $"{featureN.Crc32()}";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 65: { // TUNNEL_Tunnel
                            var instance = new Tunnel();

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            instance.horizontalClearanceFixed = new horizontalClearanceFixed() {
                                horizontalClearanceValue = current.HORCLR.HasValue && current.HORCLR.Value != -32767d ? current.HORCLR!.Value : default(double?),
                                horizontalDistanceUncertainty = current.HORACC.HasValue && current.HORACC.Value != -32767d ? current.HORACC!.Value : default(double?),
                            };

                            // TODO: interoperabilityIdentifier

                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                                    instance.reportedDate = result;
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
                                    uncertaintyFixed = current.VERACC.HasValue && current.VERACC.Value != -32767d ? current.VERACC.Value : default(double?),
                                    uncertaintyVariableFactor = default(double?)
                                },
                                //verticalClearanceValue = default(double?)
                                //verticalClearanceValue = current.VERCOP.HasValue && current.VERCOP.Value != -32767d ? current.VERCOP.Value : default(double?),
                                //verticalClearanceValue = current.VERCLR.HasValue && current.VERCLR.Value != -32767d ? current.VERCLR.Value : default(double?),
                                verticalClearanceValue = current.VERCCL.HasValue && current.VERCCL.Value != -32767d ? current.VERCCL.Value : default(double?),
                            };


                            instance.verticalDatum = ImporterNIS.GetVerticalDatum<Tunnel>(current.VERDAT ?? 3);

                            // Clear vdat if covered by a metadata object with same vdat
                            foreach (var elm in VerticalDatums.Instance.Touch(current.SHAPE!)) {
                                if (elm.Item2 == instance.verticalDatum) {
                                    instance.verticalDatum = null;
                                }
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;
                            bufferSurface["edition"] = ImporterNIS.s101version;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = surface.CreateRow(bufferSurface);
                            var name = $"{featureN.Crc32()}";

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