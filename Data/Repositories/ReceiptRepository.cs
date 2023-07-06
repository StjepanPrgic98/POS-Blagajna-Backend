using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POS_Blagajna_Backend.Entities;
using POS_Blagajna_Backend.Interfaces.RepositoryInterfaces;

namespace POS_Blagajna_Backend.Data.Repositories
{
    public class ReceiptRepository : BaseRepository, IReceiptRepository
    {
        public ReceiptRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> CreateReceipt(Receipt receipt)
        {
            _context.ReceiptHeaders.Add(receipt);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteReceipt(Receipt receipt)
        {
            _context.ReceiptHeaders.Remove(receipt);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Receipt>> GetAllReceipts()
        {
            return await _context.ReceiptHeaders
            .Include(x => x.Customer)
            .ToListAsync();
        }


        public async Task<bool> UpdateReceipt(Receipt receipt)
        {
            _context.ReceiptHeaders.Update(receipt);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<Receipt> GetReceiptById(int id)
        {
            return await _context.ReceiptHeaders.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}