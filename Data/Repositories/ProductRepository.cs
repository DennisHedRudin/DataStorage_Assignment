using Data.Contexts;
using Data.Entities;
using Data.Interfaces.Repositories;

namespace Data.Repositories;

public class ProductRepository(DataContext context) : BaseRepository<ProductEntity>(context), IProductRepository
{
    
}
