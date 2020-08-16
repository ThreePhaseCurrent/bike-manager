using System.Linq;
using BikeManager.Core.Models;

namespace BikeManager.Core.Repositories.Interfaces
{
    public interface IBikeRepository: IBaseRepository<Bike>
    {
        public IQueryable<Bike> Bikes { get; }
    }
}