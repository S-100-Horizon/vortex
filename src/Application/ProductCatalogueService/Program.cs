using ArcGIS.Core.Data;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Mvc; // Required for ApiVersion
using Microsoft.OpenApi.Models; // Required for AddApiVersioning
using Serilog;
using Serilog.Events;
using System.Reflection;

namespace ProductCatalogueService
{
    public class Program
    {
        private const string outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff}| [{Level:u3}] [{SourceContext}] {Message:lj} {NewLine}{Exception}";
        public static async Task Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            if (!(System.Diagnostics.Debugger.IsAttached)) {
                Log.Logger = new LoggerConfiguration().MinimumLevel.Verbose().WriteTo.File(
                        System.IO.Path.Combine(@"\\nas.gst.dk\public\applications\serilog\Applications\ProductCatalogueAPI", $"{Environment.MachineName}", "bootstrap.log"),
                        rollingInterval: RollingInterval.Infinite,
                        retainedFileCountLimit: 1,
                        shared: true,
                        flushToDiskInterval: TimeSpan.FromMinutes(10),
                        outputTemplate: outputTemplate).CreateLogger();
            }

            // logging 
            builder.Host.UseSerilog((context, loggerConfiguration) => {
                loggerConfiguration.MinimumLevel.Verbose()
                     .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                     .MinimumLevel.Override("Geodatastyrelsen", LogEventLevel.Verbose)

                     .Enrich.FromLogContext()
                     .Enrich.WithProperty("MachineName", Environment.MachineName)
                     .WriteTo.Console(outputTemplate: outputTemplate, restrictedToMinimumLevel: LogEventLevel.Verbose);

                if (System.Diagnostics.Debugger.IsAttached) {
                    loggerConfiguration = loggerConfiguration
                        .WriteTo.File(
                             System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Geodatastyrelsen", "ProductCatalogueAPI", "ProductCatalogueAPI-developer.log"),
                            rollingInterval: RollingInterval.Month,
                            retainedFileCountLimit: 1,
                             shared: true,
                             outputTemplate: outputTemplate);
                }
                else {
                    loggerConfiguration = loggerConfiguration.WriteTo.File(
                        System.IO.Path.Combine(@"\\nas.gst.dk\public\applications\serilog\Applications\ProductCatalogueAPI", $"{Environment.MachineName}", "ProductCatalogueAPI.log"),
                        rollingInterval: RollingInterval.Day,
                        retainedFileCountLimit: 180,
                        shared: true,
                        flushToDiskInterval: TimeSpan.FromMinutes(10),
                        outputTemplate: outputTemplate);
                }
            });

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSwaggerGen(options => {
                //options.SwaggerDoc("v1", new OpenApiInfo {
                //    Title = "ProductCatalogue API",
                //    Version = "v1",
                //    Description = "OpenAPI 3 (Swagger)"
                //});

                // Include XML comments if generated
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                    options.IncludeXmlComments(xmlPath);

            });


            builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();

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


                builder.Services.AddSingleton(productManager);
            }
            else {
                // Connect to prod DB
                var path = Environment.GetEnvironmentVariable("S100-Horizon-S101-Database");

                if (string.IsNullOrEmpty(path))
                    throw new ArgumentNullException("Environment variable is null!");

                var productManager = await S100Framework.ProductCatalogue.ProductManager.CreateInstanceAsync(() => {
                    var connectionFile = new FileGeodatabaseConnectionPath(new Uri(Path.GetFullPath(path)));

                    return new Geodatabase(connectionFile);
                });

                builder.Services.AddSingleton(productManager);
            }

            // Problem details & Exception handling
            builder.Services.AddProblemDetails();
            builder.Services.AddExceptionHandler<CustomExceptionHandler>();

            // Caching
            builder.Services.AddMemoryCache();

            var app = builder.Build();

            app.UseExceptionHandler();

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