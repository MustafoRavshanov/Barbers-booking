using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Barber.Domain.Enums;

namespace Barber.Domain.Entities;

[Table("appointments")]
public class Appointment
{
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }=Guid.NewGuid();
    
    [Column("barber_id")]
    public Guid BarberId { get; set; }
    public Barbers? Barber { get; set; }
    
    [Column("client_id")]
    public Guid ClientId { get; set; }
    public Client? Client { get; set; }
    
    [Column("start_time")]
    public DateTimeOffset StartTime { get; set; }
    
    [Column("end_time")]
    public DateTimeOffset EndTime { get; set; }
    
    [Column("price")]
    public decimal Price { get; set; }

    [Column("status")]
    public AppointmentStatus Status { get; set; } = AppointmentStatus.Booked;

    [Column("created_at")] public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    
    public ICollection<AppointmentService> AppointmentServices { get; set; } = [];
}