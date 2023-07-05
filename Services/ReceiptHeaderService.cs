using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using POS_Blagajna_Backend.DTOs.ReceiptHeaderDTOs;
using POS_Blagajna_Backend.Entities;
using POS_Blagajna_Backend.Interfaces.RepositoryInterfaces;
using POS_Blagajna_Backend.Interfaces.ServiceInterfaces;

namespace POS_Blagajna_Backend.Services
{
    public class ReceiptHeaderService : IReceiptHeaderService
    {
        private readonly IReceiptHeaderRepository _receiptHeaderRepository;
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        public ReceiptHeaderService(IReceiptHeaderRepository receiptHeaderRepository, IMapper mapper, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _receiptHeaderRepository = receiptHeaderRepository;        
        }

        public async Task<bool> CreateReceiptHeader(ReceiptHeaderDTO receiptHeaderDTO)
        {
            
            ReceiptHeader newReceiptHeader = new ReceiptHeader();

            _mapper.Map(receiptHeaderDTO, newReceiptHeader);

            if(receiptHeaderDTO.CustomerName != null)
            {
                Customer customer = await _customerRepository.GetCustomerByName(receiptHeaderDTO.CustomerName);
                newReceiptHeader.Customer = customer;
            }
            else
            {
                Customer customer = new Customer();
                newReceiptHeader.Customer = customer;
            }

            return await _receiptHeaderRepository.CreateReceiptHeader(newReceiptHeader);         
        }

        public async Task<bool> DeleteReceiptHeader(int id)
        {
            ReceiptHeader receiptHeaderToDelete = await _receiptHeaderRepository.GetReceiptHeaderById(id);
            return await _receiptHeaderRepository.DeleteReceiptHeader(receiptHeaderToDelete);
        }

        public async Task<IEnumerable<ReceiptHeader>> GetAllReceiptHeaders()
        {
            return await _receiptHeaderRepository.GetAllReceiptHeaders();
        }

        public async Task<bool> UpdateReceiptHeader(ReceiptHeaderDTO receiptHeaderDTO)
        {
            ReceiptHeader receiptHeaderToUpdate = await _receiptHeaderRepository.GetReceiptHeaderById(receiptHeaderDTO.Id);

            _mapper.Map(receiptHeaderDTO, receiptHeaderToUpdate);

            if(receiptHeaderDTO.CustomerName != null)
            {
                Customer customer = await _customerRepository.GetCustomerByName(receiptHeaderDTO.CustomerName);
                receiptHeaderToUpdate.Customer = customer;
            }
            else
            {
                Customer customer = new Customer();
                receiptHeaderToUpdate.Customer = customer;
            }

            return await _receiptHeaderRepository.UpdateReceiptHeader(receiptHeaderToUpdate);       
        }
    }
}