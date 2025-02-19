using Data.Contexts;
using Data.Entities;
using Data.Interfaces.IServices;
using Data.Repositories;

namespace Data.Services;

public class ProductService(ProductRepository productRepository, DataContext context) 
{
    private readonly ProductRepository _productRepository = productRepository;
    private readonly DataContext _context = context;


}

