using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync(CancellationToken cancellationToken = default);
        Task<Product> GetProductByIdAsync(int productId, CancellationToken cancellationToken = default);
        Task<int> CreateProductAsync(Product product, CancellationToken cancellationToken = default);
    }
}
