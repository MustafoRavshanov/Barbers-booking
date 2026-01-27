using Barber.Domain.DTOs;
using Barber.Domain.Helper;

namespace Barber.Service.Services.Locations;

public interface ILocationService
{
    Task<ResponseModel<LocationDto>> AddAsync(CreateLocationDto createLocationDto);
    Task<TableResponse<List<LocationDto>>> GetAllAsync(TableOptions options);
    Task<ResponseModel<LocationDto>> GetByIdAsync(Guid id);
    Task<ResponseModel<LocationDto>> UpdateAsync(UpdateLocationDto updateLocationDto, Guid id);
    Task<ResponseModel<bool>> RemoveAsync(Guid id);
}