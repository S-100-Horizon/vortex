using ArcGIS.Core.Data;
using S100FC.S101.FeatureTypes;
//using ArcGIS.Desktop.Internal.Mapping;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;

namespace S100Framework.Applications
{
    internal static partial class Converters
    {
        // OBSTRN - DangersP
        internal static Obstruction CreateObstruction(DangersP current, int? scaleMinimum, Geodatabase source) {

            var instance = new Obstruction {
            };

            if (current.CATOBS.HasValue) {
                instance.categoryOfObstruction = EnumHelper.GetEnumValue(current.CATOBS.Value);
            }

            if (current.CONDTN.HasValue) {
                instance.condition = ImporterNIS.GetCondition(current.CONDTN.Value)?.value;
            }

            if (current.EXPSOU.HasValue) {
                instance.expositionOfSounding = EnumHelper.GetEnumValue(current.EXPSOU.Value);
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            if (current.HEIGHT.HasValue) {
                instance.height = current.HEIGHT.Value != -32767m ? current.HEIGHT.Value : null;
            }

            // DODO: Interoperability identifier

            // TODO: Maximum permitted draught

            if (current.NATSUR != default) {
                var natureOfSurface = EnumHelper.GetEnumValues(current.NATSUR);
                if (natureOfSurface is not null && natureOfSurface.Any())
                    instance.natureOfSurface = natureOfSurface;
            }

            if (current.PRODCT != default) {
                var product = EnumHelper.GetEnumValues(current.PRODCT);
                if (product is not null && product.Any())
                    instance.product = product;
            }

            // TODO: QualityOfVerticalMeasurement
            if (!string.IsNullOrEmpty(current.SORDAT)) {
                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                    instance.reportedDate = reportedDate;
                }
                else {
                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date: {current.SORDAT}");
                }
            }

            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }

            if (current.TECSOU != null) {
                var techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues(current.TECSOU);
                if (techniqueOfVerticalMeasurement is not null && techniqueOfVerticalMeasurement.Any())
                    instance.techniqueOfVerticalMeasurement = techniqueOfVerticalMeasurement;
            }

            if (current.VALSOU.HasValue) {
                instance.valueOfSounding = current.VALSOU.Value != -32767m ? current.VALSOU.Value : null;
            }

            if (current.VERLEN.HasValue) {
                instance.verticalLength = current.VERLEN.Value != -32767m ? current.VERLEN.Value : null;
            }

            if (current.WATLEV.HasValue) {
                instance.waterLevelEffect = EnumHelper.GetEnumValue(current.WATLEV);
            }

            if (scaleMinimum.HasValue) {
                instance.scaleMinimum = scaleMinimum;
            }
            else if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                string subtype = "";

                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                var scamin = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                if (scamin.HasValue)
                    instance.scaleMinimum = scamin.Value;
            }

            foreach (DepthsA depthArea in SpatialRelationResolver.Instance.GetSpatialRelatedValueFrom<DepthsA>(current.Shape!)) {
                var drval1 = depthArea.DRVAL1 ?? default;
                instance.surroundingDepth = drval1;
            }

            var defaultClearanceDepth = ImporterNIS.GetDefaultClearanceDepthObstruction(current.SHAPE, current.VALSOU, current.EXPSOU, current.HEIGHT, current.WATLEV, current.CATOBS, current.OBJECTID ?? -1, current.TableName ?? "Unknown tablename", current.LNAM ?? "Unknown long name");
            if (defaultClearanceDepth.HasValue)
                instance.defaultClearanceDepth = defaultClearanceDepth.Value;

            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
            instance.information = result.information.ToArray();
            instance.SetInformationBindings(result.InformationBindings.ToArray());

