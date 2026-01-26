using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Barber.Domain.Enums;

namespace Barber.Domain.Entities;

[Table("services_catalogs")]
public class ServicesCatalog
{
    [Column("service_id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }=Guid.NewGuid();
    
    [Column("barber_id")]
    public Guid BarberId { get; set; }
    public Barbers? Barber { get; set; }
    
    [Column("type")]
    public ServiceType Type { get; set; }
    
    [Column("duration_minutes")]
    public int DurationMinutes { get; set; }
    
    [Column("price")]
    public decimal Price { get; set; }

    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; } = DateTime.Now;

    public ICollection<AppointmentService> AppointmentServices { get; set; } = [];
}