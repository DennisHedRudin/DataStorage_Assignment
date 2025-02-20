
using Data.Contexts;
using Data.Entities;
using Data.Repositories;
using Infrastructure.Models;

namespace Data.Services;

public class StatusService(StatusRepository statusRepository, DataContext context)
{
    private readonly StatusRepository _statusRepository = statusRepository;
    private readonly DataContext _context = context;

    public async Task<StatusTypeEntity?> GetStatusAsync(int id)
    {
        var entity = await _statusRepository.GetOneAsync(x => x.Id == id);
        return entity;
    }

    public async Task<IEnumerable<StatusTypeEntity?>> GetAllAsync()
    {
        var entities = await _statusRepository.GetAllAsync();
        return entities;
    }
}

