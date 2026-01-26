using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barber.Domain.Entities;

[Table("appointment_services")]
public class AppointmentService
{
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Column("appointment_id")]
    public Guid AppointmentId { get; set; }
    public Appointment? Appointment { get; set; }
    
    [Column("service_id")]
    public Guid ServiceId { get; set; }
    public ServicesCatalog? Service { get; set; }
}