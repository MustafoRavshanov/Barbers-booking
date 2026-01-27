namespace Barber.Domain.DTOs;

public class BarbersDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PhoneNumber { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public required string RoomName { get; set; }
}

public class CreateBarberDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PhoneNumber { get; set; }
    public required string RoomName { get; set; }
}

public class UpdateBarberDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PhoneNumber { get; set; }
    public required string RoomName { get; set; }
}