using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_2.Models
{
    public class GoodsAllocation
    {
        public int Id { get; set; }
        public string goodType { get; set; }
        public DateTime dateAllocated { get; set; }
        public int quantity { get; set; }
        public double pricePerItem { get; set; }

        public string disasterType { get; set; }
        public GoodsAllocation() { 
        
        }

    }
}
