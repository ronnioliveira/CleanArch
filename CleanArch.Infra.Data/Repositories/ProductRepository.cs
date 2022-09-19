using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _productRepository;

        public ProductRepository(ApplicationDbContext productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productRepository.Products.ToListAsync();
        }

        public async Task<Product> GetProductsCategoryAsync(int? id)
        {
            return await _productRepository.Products.Include(c => c.Categoy).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> GetAsync(int? id)
        {
            return await _productRepository.Products.FindAsync(id);
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _productRepository.Add(product);
            await _productRepository.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _productRepository.Update(product);
            await _productRepository.SaveChangesAsync();
            return product;
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _productRepository.Remove(product);
            await _productRepository.SaveChangesAsync();
            return product;
        }
    }
}
