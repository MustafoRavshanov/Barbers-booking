using Barber.Domain.DTOs;
using Barber.Domain.Helper;

namespace Barber.Service.Services.Barber;

public interface IBarberService
{
    Task<ResponseModel<BarbersDto>> AddAsync(CreateBarberDto createBarberDto);
    Task<TableResponse<List<BarbersDto>>> GetAllAsync(TableOptions options);
    Task<ResponseModel<BarbersDto>> GetByIdAsync(Guid id);
    Task<ResponseModel<BarbersDto>> UpdateAsync(UpdateBarberDto updateBarberDto, Guid id);
}