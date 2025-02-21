using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class CustomerContactEntity
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
   

}
