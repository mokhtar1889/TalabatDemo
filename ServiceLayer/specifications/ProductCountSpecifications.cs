using DomainLayer.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.specifications
{
    public class ProductCountSpecifications : BaseSpecifications<Product , int>
    {
        public ProductCountSpecifications(ProductQueryParameters queryParameters)
    : base(p => (!queryParameters.BrandId.HasValue || p.BrandId == queryParameters.BrandId)
    && (!queryParameters.TypeId.HasValue || p.TypeId == queryParameters.TypeId)
    && (string.IsNullOrEmpty(queryParameters.SearchValue) || p.Name.ToLower().Contains(queryParameters.SearchValue.ToLower())))
      {}



    }
}
