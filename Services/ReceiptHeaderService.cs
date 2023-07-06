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
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository _receiptRepository;
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        public ReceiptService(IReceiptRepository receiptRepository, IMapper mapper, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _receiptRepository = receiptRepository;        
        }

        public async Task<bool> CreateReceipt(ReceiptDTO receiptDTO)
        {
            
            Receipt newReceipt = new Receipt();

            _mapper.Map(receiptDTO, newReceipt);

            if(receiptDTO.CustomerName != null)
            {
                Customer customer = await _customerRepository.GetCustomerByName(receiptDTO.CustomerName);
                newReceipt.Customer = customer;
            }
            else
            {
                Customer customer = new Customer();
                newReceipt.Customer = customer;
            }

            return await _receiptRepository.CreateReceipt(newReceipt);         
        }

        public async Task<bool> DeleteReceipt(int id)
        {
            Receipt receiptToDelete = await _receiptRepository.GetReceiptById(id);
            return await _receiptRepository.DeleteReceipt(receiptToDelete);
        }

        public async Task<IEnumerable<Receipt>> GetAllReceipts()
        {
            return await _receiptRepository.GetAllReceipts();
        }

        public async Task<bool> UpdateReceipt(ReceiptDTO receiptDTO)
        {
            Receipt receiptToUpdate = await _receiptRepository.GetReceiptById(receiptDTO.Id);

            _mapper.Map(receiptDTO, receiptToUpdate);

            if(receiptDTO.CustomerName != null)
            {
                Customer customer = await _customerRepository.GetCustomerByName(receiptDTO.CustomerName);
                receiptToUpdate.Customer = customer;
            }
            else
            {
                Customer customer = new Customer();
                receiptToUpdate.Customer = customer;
            }

            return await _receiptRepository.UpdateReceipt(receiptToUpdate);       
        }
    }
}