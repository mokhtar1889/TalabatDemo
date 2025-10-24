using DomainLayer.Contracts;
using DomainLayer.Models;
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
        void IDataSeeding.DataSeed()
        {

            try {

                if (_storeDbContext.Database.GetPendingMigrations().Any())
                {

                    _storeDbContext.Database.Migrate();
                }

                if (_storeDbContext.ProductBrands.Any())
                {

                    var productsBrandsData = File.ReadAllText(@"..\PersistanceLayer\Data\SeedData\brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(productsBrandsData);

                    if (brands is not null && brands.Any())
                    {

                        _storeDbContext.ProductBrands.AddRange(brands);
                    }

                }

                if (_storeDbContext.ProductTypes.Any())
                {

                    var productsTypesData = File.ReadAllText(@"..\PersistanceLayer\Data\SeedData\types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(productsTypesData);

                    if (types is not null && types.Any())
                    {

                        _storeDbContext.ProductTypes.AddRange(types);
                    }

                }

                if (_storeDbContext.Products.Any())
                {

                    var productsData = File.ReadAllText(@"..\PersistanceLayer\Data\SeedData\products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    if (products is not null && products.Any())
                    {

                        _storeDbContext.Products.AddRange(products);
                    }

                }

            }
            catch (Exception ex) {
            
            
            }



        }
    }
}
