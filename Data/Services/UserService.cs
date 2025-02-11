using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;

namespace Data.Services;

public class UserService(DataContext context) : BaseService<UserEntity>(context), IUserService
{

    private readonly DataContext _context = context;

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

