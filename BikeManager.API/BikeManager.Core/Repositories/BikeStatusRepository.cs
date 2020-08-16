using System.Threading.Tasks;
using BikeManager.Core.Models;
using BikeManager.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BikeManager.Core.Repositories
{
    public class BikeStatusRepository: BaseRepository<BikeStatus>, IBikeStatusRepository
    {
        private BikeManagerDbContext _context;
        public BikeStatusRepository(BikeManagerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<long> FindIdByStatusName(string statusName)
        {
            var status = await _context.BikeStatuses
                .FirstOrDefaultAsync(x => x.StatusName == statusName);

            return status.StatusId;
        }
    }
}