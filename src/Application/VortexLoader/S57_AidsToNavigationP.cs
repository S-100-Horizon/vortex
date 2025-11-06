using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;
using S100Framework.DomainModel.S101.FeatureTypes;
using System.ComponentModel;
using System.Globalization;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_AidsToNavigationP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "AidsToNavigationP";

            using var aidstonavigationp = source.OpenDataset<FeatureClass>(source.GetName(tableName));

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("point"));

            using var buffer = featureClass.CreateRowBuffer();


            var orgWhereClause = filter.WhereClause.Clone().ToString();

            //filter.WhereClause += " AND globalid in ('{FF531488-02BE-496F-91D5-7E6FEDCB0CD1}')";
            //filter.WhereClause += " AND globalid in ('{80125E6A-2D84-4FD2-B9C8-BEF5594FA926}', '{048BFCB0-F3B2-4075-9460-B89E1840CA03}')"; // NO SPEC FLOATING LIGHT

            using var cursor = aidstonavigationp.Search(filter, true);

            //filter.WhereClause = orgWhereClause;

            int recordCount = 0;
            var _slaves = new Dictionary<Guid, string>();

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
                    Subtypes.Instance.TryGetSubtype(tableName, current.FCSUBTYPE!.Value, out var subtype);
                    _slaves.Add(globalid, $"{tableName}::{globalid}::{subtype}");
                    continue;
                }

                switch (fcSubtype) {
                    case 1: { // BCNCAR_BeaconCardinal

                            var instance = _converterRegistry.Convert<CardinalBeacon>(current);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.Crc32();

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }
                        }
                        break;

                    case 5: { // BCNISD_BeaconIsolatedDanger
                            var instance = new IsolatedDangerBeacon {
                                beaconShape = default,
                            };

                            #region aidstonavigation

                            if (current.BCNSHP.HasValue) {
                                instance.beaconShape = EnumHelper.GetEnumValue<IsolatedDangerBeacon, beaconShape>(current.BCNSHP);
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours<IsolatedDangerBeacon>(current.COLOUR);
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
                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(double?);
                            }

                            // TODO: interoperabilityidentifier

                            if (current.MARSYS.HasValue) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<IsolatedDangerBeacon, marksNavigationalSystemOf>(current.MARSYS.Value);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<IsolatedDangerBeacon, natureOfConstruction>(current.NATCON);
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
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

                            var topmark = relatedEquipment?.GetTopMark<IsolatedDangerBeacon>(current);


                            if (topmark != null) {
                                instance.topmark = topmark;
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                instance.visualProminence = EnumHelper.GetEnumValue<IsolatedDangerBeacon, visualProminence>(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            instance.pictorialRepresentation = FixFilename(current.PICREP!);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.Crc32();


                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);

                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }
                        }
                        break;

                    case 10: { // BCNLAT_BeaconLateral
                            var instance = new LateralBeacon {
                                beaconShape = default,
                                categoryOfLateralMark = default,
                            };

                            #region aidstonavigation

                            if (current.BCNSHP.HasValue) {
                                instance.beaconShape = EnumHelper.GetEnumValue<LateralBeacon, beaconShape>(current.BCNSHP);
                            }

                            if (current.CATLAM.HasValue) {
                                instance.categoryOfLateralMark = EnumHelper.GetEnumValue<LateralBeacon, categoryOfLateralMark>(current.CATLAM.Value);
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours<LateralBeacon>(current.COLOUR);
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
                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(double?);
                            }

                            if (current.MARSYS.HasValue) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<LateralBeacon, marksNavigationalSystemOf>(current.MARSYS.Value);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<LateralBeacon, natureOfConstruction>(current.NATCON);
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
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

                            var topmark = relatedEquipment?.GetTopMark<LateralBeacon>(current);
                            if (topmark != null) {
                                instance.topmark = topmark;
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                instance.visualProminence = EnumHelper.GetEnumValue<LateralBeacon, visualProminence>(current.CONVIS.Value);
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

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.Crc32();

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }
                        }
                        break;

                    case 15: { // BCNSAW_BeaconSafeWater
                            var instance = new SafeWaterBeacon {
                                beaconShape = default,
                            };

                            #region aidstonavigation

                            if (current.BCNSHP.HasValue) {
                                instance.beaconShape = EnumHelper.GetEnumValue<SafeWaterBeacon, beaconShape>(current.BCNSHP);
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours<SafeWaterBeacon>(current.COLOUR);
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
                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(double?);
                            }

                            // TODO: interoperabilityidentifier

                            if (current.MARSYS.HasValue) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<SafeWaterBeacon, marksNavigationalSystemOf>(current.MARSYS.Value);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<SafeWaterBeacon, natureOfConstruction>(current.NATCON);
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
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

                            var topmark = relatedEquipment?.GetTopMark<SafeWaterBeacon>(current);
                            if (topmark != null) {
                                instance.topmark = topmark;
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                instance.visualProminence = EnumHelper.GetEnumValue<SafeWaterBeacon, visualProminence>(current.CONVIS.Value);
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

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.Crc32();

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }
                        }
                        break;

                    case 20: { // BCNSPP_BeaconSpecialPurpose
                            var instance = new SpecialPurposeGeneralBeacon {
                                beaconShape = default,
                            };

                            #region aidstonavigation

                            if (current.BCNSHP.HasValue) {
                                instance.beaconShape = EnumHelper.GetEnumValue<SpecialPurposeGeneralBeacon, beaconShape>(current.BCNSHP);
                            }

                            if (current.CATSPM != default) {
                                instance.categoryOfSpecialPurposeMark = EnumHelper.GetEnumValues<SpecialPurposeGeneralBeacon, categoryOfSpecialPurposeMark>(current.CATSPM);
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours<SpecialPurposeGeneralBeacon>(current.COLOUR);
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
                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(double?);
                            }

                            // TODO: interoperabilityidentifier

                            if (current.MARSYS.HasValue) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<SpecialPurposeGeneralBeacon, marksNavigationalSystemOf>(current.MARSYS.Value);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<SpecialPurposeGeneralBeacon, natureOfConstruction>(current.NATCON);
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
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

                            var topmark = relatedEquipment?.GetTopMark<SpecialPurposeGeneralBeacon>(current);
                            if (topmark != null) {
                                instance.topmark = topmark;
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                instance.visualProminence = EnumHelper.GetEnumValue<SpecialPurposeGeneralBeacon, visualProminence>(current.CONVIS.Value);
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

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.Crc32();

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }
                        }
                        break;

                    case 25: { // BOYCAR_BuoyCardinal
                            var instance = new CardinalBuoy {
                                buoyShape = default,
                                categoryOfCardinalMark = default,
                            };

                            #region aidstonavigation

                            if (current.BOYSHP.HasValue) {
                                instance.buoyShape = EnumHelper.GetEnumValue<CardinalBuoy, buoyShape>(current.BOYSHP);
                            }

                            if (current.CATCAM.HasValue) {
                                instance.categoryOfCardinalMark = EnumHelper.GetEnumValue<CardinalBuoy, categoryOfCardinalMark>(current.CATCAM.Value);
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours<CardinalBuoy>(current.COLOUR);
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
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<CardinalBuoy, marksNavigationalSystemOf>(current.MARSYS.Value);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<CardinalBuoy, natureOfConstruction>(current.NATCON);
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

                            var topmark = relatedEquipment?.GetTopMark<CardinalBuoy>(current);
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

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }


                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.Crc32();

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }
                        }
                        break;

                    case 30: { // BOYINB_BuoyInstallation
                            var instance = new InstallationBuoy {
                                buoyShape = default,
                            };

                            #region aidstonavigation

                            if (current.BOYSHP.HasValue) {
                                instance.buoyShape = EnumHelper.GetEnumValue<InstallationBuoy, buoyShape>(current.BOYSHP);
                            }

                            if (current.CATINB.HasValue) {
                                instance.categoryOfInstallationBuoy = EnumHelper.GetEnumValue<InstallationBuoy, categoryOfInstallationBuoy>(current.CATINB.Value);
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours<InstallationBuoy>(current.COLOUR);
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
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<InstallationBuoy, natureOfConstruction>(current.NATCON);
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.PRODCT != default) {
                                instance.product = EnumHelper.GetEnumValues<InstallationBuoy, product>(current.PRODCT);
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                instance.visualProminence = EnumHelper.GetEnumValue<InstallationBuoy, visualProminence>(current.CONVIS.Value);
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

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.Crc32();

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }
                        }
                        break;

                    case 35: { // BOYISD_BuoyIsolatedDanger
                            var instance = new IsolatedDangerBuoy {
                                buoyShape = default,
                            };

                            #region aidstonavigation

                            if (current.BOYSHP.HasValue) {
                                instance.buoyShape = EnumHelper.GetEnumValue<IsolatedDangerBuoy, buoyShape>(current.BOYSHP);
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours<IsolatedDangerBuoy>(current.COLOUR);
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
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<IsolatedDangerBuoy, marksNavigationalSystemOf>(current.MARSYS.Value);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<IsolatedDangerBuoy, natureOfConstruction>(current.NATCON);
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

                            var topmark = relatedEquipment?.GetTopMark<IsolatedDangerBuoy>(current);
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

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }


                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.Crc32();

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }
                        }
                        break;

                    case 40: { // BOYLAT_BuoyLateral
                            var instance = new LateralBuoy {
                                buoyShape = default,
                                categoryOfLateralMark = default,
                            };

                            #region aidstonavigation

                            if (current.BOYSHP.HasValue) {
                                instance.buoyShape = EnumHelper.GetEnumValue<LateralBuoy, buoyShape>(current.BOYSHP);
                            }

                            if (current.CATLAM.HasValue) {
                                instance.categoryOfLateralMark = EnumHelper.GetEnumValue<LateralBuoy, categoryOfLateralMark>(current.CATLAM.Value);
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours<LateralBuoy>(current.COLOUR);
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
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<LateralBuoy, marksNavigationalSystemOf>(current.MARSYS.Value);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<LateralBuoy, natureOfConstruction>(current.NATCON);
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

                            var topmark = relatedEquipment?.GetTopMark<LateralBuoy>(current);
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

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }


                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.Crc32();

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }
                        }
                        break;

                    case 45: { // BOYSAW_BuoySafeWater
                            var instance = new SafeWaterBuoy {
                                buoyShape = default,
                            };

                            #region aidstonavigation

                            if (current.BOYSHP.HasValue) {
                                instance.buoyShape = EnumHelper.GetEnumValue<SafeWaterBuoy, buoyShape>(current.BOYSHP);
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours<SafeWaterBuoy>(current.COLOUR);
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
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<SafeWaterBuoy, marksNavigationalSystemOf>(current.MARSYS.Value);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<SafeWaterBuoy, natureOfConstruction>(current.NATCON);
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

                            var topmark = relatedEquipment?.GetTopMark<SafeWaterBuoy>(current);
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

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }


                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.Crc32();

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (relatedEquipment != null) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }
                        }
                        break;

                    case 50: { // BOYSPP_BuoySpecialPurpose
                            {
                                /*
                                    Instances of BOYSPP having attributes CATSPM = 27, COLOUR = 5,6 or 6,5 and COLPAT = 2 will
                                    be converted to an instance of Emergency Wreck Marking Buoy (see clause 12.4.1.1).                               
                                 */
                                if (current.CATSPM is not null && current.CATSPM.Contains("27")) {
                                    if ((current.COLOUR == "5,6" || current.COLOUR == "6,5") && current.COLPAT == "2") {
                                        var instance = new EmergencyWreckMarkingBuoy {
                                            buoyShape = default,
                                        };

                                        #region aidstonavigation

                                        if (current.BOYSHP.HasValue) {
                                            instance.buoyShape = EnumHelper.GetEnumValue<SpecialPurposeGeneralBuoy, buoyShape>(current.BOYSHP);
                                        }

                                        if (current.COLOUR != default) {
                                            instance.colour = EnumHelper.GetEnumValues<SpecialPurposeGeneralBuoy, colour>(current.COLOUR);
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
                                            instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<SpecialPurposeGeneralBuoy, marksNavigationalSystemOf>(current.MARSYS.Value);
                                        }

                                        if (current.NATCON != default) {
                                            instance.natureOfConstruction = EnumHelper.GetEnumValues<SpecialPurposeGeneralBuoy, natureOfConstruction>(current.NATCON);
                                        }

                                        if (current.CONRAD.HasValue) {
                                            instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                                        }

                                        var topmark = relatedEquipment?.GetTopMark<SpecialPurposeGeneralBuoy>(current);
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

                                            instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                        }

                                        instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                                        instance.pictorialRepresentation = FixFilename(current.PICREP!);

                                        buffer["ps"] = ps101;
                                        buffer["code"] = instance.GetType().Name;
                                        buffer["edition"] = ImporterNIS.s101version;
                                        buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                        buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                                        SetShape(buffer, current.SHAPE);
                                        SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                        var featureN = featureClass.CreateRow(buffer);
                                        var name = featureN.Crc32();

                                        ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                                        Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                                        #endregion aidstonavigation

                                        if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                            relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                                        }

                                    }
                                    continue;
                                }
                            }
                            {
                                var instance = new SpecialPurposeGeneralBuoy {
                                    buoyShape = default,
                                };

                                #region aidstonavigation

                                if (current.BOYSHP.HasValue) {
                                    instance.buoyShape = EnumHelper.GetEnumValue<SpecialPurposeGeneralBuoy, buoyShape>(current.BOYSHP);
                                }

                                if (current.CATSPM != default) {


                                    var catspms = current.CATSPM.Split(',');

                                    if (catspms.Contains("13")) {
                                        catspms = catspms.Where(e => e != "13").ToArray();
                                        Logger.Current.DataError(current.OBJECTID ?? -1, current.TableName!, current.LNAM ?? "Unknown LNAM", "Cannot convert CATSPM = 13 privately maintained. Not converted.");
                                    }

                                    instance.categoryOfSpecialPurposeMark = EnumHelper.GetEnumValues<SpecialPurposeGeneralBuoy, categoryOfSpecialPurposeMark>(string.Join(",", catspms));
                                }

                                if (current.COLOUR != default) {
                                    instance.colour = EnumHelper.GetEnumValues<SpecialPurposeGeneralBuoy, colour>(current.COLOUR);
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
                                    instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<SpecialPurposeGeneralBuoy, marksNavigationalSystemOf>(current.MARSYS.Value);
                                }

                                if (current.NATCON != default) {
                                    instance.natureOfConstruction = EnumHelper.GetEnumValues<SpecialPurposeGeneralBuoy, natureOfConstruction>(current.NATCON);
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

                                var topmark = relatedEquipment?.GetTopMark<SpecialPurposeGeneralBuoy>(current);
                                if (topmark != null) {
                                    instance.topmark = topmark;
                                }

                                if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                    string subtype = "";

                                    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                    instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                }


                                instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                                instance.pictorialRepresentation = FixFilename(current.PICREP!);

                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["edition"] = ImporterNIS.s101version;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                                SetShape(buffer, current.SHAPE);
                                SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = featureN.Crc32();

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                                Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                                #endregion aidstonavigation

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                                }
                            }
                        }
                        break;

                    case 55: { // DAYMAR_Daymark // SLAVE RIND: 2
                            var instance = ImporterNIS._converterRegistry.Convert<Daymark>(current);
                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.Crc32();

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);

                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }
                        }
                        break;

                    case 60: { // FOGSIG_FogSignal // SLAVE RIND: 2
                            //https://geodatastyrelsen.atlassian.net/wiki/spaces/SOEKORT/pages/4404478463/S-65+Annex+B+Appendix+A+-+Impact+analysis
                            //We have one TOPMAR at the same location as a FOGSIG(in three scale bands).We need to add topmark shape in fog signal INFORM.
                            //We do not have in the database information regarding “Radio Activated” nor “Call Activated”. We do have one instance of “On request”. What does this refer to??
                            var instance = _converterRegistry.Convert<FogSignal>(current);

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.Crc32();

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
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

                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["edition"] = ImporterNIS.s101version;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                                SetShape(buffer, current.SHAPE);
                                SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var structureName = featureN.Crc32();
                                if (structureName == null) {
                                    throw new NotSupportedException("empty structure name");
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, structureName);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            }
                            else if (FeatureRelations.Instance.GetS101CatlitTypeFrom(current) == typeof(LightAirObstruction)) {
                                var instance = ImporterNIS._converterRegistry.Convert<LightAirObstruction>(current); //CreateLightAirObstruction(current);

                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["edition"] = ImporterNIS.s101version;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                                SetShape(buffer, current.SHAPE);
                                SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var structureName = featureN.Crc32();

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, structureName ?? "Unknown structure name");
                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            }
                            else if (FeatureRelations.Instance.GetS101CatlitTypeFrom(current) == typeof(LightFogDetector)) {
                                var instance = ImporterNIS._converterRegistry.Convert<LightFogDetector>(current); // new List<AidsToNavigationP>() { current }); // var instance = CreateLightFogDetector(current);

                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["edition"] = ImporterNIS.s101version;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                                SetShape(buffer, current.SHAPE);
                                SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var structureName = featureN.Crc32();

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, structureName ?? "Unknown structure name");
                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            }
                            else if (FeatureRelations.Instance.GetS101CatlitTypeFrom(current) == typeof(LightAllAround)) {
                                var instance = ImporterNIS._converterRegistry.Convert<LightAllAround>(current);

                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["edition"] = ImporterNIS.s101version;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                                SetShape(buffer, current.SHAPE);
                                SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var structureName = featureN.Crc32();

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
                                instance.colour = EnumHelper.GetEnumValues<LightFloat, colour>(current.COLOUR);
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
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<LightFloat, natureOfConstruction>(current.NATCON);
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

                            var topmark = relatedEquipment?.GetTopMark<LightFloat>(current);
                            if (topmark != null) {
                                instance.topmark = topmark;
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN;
                            }

                            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                instance.visualProminence = EnumHelper.GetEnumValue<LightFloat, visualProminence>(current.CONVIS.Value);
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

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.Crc32();

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }
                        }
                        break;

                    case 75: { // LITVES_LightVessel
                            var instance = new LightVessel();

                            #region aidstonavigation

                            if (current.COLOUR != default) {
                                instance.colour = EnumHelper.GetEnumValues<LightVessel, colour>(current.COLOUR);
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
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<LightVessel, natureOfConstruction>(current.NATCON);
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
                                instance.visualProminence = EnumHelper.GetEnumValue<LightVessel, visualProminence>(current.CONVIS.Value);
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

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.Crc32();

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
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
                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(double?);
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

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }


                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.Crc32();

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            #endregion aidstonavigation

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }
                        }
                        break;

                    case 90: { // RADSTA_RadarStation  // SLAVE RIND: 2
                            var instance = _converterRegistry.Convert<RadarStation>(current);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.Crc32();

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }
                        }
                        break;

                    case 95: { // RDOSTA_RadioStation // SLAVE RIND: 2
                            var instance = _converterRegistry.Convert<RadioStation>(current);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.Crc32();

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                        }
                        break;

                    case 100: { // RETRFL_RetroReflector // SLAVE RIND: 2
                            var instance = _converterRegistry.Convert<Retroreflector>(current);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.Crc32();

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID(), name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }
                        }
                        break;

                    case 105: { // RTPBCN_RadarTransponderBeacon // SLAVE RIND: 2
                            var instance = _converterRegistry.Convert<RadarTransponderBeacon>(current);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = instance.GetInformationBindings() == null ? DBNull.Value : System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.Crc32();

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
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
                    Logger.Current.DataError(-1, tableName, "These slaves are missing the structure and therefore not converted.", $"{_slaves[slaveId]}");
                }
            }
        }

        internal static bool TryGetRadarWaveLengths(string radwal, out List<radarWaveLength> radarWaveLengths) {
            radarWaveLengths = new List<radarWaveLength>();

            string[] parts = radwal.Split(',');
            foreach (var part in parts) {
                string[] split = part.Split('-');
                if (split.Length == 2) {
                    if (double.TryParse(split[0], CultureInfo.InvariantCulture, out double waveLength)) {
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
        internal static List<sectorCharacteristics> GetSectorCharacteristics<TType>(IList<AidsToNavigationP> lights) where TType : DomainModel.FeatureNode {
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
                var rhythmofLightValue = GetRythmOfLight<TType>(light);
                if ((light.SECTR1 != null && light.SECTR2 != null) || light.CATLIT == "1") {
                    {
                        List<lightVisibility> visibility = new List<lightVisibility>();

                        if (light.LITVIS != null) {
                            visibility = EnumHelper.GetEnumValues<lightSector, lightVisibility>(light.LITVIS);
                        }

                        List<colour> colours = new();
                        if (light.COLOUR != default) {
                            colours = GetColours<lightSector>(light.COLOUR);
                        }

                        //if (light.SECTR1 != null && light.SECTR2 != null) { 
                        var sectorCharacteristic = new sectorCharacteristics() {
                            lightCharacteristic = rhythmofLightValue.lightCharacteristic,
                            signalGroup = rhythmofLightValue.signalGroup,
                            signalPeriod = rhythmofLightValue.signalPeriod,
                            signalSequence = rhythmofLightValue.signalSequence,
                            lightSector = new List<lightSector>() {
                                new lightSector() {
                                    lightVisibility = visibility,
                                    valueOfNominalRange = light.VALNMR.GetValueOrDefault(),
                                    colour = colours,
                                    sectorLimit = null
                                },
                            }
                        };

                        if (light.SECTR1 != null && light.SECTR2 != null) {
                            sectorCharacteristic.lightSector[0].sectorLimit = new sectorLimit() {
                                sectorLimitOne = new sectorLimitOne() {
                                    sectorBearing = light.SECTR1.Value,
                                },
                                sectorLimitTwo = new sectorLimitTwo() {
                                    sectorBearing = light.SECTR2.Value,
                                }
                            };
                        }

                        sectorCharacteristics.Add(sectorCharacteristic);

                        //}

                    }
                    ;
                }
            }
            //}

            return sectorCharacteristics;
        }
    }
}

