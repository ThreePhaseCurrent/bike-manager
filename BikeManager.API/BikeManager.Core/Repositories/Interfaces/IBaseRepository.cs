using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeManager.Core.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> GetAll();
        Task<List<T>> GetAllAsync();
        Task Add(T entity);
        Task AddRange(IList<T> entityRange);
        Task Update(T entity);
        Task UpdateRange(IList<T> entityRange);
        Task Remove(T entity);
        Task RemoveRange(IList<T> entityRange);
    }
}