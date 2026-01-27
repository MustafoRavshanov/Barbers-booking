using Barber.Domain.DTOs;
using Barber.Domain.Helper;

namespace Barber.Service.Services.WorkingHours;

public interface IWorkingHourService
{
    Task<ResponseModel<WorkingHourDto>> AddAsync(CreateWorkingHourDto createWorkingHourDto);
    Task<TableResponse<List<WorkingHourDto>>> GetAllAsync(TableOptions options);
    Task<ResponseModel<WorkingHourDto>> GetByIdAsync(Guid id);
    Task<ResponseModel<WorkingHourDto>> UpdateAsync(UpdateWorkingHourDto updateWorkingHourDto, Guid id);
    Task<ResponseModel<bool>> RemoveAsync(Guid id);
}