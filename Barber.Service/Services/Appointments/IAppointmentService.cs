using Barber.Domain.DTOs;
using Barber.Domain.Helper;

namespace Barber.Service.Services.Appointments;

public interface IAppointmentService
{
    Task<ResponseModel<AppointmentDto>> AddAsync(CreateAppointmentDto appointmentDto);
    Task<TableResponse<List<AppointmentDto>>> GetAllAsync(TableOptions options);
    Task<ResponseModel<AppointmentDto>> GetByIdAsync(Guid id);
    Task<ResponseModel<AppointmentDto>> UpdateAsync(UpdateAppointmentDto appointmentDto, Guid id);
    Task<ResponseModel<bool>> RemoveAsync(Guid id);
}