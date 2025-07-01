using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;
using S100Framework.DomainModel.S101.FeatureTypes;



namespace S100Framework.Applications
{
    internal static partial class ImporterNIS {



        private static void S57_AidsToNavigationP(Geodatabase source, Geodatabase target, QueryFilter filter) {


            var tableName = "AidsToNavigationP";

            var aidstonavigation = source.OpenDataset<FeatureClass>(source.GetName(tableName));

            var featureAssociation = target.OpenDataset<Table>(target.GetName("featureassociation"));
            var informationAssociation = target.OpenDataset<Table>(target.GetName("informationassociation"));

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("point"));

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var featureAssociationBuffer = featureAssociation.CreateRowBuffer();
            using var featureAssociationInsert = featureAssociation.CreateInsertCursor();
            using var informationAssociationBuffer = informationAssociation.CreateRowBuffer();
            using var informationAssociationInsert = informationAssociation.CreateInsertCursor();

            using var cursor = aidstonavigation.Search(filter, true);
            int recordCount = 0;
            int convertedCount = 0;
            
            while (cursor.MoveNext()) {
                recordCount += 1;
                var feature = (Feature)cursor.Current;
                var current = new AidsToNavigationP(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;
                var subtype = current.FCSUBTYPE ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;

                if (featureRelations.IsSlave(globalid)) {
                    continue;
                }

                switch (subtype) {
                    case 1: { // BCNCAR_BeaconCardinal
                            var instance = new CardinalBeacon() {
                                beaconShape = default,
                                categoryOfCardinalMark = default,
                            };
                            
                            #region aidstonavigation
                            if (current.BCNSHP.HasValue) {
                                if (current.BCNSHP.Value == -32767)
                                    instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>(-1);
                                else {
                                    instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>(current.BCNSHP);
                                }
                            }

                            if (current.CATCAM.HasValue) {
                                if (current.CATCAM.Value == -32767)
                                    instance.categoryOfCardinalMark = EnumHelper.GetEnumValue<categoryOfCardinalMark>(-1);
                                else {
                                    instance.categoryOfCardinalMark = EnumHelper.GetEnumValue<categoryOfCardinalMark>(current.CATCAM.Value);
                                }
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

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value;
                            }

                            


                            // TODO: interoperabilityidentifier

                            if (current.MARSYS != null) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = current.PERSTA,
                                                    dateEnd = current.PEREND
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }
                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
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
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;
                            
                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;
                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}
                            var topmark = relatedEquipment.GetTopMark(current);
                            instance.topmark = topmark;

                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(-1);
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);

                            //insert.Insert(buffer);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relation

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID());
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                            #endregion aidstonavigation
                            #region related

                            relatedEquipment.CreateRelatedEquipment(current, name, target);

