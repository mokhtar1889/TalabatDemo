using AutoMapper;
using DomainLayer.Models;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,ProductDto>()
            .ForMember(des => des.BrandName , options => options.MapFrom(src => src.ProductBrand.Name))
            .ForMember(des => des.TypeName, options => options.MapFrom(src => src.ProductType.Name));


            CreateMap<ProductType, TypeDto>();
            CreateMap<ProductBrand, BrandDto>();
        }

    }
}
