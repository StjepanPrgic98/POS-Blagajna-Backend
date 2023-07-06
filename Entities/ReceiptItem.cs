using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS_Blagajna_Backend.Entities
{
    public class ReceiptItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float DiscountPercentage { get; set; } = 0;
        public float DiscountAmmount { get; set; }
        public float TotalPrice { get; set; }

    }
}