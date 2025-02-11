using Data.Contexts;
using Data.Entities;
using Data.Interfaces.Repositories;

namespace Data.Repositories;

public class RolesRepository(DataContext context) : BaseRepository<RolesEntity>(context), IRolesRepository
{
    private readonly DataContext _context = context;
}

