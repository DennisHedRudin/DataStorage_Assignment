
using Data.Entities;

namespace Data.Models.UserModel;

public class UserRegistrationForm
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public int RolesId { get; set; }
    public RolesEntity roles { get; set; } = null!;
}
