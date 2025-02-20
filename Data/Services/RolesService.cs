using Data.Contexts;
using Data.Entities;
using Data.Interfaces.Repositories;
using Data.Repositories;
using Infrastructure.Models;

namespace Data.Services;

public class RolesService(RolesRepository rolesRepository, DataContext context)
{
    private readonly RolesRepository _rolesRepository = rolesRepository;
    private readonly DataContext _context = context;

    public async Task<RolesEntity?> GetRoleAsync(int id)
    {
        var entity = await _rolesRepository.GetOneAsync(x => x.Id == id);
        return entity;
    }

    public async Task<IEnumerable<RolesEntity?>> GetAllAsync()
    {
        var entities = await _rolesRepository.GetAllAsync();
        return entities;
    }
}

