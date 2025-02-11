using Data.Entities;
using Data.Models.CustomerModel;
using Data.Models.ProductModel;

namespace Data.Factories;

public class ProductFactory
{
    public static ProductEntity Create(ProductRegistrationForm form)
    {
        return new ProductEntity
        {
            ProductName = form.ProductName,
            Price = form.Price,
        };
    }

    public static Product Create(ProductEntity entity)
    {
        return new Product
        {
            Id = entity.Id,
            ProductName = entity.ProductName,
            Price = entity.Price,
        };
    }
}
