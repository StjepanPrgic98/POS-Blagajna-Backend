using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using POS_Blagajna_Backend.DTOs.ReceiptItemDTOs;
using POS_Blagajna_Backend.Entities;
using POS_Blagajna_Backend.Interfaces.RepositoryInterfaces;
using POS_Blagajna_Backend.Interfaces.ServiceInterfaces;

namespace POS_Blagajna_Backend.Services
{
    public class ReceiptItemService : IReceiptItemService
    {
        private readonly IReceiptItemRepository _receiptItemsRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ReceiptItemService(IReceiptItemRepository receiptItemsRepository, IProductRepository productRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _receiptItemsRepository = receiptItemsRepository;       
        }


        public async Task<bool> CreateReceiptItem(ReceiptItemDTO receiptItemDTO)
        {

            Product product = await _productRepository.GetProductByName(receiptItemDTO.ProductName);

            ReceiptItem newReceiptItem = new ReceiptItem();
            _mapper.Map(receiptItemDTO, newReceiptItem);
             
            newReceiptItem.Product = product;
            newReceiptItem.Price = newReceiptItem.Product.Price * newReceiptItem.Quantity;

            if(newReceiptItem.DiscountPercentage == 0)
            {
                newReceiptItem.DiscountAmmount = 0;
                newReceiptItem.TotalPrice = newReceiptItem.Price;
            }
            else
            {
                newReceiptItem.DiscountAmmount = (newReceiptItem.Price * newReceiptItem.DiscountPercentage) / 100;
                newReceiptItem.TotalPrice = newReceiptItem.Price - newReceiptItem.DiscountAmmount;
            }

            return await _receiptItemsRepository.CreateReceiptItem(newReceiptItem);
        }

        public async Task<List<ReceiptItem>> CreateMultipleReceiptItems(List<ReceiptItemDTO> receiptItemDTOs)
        {
            List<ReceiptItem> newReceiptItems = new List<ReceiptItem>();

            foreach (var receiptItemDTO in receiptItemDTOs)
            {
                Product product = await _productRepository.GetProductByName(receiptItemDTO.ProductName);

                ReceiptItem newReceiptItem = new ReceiptItem();
                _mapper.Map(receiptItemDTO, newReceiptItem);
                
                newReceiptItem.Product = product;
                newReceiptItem.Price = newReceiptItem.Product.Price * newReceiptItem.Quantity;

                if(newReceiptItem.DiscountPercentage == 0)
                {
                    newReceiptItem.DiscountAmmount = 0;
                    newReceiptItem.TotalPrice = newReceiptItem.Price;
                }
                else
                {
                    newReceiptItem.DiscountAmmount = (newReceiptItem.Price * newReceiptItem.DiscountPercentage) / 100;
                    newReceiptItem.TotalPrice = newReceiptItem.Price - newReceiptItem.DiscountAmmount;
                }
                
                newReceiptItems.Add(newReceiptItem);
            }

            return await _receiptItemsRepository.CreateMultipleReceiptItems(newReceiptItems);
        }

        public async Task<bool> DeleteReceiptItem(int id)
        {
            ReceiptItem receiptItemToDelete = await _receiptItemsRepository.GetReceiptItemById(id);
            return await _receiptItemsRepository.DeleteReceiptItem(receiptItemToDelete);
        }

        public async Task<IEnumerable<ReceiptItem>> GetAllReceiptItems()
        {
            return await _receiptItemsRepository.GetAllReceiptItems();
        }

        public async Task<bool> UpdateReceiptItem(ReceiptItemDTO receiptItemDTO)
        {
            ReceiptItem receiptItemToUpdate = await _receiptItemsRepository.GetReceiptItemById(receiptItemDTO.Id);

            Product product = await _productRepository.GetProductByName(receiptItemDTO.ProductName);

            _mapper.Map(receiptItemDTO, receiptItemToUpdate);
             
            receiptItemToUpdate.Product = product;
            receiptItemToUpdate.Price = receiptItemToUpdate.Product.Price * receiptItemToUpdate.Quantity;

            if(receiptItemToUpdate.DiscountPercentage == 0)
            {
                receiptItemToUpdate.DiscountAmmount = 0;
                receiptItemToUpdate.TotalPrice = receiptItemToUpdate.Price;
            }
            else
            {
                receiptItemToUpdate.DiscountAmmount = (receiptItemToUpdate.Price * receiptItemToUpdate.DiscountPercentage) / 100;
                receiptItemToUpdate.TotalPrice = receiptItemToUpdate.Price - receiptItemToUpdate.DiscountAmmount;
            }

            return await _receiptItemsRepository.UpdateReceiptItem(receiptItemToUpdate);
        }
    }
}