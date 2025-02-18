using Data.Contexts;
using Data.Entities;
using Data.Interfaces.IServices;

namespace Data.Services;

public class ProductService(DataContext context) : IProductService
{

    private readonly DataContext _context = context;


}

