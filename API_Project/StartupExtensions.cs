using Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence;
using Persistence.Data;
using System.Configuration;

namespace API_Project
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices(builder.Configuration);
            builder.Services.AddPersistenceServices(builder.Configuration);
            

            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
                options.AddPolicy("open", builder => builder.AllowAnyOrigin()
                .AllowAnyHeader().AllowAnyMethod()));

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app, IWebHostEnvironment env) {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });

            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("open");
            app.MapControllers();
            return app;
        }

        //private static void AddSwagger(IServiceCollection services)
        //{
        //    services.AddSwaggerGen(c =>
        //    { 
        //        c.SwaggerDoc("v1", new OpenApiInfo {
        //        Version = "v1",
        //        Title = "crud test api app",

        //    });
        //        c.OperationFilter<FileResultContentTypeOperationFilter>();
        //});

        //}
    }
}
