namespace Barber.Domain.DTOs;

public class FullBarberInformationDto
{
    public BarbersDto Barber { get; set; } = null!;
    public LocationDto? Location { get; set; }
    public required WorkingHourDto WorkingHour { get; set; }
}

public class CreateFullBarberInformationDto
{
    public CreateBarberDto Barber { get; set; } = null!;
    public CreateLocationDto? Location { get; set; }
    public required CreateWorkingHourDto WorkingHour { get; set; }
}
