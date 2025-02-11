using Data.Contexts;
using Data.Entities;
using Data.Interfaces.IServices;


namespace Data.Services;

public class CustomerContactService(DataContext context) : BaseService<CustomerContactEntity>(context), ICustomerContactService
{

    private readonly DataContext _context = context;


}

