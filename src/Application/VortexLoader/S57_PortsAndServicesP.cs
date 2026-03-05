using ArcGIS.Core.Data;
using S100FC;
using S100FC.S101.ComplexAttributes;
using S100FC.S101.FeatureTypes;
using S100FC.S101.SimpleAttributes;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_PortsAndServicesP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "PortsAndServicesP";

            var ps101 = "S-101";

            using var portsAndServicesP = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            Subtypes.Instance.RegisterSubtypes(portsAndServicesP);

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("point"));

            using var buffer = featureClass.CreateRowBuffer();

            using var cursor = portsAndServicesP.Search(filter, true);
            int recordCount = 0;

            var _ids = new List<Guid>();

            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new PortsAndServicesP(feature);

                // Pile w related light: current.LNAM == "DK001268840600001"

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;

                _ids.Add(globalid);

                if (FeatureRelations.Instance.IsSlave(globalid)) {
                    continue;
                }

                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    continue;
                }

                var fcSubtype = current.FCSUBTYPE ?? default;
                var watlev = current.WATLEV ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;
                var status = current.STATUS ?? default;

                // The attribute default clearance depth must be populated with a value, which must not be an empty(null)
                // value, only if the attribute value of sounding for the feature instance is populated with an empty(null) value
                // and the attribute height, if an allowable attribute for the feature, is not populated.
                // S-101 Annex A_DCEG Edition 1.5.0_Draft for Edition 2.0.0.pdf: p.771
                //Decimal defaultClearanceDepth = -1;

                switch (fcSubtype) {
                    case 1: { // BERTHS_Berth
                            var instance = new Berth {
                                // TODO: Category of Berth
                                /* S-57 ENC to S-101 Conversion Guidance ed 1.2.0

                                    The attribute category of cargo has been introduced in S-101 to encode the type of vessel cargo
                                    allowed at the berth, in particular the fact that a berth is a berth for dangerous or hazardous cargo
                                    (category of cargo = 7). This information is encoded in S-57 on BERTHS using the attribute
                                    INFORM (see clause 2.3). In order for this information to be converted across to S-101, the text
                                    string encoded in INFORM on the BERTHS should be in a standardised format, such as Dangerous
                                    or hazardous cargo.
                                */

                                featureName = GetFeatureName(current.OBJNAM, current.NOBJNM)
                            };

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            // TODO: horizontalClearanceLength

                            if (current.HORCLR.HasValue) {
                                instance.horizontalClearanceWidth = current.HORCLR.Value;
                            }

                            // TODO: interoperabilityIdentifier

                            // TODO: maximumPermittedDraught - From INFORM - No instances in GST - Not converted

                            // TODO: minimumBerthDepth

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.QUASOU != default) {
                                var qualityOfVerticalMeasurement = EnumHelper.GetEnumValues(current.QUASOU);
                                if (qualityOfVerticalMeasurement is not null && qualityOfVerticalMeasurement.Any())
                                    instance.qualityOfVerticalMeasurement = qualityOfVerticalMeasurement;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.SOUACC.HasValue) {
                                instance.verticalUncertainty = new() {
                                    uncertaintyFixed = current.SOUACC.Value
                                };
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

                        }
                        break;
                    case 5: { // CGUSTA_CoastguardStation

                            var instance = new CoastGuardStation();

                            if (current.COMCHA != default) {
                                instance.communicationChannel = current.COMCHA.Split(',').ToArray();
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            // TODO: interoperabilityIdentifier

                            /*
                                The S-101 Boolean attribute is MRCC has been introduced in S - 101 to indicate that a coast guard
                                station also performs the function of a Maritime Rescue and Coordination Centres(MRCC). This
                                information is encoded in S - 57 on CGUSTA using the attribute INFORM(see clause 2.3).In order
                                for this information to be converted across to S - 101, the text string encoded in INFORM on the
                                CGUSTA should be in a standardised format, such as Maritime Rescue and Coordination Centre.
                            */

                            //TODO: MRCC from INFORM


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
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

                        }
                        break;
                    case 10: { // CHKPNT_CheckPoint
                            throw new NotImplementedException($"No CHKPNT_CheckPoint in DK or GL. {tableName}");
                        }
                    case 15: { // CRANES_Cranes
                            var instance = new Crane();

                            if (current.CATCRN.HasValue) {
                                instance.categoryOfCrane = EnumHelper.GetEnumValue(current.CATCRN.Value);
                            }

                            if (current.COLOUR != default) {
                                var colour = GetColours(current.COLOUR);
                                if (colour is not null && colour.Any())
                                    instance.colour = colour;
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT)!.value;
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value != -32767m ? current.HEIGHT.Value : null;
                            }
                            else {

                            }

                            // TODO: interoperabilityIdentifier

                            if (current.LIFCAP.HasValue) {
                                instance.liftingCapacity = current.LIFCAP.Value;
                            }

                            if (current.ORIENT.HasValue) {
                                instance.orientation = new() {
                                    orientationValue = current.ORIENT.HasValue && current.ORIENT.Value != -32767m ? current.ORIENT : default(decimal?),
                                };
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (current.RADIUS.HasValue) {
                                instance.radius = current.RADIUS.Value != -32767m ? current.RADIUS.Value : null;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            instance.verticalClearanceFixed = new() {
                                verticalUncertainty = new() {
                                    uncertaintyFixed = current.VERACC.HasValue ? current.VERACC.Value : default(decimal?),
                                },
                                // TODO: verticalClearanceValue
                                //verticalClearanceValue = default(decimal?)
                                verticalClearanceValue = current.VERCLR.HasValue && current.VERCLR.Value != -32767m ? current.VERCLR.Value : default(decimal?),
                            };

                            var verticalDatum = ImporterNIS.GetVerticalDatum(current.VERDAT);
                            if (verticalDatum != null) {
                                var update = true;
                                foreach (var elm in VerticalDatums.Instance.Touch(current.SHAPE!)) {
                                    if (elm.Item2.value == verticalDatum.value) {
                                        update = false;
                                    }
                                }
                                if (update)
                                    instance.verticalDatum = verticalDatum.value;
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value != -32767m ? current.VERLEN.Value : null;
                            }
                            else {
                                //instance.verticalLength = default(decimal?);
                            }


                            if (current.CONVIS.HasValue) {
                                instance.visualProminence = EnumHelper.GetEnumValue(current.CONVIS.Value);
                            }



                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            instance.inTheWater = !LandAreas.Instance.Touch(current!.SHAPE!).Any();

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

                        }
                        break;
                    case 20: { // DISMAR_DistanceMark
                            var instance = new DistanceMark();

                            /*
                                The S-57 attribute CATDIS has been replaced in S-101 by the mandatory Boolean type attribute
                                distance mark visible. Where CATDIS has not been populated, or has been populated with value
                                1 (distance mark not physically installed) or an empty (null) value, distance mark visible will be set
                                to False. Where CATDIS has been populated with a value other than 1, distance mark visible will
                                be set to True.                             
                            */
                            if (!current.CATDIS.HasValue || (current.CATDIS.HasValue && current.CATDIS.Value == 1) || (current.CATDIS.HasValue && current.CATDIS.Value == -32767)) {
                                instance.distanceMarkVisible = false;
                            }
                            else if (current.CATDIS.HasValue) {
                                instance.distanceMarkVisible = true;
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;


                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            // TODO: interoperabilityIdentifier


                            decimal? dist = default;

                            if (decimal.TryParse(current.INFORM, out decimal value)) {
                                dist = value;
                            }

                            // TODO: INFORM measured distance value
                            instance.measuredDistanceValue = new() {
                                waterwayDistance = dist.HasValue ? dist.Value : default,
                                distanceUnitOfMeasurement = 4 // TODO: dismark Is Nautical Miles the correct unit of measurement

                            };



                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }
                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                        }
                        break;
                    case 25: { // GATCON_Gate
                            var instance = new Gate();

                            if (current.CATGAT.HasValue) {
                                instance.categoryOfGate = EnumHelper.GetEnumValue(current.CATGAT.Value);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            if (current.DRVAL1.HasValue) {
                                instance.depthRangeMinimumValue = current.DRVAL1.Value != -32767m ? current.DRVAL1.Value : null;
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            instance.horizontalClearanceOpen = new horizontalClearanceOpen() {
                                horizontalClearanceValue = current.HORCLR.HasValue && current.HORCLR.Value != -32767m ? current.HORCLR!.Value : default(decimal?),
                                horizontalDistanceUncertainty = current.HORACC.HasValue && current.HORACC.Value != -32767m ? current.HORACC!.Value : default(decimal?),
                            };

                            // TODO: interoperabilityIdentifier

                            if (current.NATCON != default) {
                                var natureOfConstruction = EnumHelper.GetEnumValues(current.NATCON);
                                if (natureOfConstruction is not null && natureOfConstruction.Any())
                                    instance.natureOfConstruction = natureOfConstruction;
                            }

                            if (current.QUASOU != default) {
                                var qualityOfVerticalMeasurement = EnumHelper.GetEnumValues(current.QUASOU);
                                if (qualityOfVerticalMeasurement is not null && qualityOfVerticalMeasurement.Any())
                                    instance.qualityOfVerticalMeasurement = qualityOfVerticalMeasurement;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            instance.verticalClearanceOpen = new() {
                                verticalUncertainty = new() {
                                    uncertaintyFixed = current.VERACC.HasValue ? current.VERACC.Value : default(decimal?),
                                },
                                verticalClearanceValue = current.VERCLR.HasValue ? current.VERCLR.Value : default(decimal?),
                                verticalClearanceUnlimited = current.VERCLR.HasValue ? !(current.VERCLR!.Value == default(decimal)) : default
                            };

                            var verticalDatum = ImporterNIS.GetVerticalDatum(current.VERDAT);
                            if (verticalDatum != null) {
                                var update = true;
                                foreach (var elm in VerticalDatums.Instance.Touch(current.SHAPE!)) {
                                    if (elm.Item2.value == verticalDatum.value) {
                                        update = false;
                                    }
                                }
                                if (update)
                                    instance.verticalDatum = verticalDatum.value;
                            }

                            if (current.SOUACC.HasValue) {
                                instance.verticalUncertainty = new() {
                                    uncertaintyFixed = current.SOUACC.Value
                                };
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }
                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

                        }
                        break;
                    case 30: { // GRIDRN_Gridiron
                            throw new NotImplementedException($"No GRIDRN_Gridiron in DK or GL. {tableName}");
                        }
                    case 35: { // HRBFAC_HarbourFacility
                            var instance = new HarbourFacility();

                            if (current.CATHAF != default) {
                                var categoryOfHarbourFacility = EnumHelper.GetEnumValues(current.CATHAF);
                                if (categoryOfHarbourFacility is not null)
                                    instance.categoryOfHarbourFacility = categoryOfHarbourFacility;
                            }

                            if (current.COMCHA != default) {
                                instance.communicationChannel = GetCommunicationChannel(current.COMCHA);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.NATCON != default) {
                                var natureOfConstruction = EnumHelper.GetEnumValues(current.NATCON);
                                if (natureOfConstruction is not null && natureOfConstruction.Any())
                                    instance.natureOfConstruction = natureOfConstruction;
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            // TODO: product
                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                    instance.reportedDate = reportedDate;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            // TODO: restriction

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }
                            if (current.INFORM is not null && instance.restriction is not null && instance.restriction.Contains(27 /*restriction.SpeedRestricted*/)) {
                                instance.vesselSpeedLimit = ImporterNIS.GetVesselSpeedLimit(current.INFORM);
                            }
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

                        }
                        break;
                    case 40: { // HULKES_Hulk
                            var instance = new Hulk();


                            if (current.CATHLK != default) {
                                var categoryOfHulk = EnumHelper.GetEnumValues(current.CATHLK);
                                if (categoryOfHulk is not null && categoryOfHulk.Any())
                                    instance.categoryOfHulk = categoryOfHulk;
                            }

                            if (current.COLOUR != default) {
                                var colour = GetColours(current.COLOUR);
                                if (colour is not null && colour.Any())
                                    instance.colour = colour;
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT)!.value;
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

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

                            // TODO: interoperabilityIdentifier

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }
                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                    instance.reportedDate = reportedDate;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }



                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value != -32767m ? current.VERLEN.Value : null;
                            }

                            if (current.CONVIS.HasValue /*&& current.CONVIS.Value != -32767*/) {
                                instance.visualProminence = EnumHelper.GetEnumValue(current.CONVIS.Value);
                            }


                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                var scamin = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                if (scamin.HasValue)
                                    instance.scaleMinimum = scamin.Value;
                            }


                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                        }
                        break;
                    case 45: { // MORFAC_MooringWarpingFacility
                            // https://iho.int/uploads/user/pubs/standards/s-65/S-65%20Annex%20B_Ed%201.2.0_Final.pdf p25
                            var catmor = current.CATMOR ?? default;
                            if (catmor == default || catmor == -32767) {
                                Logger.Current.DataError(current.OBJECTID ?? -1, tableName, current.LNAM ?? "Unknown LNAM", $"Unknown CATMOR for MORFAC. Cannot convert.");
                            }

                            // DOLPHIN
                            //TODO: LIST ?
                            if (catmor == 1 || catmor == 2) {
                                var instance = new Dolphin();

                                if (catmor == 1) {
                                    instance.categoryOfDolphin = [1]; // categoryOfDolphin.MooringDolphin
                                }
                                if (catmor == 2) {
                                    instance.categoryOfDolphin = [2]; // categoryOfDolphin.DeviationDolphin
                                }

                                if (current.COLOUR != default) {
                                    var colour = GetColours(current.COLOUR);
                                    if (colour is not null && colour.Any())
                                        instance.colour = colour;
                                }

                                if (current.COLPAT != default) {
                                    instance.colourPattern = GetColourPattern(current.COLPAT)!.value;
                                }

                                if (current.CONDTN.HasValue) {
                                    instance.condition = GetCondition(current.CONDTN.Value)?.value;
                                }

                                // elevation is new 

                                var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                                if (featureName is not null)
                                    instance.featureName = featureName;

                                DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                                if (dateRange != default) {
                                    instance.fixedDateRange = dateRange;
                                }
                                if (current.HEIGHT.HasValue) {
                                    instance.height = current.HEIGHT.Value != -32767m ? current.HEIGHT.Value : null;
                                }
                                else {

                                }

                                // TODO: interoperabilityIdentifier


                                if (current.NATCON != default) {
                                    var natureOfConstruction = EnumHelper.GetEnumValues(current.NATCON);
                                    if (natureOfConstruction is not null && natureOfConstruction.Any())
                                        instance.natureOfConstruction = natureOfConstruction;
                                }

                                DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                                if (periodicDateRange != default) {
                                    instance.periodicDateRange = periodicDateRange;
                                }

                                if (current.CONRAD.HasValue) {
                                    instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                                }
                                if (!string.IsNullOrEmpty(current.SORDAT)) {
                                    if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                        instance.reportedDate = reportedDate;
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                    }
                                }



                                if (current.STATUS != default) {
                                    instance.status = GetStatus(current.STATUS);
                                }

                                if (current.VERLEN.HasValue) {
                                    instance.verticalLength = current.VERLEN.Value != -32767m ? current.VERLEN.Value : null;
                                }

                                if (current.CONVIS.HasValue /*&& current.CONVIS.Value != -32767*/) {
                                    instance.visualProminence = EnumHelper.GetEnumValue(current.CONVIS.Value);
                                }

                                if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                    string subtype = "";

                                    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                    var scamin = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                    if (scamin.HasValue)
                                        instance.scaleMinimum = scamin.Value;
                                }


                                var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                                instance.information = result.information.ToArray();
                                instance.SetInformationBindings(result.InformationBindings.ToArray());

                                if (current.PICREP != default) {
                                    instance.pictorialRepresentation = FixFilename(current.PICREP);
                                }

                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;


                                buffer["flatten"] = instance.Flatten();
                                buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                                SetShape(buffer, current.SHAPE);
                                SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = featureN.UID();

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

                            }

                            // BOLLARD
                            if (catmor == 3) {
                                var instance = new Bollard();

                                if (current.CONDTN.HasValue) {
                                    instance.condition = GetCondition(current.CONDTN.Value)?.value;
                                }

                                var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                                if (featureName is not null)
                                    instance.featureName = featureName;

                                DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                                if (dateRange != default) {
                                    instance.fixedDateRange = dateRange;
                                }

                                // TODO: interoperabilityIdentifier

                                DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                                if (periodicDateRange != default) {
                                    instance.periodicDateRange = periodicDateRange;
                                }
                                if (!string.IsNullOrEmpty(current.SORDAT)) {
                                    if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                        instance.reportedDate = reportedDate;
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                    }
                                }



                                if (current.STATUS != default) {
                                    instance.status = GetStatus(current.STATUS);
                                }

                                if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                    string subtype = "";

                                    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                    var scamin = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                    if (scamin.HasValue)
                                        instance.scaleMinimum = scamin.Value;
                                }

                                var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                                instance.information = result.information.ToArray();
                                instance.SetInformationBindings(result.InformationBindings.ToArray());

                                if (current.PICREP != default) {
                                    instance.pictorialRepresentation = FixFilename(current.PICREP);
                                }


                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;


                                buffer["flatten"] = instance.Flatten();
                                buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                                SetShape(buffer, current.SHAPE);
                                SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = featureN.UID();

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

                            }

                            // SHORELINECONSTRUCTION
                            if (catmor == 4) {
                                var instance = new ShorelineConstruction {
                                    categoryOfShorelineConstruction = 23 // categoryOfShorelineConstruction.TieUpWall;
                                };

                                if (current.COLOUR != default) {
                                    var colour = GetColours(current.COLOUR);
                                    if (colour is not null && colour.Any())
                                        instance.colour = colour;
                                }

                                if (current.COLPAT != default) {
                                    instance.colourPattern = GetColourPattern(current.COLPAT)!.value;
                                }

                                if (current.CONDTN.HasValue) {
                                    instance.condition = GetCondition(current.CONDTN.Value)?.value;
                                }

                                var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                                if (featureName is not null)
                                    instance.featureName = featureName;

                                DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                                if (dateRange != default) {
                                    instance.fixedDateRange = dateRange;
                                }

                                if (current.HEIGHT.HasValue) {
                                    instance.height = current.HEIGHT.Value != -32767m ? current.HEIGHT.Value : null;
                                }
                                else {

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
                                    var natureOfConstruction = EnumHelper.GetEnumValues(current.NATCON);
                                    if (natureOfConstruction is not null && natureOfConstruction.Any())
                                        instance.natureOfConstruction = natureOfConstruction;
                                }

                                if (current.CONRAD.HasValue) {
                                    instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                                }

                                if (!string.IsNullOrEmpty(current.SORDAT)) {
                                    if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                        instance.reportedDate = reportedDate;
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                    }
                                }

                                if (current.STATUS != default) {
                                    instance.status = GetStatus(current.STATUS);
                                }

                                if (current.VERLEN.HasValue) {
                                    instance.verticalLength = current.VERLEN.Value != -32767m ? current.VERLEN.Value : null;
                                }

                                if (current.CONVIS.HasValue /*&& current.CONVIS.Value != -32767*/) {
                                    instance.visualProminence = EnumHelper.GetEnumValue(current.CONVIS.Value);
                                }

                                if (current.WATLEV.HasValue) {
                                    if (current.WATLEV.Value == -32767)
                                        instance.waterLevelEffect = default;
                                    else {
                                        instance.waterLevelEffect = EnumHelper.GetEnumValue(current.WATLEV);
                                    }
                                }

                                if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                    string subtype = "";

                                    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                    var scamin = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                    if (scamin.HasValue)
                                        instance.scaleMinimum = scamin.Value;
                                }

                                var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                                instance.information = result.information.ToArray();
                                instance.SetInformationBindings(result.InformationBindings.ToArray());

                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;


                                buffer["flatten"] = instance.Flatten();
                                buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                                SetShape(buffer, current.SHAPE);
                                SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = featureN.UID();

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                            }

                            // PILE
                            if (catmor == 5) {
                                var instance = new Pile {
                                    categoryOfPile = 8   // categoryOfPile.MooringPost;
                                };


                                if (current.COLOUR != default) {
                                    var colour = GetColours(current.COLOUR);
                                    if (colour is not null && colour.Any())
                                        instance.colour = colour;
                                }

                                if (current.COLPAT != default) {
                                    instance.colourPattern = GetColourPattern(current.COLPAT)!.value;
                                }

                                if (current.CONDTN.HasValue) {
                                    instance.condition = GetCondition(current.CONDTN.Value)?.value;
                                }

                                var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                                if (featureName is not null)
                                    instance.featureName = featureName;

                                DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                                if (dateRange != default) {
                                    instance.fixedDateRange = dateRange;
                                }


                                if (current.HEIGHT.HasValue) {
                                    instance.height = current.HEIGHT.Value != -32767m ? current.HEIGHT.Value : null;
                                }
                                else {

                                }

                                // TODO: interoperabilityIdentifier

                                if (current.CONRAD.HasValue) {
                                    instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                                }
                                if (!string.IsNullOrEmpty(current.SORDAT)) {
                                    if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                        instance.reportedDate = reportedDate;
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                    }
                                }



                                if (current.STATUS != default) {
                                    instance.status = GetStatus(current.STATUS);
                                }

                                if (current.VERLEN.HasValue) {
                                    instance.verticalLength = current.VERLEN.Value != -32767m ? current.VERLEN.Value : null;
                                }

                                if (current.CONVIS.HasValue /*&& current.CONVIS.Value != -32767*/) {
                                    instance.visualProminence = EnumHelper.GetEnumValue(current.CONVIS.Value);
                                }

                                if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                    string subtype = "";

                                    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                    var scamin = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                    if (scamin.HasValue)
                                        instance.scaleMinimum = scamin.Value;
                                }

                                var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                                instance.information = result.information.ToArray();
                                instance.SetInformationBindings(result.InformationBindings.ToArray());

                                if (current.PICREP != default) {
                                    instance.pictorialRepresentation = FixFilename(current.PICREP);
                                }
                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;


                                buffer["flatten"] = instance.Flatten();
                                buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                                SetShape(buffer, current.SHAPE);
                                SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = featureN.UID();

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

                            }

                            // CABLESUBMARINE
                            if (catmor == 6) {
                                throw new NotImplementedException($"CATMOR = 6 (chain/wire/cable). {tableName}");
                            }

                            // MOORING BUOY
                            if (catmor == 7) {
                                var instance = new MooringBuoy() {
                                };

                                if (current.BOYSHP == default) {
                                    instance.buoyShape = 3; // buoyShape.Spherical;
                                }

                                if (current.COLOUR != default) {
                                    var colour = GetColours(current.COLOUR);
                                    if (colour is not null && colour.Any())
                                        instance.colour = colour;
                                }

                                if (current.COLPAT != default) {
                                    instance.colourPattern = GetColourPattern(current.COLPAT)!.value;
                                }

                                var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                                if (featureName is not null)
                                    instance.featureName = featureName;

                                DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                                if (dateRange != default) {
                                    instance.fixedDateRange = dateRange;
                                }


                                // TODO: interoperabilityIdentifier

                                // TODO: maximumPermittedDraught - From INFORM - No instances in GST - Not converted

                                // TODO: maximumPermittedVesselLength


                                if (current.NATCON != default) {
                                    var natureOfConstruction = EnumHelper.GetEnumValues(current.NATCON);
                                    if (natureOfConstruction is not null && natureOfConstruction.Any())
                                        instance.natureOfConstruction = natureOfConstruction;
                                }

                                DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                                if (periodicDateRange != default) {
                                    instance.periodicDateRange = periodicDateRange;
                                }

                                if (current.STATUS != default) {
                                    instance.status = GetStatus(current.STATUS);
                                }

                                if (current.VERLEN.HasValue) {
                                    instance.verticalLength = current.VERLEN.Value != -32767m ? current.VERLEN.Value : null;
                                }

                                // TODO: visitors mooring (SMCFAC) 

                                if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                    string subtype = "";

                                    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                    var scamin = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                    if (scamin.HasValue)
                                        instance.scaleMinimum = scamin.Value;
                                }

                                var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                                instance.information = result.information.ToArray();
                                instance.SetInformationBindings(result.InformationBindings.ToArray());

                                if (current.PICREP != default) {
                                    instance.pictorialRepresentation = FixFilename(current.PICREP);
                                }

                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;


                                buffer["flatten"] = instance.Flatten();
                                buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);
                                SetShape(buffer, current.SHAPE);
                                SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = featureN.UID();

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

                            }
                        }
                        break;
                    case 50: { // PILBOP_PilotBoardingPlace
                            var instance = new PilotBoardingPlace();

                            if (current.CATPIL.HasValue) {
                                instance.categoryOfPilotBoardingPlace = EnumHelper.GetEnumValue(current.CATPIL);
                            }

                            // TODO: CategoryOfPrecense - new S-101 att.

                            if (current.COMCHA != default) {
                                instance.communicationChannel = current.COMCHA.Split(',').ToArray();
                            }

                            // TODO: Destination - new S-101 att.

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            // TODO: interoperabilityIdentifier

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            // TODO: PilotMovement - new S-101 att.

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

                        }
                        break;
                    case 55: { // PILPNT_Pile
                            var instance = new Pile {
                                categoryOfPile = 8   // categoryOfPile.MooringPost;
                            };

                            if (current.COLOUR != default) {
                                var colour = GetColours(current.COLOUR);
                                if (colour is not null && colour.Any())
                                    instance.colour = colour;
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT)!.value;
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }


                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value != -32767m ? current.HEIGHT.Value : null;
                            }
                            else {

                            }

                            // TODO: interoperabilityIdentifier

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }
                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                    instance.reportedDate = reportedDate;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }



                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value != -32767m ? current.VERLEN.Value : null;
                            }

                            if (current.CONVIS.HasValue /*&& current.CONVIS.Value != -32767*/) {
                                instance.visualProminence = EnumHelper.GetEnumValue(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                var scamin = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                if (scamin.HasValue)
                                    instance.scaleMinimum = scamin.Value;
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

                        }
                        break;
                    case 60: { // RSCSTA_RescueStation
                            var instance = new RescueStation();

                            if (current.CATRSC != null) {
                                var categoryOfRescueStation = EnumHelper.GetEnumValues(current.CATRSC);
                                if (categoryOfRescueStation is not null && categoryOfRescueStation.Any())
                                    instance.categoryOfRescueStation = categoryOfRescueStation;
                            }

                            if (current.COMCHA != default) {
                                instance.communicationChannel = current.COMCHA.Split(',').ToArray();
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            // TODO: interoperabilityIdentifier

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
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

                        }
                        break;
                    case 65: { // SISTAT_SignalStationTraffic // SLAVE RIND: 2  
                            var instance = _converterRegistry.Convert<SignalStationTraffic>(current);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }
                        }
                        break;
                    case 70: { // SISTAW_SignalStationWarning // SLAVE RIND: 2
                            var instance = _converterRegistry.Convert<SignalStationWarning>(current);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

                        }
                        break;
                    case 75: { // SMCFAC_SmallCraftFacility
                            var instance = new SmallCraftFacility();

                            if (current.CATSCF != default) {
                                var categoryOfSmallCraftFacility = EnumHelper.GetEnumValues(current.CATSCF);
                                if (categoryOfSmallCraftFacility is not null)
                                    instance.categoryOfSmallCraftFacility = categoryOfSmallCraftFacility;
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            // TODO: interoperabilityIdentifier

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
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

            var _nonConvertedSlaves = new List<Guid>();

            foreach (var id in _ids) {
                if (!ConversionAnalytics.Instance.IsConverted(id)) {
                    _nonConvertedSlaves.Add(id);
                }
            }

            Logger.Current.DataTotalCount(tableName, recordCount, ConversionAnalytics.Instance.GetConvertedCount(tableName));
        }
    }
}
