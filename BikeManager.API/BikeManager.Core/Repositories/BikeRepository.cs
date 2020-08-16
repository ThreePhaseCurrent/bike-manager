using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeManager.Core.Models;
using BikeManager.Core.Repositories.Interfaces;

namespace BikeManager.Core.Repositories
{
    public class BikeRepository: BaseRepository<Bike>, IBikeRepository
    {
        private BikeManagerDbContext _context;
        public IQueryable<Bike> Bikes => _context.Bikes;
        
        public BikeRepository(BikeManagerDbContext context) : base(context)
        {
            _context = context;
        }
    }
}