            return instance;
        }

        // OBSTRN - DangersP
        internal static Obstruction CreateObstruction(DangersA current, int? scaleMinimum, Geodatabase source) {

            var instance = new Obstruction {
            };

            if (current.CATOBS.HasValue) {
                instance.categoryOfObstruction = EnumHelper.GetEnumValue(current.CATOBS.Value);
            }

            if (current.CONDTN.HasValue) {
                instance.condition = ImporterNIS.GetCondition(current.CONDTN.Value)?.value;
            }

            if (current.EXPSOU.HasValue) {
                instance.expositionOfSounding = EnumHelper.GetEnumValue(current.EXPSOU.Value);
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            if (current.HEIGHT.HasValue) {
                instance.height = current.HEIGHT.Value != -32767m ? current.HEIGHT.Value : null;
            }

            // DODO: Interoperability identifier

            // TODO: Maximum permitted draught

            if (current.NATSUR != default) {
                var natureOfSurface = EnumHelper.GetEnumValues(current.NATSUR);
                if (natureOfSurface is not null && natureOfSurface.Any())
                    instance.natureOfSurface = natureOfSurface;
            }

            if (current.PRODCT != default) {
                var product = EnumHelper.GetEnumValues(current.PRODCT);
                if (product is not null && product.Any())
                    instance.product = product;
            }

            // TODO: QualityOfVerticalMeasurement
            if (!string.IsNullOrEmpty(current.SORDAT)) {
                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                    instance.reportedDate = reportedDate;
                }
                else {
                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                }
            }

            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }


            if (current.TECSOU != null) {
                var techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues(current.TECSOU);
                if (techniqueOfVerticalMeasurement is not null && techniqueOfVerticalMeasurement.Any())
                    instance.techniqueOfVerticalMeasurement = techniqueOfVerticalMeasurement;
            }


            if (current.VALSOU.HasValue) {
                instance.valueOfSounding = current.VALSOU.Value != -32767m ? current.VALSOU.Value : null;
            }
            else {

            }

            if (current.VERLEN.HasValue) {
                instance.verticalLength = current.VERLEN.Value != -32767m ? current.VERLEN.Value : null;
            }

            if (current.WATLEV.HasValue) {
                instance.waterLevelEffect = EnumHelper.GetEnumValue(current.WATLEV);
            }

            if (scaleMinimum.HasValue) {
                instance.scaleMinimum = scaleMinimum;
            }
            else if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                string subtype = "";

                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                var scamin = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                if (scamin.HasValue)
                    instance.scaleMinimum = scamin.Value;
            }


            foreach (DepthsA depthArea in SpatialRelationResolver.Instance.GetSpatialRelatedValueFrom<DepthsA>(current.SHAPE!)) {
                var drval1 = depthArea.DRVAL1 ?? default;
                instance.surroundingDepth = drval1;
            }

            var defaultClearanceDepth = ImporterNIS.GetDefaultClearanceDepthObstruction(current.SHAPE, current.VALSOU, current.EXPSOU, current.HEIGHT, current.WATLEV, current.CATOBS, current.OBJECTID ?? -1, current.TableName ?? "Unknown tablename", current.LNAM ?? "Unknown long name");
            if (defaultClearanceDepth.HasValue)
                instance.defaultClearanceDepth = defaultClearanceDepth.Value;

            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
            instance.information = result.information.ToArray();
            instance.SetInformationBindings(result.InformationBindings.ToArray());

            return instance;
        }

        // OBSTRN - DangersP
        internal static Obstruction CreateObstruction(DangersL current, int? scaleMinimum, Geodatabase source) {

            var instance = new Obstruction {
            };

            if (current.CATOBS.HasValue) {
                instance.categoryOfObstruction = EnumHelper.GetEnumValue(current.CATOBS.Value);
            }

            if (current.CONDTN.HasValue) {
                instance.condition = ImporterNIS.GetCondition(current.CONDTN.Value)?.value;
            }

            if (current.EXPSOU.HasValue) {
                instance.expositionOfSounding = EnumHelper.GetEnumValue(current.EXPSOU.Value);
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            if (current.HEIGHT.HasValue) {
                instance.height = current.HEIGHT.Value != -32767m ? current.HEIGHT.Value : null;
            }
            else {

            }

            // DODO: Interoperability identifier

            // TODO: Maximum permitted draught

            if (current.NATSUR != default) {
                var natureOfSurface = EnumHelper.GetEnumValues(current.NATSUR);
                if (natureOfSurface is not null && natureOfSurface.Any())
                    instance.natureOfSurface = natureOfSurface;
            }

            if (current.PRODCT != default) {
                var product = EnumHelper.GetEnumValues(current.PRODCT);
                if (product is not null && product.Any())
                    instance.product = product;
            }

            // TODO: QualityOfVerticalMeasurement
            if (!string.IsNullOrEmpty(current.SORDAT)) {
                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                    instance.reportedDate = reportedDate;
                }
                else {
                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                }
            }

            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }


            if (current.TECSOU != null) {
                var techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues(current.TECSOU);
                if (techniqueOfVerticalMeasurement is not null && techniqueOfVerticalMeasurement.Any())
                    instance.techniqueOfVerticalMeasurement = techniqueOfVerticalMeasurement;
            }


            if (current.VALSOU.HasValue) {
                instance.valueOfSounding = current.VALSOU.Value != -32767m ? current.VALSOU.Value : null;
            }

            if (current.VERLEN.HasValue) {
                instance.verticalLength = current.VERLEN.Value != -32767m ? current.VERLEN.Value : null;
            }

            if (current.WATLEV.HasValue) {
                instance.waterLevelEffect = EnumHelper.GetEnumValue(current.WATLEV);
            }

            if (scaleMinimum.HasValue) {
                instance.scaleMinimum = scaleMinimum;
            }
            else if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                string subtype = "";

                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                var scamin = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                if (scamin.HasValue)
                    instance.scaleMinimum = scamin.Value;
            }

            foreach (DepthsA depthArea in SpatialRelationResolver.Instance.GetSpatialRelatedValueFrom<DepthsA>(current.SHAPE!)) {
                var drval1 = depthArea.DRVAL1 ?? default;
                instance.surroundingDepth = drval1;
            }

            var defaultClearanceDepth = ImporterNIS.GetDefaultClearanceDepthObstruction(current.SHAPE, current.VALSOU, current.EXPSOU, current.HEIGHT, current.WATLEV, current.CATOBS, current.OBJECTID ?? -1, current.TableName ?? "Unknown tablename", current.LNAM ?? "Unknown long name");
            if (defaultClearanceDepth.HasValue)
                instance.defaultClearanceDepth = defaultClearanceDepth.Value;

            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
            instance.information = result.information.ToArray();
            instance.SetInformationBindings(result.InformationBindings.ToArray());

            return instance;
        }


    }
}
