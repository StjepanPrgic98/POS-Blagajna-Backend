using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using POS_Blagajna_Backend.DTOs.CustomerDTOs;
using POS_Blagajna_Backend.Entities;
using POS_Blagajna_Backend.Interfaces.RepositoryInterfaces;
using POS_Blagajna_Backend.Interfaces.ServiceInterfaces;

namespace POS_Blagajna_Backend.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public async Task<bool> CreateCustomer(CustomerDTO customerDTO)
        {
            Customer newCustomer = new Customer();

            _mapper.Map(customerDTO, newCustomer);

            return await _customerRepository.CreateCustomer(newCustomer);
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            Customer customerToDelete = await _customerRepository.GetCustomerById(id);
            return await _customerRepository.DeleteCustomer(customerToDelete);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _customerRepository.GetAllCustomers();
        }

        public async Task<bool> UpdateCustomer(CustomerDTO customerDTO)
        {
            Customer customerToUpdate = await _customerRepository.GetCustomerById(customerDTO.Id);

            _mapper.Map(customerDTO, customerToUpdate);

            return await _customerRepository.UpdateCustomer(customerToUpdate);
        }

        public async Task<Customer> GetCustomerByName(string name)
        {
            return await _customerRepository.GetCustomerByName(name);
        }

        public async Task<IEnumerable<Customer>> GetCustomersThatContainsName(string name)
        {
            return await _customerRepository.GetCustomersThatContainsName(name);
        }
    }
}