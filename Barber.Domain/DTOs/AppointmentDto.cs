using Barber.Domain.Enums;

namespace Barber.Domain.DTOs;

public class AppointmentDto
{
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
    public decimal Price { get; set; }
    public AppointmentStatus  Status { get; set; }
    public DateTimeOffset CreatedAt {get;set; }
}

public class CreateAppointmentDto
{
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
    public decimal Price { get; set; }
    public AppointmentStatus  Status { get; set; }
}

public class UpdateAppointmentDto
{
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
    public decimal Price { get; set; }
    public AppointmentStatus  Status { get; set; }
}
