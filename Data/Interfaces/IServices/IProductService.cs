using Data.Entities;
using Data.Interfaces.Repositories;
using Infrastructure.Models;

namespace Data.Interfaces.IServices;

public interface IProductService : IBaseRepository<ProductEntity>
{
    Task<ProductEntity?> GetProductAsync(int id);

    Task<IEnumerable<ProductEntity?>> GetAllAsync();
}
