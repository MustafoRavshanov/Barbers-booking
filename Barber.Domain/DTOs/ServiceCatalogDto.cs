using Barber.Domain.Enums;

namespace Barber.Domain.DTOs;

public class ServiceCatalogDto
{
    public Guid Id { get; set; }
    public ServiceType Type { get; set; }
    public int DurationMinutes {get; set; }
    public decimal Price {get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}

public class CreateServiceCatalogDto
{
    public ServiceType Type { get; set; }
    public int DurationMinutes {get; set; }
    public decimal Price {get; set; }
}

public class UpdateServiceCatalogDto
{
    public ServiceType Type { get; set; }
    public int DurationMinutes {get; set; }
    public decimal Price {get; set; }
}