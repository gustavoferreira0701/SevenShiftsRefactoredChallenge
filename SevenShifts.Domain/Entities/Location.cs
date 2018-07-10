using System;
using System.Collections.Generic;
using System.Text;

namespace SevenShifts.Domain.Entities
{
    public class Location
    {   
        public long Id { get; set; }
        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public DateTime Created { get; set; }

        public LabourSettings LabourSettings { get; set; }
        
        public double Lat { get; set; }
        
        public double Lng { get; set; }
        
        public DateTime Modified { get; set; }
        
        public string State { get; set; }
        
        public string Timezone { get; set; }
    }
}
