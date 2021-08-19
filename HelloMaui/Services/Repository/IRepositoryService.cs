using HelloMaui.Models;
using System.Linq.Expressions;

namespace HelloMaui.Services.Repository
{
    public interface IRepositoryService
    {
        Task AddAsync<T>(T entity) where T : IEntityBase, new();
        Task RemoveAsync<T>(T entity) where T : IEntityBase, new();
        Task UpdateAsync<T>(T entity) where T : IEntityBase, new();

        Task<IEnumerable<T>> GetAsync<T>(Expression<Func<T, bool>> pred = null) where T : IEntityBase, new();
        Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> pred = null) where T : IEntityBase, new();
    }
}
