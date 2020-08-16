namespace BikeManager.API.Models
{
    public class BikeDto
    {
        public long Id { get; set; }
        public string BikeName { get; set; }
        public string CategoryName { get; set; }
        public string StatusName { get; set; }
        public decimal Price { get; set; }
    }
}