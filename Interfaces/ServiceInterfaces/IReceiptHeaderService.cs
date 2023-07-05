using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS_Blagajna_Backend.DTOs.ReceiptHeaderDTOs;
using POS_Blagajna_Backend.Entities;

namespace POS_Blagajna_Backend.Interfaces.ServiceInterfaces
{
    public interface IReceiptHeaderService
    {
        Task<IEnumerable<ReceiptHeader>> GetAllReceiptHeaders();
        Task<bool> CreateReceiptHeader(ReceiptHeaderDTO receiptHeaderDTO);
        Task<bool> UpdateReceiptHeader(ReceiptHeaderDTO receiptHeaderDTO);
        Task<bool> DeleteReceiptHeader(int id);
    }
}