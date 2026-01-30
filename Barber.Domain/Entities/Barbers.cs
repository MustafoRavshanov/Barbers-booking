using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barber.Domain.Entities;

[Table("barbers")]
public class Barbers
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
    public DateTimeOffset CreatedAt { get; set; }
    
    [Column("room_name")]
    public required string RoomName { get; set; }

    [Column("location_id")]
    public Guid LocationId { get; set; }
    public Location? Location { get; set; }

    public ICollection<WorkingHour> WorkingHours { get; set; } = [];
    public ICollection<Appointment> Appointments { get; set; } = [];
    public ICollection<BarberServiceCatalog> BarberServiceCatalogs { get; set; } = [];
}