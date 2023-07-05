using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using POS_Blagajna_Backend.DTOs.ProductDTOs;
using POS_Blagajna_Backend.Entities;
using POS_Blagajna_Backend.Interfaces.RepositoryInterfaces;
using POS_Blagajna_Backend.Interfaces.ServiceInterfaces;

namespace POS_Blagajna_Backend.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;     
        }

        public async Task<bool> CreateProduct(ProductDTO productDTO)
        {
            Product newProduct = new Product();

            _mapper.Map(productDTO, newProduct);
            
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

            _mapper.Map(productDTO, productToUpdate);

            return await _productRepository.UpdateProduct(productToUpdate);
        }
    }
}