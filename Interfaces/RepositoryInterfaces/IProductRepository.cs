using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS_Blagajna_Backend.DTOs.ProductDTOs;
using POS_Blagajna_Backend.Entities;

namespace POS_Blagajna_Backend.Interfaces.RepositoryInterfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<bool> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(Product product);

        Task<Product> GetProductById(int id);
        Task<Product> GetProductByName(string name);
        Task<Product> GetProductByCode(int code);


        Task<IEnumerable<Product>> GetProductsThatContainCode(int code);
        Task<IEnumerable<Product>> GetProductsThatContainName(string name);
    }
}