using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barber.Domain.Entities;

[Table("appointment_services")]
public class AppointmentAndService
{
    [Column("appointment_id")]
    public Guid AppointmentId { get; set; }
    public Appointment? Appointment { get; set; }
    
    [Column("service_id")]
    public Guid ServiceId { get; set; }
    public ServicesCatalog? Service { get; set; }

    [Column("price")]
    public decimal Price { get; set; }

    [Column("duration_minutes")]
    public int DurationMinutes { get; set; }

    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}