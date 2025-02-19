using System.Linq.Expressions;

namespace Data.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<bool> AddAsync(TEntity entity);

        Task<bool> Delete(TEntity entity);
        Task<IEnumerable<TEntity?>> GetAllAsync();
        Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>> expression);

        Task<bool> Update(TEntity entity);
        Task<int> SaveAsync();
    }
}