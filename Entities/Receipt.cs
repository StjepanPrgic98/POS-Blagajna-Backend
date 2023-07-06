using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS_Blagajna_Backend.Entities
{
    public class Receipt
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Note { get; set; }
        public Customer Customer { get; set; }
        public ICollection<ReceiptItem> ReceiptItems { get; set; }
    }
}