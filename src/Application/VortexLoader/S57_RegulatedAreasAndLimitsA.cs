using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_RegulatedAreasAndLimitsA(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "RegulatedAreasAndLimitsA";
            

            using var featureclass = target.OpenDataset<FeatureClass>(LayerDefinitions.GetName("surface"));

            using var regulatedAreasAndLimitsA = source.OpenDataset<FeatureClass>(tableName);

            int recordCount = 0;
            int convertedCount = 0;

            using var buffer = featureclass.CreateRowBuffer();
            using var insert = featureclass.CreateInsertCursor();

            using var cursor = regulatedAreasAndLimitsA.Search(filter, true);

            while (cursor.MoveNext()) {
                recordCount += 1;
                var feature = (Feature)cursor.Current;
                var current = new RegulatedAreasAndLimitsA(feature); // (Row)cursor.Current;

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;
                var subtype = current.FCSUBTYPE ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;
                var status = current.STATUS ?? default;
                var verlen = current.VERLEN ?? default;

                switch (subtype) {
                    case 1: { // ACHARE_AnchorageArea
                            var instance = new AnchorageArea();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 5: { // ACHBRT_AnchorBerth
                            var instance = new AnchorBerth();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 10: { // ADMARE_AdministrationAreaNamed
                            var instance = new AdministrationArea();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 15: { // ARCSLN_ArchipelagicSeaLane
                            var instance = new ArchipelagicSeaLane();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 20: { // CONZNE_ContiguousZone
                            var instance = new ContiguousZone();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            
                            
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 25: { // COSARE_ContinentalShelfArea
                            var instance = new ContinentalShelfArea();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 30: { // CTSARE_CargoTranshipmentArea
                            var instance = new CargoTranshipmentArea();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 35: { // CUSZNE_CustomZone
                            var instance = new CustomZone();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            
                            //AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 40: { // DMPGRD_DumpingGround
                            var instance = new DumpingGround();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 50: { // EXEZNE_ExclusiveEconomicZone
                            var instance = new ExclusiveEconomicZone();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            
                            
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 55: { // FRPARE_FreePortArea
                            var instance = new FreePortArea();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 60: { // FSHGRD_FishingGround
                            var instance = new FishingGround();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 65: { // FSHZNE_FisheryZone
                            var instance = new FisheryZone();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 70: { // HRBARE_HarbourAreaAdministrative
                            var instance = new HarbourAreaAdministrative();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 75: { // ICNARE_IncinerationArea
                            //The S-57 Object class ICNARE will not be converted. 
                            //https://iho.int/uploads/user/pubs/standards/s-65/S-65%20Annex%20B_Ed%201.2.0_Final.pdf
                            convertedCount++;
                        }
                        break;
                    case 85: { // LOGPON_LogPond
                            var instance = new LogPond();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 95: { // MARCUL_MarineFarmCulture
                            var instance = new MarineFarmCulture();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 105: { // RESARE_RestrictedArea
                            var instance = new RestrictedArea();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 110: { // SPLARE_SeaPlaneLandingArea
                            var instance = new SeaplaneLandingArea();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 115: { // TESARE_TerritorialSeaArea
                            var instance = new TerritorialSeaArea();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            
                            //AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
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




