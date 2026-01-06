using ArcGIS.Core.Data;
//using ArcGIS.Desktop.Internal.Mapping;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.AttributeModel.S101;
using S100Framework.AttributeModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class Converters
    {
        // OBSTRN - DangersP
        internal static Obstruction CreateObstruction(DangersP current, int? scaleMinimum, Geodatabase source) {

            var instance = new Obstruction {
            };

            if (current.CATOBS.HasValue) {
                instance.categoryOfObstruction_optional = EnumHelper.GetEnumValue(current.CATOBS.Value);
            }

            if (current.CONDTN.HasValue) {
                instance.condition_optional = ImporterNIS.GetCondition(current.CONDTN.Value)?.value;
            }

            if (current.EXPSOU.HasValue) {
                instance.expositionOfSounding_optional = EnumHelper.GetEnumValue(current.EXPSOU.Value);
            }

            instance.featureName_optional = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                instance.height_optional = current.HEIGHT.Value;
            }

            // DODO: Interoperability identifier

            // TODO: Maximum permitted draught

            if (current.NATSUR != default) {
                var natureOfSurface = EnumHelper.GetEnumValues(current.NATSUR);
                if (natureOfSurface is not null && natureOfSurface.Any())
                    instance.natureOfSurface_optional = natureOfSurface;
            }

            if (current.PRODCT != default) {
                var product = EnumHelper.GetEnumValues(current.PRODCT);
                if(product is not null && product.Any())
                    instance.product_optional = product;
            }

            // TODO: QualityOfVerticalMeasurement
            if (!string.IsNullOrEmpty(current.SORDAT)) {
                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                    instance.reportedDate_optional = result;
                }
                else {
                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date: {current.SORDAT}");
                }
            }

            if (current.STATUS != default) {
                instance.status_optional = ImporterNIS.GetStatus(current.STATUS);
            }

            if (current.TECSOU != null) {
                    var techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues(current.TECSOU);
                    if(techniqueOfVerticalMeasurement is not null && techniqueOfVerticalMeasurement.Any())
                        instance.techniqueOfVerticalMeasurement_optional = techniqueOfVerticalMeasurement;
            }

            if (current.VALSOU.HasValue && current.VALSOU.Value != -32767d) {
                instance.valueOfSounding_optional = current.VALSOU.Value;
            }

            if (current.VERLEN.HasValue) {
                instance.verticalLength_optional = current.VERLEN.Value;
            }
            else if (current.VERLEN.HasValue && current.VERLEN.Value == -32767d) {
                //instance.verticalLength = default(double?);
            }

            if (current.WATLEV.HasValue) {
                instance.waterLevelEffect = EnumHelper.GetEnumValue(current.WATLEV);
            }

            if (scaleMinimum.HasValue) {
                instance.scaleMinimum_optional = scaleMinimum;
            }
            else if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                string subtype = "";

                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                instance.scaleMinimum_optional = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
            }

            foreach (DepthsA depthArea in SpatialRelationResolver.Instance.GetSpatialRelatedValueFrom<DepthsA>(current.Shape!)) {
                var drval1 = depthArea.DRVAL1 ?? default;
                instance.surroundingDepth = drval1;
            }

            instance.defaultClearanceDepth_optional = ImporterNIS.GetDefaultClearanceDepthObstruction(current.SHAPE, current.VALSOU,current.EXPSOU,current.HEIGHT,current.WATLEV,current.CATOBS,current.OBJECTID ?? -1,current.TableName ?? "Unknown tablename",current.LNAM ?? "Unknown long name");

            instance.SetInformationBindings(ImporterNIS.AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

            return instance;
        }

        // OBSTRN - DangersP
        internal static Obstruction CreateObstruction(DangersA current, int? scaleMinimum, Geodatabase source) {

            var instance = new Obstruction {
            };

            if (current.CATOBS.HasValue) {
                instance.categoryOfObstruction_optional = EnumHelper.GetEnumValue(current.CATOBS.Value);
            }

            if (current.CONDTN.HasValue) {
                instance.condition_optional = ImporterNIS.GetCondition(current.CONDTN.Value)?.value;
            }

            if (current.EXPSOU.HasValue) {
                instance.expositionOfSounding_optional = EnumHelper.GetEnumValue(current.EXPSOU.Value);
            }

            instance.featureName_optional = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                instance.height_optional = current.HEIGHT.Value;
            }

            // DODO: Interoperability identifier

            // TODO: Maximum permitted draught

            if (current.NATSUR != default) {
                var natureOfSurface = EnumHelper.GetEnumValues(current.NATSUR);
                if (natureOfSurface is not null && natureOfSurface.Any())
                    instance.natureOfSurface_optional = natureOfSurface;
            }

            if (current.PRODCT != default) {
                var product = EnumHelper.GetEnumValues(current.PRODCT);
                if (product is not null && product.Any())
                    instance.product_optional = product;
            }

            // TODO: QualityOfVerticalMeasurement
            if (!string.IsNullOrEmpty(current.SORDAT)) {
                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                    instance.reportedDate = result;
                }
                else {
                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                }
            }

            if (current.STATUS != default) {
                instance.status_optional = ImporterNIS.GetStatus(current.STATUS);
            }


            if (current.TECSOU != null) {
                var techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues(current.TECSOU);
                if (techniqueOfVerticalMeasurement is not null && techniqueOfVerticalMeasurement.Any())
                    instance.techniqueOfVerticalMeasurement_optional = techniqueOfVerticalMeasurement;
            }


            if (current.VALSOU.HasValue && current.VALSOU.Value != -32767d) {
                instance.valueOfSounding_optional = current.VALSOU.Value;
            }
            else {
                
            }

            if (current.VERLEN.HasValue) {
                instance.verticalLength_optional = current.VERLEN.Value;
            }
            else if (current.VERLEN.HasValue && current.VERLEN.Value == -32767d) {
                //instance.verticalLength = default(double?);
            }

            if (current.WATLEV.HasValue) {
                instance.waterLevelEffect = EnumHelper.GetEnumValue(current.WATLEV);
            }

            if (scaleMinimum.HasValue) {
                instance.scaleMinimum_optional = scaleMinimum;
            }
            else if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                string subtype = "";

                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                instance.scaleMinimum_optional = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
            }


            foreach (DepthsA depthArea in SpatialRelationResolver.Instance.GetSpatialRelatedValueFrom<DepthsA>(current.SHAPE!)) {
                var drval1 = depthArea.DRVAL1 ?? default;
                instance.surroundingDepth = drval1;
            }

            instance.defaultClearanceDepth_optional = ImporterNIS.GetDefaultClearanceDepthObstruction(current.SHAPE, current.VALSOU, current.EXPSOU, current.HEIGHT, current.WATLEV, current.CATOBS, current.OBJECTID ?? -1, current.TableName ?? "Unknown tablename", current.LNAM ?? "Unknown long name");

            instance.SetInformationBindings(ImporterNIS.AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));

            return instance;
        }

        // OBSTRN - DangersP
        internal static Obstruction CreateObstruction(DangersL current, int? scaleMinimum, Geodatabase source) {

            var instance = new Obstruction {
            };

            if (current.CATOBS.HasValue) {
                instance.categoryOfObstruction_optional = EnumHelper.GetEnumValue(current.CATOBS.Value);
            }

            if (current.CONDTN.HasValue) {
                instance.condition_optional = ImporterNIS.GetCondition(current.CONDTN.Value)?.value;
            }

            if (current.EXPSOU.HasValue) {
                instance.expositionOfSounding_optional = EnumHelper.GetEnumValue(current.EXPSOU.Value);
            }

            instance.featureName_optional = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                instance.height_optional = current.HEIGHT.Value;
            }
            else {
                
            }

            // DODO: Interoperability identifier

            // TODO: Maximum permitted draught

            if (current.NATSUR != default) {
                var natureOfSurface = EnumHelper.GetEnumValues(current.NATSUR);
                if (natureOfSurface is not null && natureOfSurface.Any())
                    instance.natureOfSurface_optional = natureOfSurface;
            }

            if (current.PRODCT != default) {
                var product = EnumHelper.GetEnumValues(current.PRODCT);
                if (product is not null && product.Any())
                    instance.product_optional = product;
            }

            // TODO: QualityOfVerticalMeasurement
            if (!string.IsNullOrEmpty(current.SORDAT)) {
                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                    instance.reportedDate_optional = result;
                }
                else {
                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                }
            }

            if (current.STATUS != default) {
                instance.status_optional = ImporterNIS.GetStatus(current.STATUS);
            }


            if (current.TECSOU != null) {
                var techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues(current.TECSOU);
                if (techniqueOfVerticalMeasurement is not null && techniqueOfVerticalMeasurement.Any())
                    instance.techniqueOfVerticalMeasurement_optional = techniqueOfVerticalMeasurement;
            }


            if (current.VALSOU.HasValue && current.VALSOU.Value != -32767d) {
                instance.valueOfSounding_optional = current.VALSOU.Value;
            }
            else {
                
            }

            if (current.VERLEN.HasValue) {
                instance.verticalLength_optional = current.VERLEN.Value;
            }
            else if (current.VERLEN.HasValue && current.VERLEN.Value == -32767d) {
                //instance.verticalLength = default(double?);
            }

            if (current.WATLEV.HasValue) {
                instance.waterLevelEffect = EnumHelper.GetEnumValue(current.WATLEV);
            }

            if (scaleMinimum.HasValue) {
                instance.scaleMinimum_optional = scaleMinimum;
            }
            else if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                string subtype = "";

                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                instance.scaleMinimum_optional = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
            }

            foreach (DepthsA depthArea in SpatialRelationResolver.Instance.GetSpatialRelatedValueFrom<DepthsA>(current.SHAPE!)) {
                var drval1 = depthArea.DRVAL1 ?? default;
                instance.surroundingDepth = drval1;
            }

            instance.defaultClearanceDepth_optional = ImporterNIS.GetDefaultClearanceDepthObstruction(current.SHAPE, current.VALSOU, current.EXPSOU, current.HEIGHT, current.WATLEV, current.CATOBS, current.OBJECTID ?? -1, current.TableName ?? "Unknown tablename", current.LNAM ?? "Unknown long name");

            instance.SetInformationBindings(ImporterNIS.AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));



            return instance;
        }


    }
}
