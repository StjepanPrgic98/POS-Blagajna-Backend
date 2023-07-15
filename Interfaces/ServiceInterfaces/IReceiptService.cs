using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS_Blagajna_Backend.DTOs.DateTimeDTOs;
using POS_Blagajna_Backend.DTOs.ReceiptDTOs;
using POS_Blagajna_Backend.DTOs.ReceiptHeaderDTOs;
using POS_Blagajna_Backend.Entities;

namespace POS_Blagajna_Backend.Interfaces.ServiceInterfaces
{
    public interface IReceiptService
    {
        Task<IEnumerable<Receipt>> GetAllReceipts();
        Task<bool> CreateReceipt(ReceiptDTO receiptDTO);
        Task<bool> UpdateReceipt(ReceiptDTO receiptDTO);
        Task<bool> DeleteReceipt(int id);
        
        Task<int> GetNewReceiptNumber();
        Task<ReceiptHistoryDTO> GetReceiptsForChosenDate(PurchaseHistoryFiltersDTO purchaseHistoryFiltersDTO, string filterOptions);
    }
}