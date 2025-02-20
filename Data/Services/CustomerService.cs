
using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces.IServices;
using Data.Interfaces.Repositories;
using Data.Repositories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;



namespace Data.Services;

public class CustomerService(DataContext context, CustomerRepository customerRepository) 
{
    private readonly CustomerRepository _customerRepository = customerRepository;
    private readonly DataContext _context = context;

    public async Task<CustomerEntity?> GetCustomerAsync(int id)
    {
        var entity = await _customerRepository.GetOneAsync(x => x.Id == id);
        return entity;
    }

    public async Task<IEnumerable<CustomerEntity?>> GetAllAsync()
    {
        var entities = await _customerRepository.GetAllAsync();
        return entities;
    }


}


