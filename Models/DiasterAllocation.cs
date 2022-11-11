using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_2.Models
{
    public class DiasterAllocation
    {
        public int Id { get; set; }
        public string disasterType { get; set; }
        public DateTime dateAlloted { get; set; }
        public double amountAllotted { get; set; }

        public DiasterAllocation() { 
        
        
        
        }

    }
}
