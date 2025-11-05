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
        private const string outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff}| [{Level:u3}] {Message:lj} {NewLine}{Exception}";
        public static async Task Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // logging 
            builder.Host.UseSerilog((context, loggerConfiguration) => {
                loggerConfiguration.MinimumLevel.Information()
                     .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                     .Enrich.FromLogContext()
                     .Enrich.WithProperty("MachineName", Environment.MachineName)
                     .WriteTo.Console(outputTemplate: outputTemplate, restrictedToMinimumLevel: LogEventLevel.Verbose)
                     .WriteTo.File("ProductCatalogue.log",
                            rollingInterval: RollingInterval.Month,
                            retainedFileCountLimit: 1,
                            shared: true,
                            outputTemplate: outputTemplate);

                if (System.Diagnostics.Debugger.IsAttached) {
                    loggerConfiguration = loggerConfiguration
                        .WriteTo.File(
                            System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProductCatalogue", "ProductCatalogueAPI-developer.log"),
                            rollingInterval: RollingInterval.Month,
                            retainedFileCountLimit: 1,
                            shared: true,
                            outputTemplate: outputTemplate);
                }
            });

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSwaggerGen(options => {
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

            // Configure ArcGIS and ProductManager
            await builder.Services.AddS100();

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

            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/") {
                    context.Response.Redirect("/swagger");
                    return;
                }
                await next();
            });

            app.MapControllers();

            app.Run();
        }
    }
}