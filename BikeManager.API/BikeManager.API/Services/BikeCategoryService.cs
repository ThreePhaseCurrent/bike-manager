using BikeManager.API.Services.Interfaces;
using BikeManager.Core.Models;
using BikeManager.Core.Repositories;

namespace BikeManager.API.Services
{
    public class BikeCategoryService: BikeCategoryRepository, IBikeCategoryService
    {
        public BikeCategoryService(BikeManagerDbContext context) : base(context)
        {
        }
    }
}