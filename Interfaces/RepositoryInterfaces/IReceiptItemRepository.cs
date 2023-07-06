using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS_Blagajna_Backend.DTOs.ReceiptItemDTOs;
using POS_Blagajna_Backend.Entities;

namespace POS_Blagajna_Backend.Interfaces.RepositoryInterfaces
{
    public interface IReceiptItemRepository
    {
        Task<IEnumerable<ReceiptItem>> GetAllReceiptItems();
        Task<bool> CreateReceiptItem(ReceiptItem receiptItem);
        Task<List<ReceiptItem>> CreateMultipleReceiptItems(List<ReceiptItem> receiptItems);
        Task<bool> UpdateReceiptItem(ReceiptItem receiptItem);
        Task<bool> DeleteReceiptItem(ReceiptItem receiptItem);

        Task<ReceiptItem> GetReceiptItemById(int id);
    }
}