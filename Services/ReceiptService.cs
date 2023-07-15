using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using POS_Blagajna_Backend.DTOs.DateTimeDTOs;
using POS_Blagajna_Backend.DTOs.ReceiptDTOs;
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
        private readonly IReceiptItemService _receiptItemService;
        public ReceiptService(IReceiptRepository receiptRepository, IMapper mapper, ICustomerRepository customerRepository, IReceiptItemService receiptItemService)
        {
            _receiptRepository = receiptRepository;
            _receiptItemService = receiptItemService;
            _customerRepository = customerRepository;
            _mapper = mapper;     
        }

        public async Task<bool> CreateReceipt(ReceiptDTO receiptDTO)
        {

            List<ReceiptItem> receiptItems = await _receiptItemService.CreateMultipleReceiptItems(receiptDTO.ReceiptItems);
            
            Receipt newReceipt = new Receipt();

            _mapper.Map(receiptDTO, newReceipt);

            Customer customer = await _customerRepository.GetCustomerByName(receiptDTO.CustomerName);
            newReceipt.Customer = customer;
            

            newReceipt.ReceiptItems = receiptItems;

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

        public async Task<int> GetNewReceiptNumber()
        {
            return await _receiptRepository.GetLatestReceiptNumber() + 1;
        }

        public async Task<ReceiptHistoryDTO> GetReceiptsForChosenDate(PurchaseHistoryFiltersDTO purchaseHistoryFiltersDTO, string filterOptions)
        {
            List<Receipt> filteredReceipts = await _receiptRepository.GetReceiptsForChosenDate(purchaseHistoryFiltersDTO, filterOptions);
            
            ReceiptHistoryDTO receiptHistoryDTO = new ReceiptHistoryDTO
            {
                Receipts = filteredReceipts,
                TotalTransactions = filteredReceipts.Count,
                TotalNetSales = MathF.Round(filteredReceipts.Sum(x => x.ReceiptItems.Sum(y => y.TotalPrice)) + filteredReceipts.Sum(x => x.ReceiptItems.Sum(y => y.DiscountAmmount))),
                TotalDiscounts = (float)Math.Round(filteredReceipts.Sum(x => x.ReceiptItems.Sum(y => y.DiscountAmmount)), 2),
                TotalSales = (float)Math.Round((filteredReceipts.Sum(x => x.ReceiptItems.Sum(y => y.TotalPrice))
                - filteredReceipts.Sum(x => x.ReceiptItems.Sum(y => y.DiscountAmmount))
                ), 2),

                CashSales = (float)Math.Round(filteredReceipts.Where(x => 
                x.Customer != null
                && x.Customer.Name != null 
                && x.Customer.Name == "-").Sum(z => z.ReceiptItems.Sum(y => y.TotalPrice)), 2),

                CardSales = (float)Math.Round(filteredReceipts.Where(x => 
                x.Customer != null
                && x.Customer.Name != null
                && x.Customer.Name != "-").Sum(z => z.ReceiptItems.Sum(y => y.TotalPrice)), 2)
            };

            return receiptHistoryDTO;
        }
    }
}