using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using CommandLine;
using S100FC.S101;
using S100FC.S101.FeatureAssociation;
using S100FC.S101.FeatureTypes;
using S100FC.S128.SimpleAttributes;
using S100Framework.Applications;
using S100Framework.Applications.Singletons;
using Serilog;
using System.Collections.Generic;
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

                using var fcPoint = geodatabase.OpenDataset<FeatureClass>(geodatabase.GetName("point"));
                using var fcPointSet = geodatabase.OpenDataset<FeatureClass>(geodatabase.GetName("pointset"));
                using var fcCurve = geodatabase.OpenDataset<FeatureClass>(geodatabase.GetName("curve"));
                using var fcSurface = geodatabase.OpenDataset<FeatureClass>(geodatabase.GetName("surface"));

                using var bufferFeatureType = tableFeatureType.CreateRowBuffer();
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
                    tableFeatureType.DeleteRows(filter);
                    fcPoint.DeleteRows(filter);
                    fcPointSet.DeleteRows(filter);
                    fcCurve.DeleteRows(filter);
                    fcSurface.DeleteRows(filter);
                }

                var foreignFoids = new Dictionary<string, string>();

                foreach (var feature in dataset.Features!) {
                    // 1) Cast feature.Attributes to S101 Model
                    var type = featureCatalogue.Assembly!.GetType($"{S100FC.Catalogues.FeatureCatalogue.Namespace("S101", "FeatureTypes")}.{feature.Name}", true) ?? default;

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
                        null => bufferFeatureType,
                        _ => throw new NotImplementedException(),
                    };

                    // Feature Association
                    if (feature.FeatureAssociation != null && feature.FeatureAssociation.Count != 0) {
                        var featureAssociations = new List<featureBinding>();

                        foreach (var fa in feature.FeatureAssociation) {
                            var binding = Extensions.CreateFeatureBinding(fa.Name, "roletype", fa.Role, feature.Name!, fa.To) as featureBinding;
                            featureAssociations.Add(binding);

                            // fa.Name == "StructureEquipment"
                            // fa.Role == "theStructure"
                            // fa.To == "110:85:1"



                            // var f = FeatureRelations.featureBindings[$"{fa.Name}::{fa.Role}"]();
                            // f.featureId = fa.To;
                            // featureAssociations.Add(f);







                            //if (!foreignFoids.TryGetValue(fa.To, out var featureType)) { }
                            //    featureType = dataset.Features.First(e => e.Foid == fa.To).Name;
                            //    foreignFoids.TryAdd(fa.To, featureType!);
                            //}


                            //var instance = Activator.CreateInstance(type);
                            //var casted = instance as IFeatureBindingDefinition;
                            //var featurebindingdefinition = casted!.featureBindingDefinitions.Single(e => e.association == fa.Name && e.role == fa.Role);

                            //var theType = Summary.FeatureBindings(fa.Name);
                            //var fb = Activator.CreateInstance(theType) as featureBinding;

                            //fb.featureType = featureType;
                            //fb.role = fa.Role;
                            //fb.roleType = featurebindingdefinition.roleType.ToString();
                            //fb.referenceId = fa.To;


                        }


                        var featureAssociationJSON = JsonSerializer.Serialize(featureAssociations, jsonSerializerOptions);
                        rowbuffer["featurebindings"] = featureAssociationJSON;
                    }

                    // Information Association
                    if (feature.Association != null && feature.Association.Count != 0) {
                        var informationAssociations = new List<informationBinding>();

                        foreach (var fa in feature.Association) {
                            var binding = Extensions.CreateInformationBinding(fa.Name, "roletype", fa.Role, feature.Name!, fa.To) as informationBinding;
                            informationAssociations.Add(binding);
                            // var i = FeatureRelations.featureBindings[$"{ia.Name}::{ia.Role}"]();


                            //    if (!foreignFoids.TryGetValue(ia.To, out var informationType)) {
                            //        informationType = dataset.InformationTypes!.First(e => e.ID == ia.To).Name;
                            //        foreignFoids.TryAdd(ia.To, informationType!);
                            //    }

                            //    var instance = Activator.CreateInstance(type);
                            //    var casted = instance as IFeatureBindingDefinition;
                            //    var informationBindingDefinitions = casted!.informationBindingDefinitions.Single(e => e.association == ia.Name && e.role == ia.Role);

                            //    var theType = Summary.InformationBindings(ia.Name);
                            //    var ib = Activator.CreateInstance(theType) as informationBinding;
                            //    //var ab = new informationBinding() {
                            //    //    informationType = informationType,
                            //    //    role = ia.Role,
                            //    //    roleType = informationBindingDefinitions.roleType.ToString(),
                            //    //    informationId = ia.To,
                            //    //}
                            //    ib!.informationType = informationType;
                            //    ib.role = ia.Role;
                            //    ib.roleType = informationBindingDefinitions.roleType.ToString();
                            //    ib.referenceId = ia.To;

                            //    informationAssociations.Add(ib);
                        }

                        var informationAssociationJSON = JsonSerializer.Serialize(informationAssociations, jsonSerializerOptions);
                        rowbuffer["informationbindings"] = informationAssociationJSON;
                    }

                    // Set Usageband
                    var match = Regex.Match(dataset.CellName, @"101DK00(\d)");

                    if (match.Success)
                        rowbuffer["usageband"] = match.Groups[1].Value;

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
                    var type = featureCatalogue.Assembly!.GetType($"{S100FC.Catalogues.FeatureCatalogue.Namespace("S101", "InformationTypes")}.{informationType!.Attributes!.S100FC_code}", true) ?? default;
                    if (type == default) {
                        Log.Error("Could not get type: {type} for informationType: {name}", informationType.Attributes.S100FC_code, informationType.Name);
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
