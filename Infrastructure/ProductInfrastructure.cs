﻿using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ProductInfrastructure : IProductInfrastructure
    {
        private readonly AppDbContext _context;

        public ProductInfrastructure(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null) return false;
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<bool> UpdatedProduct(int id, Product product)
        {
            var productFound = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (productFound == null) return false;

            productFound.Name = product.Name;
            productFound.Description = product.Description;
            productFound.ImgUrl = product.ImgUrl;
            productFound.Price = product.Price;
            _context.Products.Update(productFound);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
