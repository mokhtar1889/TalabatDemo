using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProductQueryParameters
    {
        // int? brandId , int? typeId, ProductSortingOptions sortingOptions

        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public ProductSortingOptions SortingOptions { get; set; }
        public string? SearchValue { get; set; }

        private const int DefautPageSize = 5;

        private const int MaxPageSize= 10;
        public int PageIndex { get; set; } = 1;

        private int pageSize;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > MaxPageSize ? DefautPageSize : value; }
        }


    }
}
