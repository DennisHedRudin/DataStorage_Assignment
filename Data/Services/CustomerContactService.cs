using Data.Contexts;
using Data.Entities;
using Data.Interfaces.IServices;
using Data.Repositories;
using Infrastructure.Models;


namespace Data.Services;

public class CustomerContactService(CustomerContactRepository repository, DataContext context )
{
    private readonly CustomerContactRepository _repository = repository;
    private readonly DataContext _context= context;

    public async Task<CustomerContactEntity?> GetContactAsync(int id)
    {
        var entity = await _repository.GetOneAsync(x => x.Id == id);
        return entity;
    }

    public async Task<IEnumerable<CustomerContactEntity?>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return entities;
    }

}

