using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}