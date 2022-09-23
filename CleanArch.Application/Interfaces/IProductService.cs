using CleanArch.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();

        Task<ProductDTO> GetAsync(int? id);
        Task CreateAsync(ProductDTO product);
        Task UpdateAsync(ProductDTO product);
        Task RemoveAsync(int? id);
    }
}
