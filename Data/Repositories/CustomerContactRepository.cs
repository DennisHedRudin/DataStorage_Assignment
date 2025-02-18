using Data.Contexts;
using Data.Entities;
using Data.Interfaces.Repositories;

namespace Data.Repositories;

public class CustomerContactRepository(DataContext context) : BaseRepository<CustomerContactEntity>(context), ICustomerContactRepository
{
    
}
