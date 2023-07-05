using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS_Blagajna_Backend.Entities;

namespace POS_Blagajna_Backend.Interfaces.RepositoryInterfaces
{
    public interface IReceiptHeaderRepository
    {
        Task<IEnumerable<ReceiptHeader>> GetAllReceiptHeaders();
        Task<bool> CreateReceiptHeader(ReceiptHeader receiptHeader);
        Task<bool> UpdateReceiptHeader(ReceiptHeader receiptHeader);
        Task<bool> DeleteReceiptHeader(ReceiptHeader receiptHeader);

        Task<ReceiptHeader> GetReceiptHeaderById(int id);
    }
}