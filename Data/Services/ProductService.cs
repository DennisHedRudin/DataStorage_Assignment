using Data.Contexts;
using Data.Entities;
using Data.Interfaces.IServices;
using Data.Interfaces.Repositories;
using Data.Repositories;
using Infrastructure.Models;

namespace Data.Services;

public class ProductService(ProductRepository productRepository, DataContext context) 
{
    private readonly ProductRepository _productRepository = productRepository;
    private readonly DataContext _context = context;

    public async Task<ResponseResult<ProductEntity?>> GetProductAsync(int id)
    {
        var entity = await _productRepository.GetOneAsync(x => x.Id == id);
        return new ResponseResult<ProductEntity?>(true, 201, "Project created successfully", entity);
    }

    public async Task<ResponseResult<IEnumerable<ProductEntity?>>> GetAllAsync()
    {
        var entities = await _productRepository.GetAllAsync();
        return new ResponseResult<IEnumerable<ProductEntity?>>(true, 200, null, entities);
    }
}

