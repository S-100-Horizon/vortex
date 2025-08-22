using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using CommandLine;
using NetTopologySuite.Utilities;
using S100Framework.Applications;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel.S101.InformationTypes;
using Serilog;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using VortexLoader;
using static S100Framework.Applications.VortexLoader;
using IO = System.IO;

namespace S100Framework.Applications
{
    internal static class ImporterYAML
    {
        public static bool Load(Geodatabase geodatabase, ParserResult<Options> arguments) {
            S100Framework.YAML.Dataset? dataset = null;

            bool append = false;

            var productSpecification = "S-101"; // Default product specification

            var featureCatalogue = S100Framework.Catalogues.FeatureCatalogue.Catalogues.Single(e => e.ProductID.Equals(productSpecification));

            arguments.WithParsed<Options>(o => {
                if (o.Append) {
                    append = o.Append;
                }

                if (!IO.File.Exists(o.Dataset))
                    throw new FileNotFoundException(o.Dataset);

                var yaml = IO.File.ReadAllText(o.Dataset);
                dataset = S100Framework.YAML.Converter.Deserialize<S100Framework.YAML.Dataset>(yaml);
            });

            if (dataset is null)
                throw new InvalidProgramException();

            geodatabase.ApplyEdits(() => {
                using var tableInformationType = geodatabase.OpenDataset<Table>("informationtype");

                using var fcPoint = geodatabase.OpenDataset<FeatureClass>(geodatabase.GetName("point"));
                using var fcPointSet = geodatabase.OpenDataset<FeatureClass>(geodatabase.GetName("pointset"));
                using var fcCurve = geodatabase.OpenDataset<FeatureClass>(geodatabase.GetName("curve"));
                using var fcSurface = geodatabase.OpenDataset<FeatureClass>(geodatabase.GetName("surface"));

                using var bufferInformationType = tableInformationType.CreateRowBuffer();
                using var bufferPoint = fcPoint.CreateRowBuffer();
                using var bufferPointSet = fcPointSet.CreateRowBuffer();
                using var bufferCurve = fcCurve.CreateRowBuffer();
                using var bufferSurface = fcSurface.CreateRowBuffer();

                if (!append) {
                    var filter = new QueryFilter {
                        WhereClause = $"ps = '{productSpecification}'",
                    };
                    tableInformationType.DeleteRows(filter);
                    fcPoint.DeleteRows(filter);
                    fcPointSet.DeleteRows(filter);
                    fcCurve.DeleteRows(filter);
                    fcSurface.DeleteRows(filter);
                }

                foreach (var feature in dataset.Features!) {
                    // 1) Cast feature.Attributes to S101 Model
                    var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Catalogues.FeatureCatalogue.Namespace("S101", "FeatureTypes")}.{feature.Name}", true) ?? default;

                    if (type == default) {
                        Log.Error("Could not get type: {name}", feature.Name);
                        continue;
                    }

                    // Serialize to JSON
                    var json = System.Text.Json.JsonSerializer.Serialize(feature.Attributes, type);

                    //  Find corresponding geometry and cast it to ArcGIS.Core.Geometry
                    var geometry = dataset.GetFeatureShape(feature);

                    // Append row to table
                    var rowbuffer = geometry switch {
                        MapPoint => bufferPoint,
                        Multipoint => bufferPointSet,
                        Polyline => bufferCurve,
                        Polygon => bufferSurface,
                        _ => throw new NotImplementedException(),
                    };

                    // Feature Association
                    if (feature.FeatureAssociation != null && feature.FeatureAssociation.Count != 0) {
                        var featureAssociations = feature.FeatureAssociation.Select(e => new featureBinding {
                            association = e.Name,
                            role = e.Role,
                            featureId = feature.Geometry,
                            //roleType = ??,         Skip for now
                        });

                        var featureAssociationJSON = JsonSerializer.Serialize(featureAssociations);

                        rowbuffer["featurebindings"] = featureAssociationJSON;
                    }

                    // Information Association
                    if (feature.Association != null && feature.Association.Count != 0) {
                        var informationAssociations = feature.Association.Select(e => new informationBinding {
                            association = e.Name,
                            role = e.Role,
                            informationId = e.To,
                            //roleType = ??,        Skip for now
                        });

                        var informationAssociationJSON = JsonSerializer.Serialize(informationAssociations);

                        rowbuffer["informationbindings"] = informationAssociationJSON;
                    }

                    // Set Usageband
                    var match = Regex.Match(dataset.CellName, @"101DK00(\d)");

                    if (match.Success)
                        rowbuffer["usageband"] = match.Groups[1].Value[0];

                    rowbuffer["ps"] = productSpecification;
                    rowbuffer["code"] = feature.Name;
                    rowbuffer["json"] = json;

                    if (geometry is MapPoint point) {
                        if (point.HasZ == false)
                            bufferPoint["shape"] = MapPointBuilderEx.CreateMapPoint(((MapPoint)geometry).X, ((MapPoint)geometry).Y, 0.00, geometry.SpatialReference);
                        else
                            bufferPoint["shape"] = geometry;

                        using var row = fcPoint.CreateRow(bufferPoint);
                    }
                    if (geometry is Multipoint) {
                        bufferPointSet["shape"] = geometry;
                        using var row = fcPointSet.CreateRow(bufferPointSet);
                    }
                    if (geometry is Polyline) {
                        bufferCurve["shape"] = geometry;
                        using var row = fcCurve.CreateRow(bufferCurve);
                    }
                    if (geometry is Polygon) {
                        bufferSurface["shape"] = geometry;
                        using var row = fcSurface.CreateRow(bufferSurface);
                    }
                }

                foreach (var informationType in dataset.InformationTypes!) {
                    // 1) Cast feature.Attributes to S101 Model
                    var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Catalogues.FeatureCatalogue.Namespace("S101", "InformationTypes")}.{informationType!.Attributes!.Code}", true) ?? default;
                    if (type == default) {
                        Log.Error("Could not get type: {type} for informationType: {name}", informationType.Attributes.Code, informationType.Name);
                        continue;
                    }

                    // 2) Serialize to JSON
                    var json = System.Text.Json.JsonSerializer.Serialize(informationType.Attributes, type);

                    // Write to table
                    var rowbuffer = bufferInformationType;
                    rowbuffer["ps"] = productSpecification;
                    rowbuffer["code"] = informationType.Name;
                    rowbuffer["json"] = json;
                    tableInformationType.CreateRow(bufferInformationType);
                }                
            });
            return true;
        }

    }
}
