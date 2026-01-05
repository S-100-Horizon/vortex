using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.AttributeModel.S101;
using S100Framework.AttributeModel.S101.ComplexAttributes;
using S100Framework.AttributeModel.S101.FeatureTypes;

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
                            var instance = new Berth();


                            // TODO: Category of Berth
                            /* S-57 ENC to S-101 Conversion Guidance ed 1.2.0

                                The attribute category of cargo has been introduced in S-101 to encode the type of vessel cargo
                                allowed at the berth, in particular the fact that a berth is a berth for dangerous or hazardous cargo
                                (category of cargo = 7). This information is encoded in S-57 on BERTHS using the attribute
                                INFORM (see clause 2.3). In order for this information to be converted across to S-101, the text
                                string encoded in INFORM on the BERTHS should be in a standardised format, such as Dangerous
                                or hazardous cargo.
                            */

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            // TODO: horizontalClearanceLength

                            if (current.HORCLR.HasValue) {
                                instance.horizontalClearanceWidth = current.HORCLR.Value;
                            }

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
                                instance.qualityOfVerticalMeasurement = EnumHelper.GetEnumValues<Berth, qualityOfVerticalMeasurement>(current.QUASOU);
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

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;
                    case 5: { // CGUSTA_CoastguardStation

                            var instance = new CoastGuardStation();

                            if (current.COMCHA != default) {
                                instance.communicationChannel = current.COMCHA.Split(',').ToList<string>();
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

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

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;
                    case 10: { // CHKPNT_CheckPoint
                            throw new NotImplementedException($"No CHKPNT_CheckPoint in DK or GL. {tableName}");
                        }
                    case 15: { // CRANES_Cranes
                            var instance = new Crane();

                            if (current.CATCRN.HasValue) {
                                instance.categoryOfCrane = EnumHelper.GetEnumValue<Crane, categoryOfCrane>(current.CATCRN.Value);
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours<Crane>(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);


                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(double?);
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.LIFCAP.HasValue) {
                                instance.liftingCapacity = current.LIFCAP.Value;
                            }

                            if (current.ORIENT.HasValue) {
                                instance.orientation = new() {
                                    orientationValue = current.ORIENT.HasValue && current.ORIENT.Value != -32767d ? current.ORIENT : default(double?),
                                    orientationUncertainty = default(double?)
                                };
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (current.RADIUS.HasValue && current.RADIUS.Value != -32767d) {
                                instance.radius = current.RADIUS.Value;
                            }
                            else {
                                instance.radius = default(double?);
                            }


                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            instance.verticalClearanceFixed = new() {
                                verticalUncertainty = new() {
                                    uncertaintyFixed = current.VERACC.HasValue ? current.VERACC.Value : default(double?),
                                    uncertaintyVariableFactor = default(double?)
                                },
                                // TODO: verticalClearanceValue
                                //verticalClearanceValue = default(double?)
                                verticalClearanceValue = current.VERCLR.HasValue && current.VERCLR.Value != -32767d ? current.VERCLR.Value : default(double?),
                            };

                            instance.verticalDatum = !current.VERDAT.HasValue ? null : ImporterNIS.GetVerticalDatum<Crane>(current.VERDAT ?? 3);

                            // Clear vdat if covered by a metadata object with same vdat
                            foreach (var elm in VerticalDatums.Instance.Touch(current.SHAPE!)) {
                                if (elm.Item2 == instance.verticalDatum) {
                                    instance.verticalDatum = null;
                                    break;
                                }
                            }

                            if (current.VERLEN.HasValue && current.VERLEN.Value != -32767d) {
                                instance.verticalLength = current.VERLEN.Value;
                            }
                            else {
                                instance.verticalLength = default(double?);
                            }


                            if (current.CONVIS.HasValue) {
                                instance.visualProminence = EnumHelper.GetEnumValue<Crane, visualProminence>(current.CONVIS.Value);
                            }



                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            if (LandAreas.Instance.Touch(current!.SHAPE!).Count() > 0) {
                                instance.inTheWater = false;
                            }
                            else {
                                instance.inTheWater = true;
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;
                    case 20: { // DISMAR_DistanceMark
                            throw new NotImplementedException($"No DISMAR_DistanceMark in DK or GL. {tableName}");
                        }
                    case 25: { // GATCON_Gate
                            var instance = new Gate();

                            if (current.CATGAT.HasValue) {
                                instance.categoryOfGate = EnumHelper.GetEnumValue<Gate, categoryOfGate>(current.CATGAT.Value);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            if (current.DRVAL1.HasValue && current.DRVAL1.Value != -32767d) {
                                instance.depthRangeMinimumValue = current.DRVAL1.Value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            instance.horizontalClearanceOpen = new horizontalClearanceOpen() {
                                horizontalClearanceValue = current.HORCLR.HasValue && current.HORCLR.Value != -32767d ? current.HORCLR!.Value : default(double?),
                                horizontalDistanceUncertainty = current.HORACC.HasValue && current.HORACC.Value != -32767d ? current.HORACC!.Value : default(double?),
                            };

                            // TODO: interoperabilityIdentifier

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<Gate, natureOfConstruction>(current.NATCON);
                            }

                            if (current.QUASOU != default) {
                                instance.qualityOfVerticalMeasurement = EnumHelper.GetEnumValues<Gate, qualityOfVerticalMeasurement>(current.QUASOU);
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            instance.verticalClearanceOpen = new() {
                                verticalUncertainty = new() {
                                    uncertaintyFixed = current.VERACC.HasValue ? current.VERACC.Value : default(double?),
                                    uncertaintyVariableFactor = default(double?)
                                },
                                verticalClearanceValue = current.VERCLR.HasValue ? current.VERCLR.Value : default(double?),
                                verticalClearanceUnlimited = current.VERCLR.HasValue ? !(current.VERCLR!.Value == default(double)) : null
                            };

                            instance.verticalDatum = !current.VERDAT.HasValue ? null : ImporterNIS.GetVerticalDatum<Gate>(current.VERDAT ?? 3);
                            foreach (var elm in VerticalDatums.Instance.Touch(current.SHAPE!)) {
                                if (elm.Item2 == instance.verticalDatum) {
                                    instance.verticalDatum = null;
                                }
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
                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;
                    case 30: { // GRIDRN_Gridiron
                            throw new NotImplementedException($"No GRIDRN_Gridiron in DK or GL. {tableName}");
                        }
                    case 35: { // HRBFAC_HarbourFacility
                            var instance = new HarbourFacility();

                            if (current.CATHAF != default) {
                                instance.categoryOfHarbourFacility = EnumHelper.GetEnumValues<HarbourFacility, categoryOfHarbourFacility>(current.CATHAF);
                            }

                            if (current.COMCHA != default) {
                                instance.communicationChannel = GetCommunicationChannel(current.COMCHA);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<HarbourFacility, natureOfConstruction>(current.NATCON);
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            // TODO: product
                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                                    instance.reportedDate = result;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            // TODO: restriction

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }
                            if (current.INFORM is not null && instance.restriction is not null && instance.restriction.Contains(restriction.SpeedRestricted)) {
                                instance.vesselSpeedLimit = ImporterNIS.GetVesselSpeedLimit(current.INFORM);
                            }
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;
                    case 40: { // HULKES_Hulk
                            var instance = new Hulk();


                            if (current.CATHLK != default) {
                                instance.categoryOfHulk = EnumHelper.GetEnumValues<Hulk, categoryOfHulk>(current.CATHLK);
                            }
                            ;


                            if (current.COLOUR != default) {
                                instance.colour = GetColours<Hulk>(current.COLOUR);
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
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                                    instance.reportedDate = result;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }



                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                instance.visualProminence = EnumHelper.GetEnumValue<Hulk, visualProminence>(current.CONVIS.Value);
                            }


                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }


                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;
                    case 45: { // MORFAC_MooringWarpingFacility
                            // https://iho.int/uploads/user/pubs/standards/s-65/S-65%20Annex%20B_Ed%201.2.0_Final.pdf p25
                            var catmor = current.CATMOR ?? default;
                            if (catmor == default || catmor == -32767) {
                                Logger.Current.DataError(current.OBJECTID ?? -1, tableName, current.LNAM ?? "Unknown LNAM", $"Unknown CATMOR for MORFAC. Cannot convert.");
                            }

                            // DOLPHIN
                            if (catmor == 1 || catmor == 2) {
                                var instance = new Dolphin();

                                if (catmor == 1) {
                                    instance.categoryOfDolphin = new() { categoryOfDolphin.MooringDolphin };
                                }
                                if (catmor == 2) {
                                    instance.categoryOfDolphin = new() { categoryOfDolphin.DeviationDolphin };
                                }

                                if (current.COLOUR != default) {
                                    instance.colour = GetColours<Dolphin>(current.COLOUR);
                                }

                                if (current.COLPAT != default) {
                                    instance.colourPattern = GetColourPattern(current.COLPAT);
                                }

                                if (current.CONDTN.HasValue) {
                                    instance.condition = GetCondition(current.CONDTN.Value);
                                }

                                // elevation is new 

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

                                // TODO: interoperabilityIdentifier


                                if (current.NATCON != default) {
                                    instance.natureOfConstruction = EnumHelper.GetEnumValues<Dolphin, natureOfConstruction>(current.NATCON);
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

                                if (current.VERLEN.HasValue) {
                                    instance.verticalLength = current.VERLEN.Value;
                                }

                                if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                    instance.visualProminence = EnumHelper.GetEnumValue<Dolphin, visualProminence>(current.CONVIS.Value);
                                }

                                if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                    string subtype = "";

                                    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                    instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                }


                                instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                                if (current.PICREP != default) {
                                    instance.pictorialRepresentation = FixFilename(current.PICREP);
                                }

                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["edition"] = ImporterNIS.s101version;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                                SetShape(buffer, current.SHAPE);
                                SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = featureN.UID();

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                            }

                            // BOLLARD
                            if (catmor == 3) {
                                var instance = new Bollard();

                                if (current.CONDTN.HasValue) {
                                    instance.condition = GetCondition(current.CONDTN.Value);
                                }

                                instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

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

                                if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                    string subtype = "";

                                    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                    instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                }

                                instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                                if (current.PICREP != default) {
                                    instance.pictorialRepresentation = FixFilename(current.PICREP);
                                }


                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["edition"] = ImporterNIS.s101version;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                                SetShape(buffer, current.SHAPE);
                                SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = featureN.UID();

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                            }

                            // SHORELINECONSTRUCTION
                            if (catmor == 4) {
                                var instance = new ShorelineConstruction();

                                instance.categoryOfShorelineConstruction = categoryOfShorelineConstruction.TieUpWall;

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

                                    instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                }

                                instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["edition"] = ImporterNIS.s101version;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                                SetShape(buffer, current.SHAPE);
                                SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = featureN.UID();

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            }

                            // PILE
                            if (catmor == 5) {
                                var instance = new Pile();

                                instance.categoryOfPile = categoryOfPile.MooringPost;


                                if (current.COLOUR != default) {
                                    instance.colour = GetColours<Pile>(current.COLOUR);
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

                                // TODO: interoperabilityIdentifier

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
                                    instance.visualProminence = EnumHelper.GetEnumValue<Pile, visualProminence>(current.CONVIS.Value);
                                }

                                if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                    string subtype = "";

                                    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                    instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                }

                                instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                                if (current.PICREP != default) {
                                    instance.pictorialRepresentation = FixFilename(current.PICREP);
                                }
                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["edition"] = ImporterNIS.s101version;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                                SetShape(buffer, current.SHAPE);
                                SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = featureN.UID();

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                            }

                            // CABLESUBMARINE
                            if (catmor == 6) {
                                throw new NotImplementedException($"CATMOR = 6 (chain/wire/cable). {tableName}");
                            }

                            // MOORING BUOY
                            if (catmor == 7) {
                                var instance = new MooringBuoy() {
                                    buoyShape = default,
                                };

                                if (current.BOYSHP == default) {
                                    instance.buoyShape = buoyShape.Spherical;
                                }


                                if (current.COLOUR != default) {
                                    instance.colour = GetColours<MooringBuoy>(current.COLOUR);
                                }

                                if (current.COLPAT != default) {
                                    instance.colourPattern = GetColourPattern(current.COLPAT);
                                }

                                instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);


                                DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                                if (dateRange != default) {
                                    instance.fixedDateRange = dateRange;
                                }


                                // TODO: interoperabilityIdentifier

                                // TODO: maximumPermittedDraught - From INFORM - No instances in GST - Not converted

                                // TODO: maximumPermittedVesselLength


                                if (current.NATCON != default) {
                                    instance.natureOfConstruction = EnumHelper.GetEnumValues<MooringBuoy, natureOfConstruction>(current.NATCON);
                                }

                                DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                                if (periodicDateRange != default) {
                                    instance.periodicDateRange = periodicDateRange;
                                }

                                if (current.STATUS != default) {
                                    instance.status = GetStatus(current.STATUS);
                                }

                                if (current.VERLEN.HasValue) {
                                    instance.verticalLength = current.VERLEN.Value;
                                }

                                // TODO: visitors mooring (SMCFAC) 

                                if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                    string subtype = "";

                                    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                    instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                }

                                instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                                if (current.PICREP != default) {
                                    instance.pictorialRepresentation = FixFilename(current.PICREP);
                                }

                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["edition"] = ImporterNIS.s101version;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);
                                SetShape(buffer, current.SHAPE);
                                SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = featureN.UID();

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                            }
                        }
                        break;
                    case 50: { // PILBOP_PilotBoardingPlace
                            var instance = new PilotBoardingPlace();

                            if (current.CATPIL.HasValue) {
                                instance.categoryOfPilotBoardingPlace = EnumHelper.GetEnumValue<PilotBoardingPlace, categoryOfPilotBoardingPlace>(current.CATPIL);
                            }

                            // TODO: CategoryOfPrecense - new S-101 att.

                            if (current.COMCHA != default) {
                                instance.communicationChannel = current.COMCHA.Split(',').ToList<string>();
                            }

                            // TODO: Destination - new S-101 att.

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

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

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;
                    case 55: { // PILPNT_Pile
                            var instance = new Pile();

                            instance.categoryOfPile = categoryOfPile.MooringPost;

                            if (current.COLOUR != default) {
                                instance.colour = GetColours<Pile>(current.COLOUR);
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

                            // TODO: interoperabilityIdentifier

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
                                instance.visualProminence = EnumHelper.GetEnumValue<Pile, visualProminence>(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;
                    case 60: { // RSCSTA_RescueStation
                            var instance = new RescueStation();

                            if (current.CATRSC != null) {
                                instance.categoryOfRescueStation = EnumHelper.GetEnumValues<RescueStation, categoryOfRescueStation>(current.CATRSC);
                            }

                            if (current.COMCHA != default) {
                                instance.communicationChannel = current.COMCHA.Split(',').ToList<string>();
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

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

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;
                    case 65: { // SISTAT_SignalStationTraffic // SLAVE RIND: 2  
                            var instance = _converterRegistry.Convert<SignalStationTraffic>(current);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GlobalId, name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }
                        }
                        break;
                    case 70: { // SISTAW_SignalStationWarning // SLAVE RIND: 2
                            var instance = _converterRegistry.Convert<SignalStationWarning>(current);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;
                    case 75: { // SMCFAC_SmallCraftFacility
                            var instance = new SmallCraftFacility();

                            if (current.CATSCF != default) {
                                instance.categoryOfSmallCraftFacility = EnumHelper.GetEnumValues<SmallCraftFacility, categoryOfSmallCraftFacility>(current.CATSCF);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

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

                            instance.SetInformationBindings(AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));


                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
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
