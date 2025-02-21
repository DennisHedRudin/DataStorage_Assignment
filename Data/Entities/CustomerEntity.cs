using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class CustomerEntity
{
    [Key]
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public int CustomerContactId { get; set; }
    public CustomerContactEntity Contact { get; set; } = null!;
}
