using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_CoastlineL(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "CoastlineL";

            using var coastlinel = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            Subtypes.Instance.RegisterSubtypes(coastlinel); ;

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("curve"));


            using var buffer = featureClass.CreateRowBuffer();
            

            using var cursor = coastlinel.Search(filter, true);
            int recordCount = 0;

            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new CoastlineL(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;

                if (FeatureRelations.Instance.IsSlave(globalid)) {
                    continue;
                }

                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    throw new Exception("Ups. Not supported");
                }



                var fcSubtype = current.FCSUBTYPE ?? default;
                var watlev = current.WATLEV ?? default;

                var catcoa = current.CATCOA ?? default;
                var catslc = current.CATSLC ?? default;


                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;
                var status = current.STATUS ?? default;

                switch (fcSubtype) {
                    case 1: { // COALNE_Coastline
                            var instance = new Coastline();

                            if (catcoa != default/* && instance.natureOfSurface == default*/) {
                                categoryOfCoastline? e = catcoa switch {
                                    1 => categoryOfCoastline.SteepCoast,
                                    2 => categoryOfCoastline.FlatCoast,
                                    3 => null, // SANDY SHORE
                                    4 => null, // STONY SHORE
                                    5 => null, // SHINGLY SHORE
                                    6 => categoryOfCoastline.GlacierSeawardEnd,
                                    7 => categoryOfCoastline.Mangrove,
                                    8 => categoryOfCoastline.MarshyShore,
                                    9 => null, //CORAL REEF
                                    10 => null, // ICE COAST
                                    11 => null, // SHELLY SHORE
                                    -32767 => (categoryOfCoastline)(-1),
                                    _ => throw new IndexOutOfRangeException($"catcoa to categoryOfCoastLine: {catcoa}")
                                };
                                if (e.HasValue) {
                                    instance.categoryOfCoastline = e.Value;
                                }
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours<Coastline>(current.COLOUR);
                            }

                            if (current.ELEVAT.HasValue) {
                                instance.elevation = current.ELEVAT.Value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            /*
                                • The attribute nature of surface has been included as an allowable attribute for Coastline in S-101.
                                During the automated conversion process, the following COALNE/CATCOA encoding instances will
                                be converted to the corresponding Coastline/nature of surface instances.
                                CATCOA = 3 (sandy shore) -> nature of surface = 4 (sand)
                                CATCOA = 4 (stony shore) -> nature of surface = 5 (stone)
                                CATCOA = 5 (shingly shore) -> nature of surface = 7 (pebbles)
                                CATCOA = 9 (coral reef) -> nature of surface = 14 (coral)
                                CATCOA = 11 (shelly shore) -> nature of surface = 17 (shells)
                            */
                            if (catcoa != default) {
                                natureOfSurface? e = catcoa switch {
                                    3 => natureOfSurface.Sand,
                                    4 => natureOfSurface.Stone,
                                    5 => natureOfSurface.Pebbles,
                                    9 => natureOfSurface.Coral,
                                    11 => natureOfSurface.Shells,
                                    -32767 => (natureOfSurface)(-1),
                                    _ => null //lthrow new IndexOutOfRangeException($"catcoa to natureOfSurface: {catcoa}")
                                };
                                if (e.HasValue) {
                                    instance.natureOfSurface = [e.Value];

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                instance.visualProminence = EnumHelper.GetEnumValue<Coastline, visualProminence>(current.CONVIS.Value);
                            }

                            AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            ImporterNIS.SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = $"{featureN.Crc32}";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedLineEquipment(current, instance, featureN);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;
                    case
                    5: { // SLCONS_ShorelineConstruction
                            // Restricted allowable S-101 enumerate values for STATUS.
                            // Reconcile conversion of CATSLC = 6(wharf(quay)) to
                            // category of shoreline construction = 6(wharf) or 22
                            // (quay).

                            var instance = new ShorelineConstruction();

                            if (current.CATSLC.HasValue) {
                                instance.categoryOfShorelineConstruction = EnumHelper.GetEnumValue<ShorelineConstruction, categoryOfShorelineConstruction>(current.CATSLC.Value);
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours<ShorelineConstruction>(current.COLOUR);
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

                            var horclr = current.HORCLR ?? default;
                            var horacc = current.HORACC ?? default;

                            if (horclr != default) {
                                instance.horizontalClearanceFixed = new() {
                                    horizontalClearanceValue = horclr,
                                    horizontalDistanceUncertainty = horacc,
                                };
                            }

                            if (current.HORLEN.HasValue) {
                                instance.horizontalLength = current.HORLEN.Value;
                            }

                            if (current.HORWID.HasValue) {
                                instance.horizontalWidth = current.HORWID.Value;
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<ShorelineConstruction, natureOfConstruction>(current.NATCON);
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
                                instance.visualProminence = EnumHelper.GetEnumValue<ShorelineConstruction, visualProminence>(current.CONVIS.Value);
                            }

                            if (current.WATLEV.HasValue) {
                                if (current.WATLEV.Value == -32767)
                                    instance.waterLevelEffect = EnumHelper.GetEnumValue<ShorelineConstruction, waterLevelEffect>(-1);
                                else {
                                    instance.waterLevelEffect = EnumHelper.GetEnumValue<ShorelineConstruction, waterLevelEffect>(current.WATLEV);
                                }
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);


                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = $"{featureN.Crc32}";

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
