using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS_Blagajna_Backend.Entities;

namespace POS_Blagajna_Backend.Interfaces.RepositoryInterfaces
{
    public interface IReceiptRepository
    {
        Task<IEnumerable<Receipt>> GetAllReceipts();
        Task<bool> CreateReceipt(Receipt receipt);
        Task<bool> UpdateReceipt(Receipt receipt);
        Task<bool> DeleteReceipt(Receipt receipt);

        Task<Receipt> GetReceiptById(int id);
        Task<int> GetLatestReceiptNumber();
    }
}