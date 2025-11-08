
using Azure;
using DomainLayer.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersistanceLayer;
using PersistanceLayer.Data;
using PersistanceLayer.Repositories;
using ServiceAbstractionLayer;
using ServiceLayer;
using Shared.ErrorModels;
using TalabatDemo.CustomMiddelwares;
using TalabatDemo.Extensions;
using TalabatDemo.Factory;

namespace TalabatDemo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddSwaggerService();

            builder.Services.AddInfraStructureService(builder.Configuration);

            builder.Services.AddApplicationServices();

            builder.Services.AddWebApplicationServices();

            var app = builder.Build();

            using var scope = app.Services.CreateScope();
            var seedObj = scope.ServiceProvider.GetRequiredService<IDataSeeding>();
            await seedObj.DataSeedAsync();

            app.UseMiddleware<CustomExceptionHandlerMiddelware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}
