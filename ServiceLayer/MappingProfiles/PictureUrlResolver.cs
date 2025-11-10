using AutoMapper;
using AutoMapper.Execution;
using DomainLayer.Models.ProductModels;
using Microsoft.Extensions.Configuration;
using Shared.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.MappingProfiles
{
    internal class PictureUrlResolver(IConfiguration _configuration) : IValueResolver<Product, ProductDto, string>
    {
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.PictureUrl))
                return string.Empty;
            else {

                var pictureUrl = $"{_configuration.GetSection("Urls")["baseUrl"]}{source.PictureUrl}";
                return pictureUrl;
            }
        }
    }
}
