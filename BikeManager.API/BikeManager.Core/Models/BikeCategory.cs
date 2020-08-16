using System.Collections.Generic;

namespace BikeManager.Core.Models
{
    public class BikeCategory
    {
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        
        public ICollection<Bike> Bikes { get; set; }
    }
}