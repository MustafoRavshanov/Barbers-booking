namespace Barber.Domain.DTOs;

public class CreateClientDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PhoneNumber { get; set; }
}

public class ClientDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PhoneNumber { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
   
}