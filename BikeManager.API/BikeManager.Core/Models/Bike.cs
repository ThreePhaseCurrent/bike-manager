using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BikeManager.Core.Models
{
    public class Bike
    {
        public long BikeId { get; set; }
        public string BikeName { get; set; }
        public long CategoryId { get; set; }
        public long StatusId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        
        [JsonIgnore]
        [ForeignKey("CategoryId")]
        public virtual BikeCategory Category { get; set; }
        [JsonIgnore]
        [ForeignKey("StatusId")]
        public virtual BikeStatus Status { get; set; }
    }
}