using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POS_Blagajna_Backend.DTOs.ProductDTOs;
using POS_Blagajna_Backend.Entities;
using POS_Blagajna_Backend.Interfaces.RepositoryInterfaces;

namespace POS_Blagajna_Backend.Data.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products
            .OrderBy(x => x.Code)
            .ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> GetProductByName(string name)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Product> GetProductByCode(int code)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task<IEnumerable<Product>> GetProductsThatContainCode(int code)
        {
            return await _context.Products.Where(x => x.Code.ToString().Contains(code.ToString())).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsThatContainName(string name)
        {
            return await _context.Products.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }
    }
}