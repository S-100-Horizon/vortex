using ArcGIS.Core.Data;
using VortexLoader.S57.esri;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel.S101.ComplexAttributes;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S101;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_PortsAndServicesL(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "PortsAndServicesL";

            var ps101 = "S-101";

            var portsAndServicesL = source.OpenDataset<FeatureClass>(tableName);

            using var featureClass = target.OpenDataset<FeatureClass>("curve");
            using var informationtype = target.OpenDataset<Table>("informationtype");

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = portsAndServicesL.Search(filter, true);
            int recordCount = 0;
            int convertedCount = 0;
            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new PortsAndServicesL(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;
                var subtype = current.FCSUBTYPE ?? default;
                var watlev = current.WATLEV ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;
                var status = current.STATUS ?? default;



                // The attribute default clearance depth must be populated with a value, which must not be an empty(null)
                // value, only if the attribute value of sounding for the feature instance is populated with an empty(null) value
                // and the attribute height, if an allowable attribute for the feature, is not populated.
                // S-101 Annex A_DCEG Edition 1.5.0_Draft for Edition 2.0.0.pdf: p.771
                //Decimal defaultClearanceDepth = -32767;

                switch (subtype) {
                    case 1: { // BERTHS_Berth
                            var instance = new Berth() {
                            };
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
                    case 5: { // CANALS_Canal
                            var instance = new Canal() {
                            };
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
                    case 10: { // CAUSWY_Causeway
                            var instance = new Causeway() {
                            };
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
                    case 15: { // DYKCON_Dyke
                            var instance = new Dyke() {
                            };
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
                    case 20: { // FLODOC_FloatingDock
                            var instance = new FloatingDock() {
                            };
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
                    case 25: { // GATCON_Gate
                            var instance = new Gate() {
                            };
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
                    case 30: { // MORFAC_MooringWarpingFacility
                            // https://iho.int/uploads/user/pubs/standards/s-65/S-65%20Annex%20B_Ed%201.2.0_Final.pdf p25
                            var catmor = current.CATMOR ?? default;

                            // DOLPHIN
                            if (catmor == 1 || catmor == 2) {
                                var instance = new Dolphin();
                                if (plts_comp_scale != default) {
                                    instance.scaleMinimum = plts_comp_scale;
                                }

                                if (catmor != default) {
                                    instance.categoryOfDolphin = catmor switch {
                                        1 => new List<categoryOfDolphin>() { categoryOfDolphin.MooringDolphin },
                                        2 => new List<categoryOfDolphin>() { categoryOfDolphin.DeviationDolphin },
                                        -32767 => new List<categoryOfDolphin>() { (categoryOfDolphin)(-32767) },
                                        // TODO: QUESTION: how to handle -32767 on a required attribute without an S-101 equivalent "unknown". Illegal value assigned. MUST be fixed.
                                        _ => throw new IndexOutOfRangeException(),
                                    };
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

                            // BOLLARD
                            if (catmor == 3) {
                                var instance = new Bollard();

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

                            // SHORELINECONSTRUCTION
                            if (catmor == 4) {
                                var instance = new ShorelineConstruction();

                                if (plts_comp_scale != default) {
                                    instance.scaleMinimum = plts_comp_scale;
                                }

                                instance.categoryOfShorelineConstruction = categoryOfShorelineConstruction.TieUpWall;
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

                            // PILE
                            if (catmor == 5) {
                                var instance = new Pile();

                                if (plts_comp_scale != default) {
                                    instance.scaleMinimum = plts_comp_scale;
                                }

                                instance.categoryOfPile = categoryOfPile.MooringPost;
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

                            // CABLESUBMARINE
                            if (catmor == 6) {
                                var instance = new CableSubmarine();

                                if (plts_comp_scale != default) {
                                    instance.scaleMinimum = plts_comp_scale;
                                }

                                instance.categoryOfCable = categoryOfCable.JunctionCable;
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

                            // MOORING BUOY
                            if (catmor == 7) {
                                var instance = new MooringBuoy();

                                if (plts_comp_scale != default) {
                                    instance.scaleMinimum = plts_comp_scale;
                                }

                                if (current.BOYSHP == default) {
                                    instance.buoyShape = buoyShape.Spherical;
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
                        }
                        break;
                    case 35: { // PONTON_Pontoon
                            var instance = new Pontoon() {
                            };
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
