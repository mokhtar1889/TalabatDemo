using DomainLayer.Contracts;
using DomainLayer.Models.ProductModels;
using Microsoft.EntityFrameworkCore;
using PersistanceLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersistanceLayer
{
    public class DataSeed(StoreDbContext _storeDbContext) : IDataSeeding
    {
        async Task IDataSeeding.DataSeedAsync()
        {


                if ((await _storeDbContext.Database.GetPendingMigrationsAsync()).Any())
                {

                   await _storeDbContext.Database.MigrateAsync();
                }

                if (_storeDbContext.ProductBrands.Any())
                {

                    var productsBrandsData = File.OpenRead(@"..\infrastructure\PersistanceLayer\Data\SeedData\brands.json");

                    var brands = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(productsBrandsData);

                    if (brands is not null && brands.Any())
                    {

                       await _storeDbContext.ProductBrands.AddRangeAsync(brands);
                    }

                }

                if (_storeDbContext.ProductTypes.Any())
                {

                    var productsTypesData = File.OpenRead(@"..\infrastructure\PersistanceLayer\Data\SeedData\types.json");

                    var types =await JsonSerializer.DeserializeAsync<List<ProductType>>(productsTypesData);

                    if (types is not null && types.Any())
                    {

                        await _storeDbContext.ProductTypes.AddRangeAsync(types);
                    }

                }

                if (_storeDbContext.Products.Any())
                {

                    var productsData = File.OpenRead(@"..\infrastructure\PersistanceLayer\Data\SeedData\products.json");

                    var products = await JsonSerializer.DeserializeAsync<List<Product>>(productsData);

                    if (products is not null && products.Any())
                    {

                        await _storeDbContext.Products.AddRangeAsync(products);
                    }

                }

               await _storeDbContext.SaveChangesAsync();


        }
    }
}
