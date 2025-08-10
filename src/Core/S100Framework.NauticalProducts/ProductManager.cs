using ArcGIS.Core.Data;
using ArcGIS.Desktop.Internal.Catalog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO = System.IO;

namespace S100Framework.NauticalProducts
{
    public interface IProductManager
    {

    }

    public class ProductManager : IProductManager, IDisposable
    {
        public static async Task<IProductManager> CreateInstanceAsync(Func<Geodatabase> creator) => await new ProductManager().Initialize(creator);

        private bool _disposed = false;

        private Geodatabase? _geodatabase = default;

        private IDictionary<string, Geodatabase> _connections = new Dictionary<string, Geodatabase>();

        private ProductManager() { }

        protected async Task<ProductManager> Initialize(Func<Geodatabase> creator) {
            await Utils.StartOnUIThread(() => {
                this._geodatabase = creator();

                var tableDefinitions = this._geodatabase.GetDefinitions<TableDefinition>();

                var configuration = tableDefinitions.Single(e => e.GetName().EndsWith("configuration"));

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

            return this;
        }

        public void Dispose() {
            if (!this._disposed) {

                foreach (var e in this._connections) {
                    e.Value.Dispose();
                }
                this._geodatabase?.Dispose();
                this._disposed = true;
            }

            // Prevent the finalizer from running, since we've already cleaned up.
            GC.SuppressFinalize(this);
        }

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
    }
}
