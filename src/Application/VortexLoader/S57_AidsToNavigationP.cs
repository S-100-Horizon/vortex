using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using ArcGIS.Desktop.Internal.Mapping;
using Microsoft.Extensions.Configuration;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;
using S100Framework.DomainModel.S101.FeatureTypes;
using System.Security.AccessControl;




namespace S100Framework.Applications
{
    internal static partial class ImporterNIS {



        private static void S57_AidsToNavigationP(Geodatabase source, Geodatabase target, QueryFilter filter) {


            var tableName = "AidsToNavigationP";

            using var aidstonavigation = source.OpenDataset<FeatureClass>(source.GetName(tableName));

            using var featureAssociation = target.OpenDataset<Table>(target.GetName("featureassociation"));
            using var informationAssociation = target.OpenDataset<Table>(target.GetName("informationassociation"));

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
                            var instance = new CardinalBeacon();
                            
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

                            if (current.MARSYS.HasValue) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS.Value);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.TryConvertToDateOnly(current.SORDAT, out var dateOnly)) {
                                    instance.reportedDate = dateOnly;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            topmarkDaymarkShape? topmarkDaymark = null;
                            

                            var topmark = relatedEquipment.GetTopMark(current);
                            if (topmark != null) {
                                instance.topmark = topmark;
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }


                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(-1);
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            //if (plts_comp_scale != default) {
                            //    instance.scaleMinimum = plts_comp_scale;
                            //}

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);

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
                            var instance = new IsolatedDangerBeacon();

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

