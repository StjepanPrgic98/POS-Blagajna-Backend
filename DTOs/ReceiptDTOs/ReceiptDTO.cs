using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS_Blagajna_Backend.DTOs.CustomerDTOs;
using POS_Blagajna_Backend.DTOs.ReceiptItemDTOs;

namespace POS_Blagajna_Backend.DTOs.ReceiptHeaderDTOs
{
    public class ReceiptDTO
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public string CustomerName { get; set; }
        public List<ReceiptItemDTO> ReceiptItems { get; set; }
    }
}