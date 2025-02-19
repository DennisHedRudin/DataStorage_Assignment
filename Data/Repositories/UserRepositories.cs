using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class UserRepositories(DataContext context) : BaseRepository<UserEntity>(context), IUserRepository
{

    private new readonly DataContext _context = context;

    public override async Task<UserEntity?> GetOneAsync(Expression<Func<UserEntity, bool>> expression)
    {
        var entity = await _context.Users
            .Include(x => x.roles)
            .FirstOrDefaultAsync(expression);

        return entity;
    }

    public override async Task<IEnumerable<UserEntity?>> GetAllAsync()
    {
        var entities = await _context.Users
            .Include(x => x.roles)
            .ToListAsync();

        return entities;


    }

}