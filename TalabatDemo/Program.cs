
using DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using PersistanceLayer;
using PersistanceLayer.Data;
using PersistanceLayer.Repositories;
using ServiceLayer;

namespace TalabatDemo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreDbContext>(options =>
            {

                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });
            builder.Services.AddScoped<IDataSeeding,DataSeed>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper((x) => { } , typeof(ServiceLayerAssemblyReference).Assembly);

            var app = builder.Build();

            using var scope = app.Services.CreateScope();
            var seedObj = scope.ServiceProvider.GetRequiredService<IDataSeeding>();
            await seedObj.DataSeedAsync();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
