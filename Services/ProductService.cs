using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS_Blagajna_Backend.DTOs.ProductDTOs;
using POS_Blagajna_Backend.Entities;
using POS_Blagajna_Backend.Interfaces.RepositoryInterfaces;
using POS_Blagajna_Backend.Interfaces.ServiceInterfaces;

namespace POS_Blagajna_Backend.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;     
        }

        public async Task<bool> CreateProduct(ProductDTO productDTO)
        {
            Product newProduct = new Product
            {
                Name = productDTO.Name,
                UnitOfMeasure = productDTO.UnitOfMeasure,
                Price = productDTO.Price,
                StorageQuantity = productDTO.StorageQuantity
            };

            return await _productRepository.CreateProduct(newProduct);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            Product productToDelete = await _productRepository.GetProductById(id);
            return await _productRepository.DeleteProduct(productToDelete);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }

        public async Task<bool> UpdateProduct(ProductDTO productDTO)
        {
            Product productToUpdate = await _productRepository.GetProductById(productDTO.Id);

            productToUpdate.Name = productDTO.Name;
            productToUpdate.UnitOfMeasure = productDTO.UnitOfMeasure;
            productToUpdate.Price = productDTO.Price;
            productToUpdate.StorageQuantity = productDTO.StorageQuantity;

            return await _productRepository.UpdateProduct(productToUpdate);
        }
    }
}