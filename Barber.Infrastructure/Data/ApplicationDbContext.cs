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
    public DbSet<BarberServiceCatalog> BarberServiceCatalogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BarberServiceCatalog>()
       .HasKey(bs => new { bs.BarberId, bs.ServiceId });

        modelBuilder.Entity<BarberServiceCatalog>()
            .HasOne(bs => bs.Barber)
            .WithMany(b => b.BarberServiceCatalogs)
            .HasForeignKey(bs => bs.BarberId);

        modelBuilder.Entity<BarberServiceCatalog>()
            .HasOne(bs => bs.Service)
            .WithMany(s => s.BarberServiceCatalogs)
            .HasForeignKey(bs => bs.ServiceId);


        modelBuilder.Entity<AppointmentService>()
            .HasKey(asg => new { asg.AppointmentId, asg.ServiceId });

        modelBuilder.Entity<AppointmentService>()
            .HasOne(asg => asg.Appointment)
            .WithMany(a => a.AppointmentServices)
            .HasForeignKey(asg => asg.AppointmentId);

        modelBuilder.Entity<AppointmentService>()
            .HasOne(asg => asg.Service)
            .WithMany(s => s.AppointmentServices)
            .HasForeignKey(asg => asg.ServiceId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connection);
    }
}