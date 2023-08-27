using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POS_Blagajna_Backend.DTOs.DateTimeDTOs;
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
            _context.Receipts.Add(receipt);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteReceipt(Receipt receipt)
        {
            _context.ReceiptItems.RemoveRange(receipt.ReceiptItems);
            _context.Receipts.Remove(receipt);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Receipt>> GetAllReceipts()
        {
            return await _context.Receipts
            .Include(x => x.Customer)
            .Include(x => x.ReceiptItems).ThenInclude(x => x.Product)
            .ToListAsync();
        }


        public async Task<bool> UpdateReceipt(Receipt receipt)
        {
            _context.Receipts.Update(receipt);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<Receipt> GetReceiptById(int id)
        {
            return await _context.Receipts
            .Include(x => x.ReceiptItems)
            .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> GetLatestReceiptNumber()
        {
            return await _context.Receipts.MaxAsync(x => x.Number);
        }

        public async Task<List<Receipt>> GetReceiptsForChosenDate(PurchaseHistoryFiltersDTO purchaseHistoryFiltersDTO, string filterOptions)
        {
            if(filterOptions == "day")
            {
                return await _context.Receipts
                    .Include(x => x.Customer)
                    .Include(x => x.ReceiptItems).ThenInclude(x => x.Product)
                    .Include(x => x.Employee)
                    .Where(x =>
                        x.Date.Day == purchaseHistoryFiltersDTO.Day
                    && x.Date.Month == purchaseHistoryFiltersDTO.Month
                    && x.Date.Year == purchaseHistoryFiltersDTO.Year
                    )
                    .ToListAsync();
            }
            else if(filterOptions == "month")
            {
                return await _context.Receipts
                    .Include(x => x.Customer)
                    .Include(x => x.ReceiptItems).ThenInclude(x => x.Product)
                    .Include(x => x.Employee)
                    .Where(x =>      
                    x.Date.Month == purchaseHistoryFiltersDTO.Month
                    && x.Date.Year == purchaseHistoryFiltersDTO.Year
                    )
                    .ToListAsync();
            }
            else
            {
                return await _context.Receipts
                    .Include(x => x.Customer)
                    .Include(x => x.ReceiptItems).ThenInclude(x => x.Product)
                    .Include(x => x.Employee)
                    .Where(x => x.Date.Year == purchaseHistoryFiltersDTO.Year
                    )
                    .ToListAsync();
            }
            
        }
    }
}