using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;


namespace S100Framework.Applications
{
    internal static partial class Converters
    {

        internal static WindTurbine CreateWindturbine(CulturalFeaturesP current, int? scaleMinimum, Geodatabase source) {
            var instance = new WindTurbine();

            if (current.COLOUR != default) {
                instance.colour = ImporterNIS.GetColours<WindTurbine>(current.COLOUR);
            }

            if (current.COLPAT != default) {
                instance.colourPattern = ImporterNIS.GetColourPattern(current.COLPAT);
            }

            if (current.CONDTN.HasValue) {
                instance.condition = ImporterNIS.GetCondition(current.CONDTN.Value);
            }

            if (current.ELEVAT.HasValue) {
                instance.elevation = current.ELEVAT.Value;
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

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

            // TODO: multiplicityOfFeatures

            if (current.NATCON != default) {
                instance.natureOfConstruction = EnumHelper.GetEnumValues<WindTurbine,natureOfConstruction>(current.NATCON);
            }

            if (current.CONRAD.HasValue) {
                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
            }                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                                    instance.reportedDate = result;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }



            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }


            instance.verticalClearanceFixed = new() {
                verticalUncertainty = new() {
                    uncertaintyFixed = current.VERACC.HasValue && current.VERACC.Value != -32767d ? current.VERACC.Value : default(double?),
                    uncertaintyVariableFactor = default(double?)
                },
                //verticalClearanceValue = default(double?)
                //verticalClearanceValue = current.VERCOP.HasValue && current.VERCOP.Value != -32767d ? current.VERCOP.Value : default(double?),
                verticalClearanceValue = current.VERCLR.HasValue && current.VERCLR.Value != -32767d ? current.VERCLR.Value : default(double?),
                //verticalClearanceValue = current.VERCCL.HasValue && current.VERCCL.Value != -32767d ? current.VERCCL.Value : default(double?),
            };



            if (current.VERLEN.HasValue) {
                instance.verticalLength = current.VERLEN.Value;
                instance.verticalDatum = ImporterNIS.GetVerticalDatum<WindTurbine>(current.VERDAT ?? 3);

            }

            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                instance.visualProminence = EnumHelper.GetEnumValue<WindTurbine,visualProminence>(current.CONVIS.Value);
            }

            if (current.WATLEV.HasValue) {
                if (current.WATLEV.Value == -32767)
                    instance.waterLevelEffect = EnumHelper.GetEnumValue<WindTurbine, waterLevelEffect>(-1);
                else {
                    instance.waterLevelEffect = EnumHelper.GetEnumValue<WindTurbine, waterLevelEffect>(current.WATLEV);
                }
            }


            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                string subtype = "";
                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
            }


            instance.SetInformationBindings(ImporterNIS.AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));


            return instance;

        }
    }
}