using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POS_Blagajna_Backend.Entities;
using POS_Blagajna_Backend.Interfaces.RepositoryInterfaces;

namespace POS_Blagajna_Backend.Data.Repositories
{
    public class ReceiptHeaderRepository : BaseRepository, IReceiptHeaderRepository
    {
        public ReceiptHeaderRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> CreateReceiptHeader(ReceiptHeader receiptHeader)
        {
            _context.ReceiptHeaders.Add(receiptHeader);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteReceiptHeader(ReceiptHeader receiptHeader)
        {
            _context.ReceiptHeaders.Remove(receiptHeader);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<ReceiptHeader>> GetAllReceiptHeaders()
        {
            return await _context.ReceiptHeaders
            .Include(x => x.Customer)
            .ToListAsync();
        }


        public async Task<bool> UpdateReceiptHeader(ReceiptHeader receiptHeader)
        {
            _context.ReceiptHeaders.Update(receiptHeader);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<ReceiptHeader> GetReceiptHeaderById(int id)
        {
            return await _context.ReceiptHeaders.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}