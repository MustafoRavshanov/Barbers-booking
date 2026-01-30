namespace Barber.Domain.DTOs;

public class FullBarberInformationDto
{
    public BarbersDto Barber { get; set; } = null!;
    public LocationDto? Location { get; set; }
    public required WorkingHourDto WorkingHour { get; set; }
}
