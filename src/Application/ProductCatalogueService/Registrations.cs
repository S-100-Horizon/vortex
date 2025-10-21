using ArcGIS.Core.Data;
using ICSharpCode.SharpZipLib.Zip;

namespace ProductCatalogueService
{
    public static class Registrations
    {
        public static async Task AddS100(this IServiceCollection services) {
            // Setup ArcGIS and ProductManager
            ArcGIS.Core.Hosting.Host.Initialize();

            // Use the attached .zip gdb when developing
            if (System.Diagnostics.Debugger.IsAttached) {
                // If no .gdb exist in bin, extract the .zip from project root
                var output = new DirectoryInfo(Path.Combine(AppContext.BaseDirectory, "s100ed9.gdb"));

                if (!output.Exists)
                    new FastZip().ExtractZip("s100ed9.gdb.zip", Path.Combine(AppContext.BaseDirectory, "s100ed9.gdb"), null);

                var productManager = await S100Framework.ProductCatalogue.ProductManager.CreateInstanceAsync(() => {
                    var connectionFile = new FileGeodatabaseConnectionPath(new Uri(Path.GetFullPath(output.FullName)));

                    return new Geodatabase(connectionFile);
                });


                services.AddSingleton(productManager);
            }
            else {
                // Connect to prod DB
                var path = Environment.GetEnvironmentVariable("S100-Horizon-S101-Database");

                if (string.IsNullOrEmpty(path))
                    throw new ArgumentNullException("Environment variable is null!");

                var productManager = await S100Framework.ProductCatalogue.ProductManager.CreateInstanceAsync(() => {
                    if (".sde".Equals(System.IO.Path.GetExtension(path), StringComparison.OrdinalIgnoreCase)) {
                        var connectionFile = new DatabaseConnectionFile(new Uri(System.IO.Path.GetFullPath(path)));

                        return new Geodatabase(connectionFile);
                    }
                    else if (".gdb".Equals(System.IO.Path.GetExtension(path), StringComparison.OrdinalIgnoreCase)) {
                        var connectionFile = new FileGeodatabaseConnectionPath(new Uri(Path.GetFullPath(path)));

                        return new Geodatabase(connectionFile);
                    }
                    else {
                        throw new InvalidOperationException("Connectionfile path is neither .gdb nor .sde");
                    }

                });

                services.AddSingleton(productManager);
            }
        }
    }
}
