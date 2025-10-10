using ArcGIS.Core.Data;
using ArcGIS.Core.Data.UtilityNetwork;
using ArcGIS.Core.Geometry;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S128.FeatureTypes;
using S100Framework.YAML;
using Serilog;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text;
using IO = System.IO;

namespace S100Framework.ProductCatalogue
{
    public interface INauticalProductManager
    {
    }

    public interface IElectronicProductManager : IEnumerable<string>
    {
        Task CreateElectronicProductAsync(string name, DomainModel.S128.ComplexAttributes.productSpecification productSpecification, S100Framework.DomainModel.S128.specificUsage specificUsage, ArcGIS.Core.Geometry.Polygon boundary);

        Task CreateElectronicProductAsync(string name, DomainModel.S128.ComplexAttributes.productSpecification productSpecification, S100Framework.DomainModel.S128.specificUsage specificUsage, ArcGIS.Core.Geometry.Polygon boundary, int edition, int update, byte[] zipfile);

        Task<YAML.Dataset> CreateNewDatasetAsync(string name);

        Task<YAML.Dataset> CreateNewEditionAsync(string name);

        Task<YAML.Dataset> CreateNewUpdateAsync(string name);

        Task<YAML.Dataset> ReissueAsync(string name);

        Task<bool> QueryUpdatesAsync(string name, Action<object> action);

        Task<bool> IsDirtyAsync(string name);

        ElectronicProduct ElectronicProduct(string name);
    }

    public interface IProductManager
    {
        INauticalProductManager NauticalProductManager { get; }

        IElectronicProductManager ElectronicProductManager { get; }

        Task Dispatch(Action action);

        Task<TResult> Dispatch<TResult>(Func<TResult> function);
    }

    public class ProductManager : IProductManager, INauticalProductManager, IElectronicProductManager, IDisposable
    {
        public static async Task<IProductManager> CreateInstanceAsync(Func<Geodatabase> creator) => await new ProductManager().InitializeAsync(creator);

        private bool _disposed = false;

        private SingleThreadTaskScheduler _singleThreadTaskScheduler;

        private TaskFactory _taskFactory;

        private Geodatabase? _geodatabase = default;

        private string _databaseName = string.Empty;
        private string _ownerName = string.Empty;

        private IDictionary<string, Geodatabase> _connections = new Dictionary<string, Geodatabase>();

        record ElectronicProductKey(string ps, string name)
        {
            public override string ToString() => $"{this.ps}::{this.name}";
        }

        private ConcurrentDictionary<string, S100Framework.DomainModel.S128.FeatureTypes.ElectronicProduct> _electronicProducts = new ConcurrentDictionary<string, S100Framework.DomainModel.S128.FeatureTypes.ElectronicProduct>();

        private ProductManager() {
            this._singleThreadTaskScheduler = new SingleThreadTaskScheduler();
            this._taskFactory = new TaskFactory(this._singleThreadTaskScheduler);
        }

