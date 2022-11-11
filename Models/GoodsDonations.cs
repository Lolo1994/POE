using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_2.Models
{
    public class GoodsDonations
    {
        public int Id { get; set; }
        public string itemName { get; set; }
        public DateTime dateReceived { get; set; }
        public int itemNumber { get; set; }
        public string itemType { get; set; }
        public bool isAnonymous { get; set; }
        public string disasteType { get; set; }

        public GoodsDonations() { 

        }

    }
}