                            if (current.MARSYS.HasValue) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS.Value);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.TryConvertToDateOnly(current.SORDAT, out var dateOnly)) {
                                    instance.reportedDate = dateOnly;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }


                            var topmark = relatedEquipment.GetTopMark(current);
                            if (topmark != null) {
                                instance.topmark = topmark;
                            }


                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(-1);
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            //if (plts_comp_scale != default) {
                            //  instance.scaleMinimum = plts_comp_scale;
                            //}

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);

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
                            var instance = new LateralBeacon();

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

                            // TODO: interoperabilityidentifier
                            
                            if (current.HEIGHT.HasValue) { 
                                instance.height = current.HEIGHT.Value;
                            }

                            if (current.MARSYS.HasValue) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS.Value);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }



                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.TryConvertToDateOnly(current.SORDAT, out var dateOnly)) {
                                    instance.reportedDate = dateOnly;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.SORDAT}");
                                }
                            }


                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            var topmark = relatedEquipment.GetTopMark(current);
                            if (topmark != null) {
                                instance.topmark = topmark;
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(-1);
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            //if (plts_comp_scale != default) {
                            //  instance.scaleMinimum = plts_comp_scale;
                            //}

                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }


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
                            var instance = new SafeWaterBeacon();

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

                            if (current.MARSYS.HasValue) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS.Value);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.TryConvertToDateOnly(current.SORDAT, out var dateOnly)) {
                                    instance.reportedDate = dateOnly;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            var topmark = relatedEquipment.GetTopMark(current);
                            if (topmark != null) {
                                instance.topmark = topmark;
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(-1);
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            //if (plts_comp_scale != default) {
                            //  instance.scaleMinimum = plts_comp_scale;
                            //}

                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);

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
                            var instance = new SpecialPurposeGeneralBeacon();

                            #region aidstonavigation

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

                            if (current.MARSYS.HasValue) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS.Value);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }
                            
                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.TryConvertToDateOnly(current.SORDAT, out var dateOnly)) {
                                    instance.reportedDate = dateOnly;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            var topmark = relatedEquipment.GetTopMark(current);
                            if (topmark != null) {
                                instance.topmark = topmark;
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(-1);
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            //if (plts_comp_scale != default) {
                            //  instance.scaleMinimum = plts_comp_scale;
                            //}
                                
                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);

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
                            var instance = new CardinalBuoy();
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

                            if (current.MARSYS.HasValue) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS.Value);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }
                                
                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            var topmark = relatedEquipment.GetTopMark(current);
                            if (topmark != null) {
                                instance.topmark = topmark;
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            //if (plts_comp_scale != default) {
                            //  instance.scaleMinimum = plts_comp_scale;
                            //}

                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

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
                            var instance = new InstallationBuoy();
                            #region aidstonavigation
                            if (current.BOYSHP.HasValue) {
                                if (current.BOYSHP.Value == -32767)
                                    instance.buoyShape = EnumHelper.GetEnumValue<buoyShape>(-1);
                                else {
                                    instance.buoyShape = EnumHelper.GetEnumValue<buoyShape>(current.BOYSHP);
                                }
                            }

                            if (current.CATINB.HasValue) {
                                instance.categoryOfInstallationBuoy = EnumHelper.GetEnumValue<categoryOfInstallationBuoy>(current.CATINB.Value);
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

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.PRODCT != default) {
                                instance.product = EnumHelper.GetEnumValues<product>(current.PRODCT);
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(-1);
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            //if (plts_comp_scale != default) {
                            //  instance.scaleMinimum = plts_comp_scale;
                            //}

                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);

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
                            var instance = new IsolatedDangerBuoy();
                            #region aidstonavigation
                            if (current.BOYSHP.HasValue) {
                                if (current.BOYSHP.Value == -32767)
                                    instance.buoyShape = EnumHelper.GetEnumValue<buoyShape>(-1);
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

                            if (current.MARSYS.HasValue) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS.Value);
                            }


                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            var topmark = relatedEquipment.GetTopMark(current);
                            if (topmark != null) {
                                instance.topmark = topmark;
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            //if (plts_comp_scale != default) {
                            //  instance.scaleMinimum = plts_comp_scale;
                            //}

                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);

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
                    case 40: { // BOYLAT_BuoyLateral
                            var instance = new LateralBuoy();

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

                            if (current.MARSYS.HasValue) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS.Value);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            var topmark = relatedEquipment.GetTopMark(current);
                            if (topmark != null) {
                                instance.topmark = topmark;
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            //if (plts_comp_scale != default) {
                            //  instance.scaleMinimum = plts_comp_scale;
                            //}
                                
                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }


                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relation

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID());
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                            #endregion aidstonavigation
                            #region related

                            relatedEquipment.CreateRelatedEquipment(current, name, target);

                            #endregion relatedæ

                        }
                        break;
                    case 45: { // BOYSAW_BuoySafeWater
                            var instance = new SafeWaterBuoy();
                            #region aidstonavigation
                            if (current.BOYSHP.HasValue) {
                                if (current.BOYSHP.Value == -32767)
                                    instance.buoyShape = EnumHelper.GetEnumValue<buoyShape>(-1);
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

                            if (current.MARSYS.HasValue) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS.Value);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            var topmark = relatedEquipment.GetTopMark(current);
                            if (topmark != null) {
                                instance.topmark = topmark;
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            //if (plts_comp_scale != default) {
                            //  instance.scaleMinimum = plts_comp_scale;
                            //}

                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

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
                            var instance = new SpecialPurposeGeneralBuoy();

                            #region aidstonavigation
                            if (current.BOYSHP.HasValue) {
                                if (current.BOYSHP.Value == -32767)
                                    instance.buoyShape = EnumHelper.GetEnumValue<buoyShape>(-1);
                                else {
                                    instance.buoyShape = EnumHelper.GetEnumValue<buoyShape>(current.BOYSHP);
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

                            if (current.MARSYS.HasValue) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS.Value);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }


                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            var topmark = relatedEquipment.GetTopMark(current);
                            if (topmark != null) {
                                instance.topmark = topmark;
                            }

                            //if (plts_comp_scale != default) {
                            //  instance.scaleMinimum = plts_comp_scale;
                            //}

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
                            var instance = new Daymark();

                            #region aidstonavigation
                            if (current.CATSPM != default) {
                                if (current.CATSPM == "-32767")
                                    instance.categoryOfSpecialPurposeMark = EnumHelper.GetEnumValues<categoryOfSpecialPurposeMark>(-1);
                                else {
                                    instance.categoryOfSpecialPurposeMark = EnumHelper.GetEnumValues<categoryOfSpecialPurposeMark>(current.CATSPM);
                                }
                            }

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

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.TOPSHP.HasValue) {
                                instance.topmarkDaymarkShape = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            // TODO: shapeInformation

                            //if (plts_comp_scale != default) {
                            //  instance.scaleMinimum = plts_comp_scale;
                            //}

                            AddInformation(instance.information, feature);


                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

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

                            var instance = new FogSignal();

                            #region aidstonavigation
                            if (current.CATFOG.HasValue!= default) {
                                if (current.CATFOG.Value == -32767)
                                    instance.categoryOfFogSignal = EnumHelper.GetEnumValue<categoryOfFogSignal>(-1);
                                else {
                                    instance.categoryOfFogSignal = EnumHelper.GetEnumValue<categoryOfFogSignal>(current.CATFOG.Value);
                                }
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

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
                                instance.signalGeneration = EnumHelper.GetEnumValue<signalGeneration>(current.SIGGEN.Value);
                            }
                            if (current.SIGGRP != default) {
                                instance.signalGroup = current.SIGGRP;
                            }
                            if (current.SIGPER != default) {
                                instance.signalPeriod = current.SIGPER;
                            }

                            if (current.SIGSEQ != default) {
                                instance.signalSequence = GetSignalSequences(current.SIGSEQ);
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            // TODO: interoperabilityidentifier

                            if (current.VALMXR.HasValue) {
                                instance.valueOfMaximumRange = current.VALMXR.Value;
                            }

                            //if (plts_comp_scale != default) {
                            //  instance.scaleMinimum = plts_comp_scale;
                            //}

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

                            if (current.HORLEN.HasValue) {
                                instance.horizontalLength = current.HORLEN.Value;
                            }

                            if (current.HORWID.HasValue) {
                                instance.horizontalWidth = current.HORWID.Value;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            var topmark = relatedEquipment.GetTopMark(current);
                            if (topmark != null) {
                                instance.topmark = topmark;
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN;
                            }

                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(-1);
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            //if (plts_comp_scale != default) {
                            //  instance.scaleMinimum = plts_comp_scale;
                            //}

                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

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

                            if (current.HORLEN.HasValue) {
                                instance.horizontalLength = current.HORLEN.Value;
                            }

                            if (current.HORWID.HasValue) {
                                instance.horizontalWidth = current.HORWID.Value;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN;
                            }

                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(-1);
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            //if (plts_comp_scale != default) {
                            //  instance.scaleMinimum = plts_comp_scale;
                            //}

                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
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

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            //if (plts_comp_scale != default) {
                            //  instance.scaleMinimum = plts_comp_scale;
                            //}

                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);

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

                            if (current.CALSGN != default) {
                                instance.callSign = current.CALSGN;
                            }

                            if (current.CATRAS != null) {
                                if (current.CATRAS == -32767) {
                                    instance.categoryOfRadarStation = EnumHelper.GetEnumValues<categoryOfRadarStation>(-1);
                                }
                                else {
                                    instance.categoryOfRadarStation = EnumHelper.GetEnumValues<categoryOfRadarStation>(current.CATRAS);
                                }
                            }
                            
                            if (current.COMCHA != default) {
                                instance.communicationChannel = current.COMCHA.Split(',').ToList<string>();
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value;
                            }

                            // TODO: interoperabilityidentifier

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VALMXR.HasValue) {
                                instance.valueOfMaximumRange = current.VALMXR.Value;
                            }

                            //if (plts_comp_scale != default) {
                            //  instance.scaleMinimum = plts_comp_scale;
                            //}

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

                            if (current.CALSGN != default) {
                                instance.callSign = current.CALSGN;
                            }

                            if (current.CATROS != null) {
                                if (current.CATROS == "-32767") {
                                    instance.categoryOfRadioStation = EnumHelper.GetEnumValues<categoryOfRadioStation>(-1);
                                }
                                else {
                                    instance.categoryOfRadioStation = EnumHelper.GetEnumValues<categoryOfRadioStation>(current.CATROS);
                                }
                            }

                            if (current.COMCHA != default) {
                                instance.communicationChannel = current.COMCHA.Split(',').ToList<string>();
                            }

                            if (current.ESTRNG.HasValue) {
                                instance.estimatedRangeOfTransmission = current.ESTRNG.Value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            if (current.SIGFRQ.HasValue) {
                                instance.frequencyPair = GetFrequencyPair(current.SIGFRQ.Value);
                            }

                            // TODO: interoperabilityidentifier

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            //if (plts_comp_scale != default) {
                            //  instance.scaleMinimum = plts_comp_scale;
                            //}

                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);

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


                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            //if (plts_comp_scale != default) {
                            //  instance.scaleMinimum = plts_comp_scale;
                            //}

                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);

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
                            var instance = new RadarTransponderBeacon();

                            #region aidstonavigation

                            if (current.CATROS != null) {
                                if (current.CATROS == "-32767") {
                                    instance.categoryOfRadarTransponderBeacon = EnumHelper.GetEnumValue<categoryOfRadarTransponderBeacon>(-1);
                                }
                                else {
                                    instance.categoryOfRadarTransponderBeacon = EnumHelper.GetEnumValue<categoryOfRadarTransponderBeacon>(current.CATROS);
                                }
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            // TODO: interoperabilityidentifier

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }


                            // TODO: radarWaveLengths #30 on action point list.
                            //if (current.RADWAL != default) {
                            //    instance.radarWaveLength = GetRadarWaveLengths(current.RADWAL);
                            //}

                            if (current.SECTR1.HasValue && current.SECTR2.HasValue) {
                                instance.sectorLimit = new sectorLimit() {
                                    sectorLimitOne = new sectorLimitOne {
                                        sectorBearing = current.SECTR1.Value,
                                    },
                                    sectorLimitTwo = new sectorLimitTwo {
                                        sectorBearing = current.SECTR2.Value
                                    }
                                };
                            }

                            var rhythmOfLight = GetRythmOfLight(current);

                            if (current.SIGGRP != default) {
                                instance.signalGroup = current.SIGGRP;
                            }

                            if (current.SIGSEQ != default) {
                                instance.signalSequence = rhythmOfLight.signalSequence;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VALMXR.HasValue) {
                                instance.valueOfMaximumRange = current.VALMXR.Value;
                            }

                            //if (plts_comp_scale != default) {
                            //  instance.scaleMinimum = plts_comp_scale;
                            //}

                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);

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

        private static List<radarWaveLength> GetRadarWaveLengths(string radwal) {
            var result = new List<radarWaveLength>();
            string[] radwals = radwal.Split(',');
            if (radwals.Length == 1) {
                result.Add(new radarWaveLength() {
                    waveLengthValue = Decimal.Parse(radwals[0])
                });
            } else {
                result.Add(new radarWaveLength() {
                    radarBand = radwals[0],
                    waveLengthValue = Decimal.Parse(radwals[1])
                });

            }
            return result;
        }

        private static frequencyPair? GetFrequencyPair(int frequencyShoreStationTransmits) {
            return new frequencyPair() {
                frequencyShoreStationTransmits = frequencyShoreStationTransmits
            };
        }

        internal static LightAllAround CreateLightAllAround(AidsToNavigationP current) {
            var instance = new LightAllAround();

            if (current.CATLIT != null) {
                if (current.CATLIT == "-32767") {
                    instance.categoryOfLight = EnumHelper.GetEnumValues<categoryOfLight>(-1);
                }
                else {
                    instance.categoryOfLight = EnumHelper.GetEnumValues<categoryOfLight>(current.CATLIT);
                }
            }

            if (current.COLOUR != default) {
                instance.colour = GetColours(current.COLOUR);
            }

            if (current.EXCLIT.HasValue) {
                instance.exhibitionConditionOfLight = EnumHelper.GetEnumValue<exhibitionConditionOfLight>(current.EXCLIT.Value);
            }

            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
            if (dateRange != default) {
                instance.fixedDateRange = dateRange;
            }

            // flareBearing is not populated. New field.

            if (current.HEIGHT.HasValue) {
                instance.height = current.HEIGHT.Value;
            }

            // TODO: interoperabilityidentifier

            if (current.LITVIS != null) {
                instance.lightVisibility = EnumHelper.GetEnumValue<lightVisibility>(current.LITVIS);
            }

            /*
                The S-101 Boolean type attribute major light has been introduced in S-101 to aid in improved
                portrayal of lights in ECDIS. This attribute will be populated as True during the automated conversion
                process for all lights having a nominal range of 10 Nautical Miles or greater.
            */

            if (current.VALNMR.HasValue) {
                instance.valueOfNominalRange = current.VALNMR.Value;

                if (current.VALNMR.Value >= 10.0m) {
                    instance.majorLight = true;
                }
            }

            if (current.MARSYS.HasValue) {
                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS.Value);
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

            instance.rhythmOfLight = GetRythmOfLight(current);

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var fixedDateRange);
            if (dateRange != default) {
                instance.fixedDateRange = fixedDateRange;
            }

            if (current.SIGGEN != null) {
                instance.signalGeneration = EnumHelper.GetEnumValue<signalGeneration>(current.SIGGEN.Value);
            }

            if (current.STATUS != default) {
                instance.status = GetStatus(current.STATUS);
            }

            if (current.VALNMR.HasValue) {
                instance.valueOfNominalRange = current.VALNMR.Value;
            }

            if (current.VERDAT.HasValue) {
                instance.verticalDatum = EnumHelper.GetEnumValue<verticalDatum>(current.VERDAT.Value);
            }

            if (current.VERLEN.HasValue) {
                instance.verticalLength = current.VERLEN.Value;
            }

            //if (plts_comp_scale != default) {
            //  instance.scaleMinimum = plts_comp_scale;
            //}

            return instance;
        }

        internal static LightFogDetector CreateLightFogDetector(AidsToNavigationP current) {
            var instance = new LightFogDetector();

            if (current.COLOUR != default) {
                instance.colour = GetColours(current.COLOUR);
            }

            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
            if (dateRange != default) {
                instance.fixedDateRange = dateRange;
            }

            // flareBearing is not populated. New field.

            if (current.HEIGHT.HasValue) {
                instance.height = current.HEIGHT.Value;
            }

            // DODO: Interoperability identifier

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange = periodicDateRange;
            }

            instance.rhythmOfLight = GetRythmOfLight(current);

            if (current.SIGGEN != null) {
                instance.signalGeneration = EnumHelper.GetEnumValue<signalGeneration>(current.SIGGEN.Value);
            }

            if (current.STATUS != default) {
                instance.status = GetStatus(current.STATUS);
            }

            if (current.VERDAT.HasValue) {
                instance.verticalDatum = EnumHelper.GetEnumValue<verticalDatum>(current.VERDAT.Value);
            }

            if (current.VERLEN.HasValue) {
                instance.verticalLength = current.VERLEN.Value;
            }

            //if (current.PLTS_COMP_SCALE.HasValue) {
            //    instance.scaleMinimum = current.PLTS_COMP_SCALE.Value;
            //}

            if (current.HEIGHT.HasValue) {
                instance.height = current.HEIGHT.Value;
            }

            return instance;
        }

        internal static LightAirObstruction CreateLightAirObstruction(AidsToNavigationP current) {
            var instance = new LightAirObstruction();

            if (current.COLOUR != default) {
                instance.colour = GetColours(current.COLOUR);
            }

            if (current.EXCLIT.HasValue) {
                instance.exhibitionConditionOfLight = EnumHelper.GetEnumValue<exhibitionConditionOfLight>(current.EXCLIT.Value);
            }

            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
            if (dateRange != default) {
                instance.fixedDateRange = dateRange;
            }

            // flareBearing is not populated. New field.

            // DODO: Interoperability identifier

            if (current.HEIGHT.HasValue) {
                instance.height = current.HEIGHT.Value;
            }

            if (current.LITVIS != null) {
                instance.lightVisibility = EnumHelper.GetEnumValues<lightVisibility>(current.LITVIS);
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

            instance.rhythmOfLight = GetRythmOfLight(current);

            if (current.STATUS != default) {
                instance.status = GetStatus(current.STATUS);
            }

            if (current.VALNMR.HasValue) {
                instance.valueOfNominalRange = current.VALNMR.Value;
            }

            if (current.VERDAT.HasValue) {
                instance.verticalDatum = EnumHelper.GetEnumValue<verticalDatum>(current.VERDAT.Value);
            }

            //if (plts_comp_scale != default) {
            //  instance.scaleMinimum = plts_comp_scale;
            //}

            return instance;
        }

        internal static LightSectored CreateLightSectored(IList<AidsToNavigationP> lights) {
            var instance = new LightSectored();

            // TODO: evaluate light sectors based on height. Assume same height for now and take data from first.
            var current = lights.First();

            foreach (var lightN in lights) {
                if (lightN.CATLIT != default) {
                    var list = EnumHelper.GetEnumValues<categoryOfLight>(lightN.CATLIT);
                    instance.categoryOfLight = (List<categoryOfLight>)instance.categoryOfLight.Union(list.ToList<categoryOfLight>());
                }
            }

            if (current.EXCLIT.HasValue) {
                instance.exhibitionConditionOfLight = EnumHelper.GetEnumValue<exhibitionConditionOfLight>(current.EXCLIT.Value);
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

            if (current.MARSYS.HasValue) {
                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS.Value);
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

            instance.sectorCharacteristics = (GetSectorCharacteristics(lights));

            if (current.SIGGEN != null) {
                instance.signalGeneration = EnumHelper.GetEnumValue<signalGeneration>(current.SIGGEN.Value);
            }

            if (current.STATUS != default) {
                instance.status = GetStatus(current.STATUS);
            }

            // TODO: verticalDatum

            if (current.VERDAT.HasValue) {
                instance.verticalDatum = EnumHelper.GetEnumValue<verticalDatum>(current.VERDAT.Value);
            }

            //if (current.PLTS_COMP_SCALE.HasValue) {
            //    instance.scaleMinimum = current.PLTS_COMP_SCALE.Value;
            //}

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
