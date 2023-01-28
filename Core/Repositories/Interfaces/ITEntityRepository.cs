using System.Linq.Expressions;

namespace Studio.Core.Repositories.Interfaces
{
    public interface ITEntityRepository<T>
        where T:class,new()
    {
        Task<List<T>> GetAllAsync(Expression<Func<T,bool>> exp, params string[]? includes);
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T model);
        Task SaveAsync();
    }
}
