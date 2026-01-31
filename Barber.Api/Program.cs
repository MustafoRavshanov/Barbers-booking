using Barber.Infrastructure.Data;
using Barber.Service.Helper;
using Barber.Service.Services.AppointmentAndServices;
using Barber.Service.Services.Appointments;
using Barber.Service.Services.Barber;
using Barber.Service.Services.BarberAndServiceCatalogs;
using Barber.Service.Services.Clients;
using Barber.Service.Services.Locations;
using Barber.Service.Services.ServiceCatalogs;
using Barber.Service.Services.WorkingHours;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddTransient<IAppointmentService, AppointmentService>();
builder.Services.AddTransient<IBarberService, BarberService>();
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<ILocationService, LocationService>();
builder.Services.AddTransient<IServiceCatalogService, ServiceCatalogService>();
builder.Services.AddTransient<IWorkingHourService, WorkingHourService>();
builder.Services.AddTransient<IBarberAndServiceCatalogsService, BarberAndServiceCatalogService>();
builder.Services.AddTransient<IAppointmentAndServiceCatalogService, AppointmentAndServiceCatalogService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();