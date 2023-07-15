using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS_Blagajna_Backend.DTOs.ReceiptHeaderDTOs;
using POS_Blagajna_Backend.Entities;

namespace POS_Blagajna_Backend.DTOs.ReceiptDTOs
{
    public class ReceiptHistoryDTO
    {
        public List<Receipt> Receipts { get; set; }
        public int TotalTransactions { get; set; }
        public float TotalNetSales { get; set; }
        public float TotalDiscounts { get; set; }
        public float TotalSales { get; set; }
        public float CashSales { get; set; }
        public float CardSales { get; set; }
    }
}