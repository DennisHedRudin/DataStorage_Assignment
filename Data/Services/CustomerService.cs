
using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces.IServices;
using Data.Interfaces.Repositories;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;



namespace Data.Services;

public class CustomerService(DataContext context, CustomerRepository customerRepository) 
{
    private readonly CustomerRepository _customerRepository = customerRepository;
    private readonly DataContext _context = context;

    public async Task<CustomerEntity?> GetOneAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        var entity = await _context.Customer
            .Include(x => x.CustomerContacts)
            .FirstOrDefaultAsync(expression);

        return entity;
    }

    public async Task<IEnumerable<CustomerEntity?>> GetAllAsync()
    {
        var entities = await _context.Customer
            .Include(x => x.CustomerContacts)
            .ToListAsync();

        return entities;


    }


}


