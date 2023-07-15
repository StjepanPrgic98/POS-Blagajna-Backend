using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS_Blagajna_Backend.DTOs.DateTimeDTOs
{
    public class PurchaseHistoryFiltersDTO
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}