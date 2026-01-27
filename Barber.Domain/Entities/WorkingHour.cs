using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barber.Domain.Entities;

[Table("working_hours")]
public class WorkingHour
{
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }=Guid.NewGuid();
    
    [Column("day")]
    public DayOfWeek Day { get; set; }
    
    [Column("start_time")]
    public TimeSpan StartTime { get; set; }
    
    [Column("start_breaking_time")]
    public TimeSpan StartBreakingTime { get; set; }
    
    [Column("end_breaking_time")]
    public TimeSpan EndBreakingTime { get; set; }
    
    [Column("end_time")]
    public TimeSpan EndTime { get; set; }
    
    [Column("barber_id")]
    public Guid BarberId { get; set; }
    public Barbers? Barber { get; set; }
    
    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; }
}