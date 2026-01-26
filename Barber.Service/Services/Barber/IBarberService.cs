using Barber.Domain.DTOs;

namespace Barber.Service.Services.Barber;

public interface IBarberService
{
    ValueTask<BarbersDto> AddBarberAsync(BarbersDto barberDto);
    IQueryable<BarbersDto> RetrieveAllBarbers();
    ValueTask<BarbersDto> RetrieveBarberById(Guid id);
    ValueTask<BarbersDto> ModifyBarberAsync(BarbersDto barberDto,Guid id);
}