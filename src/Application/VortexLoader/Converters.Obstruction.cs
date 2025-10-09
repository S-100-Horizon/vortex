using ArcGIS.Core.Data;
//using ArcGIS.Desktop.Internal.Mapping;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class Converters
    {
        // OBSTRN - DangersP
        internal static Obstruction CreateObstruction(DangersP current, int? scaleMinimum, Geodatabase source) {

            var instance = new Obstruction {
                surroundingDepth = default,
                waterLevelEffect = default,
            };

            if (current.CATOBS.HasValue) {
                instance.categoryOfObstruction = EnumHelper.GetEnumValue<Obstruction, categoryOfObstruction>(current.CATOBS.Value);
            }

            if (current.CONDTN.HasValue) {
                instance.condition = ImporterNIS.GetCondition(current.CONDTN.Value);
            }

            if (current.EXPSOU.HasValue) {
                instance.expositionOfSounding = EnumHelper.GetEnumValue<Obstruction, expositionOfSounding>(current.EXPSOU.Value);
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                instance.height = current.HEIGHT.Value;
            }
            else {
                instance.height = default(double?);
            }

            // DODO: Interoperability identifier

            // TODO: Maximum permitted draught

            if (current.NATSUR != default) {
                instance.natureOfSurface = EnumHelper.GetEnumValues<Obstruction, natureOfSurface>(current.NATSUR);
            }

            if (current.PRODCT != default) {
                instance.product = EnumHelper.GetEnumValues<Obstruction, product>(current.PRODCT);
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
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }


            if (current.TECSOU != null) {
                instance.techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues<Obstruction, techniqueOfVerticalMeasurement>(current.TECSOU);
            }


            if (current.VALSOU.HasValue && current.VALSOU.Value != -32767d) {
                instance.valueOfSounding = current.VALSOU.Value;
            }
            else {
                instance.valueOfSounding = default(double?);
            }

            if (current.VERLEN.HasValue) {
                instance.verticalLength = current.VERLEN.Value;
            }
            else if (current.VERLEN.HasValue && current.VERLEN.Value == -32767d) {
                instance.verticalLength = default(double?);
            }

            if (current.WATLEV.HasValue) {
                instance.waterLevelEffect = EnumHelper.GetEnumValue<Obstruction, waterLevelEffect>(current.WATLEV);
            }

            if (scaleMinimum.HasValue) {
                instance.scaleMinimum = scaleMinimum;
            }
            else if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                string subtype = "";

                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
            }

            foreach (DepthsA depthArea in SpatialRelationResolver.Instance.GetSpatialRelatedValueFrom<DepthsA>(current.Shape!)) {
                var drval1 = depthArea.DRVAL1 ?? default;
                instance.surroundingDepth = drval1;
            }

            instance.defaultClearanceDepth = ImporterNIS.GetDefaultClearanceDepthObstruction(current.SHAPE, current.VALSOU,current.EXPSOU,current.HEIGHT,current.WATLEV,current.CATOBS,current.OBJECTID ?? -1,current.TableName ?? "Unknown tablename",current.LNAM ?? "Unknown long name");




            return instance;
        }

        // OBSTRN - DangersP
        internal static Obstruction CreateObstruction(DangersA current, int? scaleMinimum, Geodatabase source) {

            var instance = new Obstruction {
                surroundingDepth = default,
                waterLevelEffect = default,
            };

            if (current.CATOBS.HasValue) {
                instance.categoryOfObstruction = EnumHelper.GetEnumValue<Obstruction, categoryOfObstruction>(current.CATOBS.Value);
            }

            if (current.CONDTN.HasValue) {
                instance.condition = ImporterNIS.GetCondition(current.CONDTN.Value);
            }

            if (current.EXPSOU.HasValue) {
                instance.expositionOfSounding = EnumHelper.GetEnumValue<Obstruction, expositionOfSounding>(current.EXPSOU.Value);
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                instance.height = current.HEIGHT.Value;
            }
            else {
                instance.height = default(double?);
            }

            // DODO: Interoperability identifier

            // TODO: Maximum permitted draught

            if (current.NATSUR != default) {
                instance.natureOfSurface = EnumHelper.GetEnumValues<Obstruction, natureOfSurface>(current.NATSUR);
            }

            if (current.PRODCT != default) {
                instance.product = EnumHelper.GetEnumValues<Obstruction, product>(current.PRODCT);
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
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }


            if (current.TECSOU != null) {
                instance.techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues<Obstruction, techniqueOfVerticalMeasurement>(current.TECSOU);
            }


            if (current.VALSOU.HasValue && current.VALSOU.Value != -32767d) {
                instance.valueOfSounding = current.VALSOU.Value;
            }
            else {
                instance.valueOfSounding = default(double?);
            }

            if (current.VERLEN.HasValue) {
                instance.verticalLength = current.VERLEN.Value;
            }
            else if (current.VERLEN.HasValue && current.VERLEN.Value == -32767d) {
                instance.verticalLength = default(double?);
            }

            if (current.WATLEV.HasValue) {
                instance.waterLevelEffect = EnumHelper.GetEnumValue<Obstruction, waterLevelEffect>(current.WATLEV);
            }

            if (scaleMinimum.HasValue) {
                instance.scaleMinimum = scaleMinimum;
            }
            else if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                string subtype = "";

                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
            }


            foreach (DepthsA depthArea in SpatialRelationResolver.Instance.GetSpatialRelatedValueFrom<DepthsA>(current.SHAPE!)) {
                var drval1 = depthArea.DRVAL1 ?? default;
                instance.surroundingDepth = drval1;
            }

            instance.defaultClearanceDepth = ImporterNIS.GetDefaultClearanceDepthObstruction(current.SHAPE, current.VALSOU, current.EXPSOU, current.HEIGHT, current.WATLEV, current.CATOBS, current.OBJECTID ?? -1, current.TableName ?? "Unknown tablename", current.LNAM ?? "Unknown long name");


            return instance;
        }

        // OBSTRN - DangersP
        internal static Obstruction CreateObstruction(DangersL current, int? scaleMinimum, Geodatabase source) {

            var instance = new Obstruction {
                surroundingDepth = default,
                waterLevelEffect = default,
            };

            if (current.CATOBS.HasValue) {
                instance.categoryOfObstruction = EnumHelper.GetEnumValue<Obstruction, categoryOfObstruction>(current.CATOBS.Value);
            }

            if (current.CONDTN.HasValue) {
                instance.condition = ImporterNIS.GetCondition(current.CONDTN.Value);
            }

            if (current.EXPSOU.HasValue) {
                instance.expositionOfSounding = EnumHelper.GetEnumValue<Obstruction, expositionOfSounding>(current.EXPSOU.Value);
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                instance.height = current.HEIGHT.Value;
            }
            else {
                instance.height = default(double?);
            }

            // DODO: Interoperability identifier

            // TODO: Maximum permitted draught

            if (current.NATSUR != default) {
                instance.natureOfSurface = EnumHelper.GetEnumValues<Obstruction, natureOfSurface>(current.NATSUR);
            }

            if (current.PRODCT != default) {
                instance.product = EnumHelper.GetEnumValues<Obstruction, product>(current.PRODCT);
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
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }


            if (current.TECSOU != null) {
                instance.techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues<Obstruction, techniqueOfVerticalMeasurement>(current.TECSOU);
            }


            if (current.VALSOU.HasValue && current.VALSOU.Value != -32767d) {
                instance.valueOfSounding = current.VALSOU.Value;
            }
            else {
                instance.valueOfSounding = default(double?);
            }

            if (current.VERLEN.HasValue) {
                instance.verticalLength = current.VERLEN.Value;
            }
            else if (current.VERLEN.HasValue && current.VERLEN.Value == -32767d) {
                instance.verticalLength = default(double?);
            }

            if (current.WATLEV.HasValue) {
                instance.waterLevelEffect = EnumHelper.GetEnumValue<Obstruction, waterLevelEffect>(current.WATLEV);
            }

            if (scaleMinimum.HasValue) {
                instance.scaleMinimum = scaleMinimum;
            }
            else if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                string subtype = "";

                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
            }

            foreach (DepthsA depthArea in SpatialRelationResolver.Instance.GetSpatialRelatedValueFrom<DepthsA>(current.SHAPE!)) {
                var drval1 = depthArea.DRVAL1 ?? default;
                instance.surroundingDepth = drval1;
            }

            instance.defaultClearanceDepth = ImporterNIS.GetDefaultClearanceDepthObstruction(current.SHAPE, current.VALSOU, current.EXPSOU, current.HEIGHT, current.WATLEV, current.CATOBS, current.OBJECTID ?? -1, current.TableName ?? "Unknown tablename", current.LNAM ?? "Unknown long name");

            instance.SetInformationBindings(ImporterNIS.AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM));



            return instance;
        }


    }
}
