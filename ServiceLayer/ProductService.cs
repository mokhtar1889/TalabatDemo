using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
using ServiceAbstractionLayer;
using ServiceLayer.specifications;
using Shared;
using Shared.DTOs;


namespace ServiceLayer
{
    public class ProductService(IUnitOfWork _unitOfWork , IMapper _mapper) : IProductService
    {
        public async Task<PaginatedResult<ProductDto>> GetAllProductsAsync(ProductQueryParameters queryParameters)
        {
            var specs = new ProductWithBrandAndTypeSpecifications(queryParameters);
            var repo = _unitOfWork.GetRepository<Product, int>();
            var Product = await repo.GetAllAsync(specs);
            var mappedProoducts = _mapper.Map<IEnumerable<ProductDto>>(Product);
            var objectToReturn = new PaginatedResult<ProductDto>(queryParameters.PageIndex,queryParameters.PageSize,0,mappedProoducts);
            var countSpecs = new ProductCountSpecifications(queryParameters);
            var totalCount = await repo.CountAsync(countSpecs);
            return objectToReturn;
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
            var specs = new ProductWithBrandAndTypeSpecifications(id);
            var product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(specs);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
