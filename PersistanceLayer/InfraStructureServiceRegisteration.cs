using DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersistanceLayer.Data;
using PersistanceLayer.Repositories;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistanceLayer
{
    public static class InfraStructureServiceRegisteration
    {
        public static IServiceCollection AddInfraStructureService(this IServiceCollection Services , IConfiguration _configuration) {

            Services.AddDbContext<StoreDbContext>(options =>
            {

                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));

            });
            Services.AddScoped<IDataSeeding, DataSeed>();
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddScoped<IBasketRepository, BasketRepository>();
            Services.AddSingleton<IConnectionMultiplexer>( (_) => { 

                return ConnectionMultiplexer.Connect(_configuration.GetConnectionString("ReddiseConnectionString"));
            
            
            });

            return Services;
        }
    }
}
