using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_2.Models
{
    public class Report
    {
        public int id { get; set; }
        public double totalMonetaryDonationsReceived { get; set; }
        public int totalNumberOfGoodsReceived { get; set; }


        public Report() { 
        }
    }

}
