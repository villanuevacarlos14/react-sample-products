using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using product.inventory.data.repository;
using product.inventory.dto;
using System.Linq;
using System;
using product.inventory.data.models;
using System.Linq.Expressions;

namespace product.inventory.service
{
    public interface IProductService
    {
        Task<ProductDto> GetProduct(int id);
        Task<IEnumerable<ProductDto>> GetProducts(string name = "");
        Task<int> SaveProduct(ProductDto product);
        Task<ProductDto> UpdateProduct(ProductDto product);
        Task Delete(int id);
    }
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task Delete(int id)
        {
            var product = await _productRepository.GetAsync(id).ConfigureAwait(false);
            await _productRepository.Delete(product).ConfigureAwait(false);
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            var product = await _productRepository.GetAsync(id).ConfigureAwait(false);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts(string name = "")
        {
            Expression<Func<Product, bool>> predicate = _ => true;

            if (!string.IsNullOrEmpty(name))
            {
                predicate = x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase);
            }

            var products = await _productRepository.GetAll(x => x.ProductInventory, x => x.ProductInventory.ProductInventoryLogs).Where(predicate).ToListAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<int> SaveProduct(ProductDto product)
        {
            var result = await _productRepository.AddAsync(_mapper.Map<Product>(product)).ConfigureAwait(false);
            return result.Id;
        }

        public async Task<ProductDto> UpdateProduct(ProductDto product)
        {
            var result = await _productRepository.UpdateAsync(_mapper.Map<Product>(product)).ConfigureAwait(false);
            return _mapper.Map<ProductDto>(result);
        }
    }
}