using ArcGIS.Core.Data;
using S100Framework.Applications;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S100Framework.Applications
{
    internal static partial class Converters
    {

        internal static Obstruction CreateObstruction(DangersP current) {

            var instance = new Obstruction();

            if (current.CATOBS.HasValue) {
                instance.categoryOfObstruction = EnumHelper.GetEnumValue<categoryOfObstruction>(current.CATOBS.Value);
            }

            if (current.CONDTN.HasValue) {
                instance.condition = ImporterNIS.GetCondition(current.CONDTN.Value);
            }

            if (current.EXPSOU.HasValue) {
                instance.expositionOfSounding = EnumHelper.GetEnumValue<expositionOfSounding>(current.EXPSOU.Value);
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            if (current.HEIGHT.HasValue) {
                instance.height = current.HEIGHT.Value;
            }

            // DODO: Interoperability identifier

            // TODO: Maximum permitted draught

            if (current.NATSUR != default) {
                instance.natureOfSurface = EnumHelper.GetEnumValues<natureOfSurface>(current.NATSUR);
            }

            if (current.PRODCT != default) {
                instance.product = EnumHelper.GetEnumValues<product>(current.PRODCT);
            }

            // TODO: QualityOfVerticalMeasurement

            if (current.SORDAT != default) {
                if (DateHelper.TryConvertToDateOnly(current.SORDAT, out var dateOnly)) {
                    instance.reportedDate = dateOnly;
                }
                else {
                    //Logger.Current.DataError(current.OBJECTID ?? -1, tableName, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                }
            }

            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }

            // TODO: techniqueOfVerticalMeasurement

            if (current.VALSOU.HasValue && current.VALSOU.Value != -32767) {
                instance.valueOfSounding = current.VALSOU.Value;
            }

            if (current.VERLEN.HasValue) {
                instance.verticalLength = current.VERLEN.Value;
            }

            if (current.WATLEV.HasValue) {
                instance.waterLevelEffect = EnumHelper.GetEnumValue<waterLevelEffect>(current.WATLEV);
            }

            //if (current.SHAPE != null) {
            //    foreach (var depthArea in ImporterNIS.SelectIn<DepthsA>(current.SHAPE, depthsA, SpatialRelationship.Intersects, ImporterNIS.CompilationScale)) {
            //        var drval1 = depthArea.DRVAL1 ?? default;
            //        instance.surroundingDepth = drval1;
            //    }
            //}

            return instance;
        }


    }
}