        protected async Task<ProductManager> InitializeAsync(Func<Geodatabase> creator) {
            await this.Dispatch(() => {
                this._geodatabase = creator();

                var tableDefinitions = this._geodatabase.GetDefinitions<TableDefinition>();

                var configuration = tableDefinitions.Single(e => e.GetName().EndsWith("configuration"));

                var syntax = this.SQLSyntax.ParseTableName(configuration.GetName());
                this._databaseName = syntax.Item1;
                this._ownerName = syntax.Item2;

                using var table = this._geodatabase.OpenDataset<Table>(configuration.GetName());

                using var cursor = table.Search(new QueryFilter {
                    WhereClause = "upper(ps) = 'S-128.HORIZON' AND code = 'ProductCatalogue'",
                }, true);

                cursor.MoveNext();

                Debug.Assert(cursor.Current != null);

                var c = cursor.Current;

                var code = Convert.ToString(c["code"]);
                if (!string.IsNullOrEmpty(code) && code.Equals("ProductCatalogue")) {
                    if (!c.IsNull("json")) {
                        var settings = System.Text.Json.JsonSerializer.Deserialize<S100Horizon.Settings.ProductCatalogue>(Convert.ToString(c["json"])!);

                        if (settings != null) {
                            foreach (var connection in settings.Connections) {
                                if (connection.ConnectionFile == default) {
                                    _connections.Add(connection.ProductSpecification.ToUpperInvariant(), this._geodatabase);
                                }
                                else {
                                    var geodatabase = this.OpenGeodatabase(connection.ConnectionFile);
                                    _connections.Add(connection.ProductSpecification.ToUpperInvariant(), geodatabase);
                                }
                            }
                        }
                    }
                }
            });

            await this.Dispatch(() => {
                using (var surface = this._geodatabase!.OpenDataset<FeatureClass>(this.QualifyTableName("surface"))) {
                    using var cursor = surface.Search(new QueryFilter {
                        WhereClause = "upper(ps) = 'S-128'"
                    }, true);
                    while (cursor.MoveNext()) {
                        var c = cursor.Current;

                        if (c.IsNull("code")) continue;

                        var code = Convert.ToString(c["code"])!;
                        if (code.Equals(nameof(S100Framework.DomainModel.S128.FeatureTypes.ElectronicProduct))) {
                            var electronicProduct = System.Text.Json.JsonSerializer.Deserialize<S100Framework.DomainModel.S128.FeatureTypes.ElectronicProduct>(Convert.ToString(c["json"])!)!;
                            this._electronicProducts.GetOrAdd(electronicProduct.datasetName!.ToUpperInvariant(), electronicProduct);
                        }
                    }
                }
            });

            return this;
        }

        public INauticalProductManager NauticalProductManager => this;

        public IElectronicProductManager ElectronicProductManager => this;

        public Task Dispatch(Action action) {
            return this._taskFactory.StartNew(() => {
                action();
            });
        }
        public Task<TResult> Dispatch<TResult>(Func<TResult> function) {
            return this._taskFactory.StartNew(() => {
                return function();
            });
        }

        #region IElectronicProductManager

        async Task IElectronicProductManager.CreateElectronicProductAsync(string name, DomainModel.S128.ComplexAttributes.productSpecification productSpecification, DomainModel.S128.specificUsage specificUsage, ArcGIS.Core.Geometry.Polygon boundary) {
            if (string.IsNullOrEmpty(name))
                throw new System.ArgumentNullException(nameof(name));

            name = name.ToUpperInvariant();

            var key = new ElectronicProductKey(productSpecification.name, name);

            await this.Dispatch(() => {
                if (this._electronicProducts.ContainsKey(name))
                    throw new System.ArgumentException("An element with the same key already exists!");

                this._geodatabase!.ApplyEdits(() => {
                    using (var surface = this._geodatabase!.OpenDataset<FeatureClass>(this.QualifyTableName("surface"))) {
                        using var buffer = surface.CreateRowBuffer();
                        buffer["ps"] = "S-128";
                        buffer["code"] = nameof(S100Framework.DomainModel.S128.FeatureTypes.ElectronicProduct);

                        var electronicProduct = new S100Framework.DomainModel.S128.FeatureTypes.ElectronicProduct {
                            datasetName = name,
                            typeOfProductFormat = DomainModel.S128.typeOfProductFormat.IsoIec8211,
                            notForNavigation = true,
                            issueDate = DateOnly.FromDateTime(DateTime.Now),
                            editionNumber = 0,
                            agencyResponsibleForProduction = "Danish Geodata Agency",
                            specificUsage = specificUsage,
                            productSpecification = productSpecification,
                        };

                        buffer["json"] = System.Text.Json.JsonSerializer.Serialize(electronicProduct);
                        buffer["shape"] = boundary;
                        surface.CreateRow(buffer);

                        var result = this._electronicProducts.TryAdd(name, electronicProduct);
                        Debug.Assert(result);
                    }
                });
            });

        }

        Task IElectronicProductManager.CreateElectronicProductAsync(string name, DomainModel.S128.ComplexAttributes.productSpecification productSpecification, DomainModel.S128.specificUsage specificUsage, ArcGIS.Core.Geometry.Polygon boundary, int edition, int update, byte[] zipfile) {
            throw new NotImplementedException();
        }

