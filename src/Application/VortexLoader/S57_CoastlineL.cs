using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.Applications.Singletons;

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
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = coastlinel.Search(filter, true);
            int recordCount = 0;
            
            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new CoastlineL(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;

                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    continue;
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

                            if (catcoa != default) {
                                natureOfSurface? e = catcoa switch {
                                    3 => natureOfSurface.Sand,
                                    4 => natureOfSurface.Stone,
                                    5 => natureOfSurface.Pebbles,
                                    9 => natureOfSurface.Coral,
                                    11 => natureOfSurface.Shells,
                                    -32767 =>(natureOfSurface)(-1),
                                    _ => null //lthrow new IndexOutOfRangeException($"catcoa to natureOfSurface: {catcoa}")
                                };  
                                if (e.HasValue) {
                                    instance.natureOfSurface = [e.Value];

                                }
                            }

                            if (catcoa != default && instance.natureOfSurface == default) {
                                categoryOfCoastline? e = catcoa switch {
                                    1 => categoryOfCoastline.SteepCoast,
                                    2 => categoryOfCoastline.FlatCoast,
                                    //3 => categoryOfCoastline.., // SANDY SHORE
                                    //4 => categoryOfCoastline., // STONY SHORE
                                    //5 => categoryOfCoastline., // SHINGLY SHORE
                                    6 => categoryOfCoastline.GlacierSeawardEnd,
                                    7 => categoryOfCoastline.Mangrove,
                                    8 => categoryOfCoastline.MarshyShore,
                                    //9 => categoryOfCoastline., //CORAL REEF
                                    //10 => categoryOfCoastline, // ICE COAST
                                    //11 => categoryOfCoastline, // SHELLY SHORE
                                    -32767 =>(categoryOfCoastline)(-1),
                                    _ => throw new IndexOutOfRangeException($"catcoa to categoryOfCoastLine: {catcoa}")
                                };
                                if (e.HasValue) {
                                    instance.categoryOfCoastline = e.Value;
                                }
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }


                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedLineEquipment(current, instance, name, target, source);
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
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }


                            if (current.CATSLC.HasValue) {
                                instance.categoryOfShorelineConstruction = EnumHelper.GetEnumValue<categoryOfShorelineConstruction>(current.CATSLC.Value);
                            };

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

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedLineEquipment(current, instance, name, target, source);
                            }


                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

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
