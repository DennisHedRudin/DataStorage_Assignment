
using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;



namespace Data.Services;

public class CustomerService(DataContext context) : BaseService<CustomerEntity>(context), ICustomerService
{

    private readonly DataContext _context = context;

    public override async Task<CustomerEntity?> GetOneAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        var entity = await _context.Customer
            .Include(x => x.CustomerContacts)
            .FirstOrDefaultAsync(expression);

        return entity;
    }

    public override async Task<IEnumerable<CustomerEntity?>> GetAllAsync()
    {
        var entities = await _context.Customer
            .Include(x => x.CustomerContacts)
            .ToListAsync();

        return entities;


    }


}


