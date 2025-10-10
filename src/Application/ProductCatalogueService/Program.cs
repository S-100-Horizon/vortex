using ArcGIS.Core.Data;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Mvc; // Required for ApiVersion
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models; // Required for AddApiVersioning

namespace ProductCatalogueService
{
    public class Program
    {
        public static async Task Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddSwaggerGen(c => {
            //    c.EnableAnnotations();
            //     c.SwaggerDoc("v1", new OpenApiInfo());   //  { Title = "ProductCatalogueService", Version = "v1" }
            //});

            builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
                .AddNegotiate();

            builder.Services.AddAuthorization(options => {
                // By default, all incoming requests will be authorized according to the default policy.
                options.FallbackPolicy = options.DefaultPolicy;
            });

            builder.Services.AddApiVersioning(options => {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            builder.Services.AddRouting(options => {
                options.LowercaseUrls = true;
            });

            // Setup ArcGIS and ProductManager
            ArcGIS.Core.Hosting.Host.Initialize();

            // Set output path to bin
            var output = new DirectoryInfo(Path.Combine(AppContext.BaseDirectory, "s100ed9.gdb"));

            if (!output.Exists)
                new FastZip().ExtractZip("s100ed9.gdb.zip", output.FullName, null);


            var productManager = await S100Framework.ProductCatalogue.ProductManager.CreateInstanceAsync(() => {
                var connectionFile = new FileGeodatabaseConnectionPath(new Uri(Path.GetFullPath(output.FullName)));

                return new Geodatabase(connectionFile);
            });


            builder.Services.AddSingleton(productManager);


            // Caching
            builder.Services.AddMemoryCache();

            // Problem details & Exception handling
            //builder.Services.AddProblemDetails();
            //builder.Services.AddExceptionHandler<CustomExceptionHandler>();

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}