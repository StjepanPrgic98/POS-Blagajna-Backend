using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS_Blagajna_Backend.DTOs.ProductDTOs;
using POS_Blagajna_Backend.Entities;

namespace POS_Blagajna_Backend.Interfaces.ServiceInterfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<bool> CreateProduct(ProductDTO productDTO);
        Task<bool> UpdateProduct(ProductDTO productDTO);
        Task<bool> DeleteProduct(int id);
        
        Task<Product> GetProductByName(string name);
        Task<IEnumerable<Product>> GetProductsThatContainCode(int code);
        Task<IEnumerable<Product>> GetProductsThatContainName(string name);
        Task<bool> IncreaseProductQuantity(int id, int quantity);
    }
}