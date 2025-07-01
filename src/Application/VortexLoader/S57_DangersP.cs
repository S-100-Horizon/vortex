using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;
using System.ComponentModel;


namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        


        private static void S57_DangersP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "DangersP";

            var dangersp = source.OpenDataset<FeatureClass>(source.GetName("DangersP"));
            var depthsA = source.OpenDataset<FeatureClass>(source.GetName("DepthsA"));

            //var dredged = source.OpenDataset<FeatureClass>("Depare");

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("point"));
            

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = dangersp.Search(filter, true);
            int recordCount = 0;
            int convertedCount = 0;
            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new DangersP(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;
                var subtype = current.FCSUBTYPE ?? default;

                var longname = current.LNAM ?? Strings.UNKNOWN;

                bool isValsouEmpty = !current.VALSOU.HasValue;

                // The attribute default clearance depth must be populated with a value, which must not be an empty(null)
                // value, only if the attribute value of sounding for the feature instance is populated with an empty(null) value
                // and the attribute height, if an allowable attribute for the feature, is not populated.
                // S-101 Annex A_DCEG Edition 1.5.0_Draft for Edition 2.0.0.pdf: p.771
                //Decimal defaultClearanceDepth = -1;

                switch (subtype) {
                    case 1: { // CTNARE
                            var instance = new CautionArea {

                            };


                            //if (current.PLTS_COMP_SCALE.HasValue) {
                            //    instance.scaleMinimum = current.PLTS_COMP_SCALE.Value;
                            //}

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            if (current.STATUS != default) {
                                instance.status = GetSingleStatus(current.STATUS);
                            }

                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            insert.Insert(buffer);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;

                    case 10: { // FSHFAC Fishing facilities
                            var instance = new FishingFacility {

                            };


                            //if (current.PLTS_COMP_SCALE.HasValue) {
                            //    instance.scaleMinimum = current.PLTS_COMP_SCALE.Value;
                            //}

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
                            SetShape(buffer,current.SHAPE);
                            insert.Insert(buffer);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;

                    case 20: { // OBSTRN
                            {
                                // Foul ground
                                if (current.CATOBS.HasValue && current.CATOBS.Value == 7) {
                                    var instance = new FoulGround();

                                    //foulGround.verticalUncertainty = 
                                    if (current.STATUS != default) {
                                        instance.status = GetStatus(current.STATUS);
                                    }

                                    if (current.VALSOU.HasValue) {
                                        instance.valueOfSounding = current.VALSOU.Value;
                                    }

                                    //if (current.PLTS_COMP_SCALE.HasValue)
                                        //instance.scaleMinimum = current.PLTS_COMP_SCALE;

                                    instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                                    AddInformation(instance.information, feature);
                                    buffer["ps"] = ps101;

                                    buffer["code"] = instance.GetType().Name;
                                    buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                                    ImporterNIS.SetShape(buffer, current.SHAPE);
                                    insert.Insert(buffer);
                                    Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                                    convertedCount++;
                                    break;
                                }
                            }
                            {
                                //CONDTN, EXPSOU, NATCON, NATQUA, NATSUR, PRODCT, VERLEN, WATLEV

                                /*
                                    OBSTRN of geometric primitive area or line with attribute INFORM = Submerged weir will be
                                    converted to an instance of the S-101 Feature type Dam (see clause 4.8.5). Where this is the case,
                                    the attributes CATOBS, EXPSOU, NATQUA, NATSUR, PRODCT, QUASOU, SOUACC, TECSOU
                                    and VALSOU will not be converted. It is considered that these attributes are not relevant for Dam in
                                    S-101. 
                                */


                                var instance = new Obstruction() {
                                    surroundingDepth = default,
                                    waterLevelEffect = default,
                                };

                                if (current.CATOBS.HasValue) {
                                    if (current.CATOBS.Value == -32767)
                                        instance.categoryOfObstruction = EnumHelper.GetEnumValue<categoryOfObstruction>(-1);
                                    else {

                                        instance.categoryOfObstruction = EnumHelper.GetEnumValue<categoryOfObstruction>(current.CATOBS.Value);
                                    }
                                }


                                if (current.CONDTN.HasValue) {
                                    instance.condition = GetCondition(current.CONDTN.Value);
                                }

                                if (current.EXPSOU.HasValue) {
                                    instance.expositionOfSounding = EnumHelper.GetEnumValue<expositionOfSounding>(current.EXPSOU.Value);
                                }

                                instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                                if (current.HEIGHT.HasValue) {
                                    instance.height = current.HEIGHT.Value;
                                }

                                // DODO: Interoperability identifier

                                // TODO: Maximum permitted draught

                                if (current.NATSUR != default) {
                                    instance.natureOfSurface = EnumHelper.GetEnumValues<natureOfSurface>(current.NATSUR);
                                }

                                if (current.PRODCT != default) {
                                    instance.product = EnumHelper.GetEnumValues<product>(current.PRODCT);
                                }

                                // TODO: QualityOfVerticalMeasurement

                                if (current.SORDAT != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.SORDAT, out var dateOnly)) {
                                        instance.reportedDate = current.SORDAT;
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.SORDAT}");
                                    }
                                }

                                if (current.STATUS != default) {
                                    instance.status = GetStatus(current.STATUS);
                                }

                                // TODO: techniqueOfVerticalMeasurement

                                if (current.VALSOU.HasValue) {
                                    instance.valueOfSounding = current.VALSOU.Value;
                                }

                                if (current.VERLEN.HasValue) {
                                    instance.verticalLength = current.VERLEN.Value;
                                }

                                if (current.WATLEV.HasValue) {
                                    if (current.WATLEV.Value == -32767)
                                        instance.waterLevelEffect = EnumHelper.GetEnumValue<waterLevelEffect>(-1);
                                    else {
                                        instance.waterLevelEffect = EnumHelper.GetEnumValue<waterLevelEffect>(current.WATLEV);
                                    }
                                }

                                //if (current.PLTS_COMP_SCALE.HasValue) {
                                //  instance.scaleMinimum = current.PLTS_COMP_SCALE;
                                //}

                                AddInformation(instance.information, feature);

                                // TODO: defaultClearanceDepth

                                if (current.SHAPE != null) {
                                    foreach (var depthArea in SelectIn<DepthsA>(current.SHAPE, depthsA, SpatialRelationship.Intersects, ImporterNIS.CompilationScale)) {
                                        var drval1 = depthArea.DRVAL1 ?? default;
                                        instance.surroundingDepth = drval1;
                                    }
                                }

                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                                SetShape(buffer,current.SHAPE);
                                insert.Insert(buffer);
                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                                convertedCount++;
                            }
                        }
                        break;
                        
                    case 35: { // UWTROC
                            // TODO: surrounding depth, valueofsounding

                            var instance = new UnderwaterAwashRock {
                                surroundingDepth = default,
                                valueOfSounding = default,
                                waterLevelEffect = waterLevelEffect.CoversAndUncovers                                
                            };

                            
                            if (current.SHAPE != null) {
                                foreach (var depthArea in SelectIn<DepthsA>(current.SHAPE, depthsA,SpatialRelationship.Intersects, 22000)) {
                                    var drval1 = depthArea.DRVAL1 ?? default;
                                    instance.surroundingDepth = drval1;
                                }
                            }

                            if (current.EXPSOU.HasValue) {
                                instance.expositionOfSounding = EnumHelper.GetEnumValue<expositionOfSounding>(current.EXPSOU.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            // TODO: interoperabilityidentifier

                            if (current.NATSUR != default) {
                                if (int.TryParse(current.NATSUR, out var value)) {
                                    instance.natureOfSurface = EnumHelper.GetEnumValue<natureOfSurface>(value);
                                }
                            }

                            if (current.QUASOU != default) {
                                instance.qualityOfVerticalMeasurement = EnumHelper.GetEnumValues<qualityOfVerticalMeasurement>(current.QUASOU);
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.TryConvertToDateOnly(current.SORDAT, out var dateOnly)) {
                                    instance.reportedDate = current.SORDAT;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetSingleStatus(current.STATUS);
                            }

                            if (current.TECSOU != default) {
                                instance.techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues<techniqueOfVerticalMeasurement>(current.TECSOU);
                            }

                            if (current.VALSOU.HasValue) {
                                instance.valueOfSounding = current.VALSOU.Value;
                            }

                            //      S57
                            //    Code Description
                            // 1   partly submerged at high water
                            // 2   always dry
                            // 3   always under water / submerged
                            // 4   covers and uncovers
                            // 5   awash
                            // 6   subject to inundation or flooding
                            // 7   floating
                            // -1  Unknown


                            if (current.WATLEV.HasValue) {
                                if (current.WATLEV.Value == -32767)
                                    instance.waterLevelEffect = EnumHelper.GetEnumValue<waterLevelEffect>(-1);
                                else {
                                    instance.waterLevelEffect = EnumHelper.GetEnumValue<waterLevelEffect>(current.WATLEV);
                                }
                            }

                            //if (current.PLTS_COMP_SCALE.HasValue) {
                            //    //instance.scaleMinimum = current.PLTS_COMP_SCALE;
                            //}

                            // TODO: defaultClearanceDepth

                            //instance.defaultClearanceDepth = current.

                            
                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            SetShape(buffer,current.SHAPE);
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                        }
                        break;

                    case 40: { // WATTUR
                            // TODO: no instances in NIS
                            // TODO: surrounding depth, valueofsounding
                            var instance = new WaterTurbulence {
                                categoryOfWaterTurbulence = default,
                            };

                            if (current.CATWAT.HasValue) {
                                if (current.CATWAT.Value == -32767)
                                    instance.categoryOfWaterTurbulence = EnumHelper.GetEnumValue<categoryOfWaterTurbulence>(-1);
                                else {
                                    instance.categoryOfWaterTurbulence = EnumHelper.GetEnumValue<categoryOfWaterTurbulence>(current.CATWAT);
                                }
                            }



                            //if (current.PLTS_COMP_SCALE.HasValue) {
                            //    //instance.scaleMinimum = current.PLTS_COMP_SCALE;
                            //}

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                        }
                        break;
                    case 45: { // WRECKS
                            waterLevelEffect waterLeveleffectCurrent = default;
                            var instance = new Wreck() {
                                surroundingDepth = default,
                                waterLevelEffect = default,
                            };

                            if (current.SHAPE != null) {
                                foreach (var depthArea in SelectIn<DepthsA>(current.SHAPE, depthsA, SpatialRelationship.Intersects, ImporterNIS.CompilationScale)) {
                                    var drval1 = depthArea.DRVAL1 ?? default;
                                    instance.surroundingDepth = drval1;
                                }
                            }

                            if (current.WATLEV.HasValue) {
                                if (current.WATLEV.Value == -32767)
                                    instance.waterLevelEffect = EnumHelper.GetEnumValue<waterLevelEffect>(-1);
                                else {
                                    instance.waterLevelEffect = EnumHelper.GetEnumValue<waterLevelEffect>(current.WATLEV);
                                }
                            }

                            if (current.CATWRK.HasValue) {
                                if (current.CATWRK.Value == -32767)
                                    instance.categoryOfWreck = EnumHelper.GetEnumValue<categoryOfWreck>(-1);
                                else {
                                    instance.categoryOfWreck = EnumHelper.GetEnumValue<categoryOfWreck>(current.CATWRK.Value);
                                }
                            }

                            if (current.VALSOU.HasValue) {
                                instance.valueOfSounding = current.VALSOU.Value;
                            }


                            //if (current.PLTS_COMP_SCALE.HasValue) {
                            //    instance.scaleMinimum = current.PLTS_COMP_SCALE.Value;
                            //}

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                        }

                        break;
                    default:
                        // code block
                        System.Diagnostics.Debugger.Break();
                        break;
                }

                

            }
            Logger.Current.DataTotalCount(tableName, recordCount, convertedCount);
        }

    }
}