                            #endregion related
                        }
                        break;
                    case 5: { // BCNISD_BeaconIsolatedDanger
                            var instance = new IsolatedDangerBeacon() {
                                beaconShape = default,                                
                            };

                            #region aidstonavigation
                            if (current.BCNSHP.HasValue) {
                                if (current.BCNSHP.Value == -32767)
                                    instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>(-1);
                                else {
                                    instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>(current.BCNSHP);
                                }
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

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.MARSYS != null) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }


                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = current.PERSTA,
                                                    dateEnd = current.PEREND
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
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
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;
                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}
                            var topmark = relatedEquipment.GetTopMark(current);
                            instance.topmark = topmark;


                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(-1);
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            //insert.Insert(buffer);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relation

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID());
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                            #endregion aidstonavigation
                            #region related

                            relatedEquipment.CreateRelatedEquipment(current, name, target);

                            #endregion related
                        }
                        break;
                    case 10: { // BCNLAT_BeaconLateral
                            var instance = new LateralBeacon() {
                                beaconShape = default,
                                categoryOfLateralMark = default,
                            };

                            #region aidstonavigation
                            if (current.BCNSHP.HasValue) {
                                if (current.BCNSHP.Value == -32767)
                                    instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>(-1);
                                else {
                                    instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>(current.BCNSHP);
                                }
                            }

                            if (current.CATLAM.HasValue) {
                                if (current.CATLAM.Value == -32767)
                                    instance.categoryOfLateralMark = EnumHelper.GetEnumValue<categoryOfLateralMark>(-1);
                                else {
                                    instance.categoryOfLateralMark = EnumHelper.GetEnumValue<categoryOfLateralMark>(current.CATLAM.Value);
                                }
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

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            if (current.HEIGHT.HasValue) { 
                                instance.height = current.HEIGHT.Value;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.MARSYS != null) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = current.PERSTA,
                                                    dateEnd = current.PEREND
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
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
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}

                            var topmark = relatedEquipment.GetTopMark(current);
                            instance.topmark = topmark;

                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(-1);
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;


                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            //insert.Insert(buffer);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relation

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID());
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                            #endregion aidstonavigation
                            #region related

                            relatedEquipment.CreateRelatedEquipment(current, name, target);

                            #endregion related
                        }
                        break;
                    case 15: { // BCNSAW_BeaconSafeWater
                            var instance = new SafeWaterBeacon() {
                                beaconShape = default,
                            };

                            #region aidstonavigation
                            if (current.BCNSHP.HasValue) {
                                if (current.BCNSHP.Value == -32767)
                                    instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>(-1);
                                else {
                                    instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>(current.BCNSHP);
                                }
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

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.MARSYS != null) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = current.PERSTA,
                                                    dateEnd = current.PEREND
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
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
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;
                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}

                            var topmark = relatedEquipment.GetTopMark(current);
                            instance.topmark = topmark;


                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(-1);
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);

                            //insert.Insert(buffer);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relation

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID());
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                            #endregion aidstonavigation
                            #region related

                            relatedEquipment.CreateRelatedEquipment(current, name, target);

                            #endregion related
                        }
                        break;
                    case 20: { // BCNSPP_BeaconSpecialPurpose
                            var instance = new SpecialPurposeGeneralBeacon() {
                                beaconShape = default,
                            };

                            #region aidstonavigation
                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            if (current.BCNSHP.HasValue) {
                                if (current.BCNSHP.Value == -32767)
                                    instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>(-1);
                                else {
                                    instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>(current.BCNSHP);
                                }
                            }

                            if (current.CATSPM != default) {
                                if (current.CATSPM == "-32767")
                                    instance.categoryOfSpecialPurposeMark = EnumHelper.GetEnumValues<categoryOfSpecialPurposeMark>(-1);
                                else {
                                    instance.categoryOfSpecialPurposeMark = EnumHelper.GetEnumValues<categoryOfSpecialPurposeMark>(current.CATSPM);
                                }
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
                            
                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.MARSYS != null) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = current.PERSTA,
                                                    dateEnd = current.PEREND
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
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
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}

                            var topmark = relatedEquipment.GetTopMark(current);
                            instance.topmark = topmark;


                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(-1);
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            //insert.Insert(buffer);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relation

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID());
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                            #endregion aidstonavigation
                            #region related

                            relatedEquipment.CreateRelatedEquipment(current, name, target);

                            #endregion related
                        }
                        break;
                    case 25: { // BOYCAR_BuoyCardinal
                            var instance = new CardinalBuoy() {
                                buoyShape = default,
                                categoryOfCardinalMark = default,
                            };

                            #region aidstonavigation

                            if (current.BOYSHP.HasValue) {
                                if (current.BOYSHP.Value == -32767)
                                    instance.buoyShape = EnumHelper.GetEnumValue<buoyShape>(-1);
                                else {
                                    instance.buoyShape = EnumHelper.GetEnumValue<buoyShape>(current.BOYSHP);
                                }
                            }

                            if (current.CATCAM.HasValue) {
                                if (current.CATCAM.Value == -32767)
                                    instance.categoryOfCardinalMark = EnumHelper.GetEnumValue<categoryOfCardinalMark>(-1);
                                else {
                                    instance.categoryOfCardinalMark = EnumHelper.GetEnumValue<categoryOfCardinalMark>(current.CATCAM.Value);
                                }
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.MARSYS != null) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = current.PERSTA,
                                                    dateEnd = current.PEREND
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;



                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}
                            var topmark = relatedEquipment.GetTopMark(current);
                            instance.topmark = topmark;


                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            //insert.Insert(buffer);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relation

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID());
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                            #endregion aidstonavigation
                            #region related

                            relatedEquipment.CreateRelatedEquipment(current, name, target);

                            #endregion related
                        }
                        break;
                    case 30: { // BOYINB_BuoyInstallation
                            var instance = new InstallationBuoy() {
                                buoyShape = default,
                            };
                            #region aidstonavigation
                            if (current.BOYSHP.HasValue) {
                                if (current.BOYSHP.Value == -32767)
                                    instance.buoyShape = EnumHelper.GetEnumValue<buoyShape>("-1");
                                else {
                                    instance.buoyShape = EnumHelper.GetEnumValue<buoyShape>(current.BOYSHP);
                                }
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }


                            // TODO: interoperabilityidentifier


                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = current.PERSTA,
                                                    dateEnd = current.PEREND
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}

                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(-1);
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;


                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            //insert.Insert(buffer);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relation

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID());
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                            #endregion aidstonavigation
                            #region related

                            relatedEquipment.CreateRelatedEquipment(current, name, target);

                            #endregion related
                        }
                        break;
                    case 35: { // BOYISD_BuoyIsolatedDanger
                            var instance = new IsolatedDangerBuoy() {
                                buoyShape = default,
                            };

                            #region aidstonavigation
                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.MARSYS != null) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = current.PERSTA,
                                                    dateEnd = current.PEREND
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;
                            var topmark = relatedEquipment.GetTopMark(current);
                            instance.topmark = topmark;

                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;


                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            //insert.Insert(buffer);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relation

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID());
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                            #endregion aidstonavigation
                            #region related

                            relatedEquipment.CreateRelatedEquipment(current, name, target);

                            #endregion related

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}
                        }
                        break;
                    case 40: { // BOYLAT_BuoyLateral
                            var instance = new LateralBuoy() {
                                buoyShape = default,
                                categoryOfLateralMark = default,                                
                            };

                            #region aidstonavigation

                            if (current.BOYSHP.HasValue) {
                                if (current.BOYSHP.Value == -32767)
                                    instance.buoyShape = EnumHelper.GetEnumValue<buoyShape>(-1);
                                else {
                                    instance.buoyShape = EnumHelper.GetEnumValue<buoyShape>(current.BOYSHP);
                                }
                            }

                            if (current.CATLAM.HasValue) {
                                if (current.CATLAM.Value == -32767)
                                    instance.categoryOfLateralMark = EnumHelper.GetEnumValue<categoryOfLateralMark>(-1);
                                else {
                                    instance.categoryOfLateralMark = EnumHelper.GetEnumValue<categoryOfLateralMark>(current.CATLAM.Value);
                                }
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.MARSYS != null) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = current.PERSTA,
                                                    dateEnd = current.PEREND
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;

                            var topmark = relatedEquipment.GetTopMark(current);
                            instance.topmark = topmark;


                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);
                            instance.pictorialRepresentation = current.PICREP;


                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            //insert.Insert(buffer);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relation

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID());
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                            #endregion aidstonavigation
                            #region related

                            relatedEquipment.CreateRelatedEquipment(current, name, target);

                            #endregion related

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}

                        }
                        break;
                    case 45: { // BOYSAW_BuoySafeWater
                            var instance = new SafeWaterBuoy() {
                                buoyShape = default,
                            };

                            #region aidstonavigation
                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }


                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.MARSYS != null) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = current.PERSTA,
                                                    dateEnd = current.PEREND
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}

                            var topmark = relatedEquipment.GetTopMark(current);
                            instance.topmark = topmark;


                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;



                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            //insert.Insert(buffer);


                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relation

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID());
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                            #endregion aidstonavigation
                            #region related

                            relatedEquipment.CreateRelatedEquipment(current, name, target);

                            #endregion related

                        }
                        break;
                    case 50: { // BOYSPP_BuoySpecialPurpose
                            var instance = new SpecialPurposeGeneralBuoy() {
                                buoyShape = default,
                            };

                            #region aidstonavigation
                            if (current.COLOUR != default) {
                                instance.colour = EnumHelper.GetEnumValues<colour>(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }


                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            
                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.MARSYS != null) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = current.PERSTA,
                                                    dateEnd = current.PEREND
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}

                            var topmark = relatedEquipment.GetTopMark(current);
                            instance.topmark = topmark;

                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);

                            //insert.Insert(buffer);


                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relation

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID());
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                            #endregion aidstonavigation
                            #region related

                            relatedEquipment.CreateRelatedEquipment(current, name, target);

                            #endregion related

                        }
                        break;
                    case 55: { // DAYMAR_Daymark // SLAVE RIND: 2
                            var instance = new Daymark() {
                                topmarkDaymarkShape = default,
                            };

                            #region aidstonavigation

                            if (current.COLOUR != default) {
                                instance.colour = EnumHelper.GetEnumValues<colour>(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            if (current.ELEVAT.HasValue) {
                                instance.elevation = current.ELEVAT.Value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = current.PERSTA,
                                                    dateEnd = current.PEREND
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;
                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}

                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            //insert.Insert(buffer);


                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relation

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID());
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                            #endregion aidstonavigation
                            #region related

                            relatedEquipment.CreateRelatedEquipment(current, name, target);

                            #endregion related

                        }
                        break;
                    case 60: { // FOGSIG_FogSignal // SLAVE RIND: 2

                            //https://geodatastyrelsen.atlassian.net/wiki/spaces/SOEKORT/pages/4404478463/S-65+Annex+B+Appendix+A+-+Impact+analysis
                            //We have one TOPMAR at the same location as a FOGSIG(in three scale bands).We need to add topmark shape in fog signal INFORM.
                            //We do not have in the database information regarding “Radio Activated” nor “Call Activated”. We do have one instance of “On request”. What does this refer to??

                            var instance = new FogSignal() {
                                categoryOfFogSignal = default,
                            };

                            #region aidstonavigation

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = current.PERSTA,
                                                    dateEnd = current.PEREND
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}


                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            //insert.Insert(buffer);


                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relation

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID());
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                            #endregion aidstonavigation
                            #region related

                            relatedEquipment.CreateRelatedEquipment(current, name, target);

                            #endregion related
                        }
                        break;
                    case 65: { // LIGHTS_Light // SLAVE RIND: 2
                            // Only free floating lights!
                            // lights without frels
                            //var light = CreateLight(current, insert, buffer, feature, tableName, convertedCount, featureClass);
                            ;
                            //var related = featureRelations.GetRelated(current.GLOBALID);

                            var lnam = current.LNAM;
                            if (FeatureRelations.GetS101CatlitTypeFrom(current) == typeof(LightSectored)) {
                                var instance = CreateLightSectored(new List<AidsToNavigationP>() { current }); // No related sectors - only the one on the feature.
                                AddInformation(instance.information, feature);

                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                SetShape(buffer,current.SHAPE);
                                //insert.Insert(buffer);

                                var featureN = featureClass.CreateRow(buffer);
                                var structureName = Convert.ToString(featureN["name"]);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                                convertedCount++;


                            }
                            else if (FeatureRelations.GetS101CatlitTypeFrom(current) == typeof(LightAirObstruction)) {
                                var instance = CreateLightAirObstruction(current);

                                AddInformation(instance.information, feature);
                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                SetShape(buffer,current.SHAPE);

                                var featureN = featureClass.CreateRow(buffer);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                                convertedCount++;
                            }
                            else if (FeatureRelations.GetS101CatlitTypeFrom(current) == typeof(LightFogDetector)) {
                                var instance = CreateLightFogDetector(current);
                                AddInformation(instance.information, feature);

                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                SetShape(buffer,current.SHAPE);

                                var featureN = featureClass.CreateRow(buffer);
                                var structureName = Convert.ToString(featureN["name"]);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                                convertedCount++;
                            }
                            else if (FeatureRelations.GetS101CatlitTypeFrom(current) == typeof(LightAllAround)) {
                                var instance = CreateLightAllAround(current);

                                AddInformation(instance.information, feature);
                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                SetShape(buffer,current.SHAPE);

                                //insert.Insert(buffer);
                                var featureN = featureClass.CreateRow(buffer);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                                convertedCount++;
                            }

                            else {
                                throw new NotSupportedException($"{current.GetType()}");
                            }
                        }
                        break;
                    case 70: { // LITFLT_LightFloat
                            var instance = new LightFloat();

                            #region aidstonavigation
                            if (current.COLOUR != default) {
                                instance.colour = EnumHelper.GetEnumValues<colour>(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = current.PERSTA,
                                                    dateEnd = current.PEREND
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}
                            var topmark = relatedEquipment.GetTopMark(current);
                            instance.topmark = topmark;

                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(-1);
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            //insert.Insert(buffer);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relation

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID());
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                            #endregion aidstonavigation
                            #region related

                            relatedEquipment.CreateRelatedEquipment(current, name, target);

                            #endregion related

                        }
                        break;
                    case 75: { // LITVES_LightVessel
                            var instance = new LightVessel();

                            #region aidstonavigation
                            if (current.COLOUR != default) {
                                instance.colour = EnumHelper.GetEnumValues<colour>(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = current.PERSTA,
                                                    dateEnd = current.PEREND
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;
                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}


                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(-1);
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;


                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            //insert.Insert(buffer);


                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relation

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID());
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                            #endregion aidstonavigation
                            #region related

                            relatedEquipment.CreateRelatedEquipment(current, name, target);

                            #endregion related


                        }
                        break;
                    case 85: { // RADRFL_RadarReflector // NOT PART OF Esri PLTS_MASTER_SLAVES
                            var instance = new RadarReflector();

                            #region aidstonavigation

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = current.PERSTA,
                                                    dateEnd = current.PEREND
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }
                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}

                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);



                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);

                            //insert.Insert(buffer);


                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relation

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID());
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                            #endregion aidstonavigation
                            #region related

                            relatedEquipment.CreateRelatedEquipment(current, name, target);

                            #endregion related

                        }
                        break;
                    case 90: { // RADSTA_RadarStation  // SLAVE RIND: 2
                            var instance = new RadarStation();

                            #region aidstonavigation

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = current.PERSTA,
                                                    dateEnd = current.PEREND
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }


                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}


                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);



                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            //insert.Insert(buffer);


                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relation

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID());
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                            #endregion aidstonavigation
                            #region related

                            relatedEquipment.CreateRelatedEquipment(current, name, target);

                            #endregion related


                        }
                        break;
                    case 95: { // RDOSTA_RadioStation // SLAVE RIND: 2
                            var instance = new RadioStation();

                            #region aidstonavigation

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = current.PERSTA,
                                                    dateEnd = current.PEREND
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // TODO: topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            //insert.Insert(buffer);


                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relation

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID());
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                            #endregion aidstonavigation
                            #region related

                            relatedEquipment.CreateRelatedEquipment(current, name, target);

                            #endregion related


                        }
                        break;
                    case 100: { // RETRFL_RetroReflector // SLAVE RIND: 2
                            var instance = new Retroreflector();

                            #region aidstonavigation

                            if (current.COLOUR != default) {
                                instance.colour = EnumHelper.GetEnumValues<colour>(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            if (current.HEIGHT.HasValue) { 
                                instance.height = current.HEIGHT.Value;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = current.PERSTA,
                                                    dateEnd = current.PEREND
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}


                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            //insert.Insert(buffer);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relation

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID());
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                            #endregion aidstonavigation
                            #region related

                            relatedEquipment.CreateRelatedEquipment(current, name, target);

                            #endregion related


                        }
                        break;
                    case 105: { // RTPBCN_RadarTransponderBeacon // SLAVE RIND: 2
                            var instance = new RadarTransponderBeacon() {
                                categoryOfRadarTransponderBeacon = default,
                            };

                            #region aidstonavigation
                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.DATSTA != default) {
                                if (current.DATEND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.DATEND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.DATSTA, out var dateStart)) {
                                            instance.fixedDateRange = new fixedDateRange() {
                                                dateStart = current.PERSTA,
                                                dateEnd = current.PEREND
                                            };
                                        }
                                        else {
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.DATEND}");
                                    }
                                }
                            }

                            // TODO: interoperabilityidentifier

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = current.PERSTA,
                                                    dateEnd = current.PEREND
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }


                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}


                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            //insert.Insert(buffer);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relation

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID());
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                            #endregion aidstonavigation
                            #region related

                            relatedEquipment.CreateRelatedEquipment(current, name, target);

                            #endregion related
                        }
                        break;
                    case 110: { // TOPMAR_Topmark // SLAVE RIND: 2
                            // TODO: TOPMAR
                            //System.Diagnostics.Debugger.Break();
                            //GetCorrespondingAidsToNav
                            /*

                                The S-101 complex attribute topmark has been introduced in S-101 to encode topmarks on aids to
                                navigation features. This information is encoded in S-57 using the Object class TOPMAR. All
                                instances of TOPMAR will be converted to topmark for the corresponding aid to navigation structure
                                feature during the automated conversion process. However, it must be noted that the TOPMAR
                                attributes DATEND, DATSTA, PEREND, PERSTA and STATUS will not be converted. Additional
                                topmark shape information populated in the S-57 attribute INFORM will be converted to the S-101
                                complex attribute shape information. See also clause 12.6.
                            */
                            throw new NotImplementedException("Master topmarks");
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

        internal static LightAllAround CreateLightAllAround(AidsToNavigationP current) {
            var instance = new LightAllAround() {
                rhythmOfLight = default,
            };

            if (current.COLOUR != default) {
                instance.colour = GetColours(current.COLOUR);
            }

            instance.rhythmOfLight = GetRythmOfLight(current);

            if (current.CATLIT != null) {

                if (current.CATLIT == "-32767") {
                    instance.categoryOfLight = EnumHelper.GetEnumValues<categoryOfLight>(-1);
                }
                else {
                    instance.categoryOfLight = EnumHelper.GetEnumValues<categoryOfLight>(current.CATLIT);
                }
            }

            if (current.EXCLIT.HasValue) {
                instance.exhibitionConditionOfLight = EnumHelper.GetEnumValue<exhibitionConditionOfLight>(current.EXCLIT.Value);
            }

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
            if (dateRange != default) {
                instance.fixedDateRange = dateRange;
            }

            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

            //if (current.PLTS_COMP_SCALE.HasValue) {
            //    instance.scaleMinimum = current.PLTS_COMP_SCALE.Value;
            //}

            if (current.STATUS != default) {
                instance.status = GetStatus(current.STATUS);
            }

            if (current.SIGGEN != null) {
                instance.signalGeneration = EnumHelper.GetEnumValue<signalGeneration>(current.SIGGEN.Value);
            }

            if (current.HEIGHT.HasValue) {
                instance.height = current.HEIGHT.Value;
            }

            if (current.EXCLIT.HasValue) {
                instance.exhibitionConditionOfLight = EnumHelper.GetEnumValue<exhibitionConditionOfLight>(current.EXCLIT);
            }

            if (current.MARSYS.HasValue) {
                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS);
            }

            if (current.MLTYLT.HasValue) {
                instance.multiplicityOfFeatures = new multiplicityOfFeatures() {
                    multiplicityKnown = true,
                    numberOfFeatures = current.MLTYLT
                };
            }

            return instance;
        }

        internal static LightFogDetector CreateLightFogDetector(AidsToNavigationP current) {
            var instance = new LightFogDetector();
            //if (current.PLTS_COMP_SCALE.HasValue) {
            //    instance.scaleMinimum = current.PLTS_COMP_SCALE.Value;
            //}
            if (current.COLOUR != default) {
                instance.colour = GetColours(current.COLOUR);
            }

            if (current.STATUS != default) {
                instance.status = GetStatus(current.STATUS);
            }

            instance.rhythmOfLight = GetRythmOfLight(current);


            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

            return instance;
        }

        internal static LightAirObstruction CreateLightAirObstruction(AidsToNavigationP current) {
            // LIGHTS: Attribute catlits contains value 6 (air obstruction light)
            // Build "Light Air Obstruction");
            var instance = new LightAirObstruction();
            //if (current.PLTS_COMP_SCALE.HasValue) {
            //    instance.scaleMinimum = current.PLTS_COMP_SCALE.Value;
            //}
            if (current.COLOUR != default) {
                instance.colour = GetColours(current.COLOUR);
            }

            if (current.STATUS != default) {
                instance.status = GetStatus(current.STATUS);
            }

            instance.rhythmOfLight = GetRythmOfLight(current);

            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

            return instance;
        }

        internal static LightSectored CreateLightSectored(IList<AidsToNavigationP> lights) {
            var instance = new LightSectored();

            // TODO: evaluate
            var current = lights.First();

            if (current.EXCLIT.HasValue) {
                instance.exhibitionConditionOfLight = EnumHelper.GetEnumValue<exhibitionConditionOfLight>(current.EXCLIT.Value);
            }

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
            if (dateRange != default) {
                instance.fixedDateRange = dateRange;
            }

            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

            //if (current.PLTS_COMP_SCALE.HasValue) {
            //    instance.scaleMinimum = current.PLTS_COMP_SCALE.Value;
            //}

            if (current.STATUS != default) {
                instance.status = GetStatus(current.STATUS);
            }

            if (current.SIGGEN != null) {
                instance.signalGeneration = EnumHelper.GetEnumValue<signalGeneration>(current.SIGGEN.Value);
            }

            instance.sectorCharacteristics = (GetSectorCharacteristics(lights));

            if (current.HEIGHT.HasValue) {
                instance.height = current.HEIGHT.Value;
            }

            if (current.EXCLIT.HasValue) {
                instance.exhibitionConditionOfLight = EnumHelper.GetEnumValue<exhibitionConditionOfLight>(current.EXCLIT);
            }

            if (current.MARSYS.HasValue) {
                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS);
            }

            if (current.MLTYLT.HasValue) {
                instance.multiplicityOfFeatures = new multiplicityOfFeatures() {
                    multiplicityKnown = true,
                    numberOfFeatures = current.MLTYLT
                };
            }


            return instance;
        }


        /// <summary>
        /// Take all sectored lights related to this instance and convert them into one sector characteristics
        /// </summary>
        /// <param name="current"></param>
        /// <param name="sectors"></param>
        /// <returns>List of sectorCharacteristics</returns>
        internal static List<sectorCharacteristics> GetSectorCharacteristics(IList<AidsToNavigationP> lights) {
            var sectorCharacteristics = new List<sectorCharacteristics>();

            //if (sectors == null || sectors.Count == 0) {
            //    var rhythmofLight = GetRythmOfLight(current);
            //    if (current.SECTR1 != null && current.SECTR2 != null) {
            //        {
            //            sectorCharacteristics.Add(new sectorCharacteristics() {
            //                lightCharacteristic = rhythmofLight.lightCharacteristic,
            //                signalGroup = rhythmofLight.signalGroup,
            //                signalPeriod = rhythmofLight.signalPeriod,
            //                signalSequence = rhythmofLight.signalSequence,
            //                lightSector = new List<lightSector>() {
            //                    new lightSector() {
            //                        valueOfNominalRange = current.VALNMR.Value,
            //                        colour = EnumHelper.GetEnumValues<colour>(current.COLOUR),
            //                        sectorLimit = new sectorLimit() {
            //                            sectorLimitOne = new sectorLimitOne() {
            //                                sectorBearing = current.SECTR1.Value,
            //                            },
            //                            sectorLimitTwo = new sectorLimitTwo() {
            //                                sectorBearing = current.SECTR2.Value,
            //                            }
            //                        }
            //                    },
            //                }
            //            });
            //        };
            //    }
            //}
            //else {
                foreach (var light in lights) {
                    var rhythmofLight = GetRythmOfLight(light);
                    if (light.SECTR1 != null && light.SECTR2 != null) {
                        {
                        List<lightVisibility> visibility = new List<lightVisibility>();

                        if (light.LITVIS != null) {
                            visibility = EnumHelper.GetEnumValues<lightVisibility>(light.LITVIS);
                        }

                        var sectorCharacteristic = new sectorCharacteristics() {
                            lightCharacteristic = rhythmofLight.lightCharacteristic,
                            signalGroup = rhythmofLight.signalGroup,
                            signalPeriod = rhythmofLight.signalPeriod,
                            signalSequence = rhythmofLight.signalSequence,
                            lightSector = new List<lightSector>() {
                                new lightSector() {
                                    lightVisibility = visibility,
                                    valueOfNominalRange = light.VALNMR.GetValueOrDefault(),
                                    colour = EnumHelper.GetEnumValues<colour>(light.COLOUR),
                                    sectorLimit = new sectorLimit() {
                                        sectorLimitOne = new sectorLimitOne() {
                                            sectorBearing = light.SECTR1.Value,
                                        },
                                        sectorLimitTwo = new sectorLimitTwo() {
                                            sectorBearing = light.SECTR2.Value,
                                        }
                                    }
                                },
                            }
                        };


                            sectorCharacteristics.Add(sectorCharacteristic);
                        };
                    }

                }
            //}

            return sectorCharacteristics;
        }
    }
}
