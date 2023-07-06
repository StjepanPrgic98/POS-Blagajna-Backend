using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS_Blagajna_Backend.DTOs.ReceiptItemDTOs
{
    public class ReceiptItemDTO
    {
         public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public float DiscountPercentage { get; set; }
    }
}