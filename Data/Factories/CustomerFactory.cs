using Data.Entities;
using Data.Models.CustomerModel;

namespace Data.Factories;

public class CustomerFactory
{
    public static CustomerEntity Create (CustomerRegistrationForm form)
    {
        return new CustomerEntity
        {
            CustomerName = form.CustomerName,
        };
    }

    public static Customer Create (CustomerEntity entity)
    {
        return new Customer
        {
            Id = entity.Id,
            CustomerName = entity.CustomerName,
        };
    }
}
