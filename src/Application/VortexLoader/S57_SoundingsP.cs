using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_SoundingsP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "SoundingsP";

            using var soundingsP = source.OpenDataset<FeatureClass>(source.GetName("SoundingsP"));

            Subtypes.Instance.RegisterSubtypes(soundingsP);

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("pointset"));
            using var informationtype = target.OpenDataset<Table>(target.GetName("informationType"));

            using var bufferPointset = featureClass.CreateRowBuffer();
            using var insertCursor = featureClass.CreateInsertCursor();

            using var cursor = soundingsP.Search(filter, true);

            var recordCount = 0;

            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;
                var current = new SoundingsP(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;

                if (FeatureRelations.Instance.IsSlave(globalid)) {
                    continue;
                }

                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    throw new Exception("Ups. Not supported");
                }



                var longname = current.LNAM ?? Strings.UNKNOWN;
                var fcSubtype = current.FCSUBTYPE ?? default;
                var depth = current.DEPTH ?? default;
                var quasou = current.QUASOU ?? default;
                var quapos = current.P_QUAPOS ?? default;
                var tecsou = current.TECSOU ?? default;
                var objnam = current.OBJNAM ?? default;
                var nobjnm = current.NOBJNM ?? default;

                switch (fcSubtype) {
                    case 1:
                        var shape = current.SHAPE as MapPoint;
                        if (shape == default) {
                            Logger.Current.DataError(objectid, tableName, longname, Strings.ERR_NULL_SHAPE);
                            continue;
                        }

                        var mappoint = MapPointBuilderEx.CreateMapPoint(shape.X, shape.Y, Convert.ToDouble(depth), shape.SpatialReference);

                        SetShape(bufferPointset, MultipointBuilderEx.CreateMultipoint(mappoint));
                        SetUsageBand(bufferPointset, current.PLTS_COMP_SCALE!.Value);

                        if (quasou == default || !string.Equals(quasou, "5", StringComparison.OrdinalIgnoreCase)) {
                            var sounding = new Sounding {
                            };
                            if (quasou != default) {
                                sounding.qualityOfVerticalMeasurement = new List<qualityOfVerticalMeasurement> {
                                            (qualityOfVerticalMeasurement)Enum.Parse(typeof(qualityOfVerticalMeasurement), quasou)
                                        };
                            }
                            if (tecsou != default && !string.IsNullOrEmpty(tecsou)) {
                                sounding.techniqueOfVerticalMeasurement = new List<techniqueOfVerticalMeasurement> {
                                            (techniqueOfVerticalMeasurement)Enum.Parse(typeof(techniqueOfVerticalMeasurement), tecsou)
                                        };
                            }

                            //if (objnam != default) {

                            //    if (!string.IsNullOrEmpty(objnam.Trim())) {
                            //        sounding.featureName.Add(new featureName {
                            //            language = "eng",
                            //            nameUsage = null,
                            //            _s101name = objnam.Trim(),
                            //        });
                            //    }
                            //}
                            //if (nobjnm != default) {

                            //    if (!string.IsNullOrEmpty(nobjnm.Trim())) {
                            //        sounding.featureName.Add(new featureName {
                            //            language = "dk",
                            //            nameUsage = nameUsage.AlternateNameDisplay,
                            //            _s101name = nobjnm.Trim(),
                            //        });
                            //    }
                            //}


                            sounding.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);


                            // TODO: interoperabilityIdentifier


                            if (current.QUASOU != default) {
                                if (current.QUASOU == "-32767")
                                    sounding.qualityOfVerticalMeasurement = EnumHelper.GetEnumValues<Sounding, qualityOfVerticalMeasurement>("-1");
                                else {
                                    sounding.qualityOfVerticalMeasurement = EnumHelper.GetEnumValues<Sounding, qualityOfVerticalMeasurement>(current.QUASOU);
                                }
                            }


                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                                    sounding.reportedDate = result;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                sounding.status = ImporterNIS.GetSingleStatus(current.STATUS);
                            }

                            if (current.TECSOU != null) {
                                sounding.techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues<Sounding, techniqueOfVerticalMeasurement>(current.TECSOU);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                sounding.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            AddInformation(sounding.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);

                            bufferPointset["json"] = System.Text.Json.JsonSerializer.Serialize(sounding);
                            bufferPointset["ps"] = ps101;
                            bufferPointset["code"] = sounding.GetType().Name;
                            bufferPointset["edition"] = ImporterNIS.s101version;
                            var featureN = featureClass.CreateRow(bufferPointset);

                            var name = $"{featureN.GetGlobalID():N}";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, sounding, featureN, sounding.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(sounding));

                            // TODO: Handle Spatialquality
                            //if (quapos != default && quapos == 4) {
                            //    /*  SOUNDG with attribute QUAPOS = 4 (approximate) will also be converted to an instance of the S101 Information _s101type Spatial Quality (see S-101 DCEG clause 24.5), attribute quality of horizontal
                            //        measurement = 4 (approximate), associated to the geometry of the Sounding feature using the
                            //        association Spatial Association. */
                            //    using var information = informationtype.CreateRowBuffer();

                            //    var row = new SpatialQuality {
                            //        qualityOfHorizontalMeasurement = qualityOfHorizontalMeasurement.Approximate,
                            //    };

                            //    information["ps"] = ps101;
                            //    information["code"] = row.GetType().Name;
                            //    information["json"] = System.Text.Json.JsonSerializer.Serialize(row);
                            //    using var _ = informationtype.CreateRow(information);
                            //}
                        }
                        else {
                            /*  SOUNDG with attribute QUASOU = 5 (no bottom found at value shown) will be converted to an
                                instance of the S-101 Feature _s101type Depth – No Bottom Found. Where this is the case, the attributes
                                EXPSOU, NOBJNM, OBJNAM, SOUACC and STATUS will not be converted. It is considered that
                                these attributes are not relevant for Depth – No Bottom Found in S-101. */
                            var instance = new DepthNoBottomFound();

                            // TODO: interoperabilityIdentifier

                            if (current.TECSOU != null) {
                                instance.techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues<DepthNoBottomFound, techniqueOfVerticalMeasurement>(current.TECSOU);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);

                            bufferPointset["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);

                            var featureN = featureClass.CreateRow(bufferPointset);
                            var name = $"{featureN.GetGlobalID():N}";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name); Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
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
