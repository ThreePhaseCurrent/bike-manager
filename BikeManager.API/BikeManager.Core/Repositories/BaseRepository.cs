using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeManager.Core.Models;
using BikeManager.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BikeManager.Core.Repositories
{
    public class BaseRepository<T>: IBaseRepository<T> where T: class
    {
        private readonly BikeManagerDbContext _context;

        public BaseRepository(BikeManagerDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll() => _context.Set<T>();
        public async Task<List<T>> GetAllAsync() => 
            await _context.Set<T>().ToListAsync();

        public virtual async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }


        public virtual async Task AddRange(IList<T> entityRange) =>
            await _context.Set<T>().AddRangeAsync(entityRange);

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRange(IList<T> entityRange)
        {
            _context.Set<T>().UpdateRange(entityRange);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRange(IList<T> entityRange)
        {
            _context.Set<T>().RemoveRange(entityRange);
            await _context.SaveChangesAsync();
        }
    }
}