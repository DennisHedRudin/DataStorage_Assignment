using Data.Entities;

namespace Data.Models.CustomerContactModel;

public class CustomerContact
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;
}
