using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Domain.DTOs
{
    public class BarberServiceCatalogDto
    {
        public Guid BarberId { get; set; }
        public Guid ServiceId { get; set; }
        public decimal Price { get; set; }
        public int DurationMinutes { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }

    public class CreateBarberServiceCatalogDto
    {
        public Guid BarberId { get; set; }
        public Guid ServiceId { get; set; }
        public decimal Price { get; set; }
        public int DurationMinutes { get; set; }
    }

    public class UpdateBarberServiceCatalogDto
    {
        public Guid ServiceId { get; set; }
        public decimal Price { get; set; }
        public int DurationMinutes { get; set; }
    }
}
