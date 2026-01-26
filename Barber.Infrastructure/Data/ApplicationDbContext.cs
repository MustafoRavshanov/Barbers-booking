using Barber.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Barber.Infrastructure.Data;

public class ApplicationDbContext(IConfiguration configuration):DbContext
{
    private readonly string? _connection=configuration.GetConnectionString("DefaultConnection");
    
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentService> AppointmentServices { get; set; }
    public DbSet<Barbers> Barbers { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<ServicesCatalog> ServicesCatalog { get; set; }
    public DbSet<WorkingHour>  WorkingHours { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connection);
    }
}