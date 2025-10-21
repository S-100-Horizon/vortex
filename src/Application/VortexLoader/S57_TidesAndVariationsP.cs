using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_TidesAndVariationsP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "TidesAndVariationsP";

            using var tidesAndVariationsP = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            Subtypes.Instance.RegisterSubtypes(tidesAndVariationsP);

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("point"));

            using var buffer = featureClass.CreateRowBuffer();

            using var cursor = tidesAndVariationsP.Search(filter, true);
            int recordCount = 0;

            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new TidesAndVariationsP(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;

                if (FeatureRelations.Instance.IsSlave(globalid)) {
                    continue;
                }

                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    throw new Exception("Ups. Not supported");
                }



                var fcSubtype = current.FCSUBTYPE ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;
                var status = current.STATUS ?? default;

                switch (fcSubtype) {
                    case 5: { // LOCMAG_LocalMagneticAnomaly
                            throw new NotImplementedException("No LOCMAG_LocalMagneticAnomaly in DK | GL NIS");
                        }

                    case 10: { // MAGVAR_MagneticVariation
                            var instance = new MagneticVariation {
                                referenceYearForMagneticVariation = default,
                                valueOfAnnualChangeInMagneticVariation = default,
                                valueOfMagneticVariation = default,
                            };

                            // TODO: interoperabilityIdentifier

                            /*  27.152 reference year for magnetic variation (RYRMGV)
                                IHO Definition: REFERENCE YEAR FOR MAGNETIC VARIATION. The reference calendar year for magnetic
                                variation values. (S-57 Edition 3.1, Appendix A – Chapter 2, Page 2.176, November 2000).
                                Attribute Type: Truncated date
                                Unit: Four digit year indication (YYYY)
                                Format: YYYY----
                                Example: 2009----
                                
                                Remarks:
                                The dashes (----) must be included in all cases.
                            */
                            if (current.RYRMGV != default) {
                                instance.referenceYearForMagneticVariation = current.RYRMGV.PadRight(8, '-');
                            }

                            if (current.VALACM.HasValue) {
                                instance.valueOfAnnualChangeInMagneticVariation = current.VALACM.Value;
                            }

                            if (current.VALMAG.HasValue) {
                                instance.valueOfMagneticVariation = current.VALMAG.Value;
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
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), ImporterNIS.jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.Crc32();
                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedAreaEquipment(current, instance, featureN, instance.scaleMinimum);
                            }
                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;
                    case 15: { // T_HMON_TideHarmonicPrediction
                            throw new NotImplementedException("No T_HMON_TideHarmonicPrediction in DK | GL NIS");
                        }

                    case 20: { // T_NHMN_TideNonHarmonicPrediction
                            throw new NotImplementedException("No T_NHMN_TideNonHarmonicPrediction in DK | GL NIS");
                        }

                    case 25: { // T_TIMS_TideTimeSeries
                            throw new NotImplementedException("No T_TIMS_TideTimeSeries in DK | GL NIS");
                        }

                    case 30: { // TIDEWY_Tideway
                            throw new NotImplementedException("No TIDEWY_Tideway in DK | GL NIS");
                        }

                    case 35: { // TS_FEB_TidalStreamFloodEbb
                            throw new NotImplementedException("No TS_FEB_TidalStreamFloodEbb in DK | GL NIS");
                        }

                    case 40: { // TS_PAD_TidalStreamPanelData
                            throw new NotImplementedException("No TS_PAD_TidalStreamPanelData in DK | GL NIS");
                        }

                    case 45: { // TS_PNH_TidalStreamNonHarmonicPrediction
                            throw new NotImplementedException("No TS_PNH_TidalStreamNonHarmonicPrediction in DK | GL NIS");
                        }

                    case 50: { // TS_PRH_TidalStreamHarmonicPrediction
                            throw new NotImplementedException("No TS_PRH_TidalStreamHarmonicPrediction in DK | GL NIS");
                        }

                    case 55: { // TS_TIS_TidalStreamTimeSeries
                            throw new NotImplementedException("No TS_TIS_TidalStreamTimeSeries in DK | GL NIS");
                        }

                    default:
                        // code block
                        //System.Diagnostics.Debugger.Break();
                        throw new NotImplementedException("Unhandled subtype");


                }
            }
            Logger.Current.DataTotalCount(tableName, recordCount, ConversionAnalytics.Instance.GetConvertedCount(tableName));
        }


    }
}
