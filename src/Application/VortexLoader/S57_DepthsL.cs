using ArcGIS.Core.Data;
using S100FC;
using S100FC.S101.FeatureTypes;
using S100FC.S101.InformationAssociation;
using S100FC.S101.InformationTypes;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;


namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        /*
         *  curve
         *  point
         *  pointset
         *  surface
         *  
         */

        private static void S57_DepthsL(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "DepthsL";

            using var depthsl = source.OpenDataset<FeatureClass>(source.GetName("DepthsL"));
            Subtypes.Instance.RegisterSubtypes(depthsl);

            //using var plts_spatialattributel = source.OpenDataset<FeatureClass>(source.GetName("PLTS_SpatialAttributeL"));
            //using var informationtype = target.OpenDataset<Table>(target.GetName("informationType"));
            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("curve"));
            using var buffer = featureClass.CreateRowBuffer();


            using var cursor = depthsl.Search(filter, true);
            int recordCount = 0;

            var informationBinding = CreateAssociationSpatialQuality(target);

            while (cursor.MoveNext()) {

                recordCount += 1;

                var feature = (Feature)cursor.Current;

                if (feature.GetShape() is null) continue;

                var current = new DepthsL(feature);

                var spatialQualityHits = SpatialAssociations.Instance.GetSpatialAttributeL(feature.GetShape());

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;
                if (FeatureRelations.Instance.IsSlave(globalid)) {
                    continue;
                }

                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    throw new Exception("Not supported.");
                }

                var fcSubtype = current.FCSUBTYPE ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;

                switch (fcSubtype) {
                    case 5: { // DEPCNT_DepthContour
                            var instance = new DepthContour {
                                valueOfDepthContour = default,
                            };

                            if (current.VALDCO.HasValue) {
                                instance.valueOfDepthContour = current.VALDCO.Value;
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                var scamin = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                if (scamin.HasValue)
                                    instance.scaleMinimum = scamin.Value;
                            }

                            /*
                               QUAPOS = 1 (surveyed) -> will not be converted
                               QUAPOS = 2 (unsurveyed) -> will not be converted
                               QUAPOS = 3 (inadequately surveyed) -> quality of horizontal measurement = 4 (approximate)
                               QUAPOS = 4 (approximate) -> quality of horizontal measurement = 4 (approximate)
                               QUAPOS = 5 (position doubtful) -> quality of horizontal measurement = 5 (position doubtful)
                               QUAPOS = 6 (unreliable) -> quality of horizontal measurement = 4 (approximate)
                               QUAPOS = 7 (reported (not surveyed)) -> quality of horizontal measurement = 4 (approximate)
                               QUAPOS = 8 (reported (not confirmed)) -> quality of horizontal measurement = 4 (approximate)
                               QUAPOS = 9 (estimated) -> quality of horizontal measurement = 4 (approximate)
                               QUAPOS = 10 (precisely known) -> will not be converted
                               QUAPOS = 11 (calculated) -> quality of horizontal measurement = 4 (approximate)

                            */


                            // TODO: handle spatial quality spatial relation

                            //if (current.SHAPE != null) {
                            //    foreach (var spatialAttributeL in SelectIn<PLTS_SpatialAttributeL>(current.SHAPE, plts_spatialattributel)) {
                            //        var p_quapos = spatialAttributeL.P_QUAPOS ?? default;
                            //        if (p_quapos != default && p_quapos == 4) {
                            //            var spatialQuality = new SpatialQuality() {
                            //                qualityOfHorizontalMeasurement = qualityOfHorizontalMeasurement.Approximate,
                            //                //spatialAccuracy = new List<DomainModel.ComplexAttributes.spatialAccuracy>() {
                            //                //new DomainModel.ComplexAttributes.spatialAccuracy() {
                            //                //    horizontalPositionUncertainty = default,
                            //                //    fixedDateRange = default,
                            //                //    verticalUncertainty = new DomainModel.ComplexAttributes.verticalUncertainty() {
                            //                //        uncertaintyFixed = default,
                            //                //        uncertaintyVariableFactor = default
                            //                //    }
                            //                //}
                            //            //}
                            //            };

                            //            using var information = informationtype.CreateRowBuffer();
                            //            information["ps"] = ps101;
                            //            information["code"] = spatialQuality.GetType().Name;
                            //            information["json"] = System.Text.Json.JsonSerializer.Serialize(spatialQuality);
                            //            //information["shape"] = spatialAttributeL.SHAPE;

                            //            using var _ = informationtype.CreateRow(information);

                            //        }
                            //    }
                            //}

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            ImporterNIS.SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedLineEquipment(current, instance, featureN);
                            }

                            // Spatial Quality
                            if (spatialQualityHits.Count > 0) {

                                buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), ImporterNIS.jsonSerializerOptions);
                                featureN.Store();


                                //foreach (var spatialQuality in spatialQualityHits) {
                                //    // create spatial quality
                                //    SpatialQuality spatialQuality101 = new SpatialQuality();

                                //    spatialQuality101.qualityOfHorizontalMeasurement = EnumHelper.GetEnumValue<qualityOfHorizontalMeasurement>(spatialQuality.qualityOfPrecision);

                                //    bufferInformationType["ps"] = ps101;
                                //    bufferInformationType["code"] = spatialQuality101.Code;
                                //    bufferInformationType["json"] = System.Text.Json.JsonSerializer.Serialize(spatialQuality101, jsonSerializerOptions);

                                //    var informationTypeRow = informationTypeTable.CreateRow(bufferInformationType);
                                //    var informationName = Convert.ToString(informationTypeRow["name"]);

                                //    // create Association

                                //    var informationAssociationBuffer = informationassociationTable.CreateRowBuffer();

                                //    informationAssociationBuffer["ps"] = ImporterNIS.ps101;
                                //    informationAssociationBuffer["code"] = "association";

                                //    var association = informationassociationTable.CreateRow(informationAssociationBuffer);
                                //    var informationAssociationName = $"{association.Crc32()}";

                                //    // create binding
                                //    var informationBinding = new informationBinding {
                                //        informationId = informationName,
                                //        associationId = informationAssociationName,
                                //        association = nameof(SpatialAssociation),
                                //        role = Enum.GetName<Role>(Role.theQualityInformation)!,
                                //        roleType = roleType.association.ToString()
                                //    };

                                //    buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(informationBinding);
                                //    featureN.Store();
                                //}
                            }


                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);


                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

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

        private static List<informationBinding<SpatialAssociation>> CreateAssociationSpatialQuality(Geodatabase target) {
            // create spatial quality
            SpatialQuality spatialQuality101 = new SpatialQuality();

            using var informationTypeTable = target.OpenDataset<Table>(target.GetName("informationtype"));
            using var buffer = informationTypeTable.CreateRowBuffer();

            spatialQuality101.qualityOfHorizontalMeasurement = EnumHelper.GetEnumValue(4);

            buffer["ps"] = ps101;
            buffer["code"] = spatialQuality101.S100FC_code;

            buffer["flatten"] = spatialQuality101.Flatten();

            var informationTypeRow = informationTypeTable.CreateRow(buffer);
            var informationName = informationTypeRow.UID();

            // create binding
            var informationBinding = new informationBinding<SpatialAssociation> {
                informationId = informationName,
                informationType = nameof(SpatialQuality),
                role = "theQualityInformation",
                roleType = "association",
            };

            return /*informationAssociationName, spatialQuality101,*/ [informationBinding];


        }




    }
}

