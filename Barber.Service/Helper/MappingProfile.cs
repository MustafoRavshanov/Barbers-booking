using AutoMapper;
using Barber.Domain.DTOs;
using Barber.Domain.Entities;

namespace Barber.Service.Helper;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Client, ClientDto>().ReverseMap();
        CreateMap<Client,  UpdateClientDto>().ReverseMap();
        
        CreateMap<Appointment, AppointmentDto>().ReverseMap();
        CreateMap<Appointment, UpdateAppointmentDto>().ReverseMap();
        
        CreateMap<Barbers, BarbersDto>().ReverseMap();
        CreateMap<Barbers, UpdateBarberDto>().ReverseMap();
        
        CreateMap<Location, LocationDto>().ReverseMap();
        CreateMap<Location, UpdateLocationDto>().ReverseMap();
        
        CreateMap<ServicesCatalog, ServiceCatalogDto>().ReverseMap();
        CreateMap<ServicesCatalog, UpdateServiceCatalogDto>().ReverseMap();
        
        CreateMap<WorkingHour, WorkingHourDto>().ReverseMap();
        CreateMap<WorkingHour, UpdateWorkingHourDto>().ReverseMap();
        
        CreateMap<Client, CreateClientDto>()
            .ReverseMap().ForMember(
                dest=>dest.CreatedAt,
                opt=>opt
                    .MapFrom(_=>DateTimeOffset.UtcNow));
        
        CreateMap<Barbers, CreateBarberDto>()
            .ReverseMap().ForMember(
                dest=>dest.CreatedAt,
                opt=>opt
                    .MapFrom(_=>DateTimeOffset.UtcNow));

        CreateMap<Location, CreateLocationDto>()
            .ReverseMap().ForMember(
                dest => dest.CreatedAt,
                opt => opt
                    .MapFrom(_ => DateTimeOffset.UtcNow));
        
        CreateMap<WorkingHour, CreateWorkingHourDto>()
            .ReverseMap().ForMember(
                dest => dest.CreatedAt,
                opt => opt
                    .MapFrom(_ => DateTimeOffset.UtcNow));
        
        CreateMap<ServicesCatalog, CreateServiceCatalogDto>()
            .ReverseMap().ForMember(
                dest => dest.CreatedAt,
                opt => opt
                    .MapFrom(_ => DateTimeOffset.UtcNow));
        
        CreateMap<Appointment, CreateAppointmentDto>()
            .ReverseMap().ForMember(
                dest => dest.CreatedAt,
                opt => opt
                    .MapFrom(_ => DateTimeOffset.UtcNow));
        
    }
}