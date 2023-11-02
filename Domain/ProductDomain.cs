using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ProductDomain : IProductDomain
    {
        private readonly IProductInfrastructure _infrastructure;

        public ProductDomain(IProductInfrastructure infrastructure)
        {
            _infrastructure = infrastructure;
        }
        public async Task<bool> CreateProduct(Product product)
        {
            return await _infrastructure.CreateProduct(product);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _infrastructure.DeleteProduct(id);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _infrastructure.GetAllProducts();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _infrastructure.GetProductById(id);
        }

        public async Task<bool> UpdateProduct(int id, Product product)
        {
           return await _infrastructure.UpdatedProduct(id, product);
        }
    }
}
