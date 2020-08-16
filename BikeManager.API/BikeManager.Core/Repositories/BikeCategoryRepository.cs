using System.Threading.Tasks;
using BikeManager.Core.Models;
using BikeManager.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BikeManager.Core.Repositories
{
    public class BikeCategoryRepository: BaseRepository<BikeCategory>, IBikeCategoryRepository
    {
        private BikeManagerDbContext _context;
        
        public BikeCategoryRepository(BikeManagerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<long> FindIdByCategoryName(string categoryName)
        {
            var category = await _context.BikeCategories
                .FirstOrDefaultAsync(x => x.CategoryName == categoryName);

            return category.CategoryId;
        }
    }
}