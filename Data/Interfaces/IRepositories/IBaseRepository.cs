using System.Linq.Expressions;

namespace Data.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        
        void Delete(TEntity entity);
        Task<IEnumerable<TEntity?>> GetAllAsync();
        Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>> expression);
        
        void Update(TEntity entity);
        Task<int> SaveAsync();
    }
}