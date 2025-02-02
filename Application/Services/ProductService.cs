using Application.Interfaces;
using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateProductAsync(Product product, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return product.ProductId;
        }

        public async Task<List<Product>> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }

        public async Task<Product> GetProductByIdAsync(int productId, CancellationToken cancellationToken)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.ProductId.Equals(productId), cancellationToken);
        }
    }
}
