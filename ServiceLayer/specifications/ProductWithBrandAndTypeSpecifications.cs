using DomainLayer.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.specifications
{
    public class ProductWithBrandAndTypeSpecifications : BaseSpecifications<Product,int>
    {
        public ProductWithBrandAndTypeSpecifications(ProductQueryParameters queryParameters) 
            :base(p=>(!queryParameters.BrandId.HasValue || p.BrandId == queryParameters.BrandId) 
            && (!queryParameters.TypeId.HasValue || p.TypeId == queryParameters.TypeId)
            &&(string.IsNullOrEmpty(queryParameters.SearchValue) || p.Name.ToLower().Contains(queryParameters.SearchValue.ToLower()))

            )
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);

            switch (queryParameters.SortingOptions) {

                case ProductSortingOptions.NameAsc:
                    AddOrderBy(p => p.Name);
                    break;
                case ProductSortingOptions.NameDesc:
                    AddOrderBy(p => p.Name);
                    break;
                case ProductSortingOptions.PriceAsc:
                    AddOrderBy(p => p.Price);
                    break;
                case ProductSortingOptions.PriceDesc:
                    AddOrderBy(p => p.Price);
                    break;

                default:
                    break;
            }

            ApplyPagination(queryParameters.PageSize, queryParameters.PageIndex);


        }

        public ProductWithBrandAndTypeSpecifications(int id) : base(p =>p.Id==id)
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
        }
    }
}
