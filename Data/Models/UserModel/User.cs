using Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Data.Models.UserModel;

public class User
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public int RolesId { get; set; }
    public RolesEntity roles { get; set; } = null!;
}
