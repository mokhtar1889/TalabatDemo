using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
using ServiceAbstractionLayer;
using ServiceLayer.specifications;
using Shared.DTOs;


namespace ServiceLayer
{
    public class ProductService(IUnitOfWork _unitOfWork , IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var specs = new ProductWithBrandAndTypeSpecifications();
            var repo = _unitOfWork.GetRepository<Product, int>();
            var Product = await repo.GetAllAsync(specs);
            var ProductDtos = _mapper.Map<IEnumerable<ProductDto>>(Product);
            return ProductDtos;
        }

        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.GetRepository<ProductType , int>().GetAllAsync();
            return _mapper.Map<IEnumerable<TypeDto>>(types);
        }

        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var repo = _unitOfWork.GetRepository<ProductBrand, int>();
            var brand = await repo.GetAllAsync();
            var bradsDtos = _mapper.Map <IEnumerable<BrandDto>> (brand);
            return bradsDtos;
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
