using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_2.Models
{
    public class DisasterType
    {

        public int Id { get; set; }
        public string disasterType { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public string aidRequired { get; set; }

        public DisasterType() { 
        
        }
    }
}
