using System.Diagnostics;
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
            .Include(x => x.Customer)
            .Include(x => x.Status)
            .Include(x => x.User) 
            .Include(x => x.Product)            
            .FirstOrDefaultAsync(expression);

        return entity;
    }

    public override async Task<IEnumerable<ProjectEntity?>> GetAllAsync()
    {
        try
        {
            var entities = await _context.Projects
           .Include(x => x.Customer)
           .Include(x => x.Status)
           .Include(x => x.User)
           .Include(x => x.Product)
           .ToListAsync();

            return entities;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error retrieving projects :: {ex.Message}");
            return null!;
        }     

        


    }

}

