
using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class UserEntity
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = null!; 
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public int RolesId { get; set; }
    public RolesEntity Roles { get; set; } = null!;

}
