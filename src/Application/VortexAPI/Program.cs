
using Microsoft.AspNetCore.Builder;
using Scalar.AspNetCore;

namespace VortexAPI
{
    public class Program
    {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Initializing ArcGIS
            ArcGIS.Core.Hosting.Host.Initialize();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    //  /swagger/index.html
                    options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1");
                });

                app.UseReDoc(options =>
                {
                    //  /api-docs/index.html
                    options.SpecUrl("/openapi/v1.json");
                });

                app.MapScalarApiReference(options => {
                    //  /scalar/
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
