using System.Threading.Tasks;
using BikeManager.Core.Models;

namespace BikeManager.Core.Repositories.Interfaces
{
    public interface IBikeCategoryRepository: IBaseRepository<BikeCategory>
    {
        Task<long> FindIdByCategoryName(string categoryName);
    }
}