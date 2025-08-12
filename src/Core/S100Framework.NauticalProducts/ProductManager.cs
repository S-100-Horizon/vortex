using ArcGIS.Core.Data;
using ArcGIS.Core.Data.Topology;
using ArcGIS.Core.Data.UtilityNetwork.Trace;
using ArcGIS.Core.Geometry;
using S100Framework.Catalogues;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S128.FeatureTypes;
using S100Framework.YAML;
using Serilog;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using IO = System.IO;

namespace S100Framework.NauticalProducts
{
    public interface INauticalProductManager
    {
    }

    public interface IElectronicProductManager
    {
        Task CreateElectronicProductAsync(string name, S100Framework.DomainModel.S128.specificUsage specificUsage, ArcGIS.Core.Geometry.Polygon boundary);

        Task CreateElectronicProductAsync(string name, S100Framework.DomainModel.S128.specificUsage specificUsage, ArcGIS.Core.Geometry.Polygon boundary, int edition, int update, byte[] zipfile);

        Task CreateNewEditionAsync(string ps, string name);

        Task CreateNewUpdateAsync(string ps, string name);
    }

    public interface IProductManager
    {
        INauticalProductManager NauticalProductManager { get; }

        IElectronicProductManager ElectronicProductManager { get; }

        Task Dispatch(Action action);
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

        private ConcurrentDictionary<string, S100Framework.DomainModel.S128.FeatureTypes.ElectronicProduct> _electronicProducts = new ConcurrentDictionary<string, S100Framework.DomainModel.S128.FeatureTypes.ElectronicProduct>();

        private ProductManager() {
            this._singleThreadTaskScheduler = new SingleThreadTaskScheduler();
            this._taskFactory = new TaskFactory(this._singleThreadTaskScheduler);
        }

        protected async Task<ProductManager> InitializeAsync(Func<Geodatabase> creator) {
            await this._taskFactory.StartNew(() => {
                this._geodatabase = creator();

                var tableDefinitions = this._geodatabase.GetDefinitions<TableDefinition>();

                var configuration = tableDefinitions.Single(e => e.GetName().EndsWith("configuration"));

                var syntax = this.SQLSyntax.ParseTableName(configuration.GetName());
                this._databaseName = syntax.Item1;
                this._ownerName = syntax.Item2;

                using var table = this._geodatabase.OpenDataset<Table>(configuration.GetName());

                using var cursor = table.Search(new QueryFilter {
                    WhereClause = "upper(ps) = 'S-128' AND code = 'NauticalProducts'",
                }, true);
                cursor.MoveNext();

                Debug.Assert(cursor.Current != null);

                var c = cursor.Current;

                var code = Convert.ToString(c["code"]);
                if (!string.IsNullOrEmpty(code) && code.Equals("NauticalProducts")) {
                    if (!c.IsNull("json")) {
                        var settings = System.Text.Json.JsonSerializer.Deserialize<Settings.NauticalProducts>(Convert.ToString(c["json"])!);

                        if (settings != null) {
                            foreach (var connection in settings.Connections) {
                                var geodatabase = this.OpenGeodatabase(connection.ConnectionFile);
                                _connections.Add(connection.ProductSpecification.ToUpperInvariant(), geodatabase);
                            }
                        }
                    }
                }
            });

            await this._taskFactory.StartNew(() => {
                using (var surface = this.OpenDataset<FeatureClass>("surface")) {
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
                action?.Invoke();
            });
        }

        Task IElectronicProductManager.CreateElectronicProductAsync(string name, DomainModel.S128.specificUsage specificUsage, ArcGIS.Core.Geometry.Polygon boundary) {
            if (string.IsNullOrEmpty(name))
                throw new System.ArgumentNullException(nameof(name));

            name = name.ToUpperInvariant();

            return this._taskFactory.StartNew(() => {
                if (this._electronicProducts.ContainsKey(name))
                    throw new System.ArgumentException("An element with the same key already exists!");

                using (var surface = this.OpenDataset<FeatureClass>("surface")) {
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
                    };

                    buffer["json"] = System.Text.Json.JsonSerializer.Serialize(electronicProduct);
                    buffer["shape"] = boundary;
                    surface.CreateRow(buffer);

                    var result = this._electronicProducts.TryAdd(name, electronicProduct);
                    Debug.Assert(result);
                }
            });

        }

        Task IElectronicProductManager.CreateElectronicProductAsync(string name, DomainModel.S128.specificUsage specificUsage, ArcGIS.Core.Geometry.Polygon boundary, int edition, int update, byte[] zipfile) {
            throw new NotImplementedException();
        }

