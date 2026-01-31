using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barber.Domain.Entities;

[Table("clients")]
public class Client
{
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }=Guid.NewGuid();
    
    [Column("first_name")]
    public required string FirstName { get; set; }
    
    [Column("last_name")]
    public required string LastName { get; set; }
    
    [Column("phone_number")]
    public required string PhoneNumber { get; set; }
    
    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; }= DateTimeOffset.UtcNow;

    public ICollection<Appointment> Appointments { get; set; } = [];
}