using ArcGIS.Core.Data;
using Microsoft.AspNetCore.Mvc;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;
using S100Framework.DomainModel.S101.FeatureTypes;
using System.Globalization;
using VortexLoader;
using S100Framework.Applications.Singletons;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_AidsToNavigationP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "AidsToNavigationP";

            using var aidstonavigationp = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("point"));

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            var orgWhereClause = filter.WhereClause.Clone().ToString();

            //filter.WhereClause += " AND globalid in ('{FF531488-02BE-496F-91D5-7E6FEDCB0CD1}')";
            //filter.WhereClause += " AND globalid in ('{80125E6A-2D84-4FD2-B9C8-BEF5594FA926}', '{048BFCB0-F3B2-4075-9460-B89E1840CA03}')"; // NO SPEC FLOATING LIGHT

            using var cursor = aidstonavigationp.Search(filter, true);
            
            //filter.WhereClause = orgWhereClause;

            int recordCount = 0;
            var _slaves = new Dictionary<Guid,string>();

            while (cursor.MoveNext()) {
                recordCount += 1;
                var feature = (Feature)cursor.Current; 
                var current = new AidsToNavigationP(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;
                var fcSubtype = current.FCSUBTYPE ?? default;

                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    continue;
                }

                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;

                if (FeatureRelations.Instance.IsSlave(globalid)) {
                    Subtypes.Instance.TryGetSubtype(tableName, current.FCSUBTYPE.Value, out var subtype);
                    _slaves.Add(globalid,$"{tableName}::{globalid}::{subtype}");
                    continue;
                }

                switch (fcSubtype) {
                    case 1: { // BCNCAR_BeaconCardinal

                            var instance = _converterRegistry.Convert<CardinalBeacon>(current);

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN);
                            }
                        }
                        break;

                    case 5: { // BCNISD_BeaconIsolatedDanger
                            var instance = new IsolatedDangerBeacon();

                            #region aidstonavigation

                            if (current.BCNSHP.HasValue) {
                                instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>(current.BCNSHP);
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
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.regexTruncatedDateValidation.IsMatch(current.SORDAT)) {
                                    instance.reportedDate = current.SORDAT;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, tableName, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            var topmark = relatedEquipment?.GetTopMark(current);
                            

                            if (topmark != null) {
                                instance.topmark = topmark;
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

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            
                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN);
                            }
                        }
                        break;

                    case 10: { // BCNLAT_BeaconLateral
                            var instance = new LateralBeacon();

                            #region aidstonavigation

                            if (current.BCNSHP.HasValue) {
                                instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>(current.BCNSHP);
                            }

                            if (current.CATLAM.HasValue) {
                                instance.categoryOfLateralMark = EnumHelper.GetEnumValue<categoryOfLateralMark>(current.CATLAM.Value);
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
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.regexTruncatedDateValidation.IsMatch(current.SORDAT)) {
                                    instance.reportedDate = current.SORDAT;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, tableName, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            var topmark = relatedEquipment?.GetTopMark(current);
                            if (topmark != null) {
                                instance.topmark = topmark;
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

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }


                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN);
                            }
                        }
                        break;

                    case 15: { // BCNSAW_BeaconSafeWater
                            var instance = new SafeWaterBeacon();

                            #region aidstonavigation

                            if (current.BCNSHP.HasValue) {
                                instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>(current.BCNSHP);
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
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.regexTruncatedDateValidation.IsMatch(current.SORDAT)) {
                                    instance.reportedDate = current.SORDAT;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, tableName, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            var topmark = relatedEquipment?.GetTopMark(current);
                            if (topmark != null) {
                                instance.topmark = topmark;
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

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }


                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN);
                            }
                        }
                        break;

                    case 20: { // BCNSPP_BeaconSpecialPurpose
                            var instance = new SpecialPurposeGeneralBeacon();

                            #region aidstonavigation

                            if (current.BCNSHP.HasValue) {
                                instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>(current.BCNSHP);
                            }

                            if (current.CATSPM != default) {
                                instance.categoryOfSpecialPurposeMark = EnumHelper.GetEnumValues<categoryOfSpecialPurposeMark>(current.CATSPM);
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
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.regexTruncatedDateValidation.IsMatch(current.SORDAT)) {
                                    instance.reportedDate = current.SORDAT;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, tableName, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            var topmark = relatedEquipment?.GetTopMark(current);
                            if (topmark != null) {
                                instance.topmark = topmark;
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

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }


                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN);
                            }
                        }
                        break;

                    case 25: { // BOYCAR_BuoyCardinal
                            var instance = new CardinalBuoy();

                            #region aidstonavigation

                            if (current.BOYSHP.HasValue) {
                                instance.buoyShape = EnumHelper.GetEnumValue<buoyShape>(current.BOYSHP);
                            }

                            if (current.CATCAM.HasValue) {
                                instance.categoryOfCardinalMark = EnumHelper.GetEnumValue<categoryOfCardinalMark>(current.CATCAM.Value);
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
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            var topmark = relatedEquipment?.GetTopMark(current);
                            if (topmark != null) {
                                instance.topmark = topmark;
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }


                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN);
                            }
                        }
                        break;

                    case 30: { // BOYINB_BuoyInstallation
                            var instance = new InstallationBuoy();

                            #region aidstonavigation

                            if (current.BOYSHP.HasValue) {
                                instance.buoyShape = EnumHelper.GetEnumValue<buoyShape>(current.BOYSHP);
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
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }


                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN);
                            }
                        }
                        break;

                    case 35: { // BOYISD_BuoyIsolatedDanger
                            var instance = new IsolatedDangerBuoy();

                            #region aidstonavigation

                            if (current.BOYSHP.HasValue) {
                                instance.buoyShape = EnumHelper.GetEnumValue<buoyShape>(current.BOYSHP);
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
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            var topmark = relatedEquipment?.GetTopMark(current);
                            if (topmark != null) {
                                instance.topmark = topmark;
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }


                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN);
                            }
                        }
                        break;

                    case 40: { // BOYLAT_BuoyLateral
                            var instance = new LateralBuoy();

                            #region aidstonavigation

                            if (current.BOYSHP.HasValue) {
                                instance.buoyShape = EnumHelper.GetEnumValue<buoyShape>(current.BOYSHP);
                            }

                            if (current.CATLAM.HasValue) {
                                instance.categoryOfLateralMark = EnumHelper.GetEnumValue<categoryOfLateralMark>(current.CATLAM.Value);
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
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            var topmark = relatedEquipment?.GetTopMark(current);
                            if (topmark != null) {
                                instance.topmark = topmark;
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }


                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN);
                            }
                        }
                        break;

                    case 45: { // BOYSAW_BuoySafeWater
                            var instance = new SafeWaterBuoy();

                            #region aidstonavigation

                            if (current.BOYSHP.HasValue) {
                                instance.buoyShape = EnumHelper.GetEnumValue<buoyShape>(current.BOYSHP);
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
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            var topmark = relatedEquipment?.GetTopMark(current);
                            if (topmark != null) {
                                instance.topmark = topmark;
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }


                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (relatedEquipment != null) {
                                relatedEquipment.CreateRelatedPointEquipment(current, instance, featureN);
                            }
                        }
                        break;

                    case 50: { // BOYSPP_BuoySpecialPurpose
                            var instance = new SpecialPurposeGeneralBuoy();

                            #region aidstonavigation

                            if (current.BOYSHP.HasValue) {
                                instance.buoyShape = EnumHelper.GetEnumValue<buoyShape>(current.BOYSHP);
                            }

                            if (current.CATSPM != default) {
                                instance.categoryOfSpecialPurposeMark = EnumHelper.GetEnumValues<categoryOfSpecialPurposeMark>(current.CATSPM);
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
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            var topmark = relatedEquipment?.GetTopMark(current);
                            if (topmark != null) {
                                instance.topmark = topmark;
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }


                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN);
                            }
                        }
                        break;

                    case 55: { // DAYMAR_Daymark // SLAVE RIND: 2
                            var instance = ImporterNIS._converterRegistry.Convert<Daymark>(current);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);

                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN);
                            }
                        }
                        break;

                    case 60: { // FOGSIG_FogSignal // SLAVE RIND: 2
                            //https://geodatastyrelsen.atlassian.net/wiki/spaces/SOEKORT/pages/4404478463/S-65+Annex+B+Appendix+A+-+Impact+analysis
                            //We have one TOPMAR at the same location as a FOGSIG(in three scale bands).We need to add topmark shape in fog signal INFORM.
                            //We do not have in the database information regarding “Radio Activated” nor “Call Activated”. We do have one instance of “On request”. What does this refer to??
                            var instance = _converterRegistry.Convert<FogSignal>(current);

                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN);
                            }
                        }
                        break;

                    case 65: { // LIGHTS_Light // SLAVE RIND: 2
                            // Only free floating lights!
                            // lights without frels
                            //var light = CreateLight(current, insert, buffer, feature, tableName, convertedCount, featureClass);
                            ;
                            //var related = featureRelations.GetRelated(current.GLOBALID);

                            var lnam = current.LNAM;
                            if (FeatureRelations.Instance.GetS101CatlitTypeFrom(current) == typeof(LightSectored)) {
                                var instance = ImporterNIS._converterRegistry.Convert<LightSectored>(current); // No related sectors - only the one on the feature.

                                AddInformation(instance.information, feature);

                                if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                    string subtype = "";

                                    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                    instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                                }

                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                SetShape(buffer, current.SHAPE);

                                var featureN = featureClass.CreateRow(buffer);
                                var structureName = Convert.ToString(featureN["name"]);
                                if (structureName == null) {
                                    throw new NotSupportedException("empty structure name");
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, structureName);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            }
                            else if (FeatureRelations.Instance.GetS101CatlitTypeFrom(current) == typeof(LightAirObstruction)) {
                                var instance = ImporterNIS._converterRegistry.Convert<LightAirObstruction>(current); //CreateLightAirObstruction(current);

                                if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                    string subtype = "";

                                    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                    instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                                }


                                AddInformation(instance.information, feature);
                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                SetShape(buffer, current.SHAPE);

                                var featureN = featureClass.CreateRow(buffer);
                                var structureName = Convert.ToString(featureN["name"]);

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, structureName ?? "Unknown structure name");
                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            }
                            else if (FeatureRelations.Instance.GetS101CatlitTypeFrom(current) == typeof(LightFogDetector)) {
                                var instance = ImporterNIS._converterRegistry.Convert<LightFogDetector>(new List<AidsToNavigationP>() { current }); // var instance = CreateLightFogDetector(current);

                                if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                    string subtype = "";

                                    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                    instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                                }


                                AddInformation(instance.information, feature);

                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                SetShape(buffer, current.SHAPE);

                                var featureN = featureClass.CreateRow(buffer);
                                var structureName = Convert.ToString(featureN["name"]);

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, structureName ?? "Unknown structure name");
                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            }
                            else if (FeatureRelations.Instance.GetS101CatlitTypeFrom(current) == typeof(LightAllAround)) {
                                var instance = ImporterNIS._converterRegistry.Convert<LightAllAround>(current);

                                if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                    string subtype = "";

                                    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                    instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                                }

                                AddInformation(instance.information, feature);
                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                SetShape(buffer, current.SHAPE);

                                var featureN = featureClass.CreateRow(buffer);
                                var structureName = Convert.ToString(featureN["name"]);

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, structureName ?? "Unknown structure name");
                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
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
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            var topmark = relatedEquipment?.GetTopMark(current);
                            if (topmark != null) {
                                instance.topmark = topmark;
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN;
                            }

                            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }


                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN);
                            }
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
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN;
                            }

                            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }


                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN);
                            }
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

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }


                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN);
                            }
                        }
                        break;

                    case 90: { // RADSTA_RadarStation  // SLAVE RIND: 2
                            var instance = _converterRegistry.Convert<RadarStation>(current);

                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN);
                            }
                        }
                        break;

                    case 95: { // RDOSTA_RadioStation // SLAVE RIND: 2
                            var instance = _converterRegistry.Convert<RadioStation>(current);
                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN);
                            }

                        }
                        break;

                    case 100: { // RETRFL_RetroReflector // SLAVE RIND: 2
                            var instance = _converterRegistry.Convert<Retroreflector>(current);

                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID(), name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN);
                            }
                        } 
                        break;

                    case 105: { // RTPBCN_RadarTransponderBeacon // SLAVE RIND: 2
                            var instance = _converterRegistry.Convert<RadarTransponderBeacon>(current);

                            if (current.CATRTB.HasValue) {
                                instance.categoryOfRadarTransponderBeacon = EnumHelper.GetEnumValue<categoryOfRadarTransponderBeacon>(current.CATRTB.Value);
                            }

                            if (current.SIGGRP != default) {
                                instance.signalGroup = current.SIGGRP;
                             }

                            if (current.RADWAL != default) {
                                if (TryGetRadarWaveLengths(current.RADWAL, out var lengths)) {
                                    instance.radarWaveLength = lengths;
                                }
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            AddInformation(instance.information, feature);

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN);
                            }
                        }
                        break;

                    case 110: { // TOPMAR_Topmark // SLAVE RIND: 2
                            /*

                                The S-101 complex attribute topmark has been introduced in S-101 to encode topmarks on aids to
                                navigation features. This information is encoded in S-57 using the Object class TOPMAR. All
                                instances of TOPMAR will be converted to topmark for the corresponding aid to navigation structure
                                feature during the automated conversion process. However, it must be noted that the TOPMAR
                                attributes DATEND, DATSTA, PEREND, PERSTA and STATUS will not be converted. Additional
                                topmark shape information populated in the S-57 attribute INFORM will be converted to the S-101
                                complex attribute shape information. See also clause 12.6.
                            */

                            throw new NotImplementedException("Impossible! No stand alone topmarks alloved.");
                            
                        }
                    default:
                        // code block
                        throw new Exception($"Missing subtype in S57_AidsToNavigation: {fcSubtype}");
                }
            }

            Logger.Current.DataTotalCount(tableName, recordCount, ConversionAnalytics.Instance.GetConvertedCount(tableName));

            var _nonConvertedSlaves = new List<Guid>();

            foreach (var slaveId in _slaves.Keys) {
                if (!ConversionAnalytics.Instance.IsConverted(slaveId)) {
                    _nonConvertedSlaves.Add(slaveId);
                    Logger.Current.DataError(-1, tableName, "These slaves are missing the structure", $"{_slaves[slaveId]}");
                }
            }
        }

        internal static bool TryGetRadarWaveLengths(string radwal, out List<radarWaveLength> radarWaveLengths) {
            radarWaveLengths = new List<radarWaveLength>();

            string[] parts = radwal.Split(',');
            foreach (var part in parts) {
                string[] split = part.Split('-');
                if (split.Length == 2) {
                    if (decimal.TryParse(split[0], CultureInfo.InvariantCulture, out decimal waveLength)) {
                        string band = split[1];
                        radarWaveLengths.Add(new radarWaveLength() {
                            radarBand = band,
                            waveLengthValue = waveLength
                        });
                    }
                    else { // data error
                        return false;
                    }
                }
                else { // data error
                    return false;
                }
            }
            return true;
        }

        internal static frequencyPair? GetFrequencyPair(int frequencyShoreStationTransmits) {
            return new frequencyPair() {
                frequencyShoreStationTransmits = frequencyShoreStationTransmits
            };
        }







        /// <summary>
        /// Take all sectored lights related to this instance and convert them into one sector characteristics
        /// </summary>
        /// <param _s101name="current"></param>
        /// <param _s101name="sectors"></param>
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

                        List<colour> colours = new();
                        if (light.COLOUR != default) {
                            colours = GetColours(light.COLOUR);
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
                                    colour = colours,
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

