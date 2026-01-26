using AutoMapper;
using Barber.Domain.DTOs;
using Barber.Domain.Entities;

namespace Barber;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Client, ClientDto>().ReverseMap();
        CreateMap<Appointment, AppointmentDto>().ReverseMap();
        CreateMap<Barbers, BarbersDto>().ReverseMap();
        CreateMap<Location, LocationDto>().ReverseMap();
        CreateMap<ServicesCatalog, ServiceCatalogDto>().ReverseMap();
        
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
    }
}