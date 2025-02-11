
using Data.Entities;
using Data.Models.CustomerContactModel;


namespace Data.Factories;

public class CustomerContactFactory
{
    public static CustomerContactEntity Create(CustomerContactRegistrationForm form)
    {
        return new CustomerContactEntity
        {
            FirstName = form.FirstName,
            LastName = form.LastName,
        };
    }

    public static CustomerContact Create(CustomerContactEntity entity)
    {
        return new CustomerContact
        {
           
            FirstName = entity.FirstName,
            LastName = entity.LastName,
        };
    }
}
