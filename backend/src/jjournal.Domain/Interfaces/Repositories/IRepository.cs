using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace jjournal.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, int pageSize = 0, int pageNumber = 1);
        Task<T?> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
        Task<EntityEntry<T>> CreateAsync(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
