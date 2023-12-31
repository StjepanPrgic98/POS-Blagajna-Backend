using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS_Blagajna_Backend.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string UnitOfMeasure { get; set; }
        public float Price { get; set; }
        public int StorageQuantity { get; set; }
    }
}