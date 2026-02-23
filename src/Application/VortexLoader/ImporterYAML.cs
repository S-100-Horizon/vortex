using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using CommandLine;
using S100FC.S101;
using S100Framework.Applications;
using Serilog;
using System.Text.Json;
using System.Text.RegularExpressions;
using static S100Framework.Applications.VortexLoader;
using IO = System.IO;

namespace S100FC.Applications
{
    internal static class ImporterYAML
    {
        public static bool Load(Geodatabase geodatabase, ParserResult<Options> arguments) {
            S100FC.YAML.Dataset? dataset = null;

            bool append = false;

            var productSpecification = "S-101"; // Default product specification

            var featureCatalogue = S100FC.Catalogues.FeatureCatalogue.Catalogues.Single(e => e.ProductID.Equals(productSpecification));

            arguments.WithParsed<Options>(o => {
                append = o.Append;

                if (!IO.File.Exists(o.Dataset))
                    throw new FileNotFoundException(o.Dataset);

                var yaml = IO.File.ReadAllText(o.Dataset);
                dataset = S100FC.YAML.Converter.Deserialize<S100FC.YAML.Dataset>(yaml);
            });

            if (dataset is null)
                throw new InvalidProgramException();

            var jsonSerializerOptions = new JsonSerializerOptions {
                WriteIndented = false,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                PropertyNameCaseInsensitive = true,
            }.AppendTypeInfoResolver();

            geodatabase.ApplyEdits(() => {
                using var tableInformationType = geodatabase.OpenDataset<Table>(geodatabase.GetName("informationtype"));
                using var tableFeatureType = geodatabase.OpenDataset<Table>(geodatabase.GetName("featuretype"));
                using var tableAttachment = geodatabase.OpenDataset<Table>(geodatabase.GetName("attachment"));

                using var fcPoint = geodatabase.OpenDataset<FeatureClass>(geodatabase.GetName("point"));
                using var fcPointSet = geodatabase.OpenDataset<FeatureClass>(geodatabase.GetName("pointset"));
                using var fcCurve = geodatabase.OpenDataset<FeatureClass>(geodatabase.GetName("curve"));
                using var fcSurface = geodatabase.OpenDataset<FeatureClass>(geodatabase.GetName("surface"));

                using var bufferFeatureType = tableFeatureType.CreateRowBuffer();
                using var bufferInformationType = tableInformationType.CreateRowBuffer();
                using var bufferAttachment = tableAttachment.CreateRowBuffer();
                using var bufferPoint = fcPoint.CreateRowBuffer();
                using var bufferPointSet = fcPointSet.CreateRowBuffer();
                using var bufferCurve = fcCurve.CreateRowBuffer();
                using var bufferSurface = fcSurface.CreateRowBuffer();

                if (!append) {
                    var filter = new QueryFilter {
                        WhereClause = $"ps = '{productSpecification}'",
                    };
                    tableInformationType.DeleteRows(filter);
                    tableFeatureType.DeleteRows(filter);
                    fcPoint.DeleteRows(filter);
                    fcPointSet.DeleteRows(filter);
                    fcCurve.DeleteRows(filter);
                    fcSurface.DeleteRows(filter);
                }

                var match = Regex.Match(dataset.CellName, @"101DK00(\d)");
                int? usageBand = match.Success ? int.Parse(match.Groups[1].Value) : null;

                var foreignFoids = new Dictionary<string, string>();

                foreach (var feature in dataset.Features!) {
                    // 1) Cast feature.Attributes to S101 Model
                    var type = featureCatalogue.Assembly!.GetType($"{S100FC.Catalogues.FeatureCatalogue.Namespace("S101", "FeatureTypes")}.{feature.Name}", true) ?? default;

                    if (type == default) {
                        Log.Error("Could not get type: {name}", feature.Name);
                        continue;
                    }

                    // Serialize to JSON
                    //var json = System.Text.Json.JsonSerializer.Serialize(feature.Attributes, type, jsonSerializerOptions);
                    var flatten = feature.Attributes?.Flatten() ?? "";

                    //  Find corresponding geometry and cast it to ArcGIS.Core.Geometry
                    var geometry = dataset.GetFeatureShape(feature);

                    // Append row to table
                    var buffer = geometry switch {
                        MapPoint => bufferPoint,
                        Multipoint => bufferPointSet,
                        Polyline => bufferCurve,
                        Polygon => bufferSurface,
                        null => bufferFeatureType,
                        _ => throw new NotImplementedException(),
                    };

                    // Feature Association
                    if (feature.FeatureAssociation != null && feature.FeatureAssociation.Count != 0) {
                        var featureAssociations = new List<featureBinding>();

                        foreach (var featureAssociation in feature.FeatureAssociation) {
                            var binding = Extensions.CreateFeatureBinding(feature.Name!, featureAssociation.Name, featureAssociation.Role);
                            // Set featureId on featurebindings
                            binding.featureId = featureAssociation.To;

                            featureAssociations.Add(binding);
                        }

                        var featureAssociationJSON = JsonSerializer.Serialize(featureAssociations, jsonSerializerOptions);
                        buffer["featurebindings"] = featureAssociationJSON;
                    }

                    // Information Association
                    if (feature.Association != null && feature.Association.Count != 0) {
                        var informationAssociations = new List<informationBinding>();

                        foreach (var informationAssociation in feature.Association) {
                            var binding = Extensions.CreateInformationBinding(feature.Name!, informationAssociation.Name);

                            informationAssociations.Add(binding);
                        }

                        var informationAssociationJSON = JsonSerializer.Serialize(informationAssociations, jsonSerializerOptions);
                        buffer["informationbindings"] = informationAssociationJSON;
                    }

                    // Set Usageband
                    buffer["usageband"] = usageBand;
                    buffer["ps"] = productSpecification;
                    buffer["code"] = feature.Name;
                    buffer["flatten"] = flatten;

                    if (geometry is MapPoint point) {
                        if (point.HasZ == false)
                            bufferPoint["shape"] = MapPointBuilderEx.CreateMapPoint(((MapPoint)geometry).X, ((MapPoint)geometry).Y, 0.00, geometry.SpatialReference);
                        else
                            bufferPoint["shape"] = geometry;

                        using var row = fcPoint.CreateRow(bufferPoint);
                    }
                    else if (geometry is Multipoint) {
                        bufferPointSet["shape"] = geometry;
                        using var row = fcPointSet.CreateRow(bufferPointSet);
                    }
                    else if (geometry is Polyline) {
                        bufferCurve["shape"] = geometry;
                        using var row = fcCurve.CreateRow(bufferCurve);
                    }
                    else if (geometry is Polygon) {
                        bufferSurface["shape"] = geometry;
                        using var row = fcSurface.CreateRow(bufferSurface);
                    }
                    else if (geometry is null) {     // NoGeometry feature
                        using var row = tableFeatureType.CreateRow(bufferFeatureType);
                    }
                }

                foreach (var informationType in dataset.InformationTypes ?? []) {
                    // 1) Cast feature.Attributes to S101 Model
                    var type = featureCatalogue.Assembly!.GetType($"{S100FC.Catalogues.FeatureCatalogue.Namespace("S101", "InformationTypes")}.{informationType!.Attributes!.S100FC_code}", true) ?? default;
                    if (type == default) {
                        Log.Error("Could not get type: {type} for informationType: {name}", informationType.Attributes.S100FC_code, informationType.Name);
                        continue;
                    }

                    // 2) Serialize to JSON
                    //var json = System.Text.Json.JsonSerializer.Serialize(informationType.Attributes, type, jsonSerializerOptions);
                    var flatten = informationType.Attributes.Flatten();

                    // Write to table
                    var buffer = bufferInformationType;
                    buffer["ps"] = productSpecification;
                    buffer["code"] = informationType.Name;
                    buffer["flatten"] = flatten;
                    tableInformationType.CreateRow(bufferInformationType);
                }


                // Todo: add support files
                //foreach(var supportFile in dataset.Metadata.SupportFiles ?? []) {
                //    using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(supportFile.Content));

                //    // Write to table
                //    var buffer = bufferAttachment;

                //    buffer["ps"] = productSpecification;
                //    buffer["code"] = "supportfile";
                //    buffer["data_size"] = memoryStream.Length;
                //    buffer["data"] = memoryStream;
                //    // buffer["json"] = ??
                //    tableInformationType.CreateRow(bufferInformationType);

                //    tableAttachment.CreateRow(bufferAttachment);
                //}

            });
            return true;
        }
    }
}