using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Domain.Entities
{
    [Table("barber_service_catalog")]
    public class BarberServiceCatalog
    {
        [Column("barber_id")]
        public Guid BarberId { get; set; }
        public Barbers? Barber { get; set; }

        [Column("service_id")]
        public Guid ServiceId { get; set; }
        public ServicesCatalog? Service { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("duration_minutes")]
        public int DurationMinutes { get; set; }

        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
