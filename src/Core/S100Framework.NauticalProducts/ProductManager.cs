using ArcGIS.Core.Data;
using ArcGIS.Desktop.Internal.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO = System.IO;

namespace S100Framework.NauticalProducts
{
    public interface iProductManager {

    }

    public class ProductManager : iProductManager
    {
        public static async Task<iProductManager> CreateInstanceAsync(Settings.NauticalProducts settings) => await new ProductManager().Initialize(settings);

        private Geodatabase? _geodatabase = default;

        private ProductManager() { }

        protected async Task<ProductManager> Initialize(Settings.NauticalProducts settings) {
            var connection = settings.ConnectionFile;

            Func<Geodatabase> createGeodatabase = () => { throw new NotImplementedException(); };

            if (IO.File.Exists(connection) && ".sde".Equals(IO.Path.GetExtension(connection), StringComparison.InvariantCultureIgnoreCase)) {
                createGeodatabase = () => { return new Geodatabase(new DatabaseConnectionFile(new Uri(IO.Path.GetFullPath(connection)))); };
            }
            else if (IO.Directory.Exists(connection) && ".gdb".Equals(IO.Path.GetExtension(connection), StringComparison.InvariantCultureIgnoreCase)) {
                createGeodatabase = () => { return new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(connection)))); };
            }
            else
                throw new System.ArgumentOutOfRangeException(nameof(settings));

            await Utils.StartOnUIThread(() => {
                this._geodatabase = createGeodatabase();
            });

            return this;
        }
    }
}
