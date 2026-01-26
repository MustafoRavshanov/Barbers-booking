using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barber.Domain.Entities;

[Table("locations")]
public class Location
{
    [Column("location_id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Column("country")]
    public required string Country { get; set; }
    
    [Column("city")]
    public required string City { get; set; }
    
    [Column("region")]
    public required string Region { get; set; }
    
    [Column("street")]
    public required string Street { get; set; }

    [Column("house_number")]
    public int HouseNumber { get; set; }
    
    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; }
    
    [Column("latitude")]
    public decimal Latitude { get; set; }
    
    [Column("longitude")]
    public decimal Longitude { get; set; }

    public ICollection<Barbers> Barbers { get; set; } = [];
}