using Data.Entities;
using Data.Interfaces.Repositories;
using Infrastructure.Models;


namespace Data.Interfaces.IServices;

public interface ICustomerService : IBaseRepository<CustomerEntity>
{
    Task<CustomerEntity?> GetCustomerAsync(int id);

    Task<IEnumerable<CustomerEntity?>> GetAllAsync();
}
