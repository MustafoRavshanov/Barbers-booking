namespace Barber.Domain.DTOs;

public class CreateLocationDto
{
    public required string Country { get; set; }
    public required string Region { get; set; }
    public required string District { get; set; }
    public required string Street { get; set; }
    public int HouseNumber { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
}

public class LocationDto
{
    public Guid Id { get; set; }
    public required string Country { get; set; }
    public required string Region { get; set; }
    public required string District { get; set; }
    public required string Street { get; set; }
    public int HouseNumber { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
}

public class UpdateLocationDto
{
    public required string Country { get; set; }
    public required string Region { get; set; }
    public required string District { get; set; }
    public required string Street { get; set; }
    public int HouseNumber { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
}