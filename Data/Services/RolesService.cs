using Data.Contexts;
using Data.Entities;
using Data.Interfaces.IServices;

namespace Data.Services;

public class RolesService(DataContext context) : BaseService<RolesEntity>(context), IRolesService
{

    private readonly DataContext _context = context;


}

