using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS_Blagajna_Backend.DTOs.ReceiptItemDTOs;
using POS_Blagajna_Backend.Entities;

namespace POS_Blagajna_Backend.Interfaces.ServiceInterfaces
{
    public interface IReceiptItemService
    {
        Task<IEnumerable<ReceiptItem>> GetAllReceiptItems();
        Task<bool> CreateReceiptItem(ReceiptItemDTO receiptItemDTO);
        Task<List<ReceiptItem>> CreateMultipleReceiptItems(List<ReceiptItemDTO> receiptItemDTOs);
        Task<bool> UpdateReceiptItem(ReceiptItemDTO receiptItemDTO);
        Task<bool> DeleteReceiptItem(int id);
    }
}