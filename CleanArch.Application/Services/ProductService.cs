using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var products = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProductCategoryAsync(int? id)
        {
            var productCategory = await _productRepository.GetProductsCategoryAsync(id);
            return _mapper.Map<ProductDTO>(productCategory);
        }

        public async Task<ProductDTO> GetAsync(int? id)
        {
            var product = await _productRepository.GetAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task CreateAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.CreateAsync(product);
        }

        public async Task UpdateAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.UpdateAsync(product);
        }

        public async Task RemoveAsync(int? id)
        {
            var product = _productRepository.GetAsync(id).Result;
            await _productRepository.RemoveAsync(product);
        }
    }
}
