using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using CommandLine;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel.S128.FeatureTypes;
using VortexLoader;
using System;
using static S100Framework.Applications.VortexLoader;
using static System.Net.WebRequestMethods;
using IO = System.IO;
using VortexLoader.S57.esri;
using static ArcGIS.Core.Data.NetworkDiagrams.AngleDirectedDiagramLayoutParameters;
using System.Numerics;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_ProductCoverage(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "ProductCoverage";

            using var productDefinitionsTable = source.OpenDataset<Table>("ProductDefinitions");
            using var productCoverageFeatureClass = source.OpenDataset<FeatureClass>("ProductCoverage");
            using var surfaceFeatureClass = target.OpenDataset<FeatureClass>("surface");

            surfaceFeatureClass.DeleteRows(new QueryFilter {
                WhereClause = $"ps = 'S-128' AND code = 'ElectronicProduct'",
            });

            int recordCount = 0;
            int convertedCount = 0;

            using var buffer = surfaceFeatureClass.CreateRowBuffer();
            using var insert = surfaceFeatureClass.CreateInsertCursor();

            using var cursor = productDefinitionsTable.Search(null, true);

            while (cursor.MoveNext()) {
                recordCount += 1;
                var row = (Row)cursor.Current;
                var current = new ProductDefinitions(row); // (Row)cursor.Current;

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;

                var dsnm = current.DSNM ?? default;
                var edtn = current.EDTN ?? default;
                var updn = current.UPDN ?? default;
                var isdt = current.ISDT ?? default;



                var instance = new S100Framework.DomainModel.S128.FeatureTypes.ElectronicProduct {
                    catalogueElementClassification = new List<S100Framework.DomainModel.S128.catalogueElementClassification> {
                                S100Framework.DomainModel.S128.catalogueElementClassification.Enc,
                            },
                    editionNumber = edtn,
                    issueDate = isdt,
                    notForNavigation = true,
                    typeOfProductFormat = S100Framework.DomainModel.S128.typeOfProductFormat.IsoIec8211,
                    datasetName = dsnm,
                };
                if (updn > 0)
                    instance.updateNumber = updn;

                using var cursorCoverage = productCoverageFeatureClass.Search(new QueryFilter {
                    WhereClause = $"Product_GUID = '{globalid:B}'",
                }, true);

                buffer["ps"] = "S-128";
                buffer["code"] = nameof(instance);
                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);

                while (cursorCoverage.MoveNext()) {
                    var productCoverage = new ProductCoverage((Feature)cursorCoverage.Current);
                    var catcov = productCoverage.CATCOV ?? default;

                    switch (catcov) {
                        case 1:
                            buffer["shape"] = productCoverage.SHAPE;
                            break;
                    }
                }

                insert.Insert(buffer);
                Logger.Current.DataObject(objectid, tableName, dsnm, System.Text.Json.JsonSerializer.Serialize(instance));
                convertedCount++;
            }

            Logger.Current.DataTotalCount(tableName, recordCount, convertedCount);
        }
    }
}

