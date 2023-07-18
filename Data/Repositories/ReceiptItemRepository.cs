using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POS_Blagajna_Backend.Entities;
using POS_Blagajna_Backend.Interfaces.RepositoryInterfaces;

namespace POS_Blagajna_Backend.Data.Repositories
{
    public class ReceiptItemRepository : BaseRepository, IReceiptItemRepository
    {

        public ReceiptItemRepository(DataContext context, IdentityDataContext identityContext) : base(context, identityContext)
        {
        }

        public async Task<bool> CreateReceiptItem(ReceiptItem receiptItem)
        {
            _context.ReceiptItems.Add(receiptItem);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<ReceiptItem>> CreateMultipleReceiptItems(List<ReceiptItem> receiptItems)
        {
            _context.ReceiptItems.AddRange(receiptItems);
            await _context.SaveChangesAsync();

            return receiptItems;
        }

        public async Task<bool> DeleteReceiptItem(ReceiptItem receiptItem)
        {
            _context.ReceiptItems.Remove(receiptItem);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<ReceiptItem>> GetAllReceiptItems()
        {
            return await _context.ReceiptItems
            .Include(x => x.Product)
            .ToListAsync();
        }


        public async Task<bool> UpdateReceiptItem(ReceiptItem receiptItem)
        {
            _context.ReceiptItems.Update(receiptItem);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReceiptItem> GetReceiptItemById(int id)
        {
            return await _context.ReceiptItems.FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}