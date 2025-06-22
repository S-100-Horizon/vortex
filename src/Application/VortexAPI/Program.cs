
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
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.MapOpenApi();

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
