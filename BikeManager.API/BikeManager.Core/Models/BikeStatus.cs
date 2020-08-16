using System.Collections.Generic;

namespace BikeManager.Core.Models
{
    public class BikeStatus
    {
        public long StatusId { get; set; }
        public string StatusName { get; set; }
        
        public ICollection<Bike> Bikes { get; set; }
    }
}