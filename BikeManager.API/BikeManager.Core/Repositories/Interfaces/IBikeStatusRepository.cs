using System.Threading.Tasks;
using BikeManager.Core.Models;

namespace BikeManager.Core.Repositories.Interfaces
{
    public interface IBikeStatusRepository: IBaseRepository<BikeStatus>
    {
        Task<long> FindIdByStatusName(string statusName);
    }
}