        async Task IElectronicProductManager.CreateNewEditionAsync(string ps, string name) {
            if (string.IsNullOrEmpty(ps))
                throw new System.ArgumentNullException(nameof(ps));
            ps = ps.ToUpperInvariant();

            if (string.IsNullOrEmpty(name))
                throw new System.ArgumentNullException(nameof(name));
            name = name.ToUpperInvariant();

            if (!this._connections.ContainsKey(ps))
                throw new System.ArgumentException(nameof(ps));
            if (!this._electronicProducts.ContainsKey(name))
                throw new System.ArgumentException(nameof(name));

            var connection = this._connections[ps]!;
            var electricProduct = this._electronicProducts[name];

            var whereClause = "upper(ps) = 'S-101'";

            whereClause += electricProduct.specificUsage switch {
                DomainModel.S128.specificUsage.NavigationalPurposeOverview => $" AND usageband = 1",
                DomainModel.S128.specificUsage.NavigationalPurposeGeneral => $" AND usageband = 2",
                DomainModel.S128.specificUsage.NavigationalPurposeCoastal => $" AND usageband = 3",
                DomainModel.S128.specificUsage.NavigationalPurposeApproach => $" AND usageband = 4",
                DomainModel.S128.specificUsage.NavigationalPurposeHarbour => $" AND usageband = 5",
                _ => "",
            };

            var featureCatalogue = S100Framework.Catalogues.FeatureCatalogue.Catalogues.Single(e => e.ProductID.Equals("S-101"));

            await this._taskFactory.StartNew(() => {
                ArcGIS.Core.Geometry.Polygon shape;

                using (var surface = this._geodatabase!.OpenDataset<FeatureClass>(this.QualifyTableName("surface"))) {
                    using var cursor = surface.Search(new QueryFilter {
                        WhereClause = $"json LIKE '%\"datasetName\":\"{electricProduct!.datasetName!}\"%'",
                    }, true);

                    cursor.MoveNext();

                    Debug.Assert(cursor.Current != null);

                    shape = (ArcGIS.Core.Geometry.Polygon)((ArcGIS.Core.Data.Feature)cursor.Current).GetShape();
                }

                var dataset = new S100Framework.YAML.Dataset {
                    CellName = $"{electricProduct!.datasetName!}.000",
                    Comment = electricProduct.notForNavigation ? "Not for navigation!" : string.Empty,
                    Edition = (uint?)electricProduct.editionNumber++,
                    ENCVer = "INT.IHO.S-101.2.0",
                    FCVer = "2.0",
                    verticalDatum = "Baltic Sea Chart Datum 2000,44",
                };

                //  Topology                
                var filter = new SpatialQueryFilter {
                    FilterGeometry = shape,
                    SpatialRelationship = SpatialRelationship.Relation,
                    SpatialRelationshipDescription = "T*****FF*",
                    WhereClause = whereClause,
                };

                var topology = connection.BuildTopology(filter)!;
                dataset.AddTopology(topology);

                //  InformationTypes
                {
                    using var informationType = connection.OpenDataset<Table>(this.QualifyTableName("informationtype"));

                    using var informationCursor = informationType.Search();
                    while (informationCursor.MoveNext()) {
                        var current = informationCursor.Current;

                        var name = current["name"].ToString()!;
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

                var geometries = new List<(Geometry geometry, string name)>();

                //  Features
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
                        using var cursor = fc.Search(filter, true);
                        while (cursor.MoveNext()) {
                            var current = (ArcGIS.Core.Data.Feature)cursor.Current;
                            var name = Convert.ToString(current["name"])!;

                            //if (name.Equals("S12233")) System.Diagnostics.Debugger.Break();
                            //if (name.Equals(topology.Surfaces.ElementAt(0).Ref)) System.Diagnostics.Debugger.Break();

                            // Only map geometry, and keep name seperate so foids remain unique
                            var geometry = name;

                            if (topology.Mapping.TryGetValue(name!, out var value))
                                geometry = value;
                            else if (!name.StartsWith("P"))
                                System.Diagnostics.Debugger.Break();

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

                                var feature = new YAML.Feature {
                                    Name = code,
                                    Foid = foid,
                                    Prim = prim,
                                    Geometry = geometry,
                                };

                                // Only emit attributes if feature contains any non-static properties
                                if (!S100Framework.YAML.Converter.IsDefault(instance!))
                                    feature.Attributes = (FeatureNode)instance!;

                                // Information Associations
                                if (!current.IsNull("informationbindings")) {
                                    using var document = JsonDocument.Parse(Convert.ToString(current["informationbindings"])!);
                                    var root = document.RootElement;

                                    var association = root.GetProperty("association").GetString()!;
                                    var role = root.GetProperty("role").GetString()!;
                                    var informationId = root.GetProperty("informationId").GetString()!;

                                    var asso = new YAML.Association {
                                        Name = association,
                                        Role = role,
                                        To = informationId,
                                    };

                                    // Special case for SpatialAssociation
                                    if (prim != Primitive.Surface && association.Equals("SpatialAssociation", StringComparison.CurrentCultureIgnoreCase)) {
                                        var curve = dataset?.Curves?.FirstOrDefault(e => e.Name == geometry);

                                        curve?.AddAssociation(asso);
                                    }
                                    else {
                                        feature?.AddAssociation(asso);
                                    }
                                }

                                // Feature Associations
                                if (!current.IsNull("featurebindings")) {
                                    using var document = JsonDocument.Parse(Convert.ToString(current["featurebindings"])!);
                                    var root = document.RootElement;

                                    if (root.ValueKind == JsonValueKind.Array) {
                                        foreach (var element in root.EnumerateArray()) {
                                            var roleType = element.GetProperty("roleType").GetString();

                                            // Skip association roleType for now
                                            if (roleType == "association")
                                                continue;

                                            var association = element.GetProperty("association").GetString()!;
                                            var role = element.GetProperty("role").GetString()!;
                                            var featureId = element.GetProperty("featureId").GetString()!;


                                            var asso = new YAML.Association {
                                                Name = association,
                                                Role = role,
                                                To = $"110:{featureId[1..]}:1"
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
                                continue;
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

                var yaml = S100Framework.YAML.Converter.Serialize(dataset!);
            });
        }

        Task IElectronicProductManager.CreateNewUpdateAsync(string ps, string name) {
            throw new NotImplementedException();
        }

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

        private T OpenDataset<T>(string name) where T : ArcGIS.Core.Data.Dataset {
            var typeFromHandle = typeof(T);
            if (typeFromHandle == typeof(FeatureClass) || typeFromHandle == typeof(Table)) {
                return this._geodatabase!.OpenDataset<T>(this.QualifyTableName(name));
            }
            throw new System.ArgumentException();
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
