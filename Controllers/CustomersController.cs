using Microsoft.AspNetCore.Mvc;
using POS_Blagajna_Backend.DTOs.CustomerDTOs;
using POS_Blagajna_Backend.Entities;
using POS_Blagajna_Backend.Interfaces.ServiceInterfaces;

namespace POS_Blagajna_Backend.Controllers
{
    public class CustomersController : BaseApiController
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;       
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            try
            {
                return Ok(await _customerService.GetAllCustomers());
            }
            catch(Exception ex)
            {
                return BadRequest($"Could not get customers! \n {ex}");
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<bool>> CreateCustomer(CustomerDTO customerDTO) 
        {
            try
            {
                return await _customerService.CreateCustomer(customerDTO);
            }
            catch(Exception ex)
            {
                return BadRequest($"Could not create customer! \n {ex}");
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<bool>> UpdateCustomer(CustomerDTO customerDTO)
        {
            try
            {
                return await _customerService.UpdateCustomer(customerDTO);
            }
            catch(Exception ex)
            {
                return BadRequest($"Could not update customer! \n {ex}");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> DeleteCustomer(int id)
        {
            try
            {
                return await _customerService.DeleteCustomer(id);
            }
            catch(Exception ex)
            {
                return BadRequest($"Could not delete customer! \n {ex}");
            }
        }
    }
}