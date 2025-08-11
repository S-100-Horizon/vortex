using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using IO = System.IO;

namespace S100Framework.NauticalProducts
{
    public interface INauticalProductManager
    {
        Task CreateElectronicProductAsync(string name, S100Framework.DomainModel.S128.specificUsage specificUsage, Polygon boundary);
    }

    public interface IProductManager
    {
        INauticalProductManager NauticalProductManager { get; }

        Task Dispatch(Action action);
    }

    public class ProductManager : IProductManager, INauticalProductManager, IDisposable
    {
        public static async Task<IProductManager> CreateInstanceAsync(Func<Geodatabase> creator) => await new ProductManager().InitializeAsync(creator);

        private bool _disposed = false;

        private SingleThreadTaskScheduler _singleThreadTaskScheduler;

        private TaskFactory _taskFactory;

        private Geodatabase? _geodatabase = default;

        private string _databaseName = string.Empty;
        private string _ownerName = string.Empty;

        private IDictionary<string, Geodatabase> _connections = new Dictionary<string, Geodatabase>();

        private ConcurrentDictionary<string, S100Framework.DomainModel.S128.FeatureTypes.NavigationalProduct> _nauticalProducts = new ConcurrentDictionary<string, S100Framework.DomainModel.S128.FeatureTypes.NavigationalProduct>();

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
                    WhereClause = "upper(ps) = 'S-128'",
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
                            this._nauticalProducts.GetOrAdd(electronicProduct.datasetName!.ToLowerInvariant(), electronicProduct);
                        }
                    }
                }
            });

            return this;
        }

        public INauticalProductManager NauticalProductManager => this;

        public Task Dispatch(Action action) {
            return this._taskFactory.StartNew(() => {
                action?.Invoke();
            });
        }

        public Task CreateElectronicProductAsync(string name, S100Framework.DomainModel.S128.specificUsage specificUsage, Polygon boundary) {
            if (string.IsNullOrEmpty(name))
                throw new System.ArgumentNullException(nameof(name));

            name = name.ToUpperInvariant();

            return this._taskFactory.StartNew(() => {
                if (this._nauticalProducts.ContainsKey(name))
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
                    surface.CreateRow(buffer);

                    var result = this._nauticalProducts.TryAdd(name, electronicProduct);
                    Debug.Assert(result);
                }
            });
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

            var path = connectionFile.AbsolutePath;

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

        private T OpenDataset<T>(string name) where T : Dataset {
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
