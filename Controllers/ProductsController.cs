using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POS_Blagajna_Backend.DTOs.ProductDTOs;
using POS_Blagajna_Backend.Entities;
using POS_Blagajna_Backend.Interfaces.RepositoryInterfaces;
using POS_Blagajna_Backend.Interfaces.ServiceInterfaces;

namespace POS_Blagajna_Backend.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            try
            {
                return Ok(await _productService.GetAllProducts());
            }
            catch(Exception ex)
            {
                return BadRequest($"Could not get products! \n {ex}");
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<bool>> CreateProduct(ProductDTO productDTO)
        {
            try
            {
                return await _productService.CreateProduct(productDTO);
            }
            catch(Exception ex)
            {
                return BadRequest($"Could not create product! \n {ex}");
            }
        } 

        [HttpPut("update")]
        public async Task<ActionResult<bool>> UpdateProduct(ProductDTO productDTO)
        {
            try
            {
                return await _productService.UpdateProduct(productDTO);
            }
            catch(Exception ex)
            {
                return BadRequest($"Could not update product! \n {ex}");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> DeleteProduct(int id)
        {
            try
            {
                return await _productService.DeleteProduct(id);
            }
            catch(Exception ex)
            {
                return BadRequest($"Could not delete product! \n {ex}");
            }
        }

        [HttpGet("code/{code}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsThatContainCode(int code)
        {
            try
            {
                return Ok(await _productService.GetProductsThatContainCode(code));
            }
            catch(Exception ex)
            {
                return BadRequest($"Could not get products that contain code! \n {ex}");
            }
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsThatContainName(string name)
        {
            try
            {
                return Ok(await _productService.GetProductsThatContainName(name));
            }
            catch(Exception ex)
            {
                return BadRequest($"Could not get product that contain name! \n {ex}");
            }
        }
    }
}