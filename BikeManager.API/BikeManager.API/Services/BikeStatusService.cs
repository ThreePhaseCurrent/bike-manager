using BikeManager.API.Services.Interfaces;
using BikeManager.Core.Models;
using BikeManager.Core.Repositories;

namespace BikeManager.API.Services
{
    public class BikeStatusService: BikeStatusRepository, IBikeStatusService
    {
        public BikeStatusService(BikeManagerDbContext context) : base(context)
        {
        }
    }
}