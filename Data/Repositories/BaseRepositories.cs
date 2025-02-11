
using System.Linq.Expressions;
using Data.Contexts;
using Data.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.Repositories;

public abstract class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DataContext _context = context;
    private readonly DbSet<TEntity> _dbset = context.Set<TEntity>();
    private IDbContextTransaction _transaction = null!;

    #region Transaction Management

    public virtual async Task BeginTransactionAsync()
    {
        _transaction ??= await _context.Database.BeginTransactionAsync();
    }

    public virtual async Task CommitTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null!;
        }
    }

    public virtual async Task RollBackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null!;
        }
    }


    #endregion


    #region CRUD

    public virtual async Task AddAsync(TEntity entity)
    {           
       
            await _dbset.AddAsync(entity);           
       

    }

    public virtual async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public virtual async Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>> expression)
    {
        var entity = await _dbset.FirstOrDefaultAsync(expression);
        return entity;

    }



    public virtual async Task<IEnumerable<TEntity?>> GetAllAsync()
    {
        var entities = await _dbset.ToListAsync();
        return entities;
    }

    public virtual void Update(TEntity entity)
    {
        _dbset.Update(entity);
    }

    //public virtual async Task<TEntity> UpdateOneAsync(Expression<Func<TEntity, bool>> expression, TEntity updatedEntity)
    //{
    //    if (updatedEntity == null)
    //        return null!;

    //    try
    //    {
    //        var existingEntity = await _dbset.FirstOrDefaultAsync(expression) ?? null!;
    //        if (existingEntity == null)
    //            return null!;

    //        _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
    //        await _context.SaveChangesAsync();
    //        return updatedEntity;
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine($"Error creating {nameof(TEntity)} :: {ex.Message}");
    //        return null!;
    //    }

    //}

    public virtual void Delete(TEntity entity)
    {
        _dbset.Remove(entity);
    }

    //public virtual async Task<bool> DeleteOneAsync(Expression<Func<TEntity, bool>> expression)
    //{
    //    if (expression == null)
    //        return false;
    //    try
    //    {
    //        var existingEntity = await _dbset.FirstOrDefaultAsync(expression) ?? null!;
    //        if (existingEntity == null)
    //            return false;

    //        _dbset.Remove(existingEntity);
    //        await _context.SaveChangesAsync();
    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine($"Error deleting {nameof(TEntity)} :: {ex.Message}");
    //        return false;
    //    }
    //}

    #endregion
}
