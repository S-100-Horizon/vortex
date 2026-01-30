using ArcGIS.Core.Data;
using ICSharpCode.SharpZipLib.Zip;
using Serilog;

namespace ProductCatalogueService
{
    public static class Registrations
    {
        public static async Task AddS100(this IServiceCollection services) {
            // Setup ArcGIS and ProductManager
            ArcGIS.Core.Hosting.Host.Initialize(ArcGIS.Core.Hosting.Host.LicenseProductCode.ArcGISPro);
            Log.Logger.Information("ArcGIS Core Host Initialized");

            // Connect to prod
            var path = Environment.GetEnvironmentVariable("S100-Horizon-S128-Database");

            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("Environment variable for S128-Database is null!");

            var productManager = await S100FC.ProductCatalogue.ProductManager.CreateInstanceAsync(() => {
                if (".sde".Equals(System.IO.Path.GetExtension(path), StringComparison.OrdinalIgnoreCase)) {
                    var connectionFile = new DatabaseConnectionFile(new Uri(System.IO.Path.GetFullPath(path)));

                    return new Geodatabase(connectionFile);
                }
                else if (".gdb".Equals(System.IO.Path.GetExtension(path), StringComparison.OrdinalIgnoreCase)) {
                    var connectionFile = new FileGeodatabaseConnectionPath(new Uri(Path.GetFullPath(path)));

                    return new Geodatabase(connectionFile);
                }
                else {
                    throw new InvalidOperationException("Connectionfile path for S128-Database is neither .gdb nor .sde");
                }
            });

            services.AddSingleton(productManager);
        }
    }
}