        async Task<YAML.Dataset> IElectronicProductManager.CreateNewDatasetAsync(string name) {
            if (string.IsNullOrEmpty(name))
                throw new System.ArgumentNullException(nameof(name));
            name = name.ToUpperInvariant();

            if (!this._electronicProducts.ContainsKey(name))
                throw new System.ArgumentException(nameof(name));

            var result = await this.GetElectronicProductAsync(name);

            if (!(result.ElectronicProduct.editionNumber == 1 && result.ElectronicProduct.updateNumber == 0))
                throw new InvalidOperationException();

            return await this.CreateDatasetAsync(result.ElectronicProduct, result.Filter, ExportTypes.NewDataset);
        }

        async Task<YAML.Dataset> IElectronicProductManager.CreateNewEditionAsync(string name) {
            if (string.IsNullOrEmpty(name))
                throw new System.ArgumentNullException(nameof(name));
            name = name.ToUpperInvariant();

            if (!this._electronicProducts.ContainsKey(name))
                throw new System.ArgumentException(nameof(name));

            var result = await this.GetElectronicProductAsync(name);

            if (!(result.ElectronicProduct.editionNumber == 1 && result.ElectronicProduct.updateNumber == 0))
                throw new InvalidOperationException();

            result.ElectronicProduct.editionNumber += 1;
            result.ElectronicProduct.updateNumber = 0;

            return await this.CreateDatasetAsync(result.ElectronicProduct, result.Filter, ExportTypes.NewEdition);
        }

        Task<YAML.Dataset> IElectronicProductManager.CreateNewUpdateAsync(string name) {
            throw new NotImplementedException();
        }

        async Task<YAML.Dataset> IElectronicProductManager.ReissueAsync(string name) {
            if (string.IsNullOrEmpty(name))
                throw new System.ArgumentNullException(nameof(name));
            name = name.ToUpperInvariant();

            if (!this._electronicProducts.ContainsKey(name))
                throw new System.ArgumentException(nameof(name));

            var result = await this.GetElectronicProductAsync(name);

            return await this.CreateDatasetAsync(result.ElectronicProduct, result.Filter, ExportTypes.Reissue);
        }

        async Task<bool> IElectronicProductManager.QueryUpdatesAsync(string name, Action<object> action) {
            if (string.IsNullOrEmpty(name))
                throw new System.ArgumentNullException(nameof(name));
            name = name.ToUpperInvariant();

            if (!this._electronicProducts.ContainsKey(name))
                throw new System.ArgumentException(nameof(name));

            var electronicProduct = this._electronicProducts[name];

            var connection = this._connections[this._electronicProducts[name].productSpecification!.name]!;

            var dataset = await this.GetLatestDataset(name);

            if (dataset == default)
                return false;

            var filter = await this.BuildSpatialQueryFilter(dataset, electronicProduct.specificUsage);

            return await this.Dispatch(() => {
                string[] tableNames = ["point", "pointset", "curve", "surface"];
                foreach (var baseTableName in tableNames) {
                    using var fc = connection.OpenDataset<FeatureClass>(this.QualifyTableName($"{baseTableName}_H"));

                    using var cursor = fc.Search(filter, true);
                    while (cursor.MoveNext()) {
                        action(cursor.Current);
                    }
                }
                return false;
            });
        }

        async Task<bool> IElectronicProductManager.IsDirtyAsync(string name) {
            if (string.IsNullOrEmpty(name))
                throw new System.ArgumentNullException(nameof(name));
            name = name.ToUpperInvariant();

            if (!this._electronicProducts.ContainsKey(name))
                throw new System.ArgumentException(nameof(name));

            var electronicProduct = this._electronicProducts[name];

            var connection = this._connections[this._electronicProducts[name].productSpecification!.name]!;

            var dataset = await this.GetLatestDataset(name);

            if (dataset == default)
                return false;

            var filter = await this.BuildSpatialQueryFilter(dataset, electronicProduct.specificUsage);

            var dirty = await this.Dispatch(() => {
                string[] tableNames = ["point", "pointset", "curve", "surface"];
                foreach (var baseTableName in tableNames) {
                    using var fc = connection.OpenDataset<FeatureClass>(this.QualifyTableName($"{baseTableName}_H"));

                    using var cursor = fc.Search(filter, true);
                    while (cursor.MoveNext()) {
                        return true;
                    }
                }
                return false;
            });

            return dirty;
        }

