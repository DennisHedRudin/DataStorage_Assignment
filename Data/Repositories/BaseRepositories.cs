
using System.Diagnostics;
using System.Linq.Expressions;
using Data.Contexts;
using Data.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.Repositories;

public abstract class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DataContext _context = context;
    protected readonly DbSet<TEntity> _dbset = context.Set<TEntity>();
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

    public virtual async Task<bool> AddAsync(TEntity entity)
    {
        try
        {
            _dbset.Add(entity);
            await _dbset.AddAsync(entity);
            return true;
        }
        catch (Exception ex) 
        {

        Debug.WriteLine(ex);
            return false;
        }
                  
       

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

    public virtual async Task<bool> Update(TEntity entity)
    {
        try
        {
            _dbset.Update(entity);
            await _dbset.AddAsync(entity);
            return true;
        }
        catch (Exception ex)
        {

            Debug.WriteLine(ex);
            return false;
        }
        
    }

    
    public virtual async Task<bool> Delete(TEntity entity)
    {
        try
        {
            _dbset.Remove(entity);
            await _dbset.AddAsync(entity);
            return true;
        }
        catch (Exception ex)
        {

            Debug.WriteLine(ex);
            return false;
        }
        
    }

 

    #endregion
}
