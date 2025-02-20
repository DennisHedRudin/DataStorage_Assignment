using Data.Entities;
using Data.Interfaces.Repositories;
using Infrastructure.Models;

namespace Data.Interfaces.IServices;

public interface ICustomerContactService : ICustomerContactRepository
{
    Task<CustomerContactEntity?> GetContactAsync(int id);

    Task<IEnumerable<CustomerContactEntity?>> GetAllAsync();
}
