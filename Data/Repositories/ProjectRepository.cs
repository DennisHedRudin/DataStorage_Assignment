using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{

    
    public override async Task<ProjectEntity?> GetOneAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        var entity = await _context.Projects
            .Include(x => x.CustomerId)
            .Include(x => x.StatusId)
            .Include(x => x.UserId) 
            .Include(x => x.ProductId)            
            .FirstOrDefaultAsync(expression);

        return entity;
    }

    public override async Task<IEnumerable<ProjectEntity?>> GetAllAsync()
    {
        var entities = await _context.Projects
            .Include(x => x.CustomerId)
            .Include(x => x.StatusId)
            .Include(x => x.UserId)
            .Include(x => x.ProductId)
            .ToListAsync();

        return entities;


    }

}

