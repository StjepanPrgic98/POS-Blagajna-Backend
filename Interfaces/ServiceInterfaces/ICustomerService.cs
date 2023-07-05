using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS_Blagajna_Backend.DTOs.CustomerDTOs;
using POS_Blagajna_Backend.Entities;

namespace POS_Blagajna_Backend.Interfaces.ServiceInterfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<bool> CreateCustomer(CustomerDTO customerDTO);
        Task<bool> UpdateCustomer(CustomerDTO customerDTO);
        Task<bool> DeleteCustomer(int id);
    }
}