using Microsoft.EntityFrameworkCore;
using Studio.Core.Repositories.Interfaces;
using Studio.DAL;
using System.Linq.Expressions;

namespace Studio.Core.Repositories.Implementations
{
    public class TEntityRepository<T> : ITEntityRepository<T>
        where T : class, new()
    {
        private readonly AppDbContext _db;

        public TEntityRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> exp, params string[]? includes)
        {
            IQueryable<T> query = _db.Set<T>().Where(exp);
            if(includes is not null)
            {
                foreach (var item in includes)
                {
                    query.Include(item);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        => await _db.Set<T>().FindAsync(id);

        public async Task CreateAsync(T model)
        {
            await _db.Set<T>().AddAsync(model);    
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
