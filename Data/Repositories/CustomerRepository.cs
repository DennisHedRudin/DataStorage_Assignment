using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;



namespace Data.Repositories;

public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context), ICustomerRepository
{

    
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
