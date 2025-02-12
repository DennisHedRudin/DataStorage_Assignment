using Data.Entities;
using Data.Interfaces.Repositories;

namespace Data.Interfaces.IServices;

public interface ICustomerContactService : IBaseRepository<CustomerEntity>
{
}
