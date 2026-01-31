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
    
    [Column("type")]
    public ServiceType Type { get; set; }

    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public ICollection<AppointmentAndService> AppointmentServices { get; set; } = [];
    public ICollection<BarberServiceCatalog> BarberServiceCatalogs { get; set; } = [];
}