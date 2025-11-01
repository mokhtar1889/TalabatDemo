using DomainLayer.Models;
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
        public ProductWithBrandAndTypeSpecifications():base(null)
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
        }
    }
}
