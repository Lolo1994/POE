using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_2.Models
{
    public class MoneyDonations
    {
        public int Id { get; set; }
        public double donationAmount { get; set; }
        public DateTime dateReceived { get; set; }
        public string donorName { get; set; }
        public bool isAnonymous { get; set; }
        public string disasteType { get; set; }

        public MoneyDonations() { 
        
        }
    }
}
