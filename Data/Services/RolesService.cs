using Data.Contexts;
using Data.Repositories;

namespace Data.Services;

public class RolesService(RolesRepository rolesRepository, DataContext context)
{
    private readonly RolesRepository _rolesRepository = rolesRepository;
    private readonly DataContext _context = context;


}

