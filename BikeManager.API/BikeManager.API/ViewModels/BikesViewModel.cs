using System.Collections.Generic;
using BikeManager.Core.Models;

namespace BikeManager.API.ViewModels
{
    public class BikesViewModel
    {
        public IEnumerable<Bike> Bikes { get; set; }
    }
}