using Data.Contexts;
using Data.Entities;
using Data.Interfaces.IServices;
using Data.Interfaces.Repositories;


namespace Data.Services;

public class CustomerContactService(DataContext context) : IBaseRepository<CustomerContactEntity>(context), ICustomerContactService
{

    private readonly DataContext _context = context;


}