        ElectronicProduct IElectronicProductManager.ElectronicProduct(string name) => this._electronicProducts[name.ToUpperInvariant()];

        IEnumerator<string> IEnumerable<string>.GetEnumerator() {
            foreach (var p in this._electronicProducts)
                yield return p.Key;
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator() => this._electronicProducts.Keys.GetEnumerator();

        private async Task<(ElectronicProduct ElectronicProduct, SpatialQueryFilter Filter)> GetElectronicProductAsync(string name) {
            return await this.Dispatch(() => {
                using var surface = this._geodatabase!.OpenDataset<FeatureClass>(this.QualifyTableName("surface"));
                ArcGIS.Core.Data.Row row128;

                using var cursorS128 = surface.Search(new QueryFilter {
                    WhereClause = $"json LIKE '%\"datasetName\":\"{name}\"%'",
                }, false);

                cursorS128.MoveNext();

                Debug.Assert(cursorS128.Current != null);

                row128 = cursorS128.Current;

                if (row128.IsNull("json"))
                    throw new System.ArgumentNullException(nameof(name));

                var electronicProduct = System.Text.Json.JsonSerializer.Deserialize<DomainModel.S128.FeatureTypes.ElectronicProduct>(Convert.ToString(row128["json"])!)!;

                var shapeCoverage = (ArcGIS.Core.Geometry.Polygon)((ArcGIS.Core.Data.Feature)cursorS128.Current).GetShape();

                var whereClause = "upper(ps) = 'S-101'";

                whereClause += electronicProduct.specificUsage switch {
                    DomainModel.S128.specificUsage.NavigationalPurposeOverview => $" AND usageband = 1",
                    DomainModel.S128.specificUsage.NavigationalPurposeGeneral => $" AND usageband = 2",
                    DomainModel.S128.specificUsage.NavigationalPurposeCoastal => $" AND usageband = 3",
                    DomainModel.S128.specificUsage.NavigationalPurposeApproach => $" AND usageband = 4",
                    DomainModel.S128.specificUsage.NavigationalPurposeHarbour => $" AND usageband = 5",
                    _ => "",
                };

                var filter = new SpatialQueryFilter {
                    FilterGeometry = shapeCoverage,
                    SpatialRelationship = SpatialRelationship.Relation,
                    SpatialRelationshipDescription = Topology.Matrix.DE9IM,
                    WhereClause = whereClause,
                };

                return (electronicProduct, filter);
            });
        }

        private async Task<YAML.Dataset> CreateDatasetAsync(ElectronicProduct electronicProduct, SpatialQueryFilter filter, ExportTypes exportType) {
            var timestamp = DateTime.UtcNow;

            var featureCatalogue = S100Framework.Catalogues.FeatureCatalogue.Catalogues.Single(e => e.ProductID.Equals("S-101"));

            var connection = this._connections["S-101"]!;

            electronicProduct.issueDate = DateOnly.FromDateTime(timestamp);

            var dataset = new S100Framework.YAML.Dataset {
                CellName = $"{electronicProduct!.datasetName!}.000",
                Comment = electronicProduct.notForNavigation ? "Not for navigation!" : string.Empty,
                Edition = (uint?)electronicProduct.editionNumber,
                ENCVer = "INT.IHO.S-101.2.0",
                FCVer = "2.0",
                verticalDatum = "Baltic Sea Chart Datum 2000,44",
                Update = (uint?)electronicProduct.updateNumber,
            };

            return await this.Dispatch(() => {
                var topology = connection.BuildTopology(filter)!;
                dataset.AddTopology(topology);

                //  InformationTypes
                {
                    using var informationType = connection.OpenDataset<Table>(this.QualifyTableName("informationtype"));

                    using var informationCursor = informationType.Search();
                    while (informationCursor.MoveNext()) {
                        var current = informationCursor.Current;

                        var name = $"{current.Crc32()}";
                        var code = current["code"].ToString()!;
                        var json = current["json"].ToString()!;

                        var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Catalogues.FeatureCatalogue.Namespace("S101", "InformationTypes")}.{code}", true)!;

                        var instance = DBNull.Value.Equals(current["json"]) ? null : System.Text.Json.JsonSerializer.Deserialize(Convert.ToString(current["json"])!, type);

                        var information = new YAML.Information {
                            Name = code,
                            ID = name,
                            Attributes = (InformationNode)instance!,
                        };

                        dataset.AddInformation(information);
                    }
                }

                var geometries = new List<(ArcGIS.Core.Geometry.Geometry geometry, string name)>();

                //  FeatureTypes
                foreach (var def in connection.GetDefinitions<FeatureClassDefinition>()) {
                    var tableName = def.GetAliasName();

                    var supported = tableName switch {
                        "surface" => true,
                        "curve" => true,
                        "point" => true,
                        "pointset" => true,
                        _ => false
                    };

                    if (!supported) {
                        Log.Information("Unsupported table detected: {tableName}", tableName);
                        continue;
                    }

                    using (var fc = connection.OpenDataset<FeatureClass>(def.GetName())) {
                        using var featureCursor = fc.Search(filter, true);
                        while (featureCursor.MoveNext()) {
                            var current = (ArcGIS.Core.Data.Feature)featureCursor.Current;
                            var name = $"{current.Crc32()}";

                            // Only map geometry, and keep name seperate so foids remain unique
                            var geometry = name;

                            if (topology.Mapping.TryGetValue(name!, out var value))
                                geometry = value;

                            var shapetype = def.GetShapeType();

                            var code = Convert.ToString(current["code"]);

                            var foid = $"110:{name[1..]}:1";       // Geodatastyrelsen: 110 

                            var prim = shapetype switch {
                                GeometryType.Point => Primitive.Point,
                                GeometryType.Multipoint => Primitive.Point,
                                GeometryType.Polyline => Primitive.Curve,
                                GeometryType.Polygon => Primitive.Surface,
                                _ => throw new InvalidOperationException(),
                            };

                            try {
                                var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Catalogues.FeatureCatalogue.Namespace("S101", "FeatureTypes")}.{code}", true) ?? default;

                                if (type == default) {
                                    Log.Error("Could not get type: {type} for feature: {name}", code, name);
                                    continue;
                                }

                                var instance = current.IsNull("json") ? null : System.Text.Json.JsonSerializer.Deserialize(Convert.ToString(current["json"])!, type);

                                // Surface Masks
                                var topologySurface = topology.Surfaces.FirstOrDefault(e => e.Ref!.Equals(name, StringComparison.InvariantCultureIgnoreCase));

                                // Build comma seperated string of masks, with :1 or :2 indicating which mask it is. Should be null/omitted if empty.
                                var masks = new[] {
                                    topologySurface?.Masks1?.Select(e => $"C{e}:1"),
                                    topologySurface?.Masks2?.Select(e => $"C{e}:2")
                                }.Where(m => m != null).SelectMany(m => m!);

                                var feature = new YAML.Feature {
                                    Name = code,
                                    Foid = foid,
                                    Prim = prim,
                                    Geometry = geometry,
                                    Masks = masks.Any() ? string.Join(",", masks) : null
                                };

                                // Only emit attributes if feature contains any non-static properties
                                if (!S100Framework.YAML.Converter.IsDefault(instance!))
                                    feature.Attributes = (FeatureNode)instance!;

                                // Information Associations
                                if (!current.IsNull("informationbindings")) {
                                    var informationBindings = System.Text.Json.JsonSerializer.Deserialize<informationBinding[]?>(Convert.ToString(current["informationbindings"])!);

                                    if (informationBindings != default && informationBindings.Any()) {
                                        foreach (var binding in informationBindings) {
                                            var asso = new YAML.Association {
                                                Name = binding.association,
                                                Role = binding.role,
                                                To = binding.informationId!,
                                            };

                                            // Special case for SpatialAssociation
                                            if (prim != Primitive.Surface && asso.Name.Equals("SpatialAssociation", StringComparison.CurrentCultureIgnoreCase)) {
                                                var curve = dataset?.Curves?.FirstOrDefault(e => e.Name == geometry);

                                                curve?.AddAssociation(asso);
                                            }
                                            else {
                                                feature?.AddAssociation(asso);
                                            }
                                        }
                                    }
                                }

                                // Feature Associations
                                if (!current.IsNull("featurebindings")) {
                                    var featureBindings = System.Text.Json.JsonSerializer.Deserialize<featureBinding[]?>(Convert.ToString(current["featurebindings"])!);

                                    if (featureBindings != default && featureBindings.Any()) {
                                        foreach (var binding in featureBindings) {
                                            var roleType = binding.roleType;

                                            // Skip association roleType for now
                                            if (roleType == "association")
                                                continue;

                                            var asso = new YAML.Association {
                                                Name = binding.association,
                                                Role = binding.role,
                                                To = $"110:{binding.featureId![1..]}:1"
                                            };

                                            feature?.AddFeatureAssociation(asso);
                                        }
                                    }
                                }

                                dataset?.AddFeature(feature!);

                                geometries.Add(new(current.GetShape(), name!));
                            }
                            catch (Exception ex) {
                                Log.Error(ex, ex.Message);
                                throw;
                            }
                        }
                    }
                }

                //  Geometries
                foreach (var (geometry, name) in geometries.OrderBy(e => e.geometry.GeometryType)) {
                    if (geometry.GeometryType == GeometryType.Polygon) continue;    // Skip polygons after topology
                    dataset?.AddGeometry(geometry, name!);
                    Log.Verbose("Adding {geometryType} with ID: {name}", geometry.GeometryType, name);
                }

                this._geodatabase!.ApplyEdits(() => {
                    using var surface = this._geodatabase!.OpenDataset<FeatureClass>(this.QualifyTableName("surface"));

                    using var cursorS128 = surface.Search(new QueryFilter {
                        WhereClause = $"json LIKE '%\"datasetName\":\"{electronicProduct.datasetName}\"%'",
                    }, false);

                    cursorS128.MoveNext();

                    Debug.Assert(cursorS128.Current != null);

                    var row128 = cursorS128.Current;
                    row128["json"] = System.Text.Json.JsonSerializer.Serialize(electronicProduct);
                    row128.Store();
                    row128.Dispose();

                    this._electronicProducts[electronicProduct.datasetName!.ToUpperInvariant()] = electronicProduct;

                    using var attachment = this._geodatabase!.OpenDataset<Table>(this.QualifyTableName("attachment"));

                    using var buffer = attachment.CreateRowBuffer();

                    buffer["ps"] = "S-128.Horizon";
                    buffer["code"] = nameof(Dataset);
                    buffer["json"] = System.Text.Json.JsonSerializer.Serialize(new Dataset {
                        DatasetName = electronicProduct.datasetName!,
                        Edition = electronicProduct.editionNumber!.Value,
                        Update = electronicProduct.updateNumber ?? 0,
                        ExportTypes = exportType,
                        TimestampUTC = timestamp
                    });

                    var yaml = dataset.Serialize();

                    using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(yaml));

                    buffer["data_size"] = memoryStream.Length;
                    buffer["data"] = memoryStream;

                    attachment.CreateRow(buffer);
                });
                return dataset!;
            });
        }

        #endregion

        public void Dispose() {
            if (!this._disposed) {
                this._singleThreadTaskScheduler.Dispose();

                foreach (var e in this._connections) {
                    e.Value.Dispose();
                }
                this._geodatabase?.Dispose();
                this._disposed = true;
            }

            // Prevent the finalizer from running, since we've already cleaned up.
            GC.SuppressFinalize(this);
        }

        private SQLSyntax SQLSyntax => this._geodatabase!.GetSQLSyntax();

        private string QualifyTableName(string tableName) => this.SQLSyntax.QualifyTableName(this._databaseName, this._ownerName, tableName);

        private Geodatabase OpenGeodatabase(Uri connectionFile) {
            Func<Geodatabase> createGeodatabase = () => { throw new NotImplementedException(); };

            var path = connectionFile.LocalPath;

            if (IO.File.Exists(path) && ".sde".Equals(IO.Path.GetExtension(path), StringComparison.InvariantCultureIgnoreCase)) {
                createGeodatabase = () => { return new Geodatabase(new DatabaseConnectionFile(connectionFile)); };
            }
            else if (IO.Directory.Exists(path) && ".gdb".Equals(IO.Path.GetExtension(path), StringComparison.InvariantCultureIgnoreCase)) {
                createGeodatabase = () => { return new Geodatabase(new FileGeodatabaseConnectionPath(connectionFile)); };
            }
            else
                throw new System.ArgumentOutOfRangeException(nameof(connectionFile));

            return createGeodatabase();
        }

        private async Task<Dataset?> GetLatestDataset(string name) {
            return await this.Dispatch(() => {
                using var attachment = this._geodatabase!.OpenDataset<Table>(this.QualifyTableName("attachment"));

                using var cursor = attachment.Search(new QueryFilter {
                    WhereClause = $"json LIKE '%\"datasetName\":\"{name}\"%'",
                    PostfixClause = "ORDER BY created_date DESC",
                }, true);

                if (!cursor.MoveNext())
                    return default;

                return System.Text.Json.JsonSerializer.Deserialize<Dataset>(Convert.ToString(cursor.Current["json"])!);
            });
        }

        private async Task<SpatialQueryFilter> BuildSpatialQueryFilter(Dataset dataset, DomainModel.S128.specificUsage? specificUsage) {
            return await this.Dispatch(() => {
                using var surface = this._geodatabase!.OpenDataset<FeatureClass>(this.QualifyTableName("surface"));

                using var cursorS128 = surface.Search(new QueryFilter {
                    WhereClause = $"json LIKE '%\"datasetName\":\"{dataset.DatasetName}\"%'",
                }, false);

                cursorS128.MoveNext();

                Debug.Assert(cursorS128.Current != null);

                if (cursorS128.Current.IsNull("json"))
                    throw new System.ArgumentNullException(nameof(dataset.DatasetName));

                var whereClause = $"upper(ps) = 'S-101' AND (created_data > {dataset.TimestampUTC:dd-MM-yyyy HH:mm:ss} OR las_edited_date > {dataset.TimestampUTC:dd-MM-yyyy HH:mm:ss})";

                whereClause += specificUsage switch {
                    DomainModel.S128.specificUsage.NavigationalPurposeOverview => $" AND usageband = 1",
                    DomainModel.S128.specificUsage.NavigationalPurposeGeneral => $" AND usageband = 2",
                    DomainModel.S128.specificUsage.NavigationalPurposeCoastal => $" AND usageband = 3",
                    DomainModel.S128.specificUsage.NavigationalPurposeApproach => $" AND usageband = 4",
                    DomainModel.S128.specificUsage.NavigationalPurposeHarbour => $" AND usageband = 5",
                    _ => "",
                };

                ArcGIS.Core.Geometry.Polygon shapeCoverage;

                shapeCoverage = (ArcGIS.Core.Geometry.Polygon)((ArcGIS.Core.Data.Feature)cursorS128.Current).GetShape().Clone();

                var filter = new SpatialQueryFilter {
                    FilterGeometry = shapeCoverage,
                    SpatialRelationship = SpatialRelationship.Relation,
                    SpatialRelationshipDescription = Topology.Matrix.DE9IM,
                    WhereClause = whereClause,
                };

                return filter;
            });

        }
    }

    public sealed class SingleThreadTaskScheduler : TaskScheduler, IDisposable
    {
        private readonly BlockingCollection<Task> _tasks;
        private readonly Thread _processingThread;

        public SingleThreadTaskScheduler() {
            _tasks = new BlockingCollection<Task>();

            _processingThread = new Thread(ProcessTasks) {
                IsBackground = true, // Allow the application to exit even if this thread is running
                Name = "SingleThreadTaskScheduler"
            };
            _processingThread.Start();
        }

        private void ProcessTasks() {
            try {
                foreach (var task in _tasks.GetConsumingEnumerable()) {
                    TryExecuteTask(task);
                }
            }
            catch (ObjectDisposedException) {
                // The collection was disposed, which is fine. The thread can exit.
            }
        }

        protected override void QueueTask(Task task) {
            if (_tasks.IsAddingCompleted) return;
            _tasks.Add(task);
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued) {
            if (Thread.CurrentThread == _processingThread) {
                return TryExecuteTask(task);
            }

            // Otherwise, we cannot execute it inline. Let QueueTask handle it.
            return false;
        }

        protected override IEnumerable<Task> GetScheduledTasks() {
            return _tasks.ToArray();
        }

        public override int MaximumConcurrencyLevel => 1;

        public void Dispose() {
            _tasks.CompleteAdding();
            _processingThread.Join();
            _tasks.Dispose();
        }
    }
}
